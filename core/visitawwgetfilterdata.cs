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
   public class visitawwgetfilterdata : GXProcedure
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
            return "visitaww_Services_Execute" ;
         }

      }

      public visitawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitawwgetfilterdata( IGxContext context )
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
         this.AV57DDOName = aP0_DDOName;
         this.AV58SearchTxtParms = aP1_SearchTxtParms;
         this.AV59SearchTxtTo = aP2_SearchTxtTo;
         this.AV60OptionsJson = "" ;
         this.AV61OptionsDescJson = "" ;
         this.AV62OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV60OptionsJson;
         aP4_OptionsDescJson=this.AV61OptionsDescJson;
         aP5_OptionIndexesJson=this.AV62OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV62OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         visitawwgetfilterdata objvisitawwgetfilterdata;
         objvisitawwgetfilterdata = new visitawwgetfilterdata();
         objvisitawwgetfilterdata.AV57DDOName = aP0_DDOName;
         objvisitawwgetfilterdata.AV58SearchTxtParms = aP1_SearchTxtParms;
         objvisitawwgetfilterdata.AV59SearchTxtTo = aP2_SearchTxtTo;
         objvisitawwgetfilterdata.AV60OptionsJson = "" ;
         objvisitawwgetfilterdata.AV61OptionsDescJson = "" ;
         objvisitawwgetfilterdata.AV62OptionIndexesJson = "" ;
         objvisitawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objvisitawwgetfilterdata.initialize();
         Submit( executePrivateCatch,objvisitawwgetfilterdata);
         aP3_OptionsJson=this.AV60OptionsJson;
         aP4_OptionsDescJson=this.AV61OptionsDescJson;
         aP5_OptionIndexesJson=this.AV62OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitawwgetfilterdata)stateInfo).executePrivate();
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
         AV47Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV49OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV50OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV44MaxItems = 10;
         AV43PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV58SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV58SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV41SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV58SearchTxtParms)) ? "" : StringUtil.Substring( AV58SearchTxtParms, 3, -1));
         AV42SkipItems = (short)(AV43PageIndex*AV44MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV57DDOName), "DDO_VISINSUSUNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADVISINSUSUNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV57DDOName), "DDO_VISTIPONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADVISTIPONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV57DDOName), "DDO_VISASSUNTO") == 0 )
         {
            /* Execute user subroutine: 'LOADVISASSUNTOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV57DDOName), "DDO_VISLINK") == 0 )
         {
            /* Execute user subroutine: 'LOADVISLINKOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV60OptionsJson = AV47Options.ToJSonString(false);
         AV61OptionsDescJson = AV49OptionsDesc.ToJSonString(false);
         AV62OptionIndexesJson = AV50OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV52Session.Get("core.VisitaWWGridState"), "") == 0 )
         {
            AV54GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.VisitaWWGridState"), null, "", "");
         }
         else
         {
            AV54GridState.FromXml(AV52Session.Get("core.VisitaWWGridState"), null, "", "");
         }
         AV104GXV1 = 1;
         while ( AV104GXV1 <= AV54GridState.gxTpr_Filtervalues.Count )
         {
            AV55GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV54GridState.gxTpr_Filtervalues.Item(AV104GXV1));
            if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "VISNEGID_FILTRO") == 0 )
            {
               AV93VisNegID_Filtro = StringUtil.StrToGuid( AV55GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "VISNGFSEQ_FILTRO") == 0 )
            {
               AV94VisNgfSeq_Filtro = (int)(Math.Round(NumberUtil.Val( AV55GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "VISDEL_FILTRO") == 0 )
            {
               AV103VisDel_Filtro = BooleanUtil.Val( AV55GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "VISSITUACAO") == 0 )
            {
               AV102VisSituacao = AV55GridStateFilterValue.gxTpr_Value;
               AV101DynamicFiltersOperatorVisSituacao = AV55GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISINSDATAHORA") == 0 )
            {
               AV15TFVisInsDataHora = context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Value, 2);
               AV16TFVisInsDataHora_To = context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME") == 0 )
            {
               AV19TFVisInsUsuNome = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME_SEL") == 0 )
            {
               AV20TFVisInsUsuNome_Sel = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISDATA") == 0 )
            {
               AV21TFVisData = context.localUtil.CToD( AV55GridStateFilterValue.gxTpr_Value, 2);
               AV22TFVisData_To = context.localUtil.CToD( AV55GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISHORA") == 0 )
            {
               AV23TFVisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Value, 2));
               AV24TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISDATAHORA") == 0 )
            {
               AV25TFVisDataHora = context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Value, 2);
               AV26TFVisDataHora_To = context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISDATAFIM") == 0 )
            {
               AV95TFVisDataFim = context.localUtil.CToD( AV55GridStateFilterValue.gxTpr_Value, 2);
               AV96TFVisDataFim_To = context.localUtil.CToD( AV55GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISHORAFIM") == 0 )
            {
               AV97TFVisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Value, 2));
               AV98TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISDATAHORAFIM") == 0 )
            {
               AV99TFVisDataHoraFim = context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Value, 2);
               AV100TFVisDataHoraFim_To = context.localUtil.CToT( AV55GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME") == 0 )
            {
               AV31TFVisTipoNome = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME_SEL") == 0 )
            {
               AV32TFVisTipoNome_Sel = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO") == 0 )
            {
               AV37TFVisAssunto = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO_SEL") == 0 )
            {
               AV38TFVisAssunto_Sel = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISSITUACAO_SEL") == 0 )
            {
               AV91TFVisSituacao_SelsJson = AV55GridStateFilterValue.gxTpr_Value;
               AV92TFVisSituacao_Sels.FromJSonString(AV91TFVisSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISLINK") == 0 )
            {
               AV39TFVisLink = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "TFVISLINK_SEL") == 0 )
            {
               AV40TFVisLink_Sel = AV55GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "PARM_&VISNEGID") == 0 )
            {
               AV88VisNegID = StringUtil.StrToGuid( AV55GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV55GridStateFilterValue.gxTpr_Name, "PARM_&VISNGFSEQ") == 0 )
            {
               AV89VisNgfSeq = (int)(Math.Round(NumberUtil.Val( AV55GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV104GXV1 = (int)(AV104GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADVISINSUSUNOMEOPTIONS' Routine */
         returnInSub = false;
         AV19TFVisInsUsuNome = AV41SearchTxt;
         AV20TFVisInsUsuNome_Sel = "";
         AV106Core_visitawwds_1_visnegid_filtro = AV93VisNegID_Filtro;
         AV107Core_visitawwds_2_visngfseq_filtro = AV94VisNgfSeq_Filtro;
         AV108Core_visitawwds_3_visdel_filtro = AV103VisDel_Filtro;
         AV109Core_visitawwds_4_vissituacao = AV102VisSituacao;
         AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV101DynamicFiltersOperatorVisSituacao;
         AV111Core_visitawwds_6_tfvisinsdatahora = AV15TFVisInsDataHora;
         AV112Core_visitawwds_7_tfvisinsdatahora_to = AV16TFVisInsDataHora_To;
         AV113Core_visitawwds_8_tfvisinsusunome = AV19TFVisInsUsuNome;
         AV114Core_visitawwds_9_tfvisinsusunome_sel = AV20TFVisInsUsuNome_Sel;
         AV115Core_visitawwds_10_tfvisdata = AV21TFVisData;
         AV116Core_visitawwds_11_tfvisdata_to = AV22TFVisData_To;
         AV117Core_visitawwds_12_tfvishora = AV23TFVisHora;
         AV118Core_visitawwds_13_tfvishora_to = AV24TFVisHora_To;
         AV119Core_visitawwds_14_tfvisdatahora = AV25TFVisDataHora;
         AV120Core_visitawwds_15_tfvisdatahora_to = AV26TFVisDataHora_To;
         AV121Core_visitawwds_16_tfvisdatafim = AV95TFVisDataFim;
         AV122Core_visitawwds_17_tfvisdatafim_to = AV96TFVisDataFim_To;
         AV123Core_visitawwds_18_tfvishorafim = AV97TFVisHoraFim;
         AV124Core_visitawwds_19_tfvishorafim_to = AV98TFVisHoraFim_To;
         AV125Core_visitawwds_20_tfvisdatahorafim = AV99TFVisDataHoraFim;
         AV126Core_visitawwds_21_tfvisdatahorafim_to = AV100TFVisDataHoraFim_To;
         AV127Core_visitawwds_22_tfvistiponome = AV31TFVisTipoNome;
         AV128Core_visitawwds_23_tfvistiponome_sel = AV32TFVisTipoNome_Sel;
         AV129Core_visitawwds_24_tfvisassunto = AV37TFVisAssunto;
         AV130Core_visitawwds_25_tfvisassunto_sel = AV38TFVisAssunto_Sel;
         AV131Core_visitawwds_26_tfvissituacao_sels = AV92TFVisSituacao_Sels;
         AV132Core_visitawwds_27_tfvislink = AV39TFVisLink;
         AV133Core_visitawwds_28_tfvislink_sel = AV40TFVisLink_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels ,
                                              AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV109Core_visitawwds_4_vissituacao ,
                                              AV111Core_visitawwds_6_tfvisinsdatahora ,
                                              AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV113Core_visitawwds_8_tfvisinsusunome ,
                                              AV115Core_visitawwds_10_tfvisdata ,
                                              AV116Core_visitawwds_11_tfvisdata_to ,
                                              AV117Core_visitawwds_12_tfvishora ,
                                              AV118Core_visitawwds_13_tfvishora_to ,
                                              AV119Core_visitawwds_14_tfvisdatahora ,
                                              AV120Core_visitawwds_15_tfvisdatahora_to ,
                                              AV121Core_visitawwds_16_tfvisdatafim ,
                                              AV122Core_visitawwds_17_tfvisdatafim_to ,
                                              AV123Core_visitawwds_18_tfvishorafim ,
                                              AV124Core_visitawwds_19_tfvishorafim_to ,
                                              AV125Core_visitawwds_20_tfvisdatahorafim ,
                                              AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV128Core_visitawwds_23_tfvistiponome_sel ,
                                              AV127Core_visitawwds_22_tfvistiponome ,
                                              AV130Core_visitawwds_25_tfvisassunto_sel ,
                                              AV129Core_visitawwds_24_tfvisassunto ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV133Core_visitawwds_28_tfvislink_sel ,
                                              AV132Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              A487VisDel ,
                                              A418VisNegID ,
                                              AV88VisNegID ,
                                              A422VisNgfSeq ,
                                              AV89VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV113Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV127Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome), "%", "");
         lV129Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto), "%", "");
         lV132Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor P006C2 */
         pr_default.execute(0, new Object[] {AV88VisNegID, AV89VisNgfSeq, AV109Core_visitawwds_4_vissituacao, AV109Core_visitawwds_4_vissituacao, AV111Core_visitawwds_6_tfvisinsdatahora, AV112Core_visitawwds_7_tfvisinsdatahora_to, lV113Core_visitawwds_8_tfvisinsusunome, AV114Core_visitawwds_9_tfvisinsusunome_sel, AV115Core_visitawwds_10_tfvisdata, AV116Core_visitawwds_11_tfvisdata_to, AV117Core_visitawwds_12_tfvishora, AV118Core_visitawwds_13_tfvishora_to, AV119Core_visitawwds_14_tfvisdatahora, AV120Core_visitawwds_15_tfvisdatahora_to, AV121Core_visitawwds_16_tfvisdatafim, AV122Core_visitawwds_17_tfvisdatafim_to, AV123Core_visitawwds_18_tfvishorafim, AV124Core_visitawwds_19_tfvishorafim_to, AV125Core_visitawwds_20_tfvisdatahorafim, AV126Core_visitawwds_21_tfvisdatahorafim_to, lV127Core_visitawwds_22_tfvistiponome, AV128Core_visitawwds_23_tfvistiponome_sel, lV129Core_visitawwds_24_tfvisassunto, AV130Core_visitawwds_25_tfvisassunto_sel, lV132Core_visitawwds_27_tfvislink, AV133Core_visitawwds_28_tfvislink_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6C2 = false;
            A414VisTipoID = P006C2_A414VisTipoID[0];
            A418VisNegID = P006C2_A418VisNegID[0];
            n418VisNegID = P006C2_n418VisNegID[0];
            A422VisNgfSeq = P006C2_A422VisNgfSeq[0];
            n422VisNgfSeq = P006C2_n422VisNgfSeq[0];
            A403VisInsUsuNome = P006C2_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P006C2_n403VisInsUsuNome[0];
            A417VisLink = P006C2_A417VisLink[0];
            n417VisLink = P006C2_n417VisLink[0];
            A409VisAssunto = P006C2_A409VisAssunto[0];
            A416VisTipoNome = P006C2_A416VisTipoNome[0];
            A477VisDataHoraFim = P006C2_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P006C2_n477VisDataHoraFim[0];
            A476VisHoraFim = P006C2_A476VisHoraFim[0];
            n476VisHoraFim = P006C2_n476VisHoraFim[0];
            A475VisDataFim = P006C2_A475VisDataFim[0];
            n475VisDataFim = P006C2_n475VisDataFim[0];
            A406VisDataHora = P006C2_A406VisDataHora[0];
            A405VisHora = P006C2_A405VisHora[0];
            A404VisData = P006C2_A404VisData[0];
            A401VisInsDataHora = P006C2_A401VisInsDataHora[0];
            A472VisSituacao = P006C2_A472VisSituacao[0];
            A487VisDel = P006C2_A487VisDel[0];
            A398VisID = P006C2_A398VisID[0];
            A416VisTipoNome = P006C2_A416VisTipoNome[0];
            AV51count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006C2_A403VisInsUsuNome[0], A403VisInsUsuNome) == 0 ) )
            {
               BRK6C2 = false;
               A398VisID = P006C2_A398VisID[0];
               AV51count = (long)(AV51count+1);
               BRK6C2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV42SkipItems) )
            {
               AV46Option = (String.IsNullOrEmpty(StringUtil.RTrim( A403VisInsUsuNome)) ? "<#Empty#>" : A403VisInsUsuNome);
               AV47Options.Add(AV46Option, 0);
               AV50OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV51count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV47Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV42SkipItems = (short)(AV42SkipItems-1);
            }
            if ( ! BRK6C2 )
            {
               BRK6C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADVISTIPONOMEOPTIONS' Routine */
         returnInSub = false;
         AV31TFVisTipoNome = AV41SearchTxt;
         AV32TFVisTipoNome_Sel = "";
         AV106Core_visitawwds_1_visnegid_filtro = AV93VisNegID_Filtro;
         AV107Core_visitawwds_2_visngfseq_filtro = AV94VisNgfSeq_Filtro;
         AV108Core_visitawwds_3_visdel_filtro = AV103VisDel_Filtro;
         AV109Core_visitawwds_4_vissituacao = AV102VisSituacao;
         AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV101DynamicFiltersOperatorVisSituacao;
         AV111Core_visitawwds_6_tfvisinsdatahora = AV15TFVisInsDataHora;
         AV112Core_visitawwds_7_tfvisinsdatahora_to = AV16TFVisInsDataHora_To;
         AV113Core_visitawwds_8_tfvisinsusunome = AV19TFVisInsUsuNome;
         AV114Core_visitawwds_9_tfvisinsusunome_sel = AV20TFVisInsUsuNome_Sel;
         AV115Core_visitawwds_10_tfvisdata = AV21TFVisData;
         AV116Core_visitawwds_11_tfvisdata_to = AV22TFVisData_To;
         AV117Core_visitawwds_12_tfvishora = AV23TFVisHora;
         AV118Core_visitawwds_13_tfvishora_to = AV24TFVisHora_To;
         AV119Core_visitawwds_14_tfvisdatahora = AV25TFVisDataHora;
         AV120Core_visitawwds_15_tfvisdatahora_to = AV26TFVisDataHora_To;
         AV121Core_visitawwds_16_tfvisdatafim = AV95TFVisDataFim;
         AV122Core_visitawwds_17_tfvisdatafim_to = AV96TFVisDataFim_To;
         AV123Core_visitawwds_18_tfvishorafim = AV97TFVisHoraFim;
         AV124Core_visitawwds_19_tfvishorafim_to = AV98TFVisHoraFim_To;
         AV125Core_visitawwds_20_tfvisdatahorafim = AV99TFVisDataHoraFim;
         AV126Core_visitawwds_21_tfvisdatahorafim_to = AV100TFVisDataHoraFim_To;
         AV127Core_visitawwds_22_tfvistiponome = AV31TFVisTipoNome;
         AV128Core_visitawwds_23_tfvistiponome_sel = AV32TFVisTipoNome_Sel;
         AV129Core_visitawwds_24_tfvisassunto = AV37TFVisAssunto;
         AV130Core_visitawwds_25_tfvisassunto_sel = AV38TFVisAssunto_Sel;
         AV131Core_visitawwds_26_tfvissituacao_sels = AV92TFVisSituacao_Sels;
         AV132Core_visitawwds_27_tfvislink = AV39TFVisLink;
         AV133Core_visitawwds_28_tfvislink_sel = AV40TFVisLink_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels ,
                                              AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV109Core_visitawwds_4_vissituacao ,
                                              AV111Core_visitawwds_6_tfvisinsdatahora ,
                                              AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV113Core_visitawwds_8_tfvisinsusunome ,
                                              AV115Core_visitawwds_10_tfvisdata ,
                                              AV116Core_visitawwds_11_tfvisdata_to ,
                                              AV117Core_visitawwds_12_tfvishora ,
                                              AV118Core_visitawwds_13_tfvishora_to ,
                                              AV119Core_visitawwds_14_tfvisdatahora ,
                                              AV120Core_visitawwds_15_tfvisdatahora_to ,
                                              AV121Core_visitawwds_16_tfvisdatafim ,
                                              AV122Core_visitawwds_17_tfvisdatafim_to ,
                                              AV123Core_visitawwds_18_tfvishorafim ,
                                              AV124Core_visitawwds_19_tfvishorafim_to ,
                                              AV125Core_visitawwds_20_tfvisdatahorafim ,
                                              AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV128Core_visitawwds_23_tfvistiponome_sel ,
                                              AV127Core_visitawwds_22_tfvistiponome ,
                                              AV130Core_visitawwds_25_tfvisassunto_sel ,
                                              AV129Core_visitawwds_24_tfvisassunto ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV133Core_visitawwds_28_tfvislink_sel ,
                                              AV132Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              A487VisDel ,
                                              A418VisNegID ,
                                              AV88VisNegID ,
                                              A422VisNgfSeq ,
                                              AV89VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV113Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV127Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome), "%", "");
         lV129Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto), "%", "");
         lV132Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor P006C3 */
         pr_default.execute(1, new Object[] {AV88VisNegID, AV89VisNgfSeq, AV109Core_visitawwds_4_vissituacao, AV109Core_visitawwds_4_vissituacao, AV111Core_visitawwds_6_tfvisinsdatahora, AV112Core_visitawwds_7_tfvisinsdatahora_to, lV113Core_visitawwds_8_tfvisinsusunome, AV114Core_visitawwds_9_tfvisinsusunome_sel, AV115Core_visitawwds_10_tfvisdata, AV116Core_visitawwds_11_tfvisdata_to, AV117Core_visitawwds_12_tfvishora, AV118Core_visitawwds_13_tfvishora_to, AV119Core_visitawwds_14_tfvisdatahora, AV120Core_visitawwds_15_tfvisdatahora_to, AV121Core_visitawwds_16_tfvisdatafim, AV122Core_visitawwds_17_tfvisdatafim_to, AV123Core_visitawwds_18_tfvishorafim, AV124Core_visitawwds_19_tfvishorafim_to, AV125Core_visitawwds_20_tfvisdatahorafim, AV126Core_visitawwds_21_tfvisdatahorafim_to, lV127Core_visitawwds_22_tfvistiponome, AV128Core_visitawwds_23_tfvistiponome_sel, lV129Core_visitawwds_24_tfvisassunto, AV130Core_visitawwds_25_tfvisassunto_sel, lV132Core_visitawwds_27_tfvislink, AV133Core_visitawwds_28_tfvislink_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6C4 = false;
            A414VisTipoID = P006C3_A414VisTipoID[0];
            A417VisLink = P006C3_A417VisLink[0];
            n417VisLink = P006C3_n417VisLink[0];
            A409VisAssunto = P006C3_A409VisAssunto[0];
            A416VisTipoNome = P006C3_A416VisTipoNome[0];
            A477VisDataHoraFim = P006C3_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P006C3_n477VisDataHoraFim[0];
            A476VisHoraFim = P006C3_A476VisHoraFim[0];
            n476VisHoraFim = P006C3_n476VisHoraFim[0];
            A475VisDataFim = P006C3_A475VisDataFim[0];
            n475VisDataFim = P006C3_n475VisDataFim[0];
            A406VisDataHora = P006C3_A406VisDataHora[0];
            A405VisHora = P006C3_A405VisHora[0];
            A404VisData = P006C3_A404VisData[0];
            A403VisInsUsuNome = P006C3_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P006C3_n403VisInsUsuNome[0];
            A401VisInsDataHora = P006C3_A401VisInsDataHora[0];
            A472VisSituacao = P006C3_A472VisSituacao[0];
            A487VisDel = P006C3_A487VisDel[0];
            A422VisNgfSeq = P006C3_A422VisNgfSeq[0];
            n422VisNgfSeq = P006C3_n422VisNgfSeq[0];
            A418VisNegID = P006C3_A418VisNegID[0];
            n418VisNegID = P006C3_n418VisNegID[0];
            A398VisID = P006C3_A398VisID[0];
            A416VisTipoNome = P006C3_A416VisTipoNome[0];
            AV51count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006C3_A414VisTipoID[0] == A414VisTipoID ) )
            {
               BRK6C4 = false;
               A398VisID = P006C3_A398VisID[0];
               AV51count = (long)(AV51count+1);
               BRK6C4 = true;
               pr_default.readNext(1);
            }
            AV46Option = (String.IsNullOrEmpty(StringUtil.RTrim( A416VisTipoNome)) ? "<#Empty#>" : A416VisTipoNome);
            AV45InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV46Option, "<#Empty#>") != 0 ) && ( AV45InsertIndex <= AV47Options.Count ) && ( ( StringUtil.StrCmp(((string)AV47Options.Item(AV45InsertIndex)), AV46Option) < 0 ) || ( StringUtil.StrCmp(((string)AV47Options.Item(AV45InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV45InsertIndex = (int)(AV45InsertIndex+1);
            }
            AV47Options.Add(AV46Option, AV45InsertIndex);
            AV50OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV51count), "Z,ZZZ,ZZZ,ZZ9")), AV45InsertIndex);
            if ( AV47Options.Count == AV42SkipItems + 11 )
            {
               AV47Options.RemoveItem(AV47Options.Count);
               AV50OptionIndexes.RemoveItem(AV50OptionIndexes.Count);
            }
            if ( ! BRK6C4 )
            {
               BRK6C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV42SkipItems > 0 )
         {
            AV47Options.RemoveItem(1);
            AV50OptionIndexes.RemoveItem(1);
            AV42SkipItems = (short)(AV42SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADVISASSUNTOOPTIONS' Routine */
         returnInSub = false;
         AV37TFVisAssunto = AV41SearchTxt;
         AV38TFVisAssunto_Sel = "";
         AV106Core_visitawwds_1_visnegid_filtro = AV93VisNegID_Filtro;
         AV107Core_visitawwds_2_visngfseq_filtro = AV94VisNgfSeq_Filtro;
         AV108Core_visitawwds_3_visdel_filtro = AV103VisDel_Filtro;
         AV109Core_visitawwds_4_vissituacao = AV102VisSituacao;
         AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV101DynamicFiltersOperatorVisSituacao;
         AV111Core_visitawwds_6_tfvisinsdatahora = AV15TFVisInsDataHora;
         AV112Core_visitawwds_7_tfvisinsdatahora_to = AV16TFVisInsDataHora_To;
         AV113Core_visitawwds_8_tfvisinsusunome = AV19TFVisInsUsuNome;
         AV114Core_visitawwds_9_tfvisinsusunome_sel = AV20TFVisInsUsuNome_Sel;
         AV115Core_visitawwds_10_tfvisdata = AV21TFVisData;
         AV116Core_visitawwds_11_tfvisdata_to = AV22TFVisData_To;
         AV117Core_visitawwds_12_tfvishora = AV23TFVisHora;
         AV118Core_visitawwds_13_tfvishora_to = AV24TFVisHora_To;
         AV119Core_visitawwds_14_tfvisdatahora = AV25TFVisDataHora;
         AV120Core_visitawwds_15_tfvisdatahora_to = AV26TFVisDataHora_To;
         AV121Core_visitawwds_16_tfvisdatafim = AV95TFVisDataFim;
         AV122Core_visitawwds_17_tfvisdatafim_to = AV96TFVisDataFim_To;
         AV123Core_visitawwds_18_tfvishorafim = AV97TFVisHoraFim;
         AV124Core_visitawwds_19_tfvishorafim_to = AV98TFVisHoraFim_To;
         AV125Core_visitawwds_20_tfvisdatahorafim = AV99TFVisDataHoraFim;
         AV126Core_visitawwds_21_tfvisdatahorafim_to = AV100TFVisDataHoraFim_To;
         AV127Core_visitawwds_22_tfvistiponome = AV31TFVisTipoNome;
         AV128Core_visitawwds_23_tfvistiponome_sel = AV32TFVisTipoNome_Sel;
         AV129Core_visitawwds_24_tfvisassunto = AV37TFVisAssunto;
         AV130Core_visitawwds_25_tfvisassunto_sel = AV38TFVisAssunto_Sel;
         AV131Core_visitawwds_26_tfvissituacao_sels = AV92TFVisSituacao_Sels;
         AV132Core_visitawwds_27_tfvislink = AV39TFVisLink;
         AV133Core_visitawwds_28_tfvislink_sel = AV40TFVisLink_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels ,
                                              AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV109Core_visitawwds_4_vissituacao ,
                                              AV111Core_visitawwds_6_tfvisinsdatahora ,
                                              AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV113Core_visitawwds_8_tfvisinsusunome ,
                                              AV115Core_visitawwds_10_tfvisdata ,
                                              AV116Core_visitawwds_11_tfvisdata_to ,
                                              AV117Core_visitawwds_12_tfvishora ,
                                              AV118Core_visitawwds_13_tfvishora_to ,
                                              AV119Core_visitawwds_14_tfvisdatahora ,
                                              AV120Core_visitawwds_15_tfvisdatahora_to ,
                                              AV121Core_visitawwds_16_tfvisdatafim ,
                                              AV122Core_visitawwds_17_tfvisdatafim_to ,
                                              AV123Core_visitawwds_18_tfvishorafim ,
                                              AV124Core_visitawwds_19_tfvishorafim_to ,
                                              AV125Core_visitawwds_20_tfvisdatahorafim ,
                                              AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV128Core_visitawwds_23_tfvistiponome_sel ,
                                              AV127Core_visitawwds_22_tfvistiponome ,
                                              AV130Core_visitawwds_25_tfvisassunto_sel ,
                                              AV129Core_visitawwds_24_tfvisassunto ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV133Core_visitawwds_28_tfvislink_sel ,
                                              AV132Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              A487VisDel ,
                                              A418VisNegID ,
                                              AV88VisNegID ,
                                              A422VisNgfSeq ,
                                              AV89VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV113Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV127Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome), "%", "");
         lV129Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto), "%", "");
         lV132Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor P006C4 */
         pr_default.execute(2, new Object[] {AV88VisNegID, AV89VisNgfSeq, AV109Core_visitawwds_4_vissituacao, AV109Core_visitawwds_4_vissituacao, AV111Core_visitawwds_6_tfvisinsdatahora, AV112Core_visitawwds_7_tfvisinsdatahora_to, lV113Core_visitawwds_8_tfvisinsusunome, AV114Core_visitawwds_9_tfvisinsusunome_sel, AV115Core_visitawwds_10_tfvisdata, AV116Core_visitawwds_11_tfvisdata_to, AV117Core_visitawwds_12_tfvishora, AV118Core_visitawwds_13_tfvishora_to, AV119Core_visitawwds_14_tfvisdatahora, AV120Core_visitawwds_15_tfvisdatahora_to, AV121Core_visitawwds_16_tfvisdatafim, AV122Core_visitawwds_17_tfvisdatafim_to, AV123Core_visitawwds_18_tfvishorafim, AV124Core_visitawwds_19_tfvishorafim_to, AV125Core_visitawwds_20_tfvisdatahorafim, AV126Core_visitawwds_21_tfvisdatahorafim_to, lV127Core_visitawwds_22_tfvistiponome, AV128Core_visitawwds_23_tfvistiponome_sel, lV129Core_visitawwds_24_tfvisassunto, AV130Core_visitawwds_25_tfvisassunto_sel, lV132Core_visitawwds_27_tfvislink, AV133Core_visitawwds_28_tfvislink_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6C6 = false;
            A414VisTipoID = P006C4_A414VisTipoID[0];
            A418VisNegID = P006C4_A418VisNegID[0];
            n418VisNegID = P006C4_n418VisNegID[0];
            A422VisNgfSeq = P006C4_A422VisNgfSeq[0];
            n422VisNgfSeq = P006C4_n422VisNgfSeq[0];
            A409VisAssunto = P006C4_A409VisAssunto[0];
            A417VisLink = P006C4_A417VisLink[0];
            n417VisLink = P006C4_n417VisLink[0];
            A416VisTipoNome = P006C4_A416VisTipoNome[0];
            A477VisDataHoraFim = P006C4_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P006C4_n477VisDataHoraFim[0];
            A476VisHoraFim = P006C4_A476VisHoraFim[0];
            n476VisHoraFim = P006C4_n476VisHoraFim[0];
            A475VisDataFim = P006C4_A475VisDataFim[0];
            n475VisDataFim = P006C4_n475VisDataFim[0];
            A406VisDataHora = P006C4_A406VisDataHora[0];
            A405VisHora = P006C4_A405VisHora[0];
            A404VisData = P006C4_A404VisData[0];
            A403VisInsUsuNome = P006C4_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P006C4_n403VisInsUsuNome[0];
            A401VisInsDataHora = P006C4_A401VisInsDataHora[0];
            A472VisSituacao = P006C4_A472VisSituacao[0];
            A487VisDel = P006C4_A487VisDel[0];
            A398VisID = P006C4_A398VisID[0];
            A416VisTipoNome = P006C4_A416VisTipoNome[0];
            AV51count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006C4_A409VisAssunto[0], A409VisAssunto) == 0 ) )
            {
               BRK6C6 = false;
               A398VisID = P006C4_A398VisID[0];
               AV51count = (long)(AV51count+1);
               BRK6C6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV42SkipItems) )
            {
               AV46Option = (String.IsNullOrEmpty(StringUtil.RTrim( A409VisAssunto)) ? "<#Empty#>" : A409VisAssunto);
               AV47Options.Add(AV46Option, 0);
               AV50OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV51count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV47Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV42SkipItems = (short)(AV42SkipItems-1);
            }
            if ( ! BRK6C6 )
            {
               BRK6C6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADVISLINKOPTIONS' Routine */
         returnInSub = false;
         AV39TFVisLink = AV41SearchTxt;
         AV40TFVisLink_Sel = "";
         AV106Core_visitawwds_1_visnegid_filtro = AV93VisNegID_Filtro;
         AV107Core_visitawwds_2_visngfseq_filtro = AV94VisNgfSeq_Filtro;
         AV108Core_visitawwds_3_visdel_filtro = AV103VisDel_Filtro;
         AV109Core_visitawwds_4_vissituacao = AV102VisSituacao;
         AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV101DynamicFiltersOperatorVisSituacao;
         AV111Core_visitawwds_6_tfvisinsdatahora = AV15TFVisInsDataHora;
         AV112Core_visitawwds_7_tfvisinsdatahora_to = AV16TFVisInsDataHora_To;
         AV113Core_visitawwds_8_tfvisinsusunome = AV19TFVisInsUsuNome;
         AV114Core_visitawwds_9_tfvisinsusunome_sel = AV20TFVisInsUsuNome_Sel;
         AV115Core_visitawwds_10_tfvisdata = AV21TFVisData;
         AV116Core_visitawwds_11_tfvisdata_to = AV22TFVisData_To;
         AV117Core_visitawwds_12_tfvishora = AV23TFVisHora;
         AV118Core_visitawwds_13_tfvishora_to = AV24TFVisHora_To;
         AV119Core_visitawwds_14_tfvisdatahora = AV25TFVisDataHora;
         AV120Core_visitawwds_15_tfvisdatahora_to = AV26TFVisDataHora_To;
         AV121Core_visitawwds_16_tfvisdatafim = AV95TFVisDataFim;
         AV122Core_visitawwds_17_tfvisdatafim_to = AV96TFVisDataFim_To;
         AV123Core_visitawwds_18_tfvishorafim = AV97TFVisHoraFim;
         AV124Core_visitawwds_19_tfvishorafim_to = AV98TFVisHoraFim_To;
         AV125Core_visitawwds_20_tfvisdatahorafim = AV99TFVisDataHoraFim;
         AV126Core_visitawwds_21_tfvisdatahorafim_to = AV100TFVisDataHoraFim_To;
         AV127Core_visitawwds_22_tfvistiponome = AV31TFVisTipoNome;
         AV128Core_visitawwds_23_tfvistiponome_sel = AV32TFVisTipoNome_Sel;
         AV129Core_visitawwds_24_tfvisassunto = AV37TFVisAssunto;
         AV130Core_visitawwds_25_tfvisassunto_sel = AV38TFVisAssunto_Sel;
         AV131Core_visitawwds_26_tfvissituacao_sels = AV92TFVisSituacao_Sels;
         AV132Core_visitawwds_27_tfvislink = AV39TFVisLink;
         AV133Core_visitawwds_28_tfvislink_sel = AV40TFVisLink_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels ,
                                              AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV109Core_visitawwds_4_vissituacao ,
                                              AV111Core_visitawwds_6_tfvisinsdatahora ,
                                              AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV113Core_visitawwds_8_tfvisinsusunome ,
                                              AV115Core_visitawwds_10_tfvisdata ,
                                              AV116Core_visitawwds_11_tfvisdata_to ,
                                              AV117Core_visitawwds_12_tfvishora ,
                                              AV118Core_visitawwds_13_tfvishora_to ,
                                              AV119Core_visitawwds_14_tfvisdatahora ,
                                              AV120Core_visitawwds_15_tfvisdatahora_to ,
                                              AV121Core_visitawwds_16_tfvisdatafim ,
                                              AV122Core_visitawwds_17_tfvisdatafim_to ,
                                              AV123Core_visitawwds_18_tfvishorafim ,
                                              AV124Core_visitawwds_19_tfvishorafim_to ,
                                              AV125Core_visitawwds_20_tfvisdatahorafim ,
                                              AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV128Core_visitawwds_23_tfvistiponome_sel ,
                                              AV127Core_visitawwds_22_tfvistiponome ,
                                              AV130Core_visitawwds_25_tfvisassunto_sel ,
                                              AV129Core_visitawwds_24_tfvisassunto ,
                                              AV131Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV133Core_visitawwds_28_tfvislink_sel ,
                                              AV132Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              A487VisDel ,
                                              A418VisNegID ,
                                              AV88VisNegID ,
                                              A422VisNgfSeq ,
                                              AV89VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV113Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV127Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome), "%", "");
         lV129Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto), "%", "");
         lV132Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor P006C5 */
         pr_default.execute(3, new Object[] {AV88VisNegID, AV89VisNgfSeq, AV109Core_visitawwds_4_vissituacao, AV109Core_visitawwds_4_vissituacao, AV111Core_visitawwds_6_tfvisinsdatahora, AV112Core_visitawwds_7_tfvisinsdatahora_to, lV113Core_visitawwds_8_tfvisinsusunome, AV114Core_visitawwds_9_tfvisinsusunome_sel, AV115Core_visitawwds_10_tfvisdata, AV116Core_visitawwds_11_tfvisdata_to, AV117Core_visitawwds_12_tfvishora, AV118Core_visitawwds_13_tfvishora_to, AV119Core_visitawwds_14_tfvisdatahora, AV120Core_visitawwds_15_tfvisdatahora_to, AV121Core_visitawwds_16_tfvisdatafim, AV122Core_visitawwds_17_tfvisdatafim_to, AV123Core_visitawwds_18_tfvishorafim, AV124Core_visitawwds_19_tfvishorafim_to, AV125Core_visitawwds_20_tfvisdatahorafim, AV126Core_visitawwds_21_tfvisdatahorafim_to, lV127Core_visitawwds_22_tfvistiponome, AV128Core_visitawwds_23_tfvistiponome_sel, lV129Core_visitawwds_24_tfvisassunto, AV130Core_visitawwds_25_tfvisassunto_sel, lV132Core_visitawwds_27_tfvislink, AV133Core_visitawwds_28_tfvislink_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6C8 = false;
            A414VisTipoID = P006C5_A414VisTipoID[0];
            A418VisNegID = P006C5_A418VisNegID[0];
            n418VisNegID = P006C5_n418VisNegID[0];
            A422VisNgfSeq = P006C5_A422VisNgfSeq[0];
            n422VisNgfSeq = P006C5_n422VisNgfSeq[0];
            A417VisLink = P006C5_A417VisLink[0];
            n417VisLink = P006C5_n417VisLink[0];
            A409VisAssunto = P006C5_A409VisAssunto[0];
            A416VisTipoNome = P006C5_A416VisTipoNome[0];
            A477VisDataHoraFim = P006C5_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P006C5_n477VisDataHoraFim[0];
            A476VisHoraFim = P006C5_A476VisHoraFim[0];
            n476VisHoraFim = P006C5_n476VisHoraFim[0];
            A475VisDataFim = P006C5_A475VisDataFim[0];
            n475VisDataFim = P006C5_n475VisDataFim[0];
            A406VisDataHora = P006C5_A406VisDataHora[0];
            A405VisHora = P006C5_A405VisHora[0];
            A404VisData = P006C5_A404VisData[0];
            A403VisInsUsuNome = P006C5_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P006C5_n403VisInsUsuNome[0];
            A401VisInsDataHora = P006C5_A401VisInsDataHora[0];
            A472VisSituacao = P006C5_A472VisSituacao[0];
            A487VisDel = P006C5_A487VisDel[0];
            A398VisID = P006C5_A398VisID[0];
            A416VisTipoNome = P006C5_A416VisTipoNome[0];
            AV51count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006C5_A417VisLink[0], A417VisLink) == 0 ) )
            {
               BRK6C8 = false;
               A398VisID = P006C5_A398VisID[0];
               AV51count = (long)(AV51count+1);
               BRK6C8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV42SkipItems) )
            {
               AV46Option = (String.IsNullOrEmpty(StringUtil.RTrim( A417VisLink)) ? "<#Empty#>" : A417VisLink);
               AV47Options.Add(AV46Option, 0);
               AV50OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV51count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV47Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV42SkipItems = (short)(AV42SkipItems-1);
            }
            if ( ! BRK6C8 )
            {
               BRK6C8 = true;
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
         AV60OptionsJson = "";
         AV61OptionsDescJson = "";
         AV62OptionIndexesJson = "";
         AV47Options = new GxSimpleCollection<string>();
         AV49OptionsDesc = new GxSimpleCollection<string>();
         AV50OptionIndexes = new GxSimpleCollection<string>();
         AV41SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV52Session = context.GetSession();
         AV54GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV55GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV93VisNegID_Filtro = Guid.Empty;
         AV102VisSituacao = "PEN";
         AV15TFVisInsDataHora = (DateTime)(DateTime.MinValue);
         AV16TFVisInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV19TFVisInsUsuNome = "";
         AV20TFVisInsUsuNome_Sel = "";
         AV21TFVisData = DateTime.MinValue;
         AV22TFVisData_To = DateTime.MinValue;
         AV23TFVisHora = (DateTime)(DateTime.MinValue);
         AV24TFVisHora_To = (DateTime)(DateTime.MinValue);
         AV25TFVisDataHora = (DateTime)(DateTime.MinValue);
         AV26TFVisDataHora_To = (DateTime)(DateTime.MinValue);
         AV95TFVisDataFim = DateTime.MinValue;
         AV96TFVisDataFim_To = DateTime.MinValue;
         AV97TFVisHoraFim = (DateTime)(DateTime.MinValue);
         AV98TFVisHoraFim_To = (DateTime)(DateTime.MinValue);
         AV99TFVisDataHoraFim = (DateTime)(DateTime.MinValue);
         AV100TFVisDataHoraFim_To = (DateTime)(DateTime.MinValue);
         AV31TFVisTipoNome = "";
         AV32TFVisTipoNome_Sel = "";
         AV37TFVisAssunto = "";
         AV38TFVisAssunto_Sel = "";
         AV91TFVisSituacao_SelsJson = "";
         AV92TFVisSituacao_Sels = new GxSimpleCollection<string>();
         AV39TFVisLink = "";
         AV40TFVisLink_Sel = "";
         AV88VisNegID = Guid.Empty;
         AV106Core_visitawwds_1_visnegid_filtro = Guid.Empty;
         AV109Core_visitawwds_4_vissituacao = "";
         AV111Core_visitawwds_6_tfvisinsdatahora = (DateTime)(DateTime.MinValue);
         AV112Core_visitawwds_7_tfvisinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV113Core_visitawwds_8_tfvisinsusunome = "";
         AV114Core_visitawwds_9_tfvisinsusunome_sel = "";
         AV115Core_visitawwds_10_tfvisdata = DateTime.MinValue;
         AV116Core_visitawwds_11_tfvisdata_to = DateTime.MinValue;
         AV117Core_visitawwds_12_tfvishora = (DateTime)(DateTime.MinValue);
         AV118Core_visitawwds_13_tfvishora_to = (DateTime)(DateTime.MinValue);
         AV119Core_visitawwds_14_tfvisdatahora = (DateTime)(DateTime.MinValue);
         AV120Core_visitawwds_15_tfvisdatahora_to = (DateTime)(DateTime.MinValue);
         AV121Core_visitawwds_16_tfvisdatafim = DateTime.MinValue;
         AV122Core_visitawwds_17_tfvisdatafim_to = DateTime.MinValue;
         AV123Core_visitawwds_18_tfvishorafim = (DateTime)(DateTime.MinValue);
         AV124Core_visitawwds_19_tfvishorafim_to = (DateTime)(DateTime.MinValue);
         AV125Core_visitawwds_20_tfvisdatahorafim = (DateTime)(DateTime.MinValue);
         AV126Core_visitawwds_21_tfvisdatahorafim_to = (DateTime)(DateTime.MinValue);
         AV127Core_visitawwds_22_tfvistiponome = "";
         AV128Core_visitawwds_23_tfvistiponome_sel = "";
         AV129Core_visitawwds_24_tfvisassunto = "";
         AV130Core_visitawwds_25_tfvisassunto_sel = "";
         AV131Core_visitawwds_26_tfvissituacao_sels = new GxSimpleCollection<string>();
         AV132Core_visitawwds_27_tfvislink = "";
         AV133Core_visitawwds_28_tfvislink_sel = "";
         scmdbuf = "";
         lV113Core_visitawwds_8_tfvisinsusunome = "";
         lV127Core_visitawwds_22_tfvistiponome = "";
         lV129Core_visitawwds_24_tfvisassunto = "";
         lV132Core_visitawwds_27_tfvislink = "";
         A472VisSituacao = "";
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A403VisInsUsuNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A416VisTipoNome = "";
         A409VisAssunto = "";
         A417VisLink = "";
         A418VisNegID = Guid.Empty;
         P006C2_A414VisTipoID = new int[1] ;
         P006C2_A418VisNegID = new Guid[] {Guid.Empty} ;
         P006C2_n418VisNegID = new bool[] {false} ;
         P006C2_A422VisNgfSeq = new int[1] ;
         P006C2_n422VisNgfSeq = new bool[] {false} ;
         P006C2_A403VisInsUsuNome = new string[] {""} ;
         P006C2_n403VisInsUsuNome = new bool[] {false} ;
         P006C2_A417VisLink = new string[] {""} ;
         P006C2_n417VisLink = new bool[] {false} ;
         P006C2_A409VisAssunto = new string[] {""} ;
         P006C2_A416VisTipoNome = new string[] {""} ;
         P006C2_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C2_n477VisDataHoraFim = new bool[] {false} ;
         P006C2_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C2_n476VisHoraFim = new bool[] {false} ;
         P006C2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P006C2_n475VisDataFim = new bool[] {false} ;
         P006C2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C2_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P006C2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P006C2_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C2_A472VisSituacao = new string[] {""} ;
         P006C2_A487VisDel = new bool[] {false} ;
         P006C2_A398VisID = new Guid[] {Guid.Empty} ;
         A398VisID = Guid.Empty;
         AV46Option = "";
         P006C3_A414VisTipoID = new int[1] ;
         P006C3_A417VisLink = new string[] {""} ;
         P006C3_n417VisLink = new bool[] {false} ;
         P006C3_A409VisAssunto = new string[] {""} ;
         P006C3_A416VisTipoNome = new string[] {""} ;
         P006C3_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C3_n477VisDataHoraFim = new bool[] {false} ;
         P006C3_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C3_n476VisHoraFim = new bool[] {false} ;
         P006C3_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P006C3_n475VisDataFim = new bool[] {false} ;
         P006C3_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C3_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P006C3_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P006C3_A403VisInsUsuNome = new string[] {""} ;
         P006C3_n403VisInsUsuNome = new bool[] {false} ;
         P006C3_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C3_A472VisSituacao = new string[] {""} ;
         P006C3_A487VisDel = new bool[] {false} ;
         P006C3_A422VisNgfSeq = new int[1] ;
         P006C3_n422VisNgfSeq = new bool[] {false} ;
         P006C3_A418VisNegID = new Guid[] {Guid.Empty} ;
         P006C3_n418VisNegID = new bool[] {false} ;
         P006C3_A398VisID = new Guid[] {Guid.Empty} ;
         P006C4_A414VisTipoID = new int[1] ;
         P006C4_A418VisNegID = new Guid[] {Guid.Empty} ;
         P006C4_n418VisNegID = new bool[] {false} ;
         P006C4_A422VisNgfSeq = new int[1] ;
         P006C4_n422VisNgfSeq = new bool[] {false} ;
         P006C4_A409VisAssunto = new string[] {""} ;
         P006C4_A417VisLink = new string[] {""} ;
         P006C4_n417VisLink = new bool[] {false} ;
         P006C4_A416VisTipoNome = new string[] {""} ;
         P006C4_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C4_n477VisDataHoraFim = new bool[] {false} ;
         P006C4_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C4_n476VisHoraFim = new bool[] {false} ;
         P006C4_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P006C4_n475VisDataFim = new bool[] {false} ;
         P006C4_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C4_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P006C4_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P006C4_A403VisInsUsuNome = new string[] {""} ;
         P006C4_n403VisInsUsuNome = new bool[] {false} ;
         P006C4_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C4_A472VisSituacao = new string[] {""} ;
         P006C4_A487VisDel = new bool[] {false} ;
         P006C4_A398VisID = new Guid[] {Guid.Empty} ;
         P006C5_A414VisTipoID = new int[1] ;
         P006C5_A418VisNegID = new Guid[] {Guid.Empty} ;
         P006C5_n418VisNegID = new bool[] {false} ;
         P006C5_A422VisNgfSeq = new int[1] ;
         P006C5_n422VisNgfSeq = new bool[] {false} ;
         P006C5_A417VisLink = new string[] {""} ;
         P006C5_n417VisLink = new bool[] {false} ;
         P006C5_A409VisAssunto = new string[] {""} ;
         P006C5_A416VisTipoNome = new string[] {""} ;
         P006C5_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C5_n477VisDataHoraFim = new bool[] {false} ;
         P006C5_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006C5_n476VisHoraFim = new bool[] {false} ;
         P006C5_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P006C5_n475VisDataFim = new bool[] {false} ;
         P006C5_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C5_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P006C5_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P006C5_A403VisInsUsuNome = new string[] {""} ;
         P006C5_n403VisInsUsuNome = new bool[] {false} ;
         P006C5_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006C5_A472VisSituacao = new string[] {""} ;
         P006C5_A487VisDel = new bool[] {false} ;
         P006C5_A398VisID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006C2_A414VisTipoID, P006C2_A418VisNegID, P006C2_n418VisNegID, P006C2_A422VisNgfSeq, P006C2_n422VisNgfSeq, P006C2_A403VisInsUsuNome, P006C2_n403VisInsUsuNome, P006C2_A417VisLink, P006C2_n417VisLink, P006C2_A409VisAssunto,
               P006C2_A416VisTipoNome, P006C2_A477VisDataHoraFim, P006C2_n477VisDataHoraFim, P006C2_A476VisHoraFim, P006C2_n476VisHoraFim, P006C2_A475VisDataFim, P006C2_n475VisDataFim, P006C2_A406VisDataHora, P006C2_A405VisHora, P006C2_A404VisData,
               P006C2_A401VisInsDataHora, P006C2_A472VisSituacao, P006C2_A487VisDel, P006C2_A398VisID
               }
               , new Object[] {
               P006C3_A414VisTipoID, P006C3_A417VisLink, P006C3_n417VisLink, P006C3_A409VisAssunto, P006C3_A416VisTipoNome, P006C3_A477VisDataHoraFim, P006C3_n477VisDataHoraFim, P006C3_A476VisHoraFim, P006C3_n476VisHoraFim, P006C3_A475VisDataFim,
               P006C3_n475VisDataFim, P006C3_A406VisDataHora, P006C3_A405VisHora, P006C3_A404VisData, P006C3_A403VisInsUsuNome, P006C3_n403VisInsUsuNome, P006C3_A401VisInsDataHora, P006C3_A472VisSituacao, P006C3_A487VisDel, P006C3_A422VisNgfSeq,
               P006C3_n422VisNgfSeq, P006C3_A418VisNegID, P006C3_n418VisNegID, P006C3_A398VisID
               }
               , new Object[] {
               P006C4_A414VisTipoID, P006C4_A418VisNegID, P006C4_n418VisNegID, P006C4_A422VisNgfSeq, P006C4_n422VisNgfSeq, P006C4_A409VisAssunto, P006C4_A417VisLink, P006C4_n417VisLink, P006C4_A416VisTipoNome, P006C4_A477VisDataHoraFim,
               P006C4_n477VisDataHoraFim, P006C4_A476VisHoraFim, P006C4_n476VisHoraFim, P006C4_A475VisDataFim, P006C4_n475VisDataFim, P006C4_A406VisDataHora, P006C4_A405VisHora, P006C4_A404VisData, P006C4_A403VisInsUsuNome, P006C4_n403VisInsUsuNome,
               P006C4_A401VisInsDataHora, P006C4_A472VisSituacao, P006C4_A487VisDel, P006C4_A398VisID
               }
               , new Object[] {
               P006C5_A414VisTipoID, P006C5_A418VisNegID, P006C5_n418VisNegID, P006C5_A422VisNgfSeq, P006C5_n422VisNgfSeq, P006C5_A417VisLink, P006C5_n417VisLink, P006C5_A409VisAssunto, P006C5_A416VisTipoNome, P006C5_A477VisDataHoraFim,
               P006C5_n477VisDataHoraFim, P006C5_A476VisHoraFim, P006C5_n476VisHoraFim, P006C5_A475VisDataFim, P006C5_n475VisDataFim, P006C5_A406VisDataHora, P006C5_A405VisHora, P006C5_A404VisData, P006C5_A403VisInsUsuNome, P006C5_n403VisInsUsuNome,
               P006C5_A401VisInsDataHora, P006C5_A472VisSituacao, P006C5_A487VisDel, P006C5_A398VisID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV44MaxItems ;
      private short AV43PageIndex ;
      private short AV42SkipItems ;
      private short AV101DynamicFiltersOperatorVisSituacao ;
      private short AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ;
      private int AV104GXV1 ;
      private int AV94VisNgfSeq_Filtro ;
      private int AV89VisNgfSeq ;
      private int AV107Core_visitawwds_2_visngfseq_filtro ;
      private int AV131Core_visitawwds_26_tfvissituacao_sels_Count ;
      private int A422VisNgfSeq ;
      private int A414VisTipoID ;
      private int AV45InsertIndex ;
      private long AV51count ;
      private string scmdbuf ;
      private DateTime AV15TFVisInsDataHora ;
      private DateTime AV16TFVisInsDataHora_To ;
      private DateTime AV23TFVisHora ;
      private DateTime AV24TFVisHora_To ;
      private DateTime AV25TFVisDataHora ;
      private DateTime AV26TFVisDataHora_To ;
      private DateTime AV97TFVisHoraFim ;
      private DateTime AV98TFVisHoraFim_To ;
      private DateTime AV99TFVisDataHoraFim ;
      private DateTime AV100TFVisDataHoraFim_To ;
      private DateTime AV111Core_visitawwds_6_tfvisinsdatahora ;
      private DateTime AV112Core_visitawwds_7_tfvisinsdatahora_to ;
      private DateTime AV117Core_visitawwds_12_tfvishora ;
      private DateTime AV118Core_visitawwds_13_tfvishora_to ;
      private DateTime AV119Core_visitawwds_14_tfvisdatahora ;
      private DateTime AV120Core_visitawwds_15_tfvisdatahora_to ;
      private DateTime AV123Core_visitawwds_18_tfvishorafim ;
      private DateTime AV124Core_visitawwds_19_tfvishorafim_to ;
      private DateTime AV125Core_visitawwds_20_tfvisdatahorafim ;
      private DateTime AV126Core_visitawwds_21_tfvisdatahorafim_to ;
      private DateTime A401VisInsDataHora ;
      private DateTime A405VisHora ;
      private DateTime A406VisDataHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime AV21TFVisData ;
      private DateTime AV22TFVisData_To ;
      private DateTime AV95TFVisDataFim ;
      private DateTime AV96TFVisDataFim_To ;
      private DateTime AV115Core_visitawwds_10_tfvisdata ;
      private DateTime AV116Core_visitawwds_11_tfvisdata_to ;
      private DateTime AV121Core_visitawwds_16_tfvisdatafim ;
      private DateTime AV122Core_visitawwds_17_tfvisdatafim_to ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private bool returnInSub ;
      private bool AV103VisDel_Filtro ;
      private bool AV108Core_visitawwds_3_visdel_filtro ;
      private bool A487VisDel ;
      private bool BRK6C2 ;
      private bool n418VisNegID ;
      private bool n422VisNgfSeq ;
      private bool n403VisInsUsuNome ;
      private bool n417VisLink ;
      private bool n477VisDataHoraFim ;
      private bool n476VisHoraFim ;
      private bool n475VisDataFim ;
      private bool BRK6C4 ;
      private bool BRK6C6 ;
      private bool BRK6C8 ;
      private string AV60OptionsJson ;
      private string AV61OptionsDescJson ;
      private string AV62OptionIndexesJson ;
      private string AV91TFVisSituacao_SelsJson ;
      private string AV57DDOName ;
      private string AV58SearchTxtParms ;
      private string AV59SearchTxtTo ;
      private string AV41SearchTxt ;
      private string AV102VisSituacao ;
      private string AV19TFVisInsUsuNome ;
      private string AV20TFVisInsUsuNome_Sel ;
      private string AV31TFVisTipoNome ;
      private string AV32TFVisTipoNome_Sel ;
      private string AV37TFVisAssunto ;
      private string AV38TFVisAssunto_Sel ;
      private string AV39TFVisLink ;
      private string AV40TFVisLink_Sel ;
      private string AV109Core_visitawwds_4_vissituacao ;
      private string AV113Core_visitawwds_8_tfvisinsusunome ;
      private string AV114Core_visitawwds_9_tfvisinsusunome_sel ;
      private string AV127Core_visitawwds_22_tfvistiponome ;
      private string AV128Core_visitawwds_23_tfvistiponome_sel ;
      private string AV129Core_visitawwds_24_tfvisassunto ;
      private string AV130Core_visitawwds_25_tfvisassunto_sel ;
      private string AV132Core_visitawwds_27_tfvislink ;
      private string AV133Core_visitawwds_28_tfvislink_sel ;
      private string lV113Core_visitawwds_8_tfvisinsusunome ;
      private string lV127Core_visitawwds_22_tfvistiponome ;
      private string lV129Core_visitawwds_24_tfvisassunto ;
      private string lV132Core_visitawwds_27_tfvislink ;
      private string A472VisSituacao ;
      private string A403VisInsUsuNome ;
      private string A416VisTipoNome ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private string AV46Option ;
      private Guid AV93VisNegID_Filtro ;
      private Guid AV88VisNegID ;
      private Guid AV106Core_visitawwds_1_visnegid_filtro ;
      private Guid A418VisNegID ;
      private Guid A398VisID ;
      private IGxSession AV52Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006C2_A414VisTipoID ;
      private Guid[] P006C2_A418VisNegID ;
      private bool[] P006C2_n418VisNegID ;
      private int[] P006C2_A422VisNgfSeq ;
      private bool[] P006C2_n422VisNgfSeq ;
      private string[] P006C2_A403VisInsUsuNome ;
      private bool[] P006C2_n403VisInsUsuNome ;
      private string[] P006C2_A417VisLink ;
      private bool[] P006C2_n417VisLink ;
      private string[] P006C2_A409VisAssunto ;
      private string[] P006C2_A416VisTipoNome ;
      private DateTime[] P006C2_A477VisDataHoraFim ;
      private bool[] P006C2_n477VisDataHoraFim ;
      private DateTime[] P006C2_A476VisHoraFim ;
      private bool[] P006C2_n476VisHoraFim ;
      private DateTime[] P006C2_A475VisDataFim ;
      private bool[] P006C2_n475VisDataFim ;
      private DateTime[] P006C2_A406VisDataHora ;
      private DateTime[] P006C2_A405VisHora ;
      private DateTime[] P006C2_A404VisData ;
      private DateTime[] P006C2_A401VisInsDataHora ;
      private string[] P006C2_A472VisSituacao ;
      private bool[] P006C2_A487VisDel ;
      private Guid[] P006C2_A398VisID ;
      private int[] P006C3_A414VisTipoID ;
      private string[] P006C3_A417VisLink ;
      private bool[] P006C3_n417VisLink ;
      private string[] P006C3_A409VisAssunto ;
      private string[] P006C3_A416VisTipoNome ;
      private DateTime[] P006C3_A477VisDataHoraFim ;
      private bool[] P006C3_n477VisDataHoraFim ;
      private DateTime[] P006C3_A476VisHoraFim ;
      private bool[] P006C3_n476VisHoraFim ;
      private DateTime[] P006C3_A475VisDataFim ;
      private bool[] P006C3_n475VisDataFim ;
      private DateTime[] P006C3_A406VisDataHora ;
      private DateTime[] P006C3_A405VisHora ;
      private DateTime[] P006C3_A404VisData ;
      private string[] P006C3_A403VisInsUsuNome ;
      private bool[] P006C3_n403VisInsUsuNome ;
      private DateTime[] P006C3_A401VisInsDataHora ;
      private string[] P006C3_A472VisSituacao ;
      private bool[] P006C3_A487VisDel ;
      private int[] P006C3_A422VisNgfSeq ;
      private bool[] P006C3_n422VisNgfSeq ;
      private Guid[] P006C3_A418VisNegID ;
      private bool[] P006C3_n418VisNegID ;
      private Guid[] P006C3_A398VisID ;
      private int[] P006C4_A414VisTipoID ;
      private Guid[] P006C4_A418VisNegID ;
      private bool[] P006C4_n418VisNegID ;
      private int[] P006C4_A422VisNgfSeq ;
      private bool[] P006C4_n422VisNgfSeq ;
      private string[] P006C4_A409VisAssunto ;
      private string[] P006C4_A417VisLink ;
      private bool[] P006C4_n417VisLink ;
      private string[] P006C4_A416VisTipoNome ;
      private DateTime[] P006C4_A477VisDataHoraFim ;
      private bool[] P006C4_n477VisDataHoraFim ;
      private DateTime[] P006C4_A476VisHoraFim ;
      private bool[] P006C4_n476VisHoraFim ;
      private DateTime[] P006C4_A475VisDataFim ;
      private bool[] P006C4_n475VisDataFim ;
      private DateTime[] P006C4_A406VisDataHora ;
      private DateTime[] P006C4_A405VisHora ;
      private DateTime[] P006C4_A404VisData ;
      private string[] P006C4_A403VisInsUsuNome ;
      private bool[] P006C4_n403VisInsUsuNome ;
      private DateTime[] P006C4_A401VisInsDataHora ;
      private string[] P006C4_A472VisSituacao ;
      private bool[] P006C4_A487VisDel ;
      private Guid[] P006C4_A398VisID ;
      private int[] P006C5_A414VisTipoID ;
      private Guid[] P006C5_A418VisNegID ;
      private bool[] P006C5_n418VisNegID ;
      private int[] P006C5_A422VisNgfSeq ;
      private bool[] P006C5_n422VisNgfSeq ;
      private string[] P006C5_A417VisLink ;
      private bool[] P006C5_n417VisLink ;
      private string[] P006C5_A409VisAssunto ;
      private string[] P006C5_A416VisTipoNome ;
      private DateTime[] P006C5_A477VisDataHoraFim ;
      private bool[] P006C5_n477VisDataHoraFim ;
      private DateTime[] P006C5_A476VisHoraFim ;
      private bool[] P006C5_n476VisHoraFim ;
      private DateTime[] P006C5_A475VisDataFim ;
      private bool[] P006C5_n475VisDataFim ;
      private DateTime[] P006C5_A406VisDataHora ;
      private DateTime[] P006C5_A405VisHora ;
      private DateTime[] P006C5_A404VisData ;
      private string[] P006C5_A403VisInsUsuNome ;
      private bool[] P006C5_n403VisInsUsuNome ;
      private DateTime[] P006C5_A401VisInsDataHora ;
      private string[] P006C5_A472VisSituacao ;
      private bool[] P006C5_A487VisDel ;
      private Guid[] P006C5_A398VisID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV47Options ;
      private GxSimpleCollection<string> AV49OptionsDesc ;
      private GxSimpleCollection<string> AV50OptionIndexes ;
      private GxSimpleCollection<string> AV92TFVisSituacao_Sels ;
      private GxSimpleCollection<string> AV131Core_visitawwds_26_tfvissituacao_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV54GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV55GridStateFilterValue ;
   }

   public class visitawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006C2( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV131Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV109Core_visitawwds_4_vissituacao ,
                                             DateTime AV111Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV113Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV115Core_visitawwds_10_tfvisdata ,
                                             DateTime AV116Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV117Core_visitawwds_12_tfvishora ,
                                             DateTime AV118Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV119Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV120Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV121Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV122Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV123Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV124Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV125Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV128Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV127Core_visitawwds_22_tfvistiponome ,
                                             string AV130Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV129Core_visitawwds_24_tfvisassunto ,
                                             int AV131Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV133Core_visitawwds_28_tfvislink_sel ,
                                             string AV132Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             bool A487VisDel ,
                                             Guid A418VisNegID ,
                                             Guid AV88VisNegID ,
                                             int A422VisNgfSeq ,
                                             int AV89VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[26];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.VisTipoID AS VisTipoID, T1.VisNegID, T1.VisNgfSeq, T1.VisInsUsuNome, T1.VisLink, T1.VisAssunto, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsDataHora, T1.VisSituacao, T1.VisDel, T1.VisID FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(Not T1.VisDel)");
         AddWhere(sWhereString, "(T1.VisNegID = :AV88VisNegID)");
         AddWhere(sWhereString, "(T1.VisNgfSeq = :AV89VisNgfSeq)");
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV111Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV112Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV112Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV113Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV114Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV115Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV115Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV116Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV117Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV118Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV119Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV120Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV121Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV122Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV123Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV124Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV125Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV125Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV126Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV127Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV128Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV129Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV130Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV131Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV131Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV132Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV133Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.VisInsUsuNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006C3( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV131Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV109Core_visitawwds_4_vissituacao ,
                                             DateTime AV111Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV113Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV115Core_visitawwds_10_tfvisdata ,
                                             DateTime AV116Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV117Core_visitawwds_12_tfvishora ,
                                             DateTime AV118Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV119Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV120Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV121Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV122Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV123Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV124Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV125Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV128Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV127Core_visitawwds_22_tfvistiponome ,
                                             string AV130Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV129Core_visitawwds_24_tfvisassunto ,
                                             int AV131Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV133Core_visitawwds_28_tfvislink_sel ,
                                             string AV132Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             bool A487VisDel ,
                                             Guid A418VisNegID ,
                                             Guid AV88VisNegID ,
                                             int A422VisNgfSeq ,
                                             int AV89VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.VisTipoID AS VisTipoID, T1.VisLink, T1.VisAssunto, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsUsuNome, T1.VisInsDataHora, T1.VisSituacao, T1.VisDel, T1.VisNgfSeq, T1.VisNegID, T1.VisID FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(Not T1.VisDel)");
         AddWhere(sWhereString, "(T1.VisNegID = :AV88VisNegID)");
         AddWhere(sWhereString, "(T1.VisNgfSeq = :AV89VisNgfSeq)");
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV111Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV112Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV112Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV113Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV114Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV115Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV115Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV116Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV117Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV118Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV119Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV120Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV121Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV122Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV123Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV124Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV125Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV125Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV126Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV127Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV128Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV129Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV130Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV131Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV131Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV132Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV133Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.VisTipoID";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006C4( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV131Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV109Core_visitawwds_4_vissituacao ,
                                             DateTime AV111Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV113Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV115Core_visitawwds_10_tfvisdata ,
                                             DateTime AV116Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV117Core_visitawwds_12_tfvishora ,
                                             DateTime AV118Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV119Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV120Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV121Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV122Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV123Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV124Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV125Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV128Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV127Core_visitawwds_22_tfvistiponome ,
                                             string AV130Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV129Core_visitawwds_24_tfvisassunto ,
                                             int AV131Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV133Core_visitawwds_28_tfvislink_sel ,
                                             string AV132Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             bool A487VisDel ,
                                             Guid A418VisNegID ,
                                             Guid AV88VisNegID ,
                                             int A422VisNgfSeq ,
                                             int AV89VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[26];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.VisTipoID AS VisTipoID, T1.VisNegID, T1.VisNgfSeq, T1.VisAssunto, T1.VisLink, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsUsuNome, T1.VisInsDataHora, T1.VisSituacao, T1.VisDel, T1.VisID FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(Not T1.VisDel)");
         AddWhere(sWhereString, "(T1.VisNegID = :AV88VisNegID)");
         AddWhere(sWhereString, "(T1.VisNgfSeq = :AV89VisNgfSeq)");
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV111Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV112Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV112Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV113Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV114Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV115Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV115Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV116Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV117Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV118Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV119Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV120Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV121Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV122Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV123Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV124Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV125Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV125Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV126Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV127Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV128Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV129Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV130Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV131Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV131Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV132Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV133Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.VisAssunto";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006C5( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV131Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV109Core_visitawwds_4_vissituacao ,
                                             DateTime AV111Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV112Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV114Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV113Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV115Core_visitawwds_10_tfvisdata ,
                                             DateTime AV116Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV117Core_visitawwds_12_tfvishora ,
                                             DateTime AV118Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV119Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV120Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV121Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV122Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV123Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV124Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV125Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV126Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV128Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV127Core_visitawwds_22_tfvistiponome ,
                                             string AV130Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV129Core_visitawwds_24_tfvisassunto ,
                                             int AV131Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV133Core_visitawwds_28_tfvislink_sel ,
                                             string AV132Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             bool A487VisDel ,
                                             Guid A418VisNegID ,
                                             Guid AV88VisNegID ,
                                             int A422VisNgfSeq ,
                                             int AV89VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[26];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.VisTipoID AS VisTipoID, T1.VisNegID, T1.VisNgfSeq, T1.VisLink, T1.VisAssunto, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsUsuNome, T1.VisInsDataHora, T1.VisSituacao, T1.VisDel, T1.VisID FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(Not T1.VisDel)");
         AddWhere(sWhereString, "(T1.VisNegID = :AV88VisNegID)");
         AddWhere(sWhereString, "(T1.VisNgfSeq = :AV89VisNgfSeq)");
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( AV110Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV109Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV111Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV112Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV112Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV113Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV114Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV115Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV115Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV116Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV117Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV118Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV119Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV120Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV121Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV122Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV123Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV123Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV124Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV124Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV125Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV125Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV126Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV127Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV128Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV128Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV129Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV130Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV130Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV131Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV131Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV132Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV133Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( StringUtil.StrCmp(AV133Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.VisLink";
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
                     return conditional_P006C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] , (Guid)dynConstraints[39] , (Guid)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
               case 1 :
                     return conditional_P006C3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] , (Guid)dynConstraints[39] , (Guid)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
               case 2 :
                     return conditional_P006C4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] , (Guid)dynConstraints[39] , (Guid)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
               case 3 :
                     return conditional_P006C5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] , (Guid)dynConstraints[39] , (Guid)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] );
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
          Object[] prmP006C2;
          prmP006C2 = new Object[] {
          new ParDef("AV88VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV89VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV111Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV112Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV113Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV114Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV115Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV116Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV117Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV118Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV119Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV120Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV121Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV122Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV123Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV124Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV125Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV126Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV127Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV128Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV130Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV133Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          Object[] prmP006C3;
          prmP006C3 = new Object[] {
          new ParDef("AV88VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV89VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV111Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV112Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV113Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV114Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV115Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV116Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV117Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV118Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV119Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV120Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV121Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV122Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV123Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV124Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV125Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV126Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV127Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV128Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV130Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV133Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          Object[] prmP006C4;
          prmP006C4 = new Object[] {
          new ParDef("AV88VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV89VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV111Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV112Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV113Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV114Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV115Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV116Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV117Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV118Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV119Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV120Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV121Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV122Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV123Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV124Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV125Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV126Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV127Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV128Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV130Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV133Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          Object[] prmP006C5;
          prmP006C5 = new Object[] {
          new ParDef("AV88VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV89VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV109Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV111Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV112Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV113Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV114Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV115Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV116Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV117Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV118Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV119Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV120Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV121Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV122Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV123Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV124Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV125Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV126Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV127Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV128Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV130Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV133Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006C5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C5,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(12);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14, true);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((bool[]) buf[22])[0] = rslt.getBool(16);
                ((Guid[]) buf[23])[0] = rslt.getGuid(17);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((bool[]) buf[18])[0] = rslt.getBool(14);
                ((int[]) buf[19])[0] = rslt.getInt(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((Guid[]) buf[21])[0] = rslt.getGuid(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((Guid[]) buf[23])[0] = rslt.getGuid(17);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14, true);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((bool[]) buf[22])[0] = rslt.getBool(16);
                ((Guid[]) buf[23])[0] = rslt.getGuid(17);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14, true);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((bool[]) buf[22])[0] = rslt.getBool(16);
                ((Guid[]) buf[23])[0] = rslt.getGuid(17);
                return;
       }
    }

 }

}
