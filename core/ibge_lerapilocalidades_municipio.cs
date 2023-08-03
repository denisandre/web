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
   public class ibge_lerapilocalidades_municipio : GXProcedure
   {
      public ibge_lerapilocalidades_municipio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ibge_lerapilocalidades_municipio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> aP0_IBGE_sdtMunicipioCollection )
      {
         this.AV8IBGE_sdtMunicipioCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_IBGE_sdtMunicipioCollection=this.AV8IBGE_sdtMunicipioCollection;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> executeUdp( )
      {
         execute(out aP0_IBGE_sdtMunicipioCollection);
         return AV8IBGE_sdtMunicipioCollection ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> aP0_IBGE_sdtMunicipioCollection )
      {
         ibge_lerapilocalidades_municipio objibge_lerapilocalidades_municipio;
         objibge_lerapilocalidades_municipio = new ibge_lerapilocalidades_municipio();
         objibge_lerapilocalidades_municipio.AV8IBGE_sdtMunicipioCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup") ;
         objibge_lerapilocalidades_municipio.context.SetSubmitInitialConfig(context);
         objibge_lerapilocalidades_municipio.initialize();
         Submit( executePrivateCatch,objibge_lerapilocalidades_municipio);
         aP0_IBGE_sdtMunicipioCollection=this.AV8IBGE_sdtMunicipioCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ibge_lerapilocalidades_municipio)stateInfo).executePrivate();
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
         AV8IBGE_sdtMunicipioCollection.Clear();
         GXt_char1 = AV9cResposta;
         new GeneXus.Programs.core.ibge_lerapilocalidades(context ).execute(  "https://servicodados.ibge.gov.br/api/v1/localidades/municipios", out  GXt_char1) ;
         AV9cResposta = GXt_char1;
         AV8IBGE_sdtMunicipioCollection.FromJSonString(AV9cResposta, null);
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
         AV8IBGE_sdtMunicipioCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup");
         AV9cResposta = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV9cResposta ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> aP0_IBGE_sdtMunicipioCollection ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> AV8IBGE_sdtMunicipioCollection ;
   }

}
