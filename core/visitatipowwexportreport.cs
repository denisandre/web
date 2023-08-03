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
   public class visitatipowwexportreport : GXWebProcedure
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

      public visitatipowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitatipowwexportreport( IGxContext context )
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
         visitatipowwexportreport objvisitatipowwexportreport;
         objvisitatipowwexportreport = new visitatipowwexportreport();
         objvisitatipowwexportreport.context.SetSubmitInitialConfig(context);
         objvisitatipowwexportreport.initialize();
         Submit( executePrivateCatch,objvisitatipowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitatipowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("VisitaTipoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visitatipoww_Execute", out  GXt_boolean1) ;
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
               AV33Title = "Lista de Tipo de Visita";
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
            H5U0( true, 0) ;
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
         if ( ! (false==AV35VitDel_Filtro) )
         {
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV35VitDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFVitSigla_Sel)) )
         {
            AV22TempBoolean = (bool)(((StringUtil.StrCmp(AV19TFVitSigla_Sel, "<#Empty#>")==0)));
            AV19TFVitSigla_Sel = (AV22TempBoolean ? "(Vazio)" : AV19TFVitSigla_Sel);
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19TFVitSigla_Sel, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV19TFVitSigla_Sel = (AV22TempBoolean ? "<#Empty#>" : AV19TFVitSigla_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFVitSigla)) )
            {
               H5U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TFVitSigla, "")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFVitNome_Sel)) )
         {
            AV22TempBoolean = (bool)(((StringUtil.StrCmp(AV21TFVitNome_Sel, "<#Empty#>")==0)));
            AV21TFVitNome_Sel = (AV22TempBoolean ? "(Vazio)" : AV21TFVitNome_Sel);
            H5U0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21TFVitNome_Sel, "@!")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV21TFVitNome_Sel = (AV22TempBoolean ? "<#Empty#>" : AV21TFVitNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFVitNome)) )
            {
               H5U0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 99, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20TFVitNome, "@!")), 99, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5U0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5U0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Sigla", 30, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 410, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV39Core_visitatipowwds_1_vitdel_filtro = AV35VitDel_Filtro;
         AV40Core_visitatipowwds_2_filterfulltext = AV13FilterFullText;
         AV41Core_visitatipowwds_3_tfvitsigla = AV18TFVitSigla;
         AV42Core_visitatipowwds_4_tfvitsigla_sel = AV19TFVitSigla_Sel;
         AV43Core_visitatipowwds_5_tfvitnome = AV20TFVitNome;
         AV44Core_visitatipowwds_6_tfvitnome_sel = AV21TFVitNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Core_visitatipowwds_2_filterfulltext ,
                                              AV42Core_visitatipowwds_4_tfvitsigla_sel ,
                                              AV41Core_visitatipowwds_3_tfvitsigla ,
                                              AV44Core_visitatipowwds_6_tfvitnome_sel ,
                                              AV43Core_visitatipowwds_5_tfvitnome ,
                                              A412VitSigla ,
                                              A413VitNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A596VitDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV40Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Core_visitatipowwds_2_filterfulltext), "%", "");
         lV40Core_visitatipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Core_visitatipowwds_2_filterfulltext), "%", "");
         lV41Core_visitatipowwds_3_tfvitsigla = StringUtil.Concat( StringUtil.RTrim( AV41Core_visitatipowwds_3_tfvitsigla), "%", "");
         lV43Core_visitatipowwds_5_tfvitnome = StringUtil.Concat( StringUtil.RTrim( AV43Core_visitatipowwds_5_tfvitnome), "%", "");
         /* Using cursor P005U2 */
         pr_default.execute(0, new Object[] {lV40Core_visitatipowwds_2_filterfulltext, lV40Core_visitatipowwds_2_filterfulltext, lV41Core_visitatipowwds_3_tfvitsigla, AV42Core_visitatipowwds_4_tfvitsigla_sel, lV43Core_visitatipowwds_5_tfvitnome, AV44Core_visitatipowwds_6_tfvitnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A413VitNome = P005U2_A413VitNome[0];
            A412VitSigla = P005U2_A412VitSigla[0];
            A596VitDel = P005U2_A596VitDel[0];
            A411VitID = P005U2_A411VitID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5U0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A412VitSigla, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A413VitNome, "@!")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV14Session.Get("core.VisitaTipoWWGridState"), "") == 0 )
         {
            AV16GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.VisitaTipoWWGridState"), null, "", "");
         }
         else
         {
            AV16GridState.FromXml(AV14Session.Get("core.VisitaTipoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV16GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV16GridState.gxTpr_Ordereddsc;
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV16GridState.gxTpr_Filtervalues.Count )
         {
            AV17GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV16GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "VITDEL_FILTRO") == 0 )
            {
               AV35VitDel_Filtro = BooleanUtil.Val( AV17GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFVITSIGLA") == 0 )
            {
               AV18TFVitSigla = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFVITSIGLA_SEL") == 0 )
            {
               AV19TFVitSigla_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFVITNOME") == 0 )
            {
               AV20TFVitNome = AV17GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV17GridStateFilterValue.gxTpr_Name, "TFVITNOME_SEL") == 0 )
            {
               AV21TFVitNome_Sel = AV17GridStateFilterValue.gxTpr_Value;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
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

      protected void H5U0( bool bFoot ,
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
                  AV31PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV28DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV26AppName = "DVelop Software Solutions";
               AV32Phone = "+1 550 8923";
               AV30Mail = "info@mail.com";
               AV34Website = "http://www.web.com";
               AV23AddressLine1 = "French Boulevard 2859";
               AV24AddressLine2 = "Downtown";
               AV25AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV33Title = "";
         AV13FilterFullText = "";
         AV19TFVitSigla_Sel = "";
         AV18TFVitSigla = "";
         AV21TFVitNome_Sel = "";
         AV20TFVitNome = "";
         AV40Core_visitatipowwds_2_filterfulltext = "";
         AV41Core_visitatipowwds_3_tfvitsigla = "";
         AV42Core_visitatipowwds_4_tfvitsigla_sel = "";
         AV43Core_visitatipowwds_5_tfvitnome = "";
         AV44Core_visitatipowwds_6_tfvitnome_sel = "";
         scmdbuf = "";
         lV40Core_visitatipowwds_2_filterfulltext = "";
         lV41Core_visitatipowwds_3_tfvitsigla = "";
         lV43Core_visitatipowwds_5_tfvitnome = "";
         A412VitSigla = "";
         A413VitNome = "";
         P005U2_A413VitNome = new string[] {""} ;
         P005U2_A412VitSigla = new string[] {""} ;
         P005U2_A596VitDel = new bool[] {false} ;
         P005U2_A411VitID = new int[1] ;
         AV14Session = context.GetSession();
         AV16GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV17GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV31PageInfo = "";
         AV28DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV26AppName = "";
         AV32Phone = "";
         AV30Mail = "";
         AV34Website = "";
         AV23AddressLine1 = "";
         AV24AddressLine2 = "";
         AV25AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005U2_A413VitNome, P005U2_A412VitSigla, P005U2_A596VitDel, P005U2_A411VitID
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
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A411VitID ;
      private int AV45GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV35VitDel_Filtro ;
      private bool AV22TempBoolean ;
      private bool AV39Core_visitatipowwds_1_vitdel_filtro ;
      private bool AV12OrderedDsc ;
      private bool A596VitDel ;
      private string AV33Title ;
      private string AV13FilterFullText ;
      private string AV19TFVitSigla_Sel ;
      private string AV18TFVitSigla ;
      private string AV21TFVitNome_Sel ;
      private string AV20TFVitNome ;
      private string AV40Core_visitatipowwds_2_filterfulltext ;
      private string AV41Core_visitatipowwds_3_tfvitsigla ;
      private string AV42Core_visitatipowwds_4_tfvitsigla_sel ;
      private string AV43Core_visitatipowwds_5_tfvitnome ;
      private string AV44Core_visitatipowwds_6_tfvitnome_sel ;
      private string lV40Core_visitatipowwds_2_filterfulltext ;
      private string lV41Core_visitatipowwds_3_tfvitsigla ;
      private string lV43Core_visitatipowwds_5_tfvitnome ;
      private string A412VitSigla ;
      private string A413VitNome ;
      private string AV31PageInfo ;
      private string AV28DateInfo ;
      private string AV26AppName ;
      private string AV32Phone ;
      private string AV30Mail ;
      private string AV34Website ;
      private string AV23AddressLine1 ;
      private string AV24AddressLine2 ;
      private string AV25AddressLine3 ;
      private IGxSession AV14Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005U2_A413VitNome ;
      private string[] P005U2_A412VitSigla ;
      private bool[] P005U2_A596VitDel ;
      private int[] P005U2_A411VitID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV16GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV17GridStateFilterValue ;
   }

   public class visitatipowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005U2( IGxContext context ,
                                             string AV40Core_visitatipowwds_2_filterfulltext ,
                                             string AV42Core_visitatipowwds_4_tfvitsigla_sel ,
                                             string AV41Core_visitatipowwds_3_tfvitsigla ,
                                             string AV44Core_visitatipowwds_6_tfvitnome_sel ,
                                             string AV43Core_visitatipowwds_5_tfvitnome ,
                                             string A412VitSigla ,
                                             string A413VitNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A596VitDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT VitNome, VitSigla, VitDel, VitID FROM tb_visitatipo";
         AddWhere(sWhereString, "(Not VitDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Core_visitatipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( VitSigla like '%' || :lV40Core_visitatipowwds_2_filterfulltext) or ( VitNome like '%' || :lV40Core_visitatipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42Core_visitatipowwds_4_tfvitsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Core_visitatipowwds_3_tfvitsigla)) ) )
         {
            AddWhere(sWhereString, "(VitSigla like :lV41Core_visitatipowwds_3_tfvitsigla)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Core_visitatipowwds_4_tfvitsigla_sel)) && ! ( StringUtil.StrCmp(AV42Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitSigla = ( :AV42Core_visitatipowwds_4_tfvitsigla_sel))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV42Core_visitatipowwds_4_tfvitsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_6_tfvitnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Core_visitatipowwds_5_tfvitnome)) ) )
         {
            AddWhere(sWhereString, "(VitNome like :lV43Core_visitatipowwds_5_tfvitnome)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Core_visitatipowwds_6_tfvitnome_sel)) && ! ( StringUtil.StrCmp(AV44Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(VitNome = ( :AV44Core_visitatipowwds_6_tfvitnome_sel))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Core_visitatipowwds_6_tfvitnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from VitNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY VitSigla";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY VitSigla DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY VitNome";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY VitNome DESC";
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
                     return conditional_P005U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (bool)dynConstraints[9] );
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
          Object[] prmP005U2;
          prmP005U2 = new Object[] {
          new ParDef("lV40Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Core_visitatipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV41Core_visitatipowwds_3_tfvitsigla",GXType.VarChar,20,0) ,
          new ParDef("AV42Core_visitatipowwds_4_tfvitsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV43Core_visitatipowwds_5_tfvitnome",GXType.VarChar,80,0) ,
          new ParDef("AV44Core_visitatipowwds_6_tfvitnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
