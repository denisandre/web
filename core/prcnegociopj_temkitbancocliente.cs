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
   public class prcnegociopj_temkitbancocliente : GXProcedure
   {
      public prcnegociopj_temkitbancocliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopj_temkitbancocliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID ,
                           out bool aP2_HasKitBancoCliente )
      {
         this.AV8DocOrigem = aP0_DocOrigem;
         this.AV9DocOrigemID = aP1_DocOrigemID;
         this.AV10HasKitBancoCliente = false ;
         initialize();
         executePrivate();
         aP2_HasKitBancoCliente=this.AV10HasKitBancoCliente;
      }

      public bool executeUdp( string aP0_DocOrigem ,
                              string aP1_DocOrigemID )
      {
         execute(aP0_DocOrigem, aP1_DocOrigemID, out aP2_HasKitBancoCliente);
         return AV10HasKitBancoCliente ;
      }

      public void executeSubmit( string aP0_DocOrigem ,
                                 string aP1_DocOrigemID ,
                                 out bool aP2_HasKitBancoCliente )
      {
         prcnegociopj_temkitbancocliente objprcnegociopj_temkitbancocliente;
         objprcnegociopj_temkitbancocliente = new prcnegociopj_temkitbancocliente();
         objprcnegociopj_temkitbancocliente.AV8DocOrigem = aP0_DocOrigem;
         objprcnegociopj_temkitbancocliente.AV9DocOrigemID = aP1_DocOrigemID;
         objprcnegociopj_temkitbancocliente.AV10HasKitBancoCliente = false ;
         objprcnegociopj_temkitbancocliente.context.SetSubmitInitialConfig(context);
         objprcnegociopj_temkitbancocliente.initialize();
         Submit( executePrivateCatch,objprcnegociopj_temkitbancocliente);
         aP2_HasKitBancoCliente=this.AV10HasKitBancoCliente;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopj_temkitbancocliente)stateInfo).executePrivate();
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
         AV10HasKitBancoCliente = false;
         /* Using cursor P007S2 */
         pr_default.execute(0, new Object[] {AV8DocOrigem, AV9DocOrigemID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146DocTipoID = P007S2_A146DocTipoID[0];
            A147DocTipoSigla = P007S2_A147DocTipoSigla[0];
            A291DocOrigemID = P007S2_A291DocOrigemID[0];
            A290DocOrigem = P007S2_A290DocOrigem[0];
            A289DocID = P007S2_A289DocID[0];
            A147DocTipoSigla = P007S2_A147DocTipoSigla[0];
            AV10HasKitBancoCliente = true;
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
         P007S2_A146DocTipoID = new int[1] ;
         P007S2_A147DocTipoSigla = new string[] {""} ;
         P007S2_A291DocOrigemID = new string[] {""} ;
         P007S2_A290DocOrigem = new string[] {""} ;
         P007S2_A289DocID = new Guid[] {Guid.Empty} ;
         A147DocTipoSigla = "";
         A291DocOrigemID = "";
         A290DocOrigem = "";
         A289DocID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopj_temkitbancocliente__default(),
            new Object[][] {
                new Object[] {
               P007S2_A146DocTipoID, P007S2_A147DocTipoSigla, P007S2_A291DocOrigemID, P007S2_A290DocOrigem, P007S2_A289DocID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A146DocTipoID ;
      private string scmdbuf ;
      private bool AV10HasKitBancoCliente ;
      private string AV8DocOrigem ;
      private string AV9DocOrigemID ;
      private string A147DocTipoSigla ;
      private string A291DocOrigemID ;
      private string A290DocOrigem ;
      private Guid A289DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P007S2_A146DocTipoID ;
      private string[] P007S2_A147DocTipoSigla ;
      private string[] P007S2_A291DocOrigemID ;
      private string[] P007S2_A290DocOrigem ;
      private Guid[] P007S2_A289DocID ;
      private bool aP2_HasKitBancoCliente ;
   }

   public class prcnegociopj_temkitbancocliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007S2;
          prmP007S2 = new Object[] {
          new ParDef("AV8DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV9DocOrigemID",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007S2", "SELECT T1.DocTipoID, T2.DocTipoSigla, T1.DocOrigemID, T1.DocOrigem, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID) WHERE (T1.DocOrigem = ( :AV8DocOrigem) and T1.DocOrigemID = ( :AV9DocOrigemID)) AND (UPPER(T2.DocTipoSigla) = ( 'KITBANCOCLIENTE')) ORDER BY T1.DocOrigem, T1.DocOrigemID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007S2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
