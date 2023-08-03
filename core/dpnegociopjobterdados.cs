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
   public class dpnegociopjobterdados : GXProcedure
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

      public dpnegociopjobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpnegociopjobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> aP1_Gxm2rootcol )
      {
         this.AV5sdtNegocioPJ = aP0_sdtNegocioPJ;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ>( context, "sdtNegocioPJ", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> executeUdp( GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ )
      {
         execute(aP0_sdtNegocioPJ, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> aP1_Gxm2rootcol )
      {
         dpnegociopjobterdados objdpnegociopjobterdados;
         objdpnegociopjobterdados = new dpnegociopjobterdados();
         objdpnegociopjobterdados.AV5sdtNegocioPJ = aP0_sdtNegocioPJ;
         objdpnegociopjobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ>( context, "sdtNegocioPJ", "agl_tresorygroup") ;
         objdpnegociopjobterdados.context.SetSubmitInitialConfig(context);
         objdpnegociopjobterdados.initialize();
         Submit( executePrivateCatch,objdpnegociopjobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpnegociopjobterdados)stateInfo).executePrivate();
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
         AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj = AV5sdtNegocioPJ;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj.gxTpr_Negid ,
                                              A345NegID } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P000Y3 */
         pr_default.execute(0, new Object[] {AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj.gxTpr_Negid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A345NegID = P000Y3_A345NegID[0];
            A356NegCodigo = P000Y3_A356NegCodigo[0];
            A346NegInsData = P000Y3_A346NegInsData[0];
            A347NegInsHora = P000Y3_A347NegInsHora[0];
            A348NegInsDataHora = P000Y3_A348NegInsDataHora[0];
            A349NegInsUsuID = P000Y3_A349NegInsUsuID[0];
            n349NegInsUsuID = P000Y3_n349NegInsUsuID[0];
            A364NegInsUsuNome = P000Y3_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P000Y3_n364NegInsUsuNome[0];
            A350NegCliID = P000Y3_A350NegCliID[0];
            A473NegCliMatricula = P000Y3_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = P000Y3_A351NegCliNomeFamiliar[0];
            A352NegCpjID = P000Y3_A352NegCpjID[0];
            A353NegCpjNomFan = P000Y3_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = P000Y3_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = P000Y3_A355NegCpjMatricula[0];
            A357NegPjtID = P000Y3_A357NegPjtID[0];
            A358NegPjtSigla = P000Y3_A358NegPjtSigla[0];
            A359NegPjtNome = P000Y3_A359NegPjtNome[0];
            A369NegCpjEndSeq = P000Y3_A369NegCpjEndSeq[0];
            A370NegCpjEndNome = P000Y3_A370NegCpjEndNome[0];
            A642NegCpjEndCep = P000Y3_A642NegCpjEndCep[0];
            A375NegCpjEndMunID = P000Y3_A375NegCpjEndMunID[0];
            A377NegCpjEndUFID = P000Y3_A377NegCpjEndUFID[0];
            A379NegCpjEndUFNome = P000Y3_A379NegCpjEndUFNome[0];
            A360NegAgcID = P000Y3_A360NegAgcID[0];
            n360NegAgcID = P000Y3_n360NegAgcID[0];
            A361NegAgcNome = P000Y3_A361NegAgcNome[0];
            n361NegAgcNome = P000Y3_n361NegAgcNome[0];
            A362NegAssunto = P000Y3_A362NegAssunto[0];
            A363NegDescricao = P000Y3_A363NegDescricao[0];
            A380NegValorEstimado = P000Y3_A380NegValorEstimado[0];
            A385NegValorAtualizado = P000Y3_A385NegValorAtualizado[0];
            A454NegUltItem = P000Y3_A454NegUltItem[0];
            n454NegUltItem = P000Y3_n454NegUltItem[0];
            A572NegDel = P000Y3_A572NegDel[0];
            A573NegDelDataHora = P000Y3_A573NegDelDataHora[0];
            n573NegDelDataHora = P000Y3_n573NegDelDataHora[0];
            A574NegDelData = P000Y3_A574NegDelData[0];
            n574NegDelData = P000Y3_n574NegDelData[0];
            A575NegDelHora = P000Y3_A575NegDelHora[0];
            n575NegDelHora = P000Y3_n575NegDelHora[0];
            A576NegDelUsuId = P000Y3_A576NegDelUsuId[0];
            n576NegDelUsuId = P000Y3_n576NegDelUsuId[0];
            A577NegDelUsuNome = P000Y3_A577NegDelUsuNome[0];
            n577NegDelUsuNome = P000Y3_n577NegDelUsuNome[0];
            A448NegPgpTotal = P000Y3_A448NegPgpTotal[0];
            n448NegPgpTotal = P000Y3_n448NegPgpTotal[0];
            A373NegCpjEndComplem = P000Y3_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P000Y3_n373NegCpjEndComplem[0];
            A372NegCpjEndNumero = P000Y3_A372NegCpjEndNumero[0];
            A378NegCpjEndUFSigla = P000Y3_A378NegCpjEndUFSigla[0];
            A376NegCpjEndMunNome = P000Y3_A376NegCpjEndMunNome[0];
            A643NegCpjEndCepFormat = P000Y3_A643NegCpjEndCepFormat[0];
            A374NegCpjEndBairro = P000Y3_A374NegCpjEndBairro[0];
            A371NegCpjEndEndereco = P000Y3_A371NegCpjEndEndereco[0];
            A448NegPgpTotal = P000Y3_A448NegPgpTotal[0];
            n448NegPgpTotal = P000Y3_n448NegPgpTotal[0];
            A473NegCliMatricula = P000Y3_A473NegCliMatricula[0];
            A355NegCpjMatricula = P000Y3_A355NegCpjMatricula[0];
            A357NegPjtID = P000Y3_A357NegPjtID[0];
            A358NegPjtSigla = P000Y3_A358NegPjtSigla[0];
            A370NegCpjEndNome = P000Y3_A370NegCpjEndNome[0];
            A642NegCpjEndCep = P000Y3_A642NegCpjEndCep[0];
            A375NegCpjEndMunID = P000Y3_A375NegCpjEndMunID[0];
            A377NegCpjEndUFID = P000Y3_A377NegCpjEndUFID[0];
            A379NegCpjEndUFNome = P000Y3_A379NegCpjEndUFNome[0];
            A373NegCpjEndComplem = P000Y3_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P000Y3_n373NegCpjEndComplem[0];
            A372NegCpjEndNumero = P000Y3_A372NegCpjEndNumero[0];
            A378NegCpjEndUFSigla = P000Y3_A378NegCpjEndUFSigla[0];
            A376NegCpjEndMunNome = P000Y3_A376NegCpjEndMunNome[0];
            A643NegCpjEndCepFormat = P000Y3_A643NegCpjEndCepFormat[0];
            A374NegCpjEndBairro = P000Y3_A374NegCpjEndBairro[0];
            A371NegCpjEndEndereco = P000Y3_A371NegCpjEndEndereco[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  }
                  else
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  }
               }
            }
            Gxm1sdtnegociopj = new GeneXus.Programs.core.SdtsdtNegocioPJ(context);
            Gxm2rootcol.Add(Gxm1sdtnegociopj, 0);
            Gxm1sdtnegociopj.gxTpr_Negid = A345NegID;
            Gxm1sdtnegociopj.gxTpr_Negcodigo = A356NegCodigo;
            Gxm1sdtnegociopj.gxTpr_Neginsdata = A346NegInsData;
            Gxm1sdtnegociopj.gxTpr_Neginshora = A347NegInsHora;
            Gxm1sdtnegociopj.gxTpr_Neginsdatahora = A348NegInsDataHora;
            Gxm1sdtnegociopj.gxTpr_Neginsusuid = A349NegInsUsuID;
            Gxm1sdtnegociopj.gxTpr_Neginsusunome = A364NegInsUsuNome;
            Gxm1sdtnegociopj.gxTpr_Negcliid = A350NegCliID;
            Gxm1sdtnegociopj.gxTpr_Negclimatricula = A473NegCliMatricula;
            Gxm1sdtnegociopj.gxTpr_Negclinomefamiliar = A351NegCliNomeFamiliar;
            Gxm1sdtnegociopj.gxTpr_Negcpjid = A352NegCpjID;
            Gxm1sdtnegociopj.gxTpr_Negcpjnomfan = A353NegCpjNomFan;
            Gxm1sdtnegociopj.gxTpr_Negcpjrazsocial = A354NegCpjRazSocial;
            Gxm1sdtnegociopj.gxTpr_Negcpjmatricula = A355NegCpjMatricula;
            Gxm1sdtnegociopj.gxTpr_Negpjtid = A357NegPjtID;
            Gxm1sdtnegociopj.gxTpr_Negpjtsigla = A358NegPjtSigla;
            Gxm1sdtnegociopj.gxTpr_Negpjtnome = A359NegPjtNome;
            Gxm1sdtnegociopj.gxTpr_Negcpjendseq = A369NegCpjEndSeq;
            Gxm1sdtnegociopj.gxTpr_Negcpjendnome = A370NegCpjEndNome;
            Gxm1sdtnegociopj.gxTpr_Negcpjendendereco = A371NegCpjEndEndereco;
            Gxm1sdtnegociopj.gxTpr_Negcpjendnumero = A372NegCpjEndNumero;
            Gxm1sdtnegociopj.gxTpr_Negcpjendcomplem = A373NegCpjEndComplem;
            Gxm1sdtnegociopj.gxTpr_Negcpjendbairro = A374NegCpjEndBairro;
            Gxm1sdtnegociopj.gxTpr_Negcpjendcep = A642NegCpjEndCep;
            Gxm1sdtnegociopj.gxTpr_Negcpjendcepformat = A643NegCpjEndCepFormat;
            Gxm1sdtnegociopj.gxTpr_Negcpjendmunid = A375NegCpjEndMunID;
            Gxm1sdtnegociopj.gxTpr_Negcpjendmunnome = A376NegCpjEndMunNome;
            Gxm1sdtnegociopj.gxTpr_Negcpjendufid = A377NegCpjEndUFID;
            Gxm1sdtnegociopj.gxTpr_Negcpjendufsigla = A378NegCpjEndUFSigla;
            Gxm1sdtnegociopj.gxTpr_Negcpjendufnome = A379NegCpjEndUFNome;
            Gxm1sdtnegociopj.gxTpr_Negcpjendcompleto = A641NegCpjEndCompleto;
            Gxm1sdtnegociopj.gxTpr_Negagcid = A360NegAgcID;
            Gxm1sdtnegociopj.gxTpr_Negagcnome = A361NegAgcNome;
            Gxm1sdtnegociopj.gxTpr_Negassunto = A362NegAssunto;
            Gxm1sdtnegociopj.gxTpr_Negdescricao = A363NegDescricao;
            Gxm1sdtnegociopj.gxTpr_Negpgptotal = A448NegPgpTotal;
            Gxm1sdtnegociopj.gxTpr_Negvalorestimado = A380NegValorEstimado;
            Gxm1sdtnegociopj.gxTpr_Negvaloratualizado = A385NegValorAtualizado;
            Gxm1sdtnegociopj.gxTpr_Negultitem = A454NegUltItem;
            Gxm1sdtnegociopj.gxTpr_Negdel = A572NegDel;
            Gxm1sdtnegociopj.gxTpr_Negdeldatahora = A573NegDelDataHora;
            Gxm1sdtnegociopj.gxTpr_Negdeldata = A574NegDelData;
            Gxm1sdtnegociopj.gxTpr_Negdelhora = A575NegDelHora;
            Gxm1sdtnegociopj.gxTpr_Negdelusuid = A576NegDelUsuId;
            Gxm1sdtnegociopj.gxTpr_Negdelusunome = A577NegDelUsuNome;
            /* Using cursor P000Y4 */
            pr_default.execute(1, new Object[] {A345NegID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A435NgpItem = P000Y4_A435NgpItem[0];
               A455NgpInsData = P000Y4_A455NgpInsData[0];
               A456NgpInsHora = P000Y4_A456NgpInsHora[0];
               A457NgpInsDataHora = P000Y4_A457NgpInsDataHora[0];
               A458NgpInsUsuID = P000Y4_A458NgpInsUsuID[0];
               n458NgpInsUsuID = P000Y4_n458NgpInsUsuID[0];
               A459NgpInsUsuNome = P000Y4_A459NgpInsUsuNome[0];
               n459NgpInsUsuNome = P000Y4_n459NgpInsUsuNome[0];
               A478NgpTppID = P000Y4_A478NgpTppID[0];
               A439NgpTppPrdID = P000Y4_A439NgpTppPrdID[0];
               A440NgpTppPrdCodigo = P000Y4_A440NgpTppPrdCodigo[0];
               A441NgpTppPrdNome = P000Y4_A441NgpTppPrdNome[0];
               A442NgpTppPrdTipoID = P000Y4_A442NgpTppPrdTipoID[0];
               A443NgpTppPrdAtivo = P000Y4_A443NgpTppPrdAtivo[0];
               A444NgpTpp1Preco = P000Y4_A444NgpTpp1Preco[0];
               A445NgpPreco = P000Y4_A445NgpPreco[0];
               A446NgpQtde = P000Y4_A446NgpQtde[0];
               A447NgpTotal = P000Y4_A447NgpTotal[0];
               A453NgpObs = P000Y4_A453NgpObs[0];
               A578NgpDel = P000Y4_A578NgpDel[0];
               A579NgpDelDataHora = P000Y4_A579NgpDelDataHora[0];
               n579NgpDelDataHora = P000Y4_n579NgpDelDataHora[0];
               A580NgpDelData = P000Y4_A580NgpDelData[0];
               n580NgpDelData = P000Y4_n580NgpDelData[0];
               A581NgpDelHora = P000Y4_A581NgpDelHora[0];
               n581NgpDelHora = P000Y4_n581NgpDelHora[0];
               A582NgpDelUsuId = P000Y4_A582NgpDelUsuId[0];
               n582NgpDelUsuId = P000Y4_n582NgpDelUsuId[0];
               A583NgpDelUsuNome = P000Y4_A583NgpDelUsuNome[0];
               n583NgpDelUsuNome = P000Y4_n583NgpDelUsuNome[0];
               A440NgpTppPrdCodigo = P000Y4_A440NgpTppPrdCodigo[0];
               A441NgpTppPrdNome = P000Y4_A441NgpTppPrdNome[0];
               A442NgpTppPrdTipoID = P000Y4_A442NgpTppPrdTipoID[0];
               A443NgpTppPrdAtivo = P000Y4_A443NgpTppPrdAtivo[0];
               A444NgpTpp1Preco = P000Y4_A444NgpTpp1Preco[0];
               Gxm3sdtnegociopj_item = new GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem(context);
               Gxm1sdtnegociopj.gxTpr_Item.Add(Gxm3sdtnegociopj_item, 0);
               Gxm3sdtnegociopj_item.gxTpr_Ngpitem = A435NgpItem;
               Gxm3sdtnegociopj_item.gxTpr_Ngpinsdata = A455NgpInsData;
               Gxm3sdtnegociopj_item.gxTpr_Ngpinshora = A456NgpInsHora;
               Gxm3sdtnegociopj_item.gxTpr_Ngpinsdatahora = A457NgpInsDataHora;
               Gxm3sdtnegociopj_item.gxTpr_Ngpinsusuid = A458NgpInsUsuID;
               Gxm3sdtnegociopj_item.gxTpr_Ngpinsusunome = A459NgpInsUsuNome;
               Gxm3sdtnegociopj_item.gxTpr_Ngptppid = A478NgpTppID;
               Gxm3sdtnegociopj_item.gxTpr_Ngptppprdid = A439NgpTppPrdID;
               Gxm3sdtnegociopj_item.gxTpr_Ngptppprdcodigo = A440NgpTppPrdCodigo;
               Gxm3sdtnegociopj_item.gxTpr_Ngptppprdnome = A441NgpTppPrdNome;
               Gxm3sdtnegociopj_item.gxTpr_Ngptppprdtipoid = A442NgpTppPrdTipoID;
               Gxm3sdtnegociopj_item.gxTpr_Ngptppprdativo = A443NgpTppPrdAtivo;
               Gxm3sdtnegociopj_item.gxTpr_Ngptpp1preco = A444NgpTpp1Preco;
               Gxm3sdtnegociopj_item.gxTpr_Ngppreco = A445NgpPreco;
               Gxm3sdtnegociopj_item.gxTpr_Ngpqtde = A446NgpQtde;
               Gxm3sdtnegociopj_item.gxTpr_Ngptotal = A447NgpTotal;
               Gxm3sdtnegociopj_item.gxTpr_Ngpobs = A453NgpObs;
               Gxm3sdtnegociopj_item.gxTpr_Ngpdel = A578NgpDel;
               Gxm3sdtnegociopj_item.gxTpr_Ngpdeldatahora = A579NgpDelDataHora;
               Gxm3sdtnegociopj_item.gxTpr_Ngpdeldata = A580NgpDelData;
               Gxm3sdtnegociopj_item.gxTpr_Ngpdelhora = A581NgpDelHora;
               Gxm3sdtnegociopj_item.gxTpr_Ngpdelusuid = A582NgpDelUsuId;
               Gxm3sdtnegociopj_item.gxTpr_Ngpdelusunome = A583NgpDelUsuNome;
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj = new GeneXus.Programs.core.SdtsdtNegocioPJ(context);
         scmdbuf = "";
         A345NegID = Guid.Empty;
         P000Y3_A345NegID = new Guid[] {Guid.Empty} ;
         P000Y3_A356NegCodigo = new long[1] ;
         P000Y3_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P000Y3_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         P000Y3_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000Y3_A349NegInsUsuID = new string[] {""} ;
         P000Y3_n349NegInsUsuID = new bool[] {false} ;
         P000Y3_A364NegInsUsuNome = new string[] {""} ;
         P000Y3_n364NegInsUsuNome = new bool[] {false} ;
         P000Y3_A350NegCliID = new Guid[] {Guid.Empty} ;
         P000Y3_A473NegCliMatricula = new long[1] ;
         P000Y3_A351NegCliNomeFamiliar = new string[] {""} ;
         P000Y3_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P000Y3_A353NegCpjNomFan = new string[] {""} ;
         P000Y3_A354NegCpjRazSocial = new string[] {""} ;
         P000Y3_A355NegCpjMatricula = new long[1] ;
         P000Y3_A357NegPjtID = new int[1] ;
         P000Y3_A358NegPjtSigla = new string[] {""} ;
         P000Y3_A359NegPjtNome = new string[] {""} ;
         P000Y3_A369NegCpjEndSeq = new short[1] ;
         P000Y3_A370NegCpjEndNome = new string[] {""} ;
         P000Y3_A642NegCpjEndCep = new int[1] ;
         P000Y3_A375NegCpjEndMunID = new int[1] ;
         P000Y3_A377NegCpjEndUFID = new short[1] ;
         P000Y3_A379NegCpjEndUFNome = new string[] {""} ;
         P000Y3_A360NegAgcID = new string[] {""} ;
         P000Y3_n360NegAgcID = new bool[] {false} ;
         P000Y3_A361NegAgcNome = new string[] {""} ;
         P000Y3_n361NegAgcNome = new bool[] {false} ;
         P000Y3_A362NegAssunto = new string[] {""} ;
         P000Y3_A363NegDescricao = new string[] {""} ;
         P000Y3_A380NegValorEstimado = new decimal[1] ;
         P000Y3_A385NegValorAtualizado = new decimal[1] ;
         P000Y3_A454NegUltItem = new int[1] ;
         P000Y3_n454NegUltItem = new bool[] {false} ;
         P000Y3_A572NegDel = new bool[] {false} ;
         P000Y3_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000Y3_n573NegDelDataHora = new bool[] {false} ;
         P000Y3_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         P000Y3_n574NegDelData = new bool[] {false} ;
         P000Y3_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         P000Y3_n575NegDelHora = new bool[] {false} ;
         P000Y3_A576NegDelUsuId = new string[] {""} ;
         P000Y3_n576NegDelUsuId = new bool[] {false} ;
         P000Y3_A577NegDelUsuNome = new string[] {""} ;
         P000Y3_n577NegDelUsuNome = new bool[] {false} ;
         P000Y3_A448NegPgpTotal = new decimal[1] ;
         P000Y3_n448NegPgpTotal = new bool[] {false} ;
         P000Y3_A373NegCpjEndComplem = new string[] {""} ;
         P000Y3_n373NegCpjEndComplem = new bool[] {false} ;
         P000Y3_A372NegCpjEndNumero = new string[] {""} ;
         P000Y3_A378NegCpjEndUFSigla = new string[] {""} ;
         P000Y3_A376NegCpjEndMunNome = new string[] {""} ;
         P000Y3_A643NegCpjEndCepFormat = new string[] {""} ;
         P000Y3_A374NegCpjEndBairro = new string[] {""} ;
         P000Y3_A371NegCpjEndEndereco = new string[] {""} ;
         A346NegInsData = DateTime.MinValue;
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A349NegInsUsuID = "";
         A364NegInsUsuNome = "";
         A350NegCliID = Guid.Empty;
         A351NegCliNomeFamiliar = "";
         A352NegCpjID = Guid.Empty;
         A353NegCpjNomFan = "";
         A354NegCpjRazSocial = "";
         A358NegPjtSigla = "";
         A359NegPjtNome = "";
         A370NegCpjEndNome = "";
         A379NegCpjEndUFNome = "";
         A360NegAgcID = "";
         A361NegAgcNome = "";
         A362NegAssunto = "";
         A363NegDescricao = "";
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         A574NegDelData = (DateTime)(DateTime.MinValue);
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         A576NegDelUsuId = "";
         A577NegDelUsuNome = "";
         A373NegCpjEndComplem = "";
         A372NegCpjEndNumero = "";
         A378NegCpjEndUFSigla = "";
         A376NegCpjEndMunNome = "";
         A643NegCpjEndCepFormat = "";
         A374NegCpjEndBairro = "";
         A371NegCpjEndEndereco = "";
         A641NegCpjEndCompleto = "";
         Gxm1sdtnegociopj = new GeneXus.Programs.core.SdtsdtNegocioPJ(context);
         P000Y4_A345NegID = new Guid[] {Guid.Empty} ;
         P000Y4_A435NgpItem = new int[1] ;
         P000Y4_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P000Y4_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P000Y4_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000Y4_A458NgpInsUsuID = new string[] {""} ;
         P000Y4_n458NgpInsUsuID = new bool[] {false} ;
         P000Y4_A459NgpInsUsuNome = new string[] {""} ;
         P000Y4_n459NgpInsUsuNome = new bool[] {false} ;
         P000Y4_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P000Y4_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P000Y4_A440NgpTppPrdCodigo = new string[] {""} ;
         P000Y4_A441NgpTppPrdNome = new string[] {""} ;
         P000Y4_A442NgpTppPrdTipoID = new int[1] ;
         P000Y4_A443NgpTppPrdAtivo = new bool[] {false} ;
         P000Y4_A444NgpTpp1Preco = new decimal[1] ;
         P000Y4_A445NgpPreco = new decimal[1] ;
         P000Y4_A446NgpQtde = new int[1] ;
         P000Y4_A447NgpTotal = new decimal[1] ;
         P000Y4_A453NgpObs = new string[] {""} ;
         P000Y4_A578NgpDel = new bool[] {false} ;
         P000Y4_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000Y4_n579NgpDelDataHora = new bool[] {false} ;
         P000Y4_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P000Y4_n580NgpDelData = new bool[] {false} ;
         P000Y4_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P000Y4_n581NgpDelHora = new bool[] {false} ;
         P000Y4_A582NgpDelUsuId = new string[] {""} ;
         P000Y4_n582NgpDelUsuId = new bool[] {false} ;
         P000Y4_A583NgpDelUsuNome = new string[] {""} ;
         P000Y4_n583NgpDelUsuNome = new bool[] {false} ;
         A455NgpInsData = DateTime.MinValue;
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         A458NgpInsUsuID = "";
         A459NgpInsUsuNome = "";
         A478NgpTppID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         A440NgpTppPrdCodigo = "";
         A441NgpTppPrdNome = "";
         A453NgpObs = "";
         A579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         A580NgpDelData = (DateTime)(DateTime.MinValue);
         A581NgpDelHora = (DateTime)(DateTime.MinValue);
         A582NgpDelUsuId = "";
         A583NgpDelUsuNome = "";
         Gxm3sdtnegociopj_item = new GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpnegociopjobterdados__default(),
            new Object[][] {
                new Object[] {
               P000Y3_A345NegID, P000Y3_A356NegCodigo, P000Y3_A346NegInsData, P000Y3_A347NegInsHora, P000Y3_A348NegInsDataHora, P000Y3_A349NegInsUsuID, P000Y3_n349NegInsUsuID, P000Y3_A364NegInsUsuNome, P000Y3_n364NegInsUsuNome, P000Y3_A350NegCliID,
               P000Y3_A473NegCliMatricula, P000Y3_A351NegCliNomeFamiliar, P000Y3_A352NegCpjID, P000Y3_A353NegCpjNomFan, P000Y3_A354NegCpjRazSocial, P000Y3_A355NegCpjMatricula, P000Y3_A357NegPjtID, P000Y3_A358NegPjtSigla, P000Y3_A359NegPjtNome, P000Y3_A369NegCpjEndSeq,
               P000Y3_A370NegCpjEndNome, P000Y3_A642NegCpjEndCep, P000Y3_A375NegCpjEndMunID, P000Y3_A377NegCpjEndUFID, P000Y3_A379NegCpjEndUFNome, P000Y3_A360NegAgcID, P000Y3_n360NegAgcID, P000Y3_A361NegAgcNome, P000Y3_n361NegAgcNome, P000Y3_A362NegAssunto,
               P000Y3_A363NegDescricao, P000Y3_A380NegValorEstimado, P000Y3_A385NegValorAtualizado, P000Y3_A454NegUltItem, P000Y3_n454NegUltItem, P000Y3_A572NegDel, P000Y3_A573NegDelDataHora, P000Y3_n573NegDelDataHora, P000Y3_A574NegDelData, P000Y3_n574NegDelData,
               P000Y3_A575NegDelHora, P000Y3_n575NegDelHora, P000Y3_A576NegDelUsuId, P000Y3_n576NegDelUsuId, P000Y3_A577NegDelUsuNome, P000Y3_n577NegDelUsuNome, P000Y3_A448NegPgpTotal, P000Y3_n448NegPgpTotal, P000Y3_A373NegCpjEndComplem, P000Y3_n373NegCpjEndComplem,
               P000Y3_A372NegCpjEndNumero, P000Y3_A378NegCpjEndUFSigla, P000Y3_A376NegCpjEndMunNome, P000Y3_A643NegCpjEndCepFormat, P000Y3_A374NegCpjEndBairro, P000Y3_A371NegCpjEndEndereco
               }
               , new Object[] {
               P000Y4_A345NegID, P000Y4_A435NgpItem, P000Y4_A455NgpInsData, P000Y4_A456NgpInsHora, P000Y4_A457NgpInsDataHora, P000Y4_A458NgpInsUsuID, P000Y4_n458NgpInsUsuID, P000Y4_A459NgpInsUsuNome, P000Y4_n459NgpInsUsuNome, P000Y4_A478NgpTppID,
               P000Y4_A439NgpTppPrdID, P000Y4_A440NgpTppPrdCodigo, P000Y4_A441NgpTppPrdNome, P000Y4_A442NgpTppPrdTipoID, P000Y4_A443NgpTppPrdAtivo, P000Y4_A444NgpTpp1Preco, P000Y4_A445NgpPreco, P000Y4_A446NgpQtde, P000Y4_A447NgpTotal, P000Y4_A453NgpObs,
               P000Y4_A578NgpDel, P000Y4_A579NgpDelDataHora, P000Y4_n579NgpDelDataHora, P000Y4_A580NgpDelData, P000Y4_n580NgpDelData, P000Y4_A581NgpDelHora, P000Y4_n581NgpDelHora, P000Y4_A582NgpDelUsuId, P000Y4_n582NgpDelUsuId, P000Y4_A583NgpDelUsuNome,
               P000Y4_n583NgpDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A369NegCpjEndSeq ;
      private short A377NegCpjEndUFID ;
      private int A357NegPjtID ;
      private int A642NegCpjEndCep ;
      private int A375NegCpjEndMunID ;
      private int A454NegUltItem ;
      private int A435NgpItem ;
      private int A442NgpTppPrdTipoID ;
      private int A446NgpQtde ;
      private long A356NegCodigo ;
      private long A473NegCliMatricula ;
      private long A355NegCpjMatricula ;
      private decimal A380NegValorEstimado ;
      private decimal A385NegValorAtualizado ;
      private decimal A448NegPgpTotal ;
      private decimal A444NgpTpp1Preco ;
      private decimal A445NgpPreco ;
      private decimal A447NgpTotal ;
      private string scmdbuf ;
      private string A349NegInsUsuID ;
      private string A360NegAgcID ;
      private string A576NegDelUsuId ;
      private string A458NgpInsUsuID ;
      private string A582NgpDelUsuId ;
      private DateTime A347NegInsHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime A573NegDelDataHora ;
      private DateTime A574NegDelData ;
      private DateTime A575NegDelHora ;
      private DateTime A456NgpInsHora ;
      private DateTime A457NgpInsDataHora ;
      private DateTime A579NgpDelDataHora ;
      private DateTime A580NgpDelData ;
      private DateTime A581NgpDelHora ;
      private DateTime A346NegInsData ;
      private DateTime A455NgpInsData ;
      private bool n349NegInsUsuID ;
      private bool n364NegInsUsuNome ;
      private bool n360NegAgcID ;
      private bool n361NegAgcNome ;
      private bool n454NegUltItem ;
      private bool A572NegDel ;
      private bool n573NegDelDataHora ;
      private bool n574NegDelData ;
      private bool n575NegDelHora ;
      private bool n576NegDelUsuId ;
      private bool n577NegDelUsuNome ;
      private bool n448NegPgpTotal ;
      private bool n373NegCpjEndComplem ;
      private bool n458NgpInsUsuID ;
      private bool n459NgpInsUsuNome ;
      private bool A443NgpTppPrdAtivo ;
      private bool A578NgpDel ;
      private bool n579NgpDelDataHora ;
      private bool n580NgpDelData ;
      private bool n581NgpDelHora ;
      private bool n582NgpDelUsuId ;
      private bool n583NgpDelUsuNome ;
      private string A363NegDescricao ;
      private string A364NegInsUsuNome ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A354NegCpjRazSocial ;
      private string A358NegPjtSigla ;
      private string A359NegPjtNome ;
      private string A370NegCpjEndNome ;
      private string A379NegCpjEndUFNome ;
      private string A361NegAgcNome ;
      private string A362NegAssunto ;
      private string A577NegDelUsuNome ;
      private string A373NegCpjEndComplem ;
      private string A372NegCpjEndNumero ;
      private string A378NegCpjEndUFSigla ;
      private string A376NegCpjEndMunNome ;
      private string A643NegCpjEndCepFormat ;
      private string A374NegCpjEndBairro ;
      private string A371NegCpjEndEndereco ;
      private string A641NegCpjEndCompleto ;
      private string A459NgpInsUsuNome ;
      private string A440NgpTppPrdCodigo ;
      private string A441NgpTppPrdNome ;
      private string A453NgpObs ;
      private string A583NgpDelUsuNome ;
      private Guid AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj_gxTpr_Negid ;
      private Guid A345NegID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A478NgpTppID ;
      private Guid A439NgpTppPrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000Y3_A345NegID ;
      private long[] P000Y3_A356NegCodigo ;
      private DateTime[] P000Y3_A346NegInsData ;
      private DateTime[] P000Y3_A347NegInsHora ;
      private DateTime[] P000Y3_A348NegInsDataHora ;
      private string[] P000Y3_A349NegInsUsuID ;
      private bool[] P000Y3_n349NegInsUsuID ;
      private string[] P000Y3_A364NegInsUsuNome ;
      private bool[] P000Y3_n364NegInsUsuNome ;
      private Guid[] P000Y3_A350NegCliID ;
      private long[] P000Y3_A473NegCliMatricula ;
      private string[] P000Y3_A351NegCliNomeFamiliar ;
      private Guid[] P000Y3_A352NegCpjID ;
      private string[] P000Y3_A353NegCpjNomFan ;
      private string[] P000Y3_A354NegCpjRazSocial ;
      private long[] P000Y3_A355NegCpjMatricula ;
      private int[] P000Y3_A357NegPjtID ;
      private string[] P000Y3_A358NegPjtSigla ;
      private string[] P000Y3_A359NegPjtNome ;
      private short[] P000Y3_A369NegCpjEndSeq ;
      private string[] P000Y3_A370NegCpjEndNome ;
      private int[] P000Y3_A642NegCpjEndCep ;
      private int[] P000Y3_A375NegCpjEndMunID ;
      private short[] P000Y3_A377NegCpjEndUFID ;
      private string[] P000Y3_A379NegCpjEndUFNome ;
      private string[] P000Y3_A360NegAgcID ;
      private bool[] P000Y3_n360NegAgcID ;
      private string[] P000Y3_A361NegAgcNome ;
      private bool[] P000Y3_n361NegAgcNome ;
      private string[] P000Y3_A362NegAssunto ;
      private string[] P000Y3_A363NegDescricao ;
      private decimal[] P000Y3_A380NegValorEstimado ;
      private decimal[] P000Y3_A385NegValorAtualizado ;
      private int[] P000Y3_A454NegUltItem ;
      private bool[] P000Y3_n454NegUltItem ;
      private bool[] P000Y3_A572NegDel ;
      private DateTime[] P000Y3_A573NegDelDataHora ;
      private bool[] P000Y3_n573NegDelDataHora ;
      private DateTime[] P000Y3_A574NegDelData ;
      private bool[] P000Y3_n574NegDelData ;
      private DateTime[] P000Y3_A575NegDelHora ;
      private bool[] P000Y3_n575NegDelHora ;
      private string[] P000Y3_A576NegDelUsuId ;
      private bool[] P000Y3_n576NegDelUsuId ;
      private string[] P000Y3_A577NegDelUsuNome ;
      private bool[] P000Y3_n577NegDelUsuNome ;
      private decimal[] P000Y3_A448NegPgpTotal ;
      private bool[] P000Y3_n448NegPgpTotal ;
      private string[] P000Y3_A373NegCpjEndComplem ;
      private bool[] P000Y3_n373NegCpjEndComplem ;
      private string[] P000Y3_A372NegCpjEndNumero ;
      private string[] P000Y3_A378NegCpjEndUFSigla ;
      private string[] P000Y3_A376NegCpjEndMunNome ;
      private string[] P000Y3_A643NegCpjEndCepFormat ;
      private string[] P000Y3_A374NegCpjEndBairro ;
      private string[] P000Y3_A371NegCpjEndEndereco ;
      private Guid[] P000Y4_A345NegID ;
      private int[] P000Y4_A435NgpItem ;
      private DateTime[] P000Y4_A455NgpInsData ;
      private DateTime[] P000Y4_A456NgpInsHora ;
      private DateTime[] P000Y4_A457NgpInsDataHora ;
      private string[] P000Y4_A458NgpInsUsuID ;
      private bool[] P000Y4_n458NgpInsUsuID ;
      private string[] P000Y4_A459NgpInsUsuNome ;
      private bool[] P000Y4_n459NgpInsUsuNome ;
      private Guid[] P000Y4_A478NgpTppID ;
      private Guid[] P000Y4_A439NgpTppPrdID ;
      private string[] P000Y4_A440NgpTppPrdCodigo ;
      private string[] P000Y4_A441NgpTppPrdNome ;
      private int[] P000Y4_A442NgpTppPrdTipoID ;
      private bool[] P000Y4_A443NgpTppPrdAtivo ;
      private decimal[] P000Y4_A444NgpTpp1Preco ;
      private decimal[] P000Y4_A445NgpPreco ;
      private int[] P000Y4_A446NgpQtde ;
      private decimal[] P000Y4_A447NgpTotal ;
      private string[] P000Y4_A453NgpObs ;
      private bool[] P000Y4_A578NgpDel ;
      private DateTime[] P000Y4_A579NgpDelDataHora ;
      private bool[] P000Y4_n579NgpDelDataHora ;
      private DateTime[] P000Y4_A580NgpDelData ;
      private bool[] P000Y4_n580NgpDelData ;
      private DateTime[] P000Y4_A581NgpDelHora ;
      private bool[] P000Y4_n581NgpDelHora ;
      private string[] P000Y4_A582NgpDelUsuId ;
      private bool[] P000Y4_n582NgpDelUsuId ;
      private string[] P000Y4_A583NgpDelUsuNome ;
      private bool[] P000Y4_n583NgpDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtNegocioPJ> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ AV5sdtNegocioPJ ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ Gxm1sdtnegociopj ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem Gxm3sdtnegociopj_item ;
   }

   public class dpnegociopjobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000Y3( IGxContext context ,
                                             Guid AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj_gxTpr_Negid ,
                                             Guid A345NegID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NegID, T1.NegCodigo, T1.NegInsData, T1.NegInsHora, T1.NegInsDataHora, T1.NegInsUsuID, T1.NegInsUsuNome, T1.NegCliID AS NegCliID, T3.CliMatricula AS NegCliMatricula, T1.NegCliNomeFamiliar AS NegCliNomeFamiliar, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T4.CpjTipoId AS NegPjtID, T5.PjtSigla AS NegPjtSigla, T1.NegPjtNome AS NegPjtNome, T1.NegCpjEndSeq AS NegCpjEndSeq, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndCep AS NegCpjEndCep, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFNome AS NegCpjEndUFNome, T1.NegAgcID, T1.NegAgcNome, T1.NegAssunto, T1.NegDescricao, T1.NegValorEstimado, T1.NegValorAtualizado, T1.NegUltItem, T1.NegDel, T1.NegDelDataHora, T1.NegDelData, T1.NegDelHora, T1.NegDelUsuId, T1.NegDelUsuNome, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndCepFormat AS NegCpjEndCepFormat, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndEndereco AS NegCpjEndEndereco FROM (((((tb_negociopj T1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE T1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = T1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = T1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = T1.NegCliID AND T4.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = T1.NegCliID AND T6.CpjID = T1.NegCpjID AND T6.CpjEndSeq = T1.NegCpjEndSeq)";
         if ( ! (Guid.Empty==AV10Core_dsnegociopjfiltrogeral_4_sdtnegociopj_gxTpr_Negid) )
         {
            AddWhere(sWhereString, "(T1.NegID = :AV10Core_1Negid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NegID";
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
                     return conditional_P000Y3(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000Y4;
          prmP000Y4 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP000Y3;
          prmP000Y3 = new Object[] {
          new ParDef("AV10Core_1Negid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000Y4", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y4,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((string[]) buf[17])[0] = rslt.getVarchar(16);
                ((string[]) buf[18])[0] = rslt.getVarchar(17);
                ((short[]) buf[19])[0] = rslt.getShort(18);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((int[]) buf[21])[0] = rslt.getInt(20);
                ((int[]) buf[22])[0] = rslt.getInt(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getString(24, 40);
                ((bool[]) buf[26])[0] = rslt.wasNull(24);
                ((string[]) buf[27])[0] = rslt.getVarchar(25);
                ((bool[]) buf[28])[0] = rslt.wasNull(25);
                ((string[]) buf[29])[0] = rslt.getVarchar(26);
                ((string[]) buf[30])[0] = rslt.getLongVarchar(27);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(29);
                ((int[]) buf[33])[0] = rslt.getInt(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((bool[]) buf[35])[0] = rslt.getBool(31);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(32, true);
                ((bool[]) buf[37])[0] = rslt.wasNull(32);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(33);
                ((bool[]) buf[39])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(34);
                ((bool[]) buf[41])[0] = rslt.wasNull(34);
                ((string[]) buf[42])[0] = rslt.getString(35, 40);
                ((bool[]) buf[43])[0] = rslt.wasNull(35);
                ((string[]) buf[44])[0] = rslt.getVarchar(36);
                ((bool[]) buf[45])[0] = rslt.wasNull(36);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(37);
                ((bool[]) buf[47])[0] = rslt.wasNull(37);
                ((string[]) buf[48])[0] = rslt.getVarchar(38);
                ((bool[]) buf[49])[0] = rslt.wasNull(38);
                ((string[]) buf[50])[0] = rslt.getVarchar(39);
                ((string[]) buf[51])[0] = rslt.getVarchar(40);
                ((string[]) buf[52])[0] = rslt.getVarchar(41);
                ((string[]) buf[53])[0] = rslt.getVarchar(42);
                ((string[]) buf[54])[0] = rslt.getVarchar(43);
                ((string[]) buf[55])[0] = rslt.getVarchar(44);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((bool[]) buf[20])[0] = rslt.getBool(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(20, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(23);
                ((string[]) buf[29])[0] = rslt.getVarchar(24);
                ((bool[]) buf[30])[0] = rslt.wasNull(24);
                return;
       }
    }

 }

}
