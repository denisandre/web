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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_synchandler : GXProcedure
   {
      public wwp_synchandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public wwp_synchandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_GAMEvents ,
                           string aP1_inJson ,
                           out string aP2_outJson )
      {
         this.AV2GAMEvents = aP0_GAMEvents;
         this.AV3inJson = aP1_inJson;
         this.AV4outJson = "" ;
         initialize();
         executePrivate();
         aP2_outJson=this.AV4outJson;
      }

      public string executeUdp( string aP0_GAMEvents ,
                                string aP1_inJson )
      {
         execute(aP0_GAMEvents, aP1_inJson, out aP2_outJson);
         return AV4outJson ;
      }

      public void executeSubmit( string aP0_GAMEvents ,
                                 string aP1_inJson ,
                                 out string aP2_outJson )
      {
         wwp_synchandler objwwp_synchandler;
         objwwp_synchandler = new wwp_synchandler();
         objwwp_synchandler.AV2GAMEvents = aP0_GAMEvents;
         objwwp_synchandler.AV3inJson = aP1_inJson;
         objwwp_synchandler.AV4outJson = "" ;
         objwwp_synchandler.context.SetSubmitInitialConfig(context);
         objwwp_synchandler.initialize();
         Submit( executePrivateCatch,objwwp_synchandler);
         aP2_outJson=this.AV4outJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_synchandler)stateInfo).executePrivate();
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
         args = new Object[] {(string)AV2GAMEvents,(string)AV3inJson,(string)AV4outJson} ;
         ClassLoader.Execute("wwpbaseobjects-awwp_synchandler","GeneXus.Programs","wwpbaseobjects.awwp_synchandler", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4outJson = (string)(args[2]) ;
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
         AV4outJson = "";
         /* GeneXus formulas. */
      }

      private string AV2GAMEvents ;
      private string AV3inJson ;
      private string AV4outJson ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP2_outJson ;
   }

}
