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
   public class clientewwgetfilterdata : GXProcedure
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
            return "clienteww_Services_Execute" ;
         }

      }

      public clientewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientewwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         clientewwgetfilterdata objclientewwgetfilterdata;
         objclientewwgetfilterdata = new clientewwgetfilterdata();
         objclientewwgetfilterdata.AV35DDOName = aP0_DDOName;
         objclientewwgetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objclientewwgetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objclientewwgetfilterdata.AV38OptionsJson = "" ;
         objclientewwgetfilterdata.AV39OptionsDescJson = "" ;
         objclientewwgetfilterdata.AV40OptionIndexesJson = "" ;
         objclientewwgetfilterdata.context.SetSubmitInitialConfig(context);
         objclientewwgetfilterdata.initialize();
         Submit( executePrivateCatch,objclientewwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientewwgetfilterdata)stateInfo).executePrivate();
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
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22MaxItems = 10;
         AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
         AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_CLINOMEFAMILIAR") == 0 )
         {
            /* Execute user subroutine: 'LOADCLINOMEFAMILIAROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("core.ClienteWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClienteWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("core.ClienteWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR") == 0 )
            {
               AV11TFCliNomeFamiliar = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV12TFCliNomeFamiliar_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCLIMATRICULA") == 0 )
            {
               AV13TFCliMatricula = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCLITIPO_SEL") == 0 )
            {
               AV15TFCliTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV16TFCliTipo_Sels.FromJSonString(AV15TFCliTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCLIINSDATA") == 0 )
            {
               AV17TFCliInsData = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV18TFCliInsData_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "CLIMATRICULA") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44CliMatricula1 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "CLIMATRICULA") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV48CliMatricula2 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "CLIMATRICULA") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV52CliMatricula3 = (long)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLINOMEFAMILIAROPTIONS' Routine */
         returnInSub = false;
         AV11TFCliNomeFamiliar = AV19SearchTxt;
         AV12TFCliNomeFamiliar_Sel = "";
         AV55Core_clientewwds_1_filterfulltext = AV41FilterFullText;
         AV56Core_clientewwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV57Core_clientewwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV58Core_clientewwds_4_climatricula1 = AV44CliMatricula1;
         AV59Core_clientewwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV60Core_clientewwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV61Core_clientewwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV62Core_clientewwds_8_climatricula2 = AV48CliMatricula2;
         AV63Core_clientewwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV64Core_clientewwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV65Core_clientewwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV66Core_clientewwds_12_climatricula3 = AV52CliMatricula3;
         AV67Core_clientewwds_13_tfclinomefamiliar = AV11TFCliNomeFamiliar;
         AV68Core_clientewwds_14_tfclinomefamiliar_sel = AV12TFCliNomeFamiliar_Sel;
         AV69Core_clientewwds_15_tfclimatricula = AV13TFCliMatricula;
         AV70Core_clientewwds_16_tfclimatricula_to = AV14TFCliMatricula_To;
         AV71Core_clientewwds_17_tfclitipo_sels = AV16TFCliTipo_Sels;
         AV72Core_clientewwds_18_tfcliinsdata = AV17TFCliInsData;
         AV73Core_clientewwds_19_tfcliinsdata_to = AV18TFCliInsData_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A165CliTipo ,
                                              AV71Core_clientewwds_17_tfclitipo_sels ,
                                              AV55Core_clientewwds_1_filterfulltext ,
                                              AV56Core_clientewwds_2_dynamicfiltersselector1 ,
                                              AV57Core_clientewwds_3_dynamicfiltersoperator1 ,
                                              AV58Core_clientewwds_4_climatricula1 ,
                                              AV59Core_clientewwds_5_dynamicfiltersenabled2 ,
                                              AV60Core_clientewwds_6_dynamicfiltersselector2 ,
                                              AV61Core_clientewwds_7_dynamicfiltersoperator2 ,
                                              AV62Core_clientewwds_8_climatricula2 ,
                                              AV63Core_clientewwds_9_dynamicfiltersenabled3 ,
                                              AV64Core_clientewwds_10_dynamicfiltersselector3 ,
                                              AV65Core_clientewwds_11_dynamicfiltersoperator3 ,
                                              AV66Core_clientewwds_12_climatricula3 ,
                                              AV68Core_clientewwds_14_tfclinomefamiliar_sel ,
                                              AV67Core_clientewwds_13_tfclinomefamiliar ,
                                              AV69Core_clientewwds_15_tfclimatricula ,
                                              AV70Core_clientewwds_16_tfclimatricula_to ,
                                              AV71Core_clientewwds_17_tfclitipo_sels.Count ,
                                              AV72Core_clientewwds_18_tfcliinsdata ,
                                              AV73Core_clientewwds_19_tfcliinsdata_to ,
                                              A160CliNomeFamiliar ,
                                              A159CliMatricula ,
                                              A161CliInsData } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV55Core_clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Core_clientewwds_1_filterfulltext), "%", "");
         lV55Core_clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Core_clientewwds_1_filterfulltext), "%", "");
         lV67Core_clientewwds_13_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV67Core_clientewwds_13_tfclinomefamiliar), "%", "");
         /* Using cursor P00432 */
         pr_default.execute(0, new Object[] {lV55Core_clientewwds_1_filterfulltext, lV55Core_clientewwds_1_filterfulltext, AV58Core_clientewwds_4_climatricula1, AV58Core_clientewwds_4_climatricula1, AV58Core_clientewwds_4_climatricula1, AV62Core_clientewwds_8_climatricula2, AV62Core_clientewwds_8_climatricula2, AV62Core_clientewwds_8_climatricula2, AV66Core_clientewwds_12_climatricula3, AV66Core_clientewwds_12_climatricula3, AV66Core_clientewwds_12_climatricula3, lV67Core_clientewwds_13_tfclinomefamiliar, AV68Core_clientewwds_14_tfclinomefamiliar_sel, AV69Core_clientewwds_15_tfclimatricula, AV70Core_clientewwds_16_tfclimatricula_to, AV72Core_clientewwds_18_tfcliinsdata, AV73Core_clientewwds_19_tfcliinsdata_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK432 = false;
            A160CliNomeFamiliar = P00432_A160CliNomeFamiliar[0];
            A161CliInsData = P00432_A161CliInsData[0];
            A165CliTipo = P00432_A165CliTipo[0];
            A159CliMatricula = P00432_A159CliMatricula[0];
            A158CliID = P00432_A158CliID[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00432_A160CliNomeFamiliar[0], A160CliNomeFamiliar) == 0 ) )
            {
               BRK432 = false;
               A158CliID = P00432_A158CliID[0];
               AV29count = (long)(AV29count+1);
               BRK432 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A160CliNomeFamiliar)) ? "<#Empty#>" : A160CliNomeFamiliar);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK432 )
            {
               BRK432 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV11TFCliNomeFamiliar = "";
         AV12TFCliNomeFamiliar_Sel = "";
         AV15TFCliTipo_SelsJson = "";
         AV16TFCliTipo_Sels = new GxSimpleCollection<short>();
         AV17TFCliInsData = DateTime.MinValue;
         AV18TFCliInsData_To = DateTime.MinValue;
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV55Core_clientewwds_1_filterfulltext = "";
         AV56Core_clientewwds_2_dynamicfiltersselector1 = "";
         AV60Core_clientewwds_6_dynamicfiltersselector2 = "";
         AV64Core_clientewwds_10_dynamicfiltersselector3 = "";
         AV67Core_clientewwds_13_tfclinomefamiliar = "";
         AV68Core_clientewwds_14_tfclinomefamiliar_sel = "";
         AV71Core_clientewwds_17_tfclitipo_sels = new GxSimpleCollection<short>();
         AV72Core_clientewwds_18_tfcliinsdata = DateTime.MinValue;
         AV73Core_clientewwds_19_tfcliinsdata_to = DateTime.MinValue;
         scmdbuf = "";
         lV55Core_clientewwds_1_filterfulltext = "";
         lV67Core_clientewwds_13_tfclinomefamiliar = "";
         A160CliNomeFamiliar = "";
         A161CliInsData = DateTime.MinValue;
         P00432_A160CliNomeFamiliar = new string[] {""} ;
         P00432_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         P00432_A165CliTipo = new short[1] ;
         P00432_A159CliMatricula = new long[1] ;
         P00432_A158CliID = new Guid[] {Guid.Empty} ;
         A158CliID = Guid.Empty;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00432_A160CliNomeFamiliar, P00432_A161CliInsData, P00432_A165CliTipo, P00432_A159CliMatricula, P00432_A158CliID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV43DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV57Core_clientewwds_3_dynamicfiltersoperator1 ;
      private short AV61Core_clientewwds_7_dynamicfiltersoperator2 ;
      private short AV65Core_clientewwds_11_dynamicfiltersoperator3 ;
      private short A165CliTipo ;
      private int AV53GXV1 ;
      private int AV71Core_clientewwds_17_tfclitipo_sels_Count ;
      private long AV13TFCliMatricula ;
      private long AV14TFCliMatricula_To ;
      private long AV44CliMatricula1 ;
      private long AV48CliMatricula2 ;
      private long AV52CliMatricula3 ;
      private long AV58Core_clientewwds_4_climatricula1 ;
      private long AV62Core_clientewwds_8_climatricula2 ;
      private long AV66Core_clientewwds_12_climatricula3 ;
      private long AV69Core_clientewwds_15_tfclimatricula ;
      private long AV70Core_clientewwds_16_tfclimatricula_to ;
      private long A159CliMatricula ;
      private long AV29count ;
      private string scmdbuf ;
      private DateTime AV17TFCliInsData ;
      private DateTime AV18TFCliInsData_To ;
      private DateTime AV72Core_clientewwds_18_tfcliinsdata ;
      private DateTime AV73Core_clientewwds_19_tfcliinsdata_to ;
      private DateTime A161CliInsData ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV59Core_clientewwds_5_dynamicfiltersenabled2 ;
      private bool AV63Core_clientewwds_9_dynamicfiltersenabled3 ;
      private bool BRK432 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV15TFCliTipo_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV11TFCliNomeFamiliar ;
      private string AV12TFCliNomeFamiliar_Sel ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV55Core_clientewwds_1_filterfulltext ;
      private string AV56Core_clientewwds_2_dynamicfiltersselector1 ;
      private string AV60Core_clientewwds_6_dynamicfiltersselector2 ;
      private string AV64Core_clientewwds_10_dynamicfiltersselector3 ;
      private string AV67Core_clientewwds_13_tfclinomefamiliar ;
      private string AV68Core_clientewwds_14_tfclinomefamiliar_sel ;
      private string lV55Core_clientewwds_1_filterfulltext ;
      private string lV67Core_clientewwds_13_tfclinomefamiliar ;
      private string A160CliNomeFamiliar ;
      private string AV24Option ;
      private Guid A158CliID ;
      private GxSimpleCollection<short> AV16TFCliTipo_Sels ;
      private GxSimpleCollection<short> AV71Core_clientewwds_17_tfclitipo_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00432_A160CliNomeFamiliar ;
      private DateTime[] P00432_A161CliInsData ;
      private short[] P00432_A165CliTipo ;
      private long[] P00432_A159CliMatricula ;
      private Guid[] P00432_A158CliID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
   }

   public class clientewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00432( IGxContext context ,
                                             short A165CliTipo ,
                                             GxSimpleCollection<short> AV71Core_clientewwds_17_tfclitipo_sels ,
                                             string AV55Core_clientewwds_1_filterfulltext ,
                                             string AV56Core_clientewwds_2_dynamicfiltersselector1 ,
                                             short AV57Core_clientewwds_3_dynamicfiltersoperator1 ,
                                             long AV58Core_clientewwds_4_climatricula1 ,
                                             bool AV59Core_clientewwds_5_dynamicfiltersenabled2 ,
                                             string AV60Core_clientewwds_6_dynamicfiltersselector2 ,
                                             short AV61Core_clientewwds_7_dynamicfiltersoperator2 ,
                                             long AV62Core_clientewwds_8_climatricula2 ,
                                             bool AV63Core_clientewwds_9_dynamicfiltersenabled3 ,
                                             string AV64Core_clientewwds_10_dynamicfiltersselector3 ,
                                             short AV65Core_clientewwds_11_dynamicfiltersoperator3 ,
                                             long AV66Core_clientewwds_12_climatricula3 ,
                                             string AV68Core_clientewwds_14_tfclinomefamiliar_sel ,
                                             string AV67Core_clientewwds_13_tfclinomefamiliar ,
                                             long AV69Core_clientewwds_15_tfclimatricula ,
                                             long AV70Core_clientewwds_16_tfclimatricula_to ,
                                             int AV71Core_clientewwds_17_tfclitipo_sels_Count ,
                                             DateTime AV72Core_clientewwds_18_tfcliinsdata ,
                                             DateTime AV73Core_clientewwds_19_tfcliinsdata_to ,
                                             string A160CliNomeFamiliar ,
                                             long A159CliMatricula ,
                                             DateTime A161CliInsData )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CliNomeFamiliar, CliInsData, CliTipo, CliMatricula, CliID FROM tb_cliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CliNomeFamiliar like '%' || :lV55Core_clientewwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(CliMatricula,'999999999999'), 2) like '%' || :lV55Core_clientewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV57Core_clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV58Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV58Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV57Core_clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV58Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV58Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV57Core_clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV58Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV58Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV59Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV61Core_clientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV62Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV62Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV59Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV61Core_clientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV62Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV62Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV59Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV61Core_clientewwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV62Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV62Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV63Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV65Core_clientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV66Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV66Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV63Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV65Core_clientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV66Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV66Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV63Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV65Core_clientewwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV66Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV66Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientewwds_14_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_clientewwds_13_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(CliNomeFamiliar like :lV67Core_clientewwds_13_tfclinomefamiliar)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientewwds_14_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV68Core_clientewwds_14_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CliNomeFamiliar = ( :AV68Core_clientewwds_14_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Core_clientewwds_14_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV69Core_clientewwds_15_tfclimatricula) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV69Core_clientewwds_15_tfclimatricula)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV70Core_clientewwds_16_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV70Core_clientewwds_16_tfclimatricula_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV71Core_clientewwds_17_tfclitipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71Core_clientewwds_17_tfclitipo_sels, "CliTipo IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV72Core_clientewwds_18_tfcliinsdata) )
         {
            AddWhere(sWhereString, "(CliInsData >= :AV72Core_clientewwds_18_tfcliinsdata)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Core_clientewwds_19_tfcliinsdata_to) )
         {
            AddWhere(sWhereString, "(CliInsData <= :AV73Core_clientewwds_19_tfcliinsdata_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CliNomeFamiliar";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00432(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (DateTime)dynConstraints[23] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00432;
          prmP00432 = new Object[] {
          new ParDef("lV55Core_clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Core_clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV58Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV58Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV58Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV62Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV62Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV62Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV66Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("AV66Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("AV66Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("lV67Core_clientewwds_13_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV68Core_clientewwds_14_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV69Core_clientewwds_15_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV70Core_clientewwds_16_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("AV72Core_clientewwds_18_tfcliinsdata",GXType.Date,8,0) ,
          new ParDef("AV73Core_clientewwds_19_tfcliinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00432", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00432,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
