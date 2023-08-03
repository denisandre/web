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
   public class ufwwexport : GXProcedure
   {
      public ufwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ufwwexport( IGxContext context )
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
         ufwwexport objufwwexport;
         objufwwexport = new ufwwexport();
         objufwwexport.AV12Filename = "" ;
         objufwwexport.AV13ErrorMessage = "" ;
         objufwwexport.context.SetSubmitInitialConfig(context);
         objufwwexport.initialize();
         Submit( executePrivateCatch,objufwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ufwwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ufWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV50TFUFID) && (0==AV51TFUFID_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "ID") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV50TFUFID;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV51TFUFID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFUFSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFUFSigla_Sel)) ? "(Vazio)" : AV53TFUFSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFUFSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sigla") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFUFSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFUFNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFUFNome_Sel)) ? "(Vazio)" : AV55TFUFNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFUFNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFUFNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFUFRegNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Região") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFUFRegNome_Sel)) ? "(Vazio)" : AV57TFUFRegNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFUFRegNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Região") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFUFRegNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("core.ufWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("core.ufWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV59GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Core_ufwwds_1_filterfulltext = AV19FilterFullText;
         AV62Core_ufwwds_2_tfufid = AV50TFUFID;
         AV63Core_ufwwds_3_tfufid_to = AV51TFUFID_To;
         AV64Core_ufwwds_4_tfufsigla = AV52TFUFSigla;
         AV65Core_ufwwds_5_tfufsigla_sel = AV53TFUFSigla_Sel;
         AV66Core_ufwwds_6_tfufnome = AV54TFUFNome;
         AV67Core_ufwwds_7_tfufnome_sel = AV55TFUFNome_Sel;
         AV68Core_ufwwds_8_tfufregnome = AV56TFUFRegNome;
         AV69Core_ufwwds_9_tfufregnome_sel = AV57TFUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Core_ufwwds_1_filterfulltext ,
                                              AV62Core_ufwwds_2_tfufid ,
                                              AV63Core_ufwwds_3_tfufid_to ,
                                              AV65Core_ufwwds_5_tfufsigla_sel ,
                                              AV64Core_ufwwds_4_tfufsigla ,
                                              AV67Core_ufwwds_7_tfufnome_sel ,
                                              AV66Core_ufwwds_6_tfufnome ,
                                              AV69Core_ufwwds_9_tfufregnome_sel ,
                                              AV68Core_ufwwds_8_tfufregnome ,
                                              A4UFID ,
                                              A5UFSigla ,
                                              A6UFNome ,
                                              A10UFRegNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_1_filterfulltext), "%", "");
         lV61Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_1_filterfulltext), "%", "");
         lV61Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_1_filterfulltext), "%", "");
         lV61Core_ufwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_ufwwds_1_filterfulltext), "%", "");
         lV64Core_ufwwds_4_tfufsigla = StringUtil.Concat( StringUtil.RTrim( AV64Core_ufwwds_4_tfufsigla), "%", "");
         lV66Core_ufwwds_6_tfufnome = StringUtil.Concat( StringUtil.RTrim( AV66Core_ufwwds_6_tfufnome), "%", "");
         lV68Core_ufwwds_8_tfufregnome = StringUtil.Concat( StringUtil.RTrim( AV68Core_ufwwds_8_tfufregnome), "%", "");
         /* Using cursor P005F2 */
         pr_default.execute(0, new Object[] {lV61Core_ufwwds_1_filterfulltext, lV61Core_ufwwds_1_filterfulltext, lV61Core_ufwwds_1_filterfulltext, lV61Core_ufwwds_1_filterfulltext, AV62Core_ufwwds_2_tfufid, AV63Core_ufwwds_3_tfufid_to, lV64Core_ufwwds_4_tfufsigla, AV65Core_ufwwds_5_tfufsigla_sel, lV66Core_ufwwds_6_tfufnome, AV67Core_ufwwds_7_tfufnome_sel, lV68Core_ufwwds_8_tfufregnome, AV69Core_ufwwds_9_tfufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4UFID = P005F2_A4UFID[0];
            A10UFRegNome = P005F2_A10UFRegNome[0];
            A6UFNome = P005F2_A6UFNome[0];
            A5UFSigla = P005F2_A5UFSigla[0];
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
            AV70GXV2 = 1;
            while ( AV70GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV70GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "UFID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A4UFID;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "UFSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A5UFSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "UFNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A6UFNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "UFRegNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A10UFRegNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV70GXV2 = (int)(AV70GXV2+1);
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
         AV35Session.Set("WWPExportFileName", "ufWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "UFID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "UFSigla",  "",  "Sigla",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "UFNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "UFRegNome",  "",  "Região",  true,  "") ;
         GXt_char1 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ufWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("core.ufWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ufWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("core.ufWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV71GXV3 = 1;
         while ( AV71GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV71GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFID") == 0 )
            {
               AV50TFUFID = (int)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFUFID_To = (int)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFSIGLA") == 0 )
            {
               AV52TFUFSigla = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFSIGLA_SEL") == 0 )
            {
               AV53TFUFSigla_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFNOME") == 0 )
            {
               AV54TFUFNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFNOME_SEL") == 0 )
            {
               AV55TFUFNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFREGNOME") == 0 )
            {
               AV56TFUFRegNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUFREGNOME_SEL") == 0 )
            {
               AV57TFUFRegNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV71GXV3 = (int)(AV71GXV3+1);
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
         AV53TFUFSigla_Sel = "";
         AV52TFUFSigla = "";
         AV55TFUFNome_Sel = "";
         AV54TFUFNome = "";
         AV57TFUFRegNome_Sel = "";
         AV56TFUFRegNome = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV61Core_ufwwds_1_filterfulltext = "";
         AV64Core_ufwwds_4_tfufsigla = "";
         AV65Core_ufwwds_5_tfufsigla_sel = "";
         AV66Core_ufwwds_6_tfufnome = "";
         AV67Core_ufwwds_7_tfufnome_sel = "";
         AV68Core_ufwwds_8_tfufregnome = "";
         AV69Core_ufwwds_9_tfufregnome_sel = "";
         scmdbuf = "";
         lV61Core_ufwwds_1_filterfulltext = "";
         lV64Core_ufwwds_4_tfufsigla = "";
         lV66Core_ufwwds_6_tfufnome = "";
         lV68Core_ufwwds_8_tfufregnome = "";
         A5UFSigla = "";
         A6UFNome = "";
         A10UFRegNome = "";
         P005F2_A4UFID = new int[1] ;
         P005F2_A10UFRegNome = new string[] {""} ;
         P005F2_A6UFNome = new string[] {""} ;
         P005F2_A5UFSigla = new string[] {""} ;
         AV43UserCustomValue = "";
         GXt_char1 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.ufwwexport__default(),
            new Object[][] {
                new Object[] {
               P005F2_A4UFID, P005F2_A10UFRegNome, P005F2_A6UFNome, P005F2_A5UFSigla
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
      private int AV50TFUFID ;
      private int AV51TFUFID_To ;
      private int AV59GXV1 ;
      private int AV62Core_ufwwds_2_tfufid ;
      private int AV63Core_ufwwds_3_tfufid_to ;
      private int A4UFID ;
      private int AV70GXV2 ;
      private int AV71GXV3 ;
      private long AV47VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV53TFUFSigla_Sel ;
      private string AV52TFUFSigla ;
      private string AV55TFUFNome_Sel ;
      private string AV54TFUFNome ;
      private string AV57TFUFRegNome_Sel ;
      private string AV56TFUFRegNome ;
      private string AV61Core_ufwwds_1_filterfulltext ;
      private string AV64Core_ufwwds_4_tfufsigla ;
      private string AV65Core_ufwwds_5_tfufsigla_sel ;
      private string AV66Core_ufwwds_6_tfufnome ;
      private string AV67Core_ufwwds_7_tfufnome_sel ;
      private string AV68Core_ufwwds_8_tfufregnome ;
      private string AV69Core_ufwwds_9_tfufregnome_sel ;
      private string lV61Core_ufwwds_1_filterfulltext ;
      private string lV64Core_ufwwds_4_tfufsigla ;
      private string lV66Core_ufwwds_6_tfufnome ;
      private string lV68Core_ufwwds_8_tfufregnome ;
      private string A5UFSigla ;
      private string A6UFNome ;
      private string A10UFRegNome ;
      private IGxSession AV35Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005F2_A4UFID ;
      private string[] P005F2_A10UFRegNome ;
      private string[] P005F2_A6UFNome ;
      private string[] P005F2_A5UFSigla ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
   }

   public class ufwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005F2( IGxContext context ,
                                             string AV61Core_ufwwds_1_filterfulltext ,
                                             int AV62Core_ufwwds_2_tfufid ,
                                             int AV63Core_ufwwds_3_tfufid_to ,
                                             string AV65Core_ufwwds_5_tfufsigla_sel ,
                                             string AV64Core_ufwwds_4_tfufsigla ,
                                             string AV67Core_ufwwds_7_tfufnome_sel ,
                                             string AV66Core_ufwwds_6_tfufnome ,
                                             string AV69Core_ufwwds_9_tfufregnome_sel ,
                                             string AV68Core_ufwwds_8_tfufregnome ,
                                             int A4UFID ,
                                             string A5UFSigla ,
                                             string A6UFNome ,
                                             string A10UFRegNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT UFID, UFRegNome, UFNome, UFSigla FROM tbibge_uf";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_ufwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(UFID,'999999999'), 2) like '%' || :lV61Core_ufwwds_1_filterfulltext) or ( UFSigla like '%' || :lV61Core_ufwwds_1_filterfulltext) or ( UFNome like '%' || :lV61Core_ufwwds_1_filterfulltext) or ( UFRegNome like '%' || :lV61Core_ufwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV62Core_ufwwds_2_tfufid) )
         {
            AddWhere(sWhereString, "(UFID >= :AV62Core_ufwwds_2_tfufid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV63Core_ufwwds_3_tfufid_to) )
         {
            AddWhere(sWhereString, "(UFID <= :AV63Core_ufwwds_3_tfufid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_ufwwds_5_tfufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_ufwwds_4_tfufsigla)) ) )
         {
            AddWhere(sWhereString, "(UFSigla like :lV64Core_ufwwds_4_tfufsigla)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_ufwwds_5_tfufsigla_sel)) && ! ( StringUtil.StrCmp(AV65Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFSigla = ( :AV65Core_ufwwds_5_tfufsigla_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Core_ufwwds_5_tfufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_ufwwds_7_tfufnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_ufwwds_6_tfufnome)) ) )
         {
            AddWhere(sWhereString, "(UFNome like :lV66Core_ufwwds_6_tfufnome)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_ufwwds_7_tfufnome_sel)) && ! ( StringUtil.StrCmp(AV67Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFNome = ( :AV67Core_ufwwds_7_tfufnome_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_ufwwds_7_tfufnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_ufwwds_9_tfufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_ufwwds_8_tfufregnome)) ) )
         {
            AddWhere(sWhereString, "(UFRegNome like :lV68Core_ufwwds_8_tfufregnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_ufwwds_9_tfufregnome_sel)) && ! ( StringUtil.StrCmp(AV69Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(UFRegNome = ( :AV69Core_ufwwds_9_tfufregnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_ufwwds_9_tfufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from UFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY UFSigla";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY UFSigla DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY UFID";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY UFID DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY UFNome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY UFNome DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY UFRegNome";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY UFRegNome DESC";
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
                     return conditional_P005F2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP005F2;
          prmP005F2 = new Object[] {
          new ParDef("lV61Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_ufwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV62Core_ufwwds_2_tfufid",GXType.Int32,9,0) ,
          new ParDef("AV63Core_ufwwds_3_tfufid_to",GXType.Int32,9,0) ,
          new ParDef("lV64Core_ufwwds_4_tfufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV65Core_ufwwds_5_tfufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV66Core_ufwwds_6_tfufnome",GXType.VarChar,50,0) ,
          new ParDef("AV67Core_ufwwds_7_tfufnome_sel",GXType.VarChar,50,0) ,
          new ParDef("lV68Core_ufwwds_8_tfufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV69Core_ufwwds_9_tfufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
