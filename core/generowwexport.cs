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
   public class generowwexport : GXProcedure
   {
      public generowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generowwexport( IGxContext context )
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
         generowwexport objgenerowwexport;
         objgenerowwexport = new generowwexport();
         objgenerowwexport.AV12Filename = "" ;
         objgenerowwexport.AV13ErrorMessage = "" ;
         objgenerowwexport.context.SetSubmitInitialConfig(context);
         objgenerowwexport.initialize();
         Submit( executePrivateCatch,objgenerowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((generowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "GeneroWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV59GenDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV59GenDel_Filtro);
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "GENSIGLA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV52GenSigla1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52GenSigla1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52GenSigla1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "GENSIGLA") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV53GenSigla2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53GenSigla2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53GenSigla2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "GENSIGLA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV54GenSigla3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54GenSigla3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54GenSigla3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFGenSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFGenSigla_Sel)) ? "(Vazio)" : AV56TFGenSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFGenSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFGenSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFGenNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFGenNome_Sel)) ? "(Vazio)" : AV58TFGenNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFGenNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFGenNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.GeneroWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.GeneroWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV60GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV62Core_generowwds_1_gendel_filtro = AV59GenDel_Filtro;
         AV63Core_generowwds_2_filterfulltext = AV19FilterFullText;
         AV64Core_generowwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV65Core_generowwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV66Core_generowwds_5_gensigla1 = AV52GenSigla1;
         AV67Core_generowwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV68Core_generowwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV69Core_generowwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV70Core_generowwds_9_gensigla2 = AV53GenSigla2;
         AV71Core_generowwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Core_generowwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Core_generowwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Core_generowwds_13_gensigla3 = AV54GenSigla3;
         AV75Core_generowwds_14_tfgensigla = AV55TFGenSigla;
         AV76Core_generowwds_15_tfgensigla_sel = AV56TFGenSigla_Sel;
         AV77Core_generowwds_16_tfgennome = AV57TFGenNome;
         AV78Core_generowwds_17_tfgennome_sel = AV58TFGenNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV63Core_generowwds_2_filterfulltext ,
                                              AV64Core_generowwds_3_dynamicfiltersselector1 ,
                                              AV65Core_generowwds_4_dynamicfiltersoperator1 ,
                                              AV66Core_generowwds_5_gensigla1 ,
                                              AV67Core_generowwds_6_dynamicfiltersenabled2 ,
                                              AV68Core_generowwds_7_dynamicfiltersselector2 ,
                                              AV69Core_generowwds_8_dynamicfiltersoperator2 ,
                                              AV70Core_generowwds_9_gensigla2 ,
                                              AV71Core_generowwds_10_dynamicfiltersenabled3 ,
                                              AV72Core_generowwds_11_dynamicfiltersselector3 ,
                                              AV73Core_generowwds_12_dynamicfiltersoperator3 ,
                                              AV74Core_generowwds_13_gensigla3 ,
                                              AV76Core_generowwds_15_tfgensigla_sel ,
                                              AV75Core_generowwds_14_tfgensigla ,
                                              AV78Core_generowwds_17_tfgennome_sel ,
                                              AV77Core_generowwds_16_tfgennome ,
                                              A153GenSigla ,
                                              A154GenNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A536GenDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV63Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_2_filterfulltext), "%", "");
         lV63Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_2_filterfulltext), "%", "");
         lV66Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV66Core_generowwds_5_gensigla1), "%", "");
         lV66Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV66Core_generowwds_5_gensigla1), "%", "");
         lV70Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_generowwds_9_gensigla2), "%", "");
         lV70Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_generowwds_9_gensigla2), "%", "");
         lV74Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_generowwds_13_gensigla3), "%", "");
         lV74Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_generowwds_13_gensigla3), "%", "");
         lV75Core_generowwds_14_tfgensigla = StringUtil.Concat( StringUtil.RTrim( AV75Core_generowwds_14_tfgensigla), "%", "");
         lV77Core_generowwds_16_tfgennome = StringUtil.Concat( StringUtil.RTrim( AV77Core_generowwds_16_tfgennome), "%", "");
         /* Using cursor P003Y2 */
         pr_default.execute(0, new Object[] {lV63Core_generowwds_2_filterfulltext, lV63Core_generowwds_2_filterfulltext, lV66Core_generowwds_5_gensigla1, lV66Core_generowwds_5_gensigla1, lV70Core_generowwds_9_gensigla2, lV70Core_generowwds_9_gensigla2, lV74Core_generowwds_13_gensigla3, lV74Core_generowwds_13_gensigla3, lV75Core_generowwds_14_tfgensigla, AV76Core_generowwds_15_tfgensigla_sel, lV77Core_generowwds_16_tfgennome, AV78Core_generowwds_17_tfgennome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A154GenNome = P003Y2_A154GenNome[0];
            A153GenSigla = P003Y2_A153GenSigla[0];
            A536GenDel = P003Y2_A536GenDel[0];
            A152GenID = P003Y2_A152GenID[0];
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
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV79GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "GenSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A153GenSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "GenNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A154GenNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV79GXV2 = (int)(AV79GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "GeneroWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "GenSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "GenNome",  "",  "Descrição",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.GeneroWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.GeneroWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.GeneroWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.GeneroWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV80GXV3 = 1;
         while ( AV80GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV80GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "GENDEL_FILTRO") == 0 )
            {
               AV59GenDel_Filtro = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFGENSIGLA") == 0 )
            {
               AV55TFGenSigla = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFGENSIGLA_SEL") == 0 )
            {
               AV56TFGenSigla_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFGENNOME") == 0 )
            {
               AV57TFGenNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFGENNOME_SEL") == 0 )
            {
               AV58TFGenNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV80GXV3 = (int)(AV80GXV3+1);
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
         AV52GenSigla1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV53GenSigla2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV54GenSigla3 = "";
         AV56TFGenSigla_Sel = "";
         AV55TFGenSigla = "";
         AV58TFGenNome_Sel = "";
         AV57TFGenNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV63Core_generowwds_2_filterfulltext = "";
         AV64Core_generowwds_3_dynamicfiltersselector1 = "";
         AV66Core_generowwds_5_gensigla1 = "";
         AV68Core_generowwds_7_dynamicfiltersselector2 = "";
         AV70Core_generowwds_9_gensigla2 = "";
         AV72Core_generowwds_11_dynamicfiltersselector3 = "";
         AV74Core_generowwds_13_gensigla3 = "";
         AV75Core_generowwds_14_tfgensigla = "";
         AV76Core_generowwds_15_tfgensigla_sel = "";
         AV77Core_generowwds_16_tfgennome = "";
         AV78Core_generowwds_17_tfgennome_sel = "";
         scmdbuf = "";
         lV63Core_generowwds_2_filterfulltext = "";
         lV66Core_generowwds_5_gensigla1 = "";
         lV70Core_generowwds_9_gensigla2 = "";
         lV74Core_generowwds_13_gensigla3 = "";
         lV75Core_generowwds_14_tfgensigla = "";
         lV77Core_generowwds_16_tfgennome = "";
         A153GenSigla = "";
         A154GenNome = "";
         P003Y2_A154GenNome = new string[] {""} ;
         P003Y2_A153GenSigla = new string[] {""} ;
         P003Y2_A536GenDel = new bool[] {false} ;
         P003Y2_A152GenID = new int[1] ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.generowwexport__default(),
            new Object[][] {
                new Object[] {
               P003Y2_A154GenNome, P003Y2_A153GenSigla, P003Y2_A536GenDel, P003Y2_A152GenID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV65Core_generowwds_4_dynamicfiltersoperator1 ;
      private short AV69Core_generowwds_8_dynamicfiltersoperator2 ;
      private short AV73Core_generowwds_12_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private int A152GenID ;
      private int AV79GXV2 ;
      private int AV80GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV59GenDel_Filtro ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV62Core_generowwds_1_gendel_filtro ;
      private bool AV67Core_generowwds_6_dynamicfiltersenabled2 ;
      private bool AV71Core_generowwds_10_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool A536GenDel ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV52GenSigla1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV53GenSigla2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV54GenSigla3 ;
      private string AV56TFGenSigla_Sel ;
      private string AV55TFGenSigla ;
      private string AV58TFGenNome_Sel ;
      private string AV57TFGenNome ;
      private string AV63Core_generowwds_2_filterfulltext ;
      private string AV64Core_generowwds_3_dynamicfiltersselector1 ;
      private string AV66Core_generowwds_5_gensigla1 ;
      private string AV68Core_generowwds_7_dynamicfiltersselector2 ;
      private string AV70Core_generowwds_9_gensigla2 ;
      private string AV72Core_generowwds_11_dynamicfiltersselector3 ;
      private string AV74Core_generowwds_13_gensigla3 ;
      private string AV75Core_generowwds_14_tfgensigla ;
      private string AV76Core_generowwds_15_tfgensigla_sel ;
      private string AV77Core_generowwds_16_tfgennome ;
      private string AV78Core_generowwds_17_tfgennome_sel ;
      private string lV63Core_generowwds_2_filterfulltext ;
      private string lV66Core_generowwds_5_gensigla1 ;
      private string lV70Core_generowwds_9_gensigla2 ;
      private string lV74Core_generowwds_13_gensigla3 ;
      private string lV75Core_generowwds_14_tfgensigla ;
      private string lV77Core_generowwds_16_tfgennome ;
      private string A153GenSigla ;
      private string A154GenNome ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003Y2_A154GenNome ;
      private string[] P003Y2_A153GenSigla ;
      private bool[] P003Y2_A536GenDel ;
      private int[] P003Y2_A152GenID ;
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

   public class generowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Y2( IGxContext context ,
                                             string AV63Core_generowwds_2_filterfulltext ,
                                             string AV64Core_generowwds_3_dynamicfiltersselector1 ,
                                             short AV65Core_generowwds_4_dynamicfiltersoperator1 ,
                                             string AV66Core_generowwds_5_gensigla1 ,
                                             bool AV67Core_generowwds_6_dynamicfiltersenabled2 ,
                                             string AV68Core_generowwds_7_dynamicfiltersselector2 ,
                                             short AV69Core_generowwds_8_dynamicfiltersoperator2 ,
                                             string AV70Core_generowwds_9_gensigla2 ,
                                             bool AV71Core_generowwds_10_dynamicfiltersenabled3 ,
                                             string AV72Core_generowwds_11_dynamicfiltersselector3 ,
                                             short AV73Core_generowwds_12_dynamicfiltersoperator3 ,
                                             string AV74Core_generowwds_13_gensigla3 ,
                                             string AV76Core_generowwds_15_tfgensigla_sel ,
                                             string AV75Core_generowwds_14_tfgensigla ,
                                             string AV78Core_generowwds_17_tfgennome_sel ,
                                             string AV77Core_generowwds_16_tfgennome ,
                                             string A153GenSigla ,
                                             string A154GenNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A536GenDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT GenNome, GenSigla, GenDel, GenID FROM tb_genero";
         AddWhere(sWhereString, "(Not GenDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_generowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( GenSigla like '%' || :lV63Core_generowwds_2_filterfulltext) or ( GenNome like '%' || :lV63Core_generowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV65Core_generowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV66Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV65Core_generowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV66Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV67Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV69Core_generowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV70Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV67Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV69Core_generowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV70Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV71Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV73Core_generowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV74Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV71Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV73Core_generowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV74Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_generowwds_15_tfgensigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_generowwds_14_tfgensigla)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV75Core_generowwds_14_tfgensigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_generowwds_15_tfgensigla_sel)) && ! ( StringUtil.StrCmp(AV76Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenSigla = ( :AV76Core_generowwds_15_tfgensigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_generowwds_17_tfgennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_generowwds_16_tfgennome)) ) )
         {
            AddWhere(sWhereString, "(GenNome like :lV77Core_generowwds_16_tfgennome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_generowwds_17_tfgennome_sel)) && ! ( StringUtil.StrCmp(AV78Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenNome = ( :AV78Core_generowwds_17_tfgennome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY GenSigla";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY GenSigla DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY GenNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY GenNome DESC";
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
                     return conditional_P003Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP003Y2;
          prmP003Y2 = new Object[] {
          new ParDef("lV63Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV66Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV74Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV74Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV75Core_generowwds_14_tfgensigla",GXType.VarChar,20,0) ,
          new ParDef("AV76Core_generowwds_15_tfgensigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_generowwds_16_tfgennome",GXType.VarChar,80,0) ,
          new ParDef("AV78Core_generowwds_17_tfgennome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y2,100, GxCacheFrequency.OFF ,true,false )
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
