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
   public class aiteracao_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.aiteracao_dataprovider().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         GXBCCollection<GeneXus.Programs.core.SdtIteracao> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.SdtIteracao>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aiteracao_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aiteracao_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.SdtIteracao> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.SdtIteracao>( context, "Iteracao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.SdtIteracao> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.SdtIteracao> aP0_Gxm2rootcol )
      {
         aiteracao_dataprovider objaiteracao_dataprovider;
         objaiteracao_dataprovider = new aiteracao_dataprovider();
         objaiteracao_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.SdtIteracao>( context, "Iteracao", "agl_tresorygroup") ;
         objaiteracao_dataprovider.context.SetSubmitInitialConfig(context);
         objaiteracao_dataprovider.initialize();
         Submit( executePrivateCatch,objaiteracao_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aiteracao_dataprovider)stateInfo).executePrivate();
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
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         Gxm2rootcol.Add(Gxm1iteracao, 0);
         Gxm1iteracao.gxTpr_Iteid = StringUtil.StrToGuid( "7437e22a-fb58-461e-b382-0e049d73be97");
         Gxm1iteracao.gxTpr_Iteordem = 1;
         Gxm1iteracao.gxTpr_Itenome = "Em Desenvolvimento";
         Gxm1iteracao.gxTpr_Iteativo = true;
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         Gxm2rootcol.Add(Gxm1iteracao, 0);
         Gxm1iteracao.gxTpr_Iteid = StringUtil.StrToGuid( "c90324f9-725c-42e5-ac76-dbe80660d0d7");
         Gxm1iteracao.gxTpr_Iteordem = 2;
         Gxm1iteracao.gxTpr_Itenome = "Troca de Documentação";
         Gxm1iteracao.gxTpr_Iteativo = true;
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         Gxm2rootcol.Add(Gxm1iteracao, 0);
         Gxm1iteracao.gxTpr_Iteid = StringUtil.StrToGuid( "f3691b50-d55e-4ed4-87be-db490d8b251c");
         Gxm1iteracao.gxTpr_Iteordem = 3;
         Gxm1iteracao.gxTpr_Itenome = "Proposta";
         Gxm1iteracao.gxTpr_Iteativo = true;
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         Gxm2rootcol.Add(Gxm1iteracao, 0);
         Gxm1iteracao.gxTpr_Iteid = StringUtil.StrToGuid( "06b3b3cf-85f7-4b0a-9509-9068bbef101e");
         Gxm1iteracao.gxTpr_Iteordem = 4;
         Gxm1iteracao.gxTpr_Itenome = "Assinatura de Contrato";
         Gxm1iteracao.gxTpr_Iteativo = true;
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         Gxm2rootcol.Add(Gxm1iteracao, 0);
         Gxm1iteracao.gxTpr_Iteid = StringUtil.StrToGuid( "d70a4751-798b-4e85-af4e-015e148b2bc8");
         Gxm1iteracao.gxTpr_Iteordem = 5;
         Gxm1iteracao.gxTpr_Itenome = "Encerrar";
         Gxm1iteracao.gxTpr_Iteativo = true;
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         Gxm2rootcol.Add(Gxm1iteracao, 0);
         Gxm1iteracao.gxTpr_Iteid = StringUtil.StrToGuid( "9717034e-a726-4f2c-a0a6-a961daa5c174");
         Gxm1iteracao.gxTpr_Iteordem = 6;
         Gxm1iteracao.gxTpr_Itenome = "Acompanhamento";
         Gxm1iteracao.gxTpr_Iteativo = true;
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
         Gxm1iteracao = new GeneXus.Programs.core.SdtIteracao(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<GeneXus.Programs.core.SdtIteracao> aP0_Gxm2rootcol ;
      private GXBCCollection<GeneXus.Programs.core.SdtIteracao> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtIteracao Gxm1iteracao ;
   }

}
