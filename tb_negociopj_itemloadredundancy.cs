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
   public class tb_negociopj_itemloadredundancy : GXProcedure
   {
      public tb_negociopj_itemloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_negociopj_itemloadredundancy( IGxContext context )
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
         tb_negociopj_itemloadredundancy objtb_negociopj_itemloadredundancy;
         objtb_negociopj_itemloadredundancy = new tb_negociopj_itemloadredundancy();
         objtb_negociopj_itemloadredundancy.context.SetSubmitInitialConfig(context);
         objtb_negociopj_itemloadredundancy.initialize();
         Submit( executePrivateCatch,objtb_negociopj_itemloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_negociopj_itemloadredundancy)stateInfo).executePrivate();
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
         cmdBuffer=" LOCK TABLE tb_negociopj_item IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor TB_NEGOCIO2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_negociopj_itemloadredundancy__default(),
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

   public class tb_negociopj_itemloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_NEGOCIO2;
          prmTB_NEGOCIO2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("TB_NEGOCIO2", "UPDATE tb_negociopj_item SET NgpTotal=ROUND(( NgpPreco * CAST(NgpQtde AS NUMERIC(26,10))), 2) ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_NEGOCIO2)
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
