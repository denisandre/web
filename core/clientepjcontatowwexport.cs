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
   public class clientepjcontatowwexport : GXProcedure
   {
      public clientepjcontatowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjcontatowwexport( IGxContext context )
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
         clientepjcontatowwexport objclientepjcontatowwexport;
         objclientepjcontatowwexport = new clientepjcontatowwexport();
         objclientepjcontatowwexport.AV12Filename = "" ;
         objclientepjcontatowwexport.AV13ErrorMessage = "" ;
         objclientepjcontatowwexport.context.SetSubmitInitialConfig(context);
         objclientepjcontatowwexport.initialize();
         Submit( executePrivateCatch,objclientepjcontatowwexport);
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientepjcontatowwexport)stateInfo).executePrivate();
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
         AV12Filename = GXt_char1 + "ClientePJContatoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CPJCONNOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV22CpjConNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CpjConNome1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22CpjConNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CPJTIPONOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV23CpjTipoNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CpjTipoNome1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23CpjTipoNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CPJCONTIPONOME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV24CpjConTipoNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CpjConTipoNome1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24CpjConTipoNome1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CPJCONGENSIGLA") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV25CpjConGenSigla1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CpjConGenSigla1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Gênero", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Gênero", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25CpjConGenSigla1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV26DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV27DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CPJCONNOME") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV29CpjConNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CpjConNome2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29CpjConNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CPJTIPONOME") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV30CpjTipoNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CpjTipoNome2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30CpjTipoNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CPJCONTIPONOME") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV31CpjConTipoNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31CpjConTipoNome2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31CpjConTipoNome2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CPJCONGENSIGLA") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV32CpjConGenSigla2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32CpjConGenSigla2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Gênero", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Gênero", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32CpjConGenSigla2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV33DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV34DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CPJCONNOME") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV36CpjConNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36CpjConNome3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36CpjConNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CPJTIPONOME") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV37CpjTipoNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37CpjTipoNome3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37CpjTipoNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CPJCONTIPONOME") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV38CpjConTipoNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38CpjConTipoNome3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38CpjConTipoNome3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CPJCONGENSIGLA") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV39CpjConGenSigla3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39CpjConGenSigla3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Gênero", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Gênero", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39CpjConGenSigla3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCpjConNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCpjConNome_Sel)) ? "(Vazio)" : AV57TFCpjConNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCpjConNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFCpjConNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFCpjConNomePrim_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Primeiro Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV59TFCpjConNomePrim_Sel)) ? "(Vazio)" : AV59TFCpjConNomePrim_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFCpjConNomePrim)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Primeiro Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58TFCpjConNomePrim, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFCpjConSobrenome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sobrenome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFCpjConSobrenome_Sel)) ? "(Vazio)" : AV61TFCpjConSobrenome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFCpjConSobrenome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Sobrenome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFCpjConSobrenome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCpjConTipoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo do Contato") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCpjConTipoNome_Sel)) ? "(Vazio)" : AV63TFCpjConTipoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFCpjConTipoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo do Contato") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFCpjConTipoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCpjConCPFFormat_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "CPF") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCpjConCPFFormat_Sel)) ? "(Vazio)" : AV65TFCpjConCPFFormat_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCpjConCPFFormat)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "CPF") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TFCpjConCPFFormat, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV66TFCpjConNascimento) && (DateTime.MinValue==AV67TFCpjConNascimento_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Dt. Nascimento") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV66TFCpjConNascimento ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV67TFCpjConNascimento_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCpjConGenNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Gênero") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCpjConGenNome_Sel)) ? "(Vazio)" : AV69TFCpjConGenNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCpjConGenNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Gênero") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV68TFCpjConGenNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCpjConCelNum_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Celular") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCpjConCelNum_Sel)) ? "(Vazio)" : AV71TFCpjConCelNum_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCpjConCelNum)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Celular") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV70TFCpjConCelNum, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCpjConTelNum_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Telefone") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCpjConTelNum_Sel)) ? "(Vazio)" : AV73TFCpjConTelNum_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCpjConTelNum)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Telefone") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV72TFCpjConTelNum, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCpjConTelRam_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ramal") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCpjConTelRam_Sel)) ? "(Vazio)" : AV75TFCpjConTelRam_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCpjConTelRam)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ramal") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV74TFCpjConTelRam, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV93TFCpjConWppNum_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "WhatsApp") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV93TFCpjConWppNum_Sel)) ? "(Vazio)" : AV93TFCpjConWppNum_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV92TFCpjConWppNum)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "WhatsApp") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV92TFCpjConWppNum, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCpjConEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "E-mail") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCpjConEmail_Sel)) ? "(Vazio)" : AV77TFCpjConEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCpjConEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "E-mail") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV76TFCpjConEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCpjConLIn_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "LinkedIn") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCpjConLIn_Sel)) ? "(Vazio)" : AV79TFCpjConLIn_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV78TFCpjConLIn)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "LinkedIn") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV78TFCpjConLIn, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV83TFCliNomeFamiliar_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome Familiar") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV83TFCliNomeFamiliar_Sel)) ? "(Vazio)" : AV83TFCliNomeFamiliar_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV82TFCliNomeFamiliar)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome Familiar") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV82TFCliNomeFamiliar, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV80TFCliMatricula) && (0==AV81TFCliMatricula_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Matrícula") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV80TFCliMatricula;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV81TFCliMatricula_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFCpjTipoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV85TFCpjTipoNome_Sel)) ? "(Vazio)" : AV85TFCpjTipoNome_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV84TFCpjTipoNome)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Tipo") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84TFCpjTipoNome, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV87TFCpjNomeFan_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome Fantasia") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV87TFCpjNomeFan_Sel)) ? "(Vazio)" : AV87TFCpjNomeFan_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV86TFCpjNomeFan)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome Fantasia") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV86TFCpjNomeFan, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV89TFCpjRazaoSoc_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Razão Social") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV89TFCpjRazaoSoc_Sel)) ? "(Vazio)" : AV89TFCpjRazaoSoc_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV88TFCpjRazaoSoc)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Razão Social") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV88TFCpjRazaoSoc, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV95TFCpjMatricula) && (0==AV96TFCpjMatricula_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Matrícula") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV95TFCpjMatricula;
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "Até") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV96TFCpjMatricula_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV98TFCpjCNPJFormat_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "CNPJ") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV98TFCpjCNPJFormat_Sel)) ? "(Vazio)" : AV98TFCpjCNPJFormat_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV97TFCpjCNPJFormat)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "CNPJ") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV97TFCpjCNPJFormat, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV100TFCpjIE_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "IE") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV100TFCpjIE_Sel)) ? "(Vazio)" : AV100TFCpjIE_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV99TFCpjIE)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "IE") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV99TFCpjIE, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV102TFCpjCelNum_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Celular") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV102TFCpjCelNum_Sel)) ? "(Vazio)" : AV102TFCpjCelNum_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV101TFCpjCelNum)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Celular") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV101TFCpjCelNum, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV104TFCpjTelNum_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Telefone") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV104TFCpjTelNum_Sel)) ? "(Vazio)" : AV104TFCpjTelNum_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV103TFCpjTelNum)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Telefone") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV103TFCpjTelNum, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV106TFCpjTelRam_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ramal do Telefone") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV106TFCpjTelRam_Sel)) ? "(Vazio)" : AV106TFCpjTelRam_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV105TFCpjTelRam)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Ramal do Telefone") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV105TFCpjTelRam, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV108TFCpjWppNum_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "WhatsApp") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV108TFCpjWppNum_Sel)) ? "(Vazio)" : AV108TFCpjWppNum_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV107TFCpjWppNum)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "WhatsApp") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV107TFCpjWppNum, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV110TFCpjEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "E-mail") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV110TFCpjEmail_Sel)) ? "(Vazio)" : AV110TFCpjEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV109TFCpjEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "E-mail") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV109TFCpjEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV112TFCpjWebsite_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Website") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV112TFCpjWebsite_Sel)) ? "(Vazio)" : AV112TFCpjWebsite_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV111TFCpjWebsite)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Website") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV111TFCpjWebsite, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV53VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV41Session.Get("core.ClientePJContatoWWColumnsSelector"), "") != 0 )
         {
            AV48ColumnsSelectorXML = AV41Session.Get("core.ClientePJContatoWWColumnsSelector");
            AV45ColumnsSelector.FromXml(AV48ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV45ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV113GXV1 = 1;
         while ( AV113GXV1 <= AV45ColumnsSelector.gxTpr_Columns.Count )
         {
            AV47ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV45ColumnsSelector.gxTpr_Columns.Item(AV113GXV1));
            if ( AV47ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV47ColumnsSelector_Column.gxTpr_Displayname)) ? AV47ColumnsSelector_Column.gxTpr_Columnname : AV47ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Color = 11;
               AV53VisibleColumnCount = (long)(AV53VisibleColumnCount+1);
            }
            AV113GXV1 = (int)(AV113GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV115Core_clientepjcontatowwds_1_filterfulltext = AV19FilterFullText;
         AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV118Core_clientepjcontatowwds_4_cpjconnome1 = AV22CpjConNome1;
         AV119Core_clientepjcontatowwds_5_cpjtiponome1 = AV23CpjTipoNome1;
         AV120Core_clientepjcontatowwds_6_cpjcontiponome1 = AV24CpjConTipoNome1;
         AV121Core_clientepjcontatowwds_7_cpjcongensigla1 = AV25CpjConGenSigla1;
         AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV26DynamicFiltersEnabled2;
         AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV27DynamicFiltersSelector2;
         AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV28DynamicFiltersOperator2;
         AV125Core_clientepjcontatowwds_11_cpjconnome2 = AV29CpjConNome2;
         AV126Core_clientepjcontatowwds_12_cpjtiponome2 = AV30CpjTipoNome2;
         AV127Core_clientepjcontatowwds_13_cpjcontiponome2 = AV31CpjConTipoNome2;
         AV128Core_clientepjcontatowwds_14_cpjcongensigla2 = AV32CpjConGenSigla2;
         AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV33DynamicFiltersEnabled3;
         AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV34DynamicFiltersSelector3;
         AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV35DynamicFiltersOperator3;
         AV132Core_clientepjcontatowwds_18_cpjconnome3 = AV36CpjConNome3;
         AV133Core_clientepjcontatowwds_19_cpjtiponome3 = AV37CpjTipoNome3;
         AV134Core_clientepjcontatowwds_20_cpjcontiponome3 = AV38CpjConTipoNome3;
         AV135Core_clientepjcontatowwds_21_cpjcongensigla3 = AV39CpjConGenSigla3;
         AV136Core_clientepjcontatowwds_22_tfcpjconnome = AV56TFCpjConNome;
         AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV57TFCpjConNome_Sel;
         AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV58TFCpjConNomePrim;
         AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV59TFCpjConNomePrim_Sel;
         AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV60TFCpjConSobrenome;
         AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV61TFCpjConSobrenome_Sel;
         AV142Core_clientepjcontatowwds_28_tfcpjcontiponome = AV62TFCpjConTipoNome;
         AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV63TFCpjConTipoNome_Sel;
         AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV64TFCpjConCPFFormat;
         AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV65TFCpjConCPFFormat_Sel;
         AV146Core_clientepjcontatowwds_32_tfcpjconnascimento = AV66TFCpjConNascimento;
         AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV67TFCpjConNascimento_To;
         AV148Core_clientepjcontatowwds_34_tfcpjcongennome = AV68TFCpjConGenNome;
         AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV69TFCpjConGenNome_Sel;
         AV150Core_clientepjcontatowwds_36_tfcpjconcelnum = AV70TFCpjConCelNum;
         AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV71TFCpjConCelNum_Sel;
         AV152Core_clientepjcontatowwds_38_tfcpjcontelnum = AV72TFCpjConTelNum;
         AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV73TFCpjConTelNum_Sel;
         AV154Core_clientepjcontatowwds_40_tfcpjcontelram = AV74TFCpjConTelRam;
         AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV75TFCpjConTelRam_Sel;
         AV156Core_clientepjcontatowwds_42_tfcpjconwppnum = AV92TFCpjConWppNum;
         AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV93TFCpjConWppNum_Sel;
         AV158Core_clientepjcontatowwds_44_tfcpjconemail = AV76TFCpjConEmail;
         AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV77TFCpjConEmail_Sel;
         AV160Core_clientepjcontatowwds_46_tfcpjconlin = AV78TFCpjConLIn;
         AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV79TFCpjConLIn_Sel;
         AV162Core_clientepjcontatowwds_48_tfclinomefamiliar = AV82TFCliNomeFamiliar;
         AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV83TFCliNomeFamiliar_Sel;
         AV164Core_clientepjcontatowwds_50_tfclimatricula = AV80TFCliMatricula;
         AV165Core_clientepjcontatowwds_51_tfclimatricula_to = AV81TFCliMatricula_To;
         AV166Core_clientepjcontatowwds_52_tfcpjtiponome = AV84TFCpjTipoNome;
         AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV85TFCpjTipoNome_Sel;
         AV168Core_clientepjcontatowwds_54_tfcpjnomefan = AV86TFCpjNomeFan;
         AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV87TFCpjNomeFan_Sel;
         AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV88TFCpjRazaoSoc;
         AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV89TFCpjRazaoSoc_Sel;
         AV172Core_clientepjcontatowwds_58_tfcpjmatricula = AV95TFCpjMatricula;
         AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV96TFCpjMatricula_To;
         AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV97TFCpjCNPJFormat;
         AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV98TFCpjCNPJFormat_Sel;
         AV176Core_clientepjcontatowwds_62_tfcpjie = AV99TFCpjIE;
         AV177Core_clientepjcontatowwds_63_tfcpjie_sel = AV100TFCpjIE_Sel;
         AV178Core_clientepjcontatowwds_64_tfcpjcelnum = AV101TFCpjCelNum;
         AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV102TFCpjCelNum_Sel;
         AV180Core_clientepjcontatowwds_66_tfcpjtelnum = AV103TFCpjTelNum;
         AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV104TFCpjTelNum_Sel;
         AV182Core_clientepjcontatowwds_68_tfcpjtelram = AV105TFCpjTelRam;
         AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV106TFCpjTelRam_Sel;
         AV184Core_clientepjcontatowwds_70_tfcpjwppnum = AV107TFCpjWppNum;
         AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV108TFCpjWppNum_Sel;
         AV186Core_clientepjcontatowwds_72_tfcpjemail = AV109TFCpjEmail;
         AV187Core_clientepjcontatowwds_73_tfcpjemail_sel = AV110TFCpjEmail_Sel;
         AV188Core_clientepjcontatowwds_74_tfcpjwebsite = AV111TFCpjWebsite;
         AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV112TFCpjWebsite_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV115Core_clientepjcontatowwds_1_filterfulltext ,
                                              AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                              AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                              AV118Core_clientepjcontatowwds_4_cpjconnome1 ,
                                              AV119Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                              AV120Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                              AV121Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                              AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                              AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                              AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                              AV125Core_clientepjcontatowwds_11_cpjconnome2 ,
                                              AV126Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                              AV127Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                              AV128Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                              AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                              AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                              AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                              AV132Core_clientepjcontatowwds_18_cpjconnome3 ,
                                              AV133Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                              AV134Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                              AV135Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                              AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                              AV136Core_clientepjcontatowwds_22_tfcpjconnome ,
                                              AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                              AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                              AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                              AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                              AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                              AV142Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                              AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                              AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                              AV146Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                              AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                              AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                              AV148Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                              AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                              AV150Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                              AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                              AV152Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                              AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                              AV154Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                              AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                              AV156Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                              AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                              AV158Core_clientepjcontatowwds_44_tfcpjconemail ,
                                              AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                              AV160Core_clientepjcontatowwds_46_tfcpjconlin ,
                                              AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                              AV162Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                              AV164Core_clientepjcontatowwds_50_tfclimatricula ,
                                              AV165Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                              AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                              AV166Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                              AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                              AV168Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                              AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                              AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                              AV172Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                              AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                              AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                              AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                              AV177Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                              AV176Core_clientepjcontatowwds_62_tfcpjie ,
                                              AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                              AV178Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                              AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                              AV180Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                              AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                              AV182Core_clientepjcontatowwds_68_tfcpjtelram ,
                                              AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                              AV184Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                              AV187Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                              AV186Core_clientepjcontatowwds_72_tfcpjemail ,
                                              AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                              AV188Core_clientepjcontatowwds_74_tfcpjwebsite ,
                                              A275CpjConNome ,
                                              A276CpjConNomePrim ,
                                              A277CpjConSobrenome ,
                                              A272CpjConTipoNome ,
                                              A274CpjConCPFFormat ,
                                              A281CpjConGenNome ,
                                              A285CpjConCelNum ,
                                              A283CpjConTelNum ,
                                              A284CpjConTelRam ,
                                              A286CpjConWppNum ,
                                              A287CpjConEmail ,
                                              A288CpjConLIn ,
                                              A160CliNomeFamiliar ,
                                              A159CliMatricula ,
                                              A367CpjTipoNome ,
                                              A170CpjNomeFan ,
                                              A171CpjRazaoSoc ,
                                              A176CpjMatricula ,
                                              A188CpjCNPJFormat ,
                                              A189CpjIE ,
                                              A263CpjCelNum ,
                                              A261CpjTelNum ,
                                              A262CpjTelRam ,
                                              A264CpjWppNum ,
                                              A266CpjEmail ,
                                              A265CpjWebsite ,
                                              A280CpjConGenSigla ,
                                              A282CpjConNascimento ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV115Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV118Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV118Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
         lV118Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV118Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
         lV119Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV119Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
         lV119Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV119Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
         lV120Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV120Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
         lV120Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV120Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
         lV121Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV121Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
         lV121Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV121Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
         lV125Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV125Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
         lV125Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV125Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
         lV126Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
         lV126Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
         lV127Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV127Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
         lV127Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV127Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
         lV128Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV128Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
         lV128Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV128Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
         lV132Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV132Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
         lV132Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV132Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
         lV133Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV133Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
         lV133Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV133Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
         lV134Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV134Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
         lV134Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV134Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
         lV135Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV135Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
         lV135Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV135Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
         lV136Core_clientepjcontatowwds_22_tfcpjconnome = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_22_tfcpjconnome), "%", "");
         lV138Core_clientepjcontatowwds_24_tfcpjconnomeprim = StringUtil.Concat( StringUtil.RTrim( AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim), "%", "");
         lV140Core_clientepjcontatowwds_26_tfcpjconsobrenome = StringUtil.Concat( StringUtil.RTrim( AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome), "%", "");
         lV142Core_clientepjcontatowwds_28_tfcpjcontiponome = StringUtil.Concat( StringUtil.RTrim( AV142Core_clientepjcontatowwds_28_tfcpjcontiponome), "%", "");
         lV144Core_clientepjcontatowwds_30_tfcpjconcpfformat = StringUtil.Concat( StringUtil.RTrim( AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat), "%", "");
         lV148Core_clientepjcontatowwds_34_tfcpjcongennome = StringUtil.Concat( StringUtil.RTrim( AV148Core_clientepjcontatowwds_34_tfcpjcongennome), "%", "");
         lV150Core_clientepjcontatowwds_36_tfcpjconcelnum = StringUtil.PadR( StringUtil.RTrim( AV150Core_clientepjcontatowwds_36_tfcpjconcelnum), 20, "%");
         lV152Core_clientepjcontatowwds_38_tfcpjcontelnum = StringUtil.PadR( StringUtil.RTrim( AV152Core_clientepjcontatowwds_38_tfcpjcontelnum), 20, "%");
         lV154Core_clientepjcontatowwds_40_tfcpjcontelram = StringUtil.Concat( StringUtil.RTrim( AV154Core_clientepjcontatowwds_40_tfcpjcontelram), "%", "");
         lV156Core_clientepjcontatowwds_42_tfcpjconwppnum = StringUtil.PadR( StringUtil.RTrim( AV156Core_clientepjcontatowwds_42_tfcpjconwppnum), 20, "%");
         lV158Core_clientepjcontatowwds_44_tfcpjconemail = StringUtil.Concat( StringUtil.RTrim( AV158Core_clientepjcontatowwds_44_tfcpjconemail), "%", "");
         lV160Core_clientepjcontatowwds_46_tfcpjconlin = StringUtil.Concat( StringUtil.RTrim( AV160Core_clientepjcontatowwds_46_tfcpjconlin), "%", "");
         lV162Core_clientepjcontatowwds_48_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV162Core_clientepjcontatowwds_48_tfclinomefamiliar), "%", "");
         lV166Core_clientepjcontatowwds_52_tfcpjtiponome = StringUtil.Concat( StringUtil.RTrim( AV166Core_clientepjcontatowwds_52_tfcpjtiponome), "%", "");
         lV168Core_clientepjcontatowwds_54_tfcpjnomefan = StringUtil.Concat( StringUtil.RTrim( AV168Core_clientepjcontatowwds_54_tfcpjnomefan), "%", "");
         lV170Core_clientepjcontatowwds_56_tfcpjrazaosoc = StringUtil.Concat( StringUtil.RTrim( AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc), "%", "");
         lV174Core_clientepjcontatowwds_60_tfcpjcnpjformat = StringUtil.Concat( StringUtil.RTrim( AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat), "%", "");
         lV176Core_clientepjcontatowwds_62_tfcpjie = StringUtil.Concat( StringUtil.RTrim( AV176Core_clientepjcontatowwds_62_tfcpjie), "%", "");
         lV178Core_clientepjcontatowwds_64_tfcpjcelnum = StringUtil.PadR( StringUtil.RTrim( AV178Core_clientepjcontatowwds_64_tfcpjcelnum), 20, "%");
         lV180Core_clientepjcontatowwds_66_tfcpjtelnum = StringUtil.PadR( StringUtil.RTrim( AV180Core_clientepjcontatowwds_66_tfcpjtelnum), 20, "%");
         lV182Core_clientepjcontatowwds_68_tfcpjtelram = StringUtil.Concat( StringUtil.RTrim( AV182Core_clientepjcontatowwds_68_tfcpjtelram), "%", "");
         lV184Core_clientepjcontatowwds_70_tfcpjwppnum = StringUtil.PadR( StringUtil.RTrim( AV184Core_clientepjcontatowwds_70_tfcpjwppnum), 20, "%");
         lV186Core_clientepjcontatowwds_72_tfcpjemail = StringUtil.Concat( StringUtil.RTrim( AV186Core_clientepjcontatowwds_72_tfcpjemail), "%", "");
         lV188Core_clientepjcontatowwds_74_tfcpjwebsite = StringUtil.Concat( StringUtil.RTrim( AV188Core_clientepjcontatowwds_74_tfcpjwebsite), "%", "");
         /* Using cursor P005W2 */
         pr_default.execute(0, new Object[] {lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV115Core_clientepjcontatowwds_1_filterfulltext, lV118Core_clientepjcontatowwds_4_cpjconnome1, lV118Core_clientepjcontatowwds_4_cpjconnome1, lV119Core_clientepjcontatowwds_5_cpjtiponome1, lV119Core_clientepjcontatowwds_5_cpjtiponome1, lV120Core_clientepjcontatowwds_6_cpjcontiponome1, lV120Core_clientepjcontatowwds_6_cpjcontiponome1, lV121Core_clientepjcontatowwds_7_cpjcongensigla1, lV121Core_clientepjcontatowwds_7_cpjcongensigla1, lV125Core_clientepjcontatowwds_11_cpjconnome2, lV125Core_clientepjcontatowwds_11_cpjconnome2, lV126Core_clientepjcontatowwds_12_cpjtiponome2, lV126Core_clientepjcontatowwds_12_cpjtiponome2, lV127Core_clientepjcontatowwds_13_cpjcontiponome2, lV127Core_clientepjcontatowwds_13_cpjcontiponome2, lV128Core_clientepjcontatowwds_14_cpjcongensigla2, lV128Core_clientepjcontatowwds_14_cpjcongensigla2, lV132Core_clientepjcontatowwds_18_cpjconnome3, lV132Core_clientepjcontatowwds_18_cpjconnome3, lV133Core_clientepjcontatowwds_19_cpjtiponome3, lV133Core_clientepjcontatowwds_19_cpjtiponome3, lV134Core_clientepjcontatowwds_20_cpjcontiponome3, lV134Core_clientepjcontatowwds_20_cpjcontiponome3, lV135Core_clientepjcontatowwds_21_cpjcongensigla3, lV135Core_clientepjcontatowwds_21_cpjcongensigla3, lV136Core_clientepjcontatowwds_22_tfcpjconnome, AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel, lV138Core_clientepjcontatowwds_24_tfcpjconnomeprim, AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, lV140Core_clientepjcontatowwds_26_tfcpjconsobrenome, AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, lV142Core_clientepjcontatowwds_28_tfcpjcontiponome, AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, lV144Core_clientepjcontatowwds_30_tfcpjconcpfformat, AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, AV146Core_clientepjcontatowwds_32_tfcpjconnascimento, AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to, lV148Core_clientepjcontatowwds_34_tfcpjcongennome, AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel, lV150Core_clientepjcontatowwds_36_tfcpjconcelnum, AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, lV152Core_clientepjcontatowwds_38_tfcpjcontelnum, AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, lV154Core_clientepjcontatowwds_40_tfcpjcontelram, AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel, lV156Core_clientepjcontatowwds_42_tfcpjconwppnum, AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, lV158Core_clientepjcontatowwds_44_tfcpjconemail, AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel, lV160Core_clientepjcontatowwds_46_tfcpjconlin, AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel, lV162Core_clientepjcontatowwds_48_tfclinomefamiliar, AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, AV164Core_clientepjcontatowwds_50_tfclimatricula, AV165Core_clientepjcontatowwds_51_tfclimatricula_to, lV166Core_clientepjcontatowwds_52_tfcpjtiponome, AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel, lV168Core_clientepjcontatowwds_54_tfcpjnomefan, AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel, lV170Core_clientepjcontatowwds_56_tfcpjrazaosoc, AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, AV172Core_clientepjcontatowwds_58_tfcpjmatricula, AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to, lV174Core_clientepjcontatowwds_60_tfcpjcnpjformat, AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, lV176Core_clientepjcontatowwds_62_tfcpjie, AV177Core_clientepjcontatowwds_63_tfcpjie_sel, lV178Core_clientepjcontatowwds_64_tfcpjcelnum, AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel, lV180Core_clientepjcontatowwds_66_tfcpjtelnum, AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel, lV182Core_clientepjcontatowwds_68_tfcpjtelram, AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel, lV184Core_clientepjcontatowwds_70_tfcpjwppnum, AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel, lV186Core_clientepjcontatowwds_72_tfcpjemail, AV187Core_clientepjcontatowwds_73_tfcpjemail_sel, lV188Core_clientepjcontatowwds_74_tfcpjwebsite, AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A158CliID = P005W2_A158CliID[0];
            A166CpjID = P005W2_A166CpjID[0];
            A365CpjTipoId = P005W2_A365CpjTipoId[0];
            A176CpjMatricula = P005W2_A176CpjMatricula[0];
            A159CliMatricula = P005W2_A159CliMatricula[0];
            A282CpjConNascimento = P005W2_A282CpjConNascimento[0];
            A280CpjConGenSigla = P005W2_A280CpjConGenSigla[0];
            A265CpjWebsite = P005W2_A265CpjWebsite[0];
            n265CpjWebsite = P005W2_n265CpjWebsite[0];
            A266CpjEmail = P005W2_A266CpjEmail[0];
            n266CpjEmail = P005W2_n266CpjEmail[0];
            A264CpjWppNum = P005W2_A264CpjWppNum[0];
            n264CpjWppNum = P005W2_n264CpjWppNum[0];
            A262CpjTelRam = P005W2_A262CpjTelRam[0];
            n262CpjTelRam = P005W2_n262CpjTelRam[0];
            A261CpjTelNum = P005W2_A261CpjTelNum[0];
            n261CpjTelNum = P005W2_n261CpjTelNum[0];
            A263CpjCelNum = P005W2_A263CpjCelNum[0];
            n263CpjCelNum = P005W2_n263CpjCelNum[0];
            A189CpjIE = P005W2_A189CpjIE[0];
            A188CpjCNPJFormat = P005W2_A188CpjCNPJFormat[0];
            A171CpjRazaoSoc = P005W2_A171CpjRazaoSoc[0];
            A170CpjNomeFan = P005W2_A170CpjNomeFan[0];
            A367CpjTipoNome = P005W2_A367CpjTipoNome[0];
            A160CliNomeFamiliar = P005W2_A160CliNomeFamiliar[0];
            A288CpjConLIn = P005W2_A288CpjConLIn[0];
            n288CpjConLIn = P005W2_n288CpjConLIn[0];
            A287CpjConEmail = P005W2_A287CpjConEmail[0];
            n287CpjConEmail = P005W2_n287CpjConEmail[0];
            A286CpjConWppNum = P005W2_A286CpjConWppNum[0];
            n286CpjConWppNum = P005W2_n286CpjConWppNum[0];
            A284CpjConTelRam = P005W2_A284CpjConTelRam[0];
            n284CpjConTelRam = P005W2_n284CpjConTelRam[0];
            A283CpjConTelNum = P005W2_A283CpjConTelNum[0];
            n283CpjConTelNum = P005W2_n283CpjConTelNum[0];
            A285CpjConCelNum = P005W2_A285CpjConCelNum[0];
            n285CpjConCelNum = P005W2_n285CpjConCelNum[0];
            A281CpjConGenNome = P005W2_A281CpjConGenNome[0];
            A274CpjConCPFFormat = P005W2_A274CpjConCPFFormat[0];
            A272CpjConTipoNome = P005W2_A272CpjConTipoNome[0];
            A277CpjConSobrenome = P005W2_A277CpjConSobrenome[0];
            A276CpjConNomePrim = P005W2_A276CpjConNomePrim[0];
            A275CpjConNome = P005W2_A275CpjConNome[0];
            A269CpjConSeq = P005W2_A269CpjConSeq[0];
            A159CliMatricula = P005W2_A159CliMatricula[0];
            A160CliNomeFamiliar = P005W2_A160CliNomeFamiliar[0];
            A365CpjTipoId = P005W2_A365CpjTipoId[0];
            A176CpjMatricula = P005W2_A176CpjMatricula[0];
            A265CpjWebsite = P005W2_A265CpjWebsite[0];
            n265CpjWebsite = P005W2_n265CpjWebsite[0];
            A266CpjEmail = P005W2_A266CpjEmail[0];
            n266CpjEmail = P005W2_n266CpjEmail[0];
            A264CpjWppNum = P005W2_A264CpjWppNum[0];
            n264CpjWppNum = P005W2_n264CpjWppNum[0];
            A262CpjTelRam = P005W2_A262CpjTelRam[0];
            n262CpjTelRam = P005W2_n262CpjTelRam[0];
            A261CpjTelNum = P005W2_A261CpjTelNum[0];
            n261CpjTelNum = P005W2_n261CpjTelNum[0];
            A263CpjCelNum = P005W2_A263CpjCelNum[0];
            n263CpjCelNum = P005W2_n263CpjCelNum[0];
            A189CpjIE = P005W2_A189CpjIE[0];
            A188CpjCNPJFormat = P005W2_A188CpjCNPJFormat[0];
            A171CpjRazaoSoc = P005W2_A171CpjRazaoSoc[0];
            A170CpjNomeFan = P005W2_A170CpjNomeFan[0];
            A367CpjTipoNome = P005W2_A367CpjTipoNome[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV53VisibleColumnCount = 0;
            AV190GXV2 = 1;
            while ( AV190GXV2 <= AV45ColumnsSelector.gxTpr_Columns.Count )
            {
               AV47ColumnsSelector_Column = ((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV45ColumnsSelector.gxTpr_Columns.Item(AV190GXV2));
               if ( AV47ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A275CpjConNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConNomePrim") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A276CpjConNomePrim, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConSobrenome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A277CpjConSobrenome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConTipoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A272CpjConTipoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConCPFFormat") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A274CpjConCPFFormat, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConNascimento") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A282CpjConNascimento ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConGenNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A281CpjConGenNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConCelNum") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A285CpjConCelNum, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConTelNum") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A283CpjConTelNum, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConTelRam") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A284CpjConTelRam, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConWppNum") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A286CpjConWppNum, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConEmail") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A287CpjConEmail, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjConLIn") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A288CpjConLIn, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CliNomeFamiliar") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A160CliNomeFamiliar, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CliMatricula") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Number = A159CliMatricula;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjTipoNome") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A367CpjTipoNome, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjNomeFan") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170CpjNomeFan, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjRazaoSoc") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A171CpjRazaoSoc, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjMatricula") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Number = A176CpjMatricula;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjCNPJFormat") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A188CpjCNPJFormat, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjIE") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A189CpjIE, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjCelNum") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A263CpjCelNum, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjTelNum") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A261CpjTelNum, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjTelRam") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A262CpjTelRam, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjWppNum") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A264CpjWppNum, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjEmail") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A266CpjEmail, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV47ColumnsSelector_Column.gxTpr_Columnname, "CpjWebsite") == 0 )
                  {
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A265CpjWebsite, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV53VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV53VisibleColumnCount = (long)(AV53VisibleColumnCount+1);
               }
               AV190GXV2 = (int)(AV190GXV2+1);
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
         AV41Session.Set("WWPExportFilePath", AV12Filename);
         AV41Session.Set("WWPExportFileName", "ClientePJContatoWWExport.xlsx");
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
         AV45ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConNomePrim",  "",  "Primeiro Nome",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConSobrenome",  "",  "Sobrenome",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConTipoNome",  "",  "Tipo do Contato",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConCPFFormat",  "",  "CPF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConNascimento",  "",  "Dt. Nascimento",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConGenNome",  "",  "Gênero",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConCelNum",  "",  "Celular",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConTelNum",  "",  "Telefone",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConTelRam",  "",  "Ramal",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConWppNum",  "",  "WhatsApp",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConEmail",  "",  "E-mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjConLIn",  "",  "LinkedIn",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CliNomeFamiliar",  "Cliente",  "Nome Familiar",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CliMatricula",  "Cliente",  "Matrícula",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjTipoNome",  "Unidade",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjNomeFan",  "Unidade",  "Nome Fantasia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjRazaoSoc",  "Unidade",  "Razão Social",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjMatricula",  "Unidade",  "Matrícula",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjCNPJFormat",  "Unidade",  "CNPJ",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjIE",  "Unidade",  "IE",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjCelNum",  "Unidade",  "Celular",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjTelNum",  "Unidade",  "Telefone",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjTelRam",  "Unidade",  "Ramal do Telefone",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjWppNum",  "Unidade",  "WhatsApp",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjEmail",  "Unidade",  "E-mail",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV45ColumnsSelector,  "CpjWebsite",  "Unidade",  "Website",  false,  "") ;
         GXt_char1 = AV49UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ClientePJContatoWWColumnsSelector", out  GXt_char1) ;
         AV49UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49UserCustomValue)) ) )
         {
            AV46ColumnsSelectorAux.FromXml(AV49UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV46ColumnsSelectorAux, ref  AV45ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("core.ClientePJContatoWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClientePJContatoWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("core.ClientePJContatoWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV43GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV43GridState.gxTpr_Ordereddsc;
         AV191GXV3 = 1;
         while ( AV191GXV3 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV191GXV3));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONNOME") == 0 )
            {
               AV56TFCpjConNome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONNOME_SEL") == 0 )
            {
               AV57TFCpjConNome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONNOMEPRIM") == 0 )
            {
               AV58TFCpjConNomePrim = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONNOMEPRIM_SEL") == 0 )
            {
               AV59TFCpjConNomePrim_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONSOBRENOME") == 0 )
            {
               AV60TFCpjConSobrenome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONSOBRENOME_SEL") == 0 )
            {
               AV61TFCpjConSobrenome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONTIPONOME") == 0 )
            {
               AV62TFCpjConTipoNome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONTIPONOME_SEL") == 0 )
            {
               AV63TFCpjConTipoNome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONCPFFORMAT") == 0 )
            {
               AV64TFCpjConCPFFormat = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONCPFFORMAT_SEL") == 0 )
            {
               AV65TFCpjConCPFFormat_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONNASCIMENTO") == 0 )
            {
               AV66TFCpjConNascimento = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Value, 2);
               AV67TFCpjConNascimento_To = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONGENNOME") == 0 )
            {
               AV68TFCpjConGenNome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONGENNOME_SEL") == 0 )
            {
               AV69TFCpjConGenNome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONCELNUM") == 0 )
            {
               AV70TFCpjConCelNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONCELNUM_SEL") == 0 )
            {
               AV71TFCpjConCelNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONTELNUM") == 0 )
            {
               AV72TFCpjConTelNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONTELNUM_SEL") == 0 )
            {
               AV73TFCpjConTelNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONTELRAM") == 0 )
            {
               AV74TFCpjConTelRam = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONTELRAM_SEL") == 0 )
            {
               AV75TFCpjConTelRam_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONWPPNUM") == 0 )
            {
               AV92TFCpjConWppNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONWPPNUM_SEL") == 0 )
            {
               AV93TFCpjConWppNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONEMAIL") == 0 )
            {
               AV76TFCpjConEmail = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONEMAIL_SEL") == 0 )
            {
               AV77TFCpjConEmail_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONLIN") == 0 )
            {
               AV78TFCpjConLIn = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCONLIN_SEL") == 0 )
            {
               AV79TFCpjConLIn_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR") == 0 )
            {
               AV82TFCliNomeFamiliar = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV83TFCliNomeFamiliar_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCLIMATRICULA") == 0 )
            {
               AV80TFCliMatricula = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV81TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJTIPONOME") == 0 )
            {
               AV84TFCpjTipoNome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJTIPONOME_SEL") == 0 )
            {
               AV85TFCpjTipoNome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJNOMEFAN") == 0 )
            {
               AV86TFCpjNomeFan = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJNOMEFAN_SEL") == 0 )
            {
               AV87TFCpjNomeFan_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJRAZAOSOC") == 0 )
            {
               AV88TFCpjRazaoSoc = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJRAZAOSOC_SEL") == 0 )
            {
               AV89TFCpjRazaoSoc_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJMATRICULA") == 0 )
            {
               AV95TFCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV96TFCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCNPJFORMAT") == 0 )
            {
               AV97TFCpjCNPJFormat = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCNPJFORMAT_SEL") == 0 )
            {
               AV98TFCpjCNPJFormat_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJIE") == 0 )
            {
               AV99TFCpjIE = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJIE_SEL") == 0 )
            {
               AV100TFCpjIE_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCELNUM") == 0 )
            {
               AV101TFCpjCelNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJCELNUM_SEL") == 0 )
            {
               AV102TFCpjCelNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJTELNUM") == 0 )
            {
               AV103TFCpjTelNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJTELNUM_SEL") == 0 )
            {
               AV104TFCpjTelNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJTELRAM") == 0 )
            {
               AV105TFCpjTelRam = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJTELRAM_SEL") == 0 )
            {
               AV106TFCpjTelRam_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJWPPNUM") == 0 )
            {
               AV107TFCpjWppNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJWPPNUM_SEL") == 0 )
            {
               AV108TFCpjWppNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJEMAIL") == 0 )
            {
               AV109TFCpjEmail = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJEMAIL_SEL") == 0 )
            {
               AV110TFCpjEmail_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJWEBSITE") == 0 )
            {
               AV111TFCpjWebsite = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCPJWEBSITE_SEL") == 0 )
            {
               AV112TFCpjWebsite_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            AV191GXV3 = (int)(AV191GXV3+1);
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
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22CpjConNome1 = "";
         AV23CpjTipoNome1 = "";
         AV24CpjConTipoNome1 = "";
         AV25CpjConGenSigla1 = "";
         AV27DynamicFiltersSelector2 = "";
         AV29CpjConNome2 = "";
         AV30CpjTipoNome2 = "";
         AV31CpjConTipoNome2 = "";
         AV32CpjConGenSigla2 = "";
         AV34DynamicFiltersSelector3 = "";
         AV36CpjConNome3 = "";
         AV37CpjTipoNome3 = "";
         AV38CpjConTipoNome3 = "";
         AV39CpjConGenSigla3 = "";
         AV57TFCpjConNome_Sel = "";
         AV56TFCpjConNome = "";
         AV59TFCpjConNomePrim_Sel = "";
         AV58TFCpjConNomePrim = "";
         AV61TFCpjConSobrenome_Sel = "";
         AV60TFCpjConSobrenome = "";
         AV63TFCpjConTipoNome_Sel = "";
         AV62TFCpjConTipoNome = "";
         AV65TFCpjConCPFFormat_Sel = "";
         AV64TFCpjConCPFFormat = "";
         AV66TFCpjConNascimento = DateTime.MinValue;
         AV67TFCpjConNascimento_To = DateTime.MinValue;
         AV69TFCpjConGenNome_Sel = "";
         AV68TFCpjConGenNome = "";
         AV71TFCpjConCelNum_Sel = "";
         AV70TFCpjConCelNum = "";
         AV73TFCpjConTelNum_Sel = "";
         AV72TFCpjConTelNum = "";
         AV75TFCpjConTelRam_Sel = "";
         AV74TFCpjConTelRam = "";
         AV93TFCpjConWppNum_Sel = "";
         AV92TFCpjConWppNum = "";
         AV77TFCpjConEmail_Sel = "";
         AV76TFCpjConEmail = "";
         AV79TFCpjConLIn_Sel = "";
         AV78TFCpjConLIn = "";
         AV83TFCliNomeFamiliar_Sel = "";
         AV82TFCliNomeFamiliar = "";
         AV85TFCpjTipoNome_Sel = "";
         AV84TFCpjTipoNome = "";
         AV87TFCpjNomeFan_Sel = "";
         AV86TFCpjNomeFan = "";
         AV89TFCpjRazaoSoc_Sel = "";
         AV88TFCpjRazaoSoc = "";
         AV98TFCpjCNPJFormat_Sel = "";
         AV97TFCpjCNPJFormat = "";
         AV100TFCpjIE_Sel = "";
         AV99TFCpjIE = "";
         AV102TFCpjCelNum_Sel = "";
         AV101TFCpjCelNum = "";
         AV104TFCpjTelNum_Sel = "";
         AV103TFCpjTelNum = "";
         AV106TFCpjTelRam_Sel = "";
         AV105TFCpjTelRam = "";
         AV108TFCpjWppNum_Sel = "";
         AV107TFCpjWppNum = "";
         AV110TFCpjEmail_Sel = "";
         AV109TFCpjEmail = "";
         AV112TFCpjWebsite_Sel = "";
         AV111TFCpjWebsite = "";
         AV41Session = context.GetSession();
         AV48ColumnsSelectorXML = "";
         AV45ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV47ColumnsSelector_Column = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column(context);
         AV115Core_clientepjcontatowwds_1_filterfulltext = "";
         AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1 = "";
         AV118Core_clientepjcontatowwds_4_cpjconnome1 = "";
         AV119Core_clientepjcontatowwds_5_cpjtiponome1 = "";
         AV120Core_clientepjcontatowwds_6_cpjcontiponome1 = "";
         AV121Core_clientepjcontatowwds_7_cpjcongensigla1 = "";
         AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2 = "";
         AV125Core_clientepjcontatowwds_11_cpjconnome2 = "";
         AV126Core_clientepjcontatowwds_12_cpjtiponome2 = "";
         AV127Core_clientepjcontatowwds_13_cpjcontiponome2 = "";
         AV128Core_clientepjcontatowwds_14_cpjcongensigla2 = "";
         AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3 = "";
         AV132Core_clientepjcontatowwds_18_cpjconnome3 = "";
         AV133Core_clientepjcontatowwds_19_cpjtiponome3 = "";
         AV134Core_clientepjcontatowwds_20_cpjcontiponome3 = "";
         AV135Core_clientepjcontatowwds_21_cpjcongensigla3 = "";
         AV136Core_clientepjcontatowwds_22_tfcpjconnome = "";
         AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel = "";
         AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim = "";
         AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = "";
         AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome = "";
         AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = "";
         AV142Core_clientepjcontatowwds_28_tfcpjcontiponome = "";
         AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = "";
         AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat = "";
         AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = "";
         AV146Core_clientepjcontatowwds_32_tfcpjconnascimento = DateTime.MinValue;
         AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to = DateTime.MinValue;
         AV148Core_clientepjcontatowwds_34_tfcpjcongennome = "";
         AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel = "";
         AV150Core_clientepjcontatowwds_36_tfcpjconcelnum = "";
         AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = "";
         AV152Core_clientepjcontatowwds_38_tfcpjcontelnum = "";
         AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = "";
         AV154Core_clientepjcontatowwds_40_tfcpjcontelram = "";
         AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel = "";
         AV156Core_clientepjcontatowwds_42_tfcpjconwppnum = "";
         AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = "";
         AV158Core_clientepjcontatowwds_44_tfcpjconemail = "";
         AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel = "";
         AV160Core_clientepjcontatowwds_46_tfcpjconlin = "";
         AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel = "";
         AV162Core_clientepjcontatowwds_48_tfclinomefamiliar = "";
         AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = "";
         AV166Core_clientepjcontatowwds_52_tfcpjtiponome = "";
         AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel = "";
         AV168Core_clientepjcontatowwds_54_tfcpjnomefan = "";
         AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel = "";
         AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc = "";
         AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = "";
         AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat = "";
         AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = "";
         AV176Core_clientepjcontatowwds_62_tfcpjie = "";
         AV177Core_clientepjcontatowwds_63_tfcpjie_sel = "";
         AV178Core_clientepjcontatowwds_64_tfcpjcelnum = "";
         AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel = "";
         AV180Core_clientepjcontatowwds_66_tfcpjtelnum = "";
         AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel = "";
         AV182Core_clientepjcontatowwds_68_tfcpjtelram = "";
         AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel = "";
         AV184Core_clientepjcontatowwds_70_tfcpjwppnum = "";
         AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel = "";
         AV186Core_clientepjcontatowwds_72_tfcpjemail = "";
         AV187Core_clientepjcontatowwds_73_tfcpjemail_sel = "";
         AV188Core_clientepjcontatowwds_74_tfcpjwebsite = "";
         AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel = "";
         scmdbuf = "";
         lV115Core_clientepjcontatowwds_1_filterfulltext = "";
         lV118Core_clientepjcontatowwds_4_cpjconnome1 = "";
         lV119Core_clientepjcontatowwds_5_cpjtiponome1 = "";
         lV120Core_clientepjcontatowwds_6_cpjcontiponome1 = "";
         lV121Core_clientepjcontatowwds_7_cpjcongensigla1 = "";
         lV125Core_clientepjcontatowwds_11_cpjconnome2 = "";
         lV126Core_clientepjcontatowwds_12_cpjtiponome2 = "";
         lV127Core_clientepjcontatowwds_13_cpjcontiponome2 = "";
         lV128Core_clientepjcontatowwds_14_cpjcongensigla2 = "";
         lV132Core_clientepjcontatowwds_18_cpjconnome3 = "";
         lV133Core_clientepjcontatowwds_19_cpjtiponome3 = "";
         lV134Core_clientepjcontatowwds_20_cpjcontiponome3 = "";
         lV135Core_clientepjcontatowwds_21_cpjcongensigla3 = "";
         lV136Core_clientepjcontatowwds_22_tfcpjconnome = "";
         lV138Core_clientepjcontatowwds_24_tfcpjconnomeprim = "";
         lV140Core_clientepjcontatowwds_26_tfcpjconsobrenome = "";
         lV142Core_clientepjcontatowwds_28_tfcpjcontiponome = "";
         lV144Core_clientepjcontatowwds_30_tfcpjconcpfformat = "";
         lV148Core_clientepjcontatowwds_34_tfcpjcongennome = "";
         lV150Core_clientepjcontatowwds_36_tfcpjconcelnum = "";
         lV152Core_clientepjcontatowwds_38_tfcpjcontelnum = "";
         lV154Core_clientepjcontatowwds_40_tfcpjcontelram = "";
         lV156Core_clientepjcontatowwds_42_tfcpjconwppnum = "";
         lV158Core_clientepjcontatowwds_44_tfcpjconemail = "";
         lV160Core_clientepjcontatowwds_46_tfcpjconlin = "";
         lV162Core_clientepjcontatowwds_48_tfclinomefamiliar = "";
         lV166Core_clientepjcontatowwds_52_tfcpjtiponome = "";
         lV168Core_clientepjcontatowwds_54_tfcpjnomefan = "";
         lV170Core_clientepjcontatowwds_56_tfcpjrazaosoc = "";
         lV174Core_clientepjcontatowwds_60_tfcpjcnpjformat = "";
         lV176Core_clientepjcontatowwds_62_tfcpjie = "";
         lV178Core_clientepjcontatowwds_64_tfcpjcelnum = "";
         lV180Core_clientepjcontatowwds_66_tfcpjtelnum = "";
         lV182Core_clientepjcontatowwds_68_tfcpjtelram = "";
         lV184Core_clientepjcontatowwds_70_tfcpjwppnum = "";
         lV186Core_clientepjcontatowwds_72_tfcpjemail = "";
         lV188Core_clientepjcontatowwds_74_tfcpjwebsite = "";
         A275CpjConNome = "";
         A276CpjConNomePrim = "";
         A277CpjConSobrenome = "";
         A272CpjConTipoNome = "";
         A274CpjConCPFFormat = "";
         A281CpjConGenNome = "";
         A285CpjConCelNum = "";
         A283CpjConTelNum = "";
         A284CpjConTelRam = "";
         A286CpjConWppNum = "";
         A287CpjConEmail = "";
         A288CpjConLIn = "";
         A160CliNomeFamiliar = "";
         A367CpjTipoNome = "";
         A170CpjNomeFan = "";
         A171CpjRazaoSoc = "";
         A188CpjCNPJFormat = "";
         A189CpjIE = "";
         A263CpjCelNum = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A264CpjWppNum = "";
         A266CpjEmail = "";
         A265CpjWebsite = "";
         A280CpjConGenSigla = "";
         A282CpjConNascimento = DateTime.MinValue;
         P005W2_A158CliID = new Guid[] {Guid.Empty} ;
         P005W2_A166CpjID = new Guid[] {Guid.Empty} ;
         P005W2_A365CpjTipoId = new int[1] ;
         P005W2_A176CpjMatricula = new long[1] ;
         P005W2_A159CliMatricula = new long[1] ;
         P005W2_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         P005W2_A280CpjConGenSigla = new string[] {""} ;
         P005W2_A265CpjWebsite = new string[] {""} ;
         P005W2_n265CpjWebsite = new bool[] {false} ;
         P005W2_A266CpjEmail = new string[] {""} ;
         P005W2_n266CpjEmail = new bool[] {false} ;
         P005W2_A264CpjWppNum = new string[] {""} ;
         P005W2_n264CpjWppNum = new bool[] {false} ;
         P005W2_A262CpjTelRam = new string[] {""} ;
         P005W2_n262CpjTelRam = new bool[] {false} ;
         P005W2_A261CpjTelNum = new string[] {""} ;
         P005W2_n261CpjTelNum = new bool[] {false} ;
         P005W2_A263CpjCelNum = new string[] {""} ;
         P005W2_n263CpjCelNum = new bool[] {false} ;
         P005W2_A189CpjIE = new string[] {""} ;
         P005W2_A188CpjCNPJFormat = new string[] {""} ;
         P005W2_A171CpjRazaoSoc = new string[] {""} ;
         P005W2_A170CpjNomeFan = new string[] {""} ;
         P005W2_A367CpjTipoNome = new string[] {""} ;
         P005W2_A160CliNomeFamiliar = new string[] {""} ;
         P005W2_A288CpjConLIn = new string[] {""} ;
         P005W2_n288CpjConLIn = new bool[] {false} ;
         P005W2_A287CpjConEmail = new string[] {""} ;
         P005W2_n287CpjConEmail = new bool[] {false} ;
         P005W2_A286CpjConWppNum = new string[] {""} ;
         P005W2_n286CpjConWppNum = new bool[] {false} ;
         P005W2_A284CpjConTelRam = new string[] {""} ;
         P005W2_n284CpjConTelRam = new bool[] {false} ;
         P005W2_A283CpjConTelNum = new string[] {""} ;
         P005W2_n283CpjConTelNum = new bool[] {false} ;
         P005W2_A285CpjConCelNum = new string[] {""} ;
         P005W2_n285CpjConCelNum = new bool[] {false} ;
         P005W2_A281CpjConGenNome = new string[] {""} ;
         P005W2_A274CpjConCPFFormat = new string[] {""} ;
         P005W2_A272CpjConTipoNome = new string[] {""} ;
         P005W2_A277CpjConSobrenome = new string[] {""} ;
         P005W2_A276CpjConNomePrim = new string[] {""} ;
         P005W2_A275CpjConNome = new string[] {""} ;
         P005W2_A269CpjConSeq = new short[1] ;
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV49UserCustomValue = "";
         GXt_char1 = "";
         AV46ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontatowwexport__default(),
            new Object[][] {
                new Object[] {
               P005W2_A158CliID, P005W2_A166CpjID, P005W2_A365CpjTipoId, P005W2_A176CpjMatricula, P005W2_A159CliMatricula, P005W2_A282CpjConNascimento, P005W2_A280CpjConGenSigla, P005W2_A265CpjWebsite, P005W2_n265CpjWebsite, P005W2_A266CpjEmail,
               P005W2_n266CpjEmail, P005W2_A264CpjWppNum, P005W2_n264CpjWppNum, P005W2_A262CpjTelRam, P005W2_n262CpjTelRam, P005W2_A261CpjTelNum, P005W2_n261CpjTelNum, P005W2_A263CpjCelNum, P005W2_n263CpjCelNum, P005W2_A189CpjIE,
               P005W2_A188CpjCNPJFormat, P005W2_A171CpjRazaoSoc, P005W2_A170CpjNomeFan, P005W2_A367CpjTipoNome, P005W2_A160CliNomeFamiliar, P005W2_A288CpjConLIn, P005W2_n288CpjConLIn, P005W2_A287CpjConEmail, P005W2_n287CpjConEmail, P005W2_A286CpjConWppNum,
               P005W2_n286CpjConWppNum, P005W2_A284CpjConTelRam, P005W2_n284CpjConTelRam, P005W2_A283CpjConTelNum, P005W2_n283CpjConTelNum, P005W2_A285CpjConCelNum, P005W2_n285CpjConCelNum, P005W2_A281CpjConGenNome, P005W2_A274CpjConCPFFormat, P005W2_A272CpjConTipoNome,
               P005W2_A277CpjConSobrenome, P005W2_A276CpjConNomePrim, P005W2_A275CpjConNome, P005W2_A269CpjConSeq
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV28DynamicFiltersOperator2 ;
      private short AV35DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ;
      private short AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ;
      private short AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ;
      private short AV17OrderedBy ;
      private short A269CpjConSeq ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV113GXV1 ;
      private int A365CpjTipoId ;
      private int AV190GXV2 ;
      private int AV191GXV3 ;
      private long AV80TFCliMatricula ;
      private long AV81TFCliMatricula_To ;
      private long AV95TFCpjMatricula ;
      private long AV96TFCpjMatricula_To ;
      private long AV53VisibleColumnCount ;
      private long AV164Core_clientepjcontatowwds_50_tfclimatricula ;
      private long AV165Core_clientepjcontatowwds_51_tfclimatricula_to ;
      private long AV172Core_clientepjcontatowwds_58_tfcpjmatricula ;
      private long AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private string AV71TFCpjConCelNum_Sel ;
      private string AV70TFCpjConCelNum ;
      private string AV73TFCpjConTelNum_Sel ;
      private string AV72TFCpjConTelNum ;
      private string AV93TFCpjConWppNum_Sel ;
      private string AV92TFCpjConWppNum ;
      private string AV102TFCpjCelNum_Sel ;
      private string AV101TFCpjCelNum ;
      private string AV104TFCpjTelNum_Sel ;
      private string AV103TFCpjTelNum ;
      private string AV108TFCpjWppNum_Sel ;
      private string AV107TFCpjWppNum ;
      private string AV150Core_clientepjcontatowwds_36_tfcpjconcelnum ;
      private string AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ;
      private string AV152Core_clientepjcontatowwds_38_tfcpjcontelnum ;
      private string AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ;
      private string AV156Core_clientepjcontatowwds_42_tfcpjconwppnum ;
      private string AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ;
      private string AV178Core_clientepjcontatowwds_64_tfcpjcelnum ;
      private string AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel ;
      private string AV180Core_clientepjcontatowwds_66_tfcpjtelnum ;
      private string AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel ;
      private string AV184Core_clientepjcontatowwds_70_tfcpjwppnum ;
      private string AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel ;
      private string scmdbuf ;
      private string lV150Core_clientepjcontatowwds_36_tfcpjconcelnum ;
      private string lV152Core_clientepjcontatowwds_38_tfcpjcontelnum ;
      private string lV156Core_clientepjcontatowwds_42_tfcpjconwppnum ;
      private string lV178Core_clientepjcontatowwds_64_tfcpjcelnum ;
      private string lV180Core_clientepjcontatowwds_66_tfcpjtelnum ;
      private string lV184Core_clientepjcontatowwds_70_tfcpjwppnum ;
      private string A285CpjConCelNum ;
      private string A283CpjConTelNum ;
      private string A286CpjConWppNum ;
      private string A263CpjCelNum ;
      private string A261CpjTelNum ;
      private string A264CpjWppNum ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV66TFCpjConNascimento ;
      private DateTime AV67TFCpjConNascimento_To ;
      private DateTime AV146Core_clientepjcontatowwds_32_tfcpjconnascimento ;
      private DateTime AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to ;
      private DateTime A282CpjConNascimento ;
      private bool returnInSub ;
      private bool AV26DynamicFiltersEnabled2 ;
      private bool AV33DynamicFiltersEnabled3 ;
      private bool AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ;
      private bool AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ;
      private bool AV18OrderedDsc ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool n264CpjWppNum ;
      private bool n262CpjTelRam ;
      private bool n261CpjTelNum ;
      private bool n263CpjCelNum ;
      private bool n288CpjConLIn ;
      private bool n287CpjConEmail ;
      private bool n286CpjConWppNum ;
      private bool n284CpjConTelRam ;
      private bool n283CpjConTelNum ;
      private bool n285CpjConCelNum ;
      private string AV48ColumnsSelectorXML ;
      private string AV49UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22CpjConNome1 ;
      private string AV23CpjTipoNome1 ;
      private string AV24CpjConTipoNome1 ;
      private string AV25CpjConGenSigla1 ;
      private string AV27DynamicFiltersSelector2 ;
      private string AV29CpjConNome2 ;
      private string AV30CpjTipoNome2 ;
      private string AV31CpjConTipoNome2 ;
      private string AV32CpjConGenSigla2 ;
      private string AV34DynamicFiltersSelector3 ;
      private string AV36CpjConNome3 ;
      private string AV37CpjTipoNome3 ;
      private string AV38CpjConTipoNome3 ;
      private string AV39CpjConGenSigla3 ;
      private string AV57TFCpjConNome_Sel ;
      private string AV56TFCpjConNome ;
      private string AV59TFCpjConNomePrim_Sel ;
      private string AV58TFCpjConNomePrim ;
      private string AV61TFCpjConSobrenome_Sel ;
      private string AV60TFCpjConSobrenome ;
      private string AV63TFCpjConTipoNome_Sel ;
      private string AV62TFCpjConTipoNome ;
      private string AV65TFCpjConCPFFormat_Sel ;
      private string AV64TFCpjConCPFFormat ;
      private string AV69TFCpjConGenNome_Sel ;
      private string AV68TFCpjConGenNome ;
      private string AV75TFCpjConTelRam_Sel ;
      private string AV74TFCpjConTelRam ;
      private string AV77TFCpjConEmail_Sel ;
      private string AV76TFCpjConEmail ;
      private string AV79TFCpjConLIn_Sel ;
      private string AV78TFCpjConLIn ;
      private string AV83TFCliNomeFamiliar_Sel ;
      private string AV82TFCliNomeFamiliar ;
      private string AV85TFCpjTipoNome_Sel ;
      private string AV84TFCpjTipoNome ;
      private string AV87TFCpjNomeFan_Sel ;
      private string AV86TFCpjNomeFan ;
      private string AV89TFCpjRazaoSoc_Sel ;
      private string AV88TFCpjRazaoSoc ;
      private string AV98TFCpjCNPJFormat_Sel ;
      private string AV97TFCpjCNPJFormat ;
      private string AV100TFCpjIE_Sel ;
      private string AV99TFCpjIE ;
      private string AV106TFCpjTelRam_Sel ;
      private string AV105TFCpjTelRam ;
      private string AV110TFCpjEmail_Sel ;
      private string AV109TFCpjEmail ;
      private string AV112TFCpjWebsite_Sel ;
      private string AV111TFCpjWebsite ;
      private string AV115Core_clientepjcontatowwds_1_filterfulltext ;
      private string AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1 ;
      private string AV118Core_clientepjcontatowwds_4_cpjconnome1 ;
      private string AV119Core_clientepjcontatowwds_5_cpjtiponome1 ;
      private string AV120Core_clientepjcontatowwds_6_cpjcontiponome1 ;
      private string AV121Core_clientepjcontatowwds_7_cpjcongensigla1 ;
      private string AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2 ;
      private string AV125Core_clientepjcontatowwds_11_cpjconnome2 ;
      private string AV126Core_clientepjcontatowwds_12_cpjtiponome2 ;
      private string AV127Core_clientepjcontatowwds_13_cpjcontiponome2 ;
      private string AV128Core_clientepjcontatowwds_14_cpjcongensigla2 ;
      private string AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3 ;
      private string AV132Core_clientepjcontatowwds_18_cpjconnome3 ;
      private string AV133Core_clientepjcontatowwds_19_cpjtiponome3 ;
      private string AV134Core_clientepjcontatowwds_20_cpjcontiponome3 ;
      private string AV135Core_clientepjcontatowwds_21_cpjcongensigla3 ;
      private string AV136Core_clientepjcontatowwds_22_tfcpjconnome ;
      private string AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel ;
      private string AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim ;
      private string AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ;
      private string AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome ;
      private string AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ;
      private string AV142Core_clientepjcontatowwds_28_tfcpjcontiponome ;
      private string AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ;
      private string AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat ;
      private string AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ;
      private string AV148Core_clientepjcontatowwds_34_tfcpjcongennome ;
      private string AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel ;
      private string AV154Core_clientepjcontatowwds_40_tfcpjcontelram ;
      private string AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel ;
      private string AV158Core_clientepjcontatowwds_44_tfcpjconemail ;
      private string AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel ;
      private string AV160Core_clientepjcontatowwds_46_tfcpjconlin ;
      private string AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel ;
      private string AV162Core_clientepjcontatowwds_48_tfclinomefamiliar ;
      private string AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ;
      private string AV166Core_clientepjcontatowwds_52_tfcpjtiponome ;
      private string AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel ;
      private string AV168Core_clientepjcontatowwds_54_tfcpjnomefan ;
      private string AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel ;
      private string AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc ;
      private string AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ;
      private string AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat ;
      private string AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ;
      private string AV176Core_clientepjcontatowwds_62_tfcpjie ;
      private string AV177Core_clientepjcontatowwds_63_tfcpjie_sel ;
      private string AV182Core_clientepjcontatowwds_68_tfcpjtelram ;
      private string AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel ;
      private string AV186Core_clientepjcontatowwds_72_tfcpjemail ;
      private string AV187Core_clientepjcontatowwds_73_tfcpjemail_sel ;
      private string AV188Core_clientepjcontatowwds_74_tfcpjwebsite ;
      private string AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel ;
      private string lV115Core_clientepjcontatowwds_1_filterfulltext ;
      private string lV118Core_clientepjcontatowwds_4_cpjconnome1 ;
      private string lV119Core_clientepjcontatowwds_5_cpjtiponome1 ;
      private string lV120Core_clientepjcontatowwds_6_cpjcontiponome1 ;
      private string lV121Core_clientepjcontatowwds_7_cpjcongensigla1 ;
      private string lV125Core_clientepjcontatowwds_11_cpjconnome2 ;
      private string lV126Core_clientepjcontatowwds_12_cpjtiponome2 ;
      private string lV127Core_clientepjcontatowwds_13_cpjcontiponome2 ;
      private string lV128Core_clientepjcontatowwds_14_cpjcongensigla2 ;
      private string lV132Core_clientepjcontatowwds_18_cpjconnome3 ;
      private string lV133Core_clientepjcontatowwds_19_cpjtiponome3 ;
      private string lV134Core_clientepjcontatowwds_20_cpjcontiponome3 ;
      private string lV135Core_clientepjcontatowwds_21_cpjcongensigla3 ;
      private string lV136Core_clientepjcontatowwds_22_tfcpjconnome ;
      private string lV138Core_clientepjcontatowwds_24_tfcpjconnomeprim ;
      private string lV140Core_clientepjcontatowwds_26_tfcpjconsobrenome ;
      private string lV142Core_clientepjcontatowwds_28_tfcpjcontiponome ;
      private string lV144Core_clientepjcontatowwds_30_tfcpjconcpfformat ;
      private string lV148Core_clientepjcontatowwds_34_tfcpjcongennome ;
      private string lV154Core_clientepjcontatowwds_40_tfcpjcontelram ;
      private string lV158Core_clientepjcontatowwds_44_tfcpjconemail ;
      private string lV160Core_clientepjcontatowwds_46_tfcpjconlin ;
      private string lV162Core_clientepjcontatowwds_48_tfclinomefamiliar ;
      private string lV166Core_clientepjcontatowwds_52_tfcpjtiponome ;
      private string lV168Core_clientepjcontatowwds_54_tfcpjnomefan ;
      private string lV170Core_clientepjcontatowwds_56_tfcpjrazaosoc ;
      private string lV174Core_clientepjcontatowwds_60_tfcpjcnpjformat ;
      private string lV176Core_clientepjcontatowwds_62_tfcpjie ;
      private string lV182Core_clientepjcontatowwds_68_tfcpjtelram ;
      private string lV186Core_clientepjcontatowwds_72_tfcpjemail ;
      private string lV188Core_clientepjcontatowwds_74_tfcpjwebsite ;
      private string A275CpjConNome ;
      private string A276CpjConNomePrim ;
      private string A277CpjConSobrenome ;
      private string A272CpjConTipoNome ;
      private string A274CpjConCPFFormat ;
      private string A281CpjConGenNome ;
      private string A284CpjConTelRam ;
      private string A287CpjConEmail ;
      private string A288CpjConLIn ;
      private string A160CliNomeFamiliar ;
      private string A367CpjTipoNome ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A188CpjCNPJFormat ;
      private string A189CpjIE ;
      private string A262CpjTelRam ;
      private string A266CpjEmail ;
      private string A265CpjWebsite ;
      private string A280CpjConGenSigla ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private IGxSession AV41Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P005W2_A158CliID ;
      private Guid[] P005W2_A166CpjID ;
      private int[] P005W2_A365CpjTipoId ;
      private long[] P005W2_A176CpjMatricula ;
      private long[] P005W2_A159CliMatricula ;
      private DateTime[] P005W2_A282CpjConNascimento ;
      private string[] P005W2_A280CpjConGenSigla ;
      private string[] P005W2_A265CpjWebsite ;
      private bool[] P005W2_n265CpjWebsite ;
      private string[] P005W2_A266CpjEmail ;
      private bool[] P005W2_n266CpjEmail ;
      private string[] P005W2_A264CpjWppNum ;
      private bool[] P005W2_n264CpjWppNum ;
      private string[] P005W2_A262CpjTelRam ;
      private bool[] P005W2_n262CpjTelRam ;
      private string[] P005W2_A261CpjTelNum ;
      private bool[] P005W2_n261CpjTelNum ;
      private string[] P005W2_A263CpjCelNum ;
      private bool[] P005W2_n263CpjCelNum ;
      private string[] P005W2_A189CpjIE ;
      private string[] P005W2_A188CpjCNPJFormat ;
      private string[] P005W2_A171CpjRazaoSoc ;
      private string[] P005W2_A170CpjNomeFan ;
      private string[] P005W2_A367CpjTipoNome ;
      private string[] P005W2_A160CliNomeFamiliar ;
      private string[] P005W2_A288CpjConLIn ;
      private bool[] P005W2_n288CpjConLIn ;
      private string[] P005W2_A287CpjConEmail ;
      private bool[] P005W2_n287CpjConEmail ;
      private string[] P005W2_A286CpjConWppNum ;
      private bool[] P005W2_n286CpjConWppNum ;
      private string[] P005W2_A284CpjConTelRam ;
      private bool[] P005W2_n284CpjConTelRam ;
      private string[] P005W2_A283CpjConTelNum ;
      private bool[] P005W2_n283CpjConTelNum ;
      private string[] P005W2_A285CpjConCelNum ;
      private bool[] P005W2_n285CpjConCelNum ;
      private string[] P005W2_A281CpjConGenNome ;
      private string[] P005W2_A274CpjConCPFFormat ;
      private string[] P005W2_A272CpjConTipoNome ;
      private string[] P005W2_A277CpjConSobrenome ;
      private string[] P005W2_A276CpjConNomePrim ;
      private string[] P005W2_A275CpjConNome ;
      private short[] P005W2_A269CpjConSeq ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV45ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV46ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column AV47ColumnsSelector_Column ;
   }

   public class clientepjcontatowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005W2( IGxContext context ,
                                             string AV115Core_clientepjcontatowwds_1_filterfulltext ,
                                             string AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                             short AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                             string AV118Core_clientepjcontatowwds_4_cpjconnome1 ,
                                             string AV119Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                             string AV120Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                             string AV121Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                             bool AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                             string AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                             short AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                             string AV125Core_clientepjcontatowwds_11_cpjconnome2 ,
                                             string AV126Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                             string AV127Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                             string AV128Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                             bool AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                             string AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                             short AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                             string AV132Core_clientepjcontatowwds_18_cpjconnome3 ,
                                             string AV133Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                             string AV134Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                             string AV135Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                             string AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                             string AV136Core_clientepjcontatowwds_22_tfcpjconnome ,
                                             string AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                             string AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                             string AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                             string AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                             string AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                             string AV142Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                             string AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                             string AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                             DateTime AV146Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                             DateTime AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                             string AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                             string AV148Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                             string AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                             string AV150Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                             string AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                             string AV152Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                             string AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                             string AV154Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                             string AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                             string AV156Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                             string AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                             string AV158Core_clientepjcontatowwds_44_tfcpjconemail ,
                                             string AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                             string AV160Core_clientepjcontatowwds_46_tfcpjconlin ,
                                             string AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                             string AV162Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                             long AV164Core_clientepjcontatowwds_50_tfclimatricula ,
                                             long AV165Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                             string AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                             string AV166Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                             string AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                             string AV168Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                             string AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                             string AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                             long AV172Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                             long AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                             string AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                             string AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                             string AV177Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                             string AV176Core_clientepjcontatowwds_62_tfcpjie ,
                                             string AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                             string AV178Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                             string AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                             string AV180Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                             string AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                             string AV182Core_clientepjcontatowwds_68_tfcpjtelram ,
                                             string AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                             string AV184Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                             string AV187Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                             string AV186Core_clientepjcontatowwds_72_tfcpjemail ,
                                             string AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                             string AV188Core_clientepjcontatowwds_74_tfcpjwebsite ,
                                             string A275CpjConNome ,
                                             string A276CpjConNomePrim ,
                                             string A277CpjConSobrenome ,
                                             string A272CpjConTipoNome ,
                                             string A274CpjConCPFFormat ,
                                             string A281CpjConGenNome ,
                                             string A285CpjConCelNum ,
                                             string A283CpjConTelNum ,
                                             string A284CpjConTelRam ,
                                             string A286CpjConWppNum ,
                                             string A287CpjConEmail ,
                                             string A288CpjConLIn ,
                                             string A160CliNomeFamiliar ,
                                             long A159CliMatricula ,
                                             string A367CpjTipoNome ,
                                             string A170CpjNomeFan ,
                                             string A171CpjRazaoSoc ,
                                             long A176CpjMatricula ,
                                             string A188CpjCNPJFormat ,
                                             string A189CpjIE ,
                                             string A263CpjCelNum ,
                                             string A261CpjTelNum ,
                                             string A262CpjTelRam ,
                                             string A264CpjWppNum ,
                                             string A266CpjEmail ,
                                             string A265CpjWebsite ,
                                             string A280CpjConGenSigla ,
                                             DateTime A282CpjConNascimento ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[104];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.CliID, T1.CpjID, T3.CpjTipoId AS CpjTipoId, T3.CpjMatricula, T2.CliMatricula, T1.CpjConNascimento, T1.CpjConGenSigla, T3.CpjWebsite, T3.CpjEmail, T3.CpjWppNum, T3.CpjTelRam, T3.CpjTelNum, T3.CpjCelNum, T3.CpjIE, T3.CpjCNPJFormat, T3.CpjRazaoSoc, T3.CpjNomeFan, T4.PjtNome AS CpjTipoNome, T2.CliNomeFamiliar, T1.CpjConLIn, T1.CpjConEmail, T1.CpjConWppNum, T1.CpjConTelRam, T1.CpjConTelNum, T1.CpjConCelNum, T1.CpjConGenNome, T1.CpjConCPFFormat, T1.CpjConTipoNome, T1.CpjConSobrenome, T1.CpjConNomePrim, T1.CpjConNome, T1.CpjConSeq FROM (((tb_clientepj_contato T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_clientepjcontatowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CpjConNome like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConNomePrim like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConSobrenome like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTipoNome like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCPFFormat like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConGenNome like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCelNum like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelNum like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelRam like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConWppNum like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConEmail like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConLIn like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T2.CliNomeFamiliar like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CliMatricula,'999999999999'), 2) like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T4.PjtNome like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjNomeFan like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjRazaoSoc like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.CpjMatricula,'999999999999'), 2) like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCNPJFormat like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjIE like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCelNum like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelNum like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelRam like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWppNum like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjEmail like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWebsite like '%' || :lV115Core_clientepjcontatowwds_1_filterfulltext))");
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
            GXv_int4[9] = 1;
            GXv_int4[10] = 1;
            GXv_int4[11] = 1;
            GXv_int4[12] = 1;
            GXv_int4[13] = 1;
            GXv_int4[14] = 1;
            GXv_int4[15] = 1;
            GXv_int4[16] = 1;
            GXv_int4[17] = 1;
            GXv_int4[18] = 1;
            GXv_int4[19] = 1;
            GXv_int4[20] = 1;
            GXv_int4[21] = 1;
            GXv_int4[22] = 1;
            GXv_int4[23] = 1;
            GXv_int4[24] = 1;
            GXv_int4[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV118Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV118Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV119Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV119Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV120Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV120Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV121Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV116Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV117Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV121Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV125Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV125Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV126Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV126Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV127Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV127Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int4[39] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV128Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int4[40] = 1;
         }
         if ( AV122Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV123Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV124Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV128Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int4[41] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV132Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int4[42] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV132Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int4[43] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV133Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int4[44] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV133Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int4[45] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV134Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int4[46] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV134Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int4[47] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV135Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int4[48] = 1;
         }
         if ( AV129Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV131Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV135Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int4[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_22_tfcpjconnome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV136Core_clientepjcontatowwds_22_tfcpjconnome)");
         }
         else
         {
            GXv_int4[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ! ( StringUtil.StrCmp(AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome = ( :AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel))");
         }
         else
         {
            GXv_int4[51] = 1;
         }
         if ( StringUtil.StrCmp(AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_clientepjcontatowwds_24_tfcpjconnomeprim)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim like :lV138Core_clientepjcontatowwds_24_tfcpjconnomeprim)");
         }
         else
         {
            GXv_int4[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ! ( StringUtil.StrCmp(AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim = ( :AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel))");
         }
         else
         {
            GXv_int4[53] = 1;
         }
         if ( StringUtil.StrCmp(AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNomePrim))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Core_clientepjcontatowwds_26_tfcpjconsobrenome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome like :lV140Core_clientepjcontatowwds_26_tfcpjconsobrenome)");
         }
         else
         {
            GXv_int4[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ! ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome = ( :AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel))");
         }
         else
         {
            GXv_int4[55] = 1;
         }
         if ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConSobrenome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Core_clientepjcontatowwds_28_tfcpjcontiponome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV142Core_clientepjcontatowwds_28_tfcpjcontiponome)");
         }
         else
         {
            GXv_int4[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ! ( StringUtil.StrCmp(AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome = ( :AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel))");
         }
         else
         {
            GXv_int4[57] = 1;
         }
         if ( StringUtil.StrCmp(AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_clientepjcontatowwds_30_tfcpjconcpfformat)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat like :lV144Core_clientepjcontatowwds_30_tfcpjconcpfformat)");
         }
         else
         {
            GXv_int4[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ! ( StringUtil.StrCmp(AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat = ( :AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel))");
         }
         else
         {
            GXv_int4[59] = 1;
         }
         if ( StringUtil.StrCmp(AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConCPFFormat))=0))");
         }
         if ( ! (DateTime.MinValue==AV146Core_clientepjcontatowwds_32_tfcpjconnascimento) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento >= :AV146Core_clientepjcontatowwds_32_tfcpjconnascimento)");
         }
         else
         {
            GXv_int4[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento <= :AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to)");
         }
         else
         {
            GXv_int4[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Core_clientepjcontatowwds_34_tfcpjcongennome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome like :lV148Core_clientepjcontatowwds_34_tfcpjcongennome)");
         }
         else
         {
            GXv_int4[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ! ( StringUtil.StrCmp(AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome = ( :AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel))");
         }
         else
         {
            GXv_int4[63] = 1;
         }
         if ( StringUtil.StrCmp(AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConGenNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Core_clientepjcontatowwds_36_tfcpjconcelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum like :lV150Core_clientepjcontatowwds_36_tfcpjconcelnum)");
         }
         else
         {
            GXv_int4[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ! ( StringUtil.StrCmp(AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum = ( :AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel))");
         }
         else
         {
            GXv_int4[65] = 1;
         }
         if ( StringUtil.StrCmp(AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Core_clientepjcontatowwds_38_tfcpjcontelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum like :lV152Core_clientepjcontatowwds_38_tfcpjcontelnum)");
         }
         else
         {
            GXv_int4[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ! ( StringUtil.StrCmp(AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum = ( :AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel))");
         }
         else
         {
            GXv_int4[67] = 1;
         }
         if ( StringUtil.StrCmp(AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Core_clientepjcontatowwds_40_tfcpjcontelram)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam like :lV154Core_clientepjcontatowwds_40_tfcpjcontelram)");
         }
         else
         {
            GXv_int4[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ! ( StringUtil.StrCmp(AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam = ( :AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel))");
         }
         else
         {
            GXv_int4[69] = 1;
         }
         if ( StringUtil.StrCmp(AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_clientepjcontatowwds_42_tfcpjconwppnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum like :lV156Core_clientepjcontatowwds_42_tfcpjconwppnum)");
         }
         else
         {
            GXv_int4[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ! ( StringUtil.StrCmp(AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum = ( :AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel))");
         }
         else
         {
            GXv_int4[71] = 1;
         }
         if ( StringUtil.StrCmp(AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Core_clientepjcontatowwds_44_tfcpjconemail)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail like :lV158Core_clientepjcontatowwds_44_tfcpjconemail)");
         }
         else
         {
            GXv_int4[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ! ( StringUtil.StrCmp(AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail = ( :AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel))");
         }
         else
         {
            GXv_int4[73] = 1;
         }
         if ( StringUtil.StrCmp(AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail IS NULL or (char_length(trim(trailing ' ' from T1.CpjConEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Core_clientepjcontatowwds_46_tfcpjconlin)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn like :lV160Core_clientepjcontatowwds_46_tfcpjconlin)");
         }
         else
         {
            GXv_int4[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ! ( StringUtil.StrCmp(AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn = ( :AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel))");
         }
         else
         {
            GXv_int4[75] = 1;
         }
         if ( StringUtil.StrCmp(AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn IS NULL or (char_length(trim(trailing ' ' from T1.CpjConLIn))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_clientepjcontatowwds_48_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar like :lV162Core_clientepjcontatowwds_48_tfclinomefamiliar)");
         }
         else
         {
            GXv_int4[76] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar = ( :AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int4[77] = 1;
         }
         if ( StringUtil.StrCmp(AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV164Core_clientepjcontatowwds_50_tfclimatricula) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula >= :AV164Core_clientepjcontatowwds_50_tfclimatricula)");
         }
         else
         {
            GXv_int4[78] = 1;
         }
         if ( ! (0==AV165Core_clientepjcontatowwds_51_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula <= :AV165Core_clientepjcontatowwds_51_tfclimatricula_to)");
         }
         else
         {
            GXv_int4[79] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Core_clientepjcontatowwds_52_tfcpjtiponome)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV166Core_clientepjcontatowwds_52_tfcpjtiponome)");
         }
         else
         {
            GXv_int4[80] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ! ( StringUtil.StrCmp(AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome = ( :AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel))");
         }
         else
         {
            GXv_int4[81] = 1;
         }
         if ( StringUtil.StrCmp(AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.PjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Core_clientepjcontatowwds_54_tfcpjnomefan)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan like :lV168Core_clientepjcontatowwds_54_tfcpjnomefan)");
         }
         else
         {
            GXv_int4[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ! ( StringUtil.StrCmp(AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan = ( :AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel))");
         }
         else
         {
            GXv_int4[83] = 1;
         }
         if ( StringUtil.StrCmp(AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjNomeFan))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Core_clientepjcontatowwds_56_tfcpjrazaosoc)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc like :lV170Core_clientepjcontatowwds_56_tfcpjrazaosoc)");
         }
         else
         {
            GXv_int4[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ! ( StringUtil.StrCmp(AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc = ( :AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel))");
         }
         else
         {
            GXv_int4[85] = 1;
         }
         if ( StringUtil.StrCmp(AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjRazaoSoc))=0))");
         }
         if ( ! (0==AV172Core_clientepjcontatowwds_58_tfcpjmatricula) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula >= :AV172Core_clientepjcontatowwds_58_tfcpjmatricula)");
         }
         else
         {
            GXv_int4[86] = 1;
         }
         if ( ! (0==AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula <= :AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to)");
         }
         else
         {
            GXv_int4[87] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Core_clientepjcontatowwds_60_tfcpjcnpjformat)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat like :lV174Core_clientepjcontatowwds_60_tfcpjcnpjformat)");
         }
         else
         {
            GXv_int4[88] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ! ( StringUtil.StrCmp(AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat = ( :AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel))");
         }
         else
         {
            GXv_int4[89] = 1;
         }
         if ( StringUtil.StrCmp(AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjCNPJFormat))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_clientepjcontatowwds_63_tfcpjie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Core_clientepjcontatowwds_62_tfcpjie)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE like :lV176Core_clientepjcontatowwds_62_tfcpjie)");
         }
         else
         {
            GXv_int4[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_clientepjcontatowwds_63_tfcpjie_sel)) && ! ( StringUtil.StrCmp(AV177Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE = ( :AV177Core_clientepjcontatowwds_63_tfcpjie_sel))");
         }
         else
         {
            GXv_int4[91] = 1;
         }
         if ( StringUtil.StrCmp(AV177Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjIE))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Core_clientepjcontatowwds_64_tfcpjcelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum like :lV178Core_clientepjcontatowwds_64_tfcpjcelnum)");
         }
         else
         {
            GXv_int4[92] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ! ( StringUtil.StrCmp(AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum = ( :AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel))");
         }
         else
         {
            GXv_int4[93] = 1;
         }
         if ( StringUtil.StrCmp(AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Core_clientepjcontatowwds_66_tfcpjtelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum like :lV180Core_clientepjcontatowwds_66_tfcpjtelnum)");
         }
         else
         {
            GXv_int4[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ! ( StringUtil.StrCmp(AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum = ( :AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel))");
         }
         else
         {
            GXv_int4[95] = 1;
         }
         if ( StringUtil.StrCmp(AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_clientepjcontatowwds_68_tfcpjtelram)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam like :lV182Core_clientepjcontatowwds_68_tfcpjtelram)");
         }
         else
         {
            GXv_int4[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ! ( StringUtil.StrCmp(AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam = ( :AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel))");
         }
         else
         {
            GXv_int4[97] = 1;
         }
         if ( StringUtil.StrCmp(AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV184Core_clientepjcontatowwds_70_tfcpjwppnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum like :lV184Core_clientepjcontatowwds_70_tfcpjwppnum)");
         }
         else
         {
            GXv_int4[98] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ! ( StringUtil.StrCmp(AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum = ( :AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel))");
         }
         else
         {
            GXv_int4[99] = 1;
         }
         if ( StringUtil.StrCmp(AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV187Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV186Core_clientepjcontatowwds_72_tfcpjemail)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail like :lV186Core_clientepjcontatowwds_72_tfcpjemail)");
         }
         else
         {
            GXv_int4[100] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ! ( StringUtil.StrCmp(AV187Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail = ( :AV187Core_clientepjcontatowwds_73_tfcpjemail_sel))");
         }
         else
         {
            GXv_int4[101] = 1;
         }
         if ( StringUtil.StrCmp(AV187Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjEmail IS NULL or (char_length(trim(trailing ' ' from T3.CpjEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Core_clientepjcontatowwds_74_tfcpjwebsite)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite like :lV188Core_clientepjcontatowwds_74_tfcpjwebsite)");
         }
         else
         {
            GXv_int4[102] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ! ( StringUtil.StrCmp(AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite = ( :AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel))");
         }
         else
         {
            GXv_int4[103] = 1;
         }
         if ( StringUtil.StrCmp(AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite IS NULL or (char_length(trim(trailing ' ' from T3.CpjWebsite))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConNome";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConNome DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConNomePrim";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConNomePrim DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConSobrenome";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConSobrenome DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConTipoNome";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConTipoNome DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConCPFFormat";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConCPFFormat DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConNascimento";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConNascimento DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConGenNome";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConGenNome DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConCelNum";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConCelNum DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConTelNum";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConTelNum DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConTelRam";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConTelRam DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConWppNum";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConWppNum DESC";
         }
         else if ( ( AV17OrderedBy == 12 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConEmail";
         }
         else if ( ( AV17OrderedBy == 12 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConEmail DESC";
         }
         else if ( ( AV17OrderedBy == 13 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConLIn";
         }
         else if ( ( AV17OrderedBy == 13 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConLIn DESC";
         }
         else if ( ( AV17OrderedBy == 14 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CliNomeFamiliar";
         }
         else if ( ( AV17OrderedBy == 14 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CliNomeFamiliar DESC";
         }
         else if ( ( AV17OrderedBy == 15 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CliMatricula";
         }
         else if ( ( AV17OrderedBy == 15 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CliMatricula DESC";
         }
         else if ( ( AV17OrderedBy == 16 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.PjtNome";
         }
         else if ( ( AV17OrderedBy == 16 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.PjtNome DESC";
         }
         else if ( ( AV17OrderedBy == 17 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjNomeFan";
         }
         else if ( ( AV17OrderedBy == 17 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjNomeFan DESC";
         }
         else if ( ( AV17OrderedBy == 18 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjRazaoSoc";
         }
         else if ( ( AV17OrderedBy == 18 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjRazaoSoc DESC";
         }
         else if ( ( AV17OrderedBy == 19 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjMatricula";
         }
         else if ( ( AV17OrderedBy == 19 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjMatricula DESC";
         }
         else if ( ( AV17OrderedBy == 20 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjCNPJFormat";
         }
         else if ( ( AV17OrderedBy == 20 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjCNPJFormat DESC";
         }
         else if ( ( AV17OrderedBy == 21 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjIE";
         }
         else if ( ( AV17OrderedBy == 21 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjIE DESC";
         }
         else if ( ( AV17OrderedBy == 22 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjCelNum";
         }
         else if ( ( AV17OrderedBy == 22 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjCelNum DESC";
         }
         else if ( ( AV17OrderedBy == 23 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjTelNum";
         }
         else if ( ( AV17OrderedBy == 23 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjTelNum DESC";
         }
         else if ( ( AV17OrderedBy == 24 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjTelRam";
         }
         else if ( ( AV17OrderedBy == 24 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjTelRam DESC";
         }
         else if ( ( AV17OrderedBy == 25 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjWppNum";
         }
         else if ( ( AV17OrderedBy == 25 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjWppNum DESC";
         }
         else if ( ( AV17OrderedBy == 26 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjEmail";
         }
         else if ( ( AV17OrderedBy == 26 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjEmail DESC";
         }
         else if ( ( AV17OrderedBy == 27 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjWebsite";
         }
         else if ( ( AV17OrderedBy == 27 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjWebsite DESC";
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
                     return conditional_P005W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (long)dynConstraints[49] , (long)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (long)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (long)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (string)dynConstraints[97] , (string)dynConstraints[98] , (string)dynConstraints[99] , (string)dynConstraints[100] , (string)dynConstraints[101] , (DateTime)dynConstraints[102] , (short)dynConstraints[103] , (bool)dynConstraints[104] );
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
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV115Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV118Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV118Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV119Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV119Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV120Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV120Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV121Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV121Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV125Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV125Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV127Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV127Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV128Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV128Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV132Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV133Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV133Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV134Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV134Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV135Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV135Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_22_tfcpjconnome",GXType.VarChar,80,0) ,
          new ParDef("AV137Core_clientepjcontatowwds_23_tfcpjconnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV138Core_clientepjcontatowwds_24_tfcpjconnomeprim",GXType.VarChar,80,0) ,
          new ParDef("AV139Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel",GXType.VarChar,80,0) ,
          new ParDef("lV140Core_clientepjcontatowwds_26_tfcpjconsobrenome",GXType.VarChar,80,0) ,
          new ParDef("AV141Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV142Core_clientepjcontatowwds_28_tfcpjcontiponome",GXType.VarChar,80,0) ,
          new ParDef("AV143Core_clientepjcontatowwds_29_tfcpjcontiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV144Core_clientepjcontatowwds_30_tfcpjconcpfformat",GXType.VarChar,14,0) ,
          new ParDef("AV145Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel",GXType.VarChar,14,0) ,
          new ParDef("AV146Core_clientepjcontatowwds_32_tfcpjconnascimento",GXType.Date,8,0) ,
          new ParDef("AV147Core_clientepjcontatowwds_33_tfcpjconnascimento_to",GXType.Date,8,0) ,
          new ParDef("lV148Core_clientepjcontatowwds_34_tfcpjcongennome",GXType.VarChar,80,0) ,
          new ParDef("AV149Core_clientepjcontatowwds_35_tfcpjcongennome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV150Core_clientepjcontatowwds_36_tfcpjconcelnum",GXType.Char,20,0) ,
          new ParDef("AV151Core_clientepjcontatowwds_37_tfcpjconcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV152Core_clientepjcontatowwds_38_tfcpjcontelnum",GXType.Char,20,0) ,
          new ParDef("AV153Core_clientepjcontatowwds_39_tfcpjcontelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV154Core_clientepjcontatowwds_40_tfcpjcontelram",GXType.VarChar,10,0) ,
          new ParDef("AV155Core_clientepjcontatowwds_41_tfcpjcontelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV156Core_clientepjcontatowwds_42_tfcpjconwppnum",GXType.Char,20,0) ,
          new ParDef("AV157Core_clientepjcontatowwds_43_tfcpjconwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV158Core_clientepjcontatowwds_44_tfcpjconemail",GXType.VarChar,100,0) ,
          new ParDef("AV159Core_clientepjcontatowwds_45_tfcpjconemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV160Core_clientepjcontatowwds_46_tfcpjconlin",GXType.VarChar,1000,0) ,
          new ParDef("AV161Core_clientepjcontatowwds_47_tfcpjconlin_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV162Core_clientepjcontatowwds_48_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV163Core_clientepjcontatowwds_49_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV164Core_clientepjcontatowwds_50_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV165Core_clientepjcontatowwds_51_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV166Core_clientepjcontatowwds_52_tfcpjtiponome",GXType.VarChar,80,0) ,
          new ParDef("AV167Core_clientepjcontatowwds_53_tfcpjtiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV168Core_clientepjcontatowwds_54_tfcpjnomefan",GXType.VarChar,80,0) ,
          new ParDef("AV169Core_clientepjcontatowwds_55_tfcpjnomefan_sel",GXType.VarChar,80,0) ,
          new ParDef("lV170Core_clientepjcontatowwds_56_tfcpjrazaosoc",GXType.VarChar,80,0) ,
          new ParDef("AV171Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel",GXType.VarChar,80,0) ,
          new ParDef("AV172Core_clientepjcontatowwds_58_tfcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV173Core_clientepjcontatowwds_59_tfcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV174Core_clientepjcontatowwds_60_tfcpjcnpjformat",GXType.VarChar,18,0) ,
          new ParDef("AV175Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel",GXType.VarChar,18,0) ,
          new ParDef("lV176Core_clientepjcontatowwds_62_tfcpjie",GXType.VarChar,20,0) ,
          new ParDef("AV177Core_clientepjcontatowwds_63_tfcpjie_sel",GXType.VarChar,20,0) ,
          new ParDef("lV178Core_clientepjcontatowwds_64_tfcpjcelnum",GXType.Char,20,0) ,
          new ParDef("AV179Core_clientepjcontatowwds_65_tfcpjcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV180Core_clientepjcontatowwds_66_tfcpjtelnum",GXType.Char,20,0) ,
          new ParDef("AV181Core_clientepjcontatowwds_67_tfcpjtelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV182Core_clientepjcontatowwds_68_tfcpjtelram",GXType.VarChar,10,0) ,
          new ParDef("AV183Core_clientepjcontatowwds_69_tfcpjtelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV184Core_clientepjcontatowwds_70_tfcpjwppnum",GXType.Char,20,0) ,
          new ParDef("AV185Core_clientepjcontatowwds_71_tfcpjwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV186Core_clientepjcontatowwds_72_tfcpjemail",GXType.VarChar,100,0) ,
          new ParDef("AV187Core_clientepjcontatowwds_73_tfcpjemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV188Core_clientepjcontatowwds_74_tfcpjwebsite",GXType.VarChar,1000,0) ,
          new ParDef("AV189Core_clientepjcontatowwds_75_tfcpjwebsite_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 20);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 20);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((string[]) buf[19])[0] = rslt.getVarchar(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((string[]) buf[21])[0] = rslt.getVarchar(16);
                ((string[]) buf[22])[0] = rslt.getVarchar(17);
                ((string[]) buf[23])[0] = rslt.getVarchar(18);
                ((string[]) buf[24])[0] = rslt.getVarchar(19);
                ((string[]) buf[25])[0] = rslt.getVarchar(20);
                ((bool[]) buf[26])[0] = rslt.wasNull(20);
                ((string[]) buf[27])[0] = rslt.getVarchar(21);
                ((bool[]) buf[28])[0] = rslt.wasNull(21);
                ((string[]) buf[29])[0] = rslt.getString(22, 20);
                ((bool[]) buf[30])[0] = rslt.wasNull(22);
                ((string[]) buf[31])[0] = rslt.getVarchar(23);
                ((bool[]) buf[32])[0] = rslt.wasNull(23);
                ((string[]) buf[33])[0] = rslt.getString(24, 20);
                ((bool[]) buf[34])[0] = rslt.wasNull(24);
                ((string[]) buf[35])[0] = rslt.getString(25, 20);
                ((bool[]) buf[36])[0] = rslt.wasNull(25);
                ((string[]) buf[37])[0] = rslt.getVarchar(26);
                ((string[]) buf[38])[0] = rslt.getVarchar(27);
                ((string[]) buf[39])[0] = rslt.getVarchar(28);
                ((string[]) buf[40])[0] = rslt.getVarchar(29);
                ((string[]) buf[41])[0] = rslt.getVarchar(30);
                ((string[]) buf[42])[0] = rslt.getVarchar(31);
                ((short[]) buf[43])[0] = rslt.getShort(32);
                return;
       }
    }

 }

}
