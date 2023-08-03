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
   public class parametroswwgetfilterdata : GXProcedure
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
            return "parametrosww_Services_Execute" ;
         }

      }

      public parametroswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametroswwgetfilterdata( IGxContext context )
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
         parametroswwgetfilterdata objparametroswwgetfilterdata;
         objparametroswwgetfilterdata = new parametroswwgetfilterdata();
         objparametroswwgetfilterdata.AV31DDOName = aP0_DDOName;
         objparametroswwgetfilterdata.AV32SearchTxtParms = aP1_SearchTxtParms;
         objparametroswwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objparametroswwgetfilterdata.AV34OptionsJson = "" ;
         objparametroswwgetfilterdata.AV35OptionsDescJson = "" ;
         objparametroswwgetfilterdata.AV36OptionIndexesJson = "" ;
         objparametroswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objparametroswwgetfilterdata.initialize();
         Submit( executePrivateCatch,objparametroswwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parametroswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PARAMETROCHAVE") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETROCHAVEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PARAMETRODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETRODESCRICAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PARAMETROVALOR") == 0 )
         {
            /* Execute user subroutine: 'LOADPARAMETROVALOROPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("core.ParametrosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ParametrosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("core.ParametrosWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARAMETRODEL_FILTRO") == 0 )
            {
               AV55ParametroDel_Filtro = BooleanUtil.Val( AV29GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARAMETROCHAVE") == 0 )
            {
               AV52ParametroChave = AV29GridStateFilterValue.gxTpr_Value;
               AV51DynamicFiltersOperatorParametroChave = AV29GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "PARAMETROVALOR") == 0 )
            {
               AV54ParametroValor = AV29GridStateFilterValue.gxTpr_Value;
               AV53DynamicFiltersOperatorParametroValor = AV29GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPARAMETROCHAVE") == 0 )
            {
               AV11TFParametroChave = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPARAMETROCHAVE_SEL") == 0 )
            {
               AV12TFParametroChave_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV49TFParametroDescricao = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV50TFParametroDescricao_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV13TFParametroValor = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV14TFParametroValor_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPARAMETROCHAVEOPTIONS' Routine */
         returnInSub = false;
         AV11TFParametroChave = AV15SearchTxt;
         AV12TFParametroChave_Sel = "";
         AV58Core_parametroswwds_1_parametrodel_filtro = AV55ParametroDel_Filtro;
         AV59Core_parametroswwds_2_filterfulltext = AV37FilterFullText;
         AV60Core_parametroswwds_3_parametrochave = AV52ParametroChave;
         AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV51DynamicFiltersOperatorParametroChave;
         AV62Core_parametroswwds_5_parametrovalor = AV54ParametroValor;
         AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV53DynamicFiltersOperatorParametroValor;
         AV64Core_parametroswwds_7_tfparametrochave = AV11TFParametroChave;
         AV65Core_parametroswwds_8_tfparametrochave_sel = AV12TFParametroChave_Sel;
         AV66Core_parametroswwds_9_tfparametrodescricao = AV49TFParametroDescricao;
         AV67Core_parametroswwds_10_tfparametrodescricao_sel = AV50TFParametroDescricao_Sel;
         AV68Core_parametroswwds_11_tfparametrovalor = AV13TFParametroValor;
         AV69Core_parametroswwds_12_tfparametrovalor_sel = AV14TFParametroValor_Sel;
         GXPagingFrom2 = AV16SkipItems;
         GXPagingTo2 = AV18MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV59Core_parametroswwds_2_filterfulltext ,
                                              AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                              AV60Core_parametroswwds_3_parametrochave ,
                                              AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                              AV62Core_parametroswwds_5_parametrovalor ,
                                              AV65Core_parametroswwds_8_tfparametrochave_sel ,
                                              AV64Core_parametroswwds_7_tfparametrochave ,
                                              AV67Core_parametroswwds_10_tfparametrodescricao_sel ,
                                              AV66Core_parametroswwds_9_tfparametrodescricao ,
                                              AV69Core_parametroswwds_12_tfparametrovalor_sel ,
                                              AV68Core_parametroswwds_11_tfparametrovalor ,
                                              A342ParametroChave ,
                                              A344ParametroDescricao ,
                                              A343ParametroValor ,
                                              A518ParametroDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV60Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave), "%", "");
         lV60Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave), "%", "");
         lV62Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor), "%", "");
         lV62Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor), "%", "");
         lV64Core_parametroswwds_7_tfparametrochave = StringUtil.Concat( StringUtil.RTrim( AV64Core_parametroswwds_7_tfparametrochave), "%", "");
         lV66Core_parametroswwds_9_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV66Core_parametroswwds_9_tfparametrodescricao), "%", "");
         lV68Core_parametroswwds_11_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV68Core_parametroswwds_11_tfparametrovalor), "%", "");
         /* Using cursor P004Z2 */
         pr_default.execute(0, new Object[] {lV59Core_parametroswwds_2_filterfulltext, lV59Core_parametroswwds_2_filterfulltext, lV59Core_parametroswwds_2_filterfulltext, lV60Core_parametroswwds_3_parametrochave, lV60Core_parametroswwds_3_parametrochave, lV62Core_parametroswwds_5_parametrovalor, lV62Core_parametroswwds_5_parametrovalor, lV64Core_parametroswwds_7_tfparametrochave, AV65Core_parametroswwds_8_tfparametrochave_sel, lV66Core_parametroswwds_9_tfparametrodescricao, AV67Core_parametroswwds_10_tfparametrodescricao_sel, lV68Core_parametroswwds_11_tfparametrovalor, AV69Core_parametroswwds_12_tfparametrovalor_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A343ParametroValor = P004Z2_A343ParametroValor[0];
            n343ParametroValor = P004Z2_n343ParametroValor[0];
            A344ParametroDescricao = P004Z2_A344ParametroDescricao[0];
            n344ParametroDescricao = P004Z2_n344ParametroDescricao[0];
            A342ParametroChave = P004Z2_A342ParametroChave[0];
            A518ParametroDel = P004Z2_A518ParametroDel[0];
            AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A342ParametroChave)) ? "<#Empty#>" : A342ParametroChave);
            AV21Options.Add(AV20Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARAMETRODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV49TFParametroDescricao = AV15SearchTxt;
         AV50TFParametroDescricao_Sel = "";
         AV58Core_parametroswwds_1_parametrodel_filtro = AV55ParametroDel_Filtro;
         AV59Core_parametroswwds_2_filterfulltext = AV37FilterFullText;
         AV60Core_parametroswwds_3_parametrochave = AV52ParametroChave;
         AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV51DynamicFiltersOperatorParametroChave;
         AV62Core_parametroswwds_5_parametrovalor = AV54ParametroValor;
         AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV53DynamicFiltersOperatorParametroValor;
         AV64Core_parametroswwds_7_tfparametrochave = AV11TFParametroChave;
         AV65Core_parametroswwds_8_tfparametrochave_sel = AV12TFParametroChave_Sel;
         AV66Core_parametroswwds_9_tfparametrodescricao = AV49TFParametroDescricao;
         AV67Core_parametroswwds_10_tfparametrodescricao_sel = AV50TFParametroDescricao_Sel;
         AV68Core_parametroswwds_11_tfparametrovalor = AV13TFParametroValor;
         AV69Core_parametroswwds_12_tfparametrovalor_sel = AV14TFParametroValor_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV59Core_parametroswwds_2_filterfulltext ,
                                              AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                              AV60Core_parametroswwds_3_parametrochave ,
                                              AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                              AV62Core_parametroswwds_5_parametrovalor ,
                                              AV65Core_parametroswwds_8_tfparametrochave_sel ,
                                              AV64Core_parametroswwds_7_tfparametrochave ,
                                              AV67Core_parametroswwds_10_tfparametrodescricao_sel ,
                                              AV66Core_parametroswwds_9_tfparametrodescricao ,
                                              AV69Core_parametroswwds_12_tfparametrovalor_sel ,
                                              AV68Core_parametroswwds_11_tfparametrovalor ,
                                              A342ParametroChave ,
                                              A344ParametroDescricao ,
                                              A343ParametroValor ,
                                              A518ParametroDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV60Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave), "%", "");
         lV60Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave), "%", "");
         lV62Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor), "%", "");
         lV62Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor), "%", "");
         lV64Core_parametroswwds_7_tfparametrochave = StringUtil.Concat( StringUtil.RTrim( AV64Core_parametroswwds_7_tfparametrochave), "%", "");
         lV66Core_parametroswwds_9_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV66Core_parametroswwds_9_tfparametrodescricao), "%", "");
         lV68Core_parametroswwds_11_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV68Core_parametroswwds_11_tfparametrovalor), "%", "");
         /* Using cursor P004Z3 */
         pr_default.execute(1, new Object[] {lV59Core_parametroswwds_2_filterfulltext, lV59Core_parametroswwds_2_filterfulltext, lV59Core_parametroswwds_2_filterfulltext, lV60Core_parametroswwds_3_parametrochave, lV60Core_parametroswwds_3_parametrochave, lV62Core_parametroswwds_5_parametrovalor, lV62Core_parametroswwds_5_parametrovalor, lV64Core_parametroswwds_7_tfparametrochave, AV65Core_parametroswwds_8_tfparametrochave_sel, lV66Core_parametroswwds_9_tfparametrodescricao, AV67Core_parametroswwds_10_tfparametrodescricao_sel, lV68Core_parametroswwds_11_tfparametrovalor, AV69Core_parametroswwds_12_tfparametrovalor_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4Z3 = false;
            A344ParametroDescricao = P004Z3_A344ParametroDescricao[0];
            n344ParametroDescricao = P004Z3_n344ParametroDescricao[0];
            A343ParametroValor = P004Z3_A343ParametroValor[0];
            n343ParametroValor = P004Z3_n343ParametroValor[0];
            A342ParametroChave = P004Z3_A342ParametroChave[0];
            A518ParametroDel = P004Z3_A518ParametroDel[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004Z3_A344ParametroDescricao[0], A344ParametroDescricao) == 0 ) )
            {
               BRK4Z3 = false;
               A342ParametroChave = P004Z3_A342ParametroChave[0];
               AV25count = (long)(AV25count+1);
               BRK4Z3 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A344ParametroDescricao)) ? "<#Empty#>" : A344ParametroDescricao);
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
            if ( ! BRK4Z3 )
            {
               BRK4Z3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPARAMETROVALOROPTIONS' Routine */
         returnInSub = false;
         AV13TFParametroValor = AV15SearchTxt;
         AV14TFParametroValor_Sel = "";
         AV58Core_parametroswwds_1_parametrodel_filtro = AV55ParametroDel_Filtro;
         AV59Core_parametroswwds_2_filterfulltext = AV37FilterFullText;
         AV60Core_parametroswwds_3_parametrochave = AV52ParametroChave;
         AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV51DynamicFiltersOperatorParametroChave;
         AV62Core_parametroswwds_5_parametrovalor = AV54ParametroValor;
         AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV53DynamicFiltersOperatorParametroValor;
         AV64Core_parametroswwds_7_tfparametrochave = AV11TFParametroChave;
         AV65Core_parametroswwds_8_tfparametrochave_sel = AV12TFParametroChave_Sel;
         AV66Core_parametroswwds_9_tfparametrodescricao = AV49TFParametroDescricao;
         AV67Core_parametroswwds_10_tfparametrodescricao_sel = AV50TFParametroDescricao_Sel;
         AV68Core_parametroswwds_11_tfparametrovalor = AV13TFParametroValor;
         AV69Core_parametroswwds_12_tfparametrovalor_sel = AV14TFParametroValor_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV59Core_parametroswwds_2_filterfulltext ,
                                              AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                              AV60Core_parametroswwds_3_parametrochave ,
                                              AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                              AV62Core_parametroswwds_5_parametrovalor ,
                                              AV65Core_parametroswwds_8_tfparametrochave_sel ,
                                              AV64Core_parametroswwds_7_tfparametrochave ,
                                              AV67Core_parametroswwds_10_tfparametrodescricao_sel ,
                                              AV66Core_parametroswwds_9_tfparametrodescricao ,
                                              AV69Core_parametroswwds_12_tfparametrovalor_sel ,
                                              AV68Core_parametroswwds_11_tfparametrovalor ,
                                              A342ParametroChave ,
                                              A344ParametroDescricao ,
                                              A343ParametroValor ,
                                              A518ParametroDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV59Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext), "%", "");
         lV60Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave), "%", "");
         lV60Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave), "%", "");
         lV62Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor), "%", "");
         lV62Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor), "%", "");
         lV64Core_parametroswwds_7_tfparametrochave = StringUtil.Concat( StringUtil.RTrim( AV64Core_parametroswwds_7_tfparametrochave), "%", "");
         lV66Core_parametroswwds_9_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV66Core_parametroswwds_9_tfparametrodescricao), "%", "");
         lV68Core_parametroswwds_11_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV68Core_parametroswwds_11_tfparametrovalor), "%", "");
         /* Using cursor P004Z4 */
         pr_default.execute(2, new Object[] {lV59Core_parametroswwds_2_filterfulltext, lV59Core_parametroswwds_2_filterfulltext, lV59Core_parametroswwds_2_filterfulltext, lV60Core_parametroswwds_3_parametrochave, lV60Core_parametroswwds_3_parametrochave, lV62Core_parametroswwds_5_parametrovalor, lV62Core_parametroswwds_5_parametrovalor, lV64Core_parametroswwds_7_tfparametrochave, AV65Core_parametroswwds_8_tfparametrochave_sel, lV66Core_parametroswwds_9_tfparametrodescricao, AV67Core_parametroswwds_10_tfparametrodescricao_sel, lV68Core_parametroswwds_11_tfparametrovalor, AV69Core_parametroswwds_12_tfparametrovalor_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4Z5 = false;
            A343ParametroValor = P004Z4_A343ParametroValor[0];
            n343ParametroValor = P004Z4_n343ParametroValor[0];
            A344ParametroDescricao = P004Z4_A344ParametroDescricao[0];
            n344ParametroDescricao = P004Z4_n344ParametroDescricao[0];
            A342ParametroChave = P004Z4_A342ParametroChave[0];
            A518ParametroDel = P004Z4_A518ParametroDel[0];
            AV25count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004Z4_A343ParametroValor[0], A343ParametroValor) == 0 ) )
            {
               BRK4Z5 = false;
               A342ParametroChave = P004Z4_A342ParametroChave[0];
               AV25count = (long)(AV25count+1);
               BRK4Z5 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A343ParametroValor)) ? "<#Empty#>" : A343ParametroValor);
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
            if ( ! BRK4Z5 )
            {
               BRK4Z5 = true;
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
         AV52ParametroChave = "";
         AV54ParametroValor = "";
         AV11TFParametroChave = "";
         AV12TFParametroChave_Sel = "";
         AV49TFParametroDescricao = "";
         AV50TFParametroDescricao_Sel = "";
         AV13TFParametroValor = "";
         AV14TFParametroValor_Sel = "";
         AV59Core_parametroswwds_2_filterfulltext = "";
         AV60Core_parametroswwds_3_parametrochave = "";
         AV62Core_parametroswwds_5_parametrovalor = "";
         AV64Core_parametroswwds_7_tfparametrochave = "";
         AV65Core_parametroswwds_8_tfparametrochave_sel = "";
         AV66Core_parametroswwds_9_tfparametrodescricao = "";
         AV67Core_parametroswwds_10_tfparametrodescricao_sel = "";
         AV68Core_parametroswwds_11_tfparametrovalor = "";
         AV69Core_parametroswwds_12_tfparametrovalor_sel = "";
         scmdbuf = "";
         lV59Core_parametroswwds_2_filterfulltext = "";
         lV60Core_parametroswwds_3_parametrochave = "";
         lV62Core_parametroswwds_5_parametrovalor = "";
         lV64Core_parametroswwds_7_tfparametrochave = "";
         lV66Core_parametroswwds_9_tfparametrodescricao = "";
         lV68Core_parametroswwds_11_tfparametrovalor = "";
         A342ParametroChave = "";
         A344ParametroDescricao = "";
         A343ParametroValor = "";
         P004Z2_A343ParametroValor = new string[] {""} ;
         P004Z2_n343ParametroValor = new bool[] {false} ;
         P004Z2_A344ParametroDescricao = new string[] {""} ;
         P004Z2_n344ParametroDescricao = new bool[] {false} ;
         P004Z2_A342ParametroChave = new string[] {""} ;
         P004Z2_A518ParametroDel = new bool[] {false} ;
         AV20Option = "";
         P004Z3_A344ParametroDescricao = new string[] {""} ;
         P004Z3_n344ParametroDescricao = new bool[] {false} ;
         P004Z3_A343ParametroValor = new string[] {""} ;
         P004Z3_n343ParametroValor = new bool[] {false} ;
         P004Z3_A342ParametroChave = new string[] {""} ;
         P004Z3_A518ParametroDel = new bool[] {false} ;
         P004Z4_A343ParametroValor = new string[] {""} ;
         P004Z4_n343ParametroValor = new bool[] {false} ;
         P004Z4_A344ParametroDescricao = new string[] {""} ;
         P004Z4_n344ParametroDescricao = new bool[] {false} ;
         P004Z4_A342ParametroChave = new string[] {""} ;
         P004Z4_A518ParametroDel = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.parametroswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004Z2_A343ParametroValor, P004Z2_n343ParametroValor, P004Z2_A344ParametroDescricao, P004Z2_n344ParametroDescricao, P004Z2_A342ParametroChave, P004Z2_A518ParametroDel
               }
               , new Object[] {
               P004Z3_A344ParametroDescricao, P004Z3_n344ParametroDescricao, P004Z3_A343ParametroValor, P004Z3_n343ParametroValor, P004Z3_A342ParametroChave, P004Z3_A518ParametroDel
               }
               , new Object[] {
               P004Z4_A343ParametroValor, P004Z4_n343ParametroValor, P004Z4_A344ParametroDescricao, P004Z4_n344ParametroDescricao, P004Z4_A342ParametroChave, P004Z4_A518ParametroDel
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV51DynamicFiltersOperatorParametroChave ;
      private short AV53DynamicFiltersOperatorParametroValor ;
      private short AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ;
      private short AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ;
      private int AV56GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV25count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV55ParametroDel_Filtro ;
      private bool AV58Core_parametroswwds_1_parametrodel_filtro ;
      private bool A518ParametroDel ;
      private bool n343ParametroValor ;
      private bool n344ParametroDescricao ;
      private bool BRK4Z3 ;
      private bool BRK4Z5 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV52ParametroChave ;
      private string AV54ParametroValor ;
      private string AV11TFParametroChave ;
      private string AV12TFParametroChave_Sel ;
      private string AV49TFParametroDescricao ;
      private string AV50TFParametroDescricao_Sel ;
      private string AV13TFParametroValor ;
      private string AV14TFParametroValor_Sel ;
      private string AV59Core_parametroswwds_2_filterfulltext ;
      private string AV60Core_parametroswwds_3_parametrochave ;
      private string AV62Core_parametroswwds_5_parametrovalor ;
      private string AV64Core_parametroswwds_7_tfparametrochave ;
      private string AV65Core_parametroswwds_8_tfparametrochave_sel ;
      private string AV66Core_parametroswwds_9_tfparametrodescricao ;
      private string AV67Core_parametroswwds_10_tfparametrodescricao_sel ;
      private string AV68Core_parametroswwds_11_tfparametrovalor ;
      private string AV69Core_parametroswwds_12_tfparametrovalor_sel ;
      private string lV59Core_parametroswwds_2_filterfulltext ;
      private string lV60Core_parametroswwds_3_parametrochave ;
      private string lV62Core_parametroswwds_5_parametrovalor ;
      private string lV64Core_parametroswwds_7_tfparametrochave ;
      private string lV66Core_parametroswwds_9_tfparametrodescricao ;
      private string lV68Core_parametroswwds_11_tfparametrovalor ;
      private string A342ParametroChave ;
      private string A344ParametroDescricao ;
      private string A343ParametroValor ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004Z2_A343ParametroValor ;
      private bool[] P004Z2_n343ParametroValor ;
      private string[] P004Z2_A344ParametroDescricao ;
      private bool[] P004Z2_n344ParametroDescricao ;
      private string[] P004Z2_A342ParametroChave ;
      private bool[] P004Z2_A518ParametroDel ;
      private string[] P004Z3_A344ParametroDescricao ;
      private bool[] P004Z3_n344ParametroDescricao ;
      private string[] P004Z3_A343ParametroValor ;
      private bool[] P004Z3_n343ParametroValor ;
      private string[] P004Z3_A342ParametroChave ;
      private bool[] P004Z3_A518ParametroDel ;
      private string[] P004Z4_A343ParametroValor ;
      private bool[] P004Z4_n343ParametroValor ;
      private string[] P004Z4_A344ParametroDescricao ;
      private bool[] P004Z4_n344ParametroDescricao ;
      private string[] P004Z4_A342ParametroChave ;
      private bool[] P004Z4_A518ParametroDel ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class parametroswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Z2( IGxContext context ,
                                             string AV59Core_parametroswwds_2_filterfulltext ,
                                             short AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                             string AV60Core_parametroswwds_3_parametrochave ,
                                             short AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                             string AV62Core_parametroswwds_5_parametrovalor ,
                                             string AV65Core_parametroswwds_8_tfparametrochave_sel ,
                                             string AV64Core_parametroswwds_7_tfparametrochave ,
                                             string AV67Core_parametroswwds_10_tfparametrodescricao_sel ,
                                             string AV66Core_parametroswwds_9_tfparametrodescricao ,
                                             string AV69Core_parametroswwds_12_tfparametrovalor_sel ,
                                             string AV68Core_parametroswwds_11_tfparametrovalor ,
                                             string A342ParametroChave ,
                                             string A344ParametroDescricao ,
                                             string A343ParametroValor ,
                                             bool A518ParametroDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS ParametroValor, NULL AS ParametroDescricao, ParametroChave, NULL AS ParametroDel FROM ( SELECT ParametroValor, ParametroDescricao, ParametroChave, ParametroDel";
         sFromString = " FROM tb_parametro";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY ParametroChave";
         AddWhere(sWhereString, "(Not ParametroDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ParametroChave like '%' || :lV59Core_parametroswwds_2_filterfulltext) or ( ParametroDescricao like '%' || :lV59Core_parametroswwds_2_filterfulltext) or ( ParametroValor like '%' || :lV59Core_parametroswwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV60Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like '%' || :lV60Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV62Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like '%' || :lV62Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_8_tfparametrochave_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_parametroswwds_7_tfparametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV64Core_parametroswwds_7_tfparametrochave)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_8_tfparametrochave_sel)) && ! ( StringUtil.StrCmp(AV65Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV65Core_parametroswwds_8_tfparametrochave_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV65Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ParametroChave))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_10_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_parametroswwds_9_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao like :lV66Core_parametroswwds_9_tfparametrodescricao)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_10_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV67Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao = ( :AV67Core_parametroswwds_10_tfparametrodescricao_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroDescricao IS NULL or (char_length(trim(trailing ' ' from ParametroDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_12_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_parametroswwds_11_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV68Core_parametroswwds_11_tfparametrovalor)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_12_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV69Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroValor = ( :AV69Core_parametroswwds_12_tfparametrovalor_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroValor IS NULL or (char_length(trim(trailing ' ' from ParametroValor))=0))");
         }
         sOrderString += " ORDER BY ParametroChave";
         sOrderStringT = " ORDER BY ParametroChave";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004Z3( IGxContext context ,
                                             string AV59Core_parametroswwds_2_filterfulltext ,
                                             short AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                             string AV60Core_parametroswwds_3_parametrochave ,
                                             short AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                             string AV62Core_parametroswwds_5_parametrovalor ,
                                             string AV65Core_parametroswwds_8_tfparametrochave_sel ,
                                             string AV64Core_parametroswwds_7_tfparametrochave ,
                                             string AV67Core_parametroswwds_10_tfparametrodescricao_sel ,
                                             string AV66Core_parametroswwds_9_tfparametrodescricao ,
                                             string AV69Core_parametroswwds_12_tfparametrovalor_sel ,
                                             string AV68Core_parametroswwds_11_tfparametrovalor ,
                                             string A342ParametroChave ,
                                             string A344ParametroDescricao ,
                                             string A343ParametroValor ,
                                             bool A518ParametroDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ParametroDescricao, ParametroValor, ParametroChave, ParametroDel FROM tb_parametro";
         AddWhere(sWhereString, "(Not ParametroDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ParametroChave like '%' || :lV59Core_parametroswwds_2_filterfulltext) or ( ParametroDescricao like '%' || :lV59Core_parametroswwds_2_filterfulltext) or ( ParametroValor like '%' || :lV59Core_parametroswwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV60Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like '%' || :lV60Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV62Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like '%' || :lV62Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_8_tfparametrochave_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_parametroswwds_7_tfparametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV64Core_parametroswwds_7_tfparametrochave)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_8_tfparametrochave_sel)) && ! ( StringUtil.StrCmp(AV65Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV65Core_parametroswwds_8_tfparametrochave_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV65Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ParametroChave))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_10_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_parametroswwds_9_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao like :lV66Core_parametroswwds_9_tfparametrodescricao)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_10_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV67Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao = ( :AV67Core_parametroswwds_10_tfparametrodescricao_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroDescricao IS NULL or (char_length(trim(trailing ' ' from ParametroDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_12_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_parametroswwds_11_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV68Core_parametroswwds_11_tfparametrovalor)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_12_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV69Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroValor = ( :AV69Core_parametroswwds_12_tfparametrovalor_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroValor IS NULL or (char_length(trim(trailing ' ' from ParametroValor))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ParametroDescricao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004Z4( IGxContext context ,
                                             string AV59Core_parametroswwds_2_filterfulltext ,
                                             short AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                             string AV60Core_parametroswwds_3_parametrochave ,
                                             short AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                             string AV62Core_parametroswwds_5_parametrovalor ,
                                             string AV65Core_parametroswwds_8_tfparametrochave_sel ,
                                             string AV64Core_parametroswwds_7_tfparametrochave ,
                                             string AV67Core_parametroswwds_10_tfparametrodescricao_sel ,
                                             string AV66Core_parametroswwds_9_tfparametrodescricao ,
                                             string AV69Core_parametroswwds_12_tfparametrovalor_sel ,
                                             string AV68Core_parametroswwds_11_tfparametrovalor ,
                                             string A342ParametroChave ,
                                             string A344ParametroDescricao ,
                                             string A343ParametroValor ,
                                             bool A518ParametroDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT ParametroValor, ParametroDescricao, ParametroChave, ParametroDel FROM tb_parametro";
         AddWhere(sWhereString, "(Not ParametroDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_parametroswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ParametroChave like '%' || :lV59Core_parametroswwds_2_filterfulltext) or ( ParametroDescricao like '%' || :lV59Core_parametroswwds_2_filterfulltext) or ( ParametroValor like '%' || :lV59Core_parametroswwds_2_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV60Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( AV61Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like '%' || :lV60Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV62Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( AV63Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like '%' || :lV62Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_8_tfparametrochave_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_parametroswwds_7_tfparametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV64Core_parametroswwds_7_tfparametrochave)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_8_tfparametrochave_sel)) && ! ( StringUtil.StrCmp(AV65Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV65Core_parametroswwds_8_tfparametrochave_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV65Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ParametroChave))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_10_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_parametroswwds_9_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao like :lV66Core_parametroswwds_9_tfparametrodescricao)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_10_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV67Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao = ( :AV67Core_parametroswwds_10_tfparametrodescricao_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroDescricao IS NULL or (char_length(trim(trailing ' ' from ParametroDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_12_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_parametroswwds_11_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV68Core_parametroswwds_11_tfparametrovalor)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_12_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV69Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroValor = ( :AV69Core_parametroswwds_12_tfparametrovalor_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroValor IS NULL or (char_length(trim(trailing ' ' from ParametroValor))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ParametroValor";
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
                     return conditional_P004Z2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_P004Z3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
               case 2 :
                     return conditional_P004Z4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP004Z2;
          prmP004Z2 = new Object[] {
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV62Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV62Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV64Core_parametroswwds_7_tfparametrochave",GXType.VarChar,100,0) ,
          new ParDef("AV65Core_parametroswwds_8_tfparametrochave_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_parametroswwds_9_tfparametrodescricao",GXType.VarChar,500,0) ,
          new ParDef("AV67Core_parametroswwds_10_tfparametrodescricao_sel",GXType.VarChar,500,0) ,
          new ParDef("lV68Core_parametroswwds_11_tfparametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("AV69Core_parametroswwds_12_tfparametrovalor_sel",GXType.VarChar,2000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP004Z3;
          prmP004Z3 = new Object[] {
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV62Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV62Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV64Core_parametroswwds_7_tfparametrochave",GXType.VarChar,100,0) ,
          new ParDef("AV65Core_parametroswwds_8_tfparametrochave_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_parametroswwds_9_tfparametrodescricao",GXType.VarChar,500,0) ,
          new ParDef("AV67Core_parametroswwds_10_tfparametrodescricao_sel",GXType.VarChar,500,0) ,
          new ParDef("lV68Core_parametroswwds_11_tfparametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("AV69Core_parametroswwds_12_tfparametrovalor_sel",GXType.VarChar,2000,0)
          };
          Object[] prmP004Z4;
          prmP004Z4 = new Object[] {
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV62Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV62Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV64Core_parametroswwds_7_tfparametrochave",GXType.VarChar,100,0) ,
          new ParDef("AV65Core_parametroswwds_8_tfparametrochave_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_parametroswwds_9_tfparametrodescricao",GXType.VarChar,500,0) ,
          new ParDef("AV67Core_parametroswwds_10_tfparametrodescricao_sel",GXType.VarChar,500,0) ,
          new ParDef("lV68Core_parametroswwds_11_tfparametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("AV69Core_parametroswwds_12_tfparametrovalor_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Z2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Z3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004Z4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Z4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                return;
       }
    }

 }

}
