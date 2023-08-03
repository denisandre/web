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
   public class contatotipowwgetfilterdata : GXProcedure
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
            return "contatotipoww_Services_Execute" ;
         }

      }

      public contatotipowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contatotipowwgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         contatotipowwgetfilterdata objcontatotipowwgetfilterdata;
         objcontatotipowwgetfilterdata = new contatotipowwgetfilterdata();
         objcontatotipowwgetfilterdata.AV33DDOName = aP0_DDOName;
         objcontatotipowwgetfilterdata.AV34SearchTxtParms = aP1_SearchTxtParms;
         objcontatotipowwgetfilterdata.AV35SearchTxtTo = aP2_SearchTxtTo;
         objcontatotipowwgetfilterdata.AV36OptionsJson = "" ;
         objcontatotipowwgetfilterdata.AV37OptionsDescJson = "" ;
         objcontatotipowwgetfilterdata.AV38OptionIndexesJson = "" ;
         objcontatotipowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcontatotipowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objcontatotipowwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((contatotipowwgetfilterdata)stateInfo).executePrivate();
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
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20MaxItems = 10;
         AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
         AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_COTSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADCOTSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_COTNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCOTNOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("core.ContatoTipoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ContatoTipoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.ContatoTipoWWGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "COTDEL_FILTRO") == 0 )
            {
               AV61CotDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTSIGLA") == 0 )
            {
               AV54TFCotSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTSIGLA_SEL") == 0 )
            {
               AV55TFCotSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTNOME") == 0 )
            {
               AV56TFCotNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTNOME_SEL") == 0 )
            {
               AV57TFCotNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "COTNOME") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV58CotNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "COTNOME") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV59CotNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "COTNOME") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV60CotNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOTSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV54TFCotSigla = AV17SearchTxt;
         AV55TFCotSigla_Sel = "";
         AV64Core_contatotipowwds_1_cotdel_filtro = AV61CotDel_Filtro;
         AV65Core_contatotipowwds_2_filterfulltext = AV39FilterFullText;
         AV66Core_contatotipowwds_3_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV67Core_contatotipowwds_4_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV68Core_contatotipowwds_5_cotnome1 = AV58CotNome1;
         AV69Core_contatotipowwds_6_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV70Core_contatotipowwds_7_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV71Core_contatotipowwds_8_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV72Core_contatotipowwds_9_cotnome2 = AV59CotNome2;
         AV73Core_contatotipowwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV74Core_contatotipowwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV75Core_contatotipowwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV76Core_contatotipowwds_13_cotnome3 = AV60CotNome3;
         AV77Core_contatotipowwds_14_tfcotsigla = AV54TFCotSigla;
         AV78Core_contatotipowwds_15_tfcotsigla_sel = AV55TFCotSigla_Sel;
         AV79Core_contatotipowwds_16_tfcotnome = AV56TFCotNome;
         AV80Core_contatotipowwds_17_tfcotnome_sel = AV57TFCotNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV65Core_contatotipowwds_2_filterfulltext ,
                                              AV66Core_contatotipowwds_3_dynamicfiltersselector1 ,
                                              AV67Core_contatotipowwds_4_dynamicfiltersoperator1 ,
                                              AV68Core_contatotipowwds_5_cotnome1 ,
                                              AV69Core_contatotipowwds_6_dynamicfiltersenabled2 ,
                                              AV70Core_contatotipowwds_7_dynamicfiltersselector2 ,
                                              AV71Core_contatotipowwds_8_dynamicfiltersoperator2 ,
                                              AV72Core_contatotipowwds_9_cotnome2 ,
                                              AV73Core_contatotipowwds_10_dynamicfiltersenabled3 ,
                                              AV74Core_contatotipowwds_11_dynamicfiltersselector3 ,
                                              AV75Core_contatotipowwds_12_dynamicfiltersoperator3 ,
                                              AV76Core_contatotipowwds_13_cotnome3 ,
                                              AV78Core_contatotipowwds_15_tfcotsigla_sel ,
                                              AV77Core_contatotipowwds_14_tfcotsigla ,
                                              AV80Core_contatotipowwds_17_tfcotnome_sel ,
                                              AV79Core_contatotipowwds_16_tfcotnome ,
                                              A150CotSigla ,
                                              A151CotNome ,
                                              A566CotDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Core_contatotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_contatotipowwds_2_filterfulltext), "%", "");
         lV65Core_contatotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_contatotipowwds_2_filterfulltext), "%", "");
         lV68Core_contatotipowwds_5_cotnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1), "%", "");
         lV68Core_contatotipowwds_5_cotnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1), "%", "");
         lV72Core_contatotipowwds_9_cotnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2), "%", "");
         lV72Core_contatotipowwds_9_cotnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2), "%", "");
         lV76Core_contatotipowwds_13_cotnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3), "%", "");
         lV76Core_contatotipowwds_13_cotnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3), "%", "");
         lV77Core_contatotipowwds_14_tfcotsigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_contatotipowwds_14_tfcotsigla), "%", "");
         lV79Core_contatotipowwds_16_tfcotnome = StringUtil.Concat( StringUtil.RTrim( AV79Core_contatotipowwds_16_tfcotnome), "%", "");
         /* Using cursor P003U2 */
         pr_default.execute(0, new Object[] {lV65Core_contatotipowwds_2_filterfulltext, lV65Core_contatotipowwds_2_filterfulltext, lV68Core_contatotipowwds_5_cotnome1, lV68Core_contatotipowwds_5_cotnome1, lV72Core_contatotipowwds_9_cotnome2, lV72Core_contatotipowwds_9_cotnome2, lV76Core_contatotipowwds_13_cotnome3, lV76Core_contatotipowwds_13_cotnome3, lV77Core_contatotipowwds_14_tfcotsigla, AV78Core_contatotipowwds_15_tfcotsigla_sel, lV79Core_contatotipowwds_16_tfcotnome, AV80Core_contatotipowwds_17_tfcotnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3U2 = false;
            A150CotSigla = P003U2_A150CotSigla[0];
            A151CotNome = P003U2_A151CotNome[0];
            A566CotDel = P003U2_A566CotDel[0];
            A149CotID = P003U2_A149CotID[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003U2_A150CotSigla[0], A150CotSigla) == 0 ) )
            {
               BRK3U2 = false;
               A149CotID = P003U2_A149CotID[0];
               AV27count = (long)(AV27count+1);
               BRK3U2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A150CotSigla)) ? "<#Empty#>" : A150CotSigla);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK3U2 )
            {
               BRK3U2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCOTNOMEOPTIONS' Routine */
         returnInSub = false;
         AV56TFCotNome = AV17SearchTxt;
         AV57TFCotNome_Sel = "";
         AV64Core_contatotipowwds_1_cotdel_filtro = AV61CotDel_Filtro;
         AV65Core_contatotipowwds_2_filterfulltext = AV39FilterFullText;
         AV66Core_contatotipowwds_3_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV67Core_contatotipowwds_4_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV68Core_contatotipowwds_5_cotnome1 = AV58CotNome1;
         AV69Core_contatotipowwds_6_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV70Core_contatotipowwds_7_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV71Core_contatotipowwds_8_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV72Core_contatotipowwds_9_cotnome2 = AV59CotNome2;
         AV73Core_contatotipowwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV74Core_contatotipowwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV75Core_contatotipowwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV76Core_contatotipowwds_13_cotnome3 = AV60CotNome3;
         AV77Core_contatotipowwds_14_tfcotsigla = AV54TFCotSigla;
         AV78Core_contatotipowwds_15_tfcotsigla_sel = AV55TFCotSigla_Sel;
         AV79Core_contatotipowwds_16_tfcotnome = AV56TFCotNome;
         AV80Core_contatotipowwds_17_tfcotnome_sel = AV57TFCotNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Core_contatotipowwds_2_filterfulltext ,
                                              AV66Core_contatotipowwds_3_dynamicfiltersselector1 ,
                                              AV67Core_contatotipowwds_4_dynamicfiltersoperator1 ,
                                              AV68Core_contatotipowwds_5_cotnome1 ,
                                              AV69Core_contatotipowwds_6_dynamicfiltersenabled2 ,
                                              AV70Core_contatotipowwds_7_dynamicfiltersselector2 ,
                                              AV71Core_contatotipowwds_8_dynamicfiltersoperator2 ,
                                              AV72Core_contatotipowwds_9_cotnome2 ,
                                              AV73Core_contatotipowwds_10_dynamicfiltersenabled3 ,
                                              AV74Core_contatotipowwds_11_dynamicfiltersselector3 ,
                                              AV75Core_contatotipowwds_12_dynamicfiltersoperator3 ,
                                              AV76Core_contatotipowwds_13_cotnome3 ,
                                              AV78Core_contatotipowwds_15_tfcotsigla_sel ,
                                              AV77Core_contatotipowwds_14_tfcotsigla ,
                                              AV80Core_contatotipowwds_17_tfcotnome_sel ,
                                              AV79Core_contatotipowwds_16_tfcotnome ,
                                              A150CotSigla ,
                                              A151CotNome ,
                                              A566CotDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Core_contatotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_contatotipowwds_2_filterfulltext), "%", "");
         lV65Core_contatotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_contatotipowwds_2_filterfulltext), "%", "");
         lV68Core_contatotipowwds_5_cotnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1), "%", "");
         lV68Core_contatotipowwds_5_cotnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1), "%", "");
         lV72Core_contatotipowwds_9_cotnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2), "%", "");
         lV72Core_contatotipowwds_9_cotnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2), "%", "");
         lV76Core_contatotipowwds_13_cotnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3), "%", "");
         lV76Core_contatotipowwds_13_cotnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3), "%", "");
         lV77Core_contatotipowwds_14_tfcotsigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_contatotipowwds_14_tfcotsigla), "%", "");
         lV79Core_contatotipowwds_16_tfcotnome = StringUtil.Concat( StringUtil.RTrim( AV79Core_contatotipowwds_16_tfcotnome), "%", "");
         /* Using cursor P003U3 */
         pr_default.execute(1, new Object[] {lV65Core_contatotipowwds_2_filterfulltext, lV65Core_contatotipowwds_2_filterfulltext, lV68Core_contatotipowwds_5_cotnome1, lV68Core_contatotipowwds_5_cotnome1, lV72Core_contatotipowwds_9_cotnome2, lV72Core_contatotipowwds_9_cotnome2, lV76Core_contatotipowwds_13_cotnome3, lV76Core_contatotipowwds_13_cotnome3, lV77Core_contatotipowwds_14_tfcotsigla, AV78Core_contatotipowwds_15_tfcotsigla_sel, lV79Core_contatotipowwds_16_tfcotnome, AV80Core_contatotipowwds_17_tfcotnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3U4 = false;
            A151CotNome = P003U3_A151CotNome[0];
            A150CotSigla = P003U3_A150CotSigla[0];
            A566CotDel = P003U3_A566CotDel[0];
            A149CotID = P003U3_A149CotID[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003U3_A151CotNome[0], A151CotNome) == 0 ) )
            {
               BRK3U4 = false;
               A149CotID = P003U3_A149CotID[0];
               AV27count = (long)(AV27count+1);
               BRK3U4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A151CotNome)) ? "<#Empty#>" : A151CotNome);
               AV23Options.Add(AV22Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV23Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV18SkipItems = (short)(AV18SkipItems-1);
            }
            if ( ! BRK3U4 )
            {
               BRK3U4 = true;
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV54TFCotSigla = "";
         AV55TFCotSigla_Sel = "";
         AV56TFCotNome = "";
         AV57TFCotNome_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV58CotNome1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV59CotNome2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV60CotNome3 = "";
         AV65Core_contatotipowwds_2_filterfulltext = "";
         AV66Core_contatotipowwds_3_dynamicfiltersselector1 = "";
         AV68Core_contatotipowwds_5_cotnome1 = "";
         AV70Core_contatotipowwds_7_dynamicfiltersselector2 = "";
         AV72Core_contatotipowwds_9_cotnome2 = "";
         AV74Core_contatotipowwds_11_dynamicfiltersselector3 = "";
         AV76Core_contatotipowwds_13_cotnome3 = "";
         AV77Core_contatotipowwds_14_tfcotsigla = "";
         AV78Core_contatotipowwds_15_tfcotsigla_sel = "";
         AV79Core_contatotipowwds_16_tfcotnome = "";
         AV80Core_contatotipowwds_17_tfcotnome_sel = "";
         scmdbuf = "";
         lV65Core_contatotipowwds_2_filterfulltext = "";
         lV68Core_contatotipowwds_5_cotnome1 = "";
         lV72Core_contatotipowwds_9_cotnome2 = "";
         lV76Core_contatotipowwds_13_cotnome3 = "";
         lV77Core_contatotipowwds_14_tfcotsigla = "";
         lV79Core_contatotipowwds_16_tfcotnome = "";
         A150CotSigla = "";
         A151CotNome = "";
         P003U2_A150CotSigla = new string[] {""} ;
         P003U2_A151CotNome = new string[] {""} ;
         P003U2_A566CotDel = new bool[] {false} ;
         P003U2_A149CotID = new int[1] ;
         AV22Option = "";
         P003U3_A151CotNome = new string[] {""} ;
         P003U3_A150CotSigla = new string[] {""} ;
         P003U3_A566CotDel = new bool[] {false} ;
         P003U3_A149CotID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.contatotipowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003U2_A150CotSigla, P003U2_A151CotNome, P003U2_A566CotDel, P003U2_A149CotID
               }
               , new Object[] {
               P003U3_A151CotNome, P003U3_A150CotSigla, P003U3_A566CotDel, P003U3_A149CotID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV67Core_contatotipowwds_4_dynamicfiltersoperator1 ;
      private short AV71Core_contatotipowwds_8_dynamicfiltersoperator2 ;
      private short AV75Core_contatotipowwds_12_dynamicfiltersoperator3 ;
      private int AV62GXV1 ;
      private int A149CotID ;
      private long AV27count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV61CotDel_Filtro ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV64Core_contatotipowwds_1_cotdel_filtro ;
      private bool AV69Core_contatotipowwds_6_dynamicfiltersenabled2 ;
      private bool AV73Core_contatotipowwds_10_dynamicfiltersenabled3 ;
      private bool A566CotDel ;
      private bool BRK3U2 ;
      private bool BRK3U4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV54TFCotSigla ;
      private string AV55TFCotSigla_Sel ;
      private string AV56TFCotNome ;
      private string AV57TFCotNome_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV58CotNome1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV59CotNome2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV60CotNome3 ;
      private string AV65Core_contatotipowwds_2_filterfulltext ;
      private string AV66Core_contatotipowwds_3_dynamicfiltersselector1 ;
      private string AV68Core_contatotipowwds_5_cotnome1 ;
      private string AV70Core_contatotipowwds_7_dynamicfiltersselector2 ;
      private string AV72Core_contatotipowwds_9_cotnome2 ;
      private string AV74Core_contatotipowwds_11_dynamicfiltersselector3 ;
      private string AV76Core_contatotipowwds_13_cotnome3 ;
      private string AV77Core_contatotipowwds_14_tfcotsigla ;
      private string AV78Core_contatotipowwds_15_tfcotsigla_sel ;
      private string AV79Core_contatotipowwds_16_tfcotnome ;
      private string AV80Core_contatotipowwds_17_tfcotnome_sel ;
      private string lV65Core_contatotipowwds_2_filterfulltext ;
      private string lV68Core_contatotipowwds_5_cotnome1 ;
      private string lV72Core_contatotipowwds_9_cotnome2 ;
      private string lV76Core_contatotipowwds_13_cotnome3 ;
      private string lV77Core_contatotipowwds_14_tfcotsigla ;
      private string lV79Core_contatotipowwds_16_tfcotnome ;
      private string A150CotSigla ;
      private string A151CotNome ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003U2_A150CotSigla ;
      private string[] P003U2_A151CotNome ;
      private bool[] P003U2_A566CotDel ;
      private int[] P003U2_A149CotID ;
      private string[] P003U3_A151CotNome ;
      private string[] P003U3_A150CotSigla ;
      private bool[] P003U3_A566CotDel ;
      private int[] P003U3_A149CotID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class contatotipowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003U2( IGxContext context ,
                                             string AV65Core_contatotipowwds_2_filterfulltext ,
                                             string AV66Core_contatotipowwds_3_dynamicfiltersselector1 ,
                                             short AV67Core_contatotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV68Core_contatotipowwds_5_cotnome1 ,
                                             bool AV69Core_contatotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV70Core_contatotipowwds_7_dynamicfiltersselector2 ,
                                             short AV71Core_contatotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV72Core_contatotipowwds_9_cotnome2 ,
                                             bool AV73Core_contatotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV74Core_contatotipowwds_11_dynamicfiltersselector3 ,
                                             short AV75Core_contatotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV76Core_contatotipowwds_13_cotnome3 ,
                                             string AV78Core_contatotipowwds_15_tfcotsigla_sel ,
                                             string AV77Core_contatotipowwds_14_tfcotsigla ,
                                             string AV80Core_contatotipowwds_17_tfcotnome_sel ,
                                             string AV79Core_contatotipowwds_16_tfcotnome ,
                                             string A150CotSigla ,
                                             string A151CotNome ,
                                             bool A566CotDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CotSigla, CotNome, CotDel, CotID FROM tb_contatotipo";
         AddWhere(sWhereString, "(Not CotDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_contatotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CotSigla like '%' || :lV65Core_contatotipowwds_2_filterfulltext) or ( CotNome like '%' || :lV65Core_contatotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_contatotipowwds_3_dynamicfiltersselector1, "COTNOME") == 0 ) && ( AV67Core_contatotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV68Core_contatotipowwds_5_cotnome1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_contatotipowwds_3_dynamicfiltersselector1, "COTNOME") == 0 ) && ( AV67Core_contatotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV68Core_contatotipowwds_5_cotnome1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV69Core_contatotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_contatotipowwds_7_dynamicfiltersselector2, "COTNOME") == 0 ) && ( AV71Core_contatotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV72Core_contatotipowwds_9_cotnome2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV69Core_contatotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_contatotipowwds_7_dynamicfiltersselector2, "COTNOME") == 0 ) && ( AV71Core_contatotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV72Core_contatotipowwds_9_cotnome2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV73Core_contatotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_contatotipowwds_11_dynamicfiltersselector3, "COTNOME") == 0 ) && ( AV75Core_contatotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV76Core_contatotipowwds_13_cotnome3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV73Core_contatotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_contatotipowwds_11_dynamicfiltersselector3, "COTNOME") == 0 ) && ( AV75Core_contatotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV76Core_contatotipowwds_13_cotnome3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_contatotipowwds_15_tfcotsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_contatotipowwds_14_tfcotsigla)) ) )
         {
            AddWhere(sWhereString, "(CotSigla like :lV77Core_contatotipowwds_14_tfcotsigla)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_contatotipowwds_15_tfcotsigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_contatotipowwds_15_tfcotsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CotSigla = ( :AV78Core_contatotipowwds_15_tfcotsigla_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_contatotipowwds_15_tfcotsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CotSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_contatotipowwds_17_tfcotnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_contatotipowwds_16_tfcotnome)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV79Core_contatotipowwds_16_tfcotnome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_contatotipowwds_17_tfcotnome_sel)) && ! ( StringUtil.StrCmp(AV80Core_contatotipowwds_17_tfcotnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CotNome = ( :AV80Core_contatotipowwds_17_tfcotnome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Core_contatotipowwds_17_tfcotnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CotNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CotSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003U3( IGxContext context ,
                                             string AV65Core_contatotipowwds_2_filterfulltext ,
                                             string AV66Core_contatotipowwds_3_dynamicfiltersselector1 ,
                                             short AV67Core_contatotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV68Core_contatotipowwds_5_cotnome1 ,
                                             bool AV69Core_contatotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV70Core_contatotipowwds_7_dynamicfiltersselector2 ,
                                             short AV71Core_contatotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV72Core_contatotipowwds_9_cotnome2 ,
                                             bool AV73Core_contatotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV74Core_contatotipowwds_11_dynamicfiltersselector3 ,
                                             short AV75Core_contatotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV76Core_contatotipowwds_13_cotnome3 ,
                                             string AV78Core_contatotipowwds_15_tfcotsigla_sel ,
                                             string AV77Core_contatotipowwds_14_tfcotsigla ,
                                             string AV80Core_contatotipowwds_17_tfcotnome_sel ,
                                             string AV79Core_contatotipowwds_16_tfcotnome ,
                                             string A150CotSigla ,
                                             string A151CotNome ,
                                             bool A566CotDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CotNome, CotSigla, CotDel, CotID FROM tb_contatotipo";
         AddWhere(sWhereString, "(Not CotDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_contatotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CotSigla like '%' || :lV65Core_contatotipowwds_2_filterfulltext) or ( CotNome like '%' || :lV65Core_contatotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_contatotipowwds_3_dynamicfiltersselector1, "COTNOME") == 0 ) && ( AV67Core_contatotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV68Core_contatotipowwds_5_cotnome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_contatotipowwds_3_dynamicfiltersselector1, "COTNOME") == 0 ) && ( AV67Core_contatotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_contatotipowwds_5_cotnome1)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV68Core_contatotipowwds_5_cotnome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV69Core_contatotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_contatotipowwds_7_dynamicfiltersselector2, "COTNOME") == 0 ) && ( AV71Core_contatotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV72Core_contatotipowwds_9_cotnome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV69Core_contatotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_contatotipowwds_7_dynamicfiltersselector2, "COTNOME") == 0 ) && ( AV71Core_contatotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_contatotipowwds_9_cotnome2)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV72Core_contatotipowwds_9_cotnome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV73Core_contatotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_contatotipowwds_11_dynamicfiltersselector3, "COTNOME") == 0 ) && ( AV75Core_contatotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV76Core_contatotipowwds_13_cotnome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV73Core_contatotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_contatotipowwds_11_dynamicfiltersselector3, "COTNOME") == 0 ) && ( AV75Core_contatotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_contatotipowwds_13_cotnome3)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV76Core_contatotipowwds_13_cotnome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_contatotipowwds_15_tfcotsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_contatotipowwds_14_tfcotsigla)) ) )
         {
            AddWhere(sWhereString, "(CotSigla like :lV77Core_contatotipowwds_14_tfcotsigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_contatotipowwds_15_tfcotsigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_contatotipowwds_15_tfcotsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CotSigla = ( :AV78Core_contatotipowwds_15_tfcotsigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_contatotipowwds_15_tfcotsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CotSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_contatotipowwds_17_tfcotnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_contatotipowwds_16_tfcotnome)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV79Core_contatotipowwds_16_tfcotnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_contatotipowwds_17_tfcotnome_sel)) && ! ( StringUtil.StrCmp(AV80Core_contatotipowwds_17_tfcotnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CotNome = ( :AV80Core_contatotipowwds_17_tfcotnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Core_contatotipowwds_17_tfcotnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CotNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CotNome";
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
                     return conditional_P003U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
               case 1 :
                     return conditional_P003U3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP003U2;
          prmP003U2 = new Object[] {
          new ParDef("lV65Core_contatotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_contatotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Core_contatotipowwds_5_cotnome1",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_contatotipowwds_5_cotnome1",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_contatotipowwds_9_cotnome2",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_contatotipowwds_9_cotnome2",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_contatotipowwds_13_cotnome3",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_contatotipowwds_13_cotnome3",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_contatotipowwds_14_tfcotsigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_contatotipowwds_15_tfcotsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV79Core_contatotipowwds_16_tfcotnome",GXType.VarChar,80,0) ,
          new ParDef("AV80Core_contatotipowwds_17_tfcotnome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP003U3;
          prmP003U3 = new Object[] {
          new ParDef("lV65Core_contatotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_contatotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Core_contatotipowwds_5_cotnome1",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_contatotipowwds_5_cotnome1",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_contatotipowwds_9_cotnome2",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_contatotipowwds_9_cotnome2",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_contatotipowwds_13_cotnome3",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_contatotipowwds_13_cotnome3",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_contatotipowwds_14_tfcotsigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_contatotipowwds_15_tfcotsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV79Core_contatotipowwds_16_tfcotnome",GXType.VarChar,80,0) ,
          new ParDef("AV80Core_contatotipowwds_17_tfcotnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003U2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003U3,100, GxCacheFrequency.OFF ,true,false )
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
