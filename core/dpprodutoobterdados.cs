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
   public class dpprodutoobterdados : GXProcedure
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

      public dpprodutoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpprodutoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtProduto aP0_sdtProduto ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> aP1_Gxm2rootcol )
      {
         this.AV5sdtProduto = aP0_sdtProduto;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto>( context, "sdtProduto", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> executeUdp( GeneXus.Programs.core.SdtsdtProduto aP0_sdtProduto )
      {
         execute(aP0_sdtProduto, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtProduto aP0_sdtProduto ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> aP1_Gxm2rootcol )
      {
         dpprodutoobterdados objdpprodutoobterdados;
         objdpprodutoobterdados = new dpprodutoobterdados();
         objdpprodutoobterdados.AV5sdtProduto = aP0_sdtProduto;
         objdpprodutoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto>( context, "sdtProduto", "agl_tresorygroup") ;
         objdpprodutoobterdados.context.SetSubmitInitialConfig(context);
         objdpprodutoobterdados.initialize();
         Submit( executePrivateCatch,objdpprodutoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpprodutoobterdados)stateInfo).executePrivate();
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
         AV9Core_dsprodutofiltrogeral_3_sdtproduto = AV5sdtProduto;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsprodutofiltrogeral_3_sdtproduto.gxTpr_Prdid ,
                                              A220PrdID } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P000X2 */
         pr_default.execute(0, new Object[] {AV9Core_dsprodutofiltrogeral_3_sdtproduto.gxTpr_Prdid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A220PrdID = P000X2_A220PrdID[0];
            A221PrdCodigo = P000X2_A221PrdCodigo[0];
            A222PrdNome = P000X2_A222PrdNome[0];
            A223PrdInsData = P000X2_A223PrdInsData[0];
            A224PrdInsHora = P000X2_A224PrdInsHora[0];
            A225PrdInsDataHora = P000X2_A225PrdInsDataHora[0];
            A226PrdInsUsuID = P000X2_A226PrdInsUsuID[0];
            n226PrdInsUsuID = P000X2_n226PrdInsUsuID[0];
            A227PrdUpdData = P000X2_A227PrdUpdData[0];
            n227PrdUpdData = P000X2_n227PrdUpdData[0];
            A228PrdUpdHora = P000X2_A228PrdUpdHora[0];
            n228PrdUpdHora = P000X2_n228PrdUpdHora[0];
            A229PrdUpdDataHora = P000X2_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = P000X2_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = P000X2_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = P000X2_n230PrdUpdUsuID[0];
            A231PrdAtivo = P000X2_A231PrdAtivo[0];
            A232PrdTipoID = P000X2_A232PrdTipoID[0];
            A233PrdTipoSigla = P000X2_A233PrdTipoSigla[0];
            A234PrdTipoNome = P000X2_A234PrdTipoNome[0];
            A620PrdDel = P000X2_A620PrdDel[0];
            A621PrdDelDataHora = P000X2_A621PrdDelDataHora[0];
            n621PrdDelDataHora = P000X2_n621PrdDelDataHora[0];
            A622PrdDelData = P000X2_A622PrdDelData[0];
            n622PrdDelData = P000X2_n622PrdDelData[0];
            A623PrdDelHora = P000X2_A623PrdDelHora[0];
            n623PrdDelHora = P000X2_n623PrdDelHora[0];
            A624PrdDelUsuId = P000X2_A624PrdDelUsuId[0];
            n624PrdDelUsuId = P000X2_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = P000X2_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = P000X2_n625PrdDelUsuNome[0];
            A233PrdTipoSigla = P000X2_A233PrdTipoSigla[0];
            A234PrdTipoNome = P000X2_A234PrdTipoNome[0];
            Gxm1sdtproduto = new GeneXus.Programs.core.SdtsdtProduto(context);
            Gxm2rootcol.Add(Gxm1sdtproduto, 0);
            Gxm1sdtproduto.gxTpr_Prdid = A220PrdID;
            Gxm1sdtproduto.gxTpr_Prdcodigo = A221PrdCodigo;
            Gxm1sdtproduto.gxTpr_Prdnome = A222PrdNome;
            Gxm1sdtproduto.gxTpr_Prdinsdata = A223PrdInsData;
            Gxm1sdtproduto.gxTpr_Prdinshora = A224PrdInsHora;
            Gxm1sdtproduto.gxTpr_Prdinsdatahora = A225PrdInsDataHora;
            Gxm1sdtproduto.gxTpr_Prdinsusuid = A226PrdInsUsuID;
            Gxm1sdtproduto.gxTpr_Prdupddata = A227PrdUpdData;
            Gxm1sdtproduto.gxTpr_Prdupdhora = A228PrdUpdHora;
            Gxm1sdtproduto.gxTpr_Prdupddatahora = A229PrdUpdDataHora;
            Gxm1sdtproduto.gxTpr_Prdupdusuid = A230PrdUpdUsuID;
            Gxm1sdtproduto.gxTpr_Prdativo = A231PrdAtivo;
            Gxm1sdtproduto.gxTpr_Prdtipoid = A232PrdTipoID;
            Gxm1sdtproduto.gxTpr_Prdtiposigla = A233PrdTipoSigla;
            Gxm1sdtproduto.gxTpr_Prdtiponome = A234PrdTipoNome;
            Gxm1sdtproduto.gxTpr_Prddel = A620PrdDel;
            Gxm1sdtproduto.gxTpr_Prddeldatahora = A621PrdDelDataHora;
            Gxm1sdtproduto.gxTpr_Prddeldata = A622PrdDelData;
            Gxm1sdtproduto.gxTpr_Prddelhora = A623PrdDelHora;
            Gxm1sdtproduto.gxTpr_Prddelusuid = A624PrdDelUsuId;
            Gxm1sdtproduto.gxTpr_Prddelusunome = A625PrdDelUsuNome;
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
         AV9Core_dsprodutofiltrogeral_3_sdtproduto = new GeneXus.Programs.core.SdtsdtProduto(context);
         scmdbuf = "";
         A220PrdID = Guid.Empty;
         P000X2_A220PrdID = new Guid[] {Guid.Empty} ;
         P000X2_A221PrdCodigo = new string[] {""} ;
         P000X2_A222PrdNome = new string[] {""} ;
         P000X2_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         P000X2_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         P000X2_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000X2_A226PrdInsUsuID = new string[] {""} ;
         P000X2_n226PrdInsUsuID = new bool[] {false} ;
         P000X2_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         P000X2_n227PrdUpdData = new bool[] {false} ;
         P000X2_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         P000X2_n228PrdUpdHora = new bool[] {false} ;
         P000X2_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P000X2_n229PrdUpdDataHora = new bool[] {false} ;
         P000X2_A230PrdUpdUsuID = new string[] {""} ;
         P000X2_n230PrdUpdUsuID = new bool[] {false} ;
         P000X2_A231PrdAtivo = new bool[] {false} ;
         P000X2_A232PrdTipoID = new int[1] ;
         P000X2_A233PrdTipoSigla = new string[] {""} ;
         P000X2_A234PrdTipoNome = new string[] {""} ;
         P000X2_A620PrdDel = new bool[] {false} ;
         P000X2_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000X2_n621PrdDelDataHora = new bool[] {false} ;
         P000X2_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         P000X2_n622PrdDelData = new bool[] {false} ;
         P000X2_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         P000X2_n623PrdDelHora = new bool[] {false} ;
         P000X2_A624PrdDelUsuId = new string[] {""} ;
         P000X2_n624PrdDelUsuId = new bool[] {false} ;
         P000X2_A625PrdDelUsuNome = new string[] {""} ;
         P000X2_n625PrdDelUsuNome = new bool[] {false} ;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A223PrdInsData = DateTime.MinValue;
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A226PrdInsUsuID = "";
         A227PrdUpdData = DateTime.MinValue;
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         A230PrdUpdUsuID = "";
         A233PrdTipoSigla = "";
         A234PrdTipoNome = "";
         A621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         A622PrdDelData = (DateTime)(DateTime.MinValue);
         A623PrdDelHora = (DateTime)(DateTime.MinValue);
         A624PrdDelUsuId = "";
         A625PrdDelUsuNome = "";
         Gxm1sdtproduto = new GeneXus.Programs.core.SdtsdtProduto(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpprodutoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000X2_A220PrdID, P000X2_A221PrdCodigo, P000X2_A222PrdNome, P000X2_A223PrdInsData, P000X2_A224PrdInsHora, P000X2_A225PrdInsDataHora, P000X2_A226PrdInsUsuID, P000X2_n226PrdInsUsuID, P000X2_A227PrdUpdData, P000X2_n227PrdUpdData,
               P000X2_A228PrdUpdHora, P000X2_n228PrdUpdHora, P000X2_A229PrdUpdDataHora, P000X2_n229PrdUpdDataHora, P000X2_A230PrdUpdUsuID, P000X2_n230PrdUpdUsuID, P000X2_A231PrdAtivo, P000X2_A232PrdTipoID, P000X2_A233PrdTipoSigla, P000X2_A234PrdTipoNome,
               P000X2_A620PrdDel, P000X2_A621PrdDelDataHora, P000X2_n621PrdDelDataHora, P000X2_A622PrdDelData, P000X2_n622PrdDelData, P000X2_A623PrdDelHora, P000X2_n623PrdDelHora, P000X2_A624PrdDelUsuId, P000X2_n624PrdDelUsuId, P000X2_A625PrdDelUsuNome,
               P000X2_n625PrdDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private string scmdbuf ;
      private string A226PrdInsUsuID ;
      private string A230PrdUpdUsuID ;
      private string A624PrdDelUsuId ;
      private DateTime A224PrdInsHora ;
      private DateTime A225PrdInsDataHora ;
      private DateTime A228PrdUpdHora ;
      private DateTime A229PrdUpdDataHora ;
      private DateTime A621PrdDelDataHora ;
      private DateTime A622PrdDelData ;
      private DateTime A623PrdDelHora ;
      private DateTime A223PrdInsData ;
      private DateTime A227PrdUpdData ;
      private bool n226PrdInsUsuID ;
      private bool n227PrdUpdData ;
      private bool n228PrdUpdHora ;
      private bool n229PrdUpdDataHora ;
      private bool n230PrdUpdUsuID ;
      private bool A231PrdAtivo ;
      private bool A620PrdDel ;
      private bool n621PrdDelDataHora ;
      private bool n622PrdDelData ;
      private bool n623PrdDelHora ;
      private bool n624PrdDelUsuId ;
      private bool n625PrdDelUsuNome ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A233PrdTipoSigla ;
      private string A234PrdTipoNome ;
      private string A625PrdDelUsuNome ;
      private Guid AV9Core_dsprodutofiltrogeral_3_sdtproduto_gxTpr_Prdid ;
      private Guid A220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000X2_A220PrdID ;
      private string[] P000X2_A221PrdCodigo ;
      private string[] P000X2_A222PrdNome ;
      private DateTime[] P000X2_A223PrdInsData ;
      private DateTime[] P000X2_A224PrdInsHora ;
      private DateTime[] P000X2_A225PrdInsDataHora ;
      private string[] P000X2_A226PrdInsUsuID ;
      private bool[] P000X2_n226PrdInsUsuID ;
      private DateTime[] P000X2_A227PrdUpdData ;
      private bool[] P000X2_n227PrdUpdData ;
      private DateTime[] P000X2_A228PrdUpdHora ;
      private bool[] P000X2_n228PrdUpdHora ;
      private DateTime[] P000X2_A229PrdUpdDataHora ;
      private bool[] P000X2_n229PrdUpdDataHora ;
      private string[] P000X2_A230PrdUpdUsuID ;
      private bool[] P000X2_n230PrdUpdUsuID ;
      private bool[] P000X2_A231PrdAtivo ;
      private int[] P000X2_A232PrdTipoID ;
      private string[] P000X2_A233PrdTipoSigla ;
      private string[] P000X2_A234PrdTipoNome ;
      private bool[] P000X2_A620PrdDel ;
      private DateTime[] P000X2_A621PrdDelDataHora ;
      private bool[] P000X2_n621PrdDelDataHora ;
      private DateTime[] P000X2_A622PrdDelData ;
      private bool[] P000X2_n622PrdDelData ;
      private DateTime[] P000X2_A623PrdDelHora ;
      private bool[] P000X2_n623PrdDelHora ;
      private string[] P000X2_A624PrdDelUsuId ;
      private bool[] P000X2_n624PrdDelUsuId ;
      private string[] P000X2_A625PrdDelUsuNome ;
      private bool[] P000X2_n625PrdDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProduto> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtProduto AV5sdtProduto ;
      private GeneXus.Programs.core.SdtsdtProduto AV9Core_dsprodutofiltrogeral_3_sdtproduto ;
      private GeneXus.Programs.core.SdtsdtProduto Gxm1sdtproduto ;
   }

   public class dpprodutoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000X2( IGxContext context ,
                                             Guid AV9Core_dsprodutofiltrogeral_3_sdtproduto_gxTpr_Prdid ,
                                             Guid A220PrdID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdInsData, T1.PrdInsHora, T1.PrdInsDataHora, T1.PrdInsUsuID, T1.PrdUpdData, T1.PrdUpdHora, T1.PrdUpdDataHora, T1.PrdUpdUsuID, T1.PrdAtivo, T1.PrdTipoID AS PrdTipoID, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, T1.PrdDel, T1.PrdDelDataHora, T1.PrdDelData, T1.PrdDelHora, T1.PrdDelUsuId, T1.PrdDelUsuNome FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID)";
         if ( ! (Guid.Empty==AV9Core_dsprodutofiltrogeral_3_sdtproduto_gxTpr_Prdid) )
         {
            AddWhere(sWhereString, "(T1.PrdID = :AV9Core__1Prdid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PrdID";
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
                     return conditional_P000X2(context, (Guid)dynConstraints[0] , (Guid)dynConstraints[1] );
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
          Object[] prmP000X2;
          prmP000X2 = new Object[] {
          new ParDef("AV9Core__1Prdid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000X2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((string[]) buf[6])[0] = rslt.getString(7, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((bool[]) buf[16])[0] = rslt.getBool(12);
                ((int[]) buf[17])[0] = rslt.getInt(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((string[]) buf[19])[0] = rslt.getVarchar(15);
                ((bool[]) buf[20])[0] = rslt.getBool(16);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(17, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((string[]) buf[29])[0] = rslt.getVarchar(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                return;
       }
    }

 }

}
