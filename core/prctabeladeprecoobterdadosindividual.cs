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
   public class prctabeladeprecoobterdadosindividual : GXProcedure
   {
      public prctabeladeprecoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prctabeladeprecoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco )
      {
         this.AV8sdtTabelaDePreco = aP0_sdtTabelaDePreco;
         initialize();
         executePrivate();
         aP0_sdtTabelaDePreco=this.AV8sdtTabelaDePreco;
      }

      public GeneXus.Programs.core.SdtsdtTabelaDePreco executeUdp( )
      {
         execute(ref aP0_sdtTabelaDePreco);
         return AV8sdtTabelaDePreco ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco )
      {
         prctabeladeprecoobterdadosindividual objprctabeladeprecoobterdadosindividual;
         objprctabeladeprecoobterdadosindividual = new prctabeladeprecoobterdadosindividual();
         objprctabeladeprecoobterdadosindividual.AV8sdtTabelaDePreco = aP0_sdtTabelaDePreco;
         objprctabeladeprecoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprctabeladeprecoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprctabeladeprecoobterdadosindividual);
         aP0_sdtTabelaDePreco=this.AV8sdtTabelaDePreco;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prctabeladeprecoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtTabelaDePreco1 = AV9sdtTabelaDePrecoList;
         new GeneXus.Programs.core.dptabeladeprecoobterdados(context ).execute(  AV8sdtTabelaDePreco, out  GXt_objcol_SdtsdtTabelaDePreco1) ;
         AV9sdtTabelaDePrecoList = GXt_objcol_SdtsdtTabelaDePreco1;
         if ( AV9sdtTabelaDePrecoList.Count >= 1 )
         {
            AV8sdtTabelaDePreco = (GeneXus.Programs.core.SdtsdtTabelaDePreco)(((GeneXus.Programs.core.SdtsdtTabelaDePreco)AV9sdtTabelaDePrecoList.Item(1)).Clone());
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
         AV9sdtTabelaDePrecoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco>( context, "sdtTabelaDePreco", "agl_tresorygroup");
         GXt_objcol_SdtsdtTabelaDePreco1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco>( context, "sdtTabelaDePreco", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> AV9sdtTabelaDePrecoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> GXt_objcol_SdtsdtTabelaDePreco1 ;
      private GeneXus.Programs.core.SdtsdtTabelaDePreco AV8sdtTabelaDePreco ;
   }

}
