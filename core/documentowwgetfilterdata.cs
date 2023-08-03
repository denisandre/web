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
   public class documentowwgetfilterdata : GXProcedure
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
            return "documentoww_Services_Execute" ;
         }

      }

      public documentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentowwgetfilterdata( IGxContext context )
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
         documentowwgetfilterdata objdocumentowwgetfilterdata;
         objdocumentowwgetfilterdata = new documentowwgetfilterdata();
         objdocumentowwgetfilterdata.AV33DDOName = aP0_DDOName;
         objdocumentowwgetfilterdata.AV34SearchTxtParms = aP1_SearchTxtParms;
         objdocumentowwgetfilterdata.AV35SearchTxtTo = aP2_SearchTxtTo;
         objdocumentowwgetfilterdata.AV36OptionsJson = "" ;
         objdocumentowwgetfilterdata.AV37OptionsDescJson = "" ;
         objdocumentowwgetfilterdata.AV38OptionIndexesJson = "" ;
         objdocumentowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdocumentowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objdocumentowwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_DOCTIPONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCTIPONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_DOCNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCNOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.DocumentoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.DocumentoWWGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "DOCORIGEM_FILTRO") == 0 )
            {
               AV54DocOrigem_Filtro = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "DOCORIGEMID_FILTRO") == 0 )
            {
               AV55DocOrigemID_Filtro = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME") == 0 )
            {
               AV13TFDocTipoNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME_SEL") == 0 )
            {
               AV14TFDocTipoNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCNOME") == 0 )
            {
               AV11TFDocNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCNOME_SEL") == 0 )
            {
               AV12TFDocNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCVERSAO") == 0 )
            {
               AV60TFDocVersao = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV61TFDocVersao_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCINSDATAHORA") == 0 )
            {
               AV15TFDocInsDataHora = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, 2);
               AV16TFDocInsDataHora_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCCONTRATO_SEL") == 0 )
            {
               AV58TFDocContrato_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDOCASSINADO_SEL") == 0 )
            {
               AV59TFDocAssinado_Sel = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&DOCORIGEM") == 0 )
            {
               AV56DocOrigem = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PARM_&DOCORIGEMID") == 0 )
            {
               AV57DocOrigemID = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "DOCVERSAO") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42DocVersao1 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV43DocTipoSigla1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "DOCVERSAO") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV47DocVersao2 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV48DocTipoSigla2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "DOCVERSAO") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV52DocVersao3 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV53DocTipoSigla3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCTIPONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFDocTipoNome = AV17SearchTxt;
         AV14TFDocTipoNome_Sel = "";
         AV64Core_documentowwds_1_docorigem_filtro = AV54DocOrigem_Filtro;
         AV65Core_documentowwds_2_docorigemid_filtro = AV55DocOrigemID_Filtro;
         AV66Core_documentowwds_3_filterfulltext = AV39FilterFullText;
         AV67Core_documentowwds_4_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV68Core_documentowwds_5_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV69Core_documentowwds_6_docversao1 = AV42DocVersao1;
         AV70Core_documentowwds_7_doctiposigla1 = AV43DocTipoSigla1;
         AV71Core_documentowwds_8_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV72Core_documentowwds_9_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV73Core_documentowwds_10_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV74Core_documentowwds_11_docversao2 = AV47DocVersao2;
         AV75Core_documentowwds_12_doctiposigla2 = AV48DocTipoSigla2;
         AV76Core_documentowwds_13_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV77Core_documentowwds_14_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV78Core_documentowwds_15_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV79Core_documentowwds_16_docversao3 = AV52DocVersao3;
         AV80Core_documentowwds_17_doctiposigla3 = AV53DocTipoSigla3;
         AV81Core_documentowwds_18_tfdoctiponome = AV13TFDocTipoNome;
         AV82Core_documentowwds_19_tfdoctiponome_sel = AV14TFDocTipoNome_Sel;
         AV83Core_documentowwds_20_tfdocnome = AV11TFDocNome;
         AV84Core_documentowwds_21_tfdocnome_sel = AV12TFDocNome_Sel;
         AV85Core_documentowwds_22_tfdocversao = AV60TFDocVersao;
         AV86Core_documentowwds_23_tfdocversao_to = AV61TFDocVersao_To;
         AV87Core_documentowwds_24_tfdocinsdatahora = AV15TFDocInsDataHora;
         AV88Core_documentowwds_25_tfdocinsdatahora_to = AV16TFDocInsDataHora_To;
         AV89Core_documentowwds_26_tfdoccontrato_sel = AV58TFDocContrato_Sel;
         AV90Core_documentowwds_27_tfdocassinado_sel = AV59TFDocAssinado_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Core_documentowwds_3_filterfulltext ,
                                              AV67Core_documentowwds_4_dynamicfiltersselector1 ,
                                              AV68Core_documentowwds_5_dynamicfiltersoperator1 ,
                                              AV69Core_documentowwds_6_docversao1 ,
                                              AV70Core_documentowwds_7_doctiposigla1 ,
                                              AV71Core_documentowwds_8_dynamicfiltersenabled2 ,
                                              AV72Core_documentowwds_9_dynamicfiltersselector2 ,
                                              AV73Core_documentowwds_10_dynamicfiltersoperator2 ,
                                              AV74Core_documentowwds_11_docversao2 ,
                                              AV75Core_documentowwds_12_doctiposigla2 ,
                                              AV76Core_documentowwds_13_dynamicfiltersenabled3 ,
                                              AV77Core_documentowwds_14_dynamicfiltersselector3 ,
                                              AV78Core_documentowwds_15_dynamicfiltersoperator3 ,
                                              AV79Core_documentowwds_16_docversao3 ,
                                              AV80Core_documentowwds_17_doctiposigla3 ,
                                              AV82Core_documentowwds_19_tfdoctiponome_sel ,
                                              AV81Core_documentowwds_18_tfdoctiponome ,
                                              AV84Core_documentowwds_21_tfdocnome_sel ,
                                              AV83Core_documentowwds_20_tfdocnome ,
                                              AV85Core_documentowwds_22_tfdocversao ,
                                              AV86Core_documentowwds_23_tfdocversao_to ,
                                              AV87Core_documentowwds_24_tfdocinsdatahora ,
                                              AV88Core_documentowwds_25_tfdocinsdatahora_to ,
                                              AV89Core_documentowwds_26_tfdoccontrato_sel ,
                                              AV90Core_documentowwds_27_tfdocassinado_sel ,
                                              A148DocTipoNome ,
                                              A305DocNome ,
                                              A325DocVersao ,
                                              A147DocTipoSigla ,
                                              A294DocInsDataHora ,
                                              A480DocContrato ,
                                              A481DocAssinado ,
                                              A290DocOrigem ,
                                              AV56DocOrigem ,
                                              A291DocOrigemID ,
                                              AV57DocOrigemID ,
                                              A640DocAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext), "%", "");
         lV66Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext), "%", "");
         lV66Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext), "%", "");
         lV70Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1), "%", "");
         lV70Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1), "%", "");
         lV75Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2), "%", "");
         lV75Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2), "%", "");
         lV80Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3), "%", "");
         lV80Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3), "%", "");
         lV81Core_documentowwds_18_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV81Core_documentowwds_18_tfdoctiponome), "%", "");
         lV83Core_documentowwds_20_tfdocnome = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_20_tfdocnome), "%", "");
         /* Using cursor P006I2 */
         pr_default.execute(0, new Object[] {AV56DocOrigem, AV57DocOrigemID, lV66Core_documentowwds_3_filterfulltext, lV66Core_documentowwds_3_filterfulltext, lV66Core_documentowwds_3_filterfulltext, AV69Core_documentowwds_6_docversao1, AV69Core_documentowwds_6_docversao1, AV69Core_documentowwds_6_docversao1, lV70Core_documentowwds_7_doctiposigla1, lV70Core_documentowwds_7_doctiposigla1, AV74Core_documentowwds_11_docversao2, AV74Core_documentowwds_11_docversao2, AV74Core_documentowwds_11_docversao2, lV75Core_documentowwds_12_doctiposigla2, lV75Core_documentowwds_12_doctiposigla2, AV79Core_documentowwds_16_docversao3, AV79Core_documentowwds_16_docversao3, AV79Core_documentowwds_16_docversao3, lV80Core_documentowwds_17_doctiposigla3, lV80Core_documentowwds_17_doctiposigla3, lV81Core_documentowwds_18_tfdoctiponome, AV82Core_documentowwds_19_tfdoctiponome_sel, lV83Core_documentowwds_20_tfdocnome, AV84Core_documentowwds_21_tfdocnome_sel, AV85Core_documentowwds_22_tfdocversao, AV86Core_documentowwds_23_tfdocversao_to, AV87Core_documentowwds_24_tfdocinsdatahora, AV88Core_documentowwds_25_tfdocinsdatahora_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6I2 = false;
            A146DocTipoID = P006I2_A146DocTipoID[0];
            A290DocOrigem = P006I2_A290DocOrigem[0];
            A291DocOrigemID = P006I2_A291DocOrigemID[0];
            A640DocAtivo = P006I2_A640DocAtivo[0];
            n640DocAtivo = P006I2_n640DocAtivo[0];
            A148DocTipoNome = P006I2_A148DocTipoNome[0];
            A481DocAssinado = P006I2_A481DocAssinado[0];
            A480DocContrato = P006I2_A480DocContrato[0];
            A294DocInsDataHora = P006I2_A294DocInsDataHora[0];
            A147DocTipoSigla = P006I2_A147DocTipoSigla[0];
            A325DocVersao = P006I2_A325DocVersao[0];
            A305DocNome = P006I2_A305DocNome[0];
            A289DocID = P006I2_A289DocID[0];
            A148DocTipoNome = P006I2_A148DocTipoNome[0];
            A147DocTipoSigla = P006I2_A147DocTipoSigla[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006I2_A148DocTipoNome[0], A148DocTipoNome) == 0 ) )
            {
               BRK6I2 = false;
               A146DocTipoID = P006I2_A146DocTipoID[0];
               A289DocID = P006I2_A289DocID[0];
               AV27count = (long)(AV27count+1);
               BRK6I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148DocTipoNome)) ? "<#Empty#>" : A148DocTipoNome);
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
            if ( ! BRK6I2 )
            {
               BRK6I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDOCNOMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFDocNome = AV17SearchTxt;
         AV12TFDocNome_Sel = "";
         AV64Core_documentowwds_1_docorigem_filtro = AV54DocOrigem_Filtro;
         AV65Core_documentowwds_2_docorigemid_filtro = AV55DocOrigemID_Filtro;
         AV66Core_documentowwds_3_filterfulltext = AV39FilterFullText;
         AV67Core_documentowwds_4_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV68Core_documentowwds_5_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV69Core_documentowwds_6_docversao1 = AV42DocVersao1;
         AV70Core_documentowwds_7_doctiposigla1 = AV43DocTipoSigla1;
         AV71Core_documentowwds_8_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV72Core_documentowwds_9_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV73Core_documentowwds_10_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV74Core_documentowwds_11_docversao2 = AV47DocVersao2;
         AV75Core_documentowwds_12_doctiposigla2 = AV48DocTipoSigla2;
         AV76Core_documentowwds_13_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV77Core_documentowwds_14_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV78Core_documentowwds_15_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV79Core_documentowwds_16_docversao3 = AV52DocVersao3;
         AV80Core_documentowwds_17_doctiposigla3 = AV53DocTipoSigla3;
         AV81Core_documentowwds_18_tfdoctiponome = AV13TFDocTipoNome;
         AV82Core_documentowwds_19_tfdoctiponome_sel = AV14TFDocTipoNome_Sel;
         AV83Core_documentowwds_20_tfdocnome = AV11TFDocNome;
         AV84Core_documentowwds_21_tfdocnome_sel = AV12TFDocNome_Sel;
         AV85Core_documentowwds_22_tfdocversao = AV60TFDocVersao;
         AV86Core_documentowwds_23_tfdocversao_to = AV61TFDocVersao_To;
         AV87Core_documentowwds_24_tfdocinsdatahora = AV15TFDocInsDataHora;
         AV88Core_documentowwds_25_tfdocinsdatahora_to = AV16TFDocInsDataHora_To;
         AV89Core_documentowwds_26_tfdoccontrato_sel = AV58TFDocContrato_Sel;
         AV90Core_documentowwds_27_tfdocassinado_sel = AV59TFDocAssinado_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV66Core_documentowwds_3_filterfulltext ,
                                              AV67Core_documentowwds_4_dynamicfiltersselector1 ,
                                              AV68Core_documentowwds_5_dynamicfiltersoperator1 ,
                                              AV69Core_documentowwds_6_docversao1 ,
                                              AV70Core_documentowwds_7_doctiposigla1 ,
                                              AV71Core_documentowwds_8_dynamicfiltersenabled2 ,
                                              AV72Core_documentowwds_9_dynamicfiltersselector2 ,
                                              AV73Core_documentowwds_10_dynamicfiltersoperator2 ,
                                              AV74Core_documentowwds_11_docversao2 ,
                                              AV75Core_documentowwds_12_doctiposigla2 ,
                                              AV76Core_documentowwds_13_dynamicfiltersenabled3 ,
                                              AV77Core_documentowwds_14_dynamicfiltersselector3 ,
                                              AV78Core_documentowwds_15_dynamicfiltersoperator3 ,
                                              AV79Core_documentowwds_16_docversao3 ,
                                              AV80Core_documentowwds_17_doctiposigla3 ,
                                              AV82Core_documentowwds_19_tfdoctiponome_sel ,
                                              AV81Core_documentowwds_18_tfdoctiponome ,
                                              AV84Core_documentowwds_21_tfdocnome_sel ,
                                              AV83Core_documentowwds_20_tfdocnome ,
                                              AV85Core_documentowwds_22_tfdocversao ,
                                              AV86Core_documentowwds_23_tfdocversao_to ,
                                              AV87Core_documentowwds_24_tfdocinsdatahora ,
                                              AV88Core_documentowwds_25_tfdocinsdatahora_to ,
                                              AV89Core_documentowwds_26_tfdoccontrato_sel ,
                                              AV90Core_documentowwds_27_tfdocassinado_sel ,
                                              A148DocTipoNome ,
                                              A305DocNome ,
                                              A325DocVersao ,
                                              A147DocTipoSigla ,
                                              A294DocInsDataHora ,
                                              A480DocContrato ,
                                              A481DocAssinado ,
                                              A290DocOrigem ,
                                              AV56DocOrigem ,
                                              A291DocOrigemID ,
                                              AV57DocOrigemID ,
                                              A640DocAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV66Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext), "%", "");
         lV66Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext), "%", "");
         lV66Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext), "%", "");
         lV70Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1), "%", "");
         lV70Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1), "%", "");
         lV75Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2), "%", "");
         lV75Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2), "%", "");
         lV80Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3), "%", "");
         lV80Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3), "%", "");
         lV81Core_documentowwds_18_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV81Core_documentowwds_18_tfdoctiponome), "%", "");
         lV83Core_documentowwds_20_tfdocnome = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_20_tfdocnome), "%", "");
         /* Using cursor P006I3 */
         pr_default.execute(1, new Object[] {AV56DocOrigem, AV57DocOrigemID, lV66Core_documentowwds_3_filterfulltext, lV66Core_documentowwds_3_filterfulltext, lV66Core_documentowwds_3_filterfulltext, AV69Core_documentowwds_6_docversao1, AV69Core_documentowwds_6_docversao1, AV69Core_documentowwds_6_docversao1, lV70Core_documentowwds_7_doctiposigla1, lV70Core_documentowwds_7_doctiposigla1, AV74Core_documentowwds_11_docversao2, AV74Core_documentowwds_11_docversao2, AV74Core_documentowwds_11_docversao2, lV75Core_documentowwds_12_doctiposigla2, lV75Core_documentowwds_12_doctiposigla2, AV79Core_documentowwds_16_docversao3, AV79Core_documentowwds_16_docversao3, AV79Core_documentowwds_16_docversao3, lV80Core_documentowwds_17_doctiposigla3, lV80Core_documentowwds_17_doctiposigla3, lV81Core_documentowwds_18_tfdoctiponome, AV82Core_documentowwds_19_tfdoctiponome_sel, lV83Core_documentowwds_20_tfdocnome, AV84Core_documentowwds_21_tfdocnome_sel, AV85Core_documentowwds_22_tfdocversao, AV86Core_documentowwds_23_tfdocversao_to, AV87Core_documentowwds_24_tfdocinsdatahora, AV88Core_documentowwds_25_tfdocinsdatahora_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6I4 = false;
            A146DocTipoID = P006I3_A146DocTipoID[0];
            A305DocNome = P006I3_A305DocNome[0];
            A640DocAtivo = P006I3_A640DocAtivo[0];
            n640DocAtivo = P006I3_n640DocAtivo[0];
            A481DocAssinado = P006I3_A481DocAssinado[0];
            A480DocContrato = P006I3_A480DocContrato[0];
            A294DocInsDataHora = P006I3_A294DocInsDataHora[0];
            A147DocTipoSigla = P006I3_A147DocTipoSigla[0];
            A325DocVersao = P006I3_A325DocVersao[0];
            A148DocTipoNome = P006I3_A148DocTipoNome[0];
            A291DocOrigemID = P006I3_A291DocOrigemID[0];
            A290DocOrigem = P006I3_A290DocOrigem[0];
            A289DocID = P006I3_A289DocID[0];
            A147DocTipoSigla = P006I3_A147DocTipoSigla[0];
            A148DocTipoNome = P006I3_A148DocTipoNome[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006I3_A305DocNome[0], A305DocNome) == 0 ) )
            {
               BRK6I4 = false;
               A289DocID = P006I3_A289DocID[0];
               AV27count = (long)(AV27count+1);
               BRK6I4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A305DocNome)) ? "<#Empty#>" : A305DocNome);
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
            if ( ! BRK6I4 )
            {
               BRK6I4 = true;
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
         AV54DocOrigem_Filtro = "";
         AV55DocOrigemID_Filtro = "";
         AV39FilterFullText = "";
         AV13TFDocTipoNome = "";
         AV14TFDocTipoNome_Sel = "";
         AV11TFDocNome = "";
         AV12TFDocNome_Sel = "";
         AV15TFDocInsDataHora = (DateTime)(DateTime.MinValue);
         AV16TFDocInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV56DocOrigem = "";
         AV57DocOrigemID = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV43DocTipoSigla1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV48DocTipoSigla2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV53DocTipoSigla3 = "";
         AV64Core_documentowwds_1_docorigem_filtro = "";
         AV65Core_documentowwds_2_docorigemid_filtro = "";
         AV66Core_documentowwds_3_filterfulltext = "";
         AV67Core_documentowwds_4_dynamicfiltersselector1 = "";
         AV70Core_documentowwds_7_doctiposigla1 = "";
         AV72Core_documentowwds_9_dynamicfiltersselector2 = "";
         AV75Core_documentowwds_12_doctiposigla2 = "";
         AV77Core_documentowwds_14_dynamicfiltersselector3 = "";
         AV80Core_documentowwds_17_doctiposigla3 = "";
         AV81Core_documentowwds_18_tfdoctiponome = "";
         AV82Core_documentowwds_19_tfdoctiponome_sel = "";
         AV83Core_documentowwds_20_tfdocnome = "";
         AV84Core_documentowwds_21_tfdocnome_sel = "";
         AV87Core_documentowwds_24_tfdocinsdatahora = (DateTime)(DateTime.MinValue);
         AV88Core_documentowwds_25_tfdocinsdatahora_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV66Core_documentowwds_3_filterfulltext = "";
         lV70Core_documentowwds_7_doctiposigla1 = "";
         lV75Core_documentowwds_12_doctiposigla2 = "";
         lV80Core_documentowwds_17_doctiposigla3 = "";
         lV81Core_documentowwds_18_tfdoctiponome = "";
         lV83Core_documentowwds_20_tfdocnome = "";
         A148DocTipoNome = "";
         A305DocNome = "";
         A147DocTipoSigla = "";
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A290DocOrigem = "";
         A291DocOrigemID = "";
         P006I2_A146DocTipoID = new int[1] ;
         P006I2_A290DocOrigem = new string[] {""} ;
         P006I2_A291DocOrigemID = new string[] {""} ;
         P006I2_A640DocAtivo = new bool[] {false} ;
         P006I2_n640DocAtivo = new bool[] {false} ;
         P006I2_A148DocTipoNome = new string[] {""} ;
         P006I2_A481DocAssinado = new bool[] {false} ;
         P006I2_A480DocContrato = new bool[] {false} ;
         P006I2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006I2_A147DocTipoSigla = new string[] {""} ;
         P006I2_A325DocVersao = new short[1] ;
         P006I2_A305DocNome = new string[] {""} ;
         P006I2_A289DocID = new Guid[] {Guid.Empty} ;
         A289DocID = Guid.Empty;
         AV22Option = "";
         P006I3_A146DocTipoID = new int[1] ;
         P006I3_A305DocNome = new string[] {""} ;
         P006I3_A640DocAtivo = new bool[] {false} ;
         P006I3_n640DocAtivo = new bool[] {false} ;
         P006I3_A481DocAssinado = new bool[] {false} ;
         P006I3_A480DocContrato = new bool[] {false} ;
         P006I3_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006I3_A147DocTipoSigla = new string[] {""} ;
         P006I3_A325DocVersao = new short[1] ;
         P006I3_A148DocTipoNome = new string[] {""} ;
         P006I3_A291DocOrigemID = new string[] {""} ;
         P006I3_A290DocOrigem = new string[] {""} ;
         P006I3_A289DocID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006I2_A146DocTipoID, P006I2_A290DocOrigem, P006I2_A291DocOrigemID, P006I2_A640DocAtivo, P006I2_n640DocAtivo, P006I2_A148DocTipoNome, P006I2_A481DocAssinado, P006I2_A480DocContrato, P006I2_A294DocInsDataHora, P006I2_A147DocTipoSigla,
               P006I2_A325DocVersao, P006I2_A305DocNome, P006I2_A289DocID
               }
               , new Object[] {
               P006I3_A146DocTipoID, P006I3_A305DocNome, P006I3_A640DocAtivo, P006I3_n640DocAtivo, P006I3_A481DocAssinado, P006I3_A480DocContrato, P006I3_A294DocInsDataHora, P006I3_A147DocTipoSigla, P006I3_A325DocVersao, P006I3_A148DocTipoNome,
               P006I3_A291DocOrigemID, P006I3_A290DocOrigem, P006I3_A289DocID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV60TFDocVersao ;
      private short AV61TFDocVersao_To ;
      private short AV58TFDocContrato_Sel ;
      private short AV59TFDocAssinado_Sel ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV42DocVersao1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV47DocVersao2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV52DocVersao3 ;
      private short AV68Core_documentowwds_5_dynamicfiltersoperator1 ;
      private short AV69Core_documentowwds_6_docversao1 ;
      private short AV73Core_documentowwds_10_dynamicfiltersoperator2 ;
      private short AV74Core_documentowwds_11_docversao2 ;
      private short AV78Core_documentowwds_15_dynamicfiltersoperator3 ;
      private short AV79Core_documentowwds_16_docversao3 ;
      private short AV85Core_documentowwds_22_tfdocversao ;
      private short AV86Core_documentowwds_23_tfdocversao_to ;
      private short AV89Core_documentowwds_26_tfdoccontrato_sel ;
      private short AV90Core_documentowwds_27_tfdocassinado_sel ;
      private short A325DocVersao ;
      private int AV62GXV1 ;
      private int A146DocTipoID ;
      private long AV27count ;
      private string scmdbuf ;
      private DateTime AV15TFDocInsDataHora ;
      private DateTime AV16TFDocInsDataHora_To ;
      private DateTime AV87Core_documentowwds_24_tfdocinsdatahora ;
      private DateTime AV88Core_documentowwds_25_tfdocinsdatahora_to ;
      private DateTime A294DocInsDataHora ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV71Core_documentowwds_8_dynamicfiltersenabled2 ;
      private bool AV76Core_documentowwds_13_dynamicfiltersenabled3 ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool A640DocAtivo ;
      private bool BRK6I2 ;
      private bool n640DocAtivo ;
      private bool BRK6I4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV54DocOrigem_Filtro ;
      private string AV55DocOrigemID_Filtro ;
      private string AV39FilterFullText ;
      private string AV13TFDocTipoNome ;
      private string AV14TFDocTipoNome_Sel ;
      private string AV11TFDocNome ;
      private string AV12TFDocNome_Sel ;
      private string AV56DocOrigem ;
      private string AV57DocOrigemID ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV43DocTipoSigla1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV48DocTipoSigla2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV53DocTipoSigla3 ;
      private string AV64Core_documentowwds_1_docorigem_filtro ;
      private string AV65Core_documentowwds_2_docorigemid_filtro ;
      private string AV66Core_documentowwds_3_filterfulltext ;
      private string AV67Core_documentowwds_4_dynamicfiltersselector1 ;
      private string AV70Core_documentowwds_7_doctiposigla1 ;
      private string AV72Core_documentowwds_9_dynamicfiltersselector2 ;
      private string AV75Core_documentowwds_12_doctiposigla2 ;
      private string AV77Core_documentowwds_14_dynamicfiltersselector3 ;
      private string AV80Core_documentowwds_17_doctiposigla3 ;
      private string AV81Core_documentowwds_18_tfdoctiponome ;
      private string AV82Core_documentowwds_19_tfdoctiponome_sel ;
      private string AV83Core_documentowwds_20_tfdocnome ;
      private string AV84Core_documentowwds_21_tfdocnome_sel ;
      private string lV66Core_documentowwds_3_filterfulltext ;
      private string lV70Core_documentowwds_7_doctiposigla1 ;
      private string lV75Core_documentowwds_12_doctiposigla2 ;
      private string lV80Core_documentowwds_17_doctiposigla3 ;
      private string lV81Core_documentowwds_18_tfdoctiponome ;
      private string lV83Core_documentowwds_20_tfdocnome ;
      private string A148DocTipoNome ;
      private string A305DocNome ;
      private string A147DocTipoSigla ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string AV22Option ;
      private Guid A289DocID ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006I2_A146DocTipoID ;
      private string[] P006I2_A290DocOrigem ;
      private string[] P006I2_A291DocOrigemID ;
      private bool[] P006I2_A640DocAtivo ;
      private bool[] P006I2_n640DocAtivo ;
      private string[] P006I2_A148DocTipoNome ;
      private bool[] P006I2_A481DocAssinado ;
      private bool[] P006I2_A480DocContrato ;
      private DateTime[] P006I2_A294DocInsDataHora ;
      private string[] P006I2_A147DocTipoSigla ;
      private short[] P006I2_A325DocVersao ;
      private string[] P006I2_A305DocNome ;
      private Guid[] P006I2_A289DocID ;
      private int[] P006I3_A146DocTipoID ;
      private string[] P006I3_A305DocNome ;
      private bool[] P006I3_A640DocAtivo ;
      private bool[] P006I3_n640DocAtivo ;
      private bool[] P006I3_A481DocAssinado ;
      private bool[] P006I3_A480DocContrato ;
      private DateTime[] P006I3_A294DocInsDataHora ;
      private string[] P006I3_A147DocTipoSigla ;
      private short[] P006I3_A325DocVersao ;
      private string[] P006I3_A148DocTipoNome ;
      private string[] P006I3_A291DocOrigemID ;
      private string[] P006I3_A290DocOrigem ;
      private Guid[] P006I3_A289DocID ;
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

   public class documentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006I2( IGxContext context ,
                                             string AV66Core_documentowwds_3_filterfulltext ,
                                             string AV67Core_documentowwds_4_dynamicfiltersselector1 ,
                                             short AV68Core_documentowwds_5_dynamicfiltersoperator1 ,
                                             short AV69Core_documentowwds_6_docversao1 ,
                                             string AV70Core_documentowwds_7_doctiposigla1 ,
                                             bool AV71Core_documentowwds_8_dynamicfiltersenabled2 ,
                                             string AV72Core_documentowwds_9_dynamicfiltersselector2 ,
                                             short AV73Core_documentowwds_10_dynamicfiltersoperator2 ,
                                             short AV74Core_documentowwds_11_docversao2 ,
                                             string AV75Core_documentowwds_12_doctiposigla2 ,
                                             bool AV76Core_documentowwds_13_dynamicfiltersenabled3 ,
                                             string AV77Core_documentowwds_14_dynamicfiltersselector3 ,
                                             short AV78Core_documentowwds_15_dynamicfiltersoperator3 ,
                                             short AV79Core_documentowwds_16_docversao3 ,
                                             string AV80Core_documentowwds_17_doctiposigla3 ,
                                             string AV82Core_documentowwds_19_tfdoctiponome_sel ,
                                             string AV81Core_documentowwds_18_tfdoctiponome ,
                                             string AV84Core_documentowwds_21_tfdocnome_sel ,
                                             string AV83Core_documentowwds_20_tfdocnome ,
                                             short AV85Core_documentowwds_22_tfdocversao ,
                                             short AV86Core_documentowwds_23_tfdocversao_to ,
                                             DateTime AV87Core_documentowwds_24_tfdocinsdatahora ,
                                             DateTime AV88Core_documentowwds_25_tfdocinsdatahora_to ,
                                             short AV89Core_documentowwds_26_tfdoccontrato_sel ,
                                             short AV90Core_documentowwds_27_tfdocassinado_sel ,
                                             string A148DocTipoNome ,
                                             string A305DocNome ,
                                             short A325DocVersao ,
                                             string A147DocTipoSigla ,
                                             DateTime A294DocInsDataHora ,
                                             bool A480DocContrato ,
                                             bool A481DocAssinado ,
                                             string A290DocOrigem ,
                                             string AV56DocOrigem ,
                                             string A291DocOrigemID ,
                                             string AV57DocOrigemID ,
                                             bool A640DocAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[28];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.DocTipoID, T1.DocOrigem, T1.DocOrigemID, T1.DocAtivo, T2.DocTipoNome, T1.DocAssinado, T1.DocContrato, T1.DocInsDataHora, T2.DocTipoSigla, T1.DocVersao, T1.DocNome, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID)";
         AddWhere(sWhereString, "(T1.DocOrigem = ( :AV56DocOrigem))");
         AddWhere(sWhereString, "(T1.DocOrigemID = ( :AV57DocOrigemID))");
         AddWhere(sWhereString, "(T1.DocAtivo = TRUE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.DocTipoNome like '%' || :lV66Core_documentowwds_3_filterfulltext) or ( T1.DocNome like '%' || :lV66Core_documentowwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.DocVersao,'9999'), 2) like '%' || :lV66Core_documentowwds_3_filterfulltext))");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV69Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV69Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV69Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV69Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV69Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV69Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV70Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV70Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV74Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV74Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV74Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV74Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV74Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV74Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV75Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV75Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV79Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV79Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV79Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV79Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV79Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV79Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV80Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV80Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_documentowwds_19_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_documentowwds_18_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome like :lV81Core_documentowwds_18_tfdoctiponome)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_documentowwds_19_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV82Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome = ( :AV82Core_documentowwds_19_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV82Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.DocTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_documentowwds_21_tfdocnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_documentowwds_20_tfdocnome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocNome like :lV83Core_documentowwds_20_tfdocnome)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_documentowwds_21_tfdocnome_sel)) && ! ( StringUtil.StrCmp(AV84Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocNome = ( :AV84Core_documentowwds_21_tfdocnome_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV84Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocNome))=0))");
         }
         if ( ! (0==AV85Core_documentowwds_22_tfdocversao) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV85Core_documentowwds_22_tfdocversao)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (0==AV86Core_documentowwds_23_tfdocversao_to) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV86Core_documentowwds_23_tfdocversao_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Core_documentowwds_24_tfdocinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora >= :AV87Core_documentowwds_24_tfdocinsdatahora)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Core_documentowwds_25_tfdocinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora <= :AV88Core_documentowwds_25_tfdocinsdatahora_to)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV89Core_documentowwds_26_tfdoccontrato_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = TRUE)");
         }
         if ( AV89Core_documentowwds_26_tfdoccontrato_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = FALSE)");
         }
         if ( AV90Core_documentowwds_27_tfdocassinado_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = TRUE)");
         }
         if ( AV90Core_documentowwds_27_tfdocassinado_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.DocTipoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006I3( IGxContext context ,
                                             string AV66Core_documentowwds_3_filterfulltext ,
                                             string AV67Core_documentowwds_4_dynamicfiltersselector1 ,
                                             short AV68Core_documentowwds_5_dynamicfiltersoperator1 ,
                                             short AV69Core_documentowwds_6_docversao1 ,
                                             string AV70Core_documentowwds_7_doctiposigla1 ,
                                             bool AV71Core_documentowwds_8_dynamicfiltersenabled2 ,
                                             string AV72Core_documentowwds_9_dynamicfiltersselector2 ,
                                             short AV73Core_documentowwds_10_dynamicfiltersoperator2 ,
                                             short AV74Core_documentowwds_11_docversao2 ,
                                             string AV75Core_documentowwds_12_doctiposigla2 ,
                                             bool AV76Core_documentowwds_13_dynamicfiltersenabled3 ,
                                             string AV77Core_documentowwds_14_dynamicfiltersselector3 ,
                                             short AV78Core_documentowwds_15_dynamicfiltersoperator3 ,
                                             short AV79Core_documentowwds_16_docversao3 ,
                                             string AV80Core_documentowwds_17_doctiposigla3 ,
                                             string AV82Core_documentowwds_19_tfdoctiponome_sel ,
                                             string AV81Core_documentowwds_18_tfdoctiponome ,
                                             string AV84Core_documentowwds_21_tfdocnome_sel ,
                                             string AV83Core_documentowwds_20_tfdocnome ,
                                             short AV85Core_documentowwds_22_tfdocversao ,
                                             short AV86Core_documentowwds_23_tfdocversao_to ,
                                             DateTime AV87Core_documentowwds_24_tfdocinsdatahora ,
                                             DateTime AV88Core_documentowwds_25_tfdocinsdatahora_to ,
                                             short AV89Core_documentowwds_26_tfdoccontrato_sel ,
                                             short AV90Core_documentowwds_27_tfdocassinado_sel ,
                                             string A148DocTipoNome ,
                                             string A305DocNome ,
                                             short A325DocVersao ,
                                             string A147DocTipoSigla ,
                                             DateTime A294DocInsDataHora ,
                                             bool A480DocContrato ,
                                             bool A481DocAssinado ,
                                             string A290DocOrigem ,
                                             string AV56DocOrigem ,
                                             string A291DocOrigemID ,
                                             string AV57DocOrigemID ,
                                             bool A640DocAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.DocTipoID, T1.DocNome, T1.DocAtivo, T1.DocAssinado, T1.DocContrato, T1.DocInsDataHora, T2.DocTipoSigla, T1.DocVersao, T2.DocTipoNome, T1.DocOrigemID, T1.DocOrigem, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID)";
         AddWhere(sWhereString, "(T1.DocOrigem = ( :AV56DocOrigem))");
         AddWhere(sWhereString, "(T1.DocOrigemID = ( :AV57DocOrigemID))");
         AddWhere(sWhereString, "(T1.DocAtivo = TRUE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_documentowwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.DocTipoNome like '%' || :lV66Core_documentowwds_3_filterfulltext) or ( T1.DocNome like '%' || :lV66Core_documentowwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.DocVersao,'9999'), 2) like '%' || :lV66Core_documentowwds_3_filterfulltext))");
         }
         else
         {
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV69Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV69Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV69Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV69Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV69Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV69Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV70Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV68Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV70Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV74Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV74Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV74Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV74Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV74Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV74Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV75Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV71Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV73Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV75Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV79Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV79Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV79Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV79Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV79Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV79Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV80Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV76Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV78Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV80Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_documentowwds_19_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_documentowwds_18_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome like :lV81Core_documentowwds_18_tfdoctiponome)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_documentowwds_19_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV82Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome = ( :AV82Core_documentowwds_19_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV82Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.DocTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_documentowwds_21_tfdocnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_documentowwds_20_tfdocnome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocNome like :lV83Core_documentowwds_20_tfdocnome)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_documentowwds_21_tfdocnome_sel)) && ! ( StringUtil.StrCmp(AV84Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocNome = ( :AV84Core_documentowwds_21_tfdocnome_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV84Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocNome))=0))");
         }
         if ( ! (0==AV85Core_documentowwds_22_tfdocversao) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV85Core_documentowwds_22_tfdocversao)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (0==AV86Core_documentowwds_23_tfdocversao_to) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV86Core_documentowwds_23_tfdocversao_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Core_documentowwds_24_tfdocinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora >= :AV87Core_documentowwds_24_tfdocinsdatahora)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Core_documentowwds_25_tfdocinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora <= :AV88Core_documentowwds_25_tfdocinsdatahora_to)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV89Core_documentowwds_26_tfdoccontrato_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = TRUE)");
         }
         if ( AV89Core_documentowwds_26_tfdoccontrato_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = FALSE)");
         }
         if ( AV90Core_documentowwds_27_tfdocassinado_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = TRUE)");
         }
         if ( AV90Core_documentowwds_27_tfdocassinado_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.DocNome";
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
                     return conditional_P006I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (bool)dynConstraints[36] );
               case 1 :
                     return conditional_P006I3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] , (bool)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (bool)dynConstraints[36] );
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
          Object[] prmP006I2;
          prmP006I2 = new Object[] {
          new ParDef("AV56DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV57DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("lV66Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV69Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV69Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("lV70Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("AV74Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV74Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV74Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("lV75Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV75Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("AV79Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV79Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV79Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("lV80Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV80Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_documentowwds_18_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV82Core_documentowwds_19_tfdoctiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV83Core_documentowwds_20_tfdocnome",GXType.VarChar,80,0) ,
          new ParDef("AV84Core_documentowwds_21_tfdocnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV85Core_documentowwds_22_tfdocversao",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_23_tfdocversao_to",GXType.Int16,4,0) ,
          new ParDef("AV87Core_documentowwds_24_tfdocinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV88Core_documentowwds_25_tfdocinsdatahora_to",GXType.DateTime2,10,12)
          };
          Object[] prmP006I3;
          prmP006I3 = new Object[] {
          new ParDef("AV56DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV57DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("lV66Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV69Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV69Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("lV70Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("AV74Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV74Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV74Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("lV75Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV75Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("AV79Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV79Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV79Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("lV80Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV80Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_documentowwds_18_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV82Core_documentowwds_19_tfdoctiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV83Core_documentowwds_20_tfdocnome",GXType.VarChar,80,0) ,
          new ParDef("AV84Core_documentowwds_21_tfdocnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV85Core_documentowwds_22_tfdocversao",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_23_tfdocversao_to",GXType.Int16,4,0) ,
          new ParDef("AV87Core_documentowwds_24_tfdocinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV88Core_documentowwds_25_tfdocinsdatahora_to",GXType.DateTime2,10,12)
          };
          def= new CursorDef[] {
              new CursorDef("P006I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006I3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6, true);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
       }
    }

 }

}
