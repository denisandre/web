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
   public class tabeladeprecowwexport : GXProcedure
   {
      public tabeladeprecowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladeprecowwexport( IGxContext context )
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
         tabeladeprecowwexport objtabeladeprecowwexport;
         objtabeladeprecowwexport = new tabeladeprecowwexport();
         objtabeladeprecowwexport.AV12Filename = "" ;
         objtabeladeprecowwexport.AV13ErrorMessage = "" ;
         objtabeladeprecowwexport.context.SetSubmitInitialConfig(context);
         objtabeladeprecowwexport.initialize();
         Submit( executePrivateCatch,objtabeladeprecowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tabeladeprecowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "TabelaDePrecoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV69TppDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV69TppDel_Filtro);
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "TPPCODIGO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22TppCodigo1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TppCodigo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "C�digo", "Come�a com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "C�digo", "Cont�m", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22TppCodigo1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "TPPCODIGO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26TppCodigo2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TppCodigo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "C�digo", "Come�a com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "C�digo", "Cont�m", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26TppCodigo2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TPPCODIGO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30TppCodigo3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TppCodigo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "C�digo", "Come�a com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "C�digo", "Cont�m", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30TppCodigo3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTppCodigo_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "C�digo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTppCodigo_Sel)) ? "(Vazio)" : AV48TFTppCodigo_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFTppCodigo)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "C�digo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFTppCodigo, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTppNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descri��o") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFTppNome_Sel)) ? "(Vazio)" : AV50TFTppNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTppNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descri��o") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFTppNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV51TFTppInsData) && (DateTime.MinValue==AV52TFTppInsData_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Inclu�do em") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TFTppInsData ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "At�") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV52TFTppInsData_To ) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.TabelaDePrecoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.TabelaDePrecoWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV70GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV72Core_tabeladeprecowwds_1_tppdel_filtro = AV69TppDel_Filtro;
         AV73Core_tabeladeprecowwds_2_filterfulltext = AV19FilterFullText;
         AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV75Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV76Core_tabeladeprecowwds_5_tppcodigo1 = AV22TppCodigo1;
         AV77Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV79Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV80Core_tabeladeprecowwds_9_tppcodigo2 = AV26TppCodigo2;
         AV81Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV83Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV84Core_tabeladeprecowwds_13_tppcodigo3 = AV30TppCodigo3;
         AV85Core_tabeladeprecowwds_14_tftppcodigo = AV47TFTppCodigo;
         AV86Core_tabeladeprecowwds_15_tftppcodigo_sel = AV48TFTppCodigo_Sel;
         AV87Core_tabeladeprecowwds_16_tftppnome = AV49TFTppNome;
         AV88Core_tabeladeprecowwds_17_tftppnome_sel = AV50TFTppNome_Sel;
         AV89Core_tabeladeprecowwds_18_tftppinsdata = AV51TFTppInsData;
         AV90Core_tabeladeprecowwds_19_tftppinsdata_to = AV52TFTppInsData_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV73Core_tabeladeprecowwds_2_filterfulltext ,
                                              AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                              AV75Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                              AV76Core_tabeladeprecowwds_5_tppcodigo1 ,
                                              AV77Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                              AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                              AV79Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                              AV80Core_tabeladeprecowwds_9_tppcodigo2 ,
                                              AV81Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                              AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                              AV83Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                              AV84Core_tabeladeprecowwds_13_tppcodigo3 ,
                                              AV86Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                              AV85Core_tabeladeprecowwds_14_tftppcodigo ,
                                              AV88Core_tabeladeprecowwds_17_tftppnome_sel ,
                                              AV87Core_tabeladeprecowwds_16_tftppnome ,
                                              AV89Core_tabeladeprecowwds_18_tftppinsdata ,
                                              AV90Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                              A236TppCodigo ,
                                              A237TppNome ,
                                              A238TppInsData ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A602TppDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV73Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV73Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV76Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV76Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV76Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV76Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV80Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV80Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV80Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV80Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV84Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV84Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV84Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV84Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV85Core_tabeladeprecowwds_14_tftppcodigo = StringUtil.Concat( StringUtil.RTrim( AV85Core_tabeladeprecowwds_14_tftppcodigo), "%", "");
         lV87Core_tabeladeprecowwds_16_tftppnome = StringUtil.Concat( StringUtil.RTrim( AV87Core_tabeladeprecowwds_16_tftppnome), "%", "");
         /* Using cursor P004G2 */
         pr_default.execute(0, new Object[] {lV73Core_tabeladeprecowwds_2_filterfulltext, lV73Core_tabeladeprecowwds_2_filterfulltext, lV76Core_tabeladeprecowwds_5_tppcodigo1, lV76Core_tabeladeprecowwds_5_tppcodigo1, lV80Core_tabeladeprecowwds_9_tppcodigo2, lV80Core_tabeladeprecowwds_9_tppcodigo2, lV84Core_tabeladeprecowwds_13_tppcodigo3, lV84Core_tabeladeprecowwds_13_tppcodigo3, lV85Core_tabeladeprecowwds_14_tftppcodigo, AV86Core_tabeladeprecowwds_15_tftppcodigo_sel, lV87Core_tabeladeprecowwds_16_tftppnome, AV88Core_tabeladeprecowwds_17_tftppnome_sel, AV89Core_tabeladeprecowwds_18_tftppinsdata, AV90Core_tabeladeprecowwds_19_tftppinsdata_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A238TppInsData = P004G2_A238TppInsData[0];
            A237TppNome = P004G2_A237TppNome[0];
            A236TppCodigo = P004G2_A236TppCodigo[0];
            A602TppDel = P004G2_A602TppDel[0];
            A235TppID = P004G2_A235TppID[0];
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
            AV91GXV2 = 1;
            while ( AV91GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV91GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TppCodigo") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A236TppCodigo, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TppNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A237TppNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "TppInsData") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A238TppInsData ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV91GXV2 = (int)(AV91GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "TabelaDePrecoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TppCodigo",  "",  "C�digo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TppNome",  "",  "Descri��o",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "TppInsData",  "",  "Inclu�do em",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.TabelaDePrecoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.TabelaDePrecoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.TabelaDePrecoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.TabelaDePrecoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV92GXV3 = 1;
         while ( AV92GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV92GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TPPDEL_FILTRO") == 0 )
            {
               AV69TppDel_Filtro = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO") == 0 )
            {
               AV47TFTppCodigo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO_SEL") == 0 )
            {
               AV48TFTppCodigo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTPPNOME") == 0 )
            {
               AV49TFTppNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTPPNOME_SEL") == 0 )
            {
               AV50TFTppNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFTPPINSDATA") == 0 )
            {
               AV51TFTppInsData = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, 2);
               AV52TFTppInsData_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV92GXV3 = (int)(AV92GXV3+1);
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
         AV22TppCodigo1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26TppCodigo2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30TppCodigo3 = "";
         AV48TFTppCodigo_Sel = "";
         AV47TFTppCodigo = "";
         AV50TFTppNome_Sel = "";
         AV49TFTppNome = "";
         AV51TFTppInsData = DateTime.MinValue;
         AV52TFTppInsData_To = DateTime.MinValue;
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV73Core_tabeladeprecowwds_2_filterfulltext = "";
         AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1 = "";
         AV76Core_tabeladeprecowwds_5_tppcodigo1 = "";
         AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2 = "";
         AV80Core_tabeladeprecowwds_9_tppcodigo2 = "";
         AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3 = "";
         AV84Core_tabeladeprecowwds_13_tppcodigo3 = "";
         AV85Core_tabeladeprecowwds_14_tftppcodigo = "";
         AV86Core_tabeladeprecowwds_15_tftppcodigo_sel = "";
         AV87Core_tabeladeprecowwds_16_tftppnome = "";
         AV88Core_tabeladeprecowwds_17_tftppnome_sel = "";
         AV89Core_tabeladeprecowwds_18_tftppinsdata = DateTime.MinValue;
         AV90Core_tabeladeprecowwds_19_tftppinsdata_to = DateTime.MinValue;
         scmdbuf = "";
         lV73Core_tabeladeprecowwds_2_filterfulltext = "";
         lV76Core_tabeladeprecowwds_5_tppcodigo1 = "";
         lV80Core_tabeladeprecowwds_9_tppcodigo2 = "";
         lV84Core_tabeladeprecowwds_13_tppcodigo3 = "";
         lV85Core_tabeladeprecowwds_14_tftppcodigo = "";
         lV87Core_tabeladeprecowwds_16_tftppnome = "";
         A236TppCodigo = "";
         A237TppNome = "";
         A238TppInsData = DateTime.MinValue;
         P004G2_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P004G2_A237TppNome = new string[] {""} ;
         P004G2_A236TppCodigo = new string[] {""} ;
         P004G2_A602TppDel = new bool[] {false} ;
         P004G2_A235TppID = new Guid[] {Guid.Empty} ;
         A235TppID = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladeprecowwexport__default(),
            new Object[][] {
                new Object[] {
               P004G2_A238TppInsData, P004G2_A237TppNome, P004G2_A236TppCodigo, P004G2_A602TppDel, P004G2_A235TppID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV75Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ;
      private short AV79Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ;
      private short AV83Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV70GXV1 ;
      private int AV91GXV2 ;
      private int AV92GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV51TFTppInsData ;
      private DateTime AV52TFTppInsData_To ;
      private DateTime AV89Core_tabeladeprecowwds_18_tftppinsdata ;
      private DateTime AV90Core_tabeladeprecowwds_19_tftppinsdata_to ;
      private DateTime A238TppInsData ;
      private bool returnInSub ;
      private bool AV69TppDel_Filtro ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV72Core_tabeladeprecowwds_1_tppdel_filtro ;
      private bool AV77Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ;
      private bool AV81Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool A602TppDel ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22TppCodigo1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26TppCodigo2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30TppCodigo3 ;
      private string AV48TFTppCodigo_Sel ;
      private string AV47TFTppCodigo ;
      private string AV50TFTppNome_Sel ;
      private string AV49TFTppNome ;
      private string AV73Core_tabeladeprecowwds_2_filterfulltext ;
      private string AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1 ;
      private string AV76Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2 ;
      private string AV80Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3 ;
      private string AV84Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string AV85Core_tabeladeprecowwds_14_tftppcodigo ;
      private string AV86Core_tabeladeprecowwds_15_tftppcodigo_sel ;
      private string AV87Core_tabeladeprecowwds_16_tftppnome ;
      private string AV88Core_tabeladeprecowwds_17_tftppnome_sel ;
      private string lV73Core_tabeladeprecowwds_2_filterfulltext ;
      private string lV76Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string lV80Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string lV84Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string lV85Core_tabeladeprecowwds_14_tftppcodigo ;
      private string lV87Core_tabeladeprecowwds_16_tftppnome ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private Guid A235TppID ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P004G2_A238TppInsData ;
      private string[] P004G2_A237TppNome ;
      private string[] P004G2_A236TppCodigo ;
      private bool[] P004G2_A602TppDel ;
      private Guid[] P004G2_A235TppID ;
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

   public class tabeladeprecowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004G2( IGxContext context ,
                                             string AV73Core_tabeladeprecowwds_2_filterfulltext ,
                                             string AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                             short AV75Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                             string AV76Core_tabeladeprecowwds_5_tppcodigo1 ,
                                             bool AV77Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                             string AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                             short AV79Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                             string AV80Core_tabeladeprecowwds_9_tppcodigo2 ,
                                             bool AV81Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                             string AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                             short AV83Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                             string AV84Core_tabeladeprecowwds_13_tppcodigo3 ,
                                             string AV86Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                             string AV85Core_tabeladeprecowwds_14_tftppcodigo ,
                                             string AV88Core_tabeladeprecowwds_17_tftppnome_sel ,
                                             string AV87Core_tabeladeprecowwds_16_tftppnome ,
                                             DateTime AV89Core_tabeladeprecowwds_18_tftppinsdata ,
                                             DateTime AV90Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                             string A236TppCodigo ,
                                             string A237TppNome ,
                                             DateTime A238TppInsData ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A602TppDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT TppInsData, TppNome, TppCodigo, TppDel, TppID FROM tb_tabeladepreco";
         AddWhere(sWhereString, "(Not TppDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_tabeladeprecowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TppCodigo like '%' || :lV73Core_tabeladeprecowwds_2_filterfulltext) or ( TppNome like '%' || :lV73Core_tabeladeprecowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV75Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV76Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV75Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV76Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV77Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV79Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV80Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV77Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV79Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV80Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV81Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV83Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV84Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV81Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV82Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV83Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV84Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_14_tftppcodigo)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV85Core_tabeladeprecowwds_14_tftppcodigo)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ! ( StringUtil.StrCmp(AV86Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppCodigo = ( :AV86Core_tabeladeprecowwds_15_tftppcodigo_sel))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV86Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_tabeladeprecowwds_17_tftppnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_tabeladeprecowwds_16_tftppnome)) ) )
         {
            AddWhere(sWhereString, "(TppNome like :lV87Core_tabeladeprecowwds_16_tftppnome)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_tabeladeprecowwds_17_tftppnome_sel)) && ! ( StringUtil.StrCmp(AV88Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppNome = ( :AV88Core_tabeladeprecowwds_17_tftppnome_sel))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV88Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV89Core_tabeladeprecowwds_18_tftppinsdata) )
         {
            AddWhere(sWhereString, "(TppInsData >= :AV89Core_tabeladeprecowwds_18_tftppinsdata)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Core_tabeladeprecowwds_19_tftppinsdata_to) )
         {
            AddWhere(sWhereString, "(TppInsData <= :AV90Core_tabeladeprecowwds_19_tftppinsdata_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY TppCodigo";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TppCodigo DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY TppNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TppNome DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY TppInsData";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TppInsData DESC";
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
                     return conditional_P004G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (bool)dynConstraints[23] );
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
          Object[] prmP004G2;
          prmP004G2 = new Object[] {
          new ParDef("lV73Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV76Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV76Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV80Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV80Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV84Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV84Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV85Core_tabeladeprecowwds_14_tftppcodigo",GXType.VarChar,20,0) ,
          new ParDef("AV86Core_tabeladeprecowwds_15_tftppcodigo_sel",GXType.VarChar,20,0) ,
          new ParDef("lV87Core_tabeladeprecowwds_16_tftppnome",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_tabeladeprecowwds_17_tftppnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV89Core_tabeladeprecowwds_18_tftppinsdata",GXType.Date,8,0) ,
          new ParDef("AV90Core_tabeladeprecowwds_19_tftppinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
