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
   public class ufloaddvcombo : GXProcedure
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
            return "uf_Services_Execute" ;
         }

      }

      public ufloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ufloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_UFID ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20UFID = aP3_UFID;
         this.AV21SearchTxtParms = aP4_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_UFID ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_UFID, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_UFID ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         ufloaddvcombo objufloaddvcombo;
         objufloaddvcombo = new ufloaddvcombo();
         objufloaddvcombo.AV17ComboName = aP0_ComboName;
         objufloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objufloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objufloaddvcombo.AV20UFID = aP3_UFID;
         objufloaddvcombo.AV21SearchTxtParms = aP4_SearchTxtParms;
         objufloaddvcombo.AV22SelectedValue = "" ;
         objufloaddvcombo.AV23SelectedText = "" ;
         objufloaddvcombo.AV24Combo_DataJson = "" ;
         objufloaddvcombo.context.SetSubmitInitialConfig(context);
         objufloaddvcombo.initialize();
         Submit( executePrivateCatch,objufloaddvcombo);
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ufloaddvcombo)stateInfo).executePrivate();
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
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "UFRegID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_UFREGID' */
            S111 ();
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
         /* 'LOADCOMBOITEMS_UFREGID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A2RegiaoSigla } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P005H2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2RegiaoSigla = P005H2_A2RegiaoSigla[0];
               A1RegiaoID = P005H2_A1RegiaoID[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A1RegiaoID), 9, 0));
               AV16Combo_DataItem.gxTpr_Title = A2RegiaoSigla;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P005H3 */
                  pr_default.execute(1, new Object[] {AV20UFID});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A4UFID = P005H3_A4UFID[0];
                     A8UFRegID = P005H3_A8UFRegID[0];
                     AV22SelectedValue = ((0==A8UFRegID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A8UFRegID), 9, 0)));
                     AV28RegiaoID = A8UFRegID;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28RegiaoID = (int)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P005H4 */
               pr_default.execute(2, new Object[] {AV28RegiaoID});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A1RegiaoID = P005H4_A1RegiaoID[0];
                  A2RegiaoSigla = P005H4_A2RegiaoSigla[0];
                  AV23SelectedText = A2RegiaoSigla;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
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
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         scmdbuf = "";
         lV14SearchTxt = "";
         A2RegiaoSigla = "";
         P005H2_A2RegiaoSigla = new string[] {""} ;
         P005H2_A1RegiaoID = new int[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005H3_A4UFID = new int[1] ;
         P005H3_A8UFRegID = new int[1] ;
         P005H4_A1RegiaoID = new int[1] ;
         P005H4_A2RegiaoSigla = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.ufloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005H2_A2RegiaoSigla, P005H2_A1RegiaoID
               }
               , new Object[] {
               P005H3_A4UFID, P005H3_A8UFRegID
               }
               , new Object[] {
               P005H4_A1RegiaoID, P005H4_A2RegiaoSigla
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV20UFID ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A1RegiaoID ;
      private int A4UFID ;
      private int A8UFRegID ;
      private int AV28RegiaoID ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A2RegiaoSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005H2_A2RegiaoSigla ;
      private int[] P005H2_A1RegiaoID ;
      private int[] P005H3_A4UFID ;
      private int[] P005H3_A8UFRegID ;
      private int[] P005H4_A1RegiaoID ;
      private string[] P005H4_A2RegiaoSigla ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class ufloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005H2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A2RegiaoSigla )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " RegiaoSigla, RegiaoID";
         sFromString = " FROM tbibge_regiao";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(RegiaoSigla like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY RegiaoSigla";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
               case 0 :
                     return conditional_P005H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP005H3;
          prmP005H3 = new Object[] {
          new ParDef("AV20UFID",GXType.Int32,9,0)
          };
          Object[] prmP005H4;
          prmP005H4 = new Object[] {
          new ParDef("AV28RegiaoID",GXType.Int32,9,0)
          };
          Object[] prmP005H2;
          prmP005H2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005H2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005H3", "SELECT UFID, UFRegID FROM tbibge_uf WHERE UFID = :AV20UFID ORDER BY UFID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005H3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005H4", "SELECT RegiaoID, RegiaoSigla FROM tbibge_regiao WHERE RegiaoID = :AV28RegiaoID ORDER BY RegiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005H4,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
