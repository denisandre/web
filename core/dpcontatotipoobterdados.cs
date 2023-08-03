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
   public class dpcontatotipoobterdados : GXProcedure
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

      public dpcontatotipoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpcontatotipoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> aP1_Gxm2rootcol )
      {
         this.AV5sdtContatoTipo = aP0_sdtContatoTipo;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo>( context, "sdtContatoTipo", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> executeUdp( GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo )
      {
         execute(aP0_sdtContatoTipo, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> aP1_Gxm2rootcol )
      {
         dpcontatotipoobterdados objdpcontatotipoobterdados;
         objdpcontatotipoobterdados = new dpcontatotipoobterdados();
         objdpcontatotipoobterdados.AV5sdtContatoTipo = aP0_sdtContatoTipo;
         objdpcontatotipoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo>( context, "sdtContatoTipo", "agl_tresorygroup") ;
         objdpcontatotipoobterdados.context.SetSubmitInitialConfig(context);
         objdpcontatotipoobterdados.initialize();
         Submit( executePrivateCatch,objdpcontatotipoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpcontatotipoobterdados)stateInfo).executePrivate();
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
         AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo = AV5sdtContatoTipo;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo.gxTpr_Cotid ,
                                              A149CotID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P000T2 */
         pr_default.execute(0, new Object[] {AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo.gxTpr_Cotid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A149CotID = P000T2_A149CotID[0];
            A150CotSigla = P000T2_A150CotSigla[0];
            A151CotNome = P000T2_A151CotNome[0];
            A216CotAtivo = P000T2_A216CotAtivo[0];
            A566CotDel = P000T2_A566CotDel[0];
            A567CotDelDataHora = P000T2_A567CotDelDataHora[0];
            n567CotDelDataHora = P000T2_n567CotDelDataHora[0];
            A568CotDelData = P000T2_A568CotDelData[0];
            n568CotDelData = P000T2_n568CotDelData[0];
            A569CotDelHora = P000T2_A569CotDelHora[0];
            n569CotDelHora = P000T2_n569CotDelHora[0];
            A570CotDelUsuId = P000T2_A570CotDelUsuId[0];
            n570CotDelUsuId = P000T2_n570CotDelUsuId[0];
            A571CotDelUsuNome = P000T2_A571CotDelUsuNome[0];
            n571CotDelUsuNome = P000T2_n571CotDelUsuNome[0];
            Gxm1sdtcontatotipo = new GeneXus.Programs.core.SdtsdtContatoTipo(context);
            Gxm2rootcol.Add(Gxm1sdtcontatotipo, 0);
            Gxm1sdtcontatotipo.gxTpr_Cotid = A149CotID;
            Gxm1sdtcontatotipo.gxTpr_Cotsigla = A150CotSigla;
            Gxm1sdtcontatotipo.gxTpr_Cotnome = A151CotNome;
            Gxm1sdtcontatotipo.gxTpr_Cotativo = A216CotAtivo;
            Gxm1sdtcontatotipo.gxTpr_Cotdel = A566CotDel;
            Gxm1sdtcontatotipo.gxTpr_Cotdeldatahora = A567CotDelDataHora;
            Gxm1sdtcontatotipo.gxTpr_Cotdeldata = A568CotDelData;
            Gxm1sdtcontatotipo.gxTpr_Cotdelhora = A569CotDelHora;
            Gxm1sdtcontatotipo.gxTpr_Cotdelusuid = A570CotDelUsuId;
            Gxm1sdtcontatotipo.gxTpr_Cotdelusunome = A571CotDelUsuNome;
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
         AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo = new GeneXus.Programs.core.SdtsdtContatoTipo(context);
         scmdbuf = "";
         P000T2_A149CotID = new int[1] ;
         P000T2_A150CotSigla = new string[] {""} ;
         P000T2_A151CotNome = new string[] {""} ;
         P000T2_A216CotAtivo = new bool[] {false} ;
         P000T2_A566CotDel = new bool[] {false} ;
         P000T2_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000T2_n567CotDelDataHora = new bool[] {false} ;
         P000T2_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         P000T2_n568CotDelData = new bool[] {false} ;
         P000T2_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         P000T2_n569CotDelHora = new bool[] {false} ;
         P000T2_A570CotDelUsuId = new string[] {""} ;
         P000T2_n570CotDelUsuId = new bool[] {false} ;
         P000T2_A571CotDelUsuNome = new string[] {""} ;
         P000T2_n571CotDelUsuNome = new bool[] {false} ;
         A150CotSigla = "";
         A151CotNome = "";
         A567CotDelDataHora = (DateTime)(DateTime.MinValue);
         A568CotDelData = (DateTime)(DateTime.MinValue);
         A569CotDelHora = (DateTime)(DateTime.MinValue);
         A570CotDelUsuId = "";
         A571CotDelUsuNome = "";
         Gxm1sdtcontatotipo = new GeneXus.Programs.core.SdtsdtContatoTipo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpcontatotipoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000T2_A149CotID, P000T2_A150CotSigla, P000T2_A151CotNome, P000T2_A216CotAtivo, P000T2_A566CotDel, P000T2_A567CotDelDataHora, P000T2_n567CotDelDataHora, P000T2_A568CotDelData, P000T2_n568CotDelData, P000T2_A569CotDelHora,
               P000T2_n569CotDelHora, P000T2_A570CotDelUsuId, P000T2_n570CotDelUsuId, P000T2_A571CotDelUsuNome, P000T2_n571CotDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo_gxTpr_Cotid ;
      private int A149CotID ;
      private string scmdbuf ;
      private string A570CotDelUsuId ;
      private DateTime A567CotDelDataHora ;
      private DateTime A568CotDelData ;
      private DateTime A569CotDelHora ;
      private bool A216CotAtivo ;
      private bool A566CotDel ;
      private bool n567CotDelDataHora ;
      private bool n568CotDelData ;
      private bool n569CotDelHora ;
      private bool n570CotDelUsuId ;
      private bool n571CotDelUsuNome ;
      private string A150CotSigla ;
      private string A151CotNome ;
      private string A571CotDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000T2_A149CotID ;
      private string[] P000T2_A150CotSigla ;
      private string[] P000T2_A151CotNome ;
      private bool[] P000T2_A216CotAtivo ;
      private bool[] P000T2_A566CotDel ;
      private DateTime[] P000T2_A567CotDelDataHora ;
      private bool[] P000T2_n567CotDelDataHora ;
      private DateTime[] P000T2_A568CotDelData ;
      private bool[] P000T2_n568CotDelData ;
      private DateTime[] P000T2_A569CotDelHora ;
      private bool[] P000T2_n569CotDelHora ;
      private string[] P000T2_A570CotDelUsuId ;
      private bool[] P000T2_n570CotDelUsuId ;
      private string[] P000T2_A571CotDelUsuNome ;
      private bool[] P000T2_n571CotDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtContatoTipo> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtContatoTipo AV5sdtContatoTipo ;
      private GeneXus.Programs.core.SdtsdtContatoTipo AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo ;
      private GeneXus.Programs.core.SdtsdtContatoTipo Gxm1sdtcontatotipo ;
   }

   public class dpcontatotipoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000T2( IGxContext context ,
                                             int AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo_gxTpr_Cotid ,
                                             int A149CotID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT CotID, CotSigla, CotNome, CotAtivo, CotDel, CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome FROM tb_contatotipo";
         if ( ! (0==AV9Core_dscontatotipofiltrogeral_3_sdtcontatotipo_gxTpr_Cotid) )
         {
            AddWhere(sWhereString, "(CotID = :AV9Core__1Cotid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CotID";
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
                     return conditional_P000T2(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
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
          Object[] prmP000T2;
          prmP000T2 = new Object[] {
          new ParDef("AV9Core__1Cotid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000T2,100, GxCacheFrequency.OFF ,false,false )
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
