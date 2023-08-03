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
   public class documentoarquivowwexport : GXProcedure
   {
      public documentoarquivowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoarquivowwexport( IGxContext context )
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
         documentoarquivowwexport objdocumentoarquivowwexport;
         objdocumentoarquivowwexport = new documentoarquivowwexport();
         objdocumentoarquivowwexport.AV12Filename = "" ;
         objdocumentoarquivowwexport.AV13ErrorMessage = "" ;
         objdocumentoarquivowwexport.context.SetSubmitInitialConfig(context);
         objdocumentoarquivowwexport.initialize();
         Submit( executePrivateCatch,objdocumentoarquivowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentoarquivowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "DocumentoArquivoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (Guid.Empty==AV88DocID_Filtro) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = AV88DocID_Filtro.ToString();
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
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "DOCARQINSDATA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV23DocArqInsData1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
               AV24DocArqInsData_To1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
               AV22PrintFilterValue = false;
               if ( ! (DateTime.MinValue==AV23DocArqInsData1) || ! (DateTime.MinValue==AV24DocArqInsData_To1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Passado";
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Hoje";
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "No futuro";
                  }
                  else if ( AV21DynamicFiltersOperator1 == 3 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Incluído em", "Período", "", "", "", "", "", "", "");
                     AV22PrintFilterValue = true;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                  }
                  if ( AV22PrintFilterValue )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_dtime3 = DateTimeUtil.ResetTime( AV23DocArqInsData1 ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( AV24DocArqInsData_To1 ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
                     }
                  }
               }
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV25DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV26DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "DOCARQINSDATA") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28DocArqInsData2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
                  AV29DocArqInsData_To2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
                  AV22PrintFilterValue = false;
                  if ( ! (DateTime.MinValue==AV28DocArqInsData2) || ! (DateTime.MinValue==AV29DocArqInsData_To2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Passado";
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Hoje";
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "No futuro";
                     }
                     else if ( AV27DynamicFiltersOperator2 == 3 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Incluído em", "Período", "", "", "", "", "", "", "");
                        AV22PrintFilterValue = true;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                     }
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( AV28DocArqInsData2 ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                           GXt_dtime3 = DateTimeUtil.ResetTime( AV29DocArqInsData_To2 ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
                        }
                     }
                  }
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV30DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV31DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "DOCARQINSDATA") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33DocArqInsData3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
                     AV34DocArqInsData_To3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
                     AV22PrintFilterValue = false;
                     if ( ! (DateTime.MinValue==AV33DocArqInsData3) || ! (DateTime.MinValue==AV34DocArqInsData_To3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Passado";
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Hoje";
                        }
                        else if ( AV32DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Incluído em";
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "No futuro";
                        }
                        else if ( AV32DynamicFiltersOperator3 == 3 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Incluído em", "Período", "", "", "", "", "", "", "");
                           AV22PrintFilterValue = true;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                        }
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           GXt_dtime3 = DateTimeUtil.ResetTime( AV33DocArqInsData3 ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
                           if ( AV22PrintFilterValue )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                              GXt_dtime3 = DateTimeUtil.ResetTime( AV34DocArqInsData_To3 ) ;
                              AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
                           }
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFDocArqConteudoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome do Arquivo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV81TFDocArqConteudoNome_Sel)) ? "(Vazio)" : AV81TFDocArqConteudoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFDocArqConteudoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome do Arquivo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80TFDocArqConteudoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFDocArqConteudoExtensao_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Extensão") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV83TFDocArqConteudoExtensao_Sel)) ? "(Vazio)" : AV83TFDocArqConteudoExtensao_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFDocArqConteudoExtensao)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Extensão") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82TFDocArqConteudoExtensao, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV59TFDocArqInsDataHora) && (DateTime.MinValue==AV60TFDocArqInsDataHora_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído em") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV59TFDocArqInsDataHora;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV60TFDocArqInsDataHora_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFDocArqObservacao_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Observações") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV85TFDocArqObservacao_Sel)) ? "(Vazio)" : AV85TFDocArqObservacao_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV84TFDocArqObservacao)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Observações") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84TFDocArqObservacao, out  GXt_char1) ;
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
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Nome do Arquivo";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Extensão";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = "Incluído em";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "Observações";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV90Core_documentoarquivowwds_1_docid_filtro = AV88DocID_Filtro;
         AV91Core_documentoarquivowwds_2_filterfulltext = AV19FilterFullText;
         AV92Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV94Core_documentoarquivowwds_5_docarqinsdata1 = AV23DocArqInsData1;
         AV95Core_documentoarquivowwds_6_docarqinsdata_to1 = AV24DocArqInsData_To1;
         AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV97Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV99Core_documentoarquivowwds_10_docarqinsdata2 = AV28DocArqInsData2;
         AV100Core_documentoarquivowwds_11_docarqinsdata_to2 = AV29DocArqInsData_To2;
         AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV102Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV104Core_documentoarquivowwds_15_docarqinsdata3 = AV33DocArqInsData3;
         AV105Core_documentoarquivowwds_16_docarqinsdata_to3 = AV34DocArqInsData_To3;
         AV106Core_documentoarquivowwds_17_tfdocarqconteudonome = AV80TFDocArqConteudoNome;
         AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV81TFDocArqConteudoNome_Sel;
         AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV82TFDocArqConteudoExtensao;
         AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV83TFDocArqConteudoExtensao_Sel;
         AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV59TFDocArqInsDataHora;
         AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV60TFDocArqInsDataHora_To;
         AV112Core_documentoarquivowwds_23_tfdocarqobservacao = AV84TFDocArqObservacao;
         AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV85TFDocArqObservacao_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV91Core_documentoarquivowwds_2_filterfulltext ,
                                              AV92Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                              AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                              AV94Core_documentoarquivowwds_5_docarqinsdata1 ,
                                              AV95Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                              AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                              AV97Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                              AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                              AV99Core_documentoarquivowwds_10_docarqinsdata2 ,
                                              AV100Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                              AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                              AV102Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                              AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                              AV104Core_documentoarquivowwds_15_docarqinsdata3 ,
                                              AV105Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                              AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                              AV106Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                              AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                              AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                              AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                              AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                              AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                              AV112Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A324DocArqObservacao ,
                                              A308DocArqInsData ,
                                              A310DocArqInsDataHora ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV87DocID ,
                                              A289DocID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV91Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV91Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV91Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV91Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV106Core_documentoarquivowwds_17_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV106Core_documentoarquivowwds_17_tfdocarqconteudonome), "%", "");
         lV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao), "%", "");
         lV112Core_documentoarquivowwds_23_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV112Core_documentoarquivowwds_23_tfdocarqobservacao), "%", "");
         /* Using cursor P006O2 */
         pr_default.execute(0, new Object[] {AV87DocID, lV91Core_documentoarquivowwds_2_filterfulltext, lV91Core_documentoarquivowwds_2_filterfulltext, lV91Core_documentoarquivowwds_2_filterfulltext, AV94Core_documentoarquivowwds_5_docarqinsdata1, AV94Core_documentoarquivowwds_5_docarqinsdata1, AV94Core_documentoarquivowwds_5_docarqinsdata1, AV94Core_documentoarquivowwds_5_docarqinsdata1, AV95Core_documentoarquivowwds_6_docarqinsdata_to1, AV99Core_documentoarquivowwds_10_docarqinsdata2, AV99Core_documentoarquivowwds_10_docarqinsdata2, AV99Core_documentoarquivowwds_10_docarqinsdata2, AV99Core_documentoarquivowwds_10_docarqinsdata2, AV100Core_documentoarquivowwds_11_docarqinsdata_to2, AV104Core_documentoarquivowwds_15_docarqinsdata3, AV104Core_documentoarquivowwds_15_docarqinsdata3, AV104Core_documentoarquivowwds_15_docarqinsdata3, AV104Core_documentoarquivowwds_15_docarqinsdata3, AV105Core_documentoarquivowwds_16_docarqinsdata_to3, lV106Core_documentoarquivowwds_17_tfdocarqconteudonome, AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, lV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao, AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora, AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to, lV112Core_documentoarquivowwds_23_tfdocarqobservacao, AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A310DocArqInsDataHora = P006O2_A310DocArqInsDataHora[0];
            A308DocArqInsData = P006O2_A308DocArqInsData[0];
            A324DocArqObservacao = P006O2_A324DocArqObservacao[0];
            n324DocArqObservacao = P006O2_n324DocArqObservacao[0];
            A323DocArqConteudoExtensao = P006O2_A323DocArqConteudoExtensao[0];
            A322DocArqConteudoNome = P006O2_A322DocArqConteudoNome[0];
            A289DocID = P006O2_A289DocID[0];
            A307DocArqSeq = P006O2_A307DocArqSeq[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A322DocArqConteudoNome, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A323DocArqConteudoExtensao, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Date = A310DocArqInsDataHora;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A324DocArqObservacao, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = GXt_char1;
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
         AV36Session.Set("WWPExportFilePath", AV12Filename);
         AV36Session.Set("WWPExportFileName", "DocumentoArquivoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV36Session.Get("core.DocumentoArquivoWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoArquivoWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("core.DocumentoArquivoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV114GXV1 = 1;
         while ( AV114GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV114GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "DOCID_FILTRO") == 0 )
            {
               AV88DocID_Filtro = StringUtil.StrToGuid( AV39GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME") == 0 )
            {
               AV80TFDocArqConteudoNome = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME_SEL") == 0 )
            {
               AV81TFDocArqConteudoNome_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO") == 0 )
            {
               AV82TFDocArqConteudoExtensao = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO_SEL") == 0 )
            {
               AV83TFDocArqConteudoExtensao_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQINSDATAHORA") == 0 )
            {
               AV59TFDocArqInsDataHora = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV60TFDocArqInsDataHora_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO") == 0 )
            {
               AV84TFDocArqObservacao = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO_SEL") == 0 )
            {
               AV85TFDocArqObservacao_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "PARM_&DOCID") == 0 )
            {
               AV87DocID = StringUtil.StrToGuid( AV39GridStateFilterValue.gxTpr_Value);
            }
            AV114GXV1 = (int)(AV114GXV1+1);
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
         AV88DocID_Filtro = Guid.Empty;
         AV19FilterFullText = "";
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23DocArqInsData1 = DateTime.MinValue;
         AV24DocArqInsData_To1 = DateTime.MinValue;
         AV26DynamicFiltersSelector2 = "";
         AV28DocArqInsData2 = DateTime.MinValue;
         AV29DocArqInsData_To2 = DateTime.MinValue;
         AV31DynamicFiltersSelector3 = "";
         AV33DocArqInsData3 = DateTime.MinValue;
         AV34DocArqInsData_To3 = DateTime.MinValue;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV81TFDocArqConteudoNome_Sel = "";
         AV80TFDocArqConteudoNome = "";
         AV83TFDocArqConteudoExtensao_Sel = "";
         AV82TFDocArqConteudoExtensao = "";
         AV59TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV60TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV85TFDocArqObservacao_Sel = "";
         AV84TFDocArqObservacao = "";
         AV90Core_documentoarquivowwds_1_docid_filtro = Guid.Empty;
         AV91Core_documentoarquivowwds_2_filterfulltext = "";
         AV92Core_documentoarquivowwds_3_dynamicfiltersselector1 = "";
         AV94Core_documentoarquivowwds_5_docarqinsdata1 = DateTime.MinValue;
         AV95Core_documentoarquivowwds_6_docarqinsdata_to1 = DateTime.MinValue;
         AV97Core_documentoarquivowwds_8_dynamicfiltersselector2 = "";
         AV99Core_documentoarquivowwds_10_docarqinsdata2 = DateTime.MinValue;
         AV100Core_documentoarquivowwds_11_docarqinsdata_to2 = DateTime.MinValue;
         AV102Core_documentoarquivowwds_13_dynamicfiltersselector3 = "";
         AV104Core_documentoarquivowwds_15_docarqinsdata3 = DateTime.MinValue;
         AV105Core_documentoarquivowwds_16_docarqinsdata_to3 = DateTime.MinValue;
         AV106Core_documentoarquivowwds_17_tfdocarqconteudonome = "";
         AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = "";
         AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao = "";
         AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = "";
         AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora = (DateTime)(DateTime.MinValue);
         AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV112Core_documentoarquivowwds_23_tfdocarqobservacao = "";
         AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel = "";
         scmdbuf = "";
         lV91Core_documentoarquivowwds_2_filterfulltext = "";
         lV106Core_documentoarquivowwds_17_tfdocarqconteudonome = "";
         lV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao = "";
         lV112Core_documentoarquivowwds_23_tfdocarqobservacao = "";
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A324DocArqObservacao = "";
         A308DocArqInsData = DateTime.MinValue;
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV87DocID = Guid.Empty;
         A289DocID = Guid.Empty;
         P006O2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006O2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P006O2_A324DocArqObservacao = new string[] {""} ;
         P006O2_n324DocArqObservacao = new bool[] {false} ;
         P006O2_A323DocArqConteudoExtensao = new string[] {""} ;
         P006O2_A322DocArqConteudoNome = new string[] {""} ;
         P006O2_A289DocID = new Guid[] {Guid.Empty} ;
         P006O2_A307DocArqSeq = new short[1] ;
         GXt_char1 = "";
         AV36Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivowwexport__default(),
            new Object[][] {
                new Object[] {
               P006O2_A310DocArqInsDataHora, P006O2_A308DocArqInsData, P006O2_A324DocArqObservacao, P006O2_n324DocArqObservacao, P006O2_A323DocArqConteudoExtensao, P006O2_A322DocArqConteudoNome, P006O2_A289DocID, P006O2_A307DocArqSeq
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 ;
      private short AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 ;
      private short AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private short A307DocArqSeq ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV114GXV1 ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV59TFDocArqInsDataHora ;
      private DateTime AV60TFDocArqInsDataHora_To ;
      private DateTime AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora ;
      private DateTime AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime AV23DocArqInsData1 ;
      private DateTime AV24DocArqInsData_To1 ;
      private DateTime AV28DocArqInsData2 ;
      private DateTime AV29DocArqInsData_To2 ;
      private DateTime AV33DocArqInsData3 ;
      private DateTime AV34DocArqInsData_To3 ;
      private DateTime AV94Core_documentoarquivowwds_5_docarqinsdata1 ;
      private DateTime AV95Core_documentoarquivowwds_6_docarqinsdata_to1 ;
      private DateTime AV99Core_documentoarquivowwds_10_docarqinsdata2 ;
      private DateTime AV100Core_documentoarquivowwds_11_docarqinsdata_to2 ;
      private DateTime AV104Core_documentoarquivowwds_15_docarqinsdata3 ;
      private DateTime AV105Core_documentoarquivowwds_16_docarqinsdata_to3 ;
      private DateTime A308DocArqInsData ;
      private bool returnInSub ;
      private bool AV22PrintFilterValue ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 ;
      private bool AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n324DocArqObservacao ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV81TFDocArqConteudoNome_Sel ;
      private string AV80TFDocArqConteudoNome ;
      private string AV83TFDocArqConteudoExtensao_Sel ;
      private string AV82TFDocArqConteudoExtensao ;
      private string AV85TFDocArqObservacao_Sel ;
      private string AV84TFDocArqObservacao ;
      private string AV91Core_documentoarquivowwds_2_filterfulltext ;
      private string AV92Core_documentoarquivowwds_3_dynamicfiltersselector1 ;
      private string AV97Core_documentoarquivowwds_8_dynamicfiltersselector2 ;
      private string AV102Core_documentoarquivowwds_13_dynamicfiltersselector3 ;
      private string AV106Core_documentoarquivowwds_17_tfdocarqconteudonome ;
      private string AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ;
      private string AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao ;
      private string AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ;
      private string AV112Core_documentoarquivowwds_23_tfdocarqobservacao ;
      private string AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel ;
      private string lV91Core_documentoarquivowwds_2_filterfulltext ;
      private string lV106Core_documentoarquivowwds_17_tfdocarqconteudonome ;
      private string lV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao ;
      private string lV112Core_documentoarquivowwds_23_tfdocarqobservacao ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private Guid AV88DocID_Filtro ;
      private Guid AV90Core_documentoarquivowwds_1_docid_filtro ;
      private Guid AV87DocID ;
      private Guid A289DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P006O2_A310DocArqInsDataHora ;
      private DateTime[] P006O2_A308DocArqInsData ;
      private string[] P006O2_A324DocArqObservacao ;
      private bool[] P006O2_n324DocArqObservacao ;
      private string[] P006O2_A323DocArqConteudoExtensao ;
      private string[] P006O2_A322DocArqConteudoNome ;
      private Guid[] P006O2_A289DocID ;
      private short[] P006O2_A307DocArqSeq ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private IGxSession AV36Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class documentoarquivowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006O2( IGxContext context ,
                                             string AV91Core_documentoarquivowwds_2_filterfulltext ,
                                             string AV92Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                             short AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                             DateTime AV94Core_documentoarquivowwds_5_docarqinsdata1 ,
                                             DateTime AV95Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                             bool AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                             string AV97Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                             short AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV99Core_documentoarquivowwds_10_docarqinsdata2 ,
                                             DateTime AV100Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                             bool AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                             string AV102Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                             short AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                             DateTime AV104Core_documentoarquivowwds_15_docarqinsdata3 ,
                                             DateTime AV105Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                             string AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                             string AV106Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                             string AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                             string AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                             DateTime AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                             DateTime AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                             string AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                             string AV112Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             string A324DocArqObservacao ,
                                             DateTime A308DocArqInsData ,
                                             DateTime A310DocArqInsDataHora ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             Guid AV87DocID ,
                                             Guid A289DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[27];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT DocArqInsDataHora, DocArqInsData, DocArqObservacao, DocArqConteudoExtensao, DocArqConteudoNome, DocID, DocArqSeq FROM tb_documento_arquivo";
         AddWhere(sWhereString, "(DocID = :AV87DocID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_documentoarquivowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocArqConteudoNome like '%' || :lV91Core_documentoarquivowwds_2_filterfulltext) or ( DocArqConteudoExtensao like '%' || :lV91Core_documentoarquivowwds_2_filterfulltext) or ( DocArqObservacao like '%' || :lV91Core_documentoarquivowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV94Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV94Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV94Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV94Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV94Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV94Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV94Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV94Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV92Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV93Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV95Core_documentoarquivowwds_6_docarqinsdata_to1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV95Core_documentoarquivowwds_6_docarqinsdata_to1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV99Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV99Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV99Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV99Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV99Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV99Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV99Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV99Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV96Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV97Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV98Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV100Core_documentoarquivowwds_11_docarqinsdata_to2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV100Core_documentoarquivowwds_11_docarqinsdata_to2)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV104Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV104Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV104Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV104Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV104Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV104Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV104Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV104Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV101Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV103Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV105Core_documentoarquivowwds_16_docarqinsdata_to3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV105Core_documentoarquivowwds_16_docarqinsdata_to3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_documentoarquivowwds_17_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome like :lV106Core_documentoarquivowwds_17_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome = ( :AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao like :lV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao = ( :AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora >= :AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora <= :AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_documentoarquivowwds_23_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao like :lV112Core_documentoarquivowwds_23_tfdocarqobservacao)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao = ( :AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY DocArqInsData";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY DocArqConteudoNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocArqConteudoNome DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY DocArqConteudoExtensao";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocArqConteudoExtensao DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY DocArqInsDataHora";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocArqInsDataHora DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY DocArqObservacao";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY DocArqObservacao DESC";
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
                     return conditional_P006O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (Guid)dynConstraints[30] , (Guid)dynConstraints[31] );
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
          Object[] prmP006O2;
          prmP006O2 = new Object[] {
          new ParDef("AV87DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV91Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV94Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV94Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV94Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV94Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV95Core_documentoarquivowwds_6_docarqinsdata_to1",GXType.Date,8,0) ,
          new ParDef("AV99Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV99Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV99Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV99Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV100Core_documentoarquivowwds_11_docarqinsdata_to2",GXType.Date,8,0) ,
          new ParDef("AV104Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV104Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV104Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV104Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV105Core_documentoarquivowwds_16_docarqinsdata_to3",GXType.Date,8,0) ,
          new ParDef("lV106Core_documentoarquivowwds_17_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV107Core_documentoarquivowwds_18_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV108Core_documentoarquivowwds_19_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV109Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV110Core_documentoarquivowwds_21_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV111Core_documentoarquivowwds_22_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV112Core_documentoarquivowwds_23_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV113Core_documentoarquivowwds_24_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((Guid[]) buf[6])[0] = rslt.getGuid(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
