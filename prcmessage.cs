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
   public class prcmessage : GXProcedure
   {
      public prcmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcmessage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Id ,
                           short aP1_Type ,
                           string aP2_Description ,
                           out GeneXus.Utils.SdtMessages_Message aP3_Message )
      {
         this.AV12Id = aP0_Id;
         this.AV13Type = aP1_Type;
         this.AV14Description = aP2_Description;
         this.AV15Message = new GeneXus.Utils.SdtMessages_Message(context) ;
         initialize();
         executePrivate();
         aP3_Message=this.AV15Message;
      }

      public GeneXus.Utils.SdtMessages_Message executeUdp( string aP0_Id ,
                                                           short aP1_Type ,
                                                           string aP2_Description )
      {
         execute(aP0_Id, aP1_Type, aP2_Description, out aP3_Message);
         return AV15Message ;
      }

      public void executeSubmit( string aP0_Id ,
                                 short aP1_Type ,
                                 string aP2_Description ,
                                 out GeneXus.Utils.SdtMessages_Message aP3_Message )
      {
         prcmessage objprcmessage;
         objprcmessage = new prcmessage();
         objprcmessage.AV12Id = aP0_Id;
         objprcmessage.AV13Type = aP1_Type;
         objprcmessage.AV14Description = aP2_Description;
         objprcmessage.AV15Message = new GeneXus.Utils.SdtMessages_Message(context) ;
         objprcmessage.context.SetSubmitInitialConfig(context);
         objprcmessage.initialize();
         Submit( executePrivateCatch,objprcmessage);
         aP3_Message=this.AV15Message;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcmessage)stateInfo).executePrivate();
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
         AV15Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV15Message.gxTpr_Id = AV12Id;
         AV15Message.gxTpr_Type = AV13Type;
         AV15Message.gxTpr_Description = AV14Description;
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
         AV15Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private short AV13Type ;
      private string AV12Id ;
      private string AV14Description ;
      private GeneXus.Utils.SdtMessages_Message aP3_Message ;
      private GeneXus.Utils.SdtMessages_Message AV15Message ;
   }

}
