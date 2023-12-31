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
namespace GeneXus.Programs.wwpbaseobjects {
   public class savegridstate : GXProcedure
   {
      public savegridstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public savegridstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomKey ,
                           string aP1_UserCustomValue )
      {
         this.AV8UserCustomKey = aP0_UserCustomKey;
         this.AV9UserCustomValue = aP1_UserCustomValue;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_UserCustomKey ,
                                 string aP1_UserCustomValue )
      {
         savegridstate objsavegridstate;
         objsavegridstate = new savegridstate();
         objsavegridstate.AV8UserCustomKey = aP0_UserCustomKey;
         objsavegridstate.AV9UserCustomValue = aP1_UserCustomValue;
         objsavegridstate.context.SetSubmitInitialConfig(context);
         objsavegridstate.initialize();
         Submit( executePrivateCatch,objsavegridstate);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((savegridstate)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue(context ).execute(  AV8UserCustomKey,  AV9UserCustomValue) ;
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
         /* GeneXus formulas. */
      }

      private string AV8UserCustomKey ;
      private string AV9UserCustomValue ;
   }

}
