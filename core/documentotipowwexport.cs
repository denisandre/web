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
   public class documentotipowwexport : GXProcedure
   {
      public documentotipowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentotipowwexport( IGxContext context )
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
         documentotipowwexport objdocumentotipowwexport;
         objdocumentotipowwexport = new documentotipowwexport();
         objdocumentotipowwexport.AV12Filename = "" ;
         objdocumentotipowwexport.AV13ErrorMessage = "" ;
         objdocumentotipowwexport.context.SetSubmitInitialConfig(context);
         objdocumentotipowwexport.initialize();
         Submit( executePrivateCatch,objdocumentotipowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentotipowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "DocumentoTipoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV53DocTipoDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV53DocTipoDel_Filtro);
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
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22DocTipoSigla1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22DocTipoSigla1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22DocTipoSigla1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26DocTipoSigla2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DocTipoSigla2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26DocTipoSigla2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30DocTipoSigla3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30DocTipoSigla3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30DocTipoSigla3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFDocTipoSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFDocTipoSigla_Sel)) ? "(Vazio)" : AV48TFDocTipoSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocTipoSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFDocTipoSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFDocTipoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFDocTipoNome_Sel)) ? "(Vazio)" : AV50TFDocTipoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFDocTipoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFDocTipoNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.DocumentoTipoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.DocumentoTipoWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV54GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Core_documentotipowwds_1_doctipodel_filtro = AV53DocTipoDel_Filtro;
         AV57Core_documentotipowwds_2_filterfulltext = AV19FilterFullText;
         AV58Core_documentotipowwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV59Core_documentotipowwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV60Core_documentotipowwds_5_doctiposigla1 = AV22DocTipoSigla1;
         AV61Core_documentotipowwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV62Core_documentotipowwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV63Core_documentotipowwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV64Core_documentotipowwds_9_doctiposigla2 = AV26DocTipoSigla2;
         AV65Core_documentotipowwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV66Core_documentotipowwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV67Core_documentotipowwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV68Core_documentotipowwds_13_doctiposigla3 = AV30DocTipoSigla3;
         AV69Core_documentotipowwds_14_tfdoctiposigla = AV47TFDocTipoSigla;
         AV70Core_documentotipowwds_15_tfdoctiposigla_sel = AV48TFDocTipoSigla_Sel;
         AV71Core_documentotipowwds_16_tfdoctiponome = AV49TFDocTipoNome;
         AV72Core_documentotipowwds_17_tfdoctiponome_sel = AV50TFDocTipoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Core_documentotipowwds_2_filterfulltext ,
                                              AV58Core_documentotipowwds_3_dynamicfiltersselector1 ,
                                              AV59Core_documentotipowwds_4_dynamicfiltersoperator1 ,
                                              AV60Core_documentotipowwds_5_doctiposigla1 ,
                                              AV61Core_documentotipowwds_6_dynamicfiltersenabled2 ,
                                              AV62Core_documentotipowwds_7_dynamicfiltersselector2 ,
                                              AV63Core_documentotipowwds_8_dynamicfiltersoperator2 ,
                                              AV64Core_documentotipowwds_9_doctiposigla2 ,
                                              AV65Core_documentotipowwds_10_dynamicfiltersenabled3 ,
                                              AV66Core_documentotipowwds_11_dynamicfiltersselector3 ,
                                              AV67Core_documentotipowwds_12_dynamicfiltersoperator3 ,
                                              AV68Core_documentotipowwds_13_doctiposigla3 ,
                                              AV70Core_documentotipowwds_15_tfdoctiposigla_sel ,
                                              AV69Core_documentotipowwds_14_tfdoctiposigla ,
                                              AV72Core_documentotipowwds_17_tfdoctiponome_sel ,
                                              AV71Core_documentotipowwds_16_tfdoctiponome ,
                                              A147DocTipoSigla ,
                                              A148DocTipoNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A503DocTipoDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV57Core_documentotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Core_documentotipowwds_2_filterfulltext), "%", "");
         lV57Core_documentotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV57Core_documentotipowwds_2_filterfulltext), "%", "");
         lV60Core_documentotipowwds_5_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_documentotipowwds_5_doctiposigla1), "%", "");
         lV60Core_documentotipowwds_5_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_documentotipowwds_5_doctiposigla1), "%", "");
         lV64Core_documentotipowwds_9_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_documentotipowwds_9_doctiposigla2), "%", "");
         lV64Core_documentotipowwds_9_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_documentotipowwds_9_doctiposigla2), "%", "");
         lV68Core_documentotipowwds_13_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_documentotipowwds_13_doctiposigla3), "%", "");
         lV68Core_documentotipowwds_13_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_documentotipowwds_13_doctiposigla3), "%", "");
         lV69Core_documentotipowwds_14_tfdoctiposigla = StringUtil.Concat( StringUtil.RTrim( AV69Core_documentotipowwds_14_tfdoctiposigla), "%", "");
         lV71Core_documentotipowwds_16_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV71Core_documentotipowwds_16_tfdoctiponome), "%", "");
         /* Using cursor P003S2 */
         pr_default.execute(0, new Object[] {lV57Core_documentotipowwds_2_filterfulltext, lV57Core_documentotipowwds_2_filterfulltext, lV60Core_documentotipowwds_5_doctiposigla1, lV60Core_documentotipowwds_5_doctiposigla1, lV64Core_documentotipowwds_9_doctiposigla2, lV64Core_documentotipowwds_9_doctiposigla2, lV68Core_documentotipowwds_13_doctiposigla3, lV68Core_documentotipowwds_13_doctiposigla3, lV69Core_documentotipowwds_14_tfdoctiposigla, AV70Core_documentotipowwds_15_tfdoctiposigla_sel, lV71Core_documentotipowwds_16_tfdoctiponome, AV72Core_documentotipowwds_17_tfdoctiponome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A148DocTipoNome = P003S2_A148DocTipoNome[0];
            A147DocTipoSigla = P003S2_A147DocTipoSigla[0];
            A503DocTipoDel = P003S2_A503DocTipoDel[0];
            A146DocTipoID = P003S2_A146DocTipoID[0];
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
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DocTipoSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A147DocTipoSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "DocTipoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A148DocTipoNome, out  GXt_char1) ;
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
         AV32Session.Set("WWPExportFileName", "DocumentoTipoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DocTipoSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "DocTipoNome",  "",  "Descrição",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.DocumentoTipoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.DocumentoTipoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoTipoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.DocumentoTipoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV74GXV3 = 1;
         while ( AV74GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV74GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "DOCTIPODEL_FILTRO") == 0 )
            {
               AV53DocTipoDel_Filtro = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDOCTIPOSIGLA") == 0 )
            {
               AV47TFDocTipoSigla = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDOCTIPOSIGLA_SEL") == 0 )
            {
               AV48TFDocTipoSigla_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME") == 0 )
            {
               AV49TFDocTipoNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME_SEL") == 0 )
            {
               AV50TFDocTipoNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
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
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22DocTipoSigla1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26DocTipoSigla2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30DocTipoSigla3 = "";
         AV48TFDocTipoSigla_Sel = "";
         AV47TFDocTipoSigla = "";
         AV50TFDocTipoNome_Sel = "";
         AV49TFDocTipoNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV57Core_documentotipowwds_2_filterfulltext = "";
         AV58Core_documentotipowwds_3_dynamicfiltersselector1 = "";
         AV60Core_documentotipowwds_5_doctiposigla1 = "";
         AV62Core_documentotipowwds_7_dynamicfiltersselector2 = "";
         AV64Core_documentotipowwds_9_doctiposigla2 = "";
         AV66Core_documentotipowwds_11_dynamicfiltersselector3 = "";
         AV68Core_documentotipowwds_13_doctiposigla3 = "";
         AV69Core_documentotipowwds_14_tfdoctiposigla = "";
         AV70Core_documentotipowwds_15_tfdoctiposigla_sel = "";
         AV71Core_documentotipowwds_16_tfdoctiponome = "";
         AV72Core_documentotipowwds_17_tfdoctiponome_sel = "";
         scmdbuf = "";
         lV57Core_documentotipowwds_2_filterfulltext = "";
         lV60Core_documentotipowwds_5_doctiposigla1 = "";
         lV64Core_documentotipowwds_9_doctiposigla2 = "";
         lV68Core_documentotipowwds_13_doctiposigla3 = "";
         lV69Core_documentotipowwds_14_tfdoctiposigla = "";
         lV71Core_documentotipowwds_16_tfdoctiponome = "";
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         P003S2_A148DocTipoNome = new string[] {""} ;
         P003S2_A147DocTipoSigla = new string[] {""} ;
         P003S2_A503DocTipoDel = new bool[] {false} ;
         P003S2_A146DocTipoID = new int[1] ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentotipowwexport__default(),
            new Object[][] {
                new Object[] {
               P003S2_A148DocTipoNome, P003S2_A147DocTipoSigla, P003S2_A503DocTipoDel, P003S2_A146DocTipoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV59Core_documentotipowwds_4_dynamicfiltersoperator1 ;
      private short AV63Core_documentotipowwds_8_dynamicfiltersoperator2 ;
      private short AV67Core_documentotipowwds_12_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV54GXV1 ;
      private int A146DocTipoID ;
      private int AV73GXV2 ;
      private int AV74GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV53DocTipoDel_Filtro ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV56Core_documentotipowwds_1_doctipodel_filtro ;
      private bool AV61Core_documentotipowwds_6_dynamicfiltersenabled2 ;
      private bool AV65Core_documentotipowwds_10_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool A503DocTipoDel ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22DocTipoSigla1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26DocTipoSigla2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30DocTipoSigla3 ;
      private string AV48TFDocTipoSigla_Sel ;
      private string AV47TFDocTipoSigla ;
      private string AV50TFDocTipoNome_Sel ;
      private string AV49TFDocTipoNome ;
      private string AV57Core_documentotipowwds_2_filterfulltext ;
      private string AV58Core_documentotipowwds_3_dynamicfiltersselector1 ;
      private string AV60Core_documentotipowwds_5_doctiposigla1 ;
      private string AV62Core_documentotipowwds_7_dynamicfiltersselector2 ;
      private string AV64Core_documentotipowwds_9_doctiposigla2 ;
      private string AV66Core_documentotipowwds_11_dynamicfiltersselector3 ;
      private string AV68Core_documentotipowwds_13_doctiposigla3 ;
      private string AV69Core_documentotipowwds_14_tfdoctiposigla ;
      private string AV70Core_documentotipowwds_15_tfdoctiposigla_sel ;
      private string AV71Core_documentotipowwds_16_tfdoctiponome ;
      private string AV72Core_documentotipowwds_17_tfdoctiponome_sel ;
      private string lV57Core_documentotipowwds_2_filterfulltext ;
      private string lV60Core_documentotipowwds_5_doctiposigla1 ;
      private string lV64Core_documentotipowwds_9_doctiposigla2 ;
      private string lV68Core_documentotipowwds_13_doctiposigla3 ;
      private string lV69Core_documentotipowwds_14_tfdoctiposigla ;
      private string lV71Core_documentotipowwds_16_tfdoctiponome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003S2_A148DocTipoNome ;
      private string[] P003S2_A147DocTipoSigla ;
      private bool[] P003S2_A503DocTipoDel ;
      private int[] P003S2_A146DocTipoID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
   }

   public class documentotipowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003S2( IGxContext context ,
                                             string AV57Core_documentotipowwds_2_filterfulltext ,
                                             string AV58Core_documentotipowwds_3_dynamicfiltersselector1 ,
                                             short AV59Core_documentotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV60Core_documentotipowwds_5_doctiposigla1 ,
                                             bool AV61Core_documentotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV62Core_documentotipowwds_7_dynamicfiltersselector2 ,
                                             short AV63Core_documentotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV64Core_documentotipowwds_9_doctiposigla2 ,
                                             bool AV65Core_documentotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV66Core_documentotipowwds_11_dynamicfiltersselector3 ,
                                             short AV67Core_documentotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV68Core_documentotipowwds_13_doctiposigla3 ,
                                             string AV70Core_documentotipowwds_15_tfdoctiposigla_sel ,
                                             string AV69Core_documentotipowwds_14_tfdoctiposigla ,
                                             string AV72Core_documentotipowwds_17_tfdoctiponome_sel ,
                                             string AV71Core_documentotipowwds_16_tfdoctiponome ,
                                             string A147DocTipoSigla ,
                                             string A148DocTipoNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A503DocTipoDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT DocTipoNome, DocTipoSigla, DocTipoDel, DocTipoID FROM tb_documentotipo";
         AddWhere(sWhereString, "(Not DocTipoDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_documentotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocTipoSigla like '%' || :lV57Core_documentotipowwds_2_filterfulltext) or ( DocTipoNome like '%' || :lV57Core_documentotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Core_documentotipowwds_3_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV59Core_documentotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_documentotipowwds_5_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV60Core_documentotipowwds_5_doctiposigla1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Core_documentotipowwds_3_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV59Core_documentotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_documentotipowwds_5_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV60Core_documentotipowwds_5_doctiposigla1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Core_documentotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_documentotipowwds_7_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV63Core_documentotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_documentotipowwds_9_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV64Core_documentotipowwds_9_doctiposigla2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Core_documentotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_documentotipowwds_7_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV63Core_documentotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_documentotipowwds_9_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV64Core_documentotipowwds_9_doctiposigla2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV65Core_documentotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_documentotipowwds_11_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV67Core_documentotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_documentotipowwds_13_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV68Core_documentotipowwds_13_doctiposigla3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV65Core_documentotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_documentotipowwds_11_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV67Core_documentotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_documentotipowwds_13_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like '%' || :lV68Core_documentotipowwds_13_doctiposigla3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_documentotipowwds_15_tfdoctiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_documentotipowwds_14_tfdoctiposigla)) ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla like :lV69Core_documentotipowwds_14_tfdoctiposigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_documentotipowwds_15_tfdoctiposigla_sel)) && ! ( StringUtil.StrCmp(AV70Core_documentotipowwds_15_tfdoctiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocTipoSigla = ( :AV70Core_documentotipowwds_15_tfdoctiposigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_documentotipowwds_15_tfdoctiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocTipoSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_documentotipowwds_17_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_documentotipowwds_16_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(DocTipoNome like :lV71Core_documentotipowwds_16_tfdoctiponome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_documentotipowwds_17_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV72Core_documentotipowwds_17_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocTipoNome = ( :AV72Core_documentotipowwds_17_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Core_documentotipowwds_17_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocTipoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY DocTipoSigla";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocTipoSigla DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY DocTipoNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocTipoNome DESC";
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
                     return conditional_P003S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP003S2;
          prmP003S2 = new Object[] {
          new ParDef("lV57Core_documentotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Core_documentotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_documentotipowwds_5_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV60Core_documentotipowwds_5_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV64Core_documentotipowwds_9_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV64Core_documentotipowwds_9_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV68Core_documentotipowwds_13_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV68Core_documentotipowwds_13_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV69Core_documentotipowwds_14_tfdoctiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV70Core_documentotipowwds_15_tfdoctiposigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV71Core_documentotipowwds_16_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV72Core_documentotipowwds_17_tfdoctiponome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003S2,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
