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
   public class microrregiaowwexport : GXProcedure
   {
      public microrregiaowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public microrregiaowwexport( IGxContext context )
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
         microrregiaowwexport objmicrorregiaowwexport;
         objmicrorregiaowwexport = new microrregiaowwexport();
         objmicrorregiaowwexport.AV12Filename = "" ;
         objmicrorregiaowwexport.AV13ErrorMessage = "" ;
         objmicrorregiaowwexport.context.SetSubmitInitialConfig(context);
         objmicrorregiaowwexport.initialize();
         Submit( executePrivateCatch,objmicrorregiaowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((microrregiaowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "microrregiaoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFMicrorregiaoID) && (0==AV36TFMicrorregiaoID_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "ID") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFMicrorregiaoID;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFMicrorregiaoID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMicrorregiaoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMicrorregiaoNome_Sel)) ? "(Vazio)" : AV38TFMicrorregiaoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMicrorregiaoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFMicrorregiaoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMicrorregiaoMesoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Mesoregião") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMicrorregiaoMesoNome_Sel)) ? "(Vazio)" : AV40TFMicrorregiaoMesoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMicrorregiaoMesoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Mesoregião") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFMicrorregiaoMesoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMicrorregiaoMesoUFSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "UF") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMicrorregiaoMesoUFSigla_Sel)) ? "(Vazio)" : AV42TFMicrorregiaoMesoUFSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMicrorregiaoMesoUFSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "UF") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFMicrorregiaoMesoUFSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMicrorregiaoMesoUFRegNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Região") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMicrorregiaoMesoUFRegNome_Sel)) ? "(Vazio)" : AV44TFMicrorregiaoMesoUFRegNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMicrorregiaoMesoUFRegNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Região") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFMicrorregiaoMesoUFRegNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("core.microrregiaoWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("core.microrregiaoWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV46GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Core_microrregiaowwds_1_filterfulltext = AV19FilterFullText;
         AV49Core_microrregiaowwds_2_tfmicrorregiaoid = AV35TFMicrorregiaoID;
         AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV36TFMicrorregiaoID_To;
         AV51Core_microrregiaowwds_4_tfmicrorregiaonome = AV37TFMicrorregiaoNome;
         AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV38TFMicrorregiaoNome_Sel;
         AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV39TFMicrorregiaoMesoNome;
         AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV40TFMicrorregiaoMesoNome_Sel;
         AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV41TFMicrorregiaoMesoUFSigla;
         AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV42TFMicrorregiaoMesoUFSigla_Sel;
         AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV43TFMicrorregiaoMesoUFRegNome;
         AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV44TFMicrorregiaoMesoUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV48Core_microrregiaowwds_1_filterfulltext ,
                                              AV49Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                              AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                              AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                              AV51Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                              AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                              AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                              AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                              AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                              AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                              AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                              A23MicrorregiaoID ,
                                              A24MicrorregiaoNome ,
                                              A26MicrorregiaoMesoNome ,
                                              A28MicrorregiaoMesoUFSigla ,
                                              A33MicrorregiaoMesoUFRegNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV48Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV48Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV48Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV48Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV51Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV51Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
         lV53Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
         lV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
         lV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
         /* Using cursor P005N2 */
         pr_default.execute(0, new Object[] {lV48Core_microrregiaowwds_1_filterfulltext, lV48Core_microrregiaowwds_1_filterfulltext, lV48Core_microrregiaowwds_1_filterfulltext, lV48Core_microrregiaowwds_1_filterfulltext, lV48Core_microrregiaowwds_1_filterfulltext, AV49Core_microrregiaowwds_2_tfmicrorregiaoid, AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV51Core_microrregiaowwds_4_tfmicrorregiaonome, AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV53Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A23MicrorregiaoID = P005N2_A23MicrorregiaoID[0];
            A33MicrorregiaoMesoUFRegNome = P005N2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P005N2_n33MicrorregiaoMesoUFRegNome[0];
            A28MicrorregiaoMesoUFSigla = P005N2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P005N2_n28MicrorregiaoMesoUFSigla[0];
            A26MicrorregiaoMesoNome = P005N2_A26MicrorregiaoMesoNome[0];
            A24MicrorregiaoNome = P005N2_A24MicrorregiaoNome[0];
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
            AV59GXV2 = 1;
            while ( AV59GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV59GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MicrorregiaoID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A23MicrorregiaoID;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MicrorregiaoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A24MicrorregiaoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MicrorregiaoMesoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A26MicrorregiaoMesoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MicrorregiaoMesoUFSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A28MicrorregiaoMesoUFSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MicrorregiaoMesoUFRegNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A33MicrorregiaoMesoUFRegNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV59GXV2 = (int)(AV59GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "microrregiaoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MicrorregiaoID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MicrorregiaoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MicrorregiaoMesoNome",  "",  "Mesoregião",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MicrorregiaoMesoUFSigla",  "",  "UF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MicrorregiaoMesoUFRegNome",  "",  "Região",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.microrregiaoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("core.microrregiaoWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.microrregiaoWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("core.microrregiaoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV60GXV3 = 1;
         while ( AV60GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV60GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOID") == 0 )
            {
               AV35TFMicrorregiaoID = (int)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFMicrorregiaoID_To = (int)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAONOME") == 0 )
            {
               AV37TFMicrorregiaoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAONOME_SEL") == 0 )
            {
               AV38TFMicrorregiaoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESONOME") == 0 )
            {
               AV39TFMicrorregiaoMesoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESONOME_SEL") == 0 )
            {
               AV40TFMicrorregiaoMesoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFSIGLA") == 0 )
            {
               AV41TFMicrorregiaoMesoUFSigla = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFSIGLA_SEL") == 0 )
            {
               AV42TFMicrorregiaoMesoUFSigla_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFREGNOME") == 0 )
            {
               AV43TFMicrorregiaoMesoUFRegNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFREGNOME_SEL") == 0 )
            {
               AV44TFMicrorregiaoMesoUFRegNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV60GXV3 = (int)(AV60GXV3+1);
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
         AV38TFMicrorregiaoNome_Sel = "";
         AV37TFMicrorregiaoNome = "";
         AV40TFMicrorregiaoMesoNome_Sel = "";
         AV39TFMicrorregiaoMesoNome = "";
         AV42TFMicrorregiaoMesoUFSigla_Sel = "";
         AV41TFMicrorregiaoMesoUFSigla = "";
         AV44TFMicrorregiaoMesoUFRegNome_Sel = "";
         AV43TFMicrorregiaoMesoUFRegNome = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV48Core_microrregiaowwds_1_filterfulltext = "";
         AV51Core_microrregiaowwds_4_tfmicrorregiaonome = "";
         AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel = "";
         AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome = "";
         AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = "";
         AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = "";
         AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = "";
         AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = "";
         AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = "";
         scmdbuf = "";
         lV48Core_microrregiaowwds_1_filterfulltext = "";
         lV51Core_microrregiaowwds_4_tfmicrorregiaonome = "";
         lV53Core_microrregiaowwds_6_tfmicrorregiaomesonome = "";
         lV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = "";
         lV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = "";
         A24MicrorregiaoNome = "";
         A26MicrorregiaoMesoNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         P005N2_A23MicrorregiaoID = new int[1] ;
         P005N2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P005N2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P005N2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P005N2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P005N2_A26MicrorregiaoMesoNome = new string[] {""} ;
         P005N2_A24MicrorregiaoNome = new string[] {""} ;
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiaowwexport__default(),
            new Object[][] {
                new Object[] {
               P005N2_A23MicrorregiaoID, P005N2_A33MicrorregiaoMesoUFRegNome, P005N2_n33MicrorregiaoMesoUFRegNome, P005N2_A28MicrorregiaoMesoUFSigla, P005N2_n28MicrorregiaoMesoUFSigla, P005N2_A26MicrorregiaoMesoNome, P005N2_A24MicrorregiaoNome
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
      private int AV35TFMicrorregiaoID ;
      private int AV36TFMicrorregiaoID_To ;
      private int AV46GXV1 ;
      private int AV49Core_microrregiaowwds_2_tfmicrorregiaoid ;
      private int AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to ;
      private int A23MicrorregiaoID ;
      private int AV59GXV2 ;
      private int AV60GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFMicrorregiaoNome_Sel ;
      private string AV37TFMicrorregiaoNome ;
      private string AV40TFMicrorregiaoMesoNome_Sel ;
      private string AV39TFMicrorregiaoMesoNome ;
      private string AV42TFMicrorregiaoMesoUFSigla_Sel ;
      private string AV41TFMicrorregiaoMesoUFSigla ;
      private string AV44TFMicrorregiaoMesoUFRegNome_Sel ;
      private string AV43TFMicrorregiaoMesoUFRegNome ;
      private string AV48Core_microrregiaowwds_1_filterfulltext ;
      private string AV51Core_microrregiaowwds_4_tfmicrorregiaonome ;
      private string AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel ;
      private string AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome ;
      private string AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ;
      private string AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ;
      private string AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ;
      private string AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ;
      private string AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ;
      private string lV48Core_microrregiaowwds_1_filterfulltext ;
      private string lV51Core_microrregiaowwds_4_tfmicrorregiaonome ;
      private string lV53Core_microrregiaowwds_6_tfmicrorregiaomesonome ;
      private string lV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ;
      private string lV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ;
      private string A24MicrorregiaoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005N2_A23MicrorregiaoID ;
      private string[] P005N2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P005N2_n33MicrorregiaoMesoUFRegNome ;
      private string[] P005N2_A28MicrorregiaoMesoUFSigla ;
      private bool[] P005N2_n28MicrorregiaoMesoUFSigla ;
      private string[] P005N2_A26MicrorregiaoMesoNome ;
      private string[] P005N2_A24MicrorregiaoNome ;
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

   public class microrregiaowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005N2( IGxContext context ,
                                             string AV48Core_microrregiaowwds_1_filterfulltext ,
                                             int AV49Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV51Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MicrorregiaoID, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSigla, MicrorregiaoMesoNome, MicrorregiaoNome FROM tbibge_microrregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV48Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV48Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV48Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV48Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV48Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV49Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV49Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV51Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV53Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MicrorregiaoNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MicrorregiaoNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MicrorregiaoID";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MicrorregiaoID DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MicrorregiaoMesoNome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MicrorregiaoMesoNome DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MicrorregiaoMesoUFSigla";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MicrorregiaoMesoUFSigla DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MicrorregiaoMesoUFRegNome";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MicrorregiaoMesoUFRegNome DESC";
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
                     return conditional_P005N2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmP005N2;
          prmP005N2 = new Object[] {
          new ParDef("lV48Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV49Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV50Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV51Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV52Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV53Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV56Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV57Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV58Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005N2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
