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
   public class dpparametrosobterdados : GXProcedure
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

      public dpparametrosobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpparametrosobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> aP1_Gxm2rootcol )
      {
         this.AV5sdtParametros = aP0_sdtParametros;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros>( context, "sdtParametros", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> executeUdp( GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros )
      {
         execute(aP0_sdtParametros, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> aP1_Gxm2rootcol )
      {
         dpparametrosobterdados objdpparametrosobterdados;
         objdpparametrosobterdados = new dpparametrosobterdados();
         objdpparametrosobterdados.AV5sdtParametros = aP0_sdtParametros;
         objdpparametrosobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros>( context, "sdtParametros", "agl_tresorygroup") ;
         objdpparametrosobterdados.context.SetSubmitInitialConfig(context);
         objdpparametrosobterdados.initialize();
         Submit( executePrivateCatch,objdpparametrosobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpparametrosobterdados)stateInfo).executePrivate();
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
         AV9Core_dsparametrosfiltrogeral_3_sdtparametros = AV5sdtParametros;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsparametrosfiltrogeral_3_sdtparametros.gxTpr_Parametrochave ,
                                              A342ParametroChave } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P000R2 */
         pr_default.execute(0, new Object[] {AV9Core_dsparametrosfiltrogeral_3_sdtparametros.gxTpr_Parametrochave});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A342ParametroChave = P000R2_A342ParametroChave[0];
            A344ParametroDescricao = P000R2_A344ParametroDescricao[0];
            n344ParametroDescricao = P000R2_n344ParametroDescricao[0];
            A343ParametroValor = P000R2_A343ParametroValor[0];
            n343ParametroValor = P000R2_n343ParametroValor[0];
            A518ParametroDel = P000R2_A518ParametroDel[0];
            A519ParametroDelDataHora = P000R2_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = P000R2_n519ParametroDelDataHora[0];
            A520ParametroDelData = P000R2_A520ParametroDelData[0];
            n520ParametroDelData = P000R2_n520ParametroDelData[0];
            A521ParametroDelHora = P000R2_A521ParametroDelHora[0];
            n521ParametroDelHora = P000R2_n521ParametroDelHora[0];
            A522ParametroDelUsuId = P000R2_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = P000R2_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = P000R2_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = P000R2_n523ParametroDelUsuNome[0];
            Gxm1sdtparametros = new GeneXus.Programs.core.SdtsdtParametros(context);
            Gxm2rootcol.Add(Gxm1sdtparametros, 0);
            Gxm1sdtparametros.gxTpr_Parametrochave = A342ParametroChave;
            Gxm1sdtparametros.gxTpr_Parametrodescricao = A344ParametroDescricao;
            Gxm1sdtparametros.gxTpr_Parametrovalor = A343ParametroValor;
            Gxm1sdtparametros.gxTpr_Parametrodel = A518ParametroDel;
            Gxm1sdtparametros.gxTpr_Parametrodeldatahora = A519ParametroDelDataHora;
            Gxm1sdtparametros.gxTpr_Parametrodeldata = A520ParametroDelData;
            Gxm1sdtparametros.gxTpr_Parametrodelhora = A521ParametroDelHora;
            Gxm1sdtparametros.gxTpr_Parametrodelusuid = A522ParametroDelUsuId;
            Gxm1sdtparametros.gxTpr_Parametrodelusunome = A523ParametroDelUsuNome;
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
         AV9Core_dsparametrosfiltrogeral_3_sdtparametros = new GeneXus.Programs.core.SdtsdtParametros(context);
         scmdbuf = "";
         A342ParametroChave = "";
         P000R2_A342ParametroChave = new string[] {""} ;
         P000R2_A344ParametroDescricao = new string[] {""} ;
         P000R2_n344ParametroDescricao = new bool[] {false} ;
         P000R2_A343ParametroValor = new string[] {""} ;
         P000R2_n343ParametroValor = new bool[] {false} ;
         P000R2_A518ParametroDel = new bool[] {false} ;
         P000R2_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000R2_n519ParametroDelDataHora = new bool[] {false} ;
         P000R2_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         P000R2_n520ParametroDelData = new bool[] {false} ;
         P000R2_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         P000R2_n521ParametroDelHora = new bool[] {false} ;
         P000R2_A522ParametroDelUsuId = new string[] {""} ;
         P000R2_n522ParametroDelUsuId = new bool[] {false} ;
         P000R2_A523ParametroDelUsuNome = new string[] {""} ;
         P000R2_n523ParametroDelUsuNome = new bool[] {false} ;
         A344ParametroDescricao = "";
         A343ParametroValor = "";
         A519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         A520ParametroDelData = (DateTime)(DateTime.MinValue);
         A521ParametroDelHora = (DateTime)(DateTime.MinValue);
         A522ParametroDelUsuId = "";
         A523ParametroDelUsuNome = "";
         Gxm1sdtparametros = new GeneXus.Programs.core.SdtsdtParametros(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpparametrosobterdados__default(),
            new Object[][] {
                new Object[] {
               P000R2_A342ParametroChave, P000R2_A344ParametroDescricao, P000R2_n344ParametroDescricao, P000R2_A343ParametroValor, P000R2_n343ParametroValor, P000R2_A518ParametroDel, P000R2_A519ParametroDelDataHora, P000R2_n519ParametroDelDataHora, P000R2_A520ParametroDelData, P000R2_n520ParametroDelData,
               P000R2_A521ParametroDelHora, P000R2_n521ParametroDelHora, P000R2_A522ParametroDelUsuId, P000R2_n522ParametroDelUsuId, P000R2_A523ParametroDelUsuNome, P000R2_n523ParametroDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string scmdbuf ;
      private string A522ParametroDelUsuId ;
      private DateTime A519ParametroDelDataHora ;
      private DateTime A520ParametroDelData ;
      private DateTime A521ParametroDelHora ;
      private bool n344ParametroDescricao ;
      private bool n343ParametroValor ;
      private bool A518ParametroDel ;
      private bool n519ParametroDelDataHora ;
      private bool n520ParametroDelData ;
      private bool n521ParametroDelHora ;
      private bool n522ParametroDelUsuId ;
      private bool n523ParametroDelUsuNome ;
      private string AV9Core_dsparametrosfiltrogeral_3_sdtparametros_gxTpr_Parametrochave ;
      private string A342ParametroChave ;
      private string A344ParametroDescricao ;
      private string A343ParametroValor ;
      private string A523ParametroDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P000R2_A342ParametroChave ;
      private string[] P000R2_A344ParametroDescricao ;
      private bool[] P000R2_n344ParametroDescricao ;
      private string[] P000R2_A343ParametroValor ;
      private bool[] P000R2_n343ParametroValor ;
      private bool[] P000R2_A518ParametroDel ;
      private DateTime[] P000R2_A519ParametroDelDataHora ;
      private bool[] P000R2_n519ParametroDelDataHora ;
      private DateTime[] P000R2_A520ParametroDelData ;
      private bool[] P000R2_n520ParametroDelData ;
      private DateTime[] P000R2_A521ParametroDelHora ;
      private bool[] P000R2_n521ParametroDelHora ;
      private string[] P000R2_A522ParametroDelUsuId ;
      private bool[] P000R2_n522ParametroDelUsuId ;
      private string[] P000R2_A523ParametroDelUsuNome ;
      private bool[] P000R2_n523ParametroDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtParametros> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtParametros AV5sdtParametros ;
      private GeneXus.Programs.core.SdtsdtParametros AV9Core_dsparametrosfiltrogeral_3_sdtparametros ;
      private GeneXus.Programs.core.SdtsdtParametros Gxm1sdtparametros ;
   }

   public class dpparametrosobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000R2( IGxContext context ,
                                             string AV9Core_dsparametrosfiltrogeral_3_sdtparametros_gxTpr_Parametrochave ,
                                             string A342ParametroChave )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ParametroChave, ParametroDescricao, ParametroValor, ParametroDel, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome FROM tb_parametro";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Core_dsparametrosfiltrogeral_3_sdtparametros_gxTpr_Parametrochave)) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV9Core__1Parametrochave))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ParametroChave";
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
                     return conditional_P000R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP000R2;
          prmP000R2 = new Object[] {
          new ParDef("AV9Core__1Parametrochave",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5, true);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getString(8, 40);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
