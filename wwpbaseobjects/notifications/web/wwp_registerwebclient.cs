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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_registerwebclient : GXProcedure
   {
      public wwp_registerwebclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_registerwebclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClientId ,
                           short aP1_BrowserId ,
                           string aP2_BrowserVersion ,
                           string aP3_UserGUID )
      {
         this.AV13ClientId = aP0_ClientId;
         this.AV11BrowserId = aP1_BrowserId;
         this.AV12BrowserVersion = aP2_BrowserVersion;
         this.AV15UserGUID = aP3_UserGUID;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 short aP1_BrowserId ,
                                 string aP2_BrowserVersion ,
                                 string aP3_UserGUID )
      {
         wwp_registerwebclient objwwp_registerwebclient;
         objwwp_registerwebclient = new wwp_registerwebclient();
         objwwp_registerwebclient.AV13ClientId = aP0_ClientId;
         objwwp_registerwebclient.AV11BrowserId = aP1_BrowserId;
         objwwp_registerwebclient.AV12BrowserVersion = aP2_BrowserVersion;
         objwwp_registerwebclient.AV15UserGUID = aP3_UserGUID;
         objwwp_registerwebclient.context.SetSubmitInitialConfig(context);
         objwwp_registerwebclient.initialize();
         Submit( executePrivateCatch,objwwp_registerwebclient);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_registerwebclient)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Begin Web Client Registration") ;
         if ( ! new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended(context).executeUdp(  AV15UserGUID) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  StringUtil.Format( "Creating User Extended %1...", AV15UserGUID, "", "", "", "", "", "", "", "")) ;
            AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbyguid(AV15UserGUID, out  AV8GAMErrorCollection);
            new GeneXus.Programs.wwpbaseobjects.wwp_usersync(context ).execute(  "INS",  AV9GAMUser, out  AV10Messages) ;
         }
         AV17GXLvl7 = 0;
         /* Using cursor P002Y2 */
         pr_default.execute(0, new Object[] {AV13ClientId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A90WWPWebClientId = P002Y2_A90WWPWebClientId[0];
            A91WWPWebClientBrowserId = P002Y2_A91WWPWebClientBrowserId[0];
            A92WWPWebClientBrowserVersion = P002Y2_A92WWPWebClientBrowserVersion[0];
            A94WWPWebClientLastRegistered = P002Y2_A94WWPWebClientLastRegistered[0];
            A49WWPUserExtendedId = P002Y2_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = P002Y2_n49WWPUserExtendedId[0];
            AV17GXLvl7 = 1;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Updating Web Client") ;
            A91WWPWebClientBrowserId = AV11BrowserId;
            A92WWPWebClientBrowserVersion = AV12BrowserVersion;
            A94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A49WWPUserExtendedId = AV15UserGUID;
            n49WWPUserExtendedId = false;
            /* Using cursor P002Y3 */
            pr_default.execute(1, new Object[] {A91WWPWebClientBrowserId, A92WWPWebClientBrowserVersion, A94WWPWebClientLastRegistered, n49WWPUserExtendedId, A49WWPUserExtendedId, A90WWPWebClientId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV17GXLvl7 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Creating Web Client") ;
            /*
               INSERT RECORD ON TABLE WWP_WebClient

            */
            A90WWPWebClientId = AV13ClientId;
            A91WWPWebClientBrowserId = AV11BrowserId;
            A92WWPWebClientBrowserVersion = AV12BrowserVersion;
            A93WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A49WWPUserExtendedId = AV15UserGUID;
            n49WWPUserExtendedId = false;
            /* Using cursor P002Y4 */
            pr_default.execute(2, new Object[] {A90WWPWebClientId, A91WWPWebClientBrowserId, A92WWPWebClientBrowserVersion, A93WWPWebClientFirstRegistered, A94WWPWebClientLastRegistered, n49WWPUserExtendedId, A49WWPUserExtendedId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Completed Web Client Registration") ;
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_registerwebclient",pr_default);
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
         AV16Pgmname = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         scmdbuf = "";
         P002Y2_A90WWPWebClientId = new string[] {""} ;
         P002Y2_A91WWPWebClientBrowserId = new short[1] ;
         P002Y2_A92WWPWebClientBrowserVersion = new string[] {""} ;
         P002Y2_A94WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         P002Y2_A49WWPUserExtendedId = new string[] {""} ;
         P002Y2_n49WWPUserExtendedId = new bool[] {false} ;
         A90WWPWebClientId = "";
         A92WWPWebClientBrowserVersion = "";
         A94WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A49WWPUserExtendedId = "";
         A93WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient__default(),
            new Object[][] {
                new Object[] {
               P002Y2_A90WWPWebClientId, P002Y2_A91WWPWebClientBrowserId, P002Y2_A92WWPWebClientBrowserVersion, P002Y2_A94WWPWebClientLastRegistered, P002Y2_A49WWPUserExtendedId, P002Y2_n49WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         AV16Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
         /* GeneXus formulas. */
         AV16Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
      }

      private short AV11BrowserId ;
      private short AV17GXLvl7 ;
      private short A91WWPWebClientBrowserId ;
      private int GX_INS11 ;
      private string AV13ClientId ;
      private string AV15UserGUID ;
      private string AV16Pgmname ;
      private string scmdbuf ;
      private string A90WWPWebClientId ;
      private string A49WWPUserExtendedId ;
      private string Gx_emsg ;
      private DateTime A94WWPWebClientLastRegistered ;
      private DateTime A93WWPWebClientFirstRegistered ;
      private bool n49WWPUserExtendedId ;
      private string AV12BrowserVersion ;
      private string A92WWPWebClientBrowserVersion ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002Y2_A90WWPWebClientId ;
      private short[] P002Y2_A91WWPWebClientBrowserId ;
      private string[] P002Y2_A92WWPWebClientBrowserVersion ;
      private DateTime[] P002Y2_A94WWPWebClientLastRegistered ;
      private string[] P002Y2_A49WWPUserExtendedId ;
      private bool[] P002Y2_n49WWPUserExtendedId ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
   }

   public class wwp_registerwebclient__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002Y2;
          prmP002Y2 = new Object[] {
          new ParDef("AV13ClientId",GXType.Char,100,0)
          };
          Object[] prmP002Y3;
          prmP002Y3 = new Object[] {
          new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
          new ParDef("WWPWebClientId",GXType.Char,100,0)
          };
          Object[] prmP002Y4;
          prmP002Y4 = new Object[] {
          new ParDef("WWPWebClientId",GXType.Char,100,0) ,
          new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P002Y2", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = ( :AV13ClientId) ORDER BY WWPWebClientId  FOR UPDATE OF WWP_WebClient",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002Y3", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002Y3)
             ,new CursorDef("P002Y4", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP002Y4)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
