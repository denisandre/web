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
   public class uf_dataprovider : GXProcedure
   {
      public uf_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public uf_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<GeneXus.Programs.core.Sdtuf>( context, "uf", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<GeneXus.Programs.core.Sdtuf> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_ReturnValue )
      {
         uf_dataprovider objuf_dataprovider;
         objuf_dataprovider = new uf_dataprovider();
         objuf_dataprovider.AV2ReturnValue = new GXBCCollection<GeneXus.Programs.core.Sdtuf>( context, "uf", "agl_tresorygroup") ;
         objuf_dataprovider.context.SetSubmitInitialConfig(context);
         objuf_dataprovider.initialize();
         Submit( executePrivateCatch,objuf_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((uf_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<GeneXus.Programs.core.Sdtuf>)AV2ReturnValue} ;
         ClassLoader.Execute("core-auf_dataprovider","GeneXus.Programs","core.auf_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<GeneXus.Programs.core.Sdtuf>)(args[0]) ;
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
         AV2ReturnValue = new GXBCCollection<GeneXus.Programs.core.Sdtuf>( context, "uf", "agl_tresorygroup");
         /* GeneXus formulas. */
      }

      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<GeneXus.Programs.core.Sdtuf> aP0_ReturnValue ;
      private GXBCCollection<GeneXus.Programs.core.Sdtuf> AV2ReturnValue ;
   }

}
