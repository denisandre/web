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
   public class tb_clientepj_enderecoloadredundancy : GXProcedure
   {
      public tb_clientepj_enderecoloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_clientepj_enderecoloadredundancy( IGxContext context )
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
         tb_clientepj_enderecoloadredundancy objtb_clientepj_enderecoloadredundancy;
         objtb_clientepj_enderecoloadredundancy = new tb_clientepj_enderecoloadredundancy();
         objtb_clientepj_enderecoloadredundancy.context.SetSubmitInitialConfig(context);
         objtb_clientepj_enderecoloadredundancy.initialize();
         Submit( executePrivateCatch,objtb_clientepj_enderecoloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_clientepj_enderecoloadredundancy)stateInfo).executePrivate();
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
         cmdBuffer=" LOCK TABLE tb_clientepj_endereco IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor TB_CLIENTE2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_endereco");
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_clientepj_enderecoloadredundancy__default(),
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

   public class tb_clientepj_enderecoloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_CLIENTE2;
          prmTB_CLIENTE2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("TB_CLIENTE2", "UPDATE tb_clientepj_endereco SET CpjEndCompleto=CASE  WHEN (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndNumero))))=0) and (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndComplem))))=0) THEN RTRIM(LTRIM(CpjEndEndereco)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) WHEN Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndNumero))))=0) and (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndComplem))))=0) THEN RTRIM(LTRIM(CpjEndEndereco)) || ', ' || RTRIM(LTRIM(CpjEndNumero)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) WHEN (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndNumero))))=0) and Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndComplem))))=0) THEN RTRIM(LTRIM(CpjEndEndereco)) || ', ' || RTRIM(LTRIM(CpjEndNumero)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) ELSE RTRIM(LTRIM(CpjEndEndereco)) || ', ' || RTRIM(LTRIM(CpjEndNumero)) || ' ' || RTRIM(LTRIM(CpjEndComplem)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) END ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_CLIENTE2)
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
