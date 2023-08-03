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
   public class centrodecustowwgetfilterdata : GXProcedure
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
            return "centrodecustoww_Services_Execute" ;
         }

      }

      public centrodecustowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrodecustowwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         centrodecustowwgetfilterdata objcentrodecustowwgetfilterdata;
         objcentrodecustowwgetfilterdata = new centrodecustowwgetfilterdata();
         objcentrodecustowwgetfilterdata.AV31DDOName = aP0_DDOName;
         objcentrodecustowwgetfilterdata.AV32SearchTxtParms = aP1_SearchTxtParms;
         objcentrodecustowwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objcentrodecustowwgetfilterdata.AV34OptionsJson = "" ;
         objcentrodecustowwgetfilterdata.AV35OptionsDescJson = "" ;
         objcentrodecustowwgetfilterdata.AV36OptionIndexesJson = "" ;
         objcentrodecustowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcentrodecustowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objcentrodecustowwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((centrodecustowwgetfilterdata)stateInfo).executePrivate();
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
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV18MaxItems = 10;
         AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
         AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_CCUSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADCCUSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_CCUNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCCUNOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("core.CentroDeCustoWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.CentroDeCustoWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("core.CentroDeCustoWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "CCUDEL_FILTRO") == 0 )
            {
               AV49CcuDel_Filtro = BooleanUtil.Val( AV29GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCCUSIGLA") == 0 )
            {
               AV11TFCcuSigla = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCCUSIGLA_SEL") == 0 )
            {
               AV12TFCcuSigla_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCCUNOME") == 0 )
            {
               AV13TFCcuNome = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFCCUNOME_SEL") == 0 )
            {
               AV14TFCcuNome_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CCUNOME") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40CcuNome1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CCUNOME") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44CcuNome2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CCUNOME") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48CcuNome3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCCUSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV11TFCcuSigla = AV15SearchTxt;
         AV12TFCcuSigla_Sel = "";
         AV52Core_centrodecustowwds_1_ccudel_filtro = AV49CcuDel_Filtro;
         AV53Core_centrodecustowwds_2_filterfulltext = AV37FilterFullText;
         AV54Core_centrodecustowwds_3_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV56Core_centrodecustowwds_5_ccunome1 = AV40CcuNome1;
         AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV58Core_centrodecustowwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV60Core_centrodecustowwds_9_ccunome2 = AV44CcuNome2;
         AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV62Core_centrodecustowwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV64Core_centrodecustowwds_13_ccunome3 = AV48CcuNome3;
         AV65Core_centrodecustowwds_14_tfccusigla = AV11TFCcuSigla;
         AV66Core_centrodecustowwds_15_tfccusigla_sel = AV12TFCcuSigla_Sel;
         AV67Core_centrodecustowwds_16_tfccunome = AV13TFCcuNome;
         AV68Core_centrodecustowwds_17_tfccunome_sel = AV14TFCcuNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Core_centrodecustowwds_2_filterfulltext ,
                                              AV54Core_centrodecustowwds_3_dynamicfiltersselector1 ,
                                              AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 ,
                                              AV56Core_centrodecustowwds_5_ccunome1 ,
                                              AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 ,
                                              AV58Core_centrodecustowwds_7_dynamicfiltersselector2 ,
                                              AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 ,
                                              AV60Core_centrodecustowwds_9_ccunome2 ,
                                              AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 ,
                                              AV62Core_centrodecustowwds_11_dynamicfiltersselector3 ,
                                              AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 ,
                                              AV64Core_centrodecustowwds_13_ccunome3 ,
                                              AV66Core_centrodecustowwds_15_tfccusigla_sel ,
                                              AV65Core_centrodecustowwds_14_tfccusigla ,
                                              AV68Core_centrodecustowwds_17_tfccunome_sel ,
                                              AV67Core_centrodecustowwds_16_tfccunome ,
                                              A209CcuSigla ,
                                              A210CcuNome ,
                                              A512CcuDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Core_centrodecustowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_centrodecustowwds_2_filterfulltext), "%", "");
         lV53Core_centrodecustowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_centrodecustowwds_2_filterfulltext), "%", "");
         lV56Core_centrodecustowwds_5_ccunome1 = StringUtil.Concat( StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1), "%", "");
         lV56Core_centrodecustowwds_5_ccunome1 = StringUtil.Concat( StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1), "%", "");
         lV60Core_centrodecustowwds_9_ccunome2 = StringUtil.Concat( StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2), "%", "");
         lV60Core_centrodecustowwds_9_ccunome2 = StringUtil.Concat( StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2), "%", "");
         lV64Core_centrodecustowwds_13_ccunome3 = StringUtil.Concat( StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3), "%", "");
         lV64Core_centrodecustowwds_13_ccunome3 = StringUtil.Concat( StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3), "%", "");
         lV65Core_centrodecustowwds_14_tfccusigla = StringUtil.Concat( StringUtil.RTrim( AV65Core_centrodecustowwds_14_tfccusigla), "%", "");
         lV67Core_centrodecustowwds_16_tfccunome = StringUtil.Concat( StringUtil.RTrim( AV67Core_centrodecustowwds_16_tfccunome), "%", "");
         /* Using cursor P00482 */
         pr_default.execute(0, new Object[] {lV53Core_centrodecustowwds_2_filterfulltext, lV53Core_centrodecustowwds_2_filterfulltext, lV56Core_centrodecustowwds_5_ccunome1, lV56Core_centrodecustowwds_5_ccunome1, lV60Core_centrodecustowwds_9_ccunome2, lV60Core_centrodecustowwds_9_ccunome2, lV64Core_centrodecustowwds_13_ccunome3, lV64Core_centrodecustowwds_13_ccunome3, lV65Core_centrodecustowwds_14_tfccusigla, AV66Core_centrodecustowwds_15_tfccusigla_sel, lV67Core_centrodecustowwds_16_tfccunome, AV68Core_centrodecustowwds_17_tfccunome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK482 = false;
            A209CcuSigla = P00482_A209CcuSigla[0];
            A210CcuNome = P00482_A210CcuNome[0];
            A512CcuDel = P00482_A512CcuDel[0];
            A208CcuID = P00482_A208CcuID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00482_A209CcuSigla[0], A209CcuSigla) == 0 ) )
            {
               BRK482 = false;
               A208CcuID = P00482_A208CcuID[0];
               AV25count = (long)(AV25count+1);
               BRK482 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209CcuSigla)) ? "<#Empty#>" : A209CcuSigla);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK482 )
            {
               BRK482 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCCUNOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFCcuNome = AV15SearchTxt;
         AV14TFCcuNome_Sel = "";
         AV52Core_centrodecustowwds_1_ccudel_filtro = AV49CcuDel_Filtro;
         AV53Core_centrodecustowwds_2_filterfulltext = AV37FilterFullText;
         AV54Core_centrodecustowwds_3_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV56Core_centrodecustowwds_5_ccunome1 = AV40CcuNome1;
         AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV58Core_centrodecustowwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV60Core_centrodecustowwds_9_ccunome2 = AV44CcuNome2;
         AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV62Core_centrodecustowwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV64Core_centrodecustowwds_13_ccunome3 = AV48CcuNome3;
         AV65Core_centrodecustowwds_14_tfccusigla = AV11TFCcuSigla;
         AV66Core_centrodecustowwds_15_tfccusigla_sel = AV12TFCcuSigla_Sel;
         AV67Core_centrodecustowwds_16_tfccunome = AV13TFCcuNome;
         AV68Core_centrodecustowwds_17_tfccunome_sel = AV14TFCcuNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Core_centrodecustowwds_2_filterfulltext ,
                                              AV54Core_centrodecustowwds_3_dynamicfiltersselector1 ,
                                              AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 ,
                                              AV56Core_centrodecustowwds_5_ccunome1 ,
                                              AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 ,
                                              AV58Core_centrodecustowwds_7_dynamicfiltersselector2 ,
                                              AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 ,
                                              AV60Core_centrodecustowwds_9_ccunome2 ,
                                              AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 ,
                                              AV62Core_centrodecustowwds_11_dynamicfiltersselector3 ,
                                              AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 ,
                                              AV64Core_centrodecustowwds_13_ccunome3 ,
                                              AV66Core_centrodecustowwds_15_tfccusigla_sel ,
                                              AV65Core_centrodecustowwds_14_tfccusigla ,
                                              AV68Core_centrodecustowwds_17_tfccunome_sel ,
                                              AV67Core_centrodecustowwds_16_tfccunome ,
                                              A209CcuSigla ,
                                              A210CcuNome ,
                                              A512CcuDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Core_centrodecustowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_centrodecustowwds_2_filterfulltext), "%", "");
         lV53Core_centrodecustowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_centrodecustowwds_2_filterfulltext), "%", "");
         lV56Core_centrodecustowwds_5_ccunome1 = StringUtil.Concat( StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1), "%", "");
         lV56Core_centrodecustowwds_5_ccunome1 = StringUtil.Concat( StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1), "%", "");
         lV60Core_centrodecustowwds_9_ccunome2 = StringUtil.Concat( StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2), "%", "");
         lV60Core_centrodecustowwds_9_ccunome2 = StringUtil.Concat( StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2), "%", "");
         lV64Core_centrodecustowwds_13_ccunome3 = StringUtil.Concat( StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3), "%", "");
         lV64Core_centrodecustowwds_13_ccunome3 = StringUtil.Concat( StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3), "%", "");
         lV65Core_centrodecustowwds_14_tfccusigla = StringUtil.Concat( StringUtil.RTrim( AV65Core_centrodecustowwds_14_tfccusigla), "%", "");
         lV67Core_centrodecustowwds_16_tfccunome = StringUtil.Concat( StringUtil.RTrim( AV67Core_centrodecustowwds_16_tfccunome), "%", "");
         /* Using cursor P00483 */
         pr_default.execute(1, new Object[] {lV53Core_centrodecustowwds_2_filterfulltext, lV53Core_centrodecustowwds_2_filterfulltext, lV56Core_centrodecustowwds_5_ccunome1, lV56Core_centrodecustowwds_5_ccunome1, lV60Core_centrodecustowwds_9_ccunome2, lV60Core_centrodecustowwds_9_ccunome2, lV64Core_centrodecustowwds_13_ccunome3, lV64Core_centrodecustowwds_13_ccunome3, lV65Core_centrodecustowwds_14_tfccusigla, AV66Core_centrodecustowwds_15_tfccusigla_sel, lV67Core_centrodecustowwds_16_tfccunome, AV68Core_centrodecustowwds_17_tfccunome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK484 = false;
            A210CcuNome = P00483_A210CcuNome[0];
            A209CcuSigla = P00483_A209CcuSigla[0];
            A512CcuDel = P00483_A512CcuDel[0];
            A208CcuID = P00483_A208CcuID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00483_A210CcuNome[0], A210CcuNome) == 0 ) )
            {
               BRK484 = false;
               A208CcuID = P00483_A208CcuID[0];
               AV25count = (long)(AV25count+1);
               BRK484 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A210CcuNome)) ? "<#Empty#>" : A210CcuNome);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK484 )
            {
               BRK484 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFCcuSigla = "";
         AV12TFCcuSigla_Sel = "";
         AV13TFCcuNome = "";
         AV14TFCcuNome_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40CcuNome1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44CcuNome2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48CcuNome3 = "";
         AV53Core_centrodecustowwds_2_filterfulltext = "";
         AV54Core_centrodecustowwds_3_dynamicfiltersselector1 = "";
         AV56Core_centrodecustowwds_5_ccunome1 = "";
         AV58Core_centrodecustowwds_7_dynamicfiltersselector2 = "";
         AV60Core_centrodecustowwds_9_ccunome2 = "";
         AV62Core_centrodecustowwds_11_dynamicfiltersselector3 = "";
         AV64Core_centrodecustowwds_13_ccunome3 = "";
         AV65Core_centrodecustowwds_14_tfccusigla = "";
         AV66Core_centrodecustowwds_15_tfccusigla_sel = "";
         AV67Core_centrodecustowwds_16_tfccunome = "";
         AV68Core_centrodecustowwds_17_tfccunome_sel = "";
         scmdbuf = "";
         lV53Core_centrodecustowwds_2_filterfulltext = "";
         lV56Core_centrodecustowwds_5_ccunome1 = "";
         lV60Core_centrodecustowwds_9_ccunome2 = "";
         lV64Core_centrodecustowwds_13_ccunome3 = "";
         lV65Core_centrodecustowwds_14_tfccusigla = "";
         lV67Core_centrodecustowwds_16_tfccunome = "";
         A209CcuSigla = "";
         A210CcuNome = "";
         P00482_A209CcuSigla = new string[] {""} ;
         P00482_A210CcuNome = new string[] {""} ;
         P00482_A512CcuDel = new bool[] {false} ;
         P00482_A208CcuID = new int[1] ;
         AV20Option = "";
         P00483_A210CcuNome = new string[] {""} ;
         P00483_A209CcuSigla = new string[] {""} ;
         P00483_A512CcuDel = new bool[] {false} ;
         P00483_A208CcuID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.centrodecustowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00482_A209CcuSigla, P00482_A210CcuNome, P00482_A512CcuDel, P00482_A208CcuID
               }
               , new Object[] {
               P00483_A210CcuNome, P00483_A209CcuSigla, P00483_A512CcuDel, P00483_A208CcuID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 ;
      private short AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 ;
      private short AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 ;
      private int AV50GXV1 ;
      private int A208CcuID ;
      private long AV25count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV49CcuDel_Filtro ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV52Core_centrodecustowwds_1_ccudel_filtro ;
      private bool AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 ;
      private bool AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 ;
      private bool A512CcuDel ;
      private bool BRK482 ;
      private bool BRK484 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFCcuSigla ;
      private string AV12TFCcuSigla_Sel ;
      private string AV13TFCcuNome ;
      private string AV14TFCcuNome_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40CcuNome1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44CcuNome2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48CcuNome3 ;
      private string AV53Core_centrodecustowwds_2_filterfulltext ;
      private string AV54Core_centrodecustowwds_3_dynamicfiltersselector1 ;
      private string AV56Core_centrodecustowwds_5_ccunome1 ;
      private string AV58Core_centrodecustowwds_7_dynamicfiltersselector2 ;
      private string AV60Core_centrodecustowwds_9_ccunome2 ;
      private string AV62Core_centrodecustowwds_11_dynamicfiltersselector3 ;
      private string AV64Core_centrodecustowwds_13_ccunome3 ;
      private string AV65Core_centrodecustowwds_14_tfccusigla ;
      private string AV66Core_centrodecustowwds_15_tfccusigla_sel ;
      private string AV67Core_centrodecustowwds_16_tfccunome ;
      private string AV68Core_centrodecustowwds_17_tfccunome_sel ;
      private string lV53Core_centrodecustowwds_2_filterfulltext ;
      private string lV56Core_centrodecustowwds_5_ccunome1 ;
      private string lV60Core_centrodecustowwds_9_ccunome2 ;
      private string lV64Core_centrodecustowwds_13_ccunome3 ;
      private string lV65Core_centrodecustowwds_14_tfccusigla ;
      private string lV67Core_centrodecustowwds_16_tfccunome ;
      private string A209CcuSigla ;
      private string A210CcuNome ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00482_A209CcuSigla ;
      private string[] P00482_A210CcuNome ;
      private bool[] P00482_A512CcuDel ;
      private int[] P00482_A208CcuID ;
      private string[] P00483_A210CcuNome ;
      private string[] P00483_A209CcuSigla ;
      private bool[] P00483_A512CcuDel ;
      private int[] P00483_A208CcuID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class centrodecustowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00482( IGxContext context ,
                                             string AV53Core_centrodecustowwds_2_filterfulltext ,
                                             string AV54Core_centrodecustowwds_3_dynamicfiltersselector1 ,
                                             short AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 ,
                                             string AV56Core_centrodecustowwds_5_ccunome1 ,
                                             bool AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 ,
                                             string AV58Core_centrodecustowwds_7_dynamicfiltersselector2 ,
                                             short AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 ,
                                             string AV60Core_centrodecustowwds_9_ccunome2 ,
                                             bool AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 ,
                                             string AV62Core_centrodecustowwds_11_dynamicfiltersselector3 ,
                                             short AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 ,
                                             string AV64Core_centrodecustowwds_13_ccunome3 ,
                                             string AV66Core_centrodecustowwds_15_tfccusigla_sel ,
                                             string AV65Core_centrodecustowwds_14_tfccusigla ,
                                             string AV68Core_centrodecustowwds_17_tfccunome_sel ,
                                             string AV67Core_centrodecustowwds_16_tfccunome ,
                                             string A209CcuSigla ,
                                             string A210CcuNome ,
                                             bool A512CcuDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CcuSigla, CcuNome, CcuDel, CcuID FROM tb_centrodecusto";
         AddWhere(sWhereString, "(Not CcuDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_centrodecustowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CcuSigla like '%' || :lV53Core_centrodecustowwds_2_filterfulltext) or ( CcuNome like '%' || :lV53Core_centrodecustowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Core_centrodecustowwds_3_dynamicfiltersselector1, "CCUNOME") == 0 ) && ( AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV56Core_centrodecustowwds_5_ccunome1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Core_centrodecustowwds_3_dynamicfiltersselector1, "CCUNOME") == 0 ) && ( AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV56Core_centrodecustowwds_5_ccunome1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Core_centrodecustowwds_7_dynamicfiltersselector2, "CCUNOME") == 0 ) && ( AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV60Core_centrodecustowwds_9_ccunome2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Core_centrodecustowwds_7_dynamicfiltersselector2, "CCUNOME") == 0 ) && ( AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV60Core_centrodecustowwds_9_ccunome2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Core_centrodecustowwds_11_dynamicfiltersselector3, "CCUNOME") == 0 ) && ( AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV64Core_centrodecustowwds_13_ccunome3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Core_centrodecustowwds_11_dynamicfiltersselector3, "CCUNOME") == 0 ) && ( AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV64Core_centrodecustowwds_13_ccunome3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_centrodecustowwds_15_tfccusigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_centrodecustowwds_14_tfccusigla)) ) )
         {
            AddWhere(sWhereString, "(CcuSigla like :lV65Core_centrodecustowwds_14_tfccusigla)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_centrodecustowwds_15_tfccusigla_sel)) && ! ( StringUtil.StrCmp(AV66Core_centrodecustowwds_15_tfccusigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CcuSigla = ( :AV66Core_centrodecustowwds_15_tfccusigla_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_centrodecustowwds_15_tfccusigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CcuSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_centrodecustowwds_17_tfccunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_centrodecustowwds_16_tfccunome)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV67Core_centrodecustowwds_16_tfccunome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_centrodecustowwds_17_tfccunome_sel)) && ! ( StringUtil.StrCmp(AV68Core_centrodecustowwds_17_tfccunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CcuNome = ( :AV68Core_centrodecustowwds_17_tfccunome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Core_centrodecustowwds_17_tfccunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CcuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CcuSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00483( IGxContext context ,
                                             string AV53Core_centrodecustowwds_2_filterfulltext ,
                                             string AV54Core_centrodecustowwds_3_dynamicfiltersselector1 ,
                                             short AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 ,
                                             string AV56Core_centrodecustowwds_5_ccunome1 ,
                                             bool AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 ,
                                             string AV58Core_centrodecustowwds_7_dynamicfiltersselector2 ,
                                             short AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 ,
                                             string AV60Core_centrodecustowwds_9_ccunome2 ,
                                             bool AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 ,
                                             string AV62Core_centrodecustowwds_11_dynamicfiltersselector3 ,
                                             short AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 ,
                                             string AV64Core_centrodecustowwds_13_ccunome3 ,
                                             string AV66Core_centrodecustowwds_15_tfccusigla_sel ,
                                             string AV65Core_centrodecustowwds_14_tfccusigla ,
                                             string AV68Core_centrodecustowwds_17_tfccunome_sel ,
                                             string AV67Core_centrodecustowwds_16_tfccunome ,
                                             string A209CcuSigla ,
                                             string A210CcuNome ,
                                             bool A512CcuDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CcuNome, CcuSigla, CcuDel, CcuID FROM tb_centrodecusto";
         AddWhere(sWhereString, "(Not CcuDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_centrodecustowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CcuSigla like '%' || :lV53Core_centrodecustowwds_2_filterfulltext) or ( CcuNome like '%' || :lV53Core_centrodecustowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Core_centrodecustowwds_3_dynamicfiltersselector1, "CCUNOME") == 0 ) && ( AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV56Core_centrodecustowwds_5_ccunome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Core_centrodecustowwds_3_dynamicfiltersselector1, "CCUNOME") == 0 ) && ( AV55Core_centrodecustowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_centrodecustowwds_5_ccunome1)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV56Core_centrodecustowwds_5_ccunome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Core_centrodecustowwds_7_dynamicfiltersselector2, "CCUNOME") == 0 ) && ( AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV60Core_centrodecustowwds_9_ccunome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV57Core_centrodecustowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Core_centrodecustowwds_7_dynamicfiltersselector2, "CCUNOME") == 0 ) && ( AV59Core_centrodecustowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_centrodecustowwds_9_ccunome2)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV60Core_centrodecustowwds_9_ccunome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Core_centrodecustowwds_11_dynamicfiltersselector3, "CCUNOME") == 0 ) && ( AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV64Core_centrodecustowwds_13_ccunome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV61Core_centrodecustowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Core_centrodecustowwds_11_dynamicfiltersselector3, "CCUNOME") == 0 ) && ( AV63Core_centrodecustowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_centrodecustowwds_13_ccunome3)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV64Core_centrodecustowwds_13_ccunome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_centrodecustowwds_15_tfccusigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_centrodecustowwds_14_tfccusigla)) ) )
         {
            AddWhere(sWhereString, "(CcuSigla like :lV65Core_centrodecustowwds_14_tfccusigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_centrodecustowwds_15_tfccusigla_sel)) && ! ( StringUtil.StrCmp(AV66Core_centrodecustowwds_15_tfccusigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CcuSigla = ( :AV66Core_centrodecustowwds_15_tfccusigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_centrodecustowwds_15_tfccusigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CcuSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_centrodecustowwds_17_tfccunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_centrodecustowwds_16_tfccunome)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV67Core_centrodecustowwds_16_tfccunome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_centrodecustowwds_17_tfccunome_sel)) && ! ( StringUtil.StrCmp(AV68Core_centrodecustowwds_17_tfccunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CcuNome = ( :AV68Core_centrodecustowwds_17_tfccunome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Core_centrodecustowwds_17_tfccunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CcuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CcuNome";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00482(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
               case 1 :
                     return conditional_P00483(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00482;
          prmP00482 = new Object[] {
          new ParDef("lV53Core_centrodecustowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Core_centrodecustowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_centrodecustowwds_5_ccunome1",GXType.VarChar,80,0) ,
          new ParDef("lV56Core_centrodecustowwds_5_ccunome1",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_centrodecustowwds_9_ccunome2",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_centrodecustowwds_9_ccunome2",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_centrodecustowwds_13_ccunome3",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_centrodecustowwds_13_ccunome3",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_centrodecustowwds_14_tfccusigla",GXType.VarChar,20,0) ,
          new ParDef("AV66Core_centrodecustowwds_15_tfccusigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV67Core_centrodecustowwds_16_tfccunome",GXType.VarChar,80,0) ,
          new ParDef("AV68Core_centrodecustowwds_17_tfccunome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00483;
          prmP00483 = new Object[] {
          new ParDef("lV53Core_centrodecustowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Core_centrodecustowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_centrodecustowwds_5_ccunome1",GXType.VarChar,80,0) ,
          new ParDef("lV56Core_centrodecustowwds_5_ccunome1",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_centrodecustowwds_9_ccunome2",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_centrodecustowwds_9_ccunome2",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_centrodecustowwds_13_ccunome3",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_centrodecustowwds_13_ccunome3",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_centrodecustowwds_14_tfccusigla",GXType.VarChar,20,0) ,
          new ParDef("AV66Core_centrodecustowwds_15_tfccusigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV67Core_centrodecustowwds_16_tfccunome",GXType.VarChar,80,0) ,
          new ParDef("AV68Core_centrodecustowwds_17_tfccunome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00482", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00482,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00483", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00483,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
