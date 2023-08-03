using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class ibge_lerapilocalidades_regiao : GXProcedure
   {
      public ibge_lerapilocalidades_regiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ibge_lerapilocalidades_regiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> aP0_IBGE_sdtRegiaoCollection )
      {
         this.AV8IBGE_sdtRegiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao>( context, "IBGE_sdtRegiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_IBGE_sdtRegiaoCollection=this.AV8IBGE_sdtRegiaoCollection;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> executeUdp( )
      {
         execute(out aP0_IBGE_sdtRegiaoCollection);
         return AV8IBGE_sdtRegiaoCollection ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> aP0_IBGE_sdtRegiaoCollection )
      {
         ibge_lerapilocalidades_regiao objibge_lerapilocalidades_regiao;
         objibge_lerapilocalidades_regiao = new ibge_lerapilocalidades_regiao();
         objibge_lerapilocalidades_regiao.AV8IBGE_sdtRegiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao>( context, "IBGE_sdtRegiao", "agl_tresorygroup") ;
         objibge_lerapilocalidades_regiao.context.SetSubmitInitialConfig(context);
         objibge_lerapilocalidades_regiao.initialize();
         Submit( executePrivateCatch,objibge_lerapilocalidades_regiao);
         aP0_IBGE_sdtRegiaoCollection=this.AV8IBGE_sdtRegiaoCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ibge_lerapilocalidades_regiao)stateInfo).executePrivate();
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
         AV8IBGE_sdtRegiaoCollection.Clear();
         AV8IBGE_sdtRegiaoCollection.FromJSonString(new GeneXus.Programs.core.ibge_lerapilocalidades(context).executeUdp(  "https://servicodados.ibge.gov.br/api/v1/localidades/regioes"), null);
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
         AV8IBGE_sdtRegiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao>( context, "IBGE_sdtRegiao", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> aP0_IBGE_sdtRegiaoCollection ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> AV8IBGE_sdtRegiaoCollection ;
   }

}
