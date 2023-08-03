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
   public class dpvisitatipoobterdados : GXProcedure
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

      public dpvisitatipoobterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dpvisitatipoobterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtVisitaTipo aP0_sdtVisitaTipo ,
                           out GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> aP1_Gxm2rootcol )
      {
         this.AV5sdtVisitaTipo = aP0_sdtVisitaTipo;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo>( context, "sdtVisitaTipo", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> executeUdp( GeneXus.Programs.core.SdtsdtVisitaTipo aP0_sdtVisitaTipo )
      {
         execute(aP0_sdtVisitaTipo, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtVisitaTipo aP0_sdtVisitaTipo ,
                                 out GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> aP1_Gxm2rootcol )
      {
         dpvisitatipoobterdados objdpvisitatipoobterdados;
         objdpvisitatipoobterdados = new dpvisitatipoobterdados();
         objdpvisitatipoobterdados.AV5sdtVisitaTipo = aP0_sdtVisitaTipo;
         objdpvisitatipoobterdados.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo>( context, "sdtVisitaTipo", "agl_tresorygroup") ;
         objdpvisitatipoobterdados.context.SetSubmitInitialConfig(context);
         objdpvisitatipoobterdados.initialize();
         Submit( executePrivateCatch,objdpvisitatipoobterdados);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpvisitatipoobterdados)stateInfo).executePrivate();
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
         AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo = AV5sdtVisitaTipo;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo.gxTpr_Vitid ,
                                              A411VitID } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P000W2 */
         pr_default.execute(0, new Object[] {AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo.gxTpr_Vitid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A411VitID = P000W2_A411VitID[0];
            A412VitSigla = P000W2_A412VitSigla[0];
            A413VitNome = P000W2_A413VitNome[0];
            A596VitDel = P000W2_A596VitDel[0];
            A597VitDelDataHora = P000W2_A597VitDelDataHora[0];
            n597VitDelDataHora = P000W2_n597VitDelDataHora[0];
            A598VitDelData = P000W2_A598VitDelData[0];
            n598VitDelData = P000W2_n598VitDelData[0];
            A599VitDelHora = P000W2_A599VitDelHora[0];
            n599VitDelHora = P000W2_n599VitDelHora[0];
            A600VitDelUsuId = P000W2_A600VitDelUsuId[0];
            n600VitDelUsuId = P000W2_n600VitDelUsuId[0];
            A601VitDelUsuNome = P000W2_A601VitDelUsuNome[0];
            n601VitDelUsuNome = P000W2_n601VitDelUsuNome[0];
            Gxm1sdtvisitatipo = new GeneXus.Programs.core.SdtsdtVisitaTipo(context);
            Gxm2rootcol.Add(Gxm1sdtvisitatipo, 0);
            Gxm1sdtvisitatipo.gxTpr_Vitid = A411VitID;
            Gxm1sdtvisitatipo.gxTpr_Vitsigla = A412VitSigla;
            Gxm1sdtvisitatipo.gxTpr_Vitnome = A413VitNome;
            Gxm1sdtvisitatipo.gxTpr_Vitdel = A596VitDel;
            Gxm1sdtvisitatipo.gxTpr_Vitdeldatahora = A597VitDelDataHora;
            Gxm1sdtvisitatipo.gxTpr_Vitdeldata = A598VitDelData;
            Gxm1sdtvisitatipo.gxTpr_Vitdelhora = A599VitDelHora;
            Gxm1sdtvisitatipo.gxTpr_Vitdelusuid = A600VitDelUsuId;
            Gxm1sdtvisitatipo.gxTpr_Vitdelusunome = A601VitDelUsuNome;
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
         AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo = new GeneXus.Programs.core.SdtsdtVisitaTipo(context);
         scmdbuf = "";
         P000W2_A411VitID = new int[1] ;
         P000W2_A412VitSigla = new string[] {""} ;
         P000W2_A413VitNome = new string[] {""} ;
         P000W2_A596VitDel = new bool[] {false} ;
         P000W2_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P000W2_n597VitDelDataHora = new bool[] {false} ;
         P000W2_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         P000W2_n598VitDelData = new bool[] {false} ;
         P000W2_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         P000W2_n599VitDelHora = new bool[] {false} ;
         P000W2_A600VitDelUsuId = new string[] {""} ;
         P000W2_n600VitDelUsuId = new bool[] {false} ;
         P000W2_A601VitDelUsuNome = new string[] {""} ;
         P000W2_n601VitDelUsuNome = new bool[] {false} ;
         A412VitSigla = "";
         A413VitNome = "";
         A597VitDelDataHora = (DateTime)(DateTime.MinValue);
         A598VitDelData = (DateTime)(DateTime.MinValue);
         A599VitDelHora = (DateTime)(DateTime.MinValue);
         A600VitDelUsuId = "";
         A601VitDelUsuNome = "";
         Gxm1sdtvisitatipo = new GeneXus.Programs.core.SdtsdtVisitaTipo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.dpvisitatipoobterdados__default(),
            new Object[][] {
                new Object[] {
               P000W2_A411VitID, P000W2_A412VitSigla, P000W2_A413VitNome, P000W2_A596VitDel, P000W2_A597VitDelDataHora, P000W2_n597VitDelDataHora, P000W2_A598VitDelData, P000W2_n598VitDelData, P000W2_A599VitDelHora, P000W2_n599VitDelHora,
               P000W2_A600VitDelUsuId, P000W2_n600VitDelUsuId, P000W2_A601VitDelUsuNome, P000W2_n601VitDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo_gxTpr_Vitid ;
      private int A411VitID ;
      private string scmdbuf ;
      private string A600VitDelUsuId ;
      private DateTime A597VitDelDataHora ;
      private DateTime A598VitDelData ;
      private DateTime A599VitDelHora ;
      private bool A596VitDel ;
      private bool n597VitDelDataHora ;
      private bool n598VitDelData ;
      private bool n599VitDelHora ;
      private bool n600VitDelUsuId ;
      private bool n601VitDelUsuNome ;
      private string A412VitSigla ;
      private string A413VitNome ;
      private string A601VitDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000W2_A411VitID ;
      private string[] P000W2_A412VitSigla ;
      private string[] P000W2_A413VitNome ;
      private bool[] P000W2_A596VitDel ;
      private DateTime[] P000W2_A597VitDelDataHora ;
      private bool[] P000W2_n597VitDelDataHora ;
      private DateTime[] P000W2_A598VitDelData ;
      private bool[] P000W2_n598VitDelData ;
      private DateTime[] P000W2_A599VitDelHora ;
      private bool[] P000W2_n599VitDelHora ;
      private string[] P000W2_A600VitDelUsuId ;
      private bool[] P000W2_n600VitDelUsuId ;
      private string[] P000W2_A601VitDelUsuNome ;
      private bool[] P000W2_n601VitDelUsuNome ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.core.SdtsdtVisitaTipo> Gxm2rootcol ;
      private GeneXus.Programs.core.SdtsdtVisitaTipo AV5sdtVisitaTipo ;
      private GeneXus.Programs.core.SdtsdtVisitaTipo AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo ;
      private GeneXus.Programs.core.SdtsdtVisitaTipo Gxm1sdtvisitatipo ;
   }

   public class dpvisitatipoobterdados__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000W2( IGxContext context ,
                                             int AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo_gxTpr_Vitid ,
                                             int A411VitID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT VitID, VitSigla, VitNome, VitDel, VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome FROM tb_visitatipo";
         if ( ! (0==AV9Core_dsvisitatipofiltrogeral_3_sdtvisitatipo_gxTpr_Vitid) )
         {
            AddWhere(sWhereString, "(VitID = :AV9Core__1Vitid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY VitID";
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
                     return conditional_P000W2(context, (int)dynConstraints[0] , (int)dynConstraints[1] );
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
          Object[] prmP000W2;
          prmP000W2 = new Object[] {
          new ParDef("AV9Core__1Vitid",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
