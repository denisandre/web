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
   public class prcnegociopjfluxoverificarconfirmacaoencerramento : GXProcedure
   {
      public prcnegociopjfluxoverificarconfirmacaoencerramento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjfluxoverificarconfirmacaoencerramento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_NegID ,
                           out bool aP1_isConfirmado )
      {
         this.AV11NegID = aP0_NegID;
         this.AV9isConfirmado = false ;
         initialize();
         executePrivate();
         aP1_isConfirmado=this.AV9isConfirmado;
      }

      public bool executeUdp( Guid aP0_NegID )
      {
         execute(aP0_NegID, out aP1_isConfirmado);
         return AV9isConfirmado ;
      }

      public void executeSubmit( Guid aP0_NegID ,
                                 out bool aP1_isConfirmado )
      {
         prcnegociopjfluxoverificarconfirmacaoencerramento objprcnegociopjfluxoverificarconfirmacaoencerramento;
         objprcnegociopjfluxoverificarconfirmacaoencerramento = new prcnegociopjfluxoverificarconfirmacaoencerramento();
         objprcnegociopjfluxoverificarconfirmacaoencerramento.AV11NegID = aP0_NegID;
         objprcnegociopjfluxoverificarconfirmacaoencerramento.AV9isConfirmado = false ;
         objprcnegociopjfluxoverificarconfirmacaoencerramento.context.SetSubmitInitialConfig(context);
         objprcnegociopjfluxoverificarconfirmacaoencerramento.initialize();
         Submit( executePrivateCatch,objprcnegociopjfluxoverificarconfirmacaoencerramento);
         aP1_isConfirmado=this.AV9isConfirmado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjfluxoverificarconfirmacaoencerramento)stateInfo).executePrivate();
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
         AV10NefChaveList.Clear();
         AV10NefChaveList.Add("ENCREALIZADOONBOARD", 0);
         AV10NefChaveList.Add("ENCPESQUISAAVALIACAO", 0);
         GXt_objcol_SdtSDTNegocioPJFluxo1 = AV13SDTNegocioPJFluxoList;
         new GeneXus.Programs.core.dpnegociopjfluxoobterdados(context ).execute(  AV11NegID,  "",  AV10NefChaveList, out  GXt_objcol_SdtSDTNegocioPJFluxo1) ;
         AV13SDTNegocioPJFluxoList = GXt_objcol_SdtSDTNegocioPJFluxo1;
         AV9isConfirmado = false;
         AV8contador = 1;
         while ( AV8contador <= AV13SDTNegocioPJFluxoList.Count )
         {
            if ( ! ((GeneXus.Programs.core.SdtSDTNegocioPJFluxo)AV13SDTNegocioPJFluxoList.Item(AV8contador)).gxTpr_Nefconfirmado )
            {
               AV9isConfirmado = false;
               if (true) break;
            }
            else
            {
               AV9isConfirmado = true;
            }
            AV8contador = (short)(AV8contador+1);
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
         AV10NefChaveList = new GxSimpleCollection<string>();
         AV13SDTNegocioPJFluxoList = new GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo>( context, "SDTNegocioPJFluxo", "agl_tresorygroup");
         GXt_objcol_SdtSDTNegocioPJFluxo1 = new GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo>( context, "SDTNegocioPJFluxo", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private short AV8contador ;
      private bool AV9isConfirmado ;
      private Guid AV11NegID ;
      private bool aP1_isConfirmado ;
      private GxSimpleCollection<string> AV10NefChaveList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> AV13SDTNegocioPJFluxoList ;
      private GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> GXt_objcol_SdtSDTNegocioPJFluxo1 ;
   }

}
