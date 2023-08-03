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
   public class clientepjtipowwexport : GXProcedure
   {
      public clientepjtipowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjtipowwexport( IGxContext context )
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
         clientepjtipowwexport objclientepjtipowwexport;
         objclientepjtipowwexport = new clientepjtipowwexport();
         objclientepjtipowwexport.AV12Filename = "" ;
         objclientepjtipowwexport.AV13ErrorMessage = "" ;
         objclientepjtipowwexport.context.SetSubmitInitialConfig(context);
         objclientepjtipowwexport.initialize();
         Submit( executePrivateCatch,objclientepjtipowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientepjtipowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ClientePJTipoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "PJTNOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV59PjtNome1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59PjtNome1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59PjtNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "PJTNOME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV60PjtNome2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60PjtNome2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60PjtNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PJTNOME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV61PjtNome3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61PjtNome3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61PjtNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFPjtSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFPjtSigla_Sel)) ? "(Vazio)" : AV65TFPjtSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFPjtSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFPjtSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFPjtNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFPjtNome_Sel)) ? "(Vazio)" : AV63TFPjtNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFPjtNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFPjtNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.ClientePJTipoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.ClientePJTipoWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV66GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV68Core_clientepjtipowwds_1_filterfulltext = AV19FilterFullText;
         AV69Core_clientepjtipowwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV70Core_clientepjtipowwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV71Core_clientepjtipowwds_4_pjtnome1 = AV59PjtNome1;
         AV72Core_clientepjtipowwds_5_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV73Core_clientepjtipowwds_6_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV74Core_clientepjtipowwds_7_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV75Core_clientepjtipowwds_8_pjtnome2 = AV60PjtNome2;
         AV76Core_clientepjtipowwds_9_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV77Core_clientepjtipowwds_10_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV78Core_clientepjtipowwds_11_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV79Core_clientepjtipowwds_12_pjtnome3 = AV61PjtNome3;
         AV80Core_clientepjtipowwds_13_tfpjtsigla = AV64TFPjtSigla;
         AV81Core_clientepjtipowwds_14_tfpjtsigla_sel = AV65TFPjtSigla_Sel;
         AV82Core_clientepjtipowwds_15_tfpjtnome = AV62TFPjtNome;
         AV83Core_clientepjtipowwds_16_tfpjtnome_sel = AV63TFPjtNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68Core_clientepjtipowwds_1_filterfulltext ,
                                              AV69Core_clientepjtipowwds_2_dynamicfiltersselector1 ,
                                              AV70Core_clientepjtipowwds_3_dynamicfiltersoperator1 ,
                                              AV71Core_clientepjtipowwds_4_pjtnome1 ,
                                              AV72Core_clientepjtipowwds_5_dynamicfiltersenabled2 ,
                                              AV73Core_clientepjtipowwds_6_dynamicfiltersselector2 ,
                                              AV74Core_clientepjtipowwds_7_dynamicfiltersoperator2 ,
                                              AV75Core_clientepjtipowwds_8_pjtnome2 ,
                                              AV76Core_clientepjtipowwds_9_dynamicfiltersenabled3 ,
                                              AV77Core_clientepjtipowwds_10_dynamicfiltersselector3 ,
                                              AV78Core_clientepjtipowwds_11_dynamicfiltersoperator3 ,
                                              AV79Core_clientepjtipowwds_12_pjtnome3 ,
                                              AV81Core_clientepjtipowwds_14_tfpjtsigla_sel ,
                                              AV80Core_clientepjtipowwds_13_tfpjtsigla ,
                                              AV83Core_clientepjtipowwds_16_tfpjtnome_sel ,
                                              AV82Core_clientepjtipowwds_15_tfpjtnome ,
                                              A156PjtSigla ,
                                              A157PjtNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Core_clientepjtipowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Core_clientepjtipowwds_1_filterfulltext), "%", "");
         lV68Core_clientepjtipowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Core_clientepjtipowwds_1_filterfulltext), "%", "");
         lV71Core_clientepjtipowwds_4_pjtnome1 = StringUtil.Concat( StringUtil.RTrim( AV71Core_clientepjtipowwds_4_pjtnome1), "%", "");
         lV71Core_clientepjtipowwds_4_pjtnome1 = StringUtil.Concat( StringUtil.RTrim( AV71Core_clientepjtipowwds_4_pjtnome1), "%", "");
         lV75Core_clientepjtipowwds_8_pjtnome2 = StringUtil.Concat( StringUtil.RTrim( AV75Core_clientepjtipowwds_8_pjtnome2), "%", "");
         lV75Core_clientepjtipowwds_8_pjtnome2 = StringUtil.Concat( StringUtil.RTrim( AV75Core_clientepjtipowwds_8_pjtnome2), "%", "");
         lV79Core_clientepjtipowwds_12_pjtnome3 = StringUtil.Concat( StringUtil.RTrim( AV79Core_clientepjtipowwds_12_pjtnome3), "%", "");
         lV79Core_clientepjtipowwds_12_pjtnome3 = StringUtil.Concat( StringUtil.RTrim( AV79Core_clientepjtipowwds_12_pjtnome3), "%", "");
         lV80Core_clientepjtipowwds_13_tfpjtsigla = StringUtil.Concat( StringUtil.RTrim( AV80Core_clientepjtipowwds_13_tfpjtsigla), "%", "");
         lV82Core_clientepjtipowwds_15_tfpjtnome = StringUtil.Concat( StringUtil.RTrim( AV82Core_clientepjtipowwds_15_tfpjtnome), "%", "");
         /* Using cursor P00412 */
         pr_default.execute(0, new Object[] {lV68Core_clientepjtipowwds_1_filterfulltext, lV68Core_clientepjtipowwds_1_filterfulltext, lV71Core_clientepjtipowwds_4_pjtnome1, lV71Core_clientepjtipowwds_4_pjtnome1, lV75Core_clientepjtipowwds_8_pjtnome2, lV75Core_clientepjtipowwds_8_pjtnome2, lV79Core_clientepjtipowwds_12_pjtnome3, lV79Core_clientepjtipowwds_12_pjtnome3, lV80Core_clientepjtipowwds_13_tfpjtsigla, AV81Core_clientepjtipowwds_14_tfpjtsigla_sel, lV82Core_clientepjtipowwds_15_tfpjtnome, AV83Core_clientepjtipowwds_16_tfpjtnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A157PjtNome = P00412_A157PjtNome[0];
            A156PjtSigla = P00412_A156PjtSigla[0];
            A155PjtID = P00412_A155PjtID[0];
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
            AV84GXV2 = 1;
            while ( AV84GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV84GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PjtSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A156PjtSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "PjtNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A157PjtNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV84GXV2 = (int)(AV84GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "ClientePJTipoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PjtSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "PjtNome",  "",  "Descrição",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ClientePJTipoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.ClientePJTipoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClientePJTipoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.ClientePJTipoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV85GXV3 = 1;
         while ( AV85GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV85GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPJTSIGLA") == 0 )
            {
               AV64TFPjtSigla = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPJTSIGLA_SEL") == 0 )
            {
               AV65TFPjtSigla_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPJTNOME") == 0 )
            {
               AV62TFPjtNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPJTNOME_SEL") == 0 )
            {
               AV63TFPjtNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV85GXV3 = (int)(AV85GXV3+1);
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
         AV59PjtNome1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV60PjtNome2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV61PjtNome3 = "";
         AV65TFPjtSigla_Sel = "";
         AV64TFPjtSigla = "";
         AV63TFPjtNome_Sel = "";
         AV62TFPjtNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV68Core_clientepjtipowwds_1_filterfulltext = "";
         AV69Core_clientepjtipowwds_2_dynamicfiltersselector1 = "";
         AV71Core_clientepjtipowwds_4_pjtnome1 = "";
         AV73Core_clientepjtipowwds_6_dynamicfiltersselector2 = "";
         AV75Core_clientepjtipowwds_8_pjtnome2 = "";
         AV77Core_clientepjtipowwds_10_dynamicfiltersselector3 = "";
         AV79Core_clientepjtipowwds_12_pjtnome3 = "";
         AV80Core_clientepjtipowwds_13_tfpjtsigla = "";
         AV81Core_clientepjtipowwds_14_tfpjtsigla_sel = "";
         AV82Core_clientepjtipowwds_15_tfpjtnome = "";
         AV83Core_clientepjtipowwds_16_tfpjtnome_sel = "";
         scmdbuf = "";
         lV68Core_clientepjtipowwds_1_filterfulltext = "";
         lV71Core_clientepjtipowwds_4_pjtnome1 = "";
         lV75Core_clientepjtipowwds_8_pjtnome2 = "";
         lV79Core_clientepjtipowwds_12_pjtnome3 = "";
         lV80Core_clientepjtipowwds_13_tfpjtsigla = "";
         lV82Core_clientepjtipowwds_15_tfpjtnome = "";
         A156PjtSigla = "";
         A157PjtNome = "";
         P00412_A157PjtNome = new string[] {""} ;
         P00412_A156PjtSigla = new string[] {""} ;
         P00412_A155PjtID = new int[1] ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjtipowwexport__default(),
            new Object[][] {
                new Object[] {
               P00412_A157PjtNome, P00412_A156PjtSigla, P00412_A155PjtID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV70Core_clientepjtipowwds_3_dynamicfiltersoperator1 ;
      private short AV74Core_clientepjtipowwds_7_dynamicfiltersoperator2 ;
      private short AV78Core_clientepjtipowwds_11_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV66GXV1 ;
      private int A155PjtID ;
      private int AV84GXV2 ;
      private int AV85GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV72Core_clientepjtipowwds_5_dynamicfiltersenabled2 ;
      private bool AV76Core_clientepjtipowwds_9_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV59PjtNome1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV60PjtNome2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV61PjtNome3 ;
      private string AV65TFPjtSigla_Sel ;
      private string AV64TFPjtSigla ;
      private string AV63TFPjtNome_Sel ;
      private string AV62TFPjtNome ;
      private string AV68Core_clientepjtipowwds_1_filterfulltext ;
      private string AV69Core_clientepjtipowwds_2_dynamicfiltersselector1 ;
      private string AV71Core_clientepjtipowwds_4_pjtnome1 ;
      private string AV73Core_clientepjtipowwds_6_dynamicfiltersselector2 ;
      private string AV75Core_clientepjtipowwds_8_pjtnome2 ;
      private string AV77Core_clientepjtipowwds_10_dynamicfiltersselector3 ;
      private string AV79Core_clientepjtipowwds_12_pjtnome3 ;
      private string AV80Core_clientepjtipowwds_13_tfpjtsigla ;
      private string AV81Core_clientepjtipowwds_14_tfpjtsigla_sel ;
      private string AV82Core_clientepjtipowwds_15_tfpjtnome ;
      private string AV83Core_clientepjtipowwds_16_tfpjtnome_sel ;
      private string lV68Core_clientepjtipowwds_1_filterfulltext ;
      private string lV71Core_clientepjtipowwds_4_pjtnome1 ;
      private string lV75Core_clientepjtipowwds_8_pjtnome2 ;
      private string lV79Core_clientepjtipowwds_12_pjtnome3 ;
      private string lV80Core_clientepjtipowwds_13_tfpjtsigla ;
      private string lV82Core_clientepjtipowwds_15_tfpjtnome ;
      private string A156PjtSigla ;
      private string A157PjtNome ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00412_A157PjtNome ;
      private string[] P00412_A156PjtSigla ;
      private int[] P00412_A155PjtID ;
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

   public class clientepjtipowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00412( IGxContext context ,
                                             string AV68Core_clientepjtipowwds_1_filterfulltext ,
                                             string AV69Core_clientepjtipowwds_2_dynamicfiltersselector1 ,
                                             short AV70Core_clientepjtipowwds_3_dynamicfiltersoperator1 ,
                                             string AV71Core_clientepjtipowwds_4_pjtnome1 ,
                                             bool AV72Core_clientepjtipowwds_5_dynamicfiltersenabled2 ,
                                             string AV73Core_clientepjtipowwds_6_dynamicfiltersselector2 ,
                                             short AV74Core_clientepjtipowwds_7_dynamicfiltersoperator2 ,
                                             string AV75Core_clientepjtipowwds_8_pjtnome2 ,
                                             bool AV76Core_clientepjtipowwds_9_dynamicfiltersenabled3 ,
                                             string AV77Core_clientepjtipowwds_10_dynamicfiltersselector3 ,
                                             short AV78Core_clientepjtipowwds_11_dynamicfiltersoperator3 ,
                                             string AV79Core_clientepjtipowwds_12_pjtnome3 ,
                                             string AV81Core_clientepjtipowwds_14_tfpjtsigla_sel ,
                                             string AV80Core_clientepjtipowwds_13_tfpjtsigla ,
                                             string AV83Core_clientepjtipowwds_16_tfpjtnome_sel ,
                                             string AV82Core_clientepjtipowwds_15_tfpjtnome ,
                                             string A156PjtSigla ,
                                             string A157PjtNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT PjtNome, PjtSigla, PjtID FROM tb_clientepjtipo";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_clientepjtipowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PjtSigla like '%' || :lV68Core_clientepjtipowwds_1_filterfulltext) or ( PjtNome like '%' || :lV68Core_clientepjtipowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Core_clientepjtipowwds_2_dynamicfiltersselector1, "PJTNOME") == 0 ) && ( AV70Core_clientepjtipowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_clientepjtipowwds_4_pjtnome1)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV71Core_clientepjtipowwds_4_pjtnome1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Core_clientepjtipowwds_2_dynamicfiltersselector1, "PJTNOME") == 0 ) && ( AV70Core_clientepjtipowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_clientepjtipowwds_4_pjtnome1)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV71Core_clientepjtipowwds_4_pjtnome1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV72Core_clientepjtipowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Core_clientepjtipowwds_6_dynamicfiltersselector2, "PJTNOME") == 0 ) && ( AV74Core_clientepjtipowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_clientepjtipowwds_8_pjtnome2)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV75Core_clientepjtipowwds_8_pjtnome2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV72Core_clientepjtipowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Core_clientepjtipowwds_6_dynamicfiltersselector2, "PJTNOME") == 0 ) && ( AV74Core_clientepjtipowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_clientepjtipowwds_8_pjtnome2)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV75Core_clientepjtipowwds_8_pjtnome2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV76Core_clientepjtipowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_clientepjtipowwds_10_dynamicfiltersselector3, "PJTNOME") == 0 ) && ( AV78Core_clientepjtipowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_clientepjtipowwds_12_pjtnome3)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV79Core_clientepjtipowwds_12_pjtnome3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV76Core_clientepjtipowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Core_clientepjtipowwds_10_dynamicfiltersselector3, "PJTNOME") == 0 ) && ( AV78Core_clientepjtipowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_clientepjtipowwds_12_pjtnome3)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like '%' || :lV79Core_clientepjtipowwds_12_pjtnome3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_clientepjtipowwds_14_tfpjtsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_clientepjtipowwds_13_tfpjtsigla)) ) )
         {
            AddWhere(sWhereString, "(PjtSigla like :lV80Core_clientepjtipowwds_13_tfpjtsigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_clientepjtipowwds_14_tfpjtsigla_sel)) && ! ( StringUtil.StrCmp(AV81Core_clientepjtipowwds_14_tfpjtsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PjtSigla = ( :AV81Core_clientepjtipowwds_14_tfpjtsigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV81Core_clientepjtipowwds_14_tfpjtsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PjtSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_clientepjtipowwds_16_tfpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_clientepjtipowwds_15_tfpjtnome)) ) )
         {
            AddWhere(sWhereString, "(PjtNome like :lV82Core_clientepjtipowwds_15_tfpjtnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_clientepjtipowwds_16_tfpjtnome_sel)) && ! ( StringUtil.StrCmp(AV83Core_clientepjtipowwds_16_tfpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PjtNome = ( :AV83Core_clientepjtipowwds_16_tfpjtnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV83Core_clientepjtipowwds_16_tfpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PjtNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY PjtNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PjtNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY PjtSigla";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PjtSigla DESC";
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
                     return conditional_P00412(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00412;
          prmP00412 = new Object[] {
          new ParDef("lV68Core_clientepjtipowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Core_clientepjtipowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Core_clientepjtipowwds_4_pjtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV71Core_clientepjtipowwds_4_pjtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV75Core_clientepjtipowwds_8_pjtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV75Core_clientepjtipowwds_8_pjtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV79Core_clientepjtipowwds_12_pjtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV79Core_clientepjtipowwds_12_pjtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV80Core_clientepjtipowwds_13_tfpjtsigla",GXType.VarChar,20,0) ,
          new ParDef("AV81Core_clientepjtipowwds_14_tfpjtsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV82Core_clientepjtipowwds_15_tfpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV83Core_clientepjtipowwds_16_tfpjtnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00412", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00412,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
