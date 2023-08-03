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
   public class auditwwgetfilterdata : GXProcedure
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
            return "auditww_Services_Execute" ;
         }

      }

      public auditwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditwwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         auditwwgetfilterdata objauditwwgetfilterdata;
         objauditwwgetfilterdata = new auditwwgetfilterdata();
         objauditwwgetfilterdata.AV41DDOName = aP0_DDOName;
         objauditwwgetfilterdata.AV42SearchTxtParms = aP1_SearchTxtParms;
         objauditwwgetfilterdata.AV43SearchTxtTo = aP2_SearchTxtTo;
         objauditwwgetfilterdata.AV44OptionsJson = "" ;
         objauditwwgetfilterdata.AV45OptionsDescJson = "" ;
         objauditwwgetfilterdata.AV46OptionIndexesJson = "" ;
         objauditwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objauditwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objauditwwgetfilterdata);
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auditwwgetfilterdata)stateInfo).executePrivate();
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
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITTABLENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITTABLENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITACTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITACTIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITSHORTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITSHORTDESCRIPTIONOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITDESCRIPTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_AUDITGAMUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADAUDITGAMUSERNAMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("core.AuditWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.AuditWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("core.AuditWWGridState"), null, "", "");
         }
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDATETIME") == 0 )
            {
               AV62TFAuditDateTime = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV63TFAuditDateTime_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV11TFAuditDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV12TFAuditDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTIME") == 0 )
            {
               AV13TFAuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2));
               AV14TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV15TFAuditTableName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV16TFAuditTableName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV23TFAuditAction = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV24TFAuditAction_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV17TFAuditShortDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV18TFAuditShortDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV19TFAuditDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV20TFAuditDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME") == 0 )
            {
               AV21TFAuditGAMUserName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME_SEL") == 0 )
            {
               AV22TFAuditGAMUserName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "AUDITDATE") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV50AuditDate1 = context.localUtil.CToD( AV40GridStateDynamicFilter.gxTpr_Value, 2);
               AV51AuditDate_To1 = context.localUtil.CToD( AV40GridStateDynamicFilter.gxTpr_Valueto, 2);
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV52DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV53DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "AUDITDATE") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV55AuditDate2 = context.localUtil.CToD( AV40GridStateDynamicFilter.gxTpr_Value, 2);
                  AV56AuditDate_To2 = context.localUtil.CToD( AV40GridStateDynamicFilter.gxTpr_Valueto, 2);
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "AUDITDATE") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV60AuditDate3 = context.localUtil.CToD( AV40GridStateDynamicFilter.gxTpr_Value, 2);
                     AV61AuditDate_To3 = context.localUtil.CToD( AV40GridStateDynamicFilter.gxTpr_Valueto, 2);
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADAUDITTABLENAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFAuditTableName = AV25SearchTxt;
         AV16TFAuditTableName_Sel = "";
         AV66Core_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV67Core_auditwwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV68Core_auditwwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV69Core_auditwwds_4_auditdate1 = AV50AuditDate1;
         AV70Core_auditwwds_5_auditdate_to1 = AV51AuditDate_To1;
         AV71Core_auditwwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV72Core_auditwwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV73Core_auditwwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV74Core_auditwwds_9_auditdate2 = AV55AuditDate2;
         AV75Core_auditwwds_10_auditdate_to2 = AV56AuditDate_To2;
         AV76Core_auditwwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV77Core_auditwwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV78Core_auditwwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV79Core_auditwwds_14_auditdate3 = AV60AuditDate3;
         AV80Core_auditwwds_15_auditdate_to3 = AV61AuditDate_To3;
         AV81Core_auditwwds_16_tfauditdatetime = AV62TFAuditDateTime;
         AV82Core_auditwwds_17_tfauditdatetime_to = AV63TFAuditDateTime_To;
         AV83Core_auditwwds_18_tfauditdate = AV11TFAuditDate;
         AV84Core_auditwwds_19_tfauditdate_to = AV12TFAuditDate_To;
         AV85Core_auditwwds_20_tfaudittime = AV13TFAuditTime;
         AV86Core_auditwwds_21_tfaudittime_to = AV14TFAuditTime_To;
         AV87Core_auditwwds_22_tfaudittablename = AV15TFAuditTableName;
         AV88Core_auditwwds_23_tfaudittablename_sel = AV16TFAuditTableName_Sel;
         AV89Core_auditwwds_24_tfauditaction = AV23TFAuditAction;
         AV90Core_auditwwds_25_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV91Core_auditwwds_26_tfauditshortdescription = AV17TFAuditShortDescription;
         AV92Core_auditwwds_27_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV93Core_auditwwds_28_tfauditdescription = AV19TFAuditDescription;
         AV94Core_auditwwds_29_tfauditdescription_sel = AV20TFAuditDescription_Sel;
         AV95Core_auditwwds_30_tfauditgamusername = AV21TFAuditGAMUserName;
         AV96Core_auditwwds_31_tfauditgamusername_sel = AV22TFAuditGAMUserName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Core_auditwwds_1_filterfulltext ,
                                              AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV69Core_auditwwds_4_auditdate1 ,
                                              AV70Core_auditwwds_5_auditdate_to1 ,
                                              AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV74Core_auditwwds_9_auditdate2 ,
                                              AV75Core_auditwwds_10_auditdate_to2 ,
                                              AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV79Core_auditwwds_14_auditdate3 ,
                                              AV80Core_auditwwds_15_auditdate_to3 ,
                                              AV81Core_auditwwds_16_tfauditdatetime ,
                                              AV82Core_auditwwds_17_tfauditdatetime_to ,
                                              AV83Core_auditwwds_18_tfauditdate ,
                                              AV84Core_auditwwds_19_tfauditdate_to ,
                                              AV85Core_auditwwds_20_tfaudittime ,
                                              AV86Core_auditwwds_21_tfaudittime_to ,
                                              AV88Core_auditwwds_23_tfaudittablename_sel ,
                                              AV87Core_auditwwds_22_tfaudittablename ,
                                              AV90Core_auditwwds_25_tfauditaction_sel ,
                                              AV89Core_auditwwds_24_tfauditaction ,
                                              AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV91Core_auditwwds_26_tfauditshortdescription ,
                                              AV94Core_auditwwds_29_tfauditdescription_sel ,
                                              AV93Core_auditwwds_28_tfauditdescription ,
                                              AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV95Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV87Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename), "%", "");
         lV89Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction), "%", "");
         lV91Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV93Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription), "%", "");
         lV95Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007K2 */
         pr_default.execute(0, new Object[] {lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, AV69Core_auditwwds_4_auditdate1, AV70Core_auditwwds_5_auditdate_to1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV74Core_auditwwds_9_auditdate2, AV75Core_auditwwds_10_auditdate_to2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV79Core_auditwwds_14_auditdate3, AV80Core_auditwwds_15_auditdate_to3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV81Core_auditwwds_16_tfauditdatetime, AV82Core_auditwwds_17_tfauditdatetime_to, AV83Core_auditwwds_18_tfauditdate, AV84Core_auditwwds_19_tfauditdate_to, AV85Core_auditwwds_20_tfaudittime, AV86Core_auditwwds_21_tfaudittime_to, lV87Core_auditwwds_22_tfaudittablename, AV88Core_auditwwds_23_tfaudittablename_sel, lV89Core_auditwwds_24_tfauditaction, AV90Core_auditwwds_25_tfauditaction_sel, lV91Core_auditwwds_26_tfauditshortdescription, AV92Core_auditwwds_27_tfauditshortdescription_sel, lV93Core_auditwwds_28_tfauditdescription, AV94Core_auditwwds_29_tfauditdescription_sel, lV95Core_auditwwds_30_tfauditgamusername, AV96Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7K2 = false;
            A497AuditTableName = P007K2_A497AuditTableName[0];
            A495AuditTime = P007K2_A495AuditTime[0];
            A496AuditDateTime = P007K2_A496AuditDateTime[0];
            A494AuditDate = P007K2_A494AuditDate[0];
            A501AuditGAMUserName = P007K2_A501AuditGAMUserName[0];
            A498AuditDescription = P007K2_A498AuditDescription[0];
            A499AuditShortDescription = P007K2_A499AuditShortDescription[0];
            A502AuditAction = P007K2_A502AuditAction[0];
            A493AuditID = P007K2_A493AuditID[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007K2_A497AuditTableName[0], A497AuditTableName) == 0 ) )
            {
               BRK7K2 = false;
               A493AuditID = P007K2_A493AuditID[0];
               AV35count = (long)(AV35count+1);
               BRK7K2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A497AuditTableName)) ? "<#Empty#>" : A497AuditTableName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7K2 )
            {
               BRK7K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADAUDITACTIONOPTIONS' Routine */
         returnInSub = false;
         AV23TFAuditAction = AV25SearchTxt;
         AV24TFAuditAction_Sel = "";
         AV66Core_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV67Core_auditwwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV68Core_auditwwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV69Core_auditwwds_4_auditdate1 = AV50AuditDate1;
         AV70Core_auditwwds_5_auditdate_to1 = AV51AuditDate_To1;
         AV71Core_auditwwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV72Core_auditwwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV73Core_auditwwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV74Core_auditwwds_9_auditdate2 = AV55AuditDate2;
         AV75Core_auditwwds_10_auditdate_to2 = AV56AuditDate_To2;
         AV76Core_auditwwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV77Core_auditwwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV78Core_auditwwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV79Core_auditwwds_14_auditdate3 = AV60AuditDate3;
         AV80Core_auditwwds_15_auditdate_to3 = AV61AuditDate_To3;
         AV81Core_auditwwds_16_tfauditdatetime = AV62TFAuditDateTime;
         AV82Core_auditwwds_17_tfauditdatetime_to = AV63TFAuditDateTime_To;
         AV83Core_auditwwds_18_tfauditdate = AV11TFAuditDate;
         AV84Core_auditwwds_19_tfauditdate_to = AV12TFAuditDate_To;
         AV85Core_auditwwds_20_tfaudittime = AV13TFAuditTime;
         AV86Core_auditwwds_21_tfaudittime_to = AV14TFAuditTime_To;
         AV87Core_auditwwds_22_tfaudittablename = AV15TFAuditTableName;
         AV88Core_auditwwds_23_tfaudittablename_sel = AV16TFAuditTableName_Sel;
         AV89Core_auditwwds_24_tfauditaction = AV23TFAuditAction;
         AV90Core_auditwwds_25_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV91Core_auditwwds_26_tfauditshortdescription = AV17TFAuditShortDescription;
         AV92Core_auditwwds_27_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV93Core_auditwwds_28_tfauditdescription = AV19TFAuditDescription;
         AV94Core_auditwwds_29_tfauditdescription_sel = AV20TFAuditDescription_Sel;
         AV95Core_auditwwds_30_tfauditgamusername = AV21TFAuditGAMUserName;
         AV96Core_auditwwds_31_tfauditgamusername_sel = AV22TFAuditGAMUserName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV66Core_auditwwds_1_filterfulltext ,
                                              AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV69Core_auditwwds_4_auditdate1 ,
                                              AV70Core_auditwwds_5_auditdate_to1 ,
                                              AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV74Core_auditwwds_9_auditdate2 ,
                                              AV75Core_auditwwds_10_auditdate_to2 ,
                                              AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV79Core_auditwwds_14_auditdate3 ,
                                              AV80Core_auditwwds_15_auditdate_to3 ,
                                              AV81Core_auditwwds_16_tfauditdatetime ,
                                              AV82Core_auditwwds_17_tfauditdatetime_to ,
                                              AV83Core_auditwwds_18_tfauditdate ,
                                              AV84Core_auditwwds_19_tfauditdate_to ,
                                              AV85Core_auditwwds_20_tfaudittime ,
                                              AV86Core_auditwwds_21_tfaudittime_to ,
                                              AV88Core_auditwwds_23_tfaudittablename_sel ,
                                              AV87Core_auditwwds_22_tfaudittablename ,
                                              AV90Core_auditwwds_25_tfauditaction_sel ,
                                              AV89Core_auditwwds_24_tfauditaction ,
                                              AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV91Core_auditwwds_26_tfauditshortdescription ,
                                              AV94Core_auditwwds_29_tfauditdescription_sel ,
                                              AV93Core_auditwwds_28_tfauditdescription ,
                                              AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV95Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV87Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename), "%", "");
         lV89Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction), "%", "");
         lV91Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV93Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription), "%", "");
         lV95Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007K3 */
         pr_default.execute(1, new Object[] {lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, AV69Core_auditwwds_4_auditdate1, AV70Core_auditwwds_5_auditdate_to1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV74Core_auditwwds_9_auditdate2, AV75Core_auditwwds_10_auditdate_to2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV79Core_auditwwds_14_auditdate3, AV80Core_auditwwds_15_auditdate_to3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV81Core_auditwwds_16_tfauditdatetime, AV82Core_auditwwds_17_tfauditdatetime_to, AV83Core_auditwwds_18_tfauditdate, AV84Core_auditwwds_19_tfauditdate_to, AV85Core_auditwwds_20_tfaudittime, AV86Core_auditwwds_21_tfaudittime_to, lV87Core_auditwwds_22_tfaudittablename, AV88Core_auditwwds_23_tfaudittablename_sel, lV89Core_auditwwds_24_tfauditaction, AV90Core_auditwwds_25_tfauditaction_sel, lV91Core_auditwwds_26_tfauditshortdescription, AV92Core_auditwwds_27_tfauditshortdescription_sel, lV93Core_auditwwds_28_tfauditdescription, AV94Core_auditwwds_29_tfauditdescription_sel, lV95Core_auditwwds_30_tfauditgamusername, AV96Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7K4 = false;
            A502AuditAction = P007K3_A502AuditAction[0];
            A495AuditTime = P007K3_A495AuditTime[0];
            A496AuditDateTime = P007K3_A496AuditDateTime[0];
            A494AuditDate = P007K3_A494AuditDate[0];
            A501AuditGAMUserName = P007K3_A501AuditGAMUserName[0];
            A498AuditDescription = P007K3_A498AuditDescription[0];
            A499AuditShortDescription = P007K3_A499AuditShortDescription[0];
            A497AuditTableName = P007K3_A497AuditTableName[0];
            A493AuditID = P007K3_A493AuditID[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007K3_A502AuditAction[0], A502AuditAction) == 0 ) )
            {
               BRK7K4 = false;
               A493AuditID = P007K3_A493AuditID[0];
               AV35count = (long)(AV35count+1);
               BRK7K4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A502AuditAction)) ? "<#Empty#>" : A502AuditAction);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7K4 )
            {
               BRK7K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADAUDITSHORTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV17TFAuditShortDescription = AV25SearchTxt;
         AV18TFAuditShortDescription_Sel = "";
         AV66Core_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV67Core_auditwwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV68Core_auditwwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV69Core_auditwwds_4_auditdate1 = AV50AuditDate1;
         AV70Core_auditwwds_5_auditdate_to1 = AV51AuditDate_To1;
         AV71Core_auditwwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV72Core_auditwwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV73Core_auditwwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV74Core_auditwwds_9_auditdate2 = AV55AuditDate2;
         AV75Core_auditwwds_10_auditdate_to2 = AV56AuditDate_To2;
         AV76Core_auditwwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV77Core_auditwwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV78Core_auditwwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV79Core_auditwwds_14_auditdate3 = AV60AuditDate3;
         AV80Core_auditwwds_15_auditdate_to3 = AV61AuditDate_To3;
         AV81Core_auditwwds_16_tfauditdatetime = AV62TFAuditDateTime;
         AV82Core_auditwwds_17_tfauditdatetime_to = AV63TFAuditDateTime_To;
         AV83Core_auditwwds_18_tfauditdate = AV11TFAuditDate;
         AV84Core_auditwwds_19_tfauditdate_to = AV12TFAuditDate_To;
         AV85Core_auditwwds_20_tfaudittime = AV13TFAuditTime;
         AV86Core_auditwwds_21_tfaudittime_to = AV14TFAuditTime_To;
         AV87Core_auditwwds_22_tfaudittablename = AV15TFAuditTableName;
         AV88Core_auditwwds_23_tfaudittablename_sel = AV16TFAuditTableName_Sel;
         AV89Core_auditwwds_24_tfauditaction = AV23TFAuditAction;
         AV90Core_auditwwds_25_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV91Core_auditwwds_26_tfauditshortdescription = AV17TFAuditShortDescription;
         AV92Core_auditwwds_27_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV93Core_auditwwds_28_tfauditdescription = AV19TFAuditDescription;
         AV94Core_auditwwds_29_tfauditdescription_sel = AV20TFAuditDescription_Sel;
         AV95Core_auditwwds_30_tfauditgamusername = AV21TFAuditGAMUserName;
         AV96Core_auditwwds_31_tfauditgamusername_sel = AV22TFAuditGAMUserName_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV66Core_auditwwds_1_filterfulltext ,
                                              AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV69Core_auditwwds_4_auditdate1 ,
                                              AV70Core_auditwwds_5_auditdate_to1 ,
                                              AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV74Core_auditwwds_9_auditdate2 ,
                                              AV75Core_auditwwds_10_auditdate_to2 ,
                                              AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV79Core_auditwwds_14_auditdate3 ,
                                              AV80Core_auditwwds_15_auditdate_to3 ,
                                              AV81Core_auditwwds_16_tfauditdatetime ,
                                              AV82Core_auditwwds_17_tfauditdatetime_to ,
                                              AV83Core_auditwwds_18_tfauditdate ,
                                              AV84Core_auditwwds_19_tfauditdate_to ,
                                              AV85Core_auditwwds_20_tfaudittime ,
                                              AV86Core_auditwwds_21_tfaudittime_to ,
                                              AV88Core_auditwwds_23_tfaudittablename_sel ,
                                              AV87Core_auditwwds_22_tfaudittablename ,
                                              AV90Core_auditwwds_25_tfauditaction_sel ,
                                              AV89Core_auditwwds_24_tfauditaction ,
                                              AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV91Core_auditwwds_26_tfauditshortdescription ,
                                              AV94Core_auditwwds_29_tfauditdescription_sel ,
                                              AV93Core_auditwwds_28_tfauditdescription ,
                                              AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV95Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV87Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename), "%", "");
         lV89Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction), "%", "");
         lV91Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV93Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription), "%", "");
         lV95Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007K4 */
         pr_default.execute(2, new Object[] {lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, AV69Core_auditwwds_4_auditdate1, AV70Core_auditwwds_5_auditdate_to1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV74Core_auditwwds_9_auditdate2, AV75Core_auditwwds_10_auditdate_to2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV79Core_auditwwds_14_auditdate3, AV80Core_auditwwds_15_auditdate_to3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV81Core_auditwwds_16_tfauditdatetime, AV82Core_auditwwds_17_tfauditdatetime_to, AV83Core_auditwwds_18_tfauditdate, AV84Core_auditwwds_19_tfauditdate_to, AV85Core_auditwwds_20_tfaudittime, AV86Core_auditwwds_21_tfaudittime_to, lV87Core_auditwwds_22_tfaudittablename, AV88Core_auditwwds_23_tfaudittablename_sel, lV89Core_auditwwds_24_tfauditaction, AV90Core_auditwwds_25_tfauditaction_sel, lV91Core_auditwwds_26_tfauditshortdescription, AV92Core_auditwwds_27_tfauditshortdescription_sel, lV93Core_auditwwds_28_tfauditdescription, AV94Core_auditwwds_29_tfauditdescription_sel, lV95Core_auditwwds_30_tfauditgamusername, AV96Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7K6 = false;
            A499AuditShortDescription = P007K4_A499AuditShortDescription[0];
            A495AuditTime = P007K4_A495AuditTime[0];
            A496AuditDateTime = P007K4_A496AuditDateTime[0];
            A494AuditDate = P007K4_A494AuditDate[0];
            A501AuditGAMUserName = P007K4_A501AuditGAMUserName[0];
            A498AuditDescription = P007K4_A498AuditDescription[0];
            A502AuditAction = P007K4_A502AuditAction[0];
            A497AuditTableName = P007K4_A497AuditTableName[0];
            A493AuditID = P007K4_A493AuditID[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007K4_A499AuditShortDescription[0], A499AuditShortDescription) == 0 ) )
            {
               BRK7K6 = false;
               A493AuditID = P007K4_A493AuditID[0];
               AV35count = (long)(AV35count+1);
               BRK7K6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A499AuditShortDescription)) ? "<#Empty#>" : A499AuditShortDescription);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7K6 )
            {
               BRK7K6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADAUDITDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV19TFAuditDescription = AV25SearchTxt;
         AV20TFAuditDescription_Sel = "";
         AV66Core_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV67Core_auditwwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV68Core_auditwwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV69Core_auditwwds_4_auditdate1 = AV50AuditDate1;
         AV70Core_auditwwds_5_auditdate_to1 = AV51AuditDate_To1;
         AV71Core_auditwwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV72Core_auditwwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV73Core_auditwwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV74Core_auditwwds_9_auditdate2 = AV55AuditDate2;
         AV75Core_auditwwds_10_auditdate_to2 = AV56AuditDate_To2;
         AV76Core_auditwwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV77Core_auditwwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV78Core_auditwwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV79Core_auditwwds_14_auditdate3 = AV60AuditDate3;
         AV80Core_auditwwds_15_auditdate_to3 = AV61AuditDate_To3;
         AV81Core_auditwwds_16_tfauditdatetime = AV62TFAuditDateTime;
         AV82Core_auditwwds_17_tfauditdatetime_to = AV63TFAuditDateTime_To;
         AV83Core_auditwwds_18_tfauditdate = AV11TFAuditDate;
         AV84Core_auditwwds_19_tfauditdate_to = AV12TFAuditDate_To;
         AV85Core_auditwwds_20_tfaudittime = AV13TFAuditTime;
         AV86Core_auditwwds_21_tfaudittime_to = AV14TFAuditTime_To;
         AV87Core_auditwwds_22_tfaudittablename = AV15TFAuditTableName;
         AV88Core_auditwwds_23_tfaudittablename_sel = AV16TFAuditTableName_Sel;
         AV89Core_auditwwds_24_tfauditaction = AV23TFAuditAction;
         AV90Core_auditwwds_25_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV91Core_auditwwds_26_tfauditshortdescription = AV17TFAuditShortDescription;
         AV92Core_auditwwds_27_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV93Core_auditwwds_28_tfauditdescription = AV19TFAuditDescription;
         AV94Core_auditwwds_29_tfauditdescription_sel = AV20TFAuditDescription_Sel;
         AV95Core_auditwwds_30_tfauditgamusername = AV21TFAuditGAMUserName;
         AV96Core_auditwwds_31_tfauditgamusername_sel = AV22TFAuditGAMUserName_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV66Core_auditwwds_1_filterfulltext ,
                                              AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV69Core_auditwwds_4_auditdate1 ,
                                              AV70Core_auditwwds_5_auditdate_to1 ,
                                              AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV74Core_auditwwds_9_auditdate2 ,
                                              AV75Core_auditwwds_10_auditdate_to2 ,
                                              AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV79Core_auditwwds_14_auditdate3 ,
                                              AV80Core_auditwwds_15_auditdate_to3 ,
                                              AV81Core_auditwwds_16_tfauditdatetime ,
                                              AV82Core_auditwwds_17_tfauditdatetime_to ,
                                              AV83Core_auditwwds_18_tfauditdate ,
                                              AV84Core_auditwwds_19_tfauditdate_to ,
                                              AV85Core_auditwwds_20_tfaudittime ,
                                              AV86Core_auditwwds_21_tfaudittime_to ,
                                              AV88Core_auditwwds_23_tfaudittablename_sel ,
                                              AV87Core_auditwwds_22_tfaudittablename ,
                                              AV90Core_auditwwds_25_tfauditaction_sel ,
                                              AV89Core_auditwwds_24_tfauditaction ,
                                              AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV91Core_auditwwds_26_tfauditshortdescription ,
                                              AV94Core_auditwwds_29_tfauditdescription_sel ,
                                              AV93Core_auditwwds_28_tfauditdescription ,
                                              AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV95Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV87Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename), "%", "");
         lV89Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction), "%", "");
         lV91Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV93Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription), "%", "");
         lV95Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007K5 */
         pr_default.execute(3, new Object[] {lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, AV69Core_auditwwds_4_auditdate1, AV70Core_auditwwds_5_auditdate_to1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV74Core_auditwwds_9_auditdate2, AV75Core_auditwwds_10_auditdate_to2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV79Core_auditwwds_14_auditdate3, AV80Core_auditwwds_15_auditdate_to3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV81Core_auditwwds_16_tfauditdatetime, AV82Core_auditwwds_17_tfauditdatetime_to, AV83Core_auditwwds_18_tfauditdate, AV84Core_auditwwds_19_tfauditdate_to, AV85Core_auditwwds_20_tfaudittime, AV86Core_auditwwds_21_tfaudittime_to, lV87Core_auditwwds_22_tfaudittablename, AV88Core_auditwwds_23_tfaudittablename_sel, lV89Core_auditwwds_24_tfauditaction, AV90Core_auditwwds_25_tfauditaction_sel, lV91Core_auditwwds_26_tfauditshortdescription, AV92Core_auditwwds_27_tfauditshortdescription_sel, lV93Core_auditwwds_28_tfauditdescription, AV94Core_auditwwds_29_tfauditdescription_sel, lV95Core_auditwwds_30_tfauditgamusername, AV96Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7K8 = false;
            A498AuditDescription = P007K5_A498AuditDescription[0];
            A495AuditTime = P007K5_A495AuditTime[0];
            A496AuditDateTime = P007K5_A496AuditDateTime[0];
            A494AuditDate = P007K5_A494AuditDate[0];
            A501AuditGAMUserName = P007K5_A501AuditGAMUserName[0];
            A499AuditShortDescription = P007K5_A499AuditShortDescription[0];
            A502AuditAction = P007K5_A502AuditAction[0];
            A497AuditTableName = P007K5_A497AuditTableName[0];
            A493AuditID = P007K5_A493AuditID[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007K5_A498AuditDescription[0], A498AuditDescription) == 0 ) )
            {
               BRK7K8 = false;
               A493AuditID = P007K5_A493AuditID[0];
               AV35count = (long)(AV35count+1);
               BRK7K8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A498AuditDescription)) ? "<#Empty#>" : A498AuditDescription);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7K8 )
            {
               BRK7K8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADAUDITGAMUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFAuditGAMUserName = AV25SearchTxt;
         AV22TFAuditGAMUserName_Sel = "";
         AV66Core_auditwwds_1_filterfulltext = AV47FilterFullText;
         AV67Core_auditwwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV68Core_auditwwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV69Core_auditwwds_4_auditdate1 = AV50AuditDate1;
         AV70Core_auditwwds_5_auditdate_to1 = AV51AuditDate_To1;
         AV71Core_auditwwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV72Core_auditwwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV73Core_auditwwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV74Core_auditwwds_9_auditdate2 = AV55AuditDate2;
         AV75Core_auditwwds_10_auditdate_to2 = AV56AuditDate_To2;
         AV76Core_auditwwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV77Core_auditwwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV78Core_auditwwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV79Core_auditwwds_14_auditdate3 = AV60AuditDate3;
         AV80Core_auditwwds_15_auditdate_to3 = AV61AuditDate_To3;
         AV81Core_auditwwds_16_tfauditdatetime = AV62TFAuditDateTime;
         AV82Core_auditwwds_17_tfauditdatetime_to = AV63TFAuditDateTime_To;
         AV83Core_auditwwds_18_tfauditdate = AV11TFAuditDate;
         AV84Core_auditwwds_19_tfauditdate_to = AV12TFAuditDate_To;
         AV85Core_auditwwds_20_tfaudittime = AV13TFAuditTime;
         AV86Core_auditwwds_21_tfaudittime_to = AV14TFAuditTime_To;
         AV87Core_auditwwds_22_tfaudittablename = AV15TFAuditTableName;
         AV88Core_auditwwds_23_tfaudittablename_sel = AV16TFAuditTableName_Sel;
         AV89Core_auditwwds_24_tfauditaction = AV23TFAuditAction;
         AV90Core_auditwwds_25_tfauditaction_sel = AV24TFAuditAction_Sel;
         AV91Core_auditwwds_26_tfauditshortdescription = AV17TFAuditShortDescription;
         AV92Core_auditwwds_27_tfauditshortdescription_sel = AV18TFAuditShortDescription_Sel;
         AV93Core_auditwwds_28_tfauditdescription = AV19TFAuditDescription;
         AV94Core_auditwwds_29_tfauditdescription_sel = AV20TFAuditDescription_Sel;
         AV95Core_auditwwds_30_tfauditgamusername = AV21TFAuditGAMUserName;
         AV96Core_auditwwds_31_tfauditgamusername_sel = AV22TFAuditGAMUserName_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV66Core_auditwwds_1_filterfulltext ,
                                              AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV69Core_auditwwds_4_auditdate1 ,
                                              AV70Core_auditwwds_5_auditdate_to1 ,
                                              AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV74Core_auditwwds_9_auditdate2 ,
                                              AV75Core_auditwwds_10_auditdate_to2 ,
                                              AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV79Core_auditwwds_14_auditdate3 ,
                                              AV80Core_auditwwds_15_auditdate_to3 ,
                                              AV81Core_auditwwds_16_tfauditdatetime ,
                                              AV82Core_auditwwds_17_tfauditdatetime_to ,
                                              AV83Core_auditwwds_18_tfauditdate ,
                                              AV84Core_auditwwds_19_tfauditdate_to ,
                                              AV85Core_auditwwds_20_tfaudittime ,
                                              AV86Core_auditwwds_21_tfaudittime_to ,
                                              AV88Core_auditwwds_23_tfaudittablename_sel ,
                                              AV87Core_auditwwds_22_tfaudittablename ,
                                              AV90Core_auditwwds_25_tfauditaction_sel ,
                                              AV89Core_auditwwds_24_tfauditaction ,
                                              AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV91Core_auditwwds_26_tfauditshortdescription ,
                                              AV94Core_auditwwds_29_tfauditdescription_sel ,
                                              AV93Core_auditwwds_28_tfauditdescription ,
                                              AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV95Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV66Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext), "%", "");
         lV87Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename), "%", "");
         lV89Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction), "%", "");
         lV91Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV93Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription), "%", "");
         lV95Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007K6 */
         pr_default.execute(4, new Object[] {lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, lV66Core_auditwwds_1_filterfulltext, AV69Core_auditwwds_4_auditdate1, AV70Core_auditwwds_5_auditdate_to1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV69Core_auditwwds_4_auditdate1, AV74Core_auditwwds_9_auditdate2, AV75Core_auditwwds_10_auditdate_to2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV74Core_auditwwds_9_auditdate2, AV79Core_auditwwds_14_auditdate3, AV80Core_auditwwds_15_auditdate_to3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV79Core_auditwwds_14_auditdate3, AV81Core_auditwwds_16_tfauditdatetime, AV82Core_auditwwds_17_tfauditdatetime_to, AV83Core_auditwwds_18_tfauditdate, AV84Core_auditwwds_19_tfauditdate_to, AV85Core_auditwwds_20_tfaudittime, AV86Core_auditwwds_21_tfaudittime_to, lV87Core_auditwwds_22_tfaudittablename, AV88Core_auditwwds_23_tfaudittablename_sel, lV89Core_auditwwds_24_tfauditaction, AV90Core_auditwwds_25_tfauditaction_sel, lV91Core_auditwwds_26_tfauditshortdescription, AV92Core_auditwwds_27_tfauditshortdescription_sel, lV93Core_auditwwds_28_tfauditdescription, AV94Core_auditwwds_29_tfauditdescription_sel, lV95Core_auditwwds_30_tfauditgamusername, AV96Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK7K10 = false;
            A501AuditGAMUserName = P007K6_A501AuditGAMUserName[0];
            A495AuditTime = P007K6_A495AuditTime[0];
            A496AuditDateTime = P007K6_A496AuditDateTime[0];
            A494AuditDate = P007K6_A494AuditDate[0];
            A498AuditDescription = P007K6_A498AuditDescription[0];
            A499AuditShortDescription = P007K6_A499AuditShortDescription[0];
            A502AuditAction = P007K6_A502AuditAction[0];
            A497AuditTableName = P007K6_A497AuditTableName[0];
            A493AuditID = P007K6_A493AuditID[0];
            AV35count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P007K6_A501AuditGAMUserName[0], A501AuditGAMUserName) == 0 ) )
            {
               BRK7K10 = false;
               A493AuditID = P007K6_A493AuditID[0];
               AV35count = (long)(AV35count+1);
               BRK7K10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A501AuditGAMUserName)) ? "<#Empty#>" : A501AuditGAMUserName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK7K10 )
            {
               BRK7K10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV62TFAuditDateTime = (DateTime)(DateTime.MinValue);
         AV63TFAuditDateTime_To = (DateTime)(DateTime.MinValue);
         AV11TFAuditDate = DateTime.MinValue;
         AV12TFAuditDate_To = DateTime.MinValue;
         AV13TFAuditTime = (DateTime)(DateTime.MinValue);
         AV14TFAuditTime_To = (DateTime)(DateTime.MinValue);
         AV15TFAuditTableName = "";
         AV16TFAuditTableName_Sel = "";
         AV23TFAuditAction = "";
         AV24TFAuditAction_Sel = "";
         AV17TFAuditShortDescription = "";
         AV18TFAuditShortDescription_Sel = "";
         AV19TFAuditDescription = "";
         AV20TFAuditDescription_Sel = "";
         AV21TFAuditGAMUserName = "";
         AV22TFAuditGAMUserName_Sel = "";
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV50AuditDate1 = DateTime.MinValue;
         AV51AuditDate_To1 = DateTime.MinValue;
         AV53DynamicFiltersSelector2 = "";
         AV55AuditDate2 = DateTime.MinValue;
         AV56AuditDate_To2 = DateTime.MinValue;
         AV58DynamicFiltersSelector3 = "";
         AV60AuditDate3 = DateTime.MinValue;
         AV61AuditDate_To3 = DateTime.MinValue;
         AV66Core_auditwwds_1_filterfulltext = "";
         AV67Core_auditwwds_2_dynamicfiltersselector1 = "";
         AV69Core_auditwwds_4_auditdate1 = DateTime.MinValue;
         AV70Core_auditwwds_5_auditdate_to1 = DateTime.MinValue;
         AV72Core_auditwwds_7_dynamicfiltersselector2 = "";
         AV74Core_auditwwds_9_auditdate2 = DateTime.MinValue;
         AV75Core_auditwwds_10_auditdate_to2 = DateTime.MinValue;
         AV77Core_auditwwds_12_dynamicfiltersselector3 = "";
         AV79Core_auditwwds_14_auditdate3 = DateTime.MinValue;
         AV80Core_auditwwds_15_auditdate_to3 = DateTime.MinValue;
         AV81Core_auditwwds_16_tfauditdatetime = (DateTime)(DateTime.MinValue);
         AV82Core_auditwwds_17_tfauditdatetime_to = (DateTime)(DateTime.MinValue);
         AV83Core_auditwwds_18_tfauditdate = DateTime.MinValue;
         AV84Core_auditwwds_19_tfauditdate_to = DateTime.MinValue;
         AV85Core_auditwwds_20_tfaudittime = (DateTime)(DateTime.MinValue);
         AV86Core_auditwwds_21_tfaudittime_to = (DateTime)(DateTime.MinValue);
         AV87Core_auditwwds_22_tfaudittablename = "";
         AV88Core_auditwwds_23_tfaudittablename_sel = "";
         AV89Core_auditwwds_24_tfauditaction = "";
         AV90Core_auditwwds_25_tfauditaction_sel = "";
         AV91Core_auditwwds_26_tfauditshortdescription = "";
         AV92Core_auditwwds_27_tfauditshortdescription_sel = "";
         AV93Core_auditwwds_28_tfauditdescription = "";
         AV94Core_auditwwds_29_tfauditdescription_sel = "";
         AV95Core_auditwwds_30_tfauditgamusername = "";
         AV96Core_auditwwds_31_tfauditgamusername_sel = "";
         scmdbuf = "";
         lV66Core_auditwwds_1_filterfulltext = "";
         lV87Core_auditwwds_22_tfaudittablename = "";
         lV89Core_auditwwds_24_tfauditaction = "";
         lV91Core_auditwwds_26_tfauditshortdescription = "";
         lV93Core_auditwwds_28_tfauditdescription = "";
         lV95Core_auditwwds_30_tfauditgamusername = "";
         A497AuditTableName = "";
         A502AuditAction = "";
         A499AuditShortDescription = "";
         A498AuditDescription = "";
         A501AuditGAMUserName = "";
         A494AuditDate = DateTime.MinValue;
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         A495AuditTime = (DateTime)(DateTime.MinValue);
         P007K2_A497AuditTableName = new string[] {""} ;
         P007K2_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007K2_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007K2_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007K2_A501AuditGAMUserName = new string[] {""} ;
         P007K2_A498AuditDescription = new string[] {""} ;
         P007K2_A499AuditShortDescription = new string[] {""} ;
         P007K2_A502AuditAction = new string[] {""} ;
         P007K2_A493AuditID = new Guid[] {Guid.Empty} ;
         A493AuditID = Guid.Empty;
         AV30Option = "";
         P007K3_A502AuditAction = new string[] {""} ;
         P007K3_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007K3_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007K3_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007K3_A501AuditGAMUserName = new string[] {""} ;
         P007K3_A498AuditDescription = new string[] {""} ;
         P007K3_A499AuditShortDescription = new string[] {""} ;
         P007K3_A497AuditTableName = new string[] {""} ;
         P007K3_A493AuditID = new Guid[] {Guid.Empty} ;
         P007K4_A499AuditShortDescription = new string[] {""} ;
         P007K4_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007K4_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007K4_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007K4_A501AuditGAMUserName = new string[] {""} ;
         P007K4_A498AuditDescription = new string[] {""} ;
         P007K4_A502AuditAction = new string[] {""} ;
         P007K4_A497AuditTableName = new string[] {""} ;
         P007K4_A493AuditID = new Guid[] {Guid.Empty} ;
         P007K5_A498AuditDescription = new string[] {""} ;
         P007K5_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007K5_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007K5_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007K5_A501AuditGAMUserName = new string[] {""} ;
         P007K5_A499AuditShortDescription = new string[] {""} ;
         P007K5_A502AuditAction = new string[] {""} ;
         P007K5_A497AuditTableName = new string[] {""} ;
         P007K5_A493AuditID = new Guid[] {Guid.Empty} ;
         P007K6_A501AuditGAMUserName = new string[] {""} ;
         P007K6_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007K6_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007K6_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007K6_A498AuditDescription = new string[] {""} ;
         P007K6_A499AuditShortDescription = new string[] {""} ;
         P007K6_A502AuditAction = new string[] {""} ;
         P007K6_A497AuditTableName = new string[] {""} ;
         P007K6_A493AuditID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.auditwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007K2_A497AuditTableName, P007K2_A495AuditTime, P007K2_A496AuditDateTime, P007K2_A494AuditDate, P007K2_A501AuditGAMUserName, P007K2_A498AuditDescription, P007K2_A499AuditShortDescription, P007K2_A502AuditAction, P007K2_A493AuditID
               }
               , new Object[] {
               P007K3_A502AuditAction, P007K3_A495AuditTime, P007K3_A496AuditDateTime, P007K3_A494AuditDate, P007K3_A501AuditGAMUserName, P007K3_A498AuditDescription, P007K3_A499AuditShortDescription, P007K3_A497AuditTableName, P007K3_A493AuditID
               }
               , new Object[] {
               P007K4_A499AuditShortDescription, P007K4_A495AuditTime, P007K4_A496AuditDateTime, P007K4_A494AuditDate, P007K4_A501AuditGAMUserName, P007K4_A498AuditDescription, P007K4_A502AuditAction, P007K4_A497AuditTableName, P007K4_A493AuditID
               }
               , new Object[] {
               P007K5_A498AuditDescription, P007K5_A495AuditTime, P007K5_A496AuditDateTime, P007K5_A494AuditDate, P007K5_A501AuditGAMUserName, P007K5_A499AuditShortDescription, P007K5_A502AuditAction, P007K5_A497AuditTableName, P007K5_A493AuditID
               }
               , new Object[] {
               P007K6_A501AuditGAMUserName, P007K6_A495AuditTime, P007K6_A496AuditDateTime, P007K6_A494AuditDate, P007K6_A498AuditDescription, P007K6_A499AuditShortDescription, P007K6_A502AuditAction, P007K6_A497AuditTableName, P007K6_A493AuditID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV49DynamicFiltersOperator1 ;
      private short AV54DynamicFiltersOperator2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV68Core_auditwwds_3_dynamicfiltersoperator1 ;
      private short AV73Core_auditwwds_8_dynamicfiltersoperator2 ;
      private short AV78Core_auditwwds_13_dynamicfiltersoperator3 ;
      private int AV64GXV1 ;
      private long AV35count ;
      private string scmdbuf ;
      private DateTime AV62TFAuditDateTime ;
      private DateTime AV63TFAuditDateTime_To ;
      private DateTime AV13TFAuditTime ;
      private DateTime AV14TFAuditTime_To ;
      private DateTime AV81Core_auditwwds_16_tfauditdatetime ;
      private DateTime AV82Core_auditwwds_17_tfauditdatetime_to ;
      private DateTime AV85Core_auditwwds_20_tfaudittime ;
      private DateTime AV86Core_auditwwds_21_tfaudittime_to ;
      private DateTime A496AuditDateTime ;
      private DateTime A495AuditTime ;
      private DateTime AV11TFAuditDate ;
      private DateTime AV12TFAuditDate_To ;
      private DateTime AV50AuditDate1 ;
      private DateTime AV51AuditDate_To1 ;
      private DateTime AV55AuditDate2 ;
      private DateTime AV56AuditDate_To2 ;
      private DateTime AV60AuditDate3 ;
      private DateTime AV61AuditDate_To3 ;
      private DateTime AV69Core_auditwwds_4_auditdate1 ;
      private DateTime AV70Core_auditwwds_5_auditdate_to1 ;
      private DateTime AV74Core_auditwwds_9_auditdate2 ;
      private DateTime AV75Core_auditwwds_10_auditdate_to2 ;
      private DateTime AV79Core_auditwwds_14_auditdate3 ;
      private DateTime AV80Core_auditwwds_15_auditdate_to3 ;
      private DateTime AV83Core_auditwwds_18_tfauditdate ;
      private DateTime AV84Core_auditwwds_19_tfauditdate_to ;
      private DateTime A494AuditDate ;
      private bool returnInSub ;
      private bool AV52DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV71Core_auditwwds_6_dynamicfiltersenabled2 ;
      private bool AV76Core_auditwwds_11_dynamicfiltersenabled3 ;
      private bool BRK7K2 ;
      private bool BRK7K4 ;
      private bool BRK7K6 ;
      private bool BRK7K8 ;
      private bool BRK7K10 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string A498AuditDescription ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV15TFAuditTableName ;
      private string AV16TFAuditTableName_Sel ;
      private string AV23TFAuditAction ;
      private string AV24TFAuditAction_Sel ;
      private string AV17TFAuditShortDescription ;
      private string AV18TFAuditShortDescription_Sel ;
      private string AV19TFAuditDescription ;
      private string AV20TFAuditDescription_Sel ;
      private string AV21TFAuditGAMUserName ;
      private string AV22TFAuditGAMUserName_Sel ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV53DynamicFiltersSelector2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV66Core_auditwwds_1_filterfulltext ;
      private string AV67Core_auditwwds_2_dynamicfiltersselector1 ;
      private string AV72Core_auditwwds_7_dynamicfiltersselector2 ;
      private string AV77Core_auditwwds_12_dynamicfiltersselector3 ;
      private string AV87Core_auditwwds_22_tfaudittablename ;
      private string AV88Core_auditwwds_23_tfaudittablename_sel ;
      private string AV89Core_auditwwds_24_tfauditaction ;
      private string AV90Core_auditwwds_25_tfauditaction_sel ;
      private string AV91Core_auditwwds_26_tfauditshortdescription ;
      private string AV92Core_auditwwds_27_tfauditshortdescription_sel ;
      private string AV93Core_auditwwds_28_tfauditdescription ;
      private string AV94Core_auditwwds_29_tfauditdescription_sel ;
      private string AV95Core_auditwwds_30_tfauditgamusername ;
      private string AV96Core_auditwwds_31_tfauditgamusername_sel ;
      private string lV66Core_auditwwds_1_filterfulltext ;
      private string lV87Core_auditwwds_22_tfaudittablename ;
      private string lV89Core_auditwwds_24_tfauditaction ;
      private string lV91Core_auditwwds_26_tfauditshortdescription ;
      private string lV93Core_auditwwds_28_tfauditdescription ;
      private string lV95Core_auditwwds_30_tfauditgamusername ;
      private string A497AuditTableName ;
      private string A502AuditAction ;
      private string A499AuditShortDescription ;
      private string A501AuditGAMUserName ;
      private string AV30Option ;
      private Guid A493AuditID ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007K2_A497AuditTableName ;
      private DateTime[] P007K2_A495AuditTime ;
      private DateTime[] P007K2_A496AuditDateTime ;
      private DateTime[] P007K2_A494AuditDate ;
      private string[] P007K2_A501AuditGAMUserName ;
      private string[] P007K2_A498AuditDescription ;
      private string[] P007K2_A499AuditShortDescription ;
      private string[] P007K2_A502AuditAction ;
      private Guid[] P007K2_A493AuditID ;
      private string[] P007K3_A502AuditAction ;
      private DateTime[] P007K3_A495AuditTime ;
      private DateTime[] P007K3_A496AuditDateTime ;
      private DateTime[] P007K3_A494AuditDate ;
      private string[] P007K3_A501AuditGAMUserName ;
      private string[] P007K3_A498AuditDescription ;
      private string[] P007K3_A499AuditShortDescription ;
      private string[] P007K3_A497AuditTableName ;
      private Guid[] P007K3_A493AuditID ;
      private string[] P007K4_A499AuditShortDescription ;
      private DateTime[] P007K4_A495AuditTime ;
      private DateTime[] P007K4_A496AuditDateTime ;
      private DateTime[] P007K4_A494AuditDate ;
      private string[] P007K4_A501AuditGAMUserName ;
      private string[] P007K4_A498AuditDescription ;
      private string[] P007K4_A502AuditAction ;
      private string[] P007K4_A497AuditTableName ;
      private Guid[] P007K4_A493AuditID ;
      private string[] P007K5_A498AuditDescription ;
      private DateTime[] P007K5_A495AuditTime ;
      private DateTime[] P007K5_A496AuditDateTime ;
      private DateTime[] P007K5_A494AuditDate ;
      private string[] P007K5_A501AuditGAMUserName ;
      private string[] P007K5_A499AuditShortDescription ;
      private string[] P007K5_A502AuditAction ;
      private string[] P007K5_A497AuditTableName ;
      private Guid[] P007K5_A493AuditID ;
      private string[] P007K6_A501AuditGAMUserName ;
      private DateTime[] P007K6_A495AuditTime ;
      private DateTime[] P007K6_A496AuditDateTime ;
      private DateTime[] P007K6_A494AuditDate ;
      private string[] P007K6_A498AuditDescription ;
      private string[] P007K6_A499AuditShortDescription ;
      private string[] P007K6_A502AuditAction ;
      private string[] P007K6_A497AuditTableName ;
      private Guid[] P007K6_A493AuditID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
   }

   public class auditwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007K2( IGxContext context ,
                                             string AV66Core_auditwwds_1_filterfulltext ,
                                             string AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV69Core_auditwwds_4_auditdate1 ,
                                             DateTime AV70Core_auditwwds_5_auditdate_to1 ,
                                             bool AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV74Core_auditwwds_9_auditdate2 ,
                                             DateTime AV75Core_auditwwds_10_auditdate_to2 ,
                                             bool AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV79Core_auditwwds_14_auditdate3 ,
                                             DateTime AV80Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV81Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV82Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV83Core_auditwwds_18_tfauditdate ,
                                             DateTime AV84Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV85Core_auditwwds_20_tfaudittime ,
                                             DateTime AV86Core_auditwwds_21_tfaudittime_to ,
                                             string AV88Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV87Core_auditwwds_22_tfaudittablename ,
                                             string AV90Core_auditwwds_25_tfauditaction_sel ,
                                             string AV89Core_auditwwds_24_tfauditaction ,
                                             string AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV91Core_auditwwds_26_tfauditshortdescription ,
                                             string AV94Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV93Core_auditwwds_28_tfauditdescription ,
                                             string AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV95Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[36];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT AuditTableName, AuditTime, AuditDateTime, AuditDate, AuditGAMUserName, AuditDescription, AuditShortDescription, AuditAction, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV66Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV70Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV70Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV75Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV80Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV81Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV82Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV83Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV84Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV85Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV86Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV87Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV88Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV89Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV90Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV91Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV92Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV93Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV94Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV95Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV96Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditTableName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007K3( IGxContext context ,
                                             string AV66Core_auditwwds_1_filterfulltext ,
                                             string AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV69Core_auditwwds_4_auditdate1 ,
                                             DateTime AV70Core_auditwwds_5_auditdate_to1 ,
                                             bool AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV74Core_auditwwds_9_auditdate2 ,
                                             DateTime AV75Core_auditwwds_10_auditdate_to2 ,
                                             bool AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV79Core_auditwwds_14_auditdate3 ,
                                             DateTime AV80Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV81Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV82Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV83Core_auditwwds_18_tfauditdate ,
                                             DateTime AV84Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV85Core_auditwwds_20_tfaudittime ,
                                             DateTime AV86Core_auditwwds_21_tfaudittime_to ,
                                             string AV88Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV87Core_auditwwds_22_tfaudittablename ,
                                             string AV90Core_auditwwds_25_tfauditaction_sel ,
                                             string AV89Core_auditwwds_24_tfauditaction ,
                                             string AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV91Core_auditwwds_26_tfauditshortdescription ,
                                             string AV94Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV93Core_auditwwds_28_tfauditdescription ,
                                             string AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV95Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[36];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT AuditAction, AuditTime, AuditDateTime, AuditDate, AuditGAMUserName, AuditDescription, AuditShortDescription, AuditTableName, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV66Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV70Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV70Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV75Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV80Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV81Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV82Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV83Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV84Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV85Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV86Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV87Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV88Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV89Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV90Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV91Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV92Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV93Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV94Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV95Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV96Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditAction";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007K4( IGxContext context ,
                                             string AV66Core_auditwwds_1_filterfulltext ,
                                             string AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV69Core_auditwwds_4_auditdate1 ,
                                             DateTime AV70Core_auditwwds_5_auditdate_to1 ,
                                             bool AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV74Core_auditwwds_9_auditdate2 ,
                                             DateTime AV75Core_auditwwds_10_auditdate_to2 ,
                                             bool AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV79Core_auditwwds_14_auditdate3 ,
                                             DateTime AV80Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV81Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV82Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV83Core_auditwwds_18_tfauditdate ,
                                             DateTime AV84Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV85Core_auditwwds_20_tfaudittime ,
                                             DateTime AV86Core_auditwwds_21_tfaudittime_to ,
                                             string AV88Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV87Core_auditwwds_22_tfaudittablename ,
                                             string AV90Core_auditwwds_25_tfauditaction_sel ,
                                             string AV89Core_auditwwds_24_tfauditaction ,
                                             string AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV91Core_auditwwds_26_tfauditshortdescription ,
                                             string AV94Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV93Core_auditwwds_28_tfauditdescription ,
                                             string AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV95Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[36];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT AuditShortDescription, AuditTime, AuditDateTime, AuditDate, AuditGAMUserName, AuditDescription, AuditAction, AuditTableName, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV66Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV70Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV70Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV75Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV80Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV81Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV82Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV83Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV84Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV85Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV86Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV87Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV88Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV89Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV90Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV91Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV92Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV93Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV94Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV95Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV96Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditShortDescription";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007K5( IGxContext context ,
                                             string AV66Core_auditwwds_1_filterfulltext ,
                                             string AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV69Core_auditwwds_4_auditdate1 ,
                                             DateTime AV70Core_auditwwds_5_auditdate_to1 ,
                                             bool AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV74Core_auditwwds_9_auditdate2 ,
                                             DateTime AV75Core_auditwwds_10_auditdate_to2 ,
                                             bool AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV79Core_auditwwds_14_auditdate3 ,
                                             DateTime AV80Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV81Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV82Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV83Core_auditwwds_18_tfauditdate ,
                                             DateTime AV84Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV85Core_auditwwds_20_tfaudittime ,
                                             DateTime AV86Core_auditwwds_21_tfaudittime_to ,
                                             string AV88Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV87Core_auditwwds_22_tfaudittablename ,
                                             string AV90Core_auditwwds_25_tfauditaction_sel ,
                                             string AV89Core_auditwwds_24_tfauditaction ,
                                             string AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV91Core_auditwwds_26_tfauditshortdescription ,
                                             string AV94Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV93Core_auditwwds_28_tfauditdescription ,
                                             string AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV95Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[36];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT AuditDescription, AuditTime, AuditDateTime, AuditDate, AuditGAMUserName, AuditShortDescription, AuditAction, AuditTableName, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV66Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV70Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV70Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV75Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV80Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV81Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV82Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV83Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV84Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV85Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV86Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV87Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV88Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV89Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV90Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV91Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV92Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV93Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV94Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV95Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV96Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditDescription";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P007K6( IGxContext context ,
                                             string AV66Core_auditwwds_1_filterfulltext ,
                                             string AV67Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV68Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV69Core_auditwwds_4_auditdate1 ,
                                             DateTime AV70Core_auditwwds_5_auditdate_to1 ,
                                             bool AV71Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV73Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV74Core_auditwwds_9_auditdate2 ,
                                             DateTime AV75Core_auditwwds_10_auditdate_to2 ,
                                             bool AV76Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV78Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV79Core_auditwwds_14_auditdate3 ,
                                             DateTime AV80Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV81Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV82Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV83Core_auditwwds_18_tfauditdate ,
                                             DateTime AV84Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV85Core_auditwwds_20_tfaudittime ,
                                             DateTime AV86Core_auditwwds_21_tfaudittime_to ,
                                             string AV88Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV87Core_auditwwds_22_tfaudittablename ,
                                             string AV90Core_auditwwds_25_tfauditaction_sel ,
                                             string AV89Core_auditwwds_24_tfauditaction ,
                                             string AV92Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV91Core_auditwwds_26_tfauditshortdescription ,
                                             string AV94Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV93Core_auditwwds_28_tfauditdescription ,
                                             string AV96Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV95Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[36];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT AuditGAMUserName, AuditTime, AuditDateTime, AuditDate, AuditDescription, AuditShortDescription, AuditAction, AuditTableName, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV66Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV66Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV70Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV70Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV68Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV69Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV69Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV75Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV71Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV73Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV74Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV80Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( AV76Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV78Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV79Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV81Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV82Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV83Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV84Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV85Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV86Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV87Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV88Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( StringUtil.StrCmp(AV88Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV89Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV90Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( StringUtil.StrCmp(AV90Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV91Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV92Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( StringUtil.StrCmp(AV92Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV93Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV94Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV95Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV96Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY AuditGAMUserName";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] );
               case 1 :
                     return conditional_P007K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] );
               case 2 :
                     return conditional_P007K4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] );
               case 3 :
                     return conditional_P007K5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] );
               case 4 :
                     return conditional_P007K6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007K2;
          prmP007K2 = new Object[] {
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV70Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV81Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV82Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV83Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV84Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV86Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV87Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV89Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV90Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV92Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV93Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV94Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV95Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV96Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          Object[] prmP007K3;
          prmP007K3 = new Object[] {
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV70Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV81Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV82Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV83Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV84Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV86Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV87Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV89Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV90Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV92Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV93Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV94Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV95Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV96Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          Object[] prmP007K4;
          prmP007K4 = new Object[] {
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV70Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV81Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV82Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV83Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV84Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV86Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV87Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV89Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV90Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV92Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV93Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV94Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV95Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV96Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          Object[] prmP007K5;
          prmP007K5 = new Object[] {
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV70Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV81Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV82Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV83Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV84Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV86Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV87Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV89Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV90Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV92Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV93Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV94Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV95Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV96Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          Object[] prmP007K6;
          prmP007K6 = new Object[] {
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV70Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV69Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV81Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV82Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV83Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV84Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV86Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV87Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV89Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV90Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV92Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV93Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV94Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV95Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV96Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007K5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007K6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K6,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
