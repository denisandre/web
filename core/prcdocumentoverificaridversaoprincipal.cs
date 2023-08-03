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
   public class prcdocumentoverificaridversaoprincipal : GXProcedure
   {
      public prcdocumentoverificaridversaoprincipal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentoverificaridversaoprincipal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocIDString ,
                           out string aP1_DocIDOutString )
      {
         this.AV9DocIDString = aP0_DocIDString;
         this.AV10DocIDOutString = "" ;
         initialize();
         executePrivate();
         aP1_DocIDOutString=this.AV10DocIDOutString;
      }

      public string executeUdp( string aP0_DocIDString )
      {
         execute(aP0_DocIDString, out aP1_DocIDOutString);
         return AV10DocIDOutString ;
      }

      public void executeSubmit( string aP0_DocIDString ,
                                 out string aP1_DocIDOutString )
      {
         prcdocumentoverificaridversaoprincipal objprcdocumentoverificaridversaoprincipal;
         objprcdocumentoverificaridversaoprincipal = new prcdocumentoverificaridversaoprincipal();
         objprcdocumentoverificaridversaoprincipal.AV9DocIDString = aP0_DocIDString;
         objprcdocumentoverificaridversaoprincipal.AV10DocIDOutString = "" ;
         objprcdocumentoverificaridversaoprincipal.context.SetSubmitInitialConfig(context);
         objprcdocumentoverificaridversaoprincipal.initialize();
         Submit( executePrivateCatch,objprcdocumentoverificaridversaoprincipal);
         aP1_DocIDOutString=this.AV10DocIDOutString;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentoverificaridversaoprincipal)stateInfo).executePrivate();
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
         AV8DocID = StringUtil.StrToGuid( AV9DocIDString);
         AV11GXLvl4 = 0;
         /* Using cursor P007Z2 */
         pr_default.execute(0, new Object[] {AV8DocID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A326DocVersaoIDPai = P007Z2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007Z2_n326DocVersaoIDPai[0];
            A289DocID = P007Z2_A289DocID[0];
            AV11GXLvl4 = 1;
            AV10DocIDOutString = A326DocVersaoIDPai.ToString();
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV11GXLvl4 == 0 )
         {
            AV10DocIDOutString = AV9DocIDString;
         }
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
         AV10DocIDOutString = "";
         AV8DocID = Guid.Empty;
         scmdbuf = "";
         P007Z2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007Z2_n326DocVersaoIDPai = new bool[] {false} ;
         P007Z2_A289DocID = new Guid[] {Guid.Empty} ;
         A326DocVersaoIDPai = Guid.Empty;
         A289DocID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentoverificaridversaoprincipal__default(),
            new Object[][] {
                new Object[] {
               P007Z2_A326DocVersaoIDPai, P007Z2_n326DocVersaoIDPai, P007Z2_A289DocID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl4 ;
      private string scmdbuf ;
      private bool n326DocVersaoIDPai ;
      private string AV9DocIDString ;
      private string AV10DocIDOutString ;
      private Guid AV8DocID ;
      private Guid A326DocVersaoIDPai ;
      private Guid A289DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007Z2_A326DocVersaoIDPai ;
      private bool[] P007Z2_n326DocVersaoIDPai ;
      private Guid[] P007Z2_A289DocID ;
      private string aP1_DocIDOutString ;
   }

   public class prcdocumentoverificaridversaoprincipal__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007Z2;
          prmP007Z2 = new Object[] {
          new ParDef("AV8DocID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Z2", "SELECT DocVersaoIDPai, DocID FROM tb_documento WHERE (DocID = :AV8DocID) AND (Not (DocVersaoIDPai = '00000000-0000-0000-0000-000000000000') and Not DocVersaoIDPai IS NULL) ORDER BY DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
