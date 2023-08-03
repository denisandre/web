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
   public class ibge_lerapilocalidades_uf : GXProcedure
   {
      public ibge_lerapilocalidades_uf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ibge_lerapilocalidades_uf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> aP0_IBGE_sdtUFCollection )
      {
         this.AV8IBGE_sdtUFCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF>( context, "IBGE_sdtUF", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_IBGE_sdtUFCollection=this.AV8IBGE_sdtUFCollection;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> executeUdp( )
      {
         execute(out aP0_IBGE_sdtUFCollection);
         return AV8IBGE_sdtUFCollection ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> aP0_IBGE_sdtUFCollection )
      {
         ibge_lerapilocalidades_uf objibge_lerapilocalidades_uf;
         objibge_lerapilocalidades_uf = new ibge_lerapilocalidades_uf();
         objibge_lerapilocalidades_uf.AV8IBGE_sdtUFCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF>( context, "IBGE_sdtUF", "agl_tresorygroup") ;
         objibge_lerapilocalidades_uf.context.SetSubmitInitialConfig(context);
         objibge_lerapilocalidades_uf.initialize();
         Submit( executePrivateCatch,objibge_lerapilocalidades_uf);
         aP0_IBGE_sdtUFCollection=this.AV8IBGE_sdtUFCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ibge_lerapilocalidades_uf)stateInfo).executePrivate();
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
         AV8IBGE_sdtUFCollection.Clear();
         AV8IBGE_sdtUFCollection.FromJSonString(new GeneXus.Programs.core.ibge_lerapilocalidades(context).executeUdp(  "https://servicodados.ibge.gov.br/api/v1/localidades/estados"), null);
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
         AV8IBGE_sdtUFCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF>( context, "IBGE_sdtUF", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> aP0_IBGE_sdtUFCollection ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> AV8IBGE_sdtUFCollection ;
   }

}
