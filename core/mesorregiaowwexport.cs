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
   public class mesorregiaowwexport : GXProcedure
   {
      public mesorregiaowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mesorregiaowwexport( IGxContext context )
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
         mesorregiaowwexport objmesorregiaowwexport;
         objmesorregiaowwexport = new mesorregiaowwexport();
         objmesorregiaowwexport.AV12Filename = "" ;
         objmesorregiaowwexport.AV13ErrorMessage = "" ;
         objmesorregiaowwexport.context.SetSubmitInitialConfig(context);
         objmesorregiaowwexport.initialize();
         Submit( executePrivateCatch,objmesorregiaowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((mesorregiaowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "mesorregiaoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV52TFMesorregiaoID) && (0==AV53TFMesorregiaoID_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "ID") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV52TFMesorregiaoID;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "At�") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV53TFMesorregiaoID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMesorregiaoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMesorregiaoNome_Sel)) ? "(Vazio)" : AV51TFMesorregiaoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMesorregiaoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFMesorregiaoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFMesorregiaoUFSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "UF") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFMesorregiaoUFSigla_Sel)) ? "(Vazio)" : AV55TFMesorregiaoUFSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFMesorregiaoUFSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "UF") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV54TFMesorregiaoUFSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFMesorregiaoUFRegNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Regi�o") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFMesorregiaoUFRegNome_Sel)) ? "(Vazio)" : AV57TFMesorregiaoUFRegNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFMesorregiaoUFRegNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Regi�o") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFMesorregiaoUFRegNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("core.mesorregiaoWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("core.mesorregiaoWWColumnsSelector");
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
         AV61Core_mesorregiaowwds_1_filterfulltext = AV19FilterFullText;
         AV62Core_mesorregiaowwds_2_tfmesorregiaoid = AV52TFMesorregiaoID;
         AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV53TFMesorregiaoID_To;
         AV64Core_mesorregiaowwds_4_tfmesorregiaonome = AV50TFMesorregiaoNome;
         AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV51TFMesorregiaoNome_Sel;
         AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV54TFMesorregiaoUFSigla;
         AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV55TFMesorregiaoUFSigla_Sel;
         AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV56TFMesorregiaoUFRegNome;
         AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV57TFMesorregiaoUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Core_mesorregiaowwds_1_filterfulltext ,
                                              AV62Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                              AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                              AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                              AV64Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                              AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                              AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                              AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                              AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                              A13MesorregiaoID ,
                                              A14MesorregiaoNome ,
                                              A16MesorregiaoUFSigla ,
                                              A21MesorregiaoUFRegNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV61Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV61Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV61Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV64Core_mesorregiaowwds_4_tfmesorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_4_tfmesorregiaonome), "%", "");
         lV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla = StringUtil.Concat( StringUtil.RTrim( AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla), "%", "");
         lV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome = StringUtil.Concat( StringUtil.RTrim( AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome), "%", "");
         /* Using cursor P005J2 */
         pr_default.execute(0, new Object[] {lV61Core_mesorregiaowwds_1_filterfulltext, lV61Core_mesorregiaowwds_1_filterfulltext, lV61Core_mesorregiaowwds_1_filterfulltext, lV61Core_mesorregiaowwds_1_filterfulltext, AV62Core_mesorregiaowwds_2_tfmesorregiaoid, AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to, lV64Core_mesorregiaowwds_4_tfmesorregiaonome, AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel, lV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla, AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, lV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome, AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A13MesorregiaoID = P005J2_A13MesorregiaoID[0];
            A21MesorregiaoUFRegNome = P005J2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = P005J2_n21MesorregiaoUFRegNome[0];
            A16MesorregiaoUFSigla = P005J2_A16MesorregiaoUFSigla[0];
            A14MesorregiaoNome = P005J2_A14MesorregiaoNome[0];
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
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MesorregiaoID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A13MesorregiaoID;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MesorregiaoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A14MesorregiaoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MesorregiaoUFSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A16MesorregiaoUFSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "MesorregiaoUFRegNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A21MesorregiaoUFRegNome, out  GXt_char1) ;
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
         AV35Session.Set("WWPExportFileName", "mesorregiaoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MesorregiaoID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MesorregiaoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MesorregiaoUFSigla",  "",  "UF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "MesorregiaoUFRegNome",  "",  "Regi�o",  true,  "") ;
         GXt_char1 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.mesorregiaoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("core.mesorregiaoWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.mesorregiaoWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("core.mesorregiaoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOID") == 0 )
            {
               AV52TFMesorregiaoID = (int)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV53TFMesorregiaoID_To = (int)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAONOME") == 0 )
            {
               AV50TFMesorregiaoNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAONOME_SEL") == 0 )
            {
               AV51TFMesorregiaoNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFSIGLA") == 0 )
            {
               AV54TFMesorregiaoUFSigla = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFSIGLA_SEL") == 0 )
            {
               AV55TFMesorregiaoUFSigla_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFREGNOME") == 0 )
            {
               AV56TFMesorregiaoUFRegNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFREGNOME_SEL") == 0 )
            {
               AV57TFMesorregiaoUFRegNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
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
         AV51TFMesorregiaoNome_Sel = "";
         AV50TFMesorregiaoNome = "";
         AV55TFMesorregiaoUFSigla_Sel = "";
         AV54TFMesorregiaoUFSigla = "";
         AV57TFMesorregiaoUFRegNome_Sel = "";
         AV56TFMesorregiaoUFRegNome = "";
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV61Core_mesorregiaowwds_1_filterfulltext = "";
         AV64Core_mesorregiaowwds_4_tfmesorregiaonome = "";
         AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel = "";
         AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla = "";
         AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = "";
         AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome = "";
         AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = "";
         scmdbuf = "";
         lV61Core_mesorregiaowwds_1_filterfulltext = "";
         lV64Core_mesorregiaowwds_4_tfmesorregiaonome = "";
         lV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla = "";
         lV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome = "";
         A14MesorregiaoNome = "";
         A16MesorregiaoUFSigla = "";
         A21MesorregiaoUFRegNome = "";
         P005J2_A13MesorregiaoID = new int[1] ;
         P005J2_A21MesorregiaoUFRegNome = new string[] {""} ;
         P005J2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         P005J2_A16MesorregiaoUFSigla = new string[] {""} ;
         P005J2_A14MesorregiaoNome = new string[] {""} ;
         AV43UserCustomValue = "";
         GXt_char1 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiaowwexport__default(),
            new Object[][] {
                new Object[] {
               P005J2_A13MesorregiaoID, P005J2_A21MesorregiaoUFRegNome, P005J2_n21MesorregiaoUFRegNome, P005J2_A16MesorregiaoUFSigla, P005J2_A14MesorregiaoNome
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
      private int AV52TFMesorregiaoID ;
      private int AV53TFMesorregiaoID_To ;
      private int AV59GXV1 ;
      private int AV62Core_mesorregiaowwds_2_tfmesorregiaoid ;
      private int AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to ;
      private int A13MesorregiaoID ;
      private int AV70GXV2 ;
      private int AV71GXV3 ;
      private long AV47VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n21MesorregiaoUFRegNome ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV51TFMesorregiaoNome_Sel ;
      private string AV50TFMesorregiaoNome ;
      private string AV55TFMesorregiaoUFSigla_Sel ;
      private string AV54TFMesorregiaoUFSigla ;
      private string AV57TFMesorregiaoUFRegNome_Sel ;
      private string AV56TFMesorregiaoUFRegNome ;
      private string AV61Core_mesorregiaowwds_1_filterfulltext ;
      private string AV64Core_mesorregiaowwds_4_tfmesorregiaonome ;
      private string AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel ;
      private string AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla ;
      private string AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ;
      private string AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome ;
      private string AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ;
      private string lV61Core_mesorregiaowwds_1_filterfulltext ;
      private string lV64Core_mesorregiaowwds_4_tfmesorregiaonome ;
      private string lV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla ;
      private string lV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome ;
      private string A14MesorregiaoNome ;
      private string A16MesorregiaoUFSigla ;
      private string A21MesorregiaoUFRegNome ;
      private IGxSession AV35Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005J2_A13MesorregiaoID ;
      private string[] P005J2_A21MesorregiaoUFRegNome ;
      private bool[] P005J2_n21MesorregiaoUFRegNome ;
      private string[] P005J2_A16MesorregiaoUFSigla ;
      private string[] P005J2_A14MesorregiaoNome ;
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

   public class mesorregiaowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005J2( IGxContext context ,
                                             string AV61Core_mesorregiaowwds_1_filterfulltext ,
                                             int AV62Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                             int AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                             string AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                             string AV64Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                             string AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                             string AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                             string AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                             string AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                             int A13MesorregiaoID ,
                                             string A14MesorregiaoNome ,
                                             string A16MesorregiaoUFSigla ,
                                             string A21MesorregiaoUFRegNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MesorregiaoID, MesorregiaoUFRegNome, MesorregiaoUFSigla, MesorregiaoNome FROM tbibge_mesorregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_mesorregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MesorregiaoID,'999999999'), 2) like '%' || :lV61Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoNome like '%' || :lV61Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFSigla like '%' || :lV61Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFRegNome like '%' || :lV61Core_mesorregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV62Core_mesorregiaowwds_2_tfmesorregiaoid) )
         {
            AddWhere(sWhereString, "(MesorregiaoID >= :AV62Core_mesorregiaowwds_2_tfmesorregiaoid)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MesorregiaoID <= :AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_4_tfmesorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome like :lV64Core_mesorregiaowwds_4_tfmesorregiaonome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome = ( :AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla like :lV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ! ( StringUtil.StrCmp(AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla = ( :AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome like :lV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ! ( StringUtil.StrCmp(AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome = ( :AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MesorregiaoNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MesorregiaoNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MesorregiaoID";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MesorregiaoID DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MesorregiaoUFSigla";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MesorregiaoUFSigla DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MesorregiaoUFRegNome";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MesorregiaoUFRegNome DESC";
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
                     return conditional_P005J2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP005J2;
          prmP005J2 = new Object[] {
          new ParDef("lV61Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV62Core_mesorregiaowwds_2_tfmesorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV63Core_mesorregiaowwds_3_tfmesorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV64Core_mesorregiaowwds_4_tfmesorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV65Core_mesorregiaowwds_5_tfmesorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_mesorregiaowwds_6_tfmesorregiaoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV67Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV68Core_mesorregiaowwds_8_tfmesorregiaoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV69Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
