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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class visita_bc : GxSilentTrn, IGxSilentTrn
   {
      public visita_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visita_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1440( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1440( ) ;
         standaloneModal( ) ;
         AddRow1440( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11142 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z398VisID = A398VisID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_140( )
      {
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1440( ) ;
            }
            else
            {
               CheckExtendedTable1440( ) ;
               if ( AnyError == 0 )
               {
                  ZM1440( 38) ;
                  ZM1440( 39) ;
                  ZM1440( 40) ;
                  ZM1440( 41) ;
                  ZM1440( 42) ;
                  ZM1440( 43) ;
                  ZM1440( 44) ;
               }
               CloseExtendedTableCursors1440( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12142( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV46Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV47GXV1 = 1;
            while ( AV47GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV47GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisPaiID") == 0 )
               {
                  AV13Insert_VisPaiID = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisTipoID") == 0 )
               {
                  AV14Insert_VisTipoID = (int)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisNegID") == 0 )
               {
                  AV15Insert_VisNegID = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisNgfSeq") == 0 )
               {
                  AV16Insert_VisNgfSeq = (int)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV47GXV1 = (int)(AV47GXV1+1);
            }
         }
      }

      protected void E11142( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV43AuditingObject,  AV46Pgmname) ;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM1440( short GX_JID )
      {
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z401VisInsDataHora = A401VisInsDataHora;
            Z399VisInsData = A399VisInsData;
            Z400VisInsHora = A400VisInsHora;
            Z402VisInsUsuID = A402VisInsUsuID;
            Z403VisInsUsuNome = A403VisInsUsuNome;
            Z490VisDelDataHora = A490VisDelDataHora;
            Z488VisDelData = A488VisDelData;
            Z489VisDelHora = A489VisDelHora;
            Z491VisDelUsuID = A491VisDelUsuID;
            Z492VisDelUsuNome = A492VisDelUsuNome;
            Z482VisUpdData = A482VisUpdData;
            Z483VisUpdHora = A483VisUpdHora;
            Z484VisUpdDataHora = A484VisUpdDataHora;
            Z485VisUpdUsuID = A485VisUpdUsuID;
            Z486VisUpdUsuNome = A486VisUpdUsuNome;
            Z404VisData = A404VisData;
            Z405VisHora = A405VisHora;
            Z406VisDataHora = A406VisDataHora;
            Z475VisDataFim = A475VisDataFim;
            Z476VisHoraFim = A476VisHoraFim;
            Z477VisDataHoraFim = A477VisDataHoraFim;
            Z409VisAssunto = A409VisAssunto;
            Z417VisLink = A417VisLink;
            Z472VisSituacao = A472VisSituacao;
            Z487VisDel = A487VisDel;
            Z414VisTipoID = A414VisTipoID;
            Z418VisNegID = A418VisNegID;
            Z422VisNgfSeq = A422VisNgfSeq;
            Z419VisPaiID = A419VisPaiID;
         }
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
            Z415VisTipoSigla = A415VisTipoSigla;
            Z416VisTipoNome = A416VisTipoNome;
         }
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            Z466VisNegCodigo = A466VisNegCodigo;
            Z467VisNegAssunto = A467VisNegAssunto;
            Z468VisNegValor = A468VisNegValor;
            Z407VisNegCliID = A407VisNegCliID;
            Z408VisNegCpjID = A408VisNegCpjID;
         }
         if ( ( GX_JID == 40 ) || ( GX_JID == 0 ) )
         {
            Z423VisNgfIteID = A423VisNgfIteID;
         }
         if ( ( GX_JID == 41 ) || ( GX_JID == 0 ) )
         {
            Z460VisPaiData = A460VisPaiData;
            Z461VisPaiHora = A461VisPaiHora;
            Z462VisPaiDataHora = A462VisPaiDataHora;
            Z465VisPaiAssunto = A465VisPaiAssunto;
         }
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            Z469VisNegCliNomeFamiliar = A469VisNegCliNomeFamiliar;
         }
         if ( ( GX_JID == 43 ) || ( GX_JID == 0 ) )
         {
            Z470VisNegCpjNomFan = A470VisNegCpjNomFan;
            Z471VisNegCpjRazSocial = A471VisNegCpjRazSocial;
         }
         if ( ( GX_JID == 44 ) || ( GX_JID == 0 ) )
         {
            Z424VisNgfIteNome = A424VisNgfIteNome;
         }
         if ( GX_JID == -37 )
         {
            Z398VisID = A398VisID;
            Z401VisInsDataHora = A401VisInsDataHora;
            Z399VisInsData = A399VisInsData;
            Z400VisInsHora = A400VisInsHora;
            Z402VisInsUsuID = A402VisInsUsuID;
            Z403VisInsUsuNome = A403VisInsUsuNome;
            Z490VisDelDataHora = A490VisDelDataHora;
            Z488VisDelData = A488VisDelData;
            Z489VisDelHora = A489VisDelHora;
            Z491VisDelUsuID = A491VisDelUsuID;
            Z492VisDelUsuNome = A492VisDelUsuNome;
            Z482VisUpdData = A482VisUpdData;
            Z483VisUpdHora = A483VisUpdHora;
            Z484VisUpdDataHora = A484VisUpdDataHora;
            Z485VisUpdUsuID = A485VisUpdUsuID;
            Z486VisUpdUsuNome = A486VisUpdUsuNome;
            Z404VisData = A404VisData;
            Z405VisHora = A405VisHora;
            Z406VisDataHora = A406VisDataHora;
            Z475VisDataFim = A475VisDataFim;
            Z476VisHoraFim = A476VisHoraFim;
            Z477VisDataHoraFim = A477VisDataHoraFim;
            Z409VisAssunto = A409VisAssunto;
            Z410VisDescricao = A410VisDescricao;
            Z417VisLink = A417VisLink;
            Z472VisSituacao = A472VisSituacao;
            Z487VisDel = A487VisDel;
            Z414VisTipoID = A414VisTipoID;
            Z418VisNegID = A418VisNegID;
            Z422VisNgfSeq = A422VisNgfSeq;
            Z419VisPaiID = A419VisPaiID;
            Z460VisPaiData = A460VisPaiData;
            Z461VisPaiHora = A461VisPaiHora;
            Z462VisPaiDataHora = A462VisPaiDataHora;
            Z465VisPaiAssunto = A465VisPaiAssunto;
            Z415VisTipoSigla = A415VisTipoSigla;
            Z416VisTipoNome = A416VisTipoNome;
            Z466VisNegCodigo = A466VisNegCodigo;
            Z467VisNegAssunto = A467VisNegAssunto;
            Z468VisNegValor = A468VisNegValor;
            Z407VisNegCliID = A407VisNegCliID;
            Z408VisNegCpjID = A408VisNegCpjID;
            Z469VisNegCliNomeFamiliar = A469VisNegCliNomeFamiliar;
            Z470VisNegCpjNomFan = A470VisNegCpjNomFan;
            Z471VisNegCpjRazSocial = A471VisNegCpjRazSocial;
            Z423VisNgfIteID = A423VisNgfIteID;
            Z424VisNgfIteNome = A424VisNgfIteNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV46Pgmname = "core.Visita_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A398VisID) )
         {
            A398VisID = Guid.NewGuid( );
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A472VisSituacao)) && ( Gx_BScreen == 0 ) )
         {
            A472VisSituacao = "PEN";
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1440( )
      {
         /* Using cursor BC001411 */
         pr_default.execute(9, new Object[] {A398VisID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound40 = 1;
            A401VisInsDataHora = BC001411_A401VisInsDataHora[0];
            A399VisInsData = BC001411_A399VisInsData[0];
            A400VisInsHora = BC001411_A400VisInsHora[0];
            A402VisInsUsuID = BC001411_A402VisInsUsuID[0];
            n402VisInsUsuID = BC001411_n402VisInsUsuID[0];
            A403VisInsUsuNome = BC001411_A403VisInsUsuNome[0];
            n403VisInsUsuNome = BC001411_n403VisInsUsuNome[0];
            A490VisDelDataHora = BC001411_A490VisDelDataHora[0];
            n490VisDelDataHora = BC001411_n490VisDelDataHora[0];
            A488VisDelData = BC001411_A488VisDelData[0];
            n488VisDelData = BC001411_n488VisDelData[0];
            A489VisDelHora = BC001411_A489VisDelHora[0];
            n489VisDelHora = BC001411_n489VisDelHora[0];
            A491VisDelUsuID = BC001411_A491VisDelUsuID[0];
            n491VisDelUsuID = BC001411_n491VisDelUsuID[0];
            A492VisDelUsuNome = BC001411_A492VisDelUsuNome[0];
            n492VisDelUsuNome = BC001411_n492VisDelUsuNome[0];
            A460VisPaiData = BC001411_A460VisPaiData[0];
            A461VisPaiHora = BC001411_A461VisPaiHora[0];
            A462VisPaiDataHora = BC001411_A462VisPaiDataHora[0];
            A465VisPaiAssunto = BC001411_A465VisPaiAssunto[0];
            A482VisUpdData = BC001411_A482VisUpdData[0];
            n482VisUpdData = BC001411_n482VisUpdData[0];
            A483VisUpdHora = BC001411_A483VisUpdHora[0];
            n483VisUpdHora = BC001411_n483VisUpdHora[0];
            A484VisUpdDataHora = BC001411_A484VisUpdDataHora[0];
            n484VisUpdDataHora = BC001411_n484VisUpdDataHora[0];
            A485VisUpdUsuID = BC001411_A485VisUpdUsuID[0];
            n485VisUpdUsuID = BC001411_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = BC001411_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = BC001411_n486VisUpdUsuNome[0];
            A404VisData = BC001411_A404VisData[0];
            A405VisHora = BC001411_A405VisHora[0];
            A406VisDataHora = BC001411_A406VisDataHora[0];
            A475VisDataFim = BC001411_A475VisDataFim[0];
            n475VisDataFim = BC001411_n475VisDataFim[0];
            A476VisHoraFim = BC001411_A476VisHoraFim[0];
            n476VisHoraFim = BC001411_n476VisHoraFim[0];
            A477VisDataHoraFim = BC001411_A477VisDataHoraFim[0];
            n477VisDataHoraFim = BC001411_n477VisDataHoraFim[0];
            A415VisTipoSigla = BC001411_A415VisTipoSigla[0];
            A416VisTipoNome = BC001411_A416VisTipoNome[0];
            A466VisNegCodigo = BC001411_A466VisNegCodigo[0];
            A467VisNegAssunto = BC001411_A467VisNegAssunto[0];
            A468VisNegValor = BC001411_A468VisNegValor[0];
            A469VisNegCliNomeFamiliar = BC001411_A469VisNegCliNomeFamiliar[0];
            A470VisNegCpjNomFan = BC001411_A470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = BC001411_A471VisNegCpjRazSocial[0];
            A424VisNgfIteNome = BC001411_A424VisNgfIteNome[0];
            A409VisAssunto = BC001411_A409VisAssunto[0];
            A410VisDescricao = BC001411_A410VisDescricao[0];
            n410VisDescricao = BC001411_n410VisDescricao[0];
            A417VisLink = BC001411_A417VisLink[0];
            n417VisLink = BC001411_n417VisLink[0];
            A472VisSituacao = BC001411_A472VisSituacao[0];
            A487VisDel = BC001411_A487VisDel[0];
            A414VisTipoID = BC001411_A414VisTipoID[0];
            A418VisNegID = BC001411_A418VisNegID[0];
            n418VisNegID = BC001411_n418VisNegID[0];
            A422VisNgfSeq = BC001411_A422VisNgfSeq[0];
            n422VisNgfSeq = BC001411_n422VisNgfSeq[0];
            A419VisPaiID = BC001411_A419VisPaiID[0];
            n419VisPaiID = BC001411_n419VisPaiID[0];
            A407VisNegCliID = BC001411_A407VisNegCliID[0];
            A408VisNegCpjID = BC001411_A408VisNegCpjID[0];
            A423VisNgfIteID = BC001411_A423VisNgfIteID[0];
            ZM1440( -37) ;
         }
         pr_default.close(9);
         OnLoadActions1440( ) ;
      }

      protected void OnLoadActions1440( )
      {
         if ( true /* After */ )
         {
            A406VisDataHora = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A404VisData)), (short)(DateTimeUtil.Month( A404VisData)), (short)(DateTimeUtil.Day( A404VisData)), (short)(DateTimeUtil.Hour( A405VisHora)), (short)(DateTimeUtil.Minute( A405VisHora)), 0);
         }
         if ( IsIns( )  && (DateTime.MinValue==A475VisDataFim) && ( Gx_BScreen == 0 ) )
         {
            A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
            n475VisDataFim = false;
         }
         if ( IsIns( )  && (DateTime.MinValue==A476VisHoraFim) && ( Gx_BScreen == 0 ) )
         {
            A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
            n476VisHoraFim = false;
         }
         if ( true /* After */ )
         {
            A477VisDataHoraFim = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A475VisDataFim)), (short)(DateTimeUtil.Month( A475VisDataFim)), (short)(DateTimeUtil.Day( A475VisDataFim)), (short)(DateTimeUtil.Hour( A476VisHoraFim)), (short)(DateTimeUtil.Minute( A476VisHoraFim)), 0);
            n477VisDataHoraFim = false;
         }
      }

      protected void CheckExtendedTable1440( )
      {
         nIsDirty_40 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00147 */
         pr_default.execute(5, new Object[] {n419VisPaiID, A419VisPaiID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A419VisPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'Visita Origem'.", "ForeignKeyNotFound", 1, "VISPAIID");
               AnyError = 1;
            }
         }
         A460VisPaiData = BC00147_A460VisPaiData[0];
         A461VisPaiHora = BC00147_A461VisPaiHora[0];
         A462VisPaiDataHora = BC00147_A462VisPaiDataHora[0];
         A465VisPaiAssunto = BC00147_A465VisPaiAssunto[0];
         pr_default.close(5);
         if ( (DateTime.MinValue==A404VisData) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Data da Visita", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( true /* After */ )
         {
            nIsDirty_40 = 1;
            A406VisDataHora = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A404VisData)), (short)(DateTimeUtil.Month( A404VisData)), (short)(DateTimeUtil.Day( A404VisData)), (short)(DateTimeUtil.Hour( A405VisHora)), (short)(DateTimeUtil.Minute( A405VisHora)), 0);
         }
         if ( A405VisHora == DateTime.MinValue )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Hora da Visita", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00144 */
         pr_default.execute(2, new Object[] {A414VisTipoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo de Visita'.", "ForeignKeyNotFound", 1, "VISTIPOID");
            AnyError = 1;
         }
         A415VisTipoSigla = BC00144_A415VisTipoSigla[0];
         A416VisTipoNome = BC00144_A416VisTipoNome[0];
         pr_default.close(2);
         if ( (0==A414VisTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Tipo da Visita", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00145 */
         pr_default.execute(3, new Object[] {n418VisNegID, A418VisNegID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A418VisNegID) ) )
            {
               GX_msglist.addItem("Não existe 'Negociação da Visita'.", "ForeignKeyNotFound", 1, "VISNEGID");
               AnyError = 1;
            }
         }
         A466VisNegCodigo = BC00145_A466VisNegCodigo[0];
         A467VisNegAssunto = BC00145_A467VisNegAssunto[0];
         A468VisNegValor = BC00145_A468VisNegValor[0];
         A407VisNegCliID = BC00145_A407VisNegCliID[0];
         A408VisNegCpjID = BC00145_A408VisNegCpjID[0];
         pr_default.close(3);
         /* Using cursor BC00148 */
         pr_default.execute(6, new Object[] {A407VisNegCliID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A407VisNegCliID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "VISNEGCLIID");
               AnyError = 1;
            }
         }
         A469VisNegCliNomeFamiliar = BC00148_A469VisNegCliNomeFamiliar[0];
         pr_default.close(6);
         /* Using cursor BC00149 */
         pr_default.execute(7, new Object[] {A407VisNegCliID, A408VisNegCpjID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A407VisNegCliID) || (Guid.Empty==A408VisNegCpjID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "VISNEGCPJID");
               AnyError = 1;
            }
         }
         A470VisNegCpjNomFan = BC00149_A470VisNegCpjNomFan[0];
         A471VisNegCpjRazSocial = BC00149_A471VisNegCpjRazSocial[0];
         pr_default.close(7);
         /* Using cursor BC00146 */
         pr_default.execute(4, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A418VisNegID) || (0==A422VisNgfSeq) ) )
            {
               GX_msglist.addItem("Não existe 'Negociação da Visita'.", "ForeignKeyNotFound", 1, "VISNGFSEQ");
               AnyError = 1;
            }
         }
         A423VisNgfIteID = BC00146_A423VisNgfIteID[0];
         pr_default.close(4);
         /* Using cursor BC001410 */
         pr_default.execute(8, new Object[] {A423VisNgfIteID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A423VisNgfIteID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "VISNGFITEID");
               AnyError = 1;
            }
         }
         A424VisNgfIteNome = BC001410_A424VisNgfIteNome[0];
         pr_default.close(8);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A409VisAssunto)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Assunto da Visita", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A417VisLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A417VisLink)) ) )
         {
            GX_msglist.addItem("O valor de Link da Visita (Virtual) não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A472VisSituacao, "PEN") == 0 ) || ( StringUtil.StrCmp(A472VisSituacao, "REA") == 0 ) || ( StringUtil.StrCmp(A472VisSituacao, "REM") == 0 ) || ( StringUtil.StrCmp(A472VisSituacao, "CAN") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Situação fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A475VisDataFim) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_40 = 1;
            A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
            n475VisDataFim = false;
         }
         if ( IsIns( )  && (DateTime.MinValue==A476VisHoraFim) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_40 = 1;
            A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
            n476VisHoraFim = false;
         }
         if ( (DateTime.MinValue==A475VisDataFim) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Data de Término da Visita", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( true /* After */ )
         {
            nIsDirty_40 = 1;
            A477VisDataHoraFim = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A475VisDataFim)), (short)(DateTimeUtil.Month( A475VisDataFim)), (short)(DateTimeUtil.Day( A475VisDataFim)), (short)(DateTimeUtil.Hour( A476VisHoraFim)), (short)(DateTimeUtil.Minute( A476VisHoraFim)), 0);
            n477VisDataHoraFim = false;
         }
         if ( A476VisHoraFim == DateTime.MinValue )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Hora de Término da Hora", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( true /* After */ && ( A477VisDataHoraFim < A406VisDataHora ) )
         {
            GX_msglist.addItem("A data e hora de término da visita não pode ser anterior à data e hora de início da visita", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1440( )
      {
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(4);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1440( )
      {
         /* Using cursor BC001412 */
         pr_default.execute(10, new Object[] {A398VisID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00143 */
         pr_default.execute(1, new Object[] {A398VisID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1440( 37) ;
            RcdFound40 = 1;
            A398VisID = BC00143_A398VisID[0];
            A401VisInsDataHora = BC00143_A401VisInsDataHora[0];
            A399VisInsData = BC00143_A399VisInsData[0];
            A400VisInsHora = BC00143_A400VisInsHora[0];
            A402VisInsUsuID = BC00143_A402VisInsUsuID[0];
            n402VisInsUsuID = BC00143_n402VisInsUsuID[0];
            A403VisInsUsuNome = BC00143_A403VisInsUsuNome[0];
            n403VisInsUsuNome = BC00143_n403VisInsUsuNome[0];
            A490VisDelDataHora = BC00143_A490VisDelDataHora[0];
            n490VisDelDataHora = BC00143_n490VisDelDataHora[0];
            A488VisDelData = BC00143_A488VisDelData[0];
            n488VisDelData = BC00143_n488VisDelData[0];
            A489VisDelHora = BC00143_A489VisDelHora[0];
            n489VisDelHora = BC00143_n489VisDelHora[0];
            A491VisDelUsuID = BC00143_A491VisDelUsuID[0];
            n491VisDelUsuID = BC00143_n491VisDelUsuID[0];
            A492VisDelUsuNome = BC00143_A492VisDelUsuNome[0];
            n492VisDelUsuNome = BC00143_n492VisDelUsuNome[0];
            A482VisUpdData = BC00143_A482VisUpdData[0];
            n482VisUpdData = BC00143_n482VisUpdData[0];
            A483VisUpdHora = BC00143_A483VisUpdHora[0];
            n483VisUpdHora = BC00143_n483VisUpdHora[0];
            A484VisUpdDataHora = BC00143_A484VisUpdDataHora[0];
            n484VisUpdDataHora = BC00143_n484VisUpdDataHora[0];
            A485VisUpdUsuID = BC00143_A485VisUpdUsuID[0];
            n485VisUpdUsuID = BC00143_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = BC00143_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = BC00143_n486VisUpdUsuNome[0];
            A404VisData = BC00143_A404VisData[0];
            A405VisHora = BC00143_A405VisHora[0];
            A406VisDataHora = BC00143_A406VisDataHora[0];
            A475VisDataFim = BC00143_A475VisDataFim[0];
            n475VisDataFim = BC00143_n475VisDataFim[0];
            A476VisHoraFim = BC00143_A476VisHoraFim[0];
            n476VisHoraFim = BC00143_n476VisHoraFim[0];
            A477VisDataHoraFim = BC00143_A477VisDataHoraFim[0];
            n477VisDataHoraFim = BC00143_n477VisDataHoraFim[0];
            A409VisAssunto = BC00143_A409VisAssunto[0];
            A410VisDescricao = BC00143_A410VisDescricao[0];
            n410VisDescricao = BC00143_n410VisDescricao[0];
            A417VisLink = BC00143_A417VisLink[0];
            n417VisLink = BC00143_n417VisLink[0];
            A472VisSituacao = BC00143_A472VisSituacao[0];
            A487VisDel = BC00143_A487VisDel[0];
            A414VisTipoID = BC00143_A414VisTipoID[0];
            A418VisNegID = BC00143_A418VisNegID[0];
            n418VisNegID = BC00143_n418VisNegID[0];
            A422VisNgfSeq = BC00143_A422VisNgfSeq[0];
            n422VisNgfSeq = BC00143_n422VisNgfSeq[0];
            A419VisPaiID = BC00143_A419VisPaiID[0];
            n419VisPaiID = BC00143_n419VisPaiID[0];
            O487VisDel = A487VisDel;
            Z398VisID = A398VisID;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1440( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1440( ) ;
            }
            Gx_mode = sMode40;
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1440( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode40;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1440( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_140( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1440( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00142 */
            pr_default.execute(0, new Object[] {A398VisID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visita"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z401VisInsDataHora != BC00142_A401VisInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z399VisInsData ) != DateTimeUtil.ResetTime ( BC00142_A399VisInsData[0] ) ) || ( Z400VisInsHora != BC00142_A400VisInsHora[0] ) || ( StringUtil.StrCmp(Z402VisInsUsuID, BC00142_A402VisInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z403VisInsUsuNome, BC00142_A403VisInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z490VisDelDataHora != BC00142_A490VisDelDataHora[0] ) || ( Z488VisDelData != BC00142_A488VisDelData[0] ) || ( Z489VisDelHora != BC00142_A489VisDelHora[0] ) || ( StringUtil.StrCmp(Z491VisDelUsuID, BC00142_A491VisDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z492VisDelUsuNome, BC00142_A492VisDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z482VisUpdData ) != DateTimeUtil.ResetTime ( BC00142_A482VisUpdData[0] ) ) || ( Z483VisUpdHora != BC00142_A483VisUpdHora[0] ) || ( Z484VisUpdDataHora != BC00142_A484VisUpdDataHora[0] ) || ( StringUtil.StrCmp(Z485VisUpdUsuID, BC00142_A485VisUpdUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z486VisUpdUsuNome, BC00142_A486VisUpdUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z404VisData ) != DateTimeUtil.ResetTime ( BC00142_A404VisData[0] ) ) || ( Z405VisHora != BC00142_A405VisHora[0] ) || ( Z406VisDataHora != BC00142_A406VisDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z475VisDataFim ) != DateTimeUtil.ResetTime ( BC00142_A475VisDataFim[0] ) ) || ( Z476VisHoraFim != BC00142_A476VisHoraFim[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z477VisDataHoraFim != BC00142_A477VisDataHoraFim[0] ) || ( StringUtil.StrCmp(Z409VisAssunto, BC00142_A409VisAssunto[0]) != 0 ) || ( StringUtil.StrCmp(Z417VisLink, BC00142_A417VisLink[0]) != 0 ) || ( StringUtil.StrCmp(Z472VisSituacao, BC00142_A472VisSituacao[0]) != 0 ) || ( Z487VisDel != BC00142_A487VisDel[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z414VisTipoID != BC00142_A414VisTipoID[0] ) || ( Z418VisNegID != BC00142_A418VisNegID[0] ) || ( Z422VisNgfSeq != BC00142_A422VisNgfSeq[0] ) || ( Z419VisPaiID != BC00142_A419VisPaiID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_visita"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1440( )
      {
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1440( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1440( 0) ;
            CheckOptimisticConcurrency1440( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1440( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1440( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001413 */
                     pr_default.execute(11, new Object[] {A398VisID, A401VisInsDataHora, A399VisInsData, A400VisInsHora, n402VisInsUsuID, A402VisInsUsuID, n403VisInsUsuNome, A403VisInsUsuNome, n490VisDelDataHora, A490VisDelDataHora, n488VisDelData, A488VisDelData, n489VisDelHora, A489VisDelHora, n491VisDelUsuID, A491VisDelUsuID, n492VisDelUsuNome, A492VisDelUsuNome, n482VisUpdData, A482VisUpdData, n483VisUpdHora, A483VisUpdHora, n484VisUpdDataHora, A484VisUpdDataHora, n485VisUpdUsuID, A485VisUpdUsuID, n486VisUpdUsuNome, A486VisUpdUsuNome, A404VisData, A405VisHora, A406VisDataHora, n475VisDataFim, A475VisDataFim, n476VisHoraFim, A476VisHoraFim, n477VisDataHoraFim, A477VisDataHoraFim, A409VisAssunto, n410VisDescricao, A410VisDescricao, n417VisLink, A417VisLink, A472VisSituacao, A487VisDel, A414VisTipoID, n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq, n419VisPaiID, A419VisPaiID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visita");
                     if ( (pr_default.getStatus(11) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1440( ) ;
            }
            EndLevel1440( ) ;
         }
         CloseExtendedTableCursors1440( ) ;
      }

      protected void Update1440( )
      {
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1440( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1440( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1440( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1440( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001414 */
                     pr_default.execute(12, new Object[] {A401VisInsDataHora, A399VisInsData, A400VisInsHora, n402VisInsUsuID, A402VisInsUsuID, n403VisInsUsuNome, A403VisInsUsuNome, n490VisDelDataHora, A490VisDelDataHora, n488VisDelData, A488VisDelData, n489VisDelHora, A489VisDelHora, n491VisDelUsuID, A491VisDelUsuID, n492VisDelUsuNome, A492VisDelUsuNome, n482VisUpdData, A482VisUpdData, n483VisUpdHora, A483VisUpdHora, n484VisUpdDataHora, A484VisUpdDataHora, n485VisUpdUsuID, A485VisUpdUsuID, n486VisUpdUsuNome, A486VisUpdUsuNome, A404VisData, A405VisHora, A406VisDataHora, n475VisDataFim, A475VisDataFim, n476VisHoraFim, A476VisHoraFim, n477VisDataHoraFim, A477VisDataHoraFim, A409VisAssunto, n410VisDescricao, A410VisDescricao, n417VisLink, A417VisLink, A472VisSituacao, A487VisDel, A414VisTipoID, n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq, n419VisPaiID, A419VisPaiID, A398VisID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visita");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visita"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1440( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1440( ) ;
         }
         CloseExtendedTableCursors1440( ) ;
      }

      protected void DeferredUpdate1440( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1440( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1440( ) ;
            AfterConfirm1440( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1440( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001415 */
                  pr_default.execute(13, new Object[] {A398VisID});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("tb_visita");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1440( ) ;
         Gx_mode = sMode40;
      }

      protected void OnDeleteControls1440( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001416 */
            pr_default.execute(14, new Object[] {n419VisPaiID, A419VisPaiID});
            A460VisPaiData = BC001416_A460VisPaiData[0];
            A461VisPaiHora = BC001416_A461VisPaiHora[0];
            A462VisPaiDataHora = BC001416_A462VisPaiDataHora[0];
            A465VisPaiAssunto = BC001416_A465VisPaiAssunto[0];
            pr_default.close(14);
            /* Using cursor BC001417 */
            pr_default.execute(15, new Object[] {A414VisTipoID});
            A415VisTipoSigla = BC001417_A415VisTipoSigla[0];
            A416VisTipoNome = BC001417_A416VisTipoNome[0];
            pr_default.close(15);
            /* Using cursor BC001418 */
            pr_default.execute(16, new Object[] {n418VisNegID, A418VisNegID});
            A466VisNegCodigo = BC001418_A466VisNegCodigo[0];
            A467VisNegAssunto = BC001418_A467VisNegAssunto[0];
            A468VisNegValor = BC001418_A468VisNegValor[0];
            A407VisNegCliID = BC001418_A407VisNegCliID[0];
            A408VisNegCpjID = BC001418_A408VisNegCpjID[0];
            pr_default.close(16);
            /* Using cursor BC001419 */
            pr_default.execute(17, new Object[] {A407VisNegCliID});
            A469VisNegCliNomeFamiliar = BC001419_A469VisNegCliNomeFamiliar[0];
            pr_default.close(17);
            /* Using cursor BC001420 */
            pr_default.execute(18, new Object[] {A407VisNegCliID, A408VisNegCpjID});
            A470VisNegCpjNomFan = BC001420_A470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = BC001420_A471VisNegCpjRazSocial[0];
            pr_default.close(18);
            /* Using cursor BC001421 */
            pr_default.execute(19, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
            A423VisNgfIteID = BC001421_A423VisNgfIteID[0];
            pr_default.close(19);
            /* Using cursor BC001422 */
            pr_default.execute(20, new Object[] {A423VisNgfIteID});
            A424VisNgfIteNome = BC001422_A424VisNgfIteNome[0];
            pr_default.close(20);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001423 */
            pr_default.execute(21, new Object[] {A398VisID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel1440( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1440( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1440( )
      {
         /* Scan By routine */
         /* Using cursor BC001424 */
         pr_default.execute(22, new Object[] {A398VisID});
         RcdFound40 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound40 = 1;
            A398VisID = BC001424_A398VisID[0];
            A401VisInsDataHora = BC001424_A401VisInsDataHora[0];
            A399VisInsData = BC001424_A399VisInsData[0];
            A400VisInsHora = BC001424_A400VisInsHora[0];
            A402VisInsUsuID = BC001424_A402VisInsUsuID[0];
            n402VisInsUsuID = BC001424_n402VisInsUsuID[0];
            A403VisInsUsuNome = BC001424_A403VisInsUsuNome[0];
            n403VisInsUsuNome = BC001424_n403VisInsUsuNome[0];
            A490VisDelDataHora = BC001424_A490VisDelDataHora[0];
            n490VisDelDataHora = BC001424_n490VisDelDataHora[0];
            A488VisDelData = BC001424_A488VisDelData[0];
            n488VisDelData = BC001424_n488VisDelData[0];
            A489VisDelHora = BC001424_A489VisDelHora[0];
            n489VisDelHora = BC001424_n489VisDelHora[0];
            A491VisDelUsuID = BC001424_A491VisDelUsuID[0];
            n491VisDelUsuID = BC001424_n491VisDelUsuID[0];
            A492VisDelUsuNome = BC001424_A492VisDelUsuNome[0];
            n492VisDelUsuNome = BC001424_n492VisDelUsuNome[0];
            A460VisPaiData = BC001424_A460VisPaiData[0];
            A461VisPaiHora = BC001424_A461VisPaiHora[0];
            A462VisPaiDataHora = BC001424_A462VisPaiDataHora[0];
            A465VisPaiAssunto = BC001424_A465VisPaiAssunto[0];
            A482VisUpdData = BC001424_A482VisUpdData[0];
            n482VisUpdData = BC001424_n482VisUpdData[0];
            A483VisUpdHora = BC001424_A483VisUpdHora[0];
            n483VisUpdHora = BC001424_n483VisUpdHora[0];
            A484VisUpdDataHora = BC001424_A484VisUpdDataHora[0];
            n484VisUpdDataHora = BC001424_n484VisUpdDataHora[0];
            A485VisUpdUsuID = BC001424_A485VisUpdUsuID[0];
            n485VisUpdUsuID = BC001424_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = BC001424_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = BC001424_n486VisUpdUsuNome[0];
            A404VisData = BC001424_A404VisData[0];
            A405VisHora = BC001424_A405VisHora[0];
            A406VisDataHora = BC001424_A406VisDataHora[0];
            A475VisDataFim = BC001424_A475VisDataFim[0];
            n475VisDataFim = BC001424_n475VisDataFim[0];
            A476VisHoraFim = BC001424_A476VisHoraFim[0];
            n476VisHoraFim = BC001424_n476VisHoraFim[0];
            A477VisDataHoraFim = BC001424_A477VisDataHoraFim[0];
            n477VisDataHoraFim = BC001424_n477VisDataHoraFim[0];
            A415VisTipoSigla = BC001424_A415VisTipoSigla[0];
            A416VisTipoNome = BC001424_A416VisTipoNome[0];
            A466VisNegCodigo = BC001424_A466VisNegCodigo[0];
            A467VisNegAssunto = BC001424_A467VisNegAssunto[0];
            A468VisNegValor = BC001424_A468VisNegValor[0];
            A469VisNegCliNomeFamiliar = BC001424_A469VisNegCliNomeFamiliar[0];
            A470VisNegCpjNomFan = BC001424_A470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = BC001424_A471VisNegCpjRazSocial[0];
            A424VisNgfIteNome = BC001424_A424VisNgfIteNome[0];
            A409VisAssunto = BC001424_A409VisAssunto[0];
            A410VisDescricao = BC001424_A410VisDescricao[0];
            n410VisDescricao = BC001424_n410VisDescricao[0];
            A417VisLink = BC001424_A417VisLink[0];
            n417VisLink = BC001424_n417VisLink[0];
            A472VisSituacao = BC001424_A472VisSituacao[0];
            A487VisDel = BC001424_A487VisDel[0];
            A414VisTipoID = BC001424_A414VisTipoID[0];
            A418VisNegID = BC001424_A418VisNegID[0];
            n418VisNegID = BC001424_n418VisNegID[0];
            A422VisNgfSeq = BC001424_A422VisNgfSeq[0];
            n422VisNgfSeq = BC001424_n422VisNgfSeq[0];
            A419VisPaiID = BC001424_A419VisPaiID[0];
            n419VisPaiID = BC001424_n419VisPaiID[0];
            A407VisNegCliID = BC001424_A407VisNegCliID[0];
            A408VisNegCpjID = BC001424_A408VisNegCpjID[0];
            A423VisNgfIteID = BC001424_A423VisNgfIteID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1440( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound40 = 0;
         ScanKeyLoad1440( ) ;
      }

      protected void ScanKeyLoad1440( )
      {
         sMode40 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound40 = 1;
            A398VisID = BC001424_A398VisID[0];
            A401VisInsDataHora = BC001424_A401VisInsDataHora[0];
            A399VisInsData = BC001424_A399VisInsData[0];
            A400VisInsHora = BC001424_A400VisInsHora[0];
            A402VisInsUsuID = BC001424_A402VisInsUsuID[0];
            n402VisInsUsuID = BC001424_n402VisInsUsuID[0];
            A403VisInsUsuNome = BC001424_A403VisInsUsuNome[0];
            n403VisInsUsuNome = BC001424_n403VisInsUsuNome[0];
            A490VisDelDataHora = BC001424_A490VisDelDataHora[0];
            n490VisDelDataHora = BC001424_n490VisDelDataHora[0];
            A488VisDelData = BC001424_A488VisDelData[0];
            n488VisDelData = BC001424_n488VisDelData[0];
            A489VisDelHora = BC001424_A489VisDelHora[0];
            n489VisDelHora = BC001424_n489VisDelHora[0];
            A491VisDelUsuID = BC001424_A491VisDelUsuID[0];
            n491VisDelUsuID = BC001424_n491VisDelUsuID[0];
            A492VisDelUsuNome = BC001424_A492VisDelUsuNome[0];
            n492VisDelUsuNome = BC001424_n492VisDelUsuNome[0];
            A460VisPaiData = BC001424_A460VisPaiData[0];
            A461VisPaiHora = BC001424_A461VisPaiHora[0];
            A462VisPaiDataHora = BC001424_A462VisPaiDataHora[0];
            A465VisPaiAssunto = BC001424_A465VisPaiAssunto[0];
            A482VisUpdData = BC001424_A482VisUpdData[0];
            n482VisUpdData = BC001424_n482VisUpdData[0];
            A483VisUpdHora = BC001424_A483VisUpdHora[0];
            n483VisUpdHora = BC001424_n483VisUpdHora[0];
            A484VisUpdDataHora = BC001424_A484VisUpdDataHora[0];
            n484VisUpdDataHora = BC001424_n484VisUpdDataHora[0];
            A485VisUpdUsuID = BC001424_A485VisUpdUsuID[0];
            n485VisUpdUsuID = BC001424_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = BC001424_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = BC001424_n486VisUpdUsuNome[0];
            A404VisData = BC001424_A404VisData[0];
            A405VisHora = BC001424_A405VisHora[0];
            A406VisDataHora = BC001424_A406VisDataHora[0];
            A475VisDataFim = BC001424_A475VisDataFim[0];
            n475VisDataFim = BC001424_n475VisDataFim[0];
            A476VisHoraFim = BC001424_A476VisHoraFim[0];
            n476VisHoraFim = BC001424_n476VisHoraFim[0];
            A477VisDataHoraFim = BC001424_A477VisDataHoraFim[0];
            n477VisDataHoraFim = BC001424_n477VisDataHoraFim[0];
            A415VisTipoSigla = BC001424_A415VisTipoSigla[0];
            A416VisTipoNome = BC001424_A416VisTipoNome[0];
            A466VisNegCodigo = BC001424_A466VisNegCodigo[0];
            A467VisNegAssunto = BC001424_A467VisNegAssunto[0];
            A468VisNegValor = BC001424_A468VisNegValor[0];
            A469VisNegCliNomeFamiliar = BC001424_A469VisNegCliNomeFamiliar[0];
            A470VisNegCpjNomFan = BC001424_A470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = BC001424_A471VisNegCpjRazSocial[0];
            A424VisNgfIteNome = BC001424_A424VisNgfIteNome[0];
            A409VisAssunto = BC001424_A409VisAssunto[0];
            A410VisDescricao = BC001424_A410VisDescricao[0];
            n410VisDescricao = BC001424_n410VisDescricao[0];
            A417VisLink = BC001424_A417VisLink[0];
            n417VisLink = BC001424_n417VisLink[0];
            A472VisSituacao = BC001424_A472VisSituacao[0];
            A487VisDel = BC001424_A487VisDel[0];
            A414VisTipoID = BC001424_A414VisTipoID[0];
            A418VisNegID = BC001424_A418VisNegID[0];
            n418VisNegID = BC001424_n418VisNegID[0];
            A422VisNgfSeq = BC001424_A422VisNgfSeq[0];
            n422VisNgfSeq = BC001424_n422VisNgfSeq[0];
            A419VisPaiID = BC001424_A419VisPaiID[0];
            n419VisPaiID = BC001424_n419VisPaiID[0];
            A407VisNegCliID = BC001424_A407VisNegCliID[0];
            A408VisNegCpjID = BC001424_A408VisNegCpjID[0];
            A423VisNgfIteID = BC001424_A423VisNgfIteID[0];
         }
         Gx_mode = sMode40;
      }

      protected void ScanKeyEnd1440( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1440( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1440( )
      {
         /* Before Insert Rules */
         A401VisInsDataHora = DateTimeUtil.NowMS( context);
         A402VisInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n402VisInsUsuID = false;
         A403VisInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n403VisInsUsuNome = false;
         if ( ! (Guid.Empty==AV40VisPaiID) )
         {
            new GeneXus.Programs.core.prcvisitaremarcada(context ).execute(  AV40VisPaiID,  false,  new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get(), out  AV44Messages) ;
         }
         if ( ! (Guid.Empty==AV40VisPaiID) && ( ((GeneXus.Utils.SdtMessages_Message)AV44Messages.Item(1)).gxTpr_Type == 1 ) )
         {
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV44Messages.Item(1)).gxTpr_Description, 1, "");
            AnyError = 1;
         }
         A399VisInsData = DateTimeUtil.ResetTime( A401VisInsDataHora);
         A400VisInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A401VisInsDataHora));
      }

      protected void BeforeUpdate1440( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditvisita(context ).execute(  "Y", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A490VisDelDataHora = DateTimeUtil.NowMS( context);
            n490VisDelDataHora = false;
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A491VisDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n491VisDelUsuID = false;
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A492VisDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n492VisDelUsuNome = false;
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A488VisDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A490VisDelDataHora) ) ;
            n488VisDelData = false;
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A489VisDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A490VisDelDataHora));
            n489VisDelHora = false;
         }
      }

      protected void BeforeDelete1440( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditvisita(context ).execute(  "Y", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
      }

      protected void BeforeComplete1440( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditvisita(context ).execute(  "N", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditvisita(context ).execute(  "N", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1440( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1440( )
      {
      }

      protected void send_integrity_lvl_hashes1440( )
      {
      }

      protected void AddRow1440( )
      {
         VarsToRow40( bccore_Visita) ;
      }

      protected void ReadRow1440( )
      {
         RowToVars40( bccore_Visita, 1) ;
      }

      protected void InitializeNonKey1440( )
      {
         AV43AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A399VisInsData = DateTime.MinValue;
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         A402VisInsUsuID = "";
         n402VisInsUsuID = false;
         A403VisInsUsuNome = "";
         n403VisInsUsuNome = false;
         AV44Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         n490VisDelDataHora = false;
         A488VisDelData = (DateTime)(DateTime.MinValue);
         n488VisDelData = false;
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         n489VisDelHora = false;
         A491VisDelUsuID = "";
         n491VisDelUsuID = false;
         A492VisDelUsuNome = "";
         n492VisDelUsuNome = false;
         AV40VisPaiID = Guid.Empty;
         A419VisPaiID = Guid.Empty;
         n419VisPaiID = false;
         A460VisPaiData = DateTime.MinValue;
         A461VisPaiHora = (DateTime)(DateTime.MinValue);
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         A465VisPaiAssunto = "";
         A482VisUpdData = DateTime.MinValue;
         n482VisUpdData = false;
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         n483VisUpdHora = false;
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         n484VisUpdDataHora = false;
         A485VisUpdUsuID = "";
         n485VisUpdUsuID = false;
         A486VisUpdUsuNome = "";
         n486VisUpdUsuNome = false;
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         n477VisDataHoraFim = false;
         A414VisTipoID = 0;
         A415VisTipoSigla = "";
         A416VisTipoNome = "";
         A418VisNegID = Guid.Empty;
         n418VisNegID = false;
         A466VisNegCodigo = 0;
         A467VisNegAssunto = "";
         A468VisNegValor = 0;
         A407VisNegCliID = Guid.Empty;
         A469VisNegCliNomeFamiliar = "";
         A408VisNegCpjID = Guid.Empty;
         A470VisNegCpjNomFan = "";
         A471VisNegCpjRazSocial = "";
         A422VisNgfSeq = 0;
         n422VisNgfSeq = false;
         A423VisNgfIteID = Guid.Empty;
         A424VisNgfIteNome = "";
         A409VisAssunto = "";
         A410VisDescricao = "";
         n410VisDescricao = false;
         A417VisLink = "";
         n417VisLink = false;
         A487VisDel = false;
         A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
         n475VisDataFim = false;
         A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
         n476VisHoraFim = false;
         A472VisSituacao = "PEN";
         O487VisDel = A487VisDel;
         Z401VisInsDataHora = (DateTime)(DateTime.MinValue);
         Z399VisInsData = DateTime.MinValue;
         Z400VisInsHora = (DateTime)(DateTime.MinValue);
         Z402VisInsUsuID = "";
         Z403VisInsUsuNome = "";
         Z490VisDelDataHora = (DateTime)(DateTime.MinValue);
         Z488VisDelData = (DateTime)(DateTime.MinValue);
         Z489VisDelHora = (DateTime)(DateTime.MinValue);
         Z491VisDelUsuID = "";
         Z492VisDelUsuNome = "";
         Z482VisUpdData = DateTime.MinValue;
         Z483VisUpdHora = (DateTime)(DateTime.MinValue);
         Z484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         Z485VisUpdUsuID = "";
         Z486VisUpdUsuNome = "";
         Z404VisData = DateTime.MinValue;
         Z405VisHora = (DateTime)(DateTime.MinValue);
         Z406VisDataHora = (DateTime)(DateTime.MinValue);
         Z475VisDataFim = DateTime.MinValue;
         Z476VisHoraFim = (DateTime)(DateTime.MinValue);
         Z477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         Z409VisAssunto = "";
         Z417VisLink = "";
         Z472VisSituacao = "";
         Z487VisDel = false;
         Z414VisTipoID = 0;
         Z418VisNegID = Guid.Empty;
         Z422VisNgfSeq = 0;
         Z419VisPaiID = Guid.Empty;
      }

      protected void InitAll1440( )
      {
         A398VisID = Guid.NewGuid( );
         InitializeNonKey1440( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A472VisSituacao = i472VisSituacao;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow40( GeneXus.Programs.core.SdtVisita obj40 )
      {
         obj40.gxTpr_Mode = Gx_mode;
         obj40.gxTpr_Visinsdatahora = A401VisInsDataHora;
         obj40.gxTpr_Visinsdata = A399VisInsData;
         obj40.gxTpr_Visinshora = A400VisInsHora;
         obj40.gxTpr_Visinsusuid = A402VisInsUsuID;
         obj40.gxTpr_Visinsusunome = A403VisInsUsuNome;
         obj40.gxTpr_Visdeldatahora = A490VisDelDataHora;
         obj40.gxTpr_Visdeldata = A488VisDelData;
         obj40.gxTpr_Visdelhora = A489VisDelHora;
         obj40.gxTpr_Visdelusuid = A491VisDelUsuID;
         obj40.gxTpr_Visdelusunome = A492VisDelUsuNome;
         obj40.gxTpr_Vispaiid = A419VisPaiID;
         obj40.gxTpr_Vispaidata = A460VisPaiData;
         obj40.gxTpr_Vispaihora = A461VisPaiHora;
         obj40.gxTpr_Vispaidatahora = A462VisPaiDataHora;
         obj40.gxTpr_Vispaiassunto = A465VisPaiAssunto;
         obj40.gxTpr_Visupddata = A482VisUpdData;
         obj40.gxTpr_Visupdhora = A483VisUpdHora;
         obj40.gxTpr_Visupddatahora = A484VisUpdDataHora;
         obj40.gxTpr_Visupdusuid = A485VisUpdUsuID;
         obj40.gxTpr_Visupdusunome = A486VisUpdUsuNome;
         obj40.gxTpr_Visdata = A404VisData;
         obj40.gxTpr_Vishora = A405VisHora;
         obj40.gxTpr_Visdatahora = A406VisDataHora;
         obj40.gxTpr_Visdatahorafim = A477VisDataHoraFim;
         obj40.gxTpr_Vistipoid = A414VisTipoID;
         obj40.gxTpr_Vistiposigla = A415VisTipoSigla;
         obj40.gxTpr_Vistiponome = A416VisTipoNome;
         obj40.gxTpr_Visnegid = A418VisNegID;
         obj40.gxTpr_Visnegcodigo = A466VisNegCodigo;
         obj40.gxTpr_Visnegassunto = A467VisNegAssunto;
         obj40.gxTpr_Visnegvalor = A468VisNegValor;
         obj40.gxTpr_Visnegcliid = A407VisNegCliID;
         obj40.gxTpr_Visnegclinomefamiliar = A469VisNegCliNomeFamiliar;
         obj40.gxTpr_Visnegcpjid = A408VisNegCpjID;
         obj40.gxTpr_Visnegcpjnomfan = A470VisNegCpjNomFan;
         obj40.gxTpr_Visnegcpjrazsocial = A471VisNegCpjRazSocial;
         obj40.gxTpr_Visngfseq = A422VisNgfSeq;
         obj40.gxTpr_Visngfiteid = A423VisNgfIteID;
         obj40.gxTpr_Visngfitenome = A424VisNgfIteNome;
         obj40.gxTpr_Visassunto = A409VisAssunto;
         obj40.gxTpr_Visdescricao = A410VisDescricao;
         obj40.gxTpr_Vislink = A417VisLink;
         obj40.gxTpr_Visdel = A487VisDel;
         obj40.gxTpr_Visdatafim = A475VisDataFim;
         obj40.gxTpr_Vishorafim = A476VisHoraFim;
         obj40.gxTpr_Vissituacao = A472VisSituacao;
         obj40.gxTpr_Visid = A398VisID;
         obj40.gxTpr_Visid_Z = Z398VisID;
         obj40.gxTpr_Vispaiid_Z = Z419VisPaiID;
         obj40.gxTpr_Vispaidata_Z = Z460VisPaiData;
         obj40.gxTpr_Vispaihora_Z = Z461VisPaiHora;
         obj40.gxTpr_Vispaidatahora_Z = Z462VisPaiDataHora;
         obj40.gxTpr_Vispaiassunto_Z = Z465VisPaiAssunto;
         obj40.gxTpr_Visinsdata_Z = Z399VisInsData;
         obj40.gxTpr_Visinshora_Z = Z400VisInsHora;
         obj40.gxTpr_Visinsdatahora_Z = Z401VisInsDataHora;
         obj40.gxTpr_Visinsusuid_Z = Z402VisInsUsuID;
         obj40.gxTpr_Visinsusunome_Z = Z403VisInsUsuNome;
         obj40.gxTpr_Visupddata_Z = Z482VisUpdData;
         obj40.gxTpr_Visupdhora_Z = Z483VisUpdHora;
         obj40.gxTpr_Visupddatahora_Z = Z484VisUpdDataHora;
         obj40.gxTpr_Visupdusuid_Z = Z485VisUpdUsuID;
         obj40.gxTpr_Visupdusunome_Z = Z486VisUpdUsuNome;
         obj40.gxTpr_Visdata_Z = Z404VisData;
         obj40.gxTpr_Vishora_Z = Z405VisHora;
         obj40.gxTpr_Visdatahora_Z = Z406VisDataHora;
         obj40.gxTpr_Visdatafim_Z = Z475VisDataFim;
         obj40.gxTpr_Vishorafim_Z = Z476VisHoraFim;
         obj40.gxTpr_Visdatahorafim_Z = Z477VisDataHoraFim;
         obj40.gxTpr_Vistipoid_Z = Z414VisTipoID;
         obj40.gxTpr_Vistiposigla_Z = Z415VisTipoSigla;
         obj40.gxTpr_Vistiponome_Z = Z416VisTipoNome;
         obj40.gxTpr_Visnegid_Z = Z418VisNegID;
         obj40.gxTpr_Visnegcodigo_Z = Z466VisNegCodigo;
         obj40.gxTpr_Visnegassunto_Z = Z467VisNegAssunto;
         obj40.gxTpr_Visnegvalor_Z = Z468VisNegValor;
         obj40.gxTpr_Visnegcliid_Z = Z407VisNegCliID;
         obj40.gxTpr_Visnegclinomefamiliar_Z = Z469VisNegCliNomeFamiliar;
         obj40.gxTpr_Visnegcpjid_Z = Z408VisNegCpjID;
         obj40.gxTpr_Visnegcpjnomfan_Z = Z470VisNegCpjNomFan;
         obj40.gxTpr_Visnegcpjrazsocial_Z = Z471VisNegCpjRazSocial;
         obj40.gxTpr_Visngfseq_Z = Z422VisNgfSeq;
         obj40.gxTpr_Visngfiteid_Z = Z423VisNgfIteID;
         obj40.gxTpr_Visngfitenome_Z = Z424VisNgfIteNome;
         obj40.gxTpr_Visassunto_Z = Z409VisAssunto;
         obj40.gxTpr_Vislink_Z = Z417VisLink;
         obj40.gxTpr_Vissituacao_Z = Z472VisSituacao;
         obj40.gxTpr_Visdel_Z = Z487VisDel;
         obj40.gxTpr_Visdeldatahora_Z = Z490VisDelDataHora;
         obj40.gxTpr_Visdeldata_Z = Z488VisDelData;
         obj40.gxTpr_Visdelhora_Z = Z489VisDelHora;
         obj40.gxTpr_Visdelusuid_Z = Z491VisDelUsuID;
         obj40.gxTpr_Visdelusunome_Z = Z492VisDelUsuNome;
         obj40.gxTpr_Vispaiid_N = (short)(Convert.ToInt16(n419VisPaiID));
         obj40.gxTpr_Visinsusuid_N = (short)(Convert.ToInt16(n402VisInsUsuID));
         obj40.gxTpr_Visinsusunome_N = (short)(Convert.ToInt16(n403VisInsUsuNome));
         obj40.gxTpr_Visupddata_N = (short)(Convert.ToInt16(n482VisUpdData));
         obj40.gxTpr_Visupdhora_N = (short)(Convert.ToInt16(n483VisUpdHora));
         obj40.gxTpr_Visupddatahora_N = (short)(Convert.ToInt16(n484VisUpdDataHora));
         obj40.gxTpr_Visupdusuid_N = (short)(Convert.ToInt16(n485VisUpdUsuID));
         obj40.gxTpr_Visupdusunome_N = (short)(Convert.ToInt16(n486VisUpdUsuNome));
         obj40.gxTpr_Visdatafim_N = (short)(Convert.ToInt16(n475VisDataFim));
         obj40.gxTpr_Vishorafim_N = (short)(Convert.ToInt16(n476VisHoraFim));
         obj40.gxTpr_Visdatahorafim_N = (short)(Convert.ToInt16(n477VisDataHoraFim));
         obj40.gxTpr_Visnegid_N = (short)(Convert.ToInt16(n418VisNegID));
         obj40.gxTpr_Visngfseq_N = (short)(Convert.ToInt16(n422VisNgfSeq));
         obj40.gxTpr_Visdescricao_N = (short)(Convert.ToInt16(n410VisDescricao));
         obj40.gxTpr_Vislink_N = (short)(Convert.ToInt16(n417VisLink));
         obj40.gxTpr_Visdeldatahora_N = (short)(Convert.ToInt16(n490VisDelDataHora));
         obj40.gxTpr_Visdeldata_N = (short)(Convert.ToInt16(n488VisDelData));
         obj40.gxTpr_Visdelhora_N = (short)(Convert.ToInt16(n489VisDelHora));
         obj40.gxTpr_Visdelusuid_N = (short)(Convert.ToInt16(n491VisDelUsuID));
         obj40.gxTpr_Visdelusunome_N = (short)(Convert.ToInt16(n492VisDelUsuNome));
         obj40.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow40( GeneXus.Programs.core.SdtVisita obj40 )
      {
         obj40.gxTpr_Visid = A398VisID;
         return  ;
      }

      public void RowToVars40( GeneXus.Programs.core.SdtVisita obj40 ,
                               int forceLoad )
      {
         Gx_mode = obj40.gxTpr_Mode;
         A401VisInsDataHora = obj40.gxTpr_Visinsdatahora;
         A399VisInsData = obj40.gxTpr_Visinsdata;
         A400VisInsHora = obj40.gxTpr_Visinshora;
         A402VisInsUsuID = obj40.gxTpr_Visinsusuid;
         n402VisInsUsuID = false;
         A403VisInsUsuNome = obj40.gxTpr_Visinsusunome;
         n403VisInsUsuNome = false;
         A490VisDelDataHora = obj40.gxTpr_Visdeldatahora;
         n490VisDelDataHora = false;
         A488VisDelData = obj40.gxTpr_Visdeldata;
         n488VisDelData = false;
         A489VisDelHora = obj40.gxTpr_Visdelhora;
         n489VisDelHora = false;
         A491VisDelUsuID = obj40.gxTpr_Visdelusuid;
         n491VisDelUsuID = false;
         A492VisDelUsuNome = obj40.gxTpr_Visdelusunome;
         n492VisDelUsuNome = false;
         A419VisPaiID = obj40.gxTpr_Vispaiid;
         n419VisPaiID = false;
         A460VisPaiData = obj40.gxTpr_Vispaidata;
         A461VisPaiHora = obj40.gxTpr_Vispaihora;
         A462VisPaiDataHora = obj40.gxTpr_Vispaidatahora;
         A465VisPaiAssunto = obj40.gxTpr_Vispaiassunto;
         A482VisUpdData = obj40.gxTpr_Visupddata;
         n482VisUpdData = false;
         A483VisUpdHora = obj40.gxTpr_Visupdhora;
         n483VisUpdHora = false;
         A484VisUpdDataHora = obj40.gxTpr_Visupddatahora;
         n484VisUpdDataHora = false;
         A485VisUpdUsuID = obj40.gxTpr_Visupdusuid;
         n485VisUpdUsuID = false;
         A486VisUpdUsuNome = obj40.gxTpr_Visupdusunome;
         n486VisUpdUsuNome = false;
         A404VisData = obj40.gxTpr_Visdata;
         A405VisHora = obj40.gxTpr_Vishora;
         A406VisDataHora = obj40.gxTpr_Visdatahora;
         A477VisDataHoraFim = obj40.gxTpr_Visdatahorafim;
         n477VisDataHoraFim = false;
         A414VisTipoID = obj40.gxTpr_Vistipoid;
         A415VisTipoSigla = obj40.gxTpr_Vistiposigla;
         A416VisTipoNome = obj40.gxTpr_Vistiponome;
         A418VisNegID = obj40.gxTpr_Visnegid;
         n418VisNegID = false;
         A466VisNegCodigo = obj40.gxTpr_Visnegcodigo;
         A467VisNegAssunto = obj40.gxTpr_Visnegassunto;
         A468VisNegValor = obj40.gxTpr_Visnegvalor;
         A407VisNegCliID = obj40.gxTpr_Visnegcliid;
         A469VisNegCliNomeFamiliar = obj40.gxTpr_Visnegclinomefamiliar;
         A408VisNegCpjID = obj40.gxTpr_Visnegcpjid;
         A470VisNegCpjNomFan = obj40.gxTpr_Visnegcpjnomfan;
         A471VisNegCpjRazSocial = obj40.gxTpr_Visnegcpjrazsocial;
         A422VisNgfSeq = obj40.gxTpr_Visngfseq;
         n422VisNgfSeq = false;
         A423VisNgfIteID = obj40.gxTpr_Visngfiteid;
         A424VisNgfIteNome = obj40.gxTpr_Visngfitenome;
         A409VisAssunto = obj40.gxTpr_Visassunto;
         A410VisDescricao = obj40.gxTpr_Visdescricao;
         n410VisDescricao = false;
         A417VisLink = obj40.gxTpr_Vislink;
         n417VisLink = false;
         A487VisDel = obj40.gxTpr_Visdel;
         A475VisDataFim = obj40.gxTpr_Visdatafim;
         n475VisDataFim = false;
         A476VisHoraFim = obj40.gxTpr_Vishorafim;
         n476VisHoraFim = false;
         A472VisSituacao = obj40.gxTpr_Vissituacao;
         A398VisID = obj40.gxTpr_Visid;
         Z398VisID = obj40.gxTpr_Visid_Z;
         Z419VisPaiID = obj40.gxTpr_Vispaiid_Z;
         Z460VisPaiData = obj40.gxTpr_Vispaidata_Z;
         Z461VisPaiHora = obj40.gxTpr_Vispaihora_Z;
         Z462VisPaiDataHora = obj40.gxTpr_Vispaidatahora_Z;
         Z465VisPaiAssunto = obj40.gxTpr_Vispaiassunto_Z;
         Z399VisInsData = obj40.gxTpr_Visinsdata_Z;
         Z400VisInsHora = obj40.gxTpr_Visinshora_Z;
         Z401VisInsDataHora = obj40.gxTpr_Visinsdatahora_Z;
         Z402VisInsUsuID = obj40.gxTpr_Visinsusuid_Z;
         Z403VisInsUsuNome = obj40.gxTpr_Visinsusunome_Z;
         Z482VisUpdData = obj40.gxTpr_Visupddata_Z;
         Z483VisUpdHora = obj40.gxTpr_Visupdhora_Z;
         Z484VisUpdDataHora = obj40.gxTpr_Visupddatahora_Z;
         Z485VisUpdUsuID = obj40.gxTpr_Visupdusuid_Z;
         Z486VisUpdUsuNome = obj40.gxTpr_Visupdusunome_Z;
         Z404VisData = obj40.gxTpr_Visdata_Z;
         Z405VisHora = obj40.gxTpr_Vishora_Z;
         Z406VisDataHora = obj40.gxTpr_Visdatahora_Z;
         Z475VisDataFim = obj40.gxTpr_Visdatafim_Z;
         Z476VisHoraFim = obj40.gxTpr_Vishorafim_Z;
         Z477VisDataHoraFim = obj40.gxTpr_Visdatahorafim_Z;
         Z414VisTipoID = obj40.gxTpr_Vistipoid_Z;
         Z415VisTipoSigla = obj40.gxTpr_Vistiposigla_Z;
         Z416VisTipoNome = obj40.gxTpr_Vistiponome_Z;
         Z418VisNegID = obj40.gxTpr_Visnegid_Z;
         Z466VisNegCodigo = obj40.gxTpr_Visnegcodigo_Z;
         Z467VisNegAssunto = obj40.gxTpr_Visnegassunto_Z;
         Z468VisNegValor = obj40.gxTpr_Visnegvalor_Z;
         Z407VisNegCliID = obj40.gxTpr_Visnegcliid_Z;
         Z469VisNegCliNomeFamiliar = obj40.gxTpr_Visnegclinomefamiliar_Z;
         Z408VisNegCpjID = obj40.gxTpr_Visnegcpjid_Z;
         Z470VisNegCpjNomFan = obj40.gxTpr_Visnegcpjnomfan_Z;
         Z471VisNegCpjRazSocial = obj40.gxTpr_Visnegcpjrazsocial_Z;
         Z422VisNgfSeq = obj40.gxTpr_Visngfseq_Z;
         Z423VisNgfIteID = obj40.gxTpr_Visngfiteid_Z;
         Z424VisNgfIteNome = obj40.gxTpr_Visngfitenome_Z;
         Z409VisAssunto = obj40.gxTpr_Visassunto_Z;
         Z417VisLink = obj40.gxTpr_Vislink_Z;
         Z472VisSituacao = obj40.gxTpr_Vissituacao_Z;
         Z487VisDel = obj40.gxTpr_Visdel_Z;
         O487VisDel = obj40.gxTpr_Visdel_Z;
         Z490VisDelDataHora = obj40.gxTpr_Visdeldatahora_Z;
         Z488VisDelData = obj40.gxTpr_Visdeldata_Z;
         Z489VisDelHora = obj40.gxTpr_Visdelhora_Z;
         Z491VisDelUsuID = obj40.gxTpr_Visdelusuid_Z;
         Z492VisDelUsuNome = obj40.gxTpr_Visdelusunome_Z;
         n419VisPaiID = (bool)(Convert.ToBoolean(obj40.gxTpr_Vispaiid_N));
         n402VisInsUsuID = (bool)(Convert.ToBoolean(obj40.gxTpr_Visinsusuid_N));
         n403VisInsUsuNome = (bool)(Convert.ToBoolean(obj40.gxTpr_Visinsusunome_N));
         n482VisUpdData = (bool)(Convert.ToBoolean(obj40.gxTpr_Visupddata_N));
         n483VisUpdHora = (bool)(Convert.ToBoolean(obj40.gxTpr_Visupdhora_N));
         n484VisUpdDataHora = (bool)(Convert.ToBoolean(obj40.gxTpr_Visupddatahora_N));
         n485VisUpdUsuID = (bool)(Convert.ToBoolean(obj40.gxTpr_Visupdusuid_N));
         n486VisUpdUsuNome = (bool)(Convert.ToBoolean(obj40.gxTpr_Visupdusunome_N));
         n475VisDataFim = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdatafim_N));
         n476VisHoraFim = (bool)(Convert.ToBoolean(obj40.gxTpr_Vishorafim_N));
         n477VisDataHoraFim = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdatahorafim_N));
         n418VisNegID = (bool)(Convert.ToBoolean(obj40.gxTpr_Visnegid_N));
         n422VisNgfSeq = (bool)(Convert.ToBoolean(obj40.gxTpr_Visngfseq_N));
         n410VisDescricao = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdescricao_N));
         n417VisLink = (bool)(Convert.ToBoolean(obj40.gxTpr_Vislink_N));
         n490VisDelDataHora = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdeldatahora_N));
         n488VisDelData = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdeldata_N));
         n489VisDelHora = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdelhora_N));
         n491VisDelUsuID = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdelusuid_N));
         n492VisDelUsuNome = (bool)(Convert.ToBoolean(obj40.gxTpr_Visdelusunome_N));
         Gx_mode = obj40.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A398VisID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1440( ) ;
         ScanKeyStart1440( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z398VisID = A398VisID;
            O487VisDel = A487VisDel;
         }
         ZM1440( -37) ;
         OnLoadActions1440( ) ;
         AddRow1440( ) ;
         ScanKeyEnd1440( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars40( bccore_Visita, 0) ;
         ScanKeyStart1440( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z398VisID = A398VisID;
            O487VisDel = A487VisDel;
         }
         ZM1440( -37) ;
         OnLoadActions1440( ) ;
         AddRow1440( ) ;
         ScanKeyEnd1440( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1440( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1440( ) ;
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( A398VisID != Z398VisID )
               {
                  A398VisID = Z398VisID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1440( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A398VisID != Z398VisID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1440( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1440( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars40( bccore_Visita, 1) ;
         SaveImpl( ) ;
         VarsToRow40( bccore_Visita) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars40( bccore_Visita, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1440( ) ;
         AfterTrn( ) ;
         VarsToRow40( bccore_Visita) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow40( bccore_Visita) ;
         }
         else
         {
            GeneXus.Programs.core.SdtVisita auxBC = new GeneXus.Programs.core.SdtVisita(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A398VisID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Visita);
               auxBC.Save();
               bccore_Visita.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars40( bccore_Visita, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars40( bccore_Visita, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1440( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow40( bccore_Visita) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow40( bccore_Visita) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars40( bccore_Visita, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1440( ) ;
         if ( RcdFound40 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A398VisID != Z398VisID )
            {
               A398VisID = Z398VisID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A398VisID != Z398VisID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("core.visita_bc",pr_default);
         VarsToRow40( bccore_Visita) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bccore_Visita.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Visita.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Visita )
         {
            bccore_Visita = (GeneXus.Programs.core.SdtVisita)(sdt);
            if ( StringUtil.StrCmp(bccore_Visita.gxTpr_Mode, "") == 0 )
            {
               bccore_Visita.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow40( bccore_Visita) ;
            }
            else
            {
               RowToVars40( bccore_Visita, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Visita.gxTpr_Mode, "") == 0 )
            {
               bccore_Visita.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars40( bccore_Visita, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtVisita Visita_BC
      {
         get {
            return bccore_Visita ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "visita_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(19);
         pr_default.close(14);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z398VisID = Guid.Empty;
         A398VisID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV46Pgmname = "";
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_VisPaiID = Guid.Empty;
         AV15Insert_VisNegID = Guid.Empty;
         AV43AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         Z401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         Z399VisInsData = DateTime.MinValue;
         A399VisInsData = DateTime.MinValue;
         Z400VisInsHora = (DateTime)(DateTime.MinValue);
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         Z402VisInsUsuID = "";
         A402VisInsUsuID = "";
         Z403VisInsUsuNome = "";
         A403VisInsUsuNome = "";
         Z490VisDelDataHora = (DateTime)(DateTime.MinValue);
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         Z488VisDelData = (DateTime)(DateTime.MinValue);
         A488VisDelData = (DateTime)(DateTime.MinValue);
         Z489VisDelHora = (DateTime)(DateTime.MinValue);
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         Z491VisDelUsuID = "";
         A491VisDelUsuID = "";
         Z492VisDelUsuNome = "";
         A492VisDelUsuNome = "";
         Z482VisUpdData = DateTime.MinValue;
         A482VisUpdData = DateTime.MinValue;
         Z483VisUpdHora = (DateTime)(DateTime.MinValue);
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         Z484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         Z485VisUpdUsuID = "";
         A485VisUpdUsuID = "";
         Z486VisUpdUsuNome = "";
         A486VisUpdUsuNome = "";
         Z404VisData = DateTime.MinValue;
         A404VisData = DateTime.MinValue;
         Z405VisHora = (DateTime)(DateTime.MinValue);
         A405VisHora = (DateTime)(DateTime.MinValue);
         Z406VisDataHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         Z475VisDataFim = DateTime.MinValue;
         A475VisDataFim = DateTime.MinValue;
         Z476VisHoraFim = (DateTime)(DateTime.MinValue);
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         Z477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         Z409VisAssunto = "";
         A409VisAssunto = "";
         Z417VisLink = "";
         A417VisLink = "";
         Z472VisSituacao = "";
         A472VisSituacao = "";
         Z418VisNegID = Guid.Empty;
         A418VisNegID = Guid.Empty;
         Z419VisPaiID = Guid.Empty;
         A419VisPaiID = Guid.Empty;
         Z415VisTipoSigla = "";
         A415VisTipoSigla = "";
         Z416VisTipoNome = "";
         A416VisTipoNome = "";
         Z467VisNegAssunto = "";
         A467VisNegAssunto = "";
         Z407VisNegCliID = Guid.Empty;
         A407VisNegCliID = Guid.Empty;
         Z408VisNegCpjID = Guid.Empty;
         A408VisNegCpjID = Guid.Empty;
         Z423VisNgfIteID = Guid.Empty;
         A423VisNgfIteID = Guid.Empty;
         Z460VisPaiData = DateTime.MinValue;
         A460VisPaiData = DateTime.MinValue;
         Z461VisPaiHora = (DateTime)(DateTime.MinValue);
         A461VisPaiHora = (DateTime)(DateTime.MinValue);
         Z462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         Z465VisPaiAssunto = "";
         A465VisPaiAssunto = "";
         Z469VisNegCliNomeFamiliar = "";
         A469VisNegCliNomeFamiliar = "";
         Z470VisNegCpjNomFan = "";
         A470VisNegCpjNomFan = "";
         Z471VisNegCpjRazSocial = "";
         A471VisNegCpjRazSocial = "";
         Z424VisNgfIteNome = "";
         A424VisNgfIteNome = "";
         Z410VisDescricao = "";
         A410VisDescricao = "";
         BC001411_A398VisID = new Guid[] {Guid.Empty} ;
         BC001411_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         BC001411_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_A402VisInsUsuID = new string[] {""} ;
         BC001411_n402VisInsUsuID = new bool[] {false} ;
         BC001411_A403VisInsUsuNome = new string[] {""} ;
         BC001411_n403VisInsUsuNome = new bool[] {false} ;
         BC001411_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_n490VisDelDataHora = new bool[] {false} ;
         BC001411_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         BC001411_n488VisDelData = new bool[] {false} ;
         BC001411_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_n489VisDelHora = new bool[] {false} ;
         BC001411_A491VisDelUsuID = new string[] {""} ;
         BC001411_n491VisDelUsuID = new bool[] {false} ;
         BC001411_A492VisDelUsuNome = new string[] {""} ;
         BC001411_n492VisDelUsuNome = new bool[] {false} ;
         BC001411_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         BC001411_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_A465VisPaiAssunto = new string[] {""} ;
         BC001411_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001411_n482VisUpdData = new bool[] {false} ;
         BC001411_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_n483VisUpdHora = new bool[] {false} ;
         BC001411_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_n484VisUpdDataHora = new bool[] {false} ;
         BC001411_A485VisUpdUsuID = new string[] {""} ;
         BC001411_n485VisUpdUsuID = new bool[] {false} ;
         BC001411_A486VisUpdUsuNome = new string[] {""} ;
         BC001411_n486VisUpdUsuNome = new bool[] {false} ;
         BC001411_A404VisData = new DateTime[] {DateTime.MinValue} ;
         BC001411_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001411_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         BC001411_n475VisDataFim = new bool[] {false} ;
         BC001411_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC001411_n476VisHoraFim = new bool[] {false} ;
         BC001411_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC001411_n477VisDataHoraFim = new bool[] {false} ;
         BC001411_A415VisTipoSigla = new string[] {""} ;
         BC001411_A416VisTipoNome = new string[] {""} ;
         BC001411_A466VisNegCodigo = new long[1] ;
         BC001411_A467VisNegAssunto = new string[] {""} ;
         BC001411_A468VisNegValor = new decimal[1] ;
         BC001411_A469VisNegCliNomeFamiliar = new string[] {""} ;
         BC001411_A470VisNegCpjNomFan = new string[] {""} ;
         BC001411_A471VisNegCpjRazSocial = new string[] {""} ;
         BC001411_A424VisNgfIteNome = new string[] {""} ;
         BC001411_A409VisAssunto = new string[] {""} ;
         BC001411_A410VisDescricao = new string[] {""} ;
         BC001411_n410VisDescricao = new bool[] {false} ;
         BC001411_A417VisLink = new string[] {""} ;
         BC001411_n417VisLink = new bool[] {false} ;
         BC001411_A472VisSituacao = new string[] {""} ;
         BC001411_A487VisDel = new bool[] {false} ;
         BC001411_A414VisTipoID = new int[1] ;
         BC001411_A418VisNegID = new Guid[] {Guid.Empty} ;
         BC001411_n418VisNegID = new bool[] {false} ;
         BC001411_A422VisNgfSeq = new int[1] ;
         BC001411_n422VisNgfSeq = new bool[] {false} ;
         BC001411_A419VisPaiID = new Guid[] {Guid.Empty} ;
         BC001411_n419VisPaiID = new bool[] {false} ;
         BC001411_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         BC001411_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         BC001411_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         BC00147_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         BC00147_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         BC00147_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00147_A465VisPaiAssunto = new string[] {""} ;
         BC00144_A415VisTipoSigla = new string[] {""} ;
         BC00144_A416VisTipoNome = new string[] {""} ;
         BC00145_A466VisNegCodigo = new long[1] ;
         BC00145_A467VisNegAssunto = new string[] {""} ;
         BC00145_A468VisNegValor = new decimal[1] ;
         BC00145_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         BC00145_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         BC00148_A469VisNegCliNomeFamiliar = new string[] {""} ;
         BC00149_A470VisNegCpjNomFan = new string[] {""} ;
         BC00149_A471VisNegCpjRazSocial = new string[] {""} ;
         BC00146_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         BC001410_A424VisNgfIteNome = new string[] {""} ;
         BC001412_A398VisID = new Guid[] {Guid.Empty} ;
         BC00143_A398VisID = new Guid[] {Guid.Empty} ;
         BC00143_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         BC00143_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_A402VisInsUsuID = new string[] {""} ;
         BC00143_n402VisInsUsuID = new bool[] {false} ;
         BC00143_A403VisInsUsuNome = new string[] {""} ;
         BC00143_n403VisInsUsuNome = new bool[] {false} ;
         BC00143_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_n490VisDelDataHora = new bool[] {false} ;
         BC00143_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         BC00143_n488VisDelData = new bool[] {false} ;
         BC00143_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_n489VisDelHora = new bool[] {false} ;
         BC00143_A491VisDelUsuID = new string[] {""} ;
         BC00143_n491VisDelUsuID = new bool[] {false} ;
         BC00143_A492VisDelUsuNome = new string[] {""} ;
         BC00143_n492VisDelUsuNome = new bool[] {false} ;
         BC00143_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00143_n482VisUpdData = new bool[] {false} ;
         BC00143_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_n483VisUpdHora = new bool[] {false} ;
         BC00143_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_n484VisUpdDataHora = new bool[] {false} ;
         BC00143_A485VisUpdUsuID = new string[] {""} ;
         BC00143_n485VisUpdUsuID = new bool[] {false} ;
         BC00143_A486VisUpdUsuNome = new string[] {""} ;
         BC00143_n486VisUpdUsuNome = new bool[] {false} ;
         BC00143_A404VisData = new DateTime[] {DateTime.MinValue} ;
         BC00143_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00143_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         BC00143_n475VisDataFim = new bool[] {false} ;
         BC00143_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC00143_n476VisHoraFim = new bool[] {false} ;
         BC00143_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC00143_n477VisDataHoraFim = new bool[] {false} ;
         BC00143_A409VisAssunto = new string[] {""} ;
         BC00143_A410VisDescricao = new string[] {""} ;
         BC00143_n410VisDescricao = new bool[] {false} ;
         BC00143_A417VisLink = new string[] {""} ;
         BC00143_n417VisLink = new bool[] {false} ;
         BC00143_A472VisSituacao = new string[] {""} ;
         BC00143_A487VisDel = new bool[] {false} ;
         BC00143_A414VisTipoID = new int[1] ;
         BC00143_A418VisNegID = new Guid[] {Guid.Empty} ;
         BC00143_n418VisNegID = new bool[] {false} ;
         BC00143_A422VisNgfSeq = new int[1] ;
         BC00143_n422VisNgfSeq = new bool[] {false} ;
         BC00143_A419VisPaiID = new Guid[] {Guid.Empty} ;
         BC00143_n419VisPaiID = new bool[] {false} ;
         sMode40 = "";
         BC00142_A398VisID = new Guid[] {Guid.Empty} ;
         BC00142_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         BC00142_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_A402VisInsUsuID = new string[] {""} ;
         BC00142_n402VisInsUsuID = new bool[] {false} ;
         BC00142_A403VisInsUsuNome = new string[] {""} ;
         BC00142_n403VisInsUsuNome = new bool[] {false} ;
         BC00142_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_n490VisDelDataHora = new bool[] {false} ;
         BC00142_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         BC00142_n488VisDelData = new bool[] {false} ;
         BC00142_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_n489VisDelHora = new bool[] {false} ;
         BC00142_A491VisDelUsuID = new string[] {""} ;
         BC00142_n491VisDelUsuID = new bool[] {false} ;
         BC00142_A492VisDelUsuNome = new string[] {""} ;
         BC00142_n492VisDelUsuNome = new bool[] {false} ;
         BC00142_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00142_n482VisUpdData = new bool[] {false} ;
         BC00142_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_n483VisUpdHora = new bool[] {false} ;
         BC00142_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_n484VisUpdDataHora = new bool[] {false} ;
         BC00142_A485VisUpdUsuID = new string[] {""} ;
         BC00142_n485VisUpdUsuID = new bool[] {false} ;
         BC00142_A486VisUpdUsuNome = new string[] {""} ;
         BC00142_n486VisUpdUsuNome = new bool[] {false} ;
         BC00142_A404VisData = new DateTime[] {DateTime.MinValue} ;
         BC00142_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00142_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         BC00142_n475VisDataFim = new bool[] {false} ;
         BC00142_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC00142_n476VisHoraFim = new bool[] {false} ;
         BC00142_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC00142_n477VisDataHoraFim = new bool[] {false} ;
         BC00142_A409VisAssunto = new string[] {""} ;
         BC00142_A410VisDescricao = new string[] {""} ;
         BC00142_n410VisDescricao = new bool[] {false} ;
         BC00142_A417VisLink = new string[] {""} ;
         BC00142_n417VisLink = new bool[] {false} ;
         BC00142_A472VisSituacao = new string[] {""} ;
         BC00142_A487VisDel = new bool[] {false} ;
         BC00142_A414VisTipoID = new int[1] ;
         BC00142_A418VisNegID = new Guid[] {Guid.Empty} ;
         BC00142_n418VisNegID = new bool[] {false} ;
         BC00142_A422VisNgfSeq = new int[1] ;
         BC00142_n422VisNgfSeq = new bool[] {false} ;
         BC00142_A419VisPaiID = new Guid[] {Guid.Empty} ;
         BC00142_n419VisPaiID = new bool[] {false} ;
         BC001416_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         BC001416_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         BC001416_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001416_A465VisPaiAssunto = new string[] {""} ;
         BC001417_A415VisTipoSigla = new string[] {""} ;
         BC001417_A416VisTipoNome = new string[] {""} ;
         BC001418_A466VisNegCodigo = new long[1] ;
         BC001418_A467VisNegAssunto = new string[] {""} ;
         BC001418_A468VisNegValor = new decimal[1] ;
         BC001418_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         BC001418_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         BC001419_A469VisNegCliNomeFamiliar = new string[] {""} ;
         BC001420_A470VisNegCpjNomFan = new string[] {""} ;
         BC001420_A471VisNegCpjRazSocial = new string[] {""} ;
         BC001421_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         BC001422_A424VisNgfIteNome = new string[] {""} ;
         BC001423_A419VisPaiID = new Guid[] {Guid.Empty} ;
         BC001423_n419VisPaiID = new bool[] {false} ;
         BC001424_A398VisID = new Guid[] {Guid.Empty} ;
         BC001424_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         BC001424_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_A402VisInsUsuID = new string[] {""} ;
         BC001424_n402VisInsUsuID = new bool[] {false} ;
         BC001424_A403VisInsUsuNome = new string[] {""} ;
         BC001424_n403VisInsUsuNome = new bool[] {false} ;
         BC001424_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_n490VisDelDataHora = new bool[] {false} ;
         BC001424_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         BC001424_n488VisDelData = new bool[] {false} ;
         BC001424_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_n489VisDelHora = new bool[] {false} ;
         BC001424_A491VisDelUsuID = new string[] {""} ;
         BC001424_n491VisDelUsuID = new bool[] {false} ;
         BC001424_A492VisDelUsuNome = new string[] {""} ;
         BC001424_n492VisDelUsuNome = new bool[] {false} ;
         BC001424_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         BC001424_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_A465VisPaiAssunto = new string[] {""} ;
         BC001424_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001424_n482VisUpdData = new bool[] {false} ;
         BC001424_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_n483VisUpdHora = new bool[] {false} ;
         BC001424_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_n484VisUpdDataHora = new bool[] {false} ;
         BC001424_A485VisUpdUsuID = new string[] {""} ;
         BC001424_n485VisUpdUsuID = new bool[] {false} ;
         BC001424_A486VisUpdUsuNome = new string[] {""} ;
         BC001424_n486VisUpdUsuNome = new bool[] {false} ;
         BC001424_A404VisData = new DateTime[] {DateTime.MinValue} ;
         BC001424_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001424_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         BC001424_n475VisDataFim = new bool[] {false} ;
         BC001424_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC001424_n476VisHoraFim = new bool[] {false} ;
         BC001424_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         BC001424_n477VisDataHoraFim = new bool[] {false} ;
         BC001424_A415VisTipoSigla = new string[] {""} ;
         BC001424_A416VisTipoNome = new string[] {""} ;
         BC001424_A466VisNegCodigo = new long[1] ;
         BC001424_A467VisNegAssunto = new string[] {""} ;
         BC001424_A468VisNegValor = new decimal[1] ;
         BC001424_A469VisNegCliNomeFamiliar = new string[] {""} ;
         BC001424_A470VisNegCpjNomFan = new string[] {""} ;
         BC001424_A471VisNegCpjRazSocial = new string[] {""} ;
         BC001424_A424VisNgfIteNome = new string[] {""} ;
         BC001424_A409VisAssunto = new string[] {""} ;
         BC001424_A410VisDescricao = new string[] {""} ;
         BC001424_n410VisDescricao = new bool[] {false} ;
         BC001424_A417VisLink = new string[] {""} ;
         BC001424_n417VisLink = new bool[] {false} ;
         BC001424_A472VisSituacao = new string[] {""} ;
         BC001424_A487VisDel = new bool[] {false} ;
         BC001424_A414VisTipoID = new int[1] ;
         BC001424_A418VisNegID = new Guid[] {Guid.Empty} ;
         BC001424_n418VisNegID = new bool[] {false} ;
         BC001424_A422VisNgfSeq = new int[1] ;
         BC001424_n422VisNgfSeq = new bool[] {false} ;
         BC001424_A419VisPaiID = new Guid[] {Guid.Empty} ;
         BC001424_n419VisPaiID = new bool[] {false} ;
         BC001424_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         BC001424_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         BC001424_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         AV40VisPaiID = Guid.Empty;
         AV44Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         i472VisSituacao = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.visita_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visita_bc__default(),
            new Object[][] {
                new Object[] {
               BC00142_A398VisID, BC00142_A401VisInsDataHora, BC00142_A399VisInsData, BC00142_A400VisInsHora, BC00142_A402VisInsUsuID, BC00142_n402VisInsUsuID, BC00142_A403VisInsUsuNome, BC00142_n403VisInsUsuNome, BC00142_A490VisDelDataHora, BC00142_n490VisDelDataHora,
               BC00142_A488VisDelData, BC00142_n488VisDelData, BC00142_A489VisDelHora, BC00142_n489VisDelHora, BC00142_A491VisDelUsuID, BC00142_n491VisDelUsuID, BC00142_A492VisDelUsuNome, BC00142_n492VisDelUsuNome, BC00142_A482VisUpdData, BC00142_n482VisUpdData,
               BC00142_A483VisUpdHora, BC00142_n483VisUpdHora, BC00142_A484VisUpdDataHora, BC00142_n484VisUpdDataHora, BC00142_A485VisUpdUsuID, BC00142_n485VisUpdUsuID, BC00142_A486VisUpdUsuNome, BC00142_n486VisUpdUsuNome, BC00142_A404VisData, BC00142_A405VisHora,
               BC00142_A406VisDataHora, BC00142_A475VisDataFim, BC00142_n475VisDataFim, BC00142_A476VisHoraFim, BC00142_n476VisHoraFim, BC00142_A477VisDataHoraFim, BC00142_n477VisDataHoraFim, BC00142_A409VisAssunto, BC00142_A410VisDescricao, BC00142_n410VisDescricao,
               BC00142_A417VisLink, BC00142_n417VisLink, BC00142_A472VisSituacao, BC00142_A487VisDel, BC00142_A414VisTipoID, BC00142_A418VisNegID, BC00142_n418VisNegID, BC00142_A422VisNgfSeq, BC00142_n422VisNgfSeq, BC00142_A419VisPaiID,
               BC00142_n419VisPaiID
               }
               , new Object[] {
               BC00143_A398VisID, BC00143_A401VisInsDataHora, BC00143_A399VisInsData, BC00143_A400VisInsHora, BC00143_A402VisInsUsuID, BC00143_n402VisInsUsuID, BC00143_A403VisInsUsuNome, BC00143_n403VisInsUsuNome, BC00143_A490VisDelDataHora, BC00143_n490VisDelDataHora,
               BC00143_A488VisDelData, BC00143_n488VisDelData, BC00143_A489VisDelHora, BC00143_n489VisDelHora, BC00143_A491VisDelUsuID, BC00143_n491VisDelUsuID, BC00143_A492VisDelUsuNome, BC00143_n492VisDelUsuNome, BC00143_A482VisUpdData, BC00143_n482VisUpdData,
               BC00143_A483VisUpdHora, BC00143_n483VisUpdHora, BC00143_A484VisUpdDataHora, BC00143_n484VisUpdDataHora, BC00143_A485VisUpdUsuID, BC00143_n485VisUpdUsuID, BC00143_A486VisUpdUsuNome, BC00143_n486VisUpdUsuNome, BC00143_A404VisData, BC00143_A405VisHora,
               BC00143_A406VisDataHora, BC00143_A475VisDataFim, BC00143_n475VisDataFim, BC00143_A476VisHoraFim, BC00143_n476VisHoraFim, BC00143_A477VisDataHoraFim, BC00143_n477VisDataHoraFim, BC00143_A409VisAssunto, BC00143_A410VisDescricao, BC00143_n410VisDescricao,
               BC00143_A417VisLink, BC00143_n417VisLink, BC00143_A472VisSituacao, BC00143_A487VisDel, BC00143_A414VisTipoID, BC00143_A418VisNegID, BC00143_n418VisNegID, BC00143_A422VisNgfSeq, BC00143_n422VisNgfSeq, BC00143_A419VisPaiID,
               BC00143_n419VisPaiID
               }
               , new Object[] {
               BC00144_A415VisTipoSigla, BC00144_A416VisTipoNome
               }
               , new Object[] {
               BC00145_A466VisNegCodigo, BC00145_A467VisNegAssunto, BC00145_A468VisNegValor, BC00145_A407VisNegCliID, BC00145_A408VisNegCpjID
               }
               , new Object[] {
               BC00146_A423VisNgfIteID
               }
               , new Object[] {
               BC00147_A460VisPaiData, BC00147_A461VisPaiHora, BC00147_A462VisPaiDataHora, BC00147_A465VisPaiAssunto
               }
               , new Object[] {
               BC00148_A469VisNegCliNomeFamiliar
               }
               , new Object[] {
               BC00149_A470VisNegCpjNomFan, BC00149_A471VisNegCpjRazSocial
               }
               , new Object[] {
               BC001410_A424VisNgfIteNome
               }
               , new Object[] {
               BC001411_A398VisID, BC001411_A401VisInsDataHora, BC001411_A399VisInsData, BC001411_A400VisInsHora, BC001411_A402VisInsUsuID, BC001411_n402VisInsUsuID, BC001411_A403VisInsUsuNome, BC001411_n403VisInsUsuNome, BC001411_A490VisDelDataHora, BC001411_n490VisDelDataHora,
               BC001411_A488VisDelData, BC001411_n488VisDelData, BC001411_A489VisDelHora, BC001411_n489VisDelHora, BC001411_A491VisDelUsuID, BC001411_n491VisDelUsuID, BC001411_A492VisDelUsuNome, BC001411_n492VisDelUsuNome, BC001411_A460VisPaiData, BC001411_A461VisPaiHora,
               BC001411_A462VisPaiDataHora, BC001411_A465VisPaiAssunto, BC001411_A482VisUpdData, BC001411_n482VisUpdData, BC001411_A483VisUpdHora, BC001411_n483VisUpdHora, BC001411_A484VisUpdDataHora, BC001411_n484VisUpdDataHora, BC001411_A485VisUpdUsuID, BC001411_n485VisUpdUsuID,
               BC001411_A486VisUpdUsuNome, BC001411_n486VisUpdUsuNome, BC001411_A404VisData, BC001411_A405VisHora, BC001411_A406VisDataHora, BC001411_A475VisDataFim, BC001411_n475VisDataFim, BC001411_A476VisHoraFim, BC001411_n476VisHoraFim, BC001411_A477VisDataHoraFim,
               BC001411_n477VisDataHoraFim, BC001411_A415VisTipoSigla, BC001411_A416VisTipoNome, BC001411_A466VisNegCodigo, BC001411_A467VisNegAssunto, BC001411_A468VisNegValor, BC001411_A469VisNegCliNomeFamiliar, BC001411_A470VisNegCpjNomFan, BC001411_A471VisNegCpjRazSocial, BC001411_A424VisNgfIteNome,
               BC001411_A409VisAssunto, BC001411_A410VisDescricao, BC001411_n410VisDescricao, BC001411_A417VisLink, BC001411_n417VisLink, BC001411_A472VisSituacao, BC001411_A487VisDel, BC001411_A414VisTipoID, BC001411_A418VisNegID, BC001411_n418VisNegID,
               BC001411_A422VisNgfSeq, BC001411_n422VisNgfSeq, BC001411_A419VisPaiID, BC001411_n419VisPaiID, BC001411_A407VisNegCliID, BC001411_A408VisNegCpjID, BC001411_A423VisNgfIteID
               }
               , new Object[] {
               BC001412_A398VisID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001416_A460VisPaiData, BC001416_A461VisPaiHora, BC001416_A462VisPaiDataHora, BC001416_A465VisPaiAssunto
               }
               , new Object[] {
               BC001417_A415VisTipoSigla, BC001417_A416VisTipoNome
               }
               , new Object[] {
               BC001418_A466VisNegCodigo, BC001418_A467VisNegAssunto, BC001418_A468VisNegValor, BC001418_A407VisNegCliID, BC001418_A408VisNegCpjID
               }
               , new Object[] {
               BC001419_A469VisNegCliNomeFamiliar
               }
               , new Object[] {
               BC001420_A470VisNegCpjNomFan, BC001420_A471VisNegCpjRazSocial
               }
               , new Object[] {
               BC001421_A423VisNgfIteID
               }
               , new Object[] {
               BC001422_A424VisNgfIteNome
               }
               , new Object[] {
               BC001423_A419VisPaiID
               }
               , new Object[] {
               BC001424_A398VisID, BC001424_A401VisInsDataHora, BC001424_A399VisInsData, BC001424_A400VisInsHora, BC001424_A402VisInsUsuID, BC001424_n402VisInsUsuID, BC001424_A403VisInsUsuNome, BC001424_n403VisInsUsuNome, BC001424_A490VisDelDataHora, BC001424_n490VisDelDataHora,
               BC001424_A488VisDelData, BC001424_n488VisDelData, BC001424_A489VisDelHora, BC001424_n489VisDelHora, BC001424_A491VisDelUsuID, BC001424_n491VisDelUsuID, BC001424_A492VisDelUsuNome, BC001424_n492VisDelUsuNome, BC001424_A460VisPaiData, BC001424_A461VisPaiHora,
               BC001424_A462VisPaiDataHora, BC001424_A465VisPaiAssunto, BC001424_A482VisUpdData, BC001424_n482VisUpdData, BC001424_A483VisUpdHora, BC001424_n483VisUpdHora, BC001424_A484VisUpdDataHora, BC001424_n484VisUpdDataHora, BC001424_A485VisUpdUsuID, BC001424_n485VisUpdUsuID,
               BC001424_A486VisUpdUsuNome, BC001424_n486VisUpdUsuNome, BC001424_A404VisData, BC001424_A405VisHora, BC001424_A406VisDataHora, BC001424_A475VisDataFim, BC001424_n475VisDataFim, BC001424_A476VisHoraFim, BC001424_n476VisHoraFim, BC001424_A477VisDataHoraFim,
               BC001424_n477VisDataHoraFim, BC001424_A415VisTipoSigla, BC001424_A416VisTipoNome, BC001424_A466VisNegCodigo, BC001424_A467VisNegAssunto, BC001424_A468VisNegValor, BC001424_A469VisNegCliNomeFamiliar, BC001424_A470VisNegCpjNomFan, BC001424_A471VisNegCpjRazSocial, BC001424_A424VisNgfIteNome,
               BC001424_A409VisAssunto, BC001424_A410VisDescricao, BC001424_n410VisDescricao, BC001424_A417VisLink, BC001424_n417VisLink, BC001424_A472VisSituacao, BC001424_A487VisDel, BC001424_A414VisTipoID, BC001424_A418VisNegID, BC001424_n418VisNegID,
               BC001424_A422VisNgfSeq, BC001424_n422VisNgfSeq, BC001424_A419VisPaiID, BC001424_n419VisPaiID, BC001424_A407VisNegCliID, BC001424_A408VisNegCpjID, BC001424_A423VisNgfIteID
               }
            }
         );
         Z472VisSituacao = "PEN";
         A472VisSituacao = "PEN";
         i472VisSituacao = "PEN";
         Z398VisID = Guid.NewGuid( );
         A398VisID = Guid.NewGuid( );
         AV46Pgmname = "core.Visita_BC";
         Z476VisHoraFim = (DateTime)(DateTime.MinValue);
         n476VisHoraFim = false;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         n476VisHoraFim = false;
         Z475VisDataFim = DateTime.MinValue;
         n475VisDataFim = false;
         A475VisDataFim = DateTime.MinValue;
         n475VisDataFim = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12142 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound40 ;
      private short nIsDirty_40 ;
      private int trnEnded ;
      private int AV47GXV1 ;
      private int AV14Insert_VisTipoID ;
      private int AV16Insert_VisNgfSeq ;
      private int Z414VisTipoID ;
      private int A414VisTipoID ;
      private int Z422VisNgfSeq ;
      private int A422VisNgfSeq ;
      private long Z466VisNegCodigo ;
      private long A466VisNegCodigo ;
      private decimal Z468VisNegValor ;
      private decimal A468VisNegValor ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV46Pgmname ;
      private string Z402VisInsUsuID ;
      private string A402VisInsUsuID ;
      private string Z491VisDelUsuID ;
      private string A491VisDelUsuID ;
      private string Z485VisUpdUsuID ;
      private string A485VisUpdUsuID ;
      private string sMode40 ;
      private DateTime Z401VisInsDataHora ;
      private DateTime A401VisInsDataHora ;
      private DateTime Z400VisInsHora ;
      private DateTime A400VisInsHora ;
      private DateTime Z490VisDelDataHora ;
      private DateTime A490VisDelDataHora ;
      private DateTime Z488VisDelData ;
      private DateTime A488VisDelData ;
      private DateTime Z489VisDelHora ;
      private DateTime A489VisDelHora ;
      private DateTime Z483VisUpdHora ;
      private DateTime A483VisUpdHora ;
      private DateTime Z484VisUpdDataHora ;
      private DateTime A484VisUpdDataHora ;
      private DateTime Z405VisHora ;
      private DateTime A405VisHora ;
      private DateTime Z406VisDataHora ;
      private DateTime A406VisDataHora ;
      private DateTime Z476VisHoraFim ;
      private DateTime A476VisHoraFim ;
      private DateTime Z477VisDataHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime Z461VisPaiHora ;
      private DateTime A461VisPaiHora ;
      private DateTime Z462VisPaiDataHora ;
      private DateTime A462VisPaiDataHora ;
      private DateTime Z399VisInsData ;
      private DateTime A399VisInsData ;
      private DateTime Z482VisUpdData ;
      private DateTime A482VisUpdData ;
      private DateTime Z404VisData ;
      private DateTime A404VisData ;
      private DateTime Z475VisDataFim ;
      private DateTime A475VisDataFim ;
      private DateTime Z460VisPaiData ;
      private DateTime A460VisPaiData ;
      private bool returnInSub ;
      private bool Z487VisDel ;
      private bool A487VisDel ;
      private bool n402VisInsUsuID ;
      private bool n403VisInsUsuNome ;
      private bool n490VisDelDataHora ;
      private bool n488VisDelData ;
      private bool n489VisDelHora ;
      private bool n491VisDelUsuID ;
      private bool n492VisDelUsuNome ;
      private bool n482VisUpdData ;
      private bool n483VisUpdHora ;
      private bool n484VisUpdDataHora ;
      private bool n485VisUpdUsuID ;
      private bool n486VisUpdUsuNome ;
      private bool n475VisDataFim ;
      private bool n476VisHoraFim ;
      private bool n477VisDataHoraFim ;
      private bool n410VisDescricao ;
      private bool n417VisLink ;
      private bool n418VisNegID ;
      private bool n422VisNgfSeq ;
      private bool n419VisPaiID ;
      private bool O487VisDel ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z410VisDescricao ;
      private string A410VisDescricao ;
      private string Z403VisInsUsuNome ;
      private string A403VisInsUsuNome ;
      private string Z492VisDelUsuNome ;
      private string A492VisDelUsuNome ;
      private string Z486VisUpdUsuNome ;
      private string A486VisUpdUsuNome ;
      private string Z409VisAssunto ;
      private string A409VisAssunto ;
      private string Z417VisLink ;
      private string A417VisLink ;
      private string Z472VisSituacao ;
      private string A472VisSituacao ;
      private string Z415VisTipoSigla ;
      private string A415VisTipoSigla ;
      private string Z416VisTipoNome ;
      private string A416VisTipoNome ;
      private string Z467VisNegAssunto ;
      private string A467VisNegAssunto ;
      private string Z465VisPaiAssunto ;
      private string A465VisPaiAssunto ;
      private string Z469VisNegCliNomeFamiliar ;
      private string A469VisNegCliNomeFamiliar ;
      private string Z470VisNegCpjNomFan ;
      private string A470VisNegCpjNomFan ;
      private string Z471VisNegCpjRazSocial ;
      private string A471VisNegCpjRazSocial ;
      private string Z424VisNgfIteNome ;
      private string A424VisNgfIteNome ;
      private string i472VisSituacao ;
      private Guid Z398VisID ;
      private Guid A398VisID ;
      private Guid AV13Insert_VisPaiID ;
      private Guid AV15Insert_VisNegID ;
      private Guid Z418VisNegID ;
      private Guid A418VisNegID ;
      private Guid Z419VisPaiID ;
      private Guid A419VisPaiID ;
      private Guid Z407VisNegCliID ;
      private Guid A407VisNegCliID ;
      private Guid Z408VisNegCpjID ;
      private Guid A408VisNegCpjID ;
      private Guid Z423VisNgfIteID ;
      private Guid A423VisNgfIteID ;
      private Guid AV40VisPaiID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtVisita bccore_Visita ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001411_A398VisID ;
      private DateTime[] BC001411_A401VisInsDataHora ;
      private DateTime[] BC001411_A399VisInsData ;
      private DateTime[] BC001411_A400VisInsHora ;
      private string[] BC001411_A402VisInsUsuID ;
      private bool[] BC001411_n402VisInsUsuID ;
      private string[] BC001411_A403VisInsUsuNome ;
      private bool[] BC001411_n403VisInsUsuNome ;
      private DateTime[] BC001411_A490VisDelDataHora ;
      private bool[] BC001411_n490VisDelDataHora ;
      private DateTime[] BC001411_A488VisDelData ;
      private bool[] BC001411_n488VisDelData ;
      private DateTime[] BC001411_A489VisDelHora ;
      private bool[] BC001411_n489VisDelHora ;
      private string[] BC001411_A491VisDelUsuID ;
      private bool[] BC001411_n491VisDelUsuID ;
      private string[] BC001411_A492VisDelUsuNome ;
      private bool[] BC001411_n492VisDelUsuNome ;
      private DateTime[] BC001411_A460VisPaiData ;
      private DateTime[] BC001411_A461VisPaiHora ;
      private DateTime[] BC001411_A462VisPaiDataHora ;
      private string[] BC001411_A465VisPaiAssunto ;
      private DateTime[] BC001411_A482VisUpdData ;
      private bool[] BC001411_n482VisUpdData ;
      private DateTime[] BC001411_A483VisUpdHora ;
      private bool[] BC001411_n483VisUpdHora ;
      private DateTime[] BC001411_A484VisUpdDataHora ;
      private bool[] BC001411_n484VisUpdDataHora ;
      private string[] BC001411_A485VisUpdUsuID ;
      private bool[] BC001411_n485VisUpdUsuID ;
      private string[] BC001411_A486VisUpdUsuNome ;
      private bool[] BC001411_n486VisUpdUsuNome ;
      private DateTime[] BC001411_A404VisData ;
      private DateTime[] BC001411_A405VisHora ;
      private DateTime[] BC001411_A406VisDataHora ;
      private DateTime[] BC001411_A475VisDataFim ;
      private bool[] BC001411_n475VisDataFim ;
      private DateTime[] BC001411_A476VisHoraFim ;
      private bool[] BC001411_n476VisHoraFim ;
      private DateTime[] BC001411_A477VisDataHoraFim ;
      private bool[] BC001411_n477VisDataHoraFim ;
      private string[] BC001411_A415VisTipoSigla ;
      private string[] BC001411_A416VisTipoNome ;
      private long[] BC001411_A466VisNegCodigo ;
      private string[] BC001411_A467VisNegAssunto ;
      private decimal[] BC001411_A468VisNegValor ;
      private string[] BC001411_A469VisNegCliNomeFamiliar ;
      private string[] BC001411_A470VisNegCpjNomFan ;
      private string[] BC001411_A471VisNegCpjRazSocial ;
      private string[] BC001411_A424VisNgfIteNome ;
      private string[] BC001411_A409VisAssunto ;
      private string[] BC001411_A410VisDescricao ;
      private bool[] BC001411_n410VisDescricao ;
      private string[] BC001411_A417VisLink ;
      private bool[] BC001411_n417VisLink ;
      private string[] BC001411_A472VisSituacao ;
      private bool[] BC001411_A487VisDel ;
      private int[] BC001411_A414VisTipoID ;
      private Guid[] BC001411_A418VisNegID ;
      private bool[] BC001411_n418VisNegID ;
      private int[] BC001411_A422VisNgfSeq ;
      private bool[] BC001411_n422VisNgfSeq ;
      private Guid[] BC001411_A419VisPaiID ;
      private bool[] BC001411_n419VisPaiID ;
      private Guid[] BC001411_A407VisNegCliID ;
      private Guid[] BC001411_A408VisNegCpjID ;
      private Guid[] BC001411_A423VisNgfIteID ;
      private DateTime[] BC00147_A460VisPaiData ;
      private DateTime[] BC00147_A461VisPaiHora ;
      private DateTime[] BC00147_A462VisPaiDataHora ;
      private string[] BC00147_A465VisPaiAssunto ;
      private string[] BC00144_A415VisTipoSigla ;
      private string[] BC00144_A416VisTipoNome ;
      private long[] BC00145_A466VisNegCodigo ;
      private string[] BC00145_A467VisNegAssunto ;
      private decimal[] BC00145_A468VisNegValor ;
      private Guid[] BC00145_A407VisNegCliID ;
      private Guid[] BC00145_A408VisNegCpjID ;
      private string[] BC00148_A469VisNegCliNomeFamiliar ;
      private string[] BC00149_A470VisNegCpjNomFan ;
      private string[] BC00149_A471VisNegCpjRazSocial ;
      private Guid[] BC00146_A423VisNgfIteID ;
      private string[] BC001410_A424VisNgfIteNome ;
      private Guid[] BC001412_A398VisID ;
      private Guid[] BC00143_A398VisID ;
      private DateTime[] BC00143_A401VisInsDataHora ;
      private DateTime[] BC00143_A399VisInsData ;
      private DateTime[] BC00143_A400VisInsHora ;
      private string[] BC00143_A402VisInsUsuID ;
      private bool[] BC00143_n402VisInsUsuID ;
      private string[] BC00143_A403VisInsUsuNome ;
      private bool[] BC00143_n403VisInsUsuNome ;
      private DateTime[] BC00143_A490VisDelDataHora ;
      private bool[] BC00143_n490VisDelDataHora ;
      private DateTime[] BC00143_A488VisDelData ;
      private bool[] BC00143_n488VisDelData ;
      private DateTime[] BC00143_A489VisDelHora ;
      private bool[] BC00143_n489VisDelHora ;
      private string[] BC00143_A491VisDelUsuID ;
      private bool[] BC00143_n491VisDelUsuID ;
      private string[] BC00143_A492VisDelUsuNome ;
      private bool[] BC00143_n492VisDelUsuNome ;
      private DateTime[] BC00143_A482VisUpdData ;
      private bool[] BC00143_n482VisUpdData ;
      private DateTime[] BC00143_A483VisUpdHora ;
      private bool[] BC00143_n483VisUpdHora ;
      private DateTime[] BC00143_A484VisUpdDataHora ;
      private bool[] BC00143_n484VisUpdDataHora ;
      private string[] BC00143_A485VisUpdUsuID ;
      private bool[] BC00143_n485VisUpdUsuID ;
      private string[] BC00143_A486VisUpdUsuNome ;
      private bool[] BC00143_n486VisUpdUsuNome ;
      private DateTime[] BC00143_A404VisData ;
      private DateTime[] BC00143_A405VisHora ;
      private DateTime[] BC00143_A406VisDataHora ;
      private DateTime[] BC00143_A475VisDataFim ;
      private bool[] BC00143_n475VisDataFim ;
      private DateTime[] BC00143_A476VisHoraFim ;
      private bool[] BC00143_n476VisHoraFim ;
      private DateTime[] BC00143_A477VisDataHoraFim ;
      private bool[] BC00143_n477VisDataHoraFim ;
      private string[] BC00143_A409VisAssunto ;
      private string[] BC00143_A410VisDescricao ;
      private bool[] BC00143_n410VisDescricao ;
      private string[] BC00143_A417VisLink ;
      private bool[] BC00143_n417VisLink ;
      private string[] BC00143_A472VisSituacao ;
      private bool[] BC00143_A487VisDel ;
      private int[] BC00143_A414VisTipoID ;
      private Guid[] BC00143_A418VisNegID ;
      private bool[] BC00143_n418VisNegID ;
      private int[] BC00143_A422VisNgfSeq ;
      private bool[] BC00143_n422VisNgfSeq ;
      private Guid[] BC00143_A419VisPaiID ;
      private bool[] BC00143_n419VisPaiID ;
      private Guid[] BC00142_A398VisID ;
      private DateTime[] BC00142_A401VisInsDataHora ;
      private DateTime[] BC00142_A399VisInsData ;
      private DateTime[] BC00142_A400VisInsHora ;
      private string[] BC00142_A402VisInsUsuID ;
      private bool[] BC00142_n402VisInsUsuID ;
      private string[] BC00142_A403VisInsUsuNome ;
      private bool[] BC00142_n403VisInsUsuNome ;
      private DateTime[] BC00142_A490VisDelDataHora ;
      private bool[] BC00142_n490VisDelDataHora ;
      private DateTime[] BC00142_A488VisDelData ;
      private bool[] BC00142_n488VisDelData ;
      private DateTime[] BC00142_A489VisDelHora ;
      private bool[] BC00142_n489VisDelHora ;
      private string[] BC00142_A491VisDelUsuID ;
      private bool[] BC00142_n491VisDelUsuID ;
      private string[] BC00142_A492VisDelUsuNome ;
      private bool[] BC00142_n492VisDelUsuNome ;
      private DateTime[] BC00142_A482VisUpdData ;
      private bool[] BC00142_n482VisUpdData ;
      private DateTime[] BC00142_A483VisUpdHora ;
      private bool[] BC00142_n483VisUpdHora ;
      private DateTime[] BC00142_A484VisUpdDataHora ;
      private bool[] BC00142_n484VisUpdDataHora ;
      private string[] BC00142_A485VisUpdUsuID ;
      private bool[] BC00142_n485VisUpdUsuID ;
      private string[] BC00142_A486VisUpdUsuNome ;
      private bool[] BC00142_n486VisUpdUsuNome ;
      private DateTime[] BC00142_A404VisData ;
      private DateTime[] BC00142_A405VisHora ;
      private DateTime[] BC00142_A406VisDataHora ;
      private DateTime[] BC00142_A475VisDataFim ;
      private bool[] BC00142_n475VisDataFim ;
      private DateTime[] BC00142_A476VisHoraFim ;
      private bool[] BC00142_n476VisHoraFim ;
      private DateTime[] BC00142_A477VisDataHoraFim ;
      private bool[] BC00142_n477VisDataHoraFim ;
      private string[] BC00142_A409VisAssunto ;
      private string[] BC00142_A410VisDescricao ;
      private bool[] BC00142_n410VisDescricao ;
      private string[] BC00142_A417VisLink ;
      private bool[] BC00142_n417VisLink ;
      private string[] BC00142_A472VisSituacao ;
      private bool[] BC00142_A487VisDel ;
      private int[] BC00142_A414VisTipoID ;
      private Guid[] BC00142_A418VisNegID ;
      private bool[] BC00142_n418VisNegID ;
      private int[] BC00142_A422VisNgfSeq ;
      private bool[] BC00142_n422VisNgfSeq ;
      private Guid[] BC00142_A419VisPaiID ;
      private bool[] BC00142_n419VisPaiID ;
      private DateTime[] BC001416_A460VisPaiData ;
      private DateTime[] BC001416_A461VisPaiHora ;
      private DateTime[] BC001416_A462VisPaiDataHora ;
      private string[] BC001416_A465VisPaiAssunto ;
      private string[] BC001417_A415VisTipoSigla ;
      private string[] BC001417_A416VisTipoNome ;
      private long[] BC001418_A466VisNegCodigo ;
      private string[] BC001418_A467VisNegAssunto ;
      private decimal[] BC001418_A468VisNegValor ;
      private Guid[] BC001418_A407VisNegCliID ;
      private Guid[] BC001418_A408VisNegCpjID ;
      private string[] BC001419_A469VisNegCliNomeFamiliar ;
      private string[] BC001420_A470VisNegCpjNomFan ;
      private string[] BC001420_A471VisNegCpjRazSocial ;
      private Guid[] BC001421_A423VisNgfIteID ;
      private string[] BC001422_A424VisNgfIteNome ;
      private Guid[] BC001423_A419VisPaiID ;
      private bool[] BC001423_n419VisPaiID ;
      private Guid[] BC001424_A398VisID ;
      private DateTime[] BC001424_A401VisInsDataHora ;
      private DateTime[] BC001424_A399VisInsData ;
      private DateTime[] BC001424_A400VisInsHora ;
      private string[] BC001424_A402VisInsUsuID ;
      private bool[] BC001424_n402VisInsUsuID ;
      private string[] BC001424_A403VisInsUsuNome ;
      private bool[] BC001424_n403VisInsUsuNome ;
      private DateTime[] BC001424_A490VisDelDataHora ;
      private bool[] BC001424_n490VisDelDataHora ;
      private DateTime[] BC001424_A488VisDelData ;
      private bool[] BC001424_n488VisDelData ;
      private DateTime[] BC001424_A489VisDelHora ;
      private bool[] BC001424_n489VisDelHora ;
      private string[] BC001424_A491VisDelUsuID ;
      private bool[] BC001424_n491VisDelUsuID ;
      private string[] BC001424_A492VisDelUsuNome ;
      private bool[] BC001424_n492VisDelUsuNome ;
      private DateTime[] BC001424_A460VisPaiData ;
      private DateTime[] BC001424_A461VisPaiHora ;
      private DateTime[] BC001424_A462VisPaiDataHora ;
      private string[] BC001424_A465VisPaiAssunto ;
      private DateTime[] BC001424_A482VisUpdData ;
      private bool[] BC001424_n482VisUpdData ;
      private DateTime[] BC001424_A483VisUpdHora ;
      private bool[] BC001424_n483VisUpdHora ;
      private DateTime[] BC001424_A484VisUpdDataHora ;
      private bool[] BC001424_n484VisUpdDataHora ;
      private string[] BC001424_A485VisUpdUsuID ;
      private bool[] BC001424_n485VisUpdUsuID ;
      private string[] BC001424_A486VisUpdUsuNome ;
      private bool[] BC001424_n486VisUpdUsuNome ;
      private DateTime[] BC001424_A404VisData ;
      private DateTime[] BC001424_A405VisHora ;
      private DateTime[] BC001424_A406VisDataHora ;
      private DateTime[] BC001424_A475VisDataFim ;
      private bool[] BC001424_n475VisDataFim ;
      private DateTime[] BC001424_A476VisHoraFim ;
      private bool[] BC001424_n476VisHoraFim ;
      private DateTime[] BC001424_A477VisDataHoraFim ;
      private bool[] BC001424_n477VisDataHoraFim ;
      private string[] BC001424_A415VisTipoSigla ;
      private string[] BC001424_A416VisTipoNome ;
      private long[] BC001424_A466VisNegCodigo ;
      private string[] BC001424_A467VisNegAssunto ;
      private decimal[] BC001424_A468VisNegValor ;
      private string[] BC001424_A469VisNegCliNomeFamiliar ;
      private string[] BC001424_A470VisNegCpjNomFan ;
      private string[] BC001424_A471VisNegCpjRazSocial ;
      private string[] BC001424_A424VisNgfIteNome ;
      private string[] BC001424_A409VisAssunto ;
      private string[] BC001424_A410VisDescricao ;
      private bool[] BC001424_n410VisDescricao ;
      private string[] BC001424_A417VisLink ;
      private bool[] BC001424_n417VisLink ;
      private string[] BC001424_A472VisSituacao ;
      private bool[] BC001424_A487VisDel ;
      private int[] BC001424_A414VisTipoID ;
      private Guid[] BC001424_A418VisNegID ;
      private bool[] BC001424_n418VisNegID ;
      private int[] BC001424_A422VisNgfSeq ;
      private bool[] BC001424_n422VisNgfSeq ;
      private Guid[] BC001424_A419VisPaiID ;
      private bool[] BC001424_n419VisPaiID ;
      private Guid[] BC001424_A407VisNegCliID ;
      private Guid[] BC001424_A408VisNegCpjID ;
      private Guid[] BC001424_A423VisNgfIteID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV44Messages ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV43AuditingObject ;
   }

   public class visita_bc__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class visita_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001411;
        prmBC001411 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00147;
        prmBC00147 = new Object[] {
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00144;
        prmBC00144 = new Object[] {
        new ParDef("VisTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC00145;
        prmBC00145 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00148;
        prmBC00148 = new Object[] {
        new ParDef("VisNegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00149;
        prmBC00149 = new Object[] {
        new ParDef("VisNegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisNegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00146;
        prmBC00146 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001410;
        prmBC001410 = new Object[] {
        new ParDef("VisNgfIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001412;
        prmBC001412 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00143;
        prmBC00143 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00142;
        prmBC00142 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001413;
        prmBC001413 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("VisInsData",GXType.Date,8,0) ,
        new ParDef("VisInsHora",GXType.DateTime,0,5) ,
        new ParDef("VisInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisData",GXType.Date,8,0) ,
        new ParDef("VisHora",GXType.DateTime,0,5) ,
        new ParDef("VisDataHora",GXType.DateTime,10,5) ,
        new ParDef("VisDataFim",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisHoraFim",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDataHoraFim",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisAssunto",GXType.VarChar,80,0) ,
        new ParDef("VisDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("VisLink",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("VisSituacao",GXType.VarChar,3,0) ,
        new ParDef("VisDel",GXType.Boolean,1,0) ,
        new ParDef("VisTipoID",GXType.Int32,9,0) ,
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC001414;
        prmBC001414 = new Object[] {
        new ParDef("VisInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("VisInsData",GXType.Date,8,0) ,
        new ParDef("VisInsHora",GXType.DateTime,0,5) ,
        new ParDef("VisInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisData",GXType.Date,8,0) ,
        new ParDef("VisHora",GXType.DateTime,0,5) ,
        new ParDef("VisDataHora",GXType.DateTime,10,5) ,
        new ParDef("VisDataFim",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisHoraFim",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDataHoraFim",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisAssunto",GXType.VarChar,80,0) ,
        new ParDef("VisDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("VisLink",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("VisSituacao",GXType.VarChar,3,0) ,
        new ParDef("VisDel",GXType.Boolean,1,0) ,
        new ParDef("VisTipoID",GXType.Int32,9,0) ,
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001415;
        prmBC001415 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001416;
        prmBC001416 = new Object[] {
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC001417;
        prmBC001417 = new Object[] {
        new ParDef("VisTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC001418;
        prmBC001418 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC001419;
        prmBC001419 = new Object[] {
        new ParDef("VisNegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001420;
        prmBC001420 = new Object[] {
        new ParDef("VisNegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisNegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001421;
        prmBC001421 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmBC001422;
        prmBC001422 = new Object[] {
        new ParDef("VisNgfIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001423;
        prmBC001423 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001424;
        prmBC001424 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00142", "SELECT VisID, VisInsDataHora, VisInsData, VisInsHora, VisInsUsuID, VisInsUsuNome, VisDelDataHora, VisDelData, VisDelHora, VisDelUsuID, VisDelUsuNome, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisData, VisHora, VisDataHora, VisDataFim, VisHoraFim, VisDataHoraFim, VisAssunto, VisDescricao, VisLink, VisSituacao, VisDel, VisTipoID, VisNegID, VisNgfSeq, VisPaiID FROM tb_visita WHERE VisID = :VisID  FOR UPDATE OF tb_visita",true, GxErrorMask.GX_NOMASK, false, this,prmBC00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00143", "SELECT VisID, VisInsDataHora, VisInsData, VisInsHora, VisInsUsuID, VisInsUsuNome, VisDelDataHora, VisDelData, VisDelHora, VisDelUsuID, VisDelUsuNome, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisData, VisHora, VisDataHora, VisDataFim, VisHoraFim, VisDataHoraFim, VisAssunto, VisDescricao, VisLink, VisSituacao, VisDel, VisTipoID, VisNegID, VisNgfSeq, VisPaiID FROM tb_visita WHERE VisID = :VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00144", "SELECT VitSigla AS VisTipoSigla, VitNome AS VisTipoNome FROM tb_visitatipo WHERE VitID = :VisTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00145", "SELECT NegCodigo AS VisNegCodigo, NegAssunto AS VisNegAssunto, NegValorAtualizado AS VisNegValor, NegCliID AS VisNegCliID, NegCpjID AS VisNegCpjID FROM tb_negociopj WHERE NegID = :VisNegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00146", "SELECT NgfIteID AS VisNgfIteID FROM tb_negociopj_fase WHERE NegID = :VisNegID AND NgfSeq = :VisNgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00146,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00147", "SELECT VisData AS VisPaiData, VisHora AS VisPaiHora, VisDataHora AS VisPaiDataHora, VisAssunto AS VisPaiAssunto FROM tb_visita WHERE VisID = :VisPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00147,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00148", "SELECT CliNomeFamiliar AS VisNegCliNomeFamiliar FROM tb_cliente WHERE CliID = :VisNegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00148,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00149", "SELECT CpjNomeFan AS VisNegCpjNomFan, CpjRazaoSoc AS VisNegCpjRazSocial FROM tb_clientepj WHERE CliID = :VisNegCliID AND CpjID = :VisNegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00149,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001410", "SELECT IteNome AS VisNgfIteNome FROM tb_Iteracao WHERE IteID = :VisNgfIteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001411", "SELECT TM1.VisID, TM1.VisInsDataHora, TM1.VisInsData, TM1.VisInsHora, TM1.VisInsUsuID, TM1.VisInsUsuNome, TM1.VisDelDataHora, TM1.VisDelData, TM1.VisDelHora, TM1.VisDelUsuID, TM1.VisDelUsuNome, T2.VisData AS VisPaiData, T2.VisHora AS VisPaiHora, T2.VisDataHora AS VisPaiDataHora, T2.VisAssunto AS VisPaiAssunto, TM1.VisUpdData, TM1.VisUpdHora, TM1.VisUpdDataHora, TM1.VisUpdUsuID, TM1.VisUpdUsuNome, TM1.VisData, TM1.VisHora, TM1.VisDataHora, TM1.VisDataFim, TM1.VisHoraFim, TM1.VisDataHoraFim, T3.VitSigla AS VisTipoSigla, T3.VitNome AS VisTipoNome, T4.NegCodigo AS VisNegCodigo, T4.NegAssunto AS VisNegAssunto, T4.NegValorAtualizado AS VisNegValor, T5.CliNomeFamiliar AS VisNegCliNomeFamiliar, T6.CpjNomeFan AS VisNegCpjNomFan, T6.CpjRazaoSoc AS VisNegCpjRazSocial, T8.IteNome AS VisNgfIteNome, TM1.VisAssunto, TM1.VisDescricao, TM1.VisLink, TM1.VisSituacao, TM1.VisDel, TM1.VisTipoID AS VisTipoID, TM1.VisNegID AS VisNegID, TM1.VisNgfSeq AS VisNgfSeq, TM1.VisPaiID AS VisPaiID, T4.NegCliID AS VisNegCliID, T4.NegCpjID AS VisNegCpjID, T7.NgfIteID AS VisNgfIteID FROM (((((((tb_visita TM1 LEFT JOIN tb_visita T2 ON T2.VisID = TM1.VisPaiID) INNER JOIN tb_visitatipo T3 ON T3.VitID = TM1.VisTipoID) LEFT JOIN tb_negociopj T4 ON T4.NegID = TM1.VisNegID) LEFT JOIN tb_cliente T5 ON T5.CliID = T4.NegCliID) LEFT JOIN tb_clientepj T6 ON T6.CliID = T4.NegCliID AND T6.CpjID = T4.NegCpjID) LEFT JOIN tb_negociopj_fase T7 ON T7.NegID = TM1.VisNegID AND T7.NgfSeq = TM1.VisNgfSeq) LEFT JOIN tb_Iteracao T8 ON T8.IteID = T7.NgfIteID) WHERE TM1.VisID = :VisID ORDER BY TM1.VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001411,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001412", "SELECT VisID FROM tb_visita WHERE VisID = :VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001413", "SAVEPOINT gxupdate;INSERT INTO tb_visita(VisID, VisInsDataHora, VisInsData, VisInsHora, VisInsUsuID, VisInsUsuNome, VisDelDataHora, VisDelData, VisDelHora, VisDelUsuID, VisDelUsuNome, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisData, VisHora, VisDataHora, VisDataFim, VisHoraFim, VisDataHoraFim, VisAssunto, VisDescricao, VisLink, VisSituacao, VisDel, VisTipoID, VisNegID, VisNgfSeq, VisPaiID) VALUES(:VisID, :VisInsDataHora, :VisInsData, :VisInsHora, :VisInsUsuID, :VisInsUsuNome, :VisDelDataHora, :VisDelData, :VisDelHora, :VisDelUsuID, :VisDelUsuNome, :VisUpdData, :VisUpdHora, :VisUpdDataHora, :VisUpdUsuID, :VisUpdUsuNome, :VisData, :VisHora, :VisDataHora, :VisDataFim, :VisHoraFim, :VisDataHoraFim, :VisAssunto, :VisDescricao, :VisLink, :VisSituacao, :VisDel, :VisTipoID, :VisNegID, :VisNgfSeq, :VisPaiID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001413)
           ,new CursorDef("BC001414", "SAVEPOINT gxupdate;UPDATE tb_visita SET VisInsDataHora=:VisInsDataHora, VisInsData=:VisInsData, VisInsHora=:VisInsHora, VisInsUsuID=:VisInsUsuID, VisInsUsuNome=:VisInsUsuNome, VisDelDataHora=:VisDelDataHora, VisDelData=:VisDelData, VisDelHora=:VisDelHora, VisDelUsuID=:VisDelUsuID, VisDelUsuNome=:VisDelUsuNome, VisUpdData=:VisUpdData, VisUpdHora=:VisUpdHora, VisUpdDataHora=:VisUpdDataHora, VisUpdUsuID=:VisUpdUsuID, VisUpdUsuNome=:VisUpdUsuNome, VisData=:VisData, VisHora=:VisHora, VisDataHora=:VisDataHora, VisDataFim=:VisDataFim, VisHoraFim=:VisHoraFim, VisDataHoraFim=:VisDataHoraFim, VisAssunto=:VisAssunto, VisDescricao=:VisDescricao, VisLink=:VisLink, VisSituacao=:VisSituacao, VisDel=:VisDel, VisTipoID=:VisTipoID, VisNegID=:VisNegID, VisNgfSeq=:VisNgfSeq, VisPaiID=:VisPaiID  WHERE VisID = :VisID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001414)
           ,new CursorDef("BC001415", "SAVEPOINT gxupdate;DELETE FROM tb_visita  WHERE VisID = :VisID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001415)
           ,new CursorDef("BC001416", "SELECT VisData AS VisPaiData, VisHora AS VisPaiHora, VisDataHora AS VisPaiDataHora, VisAssunto AS VisPaiAssunto FROM tb_visita WHERE VisID = :VisPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001416,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001417", "SELECT VitSigla AS VisTipoSigla, VitNome AS VisTipoNome FROM tb_visitatipo WHERE VitID = :VisTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001418", "SELECT NegCodigo AS VisNegCodigo, NegAssunto AS VisNegAssunto, NegValorAtualizado AS VisNegValor, NegCliID AS VisNegCliID, NegCpjID AS VisNegCpjID FROM tb_negociopj WHERE NegID = :VisNegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001419", "SELECT CliNomeFamiliar AS VisNegCliNomeFamiliar FROM tb_cliente WHERE CliID = :VisNegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001420", "SELECT CpjNomeFan AS VisNegCpjNomFan, CpjRazaoSoc AS VisNegCpjRazSocial FROM tb_clientepj WHERE CliID = :VisNegCliID AND CpjID = :VisNegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001420,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001421", "SELECT NgfIteID AS VisNgfIteID FROM tb_negociopj_fase WHERE NegID = :VisNegID AND NgfSeq = :VisNgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001421,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001422", "SELECT IteNome AS VisNgfIteNome FROM tb_Iteracao WHERE IteID = :VisNgfIteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001422,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001423", "SELECT VisID AS VisPaiID FROM tb_visita WHERE VisPaiID = :VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001423,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001424", "SELECT TM1.VisID, TM1.VisInsDataHora, TM1.VisInsData, TM1.VisInsHora, TM1.VisInsUsuID, TM1.VisInsUsuNome, TM1.VisDelDataHora, TM1.VisDelData, TM1.VisDelHora, TM1.VisDelUsuID, TM1.VisDelUsuNome, T2.VisData AS VisPaiData, T2.VisHora AS VisPaiHora, T2.VisDataHora AS VisPaiDataHora, T2.VisAssunto AS VisPaiAssunto, TM1.VisUpdData, TM1.VisUpdHora, TM1.VisUpdDataHora, TM1.VisUpdUsuID, TM1.VisUpdUsuNome, TM1.VisData, TM1.VisHora, TM1.VisDataHora, TM1.VisDataFim, TM1.VisHoraFim, TM1.VisDataHoraFim, T3.VitSigla AS VisTipoSigla, T3.VitNome AS VisTipoNome, T4.NegCodigo AS VisNegCodigo, T4.NegAssunto AS VisNegAssunto, T4.NegValorAtualizado AS VisNegValor, T5.CliNomeFamiliar AS VisNegCliNomeFamiliar, T6.CpjNomeFan AS VisNegCpjNomFan, T6.CpjRazaoSoc AS VisNegCpjRazSocial, T8.IteNome AS VisNgfIteNome, TM1.VisAssunto, TM1.VisDescricao, TM1.VisLink, TM1.VisSituacao, TM1.VisDel, TM1.VisTipoID AS VisTipoID, TM1.VisNegID AS VisNegID, TM1.VisNgfSeq AS VisNgfSeq, TM1.VisPaiID AS VisPaiID, T4.NegCliID AS VisNegCliID, T4.NegCpjID AS VisNegCpjID, T7.NgfIteID AS VisNgfIteID FROM (((((((tb_visita TM1 LEFT JOIN tb_visita T2 ON T2.VisID = TM1.VisPaiID) INNER JOIN tb_visitatipo T3 ON T3.VitID = TM1.VisTipoID) LEFT JOIN tb_negociopj T4 ON T4.NegID = TM1.VisNegID) LEFT JOIN tb_cliente T5 ON T5.CliID = T4.NegCliID) LEFT JOIN tb_clientepj T6 ON T6.CliID = T4.NegCliID AND T6.CpjID = T4.NegCpjID) LEFT JOIN tb_negociopj_fase T7 ON T7.NegID = TM1.VisNegID AND T7.NgfSeq = TM1.VisNgfSeq) LEFT JOIN tb_Iteracao T8 ON T8.IteID = T7.NgfIteID) WHERE TM1.VisID = :VisID ORDER BY TM1.VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001424,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((string[]) buf[24])[0] = rslt.getString(15, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((string[]) buf[26])[0] = rslt.getVarchar(16);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[28])[0] = rslt.getGXDate(17);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(18);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(19);
              ((DateTime[]) buf[31])[0] = rslt.getGXDate(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[34])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((string[]) buf[37])[0] = rslt.getVarchar(23);
              ((string[]) buf[38])[0] = rslt.getLongVarchar(24);
              ((bool[]) buf[39])[0] = rslt.wasNull(24);
              ((string[]) buf[40])[0] = rslt.getVarchar(25);
              ((bool[]) buf[41])[0] = rslt.wasNull(25);
              ((string[]) buf[42])[0] = rslt.getVarchar(26);
              ((bool[]) buf[43])[0] = rslt.getBool(27);
              ((int[]) buf[44])[0] = rslt.getInt(28);
              ((Guid[]) buf[45])[0] = rslt.getGuid(29);
              ((bool[]) buf[46])[0] = rslt.wasNull(29);
              ((int[]) buf[47])[0] = rslt.getInt(30);
              ((bool[]) buf[48])[0] = rslt.wasNull(30);
              ((Guid[]) buf[49])[0] = rslt.getGuid(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((string[]) buf[24])[0] = rslt.getString(15, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((string[]) buf[26])[0] = rslt.getVarchar(16);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[28])[0] = rslt.getGXDate(17);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(18);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(19);
              ((DateTime[]) buf[31])[0] = rslt.getGXDate(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[34])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((string[]) buf[37])[0] = rslt.getVarchar(23);
              ((string[]) buf[38])[0] = rslt.getLongVarchar(24);
              ((bool[]) buf[39])[0] = rslt.wasNull(24);
              ((string[]) buf[40])[0] = rslt.getVarchar(25);
              ((bool[]) buf[41])[0] = rslt.wasNull(25);
              ((string[]) buf[42])[0] = rslt.getVarchar(26);
              ((bool[]) buf[43])[0] = rslt.getBool(27);
              ((int[]) buf[44])[0] = rslt.getInt(28);
              ((Guid[]) buf[45])[0] = rslt.getGuid(29);
              ((bool[]) buf[46])[0] = rslt.wasNull(29);
              ((int[]) buf[47])[0] = rslt.getInt(30);
              ((bool[]) buf[48])[0] = rslt.wasNull(30);
              ((Guid[]) buf[49])[0] = rslt.getGuid(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((string[]) buf[21])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(16);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(17);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(18, true);
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              ((string[]) buf[28])[0] = rslt.getString(19, 40);
              ((bool[]) buf[29])[0] = rslt.wasNull(19);
              ((string[]) buf[30])[0] = rslt.getVarchar(20);
              ((bool[]) buf[31])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[32])[0] = rslt.getGXDate(21);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(22);
              ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(23);
              ((DateTime[]) buf[35])[0] = rslt.getGXDate(24);
              ((bool[]) buf[36])[0] = rslt.wasNull(24);
              ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(25);
              ((bool[]) buf[38])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(26);
              ((bool[]) buf[40])[0] = rslt.wasNull(26);
              ((string[]) buf[41])[0] = rslt.getVarchar(27);
              ((string[]) buf[42])[0] = rslt.getVarchar(28);
              ((long[]) buf[43])[0] = rslt.getLong(29);
              ((string[]) buf[44])[0] = rslt.getVarchar(30);
              ((decimal[]) buf[45])[0] = rslt.getDecimal(31);
              ((string[]) buf[46])[0] = rslt.getVarchar(32);
              ((string[]) buf[47])[0] = rslt.getVarchar(33);
              ((string[]) buf[48])[0] = rslt.getVarchar(34);
              ((string[]) buf[49])[0] = rslt.getVarchar(35);
              ((string[]) buf[50])[0] = rslt.getVarchar(36);
              ((string[]) buf[51])[0] = rslt.getLongVarchar(37);
              ((bool[]) buf[52])[0] = rslt.wasNull(37);
              ((string[]) buf[53])[0] = rslt.getVarchar(38);
              ((bool[]) buf[54])[0] = rslt.wasNull(38);
              ((string[]) buf[55])[0] = rslt.getVarchar(39);
              ((bool[]) buf[56])[0] = rslt.getBool(40);
              ((int[]) buf[57])[0] = rslt.getInt(41);
              ((Guid[]) buf[58])[0] = rslt.getGuid(42);
              ((bool[]) buf[59])[0] = rslt.wasNull(42);
              ((int[]) buf[60])[0] = rslt.getInt(43);
              ((bool[]) buf[61])[0] = rslt.wasNull(43);
              ((Guid[]) buf[62])[0] = rslt.getGuid(44);
              ((bool[]) buf[63])[0] = rslt.wasNull(44);
              ((Guid[]) buf[64])[0] = rslt.getGuid(45);
              ((Guid[]) buf[65])[0] = rslt.getGuid(46);
              ((Guid[]) buf[66])[0] = rslt.getGuid(47);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 14 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 22 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((string[]) buf[21])[0] = rslt.getVarchar(15);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(16);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(17);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(18, true);
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              ((string[]) buf[28])[0] = rslt.getString(19, 40);
              ((bool[]) buf[29])[0] = rslt.wasNull(19);
              ((string[]) buf[30])[0] = rslt.getVarchar(20);
              ((bool[]) buf[31])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[32])[0] = rslt.getGXDate(21);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(22);
              ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(23);
              ((DateTime[]) buf[35])[0] = rslt.getGXDate(24);
              ((bool[]) buf[36])[0] = rslt.wasNull(24);
              ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(25);
              ((bool[]) buf[38])[0] = rslt.wasNull(25);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(26);
              ((bool[]) buf[40])[0] = rslt.wasNull(26);
              ((string[]) buf[41])[0] = rslt.getVarchar(27);
              ((string[]) buf[42])[0] = rslt.getVarchar(28);
              ((long[]) buf[43])[0] = rslt.getLong(29);
              ((string[]) buf[44])[0] = rslt.getVarchar(30);
              ((decimal[]) buf[45])[0] = rslt.getDecimal(31);
              ((string[]) buf[46])[0] = rslt.getVarchar(32);
              ((string[]) buf[47])[0] = rslt.getVarchar(33);
              ((string[]) buf[48])[0] = rslt.getVarchar(34);
              ((string[]) buf[49])[0] = rslt.getVarchar(35);
              ((string[]) buf[50])[0] = rslt.getVarchar(36);
              ((string[]) buf[51])[0] = rslt.getLongVarchar(37);
              ((bool[]) buf[52])[0] = rslt.wasNull(37);
              ((string[]) buf[53])[0] = rslt.getVarchar(38);
              ((bool[]) buf[54])[0] = rslt.wasNull(38);
              ((string[]) buf[55])[0] = rslt.getVarchar(39);
              ((bool[]) buf[56])[0] = rslt.getBool(40);
              ((int[]) buf[57])[0] = rslt.getInt(41);
              ((Guid[]) buf[58])[0] = rslt.getGuid(42);
              ((bool[]) buf[59])[0] = rslt.wasNull(42);
              ((int[]) buf[60])[0] = rslt.getInt(43);
              ((bool[]) buf[61])[0] = rslt.wasNull(43);
              ((Guid[]) buf[62])[0] = rslt.getGuid(44);
              ((bool[]) buf[63])[0] = rslt.wasNull(44);
              ((Guid[]) buf[64])[0] = rslt.getGuid(45);
              ((Guid[]) buf[65])[0] = rslt.getGuid(46);
              ((Guid[]) buf[66])[0] = rslt.getGuid(47);
              return;
     }
  }

}

}
