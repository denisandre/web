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
   public class dpcentrodecustoobterdados : GXProcedure
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

      public dpcentrodecustoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpcentrodecustoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> aP1_Gxm2rootcol )
      {
         this.AV5sdtCentroDeCusto = aP0_sdtCentroDeCusto;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto>( context, "sdtCentroDeCusto", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> executeUdp( GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto )
      {
         execute(aP0_sdtCentroDeCusto, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> aP1_Gxm2rootcol )
      {
         dpcentrodecustoobterdados objdpcentrodecustoobterdados;
         objdpcentrodecustoobterdados = new dpcentrodecustoobterdados();
         objdpcentrodecustoobterdados.AV5sdtCentroDeCusto = aP0_sdtCentroDeCusto;
         objdpcentrodecustoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto>( context, "sdtCentroDeCusto", "agl_tresorygroup") ;
         objdpcentrodecustoobterdados.context.SetSubmitInitialConfig(context);
         objdpcentrodecustoobterdados.initialize();
         Submit( executePrivateCatch,objdpcentrodecustoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpcentrodecustoobterdados)stateInfo).executePrivate();
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
         /* Using cursor P000P2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A208CcuID = P000P2_A208CcuID[0];
            A209CcuSigla = P000P2_A209CcuSigla[0];
            A210CcuNome = P000P2_A210CcuNome[0];
            A218CcuAtivo = P000P2_A218CcuAtivo[0];
            A512CcuDel = P000P2_A512CcuDel[0];
            A513CcuDelDataHora = P000P2_A513CcuDelDataHora[0];
            n513CcuDelDataHora = P000P2_n513CcuDelDataHora[0];
            A514CcuDelData = P000P2_A514CcuDelData[0];
            n514CcuDelData = P000P2_n514CcuDelData[0];
            A515CcuDelHora = P000P2_A515CcuDelHora[0];
            n515CcuDelHora = P000P2_n515CcuDelHora[0];
            A516CcuDelUsuId = P000P2_A516CcuDelUsuId[0];
            n516CcuDelUsuId = P000P2_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = P000P2_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = P000P2_n517CcuDelUsuNome[0];
            Gxm1sdtcentrodecusto = new GeneXus.Programs.core.SdtsdtCentroDeCusto(context);
            Gxm2rootcol.Add(Gxm1sdtcentrodecusto, 0);
            Gxm1sdtcentrodecusto.gxTpr_Ccuid = A208CcuID;
            Gxm1sdtcentrodecusto.gxTpr_Ccusigla = A209CcuSigla;
            Gxm1sdtcentrodecusto.gxTpr_Ccunome = A210CcuNome;
            Gxm1sdtcentrodecusto.gxTpr_Ccuativo = A218CcuAtivo;
            Gxm1sdtcentrodecusto.gxTpr_Ccudel = A512CcuDel;
            Gxm1sdtcentrodecusto.gxTpr_Ccudeldatahora = A513CcuDelDataHora;
            Gxm1sdtcentrodecusto.gxTpr_Ccudeldata = A514CcuDelData;
            Gxm1sdtcentrodecusto.gxTpr_Ccudelhora = A515CcuDelHora;
            Gxm1sdtcentrodecusto.gxTpr_Ccudelusuid = A516CcuDelUsuId;
            Gxm1sdtcentrodecusto.gxTpr_Ccudelusunome = A517CcuDelUsuNome;
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
         P000P2_A208CcuID = new int[1] ;
         P000P2_A209CcuSigla = new string[] {""} ;
         P000P2_A210CcuNome = new string[] {""} ;
         P000P2_A218CcuAtivo = new bool[] {false} ;
         P000P2_A512CcuDel = new bool[] {false} ;
         P000P2_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000P2_n513CcuDelDataHora = new bool[] {false} ;
         P000P2_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         P000P2_n514CcuDelData = new bool[] {false} ;
         P000P2_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         P000P2_n515CcuDelHora = new bool[] {false} ;
         P000P2_A516CcuDelUsuId = new string[] {""} ;
         P000P2_n516CcuDelUsuId = new bool[] {false} ;
         P000P2_A517CcuDelUsuNome = new string[] {""} ;
         P000P2_n517CcuDelUsuNome = new bool[] {false} ;
         A209CcuSigla = "";
         A210CcuNome = "";
         A513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         A514CcuDelData = (DateTime)(DateTime.MinValue);
         A515CcuDelHora = (DateTime)(DateTime.MinValue);
         A516CcuDelUsuId = "";
         A517CcuDelUsuNome = "";
         Gxm1sdtcentrodecusto = new GeneXus.Programs.core.SdtsdtCentroDeCusto(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpcentrodecustoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000P2_A208CcuID, P000P2_A209CcuSigla, P000P2_A210CcuNome, P000P2_A218CcuAtivo, P000P2_A512CcuDel, P000P2_A513CcuDelDataHora, P000P2_n513CcuDelDataHora, P000P2_A514CcuDelData, P000P2_n514CcuDelData, P000P2_A515CcuDelHora,
               P000P2_n515CcuDelHora, P000P2_A516CcuDelUsuId, P000P2_n516CcuDelUsuId, P000P2_A517CcuDelUsuNome, P000P2_n517CcuDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A208CcuID ;
      private string scmdbuf ;
      private string A516CcuDelUsuId ;
      private DateTime A513CcuDelDataHora ;
      private DateTime A514CcuDelData ;
      private DateTime A515CcuDelHora ;
      private bool A218CcuAtivo ;
      private bool A512CcuDel ;
      private bool n513CcuDelDataHora ;
      private bool n514CcuDelData ;
      private bool n515CcuDelHora ;
      private bool n516CcuDelUsuId ;
      private bool n517CcuDelUsuNome ;
      private string A209CcuSigla ;
      private string A210CcuNome ;
      private string A517CcuDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000P2_A208CcuID ;
      private string[] P000P2_A209CcuSigla ;
      private string[] P000P2_A210CcuNome ;
      private bool[] P000P2_A218CcuAtivo ;
      private bool[] P000P2_A512CcuDel ;
      private DateTime[] P000P2_A513CcuDelDataHora ;
      private bool[] P000P2_n513CcuDelDataHora ;
      private DateTime[] P000P2_A514CcuDelData ;
      private bool[] P000P2_n514CcuDelData ;
      private DateTime[] P000P2_A515CcuDelHora ;
      private bool[] P000P2_n515CcuDelHora ;
      private string[] P000P2_A516CcuDelUsuId ;
      private bool[] P000P2_n516CcuDelUsuId ;
      private string[] P000P2_A517CcuDelUsuNome ;
      private bool[] P000P2_n517CcuDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtCentroDeCusto> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtCentroDeCusto AV5sdtCentroDeCusto ;
      private GeneXus.Programs.core.SdtsdtCentroDeCusto Gxm1sdtcentrodecusto ;
   }

   public class dpcentrodecustoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP000P2;
          prmP000P2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000P2", "SELECT CcuID, CcuSigla, CcuNome, CcuAtivo, CcuDel, CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome FROM tb_centrodecusto ORDER BY CcuID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000P2,100, GxCacheFrequency.OFF ,false,false )
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
