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
   public class aregiao_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.aregiao_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtregiao>()  ;
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

      public aregiao_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aregiao_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtregiao>( context, "regiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtregiao> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_Gxm2rootcol )
      {
         aregiao_dataprovider objaregiao_dataprovider;
         objaregiao_dataprovider = new aregiao_dataprovider();
         objaregiao_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtregiao>( context, "regiao", "agl_tresorygroup") ;
         objaregiao_dataprovider.context.SetSubmitInitialConfig(context);
         objaregiao_dataprovider.initialize();
         Submit( executePrivateCatch,objaregiao_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aregiao_dataprovider)stateInfo).executePrivate();
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
         GXt_objcol_SdtIBGE_sdtRegiao1 = AV8GXV1;
         new GeneXus.Programs.core.ibge_lerapilocalidades_regiao(context ).execute( out  GXt_objcol_SdtIBGE_sdtRegiao1) ;
         AV8GXV1 = GXt_objcol_SdtIBGE_sdtRegiao1;
         while ( AV9GXV2 <= AV8GXV1.Count )
         {
            AV5IBGE_sdtRegiao = ((GeneXus.Programs.core.SdtIBGE_sdtRegiao)AV8GXV1.Item(AV9GXV2));
            Gxm1regiao = new GeneXus.Programs.core.Sdtregiao(context);
            Gxm2rootcol.Add(Gxm1regiao, 0);
            Gxm1regiao.gxTpr_Regiaoid = (int)(Math.Round(AV5IBGE_sdtRegiao.gxTpr_Id, 18, MidpointRounding.ToEven));
            Gxm1regiao.gxTpr_Regiaosigla = AV5IBGE_sdtRegiao.gxTpr_Sigla;
            Gxm1regiao.gxTpr_Regiaonome = AV5IBGE_sdtRegiao.gxTpr_Nome;
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
         AV8GXV1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao>( context, "IBGE_sdtRegiao", "agl_tresorygroup");
         GXt_objcol_SdtIBGE_sdtRegiao1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao>( context, "IBGE_sdtRegiao", "agl_tresorygroup");
         AV5IBGE_sdtRegiao = new GeneXus.Programs.core.SdtIBGE_sdtRegiao(context);
         Gxm1regiao = new GeneXus.Programs.core.Sdtregiao(context);
         /* GeneXus formulas. */
      }

      private int AV9GXV2 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> AV8GXV1 ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtRegiao> GXt_objcol_SdtIBGE_sdtRegiao1 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtregiao> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtIBGE_sdtRegiao AV5IBGE_sdtRegiao ;
      private GeneXus.Programs.core.Sdtregiao Gxm1regiao ;
   }

}
