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
   public class dpdocumentotipoobterdados : GXProcedure
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

      public dpdocumentotipoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpdocumentotipoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> aP1_Gxm2rootcol )
      {
         this.AV5sdtDocumentoTipo = aP0_sdtDocumentoTipo;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo>( context, "sdtDocumentoTipo", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> executeUdp( GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo )
      {
         execute(aP0_sdtDocumentoTipo, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> aP1_Gxm2rootcol )
      {
         dpdocumentotipoobterdados objdpdocumentotipoobterdados;
         objdpdocumentotipoobterdados = new dpdocumentotipoobterdados();
         objdpdocumentotipoobterdados.AV5sdtDocumentoTipo = aP0_sdtDocumentoTipo;
         objdpdocumentotipoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo>( context, "sdtDocumentoTipo", "agl_tresorygroup") ;
         objdpdocumentotipoobterdados.context.SetSubmitInitialConfig(context);
         objdpdocumentotipoobterdados.initialize();
         Submit( executePrivateCatch,objdpdocumentotipoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpdocumentotipoobterdados)stateInfo).executePrivate();
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
         AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo = AV5sdtDocumentoTipo;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo.gxTpr_Doctipoid ,
                                              A146DocTipoID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P000S2 */
         pr_default.execute(0, new Object[] {AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo.gxTpr_Doctipoid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146DocTipoID = P000S2_A146DocTipoID[0];
            A147DocTipoSigla = P000S2_A147DocTipoSigla[0];
            A148DocTipoNome = P000S2_A148DocTipoNome[0];
            A219DocTipoAtivo = P000S2_A219DocTipoAtivo[0];
            A503DocTipoDel = P000S2_A503DocTipoDel[0];
            A504DocTipoDelDataHora = P000S2_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = P000S2_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = P000S2_A505DocTipoDelData[0];
            n505DocTipoDelData = P000S2_n505DocTipoDelData[0];
            A506DocTipoDelHora = P000S2_A506DocTipoDelHora[0];
            n506DocTipoDelHora = P000S2_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = P000S2_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = P000S2_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = P000S2_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = P000S2_n508DocTipoDelUsuNome[0];
            Gxm1sdtdocumentotipo = new GeneXus.Programs.core.SdtsdtDocumentoTipo(context);
            Gxm2rootcol.Add(Gxm1sdtdocumentotipo, 0);
            Gxm1sdtdocumentotipo.gxTpr_Doctipoid = A146DocTipoID;
            Gxm1sdtdocumentotipo.gxTpr_Doctiposigla = A147DocTipoSigla;
            Gxm1sdtdocumentotipo.gxTpr_Doctiponome = A148DocTipoNome;
            Gxm1sdtdocumentotipo.gxTpr_Doctipoativo = A219DocTipoAtivo;
            Gxm1sdtdocumentotipo.gxTpr_Doctipodel = A503DocTipoDel;
            Gxm1sdtdocumentotipo.gxTpr_Doctipodeldatahora = A504DocTipoDelDataHora;
            Gxm1sdtdocumentotipo.gxTpr_Doctipodeldata = A505DocTipoDelData;
            Gxm1sdtdocumentotipo.gxTpr_Doctipodelhora = A506DocTipoDelHora;
            Gxm1sdtdocumentotipo.gxTpr_Doctipodelusuid = A507DocTipoDelUsuID;
            Gxm1sdtdocumentotipo.gxTpr_Doctipodelusunome = A508DocTipoDelUsuNome;
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
         AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo = new GeneXus.Programs.core.SdtsdtDocumentoTipo(context);
         scmdbuf = "";
         P000S2_A146DocTipoID = new int[1] ;
         P000S2_A147DocTipoSigla = new string[] {""} ;
         P000S2_A148DocTipoNome = new string[] {""} ;
         P000S2_A219DocTipoAtivo = new bool[] {false} ;
         P000S2_A503DocTipoDel = new bool[] {false} ;
         P000S2_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000S2_n504DocTipoDelDataHora = new bool[] {false} ;
         P000S2_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         P000S2_n505DocTipoDelData = new bool[] {false} ;
         P000S2_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         P000S2_n506DocTipoDelHora = new bool[] {false} ;
         P000S2_A507DocTipoDelUsuID = new string[] {""} ;
         P000S2_n507DocTipoDelUsuID = new bool[] {false} ;
         P000S2_A508DocTipoDelUsuNome = new string[] {""} ;
         P000S2_n508DocTipoDelUsuNome = new bool[] {false} ;
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         A504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         A505DocTipoDelData = DateTime.MinValue;
         A506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         A507DocTipoDelUsuID = "";
         A508DocTipoDelUsuNome = "";
         Gxm1sdtdocumentotipo = new GeneXus.Programs.core.SdtsdtDocumentoTipo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpdocumentotipoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000S2_A146DocTipoID, P000S2_A147DocTipoSigla, P000S2_A148DocTipoNome, P000S2_A219DocTipoAtivo, P000S2_A503DocTipoDel, P000S2_A504DocTipoDelDataHora, P000S2_n504DocTipoDelDataHora, P000S2_A505DocTipoDelData, P000S2_n505DocTipoDelData, P000S2_A506DocTipoDelHora,
               P000S2_n506DocTipoDelHora, P000S2_A507DocTipoDelUsuID, P000S2_n507DocTipoDelUsuID, P000S2_A508DocTipoDelUsuNome, P000S2_n508DocTipoDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo_gxTpr_Doctipoid ;
      private int A146DocTipoID ;
      private string scmdbuf ;
      private string A507DocTipoDelUsuID ;
      private DateTime A504DocTipoDelDataHora ;
      private DateTime A506DocTipoDelHora ;
      private DateTime A505DocTipoDelData ;
      private bool A219DocTipoAtivo ;
      private bool A503DocTipoDel ;
      private bool n504DocTipoDelDataHora ;
      private bool n505DocTipoDelData ;
      private bool n506DocTipoDelHora ;
      private bool n507DocTipoDelUsuID ;
      private bool n508DocTipoDelUsuNome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private string A508DocTipoDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000S2_A146DocTipoID ;
      private string[] P000S2_A147DocTipoSigla ;
      private string[] P000S2_A148DocTipoNome ;
      private bool[] P000S2_A219DocTipoAtivo ;
      private bool[] P000S2_A503DocTipoDel ;
      private DateTime[] P000S2_A504DocTipoDelDataHora ;
      private bool[] P000S2_n504DocTipoDelDataHora ;
      private DateTime[] P000S2_A505DocTipoDelData ;
      private bool[] P000S2_n505DocTipoDelData ;
      private DateTime[] P000S2_A506DocTipoDelHora ;
      private bool[] P000S2_n506DocTipoDelHora ;
      private string[] P000S2_A507DocTipoDelUsuID ;
      private bool[] P000S2_n507DocTipoDelUsuID ;
      private string[] P000S2_A508DocTipoDelUsuNome ;
      private bool[] P000S2_n508DocTipoDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtDocumentoTipo> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtDocumentoTipo AV5sdtDocumentoTipo ;
      private GeneXus.Programs.core.SdtsdtDocumentoTipo AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo ;
      private GeneXus.Programs.core.SdtsdtDocumentoTipo Gxm1sdtdocumentotipo ;
   }

   public class dpdocumentotipoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000S2( IGxContext context ,
                                             int AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo_gxTpr_Doctipoid ,
                                             int A146DocTipoID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DocTipoID, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel, DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome FROM tb_documentotipo";
         if ( ! (0==AV9Core_dsdocumentotipofiltrogeral_3_sdtdocumentotipo_gxTpr_Doctipoid) )
         {
            AddWhere(sWhereString, "(DocTipoID = :AV9Core__1Doctipoid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DocTipoID";
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
                     return conditional_P000S2(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
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
          Object[] prmP000S2;
          prmP000S2 = new Object[] {
          new ParDef("AV9Core__1Doctipoid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000S2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
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
