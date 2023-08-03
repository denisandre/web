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
   public class prcprodutoobterdadosindividual : GXProcedure
   {
      public prcprodutoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcprodutoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtProduto aP0_sdtProduto )
      {
         this.AV8sdtProduto = aP0_sdtProduto;
         initialize();
         executePrivate();
         aP0_sdtProduto=this.AV8sdtProduto;
      }

      public GeneXus.Programs.core.SdtsdtProduto executeUdp( )
      {
         execute(ref aP0_sdtProduto);
         return AV8sdtProduto ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtProduto aP0_sdtProduto )
      {
         prcprodutoobterdadosindividual objprcprodutoobterdadosindividual;
         objprcprodutoobterdadosindividual = new prcprodutoobterdadosindividual();
         objprcprodutoobterdadosindividual.AV8sdtProduto = aP0_sdtProduto;
         objprcprodutoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcprodutoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcprodutoobterdadosindividual);
         aP0_sdtProduto=this.AV8sdtProduto;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcprodutoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtProduto1 = AV9sdtProdutoList;
         new GeneXus.Programs.core.dpprodutoobterdados(context ).execute(  AV8sdtProduto, out  GXt_objcol_SdtsdtProduto1) ;
         AV9sdtProdutoList = GXt_objcol_SdtsdtProduto1;
         if ( AV9sdtProdutoList.Count >= 1 )
         {
            AV8sdtProduto = (GeneXus.Programs.core.SdtsdtProduto)(((GeneXus.Programs.core.SdtsdtProduto)AV9sdtProdutoList.Item(1)).Clone());
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
         AV9sdtProdutoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto>( context, "sdtProduto", "agl_tresorygroup");
         GXt_objcol_SdtsdtProduto1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto>( context, "sdtProduto", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtProduto aP0_sdtProduto ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> AV9sdtProdutoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> GXt_objcol_SdtsdtProduto1 ;
      private GeneXus.Programs.core.SdtsdtProduto AV8sdtProduto ;
   }

}
