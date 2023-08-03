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
   public class wwp_sendnotification : GXProcedure
   {
      public wwp_sendnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_pWWPNotificationDefinitionIcon ,
                           string aP4_pWWPNotificationDefinitionTitle ,
                           string aP5_pWWPNotificationDefinitionShortDescription ,
                           string aP6_pWWPNotificationDefinitionLongDescription ,
                           string aP7_pWWPNotificationDefinitionLink ,
                           string aP8_WWPNotificationMetadata ,
                           string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                           bool aP10_MakeCommit )
      {
         this.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV18WWPEntityName = aP1_WWPEntityName;
         this.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         this.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         this.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         this.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         this.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         this.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         this.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         this.AV9MakeCommit = aP10_MakeCommit;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_pWWPNotificationDefinitionIcon ,
                                 string aP4_pWWPNotificationDefinitionTitle ,
                                 string aP5_pWWPNotificationDefinitionShortDescription ,
                                 string aP6_pWWPNotificationDefinitionLongDescription ,
                                 string aP7_pWWPNotificationDefinitionLink ,
                                 string aP8_WWPNotificationMetadata ,
                                 string aP9_ExcludedWWPUserExtendedIdCollectionJson ,
                                 bool aP10_MakeCommit )
      {
         wwp_sendnotification objwwp_sendnotification;
         objwwp_sendnotification = new wwp_sendnotification();
         objwwp_sendnotification.AV23WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_sendnotification.AV18WWPEntityName = aP1_WWPEntityName;
         objwwp_sendnotification.AV27WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         objwwp_sendnotification.AV13pWWPNotificationDefinitionIcon = aP3_pWWPNotificationDefinitionIcon;
         objwwp_sendnotification.AV17pWWPNotificationDefinitionTitle = aP4_pWWPNotificationDefinitionTitle;
         objwwp_sendnotification.AV16pWWPNotificationDefinitionShortDescription = aP5_pWWPNotificationDefinitionShortDescription;
         objwwp_sendnotification.AV15pWWPNotificationDefinitionLongDescription = aP6_pWWPNotificationDefinitionLongDescription;
         objwwp_sendnotification.AV14pWWPNotificationDefinitionLink = aP7_pWWPNotificationDefinitionLink;
         objwwp_sendnotification.AV26WWPNotificationMetadata = aP8_WWPNotificationMetadata;
         objwwp_sendnotification.AV11ExcludedWWPUserExtendedIdCollectionJson = aP9_ExcludedWWPUserExtendedIdCollectionJson;
         objwwp_sendnotification.AV9MakeCommit = aP10_MakeCommit;
         objwwp_sendnotification.context.SetSubmitInitialConfig(context);
         objwwp_sendnotification.initialize();
         Submit( executePrivateCatch,objwwp_sendnotification);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_sendnotification)stateInfo).executePrivate();
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11ExcludedWWPUserExtendedIdCollectionJson)) )
         {
            AV10ExcludedWWPUserExtendedIdCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         }
         else
         {
            AV10ExcludedWWPUserExtendedIdCollection.FromJSonString(AV11ExcludedWWPUserExtendedIdCollectionJson, null);
         }
         AV10ExcludedWWPUserExtendedIdCollection.Add(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ), 0);
         AV29Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV18WWPEntityName);
         /* Using cursor P00332 */
         pr_default.execute(0, new Object[] {AV29Udparg1, AV23WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A65WWPNotificationDefinitionId = P00332_A65WWPNotificationDefinitionId[0];
            A62WWPEntityId = P00332_A62WWPEntityId[0];
            A101WWPNotificationDefinitionName = P00332_A101WWPNotificationDefinitionName[0];
            A104WWPNotificationDefinitionIcon = P00332_A104WWPNotificationDefinitionIcon[0];
            A105WWPNotificationDefinitionTitle = P00332_A105WWPNotificationDefinitionTitle[0];
            A106WWPNotificationDefinitionShort = P00332_A106WWPNotificationDefinitionShort[0];
            A107WWPNotificationDefinitionLongD = P00332_A107WWPNotificationDefinitionLongD[0];
            A108WWPNotificationDefinitionLink = P00332_A108WWPNotificationDefinitionLink[0];
            AV20WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13pWWPNotificationDefinitionIcon)) )
            {
               AV19WWPNotificationDefinitionIcon = A104WWPNotificationDefinitionIcon;
            }
            else
            {
               AV19WWPNotificationDefinitionIcon = AV13pWWPNotificationDefinitionIcon;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17pWWPNotificationDefinitionTitle)) )
            {
               AV25WWPNotificationDefinitionTitle = A105WWPNotificationDefinitionTitle;
            }
            else
            {
               AV25WWPNotificationDefinitionTitle = AV17pWWPNotificationDefinitionTitle;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16pWWPNotificationDefinitionShortDescription)) )
            {
               AV24WWPNotificationDefinitionShortDescription = A106WWPNotificationDefinitionShort;
            }
            else
            {
               AV24WWPNotificationDefinitionShortDescription = AV16pWWPNotificationDefinitionShortDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15pWWPNotificationDefinitionLongDescription)) )
            {
               AV22WWPNotificationDefinitionLongDescription = A107WWPNotificationDefinitionLongD;
            }
            else
            {
               AV22WWPNotificationDefinitionLongDescription = AV15pWWPNotificationDefinitionLongDescription;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14pWWPNotificationDefinitionLink)) )
            {
               AV21WWPNotificationDefinitionLink = A108WWPNotificationDefinitionLink;
            }
            else
            {
               AV21WWPNotificationDefinitionLink = AV14pWWPNotificationDefinitionLink;
            }
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV27WWPSubscriptionEntityRecordId ,
                                                 A68WWPSubscriptionEntityRecordId ,
                                                 A65WWPNotificationDefinitionId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00333 */
            pr_default.execute(1, new Object[] {A65WWPNotificationDefinitionId, AV27WWPSubscriptionEntityRecordId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A68WWPSubscriptionEntityRecordId = P00333_A68WWPSubscriptionEntityRecordId[0];
               A49WWPUserExtendedId = P00333_A49WWPUserExtendedId[0];
               n49WWPUserExtendedId = P00333_n49WWPUserExtendedId[0];
               A69WWPSubscriptionSubscribed = P00333_A69WWPSubscriptionSubscribed[0];
               A61WWPSubscriptionRoleId = P00333_A61WWPSubscriptionRoleId[0];
               n61WWPSubscriptionRoleId = P00333_n61WWPSubscriptionRoleId[0];
               A67WWPSubscriptionId = P00333_A67WWPSubscriptionId[0];
               if ( ! ( (AV10ExcludedWWPUserExtendedIdCollection.IndexOf(StringUtil.RTrim( A49WWPUserExtendedId))>0) ) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) && A69WWPSubscriptionSubscribed )
                  {
                     AV8WWPUserExtendedId = A49WWPUserExtendedId;
                     new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, "Discussion")) ;
                  }
                  else
                  {
                     AV32GXV2 = 1;
                     GXt_objcol_char1 = AV31GXV1;
                     new GeneXus.Programs.wwpbaseobjects.wwp_getusersfromrole(context ).execute(  A61WWPSubscriptionRoleId, out  GXt_objcol_char1) ;
                     AV31GXV1 = GXt_objcol_char1;
                     while ( AV32GXV2 <= AV31GXV1.Count )
                     {
                        AV8WWPUserExtendedId = AV31GXV1.GetString(AV32GXV2);
                        /* Execute user subroutine: 'INCLUDENOTIFICATIONTOUSER' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(1);
                           this.cleanup();
                           if (true) return;
                        }
                        if ( AV12IncludeNotificationToUser )
                        {
                           new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_createnotificationtouser(context ).execute(  AV8WWPUserExtendedId,  AV20WWPNotificationDefinitionId,  AV25WWPNotificationDefinitionTitle,  AV24WWPNotificationDefinitionShortDescription,  AV22WWPNotificationDefinitionLongDescription, ref  AV21WWPNotificationDefinitionLink,  AV26WWPNotificationMetadata,  AV19WWPNotificationDefinitionIcon,  StringUtil.StartsWith( AV23WWPNotificationDefinitionName, "Discussion")) ;
                        }
                        AV32GXV2 = (int)(AV32GXV2+1);
                     }
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV9MakeCommit )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_sendnotification",pr_default);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendpendingnotifications(context).executeSubmit( ) ;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'INCLUDENOTIFICATIONTOUSER' Routine */
         returnInSub = false;
         /* Using cursor P00335 */
         pr_default.execute(2, new Object[] {AV20WWPNotificationDefinitionId, AV8WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = P00335_A40000GXC1[0];
            n40000GXC1 = P00335_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(2);
         AV12IncludeNotificationToUser = (bool)((A40000GXC1==0));
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
         AV10ExcludedWWPUserExtendedIdCollection = new GxSimpleCollection<string>();
         scmdbuf = "";
         P00332_A65WWPNotificationDefinitionId = new long[1] ;
         P00332_A62WWPEntityId = new long[1] ;
         P00332_A101WWPNotificationDefinitionName = new string[] {""} ;
         P00332_A104WWPNotificationDefinitionIcon = new string[] {""} ;
         P00332_A105WWPNotificationDefinitionTitle = new string[] {""} ;
         P00332_A106WWPNotificationDefinitionShort = new string[] {""} ;
         P00332_A107WWPNotificationDefinitionLongD = new string[] {""} ;
         P00332_A108WWPNotificationDefinitionLink = new string[] {""} ;
         A101WWPNotificationDefinitionName = "";
         A104WWPNotificationDefinitionIcon = "";
         A105WWPNotificationDefinitionTitle = "";
         A106WWPNotificationDefinitionShort = "";
         A107WWPNotificationDefinitionLongD = "";
         A108WWPNotificationDefinitionLink = "";
         AV19WWPNotificationDefinitionIcon = "";
         AV25WWPNotificationDefinitionTitle = "";
         AV24WWPNotificationDefinitionShortDescription = "";
         AV22WWPNotificationDefinitionLongDescription = "";
         AV21WWPNotificationDefinitionLink = "";
         A68WWPSubscriptionEntityRecordId = "";
         P00333_A65WWPNotificationDefinitionId = new long[1] ;
         P00333_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         P00333_A49WWPUserExtendedId = new string[] {""} ;
         P00333_n49WWPUserExtendedId = new bool[] {false} ;
         P00333_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         P00333_A61WWPSubscriptionRoleId = new string[] {""} ;
         P00333_n61WWPSubscriptionRoleId = new bool[] {false} ;
         P00333_A67WWPSubscriptionId = new long[1] ;
         A49WWPUserExtendedId = "";
         A61WWPSubscriptionRoleId = "";
         AV8WWPUserExtendedId = "";
         AV31GXV1 = new GxSimpleCollection<string>();
         GXt_objcol_char1 = new GxSimpleCollection<string>();
         P00335_A40000GXC1 = new int[1] ;
         P00335_n40000GXC1 = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification__default(),
            new Object[][] {
                new Object[] {
               P00332_A65WWPNotificationDefinitionId, P00332_A62WWPEntityId, P00332_A101WWPNotificationDefinitionName, P00332_A104WWPNotificationDefinitionIcon, P00332_A105WWPNotificationDefinitionTitle, P00332_A106WWPNotificationDefinitionShort, P00332_A107WWPNotificationDefinitionLongD, P00332_A108WWPNotificationDefinitionLink
               }
               , new Object[] {
               P00333_A65WWPNotificationDefinitionId, P00333_A68WWPSubscriptionEntityRecordId, P00333_A49WWPUserExtendedId, P00333_n49WWPUserExtendedId, P00333_A69WWPSubscriptionSubscribed, P00333_A61WWPSubscriptionRoleId, P00333_n61WWPSubscriptionRoleId, P00333_A67WWPSubscriptionId
               }
               , new Object[] {
               P00335_A40000GXC1, P00335_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV32GXV2 ;
      private int A40000GXC1 ;
      private long AV29Udparg1 ;
      private long A65WWPNotificationDefinitionId ;
      private long A62WWPEntityId ;
      private long AV20WWPNotificationDefinitionId ;
      private long A67WWPSubscriptionId ;
      private string scmdbuf ;
      private string A49WWPUserExtendedId ;
      private string A61WWPSubscriptionRoleId ;
      private string AV8WWPUserExtendedId ;
      private bool AV9MakeCommit ;
      private bool n49WWPUserExtendedId ;
      private bool A69WWPSubscriptionSubscribed ;
      private bool n61WWPSubscriptionRoleId ;
      private bool returnInSub ;
      private bool AV12IncludeNotificationToUser ;
      private bool n40000GXC1 ;
      private string AV26WWPNotificationMetadata ;
      private string AV11ExcludedWWPUserExtendedIdCollectionJson ;
      private string AV23WWPNotificationDefinitionName ;
      private string AV18WWPEntityName ;
      private string AV27WWPSubscriptionEntityRecordId ;
      private string AV13pWWPNotificationDefinitionIcon ;
      private string AV17pWWPNotificationDefinitionTitle ;
      private string AV16pWWPNotificationDefinitionShortDescription ;
      private string AV15pWWPNotificationDefinitionLongDescription ;
      private string AV14pWWPNotificationDefinitionLink ;
      private string A101WWPNotificationDefinitionName ;
      private string A104WWPNotificationDefinitionIcon ;
      private string A105WWPNotificationDefinitionTitle ;
      private string A106WWPNotificationDefinitionShort ;
      private string A107WWPNotificationDefinitionLongD ;
      private string A108WWPNotificationDefinitionLink ;
      private string AV19WWPNotificationDefinitionIcon ;
      private string AV25WWPNotificationDefinitionTitle ;
      private string AV24WWPNotificationDefinitionShortDescription ;
      private string AV22WWPNotificationDefinitionLongDescription ;
      private string AV21WWPNotificationDefinitionLink ;
      private string A68WWPSubscriptionEntityRecordId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00332_A65WWPNotificationDefinitionId ;
      private long[] P00332_A62WWPEntityId ;
      private string[] P00332_A101WWPNotificationDefinitionName ;
      private string[] P00332_A104WWPNotificationDefinitionIcon ;
      private string[] P00332_A105WWPNotificationDefinitionTitle ;
      private string[] P00332_A106WWPNotificationDefinitionShort ;
      private string[] P00332_A107WWPNotificationDefinitionLongD ;
      private string[] P00332_A108WWPNotificationDefinitionLink ;
      private long[] P00333_A65WWPNotificationDefinitionId ;
      private string[] P00333_A68WWPSubscriptionEntityRecordId ;
      private string[] P00333_A49WWPUserExtendedId ;
      private bool[] P00333_n49WWPUserExtendedId ;
      private bool[] P00333_A69WWPSubscriptionSubscribed ;
      private string[] P00333_A61WWPSubscriptionRoleId ;
      private bool[] P00333_n61WWPSubscriptionRoleId ;
      private long[] P00333_A67WWPSubscriptionId ;
      private int[] P00335_A40000GXC1 ;
      private bool[] P00335_n40000GXC1 ;
      private IDataStoreProvider pr_gam ;
      private GxSimpleCollection<string> AV10ExcludedWWPUserExtendedIdCollection ;
      private GxSimpleCollection<string> AV31GXV1 ;
      private GxSimpleCollection<string> GXt_objcol_char1 ;
   }

   public class wwp_sendnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class wwp_sendnotification__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00333( IGxContext context ,
                                           string AV27WWPSubscriptionEntityRecordId ,
                                           string A68WWPSubscriptionEntityRecordId ,
                                           long A65WWPNotificationDefinitionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int2 = new short[2];
       Object[] GXv_Object3 = new Object[2];
       scmdbuf = "SELECT WWPNotificationDefinitionId, WWPSubscriptionEntityRecordId, WWPUserExtendedId, WWPSubscriptionSubscribed, WWPSubscriptionRoleId, WWPSubscriptionId FROM WWP_Subscription";
       AddWhere(sWhereString, "(WWPNotificationDefinitionId = :WWPNotificationDefinitionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27WWPSubscriptionEntityRecordId)) )
       {
          AddWhere(sWhereString, "(WWPSubscriptionEntityRecordId = ( :AV27WWPSubscriptionEntityRecordId))");
       }
       else
       {
          GXv_int2[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY WWPNotificationDefinitionId";
       GXv_Object3[0] = scmdbuf;
       GXv_Object3[1] = GXv_int2;
       return GXv_Object3 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 1 :
                   return conditional_P00333(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP00332;
        prmP00332 = new Object[] {
        new ParDef("AV29Udparg1",GXType.Int64,10,0) ,
        new ParDef("AV23WWPNotificationDefinitionName",GXType.VarChar,100,0)
        };
        Object[] prmP00335;
        prmP00335 = new Object[] {
        new ParDef("AV20WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("AV8WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmP00333;
        prmP00333 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("AV27WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00332", "SELECT WWPNotificationDefinitionId, WWPEntityId, WWPNotificationDefinitionName, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV29Udparg1) AND (WWPNotificationDefinitionName = ( :AV23WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00332,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00333", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00333,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00335", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM (WWP_Subscription T2 INNER JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE (T2.WWPNotificationDefinitionId = :AV20WWPNotificationDefinitionId) AND (T2.WWPUserExtendedId = ( :AV8WWPUserExtendedId)) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00335,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 40);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
