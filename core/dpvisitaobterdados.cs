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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class dpvisitaobterdados : GXProcedure
   {
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

      public dpvisitaobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpvisitaobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> aP1_Gxm2rootcol )
      {
         this.AV5sdtVisita = aP0_sdtVisita;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita>( context, "sdtVisita", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> executeUdp( GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita )
      {
         execute(aP0_sdtVisita, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> aP1_Gxm2rootcol )
      {
         dpvisitaobterdados objdpvisitaobterdados;
         objdpvisitaobterdados = new dpvisitaobterdados();
         objdpvisitaobterdados.AV5sdtVisita = aP0_sdtVisita;
         objdpvisitaobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita>( context, "sdtVisita", "agl_tresorygroup") ;
         objdpvisitaobterdados.context.SetSubmitInitialConfig(context);
         objdpvisitaobterdados.initialize();
         Submit( executePrivateCatch,objdpvisitaobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpvisitaobterdados)stateInfo).executePrivate();
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
         AV9Core_dsvisitafiltrogeral_3_sdtvisita = AV5sdtVisita;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsvisitafiltrogeral_3_sdtvisita.gxTpr_Visid ,
                                              A398VisID } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P000O2 */
         pr_default.execute(0, new Object[] {AV9Core_dsvisitafiltrogeral_3_sdtvisita.gxTpr_Visid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A398VisID = P000O2_A398VisID[0];
            A419VisPaiID = P000O2_A419VisPaiID[0];
            n419VisPaiID = P000O2_n419VisPaiID[0];
            A460VisPaiData = P000O2_A460VisPaiData[0];
            A461VisPaiHora = P000O2_A461VisPaiHora[0];
            A462VisPaiDataHora = P000O2_A462VisPaiDataHora[0];
            A465VisPaiAssunto = P000O2_A465VisPaiAssunto[0];
            A399VisInsData = P000O2_A399VisInsData[0];
            A400VisInsHora = P000O2_A400VisInsHora[0];
            A401VisInsDataHora = P000O2_A401VisInsDataHora[0];
            A402VisInsUsuID = P000O2_A402VisInsUsuID[0];
            n402VisInsUsuID = P000O2_n402VisInsUsuID[0];
            A403VisInsUsuNome = P000O2_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P000O2_n403VisInsUsuNome[0];
            A482VisUpdData = P000O2_A482VisUpdData[0];
            n482VisUpdData = P000O2_n482VisUpdData[0];
            A483VisUpdHora = P000O2_A483VisUpdHora[0];
            n483VisUpdHora = P000O2_n483VisUpdHora[0];
            A484VisUpdDataHora = P000O2_A484VisUpdDataHora[0];
            n484VisUpdDataHora = P000O2_n484VisUpdDataHora[0];
            A485VisUpdUsuID = P000O2_A485VisUpdUsuID[0];
            n485VisUpdUsuID = P000O2_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = P000O2_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = P000O2_n486VisUpdUsuNome[0];
            A404VisData = P000O2_A404VisData[0];
            A405VisHora = P000O2_A405VisHora[0];
            A406VisDataHora = P000O2_A406VisDataHora[0];
            A475VisDataFim = P000O2_A475VisDataFim[0];
            n475VisDataFim = P000O2_n475VisDataFim[0];
            A476VisHoraFim = P000O2_A476VisHoraFim[0];
            n476VisHoraFim = P000O2_n476VisHoraFim[0];
            A477VisDataHoraFim = P000O2_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P000O2_n477VisDataHoraFim[0];
            A414VisTipoID = P000O2_A414VisTipoID[0];
            A415VisTipoSigla = P000O2_A415VisTipoSigla[0];
            A416VisTipoNome = P000O2_A416VisTipoNome[0];
            A418VisNegID = P000O2_A418VisNegID[0];
            n418VisNegID = P000O2_n418VisNegID[0];
            A466VisNegCodigo = P000O2_A466VisNegCodigo[0];
            A467VisNegAssunto = P000O2_A467VisNegAssunto[0];
            A468VisNegValor = P000O2_A468VisNegValor[0];
            A407VisNegCliID = P000O2_A407VisNegCliID[0];
            A469VisNegCliNomeFamiliar = P000O2_A469VisNegCliNomeFamiliar[0];
            n469VisNegCliNomeFamiliar = P000O2_n469VisNegCliNomeFamiliar[0];
            A408VisNegCpjID = P000O2_A408VisNegCpjID[0];
            A470VisNegCpjNomFan = P000O2_A470VisNegCpjNomFan[0];
            n470VisNegCpjNomFan = P000O2_n470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = P000O2_A471VisNegCpjRazSocial[0];
            n471VisNegCpjRazSocial = P000O2_n471VisNegCpjRazSocial[0];
            A422VisNgfSeq = P000O2_A422VisNgfSeq[0];
            n422VisNgfSeq = P000O2_n422VisNgfSeq[0];
            A423VisNgfIteID = P000O2_A423VisNgfIteID[0];
            A424VisNgfIteNome = P000O2_A424VisNgfIteNome[0];
            n424VisNgfIteNome = P000O2_n424VisNgfIteNome[0];
            A409VisAssunto = P000O2_A409VisAssunto[0];
            A410VisDescricao = P000O2_A410VisDescricao[0];
            n410VisDescricao = P000O2_n410VisDescricao[0];
            A417VisLink = P000O2_A417VisLink[0];
            n417VisLink = P000O2_n417VisLink[0];
            A472VisSituacao = P000O2_A472VisSituacao[0];
            A487VisDel = P000O2_A487VisDel[0];
            A490VisDelDataHora = P000O2_A490VisDelDataHora[0];
            n490VisDelDataHora = P000O2_n490VisDelDataHora[0];
            A488VisDelData = P000O2_A488VisDelData[0];
            n488VisDelData = P000O2_n488VisDelData[0];
            A489VisDelHora = P000O2_A489VisDelHora[0];
            n489VisDelHora = P000O2_n489VisDelHora[0];
            A491VisDelUsuID = P000O2_A491VisDelUsuID[0];
            n491VisDelUsuID = P000O2_n491VisDelUsuID[0];
            A492VisDelUsuNome = P000O2_A492VisDelUsuNome[0];
            n492VisDelUsuNome = P000O2_n492VisDelUsuNome[0];
            A460VisPaiData = P000O2_A460VisPaiData[0];
            A461VisPaiHora = P000O2_A461VisPaiHora[0];
            A462VisPaiDataHora = P000O2_A462VisPaiDataHora[0];
            A465VisPaiAssunto = P000O2_A465VisPaiAssunto[0];
            A415VisTipoSigla = P000O2_A415VisTipoSigla[0];
            A416VisTipoNome = P000O2_A416VisTipoNome[0];
            A466VisNegCodigo = P000O2_A466VisNegCodigo[0];
            A467VisNegAssunto = P000O2_A467VisNegAssunto[0];
            A468VisNegValor = P000O2_A468VisNegValor[0];
            A407VisNegCliID = P000O2_A407VisNegCliID[0];
            A469VisNegCliNomeFamiliar = P000O2_A469VisNegCliNomeFamiliar[0];
            n469VisNegCliNomeFamiliar = P000O2_n469VisNegCliNomeFamiliar[0];
            A408VisNegCpjID = P000O2_A408VisNegCpjID[0];
            A470VisNegCpjNomFan = P000O2_A470VisNegCpjNomFan[0];
            n470VisNegCpjNomFan = P000O2_n470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = P000O2_A471VisNegCpjRazSocial[0];
            n471VisNegCpjRazSocial = P000O2_n471VisNegCpjRazSocial[0];
            A423VisNgfIteID = P000O2_A423VisNgfIteID[0];
            A424VisNgfIteNome = P000O2_A424VisNgfIteNome[0];
            n424VisNgfIteNome = P000O2_n424VisNgfIteNome[0];
            Gxm1sdtvisita = new GeneXus.Programs.core.SdtsdtVisita(context);
            Gxm2rootcol.Add(Gxm1sdtvisita, 0);
            Gxm1sdtvisita.gxTpr_Visid = A398VisID;
            Gxm1sdtvisita.gxTpr_Vispaiid = A419VisPaiID;
            Gxm1sdtvisita.gxTpr_Vispaidata = A460VisPaiData;
            Gxm1sdtvisita.gxTpr_Vispaihora = A461VisPaiHora;
            Gxm1sdtvisita.gxTpr_Vispaidatahora = A462VisPaiDataHora;
            Gxm1sdtvisita.gxTpr_Vispaiassunto = A465VisPaiAssunto;
            Gxm1sdtvisita.gxTpr_Visinsdata = A399VisInsData;
            Gxm1sdtvisita.gxTpr_Visinshora = A400VisInsHora;
            Gxm1sdtvisita.gxTpr_Visinsdatahora = A401VisInsDataHora;
            Gxm1sdtvisita.gxTpr_Visinsusuid = A402VisInsUsuID;
            Gxm1sdtvisita.gxTpr_Visinsusunome = A403VisInsUsuNome;
            Gxm1sdtvisita.gxTpr_Visupddata = A482VisUpdData;
            Gxm1sdtvisita.gxTpr_Visupdhora = A483VisUpdHora;
            Gxm1sdtvisita.gxTpr_Visupddatahora = A484VisUpdDataHora;
            Gxm1sdtvisita.gxTpr_Visupdusuid = A485VisUpdUsuID;
            Gxm1sdtvisita.gxTpr_Visupdusunome = A486VisUpdUsuNome;
            Gxm1sdtvisita.gxTpr_Visdata = A404VisData;
            Gxm1sdtvisita.gxTpr_Vishora = A405VisHora;
            Gxm1sdtvisita.gxTpr_Visdatahora = A406VisDataHora;
            Gxm1sdtvisita.gxTpr_Visdatafim = A475VisDataFim;
            Gxm1sdtvisita.gxTpr_Vishorafim = A476VisHoraFim;
            Gxm1sdtvisita.gxTpr_Visdatahorafim = A477VisDataHoraFim;
            Gxm1sdtvisita.gxTpr_Vistipoid = A414VisTipoID;
            Gxm1sdtvisita.gxTpr_Vistiposigla = A415VisTipoSigla;
            Gxm1sdtvisita.gxTpr_Vistiponome = A416VisTipoNome;
            Gxm1sdtvisita.gxTpr_Visnegid = A418VisNegID;
            Gxm1sdtvisita.gxTpr_Visnegcodigo = A466VisNegCodigo;
            Gxm1sdtvisita.gxTpr_Visnegassunto = A467VisNegAssunto;
            Gxm1sdtvisita.gxTpr_Visnegvalor = A468VisNegValor;
            Gxm1sdtvisita.gxTpr_Visnegcliid = A407VisNegCliID;
            Gxm1sdtvisita.gxTpr_Visnegclinomefamiliar = A469VisNegCliNomeFamiliar;
            Gxm1sdtvisita.gxTpr_Visnegcpjid = A408VisNegCpjID;
            Gxm1sdtvisita.gxTpr_Visnegcpjnomfan = A470VisNegCpjNomFan;
            Gxm1sdtvisita.gxTpr_Visnegcpjrazsocial = A471VisNegCpjRazSocial;
            Gxm1sdtvisita.gxTpr_Visngfseq = A422VisNgfSeq;
            Gxm1sdtvisita.gxTpr_Visngfiteid = A423VisNgfIteID;
            Gxm1sdtvisita.gxTpr_Visngfitenome = A424VisNgfIteNome;
            Gxm1sdtvisita.gxTpr_Visassunto = A409VisAssunto;
            Gxm1sdtvisita.gxTpr_Visdescricao = A410VisDescricao;
            Gxm1sdtvisita.gxTpr_Vislink = A417VisLink;
            Gxm1sdtvisita.gxTpr_Vissituacao = A472VisSituacao;
            Gxm1sdtvisita.gxTpr_Visdel = A487VisDel;
            Gxm1sdtvisita.gxTpr_Visdeldatahora = A490VisDelDataHora;
            Gxm1sdtvisita.gxTpr_Visdeldata = A488VisDelData;
            Gxm1sdtvisita.gxTpr_Visdelhora = A489VisDelHora;
            Gxm1sdtvisita.gxTpr_Visdelusuid = A491VisDelUsuID;
            Gxm1sdtvisita.gxTpr_Visdelusunome = A492VisDelUsuNome;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
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
         AV9Core_dsvisitafiltrogeral_3_sdtvisita = new GeneXus.Programs.core.SdtsdtVisita(context);
         scmdbuf = "";
         A398VisID = Guid.Empty;
         P000O2_A398VisID = new Guid[] {Guid.Empty} ;
         P000O2_A419VisPaiID = new Guid[] {Guid.Empty} ;
         P000O2_n419VisPaiID = new bool[] {false} ;
         P000O2_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         P000O2_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_A465VisPaiAssunto = new string[] {""} ;
         P000O2_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         P000O2_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_A402VisInsUsuID = new string[] {""} ;
         P000O2_n402VisInsUsuID = new bool[] {false} ;
         P000O2_A403VisInsUsuNome = new string[] {""} ;
         P000O2_n403VisInsUsuNome = new bool[] {false} ;
         P000O2_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         P000O2_n482VisUpdData = new bool[] {false} ;
         P000O2_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_n483VisUpdHora = new bool[] {false} ;
         P000O2_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_n484VisUpdDataHora = new bool[] {false} ;
         P000O2_A485VisUpdUsuID = new string[] {""} ;
         P000O2_n485VisUpdUsuID = new bool[] {false} ;
         P000O2_A486VisUpdUsuNome = new string[] {""} ;
         P000O2_n486VisUpdUsuNome = new bool[] {false} ;
         P000O2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P000O2_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P000O2_n475VisDataFim = new bool[] {false} ;
         P000O2_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P000O2_n476VisHoraFim = new bool[] {false} ;
         P000O2_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P000O2_n477VisDataHoraFim = new bool[] {false} ;
         P000O2_A414VisTipoID = new int[1] ;
         P000O2_A415VisTipoSigla = new string[] {""} ;
         P000O2_A416VisTipoNome = new string[] {""} ;
         P000O2_A418VisNegID = new Guid[] {Guid.Empty} ;
         P000O2_n418VisNegID = new bool[] {false} ;
         P000O2_A466VisNegCodigo = new long[1] ;
         P000O2_A467VisNegAssunto = new string[] {""} ;
         P000O2_A468VisNegValor = new decimal[1] ;
         P000O2_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         P000O2_A469VisNegCliNomeFamiliar = new string[] {""} ;
         P000O2_n469VisNegCliNomeFamiliar = new bool[] {false} ;
         P000O2_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         P000O2_A470VisNegCpjNomFan = new string[] {""} ;
         P000O2_n470VisNegCpjNomFan = new bool[] {false} ;
         P000O2_A471VisNegCpjRazSocial = new string[] {""} ;
         P000O2_n471VisNegCpjRazSocial = new bool[] {false} ;
         P000O2_A422VisNgfSeq = new int[1] ;
         P000O2_n422VisNgfSeq = new bool[] {false} ;
         P000O2_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         P000O2_A424VisNgfIteNome = new string[] {""} ;
         P000O2_n424VisNgfIteNome = new bool[] {false} ;
         P000O2_A409VisAssunto = new string[] {""} ;
         P000O2_A410VisDescricao = new string[] {""} ;
         P000O2_n410VisDescricao = new bool[] {false} ;
         P000O2_A417VisLink = new string[] {""} ;
         P000O2_n417VisLink = new bool[] {false} ;
         P000O2_A472VisSituacao = new string[] {""} ;
         P000O2_A487VisDel = new bool[] {false} ;
         P000O2_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_n490VisDelDataHora = new bool[] {false} ;
         P000O2_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         P000O2_n488VisDelData = new bool[] {false} ;
         P000O2_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         P000O2_n489VisDelHora = new bool[] {false} ;
         P000O2_A491VisDelUsuID = new string[] {""} ;
         P000O2_n491VisDelUsuID = new bool[] {false} ;
         P000O2_A492VisDelUsuNome = new string[] {""} ;
         P000O2_n492VisDelUsuNome = new bool[] {false} ;
         A419VisPaiID = Guid.Empty;
         A460VisPaiData = DateTime.MinValue;
         A461VisPaiHora = (DateTime)(DateTime.MinValue);
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         A465VisPaiAssunto = "";
         A399VisInsData = DateTime.MinValue;
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A402VisInsUsuID = "";
         A403VisInsUsuNome = "";
         A482VisUpdData = DateTime.MinValue;
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         A485VisUpdUsuID = "";
         A486VisUpdUsuNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A415VisTipoSigla = "";
         A416VisTipoNome = "";
         A418VisNegID = Guid.Empty;
         A467VisNegAssunto = "";
         A407VisNegCliID = Guid.Empty;
         A469VisNegCliNomeFamiliar = "";
         A408VisNegCpjID = Guid.Empty;
         A470VisNegCpjNomFan = "";
         A471VisNegCpjRazSocial = "";
         A423VisNgfIteID = Guid.Empty;
         A424VisNgfIteNome = "";
         A409VisAssunto = "";
         A410VisDescricao = "";
         A417VisLink = "";
         A472VisSituacao = "";
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         A488VisDelData = (DateTime)(DateTime.MinValue);
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         A491VisDelUsuID = "";
         A492VisDelUsuNome = "";
         Gxm1sdtvisita = new GeneXus.Programs.core.SdtsdtVisita(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpvisitaobterdados__default(),
            new Object[][] {
                new Object[] {
               P000O2_A398VisID, P000O2_A419VisPaiID, P000O2_n419VisPaiID, P000O2_A460VisPaiData, P000O2_A461VisPaiHora, P000O2_A462VisPaiDataHora, P000O2_A465VisPaiAssunto, P000O2_A399VisInsData, P000O2_A400VisInsHora, P000O2_A401VisInsDataHora,
               P000O2_A402VisInsUsuID, P000O2_n402VisInsUsuID, P000O2_A403VisInsUsuNome, P000O2_n403VisInsUsuNome, P000O2_A482VisUpdData, P000O2_n482VisUpdData, P000O2_A483VisUpdHora, P000O2_n483VisUpdHora, P000O2_A484VisUpdDataHora, P000O2_n484VisUpdDataHora,
               P000O2_A485VisUpdUsuID, P000O2_n485VisUpdUsuID, P000O2_A486VisUpdUsuNome, P000O2_n486VisUpdUsuNome, P000O2_A404VisData, P000O2_A405VisHora, P000O2_A406VisDataHora, P000O2_A475VisDataFim, P000O2_n475VisDataFim, P000O2_A476VisHoraFim,
               P000O2_n476VisHoraFim, P000O2_A477VisDataHoraFim, P000O2_n477VisDataHoraFim, P000O2_A414VisTipoID, P000O2_A415VisTipoSigla, P000O2_A416VisTipoNome, P000O2_A418VisNegID, P000O2_n418VisNegID, P000O2_A466VisNegCodigo, P000O2_A467VisNegAssunto,
               P000O2_A468VisNegValor, P000O2_A407VisNegCliID, P000O2_A469VisNegCliNomeFamiliar, P000O2_n469VisNegCliNomeFamiliar, P000O2_A408VisNegCpjID, P000O2_A470VisNegCpjNomFan, P000O2_n470VisNegCpjNomFan, P000O2_A471VisNegCpjRazSocial, P000O2_n471VisNegCpjRazSocial, P000O2_A422VisNgfSeq,
               P000O2_n422VisNgfSeq, P000O2_A423VisNgfIteID, P000O2_A424VisNgfIteNome, P000O2_n424VisNgfIteNome, P000O2_A409VisAssunto, P000O2_A410VisDescricao, P000O2_n410VisDescricao, P000O2_A417VisLink, P000O2_n417VisLink, P000O2_A472VisSituacao,
               P000O2_A487VisDel, P000O2_A490VisDelDataHora, P000O2_n490VisDelDataHora, P000O2_A488VisDelData, P000O2_n488VisDelData, P000O2_A489VisDelHora, P000O2_n489VisDelHora, P000O2_A491VisDelUsuID, P000O2_n491VisDelUsuID, P000O2_A492VisDelUsuNome,
               P000O2_n492VisDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A414VisTipoID ;
      private int A422VisNgfSeq ;
      private long A466VisNegCodigo ;
      private decimal A468VisNegValor ;
      private string scmdbuf ;
      private string A402VisInsUsuID ;
      private string A485VisUpdUsuID ;
      private string A491VisDelUsuID ;
      private DateTime A461VisPaiHora ;
      private DateTime A462VisPaiDataHora ;
      private DateTime A400VisInsHora ;
      private DateTime A401VisInsDataHora ;
      private DateTime A483VisUpdHora ;
      private DateTime A484VisUpdDataHora ;
      private DateTime A405VisHora ;
      private DateTime A406VisDataHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime A490VisDelDataHora ;
      private DateTime A488VisDelData ;
      private DateTime A489VisDelHora ;
      private DateTime A460VisPaiData ;
      private DateTime A399VisInsData ;
      private DateTime A482VisUpdData ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private bool n419VisPaiID ;
      private bool n402VisInsUsuID ;
      private bool n403VisInsUsuNome ;
      private bool n482VisUpdData ;
      private bool n483VisUpdHora ;
      private bool n484VisUpdDataHora ;
      private bool n485VisUpdUsuID ;
      private bool n486VisUpdUsuNome ;
      private bool n475VisDataFim ;
      private bool n476VisHoraFim ;
      private bool n477VisDataHoraFim ;
      private bool n418VisNegID ;
      private bool n469VisNegCliNomeFamiliar ;
      private bool n470VisNegCpjNomFan ;
      private bool n471VisNegCpjRazSocial ;
      private bool n422VisNgfSeq ;
      private bool n424VisNgfIteNome ;
      private bool n410VisDescricao ;
      private bool n417VisLink ;
      private bool A487VisDel ;
      private bool n490VisDelDataHora ;
      private bool n488VisDelData ;
      private bool n489VisDelHora ;
      private bool n491VisDelUsuID ;
      private bool n492VisDelUsuNome ;
      private string A410VisDescricao ;
      private string A465VisPaiAssunto ;
      private string A403VisInsUsuNome ;
      private string A486VisUpdUsuNome ;
      private string A415VisTipoSigla ;
      private string A416VisTipoNome ;
      private string A467VisNegAssunto ;
      private string A469VisNegCliNomeFamiliar ;
      private string A470VisNegCpjNomFan ;
      private string A471VisNegCpjRazSocial ;
      private string A424VisNgfIteNome ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private string A472VisSituacao ;
      private string A492VisDelUsuNome ;
      private Guid AV9Core_dsvisitafiltrogeral_3_sdtvisita_gxTpr_Visid ;
      private Guid A398VisID ;
      private Guid A419VisPaiID ;
      private Guid A418VisNegID ;
      private Guid A407VisNegCliID ;
      private Guid A408VisNegCpjID ;
      private Guid A423VisNgfIteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000O2_A398VisID ;
      private Guid[] P000O2_A419VisPaiID ;
      private bool[] P000O2_n419VisPaiID ;
      private DateTime[] P000O2_A460VisPaiData ;
      private DateTime[] P000O2_A461VisPaiHora ;
      private DateTime[] P000O2_A462VisPaiDataHora ;
      private string[] P000O2_A465VisPaiAssunto ;
      private DateTime[] P000O2_A399VisInsData ;
      private DateTime[] P000O2_A400VisInsHora ;
      private DateTime[] P000O2_A401VisInsDataHora ;
      private string[] P000O2_A402VisInsUsuID ;
      private bool[] P000O2_n402VisInsUsuID ;
      private string[] P000O2_A403VisInsUsuNome ;
      private bool[] P000O2_n403VisInsUsuNome ;
      private DateTime[] P000O2_A482VisUpdData ;
      private bool[] P000O2_n482VisUpdData ;
      private DateTime[] P000O2_A483VisUpdHora ;
      private bool[] P000O2_n483VisUpdHora ;
      private DateTime[] P000O2_A484VisUpdDataHora ;
      private bool[] P000O2_n484VisUpdDataHora ;
      private string[] P000O2_A485VisUpdUsuID ;
      private bool[] P000O2_n485VisUpdUsuID ;
      private string[] P000O2_A486VisUpdUsuNome ;
      private bool[] P000O2_n486VisUpdUsuNome ;
      private DateTime[] P000O2_A404VisData ;
      private DateTime[] P000O2_A405VisHora ;
      private DateTime[] P000O2_A406VisDataHora ;
      private DateTime[] P000O2_A475VisDataFim ;
      private bool[] P000O2_n475VisDataFim ;
      private DateTime[] P000O2_A476VisHoraFim ;
      private bool[] P000O2_n476VisHoraFim ;
      private DateTime[] P000O2_A477VisDataHoraFim ;
      private bool[] P000O2_n477VisDataHoraFim ;
      private int[] P000O2_A414VisTipoID ;
      private string[] P000O2_A415VisTipoSigla ;
      private string[] P000O2_A416VisTipoNome ;
      private Guid[] P000O2_A418VisNegID ;
      private bool[] P000O2_n418VisNegID ;
      private long[] P000O2_A466VisNegCodigo ;
      private string[] P000O2_A467VisNegAssunto ;
      private decimal[] P000O2_A468VisNegValor ;
      private Guid[] P000O2_A407VisNegCliID ;
      private string[] P000O2_A469VisNegCliNomeFamiliar ;
      private bool[] P000O2_n469VisNegCliNomeFamiliar ;
      private Guid[] P000O2_A408VisNegCpjID ;
      private string[] P000O2_A470VisNegCpjNomFan ;
      private bool[] P000O2_n470VisNegCpjNomFan ;
      private string[] P000O2_A471VisNegCpjRazSocial ;
      private bool[] P000O2_n471VisNegCpjRazSocial ;
      private int[] P000O2_A422VisNgfSeq ;
      private bool[] P000O2_n422VisNgfSeq ;
      private Guid[] P000O2_A423VisNgfIteID ;
      private string[] P000O2_A424VisNgfIteNome ;
      private bool[] P000O2_n424VisNgfIteNome ;
      private string[] P000O2_A409VisAssunto ;
      private string[] P000O2_A410VisDescricao ;
      private bool[] P000O2_n410VisDescricao ;
      private string[] P000O2_A417VisLink ;
      private bool[] P000O2_n417VisLink ;
      private string[] P000O2_A472VisSituacao ;
      private bool[] P000O2_A487VisDel ;
      private DateTime[] P000O2_A490VisDelDataHora ;
      private bool[] P000O2_n490VisDelDataHora ;
      private DateTime[] P000O2_A488VisDelData ;
      private bool[] P000O2_n488VisDelData ;
      private DateTime[] P000O2_A489VisDelHora ;
      private bool[] P000O2_n489VisDelHora ;
      private string[] P000O2_A491VisDelUsuID ;
      private bool[] P000O2_n491VisDelUsuID ;
      private string[] P000O2_A492VisDelUsuNome ;
      private bool[] P000O2_n492VisDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisita> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtVisita AV5sdtVisita ;
      private GeneXus.Programs.core.SdtsdtVisita AV9Core_dsvisitafiltrogeral_3_sdtvisita ;
      private GeneXus.Programs.core.SdtsdtVisita Gxm1sdtvisita ;
   }

   public class dpvisitaobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000O2( IGxContext context ,
                                             Guid AV9Core_dsvisitafiltrogeral_3_sdtvisita_gxTpr_Visid ,
                                             Guid A398VisID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.VisID, T1.VisPaiID AS VisPaiID, T2.VisData AS VisPaiData, T2.VisHora AS VisPaiHora, T2.VisDataHora AS VisPaiDataHora, T2.VisAssunto AS VisPaiAssunto, T1.VisInsData, T1.VisInsHora, T1.VisInsDataHora, T1.VisInsUsuID, T1.VisInsUsuNome, T1.VisUpdData, T1.VisUpdHora, T1.VisUpdDataHora, T1.VisUpdUsuID, T1.VisUpdUsuNome, T1.VisData, T1.VisHora, T1.VisDataHora, T1.VisDataFim, T1.VisHoraFim, T1.VisDataHoraFim, T1.VisTipoID AS VisTipoID, T3.VitSigla AS VisTipoSigla, T3.VitNome AS VisTipoNome, T1.VisNegID AS VisNegID, T4.NegCodigo AS VisNegCodigo, T4.NegAssunto AS VisNegAssunto, T4.NegValorAtualizado AS VisNegValor, T4.NegCliID AS VisNegCliID, T4.NegCliNomeFamiliar AS VisNegCliNomeFamiliar, T4.NegCpjID AS VisNegCpjID, T4.NegCpjNomFan AS VisNegCpjNomFan, T4.NegCpjRazSocial AS VisNegCpjRazSocial, T1.VisNgfSeq AS VisNgfSeq, T5.NgfIteID AS VisNgfIteID, T5.NgfIteNome AS VisNgfIteNome, T1.VisAssunto, T1.VisDescricao, T1.VisLink, T1.VisSituacao, T1.VisDel, T1.VisDelDataHora, T1.VisDelData, T1.VisDelHora, T1.VisDelUsuID, T1.VisDelUsuNome FROM ((((tb_visita T1 LEFT JOIN tb_visita T2 ON T2.VisID = T1.VisPaiID) INNER JOIN tb_visitatipo T3 ON T3.VitID = T1.VisTipoID) LEFT JOIN tb_negociopj T4 ON T4.NegID = T1.VisNegID) LEFT JOIN tb_negociopj_fase T5 ON T5.NegID = T1.VisNegID AND T5.NgfSeq = T1.VisNgfSeq)";
         if ( ! (Guid.Empty==AV9Core_dsvisitafiltrogeral_3_sdtvisita_gxTpr_Visid) )
         {
            AddWhere(sWhereString, "(T1.VisID = :AV9Core__1Visid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.VisID";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000O2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
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
          Object[] prmP000O2;
          prmP000O2 = new Object[] {
          new ParDef("AV9Core__1Visid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                ((string[]) buf[10])[0] = rslt.getString(10, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(19);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(20);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[31])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[32])[0] = rslt.wasNull(22);
                ((int[]) buf[33])[0] = rslt.getInt(23);
                ((string[]) buf[34])[0] = rslt.getVarchar(24);
                ((string[]) buf[35])[0] = rslt.getVarchar(25);
                ((Guid[]) buf[36])[0] = rslt.getGuid(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((string[]) buf[39])[0] = rslt.getVarchar(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((Guid[]) buf[41])[0] = rslt.getGuid(30);
                ((string[]) buf[42])[0] = rslt.getVarchar(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((Guid[]) buf[44])[0] = rslt.getGuid(32);
                ((string[]) buf[45])[0] = rslt.getVarchar(33);
                ((bool[]) buf[46])[0] = rslt.wasNull(33);
                ((string[]) buf[47])[0] = rslt.getVarchar(34);
                ((bool[]) buf[48])[0] = rslt.wasNull(34);
                ((int[]) buf[49])[0] = rslt.getInt(35);
                ((bool[]) buf[50])[0] = rslt.wasNull(35);
                ((Guid[]) buf[51])[0] = rslt.getGuid(36);
                ((string[]) buf[52])[0] = rslt.getVarchar(37);
                ((bool[]) buf[53])[0] = rslt.wasNull(37);
                ((string[]) buf[54])[0] = rslt.getVarchar(38);
                ((string[]) buf[55])[0] = rslt.getLongVarchar(39);
                ((bool[]) buf[56])[0] = rslt.wasNull(39);
                ((string[]) buf[57])[0] = rslt.getVarchar(40);
                ((bool[]) buf[58])[0] = rslt.wasNull(40);
                ((string[]) buf[59])[0] = rslt.getVarchar(41);
                ((bool[]) buf[60])[0] = rslt.getBool(42);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(43, true);
                ((bool[]) buf[62])[0] = rslt.wasNull(43);
                ((DateTime[]) buf[63])[0] = rslt.getGXDateTime(44);
                ((bool[]) buf[64])[0] = rslt.wasNull(44);
                ((DateTime[]) buf[65])[0] = rslt.getGXDateTime(45);
                ((bool[]) buf[66])[0] = rslt.wasNull(45);
                ((string[]) buf[67])[0] = rslt.getString(46, 40);
                ((bool[]) buf[68])[0] = rslt.wasNull(46);
                ((string[]) buf[69])[0] = rslt.getVarchar(47);
                ((bool[]) buf[70])[0] = rslt.wasNull(47);
                return;
       }
    }

 }

}
