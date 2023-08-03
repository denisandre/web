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
   public class parametroswwexport : GXProcedure
   {
      public parametroswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametroswwexport( IGxContext context )
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
         parametroswwexport objparametroswwexport;
         objparametroswwexport = new parametroswwexport();
         objparametroswwexport.AV12Filename = "" ;
         objparametroswwexport.AV13ErrorMessage = "" ;
         objparametroswwexport.context.SetSubmitInitialConfig(context);
         objparametroswwexport.initialize();
         Submit( executePrivateCatch,objparametroswwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parametroswwexport)stateInfo).executePrivate();
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
         S201 ();
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
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
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
         AV12Filename = GXt_char1 + "ParametrosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV58ParametroDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV58ParametroDel_Filtro);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Filtro principal") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53ParametroChave)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int2;
            if ( AV52DynamicFiltersOperatorParametroChave == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chave", "Começa com", "", "", "", "", "", "", "");
            }
            else if ( AV52DynamicFiltersOperatorParametroChave == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Chave", "Contém", "", "", "", "", "", "", "");
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53ParametroChave, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55ParametroValor)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int2;
            if ( AV54DynamicFiltersOperatorParametroValor == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "Começa com", "", "", "", "", "", "", "");
            }
            else if ( AV54DynamicFiltersOperatorParametroValor == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "Contém", "", "", "", "", "", "", "");
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55ParametroValor, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFParametroChave_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Chave") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFParametroChave_Sel)) ? "(Vazio)" : AV48TFParametroChave_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFParametroChave)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Chave") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFParametroChave, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFParametroDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFParametroDescricao_Sel)) ? "(Vazio)" : AV57TFParametroDescricao_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFParametroDescricao)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFParametroDescricao, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFParametroValor_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Valor") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFParametroValor_Sel)) ? "(Vazio)" : AV50TFParametroValor_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFParametroValor)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Valor") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFParametroValor, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("core.ParametrosWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.ParametrosWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV59GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Core_parametroswwds_1_parametrodel_filtro = AV58ParametroDel_Filtro;
         AV62Core_parametroswwds_2_filterfulltext = AV19FilterFullText;
         AV63Core_parametroswwds_3_parametrochave = AV53ParametroChave;
         AV64Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV52DynamicFiltersOperatorParametroChave;
         AV65Core_parametroswwds_5_parametrovalor = AV55ParametroValor;
         AV66Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV54DynamicFiltersOperatorParametroValor;
         AV67Core_parametroswwds_7_tfparametrochave = AV47TFParametroChave;
         AV68Core_parametroswwds_8_tfparametrochave_sel = AV48TFParametroChave_Sel;
         AV69Core_parametroswwds_9_tfparametrodescricao = AV56TFParametroDescricao;
         AV70Core_parametroswwds_10_tfparametrodescricao_sel = AV57TFParametroDescricao_Sel;
         AV71Core_parametroswwds_11_tfparametrovalor = AV49TFParametroValor;
         AV72Core_parametroswwds_12_tfparametrovalor_sel = AV50TFParametroValor_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62Core_parametroswwds_2_filterfulltext ,
                                              AV64Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                              AV63Core_parametroswwds_3_parametrochave ,
                                              AV66Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                              AV65Core_parametroswwds_5_parametrovalor ,
                                              AV68Core_parametroswwds_8_tfparametrochave_sel ,
                                              AV67Core_parametroswwds_7_tfparametrochave ,
                                              AV70Core_parametroswwds_10_tfparametrodescricao_sel ,
                                              AV69Core_parametroswwds_9_tfparametrodescricao ,
                                              AV72Core_parametroswwds_12_tfparametrovalor_sel ,
                                              AV71Core_parametroswwds_11_tfparametrovalor ,
                                              A342ParametroChave ,
                                              A344ParametroDescricao ,
                                              A343ParametroValor ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A518ParametroDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV62Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_2_filterfulltext), "%", "");
         lV62Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_2_filterfulltext), "%", "");
         lV62Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Core_parametroswwds_2_filterfulltext), "%", "");
         lV63Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV63Core_parametroswwds_3_parametrochave), "%", "");
         lV63Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV63Core_parametroswwds_3_parametrochave), "%", "");
         lV65Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV65Core_parametroswwds_5_parametrovalor), "%", "");
         lV65Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV65Core_parametroswwds_5_parametrovalor), "%", "");
         lV67Core_parametroswwds_7_tfparametrochave = StringUtil.Concat( StringUtil.RTrim( AV67Core_parametroswwds_7_tfparametrochave), "%", "");
         lV69Core_parametroswwds_9_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV69Core_parametroswwds_9_tfparametrodescricao), "%", "");
         lV71Core_parametroswwds_11_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_11_tfparametrovalor), "%", "");
         /* Using cursor P00502 */
         pr_default.execute(0, new Object[] {lV62Core_parametroswwds_2_filterfulltext, lV62Core_parametroswwds_2_filterfulltext, lV62Core_parametroswwds_2_filterfulltext, lV63Core_parametroswwds_3_parametrochave, lV63Core_parametroswwds_3_parametrochave, lV65Core_parametroswwds_5_parametrovalor, lV65Core_parametroswwds_5_parametrovalor, lV67Core_parametroswwds_7_tfparametrochave, AV68Core_parametroswwds_8_tfparametrochave_sel, lV69Core_parametroswwds_9_tfparametrodescricao, AV70Core_parametroswwds_10_tfparametrodescricao_sel, lV71Core_parametroswwds_11_tfparametrovalor, AV72Core_parametroswwds_12_tfparametrovalor_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A343ParametroValor = P00502_A343ParametroValor[0];
            n343ParametroValor = P00502_n343ParametroValor[0];
            A344ParametroDescricao = P00502_A344ParametroDescricao[0];
            n344ParametroDescricao = P00502_n344ParametroDescricao[0];
            A342ParametroChave = P00502_A342ParametroChave[0];
            A518ParametroDel = P00502_A518ParametroDel[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV44VisibleColumnCount = 0;
            AV73GXV2 = 1;
            while ( AV73GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV73GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ParametroChave") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A342ParametroChave, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ParametroDescricao") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A344ParametroDescricao, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "ParametroValor") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A343ParametroValor, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV73GXV2 = (int)(AV73GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
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

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "ParametrosWWExport.xlsx");
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

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ParametroChave",  "",  "Chave",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ParametroDescricao",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "ParametroValor",  "",  "Valor",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ParametrosWWColumnsSelector", out  GXt_char1) ;
         AV40UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomValue)) ) )
         {
            AV37ColumnsSelectorAux.FromXml(AV40UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV37ColumnsSelectorAux, ref  AV36ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("core.ParametrosWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ParametrosWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.ParametrosWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV74GXV3 = 1;
         while ( AV74GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV74GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARAMETRODEL_FILTRO") == 0 )
            {
               AV58ParametroDel_Filtro = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARAMETROCHAVE") == 0 )
            {
               AV53ParametroChave = AV35GridStateFilterValue.gxTpr_Value;
               AV52DynamicFiltersOperatorParametroChave = AV35GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARAMETROVALOR") == 0 )
            {
               AV55ParametroValor = AV35GridStateFilterValue.gxTpr_Value;
               AV54DynamicFiltersOperatorParametroValor = AV35GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROCHAVE") == 0 )
            {
               AV47TFParametroChave = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROCHAVE_SEL") == 0 )
            {
               AV48TFParametroChave_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV56TFParametroDescricao = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV57TFParametroDescricao_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV49TFParametroValor = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV50TFParametroValor_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV74GXV3 = (int)(AV74GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
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
         AV19FilterFullText = "";
         AV53ParametroChave = "";
         AV55ParametroValor = "";
         AV48TFParametroChave_Sel = "";
         AV47TFParametroChave = "";
         AV57TFParametroDescricao_Sel = "";
         AV56TFParametroDescricao = "";
         AV50TFParametroValor_Sel = "";
         AV49TFParametroValor = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV62Core_parametroswwds_2_filterfulltext = "";
         AV63Core_parametroswwds_3_parametrochave = "";
         AV65Core_parametroswwds_5_parametrovalor = "";
         AV67Core_parametroswwds_7_tfparametrochave = "";
         AV68Core_parametroswwds_8_tfparametrochave_sel = "";
         AV69Core_parametroswwds_9_tfparametrodescricao = "";
         AV70Core_parametroswwds_10_tfparametrodescricao_sel = "";
         AV71Core_parametroswwds_11_tfparametrovalor = "";
         AV72Core_parametroswwds_12_tfparametrovalor_sel = "";
         scmdbuf = "";
         lV62Core_parametroswwds_2_filterfulltext = "";
         lV63Core_parametroswwds_3_parametrochave = "";
         lV65Core_parametroswwds_5_parametrovalor = "";
         lV67Core_parametroswwds_7_tfparametrochave = "";
         lV69Core_parametroswwds_9_tfparametrodescricao = "";
         lV71Core_parametroswwds_11_tfparametrovalor = "";
         A342ParametroChave = "";
         A344ParametroDescricao = "";
         A343ParametroValor = "";
         P00502_A343ParametroValor = new string[] {""} ;
         P00502_n343ParametroValor = new bool[] {false} ;
         P00502_A344ParametroDescricao = new string[] {""} ;
         P00502_n344ParametroDescricao = new bool[] {false} ;
         P00502_A342ParametroChave = new string[] {""} ;
         P00502_A518ParametroDel = new bool[] {false} ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.parametroswwexport__default(),
            new Object[][] {
                new Object[] {
               P00502_A343ParametroValor, P00502_n343ParametroValor, P00502_A344ParametroDescricao, P00502_n344ParametroDescricao, P00502_A342ParametroChave, P00502_A518ParametroDel
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV52DynamicFiltersOperatorParametroChave ;
      private short AV54DynamicFiltersOperatorParametroValor ;
      private short GXt_int2 ;
      private short AV64Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ;
      private short AV66Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV59GXV1 ;
      private int AV73GXV2 ;
      private int AV74GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV58ParametroDel_Filtro ;
      private bool AV61Core_parametroswwds_1_parametrodel_filtro ;
      private bool AV18OrderedDsc ;
      private bool A518ParametroDel ;
      private bool n343ParametroValor ;
      private bool n344ParametroDescricao ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV53ParametroChave ;
      private string AV55ParametroValor ;
      private string AV48TFParametroChave_Sel ;
      private string AV47TFParametroChave ;
      private string AV57TFParametroDescricao_Sel ;
      private string AV56TFParametroDescricao ;
      private string AV50TFParametroValor_Sel ;
      private string AV49TFParametroValor ;
      private string AV62Core_parametroswwds_2_filterfulltext ;
      private string AV63Core_parametroswwds_3_parametrochave ;
      private string AV65Core_parametroswwds_5_parametrovalor ;
      private string AV67Core_parametroswwds_7_tfparametrochave ;
      private string AV68Core_parametroswwds_8_tfparametrochave_sel ;
      private string AV69Core_parametroswwds_9_tfparametrodescricao ;
      private string AV70Core_parametroswwds_10_tfparametrodescricao_sel ;
      private string AV71Core_parametroswwds_11_tfparametrovalor ;
      private string AV72Core_parametroswwds_12_tfparametrovalor_sel ;
      private string lV62Core_parametroswwds_2_filterfulltext ;
      private string lV63Core_parametroswwds_3_parametrochave ;
      private string lV65Core_parametroswwds_5_parametrovalor ;
      private string lV67Core_parametroswwds_7_tfparametrochave ;
      private string lV69Core_parametroswwds_9_tfparametrodescricao ;
      private string lV71Core_parametroswwds_11_tfparametrovalor ;
      private string A342ParametroChave ;
      private string A344ParametroDescricao ;
      private string A343ParametroValor ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00502_A343ParametroValor ;
      private bool[] P00502_n343ParametroValor ;
      private string[] P00502_A344ParametroDescricao ;
      private bool[] P00502_n344ParametroDescricao ;
      private string[] P00502_A342ParametroChave ;
      private bool[] P00502_A518ParametroDel ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
   }

   public class parametroswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00502( IGxContext context ,
                                             string AV62Core_parametroswwds_2_filterfulltext ,
                                             short AV64Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                             string AV63Core_parametroswwds_3_parametrochave ,
                                             short AV66Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                             string AV65Core_parametroswwds_5_parametrovalor ,
                                             string AV68Core_parametroswwds_8_tfparametrochave_sel ,
                                             string AV67Core_parametroswwds_7_tfparametrochave ,
                                             string AV70Core_parametroswwds_10_tfparametrodescricao_sel ,
                                             string AV69Core_parametroswwds_9_tfparametrodescricao ,
                                             string AV72Core_parametroswwds_12_tfparametrovalor_sel ,
                                             string AV71Core_parametroswwds_11_tfparametrovalor ,
                                             string A342ParametroChave ,
                                             string A344ParametroDescricao ,
                                             string A343ParametroValor ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A518ParametroDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ParametroValor, ParametroDescricao, ParametroChave, ParametroDel FROM tb_parametro";
         AddWhere(sWhereString, "(Not ParametroDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_parametroswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ParametroChave like '%' || :lV62Core_parametroswwds_2_filterfulltext) or ( ParametroDescricao like '%' || :lV62Core_parametroswwds_2_filterfulltext) or ( ParametroValor like '%' || :lV62Core_parametroswwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( AV64Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV63Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( AV64Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like '%' || :lV63Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( AV66Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV65Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( AV66Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like '%' || :lV65Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_parametroswwds_8_tfparametrochave_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_parametroswwds_7_tfparametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV67Core_parametroswwds_7_tfparametrochave)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_parametroswwds_8_tfparametrochave_sel)) && ! ( StringUtil.StrCmp(AV68Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV68Core_parametroswwds_8_tfparametrochave_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV68Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ParametroChave))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_parametroswwds_10_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_parametroswwds_9_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao like :lV69Core_parametroswwds_9_tfparametrodescricao)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_parametroswwds_10_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV70Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao = ( :AV70Core_parametroswwds_10_tfparametrodescricao_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroDescricao IS NULL or (char_length(trim(trailing ' ' from ParametroDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_parametroswwds_12_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_parametroswwds_11_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV71Core_parametroswwds_11_tfparametrovalor)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_parametroswwds_12_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV72Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroValor = ( :AV72Core_parametroswwds_12_tfparametrovalor_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV72Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroValor IS NULL or (char_length(trim(trailing ' ' from ParametroValor))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY ParametroChave";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParametroChave DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY ParametroDescricao";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParametroDescricao DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY ParametroValor";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParametroValor DESC";
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
                     return conditional_P00502(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmP00502;
          prmP00502 = new Object[] {
          new ParDef("lV62Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV63Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV65Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV65Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV67Core_parametroswwds_7_tfparametrochave",GXType.VarChar,100,0) ,
          new ParDef("AV68Core_parametroswwds_8_tfparametrochave_sel",GXType.VarChar,100,0) ,
          new ParDef("lV69Core_parametroswwds_9_tfparametrodescricao",GXType.VarChar,500,0) ,
          new ParDef("AV70Core_parametroswwds_10_tfparametrodescricao_sel",GXType.VarChar,500,0) ,
          new ParDef("lV71Core_parametroswwds_11_tfparametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("AV72Core_parametroswwds_12_tfparametrovalor_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00502", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00502,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                return;
       }
    }

 }

}
