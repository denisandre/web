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
   public class dpprodutotipoobterdados : GXProcedure
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

      public dpprodutotipoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpprodutotipoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> aP1_Gxm2rootcol )
      {
         this.AV5sdtProdutoTipo = aP0_sdtProdutoTipo;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo>( context, "sdtProdutoTipo", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> executeUdp( GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo )
      {
         execute(aP0_sdtProdutoTipo, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> aP1_Gxm2rootcol )
      {
         dpprodutotipoobterdados objdpprodutotipoobterdados;
         objdpprodutotipoobterdados = new dpprodutotipoobterdados();
         objdpprodutotipoobterdados.AV5sdtProdutoTipo = aP0_sdtProdutoTipo;
         objdpprodutotipoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo>( context, "sdtProdutoTipo", "agl_tresorygroup") ;
         objdpprodutotipoobterdados.context.SetSubmitInitialConfig(context);
         objdpprodutotipoobterdados.initialize();
         Submit( executePrivateCatch,objdpprodutotipoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpprodutotipoobterdados)stateInfo).executePrivate();
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
         AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo = AV5sdtProdutoTipo;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo.gxTpr_Prtid ,
                                              A211PrtID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P000U2 */
         pr_default.execute(0, new Object[] {AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo.gxTpr_Prtid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A211PrtID = P000U2_A211PrtID[0];
            A212PrtSigla = P000U2_A212PrtSigla[0];
            A213PrtNome = P000U2_A213PrtNome[0];
            A214PrtAtivo = P000U2_A214PrtAtivo[0];
            A614PrtDel = P000U2_A614PrtDel[0];
            A615PrtDelDataHora = P000U2_A615PrtDelDataHora[0];
            n615PrtDelDataHora = P000U2_n615PrtDelDataHora[0];
            A616PrtDelData = P000U2_A616PrtDelData[0];
            n616PrtDelData = P000U2_n616PrtDelData[0];
            A617PrtDelHora = P000U2_A617PrtDelHora[0];
            n617PrtDelHora = P000U2_n617PrtDelHora[0];
            A618PrtDelUsuId = P000U2_A618PrtDelUsuId[0];
            n618PrtDelUsuId = P000U2_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = P000U2_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = P000U2_n619PrtDelUsuNome[0];
            Gxm1sdtprodutotipo = new GeneXus.Programs.core.SdtsdtProdutoTipo(context);
            Gxm2rootcol.Add(Gxm1sdtprodutotipo, 0);
            Gxm1sdtprodutotipo.gxTpr_Prtid = A211PrtID;
            Gxm1sdtprodutotipo.gxTpr_Prtsigla = A212PrtSigla;
            Gxm1sdtprodutotipo.gxTpr_Prtnome = A213PrtNome;
            Gxm1sdtprodutotipo.gxTpr_Prtativo = A214PrtAtivo;
            Gxm1sdtprodutotipo.gxTpr_Prtdel = A614PrtDel;
            Gxm1sdtprodutotipo.gxTpr_Prtdeldatahora = A615PrtDelDataHora;
            Gxm1sdtprodutotipo.gxTpr_Prtdeldata = A616PrtDelData;
            Gxm1sdtprodutotipo.gxTpr_Prtdelhora = A617PrtDelHora;
            Gxm1sdtprodutotipo.gxTpr_Prtdelusuid = A618PrtDelUsuId;
            Gxm1sdtprodutotipo.gxTpr_Prtdelusunome = A619PrtDelUsuNome;
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
         AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo = new GeneXus.Programs.core.SdtsdtProdutoTipo(context);
         scmdbuf = "";
         P000U2_A211PrtID = new int[1] ;
         P000U2_A212PrtSigla = new string[] {""} ;
         P000U2_A213PrtNome = new string[] {""} ;
         P000U2_A214PrtAtivo = new bool[] {false} ;
         P000U2_A614PrtDel = new bool[] {false} ;
         P000U2_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000U2_n615PrtDelDataHora = new bool[] {false} ;
         P000U2_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         P000U2_n616PrtDelData = new bool[] {false} ;
         P000U2_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         P000U2_n617PrtDelHora = new bool[] {false} ;
         P000U2_A618PrtDelUsuId = new string[] {""} ;
         P000U2_n618PrtDelUsuId = new bool[] {false} ;
         P000U2_A619PrtDelUsuNome = new string[] {""} ;
         P000U2_n619PrtDelUsuNome = new bool[] {false} ;
         A212PrtSigla = "";
         A213PrtNome = "";
         A615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         A616PrtDelData = (DateTime)(DateTime.MinValue);
         A617PrtDelHora = (DateTime)(DateTime.MinValue);
         A618PrtDelUsuId = "";
         A619PrtDelUsuNome = "";
         Gxm1sdtprodutotipo = new GeneXus.Programs.core.SdtsdtProdutoTipo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpprodutotipoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000U2_A211PrtID, P000U2_A212PrtSigla, P000U2_A213PrtNome, P000U2_A214PrtAtivo, P000U2_A614PrtDel, P000U2_A615PrtDelDataHora, P000U2_n615PrtDelDataHora, P000U2_A616PrtDelData, P000U2_n616PrtDelData, P000U2_A617PrtDelHora,
               P000U2_n617PrtDelHora, P000U2_A618PrtDelUsuId, P000U2_n618PrtDelUsuId, P000U2_A619PrtDelUsuNome, P000U2_n619PrtDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo_gxTpr_Prtid ;
      private int A211PrtID ;
      private string scmdbuf ;
      private string A618PrtDelUsuId ;
      private DateTime A615PrtDelDataHora ;
      private DateTime A616PrtDelData ;
      private DateTime A617PrtDelHora ;
      private bool A214PrtAtivo ;
      private bool A614PrtDel ;
      private bool n615PrtDelDataHora ;
      private bool n616PrtDelData ;
      private bool n617PrtDelHora ;
      private bool n618PrtDelUsuId ;
      private bool n619PrtDelUsuNome ;
      private string A212PrtSigla ;
      private string A213PrtNome ;
      private string A619PrtDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000U2_A211PrtID ;
      private string[] P000U2_A212PrtSigla ;
      private string[] P000U2_A213PrtNome ;
      private bool[] P000U2_A214PrtAtivo ;
      private bool[] P000U2_A614PrtDel ;
      private DateTime[] P000U2_A615PrtDelDataHora ;
      private bool[] P000U2_n615PrtDelDataHora ;
      private DateTime[] P000U2_A616PrtDelData ;
      private bool[] P000U2_n616PrtDelData ;
      private DateTime[] P000U2_A617PrtDelHora ;
      private bool[] P000U2_n617PrtDelHora ;
      private string[] P000U2_A618PrtDelUsuId ;
      private bool[] P000U2_n618PrtDelUsuId ;
      private string[] P000U2_A619PrtDelUsuNome ;
      private bool[] P000U2_n619PrtDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtProdutoTipo> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtProdutoTipo AV5sdtProdutoTipo ;
      private GeneXus.Programs.core.SdtsdtProdutoTipo AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo ;
      private GeneXus.Programs.core.SdtsdtProdutoTipo Gxm1sdtprodutotipo ;
   }

   public class dpprodutotipoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000U2( IGxContext context ,
                                             int AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo_gxTpr_Prtid ,
                                             int A211PrtID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT PrtID, PrtSigla, PrtNome, PrtAtivo, PrtDel, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome FROM tb_produtotipo";
         if ( ! (0==AV9Core_dsprodutotipofiltrogeral_3_sdtprodutotipo_gxTpr_Prtid) )
         {
            AddWhere(sWhereString, "(PrtID = :AV9Core__1Prtid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY PrtID";
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
                     return conditional_P000U2(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
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
          Object[] prmP000U2;
          prmP000U2 = new Object[] {
          new ParDef("AV9Core__1Prtid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
