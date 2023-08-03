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
namespace GeneXus.Programs {
   public class acmddenistestes : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new acmddenistestes().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            Console.WriteLine( e.ToString() );
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         execute();
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

      public acmddenistestes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acmddenistestes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         acmddenistestes objacmddenistestes;
         objacmddenistestes = new acmddenistestes();
         objacmddenistestes.context.SetSubmitInitialConfig(context);
         objacmddenistestes.initialize();
         Submit( executePrivateCatch,objacmddenistestes);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acmddenistestes)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            Console.WriteLine( e.ToString() );
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtIBGE_sdtMunicipio1 = AV8IBGE_sdtMunicipioCollection;
         new GeneXus.Programs.core.ibge_lerapilocalidades_municipio(context ).execute( out  GXt_objcol_SdtIBGE_sdtMunicipio1) ;
         AV8IBGE_sdtMunicipioCollection = GXt_objcol_SdtIBGE_sdtMunicipio1;
         AV10Rand = (int)(NumberUtil.Int( (long)(NumberUtil.Random( )*1000000)));
         AV9File.Source = StringUtil.Format( "D:\\Temp\\municipios_%1.xml", StringUtil.Trim( StringUtil.Str( (decimal)(AV10Rand), 6, 0)), "", "", "", "", "", "", "", "");
         context.StatusMessage( StringUtil.Format( "gravando arquivo %1...", StringUtil.Trim( AV9File.GetAbsoluteName()), "", "", "", "", "", "", "", "") );
         AV9File.WriteAllText(AV8IBGE_sdtMunicipioCollection.ToXml(false, true, "core.IBGE_sdtMunicipioCollection", ""), "");
         context.StatusMessage( "fim" );
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
         AV8IBGE_sdtMunicipioCollection = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup");
         GXt_objcol_SdtIBGE_sdtMunicipio1 = new GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio>( context, "IBGE_sdtMunicipio", "agl_tresorygroup");
         AV9File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private int AV10Rand ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> AV8IBGE_sdtMunicipioCollection ;
      private GXBaseCollection<GeneXus.Programs.core.SdtIBGE_sdtMunicipio> GXt_objcol_SdtIBGE_sdtMunicipio1 ;
      private GxFile AV9File ;
   }

}
