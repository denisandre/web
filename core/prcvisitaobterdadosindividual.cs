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
   public class prcvisitaobterdadosindividual : GXProcedure
   {
      public prcvisitaobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcvisitaobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita )
      {
         this.AV8sdtVisita = aP0_sdtVisita;
         initialize();
         executePrivate();
         aP0_sdtVisita=this.AV8sdtVisita;
      }

      public GeneXus.Programs.core.SdtsdtVisita executeUdp( )
      {
         execute(ref aP0_sdtVisita);
         return AV8sdtVisita ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita )
      {
         prcvisitaobterdadosindividual objprcvisitaobterdadosindividual;
         objprcvisitaobterdadosindividual = new prcvisitaobterdadosindividual();
         objprcvisitaobterdadosindividual.AV8sdtVisita = aP0_sdtVisita;
         objprcvisitaobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcvisitaobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcvisitaobterdadosindividual);
         aP0_sdtVisita=this.AV8sdtVisita;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcvisitaobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtVisita1 = AV9sdtVisitaList;
         new GeneXus.Programs.core.dpvisitaobterdados(context ).execute(  AV8sdtVisita, out  GXt_objcol_SdtsdtVisita1) ;
         AV9sdtVisitaList = GXt_objcol_SdtsdtVisita1;
         if ( AV9sdtVisitaList.Count >= 1 )
         {
            AV8sdtVisita = (GeneXus.Programs.core.SdtsdtVisita)(((GeneXus.Programs.core.SdtsdtVisita)AV9sdtVisitaList.Item(1)).Clone());
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
         AV9sdtVisitaList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita>( context, "sdtVisita", "agl_tresorygroup");
         GXt_objcol_SdtsdtVisita1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita>( context, "sdtVisita", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> AV9sdtVisitaList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> GXt_objcol_SdtsdtVisita1 ;
      private GeneXus.Programs.core.SdtsdtVisita AV8sdtVisita ;
   }

}
