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
   public class clientepjloaddvcombo : GXProcedure
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
            return "clientepj_Services_Execute" ;
         }

      }

      public clientepjloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_CliID ,
                           Guid aP4_CpjID ,
                           int aP5_Cond_CpjTipoId ,
                           Guid aP6_Cond_CliID ,
                           string aP7_SearchTxtParms ,
                           out string aP8_SelectedValue ,
                           out string aP9_SelectedText ,
                           out string aP10_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20CliID = aP3_CliID;
         this.AV21CpjID = aP4_CpjID;
         this.AV36Cond_CpjTipoId = aP5_Cond_CpjTipoId;
         this.AV37Cond_CliID = aP6_Cond_CliID;
         this.AV22SearchTxtParms = aP7_SearchTxtParms;
         this.AV23SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV25Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP8_SelectedValue=this.AV23SelectedValue;
         aP9_SelectedText=this.AV24SelectedText;
         aP10_Combo_DataJson=this.AV25Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_CliID ,
                                Guid aP4_CpjID ,
                                int aP5_Cond_CpjTipoId ,
                                Guid aP6_Cond_CliID ,
                                string aP7_SearchTxtParms ,
                                out string aP8_SelectedValue ,
                                out string aP9_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CliID, aP4_CpjID, aP5_Cond_CpjTipoId, aP6_Cond_CliID, aP7_SearchTxtParms, out aP8_SelectedValue, out aP9_SelectedText, out aP10_Combo_DataJson);
         return AV25Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_CliID ,
                                 Guid aP4_CpjID ,
                                 int aP5_Cond_CpjTipoId ,
                                 Guid aP6_Cond_CliID ,
                                 string aP7_SearchTxtParms ,
                                 out string aP8_SelectedValue ,
                                 out string aP9_SelectedText ,
                                 out string aP10_Combo_DataJson )
      {
         clientepjloaddvcombo objclientepjloaddvcombo;
         objclientepjloaddvcombo = new clientepjloaddvcombo();
         objclientepjloaddvcombo.AV17ComboName = aP0_ComboName;
         objclientepjloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objclientepjloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objclientepjloaddvcombo.AV20CliID = aP3_CliID;
         objclientepjloaddvcombo.AV21CpjID = aP4_CpjID;
         objclientepjloaddvcombo.AV36Cond_CpjTipoId = aP5_Cond_CpjTipoId;
         objclientepjloaddvcombo.AV37Cond_CliID = aP6_Cond_CliID;
         objclientepjloaddvcombo.AV22SearchTxtParms = aP7_SearchTxtParms;
         objclientepjloaddvcombo.AV23SelectedValue = "" ;
         objclientepjloaddvcombo.AV24SelectedText = "" ;
         objclientepjloaddvcombo.AV25Combo_DataJson = "" ;
         objclientepjloaddvcombo.context.SetSubmitInitialConfig(context);
         objclientepjloaddvcombo.initialize();
         Submit( executePrivateCatch,objclientepjloaddvcombo);
         aP8_SelectedValue=this.AV23SelectedValue;
         aP9_SelectedText=this.AV24SelectedText;
         aP10_Combo_DataJson=this.AV25Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientepjloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV22SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV22SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV22SearchTxtParms : StringUtil.Substring( AV22SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "CpjTipoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CPJTIPOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CpjPaiID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CPJPAIID' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_CPJTIPOID' Routine */
         returnInSub = false;
         /* Using cursor P004J2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A155PjtID = P004J2_A155PjtID[0];
            A157PjtNome = P004J2_A157PjtNome[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A155PjtID), 9, 0));
            AV16Combo_DataItem.gxTpr_Title = A157PjtNome;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV25Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P004J3 */
            pr_default.execute(1, new Object[] {AV20CliID, AV21CpjID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A166CpjID = P004J3_A166CpjID[0];
               A158CliID = P004J3_A158CliID[0];
               A365CpjTipoId = P004J3_A365CpjTipoId[0];
               AV23SelectedValue = ((0==A365CpjTipoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A365CpjTipoId), 9, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_CPJPAIID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom4 = AV12SkipItems;
            GXPagingTo4 = AV11MaxItems;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A170CpjNomeFan ,
                                                 A158CliID ,
                                                 AV37Cond_CliID ,
                                                 A365CpjTipoId ,
                                                 AV36Cond_CpjTipoId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P004J4 */
            pr_default.execute(2, new Object[] {AV37Cond_CliID, AV36Cond_CpjTipoId, lV14SearchTxt, GXPagingFrom4, GXPagingTo4, GXPagingTo4});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A158CliID = P004J4_A158CliID[0];
               A365CpjTipoId = P004J4_A365CpjTipoId[0];
               A170CpjNomeFan = P004J4_A170CpjNomeFan[0];
               A166CpjID = P004J4_A166CpjID[0];
               A171CpjRazaoSoc = P004J4_A171CpjRazaoSoc[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A166CpjID.ToString());
               AV34ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV34ComboTitles.Add(A170CpjNomeFan, 0);
               AV34ComboTitles.Add(A171CpjRazaoSoc, 0);
               AV16Combo_DataItem.gxTpr_Title = AV34ComboTitles.ToJSonString(false);
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV25Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P004J5 */
                  pr_default.execute(3, new Object[] {AV20CliID, AV21CpjID});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A166CpjID = P004J5_A166CpjID[0];
                     A158CliID = P004J5_A158CliID[0];
                     A169CpjPaiID = P004J5_A169CpjPaiID[0];
                     n169CpjPaiID = P004J5_n169CpjPaiID[0];
                     AV23SelectedValue = ((Guid.Empty==A169CpjPaiID) ? "" : StringUtil.Trim( A169CpjPaiID.ToString()));
                     AV35CpjIDAux = A169CpjPaiID;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
               else
               {
                  AV35CpjIDAux = StringUtil.StrToGuid( AV14SearchTxt);
               }
               /* Using cursor P004J6 */
               pr_default.execute(4, new Object[] {AV35CpjIDAux});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A166CpjID = P004J6_A166CpjID[0];
                  A170CpjNomeFan = P004J6_A170CpjNomeFan[0];
                  A171CpjRazaoSoc = P004J6_A171CpjRazaoSoc[0];
                  A158CliID = P004J6_A158CliID[0];
                  AV34ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                  AV34ComboTitles.Add(A170CpjNomeFan, 0);
                  AV34ComboTitles.Add(A171CpjRazaoSoc, 0);
                  AV24SelectedText = AV34ComboTitles.ToJSonString(false);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(4);
               }
               pr_default.close(4);
            }
         }
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
         AV23SelectedValue = "";
         AV24SelectedText = "";
         AV25Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         scmdbuf = "";
         P004J2_A155PjtID = new int[1] ;
         P004J2_A157PjtNome = new string[] {""} ;
         A157PjtNome = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P004J3_A166CpjID = new Guid[] {Guid.Empty} ;
         P004J3_A158CliID = new Guid[] {Guid.Empty} ;
         P004J3_A365CpjTipoId = new int[1] ;
         A166CpjID = Guid.Empty;
         A158CliID = Guid.Empty;
         lV14SearchTxt = "";
         A170CpjNomeFan = "";
         P004J4_A158CliID = new Guid[] {Guid.Empty} ;
         P004J4_A365CpjTipoId = new int[1] ;
         P004J4_A170CpjNomeFan = new string[] {""} ;
         P004J4_A166CpjID = new Guid[] {Guid.Empty} ;
         P004J4_A171CpjRazaoSoc = new string[] {""} ;
         A171CpjRazaoSoc = "";
         AV34ComboTitles = new GxSimpleCollection<string>();
         P004J5_A166CpjID = new Guid[] {Guid.Empty} ;
         P004J5_A158CliID = new Guid[] {Guid.Empty} ;
         P004J5_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         P004J5_n169CpjPaiID = new bool[] {false} ;
         A169CpjPaiID = Guid.Empty;
         AV35CpjIDAux = Guid.Empty;
         P004J6_A166CpjID = new Guid[] {Guid.Empty} ;
         P004J6_A170CpjNomeFan = new string[] {""} ;
         P004J6_A171CpjRazaoSoc = new string[] {""} ;
         P004J6_A158CliID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004J2_A155PjtID, P004J2_A157PjtNome
               }
               , new Object[] {
               P004J3_A166CpjID, P004J3_A158CliID, P004J3_A365CpjTipoId
               }
               , new Object[] {
               P004J4_A158CliID, P004J4_A365CpjTipoId, P004J4_A170CpjNomeFan, P004J4_A166CpjID, P004J4_A171CpjRazaoSoc
               }
               , new Object[] {
               P004J5_A166CpjID, P004J5_A158CliID, P004J5_A169CpjPaiID, P004J5_n169CpjPaiID
               }
               , new Object[] {
               P004J6_A166CpjID, P004J6_A170CpjNomeFan, P004J6_A171CpjRazaoSoc, P004J6_A158CliID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV36Cond_CpjTipoId ;
      private int AV11MaxItems ;
      private int A155PjtID ;
      private int A365CpjTipoId ;
      private int GXPagingFrom4 ;
      private int GXPagingTo4 ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool n169CpjPaiID ;
      private string AV25Combo_DataJson ;
      private string AV17ComboName ;
      private string AV22SearchTxtParms ;
      private string AV23SelectedValue ;
      private string AV24SelectedText ;
      private string AV14SearchTxt ;
      private string A157PjtNome ;
      private string lV14SearchTxt ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private Guid AV20CliID ;
      private Guid AV21CpjID ;
      private Guid AV37Cond_CliID ;
      private Guid A166CpjID ;
      private Guid A158CliID ;
      private Guid A169CpjPaiID ;
      private Guid AV35CpjIDAux ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004J2_A155PjtID ;
      private string[] P004J2_A157PjtNome ;
      private Guid[] P004J3_A166CpjID ;
      private Guid[] P004J3_A158CliID ;
      private int[] P004J3_A365CpjTipoId ;
      private Guid[] P004J4_A158CliID ;
      private int[] P004J4_A365CpjTipoId ;
      private string[] P004J4_A170CpjNomeFan ;
      private Guid[] P004J4_A166CpjID ;
      private string[] P004J4_A171CpjRazaoSoc ;
      private Guid[] P004J5_A166CpjID ;
      private Guid[] P004J5_A158CliID ;
      private Guid[] P004J5_A169CpjPaiID ;
      private bool[] P004J5_n169CpjPaiID ;
      private Guid[] P004J6_A166CpjID ;
      private string[] P004J6_A170CpjNomeFan ;
      private string[] P004J6_A171CpjRazaoSoc ;
      private Guid[] P004J6_A158CliID ;
      private string aP8_SelectedValue ;
      private string aP9_SelectedText ;
      private string aP10_Combo_DataJson ;
      private GxSimpleCollection<string> AV34ComboTitles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class clientepjloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004J4( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A170CpjNomeFan ,
                                             Guid A158CliID ,
                                             Guid AV37Cond_CliID ,
                                             int A365CpjTipoId ,
                                             int AV36Cond_CpjTipoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CliID, CpjTipoId, CpjNomeFan, CpjID, CpjRazaoSoc";
         sFromString = " FROM tb_clientepj";
         sOrderString = "";
         AddWhere(sWhereString, "(CliID = :AV37Cond_CliID)");
         AddWhere(sWhereString, "(CpjTipoId = :AV36Cond_CpjTipoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CpjNomeFan like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         sOrderString += " ORDER BY CpjNomeFan, CliID, CpjID";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom4" + " LIMIT CASE WHEN " + ":GXPagingTo4" + " > 0 THEN " + ":GXPagingTo4" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P004J4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004J2;
          prmP004J2 = new Object[] {
          };
          Object[] prmP004J3;
          prmP004J3 = new Object[] {
          new ParDef("AV20CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP004J5;
          prmP004J5 = new Object[] {
          new ParDef("AV20CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP004J6;
          prmP004J6 = new Object[] {
          new ParDef("AV35CpjIDAux",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP004J4;
          prmP004J4 = new Object[] {
          new ParDef("AV37Cond_CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV36Cond_CpjTipoId",GXType.Int32,9,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo4",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004J2", "SELECT PjtID, PjtNome FROM tb_clientepjtipo ORDER BY PjtID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004J3", "SELECT CpjID, CliID, CpjTipoId FROM tb_clientepj WHERE CliID = :AV20CliID and CpjID = :AV21CpjID ORDER BY CliID, CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004J4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004J5", "SELECT CpjID, CliID, CpjPaiID FROM tb_clientepj WHERE CliID = :AV20CliID and CpjID = :AV21CpjID ORDER BY CliID, CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004J6", "SELECT CpjID, CpjNomeFan, CpjRazaoSoc, CliID FROM tb_clientepj WHERE CpjID = :AV35CpjIDAux ORDER BY CliID, CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004J6,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
