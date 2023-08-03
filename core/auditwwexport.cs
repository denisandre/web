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
   public class auditwwexport : GXProcedure
   {
      public auditwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditwwexport( IGxContext context )
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
         auditwwexport objauditwwexport;
         objauditwwexport = new auditwwexport();
         objauditwwexport.AV12Filename = "" ;
         objauditwwexport.AV13ErrorMessage = "" ;
         objauditwwexport.context.SetSubmitInitialConfig(context);
         objauditwwexport.initialize();
         Submit( executePrivateCatch,objauditwwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auditwwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "AuditWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "AUDITDATE") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV23AuditDate1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
               AV24AuditDate_To1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
               AV22PrintFilterValue = false;
               if ( ! (DateTime.MinValue==AV23AuditDate1) || ! (DateTime.MinValue==AV24AuditDate_To1) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Data", "Período", "", "", "", "", "", "", "");
                     AV22PrintFilterValue = true;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Passado";
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Hoje";
                  }
                  else if ( AV21DynamicFiltersOperator1 == 3 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "No futuro";
                  }
                  if ( AV22PrintFilterValue )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_dtime3 = DateTimeUtil.ResetTime( AV23AuditDate1 ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( AV24AuditDate_To1 ) ;
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
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "AUDITDATE") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28AuditDate2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
                  AV29AuditDate_To2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
                  AV22PrintFilterValue = false;
                  if ( ! (DateTime.MinValue==AV28AuditDate2) || ! (DateTime.MinValue==AV29AuditDate_To2) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Data", "Período", "", "", "", "", "", "", "");
                        AV22PrintFilterValue = true;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Passado";
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Hoje";
                     }
                     else if ( AV27DynamicFiltersOperator2 == 3 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "No futuro";
                     }
                     if ( AV22PrintFilterValue )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_dtime3 = DateTimeUtil.ResetTime( AV28AuditDate2 ) ;
                        AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                           GXt_dtime3 = DateTimeUtil.ResetTime( AV29AuditDate_To2 ) ;
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
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "AUDITDATE") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33AuditDate3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
                     AV34AuditDate_To3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
                     AV22PrintFilterValue = false;
                     if ( ! (DateTime.MinValue==AV33AuditDate3) || ! (DateTime.MinValue==AV34AuditDate_To3) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Data", "Período", "", "", "", "", "", "", "");
                           AV22PrintFilterValue = true;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 3;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = " - ";
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Passado";
                        }
                        else if ( AV32DynamicFiltersOperator3 == 2 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Hoje";
                        }
                        else if ( AV32DynamicFiltersOperator3 == 3 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = "Data";
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "No futuro";
                        }
                        if ( AV22PrintFilterValue )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                           GXt_dtime3 = DateTimeUtil.ResetTime( AV33AuditDate3 ) ;
                           AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
                           if ( AV22PrintFilterValue )
                           {
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                              GXt_dtime3 = DateTimeUtil.ResetTime( AV34AuditDate_To3 ) ;
                              AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                              AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
                           }
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (DateTime.MinValue==AV66TFAuditDateTime) && (DateTime.MinValue==AV67TFAuditDateTime_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Data/Hora") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = AV66TFAuditDateTime;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = AV67TFAuditDateTime_To;
         }
         if ( ! ( (DateTime.MinValue==AV51TFAuditDate) && (DateTime.MinValue==AV52TFAuditDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Data") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV51TFAuditDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV52TFAuditDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV53TFAuditTime) && (DateTime.MinValue==AV54TFAuditTime_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Hora") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = context.localUtil.Format( AV53TFAuditTime, "99:99");
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = context.localUtil.Format( AV54TFAuditTime_To, "99:99");
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFAuditTableName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tabela") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFAuditTableName_Sel)) ? "(Vazio)" : AV56TFAuditTableName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFAuditTableName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tabela") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFAuditTableName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFAuditAction_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ação") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV64TFAuditAction_Sel)) ? "(Vazio)" : AV64TFAuditAction_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFAuditAction)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ação") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV63TFAuditAction, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAuditShortDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAuditShortDescription_Sel)) ? "(Vazio)" : AV58TFAuditShortDescription_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFAuditShortDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Descrição") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFAuditShortDescription, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAuditDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Detalhes") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAuditDescription_Sel)) ? "(Vazio)" : StringUtil.Substring( AV60TFAuditDescription_Sel, 1, 1000)), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFAuditDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Detalhes") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV59TFAuditDescription, 1, 1000), out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFAuditGAMUserName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Usuário") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV62TFAuditGAMUserName_Sel)) ? "(Vazio)" : AV62TFAuditGAMUserName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFAuditGAMUserName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Usuário") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV61TFAuditGAMUserName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV48VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV36Session.Get("core.AuditWWColumnsSelector"), "") != 0 )
         {
            AV43ColumnsSelectorXML = AV36Session.Get("core.AuditWWColumnsSelector");
            AV40ColumnsSelector.FromXml(AV43ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV40ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV40ColumnsSelector.gxTpr_Columns.Count )
         {
            AV42ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(AV68GXV1));
            if ( AV42ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV42ColumnsSelector_Column.gxTpr_Displayname)) ? AV42ColumnsSelector_Column.gxTpr_Columnname : AV42ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Color = 11;
               AV48VisibleColumnCount = (long)(AV48VisibleColumnCount+1);
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV70Core_auditwwds_1_filterfulltext = AV19FilterFullText;
         AV71Core_auditwwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV72Core_auditwwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV73Core_auditwwds_4_auditdate1 = AV23AuditDate1;
         AV74Core_auditwwds_5_auditdate_to1 = AV24AuditDate_To1;
         AV75Core_auditwwds_6_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV76Core_auditwwds_7_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV77Core_auditwwds_8_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV78Core_auditwwds_9_auditdate2 = AV28AuditDate2;
         AV79Core_auditwwds_10_auditdate_to2 = AV29AuditDate_To2;
         AV80Core_auditwwds_11_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV81Core_auditwwds_12_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV82Core_auditwwds_13_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV83Core_auditwwds_14_auditdate3 = AV33AuditDate3;
         AV84Core_auditwwds_15_auditdate_to3 = AV34AuditDate_To3;
         AV85Core_auditwwds_16_tfauditdatetime = AV66TFAuditDateTime;
         AV86Core_auditwwds_17_tfauditdatetime_to = AV67TFAuditDateTime_To;
         AV87Core_auditwwds_18_tfauditdate = AV51TFAuditDate;
         AV88Core_auditwwds_19_tfauditdate_to = AV52TFAuditDate_To;
         AV89Core_auditwwds_20_tfaudittime = AV53TFAuditTime;
         AV90Core_auditwwds_21_tfaudittime_to = AV54TFAuditTime_To;
         AV91Core_auditwwds_22_tfaudittablename = AV55TFAuditTableName;
         AV92Core_auditwwds_23_tfaudittablename_sel = AV56TFAuditTableName_Sel;
         AV93Core_auditwwds_24_tfauditaction = AV63TFAuditAction;
         AV94Core_auditwwds_25_tfauditaction_sel = AV64TFAuditAction_Sel;
         AV95Core_auditwwds_26_tfauditshortdescription = AV57TFAuditShortDescription;
         AV96Core_auditwwds_27_tfauditshortdescription_sel = AV58TFAuditShortDescription_Sel;
         AV97Core_auditwwds_28_tfauditdescription = AV59TFAuditDescription;
         AV98Core_auditwwds_29_tfauditdescription_sel = AV60TFAuditDescription_Sel;
         AV99Core_auditwwds_30_tfauditgamusername = AV61TFAuditGAMUserName;
         AV100Core_auditwwds_31_tfauditgamusername_sel = AV62TFAuditGAMUserName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV70Core_auditwwds_1_filterfulltext ,
                                              AV71Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV72Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV73Core_auditwwds_4_auditdate1 ,
                                              AV74Core_auditwwds_5_auditdate_to1 ,
                                              AV75Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV76Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV77Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV78Core_auditwwds_9_auditdate2 ,
                                              AV79Core_auditwwds_10_auditdate_to2 ,
                                              AV80Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV81Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV82Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV83Core_auditwwds_14_auditdate3 ,
                                              AV84Core_auditwwds_15_auditdate_to3 ,
                                              AV85Core_auditwwds_16_tfauditdatetime ,
                                              AV86Core_auditwwds_17_tfauditdatetime_to ,
                                              AV87Core_auditwwds_18_tfauditdate ,
                                              AV88Core_auditwwds_19_tfauditdate_to ,
                                              AV89Core_auditwwds_20_tfaudittime ,
                                              AV90Core_auditwwds_21_tfaudittime_to ,
                                              AV92Core_auditwwds_23_tfaudittablename_sel ,
                                              AV91Core_auditwwds_22_tfaudittablename ,
                                              AV94Core_auditwwds_25_tfauditaction_sel ,
                                              AV93Core_auditwwds_24_tfauditaction ,
                                              AV96Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV95Core_auditwwds_26_tfauditshortdescription ,
                                              AV98Core_auditwwds_29_tfauditdescription_sel ,
                                              AV97Core_auditwwds_28_tfauditdescription ,
                                              AV100Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV99Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_auditwwds_1_filterfulltext), "%", "");
         lV70Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_auditwwds_1_filterfulltext), "%", "");
         lV70Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_auditwwds_1_filterfulltext), "%", "");
         lV70Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_auditwwds_1_filterfulltext), "%", "");
         lV70Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Core_auditwwds_1_filterfulltext), "%", "");
         lV91Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV91Core_auditwwds_22_tfaudittablename), "%", "");
         lV93Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_24_tfauditaction), "%", "");
         lV95Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV97Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV97Core_auditwwds_28_tfauditdescription), "%", "");
         lV99Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV99Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007L2 */
         pr_default.execute(0, new Object[] {lV70Core_auditwwds_1_filterfulltext, lV70Core_auditwwds_1_filterfulltext, lV70Core_auditwwds_1_filterfulltext, lV70Core_auditwwds_1_filterfulltext, lV70Core_auditwwds_1_filterfulltext, AV73Core_auditwwds_4_auditdate1, AV74Core_auditwwds_5_auditdate_to1, AV73Core_auditwwds_4_auditdate1, AV73Core_auditwwds_4_auditdate1, AV73Core_auditwwds_4_auditdate1, AV78Core_auditwwds_9_auditdate2, AV79Core_auditwwds_10_auditdate_to2, AV78Core_auditwwds_9_auditdate2, AV78Core_auditwwds_9_auditdate2, AV78Core_auditwwds_9_auditdate2, AV83Core_auditwwds_14_auditdate3, AV84Core_auditwwds_15_auditdate_to3, AV83Core_auditwwds_14_auditdate3, AV83Core_auditwwds_14_auditdate3, AV83Core_auditwwds_14_auditdate3, AV85Core_auditwwds_16_tfauditdatetime, AV86Core_auditwwds_17_tfauditdatetime_to, AV87Core_auditwwds_18_tfauditdate, AV88Core_auditwwds_19_tfauditdate_to, AV89Core_auditwwds_20_tfaudittime, AV90Core_auditwwds_21_tfaudittime_to, lV91Core_auditwwds_22_tfaudittablename, AV92Core_auditwwds_23_tfaudittablename_sel, lV93Core_auditwwds_24_tfauditaction, AV94Core_auditwwds_25_tfauditaction_sel, lV95Core_auditwwds_26_tfauditshortdescription, AV96Core_auditwwds_27_tfauditshortdescription_sel, lV97Core_auditwwds_28_tfauditdescription, AV98Core_auditwwds_29_tfauditdescription_sel, lV99Core_auditwwds_30_tfauditgamusername, AV100Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A495AuditTime = P007L2_A495AuditTime[0];
            A496AuditDateTime = P007L2_A496AuditDateTime[0];
            A494AuditDate = P007L2_A494AuditDate[0];
            A501AuditGAMUserName = P007L2_A501AuditGAMUserName[0];
            A498AuditDescription = P007L2_A498AuditDescription[0];
            A499AuditShortDescription = P007L2_A499AuditShortDescription[0];
            A502AuditAction = P007L2_A502AuditAction[0];
            A497AuditTableName = P007L2_A497AuditTableName[0];
            A493AuditID = P007L2_A493AuditID[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV48VisibleColumnCount = 0;
            AV101GXV2 = 1;
            while ( AV101GXV2 <= AV40ColumnsSelector.gxTpr_Columns.Count )
            {
               AV42ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV40ColumnsSelector.gxTpr_Columns.Item(AV101GXV2));
               if ( AV42ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditDateTime") == 0 )
                  {
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Date = A496AuditDateTime;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A494AuditDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditTime") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = context.localUtil.Format( A495AuditTime, "99:99");
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditTableName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A497AuditTableName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditAction") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A502AuditAction, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditShortDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A499AuditShortDescription, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  StringUtil.Substring( A498AuditDescription, 1, 1000), out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV42ColumnsSelector_Column.gxTpr_Columnname, "AuditGAMUserName") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A501AuditGAMUserName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV48VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV48VisibleColumnCount = (long)(AV48VisibleColumnCount+1);
               }
               AV101GXV2 = (int)(AV101GXV2+1);
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
         AV36Session.Set("WWPExportFilePath", AV12Filename);
         AV36Session.Set("WWPExportFileName", "AuditWWExport.xlsx");
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
         AV40ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditDateTime",  "",  "Data/Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditDate",  "",  "Data",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditTime",  "",  "Hora",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditTableName",  "",  "Tabela",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditAction",  "",  "Ação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditShortDescription",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditDescription",  "",  "Detalhes",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV40ColumnsSelector,  "AuditGAMUserName",  "",  "Usuário",  true,  "") ;
         GXt_char1 = AV44UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.AuditWWColumnsSelector", out  GXt_char1) ;
         AV44UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44UserCustomValue)) ) )
         {
            AV41ColumnsSelectorAux.FromXml(AV44UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV41ColumnsSelectorAux, ref  AV40ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("core.AuditWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.AuditWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("core.AuditWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV102GXV3 = 1;
         while ( AV102GXV3 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV102GXV3));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDATETIME") == 0 )
            {
               AV66TFAuditDateTime = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV67TFAuditDateTime_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV51TFAuditDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV52TFAuditDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTIME") == 0 )
            {
               AV53TFAuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2));
               AV54TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV55TFAuditTableName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV56TFAuditTableName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV63TFAuditAction = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV64TFAuditAction_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV57TFAuditShortDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV58TFAuditShortDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV59TFAuditDescription = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV60TFAuditDescription_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME") == 0 )
            {
               AV61TFAuditGAMUserName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME_SEL") == 0 )
            {
               AV62TFAuditGAMUserName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV102GXV3 = (int)(AV102GXV3+1);
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
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV23AuditDate1 = DateTime.MinValue;
         AV24AuditDate_To1 = DateTime.MinValue;
         AV26DynamicFiltersSelector2 = "";
         AV28AuditDate2 = DateTime.MinValue;
         AV29AuditDate_To2 = DateTime.MinValue;
         AV31DynamicFiltersSelector3 = "";
         AV33AuditDate3 = DateTime.MinValue;
         AV34AuditDate_To3 = DateTime.MinValue;
         AV66TFAuditDateTime = (DateTime)(DateTime.MinValue);
         AV67TFAuditDateTime_To = (DateTime)(DateTime.MinValue);
         AV51TFAuditDate = DateTime.MinValue;
         AV52TFAuditDate_To = DateTime.MinValue;
         AV53TFAuditTime = (DateTime)(DateTime.MinValue);
         AV54TFAuditTime_To = (DateTime)(DateTime.MinValue);
         AV56TFAuditTableName_Sel = "";
         AV55TFAuditTableName = "";
         AV64TFAuditAction_Sel = "";
         AV63TFAuditAction = "";
         AV58TFAuditShortDescription_Sel = "";
         AV57TFAuditShortDescription = "";
         AV60TFAuditDescription_Sel = "";
         AV59TFAuditDescription = "";
         AV62TFAuditGAMUserName_Sel = "";
         AV61TFAuditGAMUserName = "";
         AV36Session = context.GetSession();
         AV43ColumnsSelectorXML = "";
         AV40ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV42ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV70Core_auditwwds_1_filterfulltext = "";
         AV71Core_auditwwds_2_dynamicfiltersselector1 = "";
         AV73Core_auditwwds_4_auditdate1 = DateTime.MinValue;
         AV74Core_auditwwds_5_auditdate_to1 = DateTime.MinValue;
         AV76Core_auditwwds_7_dynamicfiltersselector2 = "";
         AV78Core_auditwwds_9_auditdate2 = DateTime.MinValue;
         AV79Core_auditwwds_10_auditdate_to2 = DateTime.MinValue;
         AV81Core_auditwwds_12_dynamicfiltersselector3 = "";
         AV83Core_auditwwds_14_auditdate3 = DateTime.MinValue;
         AV84Core_auditwwds_15_auditdate_to3 = DateTime.MinValue;
         AV85Core_auditwwds_16_tfauditdatetime = (DateTime)(DateTime.MinValue);
         AV86Core_auditwwds_17_tfauditdatetime_to = (DateTime)(DateTime.MinValue);
         AV87Core_auditwwds_18_tfauditdate = DateTime.MinValue;
         AV88Core_auditwwds_19_tfauditdate_to = DateTime.MinValue;
         AV89Core_auditwwds_20_tfaudittime = (DateTime)(DateTime.MinValue);
         AV90Core_auditwwds_21_tfaudittime_to = (DateTime)(DateTime.MinValue);
         AV91Core_auditwwds_22_tfaudittablename = "";
         AV92Core_auditwwds_23_tfaudittablename_sel = "";
         AV93Core_auditwwds_24_tfauditaction = "";
         AV94Core_auditwwds_25_tfauditaction_sel = "";
         AV95Core_auditwwds_26_tfauditshortdescription = "";
         AV96Core_auditwwds_27_tfauditshortdescription_sel = "";
         AV97Core_auditwwds_28_tfauditdescription = "";
         AV98Core_auditwwds_29_tfauditdescription_sel = "";
         AV99Core_auditwwds_30_tfauditgamusername = "";
         AV100Core_auditwwds_31_tfauditgamusername_sel = "";
         scmdbuf = "";
         lV70Core_auditwwds_1_filterfulltext = "";
         lV91Core_auditwwds_22_tfaudittablename = "";
         lV93Core_auditwwds_24_tfauditaction = "";
         lV95Core_auditwwds_26_tfauditshortdescription = "";
         lV97Core_auditwwds_28_tfauditdescription = "";
         lV99Core_auditwwds_30_tfauditgamusername = "";
         A497AuditTableName = "";
         A502AuditAction = "";
         A499AuditShortDescription = "";
         A498AuditDescription = "";
         A501AuditGAMUserName = "";
         A494AuditDate = DateTime.MinValue;
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         A495AuditTime = (DateTime)(DateTime.MinValue);
         P007L2_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007L2_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007L2_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007L2_A501AuditGAMUserName = new string[] {""} ;
         P007L2_A498AuditDescription = new string[] {""} ;
         P007L2_A499AuditShortDescription = new string[] {""} ;
         P007L2_A502AuditAction = new string[] {""} ;
         P007L2_A497AuditTableName = new string[] {""} ;
         P007L2_A493AuditID = new Guid[] {Guid.Empty} ;
         A493AuditID = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV44UserCustomValue = "";
         GXt_char1 = "";
         AV41ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.auditwwexport__default(),
            new Object[][] {
                new Object[] {
               P007L2_A495AuditTime, P007L2_A496AuditDateTime, P007L2_A494AuditDate, P007L2_A501AuditGAMUserName, P007L2_A498AuditDescription, P007L2_A499AuditShortDescription, P007L2_A502AuditAction, P007L2_A497AuditTableName, P007L2_A493AuditID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV72Core_auditwwds_3_dynamicfiltersoperator1 ;
      private short AV77Core_auditwwds_8_dynamicfiltersoperator2 ;
      private short AV82Core_auditwwds_13_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV68GXV1 ;
      private int AV101GXV2 ;
      private int AV102GXV3 ;
      private long AV48VisibleColumnCount ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime AV66TFAuditDateTime ;
      private DateTime AV67TFAuditDateTime_To ;
      private DateTime AV53TFAuditTime ;
      private DateTime AV54TFAuditTime_To ;
      private DateTime AV85Core_auditwwds_16_tfauditdatetime ;
      private DateTime AV86Core_auditwwds_17_tfauditdatetime_to ;
      private DateTime AV89Core_auditwwds_20_tfaudittime ;
      private DateTime AV90Core_auditwwds_21_tfaudittime_to ;
      private DateTime A496AuditDateTime ;
      private DateTime A495AuditTime ;
      private DateTime GXt_dtime3 ;
      private DateTime AV23AuditDate1 ;
      private DateTime AV24AuditDate_To1 ;
      private DateTime AV28AuditDate2 ;
      private DateTime AV29AuditDate_To2 ;
      private DateTime AV33AuditDate3 ;
      private DateTime AV34AuditDate_To3 ;
      private DateTime AV51TFAuditDate ;
      private DateTime AV52TFAuditDate_To ;
      private DateTime AV73Core_auditwwds_4_auditdate1 ;
      private DateTime AV74Core_auditwwds_5_auditdate_to1 ;
      private DateTime AV78Core_auditwwds_9_auditdate2 ;
      private DateTime AV79Core_auditwwds_10_auditdate_to2 ;
      private DateTime AV83Core_auditwwds_14_auditdate3 ;
      private DateTime AV84Core_auditwwds_15_auditdate_to3 ;
      private DateTime AV87Core_auditwwds_18_tfauditdate ;
      private DateTime AV88Core_auditwwds_19_tfauditdate_to ;
      private DateTime A494AuditDate ;
      private bool returnInSub ;
      private bool AV22PrintFilterValue ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV75Core_auditwwds_6_dynamicfiltersenabled2 ;
      private bool AV80Core_auditwwds_11_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private string AV43ColumnsSelectorXML ;
      private string A498AuditDescription ;
      private string AV44UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV56TFAuditTableName_Sel ;
      private string AV55TFAuditTableName ;
      private string AV64TFAuditAction_Sel ;
      private string AV63TFAuditAction ;
      private string AV58TFAuditShortDescription_Sel ;
      private string AV57TFAuditShortDescription ;
      private string AV60TFAuditDescription_Sel ;
      private string AV59TFAuditDescription ;
      private string AV62TFAuditGAMUserName_Sel ;
      private string AV61TFAuditGAMUserName ;
      private string AV70Core_auditwwds_1_filterfulltext ;
      private string AV71Core_auditwwds_2_dynamicfiltersselector1 ;
      private string AV76Core_auditwwds_7_dynamicfiltersselector2 ;
      private string AV81Core_auditwwds_12_dynamicfiltersselector3 ;
      private string AV91Core_auditwwds_22_tfaudittablename ;
      private string AV92Core_auditwwds_23_tfaudittablename_sel ;
      private string AV93Core_auditwwds_24_tfauditaction ;
      private string AV94Core_auditwwds_25_tfauditaction_sel ;
      private string AV95Core_auditwwds_26_tfauditshortdescription ;
      private string AV96Core_auditwwds_27_tfauditshortdescription_sel ;
      private string AV97Core_auditwwds_28_tfauditdescription ;
      private string AV98Core_auditwwds_29_tfauditdescription_sel ;
      private string AV99Core_auditwwds_30_tfauditgamusername ;
      private string AV100Core_auditwwds_31_tfauditgamusername_sel ;
      private string lV70Core_auditwwds_1_filterfulltext ;
      private string lV91Core_auditwwds_22_tfaudittablename ;
      private string lV93Core_auditwwds_24_tfauditaction ;
      private string lV95Core_auditwwds_26_tfauditshortdescription ;
      private string lV97Core_auditwwds_28_tfauditdescription ;
      private string lV99Core_auditwwds_30_tfauditgamusername ;
      private string A497AuditTableName ;
      private string A502AuditAction ;
      private string A499AuditShortDescription ;
      private string A501AuditGAMUserName ;
      private Guid A493AuditID ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P007L2_A495AuditTime ;
      private DateTime[] P007L2_A496AuditDateTime ;
      private DateTime[] P007L2_A494AuditDate ;
      private string[] P007L2_A501AuditGAMUserName ;
      private string[] P007L2_A498AuditDescription ;
      private string[] P007L2_A499AuditShortDescription ;
      private string[] P007L2_A502AuditAction ;
      private string[] P007L2_A497AuditTableName ;
      private Guid[] P007L2_A493AuditID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV40ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV42ColumnsSelector_Column ;
   }

   public class auditwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007L2( IGxContext context ,
                                             string AV70Core_auditwwds_1_filterfulltext ,
                                             string AV71Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV72Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV73Core_auditwwds_4_auditdate1 ,
                                             DateTime AV74Core_auditwwds_5_auditdate_to1 ,
                                             bool AV75Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV76Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV77Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV78Core_auditwwds_9_auditdate2 ,
                                             DateTime AV79Core_auditwwds_10_auditdate_to2 ,
                                             bool AV80Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV81Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV82Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV83Core_auditwwds_14_auditdate3 ,
                                             DateTime AV84Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV85Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV86Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV87Core_auditwwds_18_tfauditdate ,
                                             DateTime AV88Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV89Core_auditwwds_20_tfaudittime ,
                                             DateTime AV90Core_auditwwds_21_tfaudittime_to ,
                                             string AV92Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV91Core_auditwwds_22_tfaudittablename ,
                                             string AV94Core_auditwwds_25_tfauditaction_sel ,
                                             string AV93Core_auditwwds_24_tfauditaction ,
                                             string AV96Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV95Core_auditwwds_26_tfauditshortdescription ,
                                             string AV98Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV97Core_auditwwds_28_tfauditdescription ,
                                             string AV100Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV99Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[36];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT AuditTime, AuditDateTime, AuditDate, AuditGAMUserName, AuditDescription, AuditShortDescription, AuditAction, AuditTableName, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV70Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV70Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV70Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV70Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV70Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV72Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV73Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV73Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV72Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV74Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV74Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV72Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV73Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV73Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV72Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV73Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV73Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV72Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV73Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV73Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV75Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV77Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV78Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV78Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV75Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV77Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV79Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV79Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV75Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV77Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV78Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV78Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV75Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV77Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV78Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV78Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV75Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV77Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV78Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV78Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV80Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV82Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV83Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV83Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV80Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV82Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV84Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV84Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV80Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV82Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV83Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV83Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV80Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV82Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV83Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV83Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV80Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV82Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV83Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV83Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV85Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV86Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV87Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV88Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV89Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV90Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV91Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV92Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV92Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( StringUtil.StrCmp(AV92Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV93Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV94Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV95Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV96Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV97Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV98Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV98Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( StringUtil.StrCmp(AV98Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV99Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV100Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV100Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditDateTime";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditDateTime DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditDate";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditDate DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditTime";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditTime DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditTableName";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditTableName DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditAction";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditAction DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditShortDescription";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditShortDescription DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditDescription";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditDescription DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditGAMUserName";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditGAMUserName DESC";
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
                     return conditional_P007L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] );
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
          Object[] prmP007L2;
          prmP007L2 = new Object[] {
          new ParDef("lV70Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV73Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV74Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV73Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV73Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV73Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV78Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV79Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV78Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV78Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV78Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV83Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV84Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV83Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV83Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV83Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV86Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV87Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV88Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV89Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV90Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV91Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV92Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV93Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV94Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV96Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV97Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV98Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV99Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV100Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
