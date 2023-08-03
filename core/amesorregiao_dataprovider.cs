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
   public class amesorregiao_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.amesorregiao_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao>()  ;
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

      public amesorregiao_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amesorregiao_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao>( context, "mesorregiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao> aP0_Gxm2rootcol )
      {
         amesorregiao_dataprovider objamesorregiao_dataprovider;
         objamesorregiao_dataprovider = new amesorregiao_dataprovider();
         objamesorregiao_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao>( context, "mesorregiao", "agl_tresorygroup") ;
         objamesorregiao_dataprovider.context.SetSubmitInitialConfig(context);
         objamesorregiao_dataprovider.initialize();
         Submit( executePrivateCatch,objamesorregiao_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((amesorregiao_dataprovider)stateInfo).executePrivate();
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
         AV10GXV2 = 1;
         GXt_objcol_SdtIBGE_sdtMesorregiao1 = AV9GXV1;
         new GeneXus.Programs.core.ibge_lerapilocalidades_mesorregiao(context ).execute( out  GXt_objcol_SdtIBGE_sdtMesorregiao1) ;
         AV9GXV1 = GXt_objcol_SdtIBGE_sdtMesorregiao1;
         while ( AV10GXV2 <= AV9GXV1.Count )
         {
            AV6IBGE_sdtMesorregiao = ((GeneXus.Programs.core.SdtIBGE_sdtMesorregiao)AV9GXV1.Item(AV10GXV2));
            Gxm1mesorregiao = new GeneXus.Programs.core.Sdtmesorregiao(context);
            Gxm2rootcol.Add(Gxm1mesorregiao, 0);
            Gxm1mesorregiao.gxTpr_Mesorregiaoid = (int)(Math.Round(AV6IBGE_sdtMesorregiao.gxTpr_Id, 18, MidpointRounding.ToEven));
            Gxm1mesorregiao.gxTpr_Mesorregiaonome = AV6IBGE_sdtMesorregiao.gxTpr_Nome;
            Gxm1mesorregiao.gxTpr_Mesorregiaoufid = (int)(Math.Round(AV6IBGE_sdtMesorregiao.gxTpr_Uf.gxTpr_Id, 18, MidpointRounding.ToEven));
            AV10GXV2 = (int)(AV10GXV2+1);
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
         AV9GXV1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao>( context, "IBGE_sdtMesorregiao", "agl_tresorygroup");
         GXt_objcol_SdtIBGE_sdtMesorregiao1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao>( context, "IBGE_sdtMesorregiao", "agl_tresorygroup");
         AV6IBGE_sdtMesorregiao = new GeneXus.Programs.core.SdtIBGE_sdtMesorregiao(context);
         Gxm1mesorregiao = new GeneXus.Programs.core.Sdtmesorregiao(context);
         /* GeneXus formulas. */
      }

      private int AV10GXV2 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> AV9GXV1 ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMesorregiao> GXt_objcol_SdtIBGE_sdtMesorregiao1 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtmesorregiao> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtIBGE_sdtMesorregiao AV6IBGE_sdtMesorregiao ;
      private GeneXus.Programs.core.Sdtmesorregiao Gxm1mesorregiao ;
   }

}
