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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_createnotificationtouser : GXProcedure
   {
      public wwp_createnotificationtouser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_createnotificationtouser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPUserExtendedId ,
                           long aP1_WWPNotificationDefinitionId ,
                           string aP2_WWPNotificationDefinitionTitle ,
                           string aP3_WWPNotificationDefinitionShortDescription ,
                           string aP4_WWPNotificationDefinitionLongDescription ,
                           ref string aP5_WWPNotificationDefinitionLink ,
                           string aP6_WWPNotificationMetadata ,
                           string aP7_WWPNotificationDefinitionIcon ,
                           bool aP8_IsDiscussionNotification )
      {
         this.AV16WWPUserExtendedId = aP0_WWPUserExtendedId;
         this.AV17WWPNotificationDefinitionId = aP1_WWPNotificationDefinitionId;
         this.AV11WWPNotificationDefinitionTitle = aP2_WWPNotificationDefinitionTitle;
         this.AV12WWPNotificationDefinitionShortDescription = aP3_WWPNotificationDefinitionShortDescription;
         this.AV13WWPNotificationDefinitionLongDescription = aP4_WWPNotificationDefinitionLongDescription;
         this.AV14WWPNotificationDefinitionLink = aP5_WWPNotificationDefinitionLink;
         this.AV15WWPNotificationMetadata = aP6_WWPNotificationMetadata;
         this.AV10WWPNotificationDefinitionIcon = aP7_WWPNotificationDefinitionIcon;
         this.AV25IsDiscussionNotification = aP8_IsDiscussionNotification;
         initialize();
         executePrivate();
         aP5_WWPNotificationDefinitionLink=this.AV14WWPNotificationDefinitionLink;
      }

      public void executeSubmit( string aP0_WWPUserExtendedId ,
                                 long aP1_WWPNotificationDefinitionId ,
                                 string aP2_WWPNotificationDefinitionTitle ,
                                 string aP3_WWPNotificationDefinitionShortDescription ,
                                 string aP4_WWPNotificationDefinitionLongDescription ,
                                 ref string aP5_WWPNotificationDefinitionLink ,
                                 string aP6_WWPNotificationMetadata ,
                                 string aP7_WWPNotificationDefinitionIcon ,
                                 bool aP8_IsDiscussionNotification )
      {
         wwp_createnotificationtouser objwwp_createnotificationtouser;
         objwwp_createnotificationtouser = new wwp_createnotificationtouser();
         objwwp_createnotificationtouser.AV16WWPUserExtendedId = aP0_WWPUserExtendedId;
         objwwp_createnotificationtouser.AV17WWPNotificationDefinitionId = aP1_WWPNotificationDefinitionId;
         objwwp_createnotificationtouser.AV11WWPNotificationDefinitionTitle = aP2_WWPNotificationDefinitionTitle;
         objwwp_createnotificationtouser.AV12WWPNotificationDefinitionShortDescription = aP3_WWPNotificationDefinitionShortDescription;
         objwwp_createnotificationtouser.AV13WWPNotificationDefinitionLongDescription = aP4_WWPNotificationDefinitionLongDescription;
         objwwp_createnotificationtouser.AV14WWPNotificationDefinitionLink = aP5_WWPNotificationDefinitionLink;
         objwwp_createnotificationtouser.AV15WWPNotificationMetadata = aP6_WWPNotificationMetadata;
         objwwp_createnotificationtouser.AV10WWPNotificationDefinitionIcon = aP7_WWPNotificationDefinitionIcon;
         objwwp_createnotificationtouser.AV25IsDiscussionNotification = aP8_IsDiscussionNotification;
         objwwp_createnotificationtouser.context.SetSubmitInitialConfig(context);
         objwwp_createnotificationtouser.initialize();
         Submit( executePrivateCatch,objwwp_createnotificationtouser);
         aP5_WWPNotificationDefinitionLink=this.AV14WWPNotificationDefinitionLink;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_createnotificationtouser)stateInfo).executePrivate();
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
         /* Using cursor P00342 */
         pr_default.execute(0, new Object[] {AV16WWPUserExtendedId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49WWPUserExtendedId = P00342_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = P00342_n49WWPUserExtendedId[0];
            A53WWPUserExtendedEmaiNotif = P00342_A53WWPUserExtendedEmaiNotif[0];
            A51WWPUserExtendedEmail = P00342_A51WWPUserExtendedEmail[0];
            A56WWPUserExtendedDesktopNotif = P00342_A56WWPUserExtendedDesktopNotif[0];
            A55WWPUserExtendedMobileNotif = P00342_A55WWPUserExtendedMobileNotif[0];
            A54WWPUserExtendedSMSNotif = P00342_A54WWPUserExtendedSMSNotif[0];
            A57WWPUserExtendedPhone = P00342_A57WWPUserExtendedPhone[0];
            AV23WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            AV23WWP_Notification.gxTpr_Wwpuserextendedid = AV16WWPUserExtendedId;
            AV23WWP_Notification.gxTpr_Wwpnotificationdefinitionid = AV17WWPNotificationDefinitionId;
            AV23WWP_Notification.gxTpr_Wwpnotificationtitle = AV11WWPNotificationDefinitionTitle;
            AV23WWP_Notification.gxTpr_Wwpnotificationshortdescription = AV12WWPNotificationDefinitionShortDescription;
            AV23WWP_Notification.gxTpr_Wwpnotificationicon = AV10WWPNotificationDefinitionIcon;
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_cleannotificationurl(context ).execute( ref  AV14WWPNotificationDefinitionLink) ;
            AV23WWP_Notification.gxTpr_Wwpnotificationlink = AV14WWPNotificationDefinitionLink;
            AV23WWP_Notification.gxTpr_Wwpnotificationmetadata = AV15WWPNotificationMetadata;
            AV23WWP_Notification.Save();
            AV18WWPNotificationID = AV23WWP_Notification.gxTpr_Wwpnotificationid;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+GXUtil.UrlEncode(StringUtil.LTrimStr(AV18WWPNotificationID,10,0));
            AV30SmsAndMailUrl = formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_cleannotificationurl(context ).execute( ref  AV30SmsAndMailUrl) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Notification_BaseURL", ref  AV26Notification_BaseUrl) ;
            AV30SmsAndMailUrl = StringUtil.Format( "%1%2", AV26Notification_BaseUrl, AV30SmsAndMailUrl, "", "", "", "", "", "", "");
            if ( A53WWPUserExtendedEmaiNotif )
            {
               AV28WWPUserExtendedEmail = A51WWPUserExtendedEmail;
               /* Execute user subroutine: 'CREATEMAIL' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( AV25IsDiscussionNotification || A56WWPUserExtendedDesktopNotif )
            {
               /* Execute user subroutine: 'CREATEDESKTOPNOTIFICATION' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( A55WWPUserExtendedMobileNotif )
            {
               /* Execute user subroutine: 'CREATEMOBILENOTIFICATION' */
               S141 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( A54WWPUserExtendedSMSNotif )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A57WWPUserExtendedPhone)) )
               {
                  AV29WWPUserExtendedPhone = A57WWPUserExtendedPhone;
                  /* Execute user subroutine: 'CREATESMS' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CREATEMAIL' Routine */
         returnInSub = false;
         AV19Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV19Mail.gxTpr_Wwpnotificationid = AV18WWPNotificationID;
         AV24MailTemplate.Load("MailNotification");
         if ( AV24MailTemplate.Success() )
         {
            AV19Mail.gxTpr_Wwpmailsendername = AV24MailTemplate.gxTpr_Wwpmailtemplatesendername;
            AV19Mail.gxTpr_Wwpmailsenderaddress = AV24MailTemplate.gxTpr_Wwpmailtemplatesenderaddress;
            AV22MailBody = AV24MailTemplate.gxTpr_Wwpmailtemplatebody;
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Sender_Name", ref  AV8SenderName) ;
            AV19Mail.gxTpr_Wwpmailsendername = AV8SenderName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Sender_Address", ref  AV9SenderAddress) ;
            AV19Mail.gxTpr_Wwpmailsenderaddress = AV9SenderAddress;
            AV22MailBody = AV13WWPNotificationDefinitionLongDescription;
         }
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[SHORT_DESCRIPTION]", AV12WWPNotificationDefinitionShortDescription);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[LONG_DESCRIPTION]", AV13WWPNotificationDefinitionLongDescription);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[TITLE]", AV11WWPNotificationDefinitionTitle);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[LINK]", AV30SmsAndMailUrl);
         AV22MailBody = StringUtil.StringReplace( AV22MailBody, "[BASE_URL]", AV26Notification_BaseUrl);
         AV19Mail.gxTpr_Wwpmailbody = AV22MailBody;
         AV19Mail.gxTpr_Wwpmailto = AV28WWPUserExtendedEmail;
         AV19Mail.gxTpr_Wwpmailsubject = AV11WWPNotificationDefinitionTitle;
         AV19Mail.Save();
      }

      protected void S121( )
      {
         /* 'CREATEDESKTOPNOTIFICATION' Routine */
         returnInSub = false;
         /* Using cursor P00343 */
         pr_default.execute(1, new Object[] {AV16WWPUserExtendedId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A49WWPUserExtendedId = P00343_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = P00343_n49WWPUserExtendedId[0];
            A90WWPWebClientId = P00343_A90WWPWebClientId[0];
            AV20WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            AV20WebNotification.gxTpr_Wwpnotificationid = AV18WWPNotificationID;
            AV20WebNotification.gxTpr_Wwpwebnotificationclientid = A90WWPWebClientId;
            AV20WebNotification.gxTpr_Wwpwebnotificationtitle = AV11WWPNotificationDefinitionTitle;
            AV20WebNotification.gxTpr_Wwpwebnotificationicon = AV10WWPNotificationDefinitionIcon;
            AV20WebNotification.gxTpr_Wwpwebnotificationtext = AV12WWPNotificationDefinitionShortDescription;
            AV20WebNotification.Save();
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S131( )
      {
         /* 'CREATESMS' Routine */
         returnInSub = false;
         AV21SMS = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         AV21SMS.gxTpr_Wwpnotificationid = AV18WWPNotificationID;
         AV21SMS.gxTpr_Wwpsmsmessage = AV12WWPNotificationDefinitionShortDescription;
         AV21SMS.gxTpr_Wwpsmsrecipientnumbers = AV29WWPUserExtendedPhone;
         new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "SMS_DefaultSender", ref  AV31TextParameter) ;
         AV21SMS.gxTpr_Wwpsmssendernumber = AV31TextParameter;
         AV21SMS.Save();
      }

      protected void S141( )
      {
         /* 'CREATEMOBILENOTIFICATION' Routine */
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
         scmdbuf = "";
         P00342_A49WWPUserExtendedId = new string[] {""} ;
         P00342_n49WWPUserExtendedId = new bool[] {false} ;
         P00342_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         P00342_A51WWPUserExtendedEmail = new string[] {""} ;
         P00342_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         P00342_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         P00342_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         P00342_A57WWPUserExtendedPhone = new string[] {""} ;
         A49WWPUserExtendedId = "";
         A51WWPUserExtendedEmail = "";
         A57WWPUserExtendedPhone = "";
         AV23WWP_Notification = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
         AV30SmsAndMailUrl = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26Notification_BaseUrl = "";
         AV28WWPUserExtendedEmail = "";
         AV29WWPUserExtendedPhone = "";
         AV19Mail = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
         AV24MailTemplate = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         AV22MailBody = "";
         AV8SenderName = "";
         AV9SenderAddress = "";
         P00343_A49WWPUserExtendedId = new string[] {""} ;
         P00343_n49WWPUserExtendedId = new bool[] {false} ;
         P00343_A90WWPWebClientId = new string[] {""} ;
         A90WWPWebClientId = "";
         AV20WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV21SMS = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
         AV31TextParameter = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser__default(),
            new Object[][] {
                new Object[] {
               P00342_A49WWPUserExtendedId, P00342_A53WWPUserExtendedEmaiNotif, P00342_A51WWPUserExtendedEmail, P00342_A56WWPUserExtendedDesktopNotif, P00342_A55WWPUserExtendedMobileNotif, P00342_A54WWPUserExtendedSMSNotif, P00342_A57WWPUserExtendedPhone
               }
               , new Object[] {
               P00343_A49WWPUserExtendedId, P00343_n49WWPUserExtendedId, P00343_A90WWPWebClientId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private long AV17WWPNotificationDefinitionId ;
      private long AV18WWPNotificationID ;
      private string AV16WWPUserExtendedId ;
      private string scmdbuf ;
      private string A49WWPUserExtendedId ;
      private string A57WWPUserExtendedPhone ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV29WWPUserExtendedPhone ;
      private string A90WWPWebClientId ;
      private bool AV25IsDiscussionNotification ;
      private bool n49WWPUserExtendedId ;
      private bool A53WWPUserExtendedEmaiNotif ;
      private bool A56WWPUserExtendedDesktopNotif ;
      private bool A55WWPUserExtendedMobileNotif ;
      private bool A54WWPUserExtendedSMSNotif ;
      private bool returnInSub ;
      private string AV15WWPNotificationMetadata ;
      private string AV22MailBody ;
      private string AV11WWPNotificationDefinitionTitle ;
      private string AV12WWPNotificationDefinitionShortDescription ;
      private string AV13WWPNotificationDefinitionLongDescription ;
      private string AV14WWPNotificationDefinitionLink ;
      private string AV10WWPNotificationDefinitionIcon ;
      private string A51WWPUserExtendedEmail ;
      private string AV30SmsAndMailUrl ;
      private string AV26Notification_BaseUrl ;
      private string AV28WWPUserExtendedEmail ;
      private string AV8SenderName ;
      private string AV9SenderAddress ;
      private string AV31TextParameter ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP5_WWPNotificationDefinitionLink ;
      private IDataStoreProvider pr_default ;
      private string[] P00342_A49WWPUserExtendedId ;
      private bool[] P00342_n49WWPUserExtendedId ;
      private bool[] P00342_A53WWPUserExtendedEmaiNotif ;
      private string[] P00342_A51WWPUserExtendedEmail ;
      private bool[] P00342_A56WWPUserExtendedDesktopNotif ;
      private bool[] P00342_A55WWPUserExtendedMobileNotif ;
      private bool[] P00342_A54WWPUserExtendedSMSNotif ;
      private string[] P00342_A57WWPUserExtendedPhone ;
      private string[] P00343_A49WWPUserExtendedId ;
      private bool[] P00343_n49WWPUserExtendedId ;
      private string[] P00343_A90WWPWebClientId ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail AV19Mail ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV20WebNotification ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS AV21SMS ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification AV23WWP_Notification ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate AV24MailTemplate ;
   }

   public class wwp_createnotificationtouser__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00342;
          prmP00342 = new Object[] {
          new ParDef("AV16WWPUserExtendedId",GXType.Char,40,0)
          };
          Object[] prmP00343;
          prmP00343 = new Object[] {
          new ParDef("AV16WWPUserExtendedId",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00342", "SELECT WWPUserExtendedId, WWPUserExtendedEmaiNotif, WWPUserExtendedEmail, WWPUserExtendedDesktopNotif, WWPUserExtendedMobileNotif, WWPUserExtendedSMSNotif, WWPUserExtendedPhone FROM WWP_UserExtended WHERE WWPUserExtendedId = ( :AV16WWPUserExtendedId) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00342,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00343", "SELECT WWPUserExtendedId, WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = ( :AV16WWPUserExtendedId) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00343,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
