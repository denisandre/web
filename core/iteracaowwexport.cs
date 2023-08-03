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
   public class iteracaowwexport : GXProcedure
   {
      public iteracaowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public iteracaowwexport( IGxContext context )
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
         iteracaowwexport objiteracaowwexport;
         objiteracaowwexport = new iteracaowwexport();
         objiteracaowwexport.AV12Filename = "" ;
         objiteracaowwexport.AV13ErrorMessage = "" ;
         objiteracaowwexport.context.SetSubmitInitialConfig(context);
         objiteracaowwexport.initialize();
         Submit( executePrivateCatch,objiteracaowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((iteracaowwexport)stateInfo).executePrivate();
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
         S191 ();
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
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
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
         AV12Filename = GXt_char1 + "IteracaoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV47TFIteOrdem) && (0==AV48TFIteOrdem_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ordem de Execução") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFIteOrdem;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFIteOrdem_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIteNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIteNome_Sel)) ? "(Vazio)" : AV50TFIteNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIteNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFIteNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Ordem de Execução";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Descrição";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Core_iteracaowwds_1_filterfulltext = AV19FilterFullText;
         AV55Core_iteracaowwds_2_tfiteordem = AV47TFIteOrdem;
         AV56Core_iteracaowwds_3_tfiteordem_to = AV48TFIteOrdem_To;
         AV57Core_iteracaowwds_4_tfitenome = AV49TFIteNome;
         AV58Core_iteracaowwds_5_tfitenome_sel = AV50TFIteNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Core_iteracaowwds_1_filterfulltext ,
                                              AV55Core_iteracaowwds_2_tfiteordem ,
                                              AV56Core_iteracaowwds_3_tfiteordem_to ,
                                              AV58Core_iteracaowwds_5_tfitenome_sel ,
                                              AV57Core_iteracaowwds_4_tfitenome ,
                                              A382IteOrdem ,
                                              A383IteNome ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Core_iteracaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_iteracaowwds_1_filterfulltext), "%", "");
         lV54Core_iteracaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_iteracaowwds_1_filterfulltext), "%", "");
         lV57Core_iteracaowwds_4_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV57Core_iteracaowwds_4_tfitenome), "%", "");
         /* Using cursor P00592 */
         pr_default.execute(0, new Object[] {lV54Core_iteracaowwds_1_filterfulltext, lV54Core_iteracaowwds_1_filterfulltext, AV55Core_iteracaowwds_2_tfiteordem, AV56Core_iteracaowwds_3_tfiteordem_to, lV57Core_iteracaowwds_4_tfitenome, AV58Core_iteracaowwds_5_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A382IteOrdem = P00592_A382IteOrdem[0];
            A383IteNome = P00592_A383IteNome[0];
            A381IteID = P00592_A381IteID[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Number = A382IteOrdem;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A383IteNome, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
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

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "IteracaoWWExport.xlsx");
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

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("core.IteracaoWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.IteracaoWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.IteracaoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFITEORDEM") == 0 )
            {
               AV47TFIteOrdem = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFIteOrdem_To = (int)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV49TFIteNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV50TFIteNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
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
         AV50TFIteNome_Sel = "";
         AV49TFIteNome = "";
         AV54Core_iteracaowwds_1_filterfulltext = "";
         AV57Core_iteracaowwds_4_tfitenome = "";
         AV58Core_iteracaowwds_5_tfitenome_sel = "";
         scmdbuf = "";
         lV54Core_iteracaowwds_1_filterfulltext = "";
         lV57Core_iteracaowwds_4_tfitenome = "";
         A383IteNome = "";
         P00592_A382IteOrdem = new int[1] ;
         P00592_A383IteNome = new string[] {""} ;
         P00592_A381IteID = new Guid[] {Guid.Empty} ;
         A381IteID = Guid.Empty;
         GXt_char1 = "";
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.iteracaowwexport__default(),
            new Object[][] {
                new Object[] {
               P00592_A382IteOrdem, P00592_A383IteNome, P00592_A381IteID
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
      private int AV47TFIteOrdem ;
      private int AV48TFIteOrdem_To ;
      private int AV55Core_iteracaowwds_2_tfiteordem ;
      private int AV56Core_iteracaowwds_3_tfiteordem_to ;
      private int A382IteOrdem ;
      private int AV59GXV1 ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV50TFIteNome_Sel ;
      private string AV49TFIteNome ;
      private string AV54Core_iteracaowwds_1_filterfulltext ;
      private string AV57Core_iteracaowwds_4_tfitenome ;
      private string AV58Core_iteracaowwds_5_tfitenome_sel ;
      private string lV54Core_iteracaowwds_1_filterfulltext ;
      private string lV57Core_iteracaowwds_4_tfitenome ;
      private string A383IteNome ;
      private Guid A381IteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00592_A382IteOrdem ;
      private string[] P00592_A383IteNome ;
      private Guid[] P00592_A381IteID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
   }

   public class iteracaowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00592( IGxContext context ,
                                             string AV54Core_iteracaowwds_1_filterfulltext ,
                                             int AV55Core_iteracaowwds_2_tfiteordem ,
                                             int AV56Core_iteracaowwds_3_tfiteordem_to ,
                                             string AV58Core_iteracaowwds_5_tfitenome_sel ,
                                             string AV57Core_iteracaowwds_4_tfitenome ,
                                             int A382IteOrdem ,
                                             string A383IteNome ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT IteOrdem, IteNome, IteID FROM tb_Iteracao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_iteracaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(IteOrdem,'99999999'), 2) like '%' || :lV54Core_iteracaowwds_1_filterfulltext) or ( IteNome like '%' || :lV54Core_iteracaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV55Core_iteracaowwds_2_tfiteordem) )
         {
            AddWhere(sWhereString, "(IteOrdem >= :AV55Core_iteracaowwds_2_tfiteordem)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV56Core_iteracaowwds_3_tfiteordem_to) )
         {
            AddWhere(sWhereString, "(IteOrdem <= :AV56Core_iteracaowwds_3_tfiteordem_to)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_iteracaowwds_5_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_iteracaowwds_4_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV57Core_iteracaowwds_4_tfitenome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_iteracaowwds_5_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV58Core_iteracaowwds_5_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV58Core_iteracaowwds_5_tfitenome_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_iteracaowwds_5_tfitenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IteNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY IteOrdem DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY IteNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY IteNome DESC";
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
                     return conditional_P00592(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
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
          Object[] prmP00592;
          prmP00592 = new Object[] {
          new ParDef("lV54Core_iteracaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Core_iteracaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Core_iteracaowwds_2_tfiteordem",GXType.Int32,8,0) ,
          new ParDef("AV56Core_iteracaowwds_3_tfiteordem_to",GXType.Int32,8,0) ,
          new ParDef("lV57Core_iteracaowwds_4_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV58Core_iteracaowwds_5_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00592", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00592,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
