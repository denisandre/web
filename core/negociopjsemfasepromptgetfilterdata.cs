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
   public class negociopjsemfasepromptgetfilterdata : GXProcedure
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
            return "negociopjprompt_Services_Execute" ;
         }

      }

      public negociopjsemfasepromptgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjsemfasepromptgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         negociopjsemfasepromptgetfilterdata objnegociopjsemfasepromptgetfilterdata;
         objnegociopjsemfasepromptgetfilterdata = new negociopjsemfasepromptgetfilterdata();
         objnegociopjsemfasepromptgetfilterdata.AV43DDOName = aP0_DDOName;
         objnegociopjsemfasepromptgetfilterdata.AV44SearchTxtParms = aP1_SearchTxtParms;
         objnegociopjsemfasepromptgetfilterdata.AV45SearchTxtTo = aP2_SearchTxtTo;
         objnegociopjsemfasepromptgetfilterdata.AV46OptionsJson = "" ;
         objnegociopjsemfasepromptgetfilterdata.AV47OptionsDescJson = "" ;
         objnegociopjsemfasepromptgetfilterdata.AV48OptionIndexesJson = "" ;
         objnegociopjsemfasepromptgetfilterdata.context.SetSubmitInitialConfig(context);
         objnegociopjsemfasepromptgetfilterdata.initialize();
         Submit( executePrivateCatch,objnegociopjsemfasepromptgetfilterdata);
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((negociopjsemfasepromptgetfilterdata)stateInfo).executePrivate();
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
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30MaxItems = 10;
         AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_NEGASSUNTO") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGASSUNTOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_NEGCLINOMEFAMILIAR") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGCLINOMEFAMILIAROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_NEGCPJNOMFAN") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGCPJNOMFANOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_NEGPJTNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGPJTNOMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_NEGAGCNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADNEGAGCNOMEOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("core.NegocioPJSemFasePromptGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.NegocioPJSemFasePromptGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("core.NegocioPJSemFasePromptGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "NEGULTFASE_VAZIO") == 0 )
            {
               AV49NegUltFase_Vazio = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGCODIGO") == 0 )
            {
               AV11TFNegCodigo = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO") == 0 )
            {
               AV13TFNegAssunto = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO_SEL") == 0 )
            {
               AV14TFNegAssunto_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR") == 0 )
            {
               AV15TFNegCliNomeFamiliar = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV16TFNegCliNomeFamiliar_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN") == 0 )
            {
               AV17TFNegCpjNomFan = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN_SEL") == 0 )
            {
               AV18TFNegCpjNomFan_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGCPJMATRICULA") == 0 )
            {
               AV19TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME") == 0 )
            {
               AV21TFNegPjtNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME_SEL") == 0 )
            {
               AV22TFNegPjtNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME") == 0 )
            {
               AV23TFNegAgcNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME_SEL") == 0 )
            {
               AV24TFNegAgcNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFNEGINSDATA") == 0 )
            {
               AV25TFNegInsData = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV26TFNegInsData_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADNEGASSUNTOOPTIONS' Routine */
         returnInSub = false;
         AV13TFNegAssunto = AV27SearchTxt;
         AV14TFNegAssunto_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50FilterFullText ,
                                              AV11TFNegCodigo ,
                                              AV12TFNegCodigo_To ,
                                              AV14TFNegAssunto_Sel ,
                                              AV13TFNegAssunto ,
                                              AV16TFNegCliNomeFamiliar_Sel ,
                                              AV15TFNegCliNomeFamiliar ,
                                              AV18TFNegCpjNomFan_Sel ,
                                              AV17TFNegCpjNomFan ,
                                              AV19TFNegCpjMatricula ,
                                              AV20TFNegCpjMatricula_To ,
                                              AV22TFNegPjtNome_Sel ,
                                              AV21TFNegPjtNome ,
                                              AV24TFNegAgcNome_Sel ,
                                              AV23TFNegAgcNome ,
                                              AV25TFNegInsData ,
                                              AV26TFNegInsData_To ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A346NegInsData ,
                                              A386NegUltFase } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT
                                              }
         });
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV13TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV13TFNegAssunto), "%", "");
         lV15TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV15TFNegCliNomeFamiliar), "%", "");
         lV17TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV17TFNegCpjNomFan), "%", "");
         lV21TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV21TFNegPjtNome), "%", "");
         lV23TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV23TFNegAgcNome), "%", "");
         /* Using cursor P00622 */
         pr_default.execute(0, new Object[] {lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, AV11TFNegCodigo, AV12TFNegCodigo_To, lV13TFNegAssunto, AV14TFNegAssunto_Sel, lV15TFNegCliNomeFamiliar, AV16TFNegCliNomeFamiliar_Sel, lV17TFNegCpjNomFan, AV18TFNegCpjNomFan_Sel, AV19TFNegCpjMatricula, AV20TFNegCpjMatricula_To, lV21TFNegPjtNome, AV22TFNegPjtNome_Sel, lV23TFNegAgcNome, AV24TFNegAgcNome_Sel, AV25TFNegInsData, AV26TFNegInsData_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK622 = false;
            A350NegCliID = P00622_A350NegCliID[0];
            A352NegCpjID = P00622_A352NegCpjID[0];
            A362NegAssunto = P00622_A362NegAssunto[0];
            A346NegInsData = P00622_A346NegInsData[0];
            A361NegAgcNome = P00622_A361NegAgcNome[0];
            n361NegAgcNome = P00622_n361NegAgcNome[0];
            A359NegPjtNome = P00622_A359NegPjtNome[0];
            A355NegCpjMatricula = P00622_A355NegCpjMatricula[0];
            A353NegCpjNomFan = P00622_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00622_A351NegCliNomeFamiliar[0];
            A356NegCodigo = P00622_A356NegCodigo[0];
            A386NegUltFase = P00622_A386NegUltFase[0];
            A345NegID = P00622_A345NegID[0];
            A355NegCpjMatricula = P00622_A355NegCpjMatricula[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00622_A362NegAssunto[0], A362NegAssunto) == 0 ) )
            {
               BRK622 = false;
               A345NegID = P00622_A345NegID[0];
               AV37count = (long)(AV37count+1);
               BRK622 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A362NegAssunto)) ? "<#Empty#>" : A362NegAssunto);
               AV34OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")));
               AV33Options.Add(AV32Option, 0);
               AV35OptionsDesc.Add(AV34OptionDesc, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK622 )
            {
               BRK622 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADNEGCLINOMEFAMILIAROPTIONS' Routine */
         returnInSub = false;
         AV15TFNegCliNomeFamiliar = AV27SearchTxt;
         AV16TFNegCliNomeFamiliar_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50FilterFullText ,
                                              AV11TFNegCodigo ,
                                              AV12TFNegCodigo_To ,
                                              AV14TFNegAssunto_Sel ,
                                              AV13TFNegAssunto ,
                                              AV16TFNegCliNomeFamiliar_Sel ,
                                              AV15TFNegCliNomeFamiliar ,
                                              AV18TFNegCpjNomFan_Sel ,
                                              AV17TFNegCpjNomFan ,
                                              AV19TFNegCpjMatricula ,
                                              AV20TFNegCpjMatricula_To ,
                                              AV22TFNegPjtNome_Sel ,
                                              AV21TFNegPjtNome ,
                                              AV24TFNegAgcNome_Sel ,
                                              AV23TFNegAgcNome ,
                                              AV25TFNegInsData ,
                                              AV26TFNegInsData_To ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A346NegInsData ,
                                              A386NegUltFase } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT
                                              }
         });
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV13TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV13TFNegAssunto), "%", "");
         lV15TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV15TFNegCliNomeFamiliar), "%", "");
         lV17TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV17TFNegCpjNomFan), "%", "");
         lV21TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV21TFNegPjtNome), "%", "");
         lV23TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV23TFNegAgcNome), "%", "");
         /* Using cursor P00623 */
         pr_default.execute(1, new Object[] {lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, AV11TFNegCodigo, AV12TFNegCodigo_To, lV13TFNegAssunto, AV14TFNegAssunto_Sel, lV15TFNegCliNomeFamiliar, AV16TFNegCliNomeFamiliar_Sel, lV17TFNegCpjNomFan, AV18TFNegCpjNomFan_Sel, AV19TFNegCpjMatricula, AV20TFNegCpjMatricula_To, lV21TFNegPjtNome, AV22TFNegPjtNome_Sel, lV23TFNegAgcNome, AV24TFNegAgcNome_Sel, AV25TFNegInsData, AV26TFNegInsData_To});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK624 = false;
            A350NegCliID = P00623_A350NegCliID[0];
            A352NegCpjID = P00623_A352NegCpjID[0];
            A351NegCliNomeFamiliar = P00623_A351NegCliNomeFamiliar[0];
            A346NegInsData = P00623_A346NegInsData[0];
            A361NegAgcNome = P00623_A361NegAgcNome[0];
            n361NegAgcNome = P00623_n361NegAgcNome[0];
            A359NegPjtNome = P00623_A359NegPjtNome[0];
            A355NegCpjMatricula = P00623_A355NegCpjMatricula[0];
            A353NegCpjNomFan = P00623_A353NegCpjNomFan[0];
            A362NegAssunto = P00623_A362NegAssunto[0];
            A356NegCodigo = P00623_A356NegCodigo[0];
            A386NegUltFase = P00623_A386NegUltFase[0];
            A345NegID = P00623_A345NegID[0];
            A355NegCpjMatricula = P00623_A355NegCpjMatricula[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00623_A351NegCliNomeFamiliar[0], A351NegCliNomeFamiliar) == 0 ) )
            {
               BRK624 = false;
               A345NegID = P00623_A345NegID[0];
               AV37count = (long)(AV37count+1);
               BRK624 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A351NegCliNomeFamiliar)) ? "<#Empty#>" : A351NegCliNomeFamiliar);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK624 )
            {
               BRK624 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADNEGCPJNOMFANOPTIONS' Routine */
         returnInSub = false;
         AV17TFNegCpjNomFan = AV27SearchTxt;
         AV18TFNegCpjNomFan_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV50FilterFullText ,
                                              AV11TFNegCodigo ,
                                              AV12TFNegCodigo_To ,
                                              AV14TFNegAssunto_Sel ,
                                              AV13TFNegAssunto ,
                                              AV16TFNegCliNomeFamiliar_Sel ,
                                              AV15TFNegCliNomeFamiliar ,
                                              AV18TFNegCpjNomFan_Sel ,
                                              AV17TFNegCpjNomFan ,
                                              AV19TFNegCpjMatricula ,
                                              AV20TFNegCpjMatricula_To ,
                                              AV22TFNegPjtNome_Sel ,
                                              AV21TFNegPjtNome ,
                                              AV24TFNegAgcNome_Sel ,
                                              AV23TFNegAgcNome ,
                                              AV25TFNegInsData ,
                                              AV26TFNegInsData_To ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A346NegInsData ,
                                              A386NegUltFase } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT
                                              }
         });
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV13TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV13TFNegAssunto), "%", "");
         lV15TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV15TFNegCliNomeFamiliar), "%", "");
         lV17TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV17TFNegCpjNomFan), "%", "");
         lV21TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV21TFNegPjtNome), "%", "");
         lV23TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV23TFNegAgcNome), "%", "");
         /* Using cursor P00624 */
         pr_default.execute(2, new Object[] {lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, AV11TFNegCodigo, AV12TFNegCodigo_To, lV13TFNegAssunto, AV14TFNegAssunto_Sel, lV15TFNegCliNomeFamiliar, AV16TFNegCliNomeFamiliar_Sel, lV17TFNegCpjNomFan, AV18TFNegCpjNomFan_Sel, AV19TFNegCpjMatricula, AV20TFNegCpjMatricula_To, lV21TFNegPjtNome, AV22TFNegPjtNome_Sel, lV23TFNegAgcNome, AV24TFNegAgcNome_Sel, AV25TFNegInsData, AV26TFNegInsData_To});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK626 = false;
            A350NegCliID = P00624_A350NegCliID[0];
            A352NegCpjID = P00624_A352NegCpjID[0];
            A353NegCpjNomFan = P00624_A353NegCpjNomFan[0];
            A346NegInsData = P00624_A346NegInsData[0];
            A361NegAgcNome = P00624_A361NegAgcNome[0];
            n361NegAgcNome = P00624_n361NegAgcNome[0];
            A359NegPjtNome = P00624_A359NegPjtNome[0];
            A355NegCpjMatricula = P00624_A355NegCpjMatricula[0];
            A351NegCliNomeFamiliar = P00624_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00624_A362NegAssunto[0];
            A356NegCodigo = P00624_A356NegCodigo[0];
            A386NegUltFase = P00624_A386NegUltFase[0];
            A345NegID = P00624_A345NegID[0];
            A355NegCpjMatricula = P00624_A355NegCpjMatricula[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00624_A353NegCpjNomFan[0], A353NegCpjNomFan) == 0 ) )
            {
               BRK626 = false;
               A345NegID = P00624_A345NegID[0];
               AV37count = (long)(AV37count+1);
               BRK626 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A353NegCpjNomFan)) ? "<#Empty#>" : A353NegCpjNomFan);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK626 )
            {
               BRK626 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADNEGPJTNOMEOPTIONS' Routine */
         returnInSub = false;
         AV21TFNegPjtNome = AV27SearchTxt;
         AV22TFNegPjtNome_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV50FilterFullText ,
                                              AV11TFNegCodigo ,
                                              AV12TFNegCodigo_To ,
                                              AV14TFNegAssunto_Sel ,
                                              AV13TFNegAssunto ,
                                              AV16TFNegCliNomeFamiliar_Sel ,
                                              AV15TFNegCliNomeFamiliar ,
                                              AV18TFNegCpjNomFan_Sel ,
                                              AV17TFNegCpjNomFan ,
                                              AV19TFNegCpjMatricula ,
                                              AV20TFNegCpjMatricula_To ,
                                              AV22TFNegPjtNome_Sel ,
                                              AV21TFNegPjtNome ,
                                              AV24TFNegAgcNome_Sel ,
                                              AV23TFNegAgcNome ,
                                              AV25TFNegInsData ,
                                              AV26TFNegInsData_To ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A346NegInsData ,
                                              A386NegUltFase } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT
                                              }
         });
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV13TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV13TFNegAssunto), "%", "");
         lV15TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV15TFNegCliNomeFamiliar), "%", "");
         lV17TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV17TFNegCpjNomFan), "%", "");
         lV21TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV21TFNegPjtNome), "%", "");
         lV23TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV23TFNegAgcNome), "%", "");
         /* Using cursor P00625 */
         pr_default.execute(3, new Object[] {lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, AV11TFNegCodigo, AV12TFNegCodigo_To, lV13TFNegAssunto, AV14TFNegAssunto_Sel, lV15TFNegCliNomeFamiliar, AV16TFNegCliNomeFamiliar_Sel, lV17TFNegCpjNomFan, AV18TFNegCpjNomFan_Sel, AV19TFNegCpjMatricula, AV20TFNegCpjMatricula_To, lV21TFNegPjtNome, AV22TFNegPjtNome_Sel, lV23TFNegAgcNome, AV24TFNegAgcNome_Sel, AV25TFNegInsData, AV26TFNegInsData_To});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK628 = false;
            A350NegCliID = P00625_A350NegCliID[0];
            A352NegCpjID = P00625_A352NegCpjID[0];
            A359NegPjtNome = P00625_A359NegPjtNome[0];
            A346NegInsData = P00625_A346NegInsData[0];
            A361NegAgcNome = P00625_A361NegAgcNome[0];
            n361NegAgcNome = P00625_n361NegAgcNome[0];
            A355NegCpjMatricula = P00625_A355NegCpjMatricula[0];
            A353NegCpjNomFan = P00625_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00625_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00625_A362NegAssunto[0];
            A356NegCodigo = P00625_A356NegCodigo[0];
            A386NegUltFase = P00625_A386NegUltFase[0];
            A345NegID = P00625_A345NegID[0];
            A355NegCpjMatricula = P00625_A355NegCpjMatricula[0];
            AV37count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00625_A359NegPjtNome[0], A359NegPjtNome) == 0 ) )
            {
               BRK628 = false;
               A345NegID = P00625_A345NegID[0];
               AV37count = (long)(AV37count+1);
               BRK628 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A359NegPjtNome)) ? "<#Empty#>" : A359NegPjtNome);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK628 )
            {
               BRK628 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADNEGAGCNOMEOPTIONS' Routine */
         returnInSub = false;
         AV23TFNegAgcNome = AV27SearchTxt;
         AV24TFNegAgcNome_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV50FilterFullText ,
                                              AV11TFNegCodigo ,
                                              AV12TFNegCodigo_To ,
                                              AV14TFNegAssunto_Sel ,
                                              AV13TFNegAssunto ,
                                              AV16TFNegCliNomeFamiliar_Sel ,
                                              AV15TFNegCliNomeFamiliar ,
                                              AV18TFNegCpjNomFan_Sel ,
                                              AV17TFNegCpjNomFan ,
                                              AV19TFNegCpjMatricula ,
                                              AV20TFNegCpjMatricula_To ,
                                              AV22TFNegPjtNome_Sel ,
                                              AV21TFNegPjtNome ,
                                              AV24TFNegAgcNome_Sel ,
                                              AV23TFNegAgcNome ,
                                              AV25TFNegInsData ,
                                              AV26TFNegInsData_To ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A346NegInsData ,
                                              A386NegUltFase } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT
                                              }
         });
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV50FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV50FilterFullText), "%", "");
         lV13TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV13TFNegAssunto), "%", "");
         lV15TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV15TFNegCliNomeFamiliar), "%", "");
         lV17TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV17TFNegCpjNomFan), "%", "");
         lV21TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV21TFNegPjtNome), "%", "");
         lV23TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV23TFNegAgcNome), "%", "");
         /* Using cursor P00626 */
         pr_default.execute(4, new Object[] {lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, lV50FilterFullText, AV11TFNegCodigo, AV12TFNegCodigo_To, lV13TFNegAssunto, AV14TFNegAssunto_Sel, lV15TFNegCliNomeFamiliar, AV16TFNegCliNomeFamiliar_Sel, lV17TFNegCpjNomFan, AV18TFNegCpjNomFan_Sel, AV19TFNegCpjMatricula, AV20TFNegCpjMatricula_To, lV21TFNegPjtNome, AV22TFNegPjtNome_Sel, lV23TFNegAgcNome, AV24TFNegAgcNome_Sel, AV25TFNegInsData, AV26TFNegInsData_To});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6210 = false;
            A350NegCliID = P00626_A350NegCliID[0];
            A352NegCpjID = P00626_A352NegCpjID[0];
            A361NegAgcNome = P00626_A361NegAgcNome[0];
            n361NegAgcNome = P00626_n361NegAgcNome[0];
            A346NegInsData = P00626_A346NegInsData[0];
            A359NegPjtNome = P00626_A359NegPjtNome[0];
            A355NegCpjMatricula = P00626_A355NegCpjMatricula[0];
            A353NegCpjNomFan = P00626_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00626_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00626_A362NegAssunto[0];
            A356NegCodigo = P00626_A356NegCodigo[0];
            A386NegUltFase = P00626_A386NegUltFase[0];
            A345NegID = P00626_A345NegID[0];
            A355NegCpjMatricula = P00626_A355NegCpjMatricula[0];
            AV37count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00626_A361NegAgcNome[0], A361NegAgcNome) == 0 ) )
            {
               BRK6210 = false;
               A345NegID = P00626_A345NegID[0];
               AV37count = (long)(AV37count+1);
               BRK6210 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A361NegAgcNome)) ? "<#Empty#>" : A361NegAgcNome);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK6210 )
            {
               BRK6210 = true;
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50FilterFullText = "";
         AV13TFNegAssunto = "";
         AV14TFNegAssunto_Sel = "";
         AV15TFNegCliNomeFamiliar = "";
         AV16TFNegCliNomeFamiliar_Sel = "";
         AV17TFNegCpjNomFan = "";
         AV18TFNegCpjNomFan_Sel = "";
         AV21TFNegPjtNome = "";
         AV22TFNegPjtNome_Sel = "";
         AV23TFNegAgcNome = "";
         AV24TFNegAgcNome_Sel = "";
         AV25TFNegInsData = DateTime.MinValue;
         AV26TFNegInsData_To = DateTime.MinValue;
         scmdbuf = "";
         lV50FilterFullText = "";
         lV13TFNegAssunto = "";
         lV15TFNegCliNomeFamiliar = "";
         lV17TFNegCpjNomFan = "";
         lV21TFNegPjtNome = "";
         lV23TFNegAgcNome = "";
         A362NegAssunto = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         A359NegPjtNome = "";
         A361NegAgcNome = "";
         A346NegInsData = DateTime.MinValue;
         P00622_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00622_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00622_A362NegAssunto = new string[] {""} ;
         P00622_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00622_A361NegAgcNome = new string[] {""} ;
         P00622_n361NegAgcNome = new bool[] {false} ;
         P00622_A359NegPjtNome = new string[] {""} ;
         P00622_A355NegCpjMatricula = new long[1] ;
         P00622_A353NegCpjNomFan = new string[] {""} ;
         P00622_A351NegCliNomeFamiliar = new string[] {""} ;
         P00622_A356NegCodigo = new long[1] ;
         P00622_A386NegUltFase = new int[1] ;
         P00622_A345NegID = new Guid[] {Guid.Empty} ;
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         A345NegID = Guid.Empty;
         AV32Option = "";
         AV34OptionDesc = "";
         P00623_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00623_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00623_A351NegCliNomeFamiliar = new string[] {""} ;
         P00623_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00623_A361NegAgcNome = new string[] {""} ;
         P00623_n361NegAgcNome = new bool[] {false} ;
         P00623_A359NegPjtNome = new string[] {""} ;
         P00623_A355NegCpjMatricula = new long[1] ;
         P00623_A353NegCpjNomFan = new string[] {""} ;
         P00623_A362NegAssunto = new string[] {""} ;
         P00623_A356NegCodigo = new long[1] ;
         P00623_A386NegUltFase = new int[1] ;
         P00623_A345NegID = new Guid[] {Guid.Empty} ;
         P00624_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00624_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00624_A353NegCpjNomFan = new string[] {""} ;
         P00624_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00624_A361NegAgcNome = new string[] {""} ;
         P00624_n361NegAgcNome = new bool[] {false} ;
         P00624_A359NegPjtNome = new string[] {""} ;
         P00624_A355NegCpjMatricula = new long[1] ;
         P00624_A351NegCliNomeFamiliar = new string[] {""} ;
         P00624_A362NegAssunto = new string[] {""} ;
         P00624_A356NegCodigo = new long[1] ;
         P00624_A386NegUltFase = new int[1] ;
         P00624_A345NegID = new Guid[] {Guid.Empty} ;
         P00625_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00625_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00625_A359NegPjtNome = new string[] {""} ;
         P00625_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00625_A361NegAgcNome = new string[] {""} ;
         P00625_n361NegAgcNome = new bool[] {false} ;
         P00625_A355NegCpjMatricula = new long[1] ;
         P00625_A353NegCpjNomFan = new string[] {""} ;
         P00625_A351NegCliNomeFamiliar = new string[] {""} ;
         P00625_A362NegAssunto = new string[] {""} ;
         P00625_A356NegCodigo = new long[1] ;
         P00625_A386NegUltFase = new int[1] ;
         P00625_A345NegID = new Guid[] {Guid.Empty} ;
         P00626_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00626_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00626_A361NegAgcNome = new string[] {""} ;
         P00626_n361NegAgcNome = new bool[] {false} ;
         P00626_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00626_A359NegPjtNome = new string[] {""} ;
         P00626_A355NegCpjMatricula = new long[1] ;
         P00626_A353NegCpjNomFan = new string[] {""} ;
         P00626_A351NegCliNomeFamiliar = new string[] {""} ;
         P00626_A362NegAssunto = new string[] {""} ;
         P00626_A356NegCodigo = new long[1] ;
         P00626_A386NegUltFase = new int[1] ;
         P00626_A345NegID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjsemfasepromptgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00622_A350NegCliID, P00622_A352NegCpjID, P00622_A362NegAssunto, P00622_A346NegInsData, P00622_A361NegAgcNome, P00622_n361NegAgcNome, P00622_A359NegPjtNome, P00622_A355NegCpjMatricula, P00622_A353NegCpjNomFan, P00622_A351NegCliNomeFamiliar,
               P00622_A356NegCodigo, P00622_A386NegUltFase, P00622_A345NegID
               }
               , new Object[] {
               P00623_A350NegCliID, P00623_A352NegCpjID, P00623_A351NegCliNomeFamiliar, P00623_A346NegInsData, P00623_A361NegAgcNome, P00623_n361NegAgcNome, P00623_A359NegPjtNome, P00623_A355NegCpjMatricula, P00623_A353NegCpjNomFan, P00623_A362NegAssunto,
               P00623_A356NegCodigo, P00623_A386NegUltFase, P00623_A345NegID
               }
               , new Object[] {
               P00624_A350NegCliID, P00624_A352NegCpjID, P00624_A353NegCpjNomFan, P00624_A346NegInsData, P00624_A361NegAgcNome, P00624_n361NegAgcNome, P00624_A359NegPjtNome, P00624_A355NegCpjMatricula, P00624_A351NegCliNomeFamiliar, P00624_A362NegAssunto,
               P00624_A356NegCodigo, P00624_A386NegUltFase, P00624_A345NegID
               }
               , new Object[] {
               P00625_A350NegCliID, P00625_A352NegCpjID, P00625_A359NegPjtNome, P00625_A346NegInsData, P00625_A361NegAgcNome, P00625_n361NegAgcNome, P00625_A355NegCpjMatricula, P00625_A353NegCpjNomFan, P00625_A351NegCliNomeFamiliar, P00625_A362NegAssunto,
               P00625_A356NegCodigo, P00625_A386NegUltFase, P00625_A345NegID
               }
               , new Object[] {
               P00626_A350NegCliID, P00626_A352NegCpjID, P00626_A361NegAgcNome, P00626_n361NegAgcNome, P00626_A346NegInsData, P00626_A359NegPjtNome, P00626_A355NegCpjMatricula, P00626_A353NegCpjNomFan, P00626_A351NegCliNomeFamiliar, P00626_A362NegAssunto,
               P00626_A356NegCodigo, P00626_A386NegUltFase, P00626_A345NegID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private int AV51GXV1 ;
      private int AV49NegUltFase_Vazio ;
      private int A386NegUltFase ;
      private long AV11TFNegCodigo ;
      private long AV12TFNegCodigo_To ;
      private long AV19TFNegCpjMatricula ;
      private long AV20TFNegCpjMatricula_To ;
      private long A356NegCodigo ;
      private long A355NegCpjMatricula ;
      private long AV37count ;
      private string scmdbuf ;
      private DateTime AV25TFNegInsData ;
      private DateTime AV26TFNegInsData_To ;
      private DateTime A346NegInsData ;
      private bool returnInSub ;
      private bool BRK622 ;
      private bool n361NegAgcNome ;
      private bool BRK624 ;
      private bool BRK626 ;
      private bool BRK628 ;
      private bool BRK6210 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV50FilterFullText ;
      private string AV13TFNegAssunto ;
      private string AV14TFNegAssunto_Sel ;
      private string AV15TFNegCliNomeFamiliar ;
      private string AV16TFNegCliNomeFamiliar_Sel ;
      private string AV17TFNegCpjNomFan ;
      private string AV18TFNegCpjNomFan_Sel ;
      private string AV21TFNegPjtNome ;
      private string AV22TFNegPjtNome_Sel ;
      private string AV23TFNegAgcNome ;
      private string AV24TFNegAgcNome_Sel ;
      private string lV50FilterFullText ;
      private string lV13TFNegAssunto ;
      private string lV15TFNegCliNomeFamiliar ;
      private string lV17TFNegCpjNomFan ;
      private string lV21TFNegPjtNome ;
      private string lV23TFNegAgcNome ;
      private string A362NegAssunto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A359NegPjtNome ;
      private string A361NegAgcNome ;
      private string AV32Option ;
      private string AV34OptionDesc ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A345NegID ;
      private IGxSession AV38Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00622_A350NegCliID ;
      private Guid[] P00622_A352NegCpjID ;
      private string[] P00622_A362NegAssunto ;
      private DateTime[] P00622_A346NegInsData ;
      private string[] P00622_A361NegAgcNome ;
      private bool[] P00622_n361NegAgcNome ;
      private string[] P00622_A359NegPjtNome ;
      private long[] P00622_A355NegCpjMatricula ;
      private string[] P00622_A353NegCpjNomFan ;
      private string[] P00622_A351NegCliNomeFamiliar ;
      private long[] P00622_A356NegCodigo ;
      private int[] P00622_A386NegUltFase ;
      private Guid[] P00622_A345NegID ;
      private Guid[] P00623_A350NegCliID ;
      private Guid[] P00623_A352NegCpjID ;
      private string[] P00623_A351NegCliNomeFamiliar ;
      private DateTime[] P00623_A346NegInsData ;
      private string[] P00623_A361NegAgcNome ;
      private bool[] P00623_n361NegAgcNome ;
      private string[] P00623_A359NegPjtNome ;
      private long[] P00623_A355NegCpjMatricula ;
      private string[] P00623_A353NegCpjNomFan ;
      private string[] P00623_A362NegAssunto ;
      private long[] P00623_A356NegCodigo ;
      private int[] P00623_A386NegUltFase ;
      private Guid[] P00623_A345NegID ;
      private Guid[] P00624_A350NegCliID ;
      private Guid[] P00624_A352NegCpjID ;
      private string[] P00624_A353NegCpjNomFan ;
      private DateTime[] P00624_A346NegInsData ;
      private string[] P00624_A361NegAgcNome ;
      private bool[] P00624_n361NegAgcNome ;
      private string[] P00624_A359NegPjtNome ;
      private long[] P00624_A355NegCpjMatricula ;
      private string[] P00624_A351NegCliNomeFamiliar ;
      private string[] P00624_A362NegAssunto ;
      private long[] P00624_A356NegCodigo ;
      private int[] P00624_A386NegUltFase ;
      private Guid[] P00624_A345NegID ;
      private Guid[] P00625_A350NegCliID ;
      private Guid[] P00625_A352NegCpjID ;
      private string[] P00625_A359NegPjtNome ;
      private DateTime[] P00625_A346NegInsData ;
      private string[] P00625_A361NegAgcNome ;
      private bool[] P00625_n361NegAgcNome ;
      private long[] P00625_A355NegCpjMatricula ;
      private string[] P00625_A353NegCpjNomFan ;
      private string[] P00625_A351NegCliNomeFamiliar ;
      private string[] P00625_A362NegAssunto ;
      private long[] P00625_A356NegCodigo ;
      private int[] P00625_A386NegUltFase ;
      private Guid[] P00625_A345NegID ;
      private Guid[] P00626_A350NegCliID ;
      private Guid[] P00626_A352NegCpjID ;
      private string[] P00626_A361NegAgcNome ;
      private bool[] P00626_n361NegAgcNome ;
      private DateTime[] P00626_A346NegInsData ;
      private string[] P00626_A359NegPjtNome ;
      private long[] P00626_A355NegCpjMatricula ;
      private string[] P00626_A353NegCpjNomFan ;
      private string[] P00626_A351NegCliNomeFamiliar ;
      private string[] P00626_A362NegAssunto ;
      private long[] P00626_A356NegCodigo ;
      private int[] P00626_A386NegUltFase ;
      private Guid[] P00626_A345NegID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class negociopjsemfasepromptgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00622( IGxContext context ,
                                             string AV50FilterFullText ,
                                             long AV11TFNegCodigo ,
                                             long AV12TFNegCodigo_To ,
                                             string AV14TFNegAssunto_Sel ,
                                             string AV13TFNegAssunto ,
                                             string AV16TFNegCliNomeFamiliar_Sel ,
                                             string AV15TFNegCliNomeFamiliar ,
                                             string AV18TFNegCpjNomFan_Sel ,
                                             string AV17TFNegCpjNomFan ,
                                             long AV19TFNegCpjMatricula ,
                                             long AV20TFNegCpjMatricula_To ,
                                             string AV22TFNegPjtNome_Sel ,
                                             string AV21TFNegPjtNome ,
                                             string AV24TFNegAgcNome_Sel ,
                                             string AV23TFNegAgcNome ,
                                             DateTime AV25TFNegInsData ,
                                             DateTime AV26TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[23];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegAssunto, T1.NegInsData, T1.NegAgcNome, T1.NegPjtNome, T2.CpjMatricula AS NegCpjMatricula, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegCodigo, T1.NegUltFase, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV50FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV50FilterFullText)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV11TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV11TFNegCodigo)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV12TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV12TFNegCodigo_To)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV13TFNegAssunto)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV14TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV15TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV16TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV17TFNegCpjNomFan)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV18TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV19TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV19TFNegCpjMatricula)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (0==AV20TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV20TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV21TFNegPjtNome)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV22TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV23TFNegAgcNome)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV24TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV25TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV25TFNegInsData)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV26TFNegInsData_To)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegAssunto";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00623( IGxContext context ,
                                             string AV50FilterFullText ,
                                             long AV11TFNegCodigo ,
                                             long AV12TFNegCodigo_To ,
                                             string AV14TFNegAssunto_Sel ,
                                             string AV13TFNegAssunto ,
                                             string AV16TFNegCliNomeFamiliar_Sel ,
                                             string AV15TFNegCliNomeFamiliar ,
                                             string AV18TFNegCpjNomFan_Sel ,
                                             string AV17TFNegCpjNomFan ,
                                             long AV19TFNegCpjMatricula ,
                                             long AV20TFNegCpjMatricula_To ,
                                             string AV22TFNegPjtNome_Sel ,
                                             string AV21TFNegPjtNome ,
                                             string AV24TFNegAgcNome_Sel ,
                                             string AV23TFNegAgcNome ,
                                             DateTime AV25TFNegInsData ,
                                             DateTime AV26TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegCliNomeFamiliar, T1.NegInsData, T1.NegAgcNome, T1.NegPjtNome, T2.CpjMatricula AS NegCpjMatricula, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegAssunto, T1.NegCodigo, T1.NegUltFase, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV50FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV50FilterFullText)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV11TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV11TFNegCodigo)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV12TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV12TFNegCodigo_To)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV13TFNegAssunto)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV14TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV15TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV16TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV17TFNegCpjNomFan)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV18TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV19TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV19TFNegCpjMatricula)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (0==AV20TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV20TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV21TFNegPjtNome)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV22TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV23TFNegAgcNome)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV24TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV25TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV25TFNegInsData)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV26TFNegInsData_To)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegCliNomeFamiliar";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00624( IGxContext context ,
                                             string AV50FilterFullText ,
                                             long AV11TFNegCodigo ,
                                             long AV12TFNegCodigo_To ,
                                             string AV14TFNegAssunto_Sel ,
                                             string AV13TFNegAssunto ,
                                             string AV16TFNegCliNomeFamiliar_Sel ,
                                             string AV15TFNegCliNomeFamiliar ,
                                             string AV18TFNegCpjNomFan_Sel ,
                                             string AV17TFNegCpjNomFan ,
                                             long AV19TFNegCpjMatricula ,
                                             long AV20TFNegCpjMatricula_To ,
                                             string AV22TFNegPjtNome_Sel ,
                                             string AV21TFNegPjtNome ,
                                             string AV24TFNegAgcNome_Sel ,
                                             string AV23TFNegAgcNome ,
                                             DateTime AV25TFNegInsData ,
                                             DateTime AV26TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegInsData, T1.NegAgcNome, T1.NegPjtNome, T2.CpjMatricula AS NegCpjMatricula, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegCodigo, T1.NegUltFase, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV50FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV50FilterFullText)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV11TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV11TFNegCodigo)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV12TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV12TFNegCodigo_To)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV13TFNegAssunto)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV14TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV15TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV16TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV17TFNegCpjNomFan)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV18TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV19TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV19TFNegCpjMatricula)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (0==AV20TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV20TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV21TFNegPjtNome)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV22TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV23TFNegAgcNome)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV24TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV25TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV25TFNegInsData)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV26TFNegInsData_To)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegCpjNomFan";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00625( IGxContext context ,
                                             string AV50FilterFullText ,
                                             long AV11TFNegCodigo ,
                                             long AV12TFNegCodigo_To ,
                                             string AV14TFNegAssunto_Sel ,
                                             string AV13TFNegAssunto ,
                                             string AV16TFNegCliNomeFamiliar_Sel ,
                                             string AV15TFNegCliNomeFamiliar ,
                                             string AV18TFNegCpjNomFan_Sel ,
                                             string AV17TFNegCpjNomFan ,
                                             long AV19TFNegCpjMatricula ,
                                             long AV20TFNegCpjMatricula_To ,
                                             string AV22TFNegPjtNome_Sel ,
                                             string AV21TFNegPjtNome ,
                                             string AV24TFNegAgcNome_Sel ,
                                             string AV23TFNegAgcNome ,
                                             DateTime AV25TFNegInsData ,
                                             DateTime AV26TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[23];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegPjtNome, T1.NegInsData, T1.NegAgcNome, T2.CpjMatricula AS NegCpjMatricula, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegCodigo, T1.NegUltFase, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV50FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV50FilterFullText)))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV11TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV11TFNegCodigo)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV12TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV12TFNegCodigo_To)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV13TFNegAssunto)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV14TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV15TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV16TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV17TFNegCpjNomFan)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV18TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV19TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV19TFNegCpjMatricula)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (0==AV20TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV20TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV21TFNegPjtNome)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV22TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV23TFNegAgcNome)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV24TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV25TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV25TFNegInsData)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV26TFNegInsData_To)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegPjtNome";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00626( IGxContext context ,
                                             string AV50FilterFullText ,
                                             long AV11TFNegCodigo ,
                                             long AV12TFNegCodigo_To ,
                                             string AV14TFNegAssunto_Sel ,
                                             string AV13TFNegAssunto ,
                                             string AV16TFNegCliNomeFamiliar_Sel ,
                                             string AV15TFNegCliNomeFamiliar ,
                                             string AV18TFNegCpjNomFan_Sel ,
                                             string AV17TFNegCpjNomFan ,
                                             long AV19TFNegCpjMatricula ,
                                             long AV20TFNegCpjMatricula_To ,
                                             string AV22TFNegPjtNome_Sel ,
                                             string AV21TFNegPjtNome ,
                                             string AV24TFNegAgcNome_Sel ,
                                             string AV23TFNegAgcNome ,
                                             DateTime AV25TFNegInsData ,
                                             DateTime AV26TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[23];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegAgcNome, T1.NegInsData, T1.NegPjtNome, T2.CpjMatricula AS NegCpjMatricula, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegCodigo, T1.NegUltFase, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV50FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV50FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV50FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV50FilterFullText)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV11TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV11TFNegCodigo)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! (0==AV12TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV12TFNegCodigo_To)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV13TFNegAssunto)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV14TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV14TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV15TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV16TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV16TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV17TFNegCpjNomFan)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV18TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV18TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV19TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV19TFNegCpjMatricula)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (0==AV20TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV20TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV21TFNegPjtNome)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV22TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV23TFNegAgcNome)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV24TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV25TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV25TFNegInsData)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV26TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV26TFNegInsData_To)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegAgcNome";
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
                     return conditional_P00622(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (int)dynConstraints[25] );
               case 1 :
                     return conditional_P00623(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (int)dynConstraints[25] );
               case 2 :
                     return conditional_P00624(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (int)dynConstraints[25] );
               case 3 :
                     return conditional_P00625(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (int)dynConstraints[25] );
               case 4 :
                     return conditional_P00626(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (int)dynConstraints[25] );
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
          Object[] prmP00622;
          prmP00622 = new Object[] {
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV11TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV12TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV13TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV14TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV15TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV16TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV17TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV18TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV19TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV20TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV21TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV26TFNegInsData_To",GXType.Date,8,0)
          };
          Object[] prmP00623;
          prmP00623 = new Object[] {
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV11TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV12TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV13TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV14TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV15TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV16TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV17TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV18TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV19TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV20TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV21TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV26TFNegInsData_To",GXType.Date,8,0)
          };
          Object[] prmP00624;
          prmP00624 = new Object[] {
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV11TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV12TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV13TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV14TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV15TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV16TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV17TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV18TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV19TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV20TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV21TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV26TFNegInsData_To",GXType.Date,8,0)
          };
          Object[] prmP00625;
          prmP00625 = new Object[] {
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV11TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV12TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV13TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV14TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV15TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV16TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV17TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV18TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV19TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV20TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV21TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV26TFNegInsData_To",GXType.Date,8,0)
          };
          Object[] prmP00626;
          prmP00626 = new Object[] {
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV50FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV11TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV12TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV13TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV14TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV15TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV16TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV17TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV18TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV19TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV20TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV21TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV26TFNegInsData_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00622", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00622,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00623", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00623,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00624", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00624,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00625", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00625,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00626", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00626,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
       }
    }

 }

}
