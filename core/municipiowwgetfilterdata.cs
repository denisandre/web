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
   public class municipiowwgetfilterdata : GXProcedure
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
            return "municipioww_Services_Execute" ;
         }

      }

      public municipiowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipiowwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         municipiowwgetfilterdata objmunicipiowwgetfilterdata;
         objmunicipiowwgetfilterdata = new municipiowwgetfilterdata();
         objmunicipiowwgetfilterdata.AV39DDOName = aP0_DDOName;
         objmunicipiowwgetfilterdata.AV40SearchTxtParms = aP1_SearchTxtParms;
         objmunicipiowwgetfilterdata.AV41SearchTxtTo = aP2_SearchTxtTo;
         objmunicipiowwgetfilterdata.AV42OptionsJson = "" ;
         objmunicipiowwgetfilterdata.AV43OptionsDescJson = "" ;
         objmunicipiowwgetfilterdata.AV44OptionIndexesJson = "" ;
         objmunicipiowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmunicipiowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objmunicipiowwgetfilterdata);
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((municipiowwgetfilterdata)stateInfo).executePrivate();
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
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MUNICIPIONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMUNICIPIONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MUNICIPIOMICRONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMUNICIPIOMICRONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MUNICIPIOMICROMESONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMUNICIPIOMICROMESONOMEOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MUNICIPIOMICROMESOUFSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADMUNICIPIOMICROMESOUFSIGLAOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_MUNICIPIOMICROMESOUFREGNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMUNICIPIOMICROMESOUFREGNOMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("core.municipioWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.municipioWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("core.municipioWWGridState"), null, "", "");
         }
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV46GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOID") == 0 )
            {
               AV11TFMunicipioID = (int)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMunicipioID_To = (int)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIONOME") == 0 )
            {
               AV13TFMunicipioNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIONOME_SEL") == 0 )
            {
               AV14TFMunicipioNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICRONOME") == 0 )
            {
               AV15TFMunicipioMicroNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICRONOME_SEL") == 0 )
            {
               AV16TFMunicipioMicroNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESONOME") == 0 )
            {
               AV17TFMunicipioMicroMesoNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESONOME_SEL") == 0 )
            {
               AV18TFMunicipioMicroMesoNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFSIGLA") == 0 )
            {
               AV19TFMunicipioMicroMesoUFSigla = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFSIGLA_SEL") == 0 )
            {
               AV20TFMunicipioMicroMesoUFSigla_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFREGNOME") == 0 )
            {
               AV21TFMunicipioMicroMesoUFRegNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFREGNOME_SEL") == 0 )
            {
               AV22TFMunicipioMicroMesoUFRegNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMUNICIPIONOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFMunicipioNome = AV23SearchTxt;
         AV14TFMunicipioNome_Sel = "";
         AV48Core_municipiowwds_1_filterfulltext = AV45FilterFullText;
         AV49Core_municipiowwds_2_tfmunicipioid = AV11TFMunicipioID;
         AV50Core_municipiowwds_3_tfmunicipioid_to = AV12TFMunicipioID_To;
         AV51Core_municipiowwds_4_tfmunicipionome = AV13TFMunicipioNome;
         AV52Core_municipiowwds_5_tfmunicipionome_sel = AV14TFMunicipioNome_Sel;
         AV53Core_municipiowwds_6_tfmunicipiomicronome = AV15TFMunicipioMicroNome;
         AV54Core_municipiowwds_7_tfmunicipiomicronome_sel = AV16TFMunicipioMicroNome_Sel;
         AV55Core_municipiowwds_8_tfmunicipiomicromesonome = AV17TFMunicipioMicroMesoNome;
         AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel = AV18TFMunicipioMicroMesoNome_Sel;
         AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = AV19TFMunicipioMicroMesoUFSigla;
         AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = AV20TFMunicipioMicroMesoUFSigla_Sel;
         AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = AV21TFMunicipioMicroMesoUFRegNome;
         AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = AV22TFMunicipioMicroMesoUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Core_municipiowwds_1_filterfulltext ,
                                              AV49Core_municipiowwds_2_tfmunicipioid ,
                                              AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                              AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                              AV51Core_municipiowwds_4_tfmunicipionome ,
                                              AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                              AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                              AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                              AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                              AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                              AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                              AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                              AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                              A35MunicipioID ,
                                              A36MunicipioNome ,
                                              A38MunicipioMicroNome ,
                                              A40MunicipioMicroMesoNome ,
                                              A42MunicipioMicroMesoUFSigla ,
                                              A47MunicipioMicroMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV51Core_municipiowwds_4_tfmunicipionome = StringUtil.Concat( StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome), "%", "");
         lV53Core_municipiowwds_6_tfmunicipiomicronome = StringUtil.Concat( StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome), "%", "");
         lV55Core_municipiowwds_8_tfmunicipiomicromesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome), "%", "");
         lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla), "%", "");
         lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome), "%", "");
         /* Using cursor P005P2 */
         pr_default.execute(0, new Object[] {lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, AV49Core_municipiowwds_2_tfmunicipioid, AV50Core_municipiowwds_3_tfmunicipioid_to, lV51Core_municipiowwds_4_tfmunicipionome, AV52Core_municipiowwds_5_tfmunicipionome_sel, lV53Core_municipiowwds_6_tfmunicipiomicronome, AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, lV55Core_municipiowwds_8_tfmunicipiomicromesonome, AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla, AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome, AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5P2 = false;
            A36MunicipioNome = P005P2_A36MunicipioNome[0];
            A35MunicipioID = P005P2_A35MunicipioID[0];
            A47MunicipioMicroMesoUFRegNome = P005P2_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P005P2_n47MunicipioMicroMesoUFRegNome[0];
            A42MunicipioMicroMesoUFSigla = P005P2_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P005P2_n42MunicipioMicroMesoUFSigla[0];
            A40MunicipioMicroMesoNome = P005P2_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P005P2_n40MunicipioMicroMesoNome[0];
            A38MunicipioMicroNome = P005P2_A38MunicipioMicroNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005P2_A36MunicipioNome[0], A36MunicipioNome) == 0 ) )
            {
               BRK5P2 = false;
               A35MunicipioID = P005P2_A35MunicipioID[0];
               AV33count = (long)(AV33count+1);
               BRK5P2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A36MunicipioNome)) ? "<#Empty#>" : A36MunicipioNome);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK5P2 )
            {
               BRK5P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMUNICIPIOMICRONOMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFMunicipioMicroNome = AV23SearchTxt;
         AV16TFMunicipioMicroNome_Sel = "";
         AV48Core_municipiowwds_1_filterfulltext = AV45FilterFullText;
         AV49Core_municipiowwds_2_tfmunicipioid = AV11TFMunicipioID;
         AV50Core_municipiowwds_3_tfmunicipioid_to = AV12TFMunicipioID_To;
         AV51Core_municipiowwds_4_tfmunicipionome = AV13TFMunicipioNome;
         AV52Core_municipiowwds_5_tfmunicipionome_sel = AV14TFMunicipioNome_Sel;
         AV53Core_municipiowwds_6_tfmunicipiomicronome = AV15TFMunicipioMicroNome;
         AV54Core_municipiowwds_7_tfmunicipiomicronome_sel = AV16TFMunicipioMicroNome_Sel;
         AV55Core_municipiowwds_8_tfmunicipiomicromesonome = AV17TFMunicipioMicroMesoNome;
         AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel = AV18TFMunicipioMicroMesoNome_Sel;
         AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = AV19TFMunicipioMicroMesoUFSigla;
         AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = AV20TFMunicipioMicroMesoUFSigla_Sel;
         AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = AV21TFMunicipioMicroMesoUFRegNome;
         AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = AV22TFMunicipioMicroMesoUFRegNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Core_municipiowwds_1_filterfulltext ,
                                              AV49Core_municipiowwds_2_tfmunicipioid ,
                                              AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                              AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                              AV51Core_municipiowwds_4_tfmunicipionome ,
                                              AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                              AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                              AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                              AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                              AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                              AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                              AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                              AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                              A35MunicipioID ,
                                              A36MunicipioNome ,
                                              A38MunicipioMicroNome ,
                                              A40MunicipioMicroMesoNome ,
                                              A42MunicipioMicroMesoUFSigla ,
                                              A47MunicipioMicroMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV51Core_municipiowwds_4_tfmunicipionome = StringUtil.Concat( StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome), "%", "");
         lV53Core_municipiowwds_6_tfmunicipiomicronome = StringUtil.Concat( StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome), "%", "");
         lV55Core_municipiowwds_8_tfmunicipiomicromesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome), "%", "");
         lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla), "%", "");
         lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome), "%", "");
         /* Using cursor P005P3 */
         pr_default.execute(1, new Object[] {lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, AV49Core_municipiowwds_2_tfmunicipioid, AV50Core_municipiowwds_3_tfmunicipioid_to, lV51Core_municipiowwds_4_tfmunicipionome, AV52Core_municipiowwds_5_tfmunicipionome_sel, lV53Core_municipiowwds_6_tfmunicipiomicronome, AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, lV55Core_municipiowwds_8_tfmunicipiomicromesonome, AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla, AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome, AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5P4 = false;
            A37MunicipioMicroID = P005P3_A37MunicipioMicroID[0];
            A35MunicipioID = P005P3_A35MunicipioID[0];
            A47MunicipioMicroMesoUFRegNome = P005P3_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P005P3_n47MunicipioMicroMesoUFRegNome[0];
            A42MunicipioMicroMesoUFSigla = P005P3_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P005P3_n42MunicipioMicroMesoUFSigla[0];
            A40MunicipioMicroMesoNome = P005P3_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P005P3_n40MunicipioMicroMesoNome[0];
            A38MunicipioMicroNome = P005P3_A38MunicipioMicroNome[0];
            A36MunicipioNome = P005P3_A36MunicipioNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P005P3_A37MunicipioMicroID[0] == A37MunicipioMicroID ) )
            {
               BRK5P4 = false;
               A35MunicipioID = P005P3_A35MunicipioID[0];
               AV33count = (long)(AV33count+1);
               BRK5P4 = true;
               pr_default.readNext(1);
            }
            AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A38MunicipioMicroNome)) ? "<#Empty#>" : A38MunicipioMicroNome);
            AV27InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV28Option, "<#Empty#>") != 0 ) && ( AV27InsertIndex <= AV29Options.Count ) && ( ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), AV28Option) < 0 ) || ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV29Options.Add(AV28Option, AV27InsertIndex);
            AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), AV27InsertIndex);
            if ( AV29Options.Count == AV24SkipItems + 11 )
            {
               AV29Options.RemoveItem(AV29Options.Count);
               AV32OptionIndexes.RemoveItem(AV32OptionIndexes.Count);
            }
            if ( ! BRK5P4 )
            {
               BRK5P4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV24SkipItems > 0 )
         {
            AV29Options.RemoveItem(1);
            AV32OptionIndexes.RemoveItem(1);
            AV24SkipItems = (short)(AV24SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADMUNICIPIOMICROMESONOMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFMunicipioMicroMesoNome = AV23SearchTxt;
         AV18TFMunicipioMicroMesoNome_Sel = "";
         AV48Core_municipiowwds_1_filterfulltext = AV45FilterFullText;
         AV49Core_municipiowwds_2_tfmunicipioid = AV11TFMunicipioID;
         AV50Core_municipiowwds_3_tfmunicipioid_to = AV12TFMunicipioID_To;
         AV51Core_municipiowwds_4_tfmunicipionome = AV13TFMunicipioNome;
         AV52Core_municipiowwds_5_tfmunicipionome_sel = AV14TFMunicipioNome_Sel;
         AV53Core_municipiowwds_6_tfmunicipiomicronome = AV15TFMunicipioMicroNome;
         AV54Core_municipiowwds_7_tfmunicipiomicronome_sel = AV16TFMunicipioMicroNome_Sel;
         AV55Core_municipiowwds_8_tfmunicipiomicromesonome = AV17TFMunicipioMicroMesoNome;
         AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel = AV18TFMunicipioMicroMesoNome_Sel;
         AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = AV19TFMunicipioMicroMesoUFSigla;
         AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = AV20TFMunicipioMicroMesoUFSigla_Sel;
         AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = AV21TFMunicipioMicroMesoUFRegNome;
         AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = AV22TFMunicipioMicroMesoUFRegNome_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV48Core_municipiowwds_1_filterfulltext ,
                                              AV49Core_municipiowwds_2_tfmunicipioid ,
                                              AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                              AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                              AV51Core_municipiowwds_4_tfmunicipionome ,
                                              AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                              AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                              AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                              AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                              AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                              AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                              AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                              AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                              A35MunicipioID ,
                                              A36MunicipioNome ,
                                              A38MunicipioMicroNome ,
                                              A40MunicipioMicroMesoNome ,
                                              A42MunicipioMicroMesoUFSigla ,
                                              A47MunicipioMicroMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV51Core_municipiowwds_4_tfmunicipionome = StringUtil.Concat( StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome), "%", "");
         lV53Core_municipiowwds_6_tfmunicipiomicronome = StringUtil.Concat( StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome), "%", "");
         lV55Core_municipiowwds_8_tfmunicipiomicromesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome), "%", "");
         lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla), "%", "");
         lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome), "%", "");
         /* Using cursor P005P4 */
         pr_default.execute(2, new Object[] {lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, AV49Core_municipiowwds_2_tfmunicipioid, AV50Core_municipiowwds_3_tfmunicipioid_to, lV51Core_municipiowwds_4_tfmunicipionome, AV52Core_municipiowwds_5_tfmunicipionome_sel, lV53Core_municipiowwds_6_tfmunicipiomicronome, AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, lV55Core_municipiowwds_8_tfmunicipiomicromesonome, AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla, AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome, AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5P6 = false;
            A40MunicipioMicroMesoNome = P005P4_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P005P4_n40MunicipioMicroMesoNome[0];
            A35MunicipioID = P005P4_A35MunicipioID[0];
            A47MunicipioMicroMesoUFRegNome = P005P4_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P005P4_n47MunicipioMicroMesoUFRegNome[0];
            A42MunicipioMicroMesoUFSigla = P005P4_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P005P4_n42MunicipioMicroMesoUFSigla[0];
            A38MunicipioMicroNome = P005P4_A38MunicipioMicroNome[0];
            A36MunicipioNome = P005P4_A36MunicipioNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005P4_A40MunicipioMicroMesoNome[0], A40MunicipioMicroMesoNome) == 0 ) )
            {
               BRK5P6 = false;
               A35MunicipioID = P005P4_A35MunicipioID[0];
               AV33count = (long)(AV33count+1);
               BRK5P6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A40MunicipioMicroMesoNome)) ? "<#Empty#>" : A40MunicipioMicroMesoNome);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK5P6 )
            {
               BRK5P6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADMUNICIPIOMICROMESOUFSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV19TFMunicipioMicroMesoUFSigla = AV23SearchTxt;
         AV20TFMunicipioMicroMesoUFSigla_Sel = "";
         AV48Core_municipiowwds_1_filterfulltext = AV45FilterFullText;
         AV49Core_municipiowwds_2_tfmunicipioid = AV11TFMunicipioID;
         AV50Core_municipiowwds_3_tfmunicipioid_to = AV12TFMunicipioID_To;
         AV51Core_municipiowwds_4_tfmunicipionome = AV13TFMunicipioNome;
         AV52Core_municipiowwds_5_tfmunicipionome_sel = AV14TFMunicipioNome_Sel;
         AV53Core_municipiowwds_6_tfmunicipiomicronome = AV15TFMunicipioMicroNome;
         AV54Core_municipiowwds_7_tfmunicipiomicronome_sel = AV16TFMunicipioMicroNome_Sel;
         AV55Core_municipiowwds_8_tfmunicipiomicromesonome = AV17TFMunicipioMicroMesoNome;
         AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel = AV18TFMunicipioMicroMesoNome_Sel;
         AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = AV19TFMunicipioMicroMesoUFSigla;
         AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = AV20TFMunicipioMicroMesoUFSigla_Sel;
         AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = AV21TFMunicipioMicroMesoUFRegNome;
         AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = AV22TFMunicipioMicroMesoUFRegNome_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV48Core_municipiowwds_1_filterfulltext ,
                                              AV49Core_municipiowwds_2_tfmunicipioid ,
                                              AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                              AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                              AV51Core_municipiowwds_4_tfmunicipionome ,
                                              AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                              AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                              AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                              AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                              AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                              AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                              AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                              AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                              A35MunicipioID ,
                                              A36MunicipioNome ,
                                              A38MunicipioMicroNome ,
                                              A40MunicipioMicroMesoNome ,
                                              A42MunicipioMicroMesoUFSigla ,
                                              A47MunicipioMicroMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV51Core_municipiowwds_4_tfmunicipionome = StringUtil.Concat( StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome), "%", "");
         lV53Core_municipiowwds_6_tfmunicipiomicronome = StringUtil.Concat( StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome), "%", "");
         lV55Core_municipiowwds_8_tfmunicipiomicromesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome), "%", "");
         lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla), "%", "");
         lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome), "%", "");
         /* Using cursor P005P5 */
         pr_default.execute(3, new Object[] {lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, AV49Core_municipiowwds_2_tfmunicipioid, AV50Core_municipiowwds_3_tfmunicipioid_to, lV51Core_municipiowwds_4_tfmunicipionome, AV52Core_municipiowwds_5_tfmunicipionome_sel, lV53Core_municipiowwds_6_tfmunicipiomicronome, AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, lV55Core_municipiowwds_8_tfmunicipiomicromesonome, AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla, AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome, AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK5P8 = false;
            A42MunicipioMicroMesoUFSigla = P005P5_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P005P5_n42MunicipioMicroMesoUFSigla[0];
            A35MunicipioID = P005P5_A35MunicipioID[0];
            A47MunicipioMicroMesoUFRegNome = P005P5_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P005P5_n47MunicipioMicroMesoUFRegNome[0];
            A40MunicipioMicroMesoNome = P005P5_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P005P5_n40MunicipioMicroMesoNome[0];
            A38MunicipioMicroNome = P005P5_A38MunicipioMicroNome[0];
            A36MunicipioNome = P005P5_A36MunicipioNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P005P5_A42MunicipioMicroMesoUFSigla[0], A42MunicipioMicroMesoUFSigla) == 0 ) )
            {
               BRK5P8 = false;
               A35MunicipioID = P005P5_A35MunicipioID[0];
               AV33count = (long)(AV33count+1);
               BRK5P8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A42MunicipioMicroMesoUFSigla)) ? "<#Empty#>" : A42MunicipioMicroMesoUFSigla);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK5P8 )
            {
               BRK5P8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADMUNICIPIOMICROMESOUFREGNOMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFMunicipioMicroMesoUFRegNome = AV23SearchTxt;
         AV22TFMunicipioMicroMesoUFRegNome_Sel = "";
         AV48Core_municipiowwds_1_filterfulltext = AV45FilterFullText;
         AV49Core_municipiowwds_2_tfmunicipioid = AV11TFMunicipioID;
         AV50Core_municipiowwds_3_tfmunicipioid_to = AV12TFMunicipioID_To;
         AV51Core_municipiowwds_4_tfmunicipionome = AV13TFMunicipioNome;
         AV52Core_municipiowwds_5_tfmunicipionome_sel = AV14TFMunicipioNome_Sel;
         AV53Core_municipiowwds_6_tfmunicipiomicronome = AV15TFMunicipioMicroNome;
         AV54Core_municipiowwds_7_tfmunicipiomicronome_sel = AV16TFMunicipioMicroNome_Sel;
         AV55Core_municipiowwds_8_tfmunicipiomicromesonome = AV17TFMunicipioMicroMesoNome;
         AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel = AV18TFMunicipioMicroMesoNome_Sel;
         AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = AV19TFMunicipioMicroMesoUFSigla;
         AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = AV20TFMunicipioMicroMesoUFSigla_Sel;
         AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = AV21TFMunicipioMicroMesoUFRegNome;
         AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = AV22TFMunicipioMicroMesoUFRegNome_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV48Core_municipiowwds_1_filterfulltext ,
                                              AV49Core_municipiowwds_2_tfmunicipioid ,
                                              AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                              AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                              AV51Core_municipiowwds_4_tfmunicipionome ,
                                              AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                              AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                              AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                              AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                              AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                              AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                              AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                              AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                              A35MunicipioID ,
                                              A36MunicipioNome ,
                                              A38MunicipioMicroNome ,
                                              A40MunicipioMicroMesoNome ,
                                              A42MunicipioMicroMesoUFSigla ,
                                              A47MunicipioMicroMesoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV48Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext), "%", "");
         lV51Core_municipiowwds_4_tfmunicipionome = StringUtil.Concat( StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome), "%", "");
         lV53Core_municipiowwds_6_tfmunicipiomicronome = StringUtil.Concat( StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome), "%", "");
         lV55Core_municipiowwds_8_tfmunicipiomicromesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome), "%", "");
         lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla), "%", "");
         lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome), "%", "");
         /* Using cursor P005P6 */
         pr_default.execute(4, new Object[] {lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, lV48Core_municipiowwds_1_filterfulltext, AV49Core_municipiowwds_2_tfmunicipioid, AV50Core_municipiowwds_3_tfmunicipioid_to, lV51Core_municipiowwds_4_tfmunicipionome, AV52Core_municipiowwds_5_tfmunicipionome_sel, lV53Core_municipiowwds_6_tfmunicipiomicronome, AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, lV55Core_municipiowwds_8_tfmunicipiomicromesonome, AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla, AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome, AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK5P10 = false;
            A47MunicipioMicroMesoUFRegNome = P005P6_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P005P6_n47MunicipioMicroMesoUFRegNome[0];
            A35MunicipioID = P005P6_A35MunicipioID[0];
            A42MunicipioMicroMesoUFSigla = P005P6_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P005P6_n42MunicipioMicroMesoUFSigla[0];
            A40MunicipioMicroMesoNome = P005P6_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P005P6_n40MunicipioMicroMesoNome[0];
            A38MunicipioMicroNome = P005P6_A38MunicipioMicroNome[0];
            A36MunicipioNome = P005P6_A36MunicipioNome[0];
            AV33count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P005P6_A47MunicipioMicroMesoUFRegNome[0], A47MunicipioMicroMesoUFRegNome) == 0 ) )
            {
               BRK5P10 = false;
               A35MunicipioID = P005P6_A35MunicipioID[0];
               AV33count = (long)(AV33count+1);
               BRK5P10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A47MunicipioMicroMesoUFRegNome)) ? "<#Empty#>" : A47MunicipioMicroMesoUFRegNome);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK5P10 )
            {
               BRK5P10 = true;
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV13TFMunicipioNome = "";
         AV14TFMunicipioNome_Sel = "";
         AV15TFMunicipioMicroNome = "";
         AV16TFMunicipioMicroNome_Sel = "";
         AV17TFMunicipioMicroMesoNome = "";
         AV18TFMunicipioMicroMesoNome_Sel = "";
         AV19TFMunicipioMicroMesoUFSigla = "";
         AV20TFMunicipioMicroMesoUFSigla_Sel = "";
         AV21TFMunicipioMicroMesoUFRegNome = "";
         AV22TFMunicipioMicroMesoUFRegNome_Sel = "";
         AV48Core_municipiowwds_1_filterfulltext = "";
         AV51Core_municipiowwds_4_tfmunicipionome = "";
         AV52Core_municipiowwds_5_tfmunicipionome_sel = "";
         AV53Core_municipiowwds_6_tfmunicipiomicronome = "";
         AV54Core_municipiowwds_7_tfmunicipiomicronome_sel = "";
         AV55Core_municipiowwds_8_tfmunicipiomicromesonome = "";
         AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel = "";
         AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = "";
         AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = "";
         AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = "";
         AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = "";
         scmdbuf = "";
         lV48Core_municipiowwds_1_filterfulltext = "";
         lV51Core_municipiowwds_4_tfmunicipionome = "";
         lV53Core_municipiowwds_6_tfmunicipiomicronome = "";
         lV55Core_municipiowwds_8_tfmunicipiomicromesonome = "";
         lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla = "";
         lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome = "";
         A36MunicipioNome = "";
         A38MunicipioMicroNome = "";
         A40MunicipioMicroMesoNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A47MunicipioMicroMesoUFRegNome = "";
         P005P2_A36MunicipioNome = new string[] {""} ;
         P005P2_A35MunicipioID = new int[1] ;
         P005P2_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P005P2_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P005P2_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P005P2_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P005P2_A40MunicipioMicroMesoNome = new string[] {""} ;
         P005P2_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P005P2_A38MunicipioMicroNome = new string[] {""} ;
         AV28Option = "";
         P005P3_A37MunicipioMicroID = new int[1] ;
         P005P3_A35MunicipioID = new int[1] ;
         P005P3_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P005P3_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P005P3_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P005P3_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P005P3_A40MunicipioMicroMesoNome = new string[] {""} ;
         P005P3_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P005P3_A38MunicipioMicroNome = new string[] {""} ;
         P005P3_A36MunicipioNome = new string[] {""} ;
         P005P4_A40MunicipioMicroMesoNome = new string[] {""} ;
         P005P4_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P005P4_A35MunicipioID = new int[1] ;
         P005P4_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P005P4_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P005P4_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P005P4_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P005P4_A38MunicipioMicroNome = new string[] {""} ;
         P005P4_A36MunicipioNome = new string[] {""} ;
         P005P5_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P005P5_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P005P5_A35MunicipioID = new int[1] ;
         P005P5_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P005P5_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P005P5_A40MunicipioMicroMesoNome = new string[] {""} ;
         P005P5_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P005P5_A38MunicipioMicroNome = new string[] {""} ;
         P005P5_A36MunicipioNome = new string[] {""} ;
         P005P6_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P005P6_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P005P6_A35MunicipioID = new int[1] ;
         P005P6_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P005P6_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P005P6_A40MunicipioMicroMesoNome = new string[] {""} ;
         P005P6_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P005P6_A38MunicipioMicroNome = new string[] {""} ;
         P005P6_A36MunicipioNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.municipiowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005P2_A36MunicipioNome, P005P2_A35MunicipioID, P005P2_A47MunicipioMicroMesoUFRegNome, P005P2_n47MunicipioMicroMesoUFRegNome, P005P2_A42MunicipioMicroMesoUFSigla, P005P2_n42MunicipioMicroMesoUFSigla, P005P2_A40MunicipioMicroMesoNome, P005P2_n40MunicipioMicroMesoNome, P005P2_A38MunicipioMicroNome
               }
               , new Object[] {
               P005P3_A37MunicipioMicroID, P005P3_A35MunicipioID, P005P3_A47MunicipioMicroMesoUFRegNome, P005P3_n47MunicipioMicroMesoUFRegNome, P005P3_A42MunicipioMicroMesoUFSigla, P005P3_n42MunicipioMicroMesoUFSigla, P005P3_A40MunicipioMicroMesoNome, P005P3_n40MunicipioMicroMesoNome, P005P3_A38MunicipioMicroNome, P005P3_A36MunicipioNome
               }
               , new Object[] {
               P005P4_A40MunicipioMicroMesoNome, P005P4_n40MunicipioMicroMesoNome, P005P4_A35MunicipioID, P005P4_A47MunicipioMicroMesoUFRegNome, P005P4_n47MunicipioMicroMesoUFRegNome, P005P4_A42MunicipioMicroMesoUFSigla, P005P4_n42MunicipioMicroMesoUFSigla, P005P4_A38MunicipioMicroNome, P005P4_A36MunicipioNome
               }
               , new Object[] {
               P005P5_A42MunicipioMicroMesoUFSigla, P005P5_n42MunicipioMicroMesoUFSigla, P005P5_A35MunicipioID, P005P5_A47MunicipioMicroMesoUFRegNome, P005P5_n47MunicipioMicroMesoUFRegNome, P005P5_A40MunicipioMicroMesoNome, P005P5_n40MunicipioMicroMesoNome, P005P5_A38MunicipioMicroNome, P005P5_A36MunicipioNome
               }
               , new Object[] {
               P005P6_A47MunicipioMicroMesoUFRegNome, P005P6_n47MunicipioMicroMesoUFRegNome, P005P6_A35MunicipioID, P005P6_A42MunicipioMicroMesoUFSigla, P005P6_n42MunicipioMicroMesoUFSigla, P005P6_A40MunicipioMicroMesoNome, P005P6_n40MunicipioMicroMesoNome, P005P6_A38MunicipioMicroNome, P005P6_A36MunicipioNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private int AV46GXV1 ;
      private int AV11TFMunicipioID ;
      private int AV12TFMunicipioID_To ;
      private int AV49Core_municipiowwds_2_tfmunicipioid ;
      private int AV50Core_municipiowwds_3_tfmunicipioid_to ;
      private int A35MunicipioID ;
      private int A37MunicipioMicroID ;
      private int AV27InsertIndex ;
      private long AV33count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK5P2 ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n40MunicipioMicroMesoNome ;
      private bool BRK5P4 ;
      private bool BRK5P6 ;
      private bool BRK5P8 ;
      private bool BRK5P10 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV13TFMunicipioNome ;
      private string AV14TFMunicipioNome_Sel ;
      private string AV15TFMunicipioMicroNome ;
      private string AV16TFMunicipioMicroNome_Sel ;
      private string AV17TFMunicipioMicroMesoNome ;
      private string AV18TFMunicipioMicroMesoNome_Sel ;
      private string AV19TFMunicipioMicroMesoUFSigla ;
      private string AV20TFMunicipioMicroMesoUFSigla_Sel ;
      private string AV21TFMunicipioMicroMesoUFRegNome ;
      private string AV22TFMunicipioMicroMesoUFRegNome_Sel ;
      private string AV48Core_municipiowwds_1_filterfulltext ;
      private string AV51Core_municipiowwds_4_tfmunicipionome ;
      private string AV52Core_municipiowwds_5_tfmunicipionome_sel ;
      private string AV53Core_municipiowwds_6_tfmunicipiomicronome ;
      private string AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ;
      private string AV55Core_municipiowwds_8_tfmunicipiomicromesonome ;
      private string AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ;
      private string AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ;
      private string AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ;
      private string AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ;
      private string AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ;
      private string lV48Core_municipiowwds_1_filterfulltext ;
      private string lV51Core_municipiowwds_4_tfmunicipionome ;
      private string lV53Core_municipiowwds_6_tfmunicipiomicronome ;
      private string lV55Core_municipiowwds_8_tfmunicipiomicromesonome ;
      private string lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ;
      private string lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ;
      private string A36MunicipioNome ;
      private string A38MunicipioMicroNome ;
      private string A40MunicipioMicroMesoNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005P2_A36MunicipioNome ;
      private int[] P005P2_A35MunicipioID ;
      private string[] P005P2_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P005P2_n47MunicipioMicroMesoUFRegNome ;
      private string[] P005P2_A42MunicipioMicroMesoUFSigla ;
      private bool[] P005P2_n42MunicipioMicroMesoUFSigla ;
      private string[] P005P2_A40MunicipioMicroMesoNome ;
      private bool[] P005P2_n40MunicipioMicroMesoNome ;
      private string[] P005P2_A38MunicipioMicroNome ;
      private int[] P005P3_A37MunicipioMicroID ;
      private int[] P005P3_A35MunicipioID ;
      private string[] P005P3_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P005P3_n47MunicipioMicroMesoUFRegNome ;
      private string[] P005P3_A42MunicipioMicroMesoUFSigla ;
      private bool[] P005P3_n42MunicipioMicroMesoUFSigla ;
      private string[] P005P3_A40MunicipioMicroMesoNome ;
      private bool[] P005P3_n40MunicipioMicroMesoNome ;
      private string[] P005P3_A38MunicipioMicroNome ;
      private string[] P005P3_A36MunicipioNome ;
      private string[] P005P4_A40MunicipioMicroMesoNome ;
      private bool[] P005P4_n40MunicipioMicroMesoNome ;
      private int[] P005P4_A35MunicipioID ;
      private string[] P005P4_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P005P4_n47MunicipioMicroMesoUFRegNome ;
      private string[] P005P4_A42MunicipioMicroMesoUFSigla ;
      private bool[] P005P4_n42MunicipioMicroMesoUFSigla ;
      private string[] P005P4_A38MunicipioMicroNome ;
      private string[] P005P4_A36MunicipioNome ;
      private string[] P005P5_A42MunicipioMicroMesoUFSigla ;
      private bool[] P005P5_n42MunicipioMicroMesoUFSigla ;
      private int[] P005P5_A35MunicipioID ;
      private string[] P005P5_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P005P5_n47MunicipioMicroMesoUFRegNome ;
      private string[] P005P5_A40MunicipioMicroMesoNome ;
      private bool[] P005P5_n40MunicipioMicroMesoNome ;
      private string[] P005P5_A38MunicipioMicroNome ;
      private string[] P005P5_A36MunicipioNome ;
      private string[] P005P6_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P005P6_n47MunicipioMicroMesoUFRegNome ;
      private int[] P005P6_A35MunicipioID ;
      private string[] P005P6_A42MunicipioMicroMesoUFSigla ;
      private bool[] P005P6_n42MunicipioMicroMesoUFSigla ;
      private string[] P005P6_A40MunicipioMicroMesoNome ;
      private bool[] P005P6_n40MunicipioMicroMesoNome ;
      private string[] P005P6_A38MunicipioMicroNome ;
      private string[] P005P6_A36MunicipioNome ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
   }

   public class municipiowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005P2( IGxContext context ,
                                             string AV48Core_municipiowwds_1_filterfulltext ,
                                             int AV49Core_municipiowwds_2_tfmunicipioid ,
                                             int AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                             string AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                             string AV51Core_municipiowwds_4_tfmunicipionome ,
                                             string AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                             string AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                             string AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                             string AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                             string AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                             string AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                             string AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                             string AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                             int A35MunicipioID ,
                                             string A36MunicipioNome ,
                                             string A38MunicipioMicroNome ,
                                             string A40MunicipioMicroMesoNome ,
                                             string A42MunicipioMicroMesoUFSigla ,
                                             string A47MunicipioMicroMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT MunicipioNome, MunicipioID, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSigla, MunicipioMicroMesoNome, MunicipioMicroNome FROM tbibge_municipio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MunicipioID,'999999999'), 2) like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFSigla like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFRegNome like '%' || :lV48Core_municipiowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV49Core_municipiowwds_2_tfmunicipioid) )
         {
            AddWhere(sWhereString, "(MunicipioID >= :AV49Core_municipiowwds_2_tfmunicipioid)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV50Core_municipiowwds_3_tfmunicipioid_to) )
         {
            AddWhere(sWhereString, "(MunicipioID <= :AV50Core_municipiowwds_3_tfmunicipioid_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioNome like :lV51Core_municipiowwds_4_tfmunicipionome)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ! ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioNome = ( :AV52Core_municipiowwds_5_tfmunicipionome_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome like :lV53Core_municipiowwds_6_tfmunicipiomicronome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ! ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome = ( :AV54Core_municipiowwds_7_tfmunicipiomicronome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome like :lV55Core_municipiowwds_8_tfmunicipiomicromesonome)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome = ( :AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla like :lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla = ( :AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome like :lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome = ( :AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MunicipioNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005P3( IGxContext context ,
                                             string AV48Core_municipiowwds_1_filterfulltext ,
                                             int AV49Core_municipiowwds_2_tfmunicipioid ,
                                             int AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                             string AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                             string AV51Core_municipiowwds_4_tfmunicipionome ,
                                             string AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                             string AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                             string AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                             string AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                             string AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                             string AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                             string AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                             string AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                             int A35MunicipioID ,
                                             string A36MunicipioNome ,
                                             string A38MunicipioMicroNome ,
                                             string A40MunicipioMicroMesoNome ,
                                             string A42MunicipioMicroMesoUFSigla ,
                                             string A47MunicipioMicroMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MunicipioMicroID, MunicipioID, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSigla, MunicipioMicroMesoNome, MunicipioMicroNome, MunicipioNome FROM tbibge_municipio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MunicipioID,'999999999'), 2) like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFSigla like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFRegNome like '%' || :lV48Core_municipiowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV49Core_municipiowwds_2_tfmunicipioid) )
         {
            AddWhere(sWhereString, "(MunicipioID >= :AV49Core_municipiowwds_2_tfmunicipioid)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV50Core_municipiowwds_3_tfmunicipioid_to) )
         {
            AddWhere(sWhereString, "(MunicipioID <= :AV50Core_municipiowwds_3_tfmunicipioid_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioNome like :lV51Core_municipiowwds_4_tfmunicipionome)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ! ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioNome = ( :AV52Core_municipiowwds_5_tfmunicipionome_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome like :lV53Core_municipiowwds_6_tfmunicipiomicronome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ! ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome = ( :AV54Core_municipiowwds_7_tfmunicipiomicronome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome like :lV55Core_municipiowwds_8_tfmunicipiomicromesonome)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome = ( :AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla like :lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla = ( :AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome like :lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome = ( :AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MunicipioMicroID";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005P4( IGxContext context ,
                                             string AV48Core_municipiowwds_1_filterfulltext ,
                                             int AV49Core_municipiowwds_2_tfmunicipioid ,
                                             int AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                             string AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                             string AV51Core_municipiowwds_4_tfmunicipionome ,
                                             string AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                             string AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                             string AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                             string AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                             string AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                             string AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                             string AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                             string AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                             int A35MunicipioID ,
                                             string A36MunicipioNome ,
                                             string A38MunicipioMicroNome ,
                                             string A40MunicipioMicroMesoNome ,
                                             string A42MunicipioMicroMesoUFSigla ,
                                             string A47MunicipioMicroMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT MunicipioMicroMesoNome, MunicipioID, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSigla, MunicipioMicroNome, MunicipioNome FROM tbibge_municipio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MunicipioID,'999999999'), 2) like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFSigla like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFRegNome like '%' || :lV48Core_municipiowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV49Core_municipiowwds_2_tfmunicipioid) )
         {
            AddWhere(sWhereString, "(MunicipioID >= :AV49Core_municipiowwds_2_tfmunicipioid)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV50Core_municipiowwds_3_tfmunicipioid_to) )
         {
            AddWhere(sWhereString, "(MunicipioID <= :AV50Core_municipiowwds_3_tfmunicipioid_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioNome like :lV51Core_municipiowwds_4_tfmunicipionome)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ! ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioNome = ( :AV52Core_municipiowwds_5_tfmunicipionome_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome like :lV53Core_municipiowwds_6_tfmunicipiomicronome)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ! ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome = ( :AV54Core_municipiowwds_7_tfmunicipiomicronome_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome like :lV55Core_municipiowwds_8_tfmunicipiomicromesonome)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome = ( :AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla like :lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla = ( :AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome like :lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome = ( :AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MunicipioMicroMesoNome";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P005P5( IGxContext context ,
                                             string AV48Core_municipiowwds_1_filterfulltext ,
                                             int AV49Core_municipiowwds_2_tfmunicipioid ,
                                             int AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                             string AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                             string AV51Core_municipiowwds_4_tfmunicipionome ,
                                             string AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                             string AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                             string AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                             string AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                             string AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                             string AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                             string AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                             string AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                             int A35MunicipioID ,
                                             string A36MunicipioNome ,
                                             string A38MunicipioMicroNome ,
                                             string A40MunicipioMicroMesoNome ,
                                             string A42MunicipioMicroMesoUFSigla ,
                                             string A47MunicipioMicroMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT MunicipioMicroMesoUFSigla, MunicipioID, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoNome, MunicipioMicroNome, MunicipioNome FROM tbibge_municipio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MunicipioID,'999999999'), 2) like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFSigla like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFRegNome like '%' || :lV48Core_municipiowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV49Core_municipiowwds_2_tfmunicipioid) )
         {
            AddWhere(sWhereString, "(MunicipioID >= :AV49Core_municipiowwds_2_tfmunicipioid)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV50Core_municipiowwds_3_tfmunicipioid_to) )
         {
            AddWhere(sWhereString, "(MunicipioID <= :AV50Core_municipiowwds_3_tfmunicipioid_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioNome like :lV51Core_municipiowwds_4_tfmunicipionome)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ! ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioNome = ( :AV52Core_municipiowwds_5_tfmunicipionome_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome like :lV53Core_municipiowwds_6_tfmunicipiomicronome)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ! ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome = ( :AV54Core_municipiowwds_7_tfmunicipiomicronome_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome like :lV55Core_municipiowwds_8_tfmunicipiomicromesonome)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome = ( :AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla like :lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla = ( :AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome like :lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome = ( :AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MunicipioMicroMesoUFSigla";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P005P6( IGxContext context ,
                                             string AV48Core_municipiowwds_1_filterfulltext ,
                                             int AV49Core_municipiowwds_2_tfmunicipioid ,
                                             int AV50Core_municipiowwds_3_tfmunicipioid_to ,
                                             string AV52Core_municipiowwds_5_tfmunicipionome_sel ,
                                             string AV51Core_municipiowwds_4_tfmunicipionome ,
                                             string AV54Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                             string AV53Core_municipiowwds_6_tfmunicipiomicronome ,
                                             string AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                             string AV55Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                             string AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                             string AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                             string AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                             string AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                             int A35MunicipioID ,
                                             string A36MunicipioNome ,
                                             string A38MunicipioMicroNome ,
                                             string A40MunicipioMicroMesoNome ,
                                             string A42MunicipioMicroMesoUFSigla ,
                                             string A47MunicipioMicroMesoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT MunicipioMicroMesoUFRegNome, MunicipioID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoNome, MunicipioMicroNome, MunicipioNome FROM tbibge_municipio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_municipiowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MunicipioID,'999999999'), 2) like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoNome like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFSigla like '%' || :lV48Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFRegNome like '%' || :lV48Core_municipiowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV49Core_municipiowwds_2_tfmunicipioid) )
         {
            AddWhere(sWhereString, "(MunicipioID >= :AV49Core_municipiowwds_2_tfmunicipioid)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV50Core_municipiowwds_3_tfmunicipioid_to) )
         {
            AddWhere(sWhereString, "(MunicipioID <= :AV50Core_municipiowwds_3_tfmunicipioid_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_municipiowwds_4_tfmunicipionome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioNome like :lV51Core_municipiowwds_4_tfmunicipionome)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_municipiowwds_5_tfmunicipionome_sel)) && ! ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioNome = ( :AV52Core_municipiowwds_5_tfmunicipionome_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_municipiowwds_6_tfmunicipiomicronome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome like :lV53Core_municipiowwds_6_tfmunicipiomicronome)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ! ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome = ( :AV54Core_municipiowwds_7_tfmunicipiomicronome_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_municipiowwds_8_tfmunicipiomicromesonome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome like :lV55Core_municipiowwds_8_tfmunicipiomicromesonome)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome = ( :AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla like :lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla = ( :AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome like :lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome = ( :AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MunicipioMicroMesoUFRegNome";
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
                     return conditional_P005P2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_P005P3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 2 :
                     return conditional_P005P4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 3 :
                     return conditional_P005P5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 4 :
                     return conditional_P005P6(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
          Object[] prmP005P2;
          prmP005P2 = new Object[] {
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV49Core_municipiowwds_2_tfmunicipioid",GXType.Int32,9,0) ,
          new ParDef("AV50Core_municipiowwds_3_tfmunicipioid_to",GXType.Int32,9,0) ,
          new ParDef("lV51Core_municipiowwds_4_tfmunicipionome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_municipiowwds_5_tfmunicipionome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_municipiowwds_6_tfmunicipiomicronome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_municipiowwds_7_tfmunicipiomicronome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_municipiowwds_8_tfmunicipiomicromesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005P3;
          prmP005P3 = new Object[] {
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV49Core_municipiowwds_2_tfmunicipioid",GXType.Int32,9,0) ,
          new ParDef("AV50Core_municipiowwds_3_tfmunicipioid_to",GXType.Int32,9,0) ,
          new ParDef("lV51Core_municipiowwds_4_tfmunicipionome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_municipiowwds_5_tfmunicipionome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_municipiowwds_6_tfmunicipiomicronome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_municipiowwds_7_tfmunicipiomicronome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_municipiowwds_8_tfmunicipiomicromesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005P4;
          prmP005P4 = new Object[] {
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV49Core_municipiowwds_2_tfmunicipioid",GXType.Int32,9,0) ,
          new ParDef("AV50Core_municipiowwds_3_tfmunicipioid_to",GXType.Int32,9,0) ,
          new ParDef("lV51Core_municipiowwds_4_tfmunicipionome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_municipiowwds_5_tfmunicipionome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_municipiowwds_6_tfmunicipiomicronome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_municipiowwds_7_tfmunicipiomicronome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_municipiowwds_8_tfmunicipiomicromesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005P5;
          prmP005P5 = new Object[] {
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV49Core_municipiowwds_2_tfmunicipioid",GXType.Int32,9,0) ,
          new ParDef("AV50Core_municipiowwds_3_tfmunicipioid_to",GXType.Int32,9,0) ,
          new ParDef("lV51Core_municipiowwds_4_tfmunicipionome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_municipiowwds_5_tfmunicipionome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_municipiowwds_6_tfmunicipiomicronome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_municipiowwds_7_tfmunicipiomicronome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_municipiowwds_8_tfmunicipiomicromesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005P6;
          prmP005P6 = new Object[] {
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV49Core_municipiowwds_2_tfmunicipioid",GXType.Int32,9,0) ,
          new ParDef("AV50Core_municipiowwds_3_tfmunicipioid_to",GXType.Int32,9,0) ,
          new ParDef("lV51Core_municipiowwds_4_tfmunicipionome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_municipiowwds_5_tfmunicipionome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_municipiowwds_6_tfmunicipiomicronome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_municipiowwds_7_tfmunicipiomicronome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_municipiowwds_8_tfmunicipiomicromesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_municipiowwds_9_tfmunicipiomicromesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_municipiowwds_10_tfmunicipiomicromesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_municipiowwds_12_tfmunicipiomicromesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005P3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005P4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005P4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005P5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005P5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005P6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005P6,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
