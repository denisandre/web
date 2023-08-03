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
   public class prcnegociopj_temndaassinado : GXProcedure
   {
      public prcnegociopj_temndaassinado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopj_temndaassinado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID ,
                           out bool aP2_HasNDA )
      {
         this.AV8DocOrigem = aP0_DocOrigem;
         this.AV9DocOrigemID = aP1_DocOrigemID;
         this.AV10HasNDA = false ;
         initialize();
         executePrivate();
         aP2_HasNDA=this.AV10HasNDA;
      }

      public bool executeUdp( string aP0_DocOrigem ,
                              string aP1_DocOrigemID )
      {
         execute(aP0_DocOrigem, aP1_DocOrigemID, out aP2_HasNDA);
         return AV10HasNDA ;
      }

      public void executeSubmit( string aP0_DocOrigem ,
                                 string aP1_DocOrigemID ,
                                 out bool aP2_HasNDA )
      {
         prcnegociopj_temndaassinado objprcnegociopj_temndaassinado;
         objprcnegociopj_temndaassinado = new prcnegociopj_temndaassinado();
         objprcnegociopj_temndaassinado.AV8DocOrigem = aP0_DocOrigem;
         objprcnegociopj_temndaassinado.AV9DocOrigemID = aP1_DocOrigemID;
         objprcnegociopj_temndaassinado.AV10HasNDA = false ;
         objprcnegociopj_temndaassinado.context.SetSubmitInitialConfig(context);
         objprcnegociopj_temndaassinado.initialize();
         Submit( executePrivateCatch,objprcnegociopj_temndaassinado);
         aP2_HasNDA=this.AV10HasNDA;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopj_temndaassinado)stateInfo).executePrivate();
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
         AV10HasNDA = false;
         /* Using cursor P006U2 */
         pr_default.execute(0, new Object[] {AV8DocOrigem, AV9DocOrigemID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146DocTipoID = P006U2_A146DocTipoID[0];
            A147DocTipoSigla = P006U2_A147DocTipoSigla[0];
            A481DocAssinado = P006U2_A481DocAssinado[0];
            A480DocContrato = P006U2_A480DocContrato[0];
            A291DocOrigemID = P006U2_A291DocOrigemID[0];
            A290DocOrigem = P006U2_A290DocOrigem[0];
            A289DocID = P006U2_A289DocID[0];
            A147DocTipoSigla = P006U2_A147DocTipoSigla[0];
            AV10HasNDA = true;
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
         P006U2_A146DocTipoID = new int[1] ;
         P006U2_A147DocTipoSigla = new string[] {""} ;
         P006U2_A481DocAssinado = new bool[] {false} ;
         P006U2_A480DocContrato = new bool[] {false} ;
         P006U2_A291DocOrigemID = new string[] {""} ;
         P006U2_A290DocOrigem = new string[] {""} ;
         P006U2_A289DocID = new Guid[] {Guid.Empty} ;
         A147DocTipoSigla = "";
         A291DocOrigemID = "";
         A290DocOrigem = "";
         A289DocID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopj_temndaassinado__default(),
            new Object[][] {
                new Object[] {
               P006U2_A146DocTipoID, P006U2_A147DocTipoSigla, P006U2_A481DocAssinado, P006U2_A480DocContrato, P006U2_A291DocOrigemID, P006U2_A290DocOrigem, P006U2_A289DocID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A146DocTipoID ;
      private string scmdbuf ;
      private bool AV10HasNDA ;
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
      private int[] P006U2_A146DocTipoID ;
      private string[] P006U2_A147DocTipoSigla ;
      private bool[] P006U2_A481DocAssinado ;
      private bool[] P006U2_A480DocContrato ;
      private string[] P006U2_A291DocOrigemID ;
      private string[] P006U2_A290DocOrigem ;
      private Guid[] P006U2_A289DocID ;
      private bool aP2_HasNDA ;
   }

   public class prcnegociopj_temndaassinado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006U2;
          prmP006U2 = new Object[] {
          new ParDef("AV8DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV9DocOrigemID",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006U2", "SELECT T1.DocTipoID, T2.DocTipoSigla, T1.DocAssinado, T1.DocContrato, T1.DocOrigemID, T1.DocOrigem, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID) WHERE (T1.DocOrigem = ( :AV8DocOrigem) and T1.DocOrigemID = ( :AV9DocOrigemID)) AND (UPPER(T2.DocTipoSigla) = ( 'NDA')) AND (T1.DocContrato = TRUE) AND (T1.DocAssinado = TRUE) ORDER BY T1.DocOrigem, T1.DocOrigemID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
