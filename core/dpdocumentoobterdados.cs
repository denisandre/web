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
   public class dpdocumentoobterdados : GXProcedure
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

      public dpdocumentoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpdocumentoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> aP1_Gxm2rootcol )
      {
         this.AV5sdtDocumento = aP0_sdtDocumento;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento>( context, "sdtDocumento", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> executeUdp( GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento )
      {
         execute(aP0_sdtDocumento, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> aP1_Gxm2rootcol )
      {
         dpdocumentoobterdados objdpdocumentoobterdados;
         objdpdocumentoobterdados = new dpdocumentoobterdados();
         objdpdocumentoobterdados.AV5sdtDocumento = aP0_sdtDocumento;
         objdpdocumentoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento>( context, "sdtDocumento", "agl_tresorygroup") ;
         objdpdocumentoobterdados.context.SetSubmitInitialConfig(context);
         objdpdocumentoobterdados.initialize();
         Submit( executePrivateCatch,objdpdocumentoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpdocumentoobterdados)stateInfo).executePrivate();
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
         AV9Core_dsdocumentofiltrogeral_3_sdtdocumento = AV5sdtDocumento;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsdocumentofiltrogeral_3_sdtdocumento.gxTpr_Docid ,
                                              A289DocID } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P000N2 */
         pr_default.execute(0, new Object[] {AV9Core_dsdocumentofiltrogeral_3_sdtdocumento.gxTpr_Docid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A289DocID = P000N2_A289DocID[0];
            A325DocVersao = P000N2_A325DocVersao[0];
            A326DocVersaoIDPai = P000N2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P000N2_n326DocVersaoIDPai[0];
            A327DocVersaoNomePai = P000N2_A327DocVersaoNomePai[0];
            A290DocOrigem = P000N2_A290DocOrigem[0];
            A291DocOrigemID = P000N2_A291DocOrigemID[0];
            A292DocInsData = P000N2_A292DocInsData[0];
            A293DocInsHora = P000N2_A293DocInsHora[0];
            A294DocInsDataHora = P000N2_A294DocInsDataHora[0];
            A295DocInsUsuID = P000N2_A295DocInsUsuID[0];
            n295DocInsUsuID = P000N2_n295DocInsUsuID[0];
            A296DocUpdData = P000N2_A296DocUpdData[0];
            n296DocUpdData = P000N2_n296DocUpdData[0];
            A297DocUpdHora = P000N2_A297DocUpdHora[0];
            n297DocUpdHora = P000N2_n297DocUpdHora[0];
            A298DocUpdDataHora = P000N2_A298DocUpdDataHora[0];
            n298DocUpdDataHora = P000N2_n298DocUpdDataHora[0];
            A299DocUpdUsuID = P000N2_A299DocUpdUsuID[0];
            n299DocUpdUsuID = P000N2_n299DocUpdUsuID[0];
            A300DocDel = P000N2_A300DocDel[0];
            A303DocDelDataHora = P000N2_A303DocDelDataHora[0];
            n303DocDelDataHora = P000N2_n303DocDelDataHora[0];
            A301DocDelData = P000N2_A301DocDelData[0];
            n301DocDelData = P000N2_n301DocDelData[0];
            A302DocDelHora = P000N2_A302DocDelHora[0];
            n302DocDelHora = P000N2_n302DocDelHora[0];
            A304DocDelUsuID = P000N2_A304DocDelUsuID[0];
            n304DocDelUsuID = P000N2_n304DocDelUsuID[0];
            A510DocDelUsuNome = P000N2_A510DocDelUsuNome[0];
            n510DocDelUsuNome = P000N2_n510DocDelUsuNome[0];
            A305DocNome = P000N2_A305DocNome[0];
            A146DocTipoID = P000N2_A146DocTipoID[0];
            A147DocTipoSigla = P000N2_A147DocTipoSigla[0];
            A148DocTipoNome = P000N2_A148DocTipoNome[0];
            A219DocTipoAtivo = P000N2_A219DocTipoAtivo[0];
            A306DocUltArqSeq = P000N2_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P000N2_n306DocUltArqSeq[0];
            A480DocContrato = P000N2_A480DocContrato[0];
            A481DocAssinado = P000N2_A481DocAssinado[0];
            A640DocAtivo = P000N2_A640DocAtivo[0];
            n640DocAtivo = P000N2_n640DocAtivo[0];
            A327DocVersaoNomePai = P000N2_A327DocVersaoNomePai[0];
            A147DocTipoSigla = P000N2_A147DocTipoSigla[0];
            A148DocTipoNome = P000N2_A148DocTipoNome[0];
            A219DocTipoAtivo = P000N2_A219DocTipoAtivo[0];
            Gxm1sdtdocumento = new GeneXus.Programs.core.SdtsdtDocumento(context);
            Gxm2rootcol.Add(Gxm1sdtdocumento, 0);
            Gxm1sdtdocumento.gxTpr_Docid = A289DocID;
            Gxm1sdtdocumento.gxTpr_Docversao = A325DocVersao;
            Gxm1sdtdocumento.gxTpr_Docversaoidpai = A326DocVersaoIDPai;
            Gxm1sdtdocumento.gxTpr_Docversaonomepai = A327DocVersaoNomePai;
            Gxm1sdtdocumento.gxTpr_Docorigem = A290DocOrigem;
            Gxm1sdtdocumento.gxTpr_Docorigemid = A291DocOrigemID;
            Gxm1sdtdocumento.gxTpr_Docinsdata = A292DocInsData;
            Gxm1sdtdocumento.gxTpr_Docinshora = A293DocInsHora;
            Gxm1sdtdocumento.gxTpr_Docinsdatahora = A294DocInsDataHora;
            Gxm1sdtdocumento.gxTpr_Docinsusuid = A295DocInsUsuID;
            Gxm1sdtdocumento.gxTpr_Docupddata = A296DocUpdData;
            Gxm1sdtdocumento.gxTpr_Docupdhora = A297DocUpdHora;
            Gxm1sdtdocumento.gxTpr_Docupddatahora = A298DocUpdDataHora;
            Gxm1sdtdocumento.gxTpr_Docupdusuid = A299DocUpdUsuID;
            Gxm1sdtdocumento.gxTpr_Docdel = A300DocDel;
            Gxm1sdtdocumento.gxTpr_Docdeldatahora = A303DocDelDataHora;
            Gxm1sdtdocumento.gxTpr_Docdeldata = A301DocDelData;
            Gxm1sdtdocumento.gxTpr_Docdelhora = A302DocDelHora;
            Gxm1sdtdocumento.gxTpr_Docdelusuid = A304DocDelUsuID;
            Gxm1sdtdocumento.gxTpr_Docdelusunome = A510DocDelUsuNome;
            Gxm1sdtdocumento.gxTpr_Docnome = A305DocNome;
            Gxm1sdtdocumento.gxTpr_Doctipoid = A146DocTipoID;
            Gxm1sdtdocumento.gxTpr_Doctiposigla = A147DocTipoSigla;
            Gxm1sdtdocumento.gxTpr_Doctiponome = A148DocTipoNome;
            Gxm1sdtdocumento.gxTpr_Doctipoativo = A219DocTipoAtivo;
            Gxm1sdtdocumento.gxTpr_Docultarqseq = A306DocUltArqSeq;
            Gxm1sdtdocumento.gxTpr_Doccontrato = A480DocContrato;
            Gxm1sdtdocumento.gxTpr_Docassinado = A481DocAssinado;
            Gxm1sdtdocumento.gxTpr_Docativo = A640DocAtivo;
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
         AV9Core_dsdocumentofiltrogeral_3_sdtdocumento = new GeneXus.Programs.core.SdtsdtDocumento(context);
         scmdbuf = "";
         A289DocID = Guid.Empty;
         P000N2_A289DocID = new Guid[] {Guid.Empty} ;
         P000N2_A325DocVersao = new short[1] ;
         P000N2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P000N2_n326DocVersaoIDPai = new bool[] {false} ;
         P000N2_A327DocVersaoNomePai = new string[] {""} ;
         P000N2_A290DocOrigem = new string[] {""} ;
         P000N2_A291DocOrigemID = new string[] {""} ;
         P000N2_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         P000N2_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         P000N2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000N2_A295DocInsUsuID = new string[] {""} ;
         P000N2_n295DocInsUsuID = new bool[] {false} ;
         P000N2_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         P000N2_n296DocUpdData = new bool[] {false} ;
         P000N2_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         P000N2_n297DocUpdHora = new bool[] {false} ;
         P000N2_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P000N2_n298DocUpdDataHora = new bool[] {false} ;
         P000N2_A299DocUpdUsuID = new string[] {""} ;
         P000N2_n299DocUpdUsuID = new bool[] {false} ;
         P000N2_A300DocDel = new bool[] {false} ;
         P000N2_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000N2_n303DocDelDataHora = new bool[] {false} ;
         P000N2_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         P000N2_n301DocDelData = new bool[] {false} ;
         P000N2_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         P000N2_n302DocDelHora = new bool[] {false} ;
         P000N2_A304DocDelUsuID = new string[] {""} ;
         P000N2_n304DocDelUsuID = new bool[] {false} ;
         P000N2_A510DocDelUsuNome = new string[] {""} ;
         P000N2_n510DocDelUsuNome = new bool[] {false} ;
         P000N2_A305DocNome = new string[] {""} ;
         P000N2_A146DocTipoID = new int[1] ;
         P000N2_A147DocTipoSigla = new string[] {""} ;
         P000N2_A148DocTipoNome = new string[] {""} ;
         P000N2_A219DocTipoAtivo = new bool[] {false} ;
         P000N2_A306DocUltArqSeq = new short[1] ;
         P000N2_n306DocUltArqSeq = new bool[] {false} ;
         P000N2_A480DocContrato = new bool[] {false} ;
         P000N2_A481DocAssinado = new bool[] {false} ;
         P000N2_A640DocAtivo = new bool[] {false} ;
         P000N2_n640DocAtivo = new bool[] {false} ;
         A326DocVersaoIDPai = Guid.Empty;
         A327DocVersaoNomePai = "";
         A290DocOrigem = "";
         A291DocOrigemID = "";
         A292DocInsData = DateTime.MinValue;
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A295DocInsUsuID = "";
         A296DocUpdData = DateTime.MinValue;
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         A299DocUpdUsuID = "";
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A301DocDelData = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         A304DocDelUsuID = "";
         A510DocDelUsuNome = "";
         A305DocNome = "";
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         Gxm1sdtdocumento = new GeneXus.Programs.core.SdtsdtDocumento(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpdocumentoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000N2_A289DocID, P000N2_A325DocVersao, P000N2_A326DocVersaoIDPai, P000N2_n326DocVersaoIDPai, P000N2_A327DocVersaoNomePai, P000N2_A290DocOrigem, P000N2_A291DocOrigemID, P000N2_A292DocInsData, P000N2_A293DocInsHora, P000N2_A294DocInsDataHora,
               P000N2_A295DocInsUsuID, P000N2_n295DocInsUsuID, P000N2_A296DocUpdData, P000N2_n296DocUpdData, P000N2_A297DocUpdHora, P000N2_n297DocUpdHora, P000N2_A298DocUpdDataHora, P000N2_n298DocUpdDataHora, P000N2_A299DocUpdUsuID, P000N2_n299DocUpdUsuID,
               P000N2_A300DocDel, P000N2_A303DocDelDataHora, P000N2_n303DocDelDataHora, P000N2_A301DocDelData, P000N2_n301DocDelData, P000N2_A302DocDelHora, P000N2_n302DocDelHora, P000N2_A304DocDelUsuID, P000N2_n304DocDelUsuID, P000N2_A510DocDelUsuNome,
               P000N2_n510DocDelUsuNome, P000N2_A305DocNome, P000N2_A146DocTipoID, P000N2_A147DocTipoSigla, P000N2_A148DocTipoNome, P000N2_A219DocTipoAtivo, P000N2_A306DocUltArqSeq, P000N2_n306DocUltArqSeq, P000N2_A480DocContrato, P000N2_A481DocAssinado,
               P000N2_A640DocAtivo, P000N2_n640DocAtivo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A325DocVersao ;
      private short A306DocUltArqSeq ;
      private int A146DocTipoID ;
      private string scmdbuf ;
      private string A295DocInsUsuID ;
      private string A299DocUpdUsuID ;
      private string A304DocDelUsuID ;
      private DateTime A293DocInsHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime A297DocUpdHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime A303DocDelDataHora ;
      private DateTime A301DocDelData ;
      private DateTime A302DocDelHora ;
      private DateTime A292DocInsData ;
      private DateTime A296DocUpdData ;
      private bool n326DocVersaoIDPai ;
      private bool n295DocInsUsuID ;
      private bool n296DocUpdData ;
      private bool n297DocUpdHora ;
      private bool n298DocUpdDataHora ;
      private bool n299DocUpdUsuID ;
      private bool A300DocDel ;
      private bool n303DocDelDataHora ;
      private bool n301DocDelData ;
      private bool n302DocDelHora ;
      private bool n304DocDelUsuID ;
      private bool n510DocDelUsuNome ;
      private bool A219DocTipoAtivo ;
      private bool n306DocUltArqSeq ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool A640DocAtivo ;
      private bool n640DocAtivo ;
      private string A327DocVersaoNomePai ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string A510DocDelUsuNome ;
      private string A305DocNome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private Guid AV9Core_dsdocumentofiltrogeral_3_sdtdocumento_gxTpr_Docid ;
      private Guid A289DocID ;
      private Guid A326DocVersaoIDPai ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000N2_A289DocID ;
      private short[] P000N2_A325DocVersao ;
      private Guid[] P000N2_A326DocVersaoIDPai ;
      private bool[] P000N2_n326DocVersaoIDPai ;
      private string[] P000N2_A327DocVersaoNomePai ;
      private string[] P000N2_A290DocOrigem ;
      private string[] P000N2_A291DocOrigemID ;
      private DateTime[] P000N2_A292DocInsData ;
      private DateTime[] P000N2_A293DocInsHora ;
      private DateTime[] P000N2_A294DocInsDataHora ;
      private string[] P000N2_A295DocInsUsuID ;
      private bool[] P000N2_n295DocInsUsuID ;
      private DateTime[] P000N2_A296DocUpdData ;
      private bool[] P000N2_n296DocUpdData ;
      private DateTime[] P000N2_A297DocUpdHora ;
      private bool[] P000N2_n297DocUpdHora ;
      private DateTime[] P000N2_A298DocUpdDataHora ;
      private bool[] P000N2_n298DocUpdDataHora ;
      private string[] P000N2_A299DocUpdUsuID ;
      private bool[] P000N2_n299DocUpdUsuID ;
      private bool[] P000N2_A300DocDel ;
      private DateTime[] P000N2_A303DocDelDataHora ;
      private bool[] P000N2_n303DocDelDataHora ;
      private DateTime[] P000N2_A301DocDelData ;
      private bool[] P000N2_n301DocDelData ;
      private DateTime[] P000N2_A302DocDelHora ;
      private bool[] P000N2_n302DocDelHora ;
      private string[] P000N2_A304DocDelUsuID ;
      private bool[] P000N2_n304DocDelUsuID ;
      private string[] P000N2_A510DocDelUsuNome ;
      private bool[] P000N2_n510DocDelUsuNome ;
      private string[] P000N2_A305DocNome ;
      private int[] P000N2_A146DocTipoID ;
      private string[] P000N2_A147DocTipoSigla ;
      private string[] P000N2_A148DocTipoNome ;
      private bool[] P000N2_A219DocTipoAtivo ;
      private short[] P000N2_A306DocUltArqSeq ;
      private bool[] P000N2_n306DocUltArqSeq ;
      private bool[] P000N2_A480DocContrato ;
      private bool[] P000N2_A481DocAssinado ;
      private bool[] P000N2_A640DocAtivo ;
      private bool[] P000N2_n640DocAtivo ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumento> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtDocumento AV5sdtDocumento ;
      private GeneXus.Programs.core.SdtsdtDocumento AV9Core_dsdocumentofiltrogeral_3_sdtdocumento ;
      private GeneXus.Programs.core.SdtsdtDocumento Gxm1sdtdocumento ;
   }

   public class dpdocumentoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000N2( IGxContext context ,
                                             Guid AV9Core_dsdocumentofiltrogeral_3_sdtdocumento_gxTpr_Docid ,
                                             Guid A289DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.DocID, T1.DocVersao, T1.DocVersaoIDPai AS DocVersaoIDPai, T2.DocNome AS DocVersaoNomePai, T1.DocOrigem, T1.DocOrigemID, T1.DocInsData, T1.DocInsHora, T1.DocInsDataHora, T1.DocInsUsuID, T1.DocUpdData, T1.DocUpdHora, T1.DocUpdDataHora, T1.DocUpdUsuID, T1.DocDel, T1.DocDelDataHora, T1.DocDelData, T1.DocDelHora, T1.DocDelUsuID, T1.DocDelUsuNome, T1.DocNome, T1.DocTipoID, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, T1.DocUltArqSeq, T1.DocContrato, T1.DocAssinado, T1.DocAtivo FROM ((tb_documento T1 LEFT JOIN tb_documento T2 ON T2.DocID = T1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = T1.DocTipoID)";
         if ( ! (Guid.Empty==AV9Core_dsdocumentofiltrogeral_3_sdtdocumento_gxTpr_Docid) )
         {
            AddWhere(sWhereString, "(T1.DocID = :AV9Core__1Docid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         if ( ! (Guid.Empty==AV9Core_dsdocumentofiltrogeral_3_sdtdocumento_gxTpr_Docid) )
         {
            scmdbuf += " ORDER BY T1.DocID";
         }
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
                     return conditional_P000N2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
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
          Object[] prmP000N2;
          prmP000N2 = new Object[] {
          new ParDef("AV9Core__1Docid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000N2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                ((string[]) buf[10])[0] = rslt.getString(10, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((bool[]) buf[20])[0] = rslt.getBool(15);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getVarchar(21);
                ((int[]) buf[32])[0] = rslt.getInt(22);
                ((string[]) buf[33])[0] = rslt.getVarchar(23);
                ((string[]) buf[34])[0] = rslt.getVarchar(24);
                ((bool[]) buf[35])[0] = rslt.getBool(25);
                ((short[]) buf[36])[0] = rslt.getShort(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((bool[]) buf[38])[0] = rslt.getBool(27);
                ((bool[]) buf[39])[0] = rslt.getBool(28);
                ((bool[]) buf[40])[0] = rslt.getBool(29);
                ((bool[]) buf[41])[0] = rslt.wasNull(29);
                return;
       }
    }

 }

}
