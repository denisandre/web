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
   public class wcdocumentoarquivogetfilterdata : GXProcedure
   {
      public wcdocumentoarquivogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcdocumentoarquivogetfilterdata( IGxContext context )
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
         wcdocumentoarquivogetfilterdata objwcdocumentoarquivogetfilterdata;
         objwcdocumentoarquivogetfilterdata = new wcdocumentoarquivogetfilterdata();
         objwcdocumentoarquivogetfilterdata.AV35DDOName = aP0_DDOName;
         objwcdocumentoarquivogetfilterdata.AV36SearchTxtParms = aP1_SearchTxtParms;
         objwcdocumentoarquivogetfilterdata.AV37SearchTxtTo = aP2_SearchTxtTo;
         objwcdocumentoarquivogetfilterdata.AV38OptionsJson = "" ;
         objwcdocumentoarquivogetfilterdata.AV39OptionsDescJson = "" ;
         objwcdocumentoarquivogetfilterdata.AV40OptionIndexesJson = "" ;
         objwcdocumentoarquivogetfilterdata.context.SetSubmitInitialConfig(context);
         objwcdocumentoarquivogetfilterdata.initialize();
         Submit( executePrivateCatch,objwcdocumentoarquivogetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wcdocumentoarquivogetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DOCARQCONTEUDONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCARQCONTEUDONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DOCARQCONTEUDOEXTENSAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCARQCONTEUDOEXTENSAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DOCARQOBSERVACAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCARQOBSERVACAOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV30Session.Get("core.wcDocumentoArquivoGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.wcDocumentoArquivoGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("core.wcDocumentoArquivoGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV42FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME") == 0 )
            {
               AV11TFDocArqConteudoNome = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME_SEL") == 0 )
            {
               AV12TFDocArqConteudoNome_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO") == 0 )
            {
               AV13TFDocArqConteudoExtensao = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO_SEL") == 0 )
            {
               AV14TFDocArqConteudoExtensao_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQINSDATAHORA") == 0 )
            {
               AV15TFDocArqInsDataHora = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV16TFDocArqInsDataHora_To = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO") == 0 )
            {
               AV17TFDocArqObservacao = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO_SEL") == 0 )
            {
               AV18TFDocArqObservacao_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&INDOCID") == 0 )
            {
               AV61InDocID = StringUtil.StrToGuid( AV33GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&INDOCVERSAOIDPAI") == 0 )
            {
               AV62InDocVersaoIDPai = StringUtil.StrToGuid( AV33GridStateFilterValue.gxTpr_Value);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCARQCONTEUDONOMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFDocArqConteudoNome = AV19SearchTxt;
         AV12TFDocArqConteudoNome_Sel = "";
         AV65Core_wcdocumentoarquivods_1_filterfulltext = AV42FilterFullText;
         AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV11TFDocArqConteudoNome;
         AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV12TFDocArqConteudoNome_Sel;
         AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV13TFDocArqConteudoExtensao;
         AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV14TFDocArqConteudoExtensao_Sel;
         AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV15TFDocArqInsDataHora;
         AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV16TFDocArqInsDataHora_To;
         AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV17TFDocArqObservacao;
         AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV18TFDocArqObservacao_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV65Core_wcdocumentoarquivods_1_filterfulltext ,
                                              AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                              AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                              AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                              AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                              AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                              AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                              AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                              AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A325DocVersao ,
                                              A324DocArqObservacao ,
                                              A310DocArqInsDataHora ,
                                              A289DocID ,
                                              AV62InDocVersaoIDPai ,
                                              A326DocVersaoIDPai ,
                                              AV61InDocID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome), "%", "");
         lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao), "%", "");
         lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao), "%", "");
         /* Using cursor P006R2 */
         pr_default.execute(0, new Object[] {AV62InDocVersaoIDPai, AV62InDocVersaoIDPai, AV62InDocVersaoIDPai, AV61InDocID, AV62InDocVersaoIDPai, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome, AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao, AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora, AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to, lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao, AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6R2 = false;
            A322DocArqConteudoNome = P006R2_A322DocArqConteudoNome[0];
            A326DocVersaoIDPai = P006R2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006R2_n326DocVersaoIDPai[0];
            A289DocID = P006R2_A289DocID[0];
            A325DocVersao = P006R2_A325DocVersao[0];
            A310DocArqInsDataHora = P006R2_A310DocArqInsDataHora[0];
            A324DocArqObservacao = P006R2_A324DocArqObservacao[0];
            n324DocArqObservacao = P006R2_n324DocArqObservacao[0];
            A323DocArqConteudoExtensao = P006R2_A323DocArqConteudoExtensao[0];
            A307DocArqSeq = P006R2_A307DocArqSeq[0];
            A326DocVersaoIDPai = P006R2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006R2_n326DocVersaoIDPai[0];
            A325DocVersao = P006R2_A325DocVersao[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006R2_A322DocArqConteudoNome[0], A322DocArqConteudoNome) == 0 ) )
            {
               BRK6R2 = false;
               A289DocID = P006R2_A289DocID[0];
               A307DocArqSeq = P006R2_A307DocArqSeq[0];
               AV29count = (long)(AV29count+1);
               BRK6R2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A322DocArqConteudoNome)) ? "<#Empty#>" : A322DocArqConteudoNome);
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
            if ( ! BRK6R2 )
            {
               BRK6R2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDOCARQCONTEUDOEXTENSAOOPTIONS' Routine */
         returnInSub = false;
         AV13TFDocArqConteudoExtensao = AV19SearchTxt;
         AV14TFDocArqConteudoExtensao_Sel = "";
         AV65Core_wcdocumentoarquivods_1_filterfulltext = AV42FilterFullText;
         AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV11TFDocArqConteudoNome;
         AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV12TFDocArqConteudoNome_Sel;
         AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV13TFDocArqConteudoExtensao;
         AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV14TFDocArqConteudoExtensao_Sel;
         AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV15TFDocArqInsDataHora;
         AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV16TFDocArqInsDataHora_To;
         AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV17TFDocArqObservacao;
         AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV18TFDocArqObservacao_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV65Core_wcdocumentoarquivods_1_filterfulltext ,
                                              AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                              AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                              AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                              AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                              AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                              AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                              AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                              AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A325DocVersao ,
                                              A324DocArqObservacao ,
                                              A310DocArqInsDataHora ,
                                              A289DocID ,
                                              AV62InDocVersaoIDPai ,
                                              A326DocVersaoIDPai ,
                                              AV61InDocID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome), "%", "");
         lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao), "%", "");
         lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao), "%", "");
         /* Using cursor P006R3 */
         pr_default.execute(1, new Object[] {AV62InDocVersaoIDPai, AV62InDocVersaoIDPai, AV62InDocVersaoIDPai, AV61InDocID, AV62InDocVersaoIDPai, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome, AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao, AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora, AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to, lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao, AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6R4 = false;
            A323DocArqConteudoExtensao = P006R3_A323DocArqConteudoExtensao[0];
            A326DocVersaoIDPai = P006R3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006R3_n326DocVersaoIDPai[0];
            A289DocID = P006R3_A289DocID[0];
            A325DocVersao = P006R3_A325DocVersao[0];
            A310DocArqInsDataHora = P006R3_A310DocArqInsDataHora[0];
            A324DocArqObservacao = P006R3_A324DocArqObservacao[0];
            n324DocArqObservacao = P006R3_n324DocArqObservacao[0];
            A322DocArqConteudoNome = P006R3_A322DocArqConteudoNome[0];
            A307DocArqSeq = P006R3_A307DocArqSeq[0];
            A326DocVersaoIDPai = P006R3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006R3_n326DocVersaoIDPai[0];
            A325DocVersao = P006R3_A325DocVersao[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006R3_A323DocArqConteudoExtensao[0], A323DocArqConteudoExtensao) == 0 ) )
            {
               BRK6R4 = false;
               A289DocID = P006R3_A289DocID[0];
               A307DocArqSeq = P006R3_A307DocArqSeq[0];
               AV29count = (long)(AV29count+1);
               BRK6R4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A323DocArqConteudoExtensao)) ? "<#Empty#>" : A323DocArqConteudoExtensao);
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
            if ( ! BRK6R4 )
            {
               BRK6R4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADDOCARQOBSERVACAOOPTIONS' Routine */
         returnInSub = false;
         AV17TFDocArqObservacao = AV19SearchTxt;
         AV18TFDocArqObservacao_Sel = "";
         AV65Core_wcdocumentoarquivods_1_filterfulltext = AV42FilterFullText;
         AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV11TFDocArqConteudoNome;
         AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV12TFDocArqConteudoNome_Sel;
         AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV13TFDocArqConteudoExtensao;
         AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV14TFDocArqConteudoExtensao_Sel;
         AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV15TFDocArqInsDataHora;
         AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV16TFDocArqInsDataHora_To;
         AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV17TFDocArqObservacao;
         AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV18TFDocArqObservacao_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV65Core_wcdocumentoarquivods_1_filterfulltext ,
                                              AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                              AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                              AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                              AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                              AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                              AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                              AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                              AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A325DocVersao ,
                                              A324DocArqObservacao ,
                                              A310DocArqInsDataHora ,
                                              A289DocID ,
                                              AV62InDocVersaoIDPai ,
                                              A326DocVersaoIDPai ,
                                              AV61InDocID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV65Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome), "%", "");
         lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao), "%", "");
         lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao), "%", "");
         /* Using cursor P006R4 */
         pr_default.execute(2, new Object[] {AV62InDocVersaoIDPai, AV62InDocVersaoIDPai, AV62InDocVersaoIDPai, AV61InDocID, AV62InDocVersaoIDPai, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV65Core_wcdocumentoarquivods_1_filterfulltext, lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome, AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao, AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora, AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to, lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao, AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6R6 = false;
            A324DocArqObservacao = P006R4_A324DocArqObservacao[0];
            n324DocArqObservacao = P006R4_n324DocArqObservacao[0];
            A326DocVersaoIDPai = P006R4_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006R4_n326DocVersaoIDPai[0];
            A289DocID = P006R4_A289DocID[0];
            A325DocVersao = P006R4_A325DocVersao[0];
            A310DocArqInsDataHora = P006R4_A310DocArqInsDataHora[0];
            A323DocArqConteudoExtensao = P006R4_A323DocArqConteudoExtensao[0];
            A322DocArqConteudoNome = P006R4_A322DocArqConteudoNome[0];
            A307DocArqSeq = P006R4_A307DocArqSeq[0];
            A326DocVersaoIDPai = P006R4_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006R4_n326DocVersaoIDPai[0];
            A325DocVersao = P006R4_A325DocVersao[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006R4_A324DocArqObservacao[0], A324DocArqObservacao) == 0 ) )
            {
               BRK6R6 = false;
               A289DocID = P006R4_A289DocID[0];
               A307DocArqSeq = P006R4_A307DocArqSeq[0];
               AV29count = (long)(AV29count+1);
               BRK6R6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A324DocArqObservacao)) ? "<#Empty#>" : A324DocArqObservacao);
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
            if ( ! BRK6R6 )
            {
               BRK6R6 = true;
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
         AV42FilterFullText = "";
         AV11TFDocArqConteudoNome = "";
         AV12TFDocArqConteudoNome_Sel = "";
         AV13TFDocArqConteudoExtensao = "";
         AV14TFDocArqConteudoExtensao_Sel = "";
         AV15TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV16TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV17TFDocArqObservacao = "";
         AV18TFDocArqObservacao_Sel = "";
         AV61InDocID = Guid.Empty;
         AV62InDocVersaoIDPai = Guid.Empty;
         AV65Core_wcdocumentoarquivods_1_filterfulltext = "";
         AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = "";
         AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = "";
         AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = "";
         AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = "";
         AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = (DateTime)(DateTime.MinValue);
         AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = "";
         AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = "";
         scmdbuf = "";
         lV65Core_wcdocumentoarquivods_1_filterfulltext = "";
         lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome = "";
         lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = "";
         lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao = "";
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A324DocArqObservacao = "";
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A289DocID = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         P006R2_A322DocArqConteudoNome = new string[] {""} ;
         P006R2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P006R2_n326DocVersaoIDPai = new bool[] {false} ;
         P006R2_A289DocID = new Guid[] {Guid.Empty} ;
         P006R2_A325DocVersao = new short[1] ;
         P006R2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006R2_A324DocArqObservacao = new string[] {""} ;
         P006R2_n324DocArqObservacao = new bool[] {false} ;
         P006R2_A323DocArqConteudoExtensao = new string[] {""} ;
         P006R2_A307DocArqSeq = new short[1] ;
         AV24Option = "";
         P006R3_A323DocArqConteudoExtensao = new string[] {""} ;
         P006R3_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P006R3_n326DocVersaoIDPai = new bool[] {false} ;
         P006R3_A289DocID = new Guid[] {Guid.Empty} ;
         P006R3_A325DocVersao = new short[1] ;
         P006R3_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006R3_A324DocArqObservacao = new string[] {""} ;
         P006R3_n324DocArqObservacao = new bool[] {false} ;
         P006R3_A322DocArqConteudoNome = new string[] {""} ;
         P006R3_A307DocArqSeq = new short[1] ;
         P006R4_A324DocArqObservacao = new string[] {""} ;
         P006R4_n324DocArqObservacao = new bool[] {false} ;
         P006R4_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P006R4_n326DocVersaoIDPai = new bool[] {false} ;
         P006R4_A289DocID = new Guid[] {Guid.Empty} ;
         P006R4_A325DocVersao = new short[1] ;
         P006R4_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006R4_A323DocArqConteudoExtensao = new string[] {""} ;
         P006R4_A322DocArqConteudoNome = new string[] {""} ;
         P006R4_A307DocArqSeq = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.wcdocumentoarquivogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006R2_A322DocArqConteudoNome, P006R2_A326DocVersaoIDPai, P006R2_n326DocVersaoIDPai, P006R2_A289DocID, P006R2_A325DocVersao, P006R2_A310DocArqInsDataHora, P006R2_A324DocArqObservacao, P006R2_n324DocArqObservacao, P006R2_A323DocArqConteudoExtensao, P006R2_A307DocArqSeq
               }
               , new Object[] {
               P006R3_A323DocArqConteudoExtensao, P006R3_A326DocVersaoIDPai, P006R3_n326DocVersaoIDPai, P006R3_A289DocID, P006R3_A325DocVersao, P006R3_A310DocArqInsDataHora, P006R3_A324DocArqObservacao, P006R3_n324DocArqObservacao, P006R3_A322DocArqConteudoNome, P006R3_A307DocArqSeq
               }
               , new Object[] {
               P006R4_A324DocArqObservacao, P006R4_n324DocArqObservacao, P006R4_A326DocVersaoIDPai, P006R4_n326DocVersaoIDPai, P006R4_A289DocID, P006R4_A325DocVersao, P006R4_A310DocArqInsDataHora, P006R4_A323DocArqConteudoExtensao, P006R4_A322DocArqConteudoNome, P006R4_A307DocArqSeq
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short A325DocVersao ;
      private short A307DocArqSeq ;
      private int AV63GXV1 ;
      private long AV29count ;
      private string scmdbuf ;
      private DateTime AV15TFDocArqInsDataHora ;
      private DateTime AV16TFDocArqInsDataHora_To ;
      private DateTime AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ;
      private DateTime AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ;
      private DateTime A310DocArqInsDataHora ;
      private bool returnInSub ;
      private bool BRK6R2 ;
      private bool n326DocVersaoIDPai ;
      private bool n324DocArqObservacao ;
      private bool BRK6R4 ;
      private bool BRK6R6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV42FilterFullText ;
      private string AV11TFDocArqConteudoNome ;
      private string AV12TFDocArqConteudoNome_Sel ;
      private string AV13TFDocArqConteudoExtensao ;
      private string AV14TFDocArqConteudoExtensao_Sel ;
      private string AV17TFDocArqObservacao ;
      private string AV18TFDocArqObservacao_Sel ;
      private string AV65Core_wcdocumentoarquivods_1_filterfulltext ;
      private string AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ;
      private string AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ;
      private string AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ;
      private string AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ;
      private string AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ;
      private string AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ;
      private string lV65Core_wcdocumentoarquivods_1_filterfulltext ;
      private string lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ;
      private string lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ;
      private string lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private string AV24Option ;
      private Guid AV61InDocID ;
      private Guid AV62InDocVersaoIDPai ;
      private Guid A289DocID ;
      private Guid A326DocVersaoIDPai ;
      private IGxSession AV30Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006R2_A322DocArqConteudoNome ;
      private Guid[] P006R2_A326DocVersaoIDPai ;
      private bool[] P006R2_n326DocVersaoIDPai ;
      private Guid[] P006R2_A289DocID ;
      private short[] P006R2_A325DocVersao ;
      private DateTime[] P006R2_A310DocArqInsDataHora ;
      private string[] P006R2_A324DocArqObservacao ;
      private bool[] P006R2_n324DocArqObservacao ;
      private string[] P006R2_A323DocArqConteudoExtensao ;
      private short[] P006R2_A307DocArqSeq ;
      private string[] P006R3_A323DocArqConteudoExtensao ;
      private Guid[] P006R3_A326DocVersaoIDPai ;
      private bool[] P006R3_n326DocVersaoIDPai ;
      private Guid[] P006R3_A289DocID ;
      private short[] P006R3_A325DocVersao ;
      private DateTime[] P006R3_A310DocArqInsDataHora ;
      private string[] P006R3_A324DocArqObservacao ;
      private bool[] P006R3_n324DocArqObservacao ;
      private string[] P006R3_A322DocArqConteudoNome ;
      private short[] P006R3_A307DocArqSeq ;
      private string[] P006R4_A324DocArqObservacao ;
      private bool[] P006R4_n324DocArqObservacao ;
      private Guid[] P006R4_A326DocVersaoIDPai ;
      private bool[] P006R4_n326DocVersaoIDPai ;
      private Guid[] P006R4_A289DocID ;
      private short[] P006R4_A325DocVersao ;
      private DateTime[] P006R4_A310DocArqInsDataHora ;
      private string[] P006R4_A323DocArqConteudoExtensao ;
      private string[] P006R4_A322DocArqConteudoNome ;
      private short[] P006R4_A307DocArqSeq ;
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

   public class wcdocumentoarquivogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006R2( IGxContext context ,
                                             string AV65Core_wcdocumentoarquivods_1_filterfulltext ,
                                             string AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                             string AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                             string AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                             string AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                             DateTime AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                             DateTime AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                             string AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                             string AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             short A325DocVersao ,
                                             string A324DocArqObservacao ,
                                             DateTime A310DocArqInsDataHora ,
                                             Guid A289DocID ,
                                             Guid AV62InDocVersaoIDPai ,
                                             Guid A326DocVersaoIDPai ,
                                             Guid AV61InDocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.DocArqConteudoNome, T2.DocVersaoIDPai, T1.DocID, T2.DocVersao, T1.DocArqInsDataHora, T1.DocArqObservacao, T1.DocArqConteudoExtensao, T1.DocArqSeq FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID)";
         AddWhere(sWhereString, "(( ( ( T1.DocID = :AV62InDocVersaoIDPai or T2.DocVersaoIDPai = :AV62InDocVersaoIDPai) and Not (:AV62InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000')) or ( T1.DocID = :AV61InDocID and (:AV62InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000'))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.DocArqConteudoNome like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqConteudoExtensao like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.DocVersao,'9999'), 2) like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqObservacao like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext))");
         }
         else
         {
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome like :lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome = ( :AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao like :lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao = ( :AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora >= :AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora <= :AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao like :lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao = ( :AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from T1.DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.DocArqConteudoNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006R3( IGxContext context ,
                                             string AV65Core_wcdocumentoarquivods_1_filterfulltext ,
                                             string AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                             string AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                             string AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                             string AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                             DateTime AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                             DateTime AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                             string AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                             string AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             short A325DocVersao ,
                                             string A324DocArqObservacao ,
                                             DateTime A310DocArqInsDataHora ,
                                             Guid A289DocID ,
                                             Guid AV62InDocVersaoIDPai ,
                                             Guid A326DocVersaoIDPai ,
                                             Guid AV61InDocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.DocArqConteudoExtensao, T2.DocVersaoIDPai, T1.DocID, T2.DocVersao, T1.DocArqInsDataHora, T1.DocArqObservacao, T1.DocArqConteudoNome, T1.DocArqSeq FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID)";
         AddWhere(sWhereString, "(( ( ( T1.DocID = :AV62InDocVersaoIDPai or T2.DocVersaoIDPai = :AV62InDocVersaoIDPai) and Not (:AV62InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000')) or ( T1.DocID = :AV61InDocID and (:AV62InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000'))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.DocArqConteudoNome like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqConteudoExtensao like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.DocVersao,'9999'), 2) like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqObservacao like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext))");
         }
         else
         {
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome like :lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome = ( :AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao like :lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao = ( :AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora >= :AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora <= :AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao like :lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao = ( :AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from T1.DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.DocArqConteudoExtensao";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006R4( IGxContext context ,
                                             string AV65Core_wcdocumentoarquivods_1_filterfulltext ,
                                             string AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                             string AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                             string AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                             string AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                             DateTime AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                             DateTime AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                             string AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                             string AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             short A325DocVersao ,
                                             string A324DocArqObservacao ,
                                             DateTime A310DocArqInsDataHora ,
                                             Guid A289DocID ,
                                             Guid AV62InDocVersaoIDPai ,
                                             Guid A326DocVersaoIDPai ,
                                             Guid AV61InDocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.DocArqObservacao, T2.DocVersaoIDPai, T1.DocID, T2.DocVersao, T1.DocArqInsDataHora, T1.DocArqConteudoExtensao, T1.DocArqConteudoNome, T1.DocArqSeq FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID)";
         AddWhere(sWhereString, "(( ( ( T1.DocID = :AV62InDocVersaoIDPai or T2.DocVersaoIDPai = :AV62InDocVersaoIDPai) and Not (:AV62InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000')) or ( T1.DocID = :AV61InDocID and (:AV62InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000'))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_wcdocumentoarquivods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.DocArqConteudoNome like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqConteudoExtensao like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.DocVersao,'9999'), 2) like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqObservacao like '%' || :lV65Core_wcdocumentoarquivods_1_filterfulltext))");
         }
         else
         {
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome like :lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome = ( :AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao like :lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao = ( :AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora >= :AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora <= :AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_wcdocumentoarquivods_8_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao like :lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao = ( :AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from T1.DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.DocArqObservacao";
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
                     return conditional_P006R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (Guid)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 1 :
                     return conditional_P006R3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (Guid)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
               case 2 :
                     return conditional_P006R4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (Guid)dynConstraints[14] , (Guid)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] );
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
          Object[] prmP006R2;
          prmP006R2 = new Object[] {
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV61InDocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          Object[] prmP006R3;
          prmP006R3 = new Object[] {
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV61InDocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          Object[] prmP006R4;
          prmP006R4 = new Object[] {
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV61InDocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_wcdocumentoarquivods_2_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV67Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV68Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV69Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV70Core_wcdocumentoarquivods_6_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV71Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV72Core_wcdocumentoarquivods_8_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV73Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R4,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
