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
   public class schedulervisitas : GXProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public schedulervisitas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public schedulervisitas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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
         schedulervisitas objschedulervisitas;
         objschedulervisitas = new schedulervisitas();
         objschedulervisitas.AV5dateFrom = aP0_dateFrom;
         objschedulervisitas.AV6dateTo = aP1_dateTo;
         objschedulervisitas.Gxm2schedulerevents = new SdtSchedulerEvents(context) ;
         objschedulervisitas.context.SetSubmitInitialConfig(context);
         objschedulervisitas.initialize();
         Submit( executePrivateCatch,objschedulervisitas);
         aP2_Gxm2schedulerevents=this.Gxm2schedulerevents;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((schedulervisitas)stateInfo).executePrivate();
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
         /* Using cursor P000L2 */
         pr_default.execute(0, new Object[] {AV5dateFrom, AV6dateTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A475VisDataFim = P000L2_A475VisDataFim[0];
            n475VisDataFim = P000L2_n475VisDataFim[0];
            A404VisData = P000L2_A404VisData[0];
            A398VisID = P000L2_A398VisID[0];
            A409VisAssunto = P000L2_A409VisAssunto[0];
            A410VisDescricao = P000L2_A410VisDescricao[0];
            n410VisDescricao = P000L2_n410VisDescricao[0];
            A417VisLink = P000L2_A417VisLink[0];
            n417VisLink = P000L2_n417VisLink[0];
            A406VisDataHora = P000L2_A406VisDataHora[0];
            Gxm1schedulerevents_items = new SdtSchedulerEvents_event(context);
            Gxm2schedulerevents.gxTpr_Items.Add(Gxm1schedulerevents_items, 0);
            Gxm1schedulerevents_items.gxTpr_Id = A398VisID.ToString();
            Gxm1schedulerevents_items.gxTpr_Name = StringUtil.Trim( A409VisAssunto);
            Gxm1schedulerevents_items.gxTpr_Notes = StringUtil.Trim( A410VisDescricao);
            Gxm1schedulerevents_items.gxTpr_Link = StringUtil.Trim( A417VisLink);
            Gxm1schedulerevents_items.gxTpr_Starttime = A406VisDataHora;
            GXt_dtime1 = DateTimeUtil.ResetTime( A475VisDataFim ) ;
            Gxm1schedulerevents_items.gxTpr_Endtime = GXt_dtime1;
            Gxm1schedulerevents_items.gxTpr_Additionalinformation = "";
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         P000L2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P000L2_n475VisDataFim = new bool[] {false} ;
         P000L2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P000L2_A398VisID = new Guid[] {Guid.Empty} ;
         P000L2_A409VisAssunto = new string[] {""} ;
         P000L2_A410VisDescricao = new string[] {""} ;
         P000L2_n410VisDescricao = new bool[] {false} ;
         P000L2_A417VisLink = new string[] {""} ;
         P000L2_n417VisLink = new bool[] {false} ;
         P000L2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         A475VisDataFim = DateTime.MinValue;
         A404VisData = DateTime.MinValue;
         A398VisID = Guid.Empty;
         A409VisAssunto = "";
         A410VisDescricao = "";
         A417VisLink = "";
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         Gxm1schedulerevents_items = new SdtSchedulerEvents_event(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.schedulervisitas__default(),
            new Object[][] {
                new Object[] {
               P000L2_A475VisDataFim, P000L2_n475VisDataFim, P000L2_A404VisData, P000L2_A398VisID, P000L2_A409VisAssunto, P000L2_A410VisDescricao, P000L2_n410VisDescricao, P000L2_A417VisLink, P000L2_n417VisLink, P000L2_A406VisDataHora
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string scmdbuf ;
      private DateTime A406VisDataHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV5dateFrom ;
      private DateTime AV6dateTo ;
      private DateTime A475VisDataFim ;
      private DateTime A404VisData ;
      private bool n475VisDataFim ;
      private bool n410VisDescricao ;
      private bool n417VisLink ;
      private string A410VisDescricao ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private Guid A398VisID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P000L2_A475VisDataFim ;
      private bool[] P000L2_n475VisDataFim ;
      private DateTime[] P000L2_A404VisData ;
      private Guid[] P000L2_A398VisID ;
      private string[] P000L2_A409VisAssunto ;
      private string[] P000L2_A410VisDescricao ;
      private bool[] P000L2_n410VisDescricao ;
      private string[] P000L2_A417VisLink ;
      private bool[] P000L2_n417VisLink ;
      private DateTime[] P000L2_A406VisDataHora ;
      private SdtSchedulerEvents aP2_Gxm2schedulerevents ;
      private SdtSchedulerEvents Gxm2schedulerevents ;
      private SdtSchedulerEvents_event Gxm1schedulerevents_items ;
   }

   public class schedulervisitas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000L2;
          prmP000L2 = new Object[] {
          new ParDef("AV5dateFrom",GXType.Date,8,0) ,
          new ParDef("AV6dateTo",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000L2", "SELECT VisDataFim, VisData, VisID, VisAssunto, VisDescricao, VisLink, VisDataHora FROM tb_visita WHERE (VisData >= :AV5dateFrom) AND (VisDataFim <= :AV6dateTo) ORDER BY VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                return;
       }
    }

 }

}
