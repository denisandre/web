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
   public class negociopjfluxoloaddvcombo : GXProcedure
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
            return "negociopjfluxo_Services_Execute" ;
         }

      }

      public negociopjfluxoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjfluxoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_NegID ,
                           string aP4_NefChave ,
                           string aP5_SearchTxtParms ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20NegID = aP3_NegID;
         this.AV21NefChave = aP4_NefChave;
         this.AV22SearchTxtParms = aP5_SearchTxtParms;
         this.AV23SelectedValue = "" ;
         this.AV24SelectedText = "" ;
         this.AV25Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP6_SelectedValue=this.AV23SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV25Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_NegID ,
                                string aP4_NefChave ,
                                string aP5_SearchTxtParms ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_NegID, aP4_NefChave, aP5_SearchTxtParms, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV25Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_NegID ,
                                 string aP4_NefChave ,
                                 string aP5_SearchTxtParms ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         negociopjfluxoloaddvcombo objnegociopjfluxoloaddvcombo;
         objnegociopjfluxoloaddvcombo = new negociopjfluxoloaddvcombo();
         objnegociopjfluxoloaddvcombo.AV17ComboName = aP0_ComboName;
         objnegociopjfluxoloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objnegociopjfluxoloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objnegociopjfluxoloaddvcombo.AV20NegID = aP3_NegID;
         objnegociopjfluxoloaddvcombo.AV21NefChave = aP4_NefChave;
         objnegociopjfluxoloaddvcombo.AV22SearchTxtParms = aP5_SearchTxtParms;
         objnegociopjfluxoloaddvcombo.AV23SelectedValue = "" ;
         objnegociopjfluxoloaddvcombo.AV24SelectedText = "" ;
         objnegociopjfluxoloaddvcombo.AV25Combo_DataJson = "" ;
         objnegociopjfluxoloaddvcombo.context.SetSubmitInitialConfig(context);
         objnegociopjfluxoloaddvcombo.initialize();
         Submit( executePrivateCatch,objnegociopjfluxoloaddvcombo);
         aP6_SelectedValue=this.AV23SelectedValue;
         aP7_SelectedText=this.AV24SelectedText;
         aP8_Combo_DataJson=this.AV25Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((negociopjfluxoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "NegID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NEGID' */
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
         /* 'LOADCOMBOITEMS_NEGID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A362NegAssunto } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P007W2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A362NegAssunto = P007W2_A362NegAssunto[0];
               A345NegID = P007W2_A345NegID[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A345NegID.ToString());
               AV16Combo_DataItem.gxTpr_Title = A362NegAssunto;
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV25Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               /* Using cursor P007W3 */
               pr_default.execute(1, new Object[] {AV20NegID, AV21NefChave});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A626NefChave = P007W3_A626NefChave[0];
                  A345NegID = P007W3_A345NegID[0];
                  A362NegAssunto = P007W3_A362NegAssunto[0];
                  A362NegAssunto = P007W3_A362NegAssunto[0];
                  AV23SelectedValue = ((Guid.Empty==A345NegID) ? "" : StringUtil.Trim( A345NegID.ToString()));
                  AV24SelectedText = A362NegAssunto;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (Guid.Empty==AV20NegID) )
               {
                  AV23SelectedValue = StringUtil.Trim( AV20NegID.ToString());
                  /* Using cursor P007W4 */
                  pr_default.execute(2, new Object[] {AV20NegID});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A345NegID = P007W4_A345NegID[0];
                     A362NegAssunto = P007W4_A362NegAssunto[0];
                     AV24SelectedText = A362NegAssunto;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
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
         lV14SearchTxt = "";
         A362NegAssunto = "";
         P007W2_A362NegAssunto = new string[] {""} ;
         P007W2_A345NegID = new Guid[] {Guid.Empty} ;
         A345NegID = Guid.Empty;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P007W3_A626NefChave = new string[] {""} ;
         P007W3_A345NegID = new Guid[] {Guid.Empty} ;
         P007W3_A362NegAssunto = new string[] {""} ;
         A626NefChave = "";
         P007W4_A345NegID = new Guid[] {Guid.Empty} ;
         P007W4_A362NegAssunto = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjfluxoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007W2_A362NegAssunto, P007W2_A345NegID
               }
               , new Object[] {
               P007W3_A626NefChave, P007W3_A345NegID, P007W3_A362NegAssunto
               }
               , new Object[] {
               P007W4_A345NegID, P007W4_A362NegAssunto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private int AV11MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV25Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21NefChave ;
      private string AV22SearchTxtParms ;
      private string AV23SelectedValue ;
      private string AV24SelectedText ;
      private string AV14SearchTxt ;
      private string lV14SearchTxt ;
      private string A362NegAssunto ;
      private string A626NefChave ;
      private Guid AV20NegID ;
      private Guid A345NegID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007W2_A362NegAssunto ;
      private Guid[] P007W2_A345NegID ;
      private string[] P007W3_A626NefChave ;
      private Guid[] P007W3_A345NegID ;
      private string[] P007W3_A362NegAssunto ;
      private Guid[] P007W4_A345NegID ;
      private string[] P007W4_A362NegAssunto ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class negociopjfluxoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007W2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A362NegAssunto )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " NegAssunto, NegID";
         sFromString = " FROM tb_negociopj";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(NegAssunto like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY NegAssunto, NegID";
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
                     return conditional_P007W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP007W3;
          prmP007W3 = new Object[] {
          new ParDef("AV20NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21NefChave",GXType.VarChar,100,0)
          };
          Object[] prmP007W4;
          prmP007W4 = new Object[] {
          new ParDef("AV20NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007W2;
          prmP007W2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007W3", "SELECT T1.NefChave, T1.NegID, T2.NegAssunto FROM (tb_negociopj_fluxo T1 INNER JOIN tb_negociopj T2 ON T2.NegID = T1.NegID) WHERE T1.NegID = :AV20NegID and T1.NefChave = ( :AV21NefChave) ORDER BY T1.NegID, T1.NefChave ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007W4", "SELECT NegID, NegAssunto FROM tb_negociopj WHERE NegID = :AV20NegID ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W4,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
