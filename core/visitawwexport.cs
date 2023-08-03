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
   public class visitawwexport : GXProcedure
   {
      public visitawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitawwexport( IGxContext context )
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
         visitawwexport objvisitawwexport;
         objvisitawwexport = new visitawwexport();
         objvisitawwexport.AV12Filename = "" ;
         objvisitawwexport.AV13ErrorMessage = "" ;
         objvisitawwexport.context.SetSubmitInitialConfig(context);
         objvisitawwexport.initialize();
         Submit( executePrivateCatch,objvisitawwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitawwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "VisitaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (Guid.Empty==AV101VisNegID_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = AV101VisNegID_Filtro.ToString();
         }
         if ( ! ( (0==AV102VisNgfSeq_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Number = AV102VisNgfSeq_Filtro;
         }
         if ( ! ( (false==AV111VisDel_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV111VisDel_Filtro);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV110VisSituacao)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int2;
            if ( AV109DynamicFiltersOperatorVisSituacao == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Situação", "Igual", "", "", "", "", "", "", "");
            }
            else if ( AV109DynamicFiltersOperatorVisSituacao == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Situação", "Diferente", "", "", "", "", "", "", "");
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110VisSituacao)) )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GeneXus.Programs.core.gxdomainvisitastatus.getDescription(context,AV110VisSituacao);
            }
         }
         if ( ! ( (DateTime.MinValue==AV58TFVisInsDataHora) && (DateTime.MinValue==AV59TFVisInsDataHora_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído em") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV58TFVisInsDataHora;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV59TFVisInsDataHora_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFVisInsUsuNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído por") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFVisInsUsuNome_Sel)) ? "(Vazio)" : AV63TFVisInsUsuNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFVisInsUsuNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído por") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFVisInsUsuNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV64TFVisData) && (DateTime.MinValue==AV65TFVisData_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Data") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV64TFVisData ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV65TFVisData_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV66TFVisHora) && (DateTime.MinValue==AV67TFVisHora_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Hora") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.localUtil.Format( AV66TFVisHora, "99:99");
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = context.localUtil.Format( AV67TFVisHora_To, "99:99");
         }
         if ( ! ( (DateTime.MinValue==AV68TFVisDataHora) && (DateTime.MinValue==AV69TFVisDataHora_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Data/Hora") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV68TFVisDataHora;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV69TFVisDataHora_To;
         }
         if ( ! ( (DateTime.MinValue==AV103TFVisDataFim) && (DateTime.MinValue==AV104TFVisDataFim_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Data") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV103TFVisDataFim ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV104TFVisDataFim_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV105TFVisHoraFim) && (DateTime.MinValue==AV106TFVisHoraFim_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Hora") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.localUtil.Format( AV105TFVisHoraFim, "99:99");
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = context.localUtil.Format( AV106TFVisHoraFim_To, "99:99");
         }
         if ( ! ( (DateTime.MinValue==AV107TFVisDataHoraFim) && (DateTime.MinValue==AV108TFVisDataHoraFim_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Data/Hora") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV107TFVisDataHoraFim;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV108TFVisDataHoraFim_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFVisTipoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV75TFVisTipoNome_Sel)) ? "(Vazio)" : AV75TFVisTipoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFVisTipoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74TFVisTipoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFVisAssunto_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Assunto") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV81TFVisAssunto_Sel)) ? "(Vazio)" : AV81TFVisAssunto_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFVisAssunto)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Assunto") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80TFVisAssunto, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV99TFVisSituacao_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Situação") ;
            AV14CellRow = GXt_int2;
            AV84i = 1;
            AV112GXV1 = 1;
            while ( AV112GXV1 <= AV99TFVisSituacao_Sels.Count )
            {
               AV100TFVisSituacao_Sel = ((string)AV99TFVisSituacao_Sels.Item(AV112GXV1));
               if ( AV84i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+GeneXus.Programs.core.gxdomainvisitastatus.getDescription(context,AV100TFVisSituacao_Sel);
               AV84i = (long)(AV84i+1);
               AV112GXV1 = (int)(AV112GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFVisLink_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Link de Acesso") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV83TFVisLink_Sel)) ? "(Vazio)" : AV83TFVisLink_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFVisLink)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Link de Acesso") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82TFVisLink, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV51VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV39Session.Get("core.VisitaWWColumnsSelector"), "") != 0 )
         {
            AV46ColumnsSelectorXML = AV39Session.Get("core.VisitaWWColumnsSelector");
            AV43ColumnsSelector.FromXml(AV46ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV43ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV113GXV2 = 1;
         while ( AV113GXV2 <= AV43ColumnsSelector.gxTpr_Columns.Count )
         {
            AV45ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV43ColumnsSelector.gxTpr_Columns.Item(AV113GXV2));
            if ( AV45ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV45ColumnsSelector_Column.gxTpr_Displayname)) ? AV45ColumnsSelector_Column.gxTpr_Columnname : AV45ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Color = 11;
               AV51VisibleColumnCount = (long)(AV51VisibleColumnCount+1);
            }
            AV113GXV2 = (int)(AV113GXV2+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV115Core_visitawwds_1_visnegid_filtro = AV101VisNegID_Filtro;
         AV116Core_visitawwds_2_visngfseq_filtro = AV102VisNgfSeq_Filtro;
         AV117Core_visitawwds_3_visdel_filtro = AV111VisDel_Filtro;
         AV118Core_visitawwds_4_vissituacao = AV110VisSituacao;
         AV119Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV109DynamicFiltersOperatorVisSituacao;
         AV120Core_visitawwds_6_tfvisinsdatahora = AV58TFVisInsDataHora;
         AV121Core_visitawwds_7_tfvisinsdatahora_to = AV59TFVisInsDataHora_To;
         AV122Core_visitawwds_8_tfvisinsusunome = AV62TFVisInsUsuNome;
         AV123Core_visitawwds_9_tfvisinsusunome_sel = AV63TFVisInsUsuNome_Sel;
         AV124Core_visitawwds_10_tfvisdata = AV64TFVisData;
         AV125Core_visitawwds_11_tfvisdata_to = AV65TFVisData_To;
         AV126Core_visitawwds_12_tfvishora = AV66TFVisHora;
         AV127Core_visitawwds_13_tfvishora_to = AV67TFVisHora_To;
         AV128Core_visitawwds_14_tfvisdatahora = AV68TFVisDataHora;
         AV129Core_visitawwds_15_tfvisdatahora_to = AV69TFVisDataHora_To;
         AV130Core_visitawwds_16_tfvisdatafim = AV103TFVisDataFim;
         AV131Core_visitawwds_17_tfvisdatafim_to = AV104TFVisDataFim_To;
         AV132Core_visitawwds_18_tfvishorafim = AV105TFVisHoraFim;
         AV133Core_visitawwds_19_tfvishorafim_to = AV106TFVisHoraFim_To;
         AV134Core_visitawwds_20_tfvisdatahorafim = AV107TFVisDataHoraFim;
         AV135Core_visitawwds_21_tfvisdatahorafim_to = AV108TFVisDataHoraFim_To;
         AV136Core_visitawwds_22_tfvistiponome = AV74TFVisTipoNome;
         AV137Core_visitawwds_23_tfvistiponome_sel = AV75TFVisTipoNome_Sel;
         AV138Core_visitawwds_24_tfvisassunto = AV80TFVisAssunto;
         AV139Core_visitawwds_25_tfvisassunto_sel = AV81TFVisAssunto_Sel;
         AV140Core_visitawwds_26_tfvissituacao_sels = AV99TFVisSituacao_Sels;
         AV141Core_visitawwds_27_tfvislink = AV82TFVisLink;
         AV142Core_visitawwds_28_tfvislink_sel = AV83TFVisLink_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV140Core_visitawwds_26_tfvissituacao_sels ,
                                              AV119Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV118Core_visitawwds_4_vissituacao ,
                                              AV120Core_visitawwds_6_tfvisinsdatahora ,
                                              AV121Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV123Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV122Core_visitawwds_8_tfvisinsusunome ,
                                              AV124Core_visitawwds_10_tfvisdata ,
                                              AV125Core_visitawwds_11_tfvisdata_to ,
                                              AV126Core_visitawwds_12_tfvishora ,
                                              AV127Core_visitawwds_13_tfvishora_to ,
                                              AV128Core_visitawwds_14_tfvisdatahora ,
                                              AV129Core_visitawwds_15_tfvisdatahora_to ,
                                              AV130Core_visitawwds_16_tfvisdatafim ,
                                              AV131Core_visitawwds_17_tfvisdatafim_to ,
                                              AV132Core_visitawwds_18_tfvishorafim ,
                                              AV133Core_visitawwds_19_tfvishorafim_to ,
                                              AV134Core_visitawwds_20_tfvisdatahorafim ,
                                              AV135Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV137Core_visitawwds_23_tfvistiponome_sel ,
                                              AV136Core_visitawwds_22_tfvistiponome ,
                                              AV139Core_visitawwds_25_tfvisassunto_sel ,
                                              AV138Core_visitawwds_24_tfvisassunto ,
                                              AV140Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV142Core_visitawwds_28_tfvislink_sel ,
                                              AV141Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A487VisDel ,
                                              AV95VisNegID ,
                                              AV96VisNgfSeq ,
                                              A418VisNegID ,
                                              A422VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV122Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV122Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV136Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV136Core_visitawwds_22_tfvistiponome), "%", "");
         lV138Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV138Core_visitawwds_24_tfvisassunto), "%", "");
         lV141Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV141Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor P006D2 */
         pr_default.execute(0, new Object[] {AV95VisNegID, AV96VisNgfSeq, AV118Core_visitawwds_4_vissituacao, AV118Core_visitawwds_4_vissituacao, AV120Core_visitawwds_6_tfvisinsdatahora, AV121Core_visitawwds_7_tfvisinsdatahora_to, lV122Core_visitawwds_8_tfvisinsusunome, AV123Core_visitawwds_9_tfvisinsusunome_sel, AV124Core_visitawwds_10_tfvisdata, AV125Core_visitawwds_11_tfvisdata_to, AV126Core_visitawwds_12_tfvishora, AV127Core_visitawwds_13_tfvishora_to, AV128Core_visitawwds_14_tfvisdatahora, AV129Core_visitawwds_15_tfvisdatahora_to, AV130Core_visitawwds_16_tfvisdatafim, AV131Core_visitawwds_17_tfvisdatafim_to, AV132Core_visitawwds_18_tfvishorafim, AV133Core_visitawwds_19_tfvishorafim_to, AV134Core_visitawwds_20_tfvisdatahorafim, AV135Core_visitawwds_21_tfvisdatahorafim_to, lV136Core_visitawwds_22_tfvistiponome, AV137Core_visitawwds_23_tfvistiponome_sel, lV138Core_visitawwds_24_tfvisassunto, AV139Core_visitawwds_25_tfvisassunto_sel, lV141Core_visitawwds_27_tfvislink, AV142Core_visitawwds_28_tfvislink_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A414VisTipoID = P006D2_A414VisTipoID[0];
            A417VisLink = P006D2_A417VisLink[0];
            n417VisLink = P006D2_n417VisLink[0];
            A409VisAssunto = P006D2_A409VisAssunto[0];
            A416VisTipoNome = P006D2_A416VisTipoNome[0];
            A477VisDataHoraFim = P006D2_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P006D2_n477VisDataHoraFim[0];
            A476VisHoraFim = P006D2_A476VisHoraFim[0];
            n476VisHoraFim = P006D2_n476VisHoraFim[0];
            A475VisDataFim = P006D2_A475VisDataFim[0];
            n475VisDataFim = P006D2_n475VisDataFim[0];
            A406VisDataHora = P006D2_A406VisDataHora[0];
            A405VisHora = P006D2_A405VisHora[0];
            A404VisData = P006D2_A404VisData[0];
            A403VisInsUsuNome = P006D2_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P006D2_n403VisInsUsuNome[0];
            A401VisInsDataHora = P006D2_A401VisInsDataHora[0];
            A472VisSituacao = P006D2_A472VisSituacao[0];
            A487VisDel = P006D2_A487VisDel[0];
            A422VisNgfSeq = P006D2_A422VisNgfSeq[0];
            n422VisNgfSeq = P006D2_n422VisNgfSeq[0];
            A418VisNegID = P006D2_A418VisNegID[0];
            n418VisNegID = P006D2_n418VisNegID[0];
            A398VisID = P006D2_A398VisID[0];
            A416VisTipoNome = P006D2_A416VisTipoNome[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV51VisibleColumnCount = 0;
            AV143GXV3 = 1;
            while ( AV143GXV3 <= AV43ColumnsSelector.gxTpr_Columns.Count )
            {
               AV45ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV43ColumnsSelector.gxTpr_Columns.Item(AV143GXV3));
               if ( AV45ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisInsDataHora") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Date = A401VisInsDataHora;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisInsUsuNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A403VisInsUsuNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisData") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A404VisData ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisHora") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.localUtil.Format( A405VisHora, "99:99");
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisDataHora") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Date = A406VisDataHora;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisDataFim") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A475VisDataFim ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisHoraFim") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = context.localUtil.Format( A476VisHoraFim, "99:99");
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisDataHoraFim") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Date = A477VisDataHoraFim;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisTipoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A416VisTipoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisAssunto") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A409VisAssunto, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisSituacao") == 0 )
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A472VisSituacao)) )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GeneXus.Programs.core.gxdomainvisitastatus.getDescription(context,A472VisSituacao);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV45ColumnsSelector_Column.gxTpr_Columnname, "VisLink") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A417VisLink, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV51VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV51VisibleColumnCount = (long)(AV51VisibleColumnCount+1);
               }
               AV143GXV3 = (int)(AV143GXV3+1);
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
         AV39Session.Set("WWPExportFilePath", AV12Filename);
         AV39Session.Set("WWPExportFileName", "VisitaWWExport.xlsx");
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
         AV43ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisInsDataHora",  "",  "Incluído em",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisInsUsuNome",  "",  "Incluído por",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisData",  "Início",  "Data",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisHora",  "Início",  "Hora",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisDataHora",  "Início",  "Data/Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisDataFim",  "Término",  "Data",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisHoraFim",  "Término",  "Hora",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisDataHoraFim",  "Término",  "Data/Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisTipoNome",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisAssunto",  "",  "Assunto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisSituacao",  "",  "Situação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV43ColumnsSelector,  "VisLink",  "",  "Link de Acesso",  true,  "") ;
         GXt_char1 = AV47UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.VisitaWWColumnsSelector", out  GXt_char1) ;
         AV47UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47UserCustomValue)) ) )
         {
            AV44ColumnsSelectorAux.FromXml(AV47UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV44ColumnsSelectorAux, ref  AV43ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("core.VisitaWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.VisitaWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("core.VisitaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV144GXV4 = 1;
         while ( AV144GXV4 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV144GXV4));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "VISNEGID_FILTRO") == 0 )
            {
               AV101VisNegID_Filtro = StringUtil.StrToGuid( AV42GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "VISNGFSEQ_FILTRO") == 0 )
            {
               AV102VisNgfSeq_Filtro = (int)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "VISDEL_FILTRO") == 0 )
            {
               AV111VisDel_Filtro = BooleanUtil.Val( AV42GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "VISSITUACAO") == 0 )
            {
               AV110VisSituacao = AV42GridStateFilterValue.gxTpr_Value;
               AV109DynamicFiltersOperatorVisSituacao = AV42GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISINSDATAHORA") == 0 )
            {
               AV58TFVisInsDataHora = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV59TFVisInsDataHora_To = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME") == 0 )
            {
               AV62TFVisInsUsuNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME_SEL") == 0 )
            {
               AV63TFVisInsUsuNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISDATA") == 0 )
            {
               AV64TFVisData = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV65TFVisData_To = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISHORA") == 0 )
            {
               AV66TFVisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, 2));
               AV67TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISDATAHORA") == 0 )
            {
               AV68TFVisDataHora = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV69TFVisDataHora_To = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISDATAFIM") == 0 )
            {
               AV103TFVisDataFim = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV104TFVisDataFim_To = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISHORAFIM") == 0 )
            {
               AV105TFVisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, 2));
               AV106TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISDATAHORAFIM") == 0 )
            {
               AV107TFVisDataHoraFim = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV108TFVisDataHoraFim_To = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME") == 0 )
            {
               AV74TFVisTipoNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME_SEL") == 0 )
            {
               AV75TFVisTipoNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO") == 0 )
            {
               AV80TFVisAssunto = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO_SEL") == 0 )
            {
               AV81TFVisAssunto_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISSITUACAO_SEL") == 0 )
            {
               AV98TFVisSituacao_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV99TFVisSituacao_Sels.FromJSonString(AV98TFVisSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISLINK") == 0 )
            {
               AV82TFVisLink = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFVISLINK_SEL") == 0 )
            {
               AV83TFVisLink_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "PARM_&VISNEGID") == 0 )
            {
               AV95VisNegID = StringUtil.StrToGuid( AV42GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "PARM_&VISNGFSEQ") == 0 )
            {
               AV96VisNgfSeq = (int)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV144GXV4 = (int)(AV144GXV4+1);
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
         AV101VisNegID_Filtro = Guid.Empty;
         AV110VisSituacao = "PEN";
         AV58TFVisInsDataHora = (DateTime)(DateTime.MinValue);
         AV59TFVisInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV63TFVisInsUsuNome_Sel = "";
         AV62TFVisInsUsuNome = "";
         AV64TFVisData = DateTime.MinValue;
         AV65TFVisData_To = DateTime.MinValue;
         AV66TFVisHora = (DateTime)(DateTime.MinValue);
         AV67TFVisHora_To = (DateTime)(DateTime.MinValue);
         AV68TFVisDataHora = (DateTime)(DateTime.MinValue);
         AV69TFVisDataHora_To = (DateTime)(DateTime.MinValue);
         AV103TFVisDataFim = DateTime.MinValue;
         AV104TFVisDataFim_To = DateTime.MinValue;
         AV105TFVisHoraFim = (DateTime)(DateTime.MinValue);
         AV106TFVisHoraFim_To = (DateTime)(DateTime.MinValue);
         AV107TFVisDataHoraFim = (DateTime)(DateTime.MinValue);
         AV108TFVisDataHoraFim_To = (DateTime)(DateTime.MinValue);
         AV75TFVisTipoNome_Sel = "";
         AV74TFVisTipoNome = "";
         AV81TFVisAssunto_Sel = "";
         AV80TFVisAssunto = "";
         AV99TFVisSituacao_Sels = new GxSimpleCollection<string>();
         AV100TFVisSituacao_Sel = "PEN";
         AV83TFVisLink_Sel = "";
         AV82TFVisLink = "";
         AV39Session = context.GetSession();
         AV46ColumnsSelectorXML = "";
         AV43ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV45ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV115Core_visitawwds_1_visnegid_filtro = Guid.Empty;
         AV118Core_visitawwds_4_vissituacao = "";
         AV120Core_visitawwds_6_tfvisinsdatahora = (DateTime)(DateTime.MinValue);
         AV121Core_visitawwds_7_tfvisinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV122Core_visitawwds_8_tfvisinsusunome = "";
         AV123Core_visitawwds_9_tfvisinsusunome_sel = "";
         AV124Core_visitawwds_10_tfvisdata = DateTime.MinValue;
         AV125Core_visitawwds_11_tfvisdata_to = DateTime.MinValue;
         AV126Core_visitawwds_12_tfvishora = (DateTime)(DateTime.MinValue);
         AV127Core_visitawwds_13_tfvishora_to = (DateTime)(DateTime.MinValue);
         AV128Core_visitawwds_14_tfvisdatahora = (DateTime)(DateTime.MinValue);
         AV129Core_visitawwds_15_tfvisdatahora_to = (DateTime)(DateTime.MinValue);
         AV130Core_visitawwds_16_tfvisdatafim = DateTime.MinValue;
         AV131Core_visitawwds_17_tfvisdatafim_to = DateTime.MinValue;
         AV132Core_visitawwds_18_tfvishorafim = (DateTime)(DateTime.MinValue);
         AV133Core_visitawwds_19_tfvishorafim_to = (DateTime)(DateTime.MinValue);
         AV134Core_visitawwds_20_tfvisdatahorafim = (DateTime)(DateTime.MinValue);
         AV135Core_visitawwds_21_tfvisdatahorafim_to = (DateTime)(DateTime.MinValue);
         AV136Core_visitawwds_22_tfvistiponome = "";
         AV137Core_visitawwds_23_tfvistiponome_sel = "";
         AV138Core_visitawwds_24_tfvisassunto = "";
         AV139Core_visitawwds_25_tfvisassunto_sel = "";
         AV140Core_visitawwds_26_tfvissituacao_sels = new GxSimpleCollection<string>();
         AV141Core_visitawwds_27_tfvislink = "";
         AV142Core_visitawwds_28_tfvislink_sel = "";
         scmdbuf = "";
         lV122Core_visitawwds_8_tfvisinsusunome = "";
         lV136Core_visitawwds_22_tfvistiponome = "";
         lV138Core_visitawwds_24_tfvisassunto = "";
         lV141Core_visitawwds_27_tfvislink = "";
         A472VisSituacao = "";
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A403VisInsUsuNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A416VisTipoNome = "";
         A409VisAssunto = "";
         A417VisLink = "";
         AV95VisNegID = Guid.Empty;
         A418VisNegID = Guid.Empty;
         P006D2_A414VisTipoID = new int[1] ;
         P006D2_A417VisLink = new string[] {""} ;
         P006D2_n417VisLink = new bool[] {false} ;
         P006D2_A409VisAssunto = new string[] {""} ;
         P006D2_A416VisTipoNome = new string[] {""} ;
         P006D2_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006D2_n477VisDataHoraFim = new bool[] {false} ;
         P006D2_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006D2_n476VisHoraFim = new bool[] {false} ;
         P006D2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P006D2_n475VisDataFim = new bool[] {false} ;
         P006D2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P006D2_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P006D2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P006D2_A403VisInsUsuNome = new string[] {""} ;
         P006D2_n403VisInsUsuNome = new bool[] {false} ;
         P006D2_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006D2_A472VisSituacao = new string[] {""} ;
         P006D2_A487VisDel = new bool[] {false} ;
         P006D2_A422VisNgfSeq = new int[1] ;
         P006D2_n422VisNgfSeq = new bool[] {false} ;
         P006D2_A418VisNegID = new Guid[] {Guid.Empty} ;
         P006D2_n418VisNegID = new bool[] {false} ;
         P006D2_A398VisID = new Guid[] {Guid.Empty} ;
         A398VisID = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV47UserCustomValue = "";
         GXt_char1 = "";
         AV44ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV98TFVisSituacao_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitawwexport__default(),
            new Object[][] {
                new Object[] {
               P006D2_A414VisTipoID, P006D2_A417VisLink, P006D2_n417VisLink, P006D2_A409VisAssunto, P006D2_A416VisTipoNome, P006D2_A477VisDataHoraFim, P006D2_n477VisDataHoraFim, P006D2_A476VisHoraFim, P006D2_n476VisHoraFim, P006D2_A475VisDataFim,
               P006D2_n475VisDataFim, P006D2_A406VisDataHora, P006D2_A405VisHora, P006D2_A404VisData, P006D2_A403VisInsUsuNome, P006D2_n403VisInsUsuNome, P006D2_A401VisInsDataHora, P006D2_A472VisSituacao, P006D2_A487VisDel, P006D2_A422VisNgfSeq,
               P006D2_n422VisNgfSeq, P006D2_A418VisNegID, P006D2_n418VisNegID, P006D2_A398VisID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV109DynamicFiltersOperatorVisSituacao ;
      private short GXt_int2 ;
      private short AV119Core_visitawwds_5_dynamicfiltersoperatorvissituacao ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV102VisNgfSeq_Filtro ;
      private int AV112GXV1 ;
      private int AV113GXV2 ;
      private int AV116Core_visitawwds_2_visngfseq_filtro ;
      private int AV140Core_visitawwds_26_tfvissituacao_sels_Count ;
      private int AV96VisNgfSeq ;
      private int A422VisNgfSeq ;
      private int A414VisTipoID ;
      private int AV143GXV3 ;
      private int AV144GXV4 ;
      private long AV84i ;
      private long AV51VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime AV58TFVisInsDataHora ;
      private DateTime AV59TFVisInsDataHora_To ;
      private DateTime AV66TFVisHora ;
      private DateTime AV67TFVisHora_To ;
      private DateTime AV68TFVisDataHora ;
      private DateTime AV69TFVisDataHora_To ;
      private DateTime AV105TFVisHoraFim ;
      private DateTime AV106TFVisHoraFim_To ;
      private DateTime AV107TFVisDataHoraFim ;
      private DateTime AV108TFVisDataHoraFim_To ;
      private DateTime AV120Core_visitawwds_6_tfvisinsdatahora ;
      private DateTime AV121Core_visitawwds_7_tfvisinsdatahora_to ;
      private DateTime AV126Core_visitawwds_12_tfvishora ;
      private DateTime AV127Core_visitawwds_13_tfvishora_to ;
      private DateTime AV128Core_visitawwds_14_tfvisdatahora ;
      private DateTime AV129Core_visitawwds_15_tfvisdatahora_to ;
      private DateTime AV132Core_visitawwds_18_tfvishorafim ;
      private DateTime AV133Core_visitawwds_19_tfvishorafim_to ;
      private DateTime AV134Core_visitawwds_20_tfvisdatahorafim ;
      private DateTime AV135Core_visitawwds_21_tfvisdatahorafim_to ;
      private DateTime A401VisInsDataHora ;
      private DateTime A405VisHora ;
      private DateTime A406VisDataHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime GXt_dtime3 ;
      private DateTime AV64TFVisData ;
      private DateTime AV65TFVisData_To ;
      private DateTime AV103TFVisDataFim ;
      private DateTime AV104TFVisDataFim_To ;
      private DateTime AV124Core_visitawwds_10_tfvisdata ;
      private DateTime AV125Core_visitawwds_11_tfvisdata_to ;
      private DateTime AV130Core_visitawwds_16_tfvisdatafim ;
      private DateTime AV131Core_visitawwds_17_tfvisdatafim_to ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private bool returnInSub ;
      private bool AV111VisDel_Filtro ;
      private bool AV117Core_visitawwds_3_visdel_filtro ;
      private bool AV18OrderedDsc ;
      private bool A487VisDel ;
      private bool n417VisLink ;
      private bool n477VisDataHoraFim ;
      private bool n476VisHoraFim ;
      private bool n475VisDataFim ;
      private bool n403VisInsUsuNome ;
      private bool n422VisNgfSeq ;
      private bool n418VisNegID ;
      private string AV46ColumnsSelectorXML ;
      private string AV47UserCustomValue ;
      private string AV98TFVisSituacao_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV110VisSituacao ;
      private string AV63TFVisInsUsuNome_Sel ;
      private string AV62TFVisInsUsuNome ;
      private string AV75TFVisTipoNome_Sel ;
      private string AV74TFVisTipoNome ;
      private string AV81TFVisAssunto_Sel ;
      private string AV80TFVisAssunto ;
      private string AV100TFVisSituacao_Sel ;
      private string AV83TFVisLink_Sel ;
      private string AV82TFVisLink ;
      private string AV118Core_visitawwds_4_vissituacao ;
      private string AV122Core_visitawwds_8_tfvisinsusunome ;
      private string AV123Core_visitawwds_9_tfvisinsusunome_sel ;
      private string AV136Core_visitawwds_22_tfvistiponome ;
      private string AV137Core_visitawwds_23_tfvistiponome_sel ;
      private string AV138Core_visitawwds_24_tfvisassunto ;
      private string AV139Core_visitawwds_25_tfvisassunto_sel ;
      private string AV141Core_visitawwds_27_tfvislink ;
      private string AV142Core_visitawwds_28_tfvislink_sel ;
      private string lV122Core_visitawwds_8_tfvisinsusunome ;
      private string lV136Core_visitawwds_22_tfvistiponome ;
      private string lV138Core_visitawwds_24_tfvisassunto ;
      private string lV141Core_visitawwds_27_tfvislink ;
      private string A472VisSituacao ;
      private string A403VisInsUsuNome ;
      private string A416VisTipoNome ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private Guid AV101VisNegID_Filtro ;
      private Guid AV115Core_visitawwds_1_visnegid_filtro ;
      private Guid AV95VisNegID ;
      private Guid A418VisNegID ;
      private Guid A398VisID ;
      private IGxSession AV39Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006D2_A414VisTipoID ;
      private string[] P006D2_A417VisLink ;
      private bool[] P006D2_n417VisLink ;
      private string[] P006D2_A409VisAssunto ;
      private string[] P006D2_A416VisTipoNome ;
      private DateTime[] P006D2_A477VisDataHoraFim ;
      private bool[] P006D2_n477VisDataHoraFim ;
      private DateTime[] P006D2_A476VisHoraFim ;
      private bool[] P006D2_n476VisHoraFim ;
      private DateTime[] P006D2_A475VisDataFim ;
      private bool[] P006D2_n475VisDataFim ;
      private DateTime[] P006D2_A406VisDataHora ;
      private DateTime[] P006D2_A405VisHora ;
      private DateTime[] P006D2_A404VisData ;
      private string[] P006D2_A403VisInsUsuNome ;
      private bool[] P006D2_n403VisInsUsuNome ;
      private DateTime[] P006D2_A401VisInsDataHora ;
      private string[] P006D2_A472VisSituacao ;
      private bool[] P006D2_A487VisDel ;
      private int[] P006D2_A422VisNgfSeq ;
      private bool[] P006D2_n422VisNgfSeq ;
      private Guid[] P006D2_A418VisNegID ;
      private bool[] P006D2_n418VisNegID ;
      private Guid[] P006D2_A398VisID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GxSimpleCollection<string> AV99TFVisSituacao_Sels ;
      private GxSimpleCollection<string> AV140Core_visitawwds_26_tfvissituacao_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV43ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV44ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV45ColumnsSelector_Column ;
   }

   public class visitawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006D2( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV140Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV119Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV118Core_visitawwds_4_vissituacao ,
                                             DateTime AV120Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV121Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV123Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV122Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV124Core_visitawwds_10_tfvisdata ,
                                             DateTime AV125Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV126Core_visitawwds_12_tfvishora ,
                                             DateTime AV127Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV128Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV129Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV130Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV131Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV132Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV133Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV134Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV135Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV137Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV136Core_visitawwds_22_tfvistiponome ,
                                             string AV139Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV138Core_visitawwds_24_tfvisassunto ,
                                             int AV140Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV142Core_visitawwds_28_tfvislink_sel ,
                                             string AV141Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A487VisDel ,
                                             Guid AV95VisNegID ,
                                             int AV96VisNgfSeq ,
                                             Guid A418VisNegID ,
                                             int A422VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[26];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.VisTipoID AS VisTipoID, T1.VisLink, T1.VisAssunto, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsUsuNome, T1.VisInsDataHora, T1.VisSituacao, T1.VisDel, T1.VisNgfSeq, T1.VisNegID, T1.VisID FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(T1.VisNegID = :AV95VisNegID and T1.VisNgfSeq = :AV96VisNgfSeq)");
         AddWhere(sWhereString, "(Not T1.VisDel)");
         if ( ( AV119Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV118Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( AV119Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV118Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV120Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV120Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV121Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV122Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV123Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV123Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV123Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV124Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV124Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV125Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV125Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV126Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV126Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV127Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV127Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV128Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV128Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV129Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV129Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV130Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV131Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV131Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV132Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV132Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV133Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV133Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV134Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV134Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV135Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV135Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV136Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV137Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV137Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV137Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV138Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV139Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV139Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV139Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV140Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV140Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV142Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV141Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV142Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV142Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV142Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.VisNegID, T1.VisDataHora";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisInsDataHora";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisInsDataHora DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisInsUsuNome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisInsUsuNome DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisData";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisData DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisHora";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisHora DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisDataHora";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisDataHora DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisDataFim";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisDataFim DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisHoraFim";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisHoraFim DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisDataHoraFim";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisDataHoraFim DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.VitNome";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.VitNome DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisAssunto";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisAssunto DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisSituacao";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisSituacao DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisLink";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisLink DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006D2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (bool)dynConstraints[40] , (Guid)dynConstraints[41] , (int)dynConstraints[42] , (Guid)dynConstraints[43] , (int)dynConstraints[44] );
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
          Object[] prmP006D2;
          prmP006D2 = new Object[] {
          new ParDef("AV95VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV96VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV118Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV118Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV120Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV121Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV122Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV123Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV124Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV125Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV126Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV127Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV128Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV129Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV130Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV131Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV132Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV133Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV134Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV135Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV136Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV137Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV138Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV139Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV141Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV142Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((bool[]) buf[18])[0] = rslt.getBool(14);
                ((int[]) buf[19])[0] = rslt.getInt(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((Guid[]) buf[21])[0] = rslt.getGuid(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((Guid[]) buf[23])[0] = rslt.getGuid(17);
                return;
       }
    }

 }

}
