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
   public class prcnegociopjfluxoverificarconfirmacao : GXProcedure
   {
      public prcnegociopjfluxoverificarconfirmacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjfluxoverificarconfirmacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_NegID ,
                           string aP1_NefChave ,
                           out bool aP2_isConfirmado )
      {
         this.AV8NegID = aP0_NegID;
         this.AV9NefChave = aP1_NefChave;
         this.AV11isConfirmado = false ;
         initialize();
         executePrivate();
         aP2_isConfirmado=this.AV11isConfirmado;
      }

      public bool executeUdp( Guid aP0_NegID ,
                              string aP1_NefChave )
      {
         execute(aP0_NegID, aP1_NefChave, out aP2_isConfirmado);
         return AV11isConfirmado ;
      }

      public void executeSubmit( Guid aP0_NegID ,
                                 string aP1_NefChave ,
                                 out bool aP2_isConfirmado )
      {
         prcnegociopjfluxoverificarconfirmacao objprcnegociopjfluxoverificarconfirmacao;
         objprcnegociopjfluxoverificarconfirmacao = new prcnegociopjfluxoverificarconfirmacao();
         objprcnegociopjfluxoverificarconfirmacao.AV8NegID = aP0_NegID;
         objprcnegociopjfluxoverificarconfirmacao.AV9NefChave = aP1_NefChave;
         objprcnegociopjfluxoverificarconfirmacao.AV11isConfirmado = false ;
         objprcnegociopjfluxoverificarconfirmacao.context.SetSubmitInitialConfig(context);
         objprcnegociopjfluxoverificarconfirmacao.initialize();
         Submit( executePrivateCatch,objprcnegociopjfluxoverificarconfirmacao);
         aP2_isConfirmado=this.AV11isConfirmado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjfluxoverificarconfirmacao)stateInfo).executePrivate();
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
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV8NegID,  AV9NefChave, out  AV10SDTNegocioPJFluxo) ;
         AV11isConfirmado = AV10SDTNegocioPJFluxo.gxTpr_Nefconfirmado;
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
         AV10SDTNegocioPJFluxo = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         /* GeneXus formulas. */
      }

      private bool AV11isConfirmado ;
      private string AV9NefChave ;
      private Guid AV8NegID ;
      private bool aP2_isConfirmado ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV10SDTNegocioPJFluxo ;
   }

}
