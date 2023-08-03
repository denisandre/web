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
   public class ibge_lerapilocalidades_mesorregiao : GXProcedure
   {
      public ibge_lerapilocalidades_mesorregiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ibge_lerapilocalidades_mesorregiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> aP0_IBGE_sdtMesorregiaoCollection )
      {
         this.AV8IBGE_sdtMesorregiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao>( context, "IBGE_sdtMesorregiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_IBGE_sdtMesorregiaoCollection=this.AV8IBGE_sdtMesorregiaoCollection;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> executeUdp( )
      {
         execute(out aP0_IBGE_sdtMesorregiaoCollection);
         return AV8IBGE_sdtMesorregiaoCollection ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> aP0_IBGE_sdtMesorregiaoCollection )
      {
         ibge_lerapilocalidades_mesorregiao objibge_lerapilocalidades_mesorregiao;
         objibge_lerapilocalidades_mesorregiao = new ibge_lerapilocalidades_mesorregiao();
         objibge_lerapilocalidades_mesorregiao.AV8IBGE_sdtMesorregiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao>( context, "IBGE_sdtMesorregiao", "agl_tresorygroup") ;
         objibge_lerapilocalidades_mesorregiao.context.SetSubmitInitialConfig(context);
         objibge_lerapilocalidades_mesorregiao.initialize();
         Submit( executePrivateCatch,objibge_lerapilocalidades_mesorregiao);
         aP0_IBGE_sdtMesorregiaoCollection=this.AV8IBGE_sdtMesorregiaoCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ibge_lerapilocalidades_mesorregiao)stateInfo).executePrivate();
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
         AV8IBGE_sdtMesorregiaoCollection.Clear();
         AV8IBGE_sdtMesorregiaoCollection.FromJSonString(new GeneXus.Programs.core.ibge_lerapilocalidades(context).executeUdp(  "https://servicodados.ibge.gov.br/api/v1/localidades/mesorregioes"), null);
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
         AV8IBGE_sdtMesorregiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao>( context, "IBGE_sdtMesorregiao", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> aP0_IBGE_sdtMesorregiaoCollection ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> AV8IBGE_sdtMesorregiaoCollection ;
   }

}
