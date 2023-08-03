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
   public class amicrorregiao_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.amicrorregiao_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao>()  ;
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

      public amicrorregiao_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amicrorregiao_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao>( context, "microrregiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao> aP0_Gxm2rootcol )
      {
         amicrorregiao_dataprovider objamicrorregiao_dataprovider;
         objamicrorregiao_dataprovider = new amicrorregiao_dataprovider();
         objamicrorregiao_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao>( context, "microrregiao", "agl_tresorygroup") ;
         objamicrorregiao_dataprovider.context.SetSubmitInitialConfig(context);
         objamicrorregiao_dataprovider.initialize();
         Submit( executePrivateCatch,objamicrorregiao_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((amicrorregiao_dataprovider)stateInfo).executePrivate();
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
         GXt_objcol_SdtIBGE_sdtMicrorregiao1 = AV8GXV1;
         new GeneXus.Programs.core.ibge_lerapilocalidades_microrregiao(context ).execute( out  GXt_objcol_SdtIBGE_sdtMicrorregiao1) ;
         AV8GXV1 = GXt_objcol_SdtIBGE_sdtMicrorregiao1;
         while ( AV9GXV2 <= AV8GXV1.Count )
         {
            AV5IBGE_sdtMicrorregiao = ((GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao)AV8GXV1.Item(AV9GXV2));
            Gxm1microrregiao = new GeneXus.Programs.core.Sdtmicrorregiao(context);
            Gxm2rootcol.Add(Gxm1microrregiao, 0);
            Gxm1microrregiao.gxTpr_Microrregiaoid = (int)(Math.Round(AV5IBGE_sdtMicrorregiao.gxTpr_Id, 18, MidpointRounding.ToEven));
            Gxm1microrregiao.gxTpr_Microrregiaonome = AV5IBGE_sdtMicrorregiao.gxTpr_Nome;
            Gxm1microrregiao.gxTpr_Microrregiaomesoid = (int)(Math.Round(AV5IBGE_sdtMicrorregiao.gxTpr_Mesorregiao.gxTpr_Id, 18, MidpointRounding.ToEven));
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
         AV8GXV1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao>( context, "IBGE_sdtMicrorregiao", "agl_tresorygroup");
         GXt_objcol_SdtIBGE_sdtMicrorregiao1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao>( context, "IBGE_sdtMicrorregiao", "agl_tresorygroup");
         AV5IBGE_sdtMicrorregiao = new GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao(context);
         Gxm1microrregiao = new GeneXus.Programs.core.Sdtmicrorregiao(context);
         /* GeneXus formulas. */
      }

      private int AV9GXV2 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> AV8GXV1 ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao> GXt_objcol_SdtIBGE_sdtMicrorregiao1 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtmicrorregiao> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtIBGE_sdtMicrorregiao AV5IBGE_sdtMicrorregiao ;
      private GeneXus.Programs.core.Sdtmicrorregiao Gxm1microrregiao ;
   }

}
