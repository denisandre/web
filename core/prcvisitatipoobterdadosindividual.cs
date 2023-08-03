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
   public class prcvisitatipoobterdadosindividual : GXProcedure
   {
      public prcvisitatipoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcvisitatipoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtVisitaTipo aP0_sdtVisitaTipo )
      {
         this.AV8sdtVisitaTipo = aP0_sdtVisitaTipo;
         initialize();
         executePrivate();
         aP0_sdtVisitaTipo=this.AV8sdtVisitaTipo;
      }

      public GeneXus.Programs.core.SdtsdtVisitaTipo executeUdp( )
      {
         execute(ref aP0_sdtVisitaTipo);
         return AV8sdtVisitaTipo ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtVisitaTipo aP0_sdtVisitaTipo )
      {
         prcvisitatipoobterdadosindividual objprcvisitatipoobterdadosindividual;
         objprcvisitatipoobterdadosindividual = new prcvisitatipoobterdadosindividual();
         objprcvisitatipoobterdadosindividual.AV8sdtVisitaTipo = aP0_sdtVisitaTipo;
         objprcvisitatipoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcvisitatipoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcvisitatipoobterdadosindividual);
         aP0_sdtVisitaTipo=this.AV8sdtVisitaTipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcvisitatipoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtVisitaTipo1 = AV9sdtVisitaTipoList;
         new GeneXus.Programs.core.dpvisitatipoobterdados(context ).execute(  AV8sdtVisitaTipo, out  GXt_objcol_SdtsdtVisitaTipo1) ;
         AV9sdtVisitaTipoList = GXt_objcol_SdtsdtVisitaTipo1;
         if ( AV9sdtVisitaTipoList.Count >= 1 )
         {
            AV8sdtVisitaTipo = (GeneXus.Programs.core.SdtsdtVisitaTipo)(((GeneXus.Programs.core.SdtsdtVisitaTipo)AV9sdtVisitaTipoList.Item(1)).Clone());
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
         AV9sdtVisitaTipoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo>( context, "sdtVisitaTipo", "agl_tresorygroup");
         GXt_objcol_SdtsdtVisitaTipo1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo>( context, "sdtVisitaTipo", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtVisitaTipo aP0_sdtVisitaTipo ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> AV9sdtVisitaTipoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> GXt_objcol_SdtsdtVisitaTipo1 ;
      private GeneXus.Programs.core.SdtsdtVisitaTipo AV8sdtVisitaTipo ;
   }

}
