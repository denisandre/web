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
   public class visitatipowwgetfilterdata : GXProcedure
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
            return "visitatipoww_Services_Execute" ;
         }

      }

      public visitatipowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitatipowwgetfilterdata( IGxContext context )
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
         visitatipowwgetfilterdata objvisitatipowwgetfilterdata;
         objvisitatipowwgetfilterdata = new visitatipowwgetfilterdata();
         objvisitatipowwgetfilterdata.AV31DDOName = aP0_DDOName;
         objvisitatipowwgetfilterdata.AV32SearchTxtParms = aP1_SearchTxtParms;
         objvisitatipowwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objvisitatipowwgetfilterdata.AV34OptionsJson = "" ;
         objvisitatipowwgetfilterdata.AV35OptionsDescJson = "" ;
         objvisitatipowwgetfilterdata.AV36OptionIndexesJson = "" ;
         objvisitatipowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objvisitatipowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objvisitatipowwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitatipowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_VITSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADVITSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_VITNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADVITNOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV26Session.Get("core.VisitaTipoWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.VisitaTipoWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("core.VisitaTipoWWGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "VITDEL_FILTRO") == 0 )
            {
               AV38VitDel_Filtro = BooleanUtil.Val( AV29GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFVITSIGLA") == 0 )
            {
               AV11TFVitSigla = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFVITSIGLA_SEL") == 0 )
            {
               AV12TFVitSigla_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFVITNOME") == 0 )
            {
               AV13TFVitNome = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFVITNOME_SEL") == 0 )
            {
               AV14TFVitNome_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADVITSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV11TFVitSigla = AV15SearchTxt;
         AV12TFVitSigla_Sel = "";
         AV41Core_visitatipowwds_1_vitdel_filtro = AV38VitDel_Filtro;
         AV42Core_visitatipowwds_2_filterfulltext = AV37FilterFullText;
         AV43Core_visitatipowwds_3_tfvitsigla = AV11TFVitSigla;
         AV44Core_visitatipowwds_4_tfvitsigla_sel = AV12TFVitSigla_Sel;
         AV45Core_visitatipowwds_5_tfvitnome = AV13TFVitNome;
         AV46Core_visitatipowwds_6_tfvitnome_sel = AV14TFVitNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV42Core_visitatipowwds_2_filterfulltext ,
                                              AV44Core_visitatipowwds_4_tfvitsigla_sel ,
                                              AV43Core_visitatipowwds_3_tfvitsigla ,
                                              AV46Core_visitatipowwds_6_tfvitnome_sel ,
                                              AV45Core_visitatipowwds_5_tfvitnome ,
                                              A412VitSigla ,
                                              A413VitNome ,
                                              A596VitDel } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV42Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Core_visitatipowwds_2_filterfulltext), "%", "");
         lV42Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Core_visitatipowwds_2_filterfulltext), "%", "");
         lV43Core_visitatipowwds_3_tfvitsigla = StringUtil.Concat( StringUtil.RTrim( AV43Core_visitatipowwds_3_tfvitsigla), "%", "");
         lV45Core_visitatipowwds_5_tfvitnome = StringUtil.Concat( StringUtil.RTrim( AV45Core_visitatipowwds_5_tfvitnome), "%", "");
         /* Using cursor P005S2 */
         pr_default.execute(0, new Object[] {lV42Core_visitatipowwds_2_filterfulltext, lV42Core_visitatipowwds_2_filterfulltext, lV43Core_visitatipowwds_3_tfvitsigla, AV44Core_visitatipowwds_4_tfvitsigla_sel, lV45Core_visitatipowwds_5_tfvitnome, AV46Core_visitatipowwds_6_tfvitnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5S2 = false;
            A412VitSigla = P005S2_A412VitSigla[0];
            A413VitNome = P005S2_A413VitNome[0];
            A596VitDel = P005S2_A596VitDel[0];
            A411VitID = P005S2_A411VitID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005S2_A412VitSigla[0], A412VitSigla) == 0 ) )
            {
               BRK5S2 = false;
               A411VitID = P005S2_A411VitID[0];
               AV25count = (long)(AV25count+1);
               BRK5S2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A412VitSigla)) ? "<#Empty#>" : A412VitSigla);
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
            if ( ! BRK5S2 )
            {
               BRK5S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADVITNOMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFVitNome = AV15SearchTxt;
         AV14TFVitNome_Sel = "";
         AV41Core_visitatipowwds_1_vitdel_filtro = AV38VitDel_Filtro;
         AV42Core_visitatipowwds_2_filterfulltext = AV37FilterFullText;
         AV43Core_visitatipowwds_3_tfvitsigla = AV11TFVitSigla;
         AV44Core_visitatipowwds_4_tfvitsigla_sel = AV12TFVitSigla_Sel;
         AV45Core_visitatipowwds_5_tfvitnome = AV13TFVitNome;
         AV46Core_visitatipowwds_6_tfvitnome_sel = AV14TFVitNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV42Core_visitatipowwds_2_filterfulltext ,
                                              AV44Core_visitatipowwds_4_tfvitsigla_sel ,
                                              AV43Core_visitatipowwds_3_tfvitsigla ,
                                              AV46Core_visitatipowwds_6_tfvitnome_sel ,
                                              AV45Core_visitatipowwds_5_tfvitnome ,
                                              A412VitSigla ,
                                              A413VitNome ,
                                              A596VitDel } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV42Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Core_visitatipowwds_2_filterfulltext), "%", "");
         lV42Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV42Core_visitatipowwds_2_filterfulltext), "%", "");
         lV43Core_visitatipowwds_3_tfvitsigla = StringUtil.Concat( StringUtil.RTrim( AV43Core_visitatipowwds_3_tfvitsigla), "%", "");
         lV45Core_visitatipowwds_5_tfvitnome = StringUtil.Concat( StringUtil.RTrim( AV45Core_visitatipowwds_5_tfvitnome), "%", "");
         /* Using cursor P005S3 */
         pr_default.execute(1, new Object[] {lV42Core_visitatipowwds_2_filterfulltext, lV42Core_visitatipowwds_2_filterfulltext, lV43Core_visitatipowwds_3_tfvitsigla, AV44Core_visitatipowwds_4_tfvitsigla_sel, lV45Core_visitatipowwds_5_tfvitnome, AV46Core_visitatipowwds_6_tfvitnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5S4 = false;
            A413VitNome = P005S3_A413VitNome[0];
            A412VitSigla = P005S3_A412VitSigla[0];
            A596VitDel = P005S3_A596VitDel[0];
            A411VitID = P005S3_A411VitID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005S3_A413VitNome[0], A413VitNome) == 0 ) )
            {
               BRK5S4 = false;
               A411VitID = P005S3_A411VitID[0];
               AV25count = (long)(AV25count+1);
               BRK5S4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A413VitNome)) ? "<#Empty#>" : A413VitNome);
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
            if ( ! BRK5S4 )
            {
               BRK5S4 = true;
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
         AV11TFVitSigla = "";
         AV12TFVitSigla_Sel = "";
         AV13TFVitNome = "";
         AV14TFVitNome_Sel = "";
         AV42Core_visitatipowwds_2_filterfulltext = "";
         AV43Core_visitatipowwds_3_tfvitsigla = "";
         AV44Core_visitatipowwds_4_tfvitsigla_sel = "";
         AV45Core_visitatipowwds_5_tfvitnome = "";
         AV46Core_visitatipowwds_6_tfvitnome_sel = "";
         scmdbuf = "";
         lV42Core_visitatipowwds_2_filterfulltext = "";
         lV43Core_visitatipowwds_3_tfvitsigla = "";
         lV45Core_visitatipowwds_5_tfvitnome = "";
         A412VitSigla = "";
         A413VitNome = "";
         P005S2_A412VitSigla = new string[] {""} ;
         P005S2_A413VitNome = new string[] {""} ;
         P005S2_A596VitDel = new bool[] {false} ;
         P005S2_A411VitID = new int[1] ;
         AV20Option = "";
         P005S3_A413VitNome = new string[] {""} ;
         P005S3_A412VitSigla = new string[] {""} ;
         P005S3_A596VitDel = new bool[] {false} ;
         P005S3_A411VitID = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005S2_A412VitSigla, P005S2_A413VitNome, P005S2_A596VitDel, P005S2_A411VitID
               }
               , new Object[] {
               P005S3_A413VitNome, P005S3_A412VitSigla, P005S3_A596VitDel, P005S3_A411VitID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV39GXV1 ;
      private int A411VitID ;
      private long AV25count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV38VitDel_Filtro ;
      private bool AV41Core_visitatipowwds_1_vitdel_filtro ;
      private bool A596VitDel ;
      private bool BRK5S2 ;
      private bool BRK5S4 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV11TFVitSigla ;
      private string AV12TFVitSigla_Sel ;
      private string AV13TFVitNome ;
      private string AV14TFVitNome_Sel ;
      private string AV42Core_visitatipowwds_2_filterfulltext ;
      private string AV43Core_visitatipowwds_3_tfvitsigla ;
      private string AV44Core_visitatipowwds_4_tfvitsigla_sel ;
      private string AV45Core_visitatipowwds_5_tfvitnome ;
      private string AV46Core_visitatipowwds_6_tfvitnome_sel ;
      private string lV42Core_visitatipowwds_2_filterfulltext ;
      private string lV43Core_visitatipowwds_3_tfvitsigla ;
      private string lV45Core_visitatipowwds_5_tfvitnome ;
      private string A412VitSigla ;
      private string A413VitNome ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005S2_A412VitSigla ;
      private string[] P005S2_A413VitNome ;
      private bool[] P005S2_A596VitDel ;
      private int[] P005S2_A411VitID ;
      private string[] P005S3_A413VitNome ;
      private string[] P005S3_A412VitSigla ;
      private bool[] P005S3_A596VitDel ;
      private int[] P005S3_A411VitID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class visitatipowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005S2( IGxContext context ,
                                             string AV42Core_visitatipowwds_2_filterfulltext ,
                                             string AV44Core_visitatipowwds_4_tfvitsigla_sel ,
                                             string AV43Core_visitatipowwds_3_tfvitsigla ,
                                             string AV46Core_visitatipowwds_6_tfvitnome_sel ,
                                             string AV45Core_visitatipowwds_5_tfvitnome ,
                                             string A412VitSigla ,
                                             string A413VitNome ,
                                             bool A596VitDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT VitSigla, VitNome, VitDel, VitID FROM tb_visitatipo";
         AddWhere(sWhereString, "(Not VitDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Core_visitatipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( VitSigla like '%' || :lV42Core_visitatipowwds_2_filterfulltext) or ( VitNome like '%' || :lV42Core_visitatipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_4_tfvitsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Core_visitatipowwds_3_tfvitsigla)) ) )
         {
            AddWhere(sWhereString, "(VitSigla like :lV43Core_visitatipowwds_3_tfvitsigla)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_4_tfvitsigla_sel)) && ! ( StringUtil.StrCmp(AV44Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitSigla = ( :AV44Core_visitatipowwds_4_tfvitsigla_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV44Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_visitatipowwds_6_tfvitnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Core_visitatipowwds_5_tfvitnome)) ) )
         {
            AddWhere(sWhereString, "(VitNome like :lV45Core_visitatipowwds_5_tfvitnome)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_visitatipowwds_6_tfvitnome_sel)) && ! ( StringUtil.StrCmp(AV46Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitNome = ( :AV46Core_visitatipowwds_6_tfvitnome_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY VitSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005S3( IGxContext context ,
                                             string AV42Core_visitatipowwds_2_filterfulltext ,
                                             string AV44Core_visitatipowwds_4_tfvitsigla_sel ,
                                             string AV43Core_visitatipowwds_3_tfvitsigla ,
                                             string AV46Core_visitatipowwds_6_tfvitnome_sel ,
                                             string AV45Core_visitatipowwds_5_tfvitnome ,
                                             string A412VitSigla ,
                                             string A413VitNome ,
                                             bool A596VitDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT VitNome, VitSigla, VitDel, VitID FROM tb_visitatipo";
         AddWhere(sWhereString, "(Not VitDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Core_visitatipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( VitSigla like '%' || :lV42Core_visitatipowwds_2_filterfulltext) or ( VitNome like '%' || :lV42Core_visitatipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_4_tfvitsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Core_visitatipowwds_3_tfvitsigla)) ) )
         {
            AddWhere(sWhereString, "(VitSigla like :lV43Core_visitatipowwds_3_tfvitsigla)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_4_tfvitsigla_sel)) && ! ( StringUtil.StrCmp(AV44Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitSigla = ( :AV44Core_visitatipowwds_4_tfvitsigla_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV44Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_visitatipowwds_6_tfvitnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Core_visitatipowwds_5_tfvitnome)) ) )
         {
            AddWhere(sWhereString, "(VitNome like :lV45Core_visitatipowwds_5_tfvitnome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_visitatipowwds_6_tfvitnome_sel)) && ! ( StringUtil.StrCmp(AV46Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitNome = ( :AV46Core_visitatipowwds_6_tfvitnome_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV46Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY VitNome";
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
                     return conditional_P005S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] );
               case 1 :
                     return conditional_P005S3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] );
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
          Object[] prmP005S2;
          prmP005S2 = new Object[] {
          new ParDef("lV42Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Core_visitatipowwds_3_tfvitsigla",GXType.VarChar,20,0) ,
          new ParDef("AV44Core_visitatipowwds_4_tfvitsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV45Core_visitatipowwds_5_tfvitnome",GXType.VarChar,80,0) ,
          new ParDef("AV46Core_visitatipowwds_6_tfvitnome_sel",GXType.VarChar,80,0)
          };
          Object[] prmP005S3;
          prmP005S3 = new Object[] {
          new ParDef("lV42Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV42Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Core_visitatipowwds_3_tfvitsigla",GXType.VarChar,20,0) ,
          new ParDef("AV44Core_visitatipowwds_4_tfvitsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV45Core_visitatipowwds_5_tfvitnome",GXType.VarChar,80,0) ,
          new ParDef("AV46Core_visitatipowwds_6_tfvitnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S3,100, GxCacheFrequency.OFF ,true,false )
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
