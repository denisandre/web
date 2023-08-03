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
   public class prcprodutotipoobterdadosindividual : GXProcedure
   {
      public prcprodutotipoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcprodutotipoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo )
      {
         this.AV8sdtProdutoTipo = aP0_sdtProdutoTipo;
         initialize();
         executePrivate();
         aP0_sdtProdutoTipo=this.AV8sdtProdutoTipo;
      }

      public GeneXus.Programs.core.SdtsdtProdutoTipo executeUdp( )
      {
         execute(ref aP0_sdtProdutoTipo);
         return AV8sdtProdutoTipo ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo )
      {
         prcprodutotipoobterdadosindividual objprcprodutotipoobterdadosindividual;
         objprcprodutotipoobterdadosindividual = new prcprodutotipoobterdadosindividual();
         objprcprodutotipoobterdadosindividual.AV8sdtProdutoTipo = aP0_sdtProdutoTipo;
         objprcprodutotipoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcprodutotipoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcprodutotipoobterdadosindividual);
         aP0_sdtProdutoTipo=this.AV8sdtProdutoTipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcprodutotipoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtProdutoTipo1 = AV9sdtProdutoTipoList;
         new GeneXus.Programs.core.dpprodutotipoobterdados(context ).execute(  AV8sdtProdutoTipo, out  GXt_objcol_SdtsdtProdutoTipo1) ;
         AV9sdtProdutoTipoList = GXt_objcol_SdtsdtProdutoTipo1;
         if ( AV9sdtProdutoTipoList.Count >= 1 )
         {
            AV8sdtProdutoTipo = (GeneXus.Programs.core.SdtsdtProdutoTipo)(((GeneXus.Programs.core.SdtsdtProdutoTipo)AV9sdtProdutoTipoList.Item(1)).Clone());
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
         AV9sdtProdutoTipoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo>( context, "sdtProdutoTipo", "agl_tresorygroup");
         GXt_objcol_SdtsdtProdutoTipo1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo>( context, "sdtProdutoTipo", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> AV9sdtProdutoTipoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> GXt_objcol_SdtsdtProdutoTipo1 ;
      private GeneXus.Programs.core.SdtsdtProdutoTipo AV8sdtProdutoTipo ;
   }

}
