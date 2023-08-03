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
   public class parametrogeral : GXProcedure
   {
      public parametrogeral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametrogeral( IGxContext context )
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
         parametrogeral objparametrogeral;
         objparametrogeral = new parametrogeral();
         objparametrogeral.context.SetSubmitInitialConfig(context);
         objparametrogeral.initialize();
         Submit( executePrivateCatch,objparametrogeral);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((parametrogeral)stateInfo).executePrivate();
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
         this.cleanup();
      }

      public void gxep_get( string aP0_Chave ,
                            out string aP1_Valor )
      {
         this.AV9Chave = aP0_Chave;
         this.AV10Valor = "" ;
         initialize();
         /* Get Constructor */
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9Chave))) )
         {
            /* Using cursor P006B2 */
            pr_default.execute(0, new Object[] {AV9Chave});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A342ParametroChave = P006B2_A342ParametroChave[0];
               A343ParametroValor = P006B2_A343ParametroValor[0];
               n343ParametroValor = P006B2_n343ParametroValor[0];
               OV10Valor = AV10Valor;
               AV10Valor = A343ParametroValor;
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         executePrivate();
         aP1_Valor=this.AV10Valor;
         this.cleanup();
      }

      public void gxep_set( string aP0_Chave ,
                            string aP1_Descricao ,
                            string aP2_Valor )
      {
         this.AV9Chave = aP0_Chave;
         this.AV11Descricao = aP1_Descricao;
         this.AV10Valor = aP2_Valor;
         initialize();
         /* Set Constructor */
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9Chave))) )
         {
            AV13GXLvl17 = 0;
            /* Using cursor P006B3 */
            pr_default.execute(1, new Object[] {AV9Chave});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A342ParametroChave = P006B3_A342ParametroChave[0];
               A344ParametroDescricao = P006B3_A344ParametroDescricao[0];
               n344ParametroDescricao = P006B3_n344ParametroDescricao[0];
               A343ParametroValor = P006B3_A343ParametroValor[0];
               n343ParametroValor = P006B3_n343ParametroValor[0];
               AV13GXLvl17 = 1;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11Descricao))) )
               {
                  A344ParametroDescricao = AV11Descricao;
                  n344ParametroDescricao = false;
               }
               A343ParametroValor = AV10Valor;
               n343ParametroValor = false;
               /* Using cursor P006B4 */
               pr_default.execute(2, new Object[] {n344ParametroDescricao, A344ParametroDescricao, n343ParametroValor, A343ParametroValor, A342ParametroChave});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV13GXLvl17 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE tb_parametro

               */
               A342ParametroChave = StringUtil.Trim( StringUtil.Lower( AV9Chave));
               A344ParametroDescricao = AV11Descricao;
               n344ParametroDescricao = false;
               A343ParametroValor = AV10Valor;
               n343ParametroValor = false;
               /* Using cursor P006B5 */
               pr_default.execute(3, new Object[] {A342ParametroChave, n343ParametroValor, A343ParametroValor, n344ParametroDescricao, A344ParametroDescricao});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
               if ( (pr_default.getStatus(3) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
            }
            context.CommitDataStores("core.parametrogeral",pr_default);
         }
         executePrivate();
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
         P006B2_A342ParametroChave = new string[] {""} ;
         P006B2_A343ParametroValor = new string[] {""} ;
         P006B2_n343ParametroValor = new bool[] {false} ;
         A342ParametroChave = "";
         A343ParametroValor = "";
         OV10Valor = "";
         P006B3_A342ParametroChave = new string[] {""} ;
         P006B3_A344ParametroDescricao = new string[] {""} ;
         P006B3_n344ParametroDescricao = new bool[] {false} ;
         P006B3_A343ParametroValor = new string[] {""} ;
         P006B3_n343ParametroValor = new bool[] {false} ;
         A344ParametroDescricao = "";
         Gx_emsg = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.parametrogeral__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.parametrogeral__default(),
            new Object[][] {
                new Object[] {
               P006B2_A342ParametroChave, P006B2_A343ParametroValor, P006B2_n343ParametroValor
               }
               , new Object[] {
               P006B3_A342ParametroChave, P006B3_A344ParametroDescricao, P006B3_n344ParametroDescricao, P006B3_A343ParametroValor, P006B3_n343ParametroValor
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13GXLvl17 ;
      private int GX_INS36 ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private bool n343ParametroValor ;
      private bool n344ParametroDescricao ;
      private string AV9Chave ;
      private string AV10Valor ;
      private string A342ParametroChave ;
      private string A343ParametroValor ;
      private string OV10Valor ;
      private string AV11Descricao ;
      private string A344ParametroDescricao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006B2_A342ParametroChave ;
      private string[] P006B2_A343ParametroValor ;
      private bool[] P006B2_n343ParametroValor ;
      private string[] P006B3_A342ParametroChave ;
      private string[] P006B3_A344ParametroDescricao ;
      private bool[] P006B3_n344ParametroDescricao ;
      private string[] P006B3_A343ParametroValor ;
      private bool[] P006B3_n343ParametroValor ;
      private IDataStoreProvider pr_gam ;
   }

   public class parametrogeral__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class parametrogeral__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP006B2;
        prmP006B2 = new Object[] {
        new ParDef("AV9Chave",GXType.VarChar,100,0)
        };
        Object[] prmP006B3;
        prmP006B3 = new Object[] {
        new ParDef("AV9Chave",GXType.VarChar,100,0)
        };
        Object[] prmP006B4;
        prmP006B4 = new Object[] {
        new ParDef("ParametroDescricao",GXType.VarChar,500,0){Nullable=true} ,
        new ParDef("ParametroValor",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmP006B5;
        prmP006B5 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0) ,
        new ParDef("ParametroValor",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("ParametroDescricao",GXType.VarChar,500,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("P006B2", "SELECT ParametroChave, ParametroValor FROM tb_parametro WHERE RTRIM(LTRIM(LOWER(ParametroChave))) = ( RTRIM(LTRIM(LOWER(:AV9Chave)))) ORDER BY ParametroChave ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B2,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P006B3", "SELECT ParametroChave, ParametroDescricao, ParametroValor FROM tb_parametro WHERE RTRIM(LTRIM(LOWER(ParametroChave))) = ( RTRIM(LTRIM(LOWER(:AV9Chave)))) ORDER BY ParametroChave  FOR UPDATE OF tb_parametro",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P006B4", "SAVEPOINT gxupdate;UPDATE tb_parametro SET ParametroDescricao=:ParametroDescricao, ParametroValor=:ParametroValor  WHERE ParametroChave = :ParametroChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP006B4)
           ,new CursorDef("P006B5", "SAVEPOINT gxupdate;INSERT INTO tb_parametro(ParametroChave, ParametroValor, ParametroDescricao, ParametroDel, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome) VALUES(:ParametroChave, :ParametroValor, :ParametroDescricao, FALSE, DATE '00010101', DATE '00010101', DATE '00010101', '', '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP006B5)
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
     }
  }

}

}
