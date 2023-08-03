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
   public class clientepjtipowwgetfilterdata : GXProcedure
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
            return "clientepjtipoww_Services_Execute" ;
         }

      }

      public clientepjtipowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjtipowwgetfilterdata( IGxContext context )
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
         clientepjtipowwgetfilterdata objclientepjtipowwgetfilterdata;
         objclientepjtipowwgetfilterdata = new clientepjtipowwgetfilterdata();
         objclientepjtipowwgetfilterdata.AV33DDOName = aP0_DDOName;
         objclientepjtipowwgetfilterdata.AV34SearchTxtParms = aP1_SearchTxtParms;
         objclientepjtipowwgetfilterdata.AV35SearchTxtTo = aP2_SearchTxtTo;
         objclientepjtipowwgetfilterdata.AV36OptionsJson = "" ;
         objclientepjtipowwgetfilterdata.AV37OptionsDescJson = "" ;
         objclientepjtipowwgetfilterdata.AV38OptionIndexesJson = "" ;
         objclientepjtipowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objclientepjtipowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objclientepjtipowwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientepjtipowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_PJTSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADPJTSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_PJTNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPJTNOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.ClientePJTipoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClientePJTipoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.ClientePJTipoWWGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPJTSIGLA") == 0 )
            {
               AV61TFPjtSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPJTSIGLA_SEL") == 0 )
            {
               AV62TFPjtSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPJTNOME") == 0 )
            {
               AV56TFPjtNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPJTNOME_SEL") == 0 )
            {
               AV57TFPjtNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "PJTNOME") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV58PjtNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "PJTNOME") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV59PjtNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "PJTNOME") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV60PjtNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPJTSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV61TFPjtSigla = AV17SearchTxt;
         AV62TFPjtSigla_Sel = "";
         AV65Core_clientepjtipowwds_1_filterfulltext = AV39FilterFullText;
         AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV68Core_clientepjtipowwds_4_pjtnome1 = AV58PjtNome1;
         AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV72Core_clientepjtipowwds_8_pjtnome2 = AV59PjtNome2;
         AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV76Core_clientepjtipowwds_12_pjtnome3 = AV60PjtNome3;
         AV77Core_clientepjtipowwds_13_tfpjtsigla = AV61TFPjtSigla;
         AV78Core_clientepjtipowwds_14_tfpjtsigla_sel = AV62TFPjtSigla_Sel;
         AV79Core_clientepjtipowwds_15_tfpjtnome = AV56TFPjtNome;
         AV80Core_clientepjtipowwds_16_tfpjtnome_sel = AV57TFPjtNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV65Core_clientepjtipowwds_1_filterfulltext ,
                                              AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 ,
                                              AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 ,
                                              AV68Core_clientepjtipowwds_4_pjtnome1 ,
                                              AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 ,
                                              AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 ,
                                              AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 ,
                                              AV72Core_clientepjtipowwds_8_pjtnome2 ,
                                              AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 ,
                                              AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 ,
                                              AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 ,
                                              AV76Core_clientepjtipowwds_12_pjtnome3 ,
                                              AV78Core_clientepjtipowwds_14_tfpjtsigla_sel ,
                                              AV77Core_clientepjtipowwds_13_tfpjtsigla ,
                                              AV80Core_clientepjtipowwds_16_tfpjtnome_sel ,
                                              AV79Core_clientepjtipowwds_15_tfpjtnome ,
                                              A156PjtSigla ,
                                              A157PjtNome } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV65Core_clientepjtipowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_clientepjtipowwds_1_filterfulltext), "%", "");
         lV65Core_clientepjtipowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_clientepjtipowwds_1_filterfulltext), "%", "");
         lV68Core_clientepjtipowwds_4_pjtnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1), "%", "");
         lV68Core_clientepjtipowwds_4_pjtnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1), "%", "");
         lV72Core_clientepjtipowwds_8_pjtnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2), "%", "");
         lV72Core_clientepjtipowwds_8_pjtnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2), "%", "");
         lV76Core_clientepjtipowwds_12_pjtnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3), "%", "");
         lV76Core_clientepjtipowwds_12_pjtnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3), "%", "");
         lV77Core_clientepjtipowwds_13_tfpjtsigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_clientepjtipowwds_13_tfpjtsigla), "%", "");
         lV79Core_clientepjtipowwds_15_tfpjtnome = StringUtil.Concat( StringUtil.RTrim( AV79Core_clientepjtipowwds_15_tfpjtnome), "%", "");
         /* Using cursor P00402 */
         pr_default.execute(0, new Object[] {lV65Core_clientepjtipowwds_1_filterfulltext, lV65Core_clientepjtipowwds_1_filterfulltext, lV68Core_clientepjtipowwds_4_pjtnome1, lV68Core_clientepjtipowwds_4_pjtnome1, lV72Core_clientepjtipowwds_8_pjtnome2, lV72Core_clientepjtipowwds_8_pjtnome2, lV76Core_clientepjtipowwds_12_pjtnome3, lV76Core_clientepjtipowwds_12_pjtnome3, lV77Core_clientepjtipowwds_13_tfpjtsigla, AV78Core_clientepjtipowwds_14_tfpjtsigla_sel, lV79Core_clientepjtipowwds_15_tfpjtnome, AV80Core_clientepjtipowwds_16_tfpjtnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK402 = false;
            A156PjtSigla = P00402_A156PjtSigla[0];
            A157PjtNome = P00402_A157PjtNome[0];
            A155PjtID = P00402_A155PjtID[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00402_A156PjtSigla[0], A156PjtSigla) == 0 ) )
            {
               BRK402 = false;
               A155PjtID = P00402_A155PjtID[0];
               AV27count = (long)(AV27count+1);
               BRK402 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A156PjtSigla)) ? "<#Empty#>" : A156PjtSigla);
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
            if ( ! BRK402 )
            {
               BRK402 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPJTNOMEOPTIONS' Routine */
         returnInSub = false;
         AV56TFPjtNome = AV17SearchTxt;
         AV57TFPjtNome_Sel = "";
         AV65Core_clientepjtipowwds_1_filterfulltext = AV39FilterFullText;
         AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV68Core_clientepjtipowwds_4_pjtnome1 = AV58PjtNome1;
         AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV72Core_clientepjtipowwds_8_pjtnome2 = AV59PjtNome2;
         AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV76Core_clientepjtipowwds_12_pjtnome3 = AV60PjtNome3;
         AV77Core_clientepjtipowwds_13_tfpjtsigla = AV61TFPjtSigla;
         AV78Core_clientepjtipowwds_14_tfpjtsigla_sel = AV62TFPjtSigla_Sel;
         AV79Core_clientepjtipowwds_15_tfpjtnome = AV56TFPjtNome;
         AV80Core_clientepjtipowwds_16_tfpjtnome_sel = AV57TFPjtNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Core_clientepjtipowwds_1_filterfulltext ,
                                              AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 ,
                                              AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 ,
                                              AV68Core_clientepjtipowwds_4_pjtnome1 ,
                                              AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 ,
                                              AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 ,
                                              AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 ,
                                              AV72Core_clientepjtipowwds_8_pjtnome2 ,
                                              AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 ,
                                              AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 ,
                                              AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 ,
                                              AV76Core_clientepjtipowwds_12_pjtnome3 ,
                                              AV78Core_clientepjtipowwds_14_tfpjtsigla_sel ,
                                              AV77Core_clientepjtipowwds_13_tfpjtsigla ,
                                              AV80Core_clientepjtipowwds_16_tfpjtnome_sel ,
                                              AV79Core_clientepjtipowwds_15_tfpjtnome ,
                                              A156PjtSigla ,
                                              A157PjtNome } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV65Core_clientepjtipowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_clientepjtipowwds_1_filterfulltext), "%", "");
         lV65Core_clientepjtipowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_clientepjtipowwds_1_filterfulltext), "%", "");
         lV68Core_clientepjtipowwds_4_pjtnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1), "%", "");
         lV68Core_clientepjtipowwds_4_pjtnome1 = StringUtil.Concat( StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1), "%", "");
         lV72Core_clientepjtipowwds_8_pjtnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2), "%", "");
         lV72Core_clientepjtipowwds_8_pjtnome2 = StringUtil.Concat( StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2), "%", "");
         lV76Core_clientepjtipowwds_12_pjtnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3), "%", "");
         lV76Core_clientepjtipowwds_12_pjtnome3 = StringUtil.Concat( StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3), "%", "");
         lV77Core_clientepjtipowwds_13_tfpjtsigla = StringUtil.Concat( StringUtil.RTrim( AV77Core_clientepjtipowwds_13_tfpjtsigla), "%", "");
         lV79Core_clientepjtipowwds_15_tfpjtnome = StringUtil.Concat( StringUtil.RTrim( AV79Core_clientepjtipowwds_15_tfpjtnome), "%", "");
         /* Using cursor P00403 */
         pr_default.execute(1, new Object[] {lV65Core_clientepjtipowwds_1_filterfulltext, lV65Core_clientepjtipowwds_1_filterfulltext, lV68Core_clientepjtipowwds_4_pjtnome1, lV68Core_clientepjtipowwds_4_pjtnome1, lV72Core_clientepjtipowwds_8_pjtnome2, lV72Core_clientepjtipowwds_8_pjtnome2, lV76Core_clientepjtipowwds_12_pjtnome3, lV76Core_clientepjtipowwds_12_pjtnome3, lV77Core_clientepjtipowwds_13_tfpjtsigla, AV78Core_clientepjtipowwds_14_tfpjtsigla_sel, lV79Core_clientepjtipowwds_15_tfpjtnome, AV80Core_clientepjtipowwds_16_tfpjtnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK404 = false;
            A157PjtNome = P00403_A157PjtNome[0];
            A156PjtSigla = P00403_A156PjtSigla[0];
            A155PjtID = P00403_A155PjtID[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00403_A157PjtNome[0], A157PjtNome) == 0 ) )
            {
               BRK404 = false;
               A155PjtID = P00403_A155PjtID[0];
               AV27count = (long)(AV27count+1);
               BRK404 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A157PjtNome)) ? "<#Empty#>" : A157PjtNome);
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
            if ( ! BRK404 )
            {
               BRK404 = true;
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
         AV61TFPjtSigla = "";
         AV62TFPjtSigla_Sel = "";
         AV56TFPjtNome = "";
         AV57TFPjtNome_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV58PjtNome1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV59PjtNome2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV60PjtNome3 = "";
         AV65Core_clientepjtipowwds_1_filterfulltext = "";
         AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 = "";
         AV68Core_clientepjtipowwds_4_pjtnome1 = "";
         AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 = "";
         AV72Core_clientepjtipowwds_8_pjtnome2 = "";
         AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 = "";
         AV76Core_clientepjtipowwds_12_pjtnome3 = "";
         AV77Core_clientepjtipowwds_13_tfpjtsigla = "";
         AV78Core_clientepjtipowwds_14_tfpjtsigla_sel = "";
         AV79Core_clientepjtipowwds_15_tfpjtnome = "";
         AV80Core_clientepjtipowwds_16_tfpjtnome_sel = "";
         scmdbuf = "";
         lV65Core_clientepjtipowwds_1_filterfulltext = "";
         lV68Core_clientepjtipowwds_4_pjtnome1 = "";
         lV72Core_clientepjtipowwds_8_pjtnome2 = "";
         lV76Core_clientepjtipowwds_12_pjtnome3 = "";
         lV77Core_clientepjtipowwds_13_tfpjtsigla = "";
         lV79Core_clientepjtipowwds_15_tfpjtnome = "";
         A156PjtSigla = "";
         A157PjtNome = "";
         P00402_A156PjtSigla = new string[] {""} ;
         P00402_A157PjtNome = new string[] {""} ;
         P00402_A155PjtID = new int[1] ;
         AV22Option = "";
         P00403_A157PjtNome = new string[] {""} ;
         P00403_A156PjtSigla = new string[] {""} ;
         P00403_A155PjtID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjtipowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00402_A156PjtSigla, P00402_A157PjtNome, P00402_A155PjtID
               }
               , new Object[] {
               P00403_A157PjtNome, P00403_A156PjtSigla, P00403_A155PjtID
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
      private short AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 ;
      private short AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 ;
      private short AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 ;
      private int AV63GXV1 ;
      private int A155PjtID ;
      private long AV27count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 ;
      private bool AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 ;
      private bool BRK402 ;
      private bool BRK404 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV61TFPjtSigla ;
      private string AV62TFPjtSigla_Sel ;
      private string AV56TFPjtNome ;
      private string AV57TFPjtNome_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV58PjtNome1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV59PjtNome2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV60PjtNome3 ;
      private string AV65Core_clientepjtipowwds_1_filterfulltext ;
      private string AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 ;
      private string AV68Core_clientepjtipowwds_4_pjtnome1 ;
      private string AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 ;
      private string AV72Core_clientepjtipowwds_8_pjtnome2 ;
      private string AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 ;
      private string AV76Core_clientepjtipowwds_12_pjtnome3 ;
      private string AV77Core_clientepjtipowwds_13_tfpjtsigla ;
      private string AV78Core_clientepjtipowwds_14_tfpjtsigla_sel ;
      private string AV79Core_clientepjtipowwds_15_tfpjtnome ;
      private string AV80Core_clientepjtipowwds_16_tfpjtnome_sel ;
      private string lV65Core_clientepjtipowwds_1_filterfulltext ;
      private string lV68Core_clientepjtipowwds_4_pjtnome1 ;
      private string lV72Core_clientepjtipowwds_8_pjtnome2 ;
      private string lV76Core_clientepjtipowwds_12_pjtnome3 ;
      private string lV77Core_clientepjtipowwds_13_tfpjtsigla ;
      private string lV79Core_clientepjtipowwds_15_tfpjtnome ;
      private string A156PjtSigla ;
      private string A157PjtNome ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00402_A156PjtSigla ;
      private string[] P00402_A157PjtNome ;
      private int[] P00402_A155PjtID ;
      private string[] P00403_A157PjtNome ;
      private string[] P00403_A156PjtSigla ;
      private int[] P00403_A155PjtID ;
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

   public class clientepjtipowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00402( IGxContext context ,
                                             string AV65Core_clientepjtipowwds_1_filterfulltext ,
                                             string AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 ,
                                             short AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 ,
                                             string AV68Core_clientepjtipowwds_4_pjtnome1 ,
                                             bool AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 ,
                                             string AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 ,
                                             short AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 ,
                                             string AV72Core_clientepjtipowwds_8_pjtnome2 ,
                                             bool AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 ,
                                             string AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 ,
                                             short AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 ,
                                             string AV76Core_clientepjtipowwds_12_pjtnome3 ,
                                             string AV78Core_clientepjtipowwds_14_tfpjtsigla_sel ,
                                             string AV77Core_clientepjtipowwds_13_tfpjtsigla ,
                                             string AV80Core_clientepjtipowwds_16_tfpjtnome_sel ,
                                             string AV79Core_clientepjtipowwds_15_tfpjtnome ,
                                             string A156PjtSigla ,
                                             string A157PjtNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT PjtSigla, PjtNome, PjtID FROM tb_clientepjtipo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_clientepjtipowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PjtSigla like '%' || :lV65Core_clientepjtipowwds_1_filterfulltext) or ( PjtNome like '%' || :lV65Core_clientepjtipowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_clientepjtipowwds_2_dynamicfiltersselector1, "PJTNOME") == 0 ) && ( AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV68Core_clientepjtipowwds_4_pjtnome1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_clientepjtipowwds_2_dynamicfiltersselector1, "PJTNOME") == 0 ) && ( AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV68Core_clientepjtipowwds_4_pjtnome1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_clientepjtipowwds_6_dynamicfiltersselector2, "PJTNOME") == 0 ) && ( AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV72Core_clientepjtipowwds_8_pjtnome2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_clientepjtipowwds_6_dynamicfiltersselector2, "PJTNOME") == 0 ) && ( AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV72Core_clientepjtipowwds_8_pjtnome2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_clientepjtipowwds_10_dynamicfiltersselector3, "PJTNOME") == 0 ) && ( AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV76Core_clientepjtipowwds_12_pjtnome3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_clientepjtipowwds_10_dynamicfiltersselector3, "PJTNOME") == 0 ) && ( AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV76Core_clientepjtipowwds_12_pjtnome3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_clientepjtipowwds_14_tfpjtsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_clientepjtipowwds_13_tfpjtsigla)) ) )
         {
            AddWhere(sWhereString, "(PjtSigla like :lV77Core_clientepjtipowwds_13_tfpjtsigla)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_clientepjtipowwds_14_tfpjtsigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_clientepjtipowwds_14_tfpjtsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PjtSigla = ( :AV78Core_clientepjtipowwds_14_tfpjtsigla_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_clientepjtipowwds_14_tfpjtsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PjtSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_clientepjtipowwds_16_tfpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_clientepjtipowwds_15_tfpjtnome)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV79Core_clientepjtipowwds_15_tfpjtnome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_clientepjtipowwds_16_tfpjtnome_sel)) && ! ( StringUtil.StrCmp(AV80Core_clientepjtipowwds_16_tfpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PjtNome = ( :AV80Core_clientepjtipowwds_16_tfpjtnome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Core_clientepjtipowwds_16_tfpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PjtNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PjtSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00403( IGxContext context ,
                                             string AV65Core_clientepjtipowwds_1_filterfulltext ,
                                             string AV66Core_clientepjtipowwds_2_dynamicfiltersselector1 ,
                                             short AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 ,
                                             string AV68Core_clientepjtipowwds_4_pjtnome1 ,
                                             bool AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 ,
                                             string AV70Core_clientepjtipowwds_6_dynamicfiltersselector2 ,
                                             short AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 ,
                                             string AV72Core_clientepjtipowwds_8_pjtnome2 ,
                                             bool AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 ,
                                             string AV74Core_clientepjtipowwds_10_dynamicfiltersselector3 ,
                                             short AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 ,
                                             string AV76Core_clientepjtipowwds_12_pjtnome3 ,
                                             string AV78Core_clientepjtipowwds_14_tfpjtsigla_sel ,
                                             string AV77Core_clientepjtipowwds_13_tfpjtsigla ,
                                             string AV80Core_clientepjtipowwds_16_tfpjtnome_sel ,
                                             string AV79Core_clientepjtipowwds_15_tfpjtnome ,
                                             string A156PjtSigla ,
                                             string A157PjtNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PjtNome, PjtSigla, PjtID FROM tb_clientepjtipo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_clientepjtipowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PjtSigla like '%' || :lV65Core_clientepjtipowwds_1_filterfulltext) or ( PjtNome like '%' || :lV65Core_clientepjtipowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_clientepjtipowwds_2_dynamicfiltersselector1, "PJTNOME") == 0 ) && ( AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV68Core_clientepjtipowwds_4_pjtnome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Core_clientepjtipowwds_2_dynamicfiltersselector1, "PJTNOME") == 0 ) && ( AV67Core_clientepjtipowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientepjtipowwds_4_pjtnome1)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV68Core_clientepjtipowwds_4_pjtnome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_clientepjtipowwds_6_dynamicfiltersselector2, "PJTNOME") == 0 ) && ( AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV72Core_clientepjtipowwds_8_pjtnome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV69Core_clientepjtipowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Core_clientepjtipowwds_6_dynamicfiltersselector2, "PJTNOME") == 0 ) && ( AV71Core_clientepjtipowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_clientepjtipowwds_8_pjtnome2)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV72Core_clientepjtipowwds_8_pjtnome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_clientepjtipowwds_10_dynamicfiltersselector3, "PJTNOME") == 0 ) && ( AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV76Core_clientepjtipowwds_12_pjtnome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV73Core_clientepjtipowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Core_clientepjtipowwds_10_dynamicfiltersselector3, "PJTNOME") == 0 ) && ( AV75Core_clientepjtipowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_clientepjtipowwds_12_pjtnome3)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV76Core_clientepjtipowwds_12_pjtnome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_clientepjtipowwds_14_tfpjtsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_clientepjtipowwds_13_tfpjtsigla)) ) )
         {
            AddWhere(sWhereString, "(PjtSigla like :lV77Core_clientepjtipowwds_13_tfpjtsigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_clientepjtipowwds_14_tfpjtsigla_sel)) && ! ( StringUtil.StrCmp(AV78Core_clientepjtipowwds_14_tfpjtsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PjtSigla = ( :AV78Core_clientepjtipowwds_14_tfpjtsigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_clientepjtipowwds_14_tfpjtsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PjtSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_clientepjtipowwds_16_tfpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_clientepjtipowwds_15_tfpjtnome)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV79Core_clientepjtipowwds_15_tfpjtnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_clientepjtipowwds_16_tfpjtnome_sel)) && ! ( StringUtil.StrCmp(AV80Core_clientepjtipowwds_16_tfpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PjtNome = ( :AV80Core_clientepjtipowwds_16_tfpjtnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Core_clientepjtipowwds_16_tfpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PjtNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PjtNome";
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
                     return conditional_P00402(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P00403(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00402;
          prmP00402 = new Object[] {
          new ParDef("lV65Core_clientepjtipowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_clientepjtipowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Core_clientepjtipowwds_4_pjtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_clientepjtipowwds_4_pjtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_clientepjtipowwds_8_pjtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_clientepjtipowwds_8_pjtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_clientepjtipowwds_12_pjtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_clientepjtipowwds_12_pjtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_clientepjtipowwds_13_tfpjtsigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_clientepjtipowwds_14_tfpjtsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV79Core_clientepjtipowwds_15_tfpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV80Core_clientepjtipowwds_16_tfpjtnome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP00403;
          prmP00403 = new Object[] {
          new ParDef("lV65Core_clientepjtipowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_clientepjtipowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Core_clientepjtipowwds_4_pjtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_clientepjtipowwds_4_pjtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_clientepjtipowwds_8_pjtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_clientepjtipowwds_8_pjtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_clientepjtipowwds_12_pjtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_clientepjtipowwds_12_pjtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV77Core_clientepjtipowwds_13_tfpjtsigla",GXType.VarChar,20,0) ,
          new ParDef("AV78Core_clientepjtipowwds_14_tfpjtsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV79Core_clientepjtipowwds_15_tfpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV80Core_clientepjtipowwds_16_tfpjtnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00402", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00402,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00403", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00403,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
