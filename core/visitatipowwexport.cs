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
   public class visitatipowwexport : GXProcedure
   {
      public visitatipowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitatipowwexport( IGxContext context )
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
         visitatipowwexport objvisitatipowwexport;
         objvisitatipowwexport = new visitatipowwexport();
         objvisitatipowwexport.AV12Filename = "" ;
         objvisitatipowwexport.AV13ErrorMessage = "" ;
         objvisitatipowwexport.context.SetSubmitInitialConfig(context);
         objvisitatipowwexport.initialize();
         Submit( executePrivateCatch,objvisitatipowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitatipowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "VisitaTipoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV40VitDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV40VitDel_Filtro);
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFVitSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFVitSigla_Sel)) ? "(Vazio)" : AV36TFVitSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFVitSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFVitSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFVitNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFVitNome_Sel)) ? "(Vazio)" : AV38TFVitNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFVitNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFVitNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("core.VisitaTipoWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("core.VisitaTipoWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV41GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV43Core_visitatipowwds_1_vitdel_filtro = AV40VitDel_Filtro;
         AV44Core_visitatipowwds_2_filterfulltext = AV19FilterFullText;
         AV45Core_visitatipowwds_3_tfvitsigla = AV35TFVitSigla;
         AV46Core_visitatipowwds_4_tfvitsigla_sel = AV36TFVitSigla_Sel;
         AV47Core_visitatipowwds_5_tfvitnome = AV37TFVitNome;
         AV48Core_visitatipowwds_6_tfvitnome_sel = AV38TFVitNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Core_visitatipowwds_2_filterfulltext ,
                                              AV46Core_visitatipowwds_4_tfvitsigla_sel ,
                                              AV45Core_visitatipowwds_3_tfvitsigla ,
                                              AV48Core_visitatipowwds_6_tfvitnome_sel ,
                                              AV47Core_visitatipowwds_5_tfvitnome ,
                                              A412VitSigla ,
                                              A413VitNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A596VitDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV44Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Core_visitatipowwds_2_filterfulltext), "%", "");
         lV44Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV44Core_visitatipowwds_2_filterfulltext), "%", "");
         lV45Core_visitatipowwds_3_tfvitsigla = StringUtil.Concat( StringUtil.RTrim( AV45Core_visitatipowwds_3_tfvitsigla), "%", "");
         lV47Core_visitatipowwds_5_tfvitnome = StringUtil.Concat( StringUtil.RTrim( AV47Core_visitatipowwds_5_tfvitnome), "%", "");
         /* Using cursor P005T2 */
         pr_default.execute(0, new Object[] {lV44Core_visitatipowwds_2_filterfulltext, lV44Core_visitatipowwds_2_filterfulltext, lV45Core_visitatipowwds_3_tfvitsigla, AV46Core_visitatipowwds_4_tfvitsigla_sel, lV47Core_visitatipowwds_5_tfvitnome, AV48Core_visitatipowwds_6_tfvitnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A413VitNome = P005T2_A413VitNome[0];
            A412VitSigla = P005T2_A412VitSigla[0];
            A596VitDel = P005T2_A596VitDel[0];
            A411VitID = P005T2_A411VitID[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV32VisibleColumnCount = 0;
            AV49GXV2 = 1;
            while ( AV49GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV49GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "VitSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A412VitSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "VitNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A413VitNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV49GXV2 = (int)(AV49GXV2+1);
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
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "VisitaTipoWWExport.xlsx");
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
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "VitSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "VitNome",  "",  "Descrição",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.VisitaTipoWWColumnsSelector", out  GXt_char1) ;
         AV28UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("core.VisitaTipoWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.VisitaTipoWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("core.VisitaTipoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV50GXV3 = 1;
         while ( AV50GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV50GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "VITDEL_FILTRO") == 0 )
            {
               AV40VitDel_Filtro = BooleanUtil.Val( AV23GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFVITSIGLA") == 0 )
            {
               AV35TFVitSigla = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFVITSIGLA_SEL") == 0 )
            {
               AV36TFVitSigla_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFVITNOME") == 0 )
            {
               AV37TFVitNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFVITNOME_SEL") == 0 )
            {
               AV38TFVitNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV50GXV3 = (int)(AV50GXV3+1);
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
         AV36TFVitSigla_Sel = "";
         AV35TFVitSigla = "";
         AV38TFVitNome_Sel = "";
         AV37TFVitNome = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV44Core_visitatipowwds_2_filterfulltext = "";
         AV45Core_visitatipowwds_3_tfvitsigla = "";
         AV46Core_visitatipowwds_4_tfvitsigla_sel = "";
         AV47Core_visitatipowwds_5_tfvitnome = "";
         AV48Core_visitatipowwds_6_tfvitnome_sel = "";
         scmdbuf = "";
         lV44Core_visitatipowwds_2_filterfulltext = "";
         lV45Core_visitatipowwds_3_tfvitsigla = "";
         lV47Core_visitatipowwds_5_tfvitnome = "";
         A412VitSigla = "";
         A413VitNome = "";
         P005T2_A413VitNome = new string[] {""} ;
         P005T2_A412VitSigla = new string[] {""} ;
         P005T2_A596VitDel = new bool[] {false} ;
         P005T2_A411VitID = new int[1] ;
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipowwexport__default(),
            new Object[][] {
                new Object[] {
               P005T2_A413VitNome, P005T2_A412VitSigla, P005T2_A596VitDel, P005T2_A411VitID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV41GXV1 ;
      private int A411VitID ;
      private int AV49GXV2 ;
      private int AV50GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV40VitDel_Filtro ;
      private bool AV43Core_visitatipowwds_1_vitdel_filtro ;
      private bool AV18OrderedDsc ;
      private bool A596VitDel ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV36TFVitSigla_Sel ;
      private string AV35TFVitSigla ;
      private string AV38TFVitNome_Sel ;
      private string AV37TFVitNome ;
      private string AV44Core_visitatipowwds_2_filterfulltext ;
      private string AV45Core_visitatipowwds_3_tfvitsigla ;
      private string AV46Core_visitatipowwds_4_tfvitsigla_sel ;
      private string AV47Core_visitatipowwds_5_tfvitnome ;
      private string AV48Core_visitatipowwds_6_tfvitnome_sel ;
      private string lV44Core_visitatipowwds_2_filterfulltext ;
      private string lV45Core_visitatipowwds_3_tfvitsigla ;
      private string lV47Core_visitatipowwds_5_tfvitnome ;
      private string A412VitSigla ;
      private string A413VitNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005T2_A413VitNome ;
      private string[] P005T2_A412VitSigla ;
      private bool[] P005T2_A596VitDel ;
      private int[] P005T2_A411VitID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV22GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
   }

   public class visitatipowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005T2( IGxContext context ,
                                             string AV44Core_visitatipowwds_2_filterfulltext ,
                                             string AV46Core_visitatipowwds_4_tfvitsigla_sel ,
                                             string AV45Core_visitatipowwds_3_tfvitsigla ,
                                             string AV48Core_visitatipowwds_6_tfvitnome_sel ,
                                             string AV47Core_visitatipowwds_5_tfvitnome ,
                                             string A412VitSigla ,
                                             string A413VitNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A596VitDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT VitNome, VitSigla, VitDel, VitID FROM tb_visitatipo";
         AddWhere(sWhereString, "(Not VitDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( VitSigla like '%' || :lV44Core_visitatipowwds_2_filterfulltext) or ( VitNome like '%' || :lV44Core_visitatipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_visitatipowwds_4_tfvitsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Core_visitatipowwds_3_tfvitsigla)) ) )
         {
            AddWhere(sWhereString, "(VitSigla like :lV45Core_visitatipowwds_3_tfvitsigla)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Core_visitatipowwds_4_tfvitsigla_sel)) && ! ( StringUtil.StrCmp(AV46Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitSigla = ( :AV46Core_visitatipowwds_4_tfvitsigla_sel))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV46Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_visitatipowwds_6_tfvitnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Core_visitatipowwds_5_tfvitnome)) ) )
         {
            AddWhere(sWhereString, "(VitNome like :lV47Core_visitatipowwds_5_tfvitnome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_visitatipowwds_6_tfvitnome_sel)) && ! ( StringUtil.StrCmp(AV48Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitNome = ( :AV48Core_visitatipowwds_6_tfvitnome_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV48Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY VitSigla";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY VitSigla DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY VitNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY VitNome DESC";
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
                     return conditional_P005T2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (bool)dynConstraints[9] );
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
          Object[] prmP005T2;
          prmP005T2 = new Object[] {
          new ParDef("lV44Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV44Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV45Core_visitatipowwds_3_tfvitsigla",GXType.VarChar,20,0) ,
          new ParDef("AV46Core_visitatipowwds_4_tfvitsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV47Core_visitatipowwds_5_tfvitnome",GXType.VarChar,80,0) ,
          new ParDef("AV48Core_visitatipowwds_6_tfvitnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005T2,100, GxCacheFrequency.OFF ,true,false )
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
