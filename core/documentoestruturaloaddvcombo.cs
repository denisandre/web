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
   public class documentoestruturaloaddvcombo : GXProcedure
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
            return "documento_Services_Execute" ;
         }

      }

      public documentoestruturaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoestruturaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_DocID ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20DocID = aP3_DocID;
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
                                Guid aP3_DocID ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_DocID, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_DocID ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         documentoestruturaloaddvcombo objdocumentoestruturaloaddvcombo;
         objdocumentoestruturaloaddvcombo = new documentoestruturaloaddvcombo();
         objdocumentoestruturaloaddvcombo.AV17ComboName = aP0_ComboName;
         objdocumentoestruturaloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objdocumentoestruturaloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objdocumentoestruturaloaddvcombo.AV20DocID = aP3_DocID;
         objdocumentoestruturaloaddvcombo.AV21SearchTxtParms = aP4_SearchTxtParms;
         objdocumentoestruturaloaddvcombo.AV22SelectedValue = "" ;
         objdocumentoestruturaloaddvcombo.AV23SelectedText = "" ;
         objdocumentoestruturaloaddvcombo.AV24Combo_DataJson = "" ;
         objdocumentoestruturaloaddvcombo.context.SetSubmitInitialConfig(context);
         objdocumentoestruturaloaddvcombo.initialize();
         Submit( executePrivateCatch,objdocumentoestruturaloaddvcombo);
         aP5_SelectedValue=this.AV22SelectedValue;
         aP6_SelectedText=this.AV23SelectedText;
         aP7_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentoestruturaloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "DocTipoID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DOCTIPOID' */
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
         /* 'LOADCOMBOITEMS_DOCTIPOID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom2 = AV12SkipItems;
            GXPagingTo2 = AV11MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A147DocTipoSigla } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006H2 */
            pr_default.execute(0, new Object[] {lV14SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A147DocTipoSigla = P006H2_A147DocTipoSigla[0];
               A146DocTipoID = P006H2_A146DocTipoID[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A146DocTipoID), 9, 0));
               AV16Combo_DataItem.gxTpr_Title = A147DocTipoSigla;
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
                  /* Using cursor P006H3 */
                  pr_default.execute(1, new Object[] {AV20DocID});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A289DocID = P006H3_A289DocID[0];
                     A146DocTipoID = P006H3_A146DocTipoID[0];
                     A147DocTipoSigla = P006H3_A147DocTipoSigla[0];
                     A147DocTipoSigla = P006H3_A147DocTipoSigla[0];
                     AV22SelectedValue = ((0==A146DocTipoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A146DocTipoID), 9, 0)));
                     AV23SelectedText = A147DocTipoSigla;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV28DocTipoID = (int)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P006H4 */
                  pr_default.execute(2, new Object[] {AV28DocTipoID});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A146DocTipoID = P006H4_A146DocTipoID[0];
                     A147DocTipoSigla = P006H4_A147DocTipoSigla[0];
                     AV23SelectedText = A147DocTipoSigla;
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
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         scmdbuf = "";
         lV14SearchTxt = "";
         A147DocTipoSigla = "";
         P006H2_A147DocTipoSigla = new string[] {""} ;
         P006H2_A146DocTipoID = new int[1] ;
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006H3_A289DocID = new Guid[] {Guid.Empty} ;
         P006H3_A146DocTipoID = new int[1] ;
         P006H3_A147DocTipoSigla = new string[] {""} ;
         A289DocID = Guid.Empty;
         P006H4_A146DocTipoID = new int[1] ;
         P006H4_A147DocTipoSigla = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoestruturaloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006H2_A147DocTipoSigla, P006H2_A146DocTipoID
               }
               , new Object[] {
               P006H3_A289DocID, P006H3_A146DocTipoID, P006H3_A147DocTipoSigla
               }
               , new Object[] {
               P006H4_A146DocTipoID, P006H4_A147DocTipoSigla
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
      private int A146DocTipoID ;
      private int AV28DocTipoID ;
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
      private string A147DocTipoSigla ;
      private Guid AV20DocID ;
      private Guid A289DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006H2_A147DocTipoSigla ;
      private int[] P006H2_A146DocTipoID ;
      private Guid[] P006H3_A289DocID ;
      private int[] P006H3_A146DocTipoID ;
      private string[] P006H3_A147DocTipoSigla ;
      private int[] P006H4_A146DocTipoID ;
      private string[] P006H4_A147DocTipoSigla ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class documentoestruturaloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006H2( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A147DocTipoSigla )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DocTipoSigla, DocTipoID";
         sFromString = " FROM tb_documentotipo";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY DocTipoSigla";
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
                     return conditional_P006H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP006H3;
          prmP006H3 = new Object[] {
          new ParDef("AV20DocID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006H4;
          prmP006H4 = new Object[] {
          new ParDef("AV28DocTipoID",GXType.Int32,9,0)
          };
          Object[] prmP006H2;
          prmP006H2 = new Object[] {
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006H3", "SELECT T1.DocID, T1.DocTipoID, T2.DocTipoSigla FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID) WHERE T1.DocID = :AV20DocID ORDER BY T1.DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006H4", "SELECT DocTipoID, DocTipoSigla FROM tb_documentotipo WHERE DocTipoID = :AV28DocTipoID ORDER BY DocTipoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006H4,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
