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
   public class prcnegociopjobterdadosindividual : GXProcedure
   {
      public prcnegociopjobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ )
      {
         this.AV8sdtNegocioPJ = aP0_sdtNegocioPJ;
         initialize();
         executePrivate();
         aP0_sdtNegocioPJ=this.AV8sdtNegocioPJ;
      }

      public GeneXus.Programs.core.SdtsdtNegocioPJ executeUdp( )
      {
         execute(ref aP0_sdtNegocioPJ);
         return AV8sdtNegocioPJ ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ )
      {
         prcnegociopjobterdadosindividual objprcnegociopjobterdadosindividual;
         objprcnegociopjobterdadosindividual = new prcnegociopjobterdadosindividual();
         objprcnegociopjobterdadosindividual.AV8sdtNegocioPJ = aP0_sdtNegocioPJ;
         objprcnegociopjobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcnegociopjobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcnegociopjobterdadosindividual);
         aP0_sdtNegocioPJ=this.AV8sdtNegocioPJ;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtNegocioPJ1 = AV9sdtNegocioPJList;
         new GeneXus.Programs.core.dpnegociopjobterdados(context ).execute(  AV8sdtNegocioPJ, out  GXt_objcol_SdtsdtNegocioPJ1) ;
         AV9sdtNegocioPJList = GXt_objcol_SdtsdtNegocioPJ1;
         if ( AV9sdtNegocioPJList.Count >= 1 )
         {
            AV8sdtNegocioPJ = (GeneXus.Programs.core.SdtsdtNegocioPJ)(((GeneXus.Programs.core.SdtsdtNegocioPJ)AV9sdtNegocioPJList.Item(1)).Clone());
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
         AV9sdtNegocioPJList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ>( context, "sdtNegocioPJ", "agl_tresorygroup");
         GXt_objcol_SdtsdtNegocioPJ1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ>( context, "sdtNegocioPJ", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> AV9sdtNegocioPJList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> GXt_objcol_SdtsdtNegocioPJ1 ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ AV8sdtNegocioPJ ;
   }

}
