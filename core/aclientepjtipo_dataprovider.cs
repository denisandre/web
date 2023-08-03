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
   public class aclientepjtipo_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.aclientepjtipo_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo>()  ;
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

      public aclientepjtipo_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aclientepjtipo_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo>( context, "ClientePJTipo", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo> aP0_Gxm2rootcol )
      {
         aclientepjtipo_dataprovider objaclientepjtipo_dataprovider;
         objaclientepjtipo_dataprovider = new aclientepjtipo_dataprovider();
         objaclientepjtipo_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo>( context, "ClientePJTipo", "agl_tresorygroup") ;
         objaclientepjtipo_dataprovider.context.SetSubmitInitialConfig(context);
         objaclientepjtipo_dataprovider.initialize();
         Submit( executePrivateCatch,objaclientepjtipo_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aclientepjtipo_dataprovider)stateInfo).executePrivate();
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
         Gxm1clientepjtipo = new GeneXus.Programs.core.SdtClientePJTipo(context);
         Gxm2rootcol.Add(Gxm1clientepjtipo, 0);
         Gxm1clientepjtipo.gxTpr_Pjtid = 1;
         Gxm1clientepjtipo.gxTpr_Pjtsigla = "HOLDING";
         Gxm1clientepjtipo.gxTpr_Pjtnome = "Holding";
         Gxm1clientepjtipo.gxTpr_Pjtativo = true;
         Gxm1clientepjtipo = new GeneXus.Programs.core.SdtClientePJTipo(context);
         Gxm2rootcol.Add(Gxm1clientepjtipo, 0);
         Gxm1clientepjtipo.gxTpr_Pjtid = 2;
         Gxm1clientepjtipo.gxTpr_Pjtsigla = "EMPRESA";
         Gxm1clientepjtipo.gxTpr_Pjtnome = "Empresa";
         Gxm1clientepjtipo.gxTpr_Pjtativo = true;
         Gxm1clientepjtipo = new GeneXus.Programs.core.SdtClientePJTipo(context);
         Gxm2rootcol.Add(Gxm1clientepjtipo, 0);
         Gxm1clientepjtipo.gxTpr_Pjtid = 3;
         Gxm1clientepjtipo.gxTpr_Pjtsigla = "FILIAL";
         Gxm1clientepjtipo.gxTpr_Pjtnome = "Filial";
         Gxm1clientepjtipo.gxTpr_Pjtativo = true;
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
         Gxm1clientepjtipo = new GeneXus.Programs.core.SdtClientePJTipo(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo> aP0_Gxm2rootcol ;
      private GXBCCollection<GeneXus.Programs.core.SdtClientePJTipo> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtClientePJTipo Gxm1clientepjtipo ;
   }

}
