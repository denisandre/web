using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class tb_negociopj_faseloadredundancy : GXProcedure
   {
      public tb_negociopj_faseloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_negociopj_faseloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         tb_negociopj_faseloadredundancy objtb_negociopj_faseloadredundancy;
         objtb_negociopj_faseloadredundancy = new tb_negociopj_faseloadredundancy();
         objtb_negociopj_faseloadredundancy.context.SetSubmitInitialConfig(context);
         objtb_negociopj_faseloadredundancy.initialize();
         Submit( executePrivateCatch,objtb_negociopj_faseloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_negociopj_faseloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_NEGOCIO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A395NgfIteID = TB_NEGOCIO2_A395NgfIteID[0];
            A397NgfIteNome = TB_NEGOCIO2_A397NgfIteNome[0];
            A397NgfIteNome = TB_NEGOCIO2_A397NgfIteNome[0];
            A387NgfSeq = TB_NEGOCIO2_A387NgfSeq[0];
            A345NegID = TB_NEGOCIO2_A345NegID[0];
            O397NgfIteNome = A397NgfIteNome;
            A397NgfIteNome = TB_NEGOCIO2_A397NgfIteNome[0];
            O397NgfIteNome = A397NgfIteNome;
            A397NgfIteNome = O397NgfIteNome;
            O397NgfIteNome = A397NgfIteNome;
            /* Using cursor TB_NEGOCIO3 */
            pr_default.execute(1, new Object[] {A397NgfIteNome, A345NegID, A387NgfSeq});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fase");
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
         TB_NEGOCIO2_A395NgfIteID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO2_A397NgfIteNome = new string[] {""} ;
         TB_NEGOCIO2_A387NgfSeq = new int[1] ;
         TB_NEGOCIO2_A345NegID = new Guid[] {Guid.Empty} ;
         A395NgfIteID = Guid.Empty;
         A397NgfIteNome = "";
         A345NegID = Guid.Empty;
         O397NgfIteNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_negociopj_faseloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_NEGOCIO2_A395NgfIteID, TB_NEGOCIO2_A397NgfIteNome, TB_NEGOCIO2_A397NgfIteNome, TB_NEGOCIO2_A387NgfSeq, TB_NEGOCIO2_A345NegID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A387NgfSeq ;
      private string scmdbuf ;
      private string A397NgfIteNome ;
      private string O397NgfIteNome ;
      private Guid A395NgfIteID ;
      private Guid A345NegID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_NEGOCIO2_A395NgfIteID ;
      private string[] TB_NEGOCIO2_A397NgfIteNome ;
      private int[] TB_NEGOCIO2_A387NgfSeq ;
      private Guid[] TB_NEGOCIO2_A345NegID ;
   }

   public class tb_negociopj_faseloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTB_NEGOCIO2;
          prmTB_NEGOCIO2 = new Object[] {
          };
          Object[] prmTB_NEGOCIO3;
          prmTB_NEGOCIO3 = new Object[] {
          new ParDef("NgfIteNome",GXType.VarChar,80,0) ,
          new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NgfSeq",GXType.Int32,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_NEGOCIO2", "SELECT T1.NgfIteID AS NgfIteID, T1.NgfIteNome AS NgfIteNome, T2.IteNome AS NgfIteNome, T1.NgfSeq, T1.NegID FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) ORDER BY T1.NegID, T1.NgfSeq  FOR UPDATE OF T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_NEGOCIO2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_NEGOCIO3", "UPDATE tb_negociopj_fase SET NgfIteNome=:NgfIteNome  WHERE NegID = :NegID AND NgfSeq = :NgfSeq", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_NEGOCIO3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
