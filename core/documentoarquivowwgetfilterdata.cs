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
   public class documentoarquivowwgetfilterdata : GXProcedure
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
            return "documentoarquivoww_Services_Execute" ;
         }

      }

      public documentoarquivowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoarquivowwgetfilterdata( IGxContext context )
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
         this.AV62DDOName = aP0_DDOName;
         this.AV63SearchTxtParms = aP1_SearchTxtParms;
         this.AV64SearchTxtTo = aP2_SearchTxtTo;
         this.AV65OptionsJson = "" ;
         this.AV66OptionsDescJson = "" ;
         this.AV67OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV65OptionsJson;
         aP4_OptionsDescJson=this.AV66OptionsDescJson;
         aP5_OptionIndexesJson=this.AV67OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV67OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         documentoarquivowwgetfilterdata objdocumentoarquivowwgetfilterdata;
         objdocumentoarquivowwgetfilterdata = new documentoarquivowwgetfilterdata();
         objdocumentoarquivowwgetfilterdata.AV62DDOName = aP0_DDOName;
         objdocumentoarquivowwgetfilterdata.AV63SearchTxtParms = aP1_SearchTxtParms;
         objdocumentoarquivowwgetfilterdata.AV64SearchTxtTo = aP2_SearchTxtTo;
         objdocumentoarquivowwgetfilterdata.AV65OptionsJson = "" ;
         objdocumentoarquivowwgetfilterdata.AV66OptionsDescJson = "" ;
         objdocumentoarquivowwgetfilterdata.AV67OptionIndexesJson = "" ;
         objdocumentoarquivowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdocumentoarquivowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objdocumentoarquivowwgetfilterdata);
         aP3_OptionsJson=this.AV65OptionsJson;
         aP4_OptionsDescJson=this.AV66OptionsDescJson;
         aP5_OptionIndexesJson=this.AV67OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentoarquivowwgetfilterdata)stateInfo).executePrivate();
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
         AV52Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV54OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV55OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV49MaxItems = 10;
         AV48PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV63SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV63SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV46SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV63SearchTxtParms)) ? "" : StringUtil.Substring( AV63SearchTxtParms, 3, -1));
         AV47SkipItems = (short)(AV48PageIndex*AV49MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_DOCARQCONTEUDONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCARQCONTEUDONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_DOCARQCONTEUDOEXTENSAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCARQCONTEUDOEXTENSAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_DOCARQOBSERVACAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCARQOBSERVACAOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV65OptionsJson = AV52Options.ToJSonString(false);
         AV66OptionsDescJson = AV54OptionsDesc.ToJSonString(false);
         AV67OptionIndexesJson = AV55OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV57Session.Get("core.DocumentoArquivoWWGridState"), "") == 0 )
         {
            AV59GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoArquivoWWGridState"), null, "", "");
         }
         else
         {
            AV59GridState.FromXml(AV57Session.Get("core.DocumentoArquivoWWGridState"), null, "", "");
         }
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV59GridState.gxTpr_Filtervalues.Count )
         {
            AV60GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV59GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "DOCID_FILTRO") == 0 )
            {
               AV83DocID_Filtro = StringUtil.StrToGuid( AV60GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV68FilterFullText = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME") == 0 )
            {
               AV40TFDocArqConteudoNome = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME_SEL") == 0 )
            {
               AV41TFDocArqConteudoNome_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO") == 0 )
            {
               AV42TFDocArqConteudoExtensao = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO_SEL") == 0 )
            {
               AV43TFDocArqConteudoExtensao_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQINSDATAHORA") == 0 )
            {
               AV19TFDocArqInsDataHora = context.localUtil.CToT( AV60GridStateFilterValue.gxTpr_Value, 2);
               AV20TFDocArqInsDataHora_To = context.localUtil.CToT( AV60GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO") == 0 )
            {
               AV44TFDocArqObservacao = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO_SEL") == 0 )
            {
               AV45TFDocArqObservacao_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "PARM_&DOCID") == 0 )
            {
               AV84DocID = StringUtil.StrToGuid( AV60GridStateFilterValue.gxTpr_Value);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         if ( AV59GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV61GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV59GridState.gxTpr_Dynamicfilters.Item(1));
            AV69DynamicFiltersSelector1 = AV61GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV69DynamicFiltersSelector1, "DOCARQINSDATA") == 0 )
            {
               AV70DynamicFiltersOperator1 = AV61GridStateDynamicFilter.gxTpr_Operator;
               AV71DocArqInsData1 = context.localUtil.CToD( AV61GridStateDynamicFilter.gxTpr_Value, 2);
               AV72DocArqInsData_To1 = context.localUtil.CToD( AV61GridStateDynamicFilter.gxTpr_Valueto, 2);
            }
            if ( AV59GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV73DynamicFiltersEnabled2 = true;
               AV61GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV59GridState.gxTpr_Dynamicfilters.Item(2));
               AV74DynamicFiltersSelector2 = AV61GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV74DynamicFiltersSelector2, "DOCARQINSDATA") == 0 )
               {
                  AV75DynamicFiltersOperator2 = AV61GridStateDynamicFilter.gxTpr_Operator;
                  AV76DocArqInsData2 = context.localUtil.CToD( AV61GridStateDynamicFilter.gxTpr_Value, 2);
                  AV77DocArqInsData_To2 = context.localUtil.CToD( AV61GridStateDynamicFilter.gxTpr_Valueto, 2);
               }
               if ( AV59GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV78DynamicFiltersEnabled3 = true;
                  AV61GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV59GridState.gxTpr_Dynamicfilters.Item(3));
                  AV79DynamicFiltersSelector3 = AV61GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV79DynamicFiltersSelector3, "DOCARQINSDATA") == 0 )
                  {
                     AV80DynamicFiltersOperator3 = AV61GridStateDynamicFilter.gxTpr_Operator;
                     AV81DocArqInsData3 = context.localUtil.CToD( AV61GridStateDynamicFilter.gxTpr_Value, 2);
                     AV82DocArqInsData_To3 = context.localUtil.CToD( AV61GridStateDynamicFilter.gxTpr_Valueto, 2);
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCARQCONTEUDONOMEOPTIONS' Routine */
         returnInSub = false;
         AV40TFDocArqConteudoNome = AV46SearchTxt;
         AV41TFDocArqConteudoNome_Sel = "";
         AV87Core_documentoarquivowwds_1_docid_filtro = AV83DocID_Filtro;
         AV88Core_documentoarquivowwds_2_filterfulltext = AV68FilterFullText;
         AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV69DynamicFiltersSelector1;
         AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV70DynamicFiltersOperator1;
         AV91Core_documentoarquivowwds_5_docarqinsdata1 = AV71DocArqInsData1;
         AV92Core_documentoarquivowwds_6_docarqinsdata_to1 = AV72DocArqInsData_To1;
         AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV73DynamicFiltersEnabled2;
         AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV74DynamicFiltersSelector2;
         AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV75DynamicFiltersOperator2;
         AV96Core_documentoarquivowwds_10_docarqinsdata2 = AV76DocArqInsData2;
         AV97Core_documentoarquivowwds_11_docarqinsdata_to2 = AV77DocArqInsData_To2;
         AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV78DynamicFiltersEnabled3;
         AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV79DynamicFiltersSelector3;
         AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV80DynamicFiltersOperator3;
         AV101Core_documentoarquivowwds_15_docarqinsdata3 = AV81DocArqInsData3;
         AV102Core_documentoarquivowwds_16_docarqinsdata_to3 = AV82DocArqInsData_To3;
         AV103Core_documentoarquivowwds_17_tfdocarqconteudonome = AV40TFDocArqConteudoNome;
         AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV41TFDocArqConteudoNome_Sel;
         AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV42TFDocArqConteudoExtensao;
         AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV43TFDocArqConteudoExtensao_Sel;
         AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV19TFDocArqInsDataHora;
         AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV20TFDocArqInsDataHora_To;
         AV109Core_documentoarquivowwds_23_tfdocarqobservacao = AV44TFDocArqObservacao;
         AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV45TFDocArqObservacao_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV88Core_documentoarquivowwds_2_filterfulltext ,
                                              AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                              AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                              AV91Core_documentoarquivowwds_5_docarqinsdata1 ,
                                              AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                              AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                              AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                              AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                              AV96Core_documentoarquivowwds_10_docarqinsdata2 ,
                                              AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                              AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                              AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                              AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                              AV101Core_documentoarquivowwds_15_docarqinsdata3 ,
                                              AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                              AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                              AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                              AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                              AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                              AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                              AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                              AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                              AV109Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A324DocArqObservacao ,
                                              A308DocArqInsData ,
                                              A310DocArqInsDataHora ,
                                              AV84DocID ,
                                              A289DocID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV103Core_documentoarquivowwds_17_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV103Core_documentoarquivowwds_17_tfdocarqconteudonome), "%", "");
         lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao), "%", "");
         lV109Core_documentoarquivowwds_23_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV109Core_documentoarquivowwds_23_tfdocarqobservacao), "%", "");
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {AV84DocID, lV88Core_documentoarquivowwds_2_filterfulltext, lV88Core_documentoarquivowwds_2_filterfulltext, lV88Core_documentoarquivowwds_2_filterfulltext, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV92Core_documentoarquivowwds_6_docarqinsdata_to1, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV97Core_documentoarquivowwds_11_docarqinsdata_to2, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV102Core_documentoarquivowwds_16_docarqinsdata_to3, lV103Core_documentoarquivowwds_17_tfdocarqconteudonome, AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao, AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora, AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to, lV109Core_documentoarquivowwds_23_tfdocarqobservacao, AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6N2 = false;
            A289DocID = P006N2_A289DocID[0];
            A322DocArqConteudoNome = P006N2_A322DocArqConteudoNome[0];
            A310DocArqInsDataHora = P006N2_A310DocArqInsDataHora[0];
            A308DocArqInsData = P006N2_A308DocArqInsData[0];
            A324DocArqObservacao = P006N2_A324DocArqObservacao[0];
            n324DocArqObservacao = P006N2_n324DocArqObservacao[0];
            A323DocArqConteudoExtensao = P006N2_A323DocArqConteudoExtensao[0];
            A307DocArqSeq = P006N2_A307DocArqSeq[0];
            AV56count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P006N2_A289DocID[0] == A289DocID ) && ( StringUtil.StrCmp(P006N2_A322DocArqConteudoNome[0], A322DocArqConteudoNome) == 0 ) )
            {
               BRK6N2 = false;
               A307DocArqSeq = P006N2_A307DocArqSeq[0];
               AV56count = (long)(AV56count+1);
               BRK6N2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A322DocArqConteudoNome)) ? "<#Empty#>" : A322DocArqConteudoNome);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRK6N2 )
            {
               BRK6N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDOCARQCONTEUDOEXTENSAOOPTIONS' Routine */
         returnInSub = false;
         AV42TFDocArqConteudoExtensao = AV46SearchTxt;
         AV43TFDocArqConteudoExtensao_Sel = "";
         AV87Core_documentoarquivowwds_1_docid_filtro = AV83DocID_Filtro;
         AV88Core_documentoarquivowwds_2_filterfulltext = AV68FilterFullText;
         AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV69DynamicFiltersSelector1;
         AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV70DynamicFiltersOperator1;
         AV91Core_documentoarquivowwds_5_docarqinsdata1 = AV71DocArqInsData1;
         AV92Core_documentoarquivowwds_6_docarqinsdata_to1 = AV72DocArqInsData_To1;
         AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV73DynamicFiltersEnabled2;
         AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV74DynamicFiltersSelector2;
         AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV75DynamicFiltersOperator2;
         AV96Core_documentoarquivowwds_10_docarqinsdata2 = AV76DocArqInsData2;
         AV97Core_documentoarquivowwds_11_docarqinsdata_to2 = AV77DocArqInsData_To2;
         AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV78DynamicFiltersEnabled3;
         AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV79DynamicFiltersSelector3;
         AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV80DynamicFiltersOperator3;
         AV101Core_documentoarquivowwds_15_docarqinsdata3 = AV81DocArqInsData3;
         AV102Core_documentoarquivowwds_16_docarqinsdata_to3 = AV82DocArqInsData_To3;
         AV103Core_documentoarquivowwds_17_tfdocarqconteudonome = AV40TFDocArqConteudoNome;
         AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV41TFDocArqConteudoNome_Sel;
         AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV42TFDocArqConteudoExtensao;
         AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV43TFDocArqConteudoExtensao_Sel;
         AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV19TFDocArqInsDataHora;
         AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV20TFDocArqInsDataHora_To;
         AV109Core_documentoarquivowwds_23_tfdocarqobservacao = AV44TFDocArqObservacao;
         AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV45TFDocArqObservacao_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV88Core_documentoarquivowwds_2_filterfulltext ,
                                              AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                              AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                              AV91Core_documentoarquivowwds_5_docarqinsdata1 ,
                                              AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                              AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                              AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                              AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                              AV96Core_documentoarquivowwds_10_docarqinsdata2 ,
                                              AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                              AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                              AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                              AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                              AV101Core_documentoarquivowwds_15_docarqinsdata3 ,
                                              AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                              AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                              AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                              AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                              AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                              AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                              AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                              AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                              AV109Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A324DocArqObservacao ,
                                              A308DocArqInsData ,
                                              A310DocArqInsDataHora ,
                                              A289DocID ,
                                              AV84DocID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV103Core_documentoarquivowwds_17_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV103Core_documentoarquivowwds_17_tfdocarqconteudonome), "%", "");
         lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao), "%", "");
         lV109Core_documentoarquivowwds_23_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV109Core_documentoarquivowwds_23_tfdocarqobservacao), "%", "");
         /* Using cursor P006N3 */
         pr_default.execute(1, new Object[] {AV84DocID, lV88Core_documentoarquivowwds_2_filterfulltext, lV88Core_documentoarquivowwds_2_filterfulltext, lV88Core_documentoarquivowwds_2_filterfulltext, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV92Core_documentoarquivowwds_6_docarqinsdata_to1, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV97Core_documentoarquivowwds_11_docarqinsdata_to2, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV102Core_documentoarquivowwds_16_docarqinsdata_to3, lV103Core_documentoarquivowwds_17_tfdocarqconteudonome, AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao, AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora, AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to, lV109Core_documentoarquivowwds_23_tfdocarqobservacao, AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6N4 = false;
            A289DocID = P006N3_A289DocID[0];
            A323DocArqConteudoExtensao = P006N3_A323DocArqConteudoExtensao[0];
            A310DocArqInsDataHora = P006N3_A310DocArqInsDataHora[0];
            A308DocArqInsData = P006N3_A308DocArqInsData[0];
            A324DocArqObservacao = P006N3_A324DocArqObservacao[0];
            n324DocArqObservacao = P006N3_n324DocArqObservacao[0];
            A322DocArqConteudoNome = P006N3_A322DocArqConteudoNome[0];
            A307DocArqSeq = P006N3_A307DocArqSeq[0];
            AV56count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006N3_A323DocArqConteudoExtensao[0], A323DocArqConteudoExtensao) == 0 ) )
            {
               BRK6N4 = false;
               A289DocID = P006N3_A289DocID[0];
               A307DocArqSeq = P006N3_A307DocArqSeq[0];
               AV56count = (long)(AV56count+1);
               BRK6N4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A323DocArqConteudoExtensao)) ? "<#Empty#>" : A323DocArqConteudoExtensao);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRK6N4 )
            {
               BRK6N4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADDOCARQOBSERVACAOOPTIONS' Routine */
         returnInSub = false;
         AV44TFDocArqObservacao = AV46SearchTxt;
         AV45TFDocArqObservacao_Sel = "";
         AV87Core_documentoarquivowwds_1_docid_filtro = AV83DocID_Filtro;
         AV88Core_documentoarquivowwds_2_filterfulltext = AV68FilterFullText;
         AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV69DynamicFiltersSelector1;
         AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV70DynamicFiltersOperator1;
         AV91Core_documentoarquivowwds_5_docarqinsdata1 = AV71DocArqInsData1;
         AV92Core_documentoarquivowwds_6_docarqinsdata_to1 = AV72DocArqInsData_To1;
         AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV73DynamicFiltersEnabled2;
         AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV74DynamicFiltersSelector2;
         AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV75DynamicFiltersOperator2;
         AV96Core_documentoarquivowwds_10_docarqinsdata2 = AV76DocArqInsData2;
         AV97Core_documentoarquivowwds_11_docarqinsdata_to2 = AV77DocArqInsData_To2;
         AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV78DynamicFiltersEnabled3;
         AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV79DynamicFiltersSelector3;
         AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV80DynamicFiltersOperator3;
         AV101Core_documentoarquivowwds_15_docarqinsdata3 = AV81DocArqInsData3;
         AV102Core_documentoarquivowwds_16_docarqinsdata_to3 = AV82DocArqInsData_To3;
         AV103Core_documentoarquivowwds_17_tfdocarqconteudonome = AV40TFDocArqConteudoNome;
         AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV41TFDocArqConteudoNome_Sel;
         AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV42TFDocArqConteudoExtensao;
         AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV43TFDocArqConteudoExtensao_Sel;
         AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV19TFDocArqInsDataHora;
         AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV20TFDocArqInsDataHora_To;
         AV109Core_documentoarquivowwds_23_tfdocarqobservacao = AV44TFDocArqObservacao;
         AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV45TFDocArqObservacao_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV88Core_documentoarquivowwds_2_filterfulltext ,
                                              AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                              AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                              AV91Core_documentoarquivowwds_5_docarqinsdata1 ,
                                              AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                              AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                              AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                              AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                              AV96Core_documentoarquivowwds_10_docarqinsdata2 ,
                                              AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                              AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                              AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                              AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                              AV101Core_documentoarquivowwds_15_docarqinsdata3 ,
                                              AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                              AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                              AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                              AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                              AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                              AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                              AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                              AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                              AV109Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A324DocArqObservacao ,
                                              A308DocArqInsData ,
                                              A310DocArqInsDataHora ,
                                              A289DocID ,
                                              AV84DocID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV88Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV103Core_documentoarquivowwds_17_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV103Core_documentoarquivowwds_17_tfdocarqconteudonome), "%", "");
         lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao), "%", "");
         lV109Core_documentoarquivowwds_23_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV109Core_documentoarquivowwds_23_tfdocarqobservacao), "%", "");
         /* Using cursor P006N4 */
         pr_default.execute(2, new Object[] {AV84DocID, lV88Core_documentoarquivowwds_2_filterfulltext, lV88Core_documentoarquivowwds_2_filterfulltext, lV88Core_documentoarquivowwds_2_filterfulltext, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV91Core_documentoarquivowwds_5_docarqinsdata1, AV92Core_documentoarquivowwds_6_docarqinsdata_to1, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV96Core_documentoarquivowwds_10_docarqinsdata2, AV97Core_documentoarquivowwds_11_docarqinsdata_to2, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV101Core_documentoarquivowwds_15_docarqinsdata3, AV102Core_documentoarquivowwds_16_docarqinsdata_to3, lV103Core_documentoarquivowwds_17_tfdocarqconteudonome, AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao, AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora, AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to, lV109Core_documentoarquivowwds_23_tfdocarqobservacao, AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6N6 = false;
            A289DocID = P006N4_A289DocID[0];
            A324DocArqObservacao = P006N4_A324DocArqObservacao[0];
            n324DocArqObservacao = P006N4_n324DocArqObservacao[0];
            A310DocArqInsDataHora = P006N4_A310DocArqInsDataHora[0];
            A308DocArqInsData = P006N4_A308DocArqInsData[0];
            A323DocArqConteudoExtensao = P006N4_A323DocArqConteudoExtensao[0];
            A322DocArqConteudoNome = P006N4_A322DocArqConteudoNome[0];
            A307DocArqSeq = P006N4_A307DocArqSeq[0];
            AV56count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006N4_A324DocArqObservacao[0], A324DocArqObservacao) == 0 ) )
            {
               BRK6N6 = false;
               A289DocID = P006N4_A289DocID[0];
               A307DocArqSeq = P006N4_A307DocArqSeq[0];
               AV56count = (long)(AV56count+1);
               BRK6N6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A324DocArqObservacao)) ? "<#Empty#>" : A324DocArqObservacao);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRK6N6 )
            {
               BRK6N6 = true;
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
         AV65OptionsJson = "";
         AV66OptionsDescJson = "";
         AV67OptionIndexesJson = "";
         AV52Options = new GxSimpleCollection<string>();
         AV54OptionsDesc = new GxSimpleCollection<string>();
         AV55OptionIndexes = new GxSimpleCollection<string>();
         AV46SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV57Session = context.GetSession();
         AV59GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV60GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV83DocID_Filtro = Guid.Empty;
         AV68FilterFullText = "";
         AV40TFDocArqConteudoNome = "";
         AV41TFDocArqConteudoNome_Sel = "";
         AV42TFDocArqConteudoExtensao = "";
         AV43TFDocArqConteudoExtensao_Sel = "";
         AV19TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV20TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV44TFDocArqObservacao = "";
         AV45TFDocArqObservacao_Sel = "";
         AV84DocID = Guid.Empty;
         AV61GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV69DynamicFiltersSelector1 = "";
         AV71DocArqInsData1 = DateTime.MinValue;
         AV72DocArqInsData_To1 = DateTime.MinValue;
         AV74DynamicFiltersSelector2 = "";
         AV76DocArqInsData2 = DateTime.MinValue;
         AV77DocArqInsData_To2 = DateTime.MinValue;
         AV79DynamicFiltersSelector3 = "";
         AV81DocArqInsData3 = DateTime.MinValue;
         AV82DocArqInsData_To3 = DateTime.MinValue;
         AV87Core_documentoarquivowwds_1_docid_filtro = Guid.Empty;
         AV88Core_documentoarquivowwds_2_filterfulltext = "";
         AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 = "";
         AV91Core_documentoarquivowwds_5_docarqinsdata1 = DateTime.MinValue;
         AV92Core_documentoarquivowwds_6_docarqinsdata_to1 = DateTime.MinValue;
         AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 = "";
         AV96Core_documentoarquivowwds_10_docarqinsdata2 = DateTime.MinValue;
         AV97Core_documentoarquivowwds_11_docarqinsdata_to2 = DateTime.MinValue;
         AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 = "";
         AV101Core_documentoarquivowwds_15_docarqinsdata3 = DateTime.MinValue;
         AV102Core_documentoarquivowwds_16_docarqinsdata_to3 = DateTime.MinValue;
         AV103Core_documentoarquivowwds_17_tfdocarqconteudonome = "";
         AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = "";
         AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = "";
         AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = "";
         AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora = (DateTime)(DateTime.MinValue);
         AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV109Core_documentoarquivowwds_23_tfdocarqobservacao = "";
         AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel = "";
         scmdbuf = "";
         lV88Core_documentoarquivowwds_2_filterfulltext = "";
         lV103Core_documentoarquivowwds_17_tfdocarqconteudonome = "";
         lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao = "";
         lV109Core_documentoarquivowwds_23_tfdocarqobservacao = "";
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A324DocArqObservacao = "";
         A308DocArqInsData = DateTime.MinValue;
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A289DocID = Guid.Empty;
         P006N2_A289DocID = new Guid[] {Guid.Empty} ;
         P006N2_A322DocArqConteudoNome = new string[] {""} ;
         P006N2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006N2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P006N2_A324DocArqObservacao = new string[] {""} ;
         P006N2_n324DocArqObservacao = new bool[] {false} ;
         P006N2_A323DocArqConteudoExtensao = new string[] {""} ;
         P006N2_A307DocArqSeq = new short[1] ;
         AV51Option = "";
         P006N3_A289DocID = new Guid[] {Guid.Empty} ;
         P006N3_A323DocArqConteudoExtensao = new string[] {""} ;
         P006N3_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006N3_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P006N3_A324DocArqObservacao = new string[] {""} ;
         P006N3_n324DocArqObservacao = new bool[] {false} ;
         P006N3_A322DocArqConteudoNome = new string[] {""} ;
         P006N3_A307DocArqSeq = new short[1] ;
         P006N4_A289DocID = new Guid[] {Guid.Empty} ;
         P006N4_A324DocArqObservacao = new string[] {""} ;
         P006N4_n324DocArqObservacao = new bool[] {false} ;
         P006N4_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006N4_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P006N4_A323DocArqConteudoExtensao = new string[] {""} ;
         P006N4_A322DocArqConteudoNome = new string[] {""} ;
         P006N4_A307DocArqSeq = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006N2_A289DocID, P006N2_A322DocArqConteudoNome, P006N2_A310DocArqInsDataHora, P006N2_A308DocArqInsData, P006N2_A324DocArqObservacao, P006N2_n324DocArqObservacao, P006N2_A323DocArqConteudoExtensao, P006N2_A307DocArqSeq
               }
               , new Object[] {
               P006N3_A289DocID, P006N3_A323DocArqConteudoExtensao, P006N3_A310DocArqInsDataHora, P006N3_A308DocArqInsData, P006N3_A324DocArqObservacao, P006N3_n324DocArqObservacao, P006N3_A322DocArqConteudoNome, P006N3_A307DocArqSeq
               }
               , new Object[] {
               P006N4_A289DocID, P006N4_A324DocArqObservacao, P006N4_n324DocArqObservacao, P006N4_A310DocArqInsDataHora, P006N4_A308DocArqInsData, P006N4_A323DocArqConteudoExtensao, P006N4_A322DocArqConteudoNome, P006N4_A307DocArqSeq
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV49MaxItems ;
      private short AV48PageIndex ;
      private short AV47SkipItems ;
      private short AV70DynamicFiltersOperator1 ;
      private short AV75DynamicFiltersOperator2 ;
      private short AV80DynamicFiltersOperator3 ;
      private short AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ;
      private short AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ;
      private short AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ;
      private short A307DocArqSeq ;
      private int AV85GXV1 ;
      private long AV56count ;
      private string scmdbuf ;
      private DateTime AV19TFDocArqInsDataHora ;
      private DateTime AV20TFDocArqInsDataHora_To ;
      private DateTime AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ;
      private DateTime AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime AV71DocArqInsData1 ;
      private DateTime AV72DocArqInsData_To1 ;
      private DateTime AV76DocArqInsData2 ;
      private DateTime AV77DocArqInsData_To2 ;
      private DateTime AV81DocArqInsData3 ;
      private DateTime AV82DocArqInsData_To3 ;
      private DateTime AV91Core_documentoarquivowwds_5_docarqinsdata1 ;
      private DateTime AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ;
      private DateTime AV96Core_documentoarquivowwds_10_docarqinsdata2 ;
      private DateTime AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ;
      private DateTime AV101Core_documentoarquivowwds_15_docarqinsdata3 ;
      private DateTime AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ;
      private DateTime A308DocArqInsData ;
      private bool returnInSub ;
      private bool AV73DynamicFiltersEnabled2 ;
      private bool AV78DynamicFiltersEnabled3 ;
      private bool AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ;
      private bool AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ;
      private bool BRK6N2 ;
      private bool n324DocArqObservacao ;
      private bool BRK6N4 ;
      private bool BRK6N6 ;
      private string AV65OptionsJson ;
      private string AV66OptionsDescJson ;
      private string AV67OptionIndexesJson ;
      private string AV62DDOName ;
      private string AV63SearchTxtParms ;
      private string AV64SearchTxtTo ;
      private string AV46SearchTxt ;
      private string AV68FilterFullText ;
      private string AV40TFDocArqConteudoNome ;
      private string AV41TFDocArqConteudoNome_Sel ;
      private string AV42TFDocArqConteudoExtensao ;
      private string AV43TFDocArqConteudoExtensao_Sel ;
      private string AV44TFDocArqObservacao ;
      private string AV45TFDocArqObservacao_Sel ;
      private string AV69DynamicFiltersSelector1 ;
      private string AV74DynamicFiltersSelector2 ;
      private string AV79DynamicFiltersSelector3 ;
      private string AV88Core_documentoarquivowwds_2_filterfulltext ;
      private string AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ;
      private string AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ;
      private string AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ;
      private string AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ;
      private string AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ;
      private string AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ;
      private string AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ;
      private string AV109Core_documentoarquivowwds_23_tfdocarqobservacao ;
      private string AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ;
      private string lV88Core_documentoarquivowwds_2_filterfulltext ;
      private string lV103Core_documentoarquivowwds_17_tfdocarqconteudonome ;
      private string lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ;
      private string lV109Core_documentoarquivowwds_23_tfdocarqobservacao ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private string AV51Option ;
      private Guid AV83DocID_Filtro ;
      private Guid AV84DocID ;
      private Guid AV87Core_documentoarquivowwds_1_docid_filtro ;
      private Guid A289DocID ;
      private IGxSession AV57Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006N2_A289DocID ;
      private string[] P006N2_A322DocArqConteudoNome ;
      private DateTime[] P006N2_A310DocArqInsDataHora ;
      private DateTime[] P006N2_A308DocArqInsData ;
      private string[] P006N2_A324DocArqObservacao ;
      private bool[] P006N2_n324DocArqObservacao ;
      private string[] P006N2_A323DocArqConteudoExtensao ;
      private short[] P006N2_A307DocArqSeq ;
      private Guid[] P006N3_A289DocID ;
      private string[] P006N3_A323DocArqConteudoExtensao ;
      private DateTime[] P006N3_A310DocArqInsDataHora ;
      private DateTime[] P006N3_A308DocArqInsData ;
      private string[] P006N3_A324DocArqObservacao ;
      private bool[] P006N3_n324DocArqObservacao ;
      private string[] P006N3_A322DocArqConteudoNome ;
      private short[] P006N3_A307DocArqSeq ;
      private Guid[] P006N4_A289DocID ;
      private string[] P006N4_A324DocArqObservacao ;
      private bool[] P006N4_n324DocArqObservacao ;
      private DateTime[] P006N4_A310DocArqInsDataHora ;
      private DateTime[] P006N4_A308DocArqInsData ;
      private string[] P006N4_A323DocArqConteudoExtensao ;
      private string[] P006N4_A322DocArqConteudoNome ;
      private short[] P006N4_A307DocArqSeq ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV52Options ;
      private GxSimpleCollection<string> AV54OptionsDesc ;
      private GxSimpleCollection<string> AV55OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV59GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV60GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV61GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class documentoarquivowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006N2( IGxContext context ,
                                             string AV88Core_documentoarquivowwds_2_filterfulltext ,
                                             string AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                             short AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                             DateTime AV91Core_documentoarquivowwds_5_docarqinsdata1 ,
                                             DateTime AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                             bool AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                             string AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                             short AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV96Core_documentoarquivowwds_10_docarqinsdata2 ,
                                             DateTime AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                             bool AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                             string AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                             short AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                             DateTime AV101Core_documentoarquivowwds_15_docarqinsdata3 ,
                                             DateTime AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                             string AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                             string AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                             string AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                             string AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                             DateTime AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                             DateTime AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                             string AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                             string AV109Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             string A324DocArqObservacao ,
                                             DateTime A308DocArqInsData ,
                                             DateTime A310DocArqInsDataHora ,
                                             Guid AV84DocID ,
                                             Guid A289DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[27];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DocID, DocArqConteudoNome, DocArqInsDataHora, DocArqInsData, DocArqObservacao, DocArqConteudoExtensao, DocArqSeq FROM tb_documento_arquivo";
         AddWhere(sWhereString, "(DocID = :AV84DocID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocArqConteudoNome like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext) or ( DocArqConteudoExtensao like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext) or ( DocArqObservacao like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV92Core_documentoarquivowwds_6_docarqinsdata_to1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV92Core_documentoarquivowwds_6_docarqinsdata_to1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV97Core_documentoarquivowwds_11_docarqinsdata_to2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV97Core_documentoarquivowwds_11_docarqinsdata_to2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV102Core_documentoarquivowwds_16_docarqinsdata_to3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV102Core_documentoarquivowwds_16_docarqinsdata_to3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_documentoarquivowwds_17_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome like :lV103Core_documentoarquivowwds_17_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome = ( :AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao like :lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao = ( :AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( StringUtil.StrCmp(AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora >= :AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora <= :AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_documentoarquivowwds_23_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao like :lV109Core_documentoarquivowwds_23_tfdocarqobservacao)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao = ( :AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocID, DocArqConteudoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006N3( IGxContext context ,
                                             string AV88Core_documentoarquivowwds_2_filterfulltext ,
                                             string AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                             short AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                             DateTime AV91Core_documentoarquivowwds_5_docarqinsdata1 ,
                                             DateTime AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                             bool AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                             string AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                             short AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV96Core_documentoarquivowwds_10_docarqinsdata2 ,
                                             DateTime AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                             bool AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                             string AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                             short AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                             DateTime AV101Core_documentoarquivowwds_15_docarqinsdata3 ,
                                             DateTime AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                             string AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                             string AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                             string AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                             string AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                             DateTime AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                             DateTime AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                             string AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                             string AV109Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             string A324DocArqObservacao ,
                                             DateTime A308DocArqInsData ,
                                             DateTime A310DocArqInsDataHora ,
                                             Guid A289DocID ,
                                             Guid AV84DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[27];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT DocID, DocArqConteudoExtensao, DocArqInsDataHora, DocArqInsData, DocArqObservacao, DocArqConteudoNome, DocArqSeq FROM tb_documento_arquivo";
         AddWhere(sWhereString, "(DocID = :AV84DocID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocArqConteudoNome like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext) or ( DocArqConteudoExtensao like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext) or ( DocArqObservacao like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV92Core_documentoarquivowwds_6_docarqinsdata_to1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV92Core_documentoarquivowwds_6_docarqinsdata_to1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV97Core_documentoarquivowwds_11_docarqinsdata_to2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV97Core_documentoarquivowwds_11_docarqinsdata_to2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV102Core_documentoarquivowwds_16_docarqinsdata_to3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV102Core_documentoarquivowwds_16_docarqinsdata_to3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_documentoarquivowwds_17_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome like :lV103Core_documentoarquivowwds_17_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome = ( :AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao like :lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao = ( :AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora >= :AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora <= :AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_documentoarquivowwds_23_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao like :lV109Core_documentoarquivowwds_23_tfdocarqobservacao)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao = ( :AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocArqConteudoExtensao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006N4( IGxContext context ,
                                             string AV88Core_documentoarquivowwds_2_filterfulltext ,
                                             string AV89Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                             short AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                             DateTime AV91Core_documentoarquivowwds_5_docarqinsdata1 ,
                                             DateTime AV92Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                             bool AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                             string AV94Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                             short AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV96Core_documentoarquivowwds_10_docarqinsdata2 ,
                                             DateTime AV97Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                             bool AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                             string AV99Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                             short AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                             DateTime AV101Core_documentoarquivowwds_15_docarqinsdata3 ,
                                             DateTime AV102Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                             string AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                             string AV103Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                             string AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                             string AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                             DateTime AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                             DateTime AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                             string AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                             string AV109Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             string A324DocArqObservacao ,
                                             DateTime A308DocArqInsData ,
                                             DateTime A310DocArqInsDataHora ,
                                             Guid A289DocID ,
                                             Guid AV84DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[27];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT DocID, DocArqObservacao, DocArqInsDataHora, DocArqInsData, DocArqConteudoExtensao, DocArqConteudoNome, DocArqSeq FROM tb_documento_arquivo";
         AddWhere(sWhereString, "(DocID = :AV84DocID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_documentoarquivowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocArqConteudoNome like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext) or ( DocArqConteudoExtensao like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext) or ( DocArqObservacao like '%' || :lV88Core_documentoarquivowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV91Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV91Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV90Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV92Core_documentoarquivowwds_6_docarqinsdata_to1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV92Core_documentoarquivowwds_6_docarqinsdata_to1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV96Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV96Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV93Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV95Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV97Core_documentoarquivowwds_11_docarqinsdata_to2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV97Core_documentoarquivowwds_11_docarqinsdata_to2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV101Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV101Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV98Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV100Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV102Core_documentoarquivowwds_16_docarqinsdata_to3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV102Core_documentoarquivowwds_16_docarqinsdata_to3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_documentoarquivowwds_17_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome like :lV103Core_documentoarquivowwds_17_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome = ( :AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao like :lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao = ( :AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( StringUtil.StrCmp(AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora >= :AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora <= :AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_documentoarquivowwds_23_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao like :lV109Core_documentoarquivowwds_23_tfdocarqobservacao)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao = ( :AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocArqObservacao";
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
                     return conditional_P006N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (Guid)dynConstraints[28] , (Guid)dynConstraints[29] );
               case 1 :
                     return conditional_P006N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (Guid)dynConstraints[28] , (Guid)dynConstraints[29] );
               case 2 :
                     return conditional_P006N4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (Guid)dynConstraints[28] , (Guid)dynConstraints[29] );
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
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("AV84DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV92Core_documentoarquivowwds_6_docarqinsdata_to1",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV97Core_documentoarquivowwds_11_docarqinsdata_to2",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV102Core_documentoarquivowwds_16_docarqinsdata_to3",GXType.Date,8,0) ,
          new ParDef("lV103Core_documentoarquivowwds_17_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV109Core_documentoarquivowwds_23_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          Object[] prmP006N3;
          prmP006N3 = new Object[] {
          new ParDef("AV84DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV92Core_documentoarquivowwds_6_docarqinsdata_to1",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV97Core_documentoarquivowwds_11_docarqinsdata_to2",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV102Core_documentoarquivowwds_16_docarqinsdata_to3",GXType.Date,8,0) ,
          new ParDef("lV103Core_documentoarquivowwds_17_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV109Core_documentoarquivowwds_23_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          Object[] prmP006N4;
          prmP006N4 = new Object[] {
          new ParDef("AV84DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV91Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV92Core_documentoarquivowwds_6_docarqinsdata_to1",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV96Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV97Core_documentoarquivowwds_11_docarqinsdata_to2",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV101Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV102Core_documentoarquivowwds_16_docarqinsdata_to3",GXType.Date,8,0) ,
          new ParDef("lV103Core_documentoarquivowwds_17_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV104Core_documentoarquivowwds_18_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV105Core_documentoarquivowwds_19_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV106Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV107Core_documentoarquivowwds_21_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV108Core_documentoarquivowwds_22_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV109Core_documentoarquivowwds_23_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV110Core_documentoarquivowwds_24_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
