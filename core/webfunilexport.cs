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
   public class webfunilexport : GXProcedure
   {
      public webfunilexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webfunilexport( IGxContext context )
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
         webfunilexport objwebfunilexport;
         objwebfunilexport = new webfunilexport();
         objwebfunilexport.AV12Filename = "" ;
         objwebfunilexport.AV13ErrorMessage = "" ;
         objwebfunilexport.context.SetSubmitInitialConfig(context);
         objwebfunilexport.initialize();
         Submit( executePrivateCatch,objwebfunilexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((webfunilexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "webfunilExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "ITENOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22IteNome1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22IteNome1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22IteNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "ITENOME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26IteNome2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26IteNome2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26IteNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "ITENOME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30IteNome3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30IteNome3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30IteNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIteNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Iteração") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIteNome_Sel)) ? "(Vazio)" : AV48TFIteNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFIteNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Iteração") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFIteNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.webfunilColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.webfunilColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV55GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV57Core_webfunilds_1_filterfulltext = AV19FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV22IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV26IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV30IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV47TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV48TFIteNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Core_webfunilds_2_dynamicfiltersselector1 ,
                                              AV59Core_webfunilds_3_dynamicfiltersoperator1 ,
                                              AV60Core_webfunilds_4_itenome1 ,
                                              AV61Core_webfunilds_5_dynamicfiltersenabled2 ,
                                              AV62Core_webfunilds_6_dynamicfiltersselector2 ,
                                              AV63Core_webfunilds_7_dynamicfiltersoperator2 ,
                                              AV64Core_webfunilds_8_itenome2 ,
                                              AV65Core_webfunilds_9_dynamicfiltersenabled3 ,
                                              AV66Core_webfunilds_10_dynamicfiltersselector3 ,
                                              AV67Core_webfunilds_11_dynamicfiltersoperator3 ,
                                              AV68Core_webfunilds_12_itenome3 ,
                                              AV70Core_webfunilds_14_tfitenome_sel ,
                                              AV69Core_webfunilds_13_tfitenome ,
                                              A383IteNome ,
                                              AV18OrderedDsc ,
                                              AV57Core_webfunilds_1_filterfulltext ,
                                              A431IteTotalOportunidades ,
                                              A432IteQtdeOportunidades ,
                                              A381IteID ,
                                              A420NegUltIteID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV60Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_webfunilds_4_itenome1), "%", "");
         lV60Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_webfunilds_4_itenome1), "%", "");
         lV64Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_8_itenome2), "%", "");
         lV64Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_8_itenome2), "%", "");
         lV68Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_12_itenome3), "%", "");
         lV68Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_12_itenome3), "%", "");
         lV69Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV69Core_webfunilds_13_tfitenome), "%", "");
         /* Using cursor P00602 */
         pr_default.execute(0, new Object[] {lV60Core_webfunilds_4_itenome1, lV60Core_webfunilds_4_itenome1, lV64Core_webfunilds_8_itenome2, lV64Core_webfunilds_8_itenome2, lV68Core_webfunilds_12_itenome3, lV68Core_webfunilds_12_itenome3, lV69Core_webfunilds_13_tfitenome, AV70Core_webfunilds_14_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A383IteNome = P00602_A383IteNome[0];
            A382IteOrdem = P00602_A382IteOrdem[0];
            A381IteID = P00602_A381IteID[0];
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV57Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV57Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV57Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
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
               AV71GXV2 = 1;
               while ( AV71GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
               {
                  AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV71GXV2));
                  if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
                  {
                     if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "IteNome") == 0 )
                     {
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A383IteNome, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "IteQtdeOportunidades") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A432IteQtdeOportunidades;
                     }
                     else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "IteTotalOportunidades") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A431IteTotalOportunidades);
                     }
                     AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
                  }
                  AV71GXV2 = (int)(AV71GXV2+1);
               }
               /* Execute user subroutine: 'AFTERWRITELINE' */
               S182 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
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
         AV32Session.Set("WWPExportFileName", "webfunilExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "IteNome",  "",  "Iteração",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "IteQtdeOportunidades",  "",  "Quantidade de Oportunidades",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "IteTotalOportunidades",  "",  "Total em Oportunidades",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.webfunilColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.webfunilGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.webfunilGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.webfunilGridState"), null, "", "");
         }
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV72GXV3 = 1;
         while ( AV72GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV72GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV47TFIteNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV48TFIteNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV72GXV3 = (int)(AV72GXV3+1);
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

      protected int GetIteQtdeOportunidades0( Guid E381IteID )
      {
         Gx_cnt = 0;
         /* Using cursor P00603 */
         pr_default.execute(1, new Object[] {E381IteID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            Gx_cnt = P00603_Gx_cnt[0];
         }
         pr_default.close(1);
         return Gx_cnt ;
      }

      protected decimal GetIteTotalOportunidades0( Guid E381IteID )
      {
         X385NegValorAtualizado = 0;
         /* Using cursor P00604 */
         pr_default.execute(2, new Object[] {E381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            X385NegValorAtualizado = P00604_A385NegValorAtualizado[0];
         }
         pr_default.close(2);
         return X385NegValorAtualizado ;
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
         AV22IteNome1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26IteNome2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30IteNome3 = "";
         AV48TFIteNome_Sel = "";
         AV47TFIteNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV57Core_webfunilds_1_filterfulltext = "";
         AV58Core_webfunilds_2_dynamicfiltersselector1 = "";
         AV60Core_webfunilds_4_itenome1 = "";
         AV62Core_webfunilds_6_dynamicfiltersselector2 = "";
         AV64Core_webfunilds_8_itenome2 = "";
         AV66Core_webfunilds_10_dynamicfiltersselector3 = "";
         AV68Core_webfunilds_12_itenome3 = "";
         AV69Core_webfunilds_13_tfitenome = "";
         AV70Core_webfunilds_14_tfitenome_sel = "";
         scmdbuf = "";
         lV60Core_webfunilds_4_itenome1 = "";
         lV64Core_webfunilds_8_itenome2 = "";
         lV68Core_webfunilds_12_itenome3 = "";
         lV69Core_webfunilds_13_tfitenome = "";
         A383IteNome = "";
         A381IteID = Guid.Empty;
         A420NegUltIteID = Guid.Empty;
         P00602_A383IteNome = new string[] {""} ;
         P00602_A382IteOrdem = new int[1] ;
         P00602_A381IteID = new Guid[] {Guid.Empty} ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         E381IteID = Guid.Empty;
         P00603_Gx_cnt = new int[1] ;
         P00604_A385NegValorAtualizado = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.webfunilexport__default(),
            new Object[][] {
                new Object[] {
               P00602_A383IteNome, P00602_A382IteOrdem, P00602_A381IteID
               }
               , new Object[] {
               P00603_Gx_cnt
               }
               , new Object[] {
               P00604_A385NegValorAtualizado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV59Core_webfunilds_3_dynamicfiltersoperator1 ;
      private short AV63Core_webfunilds_7_dynamicfiltersoperator2 ;
      private short AV67Core_webfunilds_11_dynamicfiltersoperator3 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV55GXV1 ;
      private int A432IteQtdeOportunidades ;
      private int A382IteOrdem ;
      private int AV71GXV2 ;
      private int AV72GXV3 ;
      private int Gx_cnt ;
      private long AV44VisibleColumnCount ;
      private decimal A431IteTotalOportunidades ;
      private decimal X385NegValorAtualizado ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV61Core_webfunilds_5_dynamicfiltersenabled2 ;
      private bool AV65Core_webfunilds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22IteNome1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26IteNome2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30IteNome3 ;
      private string AV48TFIteNome_Sel ;
      private string AV47TFIteNome ;
      private string AV57Core_webfunilds_1_filterfulltext ;
      private string AV58Core_webfunilds_2_dynamicfiltersselector1 ;
      private string AV60Core_webfunilds_4_itenome1 ;
      private string AV62Core_webfunilds_6_dynamicfiltersselector2 ;
      private string AV64Core_webfunilds_8_itenome2 ;
      private string AV66Core_webfunilds_10_dynamicfiltersselector3 ;
      private string AV68Core_webfunilds_12_itenome3 ;
      private string AV69Core_webfunilds_13_tfitenome ;
      private string AV70Core_webfunilds_14_tfitenome_sel ;
      private string lV60Core_webfunilds_4_itenome1 ;
      private string lV64Core_webfunilds_8_itenome2 ;
      private string lV68Core_webfunilds_12_itenome3 ;
      private string lV69Core_webfunilds_13_tfitenome ;
      private string A383IteNome ;
      private Guid A381IteID ;
      private Guid A420NegUltIteID ;
      private Guid E381IteID ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00602_A383IteNome ;
      private int[] P00602_A382IteOrdem ;
      private Guid[] P00602_A381IteID ;
      private int[] P00603_Gx_cnt ;
      private decimal[] P00604_A385NegValorAtualizado ;
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

   public class webfunilexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00602( IGxContext context ,
                                             string AV58Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV59Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV60Core_webfunilds_4_itenome1 ,
                                             bool AV61Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV62Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV63Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV64Core_webfunilds_8_itenome2 ,
                                             bool AV65Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV66Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV67Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV68Core_webfunilds_12_itenome3 ,
                                             string AV70Core_webfunilds_14_tfitenome_sel ,
                                             string AV69Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             bool AV18OrderedDsc ,
                                             string AV57Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT IteNome, IteOrdem, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV58Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV59Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV60Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV59Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV60Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV61Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV63Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV64Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV61Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV63Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV64Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV65Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV67Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV68Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV65Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV67Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV68Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV69Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV70Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV70Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IteNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem";
         }
         else if ( AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem DESC";
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
                     return conditional_P00602(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (int)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
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
          Object[] prmP00603;
          prmP00603 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00604;
          prmP00604 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00602;
          prmP00602 = new Object[] {
          new ParDef("lV60Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV70Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00602", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00602,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00603", "SELECT COUNT(*) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00603,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00604", "SELECT SUM(NegValorAtualizado) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00604,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
