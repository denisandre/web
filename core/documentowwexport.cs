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
   public class documentowwexport : GXProcedure
   {
      public documentowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentowwexport( IGxContext context )
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
         documentowwexport objdocumentowwexport;
         objdocumentowwexport = new documentowwexport();
         objdocumentowwexport.AV12Filename = "" ;
         objdocumentowwexport.AV13ErrorMessage = "" ;
         objdocumentowwexport.context.SetSubmitInitialConfig(context);
         objdocumentowwexport.initialize();
         Submit( executePrivateCatch,objdocumentowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "DocumentoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59DocOrigem_Filtro)) ) )
         {
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59DocOrigem_Filtro, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60DocOrigemID_Filtro)) ) )
         {
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60DocOrigemID_Filtro, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
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
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "DOCVERSAO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV22DocVersao1 = (short)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22DocVersao1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", ">=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", "<=", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV22DocVersao1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV23DocTipoSigla1 = AV34GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23DocTipoSigla1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23DocTipoSigla1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "DOCVERSAO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV27DocVersao2 = (short)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV27DocVersao2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", ">=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", "<=", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV27DocVersao2;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV28DocTipoSigla2 = AV34GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28DocTipoSigla2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28DocTipoSigla2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "DOCVERSAO") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV32DocVersao3 = (short)(Math.Round(NumberUtil.Val( AV34GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV32DocVersao3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", ">=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Versão", "<=", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV32DocVersao3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV33DocTipoSigla3 = AV34GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33DocTipoSigla3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33DocTipoSigla3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFDocTipoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV53TFDocTipoNome_Sel)) ? "(Vazio)" : AV53TFDocTipoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFDocTipoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFDocTipoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFDocNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFDocNome_Sel)) ? "(Vazio)" : AV51TFDocNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFDocNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFDocNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV63TFDocVersao) && (0==AV64TFDocVersao_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Versão") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV63TFDocVersao;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV64TFDocVersao_To;
         }
         if ( ! ( (DateTime.MinValue==AV54TFDocInsDataHora) && (DateTime.MinValue==AV55TFDocInsDataHora_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído em") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV54TFDocInsDataHora;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV55TFDocInsDataHora_To;
         }
         if ( ! ( (0==AV61TFDocContrato_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Contrato") ;
            AV14CellRow = GXt_int2;
            if ( AV61TFDocContrato_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV61TFDocContrato_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV62TFDocAssinado_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Assinado") ;
            AV14CellRow = GXt_int2;
            if ( AV62TFDocAssinado_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV62TFDocAssinado_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV47VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV35Session.Get("core.DocumentoWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV35Session.Get("core.DocumentoWWColumnsSelector");
            AV39ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV39ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV39ColumnsSelector.gxTpr_Columns.Count )
         {
            AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV65GXV1));
            if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV41ColumnsSelector_Column.gxTpr_Displayname)) ? AV41ColumnsSelector_Column.gxTpr_Columnname : AV41ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Color = 11;
               AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV67Core_documentowwds_1_docorigem_filtro = AV59DocOrigem_Filtro;
         AV68Core_documentowwds_2_docorigemid_filtro = AV60DocOrigemID_Filtro;
         AV69Core_documentowwds_3_filterfulltext = AV19FilterFullText;
         AV70Core_documentowwds_4_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV71Core_documentowwds_5_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV72Core_documentowwds_6_docversao1 = AV22DocVersao1;
         AV73Core_documentowwds_7_doctiposigla1 = AV23DocTipoSigla1;
         AV74Core_documentowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV75Core_documentowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV76Core_documentowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV77Core_documentowwds_11_docversao2 = AV27DocVersao2;
         AV78Core_documentowwds_12_doctiposigla2 = AV28DocTipoSigla2;
         AV79Core_documentowwds_13_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV80Core_documentowwds_14_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV81Core_documentowwds_15_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV82Core_documentowwds_16_docversao3 = AV32DocVersao3;
         AV83Core_documentowwds_17_doctiposigla3 = AV33DocTipoSigla3;
         AV84Core_documentowwds_18_tfdoctiponome = AV52TFDocTipoNome;
         AV85Core_documentowwds_19_tfdoctiponome_sel = AV53TFDocTipoNome_Sel;
         AV86Core_documentowwds_20_tfdocnome = AV50TFDocNome;
         AV87Core_documentowwds_21_tfdocnome_sel = AV51TFDocNome_Sel;
         AV88Core_documentowwds_22_tfdocversao = AV63TFDocVersao;
         AV89Core_documentowwds_23_tfdocversao_to = AV64TFDocVersao_To;
         AV90Core_documentowwds_24_tfdocinsdatahora = AV54TFDocInsDataHora;
         AV91Core_documentowwds_25_tfdocinsdatahora_to = AV55TFDocInsDataHora_To;
         AV92Core_documentowwds_26_tfdoccontrato_sel = AV61TFDocContrato_Sel;
         AV93Core_documentowwds_27_tfdocassinado_sel = AV62TFDocAssinado_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV69Core_documentowwds_3_filterfulltext ,
                                              AV70Core_documentowwds_4_dynamicfiltersselector1 ,
                                              AV71Core_documentowwds_5_dynamicfiltersoperator1 ,
                                              AV72Core_documentowwds_6_docversao1 ,
                                              AV73Core_documentowwds_7_doctiposigla1 ,
                                              AV74Core_documentowwds_8_dynamicfiltersenabled2 ,
                                              AV75Core_documentowwds_9_dynamicfiltersselector2 ,
                                              AV76Core_documentowwds_10_dynamicfiltersoperator2 ,
                                              AV77Core_documentowwds_11_docversao2 ,
                                              AV78Core_documentowwds_12_doctiposigla2 ,
                                              AV79Core_documentowwds_13_dynamicfiltersenabled3 ,
                                              AV80Core_documentowwds_14_dynamicfiltersselector3 ,
                                              AV81Core_documentowwds_15_dynamicfiltersoperator3 ,
                                              AV82Core_documentowwds_16_docversao3 ,
                                              AV83Core_documentowwds_17_doctiposigla3 ,
                                              AV85Core_documentowwds_19_tfdoctiponome_sel ,
                                              AV84Core_documentowwds_18_tfdoctiponome ,
                                              AV87Core_documentowwds_21_tfdocnome_sel ,
                                              AV86Core_documentowwds_20_tfdocnome ,
                                              AV88Core_documentowwds_22_tfdocversao ,
                                              AV89Core_documentowwds_23_tfdocversao_to ,
                                              AV90Core_documentowwds_24_tfdocinsdatahora ,
                                              AV91Core_documentowwds_25_tfdocinsdatahora_to ,
                                              AV92Core_documentowwds_26_tfdoccontrato_sel ,
                                              AV93Core_documentowwds_27_tfdocassinado_sel ,
                                              A148DocTipoNome ,
                                              A305DocNome ,
                                              A325DocVersao ,
                                              A147DocTipoSigla ,
                                              A294DocInsDataHora ,
                                              A480DocContrato ,
                                              A481DocAssinado ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A640DocAtivo ,
                                              AV57DocOrigem ,
                                              AV58DocOrigemID ,
                                              A290DocOrigem ,
                                              A291DocOrigemID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV69Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Core_documentowwds_3_filterfulltext), "%", "");
         lV69Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Core_documentowwds_3_filterfulltext), "%", "");
         lV69Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Core_documentowwds_3_filterfulltext), "%", "");
         lV73Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV73Core_documentowwds_7_doctiposigla1), "%", "");
         lV73Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV73Core_documentowwds_7_doctiposigla1), "%", "");
         lV78Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV78Core_documentowwds_12_doctiposigla2), "%", "");
         lV78Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV78Core_documentowwds_12_doctiposigla2), "%", "");
         lV83Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_17_doctiposigla3), "%", "");
         lV83Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_17_doctiposigla3), "%", "");
         lV84Core_documentowwds_18_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV84Core_documentowwds_18_tfdoctiponome), "%", "");
         lV86Core_documentowwds_20_tfdocnome = StringUtil.Concat( StringUtil.RTrim( AV86Core_documentowwds_20_tfdocnome), "%", "");
         /* Using cursor P006J2 */
         pr_default.execute(0, new Object[] {AV57DocOrigem, AV58DocOrigemID, lV69Core_documentowwds_3_filterfulltext, lV69Core_documentowwds_3_filterfulltext, lV69Core_documentowwds_3_filterfulltext, AV72Core_documentowwds_6_docversao1, AV72Core_documentowwds_6_docversao1, AV72Core_documentowwds_6_docversao1, lV73Core_documentowwds_7_doctiposigla1, lV73Core_documentowwds_7_doctiposigla1, AV77Core_documentowwds_11_docversao2, AV77Core_documentowwds_11_docversao2, AV77Core_documentowwds_11_docversao2, lV78Core_documentowwds_12_doctiposigla2, lV78Core_documentowwds_12_doctiposigla2, AV82Core_documentowwds_16_docversao3, AV82Core_documentowwds_16_docversao3, AV82Core_documentowwds_16_docversao3, lV83Core_documentowwds_17_doctiposigla3, lV83Core_documentowwds_17_doctiposigla3, lV84Core_documentowwds_18_tfdoctiponome, AV85Core_documentowwds_19_tfdoctiponome_sel, lV86Core_documentowwds_20_tfdocnome, AV87Core_documentowwds_21_tfdocnome_sel, AV88Core_documentowwds_22_tfdocversao, AV89Core_documentowwds_23_tfdocversao_to, AV90Core_documentowwds_24_tfdocinsdatahora, AV91Core_documentowwds_25_tfdocinsdatahora_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146DocTipoID = P006J2_A146DocTipoID[0];
            A640DocAtivo = P006J2_A640DocAtivo[0];
            n640DocAtivo = P006J2_n640DocAtivo[0];
            A481DocAssinado = P006J2_A481DocAssinado[0];
            A480DocContrato = P006J2_A480DocContrato[0];
            A294DocInsDataHora = P006J2_A294DocInsDataHora[0];
            A147DocTipoSigla = P006J2_A147DocTipoSigla[0];
            A325DocVersao = P006J2_A325DocVersao[0];
            A305DocNome = P006J2_A305DocNome[0];
            A148DocTipoNome = P006J2_A148DocTipoNome[0];
            A291DocOrigemID = P006J2_A291DocOrigemID[0];
            A290DocOrigem = P006J2_A290DocOrigem[0];
            A289DocID = P006J2_A289DocID[0];
            A147DocTipoSigla = P006J2_A147DocTipoSigla[0];
            A148DocTipoNome = P006J2_A148DocTipoNome[0];
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
            AV94GXV2 = 1;
            while ( AV94GXV2 <= AV39ColumnsSelector.gxTpr_Columns.Count )
            {
               AV41ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV39ColumnsSelector.gxTpr_Columns.Item(AV94GXV2));
               if ( AV41ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocTipoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A148DocTipoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A305DocNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocVersao") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Number = A325DocVersao;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocInsDataHora") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Date = A294DocInsDataHora;
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocContrato") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A480DocContrato);
                  }
                  else if ( StringUtil.StrCmp(AV41ColumnsSelector_Column.gxTpr_Columnname, "DocAssinado") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV47VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A481DocAssinado);
                  }
                  AV47VisibleColumnCount = (long)(AV47VisibleColumnCount+1);
               }
               AV94GXV2 = (int)(AV94GXV2+1);
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
         AV35Session.Set("WWPExportFileName", "DocumentoWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocTipoNome",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocNome",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocVersao",  "",  "Versão",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocInsDataHora",  "",  "Incluído em",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocContrato",  "",  "Contrato",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV39ColumnsSelector,  "DocAssinado",  "",  "Assinado",  true,  "") ;
         GXt_char1 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.DocumentoWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV35Session.Get("core.DocumentoWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("core.DocumentoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV37GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV37GridState.gxTpr_Ordereddsc;
         AV95GXV3 = 1;
         while ( AV95GXV3 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV95GXV3));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "DOCORIGEM_FILTRO") == 0 )
            {
               AV59DocOrigem_Filtro = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "DOCORIGEMID_FILTRO") == 0 )
            {
               AV60DocOrigemID_Filtro = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME") == 0 )
            {
               AV52TFDocTipoNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME_SEL") == 0 )
            {
               AV53TFDocTipoNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCNOME") == 0 )
            {
               AV50TFDocNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCNOME_SEL") == 0 )
            {
               AV51TFDocNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCVERSAO") == 0 )
            {
               AV63TFDocVersao = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV64TFDocVersao_To = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCINSDATAHORA") == 0 )
            {
               AV54TFDocInsDataHora = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, 2);
               AV55TFDocInsDataHora_To = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCCONTRATO_SEL") == 0 )
            {
               AV61TFDocContrato_Sel = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFDOCASSINADO_SEL") == 0 )
            {
               AV62TFDocAssinado_Sel = (short)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&DOCORIGEM") == 0 )
            {
               AV57DocOrigem = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&DOCORIGEMID") == 0 )
            {
               AV58DocOrigemID = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV95GXV3 = (int)(AV95GXV3+1);
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
         AV59DocOrigem_Filtro = "";
         AV60DocOrigemID_Filtro = "";
         AV19FilterFullText = "";
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23DocTipoSigla1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV28DocTipoSigla2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV33DocTipoSigla3 = "";
         AV53TFDocTipoNome_Sel = "";
         AV52TFDocTipoNome = "";
         AV51TFDocNome_Sel = "";
         AV50TFDocNome = "";
         AV54TFDocInsDataHora = (DateTime)(DateTime.MinValue);
         AV55TFDocInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV35Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         AV39ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV41ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV67Core_documentowwds_1_docorigem_filtro = "";
         AV68Core_documentowwds_2_docorigemid_filtro = "";
         AV69Core_documentowwds_3_filterfulltext = "";
         AV70Core_documentowwds_4_dynamicfiltersselector1 = "";
         AV73Core_documentowwds_7_doctiposigla1 = "";
         AV75Core_documentowwds_9_dynamicfiltersselector2 = "";
         AV78Core_documentowwds_12_doctiposigla2 = "";
         AV80Core_documentowwds_14_dynamicfiltersselector3 = "";
         AV83Core_documentowwds_17_doctiposigla3 = "";
         AV84Core_documentowwds_18_tfdoctiponome = "";
         AV85Core_documentowwds_19_tfdoctiponome_sel = "";
         AV86Core_documentowwds_20_tfdocnome = "";
         AV87Core_documentowwds_21_tfdocnome_sel = "";
         AV90Core_documentowwds_24_tfdocinsdatahora = (DateTime)(DateTime.MinValue);
         AV91Core_documentowwds_25_tfdocinsdatahora_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV69Core_documentowwds_3_filterfulltext = "";
         lV73Core_documentowwds_7_doctiposigla1 = "";
         lV78Core_documentowwds_12_doctiposigla2 = "";
         lV83Core_documentowwds_17_doctiposigla3 = "";
         lV84Core_documentowwds_18_tfdoctiponome = "";
         lV86Core_documentowwds_20_tfdocnome = "";
         A148DocTipoNome = "";
         A305DocNome = "";
         A147DocTipoSigla = "";
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         AV57DocOrigem = "";
         AV58DocOrigemID = "";
         A290DocOrigem = "";
         A291DocOrigemID = "";
         P006J2_A146DocTipoID = new int[1] ;
         P006J2_A640DocAtivo = new bool[] {false} ;
         P006J2_n640DocAtivo = new bool[] {false} ;
         P006J2_A481DocAssinado = new bool[] {false} ;
         P006J2_A480DocContrato = new bool[] {false} ;
         P006J2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006J2_A147DocTipoSigla = new string[] {""} ;
         P006J2_A325DocVersao = new short[1] ;
         P006J2_A305DocNome = new string[] {""} ;
         P006J2_A148DocTipoNome = new string[] {""} ;
         P006J2_A291DocOrigemID = new string[] {""} ;
         P006J2_A290DocOrigem = new string[] {""} ;
         P006J2_A289DocID = new Guid[] {Guid.Empty} ;
         A289DocID = Guid.Empty;
         AV43UserCustomValue = "";
         GXt_char1 = "";
         AV40ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentowwexport__default(),
            new Object[][] {
                new Object[] {
               P006J2_A146DocTipoID, P006J2_A640DocAtivo, P006J2_n640DocAtivo, P006J2_A481DocAssinado, P006J2_A480DocContrato, P006J2_A294DocInsDataHora, P006J2_A147DocTipoSigla, P006J2_A325DocVersao, P006J2_A305DocNome, P006J2_A148DocTipoNome,
               P006J2_A291DocOrigemID, P006J2_A290DocOrigem, P006J2_A289DocID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV22DocVersao1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV27DocVersao2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV32DocVersao3 ;
      private short AV63TFDocVersao ;
      private short AV64TFDocVersao_To ;
      private short AV61TFDocContrato_Sel ;
      private short AV62TFDocAssinado_Sel ;
      private short GXt_int2 ;
      private short AV71Core_documentowwds_5_dynamicfiltersoperator1 ;
      private short AV72Core_documentowwds_6_docversao1 ;
      private short AV76Core_documentowwds_10_dynamicfiltersoperator2 ;
      private short AV77Core_documentowwds_11_docversao2 ;
      private short AV81Core_documentowwds_15_dynamicfiltersoperator3 ;
      private short AV82Core_documentowwds_16_docversao3 ;
      private short AV88Core_documentowwds_22_tfdocversao ;
      private short AV89Core_documentowwds_23_tfdocversao_to ;
      private short AV92Core_documentowwds_26_tfdoccontrato_sel ;
      private short AV93Core_documentowwds_27_tfdocassinado_sel ;
      private short A325DocVersao ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV65GXV1 ;
      private int A146DocTipoID ;
      private int AV94GXV2 ;
      private int AV95GXV3 ;
      private long AV47VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime AV54TFDocInsDataHora ;
      private DateTime AV55TFDocInsDataHora_To ;
      private DateTime AV90Core_documentowwds_24_tfdocinsdatahora ;
      private DateTime AV91Core_documentowwds_25_tfdocinsdatahora_to ;
      private DateTime A294DocInsDataHora ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV74Core_documentowwds_8_dynamicfiltersenabled2 ;
      private bool AV79Core_documentowwds_13_dynamicfiltersenabled3 ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool AV18OrderedDsc ;
      private bool A640DocAtivo ;
      private bool n640DocAtivo ;
      private string AV42ColumnsSelectorXML ;
      private string AV43UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV59DocOrigem_Filtro ;
      private string AV60DocOrigemID_Filtro ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV23DocTipoSigla1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV28DocTipoSigla2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV33DocTipoSigla3 ;
      private string AV53TFDocTipoNome_Sel ;
      private string AV52TFDocTipoNome ;
      private string AV51TFDocNome_Sel ;
      private string AV50TFDocNome ;
      private string AV67Core_documentowwds_1_docorigem_filtro ;
      private string AV68Core_documentowwds_2_docorigemid_filtro ;
      private string AV69Core_documentowwds_3_filterfulltext ;
      private string AV70Core_documentowwds_4_dynamicfiltersselector1 ;
      private string AV73Core_documentowwds_7_doctiposigla1 ;
      private string AV75Core_documentowwds_9_dynamicfiltersselector2 ;
      private string AV78Core_documentowwds_12_doctiposigla2 ;
      private string AV80Core_documentowwds_14_dynamicfiltersselector3 ;
      private string AV83Core_documentowwds_17_doctiposigla3 ;
      private string AV84Core_documentowwds_18_tfdoctiponome ;
      private string AV85Core_documentowwds_19_tfdoctiponome_sel ;
      private string AV86Core_documentowwds_20_tfdocnome ;
      private string AV87Core_documentowwds_21_tfdocnome_sel ;
      private string lV69Core_documentowwds_3_filterfulltext ;
      private string lV73Core_documentowwds_7_doctiposigla1 ;
      private string lV78Core_documentowwds_12_doctiposigla2 ;
      private string lV83Core_documentowwds_17_doctiposigla3 ;
      private string lV84Core_documentowwds_18_tfdoctiponome ;
      private string lV86Core_documentowwds_20_tfdocnome ;
      private string A148DocTipoNome ;
      private string A305DocNome ;
      private string A147DocTipoSigla ;
      private string AV57DocOrigem ;
      private string AV58DocOrigemID ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private Guid A289DocID ;
      private IGxSession AV35Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006J2_A146DocTipoID ;
      private bool[] P006J2_A640DocAtivo ;
      private bool[] P006J2_n640DocAtivo ;
      private bool[] P006J2_A481DocAssinado ;
      private bool[] P006J2_A480DocContrato ;
      private DateTime[] P006J2_A294DocInsDataHora ;
      private string[] P006J2_A147DocTipoSigla ;
      private short[] P006J2_A325DocVersao ;
      private string[] P006J2_A305DocNome ;
      private string[] P006J2_A148DocTipoNome ;
      private string[] P006J2_A291DocOrigemID ;
      private string[] P006J2_A290DocOrigem ;
      private Guid[] P006J2_A289DocID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV41ColumnsSelector_Column ;
   }

   public class documentowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006J2( IGxContext context ,
                                             string AV69Core_documentowwds_3_filterfulltext ,
                                             string AV70Core_documentowwds_4_dynamicfiltersselector1 ,
                                             short AV71Core_documentowwds_5_dynamicfiltersoperator1 ,
                                             short AV72Core_documentowwds_6_docversao1 ,
                                             string AV73Core_documentowwds_7_doctiposigla1 ,
                                             bool AV74Core_documentowwds_8_dynamicfiltersenabled2 ,
                                             string AV75Core_documentowwds_9_dynamicfiltersselector2 ,
                                             short AV76Core_documentowwds_10_dynamicfiltersoperator2 ,
                                             short AV77Core_documentowwds_11_docversao2 ,
                                             string AV78Core_documentowwds_12_doctiposigla2 ,
                                             bool AV79Core_documentowwds_13_dynamicfiltersenabled3 ,
                                             string AV80Core_documentowwds_14_dynamicfiltersselector3 ,
                                             short AV81Core_documentowwds_15_dynamicfiltersoperator3 ,
                                             short AV82Core_documentowwds_16_docversao3 ,
                                             string AV83Core_documentowwds_17_doctiposigla3 ,
                                             string AV85Core_documentowwds_19_tfdoctiponome_sel ,
                                             string AV84Core_documentowwds_18_tfdoctiponome ,
                                             string AV87Core_documentowwds_21_tfdocnome_sel ,
                                             string AV86Core_documentowwds_20_tfdocnome ,
                                             short AV88Core_documentowwds_22_tfdocversao ,
                                             short AV89Core_documentowwds_23_tfdocversao_to ,
                                             DateTime AV90Core_documentowwds_24_tfdocinsdatahora ,
                                             DateTime AV91Core_documentowwds_25_tfdocinsdatahora_to ,
                                             short AV92Core_documentowwds_26_tfdoccontrato_sel ,
                                             short AV93Core_documentowwds_27_tfdocassinado_sel ,
                                             string A148DocTipoNome ,
                                             string A305DocNome ,
                                             short A325DocVersao ,
                                             string A147DocTipoSigla ,
                                             DateTime A294DocInsDataHora ,
                                             bool A480DocContrato ,
                                             bool A481DocAssinado ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A640DocAtivo ,
                                             string AV57DocOrigem ,
                                             string AV58DocOrigemID ,
                                             string A290DocOrigem ,
                                             string A291DocOrigemID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.DocTipoID, T1.DocAtivo, T1.DocAssinado, T1.DocContrato, T1.DocInsDataHora, T2.DocTipoSigla, T1.DocVersao, T1.DocNome, T2.DocTipoNome, T1.DocOrigemID, T1.DocOrigem, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID)";
         AddWhere(sWhereString, "(T1.DocOrigem = ( :AV57DocOrigem) and T1.DocOrigemID = ( :AV58DocOrigemID))");
         AddWhere(sWhereString, "(T1.DocAtivo = TRUE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_documentowwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.DocTipoNome like '%' || :lV69Core_documentowwds_3_filterfulltext) or ( T1.DocNome like '%' || :lV69Core_documentowwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.DocVersao,'9999'), 2) like '%' || :lV69Core_documentowwds_3_filterfulltext))");
         }
         else
         {
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV71Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV72Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV72Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV71Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV72Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV72Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV71Core_documentowwds_5_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV72Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV72Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV71Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV73Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV71Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV73Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV74Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV76Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV77Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV77Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV74Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV76Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV77Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV77Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV74Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV76Core_documentowwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV77Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV77Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV74Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV76Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV78Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV74Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV76Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV78Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV79Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV81Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV82Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV82Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV79Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV81Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV82Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV82Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV79Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV81Core_documentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV82Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV82Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV79Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV81Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV83Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV79Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV81Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV83Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_documentowwds_19_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_documentowwds_18_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome like :lV84Core_documentowwds_18_tfdoctiponome)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_documentowwds_19_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV85Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome = ( :AV85Core_documentowwds_19_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV85Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.DocTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_21_tfdocnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Core_documentowwds_20_tfdocnome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocNome like :lV86Core_documentowwds_20_tfdocnome)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_21_tfdocnome_sel)) && ! ( StringUtil.StrCmp(AV87Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocNome = ( :AV87Core_documentowwds_21_tfdocnome_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV87Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocNome))=0))");
         }
         if ( ! (0==AV88Core_documentowwds_22_tfdocversao) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV88Core_documentowwds_22_tfdocversao)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (0==AV89Core_documentowwds_23_tfdocversao_to) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV89Core_documentowwds_23_tfdocversao_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Core_documentowwds_24_tfdocinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora >= :AV90Core_documentowwds_24_tfdocinsdatahora)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Core_documentowwds_25_tfdocinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora <= :AV91Core_documentowwds_25_tfdocinsdatahora_to)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV92Core_documentowwds_26_tfdoccontrato_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = TRUE)");
         }
         if ( AV92Core_documentowwds_26_tfdoccontrato_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = FALSE)");
         }
         if ( AV93Core_documentowwds_27_tfdocassinado_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = TRUE)");
         }
         if ( AV93Core_documentowwds_27_tfdocassinado_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.DocOrigem, T1.DocOrigemID, T1.DocInsDataHora DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.DocTipoNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.DocTipoNome DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocNome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocNome DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocVersao";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocVersao DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocInsDataHora";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocInsDataHora DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocContrato";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocContrato DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocAssinado";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocAssinado DESC";
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
                     return conditional_P006J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] , (bool)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
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
          Object[] prmP006J2;
          prmP006J2 = new Object[] {
          new ParDef("AV57DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV58DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("lV69Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV69Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV72Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV72Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV72Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("lV73Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV73Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("AV77Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV77Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV77Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("lV78Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV78Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("AV82Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV82Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV82Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("lV83Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV83Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV84Core_documentowwds_18_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV85Core_documentowwds_19_tfdoctiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV86Core_documentowwds_20_tfdocnome",GXType.VarChar,80,0) ,
          new ParDef("AV87Core_documentowwds_21_tfdocnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV88Core_documentowwds_22_tfdocversao",GXType.Int16,4,0) ,
          new ParDef("AV89Core_documentowwds_23_tfdocversao_to",GXType.Int16,4,0) ,
          new ParDef("AV90Core_documentowwds_24_tfdocinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV91Core_documentowwds_25_tfdocinsdatahora_to",GXType.DateTime2,10,12)
          };
          def= new CursorDef[] {
              new CursorDef("P006J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
       }
    }

 }

}
