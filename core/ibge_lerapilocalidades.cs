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
   public class ibge_lerapilocalidades : GXProcedure
   {
      public ibge_lerapilocalidades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ibge_lerapilocalidades( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_IBGE_EndpointLocalidades ,
                           out string aP1_JsonString )
      {
         this.AV9IBGE_EndpointLocalidades = aP0_IBGE_EndpointLocalidades;
         this.AV10JsonString = "" ;
         initialize();
         executePrivate();
         aP1_JsonString=this.AV10JsonString;
      }

      public string executeUdp( string aP0_IBGE_EndpointLocalidades )
      {
         execute(aP0_IBGE_EndpointLocalidades, out aP1_JsonString);
         return AV10JsonString ;
      }

      public void executeSubmit( string aP0_IBGE_EndpointLocalidades ,
                                 out string aP1_JsonString )
      {
         ibge_lerapilocalidades objibge_lerapilocalidades;
         objibge_lerapilocalidades = new ibge_lerapilocalidades();
         objibge_lerapilocalidades.AV9IBGE_EndpointLocalidades = aP0_IBGE_EndpointLocalidades;
         objibge_lerapilocalidades.AV10JsonString = "" ;
         objibge_lerapilocalidades.context.SetSubmitInitialConfig(context);
         objibge_lerapilocalidades.initialize();
         Submit( executePrivateCatch,objibge_lerapilocalidades);
         aP1_JsonString=this.AV10JsonString;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ibge_lerapilocalidades)stateInfo).executePrivate();
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
         AV10JsonString = "";
         AV8HTTPClient.Execute("GET", AV9IBGE_EndpointLocalidades);
         if ( AV8HTTPClient.StatusCode == 200 )
         {
            AV10JsonString = AV8HTTPClient.ToString();
         }
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
         AV10JsonString = "";
         AV8HTTPClient = new GxHttpClient( context);
         /* GeneXus formulas. */
      }

      private string AV9IBGE_EndpointLocalidades ;
      private string AV10JsonString ;
      private string aP1_JsonString ;
      private GxHttpClient AV8HTTPClient ;
   }

}
