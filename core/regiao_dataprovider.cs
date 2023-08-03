using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class regiao_dataprovider : GXProcedure
   {
      public regiao_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public regiao_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<GeneXus.Programs.core.Sdtregiao>( context, "regiao", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtregiao> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_ReturnValue )
      {
         regiao_dataprovider objregiao_dataprovider;
         objregiao_dataprovider = new regiao_dataprovider();
         objregiao_dataprovider.AV2ReturnValue = new GXBCCollection<GeneXus.Programs.core.Sdtregiao>( context, "regiao", "agl_tresorygroup") ;
         objregiao_dataprovider.context.SetSubmitInitialConfig(context);
         objregiao_dataprovider.initialize();
         Submit( executePrivateCatch,objregiao_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((regiao_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<GeneXus.Programs.core.Sdtregiao>)AV2ReturnValue} ;
         ClassLoader.Execute("core-aregiao_dataprovider","GeneXus.Programs","core.aregiao_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<GeneXus.Programs.core.Sdtregiao>)(args[0]) ;
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV2ReturnValue = new GXBCCollection<GeneXus.Programs.core.Sdtregiao>( context, "regiao", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<GeneXus.Programs.core.Sdtregiao> aP0_ReturnValue ;
      private GXBCCollection<GeneXus.Programs.core.Sdtregiao> AV2ReturnValue ;
   }

}
