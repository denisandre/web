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
   public class regiaowwexport : GXProcedure
   {
      public regiaowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public regiaowwexport( IGxContext context )
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
         regiaowwexport objregiaowwexport;
         objregiaowwexport = new regiaowwexport();
         objregiaowwexport.AV12Filename = "" ;
         objregiaowwexport.AV13ErrorMessage = "" ;
         objregiaowwexport.context.SetSubmitInitialConfig(context);
         objregiaowwexport.initialize();
         Submit( executePrivateCatch,objregiaowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((regiaowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "regiaoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV47TFRegiaoID) && (0==AV48TFRegiaoID_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "ID") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFRegiaoID;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFRegiaoID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFRegiaoSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFRegiaoSigla_Sel)) ? "(Vazio)" : AV50TFRegiaoSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFRegiaoSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFRegiaoSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRegiaoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRegiaoNome_Sel)) ? "(Vazio)" : AV52TFRegiaoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFRegiaoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFRegiaoNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.regiaoWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.regiaoWWColumnsSelector");
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
         AV56Core_regiaowwds_1_filterfulltext = AV19FilterFullText;
         AV57Core_regiaowwds_2_tfregiaoid = AV47TFRegiaoID;
         AV58Core_regiaowwds_3_tfregiaoid_to = AV48TFRegiaoID_To;
         AV59Core_regiaowwds_4_tfregiaosigla = AV49TFRegiaoSigla;
         AV60Core_regiaowwds_5_tfregiaosigla_sel = AV50TFRegiaoSigla_Sel;
         AV61Core_regiaowwds_6_tfregiaonome = AV51TFRegiaoNome;
         AV62Core_regiaowwds_7_tfregiaonome_sel = AV52TFRegiaoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Core_regiaowwds_1_filterfulltext ,
                                              AV57Core_regiaowwds_2_tfregiaoid ,
                                              AV58Core_regiaowwds_3_tfregiaoid_to ,
                                              AV60Core_regiaowwds_5_tfregiaosigla_sel ,
                                              AV59Core_regiaowwds_4_tfregiaosigla ,
                                              AV62Core_regiaowwds_7_tfregiaonome_sel ,
                                              AV61Core_regiaowwds_6_tfregiaonome ,
                                              A1RegiaoID ,
                                              A2RegiaoSigla ,
                                              A3RegiaoNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_regiaowwds_1_filterfulltext), "%", "");
         lV56Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_regiaowwds_1_filterfulltext), "%", "");
         lV56Core_regiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Core_regiaowwds_1_filterfulltext), "%", "");
         lV59Core_regiaowwds_4_tfregiaosigla = StringUtil.Concat( StringUtil.RTrim( AV59Core_regiaowwds_4_tfregiaosigla), "%", "");
         lV61Core_regiaowwds_6_tfregiaonome = StringUtil.Concat( StringUtil.RTrim( AV61Core_regiaowwds_6_tfregiaonome), "%", "");
         /* Using cursor P005D2 */
         pr_default.execute(0, new Object[] {lV56Core_regiaowwds_1_filterfulltext, lV56Core_regiaowwds_1_filterfulltext, lV56Core_regiaowwds_1_filterfulltext, AV57Core_regiaowwds_2_tfregiaoid, AV58Core_regiaowwds_3_tfregiaoid_to, lV59Core_regiaowwds_4_tfregiaosigla, AV60Core_regiaowwds_5_tfregiaosigla_sel, lV61Core_regiaowwds_6_tfregiaonome, AV62Core_regiaowwds_7_tfregiaonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1RegiaoID = P005D2_A1RegiaoID[0];
            A3RegiaoNome = P005D2_A3RegiaoNome[0];
            A2RegiaoSigla = P005D2_A2RegiaoSigla[0];
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
            AV63GXV2 = 1;
            while ( AV63GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV63GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RegiaoID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A1RegiaoID;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RegiaoSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2RegiaoSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "RegiaoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A3RegiaoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV63GXV2 = (int)(AV63GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "regiaoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RegiaoID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RegiaoSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "RegiaoNome",  "",  "Descrição",  true,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.regiaoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.regiaoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.regiaoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.regiaoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV64GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFREGIAOID") == 0 )
            {
               AV47TFRegiaoID = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFRegiaoID_To = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFREGIAOSIGLA") == 0 )
            {
               AV49TFRegiaoSigla = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFREGIAOSIGLA_SEL") == 0 )
            {
               AV50TFRegiaoSigla_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFREGIAONOME") == 0 )
            {
               AV51TFRegiaoNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFREGIAONOME_SEL") == 0 )
            {
               AV52TFRegiaoNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV64GXV3 = (int)(AV64GXV3+1);
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
         AV50TFRegiaoSigla_Sel = "";
         AV49TFRegiaoSigla = "";
         AV52TFRegiaoNome_Sel = "";
         AV51TFRegiaoNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV56Core_regiaowwds_1_filterfulltext = "";
         AV59Core_regiaowwds_4_tfregiaosigla = "";
         AV60Core_regiaowwds_5_tfregiaosigla_sel = "";
         AV61Core_regiaowwds_6_tfregiaonome = "";
         AV62Core_regiaowwds_7_tfregiaonome_sel = "";
         scmdbuf = "";
         lV56Core_regiaowwds_1_filterfulltext = "";
         lV59Core_regiaowwds_4_tfregiaosigla = "";
         lV61Core_regiaowwds_6_tfregiaonome = "";
         A2RegiaoSigla = "";
         A3RegiaoNome = "";
         P005D2_A1RegiaoID = new int[1] ;
         P005D2_A3RegiaoNome = new string[] {""} ;
         P005D2_A2RegiaoSigla = new string[] {""} ;
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.regiaowwexport__default(),
            new Object[][] {
                new Object[] {
               P005D2_A1RegiaoID, P005D2_A3RegiaoNome, P005D2_A2RegiaoSigla
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
      private int AV47TFRegiaoID ;
      private int AV48TFRegiaoID_To ;
      private int AV54GXV1 ;
      private int AV57Core_regiaowwds_2_tfregiaoid ;
      private int AV58Core_regiaowwds_3_tfregiaoid_to ;
      private int A1RegiaoID ;
      private int AV63GXV2 ;
      private int AV64GXV3 ;
      private long AV44VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV50TFRegiaoSigla_Sel ;
      private string AV49TFRegiaoSigla ;
      private string AV52TFRegiaoNome_Sel ;
      private string AV51TFRegiaoNome ;
      private string AV56Core_regiaowwds_1_filterfulltext ;
      private string AV59Core_regiaowwds_4_tfregiaosigla ;
      private string AV60Core_regiaowwds_5_tfregiaosigla_sel ;
      private string AV61Core_regiaowwds_6_tfregiaonome ;
      private string AV62Core_regiaowwds_7_tfregiaonome_sel ;
      private string lV56Core_regiaowwds_1_filterfulltext ;
      private string lV59Core_regiaowwds_4_tfregiaosigla ;
      private string lV61Core_regiaowwds_6_tfregiaonome ;
      private string A2RegiaoSigla ;
      private string A3RegiaoNome ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005D2_A1RegiaoID ;
      private string[] P005D2_A3RegiaoNome ;
      private string[] P005D2_A2RegiaoSigla ;
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

   public class regiaowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005D2( IGxContext context ,
                                             string AV56Core_regiaowwds_1_filterfulltext ,
                                             int AV57Core_regiaowwds_2_tfregiaoid ,
                                             int AV58Core_regiaowwds_3_tfregiaoid_to ,
                                             string AV60Core_regiaowwds_5_tfregiaosigla_sel ,
                                             string AV59Core_regiaowwds_4_tfregiaosigla ,
                                             string AV62Core_regiaowwds_7_tfregiaonome_sel ,
                                             string AV61Core_regiaowwds_6_tfregiaonome ,
                                             int A1RegiaoID ,
                                             string A2RegiaoSigla ,
                                             string A3RegiaoNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT RegiaoID, RegiaoNome, RegiaoSigla FROM tbibge_regiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_regiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(RegiaoID,'999999999'), 2) like '%' || :lV56Core_regiaowwds_1_filterfulltext) or ( RegiaoSigla like '%' || :lV56Core_regiaowwds_1_filterfulltext) or ( RegiaoNome like '%' || :lV56Core_regiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV57Core_regiaowwds_2_tfregiaoid) )
         {
            AddWhere(sWhereString, "(RegiaoID >= :AV57Core_regiaowwds_2_tfregiaoid)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV58Core_regiaowwds_3_tfregiaoid_to) )
         {
            AddWhere(sWhereString, "(RegiaoID <= :AV58Core_regiaowwds_3_tfregiaoid_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_regiaowwds_5_tfregiaosigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_regiaowwds_4_tfregiaosigla)) ) )
         {
            AddWhere(sWhereString, "(RegiaoSigla like :lV59Core_regiaowwds_4_tfregiaosigla)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_regiaowwds_5_tfregiaosigla_sel)) && ! ( StringUtil.StrCmp(AV60Core_regiaowwds_5_tfregiaosigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RegiaoSigla = ( :AV60Core_regiaowwds_5_tfregiaosigla_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_regiaowwds_5_tfregiaosigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from RegiaoSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_regiaowwds_7_tfregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_regiaowwds_6_tfregiaonome)) ) )
         {
            AddWhere(sWhereString, "(RegiaoNome like :lV61Core_regiaowwds_6_tfregiaonome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_regiaowwds_7_tfregiaonome_sel)) && ! ( StringUtil.StrCmp(AV62Core_regiaowwds_7_tfregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RegiaoNome = ( :AV62Core_regiaowwds_7_tfregiaonome_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_regiaowwds_7_tfregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from RegiaoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY RegiaoSigla";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY RegiaoSigla DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY RegiaoID";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY RegiaoID DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY RegiaoNome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY RegiaoNome DESC";
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
                     return conditional_P005D2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] );
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
          Object[] prmP005D2;
          prmP005D2 = new Object[] {
          new ParDef("lV56Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Core_regiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV57Core_regiaowwds_2_tfregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV58Core_regiaowwds_3_tfregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV59Core_regiaowwds_4_tfregiaosigla",GXType.VarChar,10,0) ,
          new ParDef("AV60Core_regiaowwds_5_tfregiaosigla_sel",GXType.VarChar,10,0) ,
          new ParDef("lV61Core_regiaowwds_6_tfregiaonome",GXType.VarChar,50,0) ,
          new ParDef("AV62Core_regiaowwds_7_tfregiaonome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005D2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
