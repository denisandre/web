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
   public class regiaowwgetfilterdata : GXProcedure
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
            return "regiaoww_Services_Execute" ;
         }

      }

      public regiaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public regiaowwgetfilterdata( IGxContext context )
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
         regiaowwgetfilterdata objregiaowwgetfilterdata;
         objregiaowwgetfilterdata = new regiaowwgetfilterdata();
         objregiaowwgetfilterdata.AV33DDOName = aP0_DDOName;
         objregiaowwgetfilterdata.AV34SearchTxtParms = aP1_SearchTxtParms;
         objregiaowwgetfilterdata.AV35SearchTxtTo = aP2_SearchTxtTo;
         objregiaowwgetfilterdata.AV36OptionsJson = "" ;
         objregiaowwgetfilterdata.AV37OptionsDescJson = "" ;
         objregiaowwgetfilterdata.AV38OptionIndexesJson = "" ;
         objregiaowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objregiaowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objregiaowwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((regiaowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_REGIAOSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADREGIAOSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_REGIAONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADREGIAONOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.regiaoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.regiaoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.regiaoWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFREGIAOID") == 0 )
            {
               AV11TFRegiaoID = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRegiaoID_To = (int)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFREGIAOSIGLA") == 0 )
            {
               AV13TFRegiaoSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFREGIAOSIGLA_SEL") == 0 )
            {
               AV14TFRegiaoSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFREGIAONOME") == 0 )
            {
               AV15TFRegiaoNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFREGIAONOME_SEL") == 0 )
            {
               AV16TFRegiaoNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADREGIAOSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV13TFRegiaoSigla = AV17SearchTxt;
         AV14TFRegiaoSigla_Sel = "";
         AV53Core_regiaowwds_1_filterfulltext = AV39FilterFullText;
         AV54Core_regiaowwds_2_tfregiaoid = AV11TFRegiaoID;
         AV55Core_regiaowwds_3_tfregiaoid_to = AV12TFRegiaoID_To;
         AV56Core_regiaowwds_4_tfregiaosigla = AV13TFRegiaoSigla;
         AV57Core_regiaowwds_5_tfregiaosigla_sel = AV14TFRegiaoSigla_Sel;
         AV58Core_regiaowwds_6_tfregiaonome = AV15TFRegiaoNome;
         AV59Core_regiaowwds_7_tfregiaonome_sel = AV16TFRegiaoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Core_regiaowwds_1_filterfulltext ,
                                              AV54Core_regiaowwds_2_tfregiaoid ,
                                              AV55Core_regiaowwds_3_tfregiaoid_to ,
                                              AV57Core_regiaowwds_5_tfregiaosigla_sel ,
                                              AV56Core_regiaowwds_4_tfregiaosigla ,
                                              AV59Core_regiaowwds_7_tfregiaonome_sel ,
                                              AV58Core_regiaowwds_6_tfregiaonome ,
                                              A1RegiaoID ,
                                              A2RegiaoSigla ,
                                              A3RegiaoNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext), "%", "");
         lV53Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext), "%", "");
         lV53Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext), "%", "");
         lV56Core_regiaowwds_4_tfregiaosigla = StringUtil.Concat( StringUtil.RTrim( AV56Core_regiaowwds_4_tfregiaosigla), "%", "");
         lV58Core_regiaowwds_6_tfregiaonome = StringUtil.Concat( StringUtil.RTrim( AV58Core_regiaowwds_6_tfregiaonome), "%", "");
         /* Using cursor P005C2 */
         pr_default.execute(0, new Object[] {lV53Core_regiaowwds_1_filterfulltext, lV53Core_regiaowwds_1_filterfulltext, lV53Core_regiaowwds_1_filterfulltext, AV54Core_regiaowwds_2_tfregiaoid, AV55Core_regiaowwds_3_tfregiaoid_to, lV56Core_regiaowwds_4_tfregiaosigla, AV57Core_regiaowwds_5_tfregiaosigla_sel, lV58Core_regiaowwds_6_tfregiaonome, AV59Core_regiaowwds_7_tfregiaonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5C2 = false;
            A2RegiaoSigla = P005C2_A2RegiaoSigla[0];
            A1RegiaoID = P005C2_A1RegiaoID[0];
            A3RegiaoNome = P005C2_A3RegiaoNome[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005C2_A2RegiaoSigla[0], A2RegiaoSigla) == 0 ) )
            {
               BRK5C2 = false;
               A1RegiaoID = P005C2_A1RegiaoID[0];
               AV27count = (long)(AV27count+1);
               BRK5C2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A2RegiaoSigla)) ? "<#Empty#>" : A2RegiaoSigla);
               AV24OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A2RegiaoSigla, "@!")));
               AV23Options.Add(AV22Option, 0);
               AV25OptionsDesc.Add(AV24OptionDesc, 0);
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
            if ( ! BRK5C2 )
            {
               BRK5C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADREGIAONOMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFRegiaoNome = AV17SearchTxt;
         AV16TFRegiaoNome_Sel = "";
         AV53Core_regiaowwds_1_filterfulltext = AV39FilterFullText;
         AV54Core_regiaowwds_2_tfregiaoid = AV11TFRegiaoID;
         AV55Core_regiaowwds_3_tfregiaoid_to = AV12TFRegiaoID_To;
         AV56Core_regiaowwds_4_tfregiaosigla = AV13TFRegiaoSigla;
         AV57Core_regiaowwds_5_tfregiaosigla_sel = AV14TFRegiaoSigla_Sel;
         AV58Core_regiaowwds_6_tfregiaonome = AV15TFRegiaoNome;
         AV59Core_regiaowwds_7_tfregiaonome_sel = AV16TFRegiaoNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Core_regiaowwds_1_filterfulltext ,
                                              AV54Core_regiaowwds_2_tfregiaoid ,
                                              AV55Core_regiaowwds_3_tfregiaoid_to ,
                                              AV57Core_regiaowwds_5_tfregiaosigla_sel ,
                                              AV56Core_regiaowwds_4_tfregiaosigla ,
                                              AV59Core_regiaowwds_7_tfregiaonome_sel ,
                                              AV58Core_regiaowwds_6_tfregiaonome ,
                                              A1RegiaoID ,
                                              A2RegiaoSigla ,
                                              A3RegiaoNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext), "%", "");
         lV53Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext), "%", "");
         lV53Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext), "%", "");
         lV56Core_regiaowwds_4_tfregiaosigla = StringUtil.Concat( StringUtil.RTrim( AV56Core_regiaowwds_4_tfregiaosigla), "%", "");
         lV58Core_regiaowwds_6_tfregiaonome = StringUtil.Concat( StringUtil.RTrim( AV58Core_regiaowwds_6_tfregiaonome), "%", "");
         /* Using cursor P005C3 */
         pr_default.execute(1, new Object[] {lV53Core_regiaowwds_1_filterfulltext, lV53Core_regiaowwds_1_filterfulltext, lV53Core_regiaowwds_1_filterfulltext, AV54Core_regiaowwds_2_tfregiaoid, AV55Core_regiaowwds_3_tfregiaoid_to, lV56Core_regiaowwds_4_tfregiaosigla, AV57Core_regiaowwds_5_tfregiaosigla_sel, lV58Core_regiaowwds_6_tfregiaonome, AV59Core_regiaowwds_7_tfregiaonome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5C4 = false;
            A3RegiaoNome = P005C3_A3RegiaoNome[0];
            A1RegiaoID = P005C3_A1RegiaoID[0];
            A2RegiaoSigla = P005C3_A2RegiaoSigla[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005C3_A3RegiaoNome[0], A3RegiaoNome) == 0 ) )
            {
               BRK5C4 = false;
               A1RegiaoID = P005C3_A1RegiaoID[0];
               AV27count = (long)(AV27count+1);
               BRK5C4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A3RegiaoNome)) ? "<#Empty#>" : A3RegiaoNome);
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
            if ( ! BRK5C4 )
            {
               BRK5C4 = true;
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
         AV13TFRegiaoSigla = "";
         AV14TFRegiaoSigla_Sel = "";
         AV15TFRegiaoNome = "";
         AV16TFRegiaoNome_Sel = "";
         AV53Core_regiaowwds_1_filterfulltext = "";
         AV56Core_regiaowwds_4_tfregiaosigla = "";
         AV57Core_regiaowwds_5_tfregiaosigla_sel = "";
         AV58Core_regiaowwds_6_tfregiaonome = "";
         AV59Core_regiaowwds_7_tfregiaonome_sel = "";
         scmdbuf = "";
         lV53Core_regiaowwds_1_filterfulltext = "";
         lV56Core_regiaowwds_4_tfregiaosigla = "";
         lV58Core_regiaowwds_6_tfregiaonome = "";
         A2RegiaoSigla = "";
         A3RegiaoNome = "";
         P005C2_A2RegiaoSigla = new string[] {""} ;
         P005C2_A1RegiaoID = new int[1] ;
         P005C2_A3RegiaoNome = new string[] {""} ;
         AV22Option = "";
         AV24OptionDesc = "";
         P005C3_A3RegiaoNome = new string[] {""} ;
         P005C3_A1RegiaoID = new int[1] ;
         P005C3_A2RegiaoSigla = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.regiaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005C2_A2RegiaoSigla, P005C2_A1RegiaoID, P005C2_A3RegiaoNome
               }
               , new Object[] {
               P005C3_A3RegiaoNome, P005C3_A1RegiaoID, P005C3_A2RegiaoSigla
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private int AV51GXV1 ;
      private int AV11TFRegiaoID ;
      private int AV12TFRegiaoID_To ;
      private int AV54Core_regiaowwds_2_tfregiaoid ;
      private int AV55Core_regiaowwds_3_tfregiaoid_to ;
      private int A1RegiaoID ;
      private long AV27count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK5C2 ;
      private bool BRK5C4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV13TFRegiaoSigla ;
      private string AV14TFRegiaoSigla_Sel ;
      private string AV15TFRegiaoNome ;
      private string AV16TFRegiaoNome_Sel ;
      private string AV53Core_regiaowwds_1_filterfulltext ;
      private string AV56Core_regiaowwds_4_tfregiaosigla ;
      private string AV57Core_regiaowwds_5_tfregiaosigla_sel ;
      private string AV58Core_regiaowwds_6_tfregiaonome ;
      private string AV59Core_regiaowwds_7_tfregiaonome_sel ;
      private string lV53Core_regiaowwds_1_filterfulltext ;
      private string lV56Core_regiaowwds_4_tfregiaosigla ;
      private string lV58Core_regiaowwds_6_tfregiaonome ;
      private string A2RegiaoSigla ;
      private string A3RegiaoNome ;
      private string AV22Option ;
      private string AV24OptionDesc ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005C2_A2RegiaoSigla ;
      private int[] P005C2_A1RegiaoID ;
      private string[] P005C2_A3RegiaoNome ;
      private string[] P005C3_A3RegiaoNome ;
      private int[] P005C3_A1RegiaoID ;
      private string[] P005C3_A2RegiaoSigla ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class regiaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005C2( IGxContext context ,
                                             string AV53Core_regiaowwds_1_filterfulltext ,
                                             int AV54Core_regiaowwds_2_tfregiaoid ,
                                             int AV55Core_regiaowwds_3_tfregiaoid_to ,
                                             string AV57Core_regiaowwds_5_tfregiaosigla_sel ,
                                             string AV56Core_regiaowwds_4_tfregiaosigla ,
                                             string AV59Core_regiaowwds_7_tfregiaonome_sel ,
                                             string AV58Core_regiaowwds_6_tfregiaonome ,
                                             int A1RegiaoID ,
                                             string A2RegiaoSigla ,
                                             string A3RegiaoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT RegiaoSigla, RegiaoID, RegiaoNome FROM tbibge_regiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(RegiaoID,'999999999'), 2) like '%' || :lV53Core_regiaowwds_1_filterfulltext) or ( RegiaoSigla like '%' || :lV53Core_regiaowwds_1_filterfulltext) or ( RegiaoNome like '%' || :lV53Core_regiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV54Core_regiaowwds_2_tfregiaoid) )
         {
            AddWhere(sWhereString, "(RegiaoID >= :AV54Core_regiaowwds_2_tfregiaoid)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV55Core_regiaowwds_3_tfregiaoid_to) )
         {
            AddWhere(sWhereString, "(RegiaoID <= :AV55Core_regiaowwds_3_tfregiaoid_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_regiaowwds_5_tfregiaosigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_regiaowwds_4_tfregiaosigla)) ) )
         {
            AddWhere(sWhereString, "(RegiaoSigla like :lV56Core_regiaowwds_4_tfregiaosigla)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_regiaowwds_5_tfregiaosigla_sel)) && ! ( StringUtil.StrCmp(AV57Core_regiaowwds_5_tfregiaosigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RegiaoSigla = ( :AV57Core_regiaowwds_5_tfregiaosigla_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV57Core_regiaowwds_5_tfregiaosigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from RegiaoSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_regiaowwds_7_tfregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_regiaowwds_6_tfregiaonome)) ) )
         {
            AddWhere(sWhereString, "(RegiaoNome like :lV58Core_regiaowwds_6_tfregiaonome)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_regiaowwds_7_tfregiaonome_sel)) && ! ( StringUtil.StrCmp(AV59Core_regiaowwds_7_tfregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RegiaoNome = ( :AV59Core_regiaowwds_7_tfregiaonome_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV59Core_regiaowwds_7_tfregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from RegiaoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY RegiaoSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005C3( IGxContext context ,
                                             string AV53Core_regiaowwds_1_filterfulltext ,
                                             int AV54Core_regiaowwds_2_tfregiaoid ,
                                             int AV55Core_regiaowwds_3_tfregiaoid_to ,
                                             string AV57Core_regiaowwds_5_tfregiaosigla_sel ,
                                             string AV56Core_regiaowwds_4_tfregiaosigla ,
                                             string AV59Core_regiaowwds_7_tfregiaonome_sel ,
                                             string AV58Core_regiaowwds_6_tfregiaonome ,
                                             int A1RegiaoID ,
                                             string A2RegiaoSigla ,
                                             string A3RegiaoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT RegiaoNome, RegiaoID, RegiaoSigla FROM tbibge_regiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_regiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(RegiaoID,'999999999'), 2) like '%' || :lV53Core_regiaowwds_1_filterfulltext) or ( RegiaoSigla like '%' || :lV53Core_regiaowwds_1_filterfulltext) or ( RegiaoNome like '%' || :lV53Core_regiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV54Core_regiaowwds_2_tfregiaoid) )
         {
            AddWhere(sWhereString, "(RegiaoID >= :AV54Core_regiaowwds_2_tfregiaoid)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV55Core_regiaowwds_3_tfregiaoid_to) )
         {
            AddWhere(sWhereString, "(RegiaoID <= :AV55Core_regiaowwds_3_tfregiaoid_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_regiaowwds_5_tfregiaosigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_regiaowwds_4_tfregiaosigla)) ) )
         {
            AddWhere(sWhereString, "(RegiaoSigla like :lV56Core_regiaowwds_4_tfregiaosigla)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_regiaowwds_5_tfregiaosigla_sel)) && ! ( StringUtil.StrCmp(AV57Core_regiaowwds_5_tfregiaosigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RegiaoSigla = ( :AV57Core_regiaowwds_5_tfregiaosigla_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV57Core_regiaowwds_5_tfregiaosigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from RegiaoSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_regiaowwds_7_tfregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_regiaowwds_6_tfregiaonome)) ) )
         {
            AddWhere(sWhereString, "(RegiaoNome like :lV58Core_regiaowwds_6_tfregiaonome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_regiaowwds_7_tfregiaonome_sel)) && ! ( StringUtil.StrCmp(AV59Core_regiaowwds_7_tfregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RegiaoNome = ( :AV59Core_regiaowwds_7_tfregiaonome_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV59Core_regiaowwds_7_tfregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from RegiaoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY RegiaoNome";
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
                     return conditional_P005C2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 1 :
                     return conditional_P005C3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmP005C2;
          prmP005C2 = new Object[] {
          new ParDef("lV53Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Core_regiaowwds_2_tfregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV55Core_regiaowwds_3_tfregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV56Core_regiaowwds_4_tfregiaosigla",GXType.VarChar,10,0) ,
          new ParDef("AV57Core_regiaowwds_5_tfregiaosigla_sel",GXType.VarChar,10,0) ,
          new ParDef("lV58Core_regiaowwds_6_tfregiaonome",GXType.VarChar,50,0) ,
          new ParDef("AV59Core_regiaowwds_7_tfregiaonome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005C3;
          prmP005C3 = new Object[] {
          new ParDef("lV53Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV54Core_regiaowwds_2_tfregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV55Core_regiaowwds_3_tfregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV56Core_regiaowwds_4_tfregiaosigla",GXType.VarChar,10,0) ,
          new ParDef("AV57Core_regiaowwds_5_tfregiaosigla_sel",GXType.VarChar,10,0) ,
          new ParDef("lV58Core_regiaowwds_6_tfregiaonome",GXType.VarChar,50,0) ,
          new ParDef("AV59Core_regiaowwds_7_tfregiaonome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C3,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
