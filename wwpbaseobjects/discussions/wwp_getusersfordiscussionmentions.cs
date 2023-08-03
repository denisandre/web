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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_getusersfordiscussionmentions : GXProcedure
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwp_getusersfordiscussionmentions_Services_Execute" ;
         }

      }

      public wwp_getusersfordiscussionmentions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getusersfordiscussionmentions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchTxt ,
                           out string aP1_OptionsJson )
      {
         this.AV14SearchTxt = aP0_SearchTxt;
         this.AV13OptionsJson = "" ;
         initialize();
         executePrivate();
         aP1_OptionsJson=this.AV13OptionsJson;
      }

      public string executeUdp( string aP0_SearchTxt )
      {
         execute(aP0_SearchTxt, out aP1_OptionsJson);
         return AV13OptionsJson ;
      }

      public void executeSubmit( string aP0_SearchTxt ,
                                 out string aP1_OptionsJson )
      {
         wwp_getusersfordiscussionmentions objwwp_getusersfordiscussionmentions;
         objwwp_getusersfordiscussionmentions = new wwp_getusersfordiscussionmentions();
         objwwp_getusersfordiscussionmentions.AV14SearchTxt = aP0_SearchTxt;
         objwwp_getusersfordiscussionmentions.AV13OptionsJson = "" ;
         objwwp_getusersfordiscussionmentions.context.SetSubmitInitialConfig(context);
         objwwp_getusersfordiscussionmentions.initialize();
         Submit( executePrivateCatch,objwwp_getusersfordiscussionmentions);
         aP1_OptionsJson=this.AV13OptionsJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getusersfordiscussionmentions)stateInfo).executePrivate();
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
         AV12Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "agl_tresorygroup");
         AV10MaxOptions = 5;
         AV9CheckDuplicated = false;
         /* Execute user subroutine: 'SEARCH USERS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( AV12Options.Count < AV10MaxOptions )
         {
            AV9CheckDuplicated = true;
            /* Execute user subroutine: 'SEARCH USERS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            if ( AV12Options.Count < AV10MaxOptions )
            {
               AV9CheckDuplicated = true;
               /* Execute user subroutine: 'SEARCH USERS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
         }
         AV13OptionsJson = AV12Options.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCH USERS' Routine */
         returnInSub = false;
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
         /* Using cursor P003J2 */
         pr_default.execute(0, new Object[] {lV14SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A51WWPUserExtendedEmail = P003J2_A51WWPUserExtendedEmail[0];
            A50WWPUserExtendedFullName = P003J2_A50WWPUserExtendedFullName[0];
            A59WWPUserExtendedDeleted = P003J2_A59WWPUserExtendedDeleted[0];
            A58WWPUserExtendedName = P003J2_A58WWPUserExtendedName[0];
            A49WWPUserExtendedId = P003J2_A49WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = P003J2_A40000WWPUserExtendedPhoto_GXI[0];
            AV8WWPUserExtendedFullName = (String.IsNullOrEmpty(StringUtil.RTrim( A50WWPUserExtendedFullName)) ? A58WWPUserExtendedName : A50WWPUserExtendedFullName);
            AV11Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
            AV11Option.gxTpr_Id = A49WWPUserExtendedId;
            AV11Option.gxTpr_Displayname = AV8WWPUserExtendedFullName;
            AV11Option.gxTpr_Text.Add(AV8WWPUserExtendedFullName, 0);
            AV11Option.gxTpr_Text.Add(A51WWPUserExtendedEmail, 0);
            AV11Option.gxTpr_Text.Add(A40000WWPUserExtendedPhoto_GXI, 0);
            if ( ! AV9CheckDuplicated || ! StringUtil.Contains( AV12Options.ToJSonString(false), AV11Option.ToJSonString(false, true)) )
            {
               AV12Options.Add(AV11Option, 0);
            }
            if ( AV12Options.Count > AV10MaxOptions )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV13OptionsJson = "";
         AV12Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "agl_tresorygroup");
         lV14SearchTxt = "";
         scmdbuf = "";
         P003J2_A51WWPUserExtendedEmail = new string[] {""} ;
         P003J2_A50WWPUserExtendedFullName = new string[] {""} ;
         P003J2_A59WWPUserExtendedDeleted = new bool[] {false} ;
         P003J2_A58WWPUserExtendedName = new string[] {""} ;
         P003J2_A49WWPUserExtendedId = new string[] {""} ;
         P003J2_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         A51WWPUserExtendedEmail = "";
         A50WWPUserExtendedFullName = "";
         A58WWPUserExtendedName = "";
         A49WWPUserExtendedId = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         AV8WWPUserExtendedFullName = "";
         AV11Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_getusersfordiscussionmentions__default(),
            new Object[][] {
                new Object[] {
               P003J2_A51WWPUserExtendedEmail, P003J2_A50WWPUserExtendedFullName, P003J2_A59WWPUserExtendedDeleted, P003J2_A58WWPUserExtendedName, P003J2_A49WWPUserExtendedId, P003J2_A40000WWPUserExtendedPhoto_GXI
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10MaxOptions ;
      private string scmdbuf ;
      private string A49WWPUserExtendedId ;
      private bool AV9CheckDuplicated ;
      private bool returnInSub ;
      private bool A59WWPUserExtendedDeleted ;
      private string AV13OptionsJson ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A51WWPUserExtendedEmail ;
      private string A50WWPUserExtendedFullName ;
      private string A58WWPUserExtendedName ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string AV8WWPUserExtendedFullName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003J2_A51WWPUserExtendedEmail ;
      private string[] P003J2_A50WWPUserExtendedFullName ;
      private bool[] P003J2_A59WWPUserExtendedDeleted ;
      private string[] P003J2_A58WWPUserExtendedName ;
      private string[] P003J2_A49WWPUserExtendedId ;
      private string[] P003J2_A40000WWPUserExtendedPhoto_GXI ;
      private string aP1_OptionsJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV12Options ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem AV11Option ;
   }

   public class wwp_getusersfordiscussionmentions__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003J2;
          prmP003J2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003J2", "SELECT WWPUserExtendedEmail, WWPUserExtendedFullName, WWPUserExtendedDeleted, WWPUserExtendedName, WWPUserExtendedId, WWPUserExtendedPhoto_GXI FROM WWP_UserExtended WHERE (Not ( WWPUserExtendedDeleted)) AND (WWPUserExtendedFullName like '%' || :lV14SearchTxt or WWPUserExtendedEmail like :lV14SearchTxt) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                return;
       }
    }

 }

}
