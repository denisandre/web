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
   public class ibge_lerapilocalidades_microrregiao : GXProcedure
   {
      public ibge_lerapilocalidades_microrregiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ibge_lerapilocalidades_microrregiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> aP0_IBGE_sdtMicrorregiaoCollection )
      {
         this.AV8IBGE_sdtMicrorregiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao>( context, "IBGE_sdtMicrorregiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_IBGE_sdtMicrorregiaoCollection=this.AV8IBGE_sdtMicrorregiaoCollection;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> executeUdp( )
      {
         execute(out aP0_IBGE_sdtMicrorregiaoCollection);
         return AV8IBGE_sdtMicrorregiaoCollection ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> aP0_IBGE_sdtMicrorregiaoCollection )
      {
         ibge_lerapilocalidades_microrregiao objibge_lerapilocalidades_microrregiao;
         objibge_lerapilocalidades_microrregiao = new ibge_lerapilocalidades_microrregiao();
         objibge_lerapilocalidades_microrregiao.AV8IBGE_sdtMicrorregiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao>( context, "IBGE_sdtMicrorregiao", "agl_tresorygroup") ;
         objibge_lerapilocalidades_microrregiao.context.SetSubmitInitialConfig(context);
         objibge_lerapilocalidades_microrregiao.initialize();
         Submit( executePrivateCatch,objibge_lerapilocalidades_microrregiao);
         aP0_IBGE_sdtMicrorregiaoCollection=this.AV8IBGE_sdtMicrorregiaoCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ibge_lerapilocalidades_microrregiao)stateInfo).executePrivate();
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
         AV8IBGE_sdtMicrorregiaoCollection.Clear();
         AV8IBGE_sdtMicrorregiaoCollection.FromJSonString(new GeneXus.Programs.core.ibge_lerapilocalidades(context).executeUdp(  "https://servicodados.ibge.gov.br/api/v1/localidades/microrregioes"), null);
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
         AV8IBGE_sdtMicrorregiaoCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao>( context, "IBGE_sdtMicrorregiao", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> aP0_IBGE_sdtMicrorregiaoCollection ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> AV8IBGE_sdtMicrorregiaoCollection ;
   }

}
