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
   public class municipioloaddvcombo : GXProcedure
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
            return "municipio_Services_Execute" ;
         }

      }

      public municipioloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipioloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_MunicipioID ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20MunicipioID = aP3_MunicipioID;
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
                                int aP3_MunicipioID ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_MunicipioID, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_MunicipioID ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         municipioloaddvcombo objmunicipioloaddvcombo;
         objmunicipioloaddvcombo = new municipioloaddvcombo();
         objmunicipioloaddvcombo.AV17ComboName = aP0_ComboName;
         objmunicipioloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objmunicipioloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objmunicipioloaddvcombo.AV20MunicipioID = aP3_MunicipioID;
         objmunicipioloaddvcombo.AV21SearchTxtParms = aP4_SearchTxtParms;
         objmunicipioloaddvcombo.AV22SelectedValue = "" ;
         objmunicipioloaddvcombo.AV23SelectedText = "" ;
         objmunicipioloaddvcombo.AV24Combo_DataJson = "" ;
         objmunicipioloaddvcombo.context.SetSubmitInitialConfig(context);
         objmunicipioloaddvcombo.initialize();
         Submit( executePrivateCatch,objmunicipioloaddvcombo);
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((municipioloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "MunicipioMicroID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MUNICIPIOMICROID' */
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
         /* 'LOADCOMBOITEMS_MUNICIPIOMICROID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A24MicrorregiaoNome } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P005R2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A24MicrorregiaoNome = P005R2_A24MicrorregiaoNome[0];
               A23MicrorregiaoID = P005R2_A23MicrorregiaoID[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A23MicrorregiaoID), 9, 0));
               AV16Combo_DataItem.gxTpr_Title = A24MicrorregiaoNome;
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
                  /* Using cursor P005R3 */
                  pr_default.execute(1, new Object[] {AV20MunicipioID});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A35MunicipioID = P005R3_A35MunicipioID[0];
                     A37MunicipioMicroID = P005R3_A37MunicipioMicroID[0];
                     AV22SelectedValue = ((0==A37MunicipioMicroID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A37MunicipioMicroID), 9, 0)));
                     AV28MicrorregiaoID = A37MunicipioMicroID;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28MicrorregiaoID = (int)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P005R4 */
               pr_default.execute(2, new Object[] {AV28MicrorregiaoID});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A23MicrorregiaoID = P005R4_A23MicrorregiaoID[0];
                  A24MicrorregiaoNome = P005R4_A24MicrorregiaoNome[0];
                  AV23SelectedText = A24MicrorregiaoNome;
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
         A24MicrorregiaoNome = "";
         P005R2_A24MicrorregiaoNome = new string[] {""} ;
         P005R2_A23MicrorregiaoID = new int[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005R3_A35MunicipioID = new int[1] ;
         P005R3_A37MunicipioMicroID = new int[1] ;
         P005R4_A23MicrorregiaoID = new int[1] ;
         P005R4_A24MicrorregiaoNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.municipioloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005R2_A24MicrorregiaoNome, P005R2_A23MicrorregiaoID
               }
               , new Object[] {
               P005R3_A35MunicipioID, P005R3_A37MunicipioMicroID
               }
               , new Object[] {
               P005R4_A23MicrorregiaoID, P005R4_A24MicrorregiaoNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV20MunicipioID ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A23MicrorregiaoID ;
      private int A35MunicipioID ;
      private int A37MunicipioMicroID ;
      private int AV28MicrorregiaoID ;
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
      private string A24MicrorregiaoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005R2_A24MicrorregiaoNome ;
      private int[] P005R2_A23MicrorregiaoID ;
      private int[] P005R3_A35MunicipioID ;
      private int[] P005R3_A37MunicipioMicroID ;
      private int[] P005R4_A23MicrorregiaoID ;
      private string[] P005R4_A24MicrorregiaoNome ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class municipioloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005R2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A24MicrorregiaoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " MicrorregiaoNome, MicrorregiaoID";
         sFromString = " FROM tbibge_microrregiao";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY MicrorregiaoNome, MicrorregiaoID";
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
                     return conditional_P005R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP005R3;
          prmP005R3 = new Object[] {
          new ParDef("AV20MunicipioID",GXType.Int32,9,0)
          };
          Object[] prmP005R4;
          prmP005R4 = new Object[] {
          new ParDef("AV28MicrorregiaoID",GXType.Int32,9,0)
          };
          Object[] prmP005R2;
          prmP005R2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005R3", "SELECT MunicipioID, MunicipioMicroID FROM tbibge_municipio WHERE MunicipioID = :AV20MunicipioID ORDER BY MunicipioID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005R4", "SELECT MicrorregiaoID, MicrorregiaoNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :AV28MicrorregiaoID ORDER BY MicrorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R4,1, GxCacheFrequency.OFF ,false,true )
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
