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
   public class dptabeladeprecoobterdados : GXProcedure
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

      public dptabeladeprecoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dptabeladeprecoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> aP1_Gxm2rootcol )
      {
         this.AV5sdtTabelaDePreco = aP0_sdtTabelaDePreco;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco>( context, "sdtTabelaDePreco", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> executeUdp( GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco )
      {
         execute(aP0_sdtTabelaDePreco, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> aP1_Gxm2rootcol )
      {
         dptabeladeprecoobterdados objdptabeladeprecoobterdados;
         objdptabeladeprecoobterdados = new dptabeladeprecoobterdados();
         objdptabeladeprecoobterdados.AV5sdtTabelaDePreco = aP0_sdtTabelaDePreco;
         objdptabeladeprecoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco>( context, "sdtTabelaDePreco", "agl_tresorygroup") ;
         objdptabeladeprecoobterdados.context.SetSubmitInitialConfig(context);
         objdptabeladeprecoobterdados.initialize();
         Submit( executePrivateCatch,objdptabeladeprecoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dptabeladeprecoobterdados)stateInfo).executePrivate();
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
         AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco = AV5sdtTabelaDePreco;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco.gxTpr_Tppid ,
                                              A235TppID } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P000V2 */
         pr_default.execute(0, new Object[] {AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco.gxTpr_Tppid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A235TppID = P000V2_A235TppID[0];
            A236TppCodigo = P000V2_A236TppCodigo[0];
            A237TppNome = P000V2_A237TppNome[0];
            A238TppInsData = P000V2_A238TppInsData[0];
            A239TppInsHora = P000V2_A239TppInsHora[0];
            A240TppInsDataHora = P000V2_A240TppInsDataHora[0];
            A241TppInsUsuID = P000V2_A241TppInsUsuID[0];
            n241TppInsUsuID = P000V2_n241TppInsUsuID[0];
            A433TppInsUsuNome = P000V2_A433TppInsUsuNome[0];
            n433TppInsUsuNome = P000V2_n433TppInsUsuNome[0];
            A242TppUpdData = P000V2_A242TppUpdData[0];
            n242TppUpdData = P000V2_n242TppUpdData[0];
            A243TppUpdHora = P000V2_A243TppUpdHora[0];
            n243TppUpdHora = P000V2_n243TppUpdHora[0];
            A244TppUpdDataHora = P000V2_A244TppUpdDataHora[0];
            n244TppUpdDataHora = P000V2_n244TppUpdDataHora[0];
            A245TppUpdUsuID = P000V2_A245TppUpdUsuID[0];
            n245TppUpdUsuID = P000V2_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = P000V2_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = P000V2_n434TppUpdUsuNome[0];
            A246TppAtivo = P000V2_A246TppAtivo[0];
            n246TppAtivo = P000V2_n246TppAtivo[0];
            A602TppDel = P000V2_A602TppDel[0];
            A603TppDelDataHora = P000V2_A603TppDelDataHora[0];
            n603TppDelDataHora = P000V2_n603TppDelDataHora[0];
            A604TppDelData = P000V2_A604TppDelData[0];
            n604TppDelData = P000V2_n604TppDelData[0];
            A605TppDelHora = P000V2_A605TppDelHora[0];
            n605TppDelHora = P000V2_n605TppDelHora[0];
            A606TppDelUsuId = P000V2_A606TppDelUsuId[0];
            n606TppDelUsuId = P000V2_n606TppDelUsuId[0];
            A607TppDelUsuNome = P000V2_A607TppDelUsuNome[0];
            n607TppDelUsuNome = P000V2_n607TppDelUsuNome[0];
            Gxm1sdttabeladepreco = new GeneXus.Programs.core.SdtsdtTabelaDePreco(context);
            Gxm2rootcol.Add(Gxm1sdttabeladepreco, 0);
            Gxm1sdttabeladepreco.gxTpr_Tppid = A235TppID;
            Gxm1sdttabeladepreco.gxTpr_Tppcodigo = A236TppCodigo;
            Gxm1sdttabeladepreco.gxTpr_Tppnome = A237TppNome;
            Gxm1sdttabeladepreco.gxTpr_Tppinsdata = A238TppInsData;
            Gxm1sdttabeladepreco.gxTpr_Tppinshora = A239TppInsHora;
            Gxm1sdttabeladepreco.gxTpr_Tppinsdatahora = A240TppInsDataHora;
            Gxm1sdttabeladepreco.gxTpr_Tppinsusuid = A241TppInsUsuID;
            Gxm1sdttabeladepreco.gxTpr_Tppinsusunome = A433TppInsUsuNome;
            Gxm1sdttabeladepreco.gxTpr_Tppupddata = A242TppUpdData;
            Gxm1sdttabeladepreco.gxTpr_Tppupdhora = A243TppUpdHora;
            Gxm1sdttabeladepreco.gxTpr_Tppupddatahora = A244TppUpdDataHora;
            Gxm1sdttabeladepreco.gxTpr_Tppupdusuid = A245TppUpdUsuID;
            Gxm1sdttabeladepreco.gxTpr_Tppupdusunome = A434TppUpdUsuNome;
            Gxm1sdttabeladepreco.gxTpr_Tppativo = A246TppAtivo;
            Gxm1sdttabeladepreco.gxTpr_Tppdel = A602TppDel;
            Gxm1sdttabeladepreco.gxTpr_Tppdeldatahora = A603TppDelDataHora;
            Gxm1sdttabeladepreco.gxTpr_Tppdeldata = A604TppDelData;
            Gxm1sdttabeladepreco.gxTpr_Tppdelhora = A605TppDelHora;
            Gxm1sdttabeladepreco.gxTpr_Tppdelusuid = A606TppDelUsuId;
            Gxm1sdttabeladepreco.gxTpr_Tppdelusunome = A607TppDelUsuNome;
            /* Using cursor P000V3 */
            pr_default.execute(1, new Object[] {A235TppID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A220PrdID = P000V3_A220PrdID[0];
               A221PrdCodigo = P000V3_A221PrdCodigo[0];
               A222PrdNome = P000V3_A222PrdNome[0];
               A232PrdTipoID = P000V3_A232PrdTipoID[0];
               A231PrdAtivo = P000V3_A231PrdAtivo[0];
               A247Tpp1Preco = P000V3_A247Tpp1Preco[0];
               A608Tpp1Del = P000V3_A608Tpp1Del[0];
               A609Tpp1DelDataHora = P000V3_A609Tpp1DelDataHora[0];
               n609Tpp1DelDataHora = P000V3_n609Tpp1DelDataHora[0];
               A610Tpp1DelData = P000V3_A610Tpp1DelData[0];
               n610Tpp1DelData = P000V3_n610Tpp1DelData[0];
               A611Tpp1DelHora = P000V3_A611Tpp1DelHora[0];
               n611Tpp1DelHora = P000V3_n611Tpp1DelHora[0];
               A612Tpp1DelUsuId = P000V3_A612Tpp1DelUsuId[0];
               n612Tpp1DelUsuId = P000V3_n612Tpp1DelUsuId[0];
               A613Tpp1DelUsuNome = P000V3_A613Tpp1DelUsuNome[0];
               n613Tpp1DelUsuNome = P000V3_n613Tpp1DelUsuNome[0];
               A231PrdAtivo = P000V3_A231PrdAtivo[0];
               Gxm3sdttabeladepreco_produto = new GeneXus.Programs.core.SdtsdtTabelaDePreco_ProdutoItem(context);
               Gxm1sdttabeladepreco.gxTpr_Produto.Add(Gxm3sdttabeladepreco_produto, 0);
               Gxm3sdttabeladepreco_produto.gxTpr_Prdid = A220PrdID;
               Gxm3sdttabeladepreco_produto.gxTpr_Prdcodigo = A221PrdCodigo;
               Gxm3sdttabeladepreco_produto.gxTpr_Prdnome = A222PrdNome;
               Gxm3sdttabeladepreco_produto.gxTpr_Prdtipoid = A232PrdTipoID;
               Gxm3sdttabeladepreco_produto.gxTpr_Prdativo = A231PrdAtivo;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1preco = A247Tpp1Preco;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1del = A608Tpp1Del;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1deldatahora = A609Tpp1DelDataHora;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1deldata = A610Tpp1DelData;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1delhora = A611Tpp1DelHora;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1delusuid = A612Tpp1DelUsuId;
               Gxm3sdttabeladepreco_produto.gxTpr_Tpp1delusunome = A613Tpp1DelUsuNome;
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
         AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco = new GeneXus.Programs.core.SdtsdtTabelaDePreco(context);
         scmdbuf = "";
         A235TppID = Guid.Empty;
         P000V2_A235TppID = new Guid[] {Guid.Empty} ;
         P000V2_A236TppCodigo = new string[] {""} ;
         P000V2_A237TppNome = new string[] {""} ;
         P000V2_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P000V2_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         P000V2_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000V2_A241TppInsUsuID = new string[] {""} ;
         P000V2_n241TppInsUsuID = new bool[] {false} ;
         P000V2_A433TppInsUsuNome = new string[] {""} ;
         P000V2_n433TppInsUsuNome = new bool[] {false} ;
         P000V2_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         P000V2_n242TppUpdData = new bool[] {false} ;
         P000V2_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         P000V2_n243TppUpdHora = new bool[] {false} ;
         P000V2_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P000V2_n244TppUpdDataHora = new bool[] {false} ;
         P000V2_A245TppUpdUsuID = new string[] {""} ;
         P000V2_n245TppUpdUsuID = new bool[] {false} ;
         P000V2_A434TppUpdUsuNome = new string[] {""} ;
         P000V2_n434TppUpdUsuNome = new bool[] {false} ;
         P000V2_A246TppAtivo = new bool[] {false} ;
         P000V2_n246TppAtivo = new bool[] {false} ;
         P000V2_A602TppDel = new bool[] {false} ;
         P000V2_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000V2_n603TppDelDataHora = new bool[] {false} ;
         P000V2_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         P000V2_n604TppDelData = new bool[] {false} ;
         P000V2_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         P000V2_n605TppDelHora = new bool[] {false} ;
         P000V2_A606TppDelUsuId = new string[] {""} ;
         P000V2_n606TppDelUsuId = new bool[] {false} ;
         P000V2_A607TppDelUsuNome = new string[] {""} ;
         P000V2_n607TppDelUsuNome = new bool[] {false} ;
         A236TppCodigo = "";
         A237TppNome = "";
         A238TppInsData = DateTime.MinValue;
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A241TppInsUsuID = "";
         A433TppInsUsuNome = "";
         A242TppUpdData = DateTime.MinValue;
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         A245TppUpdUsuID = "";
         A434TppUpdUsuNome = "";
         A603TppDelDataHora = (DateTime)(DateTime.MinValue);
         A604TppDelData = (DateTime)(DateTime.MinValue);
         A605TppDelHora = (DateTime)(DateTime.MinValue);
         A606TppDelUsuId = "";
         A607TppDelUsuNome = "";
         Gxm1sdttabeladepreco = new GeneXus.Programs.core.SdtsdtTabelaDePreco(context);
         P000V3_A235TppID = new Guid[] {Guid.Empty} ;
         P000V3_A220PrdID = new Guid[] {Guid.Empty} ;
         P000V3_A221PrdCodigo = new string[] {""} ;
         P000V3_A222PrdNome = new string[] {""} ;
         P000V3_A232PrdTipoID = new int[1] ;
         P000V3_A231PrdAtivo = new bool[] {false} ;
         P000V3_A247Tpp1Preco = new decimal[1] ;
         P000V3_A608Tpp1Del = new bool[] {false} ;
         P000V3_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000V3_n609Tpp1DelDataHora = new bool[] {false} ;
         P000V3_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         P000V3_n610Tpp1DelData = new bool[] {false} ;
         P000V3_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         P000V3_n611Tpp1DelHora = new bool[] {false} ;
         P000V3_A612Tpp1DelUsuId = new string[] {""} ;
         P000V3_n612Tpp1DelUsuId = new bool[] {false} ;
         P000V3_A613Tpp1DelUsuNome = new string[] {""} ;
         P000V3_n613Tpp1DelUsuNome = new bool[] {false} ;
         A220PrdID = Guid.Empty;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         A610Tpp1DelData = (DateTime)(DateTime.MinValue);
         A611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         A612Tpp1DelUsuId = "";
         A613Tpp1DelUsuNome = "";
         Gxm3sdttabeladepreco_produto = new GeneXus.Programs.core.SdtsdtTabelaDePreco_ProdutoItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dptabeladeprecoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000V2_A235TppID, P000V2_A236TppCodigo, P000V2_A237TppNome, P000V2_A238TppInsData, P000V2_A239TppInsHora, P000V2_A240TppInsDataHora, P000V2_A241TppInsUsuID, P000V2_n241TppInsUsuID, P000V2_A433TppInsUsuNome, P000V2_n433TppInsUsuNome,
               P000V2_A242TppUpdData, P000V2_n242TppUpdData, P000V2_A243TppUpdHora, P000V2_n243TppUpdHora, P000V2_A244TppUpdDataHora, P000V2_n244TppUpdDataHora, P000V2_A245TppUpdUsuID, P000V2_n245TppUpdUsuID, P000V2_A434TppUpdUsuNome, P000V2_n434TppUpdUsuNome,
               P000V2_A246TppAtivo, P000V2_n246TppAtivo, P000V2_A602TppDel, P000V2_A603TppDelDataHora, P000V2_n603TppDelDataHora, P000V2_A604TppDelData, P000V2_n604TppDelData, P000V2_A605TppDelHora, P000V2_n605TppDelHora, P000V2_A606TppDelUsuId,
               P000V2_n606TppDelUsuId, P000V2_A607TppDelUsuNome, P000V2_n607TppDelUsuNome
               }
               , new Object[] {
               P000V3_A235TppID, P000V3_A220PrdID, P000V3_A221PrdCodigo, P000V3_A222PrdNome, P000V3_A232PrdTipoID, P000V3_A231PrdAtivo, P000V3_A247Tpp1Preco, P000V3_A608Tpp1Del, P000V3_A609Tpp1DelDataHora, P000V3_n609Tpp1DelDataHora,
               P000V3_A610Tpp1DelData, P000V3_n610Tpp1DelData, P000V3_A611Tpp1DelHora, P000V3_n611Tpp1DelHora, P000V3_A612Tpp1DelUsuId, P000V3_n612Tpp1DelUsuId, P000V3_A613Tpp1DelUsuNome, P000V3_n613Tpp1DelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private decimal A247Tpp1Preco ;
      private string scmdbuf ;
      private string A241TppInsUsuID ;
      private string A245TppUpdUsuID ;
      private string A606TppDelUsuId ;
      private string A612Tpp1DelUsuId ;
      private DateTime A239TppInsHora ;
      private DateTime A240TppInsDataHora ;
      private DateTime A243TppUpdHora ;
      private DateTime A244TppUpdDataHora ;
      private DateTime A603TppDelDataHora ;
      private DateTime A604TppDelData ;
      private DateTime A605TppDelHora ;
      private DateTime A609Tpp1DelDataHora ;
      private DateTime A610Tpp1DelData ;
      private DateTime A611Tpp1DelHora ;
      private DateTime A238TppInsData ;
      private DateTime A242TppUpdData ;
      private bool n241TppInsUsuID ;
      private bool n433TppInsUsuNome ;
      private bool n242TppUpdData ;
      private bool n243TppUpdHora ;
      private bool n244TppUpdDataHora ;
      private bool n245TppUpdUsuID ;
      private bool n434TppUpdUsuNome ;
      private bool A246TppAtivo ;
      private bool n246TppAtivo ;
      private bool A602TppDel ;
      private bool n603TppDelDataHora ;
      private bool n604TppDelData ;
      private bool n605TppDelHora ;
      private bool n606TppDelUsuId ;
      private bool n607TppDelUsuNome ;
      private bool A231PrdAtivo ;
      private bool A608Tpp1Del ;
      private bool n609Tpp1DelDataHora ;
      private bool n610Tpp1DelData ;
      private bool n611Tpp1DelHora ;
      private bool n612Tpp1DelUsuId ;
      private bool n613Tpp1DelUsuNome ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string A433TppInsUsuNome ;
      private string A434TppUpdUsuNome ;
      private string A607TppDelUsuNome ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A613Tpp1DelUsuNome ;
      private Guid AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco_gxTpr_Tppid ;
      private Guid A235TppID ;
      private Guid A220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000V2_A235TppID ;
      private string[] P000V2_A236TppCodigo ;
      private string[] P000V2_A237TppNome ;
      private DateTime[] P000V2_A238TppInsData ;
      private DateTime[] P000V2_A239TppInsHora ;
      private DateTime[] P000V2_A240TppInsDataHora ;
      private string[] P000V2_A241TppInsUsuID ;
      private bool[] P000V2_n241TppInsUsuID ;
      private string[] P000V2_A433TppInsUsuNome ;
      private bool[] P000V2_n433TppInsUsuNome ;
      private DateTime[] P000V2_A242TppUpdData ;
      private bool[] P000V2_n242TppUpdData ;
      private DateTime[] P000V2_A243TppUpdHora ;
      private bool[] P000V2_n243TppUpdHora ;
      private DateTime[] P000V2_A244TppUpdDataHora ;
      private bool[] P000V2_n244TppUpdDataHora ;
      private string[] P000V2_A245TppUpdUsuID ;
      private bool[] P000V2_n245TppUpdUsuID ;
      private string[] P000V2_A434TppUpdUsuNome ;
      private bool[] P000V2_n434TppUpdUsuNome ;
      private bool[] P000V2_A246TppAtivo ;
      private bool[] P000V2_n246TppAtivo ;
      private bool[] P000V2_A602TppDel ;
      private DateTime[] P000V2_A603TppDelDataHora ;
      private bool[] P000V2_n603TppDelDataHora ;
      private DateTime[] P000V2_A604TppDelData ;
      private bool[] P000V2_n604TppDelData ;
      private DateTime[] P000V2_A605TppDelHora ;
      private bool[] P000V2_n605TppDelHora ;
      private string[] P000V2_A606TppDelUsuId ;
      private bool[] P000V2_n606TppDelUsuId ;
      private string[] P000V2_A607TppDelUsuNome ;
      private bool[] P000V2_n607TppDelUsuNome ;
      private Guid[] P000V3_A235TppID ;
      private Guid[] P000V3_A220PrdID ;
      private string[] P000V3_A221PrdCodigo ;
      private string[] P000V3_A222PrdNome ;
      private int[] P000V3_A232PrdTipoID ;
      private bool[] P000V3_A231PrdAtivo ;
      private decimal[] P000V3_A247Tpp1Preco ;
      private bool[] P000V3_A608Tpp1Del ;
      private DateTime[] P000V3_A609Tpp1DelDataHora ;
      private bool[] P000V3_n609Tpp1DelDataHora ;
      private DateTime[] P000V3_A610Tpp1DelData ;
      private bool[] P000V3_n610Tpp1DelData ;
      private DateTime[] P000V3_A611Tpp1DelHora ;
      private bool[] P000V3_n611Tpp1DelHora ;
      private string[] P000V3_A612Tpp1DelUsuId ;
      private bool[] P000V3_n612Tpp1DelUsuId ;
      private string[] P000V3_A613Tpp1DelUsuNome ;
      private bool[] P000V3_n613Tpp1DelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtTabelaDePreco> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtTabelaDePreco AV5sdtTabelaDePreco ;
      private GeneXus.Programs.core.SdtsdtTabelaDePreco AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco ;
      private GeneXus.Programs.core.SdtsdtTabelaDePreco Gxm1sdttabeladepreco ;
      private GeneXus.Programs.core.SdtsdtTabelaDePreco_ProdutoItem Gxm3sdttabeladepreco_produto ;
   }

   public class dptabeladeprecoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000V2( IGxContext context ,
                                             Guid AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco_gxTpr_Tppid ,
                                             Guid A235TppID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TppID, TppCodigo, TppNome, TppInsData, TppInsHora, TppInsDataHora, TppInsUsuID, TppInsUsuNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome FROM tb_tabeladepreco";
         if ( ! (Guid.Empty==AV10Core_dstabeladeprecofiltrogeral_4_sdttabeladepreco_gxTpr_Tppid) )
         {
            AddWhere(sWhereString, "(TppID = :AV10Core_1Tppid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TppID";
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
                     return conditional_P000V2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
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
          Object[] prmP000V3;
          prmP000V3 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP000V2;
          prmP000V2 = new Object[] {
          new ParDef("AV10Core_1Tppid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000V3", "SELECT T1.TppID, T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID ORDER BY T1.TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000V3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11, true);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((bool[]) buf[20])[0] = rslt.getBool(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((bool[]) buf[22])[0] = rslt.getBool(15);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16, true);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((string[]) buf[29])[0] = rslt.getString(19, 40);
                ((bool[]) buf[30])[0] = rslt.wasNull(19);
                ((string[]) buf[31])[0] = rslt.getVarchar(20);
                ((bool[]) buf[32])[0] = rslt.wasNull(20);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
