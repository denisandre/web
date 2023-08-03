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
   public class produtotipowwexport : GXProcedure
   {
      public produtotipowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtotipowwexport( IGxContext context )
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
         produtotipowwexport objprodutotipowwexport;
         objprodutotipowwexport = new produtotipowwexport();
         objprodutotipowwexport.AV12Filename = "" ;
         objprodutotipowwexport.AV13ErrorMessage = "" ;
         objprodutotipowwexport.context.SetSubmitInitialConfig(context);
         objprodutotipowwexport.initialize();
         Submit( executePrivateCatch,objprodutotipowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((produtotipowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ProdutoTipoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV52PrtDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV52PrtDel_Filtro);
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PRTNOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22PrtNome1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PrtNome1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22PrtNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "PRTNOME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26PrtNome2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PrtNome2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26PrtNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PRTNOME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30PrtNome3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30PrtNome3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30PrtNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFPrtSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFPrtSigla_Sel)) ? "(Vazio)" : AV48TFPrtSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFPrtSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFPrtSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPrtNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPrtNome_Sel)) ? "(Vazio)" : AV50TFPrtNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFPrtNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFPrtNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.ProdutoTipoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.ProdutoTipoWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV53GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Core_produtotipowwds_1_prtdel_filtro = AV52PrtDel_Filtro;
         AV56Core_produtotipowwds_2_filterfulltext = AV19FilterFullText;
         AV57Core_produtotipowwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV58Core_produtotipowwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV59Core_produtotipowwds_5_prtnome1 = AV22PrtNome1;
         AV60Core_produtotipowwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV61Core_produtotipowwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV62Core_produtotipowwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV63Core_produtotipowwds_9_prtnome2 = AV26PrtNome2;
         AV64Core_produtotipowwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV65Core_produtotipowwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV66Core_produtotipowwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV67Core_produtotipowwds_13_prtnome3 = AV30PrtNome3;
         AV68Core_produtotipowwds_14_tfprtsigla = AV47TFPrtSigla;
         AV69Core_produtotipowwds_15_tfprtsigla_sel = AV48TFPrtSigla_Sel;
         AV70Core_produtotipowwds_16_tfprtnome = AV49TFPrtNome;
         AV71Core_produtotipowwds_17_tfprtnome_sel = AV50TFPrtNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Core_produtotipowwds_2_filterfulltext ,
                                              AV57Core_produtotipowwds_3_dynamicfiltersselector1 ,
                                              AV58Core_produtotipowwds_4_dynamicfiltersoperator1 ,
                                              AV59Core_produtotipowwds_5_prtnome1 ,
                                              AV60Core_produtotipowwds_6_dynamicfiltersenabled2 ,
                                              AV61Core_produtotipowwds_7_dynamicfiltersselector2 ,
                                              AV62Core_produtotipowwds_8_dynamicfiltersoperator2 ,
                                              AV63Core_produtotipowwds_9_prtnome2 ,
                                              AV64Core_produtotipowwds_10_dynamicfiltersenabled3 ,
                                              AV65Core_produtotipowwds_11_dynamicfiltersselector3 ,
                                              AV66Core_produtotipowwds_12_dynamicfiltersoperator3 ,
                                              AV67Core_produtotipowwds_13_prtnome3 ,
                                              AV69Core_produtotipowwds_15_tfprtsigla_sel ,
                                              AV68Core_produtotipowwds_14_tfprtsigla ,
                                              AV71Core_produtotipowwds_17_tfprtnome_sel ,
                                              AV70Core_produtotipowwds_16_tfprtnome ,
                                              A212PrtSigla ,
                                              A213PrtNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A614PrtDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV56Core_produtotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_produtotipowwds_2_filterfulltext), "%", "");
         lV56Core_produtotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_produtotipowwds_2_filterfulltext), "%", "");
         lV59Core_produtotipowwds_5_prtnome1 = StringUtil.Concat( StringUtil.RTrim( AV59Core_produtotipowwds_5_prtnome1), "%", "");
         lV59Core_produtotipowwds_5_prtnome1 = StringUtil.Concat( StringUtil.RTrim( AV59Core_produtotipowwds_5_prtnome1), "%", "");
         lV63Core_produtotipowwds_9_prtnome2 = StringUtil.Concat( StringUtil.RTrim( AV63Core_produtotipowwds_9_prtnome2), "%", "");
         lV63Core_produtotipowwds_9_prtnome2 = StringUtil.Concat( StringUtil.RTrim( AV63Core_produtotipowwds_9_prtnome2), "%", "");
         lV67Core_produtotipowwds_13_prtnome3 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtotipowwds_13_prtnome3), "%", "");
         lV67Core_produtotipowwds_13_prtnome3 = StringUtil.Concat( StringUtil.RTrim( AV67Core_produtotipowwds_13_prtnome3), "%", "");
         lV68Core_produtotipowwds_14_tfprtsigla = StringUtil.Concat( StringUtil.RTrim( AV68Core_produtotipowwds_14_tfprtsigla), "%", "");
         lV70Core_produtotipowwds_16_tfprtnome = StringUtil.Concat( StringUtil.RTrim( AV70Core_produtotipowwds_16_tfprtnome), "%", "");
         /* Using cursor P004L2 */
         pr_default.execute(0, new Object[] {lV56Core_produtotipowwds_2_filterfulltext, lV56Core_produtotipowwds_2_filterfulltext, lV59Core_produtotipowwds_5_prtnome1, lV59Core_produtotipowwds_5_prtnome1, lV63Core_produtotipowwds_9_prtnome2, lV63Core_produtotipowwds_9_prtnome2, lV67Core_produtotipowwds_13_prtnome3, lV67Core_produtotipowwds_13_prtnome3, lV68Core_produtotipowwds_14_tfprtsigla, AV69Core_produtotipowwds_15_tfprtsigla_sel, lV70Core_produtotipowwds_16_tfprtnome, AV71Core_produtotipowwds_17_tfprtnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A213PrtNome = P004L2_A213PrtNome[0];
            A212PrtSigla = P004L2_A212PrtSigla[0];
            A614PrtDel = P004L2_A614PrtDel[0];
            A211PrtID = P004L2_A211PrtID[0];
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
            AV72GXV2 = 1;
            while ( AV72GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV72GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PrtSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A212PrtSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PrtNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A213PrtNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV72GXV2 = (int)(AV72GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "ProdutoTipoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PrtSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PrtNome",  "",  "Descrição",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ProdutoTipoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.ProdutoTipoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ProdutoTipoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.ProdutoTipoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV73GXV3 = 1;
         while ( AV73GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV73GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PRTDEL_FILTRO") == 0 )
            {
               AV52PrtDel_Filtro = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPRTSIGLA") == 0 )
            {
               AV47TFPrtSigla = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPRTSIGLA_SEL") == 0 )
            {
               AV48TFPrtSigla_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPRTNOME") == 0 )
            {
               AV49TFPrtNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPRTNOME_SEL") == 0 )
            {
               AV50TFPrtNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV73GXV3 = (int)(AV73GXV3+1);
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
         AV22PrtNome1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26PrtNome2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30PrtNome3 = "";
         AV48TFPrtSigla_Sel = "";
         AV47TFPrtSigla = "";
         AV50TFPrtNome_Sel = "";
         AV49TFPrtNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV56Core_produtotipowwds_2_filterfulltext = "";
         AV57Core_produtotipowwds_3_dynamicfiltersselector1 = "";
         AV59Core_produtotipowwds_5_prtnome1 = "";
         AV61Core_produtotipowwds_7_dynamicfiltersselector2 = "";
         AV63Core_produtotipowwds_9_prtnome2 = "";
         AV65Core_produtotipowwds_11_dynamicfiltersselector3 = "";
         AV67Core_produtotipowwds_13_prtnome3 = "";
         AV68Core_produtotipowwds_14_tfprtsigla = "";
         AV69Core_produtotipowwds_15_tfprtsigla_sel = "";
         AV70Core_produtotipowwds_16_tfprtnome = "";
         AV71Core_produtotipowwds_17_tfprtnome_sel = "";
         scmdbuf = "";
         lV56Core_produtotipowwds_2_filterfulltext = "";
         lV59Core_produtotipowwds_5_prtnome1 = "";
         lV63Core_produtotipowwds_9_prtnome2 = "";
         lV67Core_produtotipowwds_13_prtnome3 = "";
         lV68Core_produtotipowwds_14_tfprtsigla = "";
         lV70Core_produtotipowwds_16_tfprtnome = "";
         A212PrtSigla = "";
         A213PrtNome = "";
         P004L2_A213PrtNome = new string[] {""} ;
         P004L2_A212PrtSigla = new string[] {""} ;
         P004L2_A614PrtDel = new bool[] {false} ;
         P004L2_A211PrtID = new int[1] ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtotipowwexport__default(),
            new Object[][] {
                new Object[] {
               P004L2_A213PrtNome, P004L2_A212PrtSigla, P004L2_A614PrtDel, P004L2_A211PrtID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV58Core_produtotipowwds_4_dynamicfiltersoperator1 ;
      private short AV62Core_produtotipowwds_8_dynamicfiltersoperator2 ;
      private short AV66Core_produtotipowwds_12_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV53GXV1 ;
      private int A211PrtID ;
      private int AV72GXV2 ;
      private int AV73GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV52PrtDel_Filtro ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV55Core_produtotipowwds_1_prtdel_filtro ;
      private bool AV60Core_produtotipowwds_6_dynamicfiltersenabled2 ;
      private bool AV64Core_produtotipowwds_10_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool A614PrtDel ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22PrtNome1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26PrtNome2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30PrtNome3 ;
      private string AV48TFPrtSigla_Sel ;
      private string AV47TFPrtSigla ;
      private string AV50TFPrtNome_Sel ;
      private string AV49TFPrtNome ;
      private string AV56Core_produtotipowwds_2_filterfulltext ;
      private string AV57Core_produtotipowwds_3_dynamicfiltersselector1 ;
      private string AV59Core_produtotipowwds_5_prtnome1 ;
      private string AV61Core_produtotipowwds_7_dynamicfiltersselector2 ;
      private string AV63Core_produtotipowwds_9_prtnome2 ;
      private string AV65Core_produtotipowwds_11_dynamicfiltersselector3 ;
      private string AV67Core_produtotipowwds_13_prtnome3 ;
      private string AV68Core_produtotipowwds_14_tfprtsigla ;
      private string AV69Core_produtotipowwds_15_tfprtsigla_sel ;
      private string AV70Core_produtotipowwds_16_tfprtnome ;
      private string AV71Core_produtotipowwds_17_tfprtnome_sel ;
      private string lV56Core_produtotipowwds_2_filterfulltext ;
      private string lV59Core_produtotipowwds_5_prtnome1 ;
      private string lV63Core_produtotipowwds_9_prtnome2 ;
      private string lV67Core_produtotipowwds_13_prtnome3 ;
      private string lV68Core_produtotipowwds_14_tfprtsigla ;
      private string lV70Core_produtotipowwds_16_tfprtnome ;
      private string A212PrtSigla ;
      private string A213PrtNome ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004L2_A213PrtNome ;
      private string[] P004L2_A212PrtSigla ;
      private bool[] P004L2_A614PrtDel ;
      private int[] P004L2_A211PrtID ;
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

   public class produtotipowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004L2( IGxContext context ,
                                             string AV56Core_produtotipowwds_2_filterfulltext ,
                                             string AV57Core_produtotipowwds_3_dynamicfiltersselector1 ,
                                             short AV58Core_produtotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV59Core_produtotipowwds_5_prtnome1 ,
                                             bool AV60Core_produtotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV61Core_produtotipowwds_7_dynamicfiltersselector2 ,
                                             short AV62Core_produtotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV63Core_produtotipowwds_9_prtnome2 ,
                                             bool AV64Core_produtotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV65Core_produtotipowwds_11_dynamicfiltersselector3 ,
                                             short AV66Core_produtotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV67Core_produtotipowwds_13_prtnome3 ,
                                             string AV69Core_produtotipowwds_15_tfprtsigla_sel ,
                                             string AV68Core_produtotipowwds_14_tfprtsigla ,
                                             string AV71Core_produtotipowwds_17_tfprtnome_sel ,
                                             string AV70Core_produtotipowwds_16_tfprtnome ,
                                             string A212PrtSigla ,
                                             string A213PrtNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A614PrtDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PrtNome, PrtSigla, PrtDel, PrtID FROM tb_produtotipo";
         AddWhere(sWhereString, "(Not PrtDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_produtotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PrtSigla like '%' || :lV56Core_produtotipowwds_2_filterfulltext) or ( PrtNome like '%' || :lV56Core_produtotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Core_produtotipowwds_3_dynamicfiltersselector1, "PRTNOME") == 0 ) && ( AV58Core_produtotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_produtotipowwds_5_prtnome1)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV59Core_produtotipowwds_5_prtnome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Core_produtotipowwds_3_dynamicfiltersselector1, "PRTNOME") == 0 ) && ( AV58Core_produtotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_produtotipowwds_5_prtnome1)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like '%' || :lV59Core_produtotipowwds_5_prtnome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Core_produtotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Core_produtotipowwds_7_dynamicfiltersselector2, "PRTNOME") == 0 ) && ( AV62Core_produtotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_produtotipowwds_9_prtnome2)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV63Core_produtotipowwds_9_prtnome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Core_produtotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Core_produtotipowwds_7_dynamicfiltersselector2, "PRTNOME") == 0 ) && ( AV62Core_produtotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_produtotipowwds_9_prtnome2)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like '%' || :lV63Core_produtotipowwds_9_prtnome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV64Core_produtotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Core_produtotipowwds_11_dynamicfiltersselector3, "PRTNOME") == 0 ) && ( AV66Core_produtotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtotipowwds_13_prtnome3)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV67Core_produtotipowwds_13_prtnome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV64Core_produtotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Core_produtotipowwds_11_dynamicfiltersselector3, "PRTNOME") == 0 ) && ( AV66Core_produtotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtotipowwds_13_prtnome3)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like '%' || :lV67Core_produtotipowwds_13_prtnome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtotipowwds_15_tfprtsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_produtotipowwds_14_tfprtsigla)) ) )
         {
            AddWhere(sWhereString, "(PrtSigla like :lV68Core_produtotipowwds_14_tfprtsigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtotipowwds_15_tfprtsigla_sel)) && ! ( StringUtil.StrCmp(AV69Core_produtotipowwds_15_tfprtsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PrtSigla = ( :AV69Core_produtotipowwds_15_tfprtsigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_produtotipowwds_15_tfprtsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PrtSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtotipowwds_17_tfprtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_produtotipowwds_16_tfprtnome)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV70Core_produtotipowwds_16_tfprtnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_produtotipowwds_17_tfprtnome_sel)) && ! ( StringUtil.StrCmp(AV71Core_produtotipowwds_17_tfprtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PrtNome = ( :AV71Core_produtotipowwds_17_tfprtnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV71Core_produtotipowwds_17_tfprtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PrtNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY PrtNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PrtNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY PrtSigla";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PrtSigla DESC";
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
                     return conditional_P004L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP004L2;
          prmP004L2 = new Object[] {
          new ParDef("lV56Core_produtotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_produtotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Core_produtotipowwds_5_prtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV59Core_produtotipowwds_5_prtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV63Core_produtotipowwds_9_prtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV63Core_produtotipowwds_9_prtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV67Core_produtotipowwds_13_prtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV67Core_produtotipowwds_13_prtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_produtotipowwds_14_tfprtsigla",GXType.VarChar,20,0) ,
          new ParDef("AV69Core_produtotipowwds_15_tfprtsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_produtotipowwds_16_tfprtnome",GXType.VarChar,80,0) ,
          new ParDef("AV71Core_produtotipowwds_17_tfprtnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L2,100, GxCacheFrequency.OFF ,true,false )
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
