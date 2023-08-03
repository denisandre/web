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
   public class dpgeneroobterdados : GXProcedure
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

      public dpgeneroobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpgeneroobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> aP1_Gxm2rootcol )
      {
         this.AV5sdtGenero = aP0_sdtGenero;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero>( context, "sdtGenero", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> executeUdp( GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero )
      {
         execute(aP0_sdtGenero, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> aP1_Gxm2rootcol )
      {
         dpgeneroobterdados objdpgeneroobterdados;
         objdpgeneroobterdados = new dpgeneroobterdados();
         objdpgeneroobterdados.AV5sdtGenero = aP0_sdtGenero;
         objdpgeneroobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero>( context, "sdtGenero", "agl_tresorygroup") ;
         objdpgeneroobterdados.context.SetSubmitInitialConfig(context);
         objdpgeneroobterdados.initialize();
         Submit( executePrivateCatch,objdpgeneroobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpgeneroobterdados)stateInfo).executePrivate();
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
         AV9Core_dsgenerofiltrogeral_3_sdtgenero = AV5sdtGenero;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsgenerofiltrogeral_3_sdtgenero.gxTpr_Genid ,
                                              A152GenID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P000Q2 */
         pr_default.execute(0, new Object[] {AV9Core_dsgenerofiltrogeral_3_sdtgenero.gxTpr_Genid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A152GenID = P000Q2_A152GenID[0];
            A153GenSigla = P000Q2_A153GenSigla[0];
            A154GenNome = P000Q2_A154GenNome[0];
            A215GenAtivo = P000Q2_A215GenAtivo[0];
            A536GenDel = P000Q2_A536GenDel[0];
            A537GenDelDataHora = P000Q2_A537GenDelDataHora[0];
            n537GenDelDataHora = P000Q2_n537GenDelDataHora[0];
            A538GenDelData = P000Q2_A538GenDelData[0];
            n538GenDelData = P000Q2_n538GenDelData[0];
            A539GenDelHora = P000Q2_A539GenDelHora[0];
            n539GenDelHora = P000Q2_n539GenDelHora[0];
            A540GenDelUsuId = P000Q2_A540GenDelUsuId[0];
            n540GenDelUsuId = P000Q2_n540GenDelUsuId[0];
            A541GenDelUsuNome = P000Q2_A541GenDelUsuNome[0];
            n541GenDelUsuNome = P000Q2_n541GenDelUsuNome[0];
            Gxm1sdtgenero = new GeneXus.Programs.core.SdtsdtGenero(context);
            Gxm2rootcol.Add(Gxm1sdtgenero, 0);
            Gxm1sdtgenero.gxTpr_Genid = A152GenID;
            Gxm1sdtgenero.gxTpr_Gensigla = A153GenSigla;
            Gxm1sdtgenero.gxTpr_Gennome = A154GenNome;
            Gxm1sdtgenero.gxTpr_Genativo = A215GenAtivo;
            Gxm1sdtgenero.gxTpr_Gendel = A536GenDel;
            Gxm1sdtgenero.gxTpr_Gendeldatahora = A537GenDelDataHora;
            Gxm1sdtgenero.gxTpr_Gendeldata = A538GenDelData;
            Gxm1sdtgenero.gxTpr_Gendelhora = A539GenDelHora;
            Gxm1sdtgenero.gxTpr_Gendelusuid = A540GenDelUsuId;
            Gxm1sdtgenero.gxTpr_Gendelusunome = A541GenDelUsuNome;
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
         AV9Core_dsgenerofiltrogeral_3_sdtgenero = new GeneXus.Programs.core.SdtsdtGenero(context);
         scmdbuf = "";
         P000Q2_A152GenID = new int[1] ;
         P000Q2_A153GenSigla = new string[] {""} ;
         P000Q2_A154GenNome = new string[] {""} ;
         P000Q2_A215GenAtivo = new bool[] {false} ;
         P000Q2_A536GenDel = new bool[] {false} ;
         P000Q2_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000Q2_n537GenDelDataHora = new bool[] {false} ;
         P000Q2_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         P000Q2_n538GenDelData = new bool[] {false} ;
         P000Q2_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         P000Q2_n539GenDelHora = new bool[] {false} ;
         P000Q2_A540GenDelUsuId = new string[] {""} ;
         P000Q2_n540GenDelUsuId = new bool[] {false} ;
         P000Q2_A541GenDelUsuNome = new string[] {""} ;
         P000Q2_n541GenDelUsuNome = new bool[] {false} ;
         A153GenSigla = "";
         A154GenNome = "";
         A537GenDelDataHora = (DateTime)(DateTime.MinValue);
         A538GenDelData = (DateTime)(DateTime.MinValue);
         A539GenDelHora = (DateTime)(DateTime.MinValue);
         A540GenDelUsuId = "";
         A541GenDelUsuNome = "";
         Gxm1sdtgenero = new GeneXus.Programs.core.SdtsdtGenero(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpgeneroobterdados__default(),
            new Object[][] {
                new Object[] {
               P000Q2_A152GenID, P000Q2_A153GenSigla, P000Q2_A154GenNome, P000Q2_A215GenAtivo, P000Q2_A536GenDel, P000Q2_A537GenDelDataHora, P000Q2_n537GenDelDataHora, P000Q2_A538GenDelData, P000Q2_n538GenDelData, P000Q2_A539GenDelHora,
               P000Q2_n539GenDelHora, P000Q2_A540GenDelUsuId, P000Q2_n540GenDelUsuId, P000Q2_A541GenDelUsuNome, P000Q2_n541GenDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9Core_dsgenerofiltrogeral_3_sdtgenero_gxTpr_Genid ;
      private int A152GenID ;
      private string scmdbuf ;
      private string A540GenDelUsuId ;
      private DateTime A537GenDelDataHora ;
      private DateTime A538GenDelData ;
      private DateTime A539GenDelHora ;
      private bool A215GenAtivo ;
      private bool A536GenDel ;
      private bool n537GenDelDataHora ;
      private bool n538GenDelData ;
      private bool n539GenDelHora ;
      private bool n540GenDelUsuId ;
      private bool n541GenDelUsuNome ;
      private string A153GenSigla ;
      private string A154GenNome ;
      private string A541GenDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000Q2_A152GenID ;
      private string[] P000Q2_A153GenSigla ;
      private string[] P000Q2_A154GenNome ;
      private bool[] P000Q2_A215GenAtivo ;
      private bool[] P000Q2_A536GenDel ;
      private DateTime[] P000Q2_A537GenDelDataHora ;
      private bool[] P000Q2_n537GenDelDataHora ;
      private DateTime[] P000Q2_A538GenDelData ;
      private bool[] P000Q2_n538GenDelData ;
      private DateTime[] P000Q2_A539GenDelHora ;
      private bool[] P000Q2_n539GenDelHora ;
      private string[] P000Q2_A540GenDelUsuId ;
      private bool[] P000Q2_n540GenDelUsuId ;
      private string[] P000Q2_A541GenDelUsuNome ;
      private bool[] P000Q2_n541GenDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtGenero> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtGenero AV5sdtGenero ;
      private GeneXus.Programs.core.SdtsdtGenero AV9Core_dsgenerofiltrogeral_3_sdtgenero ;
      private GeneXus.Programs.core.SdtsdtGenero Gxm1sdtgenero ;
   }

   public class dpgeneroobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000Q2( IGxContext context ,
                                             int AV9Core_dsgenerofiltrogeral_3_sdtgenero_gxTpr_Genid ,
                                             int A152GenID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT GenID, GenSigla, GenNome, GenAtivo, GenDel, GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome FROM tb_genero";
         if ( ! (0==AV9Core_dsgenerofiltrogeral_3_sdtgenero_gxTpr_Genid) )
         {
            AddWhere(sWhereString, "(GenID = :AV9Core__1Genid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY GenID";
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
                     return conditional_P000Q2(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
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
          Object[] prmP000Q2;
          prmP000Q2 = new Object[] {
          new ParDef("AV9Core__1Genid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q2,100, GxCacheFrequency.OFF ,false,false )
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
