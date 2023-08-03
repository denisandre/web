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
   public class amunicipio_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.amunicipio_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.core.Sdtmunicipio> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmunicipio>()  ;
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

      public amunicipio_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amunicipio_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtmunicipio> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmunicipio>( context, "municipio", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtmunicipio> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtmunicipio> aP0_Gxm2rootcol )
      {
         amunicipio_dataprovider objamunicipio_dataprovider;
         objamunicipio_dataprovider = new amunicipio_dataprovider();
         objamunicipio_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmunicipio>( context, "municipio", "agl_tresorygroup") ;
         objamunicipio_dataprovider.context.SetSubmitInitialConfig(context);
         objamunicipio_dataprovider.initialize();
         Submit( executePrivateCatch,objamunicipio_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((amunicipio_dataprovider)stateInfo).executePrivate();
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
         AV9GXV2 = 1;
         GXt_objcol_SdtIBGE_sdtMunicipio1 = AV8GXV1;
         new GeneXus.Programs.core.ibge_lerapilocalidades_municipio(context ).execute( out  GXt_objcol_SdtIBGE_sdtMunicipio1) ;
         AV8GXV1 = GXt_objcol_SdtIBGE_sdtMunicipio1;
         while ( AV9GXV2 <= AV8GXV1.Count )
         {
            AV5IBGE_sdtMunicipio = ((GeneXus.Programs.core.SdtIBGE_sdtMunicipio)AV8GXV1.Item(AV9GXV2));
            Gxm1municipio = new GeneXus.Programs.core.Sdtmunicipio(context);
            Gxm2rootcol.Add(Gxm1municipio, 0);
            Gxm1municipio.gxTpr_Municipioid = (int)(Math.Round(AV5IBGE_sdtMunicipio.gxTpr_Id, 18, MidpointRounding.ToEven));
            Gxm1municipio.gxTpr_Municipionome = AV5IBGE_sdtMunicipio.gxTpr_Nome;
            Gxm1municipio.gxTpr_Municipiomicroid = (int)(Math.Round(AV5IBGE_sdtMunicipio.gxTpr_Microrregiao.gxTpr_Id, 18, MidpointRounding.ToEven));
            AV9GXV2 = (int)(AV9GXV2+1);
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
         AV8GXV1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup");
         GXt_objcol_SdtIBGE_sdtMunicipio1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup");
         AV5IBGE_sdtMunicipio = new GeneXus.Programs.core.SdtIBGE_sdtMunicipio(context);
         Gxm1municipio = new GeneXus.Programs.core.Sdtmunicipio(context);
         /* GeneXus formulas. */
      }

      private int AV9GXV2 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtmunicipio> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> AV8GXV1 ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> GXt_objcol_SdtIBGE_sdtMunicipio1 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtmunicipio> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtIBGE_sdtMunicipio AV5IBGE_sdtMunicipio ;
      private GeneXus.Programs.core.Sdtmunicipio Gxm1municipio ;
   }

}
