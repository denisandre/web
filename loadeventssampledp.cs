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
   public class loadeventssampledp : GXProcedure
   {
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

      public loadeventssampledp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadeventssampledp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_dateFrom ,
                           DateTime aP1_dateTo ,
                           out SdtSchedulerEvents aP2_Gxm2schedulerevents )
      {
         this.AV5dateFrom = aP0_dateFrom;
         this.AV6dateTo = aP1_dateTo;
         this.Gxm2schedulerevents = new SdtSchedulerEvents(context) ;
         initialize();
         executePrivate();
         aP2_Gxm2schedulerevents=this.Gxm2schedulerevents;
      }

      public SdtSchedulerEvents executeUdp( DateTime aP0_dateFrom ,
                                            DateTime aP1_dateTo )
      {
         execute(aP0_dateFrom, aP1_dateTo, out aP2_Gxm2schedulerevents);
         return Gxm2schedulerevents ;
      }

      public void executeSubmit( DateTime aP0_dateFrom ,
                                 DateTime aP1_dateTo ,
                                 out SdtSchedulerEvents aP2_Gxm2schedulerevents )
      {
         loadeventssampledp objloadeventssampledp;
         objloadeventssampledp = new loadeventssampledp();
         objloadeventssampledp.AV5dateFrom = aP0_dateFrom;
         objloadeventssampledp.AV6dateTo = aP1_dateTo;
         objloadeventssampledp.Gxm2schedulerevents = new SdtSchedulerEvents(context) ;
         objloadeventssampledp.context.SetSubmitInitialConfig(context);
         objloadeventssampledp.initialize();
         Submit( executePrivateCatch,objloadeventssampledp);
         aP2_Gxm2schedulerevents=this.Gxm2schedulerevents;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadeventssampledp)stateInfo).executePrivate();
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
         Gxm1schedulerevents_items = new SdtSchedulerEvents_event(context);
         Gxm2schedulerevents.gxTpr_Items.Add(Gxm1schedulerevents_items, 0);
         Gxm1schedulerevents_items.gxTpr_Id = "Sample1";
         Gxm1schedulerevents_items.gxTpr_Name = "Wimbledon Match";
         Gxm1schedulerevents_items.gxTpr_Notes = "Wimbledon Match";
         Gxm1schedulerevents_items.gxTpr_Link = "http://www.genexus.com";
         Gxm1schedulerevents_items.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 15, 30, 0);
         Gxm1schedulerevents_items.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 17, 30, 0);
         Gxm1schedulerevents_items.gxTpr_Additionalinformation = "";
         Gxm1schedulerevents_items = new SdtSchedulerEvents_event(context);
         Gxm2schedulerevents.gxTpr_Items.Add(Gxm1schedulerevents_items, 0);
         Gxm1schedulerevents_items.gxTpr_Id = "Sample2";
         Gxm1schedulerevents_items.gxTpr_Name = "NBA Finals";
         Gxm1schedulerevents_items.gxTpr_Notes = "NBA Finals";
         Gxm1schedulerevents_items.gxTpr_Link = "http://www.gxtechnical.com";
         Gxm1schedulerevents_items.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 21, 0, 0);
         Gxm1schedulerevents_items.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 22, 45, 0);
         Gxm1schedulerevents_items.gxTpr_Additionalinformation = "";
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
         Gxm1schedulerevents_items = new SdtSchedulerEvents_event(context);
         Gx_date = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private DateTime AV5dateFrom ;
      private DateTime AV6dateTo ;
      private DateTime Gx_date ;
      private SdtSchedulerEvents aP2_Gxm2schedulerevents ;
      private SdtSchedulerEvents Gxm2schedulerevents ;
      private SdtSchedulerEvents_event Gxm1schedulerevents_items ;
   }

}
