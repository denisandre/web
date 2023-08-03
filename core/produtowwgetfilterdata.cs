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
   public class produtowwgetfilterdata : GXProcedure
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
            return "produtoww_Services_Execute" ;
         }

      }

      public produtowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtowwgetfilterdata( IGxContext context )
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
         produtowwgetfilterdata objprodutowwgetfilterdata;
         objprodutowwgetfilterdata = new produtowwgetfilterdata();
         objprodutowwgetfilterdata.AV33DDOName = aP0_DDOName;
         objprodutowwgetfilterdata.AV34SearchTxtParms = aP1_SearchTxtParms;
         objprodutowwgetfilterdata.AV35SearchTxtTo = aP2_SearchTxtTo;
         objprodutowwgetfilterdata.AV36OptionsJson = "" ;
         objprodutowwgetfilterdata.AV37OptionsDescJson = "" ;
         objprodutowwgetfilterdata.AV38OptionIndexesJson = "" ;
         objprodutowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objprodutowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objprodutowwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((produtowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_PRDCODIGO") == 0 )
         {
            /* Execute user subroutine: 'LOADPRDCODIGOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_PRDNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPRDNOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_PRDTIPOSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADPRDTIPOSIGLAOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.ProdutoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ProdutoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.ProdutoWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PRDDEL_FILTRO") == 0 )
            {
               AV54PrdDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRDCODIGO") == 0 )
            {
               AV11TFPrdCodigo = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRDCODIGO_SEL") == 0 )
            {
               AV12TFPrdCodigo_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRDNOME") == 0 )
            {
               AV13TFPrdNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRDNOME_SEL") == 0 )
            {
               AV14TFPrdNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRDTIPOSIGLA") == 0 )
            {
               AV15TFPrdTipoSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRDTIPOSIGLA_SEL") == 0 )
            {
               AV16TFPrdTipoSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "PRDCODIGO") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42PrdCodigo1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "PRDTIPONOME") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV43PrdTipoNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "PRDCODIGO") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV47PrdCodigo2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "PRDTIPONOME") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV48PrdTipoNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "PRDCODIGO") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV52PrdCodigo3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "PRDTIPONOME") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV53PrdTipoNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPRDCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV11TFPrdCodigo = AV17SearchTxt;
         AV12TFPrdCodigo_Sel = "";
         AV57Core_produtowwds_1_prddel_filtro = AV54PrdDel_Filtro;
         AV58Core_produtowwds_2_filterfulltext = AV39FilterFullText;
         AV59Core_produtowwds_3_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV60Core_produtowwds_4_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV61Core_produtowwds_5_prdcodigo1 = AV42PrdCodigo1;
         AV62Core_produtowwds_6_prdtiponome1 = AV43PrdTipoNome1;
         AV63Core_produtowwds_7_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV64Core_produtowwds_8_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV65Core_produtowwds_9_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV66Core_produtowwds_10_prdcodigo2 = AV47PrdCodigo2;
         AV67Core_produtowwds_11_prdtiponome2 = AV48PrdTipoNome2;
         AV68Core_produtowwds_12_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV69Core_produtowwds_13_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV70Core_produtowwds_14_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV71Core_produtowwds_15_prdcodigo3 = AV52PrdCodigo3;
         AV72Core_produtowwds_16_prdtiponome3 = AV53PrdTipoNome3;
         AV73Core_produtowwds_17_tfprdcodigo = AV11TFPrdCodigo;
         AV74Core_produtowwds_18_tfprdcodigo_sel = AV12TFPrdCodigo_Sel;
         AV75Core_produtowwds_19_tfprdnome = AV13TFPrdNome;
         AV76Core_produtowwds_20_tfprdnome_sel = AV14TFPrdNome_Sel;
         AV77Core_produtowwds_21_tfprdtiposigla = AV15TFPrdTipoSigla;
         AV78Core_produtowwds_22_tfprdtiposigla_sel = AV16TFPrdTipoSigla_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Core_produtowwds_2_filterfulltext ,
                                              AV59Core_produtowwds_3_dynamicfiltersselector1 ,
                                              AV60Core_produtowwds_4_dynamicfiltersoperator1 ,
                                              AV61Core_produtowwds_5_prdcodigo1 ,
                                              AV62Core_produtowwds_6_prdtiponome1 ,
                                              AV63Core_produtowwds_7_dynamicfiltersenabled2 ,
                                              AV64Core_produtowwds_8_dynamicfiltersselector2 ,
                                              AV65Core_produtowwds_9_dynamicfiltersoperator2 ,
                                              AV66Core_produtowwds_10_prdcodigo2 ,
                                              AV67Core_produtowwds_11_prdtiponome2 ,
                                              AV68Core_produtowwds_12_dynamicfiltersenabled3 ,
                                              AV69Core_produtowwds_13_dynamicfiltersselector3 ,
                                              AV70Core_produtowwds_14_dynamicfiltersoperator3 ,
                                              AV71Core_produtowwds_15_prdcodigo3 ,
                                              AV72Core_produtowwds_16_prdtiponome3 ,
                                              AV74Core_produtowwds_18_tfprdcodigo_sel ,
                                              AV73Core_produtowwds_17_tfprdcodigo ,
                                              AV76Core_produtowwds_20_tfprdnome_sel ,
                                              AV75Core_produtowwds_19_tfprdnome ,
                                              AV78Core_produtowwds_22_tfprdtiposigla_sel ,
                                              AV77Core_produtowwds_21_tfprdtiposigla ,
                                              A221PrdCodigo ,
                                              A222PrdNome ,
                                              A233PrdTipoSigla ,
                                              A234PrdTipoNome ,
                                              A620PrdDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1), "%", "");
         lV61Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1), "%", "");
         lV62Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1), "%", "");
         lV62Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1), "%", "");
         lV66Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2), "%", "");
         lV66Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2), "%", "");
         lV67Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2), "%", "");
         lV67Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2), "%", "");
         lV71Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3), "%", "");
         lV71Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3), "%", "");
         lV72Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3), "%", "");
         lV72Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3), "%", "");
         lV73Core_produtowwds_17_tfprdcodigo = StringUtil.Concat( StringUtil.RTrim( AV73Core_produtowwds_17_tfprdcodigo), "%", "");
         lV75Core_produtowwds_19_tfprdnome = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_19_tfprdnome), "%", "");
         lV77Core_produtowwds_21_tfprdtiposigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_produtowwds_21_tfprdtiposigla), "%", "");
         /* Using cursor P004B2 */
         pr_default.execute(0, new Object[] {lV58Core_produtowwds_2_filterfulltext, lV58Core_produtowwds_2_filterfulltext, lV58Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_5_prdcodigo1, lV61Core_produtowwds_5_prdcodigo1, lV62Core_produtowwds_6_prdtiponome1, lV62Core_produtowwds_6_prdtiponome1, lV66Core_produtowwds_10_prdcodigo2, lV66Core_produtowwds_10_prdcodigo2, lV67Core_produtowwds_11_prdtiponome2, lV67Core_produtowwds_11_prdtiponome2, lV71Core_produtowwds_15_prdcodigo3, lV71Core_produtowwds_15_prdcodigo3, lV72Core_produtowwds_16_prdtiponome3, lV72Core_produtowwds_16_prdtiponome3, lV73Core_produtowwds_17_tfprdcodigo, AV74Core_produtowwds_18_tfprdcodigo_sel, lV75Core_produtowwds_19_tfprdnome, AV76Core_produtowwds_20_tfprdnome_sel, lV77Core_produtowwds_21_tfprdtiposigla, AV78Core_produtowwds_22_tfprdtiposigla_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4B2 = false;
            A232PrdTipoID = P004B2_A232PrdTipoID[0];
            A221PrdCodigo = P004B2_A221PrdCodigo[0];
            A234PrdTipoNome = P004B2_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004B2_A233PrdTipoSigla[0];
            A222PrdNome = P004B2_A222PrdNome[0];
            A620PrdDel = P004B2_A620PrdDel[0];
            A220PrdID = P004B2_A220PrdID[0];
            A234PrdTipoNome = P004B2_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004B2_A233PrdTipoSigla[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004B2_A221PrdCodigo[0], A221PrdCodigo) == 0 ) )
            {
               BRK4B2 = false;
               A220PrdID = P004B2_A220PrdID[0];
               AV27count = (long)(AV27count+1);
               BRK4B2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A221PrdCodigo)) ? "<#Empty#>" : A221PrdCodigo);
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
            if ( ! BRK4B2 )
            {
               BRK4B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPRDNOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFPrdNome = AV17SearchTxt;
         AV14TFPrdNome_Sel = "";
         AV57Core_produtowwds_1_prddel_filtro = AV54PrdDel_Filtro;
         AV58Core_produtowwds_2_filterfulltext = AV39FilterFullText;
         AV59Core_produtowwds_3_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV60Core_produtowwds_4_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV61Core_produtowwds_5_prdcodigo1 = AV42PrdCodigo1;
         AV62Core_produtowwds_6_prdtiponome1 = AV43PrdTipoNome1;
         AV63Core_produtowwds_7_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV64Core_produtowwds_8_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV65Core_produtowwds_9_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV66Core_produtowwds_10_prdcodigo2 = AV47PrdCodigo2;
         AV67Core_produtowwds_11_prdtiponome2 = AV48PrdTipoNome2;
         AV68Core_produtowwds_12_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV69Core_produtowwds_13_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV70Core_produtowwds_14_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV71Core_produtowwds_15_prdcodigo3 = AV52PrdCodigo3;
         AV72Core_produtowwds_16_prdtiponome3 = AV53PrdTipoNome3;
         AV73Core_produtowwds_17_tfprdcodigo = AV11TFPrdCodigo;
         AV74Core_produtowwds_18_tfprdcodigo_sel = AV12TFPrdCodigo_Sel;
         AV75Core_produtowwds_19_tfprdnome = AV13TFPrdNome;
         AV76Core_produtowwds_20_tfprdnome_sel = AV14TFPrdNome_Sel;
         AV77Core_produtowwds_21_tfprdtiposigla = AV15TFPrdTipoSigla;
         AV78Core_produtowwds_22_tfprdtiposigla_sel = AV16TFPrdTipoSigla_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV58Core_produtowwds_2_filterfulltext ,
                                              AV59Core_produtowwds_3_dynamicfiltersselector1 ,
                                              AV60Core_produtowwds_4_dynamicfiltersoperator1 ,
                                              AV61Core_produtowwds_5_prdcodigo1 ,
                                              AV62Core_produtowwds_6_prdtiponome1 ,
                                              AV63Core_produtowwds_7_dynamicfiltersenabled2 ,
                                              AV64Core_produtowwds_8_dynamicfiltersselector2 ,
                                              AV65Core_produtowwds_9_dynamicfiltersoperator2 ,
                                              AV66Core_produtowwds_10_prdcodigo2 ,
                                              AV67Core_produtowwds_11_prdtiponome2 ,
                                              AV68Core_produtowwds_12_dynamicfiltersenabled3 ,
                                              AV69Core_produtowwds_13_dynamicfiltersselector3 ,
                                              AV70Core_produtowwds_14_dynamicfiltersoperator3 ,
                                              AV71Core_produtowwds_15_prdcodigo3 ,
                                              AV72Core_produtowwds_16_prdtiponome3 ,
                                              AV74Core_produtowwds_18_tfprdcodigo_sel ,
                                              AV73Core_produtowwds_17_tfprdcodigo ,
                                              AV76Core_produtowwds_20_tfprdnome_sel ,
                                              AV75Core_produtowwds_19_tfprdnome ,
                                              AV78Core_produtowwds_22_tfprdtiposigla_sel ,
                                              AV77Core_produtowwds_21_tfprdtiposigla ,
                                              A221PrdCodigo ,
                                              A222PrdNome ,
                                              A233PrdTipoSigla ,
                                              A234PrdTipoNome ,
                                              A620PrdDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1), "%", "");
         lV61Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1), "%", "");
         lV62Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1), "%", "");
         lV62Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1), "%", "");
         lV66Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2), "%", "");
         lV66Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2), "%", "");
         lV67Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2), "%", "");
         lV67Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2), "%", "");
         lV71Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3), "%", "");
         lV71Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3), "%", "");
         lV72Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3), "%", "");
         lV72Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3), "%", "");
         lV73Core_produtowwds_17_tfprdcodigo = StringUtil.Concat( StringUtil.RTrim( AV73Core_produtowwds_17_tfprdcodigo), "%", "");
         lV75Core_produtowwds_19_tfprdnome = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_19_tfprdnome), "%", "");
         lV77Core_produtowwds_21_tfprdtiposigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_produtowwds_21_tfprdtiposigla), "%", "");
         /* Using cursor P004B3 */
         pr_default.execute(1, new Object[] {lV58Core_produtowwds_2_filterfulltext, lV58Core_produtowwds_2_filterfulltext, lV58Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_5_prdcodigo1, lV61Core_produtowwds_5_prdcodigo1, lV62Core_produtowwds_6_prdtiponome1, lV62Core_produtowwds_6_prdtiponome1, lV66Core_produtowwds_10_prdcodigo2, lV66Core_produtowwds_10_prdcodigo2, lV67Core_produtowwds_11_prdtiponome2, lV67Core_produtowwds_11_prdtiponome2, lV71Core_produtowwds_15_prdcodigo3, lV71Core_produtowwds_15_prdcodigo3, lV72Core_produtowwds_16_prdtiponome3, lV72Core_produtowwds_16_prdtiponome3, lV73Core_produtowwds_17_tfprdcodigo, AV74Core_produtowwds_18_tfprdcodigo_sel, lV75Core_produtowwds_19_tfprdnome, AV76Core_produtowwds_20_tfprdnome_sel, lV77Core_produtowwds_21_tfprdtiposigla, AV78Core_produtowwds_22_tfprdtiposigla_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4B4 = false;
            A232PrdTipoID = P004B3_A232PrdTipoID[0];
            A222PrdNome = P004B3_A222PrdNome[0];
            A234PrdTipoNome = P004B3_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004B3_A233PrdTipoSigla[0];
            A221PrdCodigo = P004B3_A221PrdCodigo[0];
            A620PrdDel = P004B3_A620PrdDel[0];
            A220PrdID = P004B3_A220PrdID[0];
            A234PrdTipoNome = P004B3_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004B3_A233PrdTipoSigla[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004B3_A222PrdNome[0], A222PrdNome) == 0 ) )
            {
               BRK4B4 = false;
               A220PrdID = P004B3_A220PrdID[0];
               AV27count = (long)(AV27count+1);
               BRK4B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A222PrdNome)) ? "<#Empty#>" : A222PrdNome);
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
            if ( ! BRK4B4 )
            {
               BRK4B4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPRDTIPOSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV15TFPrdTipoSigla = AV17SearchTxt;
         AV16TFPrdTipoSigla_Sel = "";
         AV57Core_produtowwds_1_prddel_filtro = AV54PrdDel_Filtro;
         AV58Core_produtowwds_2_filterfulltext = AV39FilterFullText;
         AV59Core_produtowwds_3_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV60Core_produtowwds_4_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV61Core_produtowwds_5_prdcodigo1 = AV42PrdCodigo1;
         AV62Core_produtowwds_6_prdtiponome1 = AV43PrdTipoNome1;
         AV63Core_produtowwds_7_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV64Core_produtowwds_8_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV65Core_produtowwds_9_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV66Core_produtowwds_10_prdcodigo2 = AV47PrdCodigo2;
         AV67Core_produtowwds_11_prdtiponome2 = AV48PrdTipoNome2;
         AV68Core_produtowwds_12_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV69Core_produtowwds_13_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV70Core_produtowwds_14_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV71Core_produtowwds_15_prdcodigo3 = AV52PrdCodigo3;
         AV72Core_produtowwds_16_prdtiponome3 = AV53PrdTipoNome3;
         AV73Core_produtowwds_17_tfprdcodigo = AV11TFPrdCodigo;
         AV74Core_produtowwds_18_tfprdcodigo_sel = AV12TFPrdCodigo_Sel;
         AV75Core_produtowwds_19_tfprdnome = AV13TFPrdNome;
         AV76Core_produtowwds_20_tfprdnome_sel = AV14TFPrdNome_Sel;
         AV77Core_produtowwds_21_tfprdtiposigla = AV15TFPrdTipoSigla;
         AV78Core_produtowwds_22_tfprdtiposigla_sel = AV16TFPrdTipoSigla_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV58Core_produtowwds_2_filterfulltext ,
                                              AV59Core_produtowwds_3_dynamicfiltersselector1 ,
                                              AV60Core_produtowwds_4_dynamicfiltersoperator1 ,
                                              AV61Core_produtowwds_5_prdcodigo1 ,
                                              AV62Core_produtowwds_6_prdtiponome1 ,
                                              AV63Core_produtowwds_7_dynamicfiltersenabled2 ,
                                              AV64Core_produtowwds_8_dynamicfiltersselector2 ,
                                              AV65Core_produtowwds_9_dynamicfiltersoperator2 ,
                                              AV66Core_produtowwds_10_prdcodigo2 ,
                                              AV67Core_produtowwds_11_prdtiponome2 ,
                                              AV68Core_produtowwds_12_dynamicfiltersenabled3 ,
                                              AV69Core_produtowwds_13_dynamicfiltersselector3 ,
                                              AV70Core_produtowwds_14_dynamicfiltersoperator3 ,
                                              AV71Core_produtowwds_15_prdcodigo3 ,
                                              AV72Core_produtowwds_16_prdtiponome3 ,
                                              AV74Core_produtowwds_18_tfprdcodigo_sel ,
                                              AV73Core_produtowwds_17_tfprdcodigo ,
                                              AV76Core_produtowwds_20_tfprdnome_sel ,
                                              AV75Core_produtowwds_19_tfprdnome ,
                                              AV78Core_produtowwds_22_tfprdtiposigla_sel ,
                                              AV77Core_produtowwds_21_tfprdtiposigla ,
                                              A221PrdCodigo ,
                                              A222PrdNome ,
                                              A233PrdTipoSigla ,
                                              A234PrdTipoNome ,
                                              A620PrdDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV58Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1), "%", "");
         lV61Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1), "%", "");
         lV62Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1), "%", "");
         lV62Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1), "%", "");
         lV66Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2), "%", "");
         lV66Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2), "%", "");
         lV67Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2), "%", "");
         lV67Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2), "%", "");
         lV71Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3), "%", "");
         lV71Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3), "%", "");
         lV72Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3), "%", "");
         lV72Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3), "%", "");
         lV73Core_produtowwds_17_tfprdcodigo = StringUtil.Concat( StringUtil.RTrim( AV73Core_produtowwds_17_tfprdcodigo), "%", "");
         lV75Core_produtowwds_19_tfprdnome = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_19_tfprdnome), "%", "");
         lV77Core_produtowwds_21_tfprdtiposigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_produtowwds_21_tfprdtiposigla), "%", "");
         /* Using cursor P004B4 */
         pr_default.execute(2, new Object[] {lV58Core_produtowwds_2_filterfulltext, lV58Core_produtowwds_2_filterfulltext, lV58Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_5_prdcodigo1, lV61Core_produtowwds_5_prdcodigo1, lV62Core_produtowwds_6_prdtiponome1, lV62Core_produtowwds_6_prdtiponome1, lV66Core_produtowwds_10_prdcodigo2, lV66Core_produtowwds_10_prdcodigo2, lV67Core_produtowwds_11_prdtiponome2, lV67Core_produtowwds_11_prdtiponome2, lV71Core_produtowwds_15_prdcodigo3, lV71Core_produtowwds_15_prdcodigo3, lV72Core_produtowwds_16_prdtiponome3, lV72Core_produtowwds_16_prdtiponome3, lV73Core_produtowwds_17_tfprdcodigo, AV74Core_produtowwds_18_tfprdcodigo_sel, lV75Core_produtowwds_19_tfprdnome, AV76Core_produtowwds_20_tfprdnome_sel, lV77Core_produtowwds_21_tfprdtiposigla, AV78Core_produtowwds_22_tfprdtiposigla_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4B6 = false;
            A232PrdTipoID = P004B4_A232PrdTipoID[0];
            A233PrdTipoSigla = P004B4_A233PrdTipoSigla[0];
            A234PrdTipoNome = P004B4_A234PrdTipoNome[0];
            A222PrdNome = P004B4_A222PrdNome[0];
            A221PrdCodigo = P004B4_A221PrdCodigo[0];
            A620PrdDel = P004B4_A620PrdDel[0];
            A220PrdID = P004B4_A220PrdID[0];
            A233PrdTipoSigla = P004B4_A233PrdTipoSigla[0];
            A234PrdTipoNome = P004B4_A234PrdTipoNome[0];
            AV27count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004B4_A233PrdTipoSigla[0], A233PrdTipoSigla) == 0 ) )
            {
               BRK4B6 = false;
               A232PrdTipoID = P004B4_A232PrdTipoID[0];
               A220PrdID = P004B4_A220PrdID[0];
               AV27count = (long)(AV27count+1);
               BRK4B6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A233PrdTipoSigla)) ? "<#Empty#>" : A233PrdTipoSigla);
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
            if ( ! BRK4B6 )
            {
               BRK4B6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV11TFPrdCodigo = "";
         AV12TFPrdCodigo_Sel = "";
         AV13TFPrdNome = "";
         AV14TFPrdNome_Sel = "";
         AV15TFPrdTipoSigla = "";
         AV16TFPrdTipoSigla_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42PrdCodigo1 = "";
         AV43PrdTipoNome1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47PrdCodigo2 = "";
         AV48PrdTipoNome2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52PrdCodigo3 = "";
         AV53PrdTipoNome3 = "";
         AV58Core_produtowwds_2_filterfulltext = "";
         AV59Core_produtowwds_3_dynamicfiltersselector1 = "";
         AV61Core_produtowwds_5_prdcodigo1 = "";
         AV62Core_produtowwds_6_prdtiponome1 = "";
         AV64Core_produtowwds_8_dynamicfiltersselector2 = "";
         AV66Core_produtowwds_10_prdcodigo2 = "";
         AV67Core_produtowwds_11_prdtiponome2 = "";
         AV69Core_produtowwds_13_dynamicfiltersselector3 = "";
         AV71Core_produtowwds_15_prdcodigo3 = "";
         AV72Core_produtowwds_16_prdtiponome3 = "";
         AV73Core_produtowwds_17_tfprdcodigo = "";
         AV74Core_produtowwds_18_tfprdcodigo_sel = "";
         AV75Core_produtowwds_19_tfprdnome = "";
         AV76Core_produtowwds_20_tfprdnome_sel = "";
         AV77Core_produtowwds_21_tfprdtiposigla = "";
         AV78Core_produtowwds_22_tfprdtiposigla_sel = "";
         scmdbuf = "";
         lV58Core_produtowwds_2_filterfulltext = "";
         lV61Core_produtowwds_5_prdcodigo1 = "";
         lV62Core_produtowwds_6_prdtiponome1 = "";
         lV66Core_produtowwds_10_prdcodigo2 = "";
         lV67Core_produtowwds_11_prdtiponome2 = "";
         lV71Core_produtowwds_15_prdcodigo3 = "";
         lV72Core_produtowwds_16_prdtiponome3 = "";
         lV73Core_produtowwds_17_tfprdcodigo = "";
         lV75Core_produtowwds_19_tfprdnome = "";
         lV77Core_produtowwds_21_tfprdtiposigla = "";
         A221PrdCodigo = "";
         A222PrdNome = "";
         A233PrdTipoSigla = "";
         A234PrdTipoNome = "";
         P004B2_A232PrdTipoID = new int[1] ;
         P004B2_A221PrdCodigo = new string[] {""} ;
         P004B2_A234PrdTipoNome = new string[] {""} ;
         P004B2_A233PrdTipoSigla = new string[] {""} ;
         P004B2_A222PrdNome = new string[] {""} ;
         P004B2_A620PrdDel = new bool[] {false} ;
         P004B2_A220PrdID = new Guid[] {Guid.Empty} ;
         A220PrdID = Guid.Empty;
         AV22Option = "";
         P004B3_A232PrdTipoID = new int[1] ;
         P004B3_A222PrdNome = new string[] {""} ;
         P004B3_A234PrdTipoNome = new string[] {""} ;
         P004B3_A233PrdTipoSigla = new string[] {""} ;
         P004B3_A221PrdCodigo = new string[] {""} ;
         P004B3_A620PrdDel = new bool[] {false} ;
         P004B3_A220PrdID = new Guid[] {Guid.Empty} ;
         P004B4_A232PrdTipoID = new int[1] ;
         P004B4_A233PrdTipoSigla = new string[] {""} ;
         P004B4_A234PrdTipoNome = new string[] {""} ;
         P004B4_A222PrdNome = new string[] {""} ;
         P004B4_A221PrdCodigo = new string[] {""} ;
         P004B4_A620PrdDel = new bool[] {false} ;
         P004B4_A220PrdID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004B2_A232PrdTipoID, P004B2_A221PrdCodigo, P004B2_A234PrdTipoNome, P004B2_A233PrdTipoSigla, P004B2_A222PrdNome, P004B2_A620PrdDel, P004B2_A220PrdID
               }
               , new Object[] {
               P004B3_A232PrdTipoID, P004B3_A222PrdNome, P004B3_A234PrdTipoNome, P004B3_A233PrdTipoSigla, P004B3_A221PrdCodigo, P004B3_A620PrdDel, P004B3_A220PrdID
               }
               , new Object[] {
               P004B4_A232PrdTipoID, P004B4_A233PrdTipoSigla, P004B4_A234PrdTipoNome, P004B4_A222PrdNome, P004B4_A221PrdCodigo, P004B4_A620PrdDel, P004B4_A220PrdID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV60Core_produtowwds_4_dynamicfiltersoperator1 ;
      private short AV65Core_produtowwds_9_dynamicfiltersoperator2 ;
      private short AV70Core_produtowwds_14_dynamicfiltersoperator3 ;
      private int AV55GXV1 ;
      private int A232PrdTipoID ;
      private long AV27count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV54PrdDel_Filtro ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV57Core_produtowwds_1_prddel_filtro ;
      private bool AV63Core_produtowwds_7_dynamicfiltersenabled2 ;
      private bool AV68Core_produtowwds_12_dynamicfiltersenabled3 ;
      private bool A620PrdDel ;
      private bool BRK4B2 ;
      private bool BRK4B4 ;
      private bool BRK4B6 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV11TFPrdCodigo ;
      private string AV12TFPrdCodigo_Sel ;
      private string AV13TFPrdNome ;
      private string AV14TFPrdNome_Sel ;
      private string AV15TFPrdTipoSigla ;
      private string AV16TFPrdTipoSigla_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV42PrdCodigo1 ;
      private string AV43PrdTipoNome1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47PrdCodigo2 ;
      private string AV48PrdTipoNome2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV52PrdCodigo3 ;
      private string AV53PrdTipoNome3 ;
      private string AV58Core_produtowwds_2_filterfulltext ;
      private string AV59Core_produtowwds_3_dynamicfiltersselector1 ;
      private string AV61Core_produtowwds_5_prdcodigo1 ;
      private string AV62Core_produtowwds_6_prdtiponome1 ;
      private string AV64Core_produtowwds_8_dynamicfiltersselector2 ;
      private string AV66Core_produtowwds_10_prdcodigo2 ;
      private string AV67Core_produtowwds_11_prdtiponome2 ;
      private string AV69Core_produtowwds_13_dynamicfiltersselector3 ;
      private string AV71Core_produtowwds_15_prdcodigo3 ;
      private string AV72Core_produtowwds_16_prdtiponome3 ;
      private string AV73Core_produtowwds_17_tfprdcodigo ;
      private string AV74Core_produtowwds_18_tfprdcodigo_sel ;
      private string AV75Core_produtowwds_19_tfprdnome ;
      private string AV76Core_produtowwds_20_tfprdnome_sel ;
      private string AV77Core_produtowwds_21_tfprdtiposigla ;
      private string AV78Core_produtowwds_22_tfprdtiposigla_sel ;
      private string lV58Core_produtowwds_2_filterfulltext ;
      private string lV61Core_produtowwds_5_prdcodigo1 ;
      private string lV62Core_produtowwds_6_prdtiponome1 ;
      private string lV66Core_produtowwds_10_prdcodigo2 ;
      private string lV67Core_produtowwds_11_prdtiponome2 ;
      private string lV71Core_produtowwds_15_prdcodigo3 ;
      private string lV72Core_produtowwds_16_prdtiponome3 ;
      private string lV73Core_produtowwds_17_tfprdcodigo ;
      private string lV75Core_produtowwds_19_tfprdnome ;
      private string lV77Core_produtowwds_21_tfprdtiposigla ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A233PrdTipoSigla ;
      private string A234PrdTipoNome ;
      private string AV22Option ;
      private Guid A220PrdID ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004B2_A232PrdTipoID ;
      private string[] P004B2_A221PrdCodigo ;
      private string[] P004B2_A234PrdTipoNome ;
      private string[] P004B2_A233PrdTipoSigla ;
      private string[] P004B2_A222PrdNome ;
      private bool[] P004B2_A620PrdDel ;
      private Guid[] P004B2_A220PrdID ;
      private int[] P004B3_A232PrdTipoID ;
      private string[] P004B3_A222PrdNome ;
      private string[] P004B3_A234PrdTipoNome ;
      private string[] P004B3_A233PrdTipoSigla ;
      private string[] P004B3_A221PrdCodigo ;
      private bool[] P004B3_A620PrdDel ;
      private Guid[] P004B3_A220PrdID ;
      private int[] P004B4_A232PrdTipoID ;
      private string[] P004B4_A233PrdTipoSigla ;
      private string[] P004B4_A234PrdTipoNome ;
      private string[] P004B4_A222PrdNome ;
      private string[] P004B4_A221PrdCodigo ;
      private bool[] P004B4_A620PrdDel ;
      private Guid[] P004B4_A220PrdID ;
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

   public class produtowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004B2( IGxContext context ,
                                             string AV58Core_produtowwds_2_filterfulltext ,
                                             string AV59Core_produtowwds_3_dynamicfiltersselector1 ,
                                             short AV60Core_produtowwds_4_dynamicfiltersoperator1 ,
                                             string AV61Core_produtowwds_5_prdcodigo1 ,
                                             string AV62Core_produtowwds_6_prdtiponome1 ,
                                             bool AV63Core_produtowwds_7_dynamicfiltersenabled2 ,
                                             string AV64Core_produtowwds_8_dynamicfiltersselector2 ,
                                             short AV65Core_produtowwds_9_dynamicfiltersoperator2 ,
                                             string AV66Core_produtowwds_10_prdcodigo2 ,
                                             string AV67Core_produtowwds_11_prdtiponome2 ,
                                             bool AV68Core_produtowwds_12_dynamicfiltersenabled3 ,
                                             string AV69Core_produtowwds_13_dynamicfiltersselector3 ,
                                             short AV70Core_produtowwds_14_dynamicfiltersoperator3 ,
                                             string AV71Core_produtowwds_15_prdcodigo3 ,
                                             string AV72Core_produtowwds_16_prdtiponome3 ,
                                             string AV74Core_produtowwds_18_tfprdcodigo_sel ,
                                             string AV73Core_produtowwds_17_tfprdcodigo ,
                                             string AV76Core_produtowwds_20_tfprdnome_sel ,
                                             string AV75Core_produtowwds_19_tfprdnome ,
                                             string AV78Core_produtowwds_22_tfprdtiposigla_sel ,
                                             string AV77Core_produtowwds_21_tfprdtiposigla ,
                                             string A221PrdCodigo ,
                                             string A222PrdNome ,
                                             string A233PrdTipoSigla ,
                                             string A234PrdTipoNome ,
                                             bool A620PrdDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[21];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.PrdTipoID AS PrdTipoID, T1.PrdCodigo, T2.PrtNome AS PrdTipoNome, T2.PrtSigla AS PrdTipoSigla, T1.PrdNome, T1.PrdDel, T1.PrdID FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID)";
         AddWhere(sWhereString, "(Not T1.PrdDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.PrdCodigo like '%' || :lV58Core_produtowwds_2_filterfulltext) or ( T1.PrdNome like '%' || :lV58Core_produtowwds_2_filterfulltext) or ( T2.PrtSigla like '%' || :lV58Core_produtowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV61Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV61Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV62Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV62Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV66Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV66Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV67Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV67Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV71Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV71Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV72Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV72Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_18_tfprdcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_produtowwds_17_tfprdcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV73Core_produtowwds_17_tfprdcodigo)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_18_tfprdcodigo_sel)) && ! ( StringUtil.StrCmp(AV74Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo = ( :AV74Core_produtowwds_18_tfprdcodigo_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_20_tfprdnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_19_tfprdnome)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome like :lV75Core_produtowwds_19_tfprdnome)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_20_tfprdnome_sel)) && ! ( StringUtil.StrCmp(AV76Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome = ( :AV76Core_produtowwds_20_tfprdnome_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_22_tfprdtiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_21_tfprdtiposigla)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla like :lV77Core_produtowwds_21_tfprdtiposigla)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_22_tfprdtiposigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla = ( :AV78Core_produtowwds_22_tfprdtiposigla_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PrtSigla))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PrdCodigo";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004B3( IGxContext context ,
                                             string AV58Core_produtowwds_2_filterfulltext ,
                                             string AV59Core_produtowwds_3_dynamicfiltersselector1 ,
                                             short AV60Core_produtowwds_4_dynamicfiltersoperator1 ,
                                             string AV61Core_produtowwds_5_prdcodigo1 ,
                                             string AV62Core_produtowwds_6_prdtiponome1 ,
                                             bool AV63Core_produtowwds_7_dynamicfiltersenabled2 ,
                                             string AV64Core_produtowwds_8_dynamicfiltersselector2 ,
                                             short AV65Core_produtowwds_9_dynamicfiltersoperator2 ,
                                             string AV66Core_produtowwds_10_prdcodigo2 ,
                                             string AV67Core_produtowwds_11_prdtiponome2 ,
                                             bool AV68Core_produtowwds_12_dynamicfiltersenabled3 ,
                                             string AV69Core_produtowwds_13_dynamicfiltersselector3 ,
                                             short AV70Core_produtowwds_14_dynamicfiltersoperator3 ,
                                             string AV71Core_produtowwds_15_prdcodigo3 ,
                                             string AV72Core_produtowwds_16_prdtiponome3 ,
                                             string AV74Core_produtowwds_18_tfprdcodigo_sel ,
                                             string AV73Core_produtowwds_17_tfprdcodigo ,
                                             string AV76Core_produtowwds_20_tfprdnome_sel ,
                                             string AV75Core_produtowwds_19_tfprdnome ,
                                             string AV78Core_produtowwds_22_tfprdtiposigla_sel ,
                                             string AV77Core_produtowwds_21_tfprdtiposigla ,
                                             string A221PrdCodigo ,
                                             string A222PrdNome ,
                                             string A233PrdTipoSigla ,
                                             string A234PrdTipoNome ,
                                             bool A620PrdDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[21];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PrdTipoID AS PrdTipoID, T1.PrdNome, T2.PrtNome AS PrdTipoNome, T2.PrtSigla AS PrdTipoSigla, T1.PrdCodigo, T1.PrdDel, T1.PrdID FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID)";
         AddWhere(sWhereString, "(Not T1.PrdDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.PrdCodigo like '%' || :lV58Core_produtowwds_2_filterfulltext) or ( T1.PrdNome like '%' || :lV58Core_produtowwds_2_filterfulltext) or ( T2.PrtSigla like '%' || :lV58Core_produtowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV61Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV61Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV62Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV62Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV66Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV66Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV67Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV67Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV71Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV71Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV72Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV72Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_18_tfprdcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_produtowwds_17_tfprdcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV73Core_produtowwds_17_tfprdcodigo)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_18_tfprdcodigo_sel)) && ! ( StringUtil.StrCmp(AV74Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo = ( :AV74Core_produtowwds_18_tfprdcodigo_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_20_tfprdnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_19_tfprdnome)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome like :lV75Core_produtowwds_19_tfprdnome)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_20_tfprdnome_sel)) && ! ( StringUtil.StrCmp(AV76Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome = ( :AV76Core_produtowwds_20_tfprdnome_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_22_tfprdtiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_21_tfprdtiposigla)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla like :lV77Core_produtowwds_21_tfprdtiposigla)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_22_tfprdtiposigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla = ( :AV78Core_produtowwds_22_tfprdtiposigla_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PrtSigla))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PrdNome";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004B4( IGxContext context ,
                                             string AV58Core_produtowwds_2_filterfulltext ,
                                             string AV59Core_produtowwds_3_dynamicfiltersselector1 ,
                                             short AV60Core_produtowwds_4_dynamicfiltersoperator1 ,
                                             string AV61Core_produtowwds_5_prdcodigo1 ,
                                             string AV62Core_produtowwds_6_prdtiponome1 ,
                                             bool AV63Core_produtowwds_7_dynamicfiltersenabled2 ,
                                             string AV64Core_produtowwds_8_dynamicfiltersselector2 ,
                                             short AV65Core_produtowwds_9_dynamicfiltersoperator2 ,
                                             string AV66Core_produtowwds_10_prdcodigo2 ,
                                             string AV67Core_produtowwds_11_prdtiponome2 ,
                                             bool AV68Core_produtowwds_12_dynamicfiltersenabled3 ,
                                             string AV69Core_produtowwds_13_dynamicfiltersselector3 ,
                                             short AV70Core_produtowwds_14_dynamicfiltersoperator3 ,
                                             string AV71Core_produtowwds_15_prdcodigo3 ,
                                             string AV72Core_produtowwds_16_prdtiponome3 ,
                                             string AV74Core_produtowwds_18_tfprdcodigo_sel ,
                                             string AV73Core_produtowwds_17_tfprdcodigo ,
                                             string AV76Core_produtowwds_20_tfprdnome_sel ,
                                             string AV75Core_produtowwds_19_tfprdnome ,
                                             string AV78Core_produtowwds_22_tfprdtiposigla_sel ,
                                             string AV77Core_produtowwds_21_tfprdtiposigla ,
                                             string A221PrdCodigo ,
                                             string A222PrdNome ,
                                             string A233PrdTipoSigla ,
                                             string A234PrdTipoNome ,
                                             bool A620PrdDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[21];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.PrdTipoID AS PrdTipoID, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, T1.PrdNome, T1.PrdCodigo, T1.PrdDel, T1.PrdID FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID)";
         AddWhere(sWhereString, "(Not T1.PrdDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_produtowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.PrdCodigo like '%' || :lV58Core_produtowwds_2_filterfulltext) or ( T1.PrdNome like '%' || :lV58Core_produtowwds_2_filterfulltext) or ( T2.PrtSigla like '%' || :lV58Core_produtowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV61Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV61Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV62Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV60Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV62Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV66Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV66Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV67Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV63Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV65Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV67Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV71Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV71Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV72Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV68Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV70Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV72Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_18_tfprdcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_produtowwds_17_tfprdcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV73Core_produtowwds_17_tfprdcodigo)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_18_tfprdcodigo_sel)) && ! ( StringUtil.StrCmp(AV74Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo = ( :AV74Core_produtowwds_18_tfprdcodigo_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_20_tfprdnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_19_tfprdnome)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome like :lV75Core_produtowwds_19_tfprdnome)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_20_tfprdnome_sel)) && ! ( StringUtil.StrCmp(AV76Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome = ( :AV76Core_produtowwds_20_tfprdnome_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_22_tfprdtiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_21_tfprdtiposigla)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla like :lV77Core_produtowwds_21_tfprdtiposigla)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_22_tfprdtiposigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla = ( :AV78Core_produtowwds_22_tfprdtiposigla_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PrtSigla))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.PrtSigla";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] );
               case 1 :
                     return conditional_P004B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] );
               case 2 :
                     return conditional_P004B4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP004B2;
          prmP004B2 = new Object[] {
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV61Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV62Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV62Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV66Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV67Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV67Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV71Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV71Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV72Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV73Core_produtowwds_17_tfprdcodigo",GXType.VarChar,30,0) ,
          new ParDef("AV74Core_produtowwds_18_tfprdcodigo_sel",GXType.VarChar,30,0) ,
          new ParDef("lV75Core_produtowwds_19_tfprdnome",GXType.VarChar,80,0) ,
          new ParDef("AV76Core_produtowwds_20_tfprdnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_produtowwds_21_tfprdtiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_produtowwds_22_tfprdtiposigla_sel",GXType.VarChar,20,0)
          };
          Object[] prmP004B3;
          prmP004B3 = new Object[] {
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV61Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV62Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV62Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV66Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV67Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV67Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV71Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV71Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV72Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV73Core_produtowwds_17_tfprdcodigo",GXType.VarChar,30,0) ,
          new ParDef("AV74Core_produtowwds_18_tfprdcodigo_sel",GXType.VarChar,30,0) ,
          new ParDef("lV75Core_produtowwds_19_tfprdnome",GXType.VarChar,80,0) ,
          new ParDef("AV76Core_produtowwds_20_tfprdnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_produtowwds_21_tfprdtiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_produtowwds_22_tfprdtiposigla_sel",GXType.VarChar,20,0)
          };
          Object[] prmP004B4;
          prmP004B4 = new Object[] {
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV61Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV62Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV62Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV66Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV67Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV67Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV71Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV71Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV72Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV73Core_produtowwds_17_tfprdcodigo",GXType.VarChar,30,0) ,
          new ParDef("AV74Core_produtowwds_18_tfprdcodigo_sel",GXType.VarChar,30,0) ,
          new ParDef("lV75Core_produtowwds_19_tfprdnome",GXType.VarChar,80,0) ,
          new ParDef("AV76Core_produtowwds_20_tfprdnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_produtowwds_21_tfprdtiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_produtowwds_22_tfprdtiposigla_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
