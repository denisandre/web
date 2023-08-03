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
   public class prcdocumentotipoobterdadosindividual : GXProcedure
   {
      public prcdocumentotipoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentotipoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo )
      {
         this.AV8sdtDocumentoTipo = aP0_sdtDocumentoTipo;
         initialize();
         executePrivate();
         aP0_sdtDocumentoTipo=this.AV8sdtDocumentoTipo;
      }

      public GeneXus.Programs.core.SdtsdtDocumentoTipo executeUdp( )
      {
         execute(ref aP0_sdtDocumentoTipo);
         return AV8sdtDocumentoTipo ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo )
      {
         prcdocumentotipoobterdadosindividual objprcdocumentotipoobterdadosindividual;
         objprcdocumentotipoobterdadosindividual = new prcdocumentotipoobterdadosindividual();
         objprcdocumentotipoobterdadosindividual.AV8sdtDocumentoTipo = aP0_sdtDocumentoTipo;
         objprcdocumentotipoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcdocumentotipoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcdocumentotipoobterdadosindividual);
         aP0_sdtDocumentoTipo=this.AV8sdtDocumentoTipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentotipoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtDocumentoTipo1 = AV9sdtDocumentoTipoList;
         new GeneXus.Programs.core.dpdocumentotipoobterdados(context ).execute(  AV8sdtDocumentoTipo, out  GXt_objcol_SdtsdtDocumentoTipo1) ;
         AV9sdtDocumentoTipoList = GXt_objcol_SdtsdtDocumentoTipo1;
         if ( AV9sdtDocumentoTipoList.Count >= 1 )
         {
            AV8sdtDocumentoTipo = (GeneXus.Programs.core.SdtsdtDocumentoTipo)(((GeneXus.Programs.core.SdtsdtDocumentoTipo)AV9sdtDocumentoTipoList.Item(1)).Clone());
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
         AV9sdtDocumentoTipoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo>( context, "sdtDocumentoTipo", "agl_tresorygroup");
         GXt_objcol_SdtsdtDocumentoTipo1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo>( context, "sdtDocumentoTipo", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> AV9sdtDocumentoTipoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> GXt_objcol_SdtsdtDocumentoTipo1 ;
      private GeneXus.Programs.core.SdtsdtDocumentoTipo AV8sdtDocumentoTipo ;
   }

}
