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
   public class auf_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new core.auf_dataprovider().executeCmdLine(args); ;
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
         GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtuf>()  ;
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

      public auf_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auf_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtuf>( context, "uf", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtuf> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_Gxm2rootcol )
      {
         auf_dataprovider objauf_dataprovider;
         objauf_dataprovider = new auf_dataprovider();
         objauf_dataprovider.Gxm2rootcol = new GXBCCollection<GeneXus.Programs.core.Sdtuf>( context, "uf", "agl_tresorygroup") ;
         objauf_dataprovider.context.SetSubmitInitialConfig(context);
         objauf_dataprovider.initialize();
         Submit( executePrivateCatch,objauf_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auf_dataprovider)stateInfo).executePrivate();
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
         AV14GXV2 = 1;
         GXt_objcol_SdtIBGE_sdtUF1 = AV13GXV1;
         new GeneXus.Programs.core.ibge_lerapilocalidades_uf(context ).execute( out  GXt_objcol_SdtIBGE_sdtUF1) ;
         AV13GXV1 = GXt_objcol_SdtIBGE_sdtUF1;
         while ( AV14GXV2 <= AV13GXV1.Count )
         {
            AV9IBGE_sdtUF = ((GeneXus.Programs.core.SdtIBGE_sdtUF)AV13GXV1.Item(AV14GXV2));
            Gxm1uf = new GeneXus.Programs.core.Sdtuf(context);
            Gxm2rootcol.Add(Gxm1uf, 0);
            Gxm1uf.gxTpr_Ufid = (int)(Math.Round(AV9IBGE_sdtUF.gxTpr_Id, 18, MidpointRounding.ToEven));
            Gxm1uf.gxTpr_Ufsigla = AV9IBGE_sdtUF.gxTpr_Sigla;
            Gxm1uf.gxTpr_Ufnome = AV9IBGE_sdtUF.gxTpr_Nome;
            Gxm1uf.gxTpr_Ufregid = (int)(Math.Round(AV9IBGE_sdtUF.gxTpr_Regiao.gxTpr_Id, 18, MidpointRounding.ToEven));
            AV14GXV2 = (int)(AV14GXV2+1);
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
         AV13GXV1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF>( context, "IBGE_sdtUF", "agl_tresorygroup");
         GXt_objcol_SdtIBGE_sdtUF1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF>( context, "IBGE_sdtUF", "agl_tresorygroup");
         AV9IBGE_sdtUF = new GeneXus.Programs.core.SdtIBGE_sdtUF(context);
         Gxm1uf = new GeneXus.Programs.core.Sdtuf(context);
         /* GeneXus formulas. */
      }

      private int AV14GXV2 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> AV13GXV1 ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtUF> GXt_objcol_SdtIBGE_sdtUF1 ;
      private GXBCCollection<GeneXus.Programs.core.Sdtuf> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtIBGE_sdtUF AV9IBGE_sdtUF ;
      private GeneXus.Programs.core.Sdtuf Gxm1uf ;
   }

}
