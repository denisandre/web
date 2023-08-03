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
   public class prcparametrosobterdadosindividual : GXProcedure
   {
      public prcparametrosobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcparametrosobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros )
      {
         this.AV8sdtParametros = aP0_sdtParametros;
         initialize();
         executePrivate();
         aP0_sdtParametros=this.AV8sdtParametros;
      }

      public GeneXus.Programs.core.SdtsdtParametros executeUdp( )
      {
         execute(ref aP0_sdtParametros);
         return AV8sdtParametros ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros )
      {
         prcparametrosobterdadosindividual objprcparametrosobterdadosindividual;
         objprcparametrosobterdadosindividual = new prcparametrosobterdadosindividual();
         objprcparametrosobterdadosindividual.AV8sdtParametros = aP0_sdtParametros;
         objprcparametrosobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcparametrosobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcparametrosobterdadosindividual);
         aP0_sdtParametros=this.AV8sdtParametros;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcparametrosobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtParametros1 = AV9sdtParametrosList;
         new GeneXus.Programs.core.dpparametrosobterdados(context ).execute(  AV8sdtParametros, out  GXt_objcol_SdtsdtParametros1) ;
         AV9sdtParametrosList = GXt_objcol_SdtsdtParametros1;
         if ( AV9sdtParametrosList.Count >= 1 )
         {
            AV8sdtParametros = (GeneXus.Programs.core.SdtsdtParametros)(((GeneXus.Programs.core.SdtsdtParametros)AV9sdtParametrosList.Item(1)).Clone());
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
         AV9sdtParametrosList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros>( context, "sdtParametros", "agl_tresorygroup");
         GXt_objcol_SdtsdtParametros1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros>( context, "sdtParametros", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> AV9sdtParametrosList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> GXt_objcol_SdtsdtParametros1 ;
      private GeneXus.Programs.core.SdtsdtParametros AV8sdtParametros ;
   }

}
