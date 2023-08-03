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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_sendpendingnotifications : GXProcedure
   {
      public wwp_sendpendingnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendpendingnotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         wwp_sendpendingnotifications objwwp_sendpendingnotifications;
         objwwp_sendpendingnotifications = new wwp_sendpendingnotifications();
         objwwp_sendpendingnotifications.context.SetSubmitInitialConfig(context);
         objwwp_sendpendingnotifications.initialize();
         Submit( executePrivateCatch,objwwp_sendpendingnotifications);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendpendingnotifications)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'SENDPENDINGMAILS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGSMS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGWEBNOTIFICATIONS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SENDPENDINGMOBILENOTIFICATIONS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SENDPENDINGMAILS' Routine */
         returnInSub = false;
         GXt_SdtWWP_SMTPParametersSDT1 = AV8SMTPParametersSDT;
         new GeneXus.Programs.wwpbaseobjects.mail.wwp_getsmtpparameters(context ).execute( out  GXt_SdtWWP_SMTPParametersSDT1) ;
         AV8SMTPParametersSDT = GXt_SdtWWP_SMTPParametersSDT1;
         AV9SmtpSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV9SmtpSession.Host = AV8SMTPParametersSDT.gxTpr_Host;
         AV9SmtpSession.Port = AV8SMTPParametersSDT.gxTpr_Port;
         AV9SmtpSession.UserName = AV8SMTPParametersSDT.gxTpr_Username;
         AV9SmtpSession.Password = AV8SMTPParametersSDT.gxTpr_Password;
         AV9SmtpSession.Authentication = AV8SMTPParametersSDT.gxTpr_Authentication;
         AV9SmtpSession.Secure = AV8SMTPParametersSDT.gxTpr_Secure;
         AV9SmtpSession.Timeout = AV8SMTPParametersSDT.gxTpr_Timeout;
         AV14StatusCode = AV9SmtpSession.Login();
         if ( AV14StatusCode != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV15Pgmname,  "Error during SMTP Login: "+AV9SmtpSession.ErrDescription) ;
         }
         else
         {
            /* Using cursor P00352 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A123WWPMailStatus = P00352_A123WWPMailStatus[0];
               A122WWPMailId = P00352_A122WWPMailId[0];
               GXt_int2 = AV14StatusCode;
               new GeneXus.Programs.wwpbaseobjects.mail.wwp_sendmail(context ).execute(  A122WWPMailId, ref  AV9SmtpSession, out  GXt_int2) ;
               AV14StatusCode = GXt_int2;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV9SmtpSession.Logout();
         }
      }

      protected void S121( )
      {
         /* 'SENDPENDINGSMS' Routine */
         returnInSub = false;
         GXt_SdtWWP_SMSParametersSDT3 = AV10SMSParametersSDT;
         new GeneXus.Programs.wwpbaseobjects.sms.wwp_getsmsparameters(context ).execute( out  GXt_SdtWWP_SMSParametersSDT3) ;
         AV10SMSParametersSDT = GXt_SdtWWP_SMSParametersSDT3;
         /* Using cursor P00353 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A76WWPSMSStatus = P00353_A76WWPSMSStatus[0];
            A75WWPSMSId = P00353_A75WWPSMSId[0];
            new GeneXus.Programs.wwpbaseobjects.sms.wwp_sendsms(context ).execute(  A75WWPSMSId,  AV10SMSParametersSDT, out  AV12Success, out  AV13SendSMSResultSDT) ;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S131( )
      {
         /* 'SENDPENDINGWEBNOTIFICATIONS' Routine */
         returnInSub = false;
         /* Using cursor P00354 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A96WWPWebNotificationStatus = P00354_A96WWPWebNotificationStatus[0];
            A89WWPWebNotificationId = P00354_A89WWPWebNotificationId[0];
            GXt_int2 = AV11SendStatus;
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_sendwebnotification(context ).execute(  A89WWPWebNotificationId, out  GXt_int2) ;
            AV11SendStatus = GXt_int2;
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S141( )
      {
         /* 'SENDPENDINGMOBILENOTIFICATIONS' Routine */
         returnInSub = false;
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
         AV8SMTPParametersSDT = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         GXt_SdtWWP_SMTPParametersSDT1 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT(context);
         AV9SmtpSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV15Pgmname = "";
         scmdbuf = "";
         P00352_A123WWPMailStatus = new short[1] ;
         P00352_A122WWPMailId = new long[1] ;
         AV10SMSParametersSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context);
         GXt_SdtWWP_SMSParametersSDT3 = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT(context);
         P00353_A76WWPSMSStatus = new short[1] ;
         P00353_A75WWPSMSId = new long[1] ;
         AV13SendSMSResultSDT = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT(context);
         P00354_A96WWPWebNotificationStatus = new short[1] ;
         P00354_A89WWPWebNotificationId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications__default(),
            new Object[][] {
                new Object[] {
               P00352_A123WWPMailStatus, P00352_A122WWPMailId
               }
               , new Object[] {
               P00353_A76WWPSMSStatus, P00353_A75WWPSMSId
               }
               , new Object[] {
               P00354_A96WWPWebNotificationStatus, P00354_A89WWPWebNotificationId
               }
            }
         );
         AV15Pgmname = "WWPBaseObjects.Notifications.Common.WWP_SendPendingNotifications";
         /* GeneXus formulas. */
         AV15Pgmname = "WWPBaseObjects.Notifications.Common.WWP_SendPendingNotifications";
      }

      private short AV14StatusCode ;
      private short A123WWPMailStatus ;
      private short A76WWPSMSStatus ;
      private short A96WWPWebNotificationStatus ;
      private short AV11SendStatus ;
      private short GXt_int2 ;
      private long A122WWPMailId ;
      private long A75WWPSMSId ;
      private long A89WWPWebNotificationId ;
      private string AV15Pgmname ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV12Success ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00352_A123WWPMailStatus ;
      private long[] P00352_A122WWPMailId ;
      private short[] P00353_A76WWPSMSStatus ;
      private long[] P00353_A75WWPSMSId ;
      private short[] P00354_A96WWPWebNotificationStatus ;
      private long[] P00354_A89WWPWebNotificationId ;
      private GeneXus.Mail.GXSMTPSession AV9SmtpSession ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT AV8SMTPParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_SMTPParametersSDT GXt_SdtWWP_SMTPParametersSDT1 ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT AV10SMSParametersSDT ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMSParametersSDT GXt_SdtWWP_SMSParametersSDT3 ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SendSMSResultSDT AV13SendSMSResultSDT ;
   }

   public class wwp_sendpendingnotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00352;
          prmP00352 = new Object[] {
          };
          Object[] prmP00353;
          prmP00353 = new Object[] {
          };
          Object[] prmP00354;
          prmP00354 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00352", "SELECT WWPMailStatus, WWPMailId FROM WWP_Mail WHERE WWPMailStatus = 1 ORDER BY WWPMailId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00352,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00353", "SELECT WWPSMSStatus, WWPSMSId FROM WWP_SMS WHERE WWPSMSStatus = 1 ORDER BY WWPSMSId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00353,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00354", "SELECT WWPWebNotificationStatus, WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationStatus = 1 ORDER BY WWPWebNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00354,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
