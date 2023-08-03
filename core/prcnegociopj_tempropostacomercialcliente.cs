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
   public class prcnegociopj_tempropostacomercialcliente : GXProcedure
   {
      public prcnegociopj_tempropostacomercialcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopj_tempropostacomercialcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID ,
                           out bool aP2_HasPropComerCliente )
      {
         this.AV8DocOrigem = aP0_DocOrigem;
         this.AV9DocOrigemID = aP1_DocOrigemID;
         this.AV10HasPropComerCliente = false ;
         initialize();
         executePrivate();
         aP2_HasPropComerCliente=this.AV10HasPropComerCliente;
      }

      public bool executeUdp( string aP0_DocOrigem ,
                              string aP1_DocOrigemID )
      {
         execute(aP0_DocOrigem, aP1_DocOrigemID, out aP2_HasPropComerCliente);
         return AV10HasPropComerCliente ;
      }

      public void executeSubmit( string aP0_DocOrigem ,
                                 string aP1_DocOrigemID ,
                                 out bool aP2_HasPropComerCliente )
      {
         prcnegociopj_tempropostacomercialcliente objprcnegociopj_tempropostacomercialcliente;
         objprcnegociopj_tempropostacomercialcliente = new prcnegociopj_tempropostacomercialcliente();
         objprcnegociopj_tempropostacomercialcliente.AV8DocOrigem = aP0_DocOrigem;
         objprcnegociopj_tempropostacomercialcliente.AV9DocOrigemID = aP1_DocOrigemID;
         objprcnegociopj_tempropostacomercialcliente.AV10HasPropComerCliente = false ;
         objprcnegociopj_tempropostacomercialcliente.context.SetSubmitInitialConfig(context);
         objprcnegociopj_tempropostacomercialcliente.initialize();
         Submit( executePrivateCatch,objprcnegociopj_tempropostacomercialcliente);
         aP2_HasPropComerCliente=this.AV10HasPropComerCliente;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopj_tempropostacomercialcliente)stateInfo).executePrivate();
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
         AV10HasPropComerCliente = false;
         /* Using cursor P00822 */
         pr_default.execute(0, new Object[] {AV8DocOrigem, AV9DocOrigemID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146DocTipoID = P00822_A146DocTipoID[0];
            A147DocTipoSigla = P00822_A147DocTipoSigla[0];
            A640DocAtivo = P00822_A640DocAtivo[0];
            n640DocAtivo = P00822_n640DocAtivo[0];
            A481DocAssinado = P00822_A481DocAssinado[0];
            A480DocContrato = P00822_A480DocContrato[0];
            A291DocOrigemID = P00822_A291DocOrigemID[0];
            A290DocOrigem = P00822_A290DocOrigem[0];
            A289DocID = P00822_A289DocID[0];
            A147DocTipoSigla = P00822_A147DocTipoSigla[0];
            AV10HasPropComerCliente = true;
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
         P00822_A146DocTipoID = new int[1] ;
         P00822_A147DocTipoSigla = new string[] {""} ;
         P00822_A640DocAtivo = new bool[] {false} ;
         P00822_n640DocAtivo = new bool[] {false} ;
         P00822_A481DocAssinado = new bool[] {false} ;
         P00822_A480DocContrato = new bool[] {false} ;
         P00822_A291DocOrigemID = new string[] {""} ;
         P00822_A290DocOrigem = new string[] {""} ;
         P00822_A289DocID = new Guid[] {Guid.Empty} ;
         A147DocTipoSigla = "";
         A291DocOrigemID = "";
         A290DocOrigem = "";
         A289DocID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopj_tempropostacomercialcliente__default(),
            new Object[][] {
                new Object[] {
               P00822_A146DocTipoID, P00822_A147DocTipoSigla, P00822_A640DocAtivo, P00822_n640DocAtivo, P00822_A481DocAssinado, P00822_A480DocContrato, P00822_A291DocOrigemID, P00822_A290DocOrigem, P00822_A289DocID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A146DocTipoID ;
      private string scmdbuf ;
      private bool AV10HasPropComerCliente ;
      private bool A640DocAtivo ;
      private bool n640DocAtivo ;
      private bool A481DocAssinado ;
      private bool A480DocContrato ;
      private string AV8DocOrigem ;
      private string AV9DocOrigemID ;
      private string A147DocTipoSigla ;
      private string A291DocOrigemID ;
      private string A290DocOrigem ;
      private Guid A289DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00822_A146DocTipoID ;
      private string[] P00822_A147DocTipoSigla ;
      private bool[] P00822_A640DocAtivo ;
      private bool[] P00822_n640DocAtivo ;
      private bool[] P00822_A481DocAssinado ;
      private bool[] P00822_A480DocContrato ;
      private string[] P00822_A291DocOrigemID ;
      private string[] P00822_A290DocOrigem ;
      private Guid[] P00822_A289DocID ;
      private bool aP2_HasPropComerCliente ;
   }

   public class prcnegociopj_tempropostacomercialcliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00822;
          prmP00822 = new Object[] {
          new ParDef("AV8DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV9DocOrigemID",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "SELECT T1.DocTipoID, T2.DocTipoSigla, T1.DocAtivo, T1.DocAssinado, T1.DocContrato, T1.DocOrigemID, T1.DocOrigem, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID) WHERE (T1.DocOrigem = ( :AV8DocOrigem) and T1.DocOrigemID = ( :AV9DocOrigemID)) AND (UPPER(T2.DocTipoSigla) = ( 'PROPCOMERCLIENTE')) AND (T1.DocContrato = TRUE) AND (T1.DocAssinado = TRUE) AND (T1.DocAtivo = TRUE) ORDER BY T1.DocOrigem, T1.DocOrigemID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((Guid[]) buf[8])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
