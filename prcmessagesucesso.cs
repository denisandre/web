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
   public class prcmessagesucesso : GXProcedure
   {
      public prcmessagesucesso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcmessagesucesso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Utils.SdtMessages_Message aP0_Message )
      {
         this.AV11Message = new GeneXus.Utils.SdtMessages_Message(context) ;
         initialize();
         executePrivate();
         aP0_Message=this.AV11Message;
      }

      public GeneXus.Utils.SdtMessages_Message executeUdp( )
      {
         execute(out aP0_Message);
         return AV11Message ;
      }

      public void executeSubmit( out GeneXus.Utils.SdtMessages_Message aP0_Message )
      {
         prcmessagesucesso objprcmessagesucesso;
         objprcmessagesucesso = new prcmessagesucesso();
         objprcmessagesucesso.AV11Message = new GeneXus.Utils.SdtMessages_Message(context) ;
         objprcmessagesucesso.context.SetSubmitInitialConfig(context);
         objprcmessagesucesso.initialize();
         Submit( executePrivateCatch,objprcmessagesucesso);
         aP0_Message=this.AV11Message;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcmessagesucesso)stateInfo).executePrivate();
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
         GXt_SdtMessages_Message1 = AV11Message;
         new prcmessage(context ).execute(  "OK",  2,  "OK", out  GXt_SdtMessages_Message1) ;
         AV11Message = GXt_SdtMessages_Message1;
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
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_SdtMessages_Message1 = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private GeneXus.Utils.SdtMessages_Message aP0_Message ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private GeneXus.Utils.SdtMessages_Message GXt_SdtMessages_Message1 ;
   }

}
