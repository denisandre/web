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
   public class microrregiaowwgetfilterdata : GXProcedure
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
            return "microrregiaoww_Services_Execute" ;
         }

      }

      public microrregiaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public microrregiaowwgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         microrregiaowwgetfilterdata objmicrorregiaowwgetfilterdata;
         objmicrorregiaowwgetfilterdata = new microrregiaowwgetfilterdata();
         objmicrorregiaowwgetfilterdata.AV37DDOName = aP0_DDOName;
         objmicrorregiaowwgetfilterdata.AV38SearchTxtParms = aP1_SearchTxtParms;
         objmicrorregiaowwgetfilterdata.AV39SearchTxtTo = aP2_SearchTxtTo;
         objmicrorregiaowwgetfilterdata.AV40OptionsJson = "" ;
         objmicrorregiaowwgetfilterdata.AV41OptionsDescJson = "" ;
         objmicrorregiaowwgetfilterdata.AV42OptionIndexesJson = "" ;
         objmicrorregiaowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmicrorregiaowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objmicrorregiaowwgetfilterdata);
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((microrregiaowwgetfilterdata)stateInfo).executePrivate();
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
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_MICRORREGIAONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMICRORREGIAONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_MICRORREGIAOMESONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMICRORREGIAOMESONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_MICRORREGIAOMESOUFSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADMICRORREGIAOMESOUFSIGLAOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_MICRORREGIAOMESOUFREGNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMICRORREGIAOMESOUFREGNOMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("core.microrregiaoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.microrregiaoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.microrregiaoWWGridState"), null, "", "");
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOID") == 0 )
            {
               AV11TFMicrorregiaoID = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMicrorregiaoID_To = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAONOME") == 0 )
            {
               AV13TFMicrorregiaoNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAONOME_SEL") == 0 )
            {
               AV14TFMicrorregiaoNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESONOME") == 0 )
            {
               AV15TFMicrorregiaoMesoNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESONOME_SEL") == 0 )
            {
               AV16TFMicrorregiaoMesoNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFSIGLA") == 0 )
            {
               AV17TFMicrorregiaoMesoUFSigla = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFSIGLA_SEL") == 0 )
            {
               AV18TFMicrorregiaoMesoUFSigla_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFREGNOME") == 0 )
            {
               AV19TFMicrorregiaoMesoUFRegNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFREGNOME_SEL") == 0 )
            {
               AV20TFMicrorregiaoMesoUFRegNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMICRORREGIAONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFMicrorregiaoNome = AV21SearchTxt;
         AV14TFMicrorregiaoNome_Sel = "";
         AV46Core_microrregiaowwds_1_filterfulltext = AV43FilterFullText;
         AV47Core_microrregiaowwds_2_tfmicrorregiaoid = AV11TFMicrorregiaoID;
         AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV12TFMicrorregiaoID_To;
         AV49Core_microrregiaowwds_4_tfmicrorregiaonome = AV13TFMicrorregiaoNome;
         AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV14TFMicrorregiaoNome_Sel;
         AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV15TFMicrorregiaoMesoNome;
         AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV16TFMicrorregiaoMesoNome_Sel;
         AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV17TFMicrorregiaoMesoUFSigla;
         AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV18TFMicrorregiaoMesoUFSigla_Sel;
         AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV19TFMicrorregiaoMesoUFRegNome;
         AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV20TFMicrorregiaoMesoUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Core_microrregiaowwds_1_filterfulltext ,
                                              AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                              AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                              AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                              AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                              AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                              AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                              AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                              AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                              AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                              AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                              A23MicrorregiaoID ,
                                              A24MicrorregiaoNome ,
                                              A26MicrorregiaoMesoNome ,
                                              A28MicrorregiaoMesoUFSigla ,
                                              A33MicrorregiaoMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV49Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
         lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
         lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
         lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
         /* Using cursor P005M2 */
         pr_default.execute(0, new Object[] {lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, AV47Core_microrregiaowwds_2_tfmicrorregiaoid, AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV49Core_microrregiaowwds_4_tfmicrorregiaonome, AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5M2 = false;
            A24MicrorregiaoNome = P005M2_A24MicrorregiaoNome[0];
            A23MicrorregiaoID = P005M2_A23MicrorregiaoID[0];
            A33MicrorregiaoMesoUFRegNome = P005M2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P005M2_n33MicrorregiaoMesoUFRegNome[0];
            A28MicrorregiaoMesoUFSigla = P005M2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P005M2_n28MicrorregiaoMesoUFSigla[0];
            A26MicrorregiaoMesoNome = P005M2_A26MicrorregiaoMesoNome[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005M2_A24MicrorregiaoNome[0], A24MicrorregiaoNome) == 0 ) )
            {
               BRK5M2 = false;
               A23MicrorregiaoID = P005M2_A23MicrorregiaoID[0];
               AV31count = (long)(AV31count+1);
               BRK5M2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A24MicrorregiaoNome)) ? "<#Empty#>" : A24MicrorregiaoNome);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK5M2 )
            {
               BRK5M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMICRORREGIAOMESONOMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFMicrorregiaoMesoNome = AV21SearchTxt;
         AV16TFMicrorregiaoMesoNome_Sel = "";
         AV46Core_microrregiaowwds_1_filterfulltext = AV43FilterFullText;
         AV47Core_microrregiaowwds_2_tfmicrorregiaoid = AV11TFMicrorregiaoID;
         AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV12TFMicrorregiaoID_To;
         AV49Core_microrregiaowwds_4_tfmicrorregiaonome = AV13TFMicrorregiaoNome;
         AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV14TFMicrorregiaoNome_Sel;
         AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV15TFMicrorregiaoMesoNome;
         AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV16TFMicrorregiaoMesoNome_Sel;
         AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV17TFMicrorregiaoMesoUFSigla;
         AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV18TFMicrorregiaoMesoUFSigla_Sel;
         AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV19TFMicrorregiaoMesoUFRegNome;
         AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV20TFMicrorregiaoMesoUFRegNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV46Core_microrregiaowwds_1_filterfulltext ,
                                              AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                              AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                              AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                              AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                              AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                              AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                              AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                              AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                              AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                              AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                              A23MicrorregiaoID ,
                                              A24MicrorregiaoNome ,
                                              A26MicrorregiaoMesoNome ,
                                              A28MicrorregiaoMesoUFSigla ,
                                              A33MicrorregiaoMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV49Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
         lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
         lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
         lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
         /* Using cursor P005M3 */
         pr_default.execute(1, new Object[] {lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, AV47Core_microrregiaowwds_2_tfmicrorregiaoid, AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV49Core_microrregiaowwds_4_tfmicrorregiaonome, AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5M4 = false;
            A25MicrorregiaoMesoID = P005M3_A25MicrorregiaoMesoID[0];
            A23MicrorregiaoID = P005M3_A23MicrorregiaoID[0];
            A33MicrorregiaoMesoUFRegNome = P005M3_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P005M3_n33MicrorregiaoMesoUFRegNome[0];
            A28MicrorregiaoMesoUFSigla = P005M3_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P005M3_n28MicrorregiaoMesoUFSigla[0];
            A26MicrorregiaoMesoNome = P005M3_A26MicrorregiaoMesoNome[0];
            A24MicrorregiaoNome = P005M3_A24MicrorregiaoNome[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P005M3_A25MicrorregiaoMesoID[0] == A25MicrorregiaoMesoID ) )
            {
               BRK5M4 = false;
               A23MicrorregiaoID = P005M3_A23MicrorregiaoID[0];
               AV31count = (long)(AV31count+1);
               BRK5M4 = true;
               pr_default.readNext(1);
            }
            AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A26MicrorregiaoMesoNome)) ? "<#Empty#>" : A26MicrorregiaoMesoNome);
            AV25InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV25InsertIndex = (int)(AV25InsertIndex+1);
            }
            AV27Options.Add(AV26Option, AV25InsertIndex);
            AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
            if ( AV27Options.Count == AV22SkipItems + 11 )
            {
               AV27Options.RemoveItem(AV27Options.Count);
               AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
            }
            if ( ! BRK5M4 )
            {
               BRK5M4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADMICRORREGIAOMESOUFSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV17TFMicrorregiaoMesoUFSigla = AV21SearchTxt;
         AV18TFMicrorregiaoMesoUFSigla_Sel = "";
         AV46Core_microrregiaowwds_1_filterfulltext = AV43FilterFullText;
         AV47Core_microrregiaowwds_2_tfmicrorregiaoid = AV11TFMicrorregiaoID;
         AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV12TFMicrorregiaoID_To;
         AV49Core_microrregiaowwds_4_tfmicrorregiaonome = AV13TFMicrorregiaoNome;
         AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV14TFMicrorregiaoNome_Sel;
         AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV15TFMicrorregiaoMesoNome;
         AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV16TFMicrorregiaoMesoNome_Sel;
         AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV17TFMicrorregiaoMesoUFSigla;
         AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV18TFMicrorregiaoMesoUFSigla_Sel;
         AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV19TFMicrorregiaoMesoUFRegNome;
         AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV20TFMicrorregiaoMesoUFRegNome_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV46Core_microrregiaowwds_1_filterfulltext ,
                                              AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                              AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                              AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                              AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                              AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                              AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                              AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                              AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                              AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                              AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                              A23MicrorregiaoID ,
                                              A24MicrorregiaoNome ,
                                              A26MicrorregiaoMesoNome ,
                                              A28MicrorregiaoMesoUFSigla ,
                                              A33MicrorregiaoMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV49Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
         lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
         lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
         lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
         /* Using cursor P005M4 */
         pr_default.execute(2, new Object[] {lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, AV47Core_microrregiaowwds_2_tfmicrorregiaoid, AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV49Core_microrregiaowwds_4_tfmicrorregiaonome, AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5M6 = false;
            A28MicrorregiaoMesoUFSigla = P005M4_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P005M4_n28MicrorregiaoMesoUFSigla[0];
            A23MicrorregiaoID = P005M4_A23MicrorregiaoID[0];
            A33MicrorregiaoMesoUFRegNome = P005M4_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P005M4_n33MicrorregiaoMesoUFRegNome[0];
            A26MicrorregiaoMesoNome = P005M4_A26MicrorregiaoMesoNome[0];
            A24MicrorregiaoNome = P005M4_A24MicrorregiaoNome[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005M4_A28MicrorregiaoMesoUFSigla[0], A28MicrorregiaoMesoUFSigla) == 0 ) )
            {
               BRK5M6 = false;
               A23MicrorregiaoID = P005M4_A23MicrorregiaoID[0];
               AV31count = (long)(AV31count+1);
               BRK5M6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A28MicrorregiaoMesoUFSigla)) ? "<#Empty#>" : A28MicrorregiaoMesoUFSigla);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK5M6 )
            {
               BRK5M6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADMICRORREGIAOMESOUFREGNOMEOPTIONS' Routine */
         returnInSub = false;
         AV19TFMicrorregiaoMesoUFRegNome = AV21SearchTxt;
         AV20TFMicrorregiaoMesoUFRegNome_Sel = "";
         AV46Core_microrregiaowwds_1_filterfulltext = AV43FilterFullText;
         AV47Core_microrregiaowwds_2_tfmicrorregiaoid = AV11TFMicrorregiaoID;
         AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV12TFMicrorregiaoID_To;
         AV49Core_microrregiaowwds_4_tfmicrorregiaonome = AV13TFMicrorregiaoNome;
         AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV14TFMicrorregiaoNome_Sel;
         AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV15TFMicrorregiaoMesoNome;
         AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV16TFMicrorregiaoMesoNome_Sel;
         AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV17TFMicrorregiaoMesoUFSigla;
         AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV18TFMicrorregiaoMesoUFSigla_Sel;
         AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV19TFMicrorregiaoMesoUFRegNome;
         AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV20TFMicrorregiaoMesoUFRegNome_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV46Core_microrregiaowwds_1_filterfulltext ,
                                              AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                              AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                              AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                              AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                              AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                              AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                              AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                              AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                              AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                              AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                              A23MicrorregiaoID ,
                                              A24MicrorregiaoNome ,
                                              A26MicrorregiaoMesoNome ,
                                              A28MicrorregiaoMesoUFSigla ,
                                              A33MicrorregiaoMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV46Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV49Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
         lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
         lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
         lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
         /* Using cursor P005M5 */
         pr_default.execute(3, new Object[] {lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, lV46Core_microrregiaowwds_1_filterfulltext, AV47Core_microrregiaowwds_2_tfmicrorregiaoid, AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV49Core_microrregiaowwds_4_tfmicrorregiaonome, AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK5M8 = false;
            A33MicrorregiaoMesoUFRegNome = P005M5_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P005M5_n33MicrorregiaoMesoUFRegNome[0];
            A23MicrorregiaoID = P005M5_A23MicrorregiaoID[0];
            A28MicrorregiaoMesoUFSigla = P005M5_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P005M5_n28MicrorregiaoMesoUFSigla[0];
            A26MicrorregiaoMesoNome = P005M5_A26MicrorregiaoMesoNome[0];
            A24MicrorregiaoNome = P005M5_A24MicrorregiaoNome[0];
            AV31count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P005M5_A33MicrorregiaoMesoUFRegNome[0], A33MicrorregiaoMesoUFRegNome) == 0 ) )
            {
               BRK5M8 = false;
               A23MicrorregiaoID = P005M5_A23MicrorregiaoID[0];
               AV31count = (long)(AV31count+1);
               BRK5M8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV22SkipItems) )
            {
               AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A33MicrorregiaoMesoUFRegNome)) ? "<#Empty#>" : A33MicrorregiaoMesoUFRegNome);
               AV27Options.Add(AV26Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV27Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV22SkipItems = (short)(AV22SkipItems-1);
            }
            if ( ! BRK5M8 )
            {
               BRK5M8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV13TFMicrorregiaoNome = "";
         AV14TFMicrorregiaoNome_Sel = "";
         AV15TFMicrorregiaoMesoNome = "";
         AV16TFMicrorregiaoMesoNome_Sel = "";
         AV17TFMicrorregiaoMesoUFSigla = "";
         AV18TFMicrorregiaoMesoUFSigla_Sel = "";
         AV19TFMicrorregiaoMesoUFRegNome = "";
         AV20TFMicrorregiaoMesoUFRegNome_Sel = "";
         AV46Core_microrregiaowwds_1_filterfulltext = "";
         AV49Core_microrregiaowwds_4_tfmicrorregiaonome = "";
         AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel = "";
         AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = "";
         AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = "";
         AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = "";
         AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = "";
         AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = "";
         AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = "";
         scmdbuf = "";
         lV46Core_microrregiaowwds_1_filterfulltext = "";
         lV49Core_microrregiaowwds_4_tfmicrorregiaonome = "";
         lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome = "";
         lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = "";
         lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = "";
         A24MicrorregiaoNome = "";
         A26MicrorregiaoMesoNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         P005M2_A24MicrorregiaoNome = new string[] {""} ;
         P005M2_A23MicrorregiaoID = new int[1] ;
         P005M2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P005M2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P005M2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P005M2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P005M2_A26MicrorregiaoMesoNome = new string[] {""} ;
         AV26Option = "";
         P005M3_A25MicrorregiaoMesoID = new int[1] ;
         P005M3_A23MicrorregiaoID = new int[1] ;
         P005M3_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P005M3_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P005M3_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P005M3_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P005M3_A26MicrorregiaoMesoNome = new string[] {""} ;
         P005M3_A24MicrorregiaoNome = new string[] {""} ;
         P005M4_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P005M4_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P005M4_A23MicrorregiaoID = new int[1] ;
         P005M4_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P005M4_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P005M4_A26MicrorregiaoMesoNome = new string[] {""} ;
         P005M4_A24MicrorregiaoNome = new string[] {""} ;
         P005M5_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P005M5_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P005M5_A23MicrorregiaoID = new int[1] ;
         P005M5_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P005M5_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P005M5_A26MicrorregiaoMesoNome = new string[] {""} ;
         P005M5_A24MicrorregiaoNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005M2_A24MicrorregiaoNome, P005M2_A23MicrorregiaoID, P005M2_A33MicrorregiaoMesoUFRegNome, P005M2_n33MicrorregiaoMesoUFRegNome, P005M2_A28MicrorregiaoMesoUFSigla, P005M2_n28MicrorregiaoMesoUFSigla, P005M2_A26MicrorregiaoMesoNome
               }
               , new Object[] {
               P005M3_A25MicrorregiaoMesoID, P005M3_A23MicrorregiaoID, P005M3_A33MicrorregiaoMesoUFRegNome, P005M3_n33MicrorregiaoMesoUFRegNome, P005M3_A28MicrorregiaoMesoUFSigla, P005M3_n28MicrorregiaoMesoUFSigla, P005M3_A26MicrorregiaoMesoNome, P005M3_A24MicrorregiaoNome
               }
               , new Object[] {
               P005M4_A28MicrorregiaoMesoUFSigla, P005M4_n28MicrorregiaoMesoUFSigla, P005M4_A23MicrorregiaoID, P005M4_A33MicrorregiaoMesoUFRegNome, P005M4_n33MicrorregiaoMesoUFRegNome, P005M4_A26MicrorregiaoMesoNome, P005M4_A24MicrorregiaoNome
               }
               , new Object[] {
               P005M5_A33MicrorregiaoMesoUFRegNome, P005M5_n33MicrorregiaoMesoUFRegNome, P005M5_A23MicrorregiaoID, P005M5_A28MicrorregiaoMesoUFSigla, P005M5_n28MicrorregiaoMesoUFSigla, P005M5_A26MicrorregiaoMesoNome, P005M5_A24MicrorregiaoNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private int AV44GXV1 ;
      private int AV11TFMicrorregiaoID ;
      private int AV12TFMicrorregiaoID_To ;
      private int AV47Core_microrregiaowwds_2_tfmicrorregiaoid ;
      private int AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ;
      private int A23MicrorregiaoID ;
      private int A25MicrorregiaoMesoID ;
      private int AV25InsertIndex ;
      private long AV31count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK5M2 ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool BRK5M4 ;
      private bool BRK5M6 ;
      private bool BRK5M8 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV13TFMicrorregiaoNome ;
      private string AV14TFMicrorregiaoNome_Sel ;
      private string AV15TFMicrorregiaoMesoNome ;
      private string AV16TFMicrorregiaoMesoNome_Sel ;
      private string AV17TFMicrorregiaoMesoUFSigla ;
      private string AV18TFMicrorregiaoMesoUFSigla_Sel ;
      private string AV19TFMicrorregiaoMesoUFRegNome ;
      private string AV20TFMicrorregiaoMesoUFRegNome_Sel ;
      private string AV46Core_microrregiaowwds_1_filterfulltext ;
      private string AV49Core_microrregiaowwds_4_tfmicrorregiaonome ;
      private string AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ;
      private string AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ;
      private string AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ;
      private string AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ;
      private string AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ;
      private string AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ;
      private string AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ;
      private string lV46Core_microrregiaowwds_1_filterfulltext ;
      private string lV49Core_microrregiaowwds_4_tfmicrorregiaonome ;
      private string lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ;
      private string lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ;
      private string lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ;
      private string A24MicrorregiaoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005M2_A24MicrorregiaoNome ;
      private int[] P005M2_A23MicrorregiaoID ;
      private string[] P005M2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P005M2_n33MicrorregiaoMesoUFRegNome ;
      private string[] P005M2_A28MicrorregiaoMesoUFSigla ;
      private bool[] P005M2_n28MicrorregiaoMesoUFSigla ;
      private string[] P005M2_A26MicrorregiaoMesoNome ;
      private int[] P005M3_A25MicrorregiaoMesoID ;
      private int[] P005M3_A23MicrorregiaoID ;
      private string[] P005M3_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P005M3_n33MicrorregiaoMesoUFRegNome ;
      private string[] P005M3_A28MicrorregiaoMesoUFSigla ;
      private bool[] P005M3_n28MicrorregiaoMesoUFSigla ;
      private string[] P005M3_A26MicrorregiaoMesoNome ;
      private string[] P005M3_A24MicrorregiaoNome ;
      private string[] P005M4_A28MicrorregiaoMesoUFSigla ;
      private bool[] P005M4_n28MicrorregiaoMesoUFSigla ;
      private int[] P005M4_A23MicrorregiaoID ;
      private string[] P005M4_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P005M4_n33MicrorregiaoMesoUFRegNome ;
      private string[] P005M4_A26MicrorregiaoMesoNome ;
      private string[] P005M4_A24MicrorregiaoNome ;
      private string[] P005M5_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P005M5_n33MicrorregiaoMesoUFRegNome ;
      private int[] P005M5_A23MicrorregiaoID ;
      private string[] P005M5_A28MicrorregiaoMesoUFSigla ;
      private bool[] P005M5_n28MicrorregiaoMesoUFSigla ;
      private string[] P005M5_A26MicrorregiaoMesoNome ;
      private string[] P005M5_A24MicrorregiaoNome ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
   }

   public class microrregiaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005M2( IGxContext context ,
                                             string AV46Core_microrregiaowwds_1_filterfulltext ,
                                             int AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT MicrorregiaoNome, MicrorregiaoID, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSigla, MicrorregiaoMesoNome FROM tbibge_microrregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV47Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV47Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV49Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MicrorregiaoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005M3( IGxContext context ,
                                             string AV46Core_microrregiaowwds_1_filterfulltext ,
                                             int AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MicrorregiaoMesoID, MicrorregiaoID, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSigla, MicrorregiaoMesoNome, MicrorregiaoNome FROM tbibge_microrregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV47Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV47Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV49Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MicrorregiaoMesoID";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005M4( IGxContext context ,
                                             string AV46Core_microrregiaowwds_1_filterfulltext ,
                                             int AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT MicrorregiaoMesoUFSigla, MicrorregiaoID, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoNome, MicrorregiaoNome FROM tbibge_microrregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV47Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV47Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV49Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MicrorregiaoMesoUFSigla";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P005M5( IGxContext context ,
                                             string AV46Core_microrregiaowwds_1_filterfulltext ,
                                             int AV47Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV49Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT MicrorregiaoMesoUFRegNome, MicrorregiaoID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoNome, MicrorregiaoNome FROM tbibge_microrregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV46Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV46Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV47Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV47Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV49Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MicrorregiaoMesoUFRegNome";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005M2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 1 :
                     return conditional_P005M3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 2 :
                     return conditional_P005M4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 3 :
                     return conditional_P005M5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005M2;
          prmP005M2 = new Object[] {
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV47Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV49Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005M3;
          prmP005M3 = new Object[] {
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV47Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV49Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005M4;
          prmP005M4 = new Object[] {
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV47Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV49Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005M5;
          prmP005M5 = new Object[] {
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV47Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV48Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV49Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV50Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV51Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV54Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV55Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV56Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005M5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M5,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
