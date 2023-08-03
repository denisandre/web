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
   public class documentotipowwgetfilterdata : GXProcedure
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
            return "documentotipoww_Services_Execute" ;
         }

      }

      public documentotipowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentotipowwgetfilterdata( IGxContext context )
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
         documentotipowwgetfilterdata objdocumentotipowwgetfilterdata;
         objdocumentotipowwgetfilterdata = new documentotipowwgetfilterdata();
         objdocumentotipowwgetfilterdata.AV31DDOName = aP0_DDOName;
         objdocumentotipowwgetfilterdata.AV32SearchTxtParms = aP1_SearchTxtParms;
         objdocumentotipowwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objdocumentotipowwgetfilterdata.AV34OptionsJson = "" ;
         objdocumentotipowwgetfilterdata.AV35OptionsDescJson = "" ;
         objdocumentotipowwgetfilterdata.AV36OptionIndexesJson = "" ;
         objdocumentotipowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdocumentotipowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objdocumentotipowwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentotipowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_DOCTIPOSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCTIPOSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_DOCTIPONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCTIPONOMEOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("core.DocumentoTipoWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoTipoWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("core.DocumentoTipoWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "DOCTIPODEL_FILTRO") == 0 )
            {
               AV50DocTipoDel_Filtro = BooleanUtil.Val( AV29GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDOCTIPOSIGLA") == 0 )
            {
               AV11TFDocTipoSigla = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDOCTIPOSIGLA_SEL") == 0 )
            {
               AV12TFDocTipoSigla_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME") == 0 )
            {
               AV13TFDocTipoNome = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME_SEL") == 0 )
            {
               AV14TFDocTipoNome_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40DocTipoSigla1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44DocTipoSigla2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48DocTipoSigla3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCTIPOSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV11TFDocTipoSigla = AV15SearchTxt;
         AV12TFDocTipoSigla_Sel = "";
         AV53Core_documentotipowwds_1_doctipodel_filtro = AV50DocTipoDel_Filtro;
         AV54Core_documentotipowwds_2_filterfulltext = AV37FilterFullText;
         AV55Core_documentotipowwds_3_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Core_documentotipowwds_4_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Core_documentotipowwds_5_doctiposigla1 = AV40DocTipoSigla1;
         AV58Core_documentotipowwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Core_documentotipowwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Core_documentotipowwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Core_documentotipowwds_9_doctiposigla2 = AV44DocTipoSigla2;
         AV62Core_documentotipowwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Core_documentotipowwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Core_documentotipowwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Core_documentotipowwds_13_doctiposigla3 = AV48DocTipoSigla3;
         AV66Core_documentotipowwds_14_tfdoctiposigla = AV11TFDocTipoSigla;
         AV67Core_documentotipowwds_15_tfdoctiposigla_sel = AV12TFDocTipoSigla_Sel;
         AV68Core_documentotipowwds_16_tfdoctiponome = AV13TFDocTipoNome;
         AV69Core_documentotipowwds_17_tfdoctiponome_sel = AV14TFDocTipoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Core_documentotipowwds_2_filterfulltext ,
                                              AV55Core_documentotipowwds_3_dynamicfiltersselector1 ,
                                              AV56Core_documentotipowwds_4_dynamicfiltersoperator1 ,
                                              AV57Core_documentotipowwds_5_doctiposigla1 ,
                                              AV58Core_documentotipowwds_6_dynamicfiltersenabled2 ,
                                              AV59Core_documentotipowwds_7_dynamicfiltersselector2 ,
                                              AV60Core_documentotipowwds_8_dynamicfiltersoperator2 ,
                                              AV61Core_documentotipowwds_9_doctiposigla2 ,
                                              AV62Core_documentotipowwds_10_dynamicfiltersenabled3 ,
                                              AV63Core_documentotipowwds_11_dynamicfiltersselector3 ,
                                              AV64Core_documentotipowwds_12_dynamicfiltersoperator3 ,
                                              AV65Core_documentotipowwds_13_doctiposigla3 ,
                                              AV67Core_documentotipowwds_15_tfdoctiposigla_sel ,
                                              AV66Core_documentotipowwds_14_tfdoctiposigla ,
                                              AV69Core_documentotipowwds_17_tfdoctiponome_sel ,
                                              AV68Core_documentotipowwds_16_tfdoctiponome ,
                                              A147DocTipoSigla ,
                                              A148DocTipoNome ,
                                              A503DocTipoDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Core_documentotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_documentotipowwds_2_filterfulltext), "%", "");
         lV54Core_documentotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_documentotipowwds_2_filterfulltext), "%", "");
         lV57Core_documentotipowwds_5_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1), "%", "");
         lV57Core_documentotipowwds_5_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1), "%", "");
         lV61Core_documentotipowwds_9_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2), "%", "");
         lV61Core_documentotipowwds_9_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2), "%", "");
         lV65Core_documentotipowwds_13_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3), "%", "");
         lV65Core_documentotipowwds_13_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3), "%", "");
         lV66Core_documentotipowwds_14_tfdoctiposigla = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentotipowwds_14_tfdoctiposigla), "%", "");
         lV68Core_documentotipowwds_16_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV68Core_documentotipowwds_16_tfdoctiponome), "%", "");
         /* Using cursor P003R2 */
         pr_default.execute(0, new Object[] {lV54Core_documentotipowwds_2_filterfulltext, lV54Core_documentotipowwds_2_filterfulltext, lV57Core_documentotipowwds_5_doctiposigla1, lV57Core_documentotipowwds_5_doctiposigla1, lV61Core_documentotipowwds_9_doctiposigla2, lV61Core_documentotipowwds_9_doctiposigla2, lV65Core_documentotipowwds_13_doctiposigla3, lV65Core_documentotipowwds_13_doctiposigla3, lV66Core_documentotipowwds_14_tfdoctiposigla, AV67Core_documentotipowwds_15_tfdoctiposigla_sel, lV68Core_documentotipowwds_16_tfdoctiponome, AV69Core_documentotipowwds_17_tfdoctiponome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3R2 = false;
            A147DocTipoSigla = P003R2_A147DocTipoSigla[0];
            A148DocTipoNome = P003R2_A148DocTipoNome[0];
            A503DocTipoDel = P003R2_A503DocTipoDel[0];
            A146DocTipoID = P003R2_A146DocTipoID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003R2_A147DocTipoSigla[0], A147DocTipoSigla) == 0 ) )
            {
               BRK3R2 = false;
               A146DocTipoID = P003R2_A146DocTipoID[0];
               AV25count = (long)(AV25count+1);
               BRK3R2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A147DocTipoSigla)) ? "<#Empty#>" : A147DocTipoSigla);
               AV22OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A147DocTipoSigla, "")));
               AV21Options.Add(AV20Option, 0);
               AV23OptionsDesc.Add(AV22OptionDesc, 0);
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
            if ( ! BRK3R2 )
            {
               BRK3R2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDOCTIPONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFDocTipoNome = AV15SearchTxt;
         AV14TFDocTipoNome_Sel = "";
         AV53Core_documentotipowwds_1_doctipodel_filtro = AV50DocTipoDel_Filtro;
         AV54Core_documentotipowwds_2_filterfulltext = AV37FilterFullText;
         AV55Core_documentotipowwds_3_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Core_documentotipowwds_4_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Core_documentotipowwds_5_doctiposigla1 = AV40DocTipoSigla1;
         AV58Core_documentotipowwds_6_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Core_documentotipowwds_7_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Core_documentotipowwds_8_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Core_documentotipowwds_9_doctiposigla2 = AV44DocTipoSigla2;
         AV62Core_documentotipowwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Core_documentotipowwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Core_documentotipowwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Core_documentotipowwds_13_doctiposigla3 = AV48DocTipoSigla3;
         AV66Core_documentotipowwds_14_tfdoctiposigla = AV11TFDocTipoSigla;
         AV67Core_documentotipowwds_15_tfdoctiposigla_sel = AV12TFDocTipoSigla_Sel;
         AV68Core_documentotipowwds_16_tfdoctiponome = AV13TFDocTipoNome;
         AV69Core_documentotipowwds_17_tfdoctiponome_sel = AV14TFDocTipoNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Core_documentotipowwds_2_filterfulltext ,
                                              AV55Core_documentotipowwds_3_dynamicfiltersselector1 ,
                                              AV56Core_documentotipowwds_4_dynamicfiltersoperator1 ,
                                              AV57Core_documentotipowwds_5_doctiposigla1 ,
                                              AV58Core_documentotipowwds_6_dynamicfiltersenabled2 ,
                                              AV59Core_documentotipowwds_7_dynamicfiltersselector2 ,
                                              AV60Core_documentotipowwds_8_dynamicfiltersoperator2 ,
                                              AV61Core_documentotipowwds_9_doctiposigla2 ,
                                              AV62Core_documentotipowwds_10_dynamicfiltersenabled3 ,
                                              AV63Core_documentotipowwds_11_dynamicfiltersselector3 ,
                                              AV64Core_documentotipowwds_12_dynamicfiltersoperator3 ,
                                              AV65Core_documentotipowwds_13_doctiposigla3 ,
                                              AV67Core_documentotipowwds_15_tfdoctiposigla_sel ,
                                              AV66Core_documentotipowwds_14_tfdoctiposigla ,
                                              AV69Core_documentotipowwds_17_tfdoctiponome_sel ,
                                              AV68Core_documentotipowwds_16_tfdoctiponome ,
                                              A147DocTipoSigla ,
                                              A148DocTipoNome ,
                                              A503DocTipoDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Core_documentotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_documentotipowwds_2_filterfulltext), "%", "");
         lV54Core_documentotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_documentotipowwds_2_filterfulltext), "%", "");
         lV57Core_documentotipowwds_5_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1), "%", "");
         lV57Core_documentotipowwds_5_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1), "%", "");
         lV61Core_documentotipowwds_9_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2), "%", "");
         lV61Core_documentotipowwds_9_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2), "%", "");
         lV65Core_documentotipowwds_13_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3), "%", "");
         lV65Core_documentotipowwds_13_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3), "%", "");
         lV66Core_documentotipowwds_14_tfdoctiposigla = StringUtil.Concat( StringUtil.RTrim( AV66Core_documentotipowwds_14_tfdoctiposigla), "%", "");
         lV68Core_documentotipowwds_16_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV68Core_documentotipowwds_16_tfdoctiponome), "%", "");
         /* Using cursor P003R3 */
         pr_default.execute(1, new Object[] {lV54Core_documentotipowwds_2_filterfulltext, lV54Core_documentotipowwds_2_filterfulltext, lV57Core_documentotipowwds_5_doctiposigla1, lV57Core_documentotipowwds_5_doctiposigla1, lV61Core_documentotipowwds_9_doctiposigla2, lV61Core_documentotipowwds_9_doctiposigla2, lV65Core_documentotipowwds_13_doctiposigla3, lV65Core_documentotipowwds_13_doctiposigla3, lV66Core_documentotipowwds_14_tfdoctiposigla, AV67Core_documentotipowwds_15_tfdoctiposigla_sel, lV68Core_documentotipowwds_16_tfdoctiponome, AV69Core_documentotipowwds_17_tfdoctiponome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3R4 = false;
            A148DocTipoNome = P003R3_A148DocTipoNome[0];
            A147DocTipoSigla = P003R3_A147DocTipoSigla[0];
            A503DocTipoDel = P003R3_A503DocTipoDel[0];
            A146DocTipoID = P003R3_A146DocTipoID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003R3_A148DocTipoNome[0], A148DocTipoNome) == 0 ) )
            {
               BRK3R4 = false;
               A146DocTipoID = P003R3_A146DocTipoID[0];
               AV25count = (long)(AV25count+1);
               BRK3R4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148DocTipoNome)) ? "<#Empty#>" : A148DocTipoNome);
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
            if ( ! BRK3R4 )
            {
               BRK3R4 = true;
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
         AV11TFDocTipoSigla = "";
         AV12TFDocTipoSigla_Sel = "";
         AV13TFDocTipoNome = "";
         AV14TFDocTipoNome_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40DocTipoSigla1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44DocTipoSigla2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48DocTipoSigla3 = "";
         AV54Core_documentotipowwds_2_filterfulltext = "";
         AV55Core_documentotipowwds_3_dynamicfiltersselector1 = "";
         AV57Core_documentotipowwds_5_doctiposigla1 = "";
         AV59Core_documentotipowwds_7_dynamicfiltersselector2 = "";
         AV61Core_documentotipowwds_9_doctiposigla2 = "";
         AV63Core_documentotipowwds_11_dynamicfiltersselector3 = "";
         AV65Core_documentotipowwds_13_doctiposigla3 = "";
         AV66Core_documentotipowwds_14_tfdoctiposigla = "";
         AV67Core_documentotipowwds_15_tfdoctiposigla_sel = "";
         AV68Core_documentotipowwds_16_tfdoctiponome = "";
         AV69Core_documentotipowwds_17_tfdoctiponome_sel = "";
         scmdbuf = "";
         lV54Core_documentotipowwds_2_filterfulltext = "";
         lV57Core_documentotipowwds_5_doctiposigla1 = "";
         lV61Core_documentotipowwds_9_doctiposigla2 = "";
         lV65Core_documentotipowwds_13_doctiposigla3 = "";
         lV66Core_documentotipowwds_14_tfdoctiposigla = "";
         lV68Core_documentotipowwds_16_tfdoctiponome = "";
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         P003R2_A147DocTipoSigla = new string[] {""} ;
         P003R2_A148DocTipoNome = new string[] {""} ;
         P003R2_A503DocTipoDel = new bool[] {false} ;
         P003R2_A146DocTipoID = new int[1] ;
         AV20Option = "";
         AV22OptionDesc = "";
         P003R3_A148DocTipoNome = new string[] {""} ;
         P003R3_A147DocTipoSigla = new string[] {""} ;
         P003R3_A503DocTipoDel = new bool[] {false} ;
         P003R3_A146DocTipoID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentotipowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003R2_A147DocTipoSigla, P003R2_A148DocTipoNome, P003R2_A503DocTipoDel, P003R2_A146DocTipoID
               }
               , new Object[] {
               P003R3_A148DocTipoNome, P003R3_A147DocTipoSigla, P003R3_A503DocTipoDel, P003R3_A146DocTipoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV56Core_documentotipowwds_4_dynamicfiltersoperator1 ;
      private short AV60Core_documentotipowwds_8_dynamicfiltersoperator2 ;
      private short AV64Core_documentotipowwds_12_dynamicfiltersoperator3 ;
      private int AV51GXV1 ;
      private int A146DocTipoID ;
      private long AV25count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV50DocTipoDel_Filtro ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV53Core_documentotipowwds_1_doctipodel_filtro ;
      private bool AV58Core_documentotipowwds_6_dynamicfiltersenabled2 ;
      private bool AV62Core_documentotipowwds_10_dynamicfiltersenabled3 ;
      private bool A503DocTipoDel ;
      private bool BRK3R2 ;
      private bool BRK3R4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFDocTipoSigla ;
      private string AV12TFDocTipoSigla_Sel ;
      private string AV13TFDocTipoNome ;
      private string AV14TFDocTipoNome_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40DocTipoSigla1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44DocTipoSigla2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48DocTipoSigla3 ;
      private string AV54Core_documentotipowwds_2_filterfulltext ;
      private string AV55Core_documentotipowwds_3_dynamicfiltersselector1 ;
      private string AV57Core_documentotipowwds_5_doctiposigla1 ;
      private string AV59Core_documentotipowwds_7_dynamicfiltersselector2 ;
      private string AV61Core_documentotipowwds_9_doctiposigla2 ;
      private string AV63Core_documentotipowwds_11_dynamicfiltersselector3 ;
      private string AV65Core_documentotipowwds_13_doctiposigla3 ;
      private string AV66Core_documentotipowwds_14_tfdoctiposigla ;
      private string AV67Core_documentotipowwds_15_tfdoctiposigla_sel ;
      private string AV68Core_documentotipowwds_16_tfdoctiponome ;
      private string AV69Core_documentotipowwds_17_tfdoctiponome_sel ;
      private string lV54Core_documentotipowwds_2_filterfulltext ;
      private string lV57Core_documentotipowwds_5_doctiposigla1 ;
      private string lV61Core_documentotipowwds_9_doctiposigla2 ;
      private string lV65Core_documentotipowwds_13_doctiposigla3 ;
      private string lV66Core_documentotipowwds_14_tfdoctiposigla ;
      private string lV68Core_documentotipowwds_16_tfdoctiponome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private string AV20Option ;
      private string AV22OptionDesc ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003R2_A147DocTipoSigla ;
      private string[] P003R2_A148DocTipoNome ;
      private bool[] P003R2_A503DocTipoDel ;
      private int[] P003R2_A146DocTipoID ;
      private string[] P003R3_A148DocTipoNome ;
      private string[] P003R3_A147DocTipoSigla ;
      private bool[] P003R3_A503DocTipoDel ;
      private int[] P003R3_A146DocTipoID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class documentotipowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003R2( IGxContext context ,
                                             string AV54Core_documentotipowwds_2_filterfulltext ,
                                             string AV55Core_documentotipowwds_3_dynamicfiltersselector1 ,
                                             short AV56Core_documentotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV57Core_documentotipowwds_5_doctiposigla1 ,
                                             bool AV58Core_documentotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV59Core_documentotipowwds_7_dynamicfiltersselector2 ,
                                             short AV60Core_documentotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV61Core_documentotipowwds_9_doctiposigla2 ,
                                             bool AV62Core_documentotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV63Core_documentotipowwds_11_dynamicfiltersselector3 ,
                                             short AV64Core_documentotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV65Core_documentotipowwds_13_doctiposigla3 ,
                                             string AV67Core_documentotipowwds_15_tfdoctiposigla_sel ,
                                             string AV66Core_documentotipowwds_14_tfdoctiposigla ,
                                             string AV69Core_documentotipowwds_17_tfdoctiponome_sel ,
                                             string AV68Core_documentotipowwds_16_tfdoctiponome ,
                                             string A147DocTipoSigla ,
                                             string A148DocTipoNome ,
                                             bool A503DocTipoDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DocTipoSigla, DocTipoNome, DocTipoDel, DocTipoID FROM tb_documentotipo";
         AddWhere(sWhereString, "(Not DocTipoDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_documentotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocTipoSigla like '%' || :lV54Core_documentotipowwds_2_filterfulltext) or ( DocTipoNome like '%' || :lV54Core_documentotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_documentotipowwds_3_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV56Core_documentotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV57Core_documentotipowwds_5_doctiposigla1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_documentotipowwds_3_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV56Core_documentotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV57Core_documentotipowwds_5_doctiposigla1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Core_documentotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_documentotipowwds_7_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV60Core_documentotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV61Core_documentotipowwds_9_doctiposigla2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Core_documentotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_documentotipowwds_7_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV60Core_documentotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV61Core_documentotipowwds_9_doctiposigla2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV62Core_documentotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_documentotipowwds_11_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV64Core_documentotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV65Core_documentotipowwds_13_doctiposigla3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV62Core_documentotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_documentotipowwds_11_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV64Core_documentotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV65Core_documentotipowwds_13_doctiposigla3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_documentotipowwds_15_tfdoctiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_documentotipowwds_14_tfdoctiposigla)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV66Core_documentotipowwds_14_tfdoctiposigla)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_documentotipowwds_15_tfdoctiposigla_sel)) && ! ( StringUtil.StrCmp(AV67Core_documentotipowwds_15_tfdoctiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla = ( :AV67Core_documentotipowwds_15_tfdoctiposigla_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_documentotipowwds_15_tfdoctiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocTipoSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_documentotipowwds_17_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_documentotipowwds_16_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(DocTipoNome like :lV68Core_documentotipowwds_16_tfdoctiponome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_documentotipowwds_17_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV69Core_documentotipowwds_17_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocTipoNome = ( :AV69Core_documentotipowwds_17_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_documentotipowwds_17_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocTipoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocTipoSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003R3( IGxContext context ,
                                             string AV54Core_documentotipowwds_2_filterfulltext ,
                                             string AV55Core_documentotipowwds_3_dynamicfiltersselector1 ,
                                             short AV56Core_documentotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV57Core_documentotipowwds_5_doctiposigla1 ,
                                             bool AV58Core_documentotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV59Core_documentotipowwds_7_dynamicfiltersselector2 ,
                                             short AV60Core_documentotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV61Core_documentotipowwds_9_doctiposigla2 ,
                                             bool AV62Core_documentotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV63Core_documentotipowwds_11_dynamicfiltersselector3 ,
                                             short AV64Core_documentotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV65Core_documentotipowwds_13_doctiposigla3 ,
                                             string AV67Core_documentotipowwds_15_tfdoctiposigla_sel ,
                                             string AV66Core_documentotipowwds_14_tfdoctiposigla ,
                                             string AV69Core_documentotipowwds_17_tfdoctiponome_sel ,
                                             string AV68Core_documentotipowwds_16_tfdoctiponome ,
                                             string A147DocTipoSigla ,
                                             string A148DocTipoNome ,
                                             bool A503DocTipoDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT DocTipoNome, DocTipoSigla, DocTipoDel, DocTipoID FROM tb_documentotipo";
         AddWhere(sWhereString, "(Not DocTipoDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_documentotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocTipoSigla like '%' || :lV54Core_documentotipowwds_2_filterfulltext) or ( DocTipoNome like '%' || :lV54Core_documentotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_documentotipowwds_3_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV56Core_documentotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV57Core_documentotipowwds_5_doctiposigla1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_documentotipowwds_3_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV56Core_documentotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_documentotipowwds_5_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV57Core_documentotipowwds_5_doctiposigla1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Core_documentotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_documentotipowwds_7_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV60Core_documentotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV61Core_documentotipowwds_9_doctiposigla2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Core_documentotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_documentotipowwds_7_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV60Core_documentotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_documentotipowwds_9_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV61Core_documentotipowwds_9_doctiposigla2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV62Core_documentotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_documentotipowwds_11_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV64Core_documentotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV65Core_documentotipowwds_13_doctiposigla3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Core_documentotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_documentotipowwds_11_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV64Core_documentotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_documentotipowwds_13_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV65Core_documentotipowwds_13_doctiposigla3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_documentotipowwds_15_tfdoctiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_documentotipowwds_14_tfdoctiposigla)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV66Core_documentotipowwds_14_tfdoctiposigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_documentotipowwds_15_tfdoctiposigla_sel)) && ! ( StringUtil.StrCmp(AV67Core_documentotipowwds_15_tfdoctiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla = ( :AV67Core_documentotipowwds_15_tfdoctiposigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_documentotipowwds_15_tfdoctiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocTipoSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_documentotipowwds_17_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_documentotipowwds_16_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(DocTipoNome like :lV68Core_documentotipowwds_16_tfdoctiponome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_documentotipowwds_17_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV69Core_documentotipowwds_17_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocTipoNome = ( :AV69Core_documentotipowwds_17_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_documentotipowwds_17_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocTipoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocTipoNome";
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
                     return conditional_P003R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
               case 1 :
                     return conditional_P003R3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP003R2;
          prmP003R2 = new Object[] {
          new ParDef("lV54Core_documentotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Core_documentotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Core_documentotipowwds_5_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV57Core_documentotipowwds_5_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV61Core_documentotipowwds_9_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV61Core_documentotipowwds_9_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV65Core_documentotipowwds_13_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV65Core_documentotipowwds_13_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV66Core_documentotipowwds_14_tfdoctiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV67Core_documentotipowwds_15_tfdoctiposigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV68Core_documentotipowwds_16_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV69Core_documentotipowwds_17_tfdoctiponome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP003R3;
          prmP003R3 = new Object[] {
          new ParDef("lV54Core_documentotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Core_documentotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Core_documentotipowwds_5_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV57Core_documentotipowwds_5_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV61Core_documentotipowwds_9_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV61Core_documentotipowwds_9_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV65Core_documentotipowwds_13_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV65Core_documentotipowwds_13_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV66Core_documentotipowwds_14_tfdoctiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV67Core_documentotipowwds_15_tfdoctiposigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV68Core_documentotipowwds_16_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV69Core_documentotipowwds_17_tfdoctiponome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R3,100, GxCacheFrequency.OFF ,true,false )
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
