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
   public class dpnegociopjfluxoobterdados : GXProcedure
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

      public dpnegociopjfluxoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpnegociopjfluxoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NegID ,
                           string aP1_NefChave ,
                           GxSimpleCollection<string> aP2_NefChaveList ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> aP3_Gxm2rootcol )
      {
         this.AV5NegID = aP0_NegID;
         this.AV6NefChave = aP1_NefChave;
         this.AV7NefChaveList = aP2_NefChaveList;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo>( context, "SDTNegocioPJFluxo", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> executeUdp( Guid aP0_NegID ,
                                                                                      string aP1_NefChave ,
                                                                                      GxSimpleCollection<string> aP2_NefChaveList )
      {
         execute(aP0_NegID, aP1_NefChave, aP2_NefChaveList, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( Guid aP0_NegID ,
                                 string aP1_NefChave ,
                                 GxSimpleCollection<string> aP2_NefChaveList ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> aP3_Gxm2rootcol )
      {
         dpnegociopjfluxoobterdados objdpnegociopjfluxoobterdados;
         objdpnegociopjfluxoobterdados = new dpnegociopjfluxoobterdados();
         objdpnegociopjfluxoobterdados.AV5NegID = aP0_NegID;
         objdpnegociopjfluxoobterdados.AV6NefChave = aP1_NefChave;
         objdpnegociopjfluxoobterdados.AV7NefChaveList = aP2_NefChaveList;
         objdpnegociopjfluxoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo>( context, "SDTNegocioPJFluxo", "agl_tresorygroup") ;
         objdpnegociopjfluxoobterdados.context.SetSubmitInitialConfig(context);
         objdpnegociopjfluxoobterdados.initialize();
         Submit( executePrivateCatch,objdpnegociopjfluxoobterdados);
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpnegociopjfluxoobterdados)stateInfo).executePrivate();
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
         AV11Core_dsnegociopjfluxofiltro_3_negid = AV5NegID;
         AV12Core_dsnegociopjfluxofiltro_4_nefchave = AV6NefChave;
         AV13Core_dsnegociopjfluxofiltro_5_nefchavelist = AV7NefChaveList;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A626NefChave ,
                                              AV13Core_dsnegociopjfluxofiltro_5_nefchavelist ,
                                              AV12Core_dsnegociopjfluxofiltro_4_nefchave ,
                                              AV13Core_dsnegociopjfluxofiltro_5_nefchavelist.Count ,
                                              AV11Core_dsnegociopjfluxofiltro_3_negid ,
                                              A345NegID } ,
                                              new int[]{
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P000M2 */
         pr_default.execute(0, new Object[] {AV11Core_dsnegociopjfluxofiltro_3_negid, AV12Core_dsnegociopjfluxofiltro_4_nefchave});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A626NefChave = P000M2_A626NefChave[0];
            A345NegID = P000M2_A345NegID[0];
            A627NefConfirmado = P000M2_A627NefConfirmado[0];
            A628NefTexto = P000M2_A628NefTexto[0];
            n628NefTexto = P000M2_n628NefTexto[0];
            A629NefInsDataHora = P000M2_A629NefInsDataHora[0];
            A630NefInsData = P000M2_A630NefInsData[0];
            A631NefInsHora = P000M2_A631NefInsHora[0];
            A632NefInsUsuId = P000M2_A632NefInsUsuId[0];
            A633NefInsUsuNome = P000M2_A633NefInsUsuNome[0];
            A634NefUpdDataHora = P000M2_A634NefUpdDataHora[0];
            n634NefUpdDataHora = P000M2_n634NefUpdDataHora[0];
            A635NefUpdData = P000M2_A635NefUpdData[0];
            n635NefUpdData = P000M2_n635NefUpdData[0];
            A636NefUpdHora = P000M2_A636NefUpdHora[0];
            n636NefUpdHora = P000M2_n636NefUpdHora[0];
            A637NefUpdUsuId = P000M2_A637NefUpdUsuId[0];
            n637NefUpdUsuId = P000M2_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = P000M2_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = P000M2_n638NefUpdUsuNome[0];
            A639NefValor = P000M2_A639NefValor[0];
            n639NefValor = P000M2_n639NefValor[0];
            Gxm1sdtnegociopjfluxo = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
            Gxm2rootcol.Add(Gxm1sdtnegociopjfluxo, 0);
            Gxm1sdtnegociopjfluxo.gxTpr_Negid = A345NegID;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefchave = A626NefChave;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefconfirmado = A627NefConfirmado;
            Gxm1sdtnegociopjfluxo.gxTpr_Neftexto = A628NefTexto;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefinsdatahora = A629NefInsDataHora;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefinsdata = A630NefInsData;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefinshora = A631NefInsHora;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefinsusuid = A632NefInsUsuId;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefinsusunome = A633NefInsUsuNome;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefupddatahora = A634NefUpdDataHora;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefupddata = A635NefUpdData;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefupdhora = A636NefUpdHora;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefupdusuid = A637NefUpdUsuId;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefupdusunome = A638NefUpdUsuNome;
            Gxm1sdtnegociopjfluxo.gxTpr_Nefvalor = A639NefValor;
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
         AV11Core_dsnegociopjfluxofiltro_3_negid = Guid.Empty;
         AV12Core_dsnegociopjfluxofiltro_4_nefchave = "";
         AV13Core_dsnegociopjfluxofiltro_5_nefchavelist = new GxSimpleCollection<string>();
         scmdbuf = "";
         A626NefChave = "";
         A345NegID = Guid.Empty;
         P000M2_A626NefChave = new string[] {""} ;
         P000M2_A345NegID = new Guid[] {Guid.Empty} ;
         P000M2_A627NefConfirmado = new bool[] {false} ;
         P000M2_A628NefTexto = new string[] {""} ;
         P000M2_n628NefTexto = new bool[] {false} ;
         P000M2_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P000M2_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         P000M2_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         P000M2_A632NefInsUsuId = new string[] {""} ;
         P000M2_A633NefInsUsuNome = new string[] {""} ;
         P000M2_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P000M2_n634NefUpdDataHora = new bool[] {false} ;
         P000M2_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         P000M2_n635NefUpdData = new bool[] {false} ;
         P000M2_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         P000M2_n636NefUpdHora = new bool[] {false} ;
         P000M2_A637NefUpdUsuId = new string[] {""} ;
         P000M2_n637NefUpdUsuId = new bool[] {false} ;
         P000M2_A638NefUpdUsuNome = new string[] {""} ;
         P000M2_n638NefUpdUsuNome = new bool[] {false} ;
         P000M2_A639NefValor = new short[1] ;
         P000M2_n639NefValor = new bool[] {false} ;
         A628NefTexto = "";
         A629NefInsDataHora = (DateTime)(DateTime.MinValue);
         A630NefInsData = (DateTime)(DateTime.MinValue);
         A631NefInsHora = (DateTime)(DateTime.MinValue);
         A632NefInsUsuId = "";
         A633NefInsUsuNome = "";
         A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         A635NefUpdData = (DateTime)(DateTime.MinValue);
         A636NefUpdHora = (DateTime)(DateTime.MinValue);
         A637NefUpdUsuId = "";
         A638NefUpdUsuNome = "";
         Gxm1sdtnegociopjfluxo = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpnegociopjfluxoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000M2_A626NefChave, P000M2_A345NegID, P000M2_A627NefConfirmado, P000M2_A628NefTexto, P000M2_n628NefTexto, P000M2_A629NefInsDataHora, P000M2_A630NefInsData, P000M2_A631NefInsHora, P000M2_A632NefInsUsuId, P000M2_A633NefInsUsuNome,
               P000M2_A634NefUpdDataHora, P000M2_n634NefUpdDataHora, P000M2_A635NefUpdData, P000M2_n635NefUpdData, P000M2_A636NefUpdHora, P000M2_n636NefUpdHora, P000M2_A637NefUpdUsuId, P000M2_n637NefUpdUsuId, P000M2_A638NefUpdUsuNome, P000M2_n638NefUpdUsuNome,
               P000M2_A639NefValor, P000M2_n639NefValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A639NefValor ;
      private int AV13Core_dsnegociopjfluxofiltro_5_nefchavelist_Count ;
      private string scmdbuf ;
      private string A632NefInsUsuId ;
      private string A637NefUpdUsuId ;
      private DateTime A629NefInsDataHora ;
      private DateTime A630NefInsData ;
      private DateTime A631NefInsHora ;
      private DateTime A634NefUpdDataHora ;
      private DateTime A635NefUpdData ;
      private DateTime A636NefUpdHora ;
      private bool A627NefConfirmado ;
      private bool n628NefTexto ;
      private bool n634NefUpdDataHora ;
      private bool n635NefUpdData ;
      private bool n636NefUpdHora ;
      private bool n637NefUpdUsuId ;
      private bool n638NefUpdUsuNome ;
      private bool n639NefValor ;
      private string AV6NefChave ;
      private string AV12Core_dsnegociopjfluxofiltro_4_nefchave ;
      private string A626NefChave ;
      private string A628NefTexto ;
      private string A633NefInsUsuNome ;
      private string A638NefUpdUsuNome ;
      private Guid AV5NegID ;
      private Guid AV11Core_dsnegociopjfluxofiltro_3_negid ;
      private Guid A345NegID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P000M2_A626NefChave ;
      private Guid[] P000M2_A345NegID ;
      private bool[] P000M2_A627NefConfirmado ;
      private string[] P000M2_A628NefTexto ;
      private bool[] P000M2_n628NefTexto ;
      private DateTime[] P000M2_A629NefInsDataHora ;
      private DateTime[] P000M2_A630NefInsData ;
      private DateTime[] P000M2_A631NefInsHora ;
      private string[] P000M2_A632NefInsUsuId ;
      private string[] P000M2_A633NefInsUsuNome ;
      private DateTime[] P000M2_A634NefUpdDataHora ;
      private bool[] P000M2_n634NefUpdDataHora ;
      private DateTime[] P000M2_A635NefUpdData ;
      private bool[] P000M2_n635NefUpdData ;
      private DateTime[] P000M2_A636NefUpdHora ;
      private bool[] P000M2_n636NefUpdHora ;
      private string[] P000M2_A637NefUpdUsuId ;
      private bool[] P000M2_n637NefUpdUsuId ;
      private string[] P000M2_A638NefUpdUsuNome ;
      private bool[] P000M2_n638NefUpdUsuNome ;
      private short[] P000M2_A639NefValor ;
      private bool[] P000M2_n639NefValor ;
      private GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> aP3_Gxm2rootcol ;
      private GxSimpleCollection<string> AV7NefChaveList ;
      private GxSimpleCollection<string> AV13Core_dsnegociopjfluxofiltro_5_nefchavelist ;
      private GXBaseCollection<GeneXus.Programs.core.SdtSDTNegocioPJFluxo> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo Gxm1sdtnegociopjfluxo ;
   }

   public class dpnegociopjfluxoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000M2( IGxContext context ,
                                             string A626NefChave ,
                                             GxSimpleCollection<string> AV13Core_dsnegociopjfluxofiltro_5_nefchavelist ,
                                             string AV12Core_dsnegociopjfluxofiltro_4_nefchave ,
                                             int AV13Core_dsnegociopjfluxofiltro_5_nefchavelist_Count ,
                                             Guid AV11Core_dsnegociopjfluxofiltro_3_negid ,
                                             Guid A345NegID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT NefChave, NegID, NefConfirmado, NefTexto, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefValor FROM tb_negociopj_fluxo";
         AddWhere(sWhereString, "(NegID = :AV11Core_dsnegociopjfluxofiltro_3_negid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Core_dsnegociopjfluxofiltro_4_nefchave)) )
         {
            AddWhere(sWhereString, "(NefChave = ( :AV12Core_dsnegociopjfluxofiltro_4_nefchave))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV13Core_dsnegociopjfluxofiltro_5_nefchavelist_Count >= 1 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13Core_dsnegociopjfluxofiltro_5_nefchavelist, "NefChave IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY NegID, NefChave";
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
                     return conditional_P000M2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (Guid)dynConstraints[4] , (Guid)dynConstraints[5] );
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
          Object[] prmP000M2;
          prmP000M2 = new Object[] {
          new ParDef("AV11Core_dsnegociopjfluxofiltro_3_negid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12Core_dsnegociopjfluxofiltro_4_nefchave",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 40);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10, true);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((short[]) buf[20])[0] = rslt.getShort(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                return;
       }
    }

 }

}
