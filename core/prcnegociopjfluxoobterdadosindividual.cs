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
   public class prcnegociopjfluxoobterdadosindividual : GXProcedure
   {
      public prcnegociopjfluxoobterdadosindividual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjfluxoobterdadosindividual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_NegID ,
                           string aP1_NefChave ,
                           out GeneXus.Programs.core.SdtSDTNegocioPJFluxo aP2_SDTNegocioPJFluxo )
      {
         this.AV9NegID = aP0_NegID;
         this.AV8NefChave = aP1_NefChave;
         this.AV11SDTNegocioPJFluxo = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context) ;
         initialize();
         executePrivate();
         aP2_SDTNegocioPJFluxo=this.AV11SDTNegocioPJFluxo;
      }

      public GeneXus.Programs.core.SdtSDTNegocioPJFluxo executeUdp( Guid aP0_NegID ,
                                                                    string aP1_NefChave )
      {
         execute(aP0_NegID, aP1_NefChave, out aP2_SDTNegocioPJFluxo);
         return AV11SDTNegocioPJFluxo ;
      }

      public void executeSubmit( Guid aP0_NegID ,
                                 string aP1_NefChave ,
                                 out GeneXus.Programs.core.SdtSDTNegocioPJFluxo aP2_SDTNegocioPJFluxo )
      {
         prcnegociopjfluxoobterdadosindividual objprcnegociopjfluxoobterdadosindividual;
         objprcnegociopjfluxoobterdadosindividual = new prcnegociopjfluxoobterdadosindividual();
         objprcnegociopjfluxoobterdadosindividual.AV9NegID = aP0_NegID;
         objprcnegociopjfluxoobterdadosindividual.AV8NefChave = aP1_NefChave;
         objprcnegociopjfluxoobterdadosindividual.AV11SDTNegocioPJFluxo = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context) ;
         objprcnegociopjfluxoobterdadosindividual.context.SetSubmitInitialConfig(context);
         objprcnegociopjfluxoobterdadosindividual.initialize();
         Submit( executePrivateCatch,objprcnegociopjfluxoobterdadosindividual);
         aP2_SDTNegocioPJFluxo=this.AV11SDTNegocioPJFluxo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjfluxoobterdadosindividual)stateInfo).executePrivate();
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
         AV12NefChaveList.Clear();
         GXt_objcol_SdtSDTNegocioPJFluxo1 = AV10SDTNegocioPJFluxoList;
         new GeneXus.Programs.core.dpnegociopjfluxoobterdados(context ).execute(  AV9NegID,  AV8NefChave,  AV12NefChaveList, out  GXt_objcol_SdtSDTNegocioPJFluxo1) ;
         AV10SDTNegocioPJFluxoList = GXt_objcol_SdtSDTNegocioPJFluxo1;
         if ( AV10SDTNegocioPJFluxoList.Count >= 1 )
         {
            AV11SDTNegocioPJFluxo = (GeneXus.Programs.core.SdtSDTNegocioPJFluxo)(((GeneXus.Programs.core.SdtSDTNegocioPJFluxo)AV10SDTNegocioPJFluxoList.Item(1)).Clone());
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
         AV11SDTNegocioPJFluxo = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV12NefChaveList = new GxSimpleCollection<string>();
         AV10SDTNegocioPJFluxoList = new GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo>( context, "SDTNegocioPJFluxo", "agl_tresorygroup");
         GXt_objcol_SdtSDTNegocioPJFluxo1 = new GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo>( context, "SDTNegocioPJFluxo", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private string AV8NefChave ;
      private Guid AV9NegID ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo aP2_SDTNegocioPJFluxo ;
      private GxSimpleCollection<string> AV12NefChaveList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> AV10SDTNegocioPJFluxoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> GXt_objcol_SdtSDTNegocioPJFluxo1 ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV11SDTNegocioPJFluxo ;
   }

}
