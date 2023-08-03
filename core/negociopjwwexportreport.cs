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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class negociopjwwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public negociopjwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         negociopjwwexportreport objnegociopjwwexportreport;
         objnegociopjwwexportreport = new negociopjwwexportreport();
         objnegociopjwwexportreport.context.SetSubmitInitialConfig(context);
         objnegociopjwwexportreport.initialize();
         Submit( executePrivateCatch,objnegociopjwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((negociopjwwexportreport)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("NegocioPJWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negociopjww_Execute", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV81Title = "Lista de Oportunidade de Negócio";
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H540( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! (false==AV88NegDel) )
         {
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV88NegDel), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "NEGASSUNTO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16NegAssunto1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16NegAssunto1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterNegAssuntoDescription = StringUtil.Format( "%1 (%2)", "Assunto", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterNegAssuntoDescription = StringUtil.Format( "%1 (%2)", "Assunto", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18NegAssunto = AV16NegAssunto1;
                  H540( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterNegAssuntoDescription, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18NegAssunto, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "NEGASSUNTO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22NegAssunto2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22NegAssunto2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterNegAssuntoDescription = StringUtil.Format( "%1 (%2)", "Assunto", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterNegAssuntoDescription = StringUtil.Format( "%1 (%2)", "Assunto", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18NegAssunto = AV22NegAssunto2;
                     H540( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterNegAssuntoDescription, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18NegAssunto, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "NEGASSUNTO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26NegAssunto3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26NegAssunto3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterNegAssuntoDescription = StringUtil.Format( "%1 (%2)", "Assunto", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterNegAssuntoDescription = StringUtil.Format( "%1 (%2)", "Assunto", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18NegAssunto = AV26NegAssunto3;
                        H540( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterNegAssuntoDescription, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18NegAssunto, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV32TFNegCodigo) && (0==AV33TFNegCodigo_To) ) )
         {
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Negociação", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFNegCodigo), "ZZZZZZZZZZZ9")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV64TFNegCodigo_To_Description = StringUtil.Format( "%1 (%2)", "Negociação", "Até", "", "", "", "", "", "", "");
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFNegCodigo_To_Description, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFNegCodigo_To), "ZZZZZZZZZZZ9")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFNegAssunto_Sel)) )
         {
            AV70TempBoolean = (bool)(((StringUtil.StrCmp(AV63TFNegAssunto_Sel, "<#Empty#>")==0)));
            AV63TFNegAssunto_Sel = (AV70TempBoolean ? "(Vazio)" : AV63TFNegAssunto_Sel);
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Assunto", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TFNegAssunto_Sel, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV63TFNegAssunto_Sel = (AV70TempBoolean ? "<#Empty#>" : AV63TFNegAssunto_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFNegAssunto)) )
            {
               H540( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Assunto", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFNegAssunto, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFNegCliNomeFamiliar_Sel)) )
         {
            AV70TempBoolean = (bool)(((StringUtil.StrCmp(AV45TFNegCliNomeFamiliar_Sel, "<#Empty#>")==0)));
            AV45TFNegCliNomeFamiliar_Sel = (AV70TempBoolean ? "(Vazio)" : AV45TFNegCliNomeFamiliar_Sel);
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Cliente", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFNegCliNomeFamiliar_Sel, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFNegCliNomeFamiliar_Sel = (AV70TempBoolean ? "<#Empty#>" : AV45TFNegCliNomeFamiliar_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFNegCliNomeFamiliar)) )
            {
               H540( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cliente", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFNegCliNomeFamiliar, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFNegCpjNomFan_Sel)) )
         {
            AV70TempBoolean = (bool)(((StringUtil.StrCmp(AV47TFNegCpjNomFan_Sel, "<#Empty#>")==0)));
            AV47TFNegCpjNomFan_Sel = (AV70TempBoolean ? "(Vazio)" : AV47TFNegCpjNomFan_Sel);
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Unidade", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFNegCpjNomFan_Sel, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV47TFNegCpjNomFan_Sel = (AV70TempBoolean ? "<#Empty#>" : AV47TFNegCpjNomFan_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFNegCpjNomFan)) )
            {
               H540( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Unidade", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFNegCpjNomFan, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV50TFNegCpjMatricula) && (0==AV51TFNegCpjMatricula_To) ) )
         {
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Matrícula", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV50TFNegCpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV68TFNegCpjMatricula_To_Description = StringUtil.Format( "%1 (%2)", "Matrícula", "Até", "", "", "", "", "", "", "");
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFNegCpjMatricula_To_Description, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV51TFNegCpjMatricula_To), "ZZZ,ZZZ,ZZZ,ZZ9")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFNegPjtNome_Sel)) )
         {
            AV70TempBoolean = (bool)(((StringUtil.StrCmp(AV57TFNegPjtNome_Sel, "<#Empty#>")==0)));
            AV57TFNegPjtNome_Sel = (AV70TempBoolean ? "(Vazio)" : AV57TFNegPjtNome_Sel);
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFNegPjtNome_Sel, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV57TFNegPjtNome_Sel = (AV70TempBoolean ? "<#Empty#>" : AV57TFNegPjtNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFNegPjtNome)) )
            {
               H540( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFNegPjtNome, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFNegAgcNome_Sel)) )
         {
            AV70TempBoolean = (bool)(((StringUtil.StrCmp(AV61TFNegAgcNome_Sel, "<#Empty#>")==0)));
            AV61TFNegAgcNome_Sel = (AV70TempBoolean ? "(Vazio)" : AV61TFNegAgcNome_Sel);
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Agente Comercial", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFNegAgcNome_Sel, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV61TFNegAgcNome_Sel = (AV70TempBoolean ? "<#Empty#>" : AV61TFNegAgcNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFNegAgcNome)) )
            {
               H540( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Agente Comercial", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFNegAgcNome, "@!")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV85TFNegValorAtualizado) && (Convert.ToDecimal(0)==AV86TFNegValorAtualizado_To) ) )
         {
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total em Negócios", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85TFNegValorAtualizado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV87TFNegValorAtualizado_To_Description = StringUtil.Format( "%1 (%2)", "Total em Negócios", "Até", "", "", "", "", "", "", "");
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87TFNegValorAtualizado_To_Description, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV86TFNegValorAtualizado_To, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV34TFNegInsData) && (DateTime.MinValue==AV35TFNegInsData_To) ) )
         {
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído em", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV34TFNegInsData, "99/99/99"), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV65TFNegInsData_To_Description = StringUtil.Format( "%1 (%2)", "Incluído em", "Até", "", "", "", "", "", "", "");
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFNegInsData_To_Description, "")), 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV35TFNegInsData_To, "99/99/99"), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFNegInsUsuNome_Sel)) )
         {
            AV70TempBoolean = (bool)(((StringUtil.StrCmp(AV84TFNegInsUsuNome_Sel, "<#Empty#>")==0)));
            AV84TFNegInsUsuNome_Sel = (AV70TempBoolean ? "(Vazio)" : AV84TFNegInsUsuNome_Sel);
            H540( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído por", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TFNegInsUsuNome_Sel, "")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV84TFNegInsUsuNome_Sel = (AV70TempBoolean ? "<#Empty#>" : AV84TFNegInsUsuNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFNegInsUsuNome)) )
            {
               H540( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Incluído por", 25, Gx_line+0, 151, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFNegInsUsuNome, "")), 151, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H540( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H540( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Negociação", 30, Gx_line+10, 102, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Assunto", 106, Gx_line+10, 178, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Cliente", 182, Gx_line+10, 254, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Unidade", 258, Gx_line+10, 330, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Matrícula", 334, Gx_line+10, 406, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 410, Gx_line+10, 482, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Agente Comercial", 486, Gx_line+10, 558, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Total em Negócios", 562, Gx_line+10, 634, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Incluído em", 638, Gx_line+10, 710, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Incluído por", 714, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV92Core_negociopjwwds_1_negdel = AV88NegDel;
         AV93Core_negociopjwwds_2_filterfulltext = AV13FilterFullText;
         AV94Core_negociopjwwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV95Core_negociopjwwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV96Core_negociopjwwds_5_negassunto1 = AV16NegAssunto1;
         AV97Core_negociopjwwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Core_negociopjwwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Core_negociopjwwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Core_negociopjwwds_9_negassunto2 = AV22NegAssunto2;
         AV101Core_negociopjwwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV102Core_negociopjwwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV103Core_negociopjwwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV104Core_negociopjwwds_13_negassunto3 = AV26NegAssunto3;
         AV105Core_negociopjwwds_14_tfnegcodigo = AV32TFNegCodigo;
         AV106Core_negociopjwwds_15_tfnegcodigo_to = AV33TFNegCodigo_To;
         AV107Core_negociopjwwds_16_tfnegassunto = AV62TFNegAssunto;
         AV108Core_negociopjwwds_17_tfnegassunto_sel = AV63TFNegAssunto_Sel;
         AV109Core_negociopjwwds_18_tfnegclinomefamiliar = AV44TFNegCliNomeFamiliar;
         AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV45TFNegCliNomeFamiliar_Sel;
         AV111Core_negociopjwwds_20_tfnegcpjnomfan = AV46TFNegCpjNomFan;
         AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV47TFNegCpjNomFan_Sel;
         AV113Core_negociopjwwds_22_tfnegcpjmatricula = AV50TFNegCpjMatricula;
         AV114Core_negociopjwwds_23_tfnegcpjmatricula_to = AV51TFNegCpjMatricula_To;
         AV115Core_negociopjwwds_24_tfnegpjtnome = AV56TFNegPjtNome;
         AV116Core_negociopjwwds_25_tfnegpjtnome_sel = AV57TFNegPjtNome_Sel;
         AV117Core_negociopjwwds_26_tfnegagcnome = AV60TFNegAgcNome;
         AV118Core_negociopjwwds_27_tfnegagcnome_sel = AV61TFNegAgcNome_Sel;
         AV119Core_negociopjwwds_28_tfnegvaloratualizado = AV85TFNegValorAtualizado;
         AV120Core_negociopjwwds_29_tfnegvaloratualizado_to = AV86TFNegValorAtualizado_To;
         AV121Core_negociopjwwds_30_tfneginsdata = AV34TFNegInsData;
         AV122Core_negociopjwwds_31_tfneginsdata_to = AV35TFNegInsData_To;
         AV123Core_negociopjwwds_32_tfneginsusunome = AV83TFNegInsUsuNome;
         AV124Core_negociopjwwds_33_tfneginsusunome_sel = AV84TFNegInsUsuNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV93Core_negociopjwwds_2_filterfulltext ,
                                              AV94Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV95Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV96Core_negociopjwwds_5_negassunto1 ,
                                              AV97Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV98Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV99Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV100Core_negociopjwwds_9_negassunto2 ,
                                              AV101Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV102Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV103Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV104Core_negociopjwwds_13_negassunto3 ,
                                              AV105Core_negociopjwwds_14_tfnegcodigo ,
                                              AV106Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV108Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV107Core_negociopjwwds_16_tfnegassunto ,
                                              AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV109Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV111Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV113Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV114Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV116Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV115Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV118Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV117Core_negociopjwwds_26_tfnegagcnome ,
                                              AV119Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV120Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV121Core_negociopjwwds_30_tfneginsdata ,
                                              AV122Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV124Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV123Core_negociopjwwds_32_tfneginsusunome ,
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
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV93Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext), "%", "");
         lV96Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_5_negassunto1), "%", "");
         lV96Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV96Core_negociopjwwds_5_negassunto1), "%", "");
         lV100Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV100Core_negociopjwwds_9_negassunto2), "%", "");
         lV100Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV100Core_negociopjwwds_9_negassunto2), "%", "");
         lV104Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV104Core_negociopjwwds_13_negassunto3), "%", "");
         lV104Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV104Core_negociopjwwds_13_negassunto3), "%", "");
         lV107Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV107Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV109Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV109Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV111Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV111Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV115Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV117Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV117Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV123Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV123Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor P00542 */
         pr_default.execute(0, new Object[] {lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV93Core_negociopjwwds_2_filterfulltext, lV96Core_negociopjwwds_5_negassunto1, lV96Core_negociopjwwds_5_negassunto1, lV100Core_negociopjwwds_9_negassunto2, lV100Core_negociopjwwds_9_negassunto2, lV104Core_negociopjwwds_13_negassunto3, lV104Core_negociopjwwds_13_negassunto3, AV105Core_negociopjwwds_14_tfnegcodigo, AV106Core_negociopjwwds_15_tfnegcodigo_to, lV107Core_negociopjwwds_16_tfnegassunto, AV108Core_negociopjwwds_17_tfnegassunto_sel, lV109Core_negociopjwwds_18_tfnegclinomefamiliar, AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV111Core_negociopjwwds_20_tfnegcpjnomfan, AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV113Core_negociopjwwds_22_tfnegcpjmatricula, AV114Core_negociopjwwds_23_tfnegcpjmatricula_to, lV115Core_negociopjwwds_24_tfnegpjtnome, AV116Core_negociopjwwds_25_tfnegpjtnome_sel, lV117Core_negociopjwwds_26_tfnegagcnome, AV118Core_negociopjwwds_27_tfnegagcnome_sel, AV119Core_negociopjwwds_28_tfnegvaloratualizado, AV120Core_negociopjwwds_29_tfnegvaloratualizado_to, AV121Core_negociopjwwds_30_tfneginsdata, AV122Core_negociopjwwds_31_tfneginsdata_to, lV123Core_negociopjwwds_32_tfneginsusunome, AV124Core_negociopjwwds_33_tfneginsusunome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A350NegCliID = P00542_A350NegCliID[0];
            A352NegCpjID = P00542_A352NegCpjID[0];
            A346NegInsData = P00542_A346NegInsData[0];
            A385NegValorAtualizado = P00542_A385NegValorAtualizado[0];
            A355NegCpjMatricula = P00542_A355NegCpjMatricula[0];
            A356NegCodigo = P00542_A356NegCodigo[0];
            A364NegInsUsuNome = P00542_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P00542_n364NegInsUsuNome[0];
            A361NegAgcNome = P00542_A361NegAgcNome[0];
            n361NegAgcNome = P00542_n361NegAgcNome[0];
            A359NegPjtNome = P00542_A359NegPjtNome[0];
            A353NegCpjNomFan = P00542_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = P00542_A351NegCliNomeFamiliar[0];
            A362NegAssunto = P00542_A362NegAssunto[0];
            A572NegDel = P00542_A572NegDel[0];
            A345NegID = P00542_A345NegID[0];
            A355NegCpjMatricula = P00542_A355NegCpjMatricula[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H540( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9")), 30, Gx_line+10, 102, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")), 106, Gx_line+10, 178, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A351NegCliNomeFamiliar, "@!")), 182, Gx_line+10, 254, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A353NegCpjNomFan, "@!")), 258, Gx_line+10, 330, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A355NegCpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 334, Gx_line+10, 406, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A359NegPjtNome, "@!")), 410, Gx_line+10, 482, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A361NegAgcNome, "@!")), 486, Gx_line+10, 558, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A385NegValorAtualizado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")), 562, Gx_line+10, 634, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A346NegInsData, "99/99/99"), 638, Gx_line+10, 710, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A364NegInsUsuNome, "")), 714, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
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

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("core.NegocioPJWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.NegocioPJWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.NegocioPJWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV125GXV1 = 1;
         while ( AV125GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV125GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "NEGDEL") == 0 )
            {
               AV88NegDel = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGCODIGO") == 0 )
            {
               AV32TFNegCodigo = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV33TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO") == 0 )
            {
               AV62TFNegAssunto = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO_SEL") == 0 )
            {
               AV63TFNegAssunto_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR") == 0 )
            {
               AV44TFNegCliNomeFamiliar = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV45TFNegCliNomeFamiliar_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN") == 0 )
            {
               AV46TFNegCpjNomFan = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN_SEL") == 0 )
            {
               AV47TFNegCpjNomFan_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGCPJMATRICULA") == 0 )
            {
               AV50TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV51TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME") == 0 )
            {
               AV56TFNegPjtNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME_SEL") == 0 )
            {
               AV57TFNegPjtNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME") == 0 )
            {
               AV60TFNegAgcNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME_SEL") == 0 )
            {
               AV61TFNegAgcNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGVALORATUALIZADO") == 0 )
            {
               AV85TFNegValorAtualizado = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV86TFNegValorAtualizado_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGINSDATA") == 0 )
            {
               AV34TFNegInsData = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, 2);
               AV35TFNegInsData_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME") == 0 )
            {
               AV83TFNegInsUsuNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME_SEL") == 0 )
            {
               AV84TFNegInsUsuNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV125GXV1 = (int)(AV125GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H540( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV79PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV76DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV74AppName = "DVelop Software Solutions";
               AV80Phone = "+1 550 8923";
               AV78Mail = "info@mail.com";
               AV82Website = "http://www.web.com";
               AV71AddressLine1 = "French Boulevard 2859";
               AV72AddressLine2 = "Downtown";
               AV73AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV81Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16NegAssunto1 = "";
         AV17FilterNegAssuntoDescription = "";
         AV18NegAssunto = "";
         AV20DynamicFiltersSelector2 = "";
         AV22NegAssunto2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26NegAssunto3 = "";
         AV64TFNegCodigo_To_Description = "";
         AV63TFNegAssunto_Sel = "";
         AV62TFNegAssunto = "";
         AV45TFNegCliNomeFamiliar_Sel = "";
         AV44TFNegCliNomeFamiliar = "";
         AV47TFNegCpjNomFan_Sel = "";
         AV46TFNegCpjNomFan = "";
         AV68TFNegCpjMatricula_To_Description = "";
         AV57TFNegPjtNome_Sel = "";
         AV56TFNegPjtNome = "";
         AV61TFNegAgcNome_Sel = "";
         AV60TFNegAgcNome = "";
         AV87TFNegValorAtualizado_To_Description = "";
         AV34TFNegInsData = DateTime.MinValue;
         AV35TFNegInsData_To = DateTime.MinValue;
         AV65TFNegInsData_To_Description = "";
         AV84TFNegInsUsuNome_Sel = "";
         AV83TFNegInsUsuNome = "";
         AV93Core_negociopjwwds_2_filterfulltext = "";
         AV94Core_negociopjwwds_3_dynamicfiltersselector1 = "";
         AV96Core_negociopjwwds_5_negassunto1 = "";
         AV98Core_negociopjwwds_7_dynamicfiltersselector2 = "";
         AV100Core_negociopjwwds_9_negassunto2 = "";
         AV102Core_negociopjwwds_11_dynamicfiltersselector3 = "";
         AV104Core_negociopjwwds_13_negassunto3 = "";
         AV107Core_negociopjwwds_16_tfnegassunto = "";
         AV108Core_negociopjwwds_17_tfnegassunto_sel = "";
         AV109Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel = "";
         AV111Core_negociopjwwds_20_tfnegcpjnomfan = "";
         AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel = "";
         AV115Core_negociopjwwds_24_tfnegpjtnome = "";
         AV116Core_negociopjwwds_25_tfnegpjtnome_sel = "";
         AV117Core_negociopjwwds_26_tfnegagcnome = "";
         AV118Core_negociopjwwds_27_tfnegagcnome_sel = "";
         AV121Core_negociopjwwds_30_tfneginsdata = DateTime.MinValue;
         AV122Core_negociopjwwds_31_tfneginsdata_to = DateTime.MinValue;
         AV123Core_negociopjwwds_32_tfneginsusunome = "";
         AV124Core_negociopjwwds_33_tfneginsusunome_sel = "";
         scmdbuf = "";
         lV93Core_negociopjwwds_2_filterfulltext = "";
         lV96Core_negociopjwwds_5_negassunto1 = "";
         lV100Core_negociopjwwds_9_negassunto2 = "";
         lV104Core_negociopjwwds_13_negassunto3 = "";
         lV107Core_negociopjwwds_16_tfnegassunto = "";
         lV109Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         lV111Core_negociopjwwds_20_tfnegcpjnomfan = "";
         lV115Core_negociopjwwds_24_tfnegpjtnome = "";
         lV117Core_negociopjwwds_26_tfnegagcnome = "";
         lV123Core_negociopjwwds_32_tfneginsusunome = "";
         A362NegAssunto = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         A359NegPjtNome = "";
         A361NegAgcNome = "";
         A364NegInsUsuNome = "";
         A346NegInsData = DateTime.MinValue;
         P00542_A350NegCliID = new Guid[] {Guid.Empty} ;
         P00542_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P00542_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P00542_A385NegValorAtualizado = new decimal[1] ;
         P00542_A355NegCpjMatricula = new long[1] ;
         P00542_A356NegCodigo = new long[1] ;
         P00542_A364NegInsUsuNome = new string[] {""} ;
         P00542_n364NegInsUsuNome = new bool[] {false} ;
         P00542_A361NegAgcNome = new string[] {""} ;
         P00542_n361NegAgcNome = new bool[] {false} ;
         P00542_A359NegPjtNome = new string[] {""} ;
         P00542_A353NegCpjNomFan = new string[] {""} ;
         P00542_A351NegCliNomeFamiliar = new string[] {""} ;
         P00542_A362NegAssunto = new string[] {""} ;
         P00542_A572NegDel = new bool[] {false} ;
         P00542_A345NegID = new Guid[] {Guid.Empty} ;
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         A345NegID = Guid.Empty;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV79PageInfo = "";
         AV76DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV74AppName = "";
         AV80Phone = "";
         AV78Mail = "";
         AV82Website = "";
         AV71AddressLine1 = "";
         AV72AddressLine2 = "";
         AV73AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00542_A350NegCliID, P00542_A352NegCpjID, P00542_A346NegInsData, P00542_A385NegValorAtualizado, P00542_A355NegCpjMatricula, P00542_A356NegCodigo, P00542_A364NegInsUsuNome, P00542_n364NegInsUsuNome, P00542_A361NegAgcNome, P00542_n361NegAgcNome,
               P00542_A359NegPjtNome, P00542_A353NegCpjNomFan, P00542_A351NegCliNomeFamiliar, P00542_A362NegAssunto, P00542_A572NegDel, P00542_A345NegID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV95Core_negociopjwwds_4_dynamicfiltersoperator1 ;
      private short AV99Core_negociopjwwds_8_dynamicfiltersoperator2 ;
      private short AV103Core_negociopjwwds_12_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV125GXV1 ;
      private long AV32TFNegCodigo ;
      private long AV33TFNegCodigo_To ;
      private long AV50TFNegCpjMatricula ;
      private long AV51TFNegCpjMatricula_To ;
      private long AV105Core_negociopjwwds_14_tfnegcodigo ;
      private long AV106Core_negociopjwwds_15_tfnegcodigo_to ;
      private long AV113Core_negociopjwwds_22_tfnegcpjmatricula ;
      private long AV114Core_negociopjwwds_23_tfnegcpjmatricula_to ;
      private long A356NegCodigo ;
      private long A355NegCpjMatricula ;
      private decimal AV85TFNegValorAtualizado ;
      private decimal AV86TFNegValorAtualizado_To ;
      private decimal AV119Core_negociopjwwds_28_tfnegvaloratualizado ;
      private decimal AV120Core_negociopjwwds_29_tfnegvaloratualizado_to ;
      private decimal A385NegValorAtualizado ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV34TFNegInsData ;
      private DateTime AV35TFNegInsData_To ;
      private DateTime AV121Core_negociopjwwds_30_tfneginsdata ;
      private DateTime AV122Core_negociopjwwds_31_tfneginsdata_to ;
      private DateTime A346NegInsData ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV88NegDel ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV70TempBoolean ;
      private bool AV92Core_negociopjwwds_1_negdel ;
      private bool AV97Core_negociopjwwds_6_dynamicfiltersenabled2 ;
      private bool AV101Core_negociopjwwds_10_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A572NegDel ;
      private bool n364NegInsUsuNome ;
      private bool n361NegAgcNome ;
      private string AV81Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16NegAssunto1 ;
      private string AV17FilterNegAssuntoDescription ;
      private string AV18NegAssunto ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22NegAssunto2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26NegAssunto3 ;
      private string AV64TFNegCodigo_To_Description ;
      private string AV63TFNegAssunto_Sel ;
      private string AV62TFNegAssunto ;
      private string AV45TFNegCliNomeFamiliar_Sel ;
      private string AV44TFNegCliNomeFamiliar ;
      private string AV47TFNegCpjNomFan_Sel ;
      private string AV46TFNegCpjNomFan ;
      private string AV68TFNegCpjMatricula_To_Description ;
      private string AV57TFNegPjtNome_Sel ;
      private string AV56TFNegPjtNome ;
      private string AV61TFNegAgcNome_Sel ;
      private string AV60TFNegAgcNome ;
      private string AV87TFNegValorAtualizado_To_Description ;
      private string AV65TFNegInsData_To_Description ;
      private string AV84TFNegInsUsuNome_Sel ;
      private string AV83TFNegInsUsuNome ;
      private string AV93Core_negociopjwwds_2_filterfulltext ;
      private string AV94Core_negociopjwwds_3_dynamicfiltersselector1 ;
      private string AV96Core_negociopjwwds_5_negassunto1 ;
      private string AV98Core_negociopjwwds_7_dynamicfiltersselector2 ;
      private string AV100Core_negociopjwwds_9_negassunto2 ;
      private string AV102Core_negociopjwwds_11_dynamicfiltersselector3 ;
      private string AV104Core_negociopjwwds_13_negassunto3 ;
      private string AV107Core_negociopjwwds_16_tfnegassunto ;
      private string AV108Core_negociopjwwds_17_tfnegassunto_sel ;
      private string AV109Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel ;
      private string AV111Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel ;
      private string AV115Core_negociopjwwds_24_tfnegpjtnome ;
      private string AV116Core_negociopjwwds_25_tfnegpjtnome_sel ;
      private string AV117Core_negociopjwwds_26_tfnegagcnome ;
      private string AV118Core_negociopjwwds_27_tfnegagcnome_sel ;
      private string AV123Core_negociopjwwds_32_tfneginsusunome ;
      private string AV124Core_negociopjwwds_33_tfneginsusunome_sel ;
      private string lV93Core_negociopjwwds_2_filterfulltext ;
      private string lV96Core_negociopjwwds_5_negassunto1 ;
      private string lV100Core_negociopjwwds_9_negassunto2 ;
      private string lV104Core_negociopjwwds_13_negassunto3 ;
      private string lV107Core_negociopjwwds_16_tfnegassunto ;
      private string lV109Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string lV111Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string lV115Core_negociopjwwds_24_tfnegpjtnome ;
      private string lV117Core_negociopjwwds_26_tfnegagcnome ;
      private string lV123Core_negociopjwwds_32_tfneginsusunome ;
      private string A362NegAssunto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A359NegPjtNome ;
      private string A361NegAgcNome ;
      private string A364NegInsUsuNome ;
      private string AV79PageInfo ;
      private string AV76DateInfo ;
      private string AV74AppName ;
      private string AV80Phone ;
      private string AV78Mail ;
      private string AV82Website ;
      private string AV71AddressLine1 ;
      private string AV72AddressLine2 ;
      private string AV73AddressLine3 ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A345NegID ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00542_A350NegCliID ;
      private Guid[] P00542_A352NegCpjID ;
      private DateTime[] P00542_A346NegInsData ;
      private decimal[] P00542_A385NegValorAtualizado ;
      private long[] P00542_A355NegCpjMatricula ;
      private long[] P00542_A356NegCodigo ;
      private string[] P00542_A364NegInsUsuNome ;
      private bool[] P00542_n364NegInsUsuNome ;
      private string[] P00542_A361NegAgcNome ;
      private bool[] P00542_n361NegAgcNome ;
      private string[] P00542_A359NegPjtNome ;
      private string[] P00542_A353NegCpjNomFan ;
      private string[] P00542_A351NegCliNomeFamiliar ;
      private string[] P00542_A362NegAssunto ;
      private bool[] P00542_A572NegDel ;
      private Guid[] P00542_A345NegID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class negociopjwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00542( IGxContext context ,
                                             string AV93Core_negociopjwwds_2_filterfulltext ,
                                             string AV94Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV95Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV96Core_negociopjwwds_5_negassunto1 ,
                                             bool AV97Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV98Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV99Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV100Core_negociopjwwds_9_negassunto2 ,
                                             bool AV101Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV102Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV103Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV104Core_negociopjwwds_13_negassunto3 ,
                                             long AV105Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV106Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV108Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV107Core_negociopjwwds_16_tfnegassunto ,
                                             string AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV109Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV111Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV113Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV114Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV116Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV115Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV118Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV117Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV119Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV120Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV121Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV122Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV124Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV123Core_negociopjwwds_32_tfneginsusunome ,
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
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[35];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegInsData, T1.NegValorAtualizado, T2.CpjMatricula AS NegCpjMatricula, T1.NegCodigo, T1.NegInsUsuNome, T1.NegAgcNome, T1.NegPjtNome, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegAssunto, T1.NegDel, T1.NegID FROM (tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV93Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV93Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV96Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV94Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV95Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV96Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV97Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV99Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV100Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV97Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV99Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV100Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV101Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV103Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV104Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV101Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV102Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV103Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV104Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (0==AV105Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV105Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV106Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV106Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV107Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV108Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV108Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV108Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV109Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV111Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV113Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV113Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (0==AV114Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV114Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV115Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV116Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV116Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV117Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV118Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV118Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( StringUtil.StrCmp(AV118Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV119Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV119Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV120Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV120Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV121Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV121Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV122Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV122Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV123Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV124Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV124Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( StringUtil.StrCmp(AV124Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegAssunto";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegAssunto DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegCodigo";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegCodigo DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegCliNomeFamiliar";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegCliNomeFamiliar DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegCpjNomFan";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegCpjNomFan DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CpjMatricula";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CpjMatricula DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegPjtNome";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegPjtNome DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegAgcNome";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegAgcNome DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegValorAtualizado";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegValorAtualizado DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegInsData";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegInsData DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.NegInsUsuNome";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.NegInsUsuNome DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00542(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (bool)dynConstraints[44] );
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
          Object[] prmP00542;
          prmP00542 = new Object[] {
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV93Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV96Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV96Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV100Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV100Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV104Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV104Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV105Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV106Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV107Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV108Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV109Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV111Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV112Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV113Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV114Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV115Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV117Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV118Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV119Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV120Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV121Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV122Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV123Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV124Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00542", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00542,100, GxCacheFrequency.OFF ,true,false )
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
