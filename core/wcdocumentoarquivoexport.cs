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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class wcdocumentoarquivoexport : GXProcedure
   {
      public wcdocumentoarquivoexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcdocumentoarquivoexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         wcdocumentoarquivoexport objwcdocumentoarquivoexport;
         objwcdocumentoarquivoexport = new wcdocumentoarquivoexport();
         objwcdocumentoarquivoexport.AV12Filename = "" ;
         objwcdocumentoarquivoexport.AV13ErrorMessage = "" ;
         objwcdocumentoarquivoexport.context.SetSubmitInitialConfig(context);
         objwcdocumentoarquivoexport.initialize();
         Submit( executePrivateCatch,objwcdocumentoarquivoexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wcdocumentoarquivoexport)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "wcDocumentoArquivoExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV21FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Filtro principal") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFDocArqConteudoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome do Arquivo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV43TFDocArqConteudoNome_Sel)) ? "(Vazio)" : AV43TFDocArqConteudoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFDocArqConteudoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome do Arquivo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFDocArqConteudoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocArqConteudoExtensao_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Extensão") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocArqConteudoExtensao_Sel)) ? "(Vazio)" : AV45TFDocArqConteudoExtensao_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocArqConteudoExtensao)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Extensão") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFDocArqConteudoExtensao, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV46TFDocArqInsDataHora) && (DateTime.MinValue==AV47TFDocArqInsDataHora_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído em") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV46TFDocArqInsDataHora;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV47TFDocArqInsDataHora_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFDocArqObservacao_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Observações") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV49TFDocArqObservacao_Sel)) ? "(Vazio)" : AV49TFDocArqObservacao_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFDocArqObservacao)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Observações") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFDocArqObservacao, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Nome do Arquivo";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Extensão";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = "Versão";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "Incluído em";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "Observações";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Core_wcdocumentoarquivods_1_filterfulltext = AV21FilterFullText;
         AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV42TFDocArqConteudoNome;
         AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV43TFDocArqConteudoNome_Sel;
         AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV44TFDocArqConteudoExtensao;
         AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV45TFDocArqConteudoExtensao_Sel;
         AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV46TFDocArqInsDataHora;
         AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV47TFDocArqInsDataHora_To;
         AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV48TFDocArqObservacao;
         AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV49TFDocArqObservacao_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Core_wcdocumentoarquivods_1_filterfulltext ,
                                              AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                              AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                              AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                              AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                              AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                              AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                              AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                              AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A325DocVersao ,
                                              A324DocArqObservacao ,
                                              A310DocArqInsDataHora ,
                                              AV18OrderedBy ,
                                              AV19OrderedDsc ,
                                              A289DocID ,
                                              AV54InDocVersaoIDPai ,
                                              A326DocVersaoIDPai ,
                                              AV53InDocID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV56Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV56Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV56Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome), "%", "");
         lV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao), "%", "");
         lV63Core_wcdocumentoarquivods_8_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao), "%", "");
         /* Using cursor P006Q2 */
         pr_default.execute(0, new Object[] {AV54InDocVersaoIDPai, AV54InDocVersaoIDPai, AV54InDocVersaoIDPai, AV53InDocID, AV54InDocVersaoIDPai, lV56Core_wcdocumentoarquivods_1_filterfulltext, lV56Core_wcdocumentoarquivods_1_filterfulltext, lV56Core_wcdocumentoarquivods_1_filterfulltext, lV56Core_wcdocumentoarquivods_1_filterfulltext, lV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome, AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, lV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao, AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora, AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to, lV63Core_wcdocumentoarquivods_8_tfdocarqobservacao, AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A326DocVersaoIDPai = P006Q2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006Q2_n326DocVersaoIDPai[0];
            A289DocID = P006Q2_A289DocID[0];
            A325DocVersao = P006Q2_A325DocVersao[0];
            A310DocArqInsDataHora = P006Q2_A310DocArqInsDataHora[0];
            A324DocArqObservacao = P006Q2_A324DocArqObservacao[0];
            n324DocArqObservacao = P006Q2_n324DocArqObservacao[0];
            A323DocArqConteudoExtensao = P006Q2_A323DocArqConteudoExtensao[0];
            A322DocArqConteudoNome = P006Q2_A322DocArqConteudoNome[0];
            A308DocArqInsData = P006Q2_A308DocArqInsData[0];
            A307DocArqSeq = P006Q2_A307DocArqSeq[0];
            A326DocVersaoIDPai = P006Q2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P006Q2_n326DocVersaoIDPai[0];
            A325DocVersao = P006Q2_A325DocVersao[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A322DocArqConteudoNome, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A323DocArqConteudoExtensao, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Number = A325DocVersao;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = A310DocArqInsDataHora;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A324DocArqObservacao, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = GXt_char1;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV38Session.Set("WWPExportFilePath", AV12Filename);
         AV38Session.Set("WWPExportFileName", "wcDocumentoArquivoExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("core.wcDocumentoArquivoGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.wcDocumentoArquivoGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("core.wcDocumentoArquivoGridState"), null, "", "");
         }
         AV18OrderedBy = AV40GridState.gxTpr_Orderedby;
         AV19OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV65GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV21FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME") == 0 )
            {
               AV42TFDocArqConteudoNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME_SEL") == 0 )
            {
               AV43TFDocArqConteudoNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO") == 0 )
            {
               AV44TFDocArqConteudoExtensao = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO_SEL") == 0 )
            {
               AV45TFDocArqConteudoExtensao_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQINSDATAHORA") == 0 )
            {
               AV46TFDocArqInsDataHora = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV47TFDocArqInsDataHora_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO") == 0 )
            {
               AV48TFDocArqObservacao = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO_SEL") == 0 )
            {
               AV49TFDocArqObservacao_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&INDOCID") == 0 )
            {
               AV53InDocID = StringUtil.StrToGuid( AV41GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&INDOCVERSAOIDPAI") == 0 )
            {
               AV54InDocVersaoIDPai = StringUtil.StrToGuid( AV41GridStateFilterValue.gxTpr_Value);
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV21FilterFullText = "";
         AV43TFDocArqConteudoNome_Sel = "";
         AV42TFDocArqConteudoNome = "";
         AV45TFDocArqConteudoExtensao_Sel = "";
         AV44TFDocArqConteudoExtensao = "";
         AV46TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV47TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV49TFDocArqObservacao_Sel = "";
         AV48TFDocArqObservacao = "";
         AV56Core_wcdocumentoarquivods_1_filterfulltext = "";
         AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome = "";
         AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = "";
         AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = "";
         AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = "";
         AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = (DateTime)(DateTime.MinValue);
         AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao = "";
         AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = "";
         scmdbuf = "";
         lV56Core_wcdocumentoarquivods_1_filterfulltext = "";
         lV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome = "";
         lV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = "";
         lV63Core_wcdocumentoarquivods_8_tfdocarqobservacao = "";
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A324DocArqObservacao = "";
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A289DocID = Guid.Empty;
         AV54InDocVersaoIDPai = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         AV53InDocID = Guid.Empty;
         P006Q2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P006Q2_n326DocVersaoIDPai = new bool[] {false} ;
         P006Q2_A289DocID = new Guid[] {Guid.Empty} ;
         P006Q2_A325DocVersao = new short[1] ;
         P006Q2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006Q2_A324DocArqObservacao = new string[] {""} ;
         P006Q2_n324DocArqObservacao = new bool[] {false} ;
         P006Q2_A323DocArqConteudoExtensao = new string[] {""} ;
         P006Q2_A322DocArqConteudoNome = new string[] {""} ;
         P006Q2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P006Q2_A307DocArqSeq = new short[1] ;
         A308DocArqInsData = DateTime.MinValue;
         GXt_char1 = "";
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.wcdocumentoarquivoexport__default(),
            new Object[][] {
                new Object[] {
               P006Q2_A326DocVersaoIDPai, P006Q2_n326DocVersaoIDPai, P006Q2_A289DocID, P006Q2_A325DocVersao, P006Q2_A310DocArqInsDataHora, P006Q2_A324DocArqObservacao, P006Q2_n324DocArqObservacao, P006Q2_A323DocArqConteudoExtensao, P006Q2_A322DocArqConteudoNome, P006Q2_A308DocArqInsData,
               P006Q2_A307DocArqSeq
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short A325DocVersao ;
      private short AV18OrderedBy ;
      private short A307DocArqSeq ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV65GXV1 ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime AV46TFDocArqInsDataHora ;
      private DateTime AV47TFDocArqInsDataHora_To ;
      private DateTime AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ;
      private DateTime AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime A308DocArqInsData ;
      private bool returnInSub ;
      private bool AV19OrderedDsc ;
      private bool n326DocVersaoIDPai ;
      private bool n324DocArqObservacao ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV21FilterFullText ;
      private string AV43TFDocArqConteudoNome_Sel ;
      private string AV42TFDocArqConteudoNome ;
      private string AV45TFDocArqConteudoExtensao_Sel ;
      private string AV44TFDocArqConteudoExtensao ;
      private string AV49TFDocArqObservacao_Sel ;
      private string AV48TFDocArqObservacao ;
      private string AV56Core_wcdocumentoarquivods_1_filterfulltext ;
      private string AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome ;
      private string AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ;
      private string AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ;
      private string AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ;
      private string AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao ;
      private string AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ;
      private string lV56Core_wcdocumentoarquivods_1_filterfulltext ;
      private string lV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome ;
      private string lV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ;
      private string lV63Core_wcdocumentoarquivods_8_tfdocarqobservacao ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private Guid A289DocID ;
      private Guid AV54InDocVersaoIDPai ;
      private Guid A326DocVersaoIDPai ;
      private Guid AV53InDocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P006Q2_A326DocVersaoIDPai ;
      private bool[] P006Q2_n326DocVersaoIDPai ;
      private Guid[] P006Q2_A289DocID ;
      private short[] P006Q2_A325DocVersao ;
      private DateTime[] P006Q2_A310DocArqInsDataHora ;
      private string[] P006Q2_A324DocArqObservacao ;
      private bool[] P006Q2_n324DocArqObservacao ;
      private string[] P006Q2_A323DocArqConteudoExtensao ;
      private string[] P006Q2_A322DocArqConteudoNome ;
      private DateTime[] P006Q2_A308DocArqInsData ;
      private short[] P006Q2_A307DocArqSeq ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private IGxSession AV38Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class wcdocumentoarquivoexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Q2( IGxContext context ,
                                             string AV56Core_wcdocumentoarquivods_1_filterfulltext ,
                                             string AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                             string AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                             string AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                             string AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                             DateTime AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                             DateTime AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                             string AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                             string AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             short A325DocVersao ,
                                             string A324DocArqObservacao ,
                                             DateTime A310DocArqInsDataHora ,
                                             short AV18OrderedBy ,
                                             bool AV19OrderedDsc ,
                                             Guid A289DocID ,
                                             Guid AV54InDocVersaoIDPai ,
                                             Guid A326DocVersaoIDPai ,
                                             Guid AV53InDocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.DocVersaoIDPai, T1.DocID, T2.DocVersao, T1.DocArqInsDataHora, T1.DocArqObservacao, T1.DocArqConteudoExtensao, T1.DocArqConteudoNome, T1.DocArqInsData, T1.DocArqSeq FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID)";
         AddWhere(sWhereString, "(( ( ( T1.DocID = :AV54InDocVersaoIDPai or T2.DocVersaoIDPai = :AV54InDocVersaoIDPai) and Not (:AV54InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000')) or ( T1.DocID = :AV53InDocID and (:AV54InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000'))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_wcdocumentoarquivods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.DocArqConteudoNome like '%' || :lV56Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqConteudoExtensao like '%' || :lV56Core_wcdocumentoarquivods_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.DocVersao,'9999'), 2) like '%' || :lV56Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqObservacao like '%' || :lV56Core_wcdocumentoarquivods_1_filterfulltext))");
         }
         else
         {
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome like :lV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome = ( :AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao like :lV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao = ( :AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora >= :AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora <= :AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_wcdocumentoarquivods_8_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao like :lV63Core_wcdocumentoarquivods_8_tfdocarqobservacao)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao = ( :AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from T1.DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV18OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.DocArqInsData";
         }
         else if ( ( AV18OrderedBy == 2 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocArqConteudoNome";
         }
         else if ( ( AV18OrderedBy == 2 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocArqConteudoNome DESC";
         }
         else if ( ( AV18OrderedBy == 3 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocArqConteudoExtensao";
         }
         else if ( ( AV18OrderedBy == 3 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocArqConteudoExtensao DESC";
         }
         else if ( ( AV18OrderedBy == 4 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocArqInsDataHora";
         }
         else if ( ( AV18OrderedBy == 4 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocArqInsDataHora DESC";
         }
         else if ( ( AV18OrderedBy == 5 ) && ! AV19OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocArqObservacao";
         }
         else if ( ( AV18OrderedBy == 5 ) && ( AV19OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocArqObservacao DESC";
         }
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
                     return conditional_P006Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006Q2;
          prmP006Q2 = new Object[] {
          new ParDef("AV54InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV54InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV54InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV53InDocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV54InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV56Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Core_wcdocumentoarquivods_2_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV58Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV59Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV60Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV61Core_wcdocumentoarquivods_6_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV62Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV63Core_wcdocumentoarquivods_8_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV64Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
