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
   public class mesorregiaowwgetfilterdata : GXProcedure
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
            return "mesorregiaoww_Services_Execute" ;
         }

      }

      public mesorregiaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mesorregiaowwgetfilterdata( IGxContext context )
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
         mesorregiaowwgetfilterdata objmesorregiaowwgetfilterdata;
         objmesorregiaowwgetfilterdata = new mesorregiaowwgetfilterdata();
         objmesorregiaowwgetfilterdata.AV35DDOName = aP0_DDOName;
         objmesorregiaowwgetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objmesorregiaowwgetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objmesorregiaowwgetfilterdata.AV38OptionsJson = "" ;
         objmesorregiaowwgetfilterdata.AV39OptionsDescJson = "" ;
         objmesorregiaowwgetfilterdata.AV40OptionIndexesJson = "" ;
         objmesorregiaowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmesorregiaowwgetfilterdata.initialize();
         Submit( executePrivateCatch,objmesorregiaowwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((mesorregiaowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MESORREGIAONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMESORREGIAONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MESORREGIAOUFSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADMESORREGIAOUFSIGLAOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_MESORREGIAOUFREGNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADMESORREGIAOUFREGNOMEOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("core.mesorregiaoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.mesorregiaoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("core.mesorregiaoWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOID") == 0 )
            {
               AV13TFMesorregiaoID = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFMesorregiaoID_To = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAONOME") == 0 )
            {
               AV11TFMesorregiaoNome = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAONOME_SEL") == 0 )
            {
               AV12TFMesorregiaoNome_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFSIGLA") == 0 )
            {
               AV15TFMesorregiaoUFSigla = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFSIGLA_SEL") == 0 )
            {
               AV16TFMesorregiaoUFSigla_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFREGNOME") == 0 )
            {
               AV17TFMesorregiaoUFRegNome = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFREGNOME_SEL") == 0 )
            {
               AV18TFMesorregiaoUFRegNome_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMESORREGIAONOMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFMesorregiaoNome = AV19SearchTxt;
         AV12TFMesorregiaoNome_Sel = "";
         AV58Core_mesorregiaowwds_1_filterfulltext = AV41FilterFullText;
         AV59Core_mesorregiaowwds_2_tfmesorregiaoid = AV13TFMesorregiaoID;
         AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV14TFMesorregiaoID_To;
         AV61Core_mesorregiaowwds_4_tfmesorregiaonome = AV11TFMesorregiaoNome;
         AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV12TFMesorregiaoNome_Sel;
         AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV15TFMesorregiaoUFSigla;
         AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV16TFMesorregiaoUFSigla_Sel;
         AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV17TFMesorregiaoUFRegNome;
         AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV18TFMesorregiaoUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Core_mesorregiaowwds_1_filterfulltext ,
                                              AV59Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                              AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                              AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                              AV61Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                              AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                              AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                              AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                              AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                              A13MesorregiaoID ,
                                              A14MesorregiaoNome ,
                                              A16MesorregiaoUFSigla ,
                                              A21MesorregiaoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV61Core_mesorregiaowwds_4_tfmesorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_4_tfmesorregiaonome), "%", "");
         lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = StringUtil.Concat( StringUtil.RTrim( AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla), "%", "");
         lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = StringUtil.Concat( StringUtil.RTrim( AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome), "%", "");
         /* Using cursor P005I2 */
         pr_default.execute(0, new Object[] {lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, AV59Core_mesorregiaowwds_2_tfmesorregiaoid, AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to, lV61Core_mesorregiaowwds_4_tfmesorregiaonome, AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla, AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome, AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5I2 = false;
            A14MesorregiaoNome = P005I2_A14MesorregiaoNome[0];
            A13MesorregiaoID = P005I2_A13MesorregiaoID[0];
            A21MesorregiaoUFRegNome = P005I2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = P005I2_n21MesorregiaoUFRegNome[0];
            A16MesorregiaoUFSigla = P005I2_A16MesorregiaoUFSigla[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005I2_A14MesorregiaoNome[0], A14MesorregiaoNome) == 0 ) )
            {
               BRK5I2 = false;
               A13MesorregiaoID = P005I2_A13MesorregiaoID[0];
               AV29count = (long)(AV29count+1);
               BRK5I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A14MesorregiaoNome)) ? "<#Empty#>" : A14MesorregiaoNome);
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
            if ( ! BRK5I2 )
            {
               BRK5I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMESORREGIAOUFSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV15TFMesorregiaoUFSigla = AV19SearchTxt;
         AV16TFMesorregiaoUFSigla_Sel = "";
         AV58Core_mesorregiaowwds_1_filterfulltext = AV41FilterFullText;
         AV59Core_mesorregiaowwds_2_tfmesorregiaoid = AV13TFMesorregiaoID;
         AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV14TFMesorregiaoID_To;
         AV61Core_mesorregiaowwds_4_tfmesorregiaonome = AV11TFMesorregiaoNome;
         AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV12TFMesorregiaoNome_Sel;
         AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV15TFMesorregiaoUFSigla;
         AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV16TFMesorregiaoUFSigla_Sel;
         AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV17TFMesorregiaoUFRegNome;
         AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV18TFMesorregiaoUFRegNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV58Core_mesorregiaowwds_1_filterfulltext ,
                                              AV59Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                              AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                              AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                              AV61Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                              AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                              AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                              AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                              AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                              A13MesorregiaoID ,
                                              A14MesorregiaoNome ,
                                              A16MesorregiaoUFSigla ,
                                              A21MesorregiaoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV61Core_mesorregiaowwds_4_tfmesorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_4_tfmesorregiaonome), "%", "");
         lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = StringUtil.Concat( StringUtil.RTrim( AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla), "%", "");
         lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = StringUtil.Concat( StringUtil.RTrim( AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome), "%", "");
         /* Using cursor P005I3 */
         pr_default.execute(1, new Object[] {lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, AV59Core_mesorregiaowwds_2_tfmesorregiaoid, AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to, lV61Core_mesorregiaowwds_4_tfmesorregiaonome, AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla, AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome, AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5I4 = false;
            A15MesorregiaoUFID = P005I3_A15MesorregiaoUFID[0];
            A13MesorregiaoID = P005I3_A13MesorregiaoID[0];
            A21MesorregiaoUFRegNome = P005I3_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = P005I3_n21MesorregiaoUFRegNome[0];
            A16MesorregiaoUFSigla = P005I3_A16MesorregiaoUFSigla[0];
            A14MesorregiaoNome = P005I3_A14MesorregiaoNome[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P005I3_A15MesorregiaoUFID[0] == A15MesorregiaoUFID ) )
            {
               BRK5I4 = false;
               A13MesorregiaoID = P005I3_A13MesorregiaoID[0];
               AV29count = (long)(AV29count+1);
               BRK5I4 = true;
               pr_default.readNext(1);
            }
            AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A16MesorregiaoUFSigla)) ? "<#Empty#>" : A16MesorregiaoUFSigla);
            AV23InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV23InsertIndex = (int)(AV23InsertIndex+1);
            }
            AV25Options.Add(AV24Option, AV23InsertIndex);
            AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            if ( AV25Options.Count == AV20SkipItems + 11 )
            {
               AV25Options.RemoveItem(AV25Options.Count);
               AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
            }
            if ( ! BRK5I4 )
            {
               BRK5I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADMESORREGIAOUFREGNOMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFMesorregiaoUFRegNome = AV19SearchTxt;
         AV18TFMesorregiaoUFRegNome_Sel = "";
         AV58Core_mesorregiaowwds_1_filterfulltext = AV41FilterFullText;
         AV59Core_mesorregiaowwds_2_tfmesorregiaoid = AV13TFMesorregiaoID;
         AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV14TFMesorregiaoID_To;
         AV61Core_mesorregiaowwds_4_tfmesorregiaonome = AV11TFMesorregiaoNome;
         AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV12TFMesorregiaoNome_Sel;
         AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV15TFMesorregiaoUFSigla;
         AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV16TFMesorregiaoUFSigla_Sel;
         AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV17TFMesorregiaoUFRegNome;
         AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV18TFMesorregiaoUFRegNome_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV58Core_mesorregiaowwds_1_filterfulltext ,
                                              AV59Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                              AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                              AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                              AV61Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                              AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                              AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                              AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                              AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                              A13MesorregiaoID ,
                                              A14MesorregiaoNome ,
                                              A16MesorregiaoUFSigla ,
                                              A21MesorregiaoUFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV58Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV61Core_mesorregiaowwds_4_tfmesorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_4_tfmesorregiaonome), "%", "");
         lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = StringUtil.Concat( StringUtil.RTrim( AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla), "%", "");
         lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = StringUtil.Concat( StringUtil.RTrim( AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome), "%", "");
         /* Using cursor P005I4 */
         pr_default.execute(2, new Object[] {lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, lV58Core_mesorregiaowwds_1_filterfulltext, AV59Core_mesorregiaowwds_2_tfmesorregiaoid, AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to, lV61Core_mesorregiaowwds_4_tfmesorregiaonome, AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla, AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome, AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5I6 = false;
            A21MesorregiaoUFRegNome = P005I4_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = P005I4_n21MesorregiaoUFRegNome[0];
            A13MesorregiaoID = P005I4_A13MesorregiaoID[0];
            A16MesorregiaoUFSigla = P005I4_A16MesorregiaoUFSigla[0];
            A14MesorregiaoNome = P005I4_A14MesorregiaoNome[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005I4_A21MesorregiaoUFRegNome[0], A21MesorregiaoUFRegNome) == 0 ) )
            {
               BRK5I6 = false;
               A13MesorregiaoID = P005I4_A13MesorregiaoID[0];
               AV29count = (long)(AV29count+1);
               BRK5I6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A21MesorregiaoUFRegNome)) ? "<#Empty#>" : A21MesorregiaoUFRegNome);
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
            if ( ! BRK5I6 )
            {
               BRK5I6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV11TFMesorregiaoNome = "";
         AV12TFMesorregiaoNome_Sel = "";
         AV15TFMesorregiaoUFSigla = "";
         AV16TFMesorregiaoUFSigla_Sel = "";
         AV17TFMesorregiaoUFRegNome = "";
         AV18TFMesorregiaoUFRegNome_Sel = "";
         AV58Core_mesorregiaowwds_1_filterfulltext = "";
         AV61Core_mesorregiaowwds_4_tfmesorregiaonome = "";
         AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel = "";
         AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = "";
         AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = "";
         AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = "";
         AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = "";
         scmdbuf = "";
         lV58Core_mesorregiaowwds_1_filterfulltext = "";
         lV61Core_mesorregiaowwds_4_tfmesorregiaonome = "";
         lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla = "";
         lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome = "";
         A14MesorregiaoNome = "";
         A16MesorregiaoUFSigla = "";
         A21MesorregiaoUFRegNome = "";
         P005I2_A14MesorregiaoNome = new string[] {""} ;
         P005I2_A13MesorregiaoID = new int[1] ;
         P005I2_A21MesorregiaoUFRegNome = new string[] {""} ;
         P005I2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         P005I2_A16MesorregiaoUFSigla = new string[] {""} ;
         AV24Option = "";
         P005I3_A15MesorregiaoUFID = new int[1] ;
         P005I3_A13MesorregiaoID = new int[1] ;
         P005I3_A21MesorregiaoUFRegNome = new string[] {""} ;
         P005I3_n21MesorregiaoUFRegNome = new bool[] {false} ;
         P005I3_A16MesorregiaoUFSigla = new string[] {""} ;
         P005I3_A14MesorregiaoNome = new string[] {""} ;
         P005I4_A21MesorregiaoUFRegNome = new string[] {""} ;
         P005I4_n21MesorregiaoUFRegNome = new bool[] {false} ;
         P005I4_A13MesorregiaoID = new int[1] ;
         P005I4_A16MesorregiaoUFSigla = new string[] {""} ;
         P005I4_A14MesorregiaoNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005I2_A14MesorregiaoNome, P005I2_A13MesorregiaoID, P005I2_A21MesorregiaoUFRegNome, P005I2_n21MesorregiaoUFRegNome, P005I2_A16MesorregiaoUFSigla
               }
               , new Object[] {
               P005I3_A15MesorregiaoUFID, P005I3_A13MesorregiaoID, P005I3_A21MesorregiaoUFRegNome, P005I3_n21MesorregiaoUFRegNome, P005I3_A16MesorregiaoUFSigla, P005I3_A14MesorregiaoNome
               }
               , new Object[] {
               P005I4_A21MesorregiaoUFRegNome, P005I4_n21MesorregiaoUFRegNome, P005I4_A13MesorregiaoID, P005I4_A16MesorregiaoUFSigla, P005I4_A14MesorregiaoNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV56GXV1 ;
      private int AV13TFMesorregiaoID ;
      private int AV14TFMesorregiaoID_To ;
      private int AV59Core_mesorregiaowwds_2_tfmesorregiaoid ;
      private int AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ;
      private int A13MesorregiaoID ;
      private int A15MesorregiaoUFID ;
      private int AV23InsertIndex ;
      private long AV29count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK5I2 ;
      private bool n21MesorregiaoUFRegNome ;
      private bool BRK5I4 ;
      private bool BRK5I6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV11TFMesorregiaoNome ;
      private string AV12TFMesorregiaoNome_Sel ;
      private string AV15TFMesorregiaoUFSigla ;
      private string AV16TFMesorregiaoUFSigla_Sel ;
      private string AV17TFMesorregiaoUFRegNome ;
      private string AV18TFMesorregiaoUFRegNome_Sel ;
      private string AV58Core_mesorregiaowwds_1_filterfulltext ;
      private string AV61Core_mesorregiaowwds_4_tfmesorregiaonome ;
      private string AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ;
      private string AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ;
      private string AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ;
      private string AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ;
      private string AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ;
      private string lV58Core_mesorregiaowwds_1_filterfulltext ;
      private string lV61Core_mesorregiaowwds_4_tfmesorregiaonome ;
      private string lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ;
      private string lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ;
      private string A14MesorregiaoNome ;
      private string A16MesorregiaoUFSigla ;
      private string A21MesorregiaoUFRegNome ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005I2_A14MesorregiaoNome ;
      private int[] P005I2_A13MesorregiaoID ;
      private string[] P005I2_A21MesorregiaoUFRegNome ;
      private bool[] P005I2_n21MesorregiaoUFRegNome ;
      private string[] P005I2_A16MesorregiaoUFSigla ;
      private int[] P005I3_A15MesorregiaoUFID ;
      private int[] P005I3_A13MesorregiaoID ;
      private string[] P005I3_A21MesorregiaoUFRegNome ;
      private bool[] P005I3_n21MesorregiaoUFRegNome ;
      private string[] P005I3_A16MesorregiaoUFSigla ;
      private string[] P005I3_A14MesorregiaoNome ;
      private string[] P005I4_A21MesorregiaoUFRegNome ;
      private bool[] P005I4_n21MesorregiaoUFRegNome ;
      private int[] P005I4_A13MesorregiaoID ;
      private string[] P005I4_A16MesorregiaoUFSigla ;
      private string[] P005I4_A14MesorregiaoNome ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class mesorregiaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005I2( IGxContext context ,
                                             string AV58Core_mesorregiaowwds_1_filterfulltext ,
                                             int AV59Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                             int AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                             string AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                             string AV61Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                             string AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                             string AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                             string AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                             string AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                             int A13MesorregiaoID ,
                                             string A14MesorregiaoNome ,
                                             string A16MesorregiaoUFSigla ,
                                             string A21MesorregiaoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT MesorregiaoNome, MesorregiaoID, MesorregiaoUFRegNome, MesorregiaoUFSigla FROM tbibge_mesorregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MesorregiaoID,'999999999'), 2) like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoNome like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFSigla like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFRegNome like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV59Core_mesorregiaowwds_2_tfmesorregiaoid) )
         {
            AddWhere(sWhereString, "(MesorregiaoID >= :AV59Core_mesorregiaowwds_2_tfmesorregiaoid)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MesorregiaoID <= :AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_mesorregiaowwds_4_tfmesorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome like :lV61Core_mesorregiaowwds_4_tfmesorregiaonome)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome = ( :AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla like :lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ! ( StringUtil.StrCmp(AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla = ( :AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome like :lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ! ( StringUtil.StrCmp(AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome = ( :AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MesorregiaoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005I3( IGxContext context ,
                                             string AV58Core_mesorregiaowwds_1_filterfulltext ,
                                             int AV59Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                             int AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                             string AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                             string AV61Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                             string AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                             string AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                             string AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                             string AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                             int A13MesorregiaoID ,
                                             string A14MesorregiaoNome ,
                                             string A16MesorregiaoUFSigla ,
                                             string A21MesorregiaoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MesorregiaoUFID, MesorregiaoID, MesorregiaoUFRegNome, MesorregiaoUFSigla, MesorregiaoNome FROM tbibge_mesorregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MesorregiaoID,'999999999'), 2) like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoNome like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFSigla like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFRegNome like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV59Core_mesorregiaowwds_2_tfmesorregiaoid) )
         {
            AddWhere(sWhereString, "(MesorregiaoID >= :AV59Core_mesorregiaowwds_2_tfmesorregiaoid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MesorregiaoID <= :AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_mesorregiaowwds_4_tfmesorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome like :lV61Core_mesorregiaowwds_4_tfmesorregiaonome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome = ( :AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla like :lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ! ( StringUtil.StrCmp(AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla = ( :AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome like :lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ! ( StringUtil.StrCmp(AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome = ( :AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MesorregiaoUFID";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005I4( IGxContext context ,
                                             string AV58Core_mesorregiaowwds_1_filterfulltext ,
                                             int AV59Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                             int AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                             string AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                             string AV61Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                             string AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                             string AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                             string AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                             string AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                             int A13MesorregiaoID ,
                                             string A14MesorregiaoNome ,
                                             string A16MesorregiaoUFSigla ,
                                             string A21MesorregiaoUFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT MesorregiaoUFRegNome, MesorregiaoID, MesorregiaoUFSigla, MesorregiaoNome FROM tbibge_mesorregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_mesorregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MesorregiaoID,'999999999'), 2) like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoNome like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFSigla like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFRegNome like '%' || :lV58Core_mesorregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV59Core_mesorregiaowwds_2_tfmesorregiaoid) )
         {
            AddWhere(sWhereString, "(MesorregiaoID >= :AV59Core_mesorregiaowwds_2_tfmesorregiaoid)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MesorregiaoID <= :AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_mesorregiaowwds_4_tfmesorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome like :lV61Core_mesorregiaowwds_4_tfmesorregiaonome)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome = ( :AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla like :lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ! ( StringUtil.StrCmp(AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla = ( :AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome like :lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ! ( StringUtil.StrCmp(AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome = ( :AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY MesorregiaoUFRegNome";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005I2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P005I3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P005I4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005I2;
          prmP005I2 = new Object[] {
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Core_mesorregiaowwds_2_tfmesorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV61Core_mesorregiaowwds_4_tfmesorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005I3;
          prmP005I3 = new Object[] {
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Core_mesorregiaowwds_2_tfmesorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV61Core_mesorregiaowwds_4_tfmesorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005I4;
          prmP005I4 = new Object[] {
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Core_mesorregiaowwds_2_tfmesorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV60Core_mesorregiaowwds_3_tfmesorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV61Core_mesorregiaowwds_4_tfmesorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV62Core_mesorregiaowwds_5_tfmesorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV63Core_mesorregiaowwds_6_tfmesorregiaoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV64Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV65Core_mesorregiaowwds_8_tfmesorregiaoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV66Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I4,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
