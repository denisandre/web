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
   public class tb_negociopj_itemconversion : GXProcedure
   {
      public tb_negociopj_itemconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_negociopj_itemconversion( IGxContext context )
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
         tb_negociopj_itemconversion objtb_negociopj_itemconversion;
         objtb_negociopj_itemconversion = new tb_negociopj_itemconversion();
         objtb_negociopj_itemconversion.context.SetSubmitInitialConfig(context);
         objtb_negociopj_itemconversion.initialize();
         Submit( executePrivateCatch,objtb_negociopj_itemconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_negociopj_itemconversion)stateInfo).executePrivate();
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
            A459NgpInsUsuNome = TB_NEGOCIO2_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = TB_NEGOCIO2_n459NgpInsUsuNome[0];
            A458NgpInsUsuID = TB_NEGOCIO2_A458NgpInsUsuID[0];
            n458NgpInsUsuID = TB_NEGOCIO2_n458NgpInsUsuID[0];
            A457NgpInsDataHora = TB_NEGOCIO2_A457NgpInsDataHora[0];
            A456NgpInsHora = TB_NEGOCIO2_A456NgpInsHora[0];
            A455NgpInsData = TB_NEGOCIO2_A455NgpInsData[0];
            A453NgpObs = TB_NEGOCIO2_A453NgpObs[0];
            A447NgpTotal = TB_NEGOCIO2_A447NgpTotal[0];
            A446NgpQtde = TB_NEGOCIO2_A446NgpQtde[0];
            A445NgpPreco = TB_NEGOCIO2_A445NgpPreco[0];
            A439NgpTppPrdID = TB_NEGOCIO2_A439NgpTppPrdID[0];
            A435NgpItem = TB_NEGOCIO2_A435NgpItem[0];
            A345NegID = TB_NEGOCIO2_A345NegID[0];
            /*
               INSERT RECORD ON TABLE GXA0042

            */
            AV2NegID = A345NegID;
            AV3NgpItem = A435NgpItem;
            AV4NgpTppPrdID = A439NgpTppPrdID;
            AV5NgpPreco = A445NgpPreco;
            AV6NgpQtde = A446NgpQtde;
            AV7NgpTotal = A447NgpTotal;
            AV8NgpObs = A453NgpObs;
            AV9NgpInsData = A455NgpInsData;
            AV10NgpInsHora = A456NgpInsHora;
            AV11NgpInsDataHora = A457NgpInsDataHora;
            if ( TB_NEGOCIO2_n458NgpInsUsuID[0] )
            {
               AV12NgpInsUsuID = "";
               nV12NgpInsUsuID = false;
               nV12NgpInsUsuID = true;
            }
            else
            {
               AV12NgpInsUsuID = A458NgpInsUsuID;
               nV12NgpInsUsuID = false;
            }
            if ( TB_NEGOCIO2_n459NgpInsUsuNome[0] )
            {
               AV13NgpInsUsuNome = "";
               nV13NgpInsUsuNome = false;
               nV13NgpInsUsuNome = true;
            }
            else
            {
               AV13NgpInsUsuNome = A459NgpInsUsuNome;
               nV13NgpInsUsuNome = false;
            }
            if ( (Guid.Empty==A235TppID) )
            {
               AV14NgpTppID = Guid.Empty;
            }
            else
            {
               AV14NgpTppID = A235TppID;
            }
            /* Using cursor TB_NEGOCIO3 */
            pr_default.execute(1, new Object[] {AV2NegID, AV3NgpItem, AV4NgpTppPrdID, AV5NgpPreco, AV6NgpQtde, AV7NgpTotal, AV8NgpObs, AV9NgpInsData, AV10NgpInsHora, AV11NgpInsDataHora, nV12NgpInsUsuID, AV12NgpInsUsuID, nV13NgpInsUsuNome, AV13NgpInsUsuNome, AV14NgpTppID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0042");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TB_NEGOCIO2_A459NgpInsUsuNome = new string[] {""} ;
         TB_NEGOCIO2_n459NgpInsUsuNome = new bool[] {false} ;
         TB_NEGOCIO2_A458NgpInsUsuID = new string[] {""} ;
         TB_NEGOCIO2_n458NgpInsUsuID = new bool[] {false} ;
         TB_NEGOCIO2_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_NEGOCIO2_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         TB_NEGOCIO2_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         TB_NEGOCIO2_A453NgpObs = new string[] {""} ;
         TB_NEGOCIO2_A447NgpTotal = new decimal[1] ;
         TB_NEGOCIO2_A446NgpQtde = new int[1] ;
         TB_NEGOCIO2_A445NgpPreco = new decimal[1] ;
         TB_NEGOCIO2_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO2_A435NgpItem = new int[1] ;
         TB_NEGOCIO2_A345NegID = new Guid[] {Guid.Empty} ;
         A459NgpInsUsuNome = "";
         A458NgpInsUsuID = "";
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         A455NgpInsData = DateTime.MinValue;
         A453NgpObs = "";
         A439NgpTppPrdID = Guid.Empty;
         A345NegID = Guid.Empty;
         AV2NegID = Guid.Empty;
         AV4NgpTppPrdID = Guid.Empty;
         AV8NgpObs = "";
         AV9NgpInsData = DateTime.MinValue;
         AV10NgpInsHora = (DateTime)(DateTime.MinValue);
         AV11NgpInsDataHora = (DateTime)(DateTime.MinValue);
         AV12NgpInsUsuID = "";
         AV13NgpInsUsuNome = "";
         A235TppID = Guid.Empty;
         AV14NgpTppID = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_negociopj_itemconversion__default(),
            new Object[][] {
                new Object[] {
               TB_NEGOCIO2_A459NgpInsUsuNome, TB_NEGOCIO2_n459NgpInsUsuNome, TB_NEGOCIO2_A458NgpInsUsuID, TB_NEGOCIO2_n458NgpInsUsuID, TB_NEGOCIO2_A457NgpInsDataHora, TB_NEGOCIO2_A456NgpInsHora, TB_NEGOCIO2_A455NgpInsData, TB_NEGOCIO2_A453NgpObs, TB_NEGOCIO2_A447NgpTotal, TB_NEGOCIO2_A446NgpQtde,
               TB_NEGOCIO2_A445NgpPreco, TB_NEGOCIO2_A439NgpTppPrdID, TB_NEGOCIO2_A435NgpItem, TB_NEGOCIO2_A345NegID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A446NgpQtde ;
      private int A435NgpItem ;
      private int GIGXA0042 ;
      private int AV3NgpItem ;
      private int AV6NgpQtde ;
      private decimal A447NgpTotal ;
      private decimal A445NgpPreco ;
      private decimal AV5NgpPreco ;
      private decimal AV7NgpTotal ;
      private string scmdbuf ;
      private string A458NgpInsUsuID ;
      private string AV12NgpInsUsuID ;
      private string Gx_emsg ;
      private DateTime A457NgpInsDataHora ;
      private DateTime A456NgpInsHora ;
      private DateTime AV10NgpInsHora ;
      private DateTime AV11NgpInsDataHora ;
      private DateTime A455NgpInsData ;
      private DateTime AV9NgpInsData ;
      private bool n459NgpInsUsuNome ;
      private bool n458NgpInsUsuID ;
      private bool nV12NgpInsUsuID ;
      private bool nV13NgpInsUsuNome ;
      private string A459NgpInsUsuNome ;
      private string A453NgpObs ;
      private string AV8NgpObs ;
      private string AV13NgpInsUsuNome ;
      private Guid A439NgpTppPrdID ;
      private Guid A345NegID ;
      private Guid AV2NegID ;
      private Guid AV4NgpTppPrdID ;
      private Guid A235TppID ;
      private Guid AV14NgpTppID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TB_NEGOCIO2_A459NgpInsUsuNome ;
      private bool[] TB_NEGOCIO2_n459NgpInsUsuNome ;
      private string[] TB_NEGOCIO2_A458NgpInsUsuID ;
      private bool[] TB_NEGOCIO2_n458NgpInsUsuID ;
      private DateTime[] TB_NEGOCIO2_A457NgpInsDataHora ;
      private DateTime[] TB_NEGOCIO2_A456NgpInsHora ;
      private DateTime[] TB_NEGOCIO2_A455NgpInsData ;
      private string[] TB_NEGOCIO2_A453NgpObs ;
      private decimal[] TB_NEGOCIO2_A447NgpTotal ;
      private int[] TB_NEGOCIO2_A446NgpQtde ;
      private decimal[] TB_NEGOCIO2_A445NgpPreco ;
      private Guid[] TB_NEGOCIO2_A439NgpTppPrdID ;
      private int[] TB_NEGOCIO2_A435NgpItem ;
      private Guid[] TB_NEGOCIO2_A345NegID ;
   }

   public class tb_negociopj_itemconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("AV2NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3NgpItem",GXType.Int32,8,0) ,
          new ParDef("AV4NgpTppPrdID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV5NgpPreco",GXType.Number,16,2) ,
          new ParDef("AV6NgpQtde",GXType.Int32,8,0) ,
          new ParDef("AV7NgpTotal",GXType.Number,16,2) ,
          new ParDef("AV8NgpObs",GXType.VarChar,1000,0) ,
          new ParDef("AV9NgpInsData",GXType.Date,8,0) ,
          new ParDef("AV10NgpInsHora",GXType.DateTime,0,5) ,
          new ParDef("AV11NgpInsDataHora",GXType.DateTime2,10,12) ,
          new ParDef("AV12NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV13NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("AV14NgpTppID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_NEGOCIO2", "SELECT NgpInsUsuNome, NgpInsUsuID, NgpInsDataHora, NgpInsHora, NgpInsData, NgpObs, NgpTotal, NgpQtde, NgpPreco, NgpTppPrdID, NgpItem, NegID FROM tb_negociopj_item ORDER BY NegID, NgpItem ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_NEGOCIO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_NEGOCIO3", "INSERT INTO GXA0042(NegID, NgpItem, NgpTppPrdID, NgpPreco, NgpQtde, NgpTotal, NgpObs, NgpInsData, NgpInsHora, NgpInsDataHora, NgpInsUsuID, NgpInsUsuNome, NgpTppID) VALUES(:AV2NegID, :AV3NgpItem, :AV4NgpTppPrdID, :AV5NgpPreco, :AV6NgpQtde, :AV7NgpTotal, :AV8NgpObs, :AV9NgpInsData, :AV10NgpInsHora, :AV11NgpInsDataHora, :AV12NgpInsUsuID, :AV13NgpInsUsuNome, :AV14NgpTppID)", GxErrorMask.GX_NOMASK,prmTB_NEGOCIO3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 40);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3, true);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((Guid[]) buf[13])[0] = rslt.getGuid(12);
                return;
       }
    }

 }

}
