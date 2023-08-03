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
   public class prcarquivodownload : GXProcedure
   {
      public prcarquivodownload( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcarquivodownload( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_DocID ,
                           short aP1_DocArqSeq ,
                           out string aP2_UrlDownload )
      {
         this.AV8DocID = aP0_DocID;
         this.AV10DocArqSeq = aP1_DocArqSeq;
         this.AV11UrlDownload = "" ;
         initialize();
         executePrivate();
         aP2_UrlDownload=this.AV11UrlDownload;
      }

      public string executeUdp( Guid aP0_DocID ,
                                short aP1_DocArqSeq )
      {
         execute(aP0_DocID, aP1_DocArqSeq, out aP2_UrlDownload);
         return AV11UrlDownload ;
      }

      public void executeSubmit( Guid aP0_DocID ,
                                 short aP1_DocArqSeq ,
                                 out string aP2_UrlDownload )
      {
         prcarquivodownload objprcarquivodownload;
         objprcarquivodownload = new prcarquivodownload();
         objprcarquivodownload.AV8DocID = aP0_DocID;
         objprcarquivodownload.AV10DocArqSeq = aP1_DocArqSeq;
         objprcarquivodownload.AV11UrlDownload = "" ;
         objprcarquivodownload.context.SetSubmitInitialConfig(context);
         objprcarquivodownload.initialize();
         Submit( executePrivateCatch,objprcarquivodownload);
         aP2_UrlDownload=this.AV11UrlDownload;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcarquivodownload)stateInfo).executePrivate();
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
         AV11UrlDownload = "";
         /* Using cursor P006S2 */
         pr_default.execute(0, new Object[] {AV8DocID, AV10DocArqSeq});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A307DocArqSeq = P006S2_A307DocArqSeq[0];
            A289DocID = P006S2_A289DocID[0];
            A322DocArqConteudoNome = P006S2_A322DocArqConteudoNome[0];
            A323DocArqConteudoExtensao = P006S2_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo = P006S2_A321DocArqConteudo[0];
            n321DocArqConteudo = P006S2_n321DocArqConteudo[0];
            AV11UrlDownload = context.PathToUrl( A321DocArqConteudo);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV11UrlDownload = "";
         scmdbuf = "";
         P006S2_A307DocArqSeq = new short[1] ;
         P006S2_A289DocID = new Guid[] {Guid.Empty} ;
         P006S2_A322DocArqConteudoNome = new string[] {""} ;
         P006S2_A323DocArqConteudoExtensao = new string[] {""} ;
         P006S2_A321DocArqConteudo = new string[] {""} ;
         P006S2_n321DocArqConteudo = new bool[] {false} ;
         A289DocID = Guid.Empty;
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A321DocArqConteudo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcarquivodownload__default(),
            new Object[][] {
                new Object[] {
               P006S2_A307DocArqSeq, P006S2_A289DocID, P006S2_A322DocArqConteudoNome, P006S2_A323DocArqConteudoExtensao, P006S2_A321DocArqConteudo, P006S2_n321DocArqConteudo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10DocArqSeq ;
      private short A307DocArqSeq ;
      private string scmdbuf ;
      private bool n321DocArqConteudo ;
      private string AV11UrlDownload ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private Guid AV8DocID ;
      private Guid A289DocID ;
      private string A321DocArqConteudo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006S2_A307DocArqSeq ;
      private Guid[] P006S2_A289DocID ;
      private string[] P006S2_A322DocArqConteudoNome ;
      private string[] P006S2_A323DocArqConteudoExtensao ;
      private string[] P006S2_A321DocArqConteudo ;
      private bool[] P006S2_n321DocArqConteudo ;
      private string aP2_UrlDownload ;
   }

   public class prcarquivodownload__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006S2;
          prmP006S2 = new Object[] {
          new ParDef("AV8DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10DocArqSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006S2", "SELECT DocArqSeq, DocID, DocArqConteudoNome, DocArqConteudoExtensao, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :AV8DocID and DocArqSeq = :AV10DocArqSeq ORDER BY DocID, DocArqSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getBLOBFile(5, rslt.getVarchar(4), rslt.getVarchar(3));
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
