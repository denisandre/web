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
   public class ufwwgetfilterdata : GXProcedure
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
            return "ufww_Services_Execute" ;
         }

      }

      public ufwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ufwwgetfilterdata( IGxContext context )
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
         ufwwgetfilterdata objufwwgetfilterdata;
         objufwwgetfilterdata = new ufwwgetfilterdata();
         objufwwgetfilterdata.AV35DDOName = aP0_DDOName;
         objufwwgetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objufwwgetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objufwwgetfilterdata.AV38OptionsJson = "" ;
         objufwwgetfilterdata.AV39OptionsDescJson = "" ;
         objufwwgetfilterdata.AV40OptionIndexesJson = "" ;
         objufwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objufwwgetfilterdata.initialize();
         Submit( executePrivateCatch,objufwwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ufwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_UFSIGLA") == 0 )
         {
            /* Execute user subroutine: 'LOADUFSIGLAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_UFNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADUFNOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_UFREGNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADUFREGNOMEOPTIONS' */
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
         if ( StringUtil.StrCmp(AV30Session.Get("core.ufWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ufWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("core.ufWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFID") == 0 )
            {
               AV11TFUFID = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFUFID_To = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFSIGLA") == 0 )
            {
               AV13TFUFSigla = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFSIGLA_SEL") == 0 )
            {
               AV14TFUFSigla_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFNOME") == 0 )
            {
               AV15TFUFNome = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFNOME_SEL") == 0 )
            {
               AV16TFUFNome_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFREGNOME") == 0 )
            {
               AV17TFUFRegNome = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUFREGNOME_SEL") == 0 )
            {
               AV18TFUFRegNome_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUFSIGLAOPTIONS' Routine */
         returnInSub = false;
         AV13TFUFSigla = AV19SearchTxt;
         AV14TFUFSigla_Sel = "";
         AV58Core_ufwwds_1_filterfulltext = AV41FilterFullText;
         AV59Core_ufwwds_2_tfufid = AV11TFUFID;
         AV60Core_ufwwds_3_tfufid_to = AV12TFUFID_To;
         AV61Core_ufwwds_4_tfufsigla = AV13TFUFSigla;
         AV62Core_ufwwds_5_tfufsigla_sel = AV14TFUFSigla_Sel;
         AV63Core_ufwwds_6_tfufnome = AV15TFUFNome;
         AV64Core_ufwwds_7_tfufnome_sel = AV16TFUFNome_Sel;
         AV65Core_ufwwds_8_tfufregnome = AV17TFUFRegNome;
         AV66Core_ufwwds_9_tfufregnome_sel = AV18TFUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Core_ufwwds_1_filterfulltext ,
                                              AV59Core_ufwwds_2_tfufid ,
                                              AV60Core_ufwwds_3_tfufid_to ,
                                              AV62Core_ufwwds_5_tfufsigla_sel ,
                                              AV61Core_ufwwds_4_tfufsigla ,
                                              AV64Core_ufwwds_7_tfufnome_sel ,
                                              AV63Core_ufwwds_6_tfufnome ,
                                              AV66Core_ufwwds_9_tfufregnome_sel ,
                                              AV65Core_ufwwds_8_tfufregnome ,
                                              A4UFID ,
                                              A5UFSigla ,
                                              A6UFNome ,
                                              A10UFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV61Core_ufwwds_4_tfufsigla = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_4_tfufsigla), "%", "");
         lV63Core_ufwwds_6_tfufnome = StringUtil.Concat( StringUtil.RTrim( AV63Core_ufwwds_6_tfufnome), "%", "");
         lV65Core_ufwwds_8_tfufregnome = StringUtil.Concat( StringUtil.RTrim( AV65Core_ufwwds_8_tfufregnome), "%", "");
         /* Using cursor P005E2 */
         pr_default.execute(0, new Object[] {lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, AV59Core_ufwwds_2_tfufid, AV60Core_ufwwds_3_tfufid_to, lV61Core_ufwwds_4_tfufsigla, AV62Core_ufwwds_5_tfufsigla_sel, lV63Core_ufwwds_6_tfufnome, AV64Core_ufwwds_7_tfufnome_sel, lV65Core_ufwwds_8_tfufregnome, AV66Core_ufwwds_9_tfufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5E2 = false;
            A5UFSigla = P005E2_A5UFSigla[0];
            A4UFID = P005E2_A4UFID[0];
            A10UFRegNome = P005E2_A10UFRegNome[0];
            A6UFNome = P005E2_A6UFNome[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005E2_A5UFSigla[0], A5UFSigla) == 0 ) )
            {
               BRK5E2 = false;
               A4UFID = P005E2_A4UFID[0];
               AV29count = (long)(AV29count+1);
               BRK5E2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A5UFSigla)) ? "<#Empty#>" : A5UFSigla);
               AV26OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A5UFSigla, "@!")));
               AV25Options.Add(AV24Option, 0);
               AV27OptionsDesc.Add(AV26OptionDesc, 0);
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
            if ( ! BRK5E2 )
            {
               BRK5E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADUFNOMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFUFNome = AV19SearchTxt;
         AV16TFUFNome_Sel = "";
         AV58Core_ufwwds_1_filterfulltext = AV41FilterFullText;
         AV59Core_ufwwds_2_tfufid = AV11TFUFID;
         AV60Core_ufwwds_3_tfufid_to = AV12TFUFID_To;
         AV61Core_ufwwds_4_tfufsigla = AV13TFUFSigla;
         AV62Core_ufwwds_5_tfufsigla_sel = AV14TFUFSigla_Sel;
         AV63Core_ufwwds_6_tfufnome = AV15TFUFNome;
         AV64Core_ufwwds_7_tfufnome_sel = AV16TFUFNome_Sel;
         AV65Core_ufwwds_8_tfufregnome = AV17TFUFRegNome;
         AV66Core_ufwwds_9_tfufregnome_sel = AV18TFUFRegNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV58Core_ufwwds_1_filterfulltext ,
                                              AV59Core_ufwwds_2_tfufid ,
                                              AV60Core_ufwwds_3_tfufid_to ,
                                              AV62Core_ufwwds_5_tfufsigla_sel ,
                                              AV61Core_ufwwds_4_tfufsigla ,
                                              AV64Core_ufwwds_7_tfufnome_sel ,
                                              AV63Core_ufwwds_6_tfufnome ,
                                              AV66Core_ufwwds_9_tfufregnome_sel ,
                                              AV65Core_ufwwds_8_tfufregnome ,
                                              A4UFID ,
                                              A5UFSigla ,
                                              A6UFNome ,
                                              A10UFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV61Core_ufwwds_4_tfufsigla = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_4_tfufsigla), "%", "");
         lV63Core_ufwwds_6_tfufnome = StringUtil.Concat( StringUtil.RTrim( AV63Core_ufwwds_6_tfufnome), "%", "");
         lV65Core_ufwwds_8_tfufregnome = StringUtil.Concat( StringUtil.RTrim( AV65Core_ufwwds_8_tfufregnome), "%", "");
         /* Using cursor P005E3 */
         pr_default.execute(1, new Object[] {lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, AV59Core_ufwwds_2_tfufid, AV60Core_ufwwds_3_tfufid_to, lV61Core_ufwwds_4_tfufsigla, AV62Core_ufwwds_5_tfufsigla_sel, lV63Core_ufwwds_6_tfufnome, AV64Core_ufwwds_7_tfufnome_sel, lV65Core_ufwwds_8_tfufregnome, AV66Core_ufwwds_9_tfufregnome_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5E4 = false;
            A6UFNome = P005E3_A6UFNome[0];
            A4UFID = P005E3_A4UFID[0];
            A10UFRegNome = P005E3_A10UFRegNome[0];
            A5UFSigla = P005E3_A5UFSigla[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005E3_A6UFNome[0], A6UFNome) == 0 ) )
            {
               BRK5E4 = false;
               A4UFID = P005E3_A4UFID[0];
               AV29count = (long)(AV29count+1);
               BRK5E4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A6UFNome)) ? "<#Empty#>" : A6UFNome);
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
            if ( ! BRK5E4 )
            {
               BRK5E4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUFREGNOMEOPTIONS' Routine */
         returnInSub = false;
         AV17TFUFRegNome = AV19SearchTxt;
         AV18TFUFRegNome_Sel = "";
         AV58Core_ufwwds_1_filterfulltext = AV41FilterFullText;
         AV59Core_ufwwds_2_tfufid = AV11TFUFID;
         AV60Core_ufwwds_3_tfufid_to = AV12TFUFID_To;
         AV61Core_ufwwds_4_tfufsigla = AV13TFUFSigla;
         AV62Core_ufwwds_5_tfufsigla_sel = AV14TFUFSigla_Sel;
         AV63Core_ufwwds_6_tfufnome = AV15TFUFNome;
         AV64Core_ufwwds_7_tfufnome_sel = AV16TFUFNome_Sel;
         AV65Core_ufwwds_8_tfufregnome = AV17TFUFRegNome;
         AV66Core_ufwwds_9_tfufregnome_sel = AV18TFUFRegNome_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV58Core_ufwwds_1_filterfulltext ,
                                              AV59Core_ufwwds_2_tfufid ,
                                              AV60Core_ufwwds_3_tfufid_to ,
                                              AV62Core_ufwwds_5_tfufsigla_sel ,
                                              AV61Core_ufwwds_4_tfufsigla ,
                                              AV64Core_ufwwds_7_tfufnome_sel ,
                                              AV63Core_ufwwds_6_tfufnome ,
                                              AV66Core_ufwwds_9_tfufregnome_sel ,
                                              AV65Core_ufwwds_8_tfufregnome ,
                                              A4UFID ,
                                              A5UFSigla ,
                                              A6UFNome ,
                                              A10UFRegNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV58Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext), "%", "");
         lV61Core_ufwwds_4_tfufsigla = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_4_tfufsigla), "%", "");
         lV63Core_ufwwds_6_tfufnome = StringUtil.Concat( StringUtil.RTrim( AV63Core_ufwwds_6_tfufnome), "%", "");
         lV65Core_ufwwds_8_tfufregnome = StringUtil.Concat( StringUtil.RTrim( AV65Core_ufwwds_8_tfufregnome), "%", "");
         /* Using cursor P005E4 */
         pr_default.execute(2, new Object[] {lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, lV58Core_ufwwds_1_filterfulltext, AV59Core_ufwwds_2_tfufid, AV60Core_ufwwds_3_tfufid_to, lV61Core_ufwwds_4_tfufsigla, AV62Core_ufwwds_5_tfufsigla_sel, lV63Core_ufwwds_6_tfufnome, AV64Core_ufwwds_7_tfufnome_sel, lV65Core_ufwwds_8_tfufregnome, AV66Core_ufwwds_9_tfufregnome_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5E6 = false;
            A10UFRegNome = P005E4_A10UFRegNome[0];
            A4UFID = P005E4_A4UFID[0];
            A6UFNome = P005E4_A6UFNome[0];
            A5UFSigla = P005E4_A5UFSigla[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005E4_A10UFRegNome[0], A10UFRegNome) == 0 ) )
            {
               BRK5E6 = false;
               A4UFID = P005E4_A4UFID[0];
               AV29count = (long)(AV29count+1);
               BRK5E6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A10UFRegNome)) ? "<#Empty#>" : A10UFRegNome);
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
            if ( ! BRK5E6 )
            {
               BRK5E6 = true;
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
         AV13TFUFSigla = "";
         AV14TFUFSigla_Sel = "";
         AV15TFUFNome = "";
         AV16TFUFNome_Sel = "";
         AV17TFUFRegNome = "";
         AV18TFUFRegNome_Sel = "";
         AV58Core_ufwwds_1_filterfulltext = "";
         AV61Core_ufwwds_4_tfufsigla = "";
         AV62Core_ufwwds_5_tfufsigla_sel = "";
         AV63Core_ufwwds_6_tfufnome = "";
         AV64Core_ufwwds_7_tfufnome_sel = "";
         AV65Core_ufwwds_8_tfufregnome = "";
         AV66Core_ufwwds_9_tfufregnome_sel = "";
         scmdbuf = "";
         lV58Core_ufwwds_1_filterfulltext = "";
         lV61Core_ufwwds_4_tfufsigla = "";
         lV63Core_ufwwds_6_tfufnome = "";
         lV65Core_ufwwds_8_tfufregnome = "";
         A5UFSigla = "";
         A6UFNome = "";
         A10UFRegNome = "";
         P005E2_A5UFSigla = new string[] {""} ;
         P005E2_A4UFID = new int[1] ;
         P005E2_A10UFRegNome = new string[] {""} ;
         P005E2_A6UFNome = new string[] {""} ;
         AV24Option = "";
         AV26OptionDesc = "";
         P005E3_A6UFNome = new string[] {""} ;
         P005E3_A4UFID = new int[1] ;
         P005E3_A10UFRegNome = new string[] {""} ;
         P005E3_A5UFSigla = new string[] {""} ;
         P005E4_A10UFRegNome = new string[] {""} ;
         P005E4_A4UFID = new int[1] ;
         P005E4_A6UFNome = new string[] {""} ;
         P005E4_A5UFSigla = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.ufwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005E2_A5UFSigla, P005E2_A4UFID, P005E2_A10UFRegNome, P005E2_A6UFNome
               }
               , new Object[] {
               P005E3_A6UFNome, P005E3_A4UFID, P005E3_A10UFRegNome, P005E3_A5UFSigla
               }
               , new Object[] {
               P005E4_A10UFRegNome, P005E4_A4UFID, P005E4_A6UFNome, P005E4_A5UFSigla
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV56GXV1 ;
      private int AV11TFUFID ;
      private int AV12TFUFID_To ;
      private int AV59Core_ufwwds_2_tfufid ;
      private int AV60Core_ufwwds_3_tfufid_to ;
      private int A4UFID ;
      private long AV29count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK5E2 ;
      private bool BRK5E4 ;
      private bool BRK5E6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV13TFUFSigla ;
      private string AV14TFUFSigla_Sel ;
      private string AV15TFUFNome ;
      private string AV16TFUFNome_Sel ;
      private string AV17TFUFRegNome ;
      private string AV18TFUFRegNome_Sel ;
      private string AV58Core_ufwwds_1_filterfulltext ;
      private string AV61Core_ufwwds_4_tfufsigla ;
      private string AV62Core_ufwwds_5_tfufsigla_sel ;
      private string AV63Core_ufwwds_6_tfufnome ;
      private string AV64Core_ufwwds_7_tfufnome_sel ;
      private string AV65Core_ufwwds_8_tfufregnome ;
      private string AV66Core_ufwwds_9_tfufregnome_sel ;
      private string lV58Core_ufwwds_1_filterfulltext ;
      private string lV61Core_ufwwds_4_tfufsigla ;
      private string lV63Core_ufwwds_6_tfufnome ;
      private string lV65Core_ufwwds_8_tfufregnome ;
      private string A5UFSigla ;
      private string A6UFNome ;
      private string A10UFRegNome ;
      private string AV24Option ;
      private string AV26OptionDesc ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005E2_A5UFSigla ;
      private int[] P005E2_A4UFID ;
      private string[] P005E2_A10UFRegNome ;
      private string[] P005E2_A6UFNome ;
      private string[] P005E3_A6UFNome ;
      private int[] P005E3_A4UFID ;
      private string[] P005E3_A10UFRegNome ;
      private string[] P005E3_A5UFSigla ;
      private string[] P005E4_A10UFRegNome ;
      private int[] P005E4_A4UFID ;
      private string[] P005E4_A6UFNome ;
      private string[] P005E4_A5UFSigla ;
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

   public class ufwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005E2( IGxContext context ,
                                             string AV58Core_ufwwds_1_filterfulltext ,
                                             int AV59Core_ufwwds_2_tfufid ,
                                             int AV60Core_ufwwds_3_tfufid_to ,
                                             string AV62Core_ufwwds_5_tfufsigla_sel ,
                                             string AV61Core_ufwwds_4_tfufsigla ,
                                             string AV64Core_ufwwds_7_tfufnome_sel ,
                                             string AV63Core_ufwwds_6_tfufnome ,
                                             string AV66Core_ufwwds_9_tfufregnome_sel ,
                                             string AV65Core_ufwwds_8_tfufregnome ,
                                             int A4UFID ,
                                             string A5UFSigla ,
                                             string A6UFNome ,
                                             string A10UFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT UFSigla, UFID, UFRegNome, UFNome FROM tbibge_uf";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(UFID,'999999999'), 2) like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFSigla like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFNome like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFRegNome like '%' || :lV58Core_ufwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV59Core_ufwwds_2_tfufid) )
         {
            AddWhere(sWhereString, "(UFID >= :AV59Core_ufwwds_2_tfufid)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV60Core_ufwwds_3_tfufid_to) )
         {
            AddWhere(sWhereString, "(UFID <= :AV60Core_ufwwds_3_tfufid_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_ufwwds_5_tfufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_ufwwds_4_tfufsigla)) ) )
         {
            AddWhere(sWhereString, "(UFSigla like :lV61Core_ufwwds_4_tfufsigla)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_ufwwds_5_tfufsigla_sel)) && ! ( StringUtil.StrCmp(AV62Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFSigla = ( :AV62Core_ufwwds_5_tfufsigla_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_7_tfufnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_ufwwds_6_tfufnome)) ) )
         {
            AddWhere(sWhereString, "(UFNome like :lV63Core_ufwwds_6_tfufnome)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_7_tfufnome_sel)) && ! ( StringUtil.StrCmp(AV64Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFNome = ( :AV64Core_ufwwds_7_tfufnome_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_9_tfufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_ufwwds_8_tfufregnome)) ) )
         {
            AddWhere(sWhereString, "(UFRegNome like :lV65Core_ufwwds_8_tfufregnome)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_9_tfufregnome_sel)) && ! ( StringUtil.StrCmp(AV66Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFRegNome = ( :AV66Core_ufwwds_9_tfufregnome_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY UFSigla";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005E3( IGxContext context ,
                                             string AV58Core_ufwwds_1_filterfulltext ,
                                             int AV59Core_ufwwds_2_tfufid ,
                                             int AV60Core_ufwwds_3_tfufid_to ,
                                             string AV62Core_ufwwds_5_tfufsigla_sel ,
                                             string AV61Core_ufwwds_4_tfufsigla ,
                                             string AV64Core_ufwwds_7_tfufnome_sel ,
                                             string AV63Core_ufwwds_6_tfufnome ,
                                             string AV66Core_ufwwds_9_tfufregnome_sel ,
                                             string AV65Core_ufwwds_8_tfufregnome ,
                                             int A4UFID ,
                                             string A5UFSigla ,
                                             string A6UFNome ,
                                             string A10UFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT UFNome, UFID, UFRegNome, UFSigla FROM tbibge_uf";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(UFID,'999999999'), 2) like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFSigla like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFNome like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFRegNome like '%' || :lV58Core_ufwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV59Core_ufwwds_2_tfufid) )
         {
            AddWhere(sWhereString, "(UFID >= :AV59Core_ufwwds_2_tfufid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV60Core_ufwwds_3_tfufid_to) )
         {
            AddWhere(sWhereString, "(UFID <= :AV60Core_ufwwds_3_tfufid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_ufwwds_5_tfufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_ufwwds_4_tfufsigla)) ) )
         {
            AddWhere(sWhereString, "(UFSigla like :lV61Core_ufwwds_4_tfufsigla)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_ufwwds_5_tfufsigla_sel)) && ! ( StringUtil.StrCmp(AV62Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFSigla = ( :AV62Core_ufwwds_5_tfufsigla_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_7_tfufnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_ufwwds_6_tfufnome)) ) )
         {
            AddWhere(sWhereString, "(UFNome like :lV63Core_ufwwds_6_tfufnome)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_7_tfufnome_sel)) && ! ( StringUtil.StrCmp(AV64Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFNome = ( :AV64Core_ufwwds_7_tfufnome_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_9_tfufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_ufwwds_8_tfufregnome)) ) )
         {
            AddWhere(sWhereString, "(UFRegNome like :lV65Core_ufwwds_8_tfufregnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_9_tfufregnome_sel)) && ! ( StringUtil.StrCmp(AV66Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFRegNome = ( :AV66Core_ufwwds_9_tfufregnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY UFNome";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005E4( IGxContext context ,
                                             string AV58Core_ufwwds_1_filterfulltext ,
                                             int AV59Core_ufwwds_2_tfufid ,
                                             int AV60Core_ufwwds_3_tfufid_to ,
                                             string AV62Core_ufwwds_5_tfufsigla_sel ,
                                             string AV61Core_ufwwds_4_tfufsigla ,
                                             string AV64Core_ufwwds_7_tfufnome_sel ,
                                             string AV63Core_ufwwds_6_tfufnome ,
                                             string AV66Core_ufwwds_9_tfufregnome_sel ,
                                             string AV65Core_ufwwds_8_tfufregnome ,
                                             int A4UFID ,
                                             string A5UFSigla ,
                                             string A6UFNome ,
                                             string A10UFRegNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT UFRegNome, UFID, UFNome, UFSigla FROM tbibge_uf";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_ufwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(UFID,'999999999'), 2) like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFSigla like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFNome like '%' || :lV58Core_ufwwds_1_filterfulltext) or ( UFRegNome like '%' || :lV58Core_ufwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV59Core_ufwwds_2_tfufid) )
         {
            AddWhere(sWhereString, "(UFID >= :AV59Core_ufwwds_2_tfufid)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV60Core_ufwwds_3_tfufid_to) )
         {
            AddWhere(sWhereString, "(UFID <= :AV60Core_ufwwds_3_tfufid_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_ufwwds_5_tfufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_ufwwds_4_tfufsigla)) ) )
         {
            AddWhere(sWhereString, "(UFSigla like :lV61Core_ufwwds_4_tfufsigla)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_ufwwds_5_tfufsigla_sel)) && ! ( StringUtil.StrCmp(AV62Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFSigla = ( :AV62Core_ufwwds_5_tfufsigla_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_7_tfufnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_ufwwds_6_tfufnome)) ) )
         {
            AddWhere(sWhereString, "(UFNome like :lV63Core_ufwwds_6_tfufnome)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_7_tfufnome_sel)) && ! ( StringUtil.StrCmp(AV64Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFNome = ( :AV64Core_ufwwds_7_tfufnome_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_9_tfufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_ufwwds_8_tfufregnome)) ) )
         {
            AddWhere(sWhereString, "(UFRegNome like :lV65Core_ufwwds_8_tfufregnome)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_9_tfufregnome_sel)) && ! ( StringUtil.StrCmp(AV66Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFRegNome = ( :AV66Core_ufwwds_9_tfufregnome_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY UFRegNome";
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
                     return conditional_P005E2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 1 :
                     return conditional_P005E3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 2 :
                     return conditional_P005E4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP005E2;
          prmP005E2 = new Object[] {
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Core_ufwwds_2_tfufid",GXType.Int32,9,0) ,
          new ParDef("AV60Core_ufwwds_3_tfufid_to",GXType.Int32,9,0) ,
          new ParDef("lV61Core_ufwwds_4_tfufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV62Core_ufwwds_5_tfufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV63Core_ufwwds_6_tfufnome",GXType.VarChar,50,0) ,
          new ParDef("AV64Core_ufwwds_7_tfufnome_sel",GXType.VarChar,50,0) ,
          new ParDef("lV65Core_ufwwds_8_tfufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV66Core_ufwwds_9_tfufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005E3;
          prmP005E3 = new Object[] {
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Core_ufwwds_2_tfufid",GXType.Int32,9,0) ,
          new ParDef("AV60Core_ufwwds_3_tfufid_to",GXType.Int32,9,0) ,
          new ParDef("lV61Core_ufwwds_4_tfufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV62Core_ufwwds_5_tfufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV63Core_ufwwds_6_tfufnome",GXType.VarChar,50,0) ,
          new ParDef("AV64Core_ufwwds_7_tfufnome_sel",GXType.VarChar,50,0) ,
          new ParDef("lV65Core_ufwwds_8_tfufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV66Core_ufwwds_9_tfufregnome_sel",GXType.VarChar,50,0)
          };
          Object[] prmP005E4;
          prmP005E4 = new Object[] {
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Core_ufwwds_2_tfufid",GXType.Int32,9,0) ,
          new ParDef("AV60Core_ufwwds_3_tfufid_to",GXType.Int32,9,0) ,
          new ParDef("lV61Core_ufwwds_4_tfufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV62Core_ufwwds_5_tfufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV63Core_ufwwds_6_tfufnome",GXType.VarChar,50,0) ,
          new ParDef("AV64Core_ufwwds_7_tfufnome_sel",GXType.VarChar,50,0) ,
          new ParDef("lV65Core_ufwwds_8_tfufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV66Core_ufwwds_9_tfufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
