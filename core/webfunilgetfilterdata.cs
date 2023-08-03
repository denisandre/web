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
   public class webfunilgetfilterdata : GXProcedure
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
            return "webfunil_Services_Execute" ;
         }

      }

      public webfunilgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webfunilgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         webfunilgetfilterdata objwebfunilgetfilterdata;
         objwebfunilgetfilterdata = new webfunilgetfilterdata();
         objwebfunilgetfilterdata.AV34DDOName = aP0_DDOName;
         objwebfunilgetfilterdata.AV35SearchTxtParms = aP1_SearchTxtParms;
         objwebfunilgetfilterdata.AV36SearchTxtTo = aP2_SearchTxtTo;
         objwebfunilgetfilterdata.AV37OptionsJson = "" ;
         objwebfunilgetfilterdata.AV38OptionsDescJson = "" ;
         objwebfunilgetfilterdata.AV39OptionIndexesJson = "" ;
         objwebfunilgetfilterdata.context.SetSubmitInitialConfig(context);
         objwebfunilgetfilterdata.initialize();
         Submit( executePrivateCatch,objwebfunilgetfilterdata);
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((webfunilgetfilterdata)stateInfo).executePrivate();
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
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_ITENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADITENOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("core.webfunilGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.webfunilGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("core.webfunilGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV11TFIteNome = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV12TFIteNome_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "ITENOME") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV43IteNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "ITENOME") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV47IteNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "ITENOME") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV51IteNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADITENOMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFIteNome = AV18SearchTxt;
         AV12TFIteNome_Sel = "";
         AV54Core_webfunilds_1_filterfulltext = AV40FilterFullText;
         AV55Core_webfunilds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Core_webfunilds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Core_webfunilds_4_itenome1 = AV43IteNome1;
         AV58Core_webfunilds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Core_webfunilds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Core_webfunilds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Core_webfunilds_8_itenome2 = AV47IteNome2;
         AV62Core_webfunilds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Core_webfunilds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Core_webfunilds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Core_webfunilds_12_itenome3 = AV51IteNome3;
         AV66Core_webfunilds_13_tfitenome = AV11TFIteNome;
         AV67Core_webfunilds_14_tfitenome_sel = AV12TFIteNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Core_webfunilds_2_dynamicfiltersselector1 ,
                                              AV56Core_webfunilds_3_dynamicfiltersoperator1 ,
                                              AV57Core_webfunilds_4_itenome1 ,
                                              AV58Core_webfunilds_5_dynamicfiltersenabled2 ,
                                              AV59Core_webfunilds_6_dynamicfiltersselector2 ,
                                              AV60Core_webfunilds_7_dynamicfiltersoperator2 ,
                                              AV61Core_webfunilds_8_itenome2 ,
                                              AV62Core_webfunilds_9_dynamicfiltersenabled3 ,
                                              AV63Core_webfunilds_10_dynamicfiltersselector3 ,
                                              AV64Core_webfunilds_11_dynamicfiltersoperator3 ,
                                              AV65Core_webfunilds_12_itenome3 ,
                                              AV67Core_webfunilds_14_tfitenome_sel ,
                                              AV66Core_webfunilds_13_tfitenome ,
                                              A383IteNome ,
                                              AV54Core_webfunilds_1_filterfulltext ,
                                              A431IteTotalOportunidades ,
                                              A432IteQtdeOportunidades ,
                                              A381IteID ,
                                              A420NegUltIteID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV57Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_webfunilds_4_itenome1), "%", "");
         lV57Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_webfunilds_4_itenome1), "%", "");
         lV61Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_webfunilds_8_itenome2), "%", "");
         lV61Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_webfunilds_8_itenome2), "%", "");
         lV65Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_webfunilds_12_itenome3), "%", "");
         lV65Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_webfunilds_12_itenome3), "%", "");
         lV66Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV66Core_webfunilds_13_tfitenome), "%", "");
         /* Using cursor P005Z2 */
         pr_default.execute(0, new Object[] {lV57Core_webfunilds_4_itenome1, lV57Core_webfunilds_4_itenome1, lV61Core_webfunilds_8_itenome2, lV61Core_webfunilds_8_itenome2, lV65Core_webfunilds_12_itenome3, lV65Core_webfunilds_12_itenome3, lV66Core_webfunilds_13_tfitenome, AV67Core_webfunilds_14_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5Z2 = false;
            A383IteNome = P005Z2_A383IteNome[0];
            A381IteID = P005Z2_A381IteID[0];
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV54Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV54Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV54Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               AV28count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005Z2_A383IteNome[0], A383IteNome) == 0 ) )
               {
                  BRK5Z2 = false;
                  A381IteID = P005Z2_A381IteID[0];
                  AV28count = (long)(AV28count+1);
                  BRK5Z2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV19SkipItems) )
               {
                  AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A383IteNome)) ? "<#Empty#>" : A383IteNome);
                  AV24Options.Add(AV23Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV24Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV19SkipItems = (short)(AV19SkipItems-1);
               }
            }
            if ( ! BRK5Z2 )
            {
               BRK5Z2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected int GetIteQtdeOportunidades0( Guid E381IteID )
      {
         Gx_cnt = 0;
         /* Using cursor P005Z3 */
         pr_default.execute(1, new Object[] {E381IteID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            Gx_cnt = P005Z3_Gx_cnt[0];
         }
         pr_default.close(1);
         return Gx_cnt ;
      }

      protected decimal GetIteTotalOportunidades0( Guid E381IteID )
      {
         X385NegValorAtualizado = 0;
         /* Using cursor P005Z4 */
         pr_default.execute(2, new Object[] {E381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            X385NegValorAtualizado = P005Z4_A385NegValorAtualizado[0];
         }
         pr_default.close(2);
         return X385NegValorAtualizado ;
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV11TFIteNome = "";
         AV12TFIteNome_Sel = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43IteNome1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47IteNome2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51IteNome3 = "";
         AV54Core_webfunilds_1_filterfulltext = "";
         AV55Core_webfunilds_2_dynamicfiltersselector1 = "";
         AV57Core_webfunilds_4_itenome1 = "";
         AV59Core_webfunilds_6_dynamicfiltersselector2 = "";
         AV61Core_webfunilds_8_itenome2 = "";
         AV63Core_webfunilds_10_dynamicfiltersselector3 = "";
         AV65Core_webfunilds_12_itenome3 = "";
         AV66Core_webfunilds_13_tfitenome = "";
         AV67Core_webfunilds_14_tfitenome_sel = "";
         scmdbuf = "";
         lV57Core_webfunilds_4_itenome1 = "";
         lV61Core_webfunilds_8_itenome2 = "";
         lV65Core_webfunilds_12_itenome3 = "";
         lV66Core_webfunilds_13_tfitenome = "";
         A383IteNome = "";
         A381IteID = Guid.Empty;
         A420NegUltIteID = Guid.Empty;
         P005Z2_A383IteNome = new string[] {""} ;
         P005Z2_A381IteID = new Guid[] {Guid.Empty} ;
         AV23Option = "";
         E381IteID = Guid.Empty;
         P005Z3_Gx_cnt = new int[1] ;
         P005Z4_A385NegValorAtualizado = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.webfunilgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005Z2_A383IteNome, P005Z2_A381IteID
               }
               , new Object[] {
               P005Z3_Gx_cnt
               }
               , new Object[] {
               P005Z4_A385NegValorAtualizado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV56Core_webfunilds_3_dynamicfiltersoperator1 ;
      private short AV60Core_webfunilds_7_dynamicfiltersoperator2 ;
      private short AV64Core_webfunilds_11_dynamicfiltersoperator3 ;
      private int AV52GXV1 ;
      private int A432IteQtdeOportunidades ;
      private int Gx_cnt ;
      private long AV28count ;
      private decimal A431IteTotalOportunidades ;
      private decimal X385NegValorAtualizado ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV58Core_webfunilds_5_dynamicfiltersenabled2 ;
      private bool AV62Core_webfunilds_9_dynamicfiltersenabled3 ;
      private bool BRK5Z2 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV11TFIteNome ;
      private string AV12TFIteNome_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV43IteNome1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47IteNome2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV51IteNome3 ;
      private string AV54Core_webfunilds_1_filterfulltext ;
      private string AV55Core_webfunilds_2_dynamicfiltersselector1 ;
      private string AV57Core_webfunilds_4_itenome1 ;
      private string AV59Core_webfunilds_6_dynamicfiltersselector2 ;
      private string AV61Core_webfunilds_8_itenome2 ;
      private string AV63Core_webfunilds_10_dynamicfiltersselector3 ;
      private string AV65Core_webfunilds_12_itenome3 ;
      private string AV66Core_webfunilds_13_tfitenome ;
      private string AV67Core_webfunilds_14_tfitenome_sel ;
      private string lV57Core_webfunilds_4_itenome1 ;
      private string lV61Core_webfunilds_8_itenome2 ;
      private string lV65Core_webfunilds_12_itenome3 ;
      private string lV66Core_webfunilds_13_tfitenome ;
      private string A383IteNome ;
      private string AV23Option ;
      private Guid A381IteID ;
      private Guid A420NegUltIteID ;
      private Guid E381IteID ;
      private IGxSession AV29Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005Z2_A383IteNome ;
      private Guid[] P005Z2_A381IteID ;
      private int[] P005Z3_Gx_cnt ;
      private decimal[] P005Z4_A385NegValorAtualizado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
   }

   public class webfunilgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Z2( IGxContext context ,
                                             string AV55Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV56Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV57Core_webfunilds_4_itenome1 ,
                                             bool AV58Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV59Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV60Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV61Core_webfunilds_8_itenome2 ,
                                             bool AV62Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV63Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV64Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV65Core_webfunilds_12_itenome3 ,
                                             string AV67Core_webfunilds_14_tfitenome_sel ,
                                             string AV66Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             string AV54Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT IteNome, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV55Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV56Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV57Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV56Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV57Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV58Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV60Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV61Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV58Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV60Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV61Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV64Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV65Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV64Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV65Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV66Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV67Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV67Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
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
                     return conditional_P005Z2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (int)dynConstraints[16] , (Guid)dynConstraints[17] , (Guid)dynConstraints[18] );
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
          Object[] prmP005Z3;
          prmP005Z3 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005Z4;
          prmP005Z4 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005Z2;
          prmP005Z2 = new Object[] {
          new ParDef("lV57Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV67Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005Z3", "SELECT COUNT(*) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P005Z4", "SELECT SUM(NegValorAtualizado) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z4,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
