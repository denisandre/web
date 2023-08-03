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
   public class prcdocumentoobterdadosindividual : GXProcedure
   {
      public prcdocumentoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento )
      {
         this.AV8sdtDocumento = aP0_sdtDocumento;
         initialize();
         executePrivate();
         aP0_sdtDocumento=this.AV8sdtDocumento;
      }

      public GeneXus.Programs.core.SdtsdtDocumento executeUdp( )
      {
         execute(ref aP0_sdtDocumento);
         return AV8sdtDocumento ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento )
      {
         prcdocumentoobterdadosindividual objprcdocumentoobterdadosindividual;
         objprcdocumentoobterdadosindividual = new prcdocumentoobterdadosindividual();
         objprcdocumentoobterdadosindividual.AV8sdtDocumento = aP0_sdtDocumento;
         objprcdocumentoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcdocumentoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcdocumentoobterdadosindividual);
         aP0_sdtDocumento=this.AV8sdtDocumento;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtDocumento1 = AV9sdtDocumentoList;
         new GeneXus.Programs.core.dpdocumentoobterdados(context ).execute(  AV8sdtDocumento, out  GXt_objcol_SdtsdtDocumento1) ;
         AV9sdtDocumentoList = GXt_objcol_SdtsdtDocumento1;
         if ( AV9sdtDocumentoList.Count >= 1 )
         {
            AV8sdtDocumento = (GeneXus.Programs.core.SdtsdtDocumento)(((GeneXus.Programs.core.SdtsdtDocumento)AV9sdtDocumentoList.Item(1)).Clone());
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
         AV9sdtDocumentoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento>( context, "sdtDocumento", "agl_tresorygroup");
         GXt_objcol_SdtsdtDocumento1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento>( context, "sdtDocumento", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> AV9sdtDocumentoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> GXt_objcol_SdtsdtDocumento1 ;
      private GeneXus.Programs.core.SdtsdtDocumento AV8sdtDocumento ;
   }

}
