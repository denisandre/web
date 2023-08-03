using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class tb_visitaconversion : GXProcedure
   {
      public tb_visitaconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_visitaconversion( IGxContext context )
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
         tb_visitaconversion objtb_visitaconversion;
         objtb_visitaconversion = new tb_visitaconversion();
         objtb_visitaconversion.context.SetSubmitInitialConfig(context);
         objtb_visitaconversion.initialize();
         Submit( executePrivateCatch,objtb_visitaconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_visitaconversion)stateInfo).executePrivate();
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
         /* Using cursor TB_VISITAC2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A492VisDelUsuNome = TB_VISITAC2_A492VisDelUsuNome[0];
            n492VisDelUsuNome = TB_VISITAC2_n492VisDelUsuNome[0];
            A491VisDelUsuID = TB_VISITAC2_A491VisDelUsuID[0];
            n491VisDelUsuID = TB_VISITAC2_n491VisDelUsuID[0];
            A490VisDelDataHora = TB_VISITAC2_A490VisDelDataHora[0];
            n490VisDelDataHora = TB_VISITAC2_n490VisDelDataHora[0];
            A489VisDelHora = TB_VISITAC2_A489VisDelHora[0];
            n489VisDelHora = TB_VISITAC2_n489VisDelHora[0];
            A487VisDel = TB_VISITAC2_A487VisDel[0];
            A486VisUpdUsuNome = TB_VISITAC2_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = TB_VISITAC2_n486VisUpdUsuNome[0];
            A485VisUpdUsuID = TB_VISITAC2_A485VisUpdUsuID[0];
            n485VisUpdUsuID = TB_VISITAC2_n485VisUpdUsuID[0];
            A484VisUpdDataHora = TB_VISITAC2_A484VisUpdDataHora[0];
            n484VisUpdDataHora = TB_VISITAC2_n484VisUpdDataHora[0];
            A483VisUpdHora = TB_VISITAC2_A483VisUpdHora[0];
            n483VisUpdHora = TB_VISITAC2_n483VisUpdHora[0];
            A482VisUpdData = TB_VISITAC2_A482VisUpdData[0];
            n482VisUpdData = TB_VISITAC2_n482VisUpdData[0];
            A477VisDataHoraFim = TB_VISITAC2_A477VisDataHoraFim[0];
            n477VisDataHoraFim = TB_VISITAC2_n477VisDataHoraFim[0];
            A476VisHoraFim = TB_VISITAC2_A476VisHoraFim[0];
            n476VisHoraFim = TB_VISITAC2_n476VisHoraFim[0];
            A475VisDataFim = TB_VISITAC2_A475VisDataFim[0];
            n475VisDataFim = TB_VISITAC2_n475VisDataFim[0];
            A472VisSituacao = TB_VISITAC2_A472VisSituacao[0];
            A422VisNgfSeq = TB_VISITAC2_A422VisNgfSeq[0];
            n422VisNgfSeq = TB_VISITAC2_n422VisNgfSeq[0];
            A419VisPaiID = TB_VISITAC2_A419VisPaiID[0];
            n419VisPaiID = TB_VISITAC2_n419VisPaiID[0];
            A418VisNegID = TB_VISITAC2_A418VisNegID[0];
            n418VisNegID = TB_VISITAC2_n418VisNegID[0];
            A417VisLink = TB_VISITAC2_A417VisLink[0];
            n417VisLink = TB_VISITAC2_n417VisLink[0];
            A414VisTipoID = TB_VISITAC2_A414VisTipoID[0];
            A410VisDescricao = TB_VISITAC2_A410VisDescricao[0];
            n410VisDescricao = TB_VISITAC2_n410VisDescricao[0];
            A409VisAssunto = TB_VISITAC2_A409VisAssunto[0];
            A406VisDataHora = TB_VISITAC2_A406VisDataHora[0];
            A405VisHora = TB_VISITAC2_A405VisHora[0];
            A404VisData = TB_VISITAC2_A404VisData[0];
            A403VisInsUsuNome = TB_VISITAC2_A403VisInsUsuNome[0];
            n403VisInsUsuNome = TB_VISITAC2_n403VisInsUsuNome[0];
            A402VisInsUsuID = TB_VISITAC2_A402VisInsUsuID[0];
            n402VisInsUsuID = TB_VISITAC2_n402VisInsUsuID[0];
            A401VisInsDataHora = TB_VISITAC2_A401VisInsDataHora[0];
            A400VisInsHora = TB_VISITAC2_A400VisInsHora[0];
            A399VisInsData = TB_VISITAC2_A399VisInsData[0];
            A398VisID = TB_VISITAC2_A398VisID[0];
            A488VisDelData = TB_VISITAC2_A488VisDelData[0];
            n488VisDelData = TB_VISITAC2_n488VisDelData[0];
            A40000GXC1 = ( A488VisDelData);
            /*
               INSERT RECORD ON TABLE GXA0040

            */
            AV2VisID = A398VisID;
            AV3VisInsData = A399VisInsData;
            AV4VisInsHora = A400VisInsHora;
            AV5VisInsDataHora = A401VisInsDataHora;
            if ( TB_VISITAC2_n402VisInsUsuID[0] )
            {
               AV6VisInsUsuID = "";
               nV6VisInsUsuID = false;
               nV6VisInsUsuID = true;
            }
            else
            {
               AV6VisInsUsuID = A402VisInsUsuID;
               nV6VisInsUsuID = false;
            }
            if ( TB_VISITAC2_n403VisInsUsuNome[0] )
            {
               AV7VisInsUsuNome = "";
               nV7VisInsUsuNome = false;
               nV7VisInsUsuNome = true;
            }
            else
            {
               AV7VisInsUsuNome = A403VisInsUsuNome;
               nV7VisInsUsuNome = false;
            }
            AV8VisData = A404VisData;
            AV9VisHora = A405VisHora;
            AV10VisDataHora = A406VisDataHora;
            AV11VisAssunto = A409VisAssunto;
            if ( TB_VISITAC2_n410VisDescricao[0] )
            {
               AV12VisDescricao = "";
               nV12VisDescricao = false;
               nV12VisDescricao = true;
            }
            else
            {
               AV12VisDescricao = A410VisDescricao;
               nV12VisDescricao = false;
            }
            AV13VisTipoID = A414VisTipoID;
            if ( TB_VISITAC2_n417VisLink[0] )
            {
               AV14VisLink = "";
               nV14VisLink = false;
               nV14VisLink = true;
            }
            else
            {
               AV14VisLink = A417VisLink;
               nV14VisLink = false;
            }
            if ( TB_VISITAC2_n418VisNegID[0] )
            {
               AV15VisNegID = Guid.Empty;
               nV15VisNegID = false;
               nV15VisNegID = true;
            }
            else
            {
               AV15VisNegID = A418VisNegID;
               nV15VisNegID = false;
            }
            if ( TB_VISITAC2_n419VisPaiID[0] )
            {
               AV16VisPaiID = Guid.Empty;
               nV16VisPaiID = false;
               nV16VisPaiID = true;
            }
            else
            {
               AV16VisPaiID = A419VisPaiID;
               nV16VisPaiID = false;
            }
            if ( TB_VISITAC2_n422VisNgfSeq[0] )
            {
               AV17VisNgfSeq = 0;
               nV17VisNgfSeq = false;
               nV17VisNgfSeq = true;
            }
            else
            {
               AV17VisNgfSeq = A422VisNgfSeq;
               nV17VisNgfSeq = false;
            }
            AV18VisSituacao = A472VisSituacao;
            if ( TB_VISITAC2_n475VisDataFim[0] )
            {
               AV19VisDataFim = DateTime.MinValue;
               nV19VisDataFim = false;
               nV19VisDataFim = true;
            }
            else
            {
               AV19VisDataFim = A475VisDataFim;
               nV19VisDataFim = false;
            }
            if ( TB_VISITAC2_n476VisHoraFim[0] )
            {
               AV20VisHoraFim = (DateTime)(DateTime.MinValue);
               nV20VisHoraFim = false;
               nV20VisHoraFim = true;
            }
            else
            {
               AV20VisHoraFim = A476VisHoraFim;
               nV20VisHoraFim = false;
            }
            if ( TB_VISITAC2_n477VisDataHoraFim[0] )
            {
               AV21VisDataHoraFim = (DateTime)(DateTime.MinValue);
               nV21VisDataHoraFim = false;
               nV21VisDataHoraFim = true;
            }
            else
            {
               AV21VisDataHoraFim = A477VisDataHoraFim;
               nV21VisDataHoraFim = false;
            }
            if ( TB_VISITAC2_n482VisUpdData[0] )
            {
               AV22VisUpdData = DateTime.MinValue;
               nV22VisUpdData = false;
               nV22VisUpdData = true;
            }
            else
            {
               AV22VisUpdData = A482VisUpdData;
               nV22VisUpdData = false;
            }
            if ( TB_VISITAC2_n483VisUpdHora[0] )
            {
               AV23VisUpdHora = (DateTime)(DateTime.MinValue);
               nV23VisUpdHora = false;
               nV23VisUpdHora = true;
            }
            else
            {
               AV23VisUpdHora = A483VisUpdHora;
               nV23VisUpdHora = false;
            }
            if ( TB_VISITAC2_n484VisUpdDataHora[0] )
            {
               AV24VisUpdDataHora = (DateTime)(DateTime.MinValue);
               nV24VisUpdDataHora = false;
               nV24VisUpdDataHora = true;
            }
            else
            {
               AV24VisUpdDataHora = A484VisUpdDataHora;
               nV24VisUpdDataHora = false;
            }
            if ( TB_VISITAC2_n485VisUpdUsuID[0] )
            {
               AV25VisUpdUsuID = "";
               nV25VisUpdUsuID = false;
               nV25VisUpdUsuID = true;
            }
            else
            {
               AV25VisUpdUsuID = A485VisUpdUsuID;
               nV25VisUpdUsuID = false;
            }
            if ( TB_VISITAC2_n486VisUpdUsuNome[0] )
            {
               AV26VisUpdUsuNome = "";
               nV26VisUpdUsuNome = false;
               nV26VisUpdUsuNome = true;
            }
            else
            {
               AV26VisUpdUsuNome = A486VisUpdUsuNome;
               nV26VisUpdUsuNome = false;
            }
            AV27VisDel = A487VisDel;
            if ( TB_VISITAC2_n488VisDelData[0] )
            {
               AV28VisDelData = (DateTime)(DateTime.MinValue);
               nV28VisDelData = false;
               nV28VisDelData = true;
            }
            else
            {
               AV28VisDelData = A40000GXC1;
               nV28VisDelData = false;
            }
            if ( TB_VISITAC2_n489VisDelHora[0] )
            {
               AV29VisDelHora = (DateTime)(DateTime.MinValue);
               nV29VisDelHora = false;
               nV29VisDelHora = true;
            }
            else
            {
               AV29VisDelHora = A489VisDelHora;
               nV29VisDelHora = false;
            }
            if ( TB_VISITAC2_n490VisDelDataHora[0] )
            {
               AV30VisDelDataHora = (DateTime)(DateTime.MinValue);
               nV30VisDelDataHora = false;
               nV30VisDelDataHora = true;
            }
            else
            {
               AV30VisDelDataHora = A490VisDelDataHora;
               nV30VisDelDataHora = false;
            }
            if ( TB_VISITAC2_n491VisDelUsuID[0] )
            {
               AV31VisDelUsuID = "";
               nV31VisDelUsuID = false;
               nV31VisDelUsuID = true;
            }
            else
            {
               AV31VisDelUsuID = A491VisDelUsuID;
               nV31VisDelUsuID = false;
            }
            if ( TB_VISITAC2_n492VisDelUsuNome[0] )
            {
               AV32VisDelUsuNome = "";
               nV32VisDelUsuNome = false;
               nV32VisDelUsuNome = true;
            }
            else
            {
               AV32VisDelUsuNome = A492VisDelUsuNome;
               nV32VisDelUsuNome = false;
            }
            /* Using cursor TB_VISITAC3 */
            pr_default.execute(1, new Object[] {AV2VisID, AV3VisInsData, AV4VisInsHora, AV5VisInsDataHora, nV6VisInsUsuID, AV6VisInsUsuID, nV7VisInsUsuNome, AV7VisInsUsuNome, AV8VisData, AV9VisHora, AV10VisDataHora, AV11VisAssunto, nV12VisDescricao, AV12VisDescricao, AV13VisTipoID, nV14VisLink, AV14VisLink, nV15VisNegID, AV15VisNegID, nV16VisPaiID, AV16VisPaiID, nV17VisNgfSeq, AV17VisNgfSeq, AV18VisSituacao, nV19VisDataFim, AV19VisDataFim, nV20VisHoraFim, AV20VisHoraFim, nV21VisDataHoraFim, AV21VisDataHoraFim, nV22VisUpdData, AV22VisUpdData, nV23VisUpdHora, AV23VisUpdHora, nV24VisUpdDataHora, AV24VisUpdDataHora, nV25VisUpdUsuID, AV25VisUpdUsuID, nV26VisUpdUsuNome, AV26VisUpdUsuNome, AV27VisDel, nV28VisDelData, AV28VisDelData, nV29VisDelHora, AV29VisDelHora, nV30VisDelDataHora, AV30VisDelDataHora, nV31VisDelUsuID, AV31VisDelUsuID, nV32VisDelUsuNome, AV32VisDelUsuNome});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0040");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         scmdbuf = "";
         TB_VISITAC2_A492VisDelUsuNome = new string[] {""} ;
         TB_VISITAC2_n492VisDelUsuNome = new bool[] {false} ;
         TB_VISITAC2_A491VisDelUsuID = new string[] {""} ;
         TB_VISITAC2_n491VisDelUsuID = new bool[] {false} ;
         TB_VISITAC2_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n490VisDelDataHora = new bool[] {false} ;
         TB_VISITAC2_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n489VisDelHora = new bool[] {false} ;
         TB_VISITAC2_A487VisDel = new bool[] {false} ;
         TB_VISITAC2_A486VisUpdUsuNome = new string[] {""} ;
         TB_VISITAC2_n486VisUpdUsuNome = new bool[] {false} ;
         TB_VISITAC2_A485VisUpdUsuID = new string[] {""} ;
         TB_VISITAC2_n485VisUpdUsuID = new bool[] {false} ;
         TB_VISITAC2_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n484VisUpdDataHora = new bool[] {false} ;
         TB_VISITAC2_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n483VisUpdHora = new bool[] {false} ;
         TB_VISITAC2_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n482VisUpdData = new bool[] {false} ;
         TB_VISITAC2_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n477VisDataHoraFim = new bool[] {false} ;
         TB_VISITAC2_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n476VisHoraFim = new bool[] {false} ;
         TB_VISITAC2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n475VisDataFim = new bool[] {false} ;
         TB_VISITAC2_A472VisSituacao = new string[] {""} ;
         TB_VISITAC2_A422VisNgfSeq = new int[1] ;
         TB_VISITAC2_n422VisNgfSeq = new bool[] {false} ;
         TB_VISITAC2_A419VisPaiID = new Guid[] {Guid.Empty} ;
         TB_VISITAC2_n419VisPaiID = new bool[] {false} ;
         TB_VISITAC2_A418VisNegID = new Guid[] {Guid.Empty} ;
         TB_VISITAC2_n418VisNegID = new bool[] {false} ;
         TB_VISITAC2_A417VisLink = new string[] {""} ;
         TB_VISITAC2_n417VisLink = new bool[] {false} ;
         TB_VISITAC2_A414VisTipoID = new int[1] ;
         TB_VISITAC2_A410VisDescricao = new string[] {""} ;
         TB_VISITAC2_n410VisDescricao = new bool[] {false} ;
         TB_VISITAC2_A409VisAssunto = new string[] {""} ;
         TB_VISITAC2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_A403VisInsUsuNome = new string[] {""} ;
         TB_VISITAC2_n403VisInsUsuNome = new bool[] {false} ;
         TB_VISITAC2_A402VisInsUsuID = new string[] {""} ;
         TB_VISITAC2_n402VisInsUsuID = new bool[] {false} ;
         TB_VISITAC2_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_A398VisID = new Guid[] {Guid.Empty} ;
         TB_VISITAC2_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         TB_VISITAC2_n488VisDelData = new bool[] {false} ;
         A492VisDelUsuNome = "";
         A491VisDelUsuID = "";
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         A486VisUpdUsuNome = "";
         A485VisUpdUsuID = "";
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         A482VisUpdData = DateTime.MinValue;
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A472VisSituacao = "";
         A419VisPaiID = Guid.Empty;
         A418VisNegID = Guid.Empty;
         A417VisLink = "";
         A410VisDescricao = "";
         A409VisAssunto = "";
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A405VisHora = (DateTime)(DateTime.MinValue);
         A404VisData = DateTime.MinValue;
         A403VisInsUsuNome = "";
         A402VisInsUsuID = "";
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         A399VisInsData = DateTime.MinValue;
         A398VisID = Guid.Empty;
         A488VisDelData = DateTime.MinValue;
         A40000GXC1 = (DateTime)(DateTime.MinValue);
         AV2VisID = Guid.Empty;
         AV3VisInsData = DateTime.MinValue;
         AV4VisInsHora = (DateTime)(DateTime.MinValue);
         AV5VisInsDataHora = (DateTime)(DateTime.MinValue);
         AV6VisInsUsuID = "";
         AV7VisInsUsuNome = "";
         AV8VisData = DateTime.MinValue;
         AV9VisHora = (DateTime)(DateTime.MinValue);
         AV10VisDataHora = (DateTime)(DateTime.MinValue);
         AV11VisAssunto = "";
         AV12VisDescricao = "";
         AV14VisLink = "";
         AV15VisNegID = Guid.Empty;
         AV16VisPaiID = Guid.Empty;
         AV18VisSituacao = "";
         AV19VisDataFim = DateTime.MinValue;
         AV20VisHoraFim = (DateTime)(DateTime.MinValue);
         AV21VisDataHoraFim = (DateTime)(DateTime.MinValue);
         AV22VisUpdData = DateTime.MinValue;
         AV23VisUpdHora = (DateTime)(DateTime.MinValue);
         AV24VisUpdDataHora = (DateTime)(DateTime.MinValue);
         AV25VisUpdUsuID = "";
         AV26VisUpdUsuNome = "";
         AV28VisDelData = (DateTime)(DateTime.MinValue);
         AV29VisDelHora = (DateTime)(DateTime.MinValue);
         AV30VisDelDataHora = (DateTime)(DateTime.MinValue);
         AV31VisDelUsuID = "";
         AV32VisDelUsuNome = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_visitaconversion__default(),
            new Object[][] {
                new Object[] {
               TB_VISITAC2_A492VisDelUsuNome, TB_VISITAC2_n492VisDelUsuNome, TB_VISITAC2_A491VisDelUsuID, TB_VISITAC2_n491VisDelUsuID, TB_VISITAC2_A490VisDelDataHora, TB_VISITAC2_n490VisDelDataHora, TB_VISITAC2_A489VisDelHora, TB_VISITAC2_n489VisDelHora, TB_VISITAC2_A487VisDel, TB_VISITAC2_A486VisUpdUsuNome,
               TB_VISITAC2_n486VisUpdUsuNome, TB_VISITAC2_A485VisUpdUsuID, TB_VISITAC2_n485VisUpdUsuID, TB_VISITAC2_A484VisUpdDataHora, TB_VISITAC2_n484VisUpdDataHora, TB_VISITAC2_A483VisUpdHora, TB_VISITAC2_n483VisUpdHora, TB_VISITAC2_A482VisUpdData, TB_VISITAC2_n482VisUpdData, TB_VISITAC2_A477VisDataHoraFim,
               TB_VISITAC2_n477VisDataHoraFim, TB_VISITAC2_A476VisHoraFim, TB_VISITAC2_n476VisHoraFim, TB_VISITAC2_A475VisDataFim, TB_VISITAC2_n475VisDataFim, TB_VISITAC2_A472VisSituacao, TB_VISITAC2_A422VisNgfSeq, TB_VISITAC2_n422VisNgfSeq, TB_VISITAC2_A419VisPaiID, TB_VISITAC2_n419VisPaiID,
               TB_VISITAC2_A418VisNegID, TB_VISITAC2_n418VisNegID, TB_VISITAC2_A417VisLink, TB_VISITAC2_n417VisLink, TB_VISITAC2_A414VisTipoID, TB_VISITAC2_A410VisDescricao, TB_VISITAC2_n410VisDescricao, TB_VISITAC2_A409VisAssunto, TB_VISITAC2_A406VisDataHora, TB_VISITAC2_A405VisHora,
               TB_VISITAC2_A404VisData, TB_VISITAC2_A403VisInsUsuNome, TB_VISITAC2_n403VisInsUsuNome, TB_VISITAC2_A402VisInsUsuID, TB_VISITAC2_n402VisInsUsuID, TB_VISITAC2_A401VisInsDataHora, TB_VISITAC2_A400VisInsHora, TB_VISITAC2_A399VisInsData, TB_VISITAC2_A398VisID, TB_VISITAC2_A488VisDelData,
               TB_VISITAC2_n488VisDelData
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A422VisNgfSeq ;
      private int A414VisTipoID ;
      private int GIGXA0040 ;
      private int AV13VisTipoID ;
      private int AV17VisNgfSeq ;
      private string scmdbuf ;
      private string A491VisDelUsuID ;
      private string A485VisUpdUsuID ;
      private string A402VisInsUsuID ;
      private string AV6VisInsUsuID ;
      private string AV25VisUpdUsuID ;
      private string AV31VisDelUsuID ;
      private string Gx_emsg ;
      private DateTime A490VisDelDataHora ;
      private DateTime A489VisDelHora ;
      private DateTime A484VisUpdDataHora ;
      private DateTime A483VisUpdHora ;
      private DateTime A477VisDataHoraFim ;
      private DateTime A476VisHoraFim ;
      private DateTime A406VisDataHora ;
      private DateTime A405VisHora ;
      private DateTime A401VisInsDataHora ;
      private DateTime A400VisInsHora ;
      private DateTime A40000GXC1 ;
      private DateTime AV4VisInsHora ;
      private DateTime AV5VisInsDataHora ;
      private DateTime AV9VisHora ;
      private DateTime AV10VisDataHora ;
      private DateTime AV20VisHoraFim ;
      private DateTime AV21VisDataHoraFim ;
      private DateTime AV23VisUpdHora ;
      private DateTime AV24VisUpdDataHora ;
      private DateTime AV28VisDelData ;
      private DateTime AV29VisDelHora ;
      private DateTime AV30VisDelDataHora ;
      private DateTime A482VisUpdData ;
      private DateTime A475VisDataFim ;
      private DateTime A404VisData ;
      private DateTime A399VisInsData ;
      private DateTime A488VisDelData ;
      private DateTime AV3VisInsData ;
      private DateTime AV8VisData ;
      private DateTime AV19VisDataFim ;
      private DateTime AV22VisUpdData ;
      private bool n492VisDelUsuNome ;
      private bool n491VisDelUsuID ;
      private bool n490VisDelDataHora ;
      private bool n489VisDelHora ;
      private bool A487VisDel ;
      private bool n486VisUpdUsuNome ;
      private bool n485VisUpdUsuID ;
      private bool n484VisUpdDataHora ;
      private bool n483VisUpdHora ;
      private bool n482VisUpdData ;
      private bool n477VisDataHoraFim ;
      private bool n476VisHoraFim ;
      private bool n475VisDataFim ;
      private bool n422VisNgfSeq ;
      private bool n419VisPaiID ;
      private bool n418VisNegID ;
      private bool n417VisLink ;
      private bool n410VisDescricao ;
      private bool n403VisInsUsuNome ;
      private bool n402VisInsUsuID ;
      private bool n488VisDelData ;
      private bool nV6VisInsUsuID ;
      private bool nV7VisInsUsuNome ;
      private bool nV12VisDescricao ;
      private bool nV14VisLink ;
      private bool nV15VisNegID ;
      private bool nV16VisPaiID ;
      private bool nV17VisNgfSeq ;
      private bool nV19VisDataFim ;
      private bool nV20VisHoraFim ;
      private bool nV21VisDataHoraFim ;
      private bool nV22VisUpdData ;
      private bool nV23VisUpdHora ;
      private bool nV24VisUpdDataHora ;
      private bool nV25VisUpdUsuID ;
      private bool nV26VisUpdUsuNome ;
      private bool AV27VisDel ;
      private bool nV28VisDelData ;
      private bool nV29VisDelHora ;
      private bool nV30VisDelDataHora ;
      private bool nV31VisDelUsuID ;
      private bool nV32VisDelUsuNome ;
      private string A410VisDescricao ;
      private string AV12VisDescricao ;
      private string A492VisDelUsuNome ;
      private string A486VisUpdUsuNome ;
      private string A472VisSituacao ;
      private string A417VisLink ;
      private string A409VisAssunto ;
      private string A403VisInsUsuNome ;
      private string AV7VisInsUsuNome ;
      private string AV11VisAssunto ;
      private string AV14VisLink ;
      private string AV18VisSituacao ;
      private string AV26VisUpdUsuNome ;
      private string AV32VisDelUsuNome ;
      private Guid A419VisPaiID ;
      private Guid A418VisNegID ;
      private Guid A398VisID ;
      private Guid AV2VisID ;
      private Guid AV15VisNegID ;
      private Guid AV16VisPaiID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TB_VISITAC2_A492VisDelUsuNome ;
      private bool[] TB_VISITAC2_n492VisDelUsuNome ;
      private string[] TB_VISITAC2_A491VisDelUsuID ;
      private bool[] TB_VISITAC2_n491VisDelUsuID ;
      private DateTime[] TB_VISITAC2_A490VisDelDataHora ;
      private bool[] TB_VISITAC2_n490VisDelDataHora ;
      private DateTime[] TB_VISITAC2_A489VisDelHora ;
      private bool[] TB_VISITAC2_n489VisDelHora ;
      private bool[] TB_VISITAC2_A487VisDel ;
      private string[] TB_VISITAC2_A486VisUpdUsuNome ;
      private bool[] TB_VISITAC2_n486VisUpdUsuNome ;
      private string[] TB_VISITAC2_A485VisUpdUsuID ;
      private bool[] TB_VISITAC2_n485VisUpdUsuID ;
      private DateTime[] TB_VISITAC2_A484VisUpdDataHora ;
      private bool[] TB_VISITAC2_n484VisUpdDataHora ;
      private DateTime[] TB_VISITAC2_A483VisUpdHora ;
      private bool[] TB_VISITAC2_n483VisUpdHora ;
      private DateTime[] TB_VISITAC2_A482VisUpdData ;
      private bool[] TB_VISITAC2_n482VisUpdData ;
      private DateTime[] TB_VISITAC2_A477VisDataHoraFim ;
      private bool[] TB_VISITAC2_n477VisDataHoraFim ;
      private DateTime[] TB_VISITAC2_A476VisHoraFim ;
      private bool[] TB_VISITAC2_n476VisHoraFim ;
      private DateTime[] TB_VISITAC2_A475VisDataFim ;
      private bool[] TB_VISITAC2_n475VisDataFim ;
      private string[] TB_VISITAC2_A472VisSituacao ;
      private int[] TB_VISITAC2_A422VisNgfSeq ;
      private bool[] TB_VISITAC2_n422VisNgfSeq ;
      private Guid[] TB_VISITAC2_A419VisPaiID ;
      private bool[] TB_VISITAC2_n419VisPaiID ;
      private Guid[] TB_VISITAC2_A418VisNegID ;
      private bool[] TB_VISITAC2_n418VisNegID ;
      private string[] TB_VISITAC2_A417VisLink ;
      private bool[] TB_VISITAC2_n417VisLink ;
      private int[] TB_VISITAC2_A414VisTipoID ;
      private string[] TB_VISITAC2_A410VisDescricao ;
      private bool[] TB_VISITAC2_n410VisDescricao ;
      private string[] TB_VISITAC2_A409VisAssunto ;
      private DateTime[] TB_VISITAC2_A406VisDataHora ;
      private DateTime[] TB_VISITAC2_A405VisHora ;
      private DateTime[] TB_VISITAC2_A404VisData ;
      private string[] TB_VISITAC2_A403VisInsUsuNome ;
      private bool[] TB_VISITAC2_n403VisInsUsuNome ;
      private string[] TB_VISITAC2_A402VisInsUsuID ;
      private bool[] TB_VISITAC2_n402VisInsUsuID ;
      private DateTime[] TB_VISITAC2_A401VisInsDataHora ;
      private DateTime[] TB_VISITAC2_A400VisInsHora ;
      private DateTime[] TB_VISITAC2_A399VisInsData ;
      private Guid[] TB_VISITAC2_A398VisID ;
      private DateTime[] TB_VISITAC2_A488VisDelData ;
      private bool[] TB_VISITAC2_n488VisDelData ;
   }

   public class tb_visitaconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTB_VISITAC2;
          prmTB_VISITAC2 = new Object[] {
          };
          Object[] prmTB_VISITAC3;
          prmTB_VISITAC3 = new Object[] {
          new ParDef("AV2VisID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3VisInsData",GXType.Date,8,0) ,
          new ParDef("AV4VisInsHora",GXType.DateTime,0,5) ,
          new ParDef("AV5VisInsDataHora",GXType.DateTime2,10,12) ,
          new ParDef("AV6VisInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV7VisInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("AV8VisData",GXType.Date,8,0) ,
          new ParDef("AV9VisHora",GXType.DateTime,0,5) ,
          new ParDef("AV10VisDataHora",GXType.DateTime,10,5) ,
          new ParDef("AV11VisAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV12VisDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV13VisTipoID",GXType.Int32,9,0) ,
          new ParDef("AV14VisLink",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("AV15VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV16VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV17VisNgfSeq",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("AV18VisSituacao",GXType.VarChar,3,0) ,
          new ParDef("AV19VisDataFim",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AV20VisHoraFim",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV21VisDataHoraFim",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("AV22VisUpdData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AV23VisUpdHora",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV24VisUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("AV25VisUpdUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV26VisUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("AV27VisDel",GXType.Boolean,1,0) ,
          new ParDef("AV28VisDelData",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("AV29VisDelHora",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV30VisDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("AV31VisDelUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV32VisDelUsuNome",GXType.VarChar,80,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TB_VISITAC2", "SELECT VisDelUsuNome, VisDelUsuID, VisDelDataHora, VisDelHora, VisDel, VisUpdUsuNome, VisUpdUsuID, VisUpdDataHora, VisUpdHora, VisUpdData, VisDataHoraFim, VisHoraFim, VisDataFim, VisSituacao, VisNgfSeq, VisPaiID, VisNegID, VisLink, VisTipoID, VisDescricao, VisAssunto, VisDataHora, VisHora, VisData, VisInsUsuNome, VisInsUsuID, VisInsDataHora, VisInsHora, VisInsData, VisID, VisDelData FROM tb_visita ORDER BY VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_VISITAC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_VISITAC3", "INSERT INTO GXA0040(VisID, VisInsData, VisInsHora, VisInsDataHora, VisInsUsuID, VisInsUsuNome, VisData, VisHora, VisDataHora, VisAssunto, VisDescricao, VisTipoID, VisLink, VisNegID, VisPaiID, VisNgfSeq, VisSituacao, VisDataFim, VisHoraFim, VisDataHoraFim, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisDel, VisDelData, VisDelHora, VisDelDataHora, VisDelUsuID, VisDelUsuNome) VALUES(:AV2VisID, :AV3VisInsData, :AV4VisInsHora, :AV5VisInsDataHora, :AV6VisInsUsuID, :AV7VisInsUsuNome, :AV8VisData, :AV9VisHora, :AV10VisDataHora, :AV11VisAssunto, :AV12VisDescricao, :AV13VisTipoID, :AV14VisLink, :AV15VisNegID, :AV16VisPaiID, :AV17VisNgfSeq, :AV18VisSituacao, :AV19VisDataFim, :AV20VisHoraFim, :AV21VisDataHoraFim, :AV22VisUpdData, :AV23VisUpdHora, :AV24VisUpdDataHora, :AV25VisUpdUsuID, :AV26VisUpdUsuNome, :AV27VisDel, :AV28VisDelData, :AV29VisDelHora, :AV30VisDelDataHora, :AV31VisDelUsuID, :AV32VisDelUsuNome)", GxErrorMask.GX_NOMASK,prmTB_VISITAC3)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 40);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3, true);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8, true);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((int[]) buf[26])[0] = rslt.getInt(15);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((Guid[]) buf[28])[0] = rslt.getGuid(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((Guid[]) buf[30])[0] = rslt.getGuid(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((string[]) buf[32])[0] = rslt.getVarchar(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((string[]) buf[35])[0] = rslt.getLongVarchar(20);
                ((bool[]) buf[36])[0] = rslt.wasNull(20);
                ((string[]) buf[37])[0] = rslt.getVarchar(21);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(22);
                ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(23);
                ((DateTime[]) buf[40])[0] = rslt.getGXDate(24);
                ((string[]) buf[41])[0] = rslt.getVarchar(25);
                ((bool[]) buf[42])[0] = rslt.wasNull(25);
                ((string[]) buf[43])[0] = rslt.getString(26, 40);
                ((bool[]) buf[44])[0] = rslt.wasNull(26);
                ((DateTime[]) buf[45])[0] = rslt.getGXDateTime(27, true);
                ((DateTime[]) buf[46])[0] = rslt.getGXDateTime(28);
                ((DateTime[]) buf[47])[0] = rslt.getGXDate(29);
                ((Guid[]) buf[48])[0] = rslt.getGuid(30);
                ((DateTime[]) buf[49])[0] = rslt.getGXDate(31);
                ((bool[]) buf[50])[0] = rslt.wasNull(31);
                return;
       }
    }

 }

}
