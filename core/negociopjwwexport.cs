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
   public class negociopjwwexport : GXProcedure
   {
      public negociopjwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjwwexport( IGxContext context )
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
         negociopjwwexport objnegociopjwwexport;
         objnegociopjwwexport = new negociopjwwexport();
         objnegociopjwwexport.AV12Filename = "" ;
         objnegociopjwwexport.AV13ErrorMessage = "" ;
         objnegociopjwwexport.context.SetSubmitInitialConfig(context);
         objnegociopjwwexport.initialize();
         Submit( executePrivateCatch,objnegociopjwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((negociopjwwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "NegocioPJWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (false==AV84NegDel) ) )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.BoolToStr( AV84NegDel);
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
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "NEGASSUNTO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22NegAssunto1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22NegAssunto1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Assunto", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Assunto", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22NegAssunto1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "NEGASSUNTO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26NegAssunto2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26NegAssunto2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Assunto", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Assunto", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26NegAssunto2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "NEGASSUNTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30NegAssunto3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30NegAssunto3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Assunto", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Assunto", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30NegAssunto3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV47TFNegCodigo) && (0==AV48TFNegCodigo_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Negociação") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV47TFNegCodigo;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV48TFNegCodigo_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFNegAssunto_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Assunto") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV78TFNegAssunto_Sel)) ? "(Vazio)" : AV78TFNegAssunto_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFNegAssunto)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Assunto") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV77TFNegAssunto, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFNegCliNomeFamiliar_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Cliente") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFNegCliNomeFamiliar_Sel)) ? "(Vazio)" : AV60TFNegCliNomeFamiliar_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFNegCliNomeFamiliar)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Cliente") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFNegCliNomeFamiliar, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFNegCpjNomFan_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Unidade") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV62TFNegCpjNomFan_Sel)) ? "(Vazio)" : AV62TFNegCpjNomFan_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFNegCpjNomFan)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Unidade") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61TFNegCpjNomFan, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV65TFNegCpjMatricula) && (0==AV66TFNegCpjMatricula_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Matrícula") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV65TFNegCpjMatricula;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV66TFNegCpjMatricula_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFNegPjtNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV72TFNegPjtNome_Sel)) ? "(Vazio)" : AV72TFNegPjtNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFNegPjtNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71TFNegPjtNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFNegAgcNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Agente Comercial") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV76TFNegAgcNome_Sel)) ? "(Vazio)" : AV76TFNegAgcNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFNegAgcNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Agente Comercial") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV75TFNegAgcNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV82TFNegValorAtualizado) && (Convert.ToDecimal(0)==AV83TFNegValorAtualizado_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Total em Negócios") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV82TFNegValorAtualizado);
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV83TFNegValorAtualizado_To);
         }
         if ( ! ( (DateTime.MinValue==AV49TFNegInsData) && (DateTime.MinValue==AV50TFNegInsData_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído em") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV49TFNegInsData ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV50TFNegInsData_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV81TFNegInsUsuNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído por") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV81TFNegInsUsuNome_Sel)) ? "(Vazio)" : AV81TFNegInsUsuNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV80TFNegInsUsuNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Incluído por") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV80TFNegInsUsuNome, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.NegocioPJWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV32Session.Get("core.NegocioPJWWColumnsSelector");
            AV36ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV36ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV36ColumnsSelector.gxTpr_Columns.Count )
         {
            AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV85GXV1));
            if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV38ColumnsSelector_Column.gxTpr_Displayname)) ? AV38ColumnsSelector_Column.gxTpr_Columnname : AV38ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Color = 11;
               AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV87Core_negociopjwwds_1_negdel = AV84NegDel;
         AV88Core_negociopjwwds_2_filterfulltext = AV19FilterFullText;
         AV89Core_negociopjwwds_3_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV90Core_negociopjwwds_4_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV91Core_negociopjwwds_5_negassunto1 = AV22NegAssunto1;
         AV92Core_negociopjwwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV93Core_negociopjwwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV94Core_negociopjwwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV95Core_negociopjwwds_9_negassunto2 = AV26NegAssunto2;
         AV96Core_negociopjwwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV97Core_negociopjwwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV98Core_negociopjwwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV99Core_negociopjwwds_13_negassunto3 = AV30NegAssunto3;
         AV100Core_negociopjwwds_14_tfnegcodigo = AV47TFNegCodigo;
         AV101Core_negociopjwwds_15_tfnegcodigo_to = AV48TFNegCodigo_To;
         AV102Core_negociopjwwds_16_tfnegassunto = AV77TFNegAssunto;
         AV103Core_negociopjwwds_17_tfnegassunto_sel = AV78TFNegAssunto_Sel;
         AV104Core_negociopjwwds_18_tfnegclinomefamiliar = AV59TFNegCliNomeFamiliar;
         AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV60TFNegCliNomeFamiliar_Sel;
         AV106Core_negociopjwwds_20_tfnegcpjnomfan = AV61TFNegCpjNomFan;
         AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV62TFNegCpjNomFan_Sel;
         AV108Core_negociopjwwds_22_tfnegcpjmatricula = AV65TFNegCpjMatricula;
         AV109Core_negociopjwwds_23_tfnegcpjmatricula_to = AV66TFNegCpjMatricula_To;
         AV110Core_negociopjwwds_24_tfnegpjtnome = AV71TFNegPjtNome;
         AV111Core_negociopjwwds_25_tfnegpjtnome_sel = AV72TFNegPjtNome_Sel;
         AV112Core_negociopjwwds_26_tfnegagcnome = AV75TFNegAgcNome;
         AV113Core_negociopjwwds_27_tfnegagcnome_sel = AV76TFNegAgcNome_Sel;
         AV114Core_negociopjwwds_28_tfnegvaloratualizado = AV82TFNegValorAtualizado;
         AV115Core_negociopjwwds_29_tfnegvaloratualizado_to = AV83TFNegValorAtualizado_To;
         AV116Core_negociopjwwds_30_tfneginsdata = AV49TFNegInsData;
         AV117Core_negociopjwwds_31_tfneginsdata_to = AV50TFNegInsData_To;
         AV118Core_negociopjwwds_32_tfneginsusunome = AV80TFNegInsUsuNome;
         AV119Core_negociopjwwds_33_tfneginsusunome_sel = AV81TFNegInsUsuNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV88Core_negociopjwwds_2_filterfulltext ,
                                              AV89Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV90Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV91Core_negociopjwwds_5_negassunto1 ,
                                              AV92Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV93Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV94Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV95Core_negociopjwwds_9_negassunto2 ,
                                              AV96Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV97Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV98Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV99Core_negociopjwwds_13_negassunto3 ,
                                              AV100Core_negociopjwwds_14_tfnegcodigo ,
                                              AV101Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV103Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV102Core_negociopjwwds_16_tfnegassunto ,
                                              AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV104Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV106Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV108Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV109Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV111Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV110Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV113Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV112Core_negociopjwwds_26_tfnegagcnome ,
                                              AV114Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV115Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV116Core_negociopjwwds_30_tfneginsdata ,
                                              AV117Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV119Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV118Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV88Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext), "%", "");
         lV91Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV91Core_negociopjwwds_5_negassunto1), "%", "");
         lV91Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV91Core_negociopjwwds_5_negassunto1), "%", "");
         lV95Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV95Core_negociopjwwds_9_negassunto2), "%", "");
         lV95Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV95Core_negociopjwwds_9_negassunto2), "%", "");
         lV99Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_13_negassunto3), "%", "");
         lV99Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV99Core_negociopjwwds_13_negassunto3), "%", "");
         lV102Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV102Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV104Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV104Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV106Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV106Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV110Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV110Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV112Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV112Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV118Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV118Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00532 */
         pr_default.execute(0, new Object[] {lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV88Core_negociopjwwds_2_filterfulltext, lV91Core_negociopjwwds_5_negassunto1, lV91Core_negociopjwwds_5_negassunto1, lV95Core_negociopjwwds_9_negassunto2, lV95Core_negociopjwwds_9_negassunto2, lV99Core_negociopjwwds_13_negassunto3, lV99Core_negociopjwwds_13_negassunto3, AV100Core_negociopjwwds_14_tfnegcodigo, AV101Core_negociopjwwds_15_tfnegcodigo_to, lV102Core_negociopjwwds_16_tfnegassunto, AV103Core_negociopjwwds_17_tfnegassunto_sel, lV104Core_negociopjwwds_18_tfnegclinomefamiliar, AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV106Core_negociopjwwds_20_tfnegcpjnomfan, AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV108Core_negociopjwwds_22_tfnegcpjmatricula, AV109Core_negociopjwwds_23_tfnegcpjmatricula_to, lV110Core_negociopjwwds_24_tfnegpjtnome, AV111Core_negociopjwwds_25_tfnegpjtnome_sel, lV112Core_negociopjwwds_26_tfnegagcnome, AV113Core_negociopjwwds_27_tfnegagcnome_sel, AV114Core_negociopjwwds_28_tfnegvaloratualizado, AV115Core_negociopjwwds_29_tfnegvaloratualizado_to, AV116Core_negociopjwwds_30_tfneginsdata, AV117Core_negociopjwwds_31_tfneginsdata_to, lV118Core_negociopjwwds_32_tfneginsusunome, AV119Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A350NegCliID = P00532_A350NegCliID[0];
            A352NegCpjID = P00532_A352NegCpjID[0];
            A346NegInsData = P00532_A346NegInsData[0];
            A385NegValorAtualizado = P00532_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00532_A355NegCpjMatricula[0];
            A356NegCodigo = P00532_A356NegCodigo[0];
            A364NegInsUsuNome = P00532_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00532_n364NegInsUsuNome[0];
            A361NegAgcNome = P00532_A361NegAgcNome[0];
            n361NegAgcNome = P00532_n361NegAgcNome[0];
            A359NegPjtNome = P00532_A359NegPjtNome[0];
            A353NegCpjNomFan = P00532_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00532_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00532_A362NegAssunto[0];
            A572NegDel = P00532_A572NegDel[0];
            A345NegID = P00532_A345NegID[0];
            A355NegCpjMatricula = P00532_A355NegCpjMatricula[0];
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
            AV120GXV2 = 1;
            while ( AV120GXV2 <= AV36ColumnsSelector.gxTpr_Columns.Count )
            {
               AV38ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV36ColumnsSelector.gxTpr_Columns.Item(AV120GXV2));
               if ( AV38ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegCodigo") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A356NegCodigo;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegAssunto") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A362NegAssunto, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegCliNomeFamiliar") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A351NegCliNomeFamiliar, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegCpjNomFan") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A353NegCpjNomFan, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegCpjMatricula") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = A355NegCpjMatricula;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegPjtNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A359NegPjtNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegAgcNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A361NegAgcNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegValorAtualizado") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Number = (double)(A385NegValorAtualizado);
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegInsData") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A346NegInsData ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV38ColumnsSelector_Column.gxTpr_Columnname, "NegInsUsuNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A364NegInsUsuNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV44VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV44VisibleColumnCount = (long)(AV44VisibleColumnCount+1);
               }
               AV120GXV2 = (int)(AV120GXV2+1);
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
         AV32Session.Set("WWPExportFileName", "NegocioPJWWExport.xlsx");
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
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegCodigo",  "",  "Negociação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegAssunto",  "",  "Assunto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegCliNomeFamiliar",  "",  "Cliente",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegCpjNomFan",  "",  "Unidade",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegCpjMatricula",  "",  "Matrícula",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegPjtNome",  "",  "Tipo",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegAgcNome",  "",  "Agente Comercial",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegValorAtualizado",  "",  "Total em Negócios",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegInsData",  "",  "Incluído em",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV36ColumnsSelector,  "NegInsUsuNome",  "",  "Incluído por",  false,  "") ;
         GXt_char1 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.NegocioPJWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV32Session.Get("core.NegocioPJWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.NegocioPJWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("core.NegocioPJWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV121GXV3 = 1;
         while ( AV121GXV3 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV121GXV3));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "NEGDEL") == 0 )
            {
               AV84NegDel = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGCODIGO") == 0 )
            {
               AV47TFNegCodigo = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO") == 0 )
            {
               AV77TFNegAssunto = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO_SEL") == 0 )
            {
               AV78TFNegAssunto_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR") == 0 )
            {
               AV59TFNegCliNomeFamiliar = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV60TFNegCliNomeFamiliar_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN") == 0 )
            {
               AV61TFNegCpjNomFan = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN_SEL") == 0 )
            {
               AV62TFNegCpjNomFan_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGCPJMATRICULA") == 0 )
            {
               AV65TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV66TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME") == 0 )
            {
               AV71TFNegPjtNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME_SEL") == 0 )
            {
               AV72TFNegPjtNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME") == 0 )
            {
               AV75TFNegAgcNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME_SEL") == 0 )
            {
               AV76TFNegAgcNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGVALORATUALIZADO") == 0 )
            {
               AV82TFNegValorAtualizado = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV83TFNegValorAtualizado_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGINSDATA") == 0 )
            {
               AV49TFNegInsData = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Value, 2);
               AV50TFNegInsData_To = context.localUtil.CToD( AV35GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME") == 0 )
            {
               AV80TFNegInsUsuNome = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME_SEL") == 0 )
            {
               AV81TFNegInsUsuNome_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV121GXV3 = (int)(AV121GXV3+1);
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
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22NegAssunto1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26NegAssunto2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30NegAssunto3 = "";
         AV78TFNegAssunto_Sel = "";
         AV77TFNegAssunto = "";
         AV60TFNegCliNomeFamiliar_Sel = "";
         AV59TFNegCliNomeFamiliar = "";
         AV62TFNegCpjNomFan_Sel = "";
         AV61TFNegCpjNomFan = "";
         AV72TFNegPjtNome_Sel = "";
         AV71TFNegPjtNome = "";
         AV76TFNegAgcNome_Sel = "";
         AV75TFNegAgcNome = "";
         AV49TFNegInsData = DateTime.MinValue;
         AV50TFNegInsData_To = DateTime.MinValue;
         AV81TFNegInsUsuNome_Sel = "";
         AV80TFNegInsUsuNome = "";
         AV32Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV36ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV38ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV88Core_negociopjwwds_2_filterfulltext = "";
         AV89Core_negociopjwwds_3_dynamicfiltersselector1 = "";
         AV91Core_negociopjwwds_5_negassunto1 = "";
         AV93Core_negociopjwwds_7_dynamicfiltersselector2 = "";
         AV95Core_negociopjwwds_9_negassunto2 = "";
         AV97Core_negociopjwwds_11_dynamicfiltersselector3 = "";
         AV99Core_negociopjwwds_13_negassunto3 = "";
         AV102Core_negociopjwwds_16_tfnegassunto = "";
         AV103Core_negociopjwwds_17_tfnegassunto_sel = "";
         AV104Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel = "";
         AV106Core_negociopjwwds_20_tfnegcpjnomfan = "";
         AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel = "";
         AV110Core_negociopjwwds_24_tfnegpjtnome = "";
         AV111Core_negociopjwwds_25_tfnegpjtnome_sel = "";
         AV112Core_negociopjwwds_26_tfnegagcnome = "";
         AV113Core_negociopjwwds_27_tfnegagcnome_sel = "";
         AV116Core_negociopjwwds_30_tfneginsdata = DateTime.MinValue;
         AV117Core_negociopjwwds_31_tfneginsdata_to = DateTime.MinValue;
         AV118Core_negociopjwwds_32_tfneginsusunome = "";
         AV119Core_negociopjwwds_33_tfneginsusunome_sel = "";
         scmdbuf = "";
         lV88Core_negociopjwwds_2_filterfulltext = "";
         lV91Core_negociopjwwds_5_negassunto1 = "";
         lV95Core_negociopjwwds_9_negassunto2 = "";
         lV99Core_negociopjwwds_13_negassunto3 = "";
         lV102Core_negociopjwwds_16_tfnegassunto = "";
         lV104Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         lV106Core_negociopjwwds_20_tfnegcpjnomfan = "";
         lV110Core_negociopjwwds_24_tfnegpjtnome = "";
         lV112Core_negociopjwwds_26_tfnegagcnome = "";
         lV118Core_negociopjwwds_32_tfneginsusunome = "";
         A362NegAssunto = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         A359NegPjtNome = "";
         A361NegAgcNome = "";
         A364NegInsUsuNome = "";
         A346NegInsData = DateTime.MinValue;
         P00532_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00532_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00532_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00532_A385NegValorAtualizado = new decimal[1] ;
         P00532_A355NegCpjMatricula = new long[1] ;
         P00532_A356NegCodigo = new long[1] ;
         P00532_A364NegInsUsuNome = new string[] {""} ;
         P00532_n364NegInsUsuNome = new bool[] {false} ;
         P00532_A361NegAgcNome = new string[] {""} ;
         P00532_n361NegAgcNome = new bool[] {false} ;
         P00532_A359NegPjtNome = new string[] {""} ;
         P00532_A353NegCpjNomFan = new string[] {""} ;
         P00532_A351NegCliNomeFamiliar = new string[] {""} ;
         P00532_A362NegAssunto = new string[] {""} ;
         P00532_A572NegDel = new bool[] {false} ;
         P00532_A345NegID = new Guid[] {Guid.Empty} ;
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         A345NegID = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV40UserCustomValue = "";
         GXt_char1 = "";
         AV37ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjwwexport__default(),
            new Object[][] {
                new Object[] {
               P00532_A350NegCliID, P00532_A352NegCpjID, P00532_A346NegInsData, P00532_A385NegValorAtualizado, P00532_A355NegCpjMatricula, P00532_A356NegCodigo, P00532_A364NegInsUsuNome, P00532_n364NegInsUsuNome, P00532_A361NegAgcNome, P00532_n361NegAgcNome,
               P00532_A359NegPjtNome, P00532_A353NegCpjNomFan, P00532_A351NegCliNomeFamiliar, P00532_A362NegAssunto, P00532_A572NegDel, P00532_A345NegID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV90Core_negociopjwwds_4_dynamicfiltersoperator1 ;
      private short AV94Core_negociopjwwds_8_dynamicfiltersoperator2 ;
      private short AV98Core_negociopjwwds_12_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV85GXV1 ;
      private int AV120GXV2 ;
      private int AV121GXV3 ;
      private long AV47TFNegCodigo ;
      private long AV48TFNegCodigo_To ;
      private long AV65TFNegCpjMatricula ;
      private long AV66TFNegCpjMatricula_To ;
      private long AV44VisibleColumnCount ;
      private long AV100Core_negociopjwwds_14_tfnegcodigo ;
      private long AV101Core_negociopjwwds_15_tfnegcodigo_to ;
      private long AV108Core_negociopjwwds_22_tfnegcpjmatricula ;
      private long AV109Core_negociopjwwds_23_tfnegcpjmatricula_to ;
      private long A356NegCodigo ;
      private long A355NegCpjMatricula ;
      private decimal AV82TFNegValorAtualizado ;
      private decimal AV83TFNegValorAtualizado_To ;
      private decimal AV114Core_negociopjwwds_28_tfnegvaloratualizado ;
      private decimal AV115Core_negociopjwwds_29_tfnegvaloratualizado_to ;
      private decimal A385NegValorAtualizado ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV49TFNegInsData ;
      private DateTime AV50TFNegInsData_To ;
      private DateTime AV116Core_negociopjwwds_30_tfneginsdata ;
      private DateTime AV117Core_negociopjwwds_31_tfneginsdata_to ;
      private DateTime A346NegInsData ;
      private bool returnInSub ;
      private bool AV84NegDel ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV87Core_negociopjwwds_1_negdel ;
      private bool AV92Core_negociopjwwds_6_dynamicfiltersenabled2 ;
      private bool AV96Core_negociopjwwds_10_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool A572NegDel ;
      private bool n364NegInsUsuNome ;
      private bool n361NegAgcNome ;
      private string AV39ColumnsSelectorXML ;
      private string AV40UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22NegAssunto1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26NegAssunto2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30NegAssunto3 ;
      private string AV78TFNegAssunto_Sel ;
      private string AV77TFNegAssunto ;
      private string AV60TFNegCliNomeFamiliar_Sel ;
      private string AV59TFNegCliNomeFamiliar ;
      private string AV62TFNegCpjNomFan_Sel ;
      private string AV61TFNegCpjNomFan ;
      private string AV72TFNegPjtNome_Sel ;
      private string AV71TFNegPjtNome ;
      private string AV76TFNegAgcNome_Sel ;
      private string AV75TFNegAgcNome ;
      private string AV81TFNegInsUsuNome_Sel ;
      private string AV80TFNegInsUsuNome ;
      private string AV88Core_negociopjwwds_2_filterfulltext ;
      private string AV89Core_negociopjwwds_3_dynamicfiltersselector1 ;
      private string AV91Core_negociopjwwds_5_negassunto1 ;
      private string AV93Core_negociopjwwds_7_dynamicfiltersselector2 ;
      private string AV95Core_negociopjwwds_9_negassunto2 ;
      private string AV97Core_negociopjwwds_11_dynamicfiltersselector3 ;
      private string AV99Core_negociopjwwds_13_negassunto3 ;
      private string AV102Core_negociopjwwds_16_tfnegassunto ;
      private string AV103Core_negociopjwwds_17_tfnegassunto_sel ;
      private string AV104Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel ;
      private string AV106Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel ;
      private string AV110Core_negociopjwwds_24_tfnegpjtnome ;
      private string AV111Core_negociopjwwds_25_tfnegpjtnome_sel ;
      private string AV112Core_negociopjwwds_26_tfnegagcnome ;
      private string AV113Core_negociopjwwds_27_tfnegagcnome_sel ;
      private string AV118Core_negociopjwwds_32_tfneginsusunome ;
      private string AV119Core_negociopjwwds_33_tfneginsusunome_sel ;
      private string lV88Core_negociopjwwds_2_filterfulltext ;
      private string lV91Core_negociopjwwds_5_negassunto1 ;
      private string lV95Core_negociopjwwds_9_negassunto2 ;
      private string lV99Core_negociopjwwds_13_negassunto3 ;
      private string lV102Core_negociopjwwds_16_tfnegassunto ;
      private string lV104Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string lV106Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string lV110Core_negociopjwwds_24_tfnegpjtnome ;
      private string lV112Core_negociopjwwds_26_tfnegagcnome ;
      private string lV118Core_negociopjwwds_32_tfneginsusunome ;
      private string A362NegAssunto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A359NegPjtNome ;
      private string A361NegAgcNome ;
      private string A364NegInsUsuNome ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A345NegID ;
      private IGxSession AV32Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00532_A350NegCliID ;
      private Guid[] P00532_A352NegCpjID ;
      private DateTime[] P00532_A346NegInsData ;
      private decimal[] P00532_A385NegValorAtualizado ;
      private long[] P00532_A355NegCpjMatricula ;
      private long[] P00532_A356NegCodigo ;
      private string[] P00532_A364NegInsUsuNome ;
      private bool[] P00532_n364NegInsUsuNome ;
      private string[] P00532_A361NegAgcNome ;
      private bool[] P00532_n361NegAgcNome ;
      private string[] P00532_A359NegPjtNome ;
      private string[] P00532_A353NegCpjNomFan ;
      private string[] P00532_A351NegCliNomeFamiliar ;
      private string[] P00532_A362NegAssunto ;
      private bool[] P00532_A572NegDel ;
      private Guid[] P00532_A345NegID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV37ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV38ColumnsSelector_Column ;
   }

   public class negociopjwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00532( IGxContext context ,
                                             string AV88Core_negociopjwwds_2_filterfulltext ,
                                             string AV89Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV90Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV91Core_negociopjwwds_5_negassunto1 ,
                                             bool AV92Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV93Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV94Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV95Core_negociopjwwds_9_negassunto2 ,
                                             bool AV96Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV97Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV98Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV99Core_negociopjwwds_13_negassunto3 ,
                                             long AV100Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV101Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV103Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV102Core_negociopjwwds_16_tfnegassunto ,
                                             string AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV104Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV106Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV108Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV109Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV111Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV110Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV113Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV112Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV114Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV115Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV116Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV117Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV119Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV118Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[35];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegAgcNome, T1.NegPjtNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV88Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV88Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV90Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV91Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV90Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV91Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV92Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV94Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV95Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV92Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV93Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV94Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV95Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV96Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV97Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV98Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV99Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV96Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV97Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV98Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV99Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (0==AV100Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV100Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV101Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV101Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV102Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV103Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV103Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV103Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV104Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV106Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV108Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV108Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (0==AV109Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV109Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV110Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV111Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV111Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV111Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV112Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV113Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV113Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV113Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV114Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV114Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV115Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV115Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV116Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV117Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV118Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV119Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV119Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( StringUtil.StrCmp(AV119Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegAssunto";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegAssunto DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegCodigo";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegCodigo DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegCliNomeFamiliar";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegCliNomeFamiliar DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegCpjNomFan";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegCpjNomFan DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CpjMatricula";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CpjMatricula DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegPjtNome";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegPjtNome DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegAgcNome";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegAgcNome DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegValorAtualizado";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegValorAtualizado DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegInsData";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegInsData DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegInsUsuNome";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegInsUsuNome DESC";
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
                     return conditional_P00532(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (bool)dynConstraints[44] );
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
          Object[] prmP00532;
          prmP00532 = new Object[] {
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV91Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV95Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV95Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV99Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV99Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV101Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV102Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV103Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV104Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV106Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV107Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV109Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV110Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV111Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV112Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV113Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV114Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV115Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV116Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV117Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV118Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV119Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00532", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00532,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((Guid[]) buf[15])[0] = rslt.getGuid(14);
                return;
       }
    }

 }

}
