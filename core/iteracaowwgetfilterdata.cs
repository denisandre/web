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
   public class iteracaowwgetfilterdata : GXProcedure
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
            return "iteracaoww_Services_Execute" ;
         }

      }

      public iteracaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public iteracaowwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         iteracaowwgetfilterdata objiteracaowwgetfilterdata;
         objiteracaowwgetfilterdata = new iteracaowwgetfilterdata();
         objiteracaowwgetfilterdata.AV32DDOName = aP0_DDOName;
         objiteracaowwgetfilterdata.AV33SearchTxtParms = aP1_SearchTxtParms;
         objiteracaowwgetfilterdata.AV34SearchTxtTo = aP2_SearchTxtTo;
         objiteracaowwgetfilterdata.AV35OptionsJson = "" ;
         objiteracaowwgetfilterdata.AV36OptionsDescJson = "" ;
         objiteracaowwgetfilterdata.AV37OptionIndexesJson = "" ;
         objiteracaowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objiteracaowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objiteracaowwgetfilterdata);
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((iteracaowwgetfilterdata)stateInfo).executePrivate();
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
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_ITENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADITENOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("core.IteracaoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.IteracaoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("core.IteracaoWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFITEORDEM") == 0 )
            {
               AV11TFIteOrdem = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFIteOrdem_To = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV13TFIteNome = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV14TFIteNome_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADITENOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFIteNome = AV16SearchTxt;
         AV14TFIteNome_Sel = "";
         AV52Core_iteracaowwds_1_filterfulltext = AV38FilterFullText;
         AV53Core_iteracaowwds_2_tfiteordem = AV11TFIteOrdem;
         AV54Core_iteracaowwds_3_tfiteordem_to = AV12TFIteOrdem_To;
         AV55Core_iteracaowwds_4_tfitenome = AV13TFIteNome;
         AV56Core_iteracaowwds_5_tfitenome_sel = AV14TFIteNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Core_iteracaowwds_1_filterfulltext ,
                                              AV53Core_iteracaowwds_2_tfiteordem ,
                                              AV54Core_iteracaowwds_3_tfiteordem_to ,
                                              AV56Core_iteracaowwds_5_tfitenome_sel ,
                                              AV55Core_iteracaowwds_4_tfitenome ,
                                              A382IteOrdem ,
                                              A383IteNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV52Core_iteracaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Core_iteracaowwds_1_filterfulltext), "%", "");
         lV52Core_iteracaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Core_iteracaowwds_1_filterfulltext), "%", "");
         lV55Core_iteracaowwds_4_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV55Core_iteracaowwds_4_tfitenome), "%", "");
         /* Using cursor P00582 */
         pr_default.execute(0, new Object[] {lV52Core_iteracaowwds_1_filterfulltext, lV52Core_iteracaowwds_1_filterfulltext, AV53Core_iteracaowwds_2_tfiteordem, AV54Core_iteracaowwds_3_tfiteordem_to, lV55Core_iteracaowwds_4_tfitenome, AV56Core_iteracaowwds_5_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK582 = false;
            A383IteNome = P00582_A383IteNome[0];
            A382IteOrdem = P00582_A382IteOrdem[0];
            A381IteID = P00582_A381IteID[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00582_A383IteNome[0], A383IteNome) == 0 ) )
            {
               BRK582 = false;
               A381IteID = P00582_A381IteID[0];
               AV26count = (long)(AV26count+1);
               BRK582 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A383IteNome)) ? "<#Empty#>" : A383IteNome);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK582 )
            {
               BRK582 = true;
               pr_default.readNext(0);
            }
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
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV13TFIteNome = "";
         AV14TFIteNome_Sel = "";
         AV52Core_iteracaowwds_1_filterfulltext = "";
         AV55Core_iteracaowwds_4_tfitenome = "";
         AV56Core_iteracaowwds_5_tfitenome_sel = "";
         scmdbuf = "";
         lV52Core_iteracaowwds_1_filterfulltext = "";
         lV55Core_iteracaowwds_4_tfitenome = "";
         A383IteNome = "";
         P00582_A383IteNome = new string[] {""} ;
         P00582_A382IteOrdem = new int[1] ;
         P00582_A381IteID = new Guid[] {Guid.Empty} ;
         A381IteID = Guid.Empty;
         AV21Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.iteracaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00582_A383IteNome, P00582_A382IteOrdem, P00582_A381IteID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private int AV50GXV1 ;
      private int AV11TFIteOrdem ;
      private int AV12TFIteOrdem_To ;
      private int AV53Core_iteracaowwds_2_tfiteordem ;
      private int AV54Core_iteracaowwds_3_tfiteordem_to ;
      private int A382IteOrdem ;
      private long AV26count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK582 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV13TFIteNome ;
      private string AV14TFIteNome_Sel ;
      private string AV52Core_iteracaowwds_1_filterfulltext ;
      private string AV55Core_iteracaowwds_4_tfitenome ;
      private string AV56Core_iteracaowwds_5_tfitenome_sel ;
      private string lV52Core_iteracaowwds_1_filterfulltext ;
      private string lV55Core_iteracaowwds_4_tfitenome ;
      private string A383IteNome ;
      private string AV21Option ;
      private Guid A381IteID ;
      private IGxSession AV27Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00582_A383IteNome ;
      private int[] P00582_A382IteOrdem ;
      private Guid[] P00582_A381IteID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class iteracaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00582( IGxContext context ,
                                             string AV52Core_iteracaowwds_1_filterfulltext ,
                                             int AV53Core_iteracaowwds_2_tfiteordem ,
                                             int AV54Core_iteracaowwds_3_tfiteordem_to ,
                                             string AV56Core_iteracaowwds_5_tfitenome_sel ,
                                             string AV55Core_iteracaowwds_4_tfitenome ,
                                             int A382IteOrdem ,
                                             string A383IteNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT IteNome, IteOrdem, IteID FROM tb_Iteracao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_iteracaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(IteOrdem,'99999999'), 2) like '%' || :lV52Core_iteracaowwds_1_filterfulltext) or ( IteNome like '%' || :lV52Core_iteracaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV53Core_iteracaowwds_2_tfiteordem) )
         {
            AddWhere(sWhereString, "(IteOrdem >= :AV53Core_iteracaowwds_2_tfiteordem)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV54Core_iteracaowwds_3_tfiteordem_to) )
         {
            AddWhere(sWhereString, "(IteOrdem <= :AV54Core_iteracaowwds_3_tfiteordem_to)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_iteracaowwds_5_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_iteracaowwds_4_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV55Core_iteracaowwds_4_tfitenome)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_iteracaowwds_5_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV56Core_iteracaowwds_5_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV56Core_iteracaowwds_5_tfitenome_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_iteracaowwds_5_tfitenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IteNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY IteNome";
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
                     return conditional_P00582(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00582;
          prmP00582 = new Object[] {
          new ParDef("lV52Core_iteracaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Core_iteracaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV53Core_iteracaowwds_2_tfiteordem",GXType.Int32,8,0) ,
          new ParDef("AV54Core_iteracaowwds_3_tfiteordem_to",GXType.Int32,8,0) ,
          new ParDef("lV55Core_iteracaowwds_4_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_iteracaowwds_5_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00582", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00582,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
