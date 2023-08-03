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
   public class clientewwexport : GXProcedure
   {
      public clientewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientewwexport( IGxContext context )
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
         clientewwexport objclientewwexport;
         objclientewwexport = new clientewwexport();
         objclientewwexport.AV12Filename = "" ;
         objclientewwexport.AV13ErrorMessage = "" ;
         objclientewwexport.context.SetSubmitInitialConfig(context);
         objclientewwexport.initialize();
         Submit( executePrivateCatch,objclientewwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientewwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ClienteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CLIMATRICULA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22CliMatricula1 = (long)(Math.Round(NumberUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22CliMatricula1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", "<=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", ">=", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV22CliMatricula1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "CLIMATRICULA") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26CliMatricula2 = (long)(Math.Round(NumberUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV26CliMatricula2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", "<=", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", ">=", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV26CliMatricula2;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIMATRICULA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30CliMatricula3 = (long)(Math.Round(NumberUtil.Val( AV31GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV30CliMatricula3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", "<=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Matrícula", ">=", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV30CliMatricula3;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliNomeFamiliar_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliNomeFamiliar_Sel)) ? "(Vazio)" : AV48TFCliNomeFamiliar_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliNomeFamiliar)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFCliNomeFamiliar, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV49TFCliMatricula) && (0==AV50TFCliMatricula_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Matrícula") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV49TFCliMatricula;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV50TFCliMatricula_To;
         }
         if ( ! ( ( AV52TFCliTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
            AV14CellRow = GXt_int2;
            AV56i = 1;
            AV57GXV1 = 1;
            while ( AV57GXV1 <= AV52TFCliTipo_Sels.Count )
            {
               AV53TFCliTipo_Sel = (short)(AV52TFCliTipo_Sels.GetNumeric(AV57GXV1));
               if ( AV56i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+GeneXus.Programs.core.gxdomainpessoatipo.getDescription(context,AV53TFCliTipo_Sel);
               AV56i = (long)(AV56i+1);
               AV57GXV1 = (int)(AV57GXV1+1);
            }
         }
         if ( ! ( (DateTime.MinValue==AV54TFCliInsData) && (DateTime.MinValue==AV55TFCliInsData_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído em") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV54TFCliInsData ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV55TFCliInsData_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV44VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV32Session.Get("core.ClienteWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.ClienteWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV58GXV2 = 1;
         while ( AV58GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV58GXV2));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV58GXV2 = (int)(AV58GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Core_clientewwds_1_filterfulltext = AV19FilterFullText;
         AV61Core_clientewwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV62Core_clientewwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV63Core_clientewwds_4_climatricula1 = AV22CliMatricula1;
         AV64Core_clientewwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV65Core_clientewwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV66Core_clientewwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV67Core_clientewwds_8_climatricula2 = AV26CliMatricula2;
         AV68Core_clientewwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV69Core_clientewwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV70Core_clientewwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV71Core_clientewwds_12_climatricula3 = AV30CliMatricula3;
         AV72Core_clientewwds_13_tfclinomefamiliar = AV47TFCliNomeFamiliar;
         AV73Core_clientewwds_14_tfclinomefamiliar_sel = AV48TFCliNomeFamiliar_Sel;
         AV74Core_clientewwds_15_tfclimatricula = AV49TFCliMatricula;
         AV75Core_clientewwds_16_tfclimatricula_to = AV50TFCliMatricula_To;
         AV76Core_clientewwds_17_tfclitipo_sels = AV52TFCliTipo_Sels;
         AV77Core_clientewwds_18_tfcliinsdata = AV54TFCliInsData;
         AV78Core_clientewwds_19_tfcliinsdata_to = AV55TFCliInsData_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A165CliTipo ,
                                              AV76Core_clientewwds_17_tfclitipo_sels ,
                                              AV60Core_clientewwds_1_filterfulltext ,
                                              AV61Core_clientewwds_2_dynamicfiltersselector1 ,
                                              AV62Core_clientewwds_3_dynamicfiltersoperator1 ,
                                              AV63Core_clientewwds_4_climatricula1 ,
                                              AV64Core_clientewwds_5_dynamicfiltersenabled2 ,
                                              AV65Core_clientewwds_6_dynamicfiltersselector2 ,
                                              AV66Core_clientewwds_7_dynamicfiltersoperator2 ,
                                              AV67Core_clientewwds_8_climatricula2 ,
                                              AV68Core_clientewwds_9_dynamicfiltersenabled3 ,
                                              AV69Core_clientewwds_10_dynamicfiltersselector3 ,
                                              AV70Core_clientewwds_11_dynamicfiltersoperator3 ,
                                              AV71Core_clientewwds_12_climatricula3 ,
                                              AV73Core_clientewwds_14_tfclinomefamiliar_sel ,
                                              AV72Core_clientewwds_13_tfclinomefamiliar ,
                                              AV74Core_clientewwds_15_tfclimatricula ,
                                              AV75Core_clientewwds_16_tfclimatricula_to ,
                                              AV76Core_clientewwds_17_tfclitipo_sels.Count ,
                                              AV77Core_clientewwds_18_tfcliinsdata ,
                                              AV78Core_clientewwds_19_tfcliinsdata_to ,
                                              A160CliNomeFamiliar ,
                                              A159CliMatricula ,
                                              A161CliInsData ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Core_clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Core_clientewwds_1_filterfulltext), "%", "");
         lV60Core_clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Core_clientewwds_1_filterfulltext), "%", "");
         lV72Core_clientewwds_13_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV72Core_clientewwds_13_tfclinomefamiliar), "%", "");
         /* Using cursor P00442 */
         pr_default.execute(0, new Object[] {lV60Core_clientewwds_1_filterfulltext, lV60Core_clientewwds_1_filterfulltext, AV63Core_clientewwds_4_climatricula1, AV63Core_clientewwds_4_climatricula1, AV63Core_clientewwds_4_climatricula1, AV67Core_clientewwds_8_climatricula2, AV67Core_clientewwds_8_climatricula2, AV67Core_clientewwds_8_climatricula2, AV71Core_clientewwds_12_climatricula3, AV71Core_clientewwds_12_climatricula3, AV71Core_clientewwds_12_climatricula3, lV72Core_clientewwds_13_tfclinomefamiliar, AV73Core_clientewwds_14_tfclinomefamiliar_sel, AV74Core_clientewwds_15_tfclimatricula, AV75Core_clientewwds_16_tfclimatricula_to, AV77Core_clientewwds_18_tfcliinsdata, AV78Core_clientewwds_19_tfcliinsdata_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A161CliInsData = P00442_A161CliInsData[0];
            A165CliTipo = P00442_A165CliTipo[0];
            A159CliMatricula = P00442_A159CliMatricula[0];
            A160CliNomeFamiliar = P00442_A160CliNomeFamiliar[0];
            A158CliID = P00442_A158CliID[0];
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
            AV79GXV3 = 1;
            while ( AV79GXV3 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV79GXV3));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CliNomeFamiliar") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A160CliNomeFamiliar, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CliMatricula") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A159CliMatricula;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CliTipo") == 0 )
                  {
                     if ( ! (0==A165CliTipo) )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GeneXus.Programs.core.gxdomainpessoatipo.getDescription(context,A165CliTipo);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "CliInsData") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A161CliInsData ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV79GXV3 = (int)(AV79GXV3+1);
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
         AV32Session.Set("WWPExportFileName", "ClienteWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CliNomeFamiliar",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CliMatricula",  "",  "Matrícula",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CliTipo",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "CliInsData",  "",  "Incluído em",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ClienteWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.ClienteWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClienteWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.ClienteWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV80GXV4 = 1;
         while ( AV80GXV4 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV80GXV4));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR") == 0 )
            {
               AV47TFCliNomeFamiliar = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV48TFCliNomeFamiliar_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIMATRICULA") == 0 )
            {
               AV49TFCliMatricula = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV50TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLITIPO_SEL") == 0 )
            {
               AV51TFCliTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV52TFCliTipo_Sels.FromJSonString(AV51TFCliTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIINSDATA") == 0 )
            {
               AV54TFCliInsData = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, 2);
               AV55TFCliInsData_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV80GXV4 = (int)(AV80GXV4+1);
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
         AV24DynamicFiltersSelector2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV48TFCliNomeFamiliar_Sel = "";
         AV47TFCliNomeFamiliar = "";
         AV52TFCliTipo_Sels = new GxSimpleCollection<short>();
         AV54TFCliInsData = DateTime.MinValue;
         AV55TFCliInsData_To = DateTime.MinValue;
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV60Core_clientewwds_1_filterfulltext = "";
         AV61Core_clientewwds_2_dynamicfiltersselector1 = "";
         AV65Core_clientewwds_6_dynamicfiltersselector2 = "";
         AV69Core_clientewwds_10_dynamicfiltersselector3 = "";
         AV72Core_clientewwds_13_tfclinomefamiliar = "";
         AV73Core_clientewwds_14_tfclinomefamiliar_sel = "";
         AV76Core_clientewwds_17_tfclitipo_sels = new GxSimpleCollection<short>();
         AV77Core_clientewwds_18_tfcliinsdata = DateTime.MinValue;
         AV78Core_clientewwds_19_tfcliinsdata_to = DateTime.MinValue;
         scmdbuf = "";
         lV60Core_clientewwds_1_filterfulltext = "";
         lV72Core_clientewwds_13_tfclinomefamiliar = "";
         A160CliNomeFamiliar = "";
         A161CliInsData = DateTime.MinValue;
         P00442_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         P00442_A165CliTipo = new short[1] ;
         P00442_A159CliMatricula = new long[1] ;
         P00442_A160CliNomeFamiliar = new string[] {""} ;
         P00442_A158CliID = new Guid[] {Guid.Empty} ;
         A158CliID = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51TFCliTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientewwexport__default(),
            new Object[][] {
                new Object[] {
               P00442_A161CliInsData, P00442_A165CliTipo, P00442_A159CliMatricula, P00442_A160CliNomeFamiliar, P00442_A158CliID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV53TFCliTipo_Sel ;
      private short GXt_int2 ;
      private short AV62Core_clientewwds_3_dynamicfiltersoperator1 ;
      private short AV66Core_clientewwds_7_dynamicfiltersoperator2 ;
      private short AV70Core_clientewwds_11_dynamicfiltersoperator3 ;
      private short A165CliTipo ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV57GXV1 ;
      private int AV58GXV2 ;
      private int AV76Core_clientewwds_17_tfclitipo_sels_Count ;
      private int AV79GXV3 ;
      private int AV80GXV4 ;
      private long AV22CliMatricula1 ;
      private long AV26CliMatricula2 ;
      private long AV30CliMatricula3 ;
      private long AV49TFCliMatricula ;
      private long AV50TFCliMatricula_To ;
      private long AV56i ;
      private long AV44VisibleColumnCount ;
      private long AV63Core_clientewwds_4_climatricula1 ;
      private long AV67Core_clientewwds_8_climatricula2 ;
      private long AV71Core_clientewwds_12_climatricula3 ;
      private long AV74Core_clientewwds_15_tfclimatricula ;
      private long AV75Core_clientewwds_16_tfclimatricula_to ;
      private long A159CliMatricula ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV54TFCliInsData ;
      private DateTime AV55TFCliInsData_To ;
      private DateTime AV77Core_clientewwds_18_tfcliinsdata ;
      private DateTime AV78Core_clientewwds_19_tfcliinsdata_to ;
      private DateTime A161CliInsData ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV64Core_clientewwds_5_dynamicfiltersenabled2 ;
      private bool AV68Core_clientewwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV51TFCliTipo_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV48TFCliNomeFamiliar_Sel ;
      private string AV47TFCliNomeFamiliar ;
      private string AV60Core_clientewwds_1_filterfulltext ;
      private string AV61Core_clientewwds_2_dynamicfiltersselector1 ;
      private string AV65Core_clientewwds_6_dynamicfiltersselector2 ;
      private string AV69Core_clientewwds_10_dynamicfiltersselector3 ;
      private string AV72Core_clientewwds_13_tfclinomefamiliar ;
      private string AV73Core_clientewwds_14_tfclinomefamiliar_sel ;
      private string lV60Core_clientewwds_1_filterfulltext ;
      private string lV72Core_clientewwds_13_tfclinomefamiliar ;
      private string A160CliNomeFamiliar ;
      private Guid A158CliID ;
      private GxSimpleCollection<short> AV52TFCliTipo_Sels ;
      private GxSimpleCollection<short> AV76Core_clientewwds_17_tfclitipo_sels ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00442_A161CliInsData ;
      private short[] P00442_A165CliTipo ;
      private long[] P00442_A159CliMatricula ;
      private string[] P00442_A160CliNomeFamiliar ;
      private Guid[] P00442_A158CliID ;
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

   public class clientewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00442( IGxContext context ,
                                             short A165CliTipo ,
                                             GxSimpleCollection<short> AV76Core_clientewwds_17_tfclitipo_sels ,
                                             string AV60Core_clientewwds_1_filterfulltext ,
                                             string AV61Core_clientewwds_2_dynamicfiltersselector1 ,
                                             short AV62Core_clientewwds_3_dynamicfiltersoperator1 ,
                                             long AV63Core_clientewwds_4_climatricula1 ,
                                             bool AV64Core_clientewwds_5_dynamicfiltersenabled2 ,
                                             string AV65Core_clientewwds_6_dynamicfiltersselector2 ,
                                             short AV66Core_clientewwds_7_dynamicfiltersoperator2 ,
                                             long AV67Core_clientewwds_8_climatricula2 ,
                                             bool AV68Core_clientewwds_9_dynamicfiltersenabled3 ,
                                             string AV69Core_clientewwds_10_dynamicfiltersselector3 ,
                                             short AV70Core_clientewwds_11_dynamicfiltersoperator3 ,
                                             long AV71Core_clientewwds_12_climatricula3 ,
                                             string AV73Core_clientewwds_14_tfclinomefamiliar_sel ,
                                             string AV72Core_clientewwds_13_tfclinomefamiliar ,
                                             long AV74Core_clientewwds_15_tfclimatricula ,
                                             long AV75Core_clientewwds_16_tfclimatricula_to ,
                                             int AV76Core_clientewwds_17_tfclitipo_sels_Count ,
                                             DateTime AV77Core_clientewwds_18_tfcliinsdata ,
                                             DateTime AV78Core_clientewwds_19_tfcliinsdata_to ,
                                             string A160CliNomeFamiliar ,
                                             long A159CliMatricula ,
                                             DateTime A161CliInsData ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[17];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT CliInsData, CliTipo, CliMatricula, CliNomeFamiliar, CliID FROM tb_cliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CliNomeFamiliar like '%' || :lV60Core_clientewwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(CliMatricula,'999999999999'), 2) like '%' || :lV60Core_clientewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV62Core_clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV63Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV63Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV62Core_clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV63Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV63Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV62Core_clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV63Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV63Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV64Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV66Core_clientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV67Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV67Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV64Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV66Core_clientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV67Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV67Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV64Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV66Core_clientewwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV67Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV67Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV68Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV70Core_clientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV71Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV71Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV68Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV70Core_clientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV71Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV71Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV68Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV70Core_clientewwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV71Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV71Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_clientewwds_14_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_clientewwds_13_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(CliNomeFamiliar like :lV72Core_clientewwds_13_tfclinomefamiliar)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_clientewwds_14_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV73Core_clientewwds_14_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CliNomeFamiliar = ( :AV73Core_clientewwds_14_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV73Core_clientewwds_14_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV74Core_clientewwds_15_tfclimatricula) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV74Core_clientewwds_15_tfclimatricula)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV75Core_clientewwds_16_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV75Core_clientewwds_16_tfclimatricula_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV76Core_clientewwds_17_tfclitipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV76Core_clientewwds_17_tfclitipo_sels, "CliTipo IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV77Core_clientewwds_18_tfcliinsdata) )
         {
            AddWhere(sWhereString, "(CliInsData >= :AV77Core_clientewwds_18_tfcliinsdata)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Core_clientewwds_19_tfcliinsdata_to) )
         {
            AddWhere(sWhereString, "(CliInsData <= :AV78Core_clientewwds_19_tfcliinsdata_to)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY CliNomeFamiliar";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliNomeFamiliar DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY CliMatricula";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliMatricula DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY CliTipo";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliTipo DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY CliInsData";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliInsData DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00442(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP00442;
          prmP00442 = new Object[] {
          new ParDef("lV60Core_clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Core_clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV63Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV63Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV67Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV67Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV67Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV71Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("AV71Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("AV71Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("lV72Core_clientewwds_13_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV73Core_clientewwds_14_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV74Core_clientewwds_15_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV75Core_clientewwds_16_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("AV77Core_clientewwds_18_tfcliinsdata",GXType.Date,8,0) ,
          new ParDef("AV78Core_clientewwds_19_tfcliinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00442", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00442,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
