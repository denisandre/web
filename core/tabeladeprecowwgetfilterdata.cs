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
   public class tabeladeprecowwgetfilterdata : GXProcedure
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
            return "tabeladeprecoww_Services_Execute" ;
         }

      }

      public tabeladeprecowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladeprecowwgetfilterdata( IGxContext context )
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
         this.AV48DDOName = aP0_DDOName;
         this.AV49SearchTxtParms = aP1_SearchTxtParms;
         this.AV50SearchTxtTo = aP2_SearchTxtTo;
         this.AV51OptionsJson = "" ;
         this.AV52OptionsDescJson = "" ;
         this.AV53OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV53OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         tabeladeprecowwgetfilterdata objtabeladeprecowwgetfilterdata;
         objtabeladeprecowwgetfilterdata = new tabeladeprecowwgetfilterdata();
         objtabeladeprecowwgetfilterdata.AV48DDOName = aP0_DDOName;
         objtabeladeprecowwgetfilterdata.AV49SearchTxtParms = aP1_SearchTxtParms;
         objtabeladeprecowwgetfilterdata.AV50SearchTxtTo = aP2_SearchTxtTo;
         objtabeladeprecowwgetfilterdata.AV51OptionsJson = "" ;
         objtabeladeprecowwgetfilterdata.AV52OptionsDescJson = "" ;
         objtabeladeprecowwgetfilterdata.AV53OptionIndexesJson = "" ;
         objtabeladeprecowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtabeladeprecowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objtabeladeprecowwgetfilterdata);
         aP3_OptionsJson=this.AV51OptionsJson;
         aP4_OptionsDescJson=this.AV52OptionsDescJson;
         aP5_OptionIndexesJson=this.AV53OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tabeladeprecowwgetfilterdata)stateInfo).executePrivate();
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
         AV38Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35MaxItems = 10;
         AV34PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV49SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV32SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV49SearchTxtParms)) ? "" : StringUtil.Substring( AV49SearchTxtParms, 3, -1));
         AV33SkipItems = (short)(AV34PageIndex*AV35MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_TPPCODIGO") == 0 )
         {
            /* Execute user subroutine: 'LOADTPPCODIGOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV48DDOName), "DDO_TPPNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADTPPNOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV51OptionsJson = AV38Options.ToJSonString(false);
         AV52OptionsDescJson = AV40OptionsDesc.ToJSonString(false);
         AV53OptionIndexesJson = AV41OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get("core.TabelaDePrecoWWGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.TabelaDePrecoWWGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("core.TabelaDePrecoWWGridState"), null, "", "");
         }
         AV67GXV1 = 1;
         while ( AV67GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV67GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TPPDEL_FILTRO") == 0 )
            {
               AV66TppDel_Filtro = BooleanUtil.Val( AV46GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV54FilterFullText = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO") == 0 )
            {
               AV11TFTppCodigo = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO_SEL") == 0 )
            {
               AV12TFTppCodigo_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTPPNOME") == 0 )
            {
               AV13TFTppNome = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTPPNOME_SEL") == 0 )
            {
               AV14TFTppNome_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTPPINSDATA") == 0 )
            {
               AV15TFTppInsData = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, 2);
               AV16TFTppInsData_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV67GXV1 = (int)(AV67GXV1+1);
         }
         if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(1));
            AV55DynamicFiltersSelector1 = AV47GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV55DynamicFiltersSelector1, "TPPCODIGO") == 0 )
            {
               AV56DynamicFiltersOperator1 = AV47GridStateDynamicFilter.gxTpr_Operator;
               AV57TppCodigo1 = AV47GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV58DynamicFiltersEnabled2 = true;
               AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(2));
               AV59DynamicFiltersSelector2 = AV47GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV59DynamicFiltersSelector2, "TPPCODIGO") == 0 )
               {
                  AV60DynamicFiltersOperator2 = AV47GridStateDynamicFilter.gxTpr_Operator;
                  AV61TppCodigo2 = AV47GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV62DynamicFiltersEnabled3 = true;
                  AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(3));
                  AV63DynamicFiltersSelector3 = AV47GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV63DynamicFiltersSelector3, "TPPCODIGO") == 0 )
                  {
                     AV64DynamicFiltersOperator3 = AV47GridStateDynamicFilter.gxTpr_Operator;
                     AV65TppCodigo3 = AV47GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTPPCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV11TFTppCodigo = AV32SearchTxt;
         AV12TFTppCodigo_Sel = "";
         AV69Core_tabeladeprecowwds_1_tppdel_filtro = AV66TppDel_Filtro;
         AV70Core_tabeladeprecowwds_2_filterfulltext = AV54FilterFullText;
         AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV55DynamicFiltersSelector1;
         AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV56DynamicFiltersOperator1;
         AV73Core_tabeladeprecowwds_5_tppcodigo1 = AV57TppCodigo1;
         AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV58DynamicFiltersEnabled2;
         AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV59DynamicFiltersSelector2;
         AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV60DynamicFiltersOperator2;
         AV77Core_tabeladeprecowwds_9_tppcodigo2 = AV61TppCodigo2;
         AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV81Core_tabeladeprecowwds_13_tppcodigo3 = AV65TppCodigo3;
         AV82Core_tabeladeprecowwds_14_tftppcodigo = AV11TFTppCodigo;
         AV83Core_tabeladeprecowwds_15_tftppcodigo_sel = AV12TFTppCodigo_Sel;
         AV84Core_tabeladeprecowwds_16_tftppnome = AV13TFTppNome;
         AV85Core_tabeladeprecowwds_17_tftppnome_sel = AV14TFTppNome_Sel;
         AV86Core_tabeladeprecowwds_18_tftppinsdata = AV15TFTppInsData;
         AV87Core_tabeladeprecowwds_19_tftppinsdata_to = AV16TFTppInsData_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV70Core_tabeladeprecowwds_2_filterfulltext ,
                                              AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                              AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                              AV73Core_tabeladeprecowwds_5_tppcodigo1 ,
                                              AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                              AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                              AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                              AV77Core_tabeladeprecowwds_9_tppcodigo2 ,
                                              AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                              AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                              AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                              AV81Core_tabeladeprecowwds_13_tppcodigo3 ,
                                              AV83Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                              AV82Core_tabeladeprecowwds_14_tftppcodigo ,
                                              AV85Core_tabeladeprecowwds_17_tftppnome_sel ,
                                              AV84Core_tabeladeprecowwds_16_tftppnome ,
                                              AV86Core_tabeladeprecowwds_18_tftppinsdata ,
                                              AV87Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                              A236TppCodigo ,
                                              A237TppNome ,
                                              A238TppInsData ,
                                              A602TppDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV70Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV70Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV73Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV73Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV77Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV77Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV81Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV81Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV82Core_tabeladeprecowwds_14_tftppcodigo = StringUtil.Concat( StringUtil.RTrim( AV82Core_tabeladeprecowwds_14_tftppcodigo), "%", "");
         lV84Core_tabeladeprecowwds_16_tftppnome = StringUtil.Concat( StringUtil.RTrim( AV84Core_tabeladeprecowwds_16_tftppnome), "%", "");
         /* Using cursor P004F2 */
         pr_default.execute(0, new Object[] {lV70Core_tabeladeprecowwds_2_filterfulltext, lV70Core_tabeladeprecowwds_2_filterfulltext, lV73Core_tabeladeprecowwds_5_tppcodigo1, lV73Core_tabeladeprecowwds_5_tppcodigo1, lV77Core_tabeladeprecowwds_9_tppcodigo2, lV77Core_tabeladeprecowwds_9_tppcodigo2, lV81Core_tabeladeprecowwds_13_tppcodigo3, lV81Core_tabeladeprecowwds_13_tppcodigo3, lV82Core_tabeladeprecowwds_14_tftppcodigo, AV83Core_tabeladeprecowwds_15_tftppcodigo_sel, lV84Core_tabeladeprecowwds_16_tftppnome, AV85Core_tabeladeprecowwds_17_tftppnome_sel, AV86Core_tabeladeprecowwds_18_tftppinsdata, AV87Core_tabeladeprecowwds_19_tftppinsdata_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4F2 = false;
            A236TppCodigo = P004F2_A236TppCodigo[0];
            A238TppInsData = P004F2_A238TppInsData[0];
            A237TppNome = P004F2_A237TppNome[0];
            A602TppDel = P004F2_A602TppDel[0];
            A235TppID = P004F2_A235TppID[0];
            AV42count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004F2_A236TppCodigo[0], A236TppCodigo) == 0 ) )
            {
               BRK4F2 = false;
               A235TppID = P004F2_A235TppID[0];
               AV42count = (long)(AV42count+1);
               BRK4F2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV33SkipItems) )
            {
               AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A236TppCodigo)) ? "<#Empty#>" : A236TppCodigo);
               AV38Options.Add(AV37Option, 0);
               AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV38Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV33SkipItems = (short)(AV33SkipItems-1);
            }
            if ( ! BRK4F2 )
            {
               BRK4F2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTPPNOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFTppNome = AV32SearchTxt;
         AV14TFTppNome_Sel = "";
         AV69Core_tabeladeprecowwds_1_tppdel_filtro = AV66TppDel_Filtro;
         AV70Core_tabeladeprecowwds_2_filterfulltext = AV54FilterFullText;
         AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV55DynamicFiltersSelector1;
         AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV56DynamicFiltersOperator1;
         AV73Core_tabeladeprecowwds_5_tppcodigo1 = AV57TppCodigo1;
         AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV58DynamicFiltersEnabled2;
         AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV59DynamicFiltersSelector2;
         AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV60DynamicFiltersOperator2;
         AV77Core_tabeladeprecowwds_9_tppcodigo2 = AV61TppCodigo2;
         AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV81Core_tabeladeprecowwds_13_tppcodigo3 = AV65TppCodigo3;
         AV82Core_tabeladeprecowwds_14_tftppcodigo = AV11TFTppCodigo;
         AV83Core_tabeladeprecowwds_15_tftppcodigo_sel = AV12TFTppCodigo_Sel;
         AV84Core_tabeladeprecowwds_16_tftppnome = AV13TFTppNome;
         AV85Core_tabeladeprecowwds_17_tftppnome_sel = AV14TFTppNome_Sel;
         AV86Core_tabeladeprecowwds_18_tftppinsdata = AV15TFTppInsData;
         AV87Core_tabeladeprecowwds_19_tftppinsdata_to = AV16TFTppInsData_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV70Core_tabeladeprecowwds_2_filterfulltext ,
                                              AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                              AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                              AV73Core_tabeladeprecowwds_5_tppcodigo1 ,
                                              AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                              AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                              AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                              AV77Core_tabeladeprecowwds_9_tppcodigo2 ,
                                              AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                              AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                              AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                              AV81Core_tabeladeprecowwds_13_tppcodigo3 ,
                                              AV83Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                              AV82Core_tabeladeprecowwds_14_tftppcodigo ,
                                              AV85Core_tabeladeprecowwds_17_tftppnome_sel ,
                                              AV84Core_tabeladeprecowwds_16_tftppnome ,
                                              AV86Core_tabeladeprecowwds_18_tftppinsdata ,
                                              AV87Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                              A236TppCodigo ,
                                              A237TppNome ,
                                              A238TppInsData ,
                                              A602TppDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV70Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV70Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV73Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV73Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV77Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV77Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV81Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV81Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV82Core_tabeladeprecowwds_14_tftppcodigo = StringUtil.Concat( StringUtil.RTrim( AV82Core_tabeladeprecowwds_14_tftppcodigo), "%", "");
         lV84Core_tabeladeprecowwds_16_tftppnome = StringUtil.Concat( StringUtil.RTrim( AV84Core_tabeladeprecowwds_16_tftppnome), "%", "");
         /* Using cursor P004F3 */
         pr_default.execute(1, new Object[] {lV70Core_tabeladeprecowwds_2_filterfulltext, lV70Core_tabeladeprecowwds_2_filterfulltext, lV73Core_tabeladeprecowwds_5_tppcodigo1, lV73Core_tabeladeprecowwds_5_tppcodigo1, lV77Core_tabeladeprecowwds_9_tppcodigo2, lV77Core_tabeladeprecowwds_9_tppcodigo2, lV81Core_tabeladeprecowwds_13_tppcodigo3, lV81Core_tabeladeprecowwds_13_tppcodigo3, lV82Core_tabeladeprecowwds_14_tftppcodigo, AV83Core_tabeladeprecowwds_15_tftppcodigo_sel, lV84Core_tabeladeprecowwds_16_tftppnome, AV85Core_tabeladeprecowwds_17_tftppnome_sel, AV86Core_tabeladeprecowwds_18_tftppinsdata, AV87Core_tabeladeprecowwds_19_tftppinsdata_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4F4 = false;
            A237TppNome = P004F3_A237TppNome[0];
            A238TppInsData = P004F3_A238TppInsData[0];
            A236TppCodigo = P004F3_A236TppCodigo[0];
            A602TppDel = P004F3_A602TppDel[0];
            A235TppID = P004F3_A235TppID[0];
            AV42count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004F3_A237TppNome[0], A237TppNome) == 0 ) )
            {
               BRK4F4 = false;
               A235TppID = P004F3_A235TppID[0];
               AV42count = (long)(AV42count+1);
               BRK4F4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV33SkipItems) )
            {
               AV37Option = (String.IsNullOrEmpty(StringUtil.RTrim( A237TppNome)) ? "<#Empty#>" : A237TppNome);
               AV38Options.Add(AV37Option, 0);
               AV41OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV38Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV33SkipItems = (short)(AV33SkipItems-1);
            }
            if ( ! BRK4F4 )
            {
               BRK4F4 = true;
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
         AV51OptionsJson = "";
         AV52OptionsDescJson = "";
         AV53OptionIndexesJson = "";
         AV38Options = new GxSimpleCollection<string>();
         AV40OptionsDesc = new GxSimpleCollection<string>();
         AV41OptionIndexes = new GxSimpleCollection<string>();
         AV32SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV45GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV46GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54FilterFullText = "";
         AV11TFTppCodigo = "";
         AV12TFTppCodigo_Sel = "";
         AV13TFTppNome = "";
         AV14TFTppNome_Sel = "";
         AV15TFTppInsData = DateTime.MinValue;
         AV16TFTppInsData_To = DateTime.MinValue;
         AV47GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV55DynamicFiltersSelector1 = "";
         AV57TppCodigo1 = "";
         AV59DynamicFiltersSelector2 = "";
         AV61TppCodigo2 = "";
         AV63DynamicFiltersSelector3 = "";
         AV65TppCodigo3 = "";
         AV70Core_tabeladeprecowwds_2_filterfulltext = "";
         AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 = "";
         AV73Core_tabeladeprecowwds_5_tppcodigo1 = "";
         AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 = "";
         AV77Core_tabeladeprecowwds_9_tppcodigo2 = "";
         AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 = "";
         AV81Core_tabeladeprecowwds_13_tppcodigo3 = "";
         AV82Core_tabeladeprecowwds_14_tftppcodigo = "";
         AV83Core_tabeladeprecowwds_15_tftppcodigo_sel = "";
         AV84Core_tabeladeprecowwds_16_tftppnome = "";
         AV85Core_tabeladeprecowwds_17_tftppnome_sel = "";
         AV86Core_tabeladeprecowwds_18_tftppinsdata = DateTime.MinValue;
         AV87Core_tabeladeprecowwds_19_tftppinsdata_to = DateTime.MinValue;
         scmdbuf = "";
         lV70Core_tabeladeprecowwds_2_filterfulltext = "";
         lV73Core_tabeladeprecowwds_5_tppcodigo1 = "";
         lV77Core_tabeladeprecowwds_9_tppcodigo2 = "";
         lV81Core_tabeladeprecowwds_13_tppcodigo3 = "";
         lV82Core_tabeladeprecowwds_14_tftppcodigo = "";
         lV84Core_tabeladeprecowwds_16_tftppnome = "";
         A236TppCodigo = "";
         A237TppNome = "";
         A238TppInsData = DateTime.MinValue;
         P004F2_A236TppCodigo = new string[] {""} ;
         P004F2_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P004F2_A237TppNome = new string[] {""} ;
         P004F2_A602TppDel = new bool[] {false} ;
         P004F2_A235TppID = new Guid[] {Guid.Empty} ;
         A235TppID = Guid.Empty;
         AV37Option = "";
         P004F3_A237TppNome = new string[] {""} ;
         P004F3_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P004F3_A236TppCodigo = new string[] {""} ;
         P004F3_A602TppDel = new bool[] {false} ;
         P004F3_A235TppID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladeprecowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004F2_A236TppCodigo, P004F2_A238TppInsData, P004F2_A237TppNome, P004F2_A602TppDel, P004F2_A235TppID
               }
               , new Object[] {
               P004F3_A237TppNome, P004F3_A238TppInsData, P004F3_A236TppCodigo, P004F3_A602TppDel, P004F3_A235TppID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV35MaxItems ;
      private short AV34PageIndex ;
      private short AV33SkipItems ;
      private short AV56DynamicFiltersOperator1 ;
      private short AV60DynamicFiltersOperator2 ;
      private short AV64DynamicFiltersOperator3 ;
      private short AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ;
      private short AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ;
      private short AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ;
      private int AV67GXV1 ;
      private long AV42count ;
      private string scmdbuf ;
      private DateTime AV15TFTppInsData ;
      private DateTime AV16TFTppInsData_To ;
      private DateTime AV86Core_tabeladeprecowwds_18_tftppinsdata ;
      private DateTime AV87Core_tabeladeprecowwds_19_tftppinsdata_to ;
      private DateTime A238TppInsData ;
      private bool returnInSub ;
      private bool AV66TppDel_Filtro ;
      private bool AV58DynamicFiltersEnabled2 ;
      private bool AV62DynamicFiltersEnabled3 ;
      private bool AV69Core_tabeladeprecowwds_1_tppdel_filtro ;
      private bool AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ;
      private bool AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ;
      private bool A602TppDel ;
      private bool BRK4F2 ;
      private bool BRK4F4 ;
      private string AV51OptionsJson ;
      private string AV52OptionsDescJson ;
      private string AV53OptionIndexesJson ;
      private string AV48DDOName ;
      private string AV49SearchTxtParms ;
      private string AV50SearchTxtTo ;
      private string AV32SearchTxt ;
      private string AV54FilterFullText ;
      private string AV11TFTppCodigo ;
      private string AV12TFTppCodigo_Sel ;
      private string AV13TFTppNome ;
      private string AV14TFTppNome_Sel ;
      private string AV55DynamicFiltersSelector1 ;
      private string AV57TppCodigo1 ;
      private string AV59DynamicFiltersSelector2 ;
      private string AV61TppCodigo2 ;
      private string AV63DynamicFiltersSelector3 ;
      private string AV65TppCodigo3 ;
      private string AV70Core_tabeladeprecowwds_2_filterfulltext ;
      private string AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 ;
      private string AV73Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 ;
      private string AV77Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 ;
      private string AV81Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string AV82Core_tabeladeprecowwds_14_tftppcodigo ;
      private string AV83Core_tabeladeprecowwds_15_tftppcodigo_sel ;
      private string AV84Core_tabeladeprecowwds_16_tftppnome ;
      private string AV85Core_tabeladeprecowwds_17_tftppnome_sel ;
      private string lV70Core_tabeladeprecowwds_2_filterfulltext ;
      private string lV73Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string lV77Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string lV81Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string lV82Core_tabeladeprecowwds_14_tftppcodigo ;
      private string lV84Core_tabeladeprecowwds_16_tftppnome ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string AV37Option ;
      private Guid A235TppID ;
      private IGxSession AV43Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004F2_A236TppCodigo ;
      private DateTime[] P004F2_A238TppInsData ;
      private string[] P004F2_A237TppNome ;
      private bool[] P004F2_A602TppDel ;
      private Guid[] P004F2_A235TppID ;
      private string[] P004F3_A237TppNome ;
      private DateTime[] P004F3_A238TppInsData ;
      private string[] P004F3_A236TppCodigo ;
      private bool[] P004F3_A602TppDel ;
      private Guid[] P004F3_A235TppID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV38Options ;
      private GxSimpleCollection<string> AV40OptionsDesc ;
      private GxSimpleCollection<string> AV41OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV45GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV47GridStateDynamicFilter ;
   }

   public class tabeladeprecowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004F2( IGxContext context ,
                                             string AV70Core_tabeladeprecowwds_2_filterfulltext ,
                                             string AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                             short AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                             string AV73Core_tabeladeprecowwds_5_tppcodigo1 ,
                                             bool AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                             string AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                             short AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                             string AV77Core_tabeladeprecowwds_9_tppcodigo2 ,
                                             bool AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                             string AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                             short AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                             string AV81Core_tabeladeprecowwds_13_tppcodigo3 ,
                                             string AV83Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                             string AV82Core_tabeladeprecowwds_14_tftppcodigo ,
                                             string AV85Core_tabeladeprecowwds_17_tftppnome_sel ,
                                             string AV84Core_tabeladeprecowwds_16_tftppnome ,
                                             DateTime AV86Core_tabeladeprecowwds_18_tftppinsdata ,
                                             DateTime AV87Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                             string A236TppCodigo ,
                                             string A237TppNome ,
                                             DateTime A238TppInsData ,
                                             bool A602TppDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TppCodigo, TppInsData, TppNome, TppDel, TppID FROM tb_tabeladepreco";
         AddWhere(sWhereString, "(Not TppDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_tabeladeprecowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TppCodigo like '%' || :lV70Core_tabeladeprecowwds_2_filterfulltext) or ( TppNome like '%' || :lV70Core_tabeladeprecowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV73Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV73Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV77Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV77Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV81Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV81Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_tabeladeprecowwds_14_tftppcodigo)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV82Core_tabeladeprecowwds_14_tftppcodigo)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ! ( StringUtil.StrCmp(AV83Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppCodigo = ( :AV83Core_tabeladeprecowwds_15_tftppcodigo_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV83Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_17_tftppnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_tabeladeprecowwds_16_tftppnome)) ) )
         {
            AddWhere(sWhereString, "(TppNome like :lV84Core_tabeladeprecowwds_16_tftppnome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_17_tftppnome_sel)) && ! ( StringUtil.StrCmp(AV85Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppNome = ( :AV85Core_tabeladeprecowwds_17_tftppnome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV85Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV86Core_tabeladeprecowwds_18_tftppinsdata) )
         {
            AddWhere(sWhereString, "(TppInsData >= :AV86Core_tabeladeprecowwds_18_tftppinsdata)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Core_tabeladeprecowwds_19_tftppinsdata_to) )
         {
            AddWhere(sWhereString, "(TppInsData <= :AV87Core_tabeladeprecowwds_19_tftppinsdata_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TppCodigo";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004F3( IGxContext context ,
                                             string AV70Core_tabeladeprecowwds_2_filterfulltext ,
                                             string AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                             short AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                             string AV73Core_tabeladeprecowwds_5_tppcodigo1 ,
                                             bool AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                             string AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                             short AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                             string AV77Core_tabeladeprecowwds_9_tppcodigo2 ,
                                             bool AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                             string AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                             short AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                             string AV81Core_tabeladeprecowwds_13_tppcodigo3 ,
                                             string AV83Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                             string AV82Core_tabeladeprecowwds_14_tftppcodigo ,
                                             string AV85Core_tabeladeprecowwds_17_tftppnome_sel ,
                                             string AV84Core_tabeladeprecowwds_16_tftppnome ,
                                             DateTime AV86Core_tabeladeprecowwds_18_tftppinsdata ,
                                             DateTime AV87Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                             string A236TppCodigo ,
                                             string A237TppNome ,
                                             DateTime A238TppInsData ,
                                             bool A602TppDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TppNome, TppInsData, TppCodigo, TppDel, TppID FROM tb_tabeladepreco";
         AddWhere(sWhereString, "(Not TppDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_tabeladeprecowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TppCodigo like '%' || :lV70Core_tabeladeprecowwds_2_filterfulltext) or ( TppNome like '%' || :lV70Core_tabeladeprecowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV73Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV72Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV73Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV77Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV74Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV76Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV77Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV81Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV78Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV80Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV81Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_tabeladeprecowwds_14_tftppcodigo)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV82Core_tabeladeprecowwds_14_tftppcodigo)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ! ( StringUtil.StrCmp(AV83Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppCodigo = ( :AV83Core_tabeladeprecowwds_15_tftppcodigo_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV83Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_17_tftppnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_tabeladeprecowwds_16_tftppnome)) ) )
         {
            AddWhere(sWhereString, "(TppNome like :lV84Core_tabeladeprecowwds_16_tftppnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_17_tftppnome_sel)) && ! ( StringUtil.StrCmp(AV85Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppNome = ( :AV85Core_tabeladeprecowwds_17_tftppnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV85Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV86Core_tabeladeprecowwds_18_tftppinsdata) )
         {
            AddWhere(sWhereString, "(TppInsData >= :AV86Core_tabeladeprecowwds_18_tftppinsdata)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Core_tabeladeprecowwds_19_tftppinsdata_to) )
         {
            AddWhere(sWhereString, "(TppInsData <= :AV87Core_tabeladeprecowwds_19_tftppinsdata_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TppNome";
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
                     return conditional_P004F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (bool)dynConstraints[21] );
               case 1 :
                     return conditional_P004F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmP004F2;
          prmP004F2 = new Object[] {
          new ParDef("lV70Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV73Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV82Core_tabeladeprecowwds_14_tftppcodigo",GXType.VarChar,20,0) ,
          new ParDef("AV83Core_tabeladeprecowwds_15_tftppcodigo_sel",GXType.VarChar,20,0) ,
          new ParDef("lV84Core_tabeladeprecowwds_16_tftppnome",GXType.VarChar,80,0) ,
          new ParDef("AV85Core_tabeladeprecowwds_17_tftppnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV86Core_tabeladeprecowwds_18_tftppinsdata",GXType.Date,8,0) ,
          new ParDef("AV87Core_tabeladeprecowwds_19_tftppinsdata_to",GXType.Date,8,0)
          };
          Object[] prmP004F3;
          prmP004F3 = new Object[] {
          new ParDef("lV70Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV73Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV82Core_tabeladeprecowwds_14_tftppcodigo",GXType.VarChar,20,0) ,
          new ParDef("AV83Core_tabeladeprecowwds_15_tftppcodigo_sel",GXType.VarChar,20,0) ,
          new ParDef("lV84Core_tabeladeprecowwds_16_tftppnome",GXType.VarChar,80,0) ,
          new ParDef("AV85Core_tabeladeprecowwds_17_tftppnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV86Core_tabeladeprecowwds_18_tftppinsdata",GXType.Date,8,0) ,
          new ParDef("AV87Core_tabeladeprecowwds_19_tftppinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004F3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
