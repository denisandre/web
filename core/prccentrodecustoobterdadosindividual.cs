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
   public class prccentrodecustoobterdadosindividual : GXProcedure
   {
      public prccentrodecustoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prccentrodecustoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto )
      {
         this.AV8sdtCentroDeCusto = aP0_sdtCentroDeCusto;
         initialize();
         executePrivate();
         aP0_sdtCentroDeCusto=this.AV8sdtCentroDeCusto;
      }

      public GeneXus.Programs.core.SdtsdtCentroDeCusto executeUdp( )
      {
         execute(ref aP0_sdtCentroDeCusto);
         return AV8sdtCentroDeCusto ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto )
      {
         prccentrodecustoobterdadosindividual objprccentrodecustoobterdadosindividual;
         objprccentrodecustoobterdadosindividual = new prccentrodecustoobterdadosindividual();
         objprccentrodecustoobterdadosindividual.AV8sdtCentroDeCusto = aP0_sdtCentroDeCusto;
         objprccentrodecustoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprccentrodecustoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprccentrodecustoobterdadosindividual);
         aP0_sdtCentroDeCusto=this.AV8sdtCentroDeCusto;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prccentrodecustoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtCentroDeCusto1 = AV9sdtCentroDeCustoList;
         new GeneXus.Programs.core.dpcentrodecustoobterdados(context ).execute(  AV8sdtCentroDeCusto, out  GXt_objcol_SdtsdtCentroDeCusto1) ;
         AV9sdtCentroDeCustoList = GXt_objcol_SdtsdtCentroDeCusto1;
         if ( AV9sdtCentroDeCustoList.Count >= 1 )
         {
            AV8sdtCentroDeCusto = (GeneXus.Programs.core.SdtsdtCentroDeCusto)(((GeneXus.Programs.core.SdtsdtCentroDeCusto)AV9sdtCentroDeCustoList.Item(1)).Clone());
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
         AV9sdtCentroDeCustoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto>( context, "sdtCentroDeCusto", "agl_tresorygroup");
         GXt_objcol_SdtsdtCentroDeCusto1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto>( context, "sdtCentroDeCusto", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> AV9sdtCentroDeCustoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> GXt_objcol_SdtsdtCentroDeCusto1 ;
      private GeneXus.Programs.core.SdtsdtCentroDeCusto AV8sdtCentroDeCusto ;
   }

}
