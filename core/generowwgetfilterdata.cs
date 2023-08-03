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
   public class generowwgetfilterdata : GXProcedure
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
            return "generoww_Services_Execute" ;
         }

      }

      public generowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generowwgetfilterdata( IGxContext context )
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
         generowwgetfilterdata objgenerowwgetfilterdata;
         objgenerowwgetfilterdata = new generowwgetfilterdata();
         objgenerowwgetfilterdata.AV31DDOName = aP0_DDOName;
         objgenerowwgetfilterdata.AV32SearchTxtParms = aP1_SearchTxtParms;
         objgenerowwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objgenerowwgetfilterdata.AV34OptionsJson = "" ;
         objgenerowwgetfilterdata.AV35OptionsDescJson = "" ;
         objgenerowwgetfilterdata.AV36OptionIndexesJson = "" ;
         objgenerowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objgenerowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objgenerowwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((generowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_GENSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADGENSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_GENNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADGENNOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV26Session.Get("core.GeneroWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.GeneroWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("core.GeneroWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "GENDEL_FILTRO") == 0 )
            {
               AV56GenDel_Filtro = BooleanUtil.Val( AV29GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFGENSIGLA") == 0 )
            {
               AV49TFGenSigla = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFGENSIGLA_SEL") == 0 )
            {
               AV50TFGenSigla_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFGENNOME") == 0 )
            {
               AV51TFGenNome = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFGENNOME_SEL") == 0 )
            {
               AV52TFGenNome_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "GENSIGLA") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV53GenSigla1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "GENSIGLA") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV54GenSigla2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "GENSIGLA") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV55GenSigla3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADGENSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV49TFGenSigla = AV15SearchTxt;
         AV50TFGenSigla_Sel = "";
         AV59Core_generowwds_1_gendel_filtro = AV56GenDel_Filtro;
         AV60Core_generowwds_2_filterfulltext = AV37FilterFullText;
         AV61Core_generowwds_3_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Core_generowwds_4_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Core_generowwds_5_gensigla1 = AV53GenSigla1;
         AV64Core_generowwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV65Core_generowwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV66Core_generowwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV67Core_generowwds_9_gensigla2 = AV54GenSigla2;
         AV68Core_generowwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV69Core_generowwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV70Core_generowwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV71Core_generowwds_13_gensigla3 = AV55GenSigla3;
         AV72Core_generowwds_14_tfgensigla = AV49TFGenSigla;
         AV73Core_generowwds_15_tfgensigla_sel = AV50TFGenSigla_Sel;
         AV74Core_generowwds_16_tfgennome = AV51TFGenNome;
         AV75Core_generowwds_17_tfgennome_sel = AV52TFGenNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Core_generowwds_2_filterfulltext ,
                                              AV61Core_generowwds_3_dynamicfiltersselector1 ,
                                              AV62Core_generowwds_4_dynamicfiltersoperator1 ,
                                              AV63Core_generowwds_5_gensigla1 ,
                                              AV64Core_generowwds_6_dynamicfiltersenabled2 ,
                                              AV65Core_generowwds_7_dynamicfiltersselector2 ,
                                              AV66Core_generowwds_8_dynamicfiltersoperator2 ,
                                              AV67Core_generowwds_9_gensigla2 ,
                                              AV68Core_generowwds_10_dynamicfiltersenabled3 ,
                                              AV69Core_generowwds_11_dynamicfiltersselector3 ,
                                              AV70Core_generowwds_12_dynamicfiltersoperator3 ,
                                              AV71Core_generowwds_13_gensigla3 ,
                                              AV73Core_generowwds_15_tfgensigla_sel ,
                                              AV72Core_generowwds_14_tfgensigla ,
                                              AV75Core_generowwds_17_tfgennome_sel ,
                                              AV74Core_generowwds_16_tfgennome ,
                                              A153GenSigla ,
                                              A154GenNome ,
                                              A536GenDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Core_generowwds_2_filterfulltext), "%", "");
         lV60Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Core_generowwds_2_filterfulltext), "%", "");
         lV63Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_5_gensigla1), "%", "");
         lV63Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_5_gensigla1), "%", "");
         lV67Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_generowwds_9_gensigla2), "%", "");
         lV67Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_generowwds_9_gensigla2), "%", "");
         lV71Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_generowwds_13_gensigla3), "%", "");
         lV71Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_generowwds_13_gensigla3), "%", "");
         lV72Core_generowwds_14_tfgensigla = StringUtil.Concat( StringUtil.RTrim( AV72Core_generowwds_14_tfgensigla), "%", "");
         lV74Core_generowwds_16_tfgennome = StringUtil.Concat( StringUtil.RTrim( AV74Core_generowwds_16_tfgennome), "%", "");
         /* Using cursor P003X2 */
         pr_default.execute(0, new Object[] {lV60Core_generowwds_2_filterfulltext, lV60Core_generowwds_2_filterfulltext, lV63Core_generowwds_5_gensigla1, lV63Core_generowwds_5_gensigla1, lV67Core_generowwds_9_gensigla2, lV67Core_generowwds_9_gensigla2, lV71Core_generowwds_13_gensigla3, lV71Core_generowwds_13_gensigla3, lV72Core_generowwds_14_tfgensigla, AV73Core_generowwds_15_tfgensigla_sel, lV74Core_generowwds_16_tfgennome, AV75Core_generowwds_17_tfgennome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3X2 = false;
            A153GenSigla = P003X2_A153GenSigla[0];
            A154GenNome = P003X2_A154GenNome[0];
            A536GenDel = P003X2_A536GenDel[0];
            A152GenID = P003X2_A152GenID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003X2_A153GenSigla[0], A153GenSigla) == 0 ) )
            {
               BRK3X2 = false;
               A152GenID = P003X2_A152GenID[0];
               AV25count = (long)(AV25count+1);
               BRK3X2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A153GenSigla)) ? "<#Empty#>" : A153GenSigla);
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
            if ( ! BRK3X2 )
            {
               BRK3X2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADGENNOMEOPTIONS' Routine */
         returnInSub = false;
         AV51TFGenNome = AV15SearchTxt;
         AV52TFGenNome_Sel = "";
         AV59Core_generowwds_1_gendel_filtro = AV56GenDel_Filtro;
         AV60Core_generowwds_2_filterfulltext = AV37FilterFullText;
         AV61Core_generowwds_3_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Core_generowwds_4_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Core_generowwds_5_gensigla1 = AV53GenSigla1;
         AV64Core_generowwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV65Core_generowwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV66Core_generowwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV67Core_generowwds_9_gensigla2 = AV54GenSigla2;
         AV68Core_generowwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV69Core_generowwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV70Core_generowwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV71Core_generowwds_13_gensigla3 = AV55GenSigla3;
         AV72Core_generowwds_14_tfgensigla = AV49TFGenSigla;
         AV73Core_generowwds_15_tfgensigla_sel = AV50TFGenSigla_Sel;
         AV74Core_generowwds_16_tfgennome = AV51TFGenNome;
         AV75Core_generowwds_17_tfgennome_sel = AV52TFGenNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60Core_generowwds_2_filterfulltext ,
                                              AV61Core_generowwds_3_dynamicfiltersselector1 ,
                                              AV62Core_generowwds_4_dynamicfiltersoperator1 ,
                                              AV63Core_generowwds_5_gensigla1 ,
                                              AV64Core_generowwds_6_dynamicfiltersenabled2 ,
                                              AV65Core_generowwds_7_dynamicfiltersselector2 ,
                                              AV66Core_generowwds_8_dynamicfiltersoperator2 ,
                                              AV67Core_generowwds_9_gensigla2 ,
                                              AV68Core_generowwds_10_dynamicfiltersenabled3 ,
                                              AV69Core_generowwds_11_dynamicfiltersselector3 ,
                                              AV70Core_generowwds_12_dynamicfiltersoperator3 ,
                                              AV71Core_generowwds_13_gensigla3 ,
                                              AV73Core_generowwds_15_tfgensigla_sel ,
                                              AV72Core_generowwds_14_tfgensigla ,
                                              AV75Core_generowwds_17_tfgennome_sel ,
                                              AV74Core_generowwds_16_tfgennome ,
                                              A153GenSigla ,
                                              A154GenNome ,
                                              A536GenDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Core_generowwds_2_filterfulltext), "%", "");
         lV60Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Core_generowwds_2_filterfulltext), "%", "");
         lV63Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_5_gensigla1), "%", "");
         lV63Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_5_gensigla1), "%", "");
         lV67Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_generowwds_9_gensigla2), "%", "");
         lV67Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_generowwds_9_gensigla2), "%", "");
         lV71Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_generowwds_13_gensigla3), "%", "");
         lV71Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_generowwds_13_gensigla3), "%", "");
         lV72Core_generowwds_14_tfgensigla = StringUtil.Concat( StringUtil.RTrim( AV72Core_generowwds_14_tfgensigla), "%", "");
         lV74Core_generowwds_16_tfgennome = StringUtil.Concat( StringUtil.RTrim( AV74Core_generowwds_16_tfgennome), "%", "");
         /* Using cursor P003X3 */
         pr_default.execute(1, new Object[] {lV60Core_generowwds_2_filterfulltext, lV60Core_generowwds_2_filterfulltext, lV63Core_generowwds_5_gensigla1, lV63Core_generowwds_5_gensigla1, lV67Core_generowwds_9_gensigla2, lV67Core_generowwds_9_gensigla2, lV71Core_generowwds_13_gensigla3, lV71Core_generowwds_13_gensigla3, lV72Core_generowwds_14_tfgensigla, AV73Core_generowwds_15_tfgensigla_sel, lV74Core_generowwds_16_tfgennome, AV75Core_generowwds_17_tfgennome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3X4 = false;
            A154GenNome = P003X3_A154GenNome[0];
            A153GenSigla = P003X3_A153GenSigla[0];
            A536GenDel = P003X3_A536GenDel[0];
            A152GenID = P003X3_A152GenID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003X3_A154GenNome[0], A154GenNome) == 0 ) )
            {
               BRK3X4 = false;
               A152GenID = P003X3_A152GenID[0];
               AV25count = (long)(AV25count+1);
               BRK3X4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A154GenNome)) ? "<#Empty#>" : A154GenNome);
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
            if ( ! BRK3X4 )
            {
               BRK3X4 = true;
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
         AV49TFGenSigla = "";
         AV50TFGenSigla_Sel = "";
         AV51TFGenNome = "";
         AV52TFGenNome_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV53GenSigla1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV54GenSigla2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV55GenSigla3 = "";
         AV60Core_generowwds_2_filterfulltext = "";
         AV61Core_generowwds_3_dynamicfiltersselector1 = "";
         AV63Core_generowwds_5_gensigla1 = "";
         AV65Core_generowwds_7_dynamicfiltersselector2 = "";
         AV67Core_generowwds_9_gensigla2 = "";
         AV69Core_generowwds_11_dynamicfiltersselector3 = "";
         AV71Core_generowwds_13_gensigla3 = "";
         AV72Core_generowwds_14_tfgensigla = "";
         AV73Core_generowwds_15_tfgensigla_sel = "";
         AV74Core_generowwds_16_tfgennome = "";
         AV75Core_generowwds_17_tfgennome_sel = "";
         scmdbuf = "";
         lV60Core_generowwds_2_filterfulltext = "";
         lV63Core_generowwds_5_gensigla1 = "";
         lV67Core_generowwds_9_gensigla2 = "";
         lV71Core_generowwds_13_gensigla3 = "";
         lV72Core_generowwds_14_tfgensigla = "";
         lV74Core_generowwds_16_tfgennome = "";
         A153GenSigla = "";
         A154GenNome = "";
         P003X2_A153GenSigla = new string[] {""} ;
         P003X2_A154GenNome = new string[] {""} ;
         P003X2_A536GenDel = new bool[] {false} ;
         P003X2_A152GenID = new int[1] ;
         AV20Option = "";
         P003X3_A154GenNome = new string[] {""} ;
         P003X3_A153GenSigla = new string[] {""} ;
         P003X3_A536GenDel = new bool[] {false} ;
         P003X3_A152GenID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.generowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003X2_A153GenSigla, P003X2_A154GenNome, P003X2_A536GenDel, P003X2_A152GenID
               }
               , new Object[] {
               P003X3_A154GenNome, P003X3_A153GenSigla, P003X3_A536GenDel, P003X3_A152GenID
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
      private short AV62Core_generowwds_4_dynamicfiltersoperator1 ;
      private short AV66Core_generowwds_8_dynamicfiltersoperator2 ;
      private short AV70Core_generowwds_12_dynamicfiltersoperator3 ;
      private int AV57GXV1 ;
      private int A152GenID ;
      private long AV25count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV56GenDel_Filtro ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV59Core_generowwds_1_gendel_filtro ;
      private bool AV64Core_generowwds_6_dynamicfiltersenabled2 ;
      private bool AV68Core_generowwds_10_dynamicfiltersenabled3 ;
      private bool A536GenDel ;
      private bool BRK3X2 ;
      private bool BRK3X4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV49TFGenSigla ;
      private string AV50TFGenSigla_Sel ;
      private string AV51TFGenNome ;
      private string AV52TFGenNome_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV53GenSigla1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV54GenSigla2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV55GenSigla3 ;
      private string AV60Core_generowwds_2_filterfulltext ;
      private string AV61Core_generowwds_3_dynamicfiltersselector1 ;
      private string AV63Core_generowwds_5_gensigla1 ;
      private string AV65Core_generowwds_7_dynamicfiltersselector2 ;
      private string AV67Core_generowwds_9_gensigla2 ;
      private string AV69Core_generowwds_11_dynamicfiltersselector3 ;
      private string AV71Core_generowwds_13_gensigla3 ;
      private string AV72Core_generowwds_14_tfgensigla ;
      private string AV73Core_generowwds_15_tfgensigla_sel ;
      private string AV74Core_generowwds_16_tfgennome ;
      private string AV75Core_generowwds_17_tfgennome_sel ;
      private string lV60Core_generowwds_2_filterfulltext ;
      private string lV63Core_generowwds_5_gensigla1 ;
      private string lV67Core_generowwds_9_gensigla2 ;
      private string lV71Core_generowwds_13_gensigla3 ;
      private string lV72Core_generowwds_14_tfgensigla ;
      private string lV74Core_generowwds_16_tfgennome ;
      private string A153GenSigla ;
      private string A154GenNome ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003X2_A153GenSigla ;
      private string[] P003X2_A154GenNome ;
      private bool[] P003X2_A536GenDel ;
      private int[] P003X2_A152GenID ;
      private string[] P003X3_A154GenNome ;
      private string[] P003X3_A153GenSigla ;
      private bool[] P003X3_A536GenDel ;
      private int[] P003X3_A152GenID ;
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

   public class generowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003X2( IGxContext context ,
                                             string AV60Core_generowwds_2_filterfulltext ,
                                             string AV61Core_generowwds_3_dynamicfiltersselector1 ,
                                             short AV62Core_generowwds_4_dynamicfiltersoperator1 ,
                                             string AV63Core_generowwds_5_gensigla1 ,
                                             bool AV64Core_generowwds_6_dynamicfiltersenabled2 ,
                                             string AV65Core_generowwds_7_dynamicfiltersselector2 ,
                                             short AV66Core_generowwds_8_dynamicfiltersoperator2 ,
                                             string AV67Core_generowwds_9_gensigla2 ,
                                             bool AV68Core_generowwds_10_dynamicfiltersenabled3 ,
                                             string AV69Core_generowwds_11_dynamicfiltersselector3 ,
                                             short AV70Core_generowwds_12_dynamicfiltersoperator3 ,
                                             string AV71Core_generowwds_13_gensigla3 ,
                                             string AV73Core_generowwds_15_tfgensigla_sel ,
                                             string AV72Core_generowwds_14_tfgensigla ,
                                             string AV75Core_generowwds_17_tfgennome_sel ,
                                             string AV74Core_generowwds_16_tfgennome ,
                                             string A153GenSigla ,
                                             string A154GenNome ,
                                             bool A536GenDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT GenSigla, GenNome, GenDel, GenID FROM tb_genero";
         AddWhere(sWhereString, "(Not GenDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_generowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( GenSigla like '%' || :lV60Core_generowwds_2_filterfulltext) or ( GenNome like '%' || :lV60Core_generowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV62Core_generowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV63Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV62Core_generowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV63Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV64Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV66Core_generowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV67Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV64Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV66Core_generowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV67Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV68Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV70Core_generowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV71Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV68Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV70Core_generowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV71Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_generowwds_15_tfgensigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_generowwds_14_tfgensigla)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV72Core_generowwds_14_tfgensigla)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_generowwds_15_tfgensigla_sel)) && ! ( StringUtil.StrCmp(AV73Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenSigla = ( :AV73Core_generowwds_15_tfgensigla_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV73Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_generowwds_17_tfgennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_generowwds_16_tfgennome)) ) )
         {
            AddWhere(sWhereString, "(GenNome like :lV74Core_generowwds_16_tfgennome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_generowwds_17_tfgennome_sel)) && ! ( StringUtil.StrCmp(AV75Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenNome = ( :AV75Core_generowwds_17_tfgennome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV75Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY GenSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003X3( IGxContext context ,
                                             string AV60Core_generowwds_2_filterfulltext ,
                                             string AV61Core_generowwds_3_dynamicfiltersselector1 ,
                                             short AV62Core_generowwds_4_dynamicfiltersoperator1 ,
                                             string AV63Core_generowwds_5_gensigla1 ,
                                             bool AV64Core_generowwds_6_dynamicfiltersenabled2 ,
                                             string AV65Core_generowwds_7_dynamicfiltersselector2 ,
                                             short AV66Core_generowwds_8_dynamicfiltersoperator2 ,
                                             string AV67Core_generowwds_9_gensigla2 ,
                                             bool AV68Core_generowwds_10_dynamicfiltersenabled3 ,
                                             string AV69Core_generowwds_11_dynamicfiltersselector3 ,
                                             short AV70Core_generowwds_12_dynamicfiltersoperator3 ,
                                             string AV71Core_generowwds_13_gensigla3 ,
                                             string AV73Core_generowwds_15_tfgensigla_sel ,
                                             string AV72Core_generowwds_14_tfgensigla ,
                                             string AV75Core_generowwds_17_tfgennome_sel ,
                                             string AV74Core_generowwds_16_tfgennome ,
                                             string A153GenSigla ,
                                             string A154GenNome ,
                                             bool A536GenDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT GenNome, GenSigla, GenDel, GenID FROM tb_genero";
         AddWhere(sWhereString, "(Not GenDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_generowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( GenSigla like '%' || :lV60Core_generowwds_2_filterfulltext) or ( GenNome like '%' || :lV60Core_generowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV62Core_generowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV63Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV62Core_generowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV63Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV64Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV66Core_generowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV67Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV64Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV66Core_generowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV67Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV68Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV70Core_generowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV71Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV68Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV70Core_generowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV71Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_generowwds_15_tfgensigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_generowwds_14_tfgensigla)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV72Core_generowwds_14_tfgensigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_generowwds_15_tfgensigla_sel)) && ! ( StringUtil.StrCmp(AV73Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenSigla = ( :AV73Core_generowwds_15_tfgensigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV73Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_generowwds_17_tfgennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_generowwds_16_tfgennome)) ) )
         {
            AddWhere(sWhereString, "(GenNome like :lV74Core_generowwds_16_tfgennome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_generowwds_17_tfgennome_sel)) && ! ( StringUtil.StrCmp(AV75Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenNome = ( :AV75Core_generowwds_17_tfgennome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV75Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY GenNome";
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
                     return conditional_P003X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
               case 1 :
                     return conditional_P003X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP003X2;
          prmP003X2 = new Object[] {
          new ParDef("lV60Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV63Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV67Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV67Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV71Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV71Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV72Core_generowwds_14_tfgensigla",GXType.VarChar,20,0) ,
          new ParDef("AV73Core_generowwds_15_tfgensigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV74Core_generowwds_16_tfgennome",GXType.VarChar,80,0) ,
          new ParDef("AV75Core_generowwds_17_tfgennome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP003X3;
          prmP003X3 = new Object[] {
          new ParDef("lV60Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV63Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV67Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV67Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV71Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV71Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV72Core_generowwds_14_tfgensigla",GXType.VarChar,20,0) ,
          new ParDef("AV73Core_generowwds_15_tfgensigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV74Core_generowwds_16_tfgennome",GXType.VarChar,80,0) ,
          new ParDef("AV75Core_generowwds_17_tfgennome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003X2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003X3,100, GxCacheFrequency.OFF ,true,false )
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
