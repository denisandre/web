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
   public class prcgeneroobterdadosindividual : GXProcedure
   {
      public prcgeneroobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcgeneroobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero )
      {
         this.AV8sdtGenero = aP0_sdtGenero;
         initialize();
         executePrivate();
         aP0_sdtGenero=this.AV8sdtGenero;
      }

      public GeneXus.Programs.core.SdtsdtGenero executeUdp( )
      {
         execute(ref aP0_sdtGenero);
         return AV8sdtGenero ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero )
      {
         prcgeneroobterdadosindividual objprcgeneroobterdadosindividual;
         objprcgeneroobterdadosindividual = new prcgeneroobterdadosindividual();
         objprcgeneroobterdadosindividual.AV8sdtGenero = aP0_sdtGenero;
         objprcgeneroobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcgeneroobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcgeneroobterdadosindividual);
         aP0_sdtGenero=this.AV8sdtGenero;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcgeneroobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtGenero1 = AV9sdtGeneroList;
         new GeneXus.Programs.core.dpgeneroobterdados(context ).execute(  AV8sdtGenero, out  GXt_objcol_SdtsdtGenero1) ;
         AV9sdtGeneroList = GXt_objcol_SdtsdtGenero1;
         if ( AV9sdtGeneroList.Count >= 1 )
         {
            AV8sdtGenero = (GeneXus.Programs.core.SdtsdtGenero)(((GeneXus.Programs.core.SdtsdtGenero)AV9sdtGeneroList.Item(1)).Clone());
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
         AV9sdtGeneroList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero>( context, "sdtGenero", "agl_tresorygroup");
         GXt_objcol_SdtsdtGenero1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero>( context, "sdtGenero", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> AV9sdtGeneroList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> GXt_objcol_SdtsdtGenero1 ;
      private GeneXus.Programs.core.SdtsdtGenero AV8sdtGenero ;
   }

}
