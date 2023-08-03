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
   public class produtowwexport : GXProcedure
   {
      public produtowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtowwexport( IGxContext context )
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
         produtowwexport objprodutowwexport;
         objprodutowwexport = new produtowwexport();
         objprodutowwexport.AV12Filename = "" ;
         objprodutowwexport.AV13ErrorMessage = "" ;
         objprodutowwexport.context.SetSubmitInitialConfig(context);
         objprodutowwexport.initialize();
         Submit( executePrivateCatch,objprodutowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((produtowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ProdutoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV57PrdDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV57PrdDel_Filtro);
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
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PRDCODIGO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22PrdCodigo1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PrdCodigo1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22PrdCodigo1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PRDTIPONOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23PrdTipoNome1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23PrdTipoNome1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23PrdTipoNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PRDCODIGO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27PrdCodigo2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27PrdCodigo2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27PrdCodigo2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "PRDTIPONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28PrdTipoNome2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28PrdTipoNome2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28PrdTipoNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PRDCODIGO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32PrdCodigo3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32PrdCodigo3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32PrdCodigo3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "PRDTIPONOME") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33PrdTipoNome3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33PrdTipoNome3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33PrdTipoNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFPrdCodigo_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Código") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFPrdCodigo_Sel)) ? "(Vazio)" : AV51TFPrdCodigo_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFPrdCodigo)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Código") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFPrdCodigo, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFPrdNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFPrdNome_Sel)) ? "(Vazio)" : AV53TFPrdNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFPrdNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFPrdNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPrdTipoSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo do Produto") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFPrdTipoSigla_Sel)) ? "(Vazio)" : AV55TFPrdTipoSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFPrdTipoSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo do Produto") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFPrdTipoSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("core.ProdutoWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("core.ProdutoWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV58GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Core_produtowwds_1_prddel_filtro = AV57PrdDel_Filtro;
         AV61Core_produtowwds_2_filterfulltext = AV19FilterFullText;
         AV62Core_produtowwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV63Core_produtowwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV64Core_produtowwds_5_prdcodigo1 = AV22PrdCodigo1;
         AV65Core_produtowwds_6_prdtiponome1 = AV23PrdTipoNome1;
         AV66Core_produtowwds_7_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV67Core_produtowwds_8_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV68Core_produtowwds_9_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV69Core_produtowwds_10_prdcodigo2 = AV27PrdCodigo2;
         AV70Core_produtowwds_11_prdtiponome2 = AV28PrdTipoNome2;
         AV71Core_produtowwds_12_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV72Core_produtowwds_13_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV73Core_produtowwds_14_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV74Core_produtowwds_15_prdcodigo3 = AV32PrdCodigo3;
         AV75Core_produtowwds_16_prdtiponome3 = AV33PrdTipoNome3;
         AV76Core_produtowwds_17_tfprdcodigo = AV50TFPrdCodigo;
         AV77Core_produtowwds_18_tfprdcodigo_sel = AV51TFPrdCodigo_Sel;
         AV78Core_produtowwds_19_tfprdnome = AV52TFPrdNome;
         AV79Core_produtowwds_20_tfprdnome_sel = AV53TFPrdNome_Sel;
         AV80Core_produtowwds_21_tfprdtiposigla = AV54TFPrdTipoSigla;
         AV81Core_produtowwds_22_tfprdtiposigla_sel = AV55TFPrdTipoSigla_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Core_produtowwds_2_filterfulltext ,
                                              AV62Core_produtowwds_3_dynamicfiltersselector1 ,
                                              AV63Core_produtowwds_4_dynamicfiltersoperator1 ,
                                              AV64Core_produtowwds_5_prdcodigo1 ,
                                              AV65Core_produtowwds_6_prdtiponome1 ,
                                              AV66Core_produtowwds_7_dynamicfiltersenabled2 ,
                                              AV67Core_produtowwds_8_dynamicfiltersselector2 ,
                                              AV68Core_produtowwds_9_dynamicfiltersoperator2 ,
                                              AV69Core_produtowwds_10_prdcodigo2 ,
                                              AV70Core_produtowwds_11_prdtiponome2 ,
                                              AV71Core_produtowwds_12_dynamicfiltersenabled3 ,
                                              AV72Core_produtowwds_13_dynamicfiltersselector3 ,
                                              AV73Core_produtowwds_14_dynamicfiltersoperator3 ,
                                              AV74Core_produtowwds_15_prdcodigo3 ,
                                              AV75Core_produtowwds_16_prdtiponome3 ,
                                              AV77Core_produtowwds_18_tfprdcodigo_sel ,
                                              AV76Core_produtowwds_17_tfprdcodigo ,
                                              AV79Core_produtowwds_20_tfprdnome_sel ,
                                              AV78Core_produtowwds_19_tfprdnome ,
                                              AV81Core_produtowwds_22_tfprdtiposigla_sel ,
                                              AV80Core_produtowwds_21_tfprdtiposigla ,
                                              A221PrdCodigo ,
                                              A222PrdNome ,
                                              A233PrdTipoSigla ,
                                              A234PrdTipoNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A620PrdDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV61Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext), "%", "");
         lV64Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1), "%", "");
         lV64Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1), "%", "");
         lV65Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1), "%", "");
         lV65Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1), "%", "");
         lV69Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2), "%", "");
         lV69Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2), "%", "");
         lV70Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2), "%", "");
         lV70Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2), "%", "");
         lV74Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3), "%", "");
         lV74Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3), "%", "");
         lV75Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3), "%", "");
         lV75Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3), "%", "");
         lV76Core_produtowwds_17_tfprdcodigo = StringUtil.Concat( StringUtil.RTrim( AV76Core_produtowwds_17_tfprdcodigo), "%", "");
         lV78Core_produtowwds_19_tfprdnome = StringUtil.Concat( StringUtil.RTrim( AV78Core_produtowwds_19_tfprdnome), "%", "");
         lV80Core_produtowwds_21_tfprdtiposigla = StringUtil.Concat( StringUtil.RTrim( AV80Core_produtowwds_21_tfprdtiposigla), "%", "");
         /* Using cursor P004C2 */
         pr_default.execute(0, new Object[] {lV61Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_2_filterfulltext, lV64Core_produtowwds_5_prdcodigo1, lV64Core_produtowwds_5_prdcodigo1, lV65Core_produtowwds_6_prdtiponome1, lV65Core_produtowwds_6_prdtiponome1, lV69Core_produtowwds_10_prdcodigo2, lV69Core_produtowwds_10_prdcodigo2, lV70Core_produtowwds_11_prdtiponome2, lV70Core_produtowwds_11_prdtiponome2, lV74Core_produtowwds_15_prdcodigo3, lV74Core_produtowwds_15_prdcodigo3, lV75Core_produtowwds_16_prdtiponome3, lV75Core_produtowwds_16_prdtiponome3, lV76Core_produtowwds_17_tfprdcodigo, AV77Core_produtowwds_18_tfprdcodigo_sel, lV78Core_produtowwds_19_tfprdnome, AV79Core_produtowwds_20_tfprdnome_sel, lV80Core_produtowwds_21_tfprdtiposigla, AV81Core_produtowwds_22_tfprdtiposigla_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A232PrdTipoID = P004C2_A232PrdTipoID[0];
            A234PrdTipoNome = P004C2_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004C2_A233PrdTipoSigla[0];
            A222PrdNome = P004C2_A222PrdNome[0];
            A221PrdCodigo = P004C2_A221PrdCodigo[0];
            A620PrdDel = P004C2_A620PrdDel[0];
            A220PrdID = P004C2_A220PrdID[0];
            A234PrdTipoNome = P004C2_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004C2_A233PrdTipoSigla[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV47VisibleColumnCount = 0;
            AV82GXV2 = 1;
            while ( AV82GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV82GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PrdCodigo") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A221PrdCodigo, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PrdNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A222PrdNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "PrdTipoSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A233PrdTipoSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV82GXV2 = (int)(AV82GXV2+1);
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
         AV35Session.Set("WWPExportFilePath", AV12Filename);
         AV35Session.Set("WWPExportFileName", "ProdutoWWExport.xlsx");
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
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PrdCodigo",  "",  "Código",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PrdNome",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "PrdTipoSigla",  "",  "Tipo do Produto",  true,  "") ;
         GXt_char1 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ProdutoWWColumnsSelector", out  GXt_char1) ;
         AV43UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43UserCustomValue)) ) )
         {
            AV40ColumnsSelectorAux.FromXml(AV43UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV40ColumnsSelectorAux, ref  AV39ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("core.ProdutoWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ProdutoWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("core.ProdutoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV83GXV3 = 1;
         while ( AV83GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV83GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PRDDEL_FILTRO") == 0 )
            {
               AV57PrdDel_Filtro = BooleanUtil.Val( AV38GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRDCODIGO") == 0 )
            {
               AV50TFPrdCodigo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRDCODIGO_SEL") == 0 )
            {
               AV51TFPrdCodigo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRDNOME") == 0 )
            {
               AV52TFPrdNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRDNOME_SEL") == 0 )
            {
               AV53TFPrdNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRDTIPOSIGLA") == 0 )
            {
               AV54TFPrdTipoSigla = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRDTIPOSIGLA_SEL") == 0 )
            {
               AV55TFPrdTipoSigla_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV83GXV3 = (int)(AV83GXV3+1);
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
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22PrdCodigo1 = "";
         AV23PrdTipoNome1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27PrdCodigo2 = "";
         AV28PrdTipoNome2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32PrdCodigo3 = "";
         AV33PrdTipoNome3 = "";
         AV51TFPrdCodigo_Sel = "";
         AV50TFPrdCodigo = "";
         AV53TFPrdNome_Sel = "";
         AV52TFPrdNome = "";
         AV55TFPrdTipoSigla_Sel = "";
         AV54TFPrdTipoSigla = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV61Core_produtowwds_2_filterfulltext = "";
         AV62Core_produtowwds_3_dynamicfiltersselector1 = "";
         AV64Core_produtowwds_5_prdcodigo1 = "";
         AV65Core_produtowwds_6_prdtiponome1 = "";
         AV67Core_produtowwds_8_dynamicfiltersselector2 = "";
         AV69Core_produtowwds_10_prdcodigo2 = "";
         AV70Core_produtowwds_11_prdtiponome2 = "";
         AV72Core_produtowwds_13_dynamicfiltersselector3 = "";
         AV74Core_produtowwds_15_prdcodigo3 = "";
         AV75Core_produtowwds_16_prdtiponome3 = "";
         AV76Core_produtowwds_17_tfprdcodigo = "";
         AV77Core_produtowwds_18_tfprdcodigo_sel = "";
         AV78Core_produtowwds_19_tfprdnome = "";
         AV79Core_produtowwds_20_tfprdnome_sel = "";
         AV80Core_produtowwds_21_tfprdtiposigla = "";
         AV81Core_produtowwds_22_tfprdtiposigla_sel = "";
         scmdbuf = "";
         lV61Core_produtowwds_2_filterfulltext = "";
         lV64Core_produtowwds_5_prdcodigo1 = "";
         lV65Core_produtowwds_6_prdtiponome1 = "";
         lV69Core_produtowwds_10_prdcodigo2 = "";
         lV70Core_produtowwds_11_prdtiponome2 = "";
         lV74Core_produtowwds_15_prdcodigo3 = "";
         lV75Core_produtowwds_16_prdtiponome3 = "";
         lV76Core_produtowwds_17_tfprdcodigo = "";
         lV78Core_produtowwds_19_tfprdnome = "";
         lV80Core_produtowwds_21_tfprdtiposigla = "";
         A221PrdCodigo = "";
         A222PrdNome = "";
         A233PrdTipoSigla = "";
         A234PrdTipoNome = "";
         P004C2_A232PrdTipoID = new int[1] ;
         P004C2_A234PrdTipoNome = new string[] {""} ;
         P004C2_A233PrdTipoSigla = new string[] {""} ;
         P004C2_A222PrdNome = new string[] {""} ;
         P004C2_A221PrdCodigo = new string[] {""} ;
         P004C2_A620PrdDel = new bool[] {false} ;
         P004C2_A220PrdID = new Guid[] {Guid.Empty} ;
         A220PrdID = Guid.Empty;
         AV43UserCustomValue = "";
         GXt_char1 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtowwexport__default(),
            new Object[][] {
                new Object[] {
               P004C2_A232PrdTipoID, P004C2_A234PrdTipoNome, P004C2_A233PrdTipoSigla, P004C2_A222PrdNome, P004C2_A221PrdCodigo, P004C2_A620PrdDel, P004C2_A220PrdID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV63Core_produtowwds_4_dynamicfiltersoperator1 ;
      private short AV68Core_produtowwds_9_dynamicfiltersoperator2 ;
      private short AV73Core_produtowwds_14_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV58GXV1 ;
      private int A232PrdTipoID ;
      private int AV82GXV2 ;
      private int AV83GXV3 ;
      private long AV47VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV57PrdDel_Filtro ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV60Core_produtowwds_1_prddel_filtro ;
      private bool AV66Core_produtowwds_7_dynamicfiltersenabled2 ;
      private bool AV71Core_produtowwds_12_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool A620PrdDel ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22PrdCodigo1 ;
      private string AV23PrdTipoNome1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV27PrdCodigo2 ;
      private string AV28PrdTipoNome2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV32PrdCodigo3 ;
      private string AV33PrdTipoNome3 ;
      private string AV51TFPrdCodigo_Sel ;
      private string AV50TFPrdCodigo ;
      private string AV53TFPrdNome_Sel ;
      private string AV52TFPrdNome ;
      private string AV55TFPrdTipoSigla_Sel ;
      private string AV54TFPrdTipoSigla ;
      private string AV61Core_produtowwds_2_filterfulltext ;
      private string AV62Core_produtowwds_3_dynamicfiltersselector1 ;
      private string AV64Core_produtowwds_5_prdcodigo1 ;
      private string AV65Core_produtowwds_6_prdtiponome1 ;
      private string AV67Core_produtowwds_8_dynamicfiltersselector2 ;
      private string AV69Core_produtowwds_10_prdcodigo2 ;
      private string AV70Core_produtowwds_11_prdtiponome2 ;
      private string AV72Core_produtowwds_13_dynamicfiltersselector3 ;
      private string AV74Core_produtowwds_15_prdcodigo3 ;
      private string AV75Core_produtowwds_16_prdtiponome3 ;
      private string AV76Core_produtowwds_17_tfprdcodigo ;
      private string AV77Core_produtowwds_18_tfprdcodigo_sel ;
      private string AV78Core_produtowwds_19_tfprdnome ;
      private string AV79Core_produtowwds_20_tfprdnome_sel ;
      private string AV80Core_produtowwds_21_tfprdtiposigla ;
      private string AV81Core_produtowwds_22_tfprdtiposigla_sel ;
      private string lV61Core_produtowwds_2_filterfulltext ;
      private string lV64Core_produtowwds_5_prdcodigo1 ;
      private string lV65Core_produtowwds_6_prdtiponome1 ;
      private string lV69Core_produtowwds_10_prdcodigo2 ;
      private string lV70Core_produtowwds_11_prdtiponome2 ;
      private string lV74Core_produtowwds_15_prdcodigo3 ;
      private string lV75Core_produtowwds_16_prdtiponome3 ;
      private string lV76Core_produtowwds_17_tfprdcodigo ;
      private string lV78Core_produtowwds_19_tfprdnome ;
      private string lV80Core_produtowwds_21_tfprdtiposigla ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A233PrdTipoSigla ;
      private string A234PrdTipoNome ;
      private Guid A220PrdID ;
      private IGxSession AV35Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004C2_A232PrdTipoID ;
      private string[] P004C2_A234PrdTipoNome ;
      private string[] P004C2_A233PrdTipoSigla ;
      private string[] P004C2_A222PrdNome ;
      private string[] P004C2_A221PrdCodigo ;
      private bool[] P004C2_A620PrdDel ;
      private Guid[] P004C2_A220PrdID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
   }

   public class produtowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004C2( IGxContext context ,
                                             string AV61Core_produtowwds_2_filterfulltext ,
                                             string AV62Core_produtowwds_3_dynamicfiltersselector1 ,
                                             short AV63Core_produtowwds_4_dynamicfiltersoperator1 ,
                                             string AV64Core_produtowwds_5_prdcodigo1 ,
                                             string AV65Core_produtowwds_6_prdtiponome1 ,
                                             bool AV66Core_produtowwds_7_dynamicfiltersenabled2 ,
                                             string AV67Core_produtowwds_8_dynamicfiltersselector2 ,
                                             short AV68Core_produtowwds_9_dynamicfiltersoperator2 ,
                                             string AV69Core_produtowwds_10_prdcodigo2 ,
                                             string AV70Core_produtowwds_11_prdtiponome2 ,
                                             bool AV71Core_produtowwds_12_dynamicfiltersenabled3 ,
                                             string AV72Core_produtowwds_13_dynamicfiltersselector3 ,
                                             short AV73Core_produtowwds_14_dynamicfiltersoperator3 ,
                                             string AV74Core_produtowwds_15_prdcodigo3 ,
                                             string AV75Core_produtowwds_16_prdtiponome3 ,
                                             string AV77Core_produtowwds_18_tfprdcodigo_sel ,
                                             string AV76Core_produtowwds_17_tfprdcodigo ,
                                             string AV79Core_produtowwds_20_tfprdnome_sel ,
                                             string AV78Core_produtowwds_19_tfprdnome ,
                                             string AV81Core_produtowwds_22_tfprdtiposigla_sel ,
                                             string AV80Core_produtowwds_21_tfprdtiposigla ,
                                             string A221PrdCodigo ,
                                             string A222PrdNome ,
                                             string A233PrdTipoSigla ,
                                             string A234PrdTipoNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A620PrdDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[21];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.PrdTipoID AS PrdTipoID, T2.PrtNome AS PrdTipoNome, T2.PrtSigla AS PrdTipoSigla, T1.PrdNome, T1.PrdCodigo, T1.PrdDel, T1.PrdID FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID)";
         AddWhere(sWhereString, "(Not T1.PrdDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.PrdCodigo like '%' || :lV61Core_produtowwds_2_filterfulltext) or ( T1.PrdNome like '%' || :lV61Core_produtowwds_2_filterfulltext) or ( T2.PrtSigla like '%' || :lV61Core_produtowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV64Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV64Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV65Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV65Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV69Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV69Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV70Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV70Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV74Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV74Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV75Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV75Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_18_tfprdcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_17_tfprdcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV76Core_produtowwds_17_tfprdcodigo)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_18_tfprdcodigo_sel)) && ! ( StringUtil.StrCmp(AV77Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo = ( :AV77Core_produtowwds_18_tfprdcodigo_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV77Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_produtowwds_20_tfprdnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_19_tfprdnome)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome like :lV78Core_produtowwds_19_tfprdnome)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_produtowwds_20_tfprdnome_sel)) && ! ( StringUtil.StrCmp(AV79Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome = ( :AV79Core_produtowwds_20_tfprdnome_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV79Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_produtowwds_22_tfprdtiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_produtowwds_21_tfprdtiposigla)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla like :lV80Core_produtowwds_21_tfprdtiposigla)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_produtowwds_22_tfprdtiposigla_sel)) && ! ( StringUtil.StrCmp(AV81Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla = ( :AV81Core_produtowwds_22_tfprdtiposigla_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV81Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PrtSigla))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PrdCodigo";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PrdCodigo DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PrdNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PrdNome DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.PrtSigla";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.PrtSigla DESC";
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
                     return conditional_P004C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP004C2;
          prmP004C2 = new Object[] {
          new ParDef("lV61Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV64Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV65Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV69Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV70Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV70Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV74Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV74Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV75Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV75Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_produtowwds_17_tfprdcodigo",GXType.VarChar,30,0) ,
          new ParDef("AV77Core_produtowwds_18_tfprdcodigo_sel",GXType.VarChar,30,0) ,
          new ParDef("lV78Core_produtowwds_19_tfprdnome",GXType.VarChar,80,0) ,
          new ParDef("AV79Core_produtowwds_20_tfprdnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV80Core_produtowwds_21_tfprdtiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV81Core_produtowwds_22_tfprdtiposigla_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
