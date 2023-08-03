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
   public class municipiowwexport : GXProcedure
   {
      public municipiowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipiowwexport( IGxContext context )
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
         municipiowwexport objmunicipiowwexport;
         objmunicipiowwexport = new municipiowwexport();
         objmunicipiowwexport.AV12Filename = "" ;
         objmunicipiowwexport.AV13ErrorMessage = "" ;
         objmunicipiowwexport.context.SetSubmitInitialConfig(context);
         objmunicipiowwexport.initialize();
         Submit( executePrivateCatch,objmunicipiowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((municipiowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "municipioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFMunicipioID) && (0==AV36TFMunicipioID_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "ID") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV35TFMunicipioID;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV36TFMunicipioID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMunicipioNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFMunicipioNome_Sel)) ? "(Vazio)" : AV38TFMunicipioNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFMunicipioNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFMunicipioNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMunicipioMicroNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Microrregião") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMunicipioMicroNome_Sel)) ? "(Vazio)" : AV40TFMunicipioMicroNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMunicipioMicroNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Microrregião") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFMunicipioMicroNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMunicipioMicroMesoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Mesorregião") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMunicipioMicroMesoNome_Sel)) ? "(Vazio)" : AV42TFMunicipioMicroMesoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMunicipioMicroMesoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Mesorregião") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFMunicipioMicroMesoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMunicipioMicroMesoUFSigla_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "UF") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMunicipioMicroMesoUFSigla_Sel)) ? "(Vazio)" : AV44TFMunicipioMicroMesoUFSigla_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFMunicipioMicroMesoUFSigla)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "UF") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFMunicipioMicroMesoUFSigla, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFMunicipioMicroMesoUFRegNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Região") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV46TFMunicipioMicroMesoUFRegNome_Sel)) ? "(Vazio)" : AV46TFMunicipioMicroMesoUFRegNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFMunicipioMicroMesoUFRegNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Região") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFMunicipioMicroMesoUFRegNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("core.municipioWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("core.municipioWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV48GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV50Core_municipiowwds_1_filterfulltext = AV19FilterFullText;
         AV51Core_municipiowwds_2_tfmunicipioid = AV35TFMunicipioID;
         AV52Core_municipiowwds_3_tfmunicipioid_to = AV36TFMunicipioID_To;
         AV53Core_municipiowwds_4_tfmunicipionome = AV37TFMunicipioNome;
         AV54Core_municipiowwds_5_tfmunicipionome_sel = AV38TFMunicipioNome_Sel;
         AV55Core_municipiowwds_6_tfmunicipiomicronome = AV39TFMunicipioMicroNome;
         AV56Core_municipiowwds_7_tfmunicipiomicronome_sel = AV40TFMunicipioMicroNome_Sel;
         AV57Core_municipiowwds_8_tfmunicipiomicromesonome = AV41TFMunicipioMicroMesoNome;
         AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel = AV42TFMunicipioMicroMesoNome_Sel;
         AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla = AV43TFMunicipioMicroMesoUFSigla;
         AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = AV44TFMunicipioMicroMesoUFSigla_Sel;
         AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome = AV45TFMunicipioMicroMesoUFRegNome;
         AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = AV46TFMunicipioMicroMesoUFRegNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Core_municipiowwds_1_filterfulltext ,
                                              AV51Core_municipiowwds_2_tfmunicipioid ,
                                              AV52Core_municipiowwds_3_tfmunicipioid_to ,
                                              AV54Core_municipiowwds_5_tfmunicipionome_sel ,
                                              AV53Core_municipiowwds_4_tfmunicipionome ,
                                              AV56Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                              AV55Core_municipiowwds_6_tfmunicipiomicronome ,
                                              AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                              AV57Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                              AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                              AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                              AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                              AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                              A35MunicipioID ,
                                              A36MunicipioNome ,
                                              A38MunicipioMicroNome ,
                                              A40MunicipioMicroMesoNome ,
                                              A42MunicipioMicroMesoUFSigla ,
                                              A47MunicipioMicroMesoUFRegNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext), "%", "");
         lV50Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext), "%", "");
         lV50Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext), "%", "");
         lV50Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext), "%", "");
         lV50Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext), "%", "");
         lV50Core_municipiowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext), "%", "");
         lV53Core_municipiowwds_4_tfmunicipionome = StringUtil.Concat( StringUtil.RTrim( AV53Core_municipiowwds_4_tfmunicipionome), "%", "");
         lV55Core_municipiowwds_6_tfmunicipiomicronome = StringUtil.Concat( StringUtil.RTrim( AV55Core_municipiowwds_6_tfmunicipiomicronome), "%", "");
         lV57Core_municipiowwds_8_tfmunicipiomicromesonome = StringUtil.Concat( StringUtil.RTrim( AV57Core_municipiowwds_8_tfmunicipiomicromesonome), "%", "");
         lV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla), "%", "");
         lV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome), "%", "");
         /* Using cursor P005Q2 */
         pr_default.execute(0, new Object[] {lV50Core_municipiowwds_1_filterfulltext, lV50Core_municipiowwds_1_filterfulltext, lV50Core_municipiowwds_1_filterfulltext, lV50Core_municipiowwds_1_filterfulltext, lV50Core_municipiowwds_1_filterfulltext, lV50Core_municipiowwds_1_filterfulltext, AV51Core_municipiowwds_2_tfmunicipioid, AV52Core_municipiowwds_3_tfmunicipioid_to, lV53Core_municipiowwds_4_tfmunicipionome, AV54Core_municipiowwds_5_tfmunicipionome_sel, lV55Core_municipiowwds_6_tfmunicipiomicronome, AV56Core_municipiowwds_7_tfmunicipiomicronome_sel, lV57Core_municipiowwds_8_tfmunicipiomicromesonome, AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel, lV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla, AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, lV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome, AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A35MunicipioID = P005Q2_A35MunicipioID[0];
            A47MunicipioMicroMesoUFRegNome = P005Q2_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P005Q2_n47MunicipioMicroMesoUFRegNome[0];
            A42MunicipioMicroMesoUFSigla = P005Q2_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P005Q2_n42MunicipioMicroMesoUFSigla[0];
            A40MunicipioMicroMesoNome = P005Q2_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P005Q2_n40MunicipioMicroMesoNome[0];
            A38MunicipioMicroNome = P005Q2_A38MunicipioMicroNome[0];
            A36MunicipioNome = P005Q2_A36MunicipioNome[0];
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
            AV63GXV2 = 1;
            while ( AV63GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV63GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MunicipioID") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A35MunicipioID;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MunicipioNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A36MunicipioNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MunicipioMicroNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A38MunicipioMicroNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MunicipioMicroMesoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A40MunicipioMicroMesoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MunicipioMicroMesoUFSigla") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A42MunicipioMicroMesoUFSigla, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "MunicipioMicroMesoUFRegNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A47MunicipioMicroMesoUFRegNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
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
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "municipioWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MunicipioID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MunicipioNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MunicipioMicroNome",  "",  "Microrregião",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MunicipioMicroMesoNome",  "",  "Mesorregião",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MunicipioMicroMesoUFSigla",  "",  "UF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "MunicipioMicroMesoUFRegNome",  "",  "Região",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.municipioWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("core.municipioWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.municipioWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("core.municipioWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV64GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOID") == 0 )
            {
               AV35TFMunicipioID = (int)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFMunicipioID_To = (int)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIONOME") == 0 )
            {
               AV37TFMunicipioNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIONOME_SEL") == 0 )
            {
               AV38TFMunicipioNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICRONOME") == 0 )
            {
               AV39TFMunicipioMicroNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICRONOME_SEL") == 0 )
            {
               AV40TFMunicipioMicroNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESONOME") == 0 )
            {
               AV41TFMunicipioMicroMesoNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESONOME_SEL") == 0 )
            {
               AV42TFMunicipioMicroMesoNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFSIGLA") == 0 )
            {
               AV43TFMunicipioMicroMesoUFSigla = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFSIGLA_SEL") == 0 )
            {
               AV44TFMunicipioMicroMesoUFSigla_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFREGNOME") == 0 )
            {
               AV45TFMunicipioMicroMesoUFRegNome = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFMUNICIPIOMICROMESOUFREGNOME_SEL") == 0 )
            {
               AV46TFMunicipioMicroMesoUFRegNome_Sel = AV23GridStateFilterValue.gxTpr_Value;
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
         AV38TFMunicipioNome_Sel = "";
         AV37TFMunicipioNome = "";
         AV40TFMunicipioMicroNome_Sel = "";
         AV39TFMunicipioMicroNome = "";
         AV42TFMunicipioMicroMesoNome_Sel = "";
         AV41TFMunicipioMicroMesoNome = "";
         AV44TFMunicipioMicroMesoUFSigla_Sel = "";
         AV43TFMunicipioMicroMesoUFSigla = "";
         AV46TFMunicipioMicroMesoUFRegNome_Sel = "";
         AV45TFMunicipioMicroMesoUFRegNome = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV50Core_municipiowwds_1_filterfulltext = "";
         AV53Core_municipiowwds_4_tfmunicipionome = "";
         AV54Core_municipiowwds_5_tfmunicipionome_sel = "";
         AV55Core_municipiowwds_6_tfmunicipiomicronome = "";
         AV56Core_municipiowwds_7_tfmunicipiomicronome_sel = "";
         AV57Core_municipiowwds_8_tfmunicipiomicromesonome = "";
         AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel = "";
         AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla = "";
         AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel = "";
         AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome = "";
         AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel = "";
         scmdbuf = "";
         lV50Core_municipiowwds_1_filterfulltext = "";
         lV53Core_municipiowwds_4_tfmunicipionome = "";
         lV55Core_municipiowwds_6_tfmunicipiomicronome = "";
         lV57Core_municipiowwds_8_tfmunicipiomicromesonome = "";
         lV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla = "";
         lV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome = "";
         A36MunicipioNome = "";
         A38MunicipioMicroNome = "";
         A40MunicipioMicroMesoNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A47MunicipioMicroMesoUFRegNome = "";
         P005Q2_A35MunicipioID = new int[1] ;
         P005Q2_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P005Q2_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P005Q2_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P005Q2_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P005Q2_A40MunicipioMicroMesoNome = new string[] {""} ;
         P005Q2_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P005Q2_A38MunicipioMicroNome = new string[] {""} ;
         P005Q2_A36MunicipioNome = new string[] {""} ;
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV22GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV23GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.municipiowwexport__default(),
            new Object[][] {
                new Object[] {
               P005Q2_A35MunicipioID, P005Q2_A47MunicipioMicroMesoUFRegNome, P005Q2_n47MunicipioMicroMesoUFRegNome, P005Q2_A42MunicipioMicroMesoUFSigla, P005Q2_n42MunicipioMicroMesoUFSigla, P005Q2_A40MunicipioMicroMesoNome, P005Q2_n40MunicipioMicroMesoNome, P005Q2_A38MunicipioMicroNome, P005Q2_A36MunicipioNome
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
      private int AV35TFMunicipioID ;
      private int AV36TFMunicipioID_To ;
      private int AV48GXV1 ;
      private int AV51Core_municipiowwds_2_tfmunicipioid ;
      private int AV52Core_municipiowwds_3_tfmunicipioid_to ;
      private int A35MunicipioID ;
      private int AV63GXV2 ;
      private int AV64GXV3 ;
      private long AV32VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n40MunicipioMicroMesoNome ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFMunicipioNome_Sel ;
      private string AV37TFMunicipioNome ;
      private string AV40TFMunicipioMicroNome_Sel ;
      private string AV39TFMunicipioMicroNome ;
      private string AV42TFMunicipioMicroMesoNome_Sel ;
      private string AV41TFMunicipioMicroMesoNome ;
      private string AV44TFMunicipioMicroMesoUFSigla_Sel ;
      private string AV43TFMunicipioMicroMesoUFSigla ;
      private string AV46TFMunicipioMicroMesoUFRegNome_Sel ;
      private string AV45TFMunicipioMicroMesoUFRegNome ;
      private string AV50Core_municipiowwds_1_filterfulltext ;
      private string AV53Core_municipiowwds_4_tfmunicipionome ;
      private string AV54Core_municipiowwds_5_tfmunicipionome_sel ;
      private string AV55Core_municipiowwds_6_tfmunicipiomicronome ;
      private string AV56Core_municipiowwds_7_tfmunicipiomicronome_sel ;
      private string AV57Core_municipiowwds_8_tfmunicipiomicromesonome ;
      private string AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel ;
      private string AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla ;
      private string AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ;
      private string AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome ;
      private string AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ;
      private string lV50Core_municipiowwds_1_filterfulltext ;
      private string lV53Core_municipiowwds_4_tfmunicipionome ;
      private string lV55Core_municipiowwds_6_tfmunicipiomicronome ;
      private string lV57Core_municipiowwds_8_tfmunicipiomicromesonome ;
      private string lV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla ;
      private string lV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome ;
      private string A36MunicipioNome ;
      private string A38MunicipioMicroNome ;
      private string A40MunicipioMicroMesoNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private IGxSession AV20Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005Q2_A35MunicipioID ;
      private string[] P005Q2_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P005Q2_n47MunicipioMicroMesoUFRegNome ;
      private string[] P005Q2_A42MunicipioMicroMesoUFSigla ;
      private bool[] P005Q2_n42MunicipioMicroMesoUFSigla ;
      private string[] P005Q2_A40MunicipioMicroMesoNome ;
      private bool[] P005Q2_n40MunicipioMicroMesoNome ;
      private string[] P005Q2_A38MunicipioMicroNome ;
      private string[] P005Q2_A36MunicipioNome ;
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

   public class municipiowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Q2( IGxContext context ,
                                             string AV50Core_municipiowwds_1_filterfulltext ,
                                             int AV51Core_municipiowwds_2_tfmunicipioid ,
                                             int AV52Core_municipiowwds_3_tfmunicipioid_to ,
                                             string AV54Core_municipiowwds_5_tfmunicipionome_sel ,
                                             string AV53Core_municipiowwds_4_tfmunicipionome ,
                                             string AV56Core_municipiowwds_7_tfmunicipiomicronome_sel ,
                                             string AV55Core_municipiowwds_6_tfmunicipiomicronome ,
                                             string AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel ,
                                             string AV57Core_municipiowwds_8_tfmunicipiomicromesonome ,
                                             string AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel ,
                                             string AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla ,
                                             string AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel ,
                                             string AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome ,
                                             int A35MunicipioID ,
                                             string A36MunicipioNome ,
                                             string A38MunicipioMicroNome ,
                                             string A40MunicipioMicroMesoNome ,
                                             string A42MunicipioMicroMesoUFSigla ,
                                             string A47MunicipioMicroMesoUFRegNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT MunicipioID, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSigla, MunicipioMicroMesoNome, MunicipioMicroNome, MunicipioNome FROM tbibge_municipio";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_municipiowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MunicipioID,'999999999'), 2) like '%' || :lV50Core_municipiowwds_1_filterfulltext) or ( MunicipioNome like '%' || :lV50Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroNome like '%' || :lV50Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoNome like '%' || :lV50Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFSigla like '%' || :lV50Core_municipiowwds_1_filterfulltext) or ( MunicipioMicroMesoUFRegNome like '%' || :lV50Core_municipiowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV51Core_municipiowwds_2_tfmunicipioid) )
         {
            AddWhere(sWhereString, "(MunicipioID >= :AV51Core_municipiowwds_2_tfmunicipioid)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV52Core_municipiowwds_3_tfmunicipioid_to) )
         {
            AddWhere(sWhereString, "(MunicipioID <= :AV52Core_municipiowwds_3_tfmunicipioid_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_5_tfmunicipionome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_municipiowwds_4_tfmunicipionome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioNome like :lV53Core_municipiowwds_4_tfmunicipionome)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_municipiowwds_5_tfmunicipionome_sel)) && ! ( StringUtil.StrCmp(AV54Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioNome = ( :AV54Core_municipiowwds_5_tfmunicipionome_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_municipiowwds_5_tfmunicipionome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_municipiowwds_6_tfmunicipiomicronome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome like :lV55Core_municipiowwds_6_tfmunicipiomicronome)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_municipiowwds_7_tfmunicipiomicronome_sel)) && ! ( StringUtil.StrCmp(AV56Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroNome = ( :AV56Core_municipiowwds_7_tfmunicipiomicronome_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_municipiowwds_7_tfmunicipiomicronome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_municipiowwds_8_tfmunicipiomicromesonome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome like :lV57Core_municipiowwds_8_tfmunicipiomicromesonome)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel)) && ! ( StringUtil.StrCmp(AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoNome = ( :AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla like :lV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFSigla = ( :AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome like :lV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MunicipioMicroMesoUFRegNome = ( :AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MunicipioMicroMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MunicipioNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MunicipioNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MunicipioID";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MunicipioID DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MunicipioMicroNome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MunicipioMicroNome DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MunicipioMicroMesoNome";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MunicipioMicroMesoNome DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MunicipioMicroMesoUFSigla";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MunicipioMicroMesoUFSigla DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY MunicipioMicroMesoUFRegNome";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY MunicipioMicroMesoUFRegNome DESC";
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
                     return conditional_P005Q2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP005Q2;
          prmP005Q2 = new Object[] {
          new ParDef("lV50Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_municipiowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV51Core_municipiowwds_2_tfmunicipioid",GXType.Int32,9,0) ,
          new ParDef("AV52Core_municipiowwds_3_tfmunicipioid_to",GXType.Int32,9,0) ,
          new ParDef("lV53Core_municipiowwds_4_tfmunicipionome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_municipiowwds_5_tfmunicipionome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_municipiowwds_6_tfmunicipiomicronome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_municipiowwds_7_tfmunicipiomicronome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_municipiowwds_8_tfmunicipiomicromesonome",GXType.VarChar,80,0) ,
          new ParDef("AV58Core_municipiowwds_9_tfmunicipiomicromesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV59Core_municipiowwds_10_tfmunicipiomicromesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV60Core_municipiowwds_11_tfmunicipiomicromesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV61Core_municipiowwds_12_tfmunicipiomicromesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV62Core_municipiowwds_13_tfmunicipiomicromesoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Q2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
