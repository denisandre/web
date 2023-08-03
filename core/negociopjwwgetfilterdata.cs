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
   public class negociopjwwgetfilterdata : GXProcedure
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
            return "negociopjww_Services_Execute" ;
         }

      }

      public negociopjwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjwwgetfilterdata( IGxContext context )
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
         this.AV59DDOName = aP0_DDOName;
         this.AV60SearchTxtParms = aP1_SearchTxtParms;
         this.AV61SearchTxtTo = aP2_SearchTxtTo;
         this.AV62OptionsJson = "" ;
         this.AV63OptionsDescJson = "" ;
         this.AV64OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV62OptionsJson;
         aP4_OptionsDescJson=this.AV63OptionsDescJson;
         aP5_OptionIndexesJson=this.AV64OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV64OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         negociopjwwgetfilterdata objnegociopjwwgetfilterdata;
         objnegociopjwwgetfilterdata = new negociopjwwgetfilterdata();
         objnegociopjwwgetfilterdata.AV59DDOName = aP0_DDOName;
         objnegociopjwwgetfilterdata.AV60SearchTxtParms = aP1_SearchTxtParms;
         objnegociopjwwgetfilterdata.AV61SearchTxtTo = aP2_SearchTxtTo;
         objnegociopjwwgetfilterdata.AV62OptionsJson = "" ;
         objnegociopjwwgetfilterdata.AV63OptionsDescJson = "" ;
         objnegociopjwwgetfilterdata.AV64OptionIndexesJson = "" ;
         objnegociopjwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objnegociopjwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objnegociopjwwgetfilterdata);
         aP3_OptionsJson=this.AV62OptionsJson;
         aP4_OptionsDescJson=this.AV63OptionsDescJson;
         aP5_OptionIndexesJson=this.AV64OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((negociopjwwgetfilterdata)stateInfo).executePrivate();
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
         AV49Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV51OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV52OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV46MaxItems = 10;
         AV45PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV60SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV60SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV43SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV60SearchTxtParms)) ? "" : StringUtil.Substring( AV60SearchTxtParms, 3, -1));
         AV44SkipItems = (short)(AV45PageIndex*AV46MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV59DDOName), "DDO_NEGASSUNTO") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGASSUNTOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV59DDOName), "DDO_NEGCLINOMEFAMILIAR") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGCLINOMEFAMILIAROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV59DDOName), "DDO_NEGCPJNOMFAN") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGCPJNOMFANOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV59DDOName), "DDO_NEGPJTNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGPJTNOMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV59DDOName), "DDO_NEGAGCNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGAGCNOMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV59DDOName), "DDO_NEGINSUSUNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGINSUSUNOMEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV62OptionsJson = AV49Options.ToJSonString(false);
         AV63OptionsDescJson = AV51OptionsDesc.ToJSonString(false);
         AV64OptionIndexesJson = AV52OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV54Session.Get("core.NegocioPJWWGridState"), "") == 0 )
         {
            AV56GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.NegocioPJWWGridState"), null, "", "");
         }
         else
         {
            AV56GridState.FromXml(AV54Session.Get("core.NegocioPJWWGridState"), null, "", "");
         }
         AV82GXV1 = 1;
         while ( AV82GXV1 <= AV56GridState.gxTpr_Filtervalues.Count )
         {
            AV57GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV56GridState.gxTpr_Filtervalues.Item(AV82GXV1));
            if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "NEGDEL") == 0 )
            {
               AV81NegDel = BooleanUtil.Val( AV57GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV65FilterFullText = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGCODIGO") == 0 )
            {
               AV11TFNegCodigo = (long)(Math.Round(NumberUtil.Val( AV57GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( AV57GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO") == 0 )
            {
               AV41TFNegAssunto = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO_SEL") == 0 )
            {
               AV42TFNegAssunto_Sel = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR") == 0 )
            {
               AV23TFNegCliNomeFamiliar = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV24TFNegCliNomeFamiliar_Sel = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN") == 0 )
            {
               AV25TFNegCpjNomFan = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN_SEL") == 0 )
            {
               AV26TFNegCpjNomFan_Sel = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGCPJMATRICULA") == 0 )
            {
               AV29TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV57GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV30TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV57GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME") == 0 )
            {
               AV35TFNegPjtNome = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME_SEL") == 0 )
            {
               AV36TFNegPjtNome_Sel = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME") == 0 )
            {
               AV39TFNegAgcNome = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME_SEL") == 0 )
            {
               AV40TFNegAgcNome_Sel = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGVALORATUALIZADO") == 0 )
            {
               AV79TFNegValorAtualizado = NumberUtil.Val( AV57GridStateFilterValue.gxTpr_Value, ".");
               AV80TFNegValorAtualizado_To = NumberUtil.Val( AV57GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGINSDATA") == 0 )
            {
               AV13TFNegInsData = context.localUtil.CToD( AV57GridStateFilterValue.gxTpr_Value, 2);
               AV14TFNegInsData_To = context.localUtil.CToD( AV57GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME") == 0 )
            {
               AV77TFNegInsUsuNome = AV57GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV57GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME_SEL") == 0 )
            {
               AV78TFNegInsUsuNome_Sel = AV57GridStateFilterValue.gxTpr_Value;
            }
            AV82GXV1 = (int)(AV82GXV1+1);
         }
         if ( AV56GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV58GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV56GridState.gxTpr_Dynamicfilters.Item(1));
            AV66DynamicFiltersSelector1 = AV58GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV66DynamicFiltersSelector1, "NEGASSUNTO") == 0 )
            {
               AV67DynamicFiltersOperator1 = AV58GridStateDynamicFilter.gxTpr_Operator;
               AV68NegAssunto1 = AV58GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV56GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV69DynamicFiltersEnabled2 = true;
               AV58GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV56GridState.gxTpr_Dynamicfilters.Item(2));
               AV70DynamicFiltersSelector2 = AV58GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV70DynamicFiltersSelector2, "NEGASSUNTO") == 0 )
               {
                  AV71DynamicFiltersOperator2 = AV58GridStateDynamicFilter.gxTpr_Operator;
                  AV72NegAssunto2 = AV58GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV56GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV73DynamicFiltersEnabled3 = true;
                  AV58GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV56GridState.gxTpr_Dynamicfilters.Item(3));
                  AV74DynamicFiltersSelector3 = AV58GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV74DynamicFiltersSelector3, "NEGASSUNTO") == 0 )
                  {
                     AV75DynamicFiltersOperator3 = AV58GridStateDynamicFilter.gxTpr_Operator;
                     AV76NegAssunto3 = AV58GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADNEGASSUNTOOPTIONS' Routine */
         returnInSub = false;
         AV41TFNegAssunto = AV43SearchTxt;
         AV42TFNegAssunto_Sel = "";
         AV84Core_negociopjwwds_1_negdel = AV81NegDel;
         AV85Core_negociopjwwds_2_filterfulltext = AV65FilterFullText;
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = AV66DynamicFiltersSelector1;
         AV87Core_negociopjwwds_4_dynamicfiltersoperator1 = AV67DynamicFiltersOperator1;
         AV88Core_negociopjwwds_5_negassunto1 = AV68NegAssunto1;
         AV89Core_negociopjwwds_6_dynamicfiltersenabled2 = AV69DynamicFiltersEnabled2;
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = AV70DynamicFiltersSelector2;
         AV91Core_negociopjwwds_8_dynamicfiltersoperator2 = AV71DynamicFiltersOperator2;
         AV92Core_negociopjwwds_9_negassunto2 = AV72NegAssunto2;
         AV93Core_negociopjwwds_10_dynamicfiltersenabled3 = AV73DynamicFiltersEnabled3;
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = AV74DynamicFiltersSelector3;
         AV95Core_negociopjwwds_12_dynamicfiltersoperator3 = AV75DynamicFiltersOperator3;
         AV96Core_negociopjwwds_13_negassunto3 = AV76NegAssunto3;
         AV97Core_negociopjwwds_14_tfnegcodigo = AV11TFNegCodigo;
         AV98Core_negociopjwwds_15_tfnegcodigo_to = AV12TFNegCodigo_To;
         AV99Core_negociopjwwds_16_tfnegassunto = AV41TFNegAssunto;
         AV100Core_negociopjwwds_17_tfnegassunto_sel = AV42TFNegAssunto_Sel;
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = AV23TFNegCliNomeFamiliar;
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV24TFNegCliNomeFamiliar_Sel;
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = AV25TFNegCpjNomFan;
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV26TFNegCpjNomFan_Sel;
         AV105Core_negociopjwwds_22_tfnegcpjmatricula = AV29TFNegCpjMatricula;
         AV106Core_negociopjwwds_23_tfnegcpjmatricula_to = AV30TFNegCpjMatricula_To;
         AV107Core_negociopjwwds_24_tfnegpjtnome = AV35TFNegPjtNome;
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = AV36TFNegPjtNome_Sel;
         AV109Core_negociopjwwds_26_tfnegagcnome = AV39TFNegAgcNome;
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = AV40TFNegAgcNome_Sel;
         AV111Core_negociopjwwds_28_tfnegvaloratualizado = AV79TFNegValorAtualizado;
         AV112Core_negociopjwwds_29_tfnegvaloratualizado_to = AV80TFNegValorAtualizado_To;
         AV113Core_negociopjwwds_30_tfneginsdata = AV13TFNegInsData;
         AV114Core_negociopjwwds_31_tfneginsdata_to = AV14TFNegInsData_To;
         AV115Core_negociopjwwds_32_tfneginsusunome = AV77TFNegInsUsuNome;
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = AV78TFNegInsUsuNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV85Core_negociopjwwds_2_filterfulltext ,
                                              AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV88Core_negociopjwwds_5_negassunto1 ,
                                              AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV92Core_negociopjwwds_9_negassunto2 ,
                                              AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV96Core_negociopjwwds_13_negassunto3 ,
                                              AV97Core_negociopjwwds_14_tfnegcodigo ,
                                              AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV99Core_negociopjwwds_16_tfnegassunto ,
                                              AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV109Core_negociopjwwds_26_tfnegagcnome ,
                                              AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV113Core_negociopjwwds_30_tfneginsdata ,
                                              AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV115Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV107Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV109Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV115Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00522 */
         pr_default.execute(0, new Object[] {lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_5_negassunto1, lV88Core_negociopjwwds_5_negassunto1, lV92Core_negociopjwwds_9_negassunto2, lV92Core_negociopjwwds_9_negassunto2, lV96Core_negociopjwwds_13_negassunto3, lV96Core_negociopjwwds_13_negassunto3, AV97Core_negociopjwwds_14_tfnegcodigo, AV98Core_negociopjwwds_15_tfnegcodigo_to, lV99Core_negociopjwwds_16_tfnegassunto, AV100Core_negociopjwwds_17_tfnegassunto_sel, lV101Core_negociopjwwds_18_tfnegclinomefamiliar, AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV103Core_negociopjwwds_20_tfnegcpjnomfan, AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV105Core_negociopjwwds_22_tfnegcpjmatricula, AV106Core_negociopjwwds_23_tfnegcpjmatricula_to, lV107Core_negociopjwwds_24_tfnegpjtnome, AV108Core_negociopjwwds_25_tfnegpjtnome_sel, lV109Core_negociopjwwds_26_tfnegagcnome, AV110Core_negociopjwwds_27_tfnegagcnome_sel, AV111Core_negociopjwwds_28_tfnegvaloratualizado, AV112Core_negociopjwwds_29_tfnegvaloratualizado_to, AV113Core_negociopjwwds_30_tfneginsdata, AV114Core_negociopjwwds_31_tfneginsdata_to, lV115Core_negociopjwwds_32_tfneginsusunome, AV116Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK522 = false;
            A350NegCliID = P00522_A350NegCliID[0];
            A352NegCpjID = P00522_A352NegCpjID[0];
            A362NegAssunto = P00522_A362NegAssunto[0];
            A346NegInsData = P00522_A346NegInsData[0];
            A385NegValorAtualizado = P00522_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00522_A355NegCpjMatricula[0];
            A356NegCodigo = P00522_A356NegCodigo[0];
            A364NegInsUsuNome = P00522_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00522_n364NegInsUsuNome[0];
            A361NegAgcNome = P00522_A361NegAgcNome[0];
            n361NegAgcNome = P00522_n361NegAgcNome[0];
            A359NegPjtNome = P00522_A359NegPjtNome[0];
            A353NegCpjNomFan = P00522_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00522_A351NegCliNomeFamiliar[0];
            A572NegDel = P00522_A572NegDel[0];
            A345NegID = P00522_A345NegID[0];
            A355NegCpjMatricula = P00522_A355NegCpjMatricula[0];
            AV53count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00522_A362NegAssunto[0], A362NegAssunto) == 0 ) )
            {
               BRK522 = false;
               A345NegID = P00522_A345NegID[0];
               AV53count = (long)(AV53count+1);
               BRK522 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV44SkipItems) )
            {
               AV48Option = (String.IsNullOrEmpty(StringUtil.RTrim( A362NegAssunto)) ? "<#Empty#>" : A362NegAssunto);
               AV50OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")));
               AV49Options.Add(AV48Option, 0);
               AV51OptionsDesc.Add(AV50OptionDesc, 0);
               AV52OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV53count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV49Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK522 )
            {
               BRK522 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADNEGCLINOMEFAMILIAROPTIONS' Routine */
         returnInSub = false;
         AV23TFNegCliNomeFamiliar = AV43SearchTxt;
         AV24TFNegCliNomeFamiliar_Sel = "";
         AV84Core_negociopjwwds_1_negdel = AV81NegDel;
         AV85Core_negociopjwwds_2_filterfulltext = AV65FilterFullText;
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = AV66DynamicFiltersSelector1;
         AV87Core_negociopjwwds_4_dynamicfiltersoperator1 = AV67DynamicFiltersOperator1;
         AV88Core_negociopjwwds_5_negassunto1 = AV68NegAssunto1;
         AV89Core_negociopjwwds_6_dynamicfiltersenabled2 = AV69DynamicFiltersEnabled2;
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = AV70DynamicFiltersSelector2;
         AV91Core_negociopjwwds_8_dynamicfiltersoperator2 = AV71DynamicFiltersOperator2;
         AV92Core_negociopjwwds_9_negassunto2 = AV72NegAssunto2;
         AV93Core_negociopjwwds_10_dynamicfiltersenabled3 = AV73DynamicFiltersEnabled3;
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = AV74DynamicFiltersSelector3;
         AV95Core_negociopjwwds_12_dynamicfiltersoperator3 = AV75DynamicFiltersOperator3;
         AV96Core_negociopjwwds_13_negassunto3 = AV76NegAssunto3;
         AV97Core_negociopjwwds_14_tfnegcodigo = AV11TFNegCodigo;
         AV98Core_negociopjwwds_15_tfnegcodigo_to = AV12TFNegCodigo_To;
         AV99Core_negociopjwwds_16_tfnegassunto = AV41TFNegAssunto;
         AV100Core_negociopjwwds_17_tfnegassunto_sel = AV42TFNegAssunto_Sel;
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = AV23TFNegCliNomeFamiliar;
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV24TFNegCliNomeFamiliar_Sel;
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = AV25TFNegCpjNomFan;
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV26TFNegCpjNomFan_Sel;
         AV105Core_negociopjwwds_22_tfnegcpjmatricula = AV29TFNegCpjMatricula;
         AV106Core_negociopjwwds_23_tfnegcpjmatricula_to = AV30TFNegCpjMatricula_To;
         AV107Core_negociopjwwds_24_tfnegpjtnome = AV35TFNegPjtNome;
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = AV36TFNegPjtNome_Sel;
         AV109Core_negociopjwwds_26_tfnegagcnome = AV39TFNegAgcNome;
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = AV40TFNegAgcNome_Sel;
         AV111Core_negociopjwwds_28_tfnegvaloratualizado = AV79TFNegValorAtualizado;
         AV112Core_negociopjwwds_29_tfnegvaloratualizado_to = AV80TFNegValorAtualizado_To;
         AV113Core_negociopjwwds_30_tfneginsdata = AV13TFNegInsData;
         AV114Core_negociopjwwds_31_tfneginsdata_to = AV14TFNegInsData_To;
         AV115Core_negociopjwwds_32_tfneginsusunome = AV77TFNegInsUsuNome;
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = AV78TFNegInsUsuNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV85Core_negociopjwwds_2_filterfulltext ,
                                              AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV88Core_negociopjwwds_5_negassunto1 ,
                                              AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV92Core_negociopjwwds_9_negassunto2 ,
                                              AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV96Core_negociopjwwds_13_negassunto3 ,
                                              AV97Core_negociopjwwds_14_tfnegcodigo ,
                                              AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV99Core_negociopjwwds_16_tfnegassunto ,
                                              AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV109Core_negociopjwwds_26_tfnegagcnome ,
                                              AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV113Core_negociopjwwds_30_tfneginsdata ,
                                              AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV115Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV107Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV109Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV115Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00523 */
         pr_default.execute(1, new Object[] {lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_5_negassunto1, lV88Core_negociopjwwds_5_negassunto1, lV92Core_negociopjwwds_9_negassunto2, lV92Core_negociopjwwds_9_negassunto2, lV96Core_negociopjwwds_13_negassunto3, lV96Core_negociopjwwds_13_negassunto3, AV97Core_negociopjwwds_14_tfnegcodigo, AV98Core_negociopjwwds_15_tfnegcodigo_to, lV99Core_negociopjwwds_16_tfnegassunto, AV100Core_negociopjwwds_17_tfnegassunto_sel, lV101Core_negociopjwwds_18_tfnegclinomefamiliar, AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV103Core_negociopjwwds_20_tfnegcpjnomfan, AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV105Core_negociopjwwds_22_tfnegcpjmatricula, AV106Core_negociopjwwds_23_tfnegcpjmatricula_to, lV107Core_negociopjwwds_24_tfnegpjtnome, AV108Core_negociopjwwds_25_tfnegpjtnome_sel, lV109Core_negociopjwwds_26_tfnegagcnome, AV110Core_negociopjwwds_27_tfnegagcnome_sel, AV111Core_negociopjwwds_28_tfnegvaloratualizado, AV112Core_negociopjwwds_29_tfnegvaloratualizado_to, AV113Core_negociopjwwds_30_tfneginsdata, AV114Core_negociopjwwds_31_tfneginsdata_to, lV115Core_negociopjwwds_32_tfneginsusunome, AV116Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK524 = false;
            A350NegCliID = P00523_A350NegCliID[0];
            A352NegCpjID = P00523_A352NegCpjID[0];
            A351NegCliNomeFamiliar = P00523_A351NegCliNomeFamiliar[0];
            A346NegInsData = P00523_A346NegInsData[0];
            A385NegValorAtualizado = P00523_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00523_A355NegCpjMatricula[0];
            A356NegCodigo = P00523_A356NegCodigo[0];
            A364NegInsUsuNome = P00523_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00523_n364NegInsUsuNome[0];
            A361NegAgcNome = P00523_A361NegAgcNome[0];
            n361NegAgcNome = P00523_n361NegAgcNome[0];
            A359NegPjtNome = P00523_A359NegPjtNome[0];
            A353NegCpjNomFan = P00523_A353NegCpjNomFan[0];
            A362NegAssunto = P00523_A362NegAssunto[0];
            A572NegDel = P00523_A572NegDel[0];
            A345NegID = P00523_A345NegID[0];
            A355NegCpjMatricula = P00523_A355NegCpjMatricula[0];
            AV53count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00523_A351NegCliNomeFamiliar[0], A351NegCliNomeFamiliar) == 0 ) )
            {
               BRK524 = false;
               A345NegID = P00523_A345NegID[0];
               AV53count = (long)(AV53count+1);
               BRK524 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV44SkipItems) )
            {
               AV48Option = (String.IsNullOrEmpty(StringUtil.RTrim( A351NegCliNomeFamiliar)) ? "<#Empty#>" : A351NegCliNomeFamiliar);
               AV49Options.Add(AV48Option, 0);
               AV52OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV53count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV49Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK524 )
            {
               BRK524 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADNEGCPJNOMFANOPTIONS' Routine */
         returnInSub = false;
         AV25TFNegCpjNomFan = AV43SearchTxt;
         AV26TFNegCpjNomFan_Sel = "";
         AV84Core_negociopjwwds_1_negdel = AV81NegDel;
         AV85Core_negociopjwwds_2_filterfulltext = AV65FilterFullText;
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = AV66DynamicFiltersSelector1;
         AV87Core_negociopjwwds_4_dynamicfiltersoperator1 = AV67DynamicFiltersOperator1;
         AV88Core_negociopjwwds_5_negassunto1 = AV68NegAssunto1;
         AV89Core_negociopjwwds_6_dynamicfiltersenabled2 = AV69DynamicFiltersEnabled2;
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = AV70DynamicFiltersSelector2;
         AV91Core_negociopjwwds_8_dynamicfiltersoperator2 = AV71DynamicFiltersOperator2;
         AV92Core_negociopjwwds_9_negassunto2 = AV72NegAssunto2;
         AV93Core_negociopjwwds_10_dynamicfiltersenabled3 = AV73DynamicFiltersEnabled3;
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = AV74DynamicFiltersSelector3;
         AV95Core_negociopjwwds_12_dynamicfiltersoperator3 = AV75DynamicFiltersOperator3;
         AV96Core_negociopjwwds_13_negassunto3 = AV76NegAssunto3;
         AV97Core_negociopjwwds_14_tfnegcodigo = AV11TFNegCodigo;
         AV98Core_negociopjwwds_15_tfnegcodigo_to = AV12TFNegCodigo_To;
         AV99Core_negociopjwwds_16_tfnegassunto = AV41TFNegAssunto;
         AV100Core_negociopjwwds_17_tfnegassunto_sel = AV42TFNegAssunto_Sel;
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = AV23TFNegCliNomeFamiliar;
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV24TFNegCliNomeFamiliar_Sel;
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = AV25TFNegCpjNomFan;
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV26TFNegCpjNomFan_Sel;
         AV105Core_negociopjwwds_22_tfnegcpjmatricula = AV29TFNegCpjMatricula;
         AV106Core_negociopjwwds_23_tfnegcpjmatricula_to = AV30TFNegCpjMatricula_To;
         AV107Core_negociopjwwds_24_tfnegpjtnome = AV35TFNegPjtNome;
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = AV36TFNegPjtNome_Sel;
         AV109Core_negociopjwwds_26_tfnegagcnome = AV39TFNegAgcNome;
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = AV40TFNegAgcNome_Sel;
         AV111Core_negociopjwwds_28_tfnegvaloratualizado = AV79TFNegValorAtualizado;
         AV112Core_negociopjwwds_29_tfnegvaloratualizado_to = AV80TFNegValorAtualizado_To;
         AV113Core_negociopjwwds_30_tfneginsdata = AV13TFNegInsData;
         AV114Core_negociopjwwds_31_tfneginsdata_to = AV14TFNegInsData_To;
         AV115Core_negociopjwwds_32_tfneginsusunome = AV77TFNegInsUsuNome;
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = AV78TFNegInsUsuNome_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV85Core_negociopjwwds_2_filterfulltext ,
                                              AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV88Core_negociopjwwds_5_negassunto1 ,
                                              AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV92Core_negociopjwwds_9_negassunto2 ,
                                              AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV96Core_negociopjwwds_13_negassunto3 ,
                                              AV97Core_negociopjwwds_14_tfnegcodigo ,
                                              AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV99Core_negociopjwwds_16_tfnegassunto ,
                                              AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV109Core_negociopjwwds_26_tfnegagcnome ,
                                              AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV113Core_negociopjwwds_30_tfneginsdata ,
                                              AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV115Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV107Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV109Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV115Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00524 */
         pr_default.execute(2, new Object[] {lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_5_negassunto1, lV88Core_negociopjwwds_5_negassunto1, lV92Core_negociopjwwds_9_negassunto2, lV92Core_negociopjwwds_9_negassunto2, lV96Core_negociopjwwds_13_negassunto3, lV96Core_negociopjwwds_13_negassunto3, AV97Core_negociopjwwds_14_tfnegcodigo, AV98Core_negociopjwwds_15_tfnegcodigo_to, lV99Core_negociopjwwds_16_tfnegassunto, AV100Core_negociopjwwds_17_tfnegassunto_sel, lV101Core_negociopjwwds_18_tfnegclinomefamiliar, AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV103Core_negociopjwwds_20_tfnegcpjnomfan, AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV105Core_negociopjwwds_22_tfnegcpjmatricula, AV106Core_negociopjwwds_23_tfnegcpjmatricula_to, lV107Core_negociopjwwds_24_tfnegpjtnome, AV108Core_negociopjwwds_25_tfnegpjtnome_sel, lV109Core_negociopjwwds_26_tfnegagcnome, AV110Core_negociopjwwds_27_tfnegagcnome_sel, AV111Core_negociopjwwds_28_tfnegvaloratualizado, AV112Core_negociopjwwds_29_tfnegvaloratualizado_to, AV113Core_negociopjwwds_30_tfneginsdata, AV114Core_negociopjwwds_31_tfneginsdata_to, lV115Core_negociopjwwds_32_tfneginsusunome, AV116Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK526 = false;
            A350NegCliID = P00524_A350NegCliID[0];
            A352NegCpjID = P00524_A352NegCpjID[0];
            A353NegCpjNomFan = P00524_A353NegCpjNomFan[0];
            A346NegInsData = P00524_A346NegInsData[0];
            A385NegValorAtualizado = P00524_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00524_A355NegCpjMatricula[0];
            A356NegCodigo = P00524_A356NegCodigo[0];
            A364NegInsUsuNome = P00524_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00524_n364NegInsUsuNome[0];
            A361NegAgcNome = P00524_A361NegAgcNome[0];
            n361NegAgcNome = P00524_n361NegAgcNome[0];
            A359NegPjtNome = P00524_A359NegPjtNome[0];
            A351NegCliNomeFamiliar = P00524_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00524_A362NegAssunto[0];
            A572NegDel = P00524_A572NegDel[0];
            A345NegID = P00524_A345NegID[0];
            A355NegCpjMatricula = P00524_A355NegCpjMatricula[0];
            AV53count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00524_A353NegCpjNomFan[0], A353NegCpjNomFan) == 0 ) )
            {
               BRK526 = false;
               A345NegID = P00524_A345NegID[0];
               AV53count = (long)(AV53count+1);
               BRK526 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV44SkipItems) )
            {
               AV48Option = (String.IsNullOrEmpty(StringUtil.RTrim( A353NegCpjNomFan)) ? "<#Empty#>" : A353NegCpjNomFan);
               AV49Options.Add(AV48Option, 0);
               AV52OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV53count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV49Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK526 )
            {
               BRK526 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADNEGPJTNOMEOPTIONS' Routine */
         returnInSub = false;
         AV35TFNegPjtNome = AV43SearchTxt;
         AV36TFNegPjtNome_Sel = "";
         AV84Core_negociopjwwds_1_negdel = AV81NegDel;
         AV85Core_negociopjwwds_2_filterfulltext = AV65FilterFullText;
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = AV66DynamicFiltersSelector1;
         AV87Core_negociopjwwds_4_dynamicfiltersoperator1 = AV67DynamicFiltersOperator1;
         AV88Core_negociopjwwds_5_negassunto1 = AV68NegAssunto1;
         AV89Core_negociopjwwds_6_dynamicfiltersenabled2 = AV69DynamicFiltersEnabled2;
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = AV70DynamicFiltersSelector2;
         AV91Core_negociopjwwds_8_dynamicfiltersoperator2 = AV71DynamicFiltersOperator2;
         AV92Core_negociopjwwds_9_negassunto2 = AV72NegAssunto2;
         AV93Core_negociopjwwds_10_dynamicfiltersenabled3 = AV73DynamicFiltersEnabled3;
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = AV74DynamicFiltersSelector3;
         AV95Core_negociopjwwds_12_dynamicfiltersoperator3 = AV75DynamicFiltersOperator3;
         AV96Core_negociopjwwds_13_negassunto3 = AV76NegAssunto3;
         AV97Core_negociopjwwds_14_tfnegcodigo = AV11TFNegCodigo;
         AV98Core_negociopjwwds_15_tfnegcodigo_to = AV12TFNegCodigo_To;
         AV99Core_negociopjwwds_16_tfnegassunto = AV41TFNegAssunto;
         AV100Core_negociopjwwds_17_tfnegassunto_sel = AV42TFNegAssunto_Sel;
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = AV23TFNegCliNomeFamiliar;
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV24TFNegCliNomeFamiliar_Sel;
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = AV25TFNegCpjNomFan;
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV26TFNegCpjNomFan_Sel;
         AV105Core_negociopjwwds_22_tfnegcpjmatricula = AV29TFNegCpjMatricula;
         AV106Core_negociopjwwds_23_tfnegcpjmatricula_to = AV30TFNegCpjMatricula_To;
         AV107Core_negociopjwwds_24_tfnegpjtnome = AV35TFNegPjtNome;
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = AV36TFNegPjtNome_Sel;
         AV109Core_negociopjwwds_26_tfnegagcnome = AV39TFNegAgcNome;
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = AV40TFNegAgcNome_Sel;
         AV111Core_negociopjwwds_28_tfnegvaloratualizado = AV79TFNegValorAtualizado;
         AV112Core_negociopjwwds_29_tfnegvaloratualizado_to = AV80TFNegValorAtualizado_To;
         AV113Core_negociopjwwds_30_tfneginsdata = AV13TFNegInsData;
         AV114Core_negociopjwwds_31_tfneginsdata_to = AV14TFNegInsData_To;
         AV115Core_negociopjwwds_32_tfneginsusunome = AV77TFNegInsUsuNome;
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = AV78TFNegInsUsuNome_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV85Core_negociopjwwds_2_filterfulltext ,
                                              AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV88Core_negociopjwwds_5_negassunto1 ,
                                              AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV92Core_negociopjwwds_9_negassunto2 ,
                                              AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV96Core_negociopjwwds_13_negassunto3 ,
                                              AV97Core_negociopjwwds_14_tfnegcodigo ,
                                              AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV99Core_negociopjwwds_16_tfnegassunto ,
                                              AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV109Core_negociopjwwds_26_tfnegagcnome ,
                                              AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV113Core_negociopjwwds_30_tfneginsdata ,
                                              AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV115Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV107Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV109Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV115Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00525 */
         pr_default.execute(3, new Object[] {lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_5_negassunto1, lV88Core_negociopjwwds_5_negassunto1, lV92Core_negociopjwwds_9_negassunto2, lV92Core_negociopjwwds_9_negassunto2, lV96Core_negociopjwwds_13_negassunto3, lV96Core_negociopjwwds_13_negassunto3, AV97Core_negociopjwwds_14_tfnegcodigo, AV98Core_negociopjwwds_15_tfnegcodigo_to, lV99Core_negociopjwwds_16_tfnegassunto, AV100Core_negociopjwwds_17_tfnegassunto_sel, lV101Core_negociopjwwds_18_tfnegclinomefamiliar, AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV103Core_negociopjwwds_20_tfnegcpjnomfan, AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV105Core_negociopjwwds_22_tfnegcpjmatricula, AV106Core_negociopjwwds_23_tfnegcpjmatricula_to, lV107Core_negociopjwwds_24_tfnegpjtnome, AV108Core_negociopjwwds_25_tfnegpjtnome_sel, lV109Core_negociopjwwds_26_tfnegagcnome, AV110Core_negociopjwwds_27_tfnegagcnome_sel, AV111Core_negociopjwwds_28_tfnegvaloratualizado, AV112Core_negociopjwwds_29_tfnegvaloratualizado_to, AV113Core_negociopjwwds_30_tfneginsdata, AV114Core_negociopjwwds_31_tfneginsdata_to, lV115Core_negociopjwwds_32_tfneginsusunome, AV116Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK528 = false;
            A350NegCliID = P00525_A350NegCliID[0];
            A352NegCpjID = P00525_A352NegCpjID[0];
            A359NegPjtNome = P00525_A359NegPjtNome[0];
            A346NegInsData = P00525_A346NegInsData[0];
            A385NegValorAtualizado = P00525_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00525_A355NegCpjMatricula[0];
            A356NegCodigo = P00525_A356NegCodigo[0];
            A364NegInsUsuNome = P00525_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00525_n364NegInsUsuNome[0];
            A361NegAgcNome = P00525_A361NegAgcNome[0];
            n361NegAgcNome = P00525_n361NegAgcNome[0];
            A353NegCpjNomFan = P00525_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00525_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00525_A362NegAssunto[0];
            A572NegDel = P00525_A572NegDel[0];
            A345NegID = P00525_A345NegID[0];
            A355NegCpjMatricula = P00525_A355NegCpjMatricula[0];
            AV53count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00525_A359NegPjtNome[0], A359NegPjtNome) == 0 ) )
            {
               BRK528 = false;
               A345NegID = P00525_A345NegID[0];
               AV53count = (long)(AV53count+1);
               BRK528 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV44SkipItems) )
            {
               AV48Option = (String.IsNullOrEmpty(StringUtil.RTrim( A359NegPjtNome)) ? "<#Empty#>" : A359NegPjtNome);
               AV49Options.Add(AV48Option, 0);
               AV52OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV53count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV49Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK528 )
            {
               BRK528 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADNEGAGCNOMEOPTIONS' Routine */
         returnInSub = false;
         AV39TFNegAgcNome = AV43SearchTxt;
         AV40TFNegAgcNome_Sel = "";
         AV84Core_negociopjwwds_1_negdel = AV81NegDel;
         AV85Core_negociopjwwds_2_filterfulltext = AV65FilterFullText;
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = AV66DynamicFiltersSelector1;
         AV87Core_negociopjwwds_4_dynamicfiltersoperator1 = AV67DynamicFiltersOperator1;
         AV88Core_negociopjwwds_5_negassunto1 = AV68NegAssunto1;
         AV89Core_negociopjwwds_6_dynamicfiltersenabled2 = AV69DynamicFiltersEnabled2;
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = AV70DynamicFiltersSelector2;
         AV91Core_negociopjwwds_8_dynamicfiltersoperator2 = AV71DynamicFiltersOperator2;
         AV92Core_negociopjwwds_9_negassunto2 = AV72NegAssunto2;
         AV93Core_negociopjwwds_10_dynamicfiltersenabled3 = AV73DynamicFiltersEnabled3;
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = AV74DynamicFiltersSelector3;
         AV95Core_negociopjwwds_12_dynamicfiltersoperator3 = AV75DynamicFiltersOperator3;
         AV96Core_negociopjwwds_13_negassunto3 = AV76NegAssunto3;
         AV97Core_negociopjwwds_14_tfnegcodigo = AV11TFNegCodigo;
         AV98Core_negociopjwwds_15_tfnegcodigo_to = AV12TFNegCodigo_To;
         AV99Core_negociopjwwds_16_tfnegassunto = AV41TFNegAssunto;
         AV100Core_negociopjwwds_17_tfnegassunto_sel = AV42TFNegAssunto_Sel;
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = AV23TFNegCliNomeFamiliar;
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV24TFNegCliNomeFamiliar_Sel;
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = AV25TFNegCpjNomFan;
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV26TFNegCpjNomFan_Sel;
         AV105Core_negociopjwwds_22_tfnegcpjmatricula = AV29TFNegCpjMatricula;
         AV106Core_negociopjwwds_23_tfnegcpjmatricula_to = AV30TFNegCpjMatricula_To;
         AV107Core_negociopjwwds_24_tfnegpjtnome = AV35TFNegPjtNome;
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = AV36TFNegPjtNome_Sel;
         AV109Core_negociopjwwds_26_tfnegagcnome = AV39TFNegAgcNome;
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = AV40TFNegAgcNome_Sel;
         AV111Core_negociopjwwds_28_tfnegvaloratualizado = AV79TFNegValorAtualizado;
         AV112Core_negociopjwwds_29_tfnegvaloratualizado_to = AV80TFNegValorAtualizado_To;
         AV113Core_negociopjwwds_30_tfneginsdata = AV13TFNegInsData;
         AV114Core_negociopjwwds_31_tfneginsdata_to = AV14TFNegInsData_To;
         AV115Core_negociopjwwds_32_tfneginsusunome = AV77TFNegInsUsuNome;
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = AV78TFNegInsUsuNome_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV85Core_negociopjwwds_2_filterfulltext ,
                                              AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV88Core_negociopjwwds_5_negassunto1 ,
                                              AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV92Core_negociopjwwds_9_negassunto2 ,
                                              AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV96Core_negociopjwwds_13_negassunto3 ,
                                              AV97Core_negociopjwwds_14_tfnegcodigo ,
                                              AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV99Core_negociopjwwds_16_tfnegassunto ,
                                              AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV109Core_negociopjwwds_26_tfnegagcnome ,
                                              AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV113Core_negociopjwwds_30_tfneginsdata ,
                                              AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV115Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV107Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV109Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV115Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00526 */
         pr_default.execute(4, new Object[] {lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_5_negassunto1, lV88Core_negociopjwwds_5_negassunto1, lV92Core_negociopjwwds_9_negassunto2, lV92Core_negociopjwwds_9_negassunto2, lV96Core_negociopjwwds_13_negassunto3, lV96Core_negociopjwwds_13_negassunto3, AV97Core_negociopjwwds_14_tfnegcodigo, AV98Core_negociopjwwds_15_tfnegcodigo_to, lV99Core_negociopjwwds_16_tfnegassunto, AV100Core_negociopjwwds_17_tfnegassunto_sel, lV101Core_negociopjwwds_18_tfnegclinomefamiliar, AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV103Core_negociopjwwds_20_tfnegcpjnomfan, AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV105Core_negociopjwwds_22_tfnegcpjmatricula, AV106Core_negociopjwwds_23_tfnegcpjmatricula_to, lV107Core_negociopjwwds_24_tfnegpjtnome, AV108Core_negociopjwwds_25_tfnegpjtnome_sel, lV109Core_negociopjwwds_26_tfnegagcnome, AV110Core_negociopjwwds_27_tfnegagcnome_sel, AV111Core_negociopjwwds_28_tfnegvaloratualizado, AV112Core_negociopjwwds_29_tfnegvaloratualizado_to, AV113Core_negociopjwwds_30_tfneginsdata, AV114Core_negociopjwwds_31_tfneginsdata_to, lV115Core_negociopjwwds_32_tfneginsusunome, AV116Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK5210 = false;
            A350NegCliID = P00526_A350NegCliID[0];
            A352NegCpjID = P00526_A352NegCpjID[0];
            A361NegAgcNome = P00526_A361NegAgcNome[0];
            n361NegAgcNome = P00526_n361NegAgcNome[0];
            A346NegInsData = P00526_A346NegInsData[0];
            A385NegValorAtualizado = P00526_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00526_A355NegCpjMatricula[0];
            A356NegCodigo = P00526_A356NegCodigo[0];
            A364NegInsUsuNome = P00526_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00526_n364NegInsUsuNome[0];
            A359NegPjtNome = P00526_A359NegPjtNome[0];
            A353NegCpjNomFan = P00526_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00526_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00526_A362NegAssunto[0];
            A572NegDel = P00526_A572NegDel[0];
            A345NegID = P00526_A345NegID[0];
            A355NegCpjMatricula = P00526_A355NegCpjMatricula[0];
            AV53count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00526_A361NegAgcNome[0], A361NegAgcNome) == 0 ) )
            {
               BRK5210 = false;
               A345NegID = P00526_A345NegID[0];
               AV53count = (long)(AV53count+1);
               BRK5210 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV44SkipItems) )
            {
               AV48Option = (String.IsNullOrEmpty(StringUtil.RTrim( A361NegAgcNome)) ? "<#Empty#>" : A361NegAgcNome);
               AV49Options.Add(AV48Option, 0);
               AV52OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV53count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV49Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK5210 )
            {
               BRK5210 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADNEGINSUSUNOMEOPTIONS' Routine */
         returnInSub = false;
         AV77TFNegInsUsuNome = AV43SearchTxt;
         AV78TFNegInsUsuNome_Sel = "";
         AV84Core_negociopjwwds_1_negdel = AV81NegDel;
         AV85Core_negociopjwwds_2_filterfulltext = AV65FilterFullText;
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = AV66DynamicFiltersSelector1;
         AV87Core_negociopjwwds_4_dynamicfiltersoperator1 = AV67DynamicFiltersOperator1;
         AV88Core_negociopjwwds_5_negassunto1 = AV68NegAssunto1;
         AV89Core_negociopjwwds_6_dynamicfiltersenabled2 = AV69DynamicFiltersEnabled2;
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = AV70DynamicFiltersSelector2;
         AV91Core_negociopjwwds_8_dynamicfiltersoperator2 = AV71DynamicFiltersOperator2;
         AV92Core_negociopjwwds_9_negassunto2 = AV72NegAssunto2;
         AV93Core_negociopjwwds_10_dynamicfiltersenabled3 = AV73DynamicFiltersEnabled3;
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = AV74DynamicFiltersSelector3;
         AV95Core_negociopjwwds_12_dynamicfiltersoperator3 = AV75DynamicFiltersOperator3;
         AV96Core_negociopjwwds_13_negassunto3 = AV76NegAssunto3;
         AV97Core_negociopjwwds_14_tfnegcodigo = AV11TFNegCodigo;
         AV98Core_negociopjwwds_15_tfnegcodigo_to = AV12TFNegCodigo_To;
         AV99Core_negociopjwwds_16_tfnegassunto = AV41TFNegAssunto;
         AV100Core_negociopjwwds_17_tfnegassunto_sel = AV42TFNegAssunto_Sel;
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = AV23TFNegCliNomeFamiliar;
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV24TFNegCliNomeFamiliar_Sel;
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = AV25TFNegCpjNomFan;
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV26TFNegCpjNomFan_Sel;
         AV105Core_negociopjwwds_22_tfnegcpjmatricula = AV29TFNegCpjMatricula;
         AV106Core_negociopjwwds_23_tfnegcpjmatricula_to = AV30TFNegCpjMatricula_To;
         AV107Core_negociopjwwds_24_tfnegpjtnome = AV35TFNegPjtNome;
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = AV36TFNegPjtNome_Sel;
         AV109Core_negociopjwwds_26_tfnegagcnome = AV39TFNegAgcNome;
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = AV40TFNegAgcNome_Sel;
         AV111Core_negociopjwwds_28_tfnegvaloratualizado = AV79TFNegValorAtualizado;
         AV112Core_negociopjwwds_29_tfnegvaloratualizado_to = AV80TFNegValorAtualizado_To;
         AV113Core_negociopjwwds_30_tfneginsdata = AV13TFNegInsData;
         AV114Core_negociopjwwds_31_tfneginsdata_to = AV14TFNegInsData_To;
         AV115Core_negociopjwwds_32_tfneginsusunome = AV77TFNegInsUsuNome;
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = AV78TFNegInsUsuNome_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV85Core_negociopjwwds_2_filterfulltext ,
                                              AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV88Core_negociopjwwds_5_negassunto1 ,
                                              AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV92Core_negociopjwwds_9_negassunto2 ,
                                              AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV96Core_negociopjwwds_13_negassunto3 ,
                                              AV97Core_negociopjwwds_14_tfnegcodigo ,
                                              AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV99Core_negociopjwwds_16_tfnegassunto ,
                                              AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV109Core_negociopjwwds_26_tfnegagcnome ,
                                              AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV113Core_negociopjwwds_30_tfneginsdata ,
                                              AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV115Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV85Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV88Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV92Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV96Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV107Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV109Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV115Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00527 */
         pr_default.execute(5, new Object[] {lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV85Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_5_negassunto1, lV88Core_negociopjwwds_5_negassunto1, lV92Core_negociopjwwds_9_negassunto2, lV92Core_negociopjwwds_9_negassunto2, lV96Core_negociopjwwds_13_negassunto3, lV96Core_negociopjwwds_13_negassunto3, AV97Core_negociopjwwds_14_tfnegcodigo, AV98Core_negociopjwwds_15_tfnegcodigo_to, lV99Core_negociopjwwds_16_tfnegassunto, AV100Core_negociopjwwds_17_tfnegassunto_sel, lV101Core_negociopjwwds_18_tfnegclinomefamiliar, AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV103Core_negociopjwwds_20_tfnegcpjnomfan, AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV105Core_negociopjwwds_22_tfnegcpjmatricula, AV106Core_negociopjwwds_23_tfnegcpjmatricula_to, lV107Core_negociopjwwds_24_tfnegpjtnome, AV108Core_negociopjwwds_25_tfnegpjtnome_sel, lV109Core_negociopjwwds_26_tfnegagcnome, AV110Core_negociopjwwds_27_tfnegagcnome_sel, AV111Core_negociopjwwds_28_tfnegvaloratualizado, AV112Core_negociopjwwds_29_tfnegvaloratualizado_to, AV113Core_negociopjwwds_30_tfneginsdata, AV114Core_negociopjwwds_31_tfneginsdata_to, lV115Core_negociopjwwds_32_tfneginsusunome, AV116Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK5212 = false;
            A350NegCliID = P00527_A350NegCliID[0];
            A352NegCpjID = P00527_A352NegCpjID[0];
            A364NegInsUsuNome = P00527_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00527_n364NegInsUsuNome[0];
            A346NegInsData = P00527_A346NegInsData[0];
            A385NegValorAtualizado = P00527_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00527_A355NegCpjMatricula[0];
            A356NegCodigo = P00527_A356NegCodigo[0];
            A361NegAgcNome = P00527_A361NegAgcNome[0];
            n361NegAgcNome = P00527_n361NegAgcNome[0];
            A359NegPjtNome = P00527_A359NegPjtNome[0];
            A353NegCpjNomFan = P00527_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00527_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00527_A362NegAssunto[0];
            A572NegDel = P00527_A572NegDel[0];
            A345NegID = P00527_A345NegID[0];
            A355NegCpjMatricula = P00527_A355NegCpjMatricula[0];
            AV53count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00527_A364NegInsUsuNome[0], A364NegInsUsuNome) == 0 ) )
            {
               BRK5212 = false;
               A345NegID = P00527_A345NegID[0];
               AV53count = (long)(AV53count+1);
               BRK5212 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV44SkipItems) )
            {
               AV48Option = (String.IsNullOrEmpty(StringUtil.RTrim( A364NegInsUsuNome)) ? "<#Empty#>" : A364NegInsUsuNome);
               AV49Options.Add(AV48Option, 0);
               AV52OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV53count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV49Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV44SkipItems = (short)(AV44SkipItems-1);
            }
            if ( ! BRK5212 )
            {
               BRK5212 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
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
         AV62OptionsJson = "";
         AV63OptionsDescJson = "";
         AV64OptionIndexesJson = "";
         AV49Options = new GxSimpleCollection<string>();
         AV51OptionsDesc = new GxSimpleCollection<string>();
         AV52OptionIndexes = new GxSimpleCollection<string>();
         AV43SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV54Session = context.GetSession();
         AV56GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV57GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV65FilterFullText = "";
         AV41TFNegAssunto = "";
         AV42TFNegAssunto_Sel = "";
         AV23TFNegCliNomeFamiliar = "";
         AV24TFNegCliNomeFamiliar_Sel = "";
         AV25TFNegCpjNomFan = "";
         AV26TFNegCpjNomFan_Sel = "";
         AV35TFNegPjtNome = "";
         AV36TFNegPjtNome_Sel = "";
         AV39TFNegAgcNome = "";
         AV40TFNegAgcNome_Sel = "";
         AV13TFNegInsData = DateTime.MinValue;
         AV14TFNegInsData_To = DateTime.MinValue;
         AV77TFNegInsUsuNome = "";
         AV78TFNegInsUsuNome_Sel = "";
         AV58GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV66DynamicFiltersSelector1 = "";
         AV68NegAssunto1 = "";
         AV70DynamicFiltersSelector2 = "";
         AV72NegAssunto2 = "";
         AV74DynamicFiltersSelector3 = "";
         AV76NegAssunto3 = "";
         AV85Core_negociopjwwds_2_filterfulltext = "";
         AV86Core_negociopjwwds_3_dynamicfiltersselector1 = "";
         AV88Core_negociopjwwds_5_negassunto1 = "";
         AV90Core_negociopjwwds_7_dynamicfiltersselector2 = "";
         AV92Core_negociopjwwds_9_negassunto2 = "";
         AV94Core_negociopjwwds_11_dynamicfiltersselector3 = "";
         AV96Core_negociopjwwds_13_negassunto3 = "";
         AV99Core_negociopjwwds_16_tfnegassunto = "";
         AV100Core_negociopjwwds_17_tfnegassunto_sel = "";
         AV101Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel = "";
         AV103Core_negociopjwwds_20_tfnegcpjnomfan = "";
         AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel = "";
         AV107Core_negociopjwwds_24_tfnegpjtnome = "";
         AV108Core_negociopjwwds_25_tfnegpjtnome_sel = "";
         AV109Core_negociopjwwds_26_tfnegagcnome = "";
         AV110Core_negociopjwwds_27_tfnegagcnome_sel = "";
         AV113Core_negociopjwwds_30_tfneginsdata = DateTime.MinValue;
         AV114Core_negociopjwwds_31_tfneginsdata_to = DateTime.MinValue;
         AV115Core_negociopjwwds_32_tfneginsusunome = "";
         AV116Core_negociopjwwds_33_tfneginsusunome_sel = "";
         scmdbuf = "";
         lV85Core_negociopjwwds_2_filterfulltext = "";
         lV88Core_negociopjwwds_5_negassunto1 = "";
         lV92Core_negociopjwwds_9_negassunto2 = "";
         lV96Core_negociopjwwds_13_negassunto3 = "";
         lV99Core_negociopjwwds_16_tfnegassunto = "";
         lV101Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         lV103Core_negociopjwwds_20_tfnegcpjnomfan = "";
         lV107Core_negociopjwwds_24_tfnegpjtnome = "";
         lV109Core_negociopjwwds_26_tfnegagcnome = "";
         lV115Core_negociopjwwds_32_tfneginsusunome = "";
         A362NegAssunto = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         A359NegPjtNome = "";
         A361NegAgcNome = "";
         A364NegInsUsuNome = "";
         A346NegInsData = DateTime.MinValue;
         P00522_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00522_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00522_A362NegAssunto = new string[] {""} ;
         P00522_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00522_A385NegValorAtualizado = new decimal[1] ;
         P00522_A355NegCpjMatricula = new long[1] ;
         P00522_A356NegCodigo = new long[1] ;
         P00522_A364NegInsUsuNome = new string[] {""} ;
         P00522_n364NegInsUsuNome = new bool[] {false} ;
         P00522_A361NegAgcNome = new string[] {""} ;
         P00522_n361NegAgcNome = new bool[] {false} ;
         P00522_A359NegPjtNome = new string[] {""} ;
         P00522_A353NegCpjNomFan = new string[] {""} ;
         P00522_A351NegCliNomeFamiliar = new string[] {""} ;
         P00522_A572NegDel = new bool[] {false} ;
         P00522_A345NegID = new Guid[] {Guid.Empty} ;
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         A345NegID = Guid.Empty;
         AV48Option = "";
         AV50OptionDesc = "";
         P00523_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00523_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00523_A351NegCliNomeFamiliar = new string[] {""} ;
         P00523_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00523_A385NegValorAtualizado = new decimal[1] ;
         P00523_A355NegCpjMatricula = new long[1] ;
         P00523_A356NegCodigo = new long[1] ;
         P00523_A364NegInsUsuNome = new string[] {""} ;
         P00523_n364NegInsUsuNome = new bool[] {false} ;
         P00523_A361NegAgcNome = new string[] {""} ;
         P00523_n361NegAgcNome = new bool[] {false} ;
         P00523_A359NegPjtNome = new string[] {""} ;
         P00523_A353NegCpjNomFan = new string[] {""} ;
         P00523_A362NegAssunto = new string[] {""} ;
         P00523_A572NegDel = new bool[] {false} ;
         P00523_A345NegID = new Guid[] {Guid.Empty} ;
         P00524_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00524_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00524_A353NegCpjNomFan = new string[] {""} ;
         P00524_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00524_A385NegValorAtualizado = new decimal[1] ;
         P00524_A355NegCpjMatricula = new long[1] ;
         P00524_A356NegCodigo = new long[1] ;
         P00524_A364NegInsUsuNome = new string[] {""} ;
         P00524_n364NegInsUsuNome = new bool[] {false} ;
         P00524_A361NegAgcNome = new string[] {""} ;
         P00524_n361NegAgcNome = new bool[] {false} ;
         P00524_A359NegPjtNome = new string[] {""} ;
         P00524_A351NegCliNomeFamiliar = new string[] {""} ;
         P00524_A362NegAssunto = new string[] {""} ;
         P00524_A572NegDel = new bool[] {false} ;
         P00524_A345NegID = new Guid[] {Guid.Empty} ;
         P00525_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00525_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00525_A359NegPjtNome = new string[] {""} ;
         P00525_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00525_A385NegValorAtualizado = new decimal[1] ;
         P00525_A355NegCpjMatricula = new long[1] ;
         P00525_A356NegCodigo = new long[1] ;
         P00525_A364NegInsUsuNome = new string[] {""} ;
         P00525_n364NegInsUsuNome = new bool[] {false} ;
         P00525_A361NegAgcNome = new string[] {""} ;
         P00525_n361NegAgcNome = new bool[] {false} ;
         P00525_A353NegCpjNomFan = new string[] {""} ;
         P00525_A351NegCliNomeFamiliar = new string[] {""} ;
         P00525_A362NegAssunto = new string[] {""} ;
         P00525_A572NegDel = new bool[] {false} ;
         P00525_A345NegID = new Guid[] {Guid.Empty} ;
         P00526_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00526_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00526_A361NegAgcNome = new string[] {""} ;
         P00526_n361NegAgcNome = new bool[] {false} ;
         P00526_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00526_A385NegValorAtualizado = new decimal[1] ;
         P00526_A355NegCpjMatricula = new long[1] ;
         P00526_A356NegCodigo = new long[1] ;
         P00526_A364NegInsUsuNome = new string[] {""} ;
         P00526_n364NegInsUsuNome = new bool[] {false} ;
         P00526_A359NegPjtNome = new string[] {""} ;
         P00526_A353NegCpjNomFan = new string[] {""} ;
         P00526_A351NegCliNomeFamiliar = new string[] {""} ;
         P00526_A362NegAssunto = new string[] {""} ;
         P00526_A572NegDel = new bool[] {false} ;
         P00526_A345NegID = new Guid[] {Guid.Empty} ;
         P00527_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00527_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00527_A364NegInsUsuNome = new string[] {""} ;
         P00527_n364NegInsUsuNome = new bool[] {false} ;
         P00527_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00527_A385NegValorAtualizado = new decimal[1] ;
         P00527_A355NegCpjMatricula = new long[1] ;
         P00527_A356NegCodigo = new long[1] ;
         P00527_A361NegAgcNome = new string[] {""} ;
         P00527_n361NegAgcNome = new bool[] {false} ;
         P00527_A359NegPjtNome = new string[] {""} ;
         P00527_A353NegCpjNomFan = new string[] {""} ;
         P00527_A351NegCliNomeFamiliar = new string[] {""} ;
         P00527_A362NegAssunto = new string[] {""} ;
         P00527_A572NegDel = new bool[] {false} ;
         P00527_A345NegID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00522_A350NegCliID, P00522_A352NegCpjID, P00522_A362NegAssunto, P00522_A346NegInsData, P00522_A385NegValorAtualizado, P00522_A355NegCpjMatricula, P00522_A356NegCodigo, P00522_A364NegInsUsuNome, P00522_n364NegInsUsuNome, P00522_A361NegAgcNome,
               P00522_n361NegAgcNome, P00522_A359NegPjtNome, P00522_A353NegCpjNomFan, P00522_A351NegCliNomeFamiliar, P00522_A572NegDel, P00522_A345NegID
               }
               , new Object[] {
               P00523_A350NegCliID, P00523_A352NegCpjID, P00523_A351NegCliNomeFamiliar, P00523_A346NegInsData, P00523_A385NegValorAtualizado, P00523_A355NegCpjMatricula, P00523_A356NegCodigo, P00523_A364NegInsUsuNome, P00523_n364NegInsUsuNome, P00523_A361NegAgcNome,
               P00523_n361NegAgcNome, P00523_A359NegPjtNome, P00523_A353NegCpjNomFan, P00523_A362NegAssunto, P00523_A572NegDel, P00523_A345NegID
               }
               , new Object[] {
               P00524_A350NegCliID, P00524_A352NegCpjID, P00524_A353NegCpjNomFan, P00524_A346NegInsData, P00524_A385NegValorAtualizado, P00524_A355NegCpjMatricula, P00524_A356NegCodigo, P00524_A364NegInsUsuNome, P00524_n364NegInsUsuNome, P00524_A361NegAgcNome,
               P00524_n361NegAgcNome, P00524_A359NegPjtNome, P00524_A351NegCliNomeFamiliar, P00524_A362NegAssunto, P00524_A572NegDel, P00524_A345NegID
               }
               , new Object[] {
               P00525_A350NegCliID, P00525_A352NegCpjID, P00525_A359NegPjtNome, P00525_A346NegInsData, P00525_A385NegValorAtualizado, P00525_A355NegCpjMatricula, P00525_A356NegCodigo, P00525_A364NegInsUsuNome, P00525_n364NegInsUsuNome, P00525_A361NegAgcNome,
               P00525_n361NegAgcNome, P00525_A353NegCpjNomFan, P00525_A351NegCliNomeFamiliar, P00525_A362NegAssunto, P00525_A572NegDel, P00525_A345NegID
               }
               , new Object[] {
               P00526_A350NegCliID, P00526_A352NegCpjID, P00526_A361NegAgcNome, P00526_n361NegAgcNome, P00526_A346NegInsData, P00526_A385NegValorAtualizado, P00526_A355NegCpjMatricula, P00526_A356NegCodigo, P00526_A364NegInsUsuNome, P00526_n364NegInsUsuNome,
               P00526_A359NegPjtNome, P00526_A353NegCpjNomFan, P00526_A351NegCliNomeFamiliar, P00526_A362NegAssunto, P00526_A572NegDel, P00526_A345NegID
               }
               , new Object[] {
               P00527_A350NegCliID, P00527_A352NegCpjID, P00527_A364NegInsUsuNome, P00527_n364NegInsUsuNome, P00527_A346NegInsData, P00527_A385NegValorAtualizado, P00527_A355NegCpjMatricula, P00527_A356NegCodigo, P00527_A361NegAgcNome, P00527_n361NegAgcNome,
               P00527_A359NegPjtNome, P00527_A353NegCpjNomFan, P00527_A351NegCliNomeFamiliar, P00527_A362NegAssunto, P00527_A572NegDel, P00527_A345NegID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV46MaxItems ;
      private short AV45PageIndex ;
      private short AV44SkipItems ;
      private short AV67DynamicFiltersOperator1 ;
      private short AV71DynamicFiltersOperator2 ;
      private short AV75DynamicFiltersOperator3 ;
      private short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ;
      private short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ;
      private short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ;
      private int AV82GXV1 ;
      private long AV11TFNegCodigo ;
      private long AV12TFNegCodigo_To ;
      private long AV29TFNegCpjMatricula ;
      private long AV30TFNegCpjMatricula_To ;
      private long AV97Core_negociopjwwds_14_tfnegcodigo ;
      private long AV98Core_negociopjwwds_15_tfnegcodigo_to ;
      private long AV105Core_negociopjwwds_22_tfnegcpjmatricula ;
      private long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ;
      private long A356NegCodigo ;
      private long A355NegCpjMatricula ;
      private long AV53count ;
      private decimal AV79TFNegValorAtualizado ;
      private decimal AV80TFNegValorAtualizado_To ;
      private decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ;
      private decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ;
      private decimal A385NegValorAtualizado ;
      private string scmdbuf ;
      private DateTime AV13TFNegInsData ;
      private DateTime AV14TFNegInsData_To ;
      private DateTime AV113Core_negociopjwwds_30_tfneginsdata ;
      private DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ;
      private DateTime A346NegInsData ;
      private bool returnInSub ;
      private bool AV81NegDel ;
      private bool AV69DynamicFiltersEnabled2 ;
      private bool AV73DynamicFiltersEnabled3 ;
      private bool AV84Core_negociopjwwds_1_negdel ;
      private bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ;
      private bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ;
      private bool A572NegDel ;
      private bool BRK522 ;
      private bool n364NegInsUsuNome ;
      private bool n361NegAgcNome ;
      private bool BRK524 ;
      private bool BRK526 ;
      private bool BRK528 ;
      private bool BRK5210 ;
      private bool BRK5212 ;
      private string AV62OptionsJson ;
      private string AV63OptionsDescJson ;
      private string AV64OptionIndexesJson ;
      private string AV59DDOName ;
      private string AV60SearchTxtParms ;
      private string AV61SearchTxtTo ;
      private string AV43SearchTxt ;
      private string AV65FilterFullText ;
      private string AV41TFNegAssunto ;
      private string AV42TFNegAssunto_Sel ;
      private string AV23TFNegCliNomeFamiliar ;
      private string AV24TFNegCliNomeFamiliar_Sel ;
      private string AV25TFNegCpjNomFan ;
      private string AV26TFNegCpjNomFan_Sel ;
      private string AV35TFNegPjtNome ;
      private string AV36TFNegPjtNome_Sel ;
      private string AV39TFNegAgcNome ;
      private string AV40TFNegAgcNome_Sel ;
      private string AV77TFNegInsUsuNome ;
      private string AV78TFNegInsUsuNome_Sel ;
      private string AV66DynamicFiltersSelector1 ;
      private string AV68NegAssunto1 ;
      private string AV70DynamicFiltersSelector2 ;
      private string AV72NegAssunto2 ;
      private string AV74DynamicFiltersSelector3 ;
      private string AV76NegAssunto3 ;
      private string AV85Core_negociopjwwds_2_filterfulltext ;
      private string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ;
      private string AV88Core_negociopjwwds_5_negassunto1 ;
      private string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ;
      private string AV92Core_negociopjwwds_9_negassunto2 ;
      private string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ;
      private string AV96Core_negociopjwwds_13_negassunto3 ;
      private string AV99Core_negociopjwwds_16_tfnegassunto ;
      private string AV100Core_negociopjwwds_17_tfnegassunto_sel ;
      private string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ;
      private string AV103Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ;
      private string AV107Core_negociopjwwds_24_tfnegpjtnome ;
      private string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ;
      private string AV109Core_negociopjwwds_26_tfnegagcnome ;
      private string AV110Core_negociopjwwds_27_tfnegagcnome_sel ;
      private string AV115Core_negociopjwwds_32_tfneginsusunome ;
      private string AV116Core_negociopjwwds_33_tfneginsusunome_sel ;
      private string lV85Core_negociopjwwds_2_filterfulltext ;
      private string lV88Core_negociopjwwds_5_negassunto1 ;
      private string lV92Core_negociopjwwds_9_negassunto2 ;
      private string lV96Core_negociopjwwds_13_negassunto3 ;
      private string lV99Core_negociopjwwds_16_tfnegassunto ;
      private string lV101Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string lV103Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string lV107Core_negociopjwwds_24_tfnegpjtnome ;
      private string lV109Core_negociopjwwds_26_tfnegagcnome ;
      private string lV115Core_negociopjwwds_32_tfneginsusunome ;
      private string A362NegAssunto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A359NegPjtNome ;
      private string A361NegAgcNome ;
      private string A364NegInsUsuNome ;
      private string AV48Option ;
      private string AV50OptionDesc ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A345NegID ;
      private IGxSession AV54Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00522_A350NegCliID ;
      private Guid[] P00522_A352NegCpjID ;
      private string[] P00522_A362NegAssunto ;
      private DateTime[] P00522_A346NegInsData ;
      private decimal[] P00522_A385NegValorAtualizado ;
      private long[] P00522_A355NegCpjMatricula ;
      private long[] P00522_A356NegCodigo ;
      private string[] P00522_A364NegInsUsuNome ;
      private bool[] P00522_n364NegInsUsuNome ;
      private string[] P00522_A361NegAgcNome ;
      private bool[] P00522_n361NegAgcNome ;
      private string[] P00522_A359NegPjtNome ;
      private string[] P00522_A353NegCpjNomFan ;
      private string[] P00522_A351NegCliNomeFamiliar ;
      private bool[] P00522_A572NegDel ;
      private Guid[] P00522_A345NegID ;
      private Guid[] P00523_A350NegCliID ;
      private Guid[] P00523_A352NegCpjID ;
      private string[] P00523_A351NegCliNomeFamiliar ;
      private DateTime[] P00523_A346NegInsData ;
      private decimal[] P00523_A385NegValorAtualizado ;
      private long[] P00523_A355NegCpjMatricula ;
      private long[] P00523_A356NegCodigo ;
      private string[] P00523_A364NegInsUsuNome ;
      private bool[] P00523_n364NegInsUsuNome ;
      private string[] P00523_A361NegAgcNome ;
      private bool[] P00523_n361NegAgcNome ;
      private string[] P00523_A359NegPjtNome ;
      private string[] P00523_A353NegCpjNomFan ;
      private string[] P00523_A362NegAssunto ;
      private bool[] P00523_A572NegDel ;
      private Guid[] P00523_A345NegID ;
      private Guid[] P00524_A350NegCliID ;
      private Guid[] P00524_A352NegCpjID ;
      private string[] P00524_A353NegCpjNomFan ;
      private DateTime[] P00524_A346NegInsData ;
      private decimal[] P00524_A385NegValorAtualizado ;
      private long[] P00524_A355NegCpjMatricula ;
      private long[] P00524_A356NegCodigo ;
      private string[] P00524_A364NegInsUsuNome ;
      private bool[] P00524_n364NegInsUsuNome ;
      private string[] P00524_A361NegAgcNome ;
      private bool[] P00524_n361NegAgcNome ;
      private string[] P00524_A359NegPjtNome ;
      private string[] P00524_A351NegCliNomeFamiliar ;
      private string[] P00524_A362NegAssunto ;
      private bool[] P00524_A572NegDel ;
      private Guid[] P00524_A345NegID ;
      private Guid[] P00525_A350NegCliID ;
      private Guid[] P00525_A352NegCpjID ;
      private string[] P00525_A359NegPjtNome ;
      private DateTime[] P00525_A346NegInsData ;
      private decimal[] P00525_A385NegValorAtualizado ;
      private long[] P00525_A355NegCpjMatricula ;
      private long[] P00525_A356NegCodigo ;
      private string[] P00525_A364NegInsUsuNome ;
      private bool[] P00525_n364NegInsUsuNome ;
      private string[] P00525_A361NegAgcNome ;
      private bool[] P00525_n361NegAgcNome ;
      private string[] P00525_A353NegCpjNomFan ;
      private string[] P00525_A351NegCliNomeFamiliar ;
      private string[] P00525_A362NegAssunto ;
      private bool[] P00525_A572NegDel ;
      private Guid[] P00525_A345NegID ;
      private Guid[] P00526_A350NegCliID ;
      private Guid[] P00526_A352NegCpjID ;
      private string[] P00526_A361NegAgcNome ;
      private bool[] P00526_n361NegAgcNome ;
      private DateTime[] P00526_A346NegInsData ;
      private decimal[] P00526_A385NegValorAtualizado ;
      private long[] P00526_A355NegCpjMatricula ;
      private long[] P00526_A356NegCodigo ;
      private string[] P00526_A364NegInsUsuNome ;
      private bool[] P00526_n364NegInsUsuNome ;
      private string[] P00526_A359NegPjtNome ;
      private string[] P00526_A353NegCpjNomFan ;
      private string[] P00526_A351NegCliNomeFamiliar ;
      private string[] P00526_A362NegAssunto ;
      private bool[] P00526_A572NegDel ;
      private Guid[] P00526_A345NegID ;
      private Guid[] P00527_A350NegCliID ;
      private Guid[] P00527_A352NegCpjID ;
      private string[] P00527_A364NegInsUsuNome ;
      private bool[] P00527_n364NegInsUsuNome ;
      private DateTime[] P00527_A346NegInsData ;
      private decimal[] P00527_A385NegValorAtualizado ;
      private long[] P00527_A355NegCpjMatricula ;
      private long[] P00527_A356NegCodigo ;
      private string[] P00527_A361NegAgcNome ;
      private bool[] P00527_n361NegAgcNome ;
      private string[] P00527_A359NegPjtNome ;
      private string[] P00527_A353NegCpjNomFan ;
      private string[] P00527_A351NegCliNomeFamiliar ;
      private string[] P00527_A362NegAssunto ;
      private bool[] P00527_A572NegDel ;
      private Guid[] P00527_A345NegID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV49Options ;
      private GxSimpleCollection<string> AV51OptionsDesc ;
      private GxSimpleCollection<string> AV52OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV56GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV57GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV58GridStateDynamicFilter ;
   }

   public class negociopjwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00522( IGxContext context ,
                                             string AV85Core_negociopjwwds_2_filterfulltext ,
                                             string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV88Core_negociopjwwds_5_negassunto1 ,
                                             bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV92Core_negociopjwwds_9_negassunto2 ,
                                             bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV96Core_negociopjwwds_13_negassunto3 ,
                                             long AV97Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV99Core_negociopjwwds_16_tfnegassunto ,
                                             string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV109Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV113Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV115Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[35];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegAssunto, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegAgcNome, T1.NegPjtNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV97Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV97Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (0==AV98Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV98Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV100Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV101Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV103Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV105Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV105Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV106Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV107Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV108Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV109Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV110Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV111Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV111Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV112Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV113Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV114Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV115Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV116Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegAssunto";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00523( IGxContext context ,
                                             string AV85Core_negociopjwwds_2_filterfulltext ,
                                             string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV88Core_negociopjwwds_5_negassunto1 ,
                                             bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV92Core_negociopjwwds_9_negassunto2 ,
                                             bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV96Core_negociopjwwds_13_negassunto3 ,
                                             long AV97Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV99Core_negociopjwwds_16_tfnegassunto ,
                                             string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV109Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV113Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV115Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[35];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegCliNomeFamiliar, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegAgcNome, T1.NegPjtNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV97Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV97Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (0==AV98Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV98Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV100Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV101Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV103Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV105Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV105Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV106Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV107Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV108Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV109Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV110Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV111Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV111Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV112Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV113Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV114Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV115Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV116Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegCliNomeFamiliar";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00524( IGxContext context ,
                                             string AV85Core_negociopjwwds_2_filterfulltext ,
                                             string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV88Core_negociopjwwds_5_negassunto1 ,
                                             bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV92Core_negociopjwwds_9_negassunto2 ,
                                             bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV96Core_negociopjwwds_13_negassunto3 ,
                                             long AV97Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV99Core_negociopjwwds_16_tfnegassunto ,
                                             string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV109Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV113Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV115Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[35];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegAgcNome, T1.NegPjtNome, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV97Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV97Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (0==AV98Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV98Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV100Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV101Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV103Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV105Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV105Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV106Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV107Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV108Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV109Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV110Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV111Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV111Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV112Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV113Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV114Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV115Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV116Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegCpjNomFan";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00525( IGxContext context ,
                                             string AV85Core_negociopjwwds_2_filterfulltext ,
                                             string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV88Core_negociopjwwds_5_negassunto1 ,
                                             bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV92Core_negociopjwwds_9_negassunto2 ,
                                             bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV96Core_negociopjwwds_13_negassunto3 ,
                                             long AV97Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV99Core_negociopjwwds_16_tfnegassunto ,
                                             string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV109Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV113Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV115Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[35];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegPjtNome, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegAgcNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (0==AV97Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV97Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (0==AV98Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV98Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV100Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV101Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV103Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV105Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV105Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV106Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV107Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV108Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV109Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV110Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV111Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV111Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV112Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV113Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV114Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV115Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV116Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegPjtNome";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00526( IGxContext context ,
                                             string AV85Core_negociopjwwds_2_filterfulltext ,
                                             string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV88Core_negociopjwwds_5_negassunto1 ,
                                             bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV92Core_negociopjwwds_9_negassunto2 ,
                                             bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV96Core_negociopjwwds_13_negassunto3 ,
                                             long AV97Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV99Core_negociopjwwds_16_tfnegassunto ,
                                             string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV109Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV113Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV115Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[35];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegAgcNome, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegPjtNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! (0==AV97Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV97Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (0==AV98Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV98Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV100Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV101Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV103Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV105Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV105Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV106Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV107Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV108Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV109Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV110Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV111Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV111Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV112Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV113Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV114Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV115Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV116Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegAgcNome";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00527( IGxContext context ,
                                             string AV85Core_negociopjwwds_2_filterfulltext ,
                                             string AV86Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV87Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV88Core_negociopjwwds_5_negassunto1 ,
                                             bool AV89Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV90Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV91Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV92Core_negociopjwwds_9_negassunto2 ,
                                             bool AV93Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV94Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV95Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV96Core_negociopjwwds_13_negassunto3 ,
                                             long AV97Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV98Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV100Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV99Core_negociopjwwds_16_tfnegassunto ,
                                             string AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV101Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV103Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV105Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV106Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV108Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV107Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV110Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV109Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV111Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV112Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV113Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV114Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV116Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV115Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[35];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegInsUsuNome, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegAgcNome, T1.NegPjtNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV85Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV85Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV87Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV88Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( AV89Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV90Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV91Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV92Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( AV93Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! (0==AV97Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV97Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! (0==AV98Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV98Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV100Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV101Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV103Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV105Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV105Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV106Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV107Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV108Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV109Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV110Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV111Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV111Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV112Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV112Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int11[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV113Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV113Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int11[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV114Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int11[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV115Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int11[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV116Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int11[34] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegInsUsuNome";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00522(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (bool)dynConstraints[42] );
               case 1 :
                     return conditional_P00523(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (bool)dynConstraints[42] );
               case 2 :
                     return conditional_P00524(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (bool)dynConstraints[42] );
               case 3 :
                     return conditional_P00525(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (bool)dynConstraints[42] );
               case 4 :
                     return conditional_P00526(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (bool)dynConstraints[42] );
               case 5 :
                     return conditional_P00527(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (bool)dynConstraints[42] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00522;
          prmP00522 = new Object[] {
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV97Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV98Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV99Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV101Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV103Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV112Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV113Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV114Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV115Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00523;
          prmP00523 = new Object[] {
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV97Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV98Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV99Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV101Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV103Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV112Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV113Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV114Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV115Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00524;
          prmP00524 = new Object[] {
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV97Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV98Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV99Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV101Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV103Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV112Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV113Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV114Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV115Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00525;
          prmP00525 = new Object[] {
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV97Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV98Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV99Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV101Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV103Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV112Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV113Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV114Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV115Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00526;
          prmP00526 = new Object[] {
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV97Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV98Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV99Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV101Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV103Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV112Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV113Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV114Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV115Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00527;
          prmP00527 = new Object[] {
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV88Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV92Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV97Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV98Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV99Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV101Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV103Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV104Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV112Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV113Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV114Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV115Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00522", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00522,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00523", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00523,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00524", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00524,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00525", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00525,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00526", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00526,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00527", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00527,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
       }
    }

 }

}
