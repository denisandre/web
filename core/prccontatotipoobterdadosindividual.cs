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
   public class prccontatotipoobterdadosindividual : GXProcedure
   {
      public prccontatotipoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prccontatotipoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo )
      {
         this.AV8sdtContatoTipo = aP0_sdtContatoTipo;
         initialize();
         executePrivate();
         aP0_sdtContatoTipo=this.AV8sdtContatoTipo;
      }

      public GeneXus.Programs.core.SdtsdtContatoTipo executeUdp( )
      {
         execute(ref aP0_sdtContatoTipo);
         return AV8sdtContatoTipo ;
      }

      public void executeSubmit( ref GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo )
      {
         prccontatotipoobterdadosindividual objprccontatotipoobterdadosindividual;
         objprccontatotipoobterdadosindividual = new prccontatotipoobterdadosindividual();
         objprccontatotipoobterdadosindividual.AV8sdtContatoTipo = aP0_sdtContatoTipo;
         objprccontatotipoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprccontatotipoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprccontatotipoobterdadosindividual);
         aP0_sdtContatoTipo=this.AV8sdtContatoTipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prccontatotipoobterdadosindividual)stateInfo).executePrivate();
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
         GXt_objcol_SdtsdtContatoTipo1 = AV9sdtContatoTipoList;
         new GeneXus.Programs.core.dpcontatotipoobterdados(context ).execute(  AV8sdtContatoTipo, out  GXt_objcol_SdtsdtContatoTipo1) ;
         AV9sdtContatoTipoList = GXt_objcol_SdtsdtContatoTipo1;
         if ( AV9sdtContatoTipoList.Count >= 1 )
         {
            AV8sdtContatoTipo = (GeneXus.Programs.core.SdtsdtContatoTipo)(((GeneXus.Programs.core.SdtsdtContatoTipo)AV9sdtContatoTipoList.Item(1)).Clone());
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
         AV9sdtContatoTipoList = new GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo>( context, "sdtContatoTipo", "agl_tresorygroup");
         GXt_objcol_SdtsdtContatoTipo1 = new GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo>( context, "sdtContatoTipo", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> AV9sdtContatoTipoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> GXt_objcol_SdtsdtContatoTipo1 ;
      private GeneXus.Programs.core.SdtsdtContatoTipo AV8sdtContatoTipo ;
   }

}
