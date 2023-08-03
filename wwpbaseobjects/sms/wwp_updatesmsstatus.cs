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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_updatesmsstatus : GXProcedure
   {
      public wwp_updatesmsstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_updatesmsstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SMSId ,
                           short aP1_SMSStatus ,
                           string aP2_SMSDetail )
      {
         this.AV10SMSId = aP0_SMSId;
         this.AV9SMSStatus = aP1_SMSStatus;
         this.AV8SMSDetail = aP2_SMSDetail;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_SMSId ,
                                 short aP1_SMSStatus ,
                                 string aP2_SMSDetail )
      {
         wwp_updatesmsstatus objwwp_updatesmsstatus;
         objwwp_updatesmsstatus = new wwp_updatesmsstatus();
         objwwp_updatesmsstatus.AV10SMSId = aP0_SMSId;
         objwwp_updatesmsstatus.AV9SMSStatus = aP1_SMSStatus;
         objwwp_updatesmsstatus.AV8SMSDetail = aP2_SMSDetail;
         objwwp_updatesmsstatus.context.SetSubmitInitialConfig(context);
         objwwp_updatesmsstatus.initialize();
         Submit( executePrivateCatch,objwwp_updatesmsstatus);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_updatesmsstatus)stateInfo).executePrivate();
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
         AV11SMS.Load(AV10SMSId);
         if ( AV11SMS.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV12Pgmname,  "SMS not found with id: "+StringUtil.Str( (decimal)(AV10SMSId), 10, 0)) ;
            this.cleanup();
            if (true) return;
         }
         AV11SMS.gxTpr_Wwpsmsprocessed = DateTimeUtil.ServerNowMs( context, pr_default);
         AV11SMS.gxTpr_Wwpsmsstatus = AV9SMSStatus;
         AV11SMS.gxTpr_Wwpsmsdetail = AV8SMSDetail;
         AV11SMS.Save();
         if ( AV11SMS.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV12Pgmname,  "Error updating SMS status with id: "+StringUtil.Str( (decimal)(AV10SMSId), 10, 0)) ;
            this.cleanup();
            if (true) return;
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
         AV11SMS = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         AV12Pgmname = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_updatesmsstatus__default(),
            new Object[][] {
            }
         );
         AV12Pgmname = "WWPBaseObjects.SMS.WWP_UpdateSMSStatus";
         /* GeneXus formulas. */
         AV12Pgmname = "WWPBaseObjects.SMS.WWP_UpdateSMSStatus";
      }

      private short AV9SMSStatus ;
      private long AV10SMSId ;
      private string AV12Pgmname ;
      private string AV8SMSDetail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS AV11SMS ;
   }

   public class wwp_updatesmsstatus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
