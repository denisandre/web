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
   public class prcparametrosmanterdados : GXProcedure
   {
      public prcparametrosmanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcparametrosmanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10sdtParametros = aP0_sdtParametros;
         this.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtParametros, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtParametros aP0_sdtParametros ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcparametrosmanterdados objprcparametrosmanterdados;
         objprcparametrosmanterdados = new prcparametrosmanterdados();
         objprcparametrosmanterdados.AV10sdtParametros = aP0_sdtParametros;
         objprcparametrosmanterdados.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         objprcparametrosmanterdados.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcparametrosmanterdados.context.SetSubmitInitialConfig(context);
         objprcparametrosmanterdados.initialize();
         Submit( executePrivateCatch,objprcparametrosmanterdados);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcparametrosmanterdados)stateInfo).executePrivate();
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
         AV9Messages.Clear();
         AV11Parametros_bc.Load(AV10sdtParametros.gxTpr_Parametrochave);
         if ( AV11Parametros_bc.Fail() )
         {
            AV11Parametros_bc = new GeneXus.Programs.core.SdtParametros(context);
         }
         if ( StringUtil.StrCmp(AV11Parametros_bc.gxTpr_Parametrodescricao, AV10sdtParametros.gxTpr_Parametrodescricao) != 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10sdtParametros.gxTpr_Parametrodescricao)) )
            {
               AV11Parametros_bc.gxTv_SdtParametros_Parametrodescricao_SetNull();
            }
            else
            {
               AV11Parametros_bc.gxTpr_Parametrodescricao = AV10sdtParametros.gxTpr_Parametrodescricao;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10sdtParametros.gxTpr_Parametrodescricao)) )
            {
               AV11Parametros_bc.gxTv_SdtParametros_Parametrodescricao_SetNull();
            }
         }
         if ( StringUtil.StrCmp(AV11Parametros_bc.gxTpr_Parametrovalor, AV10sdtParametros.gxTpr_Parametrovalor) != 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10sdtParametros.gxTpr_Parametrovalor)) )
            {
               AV11Parametros_bc.gxTv_SdtParametros_Parametrovalor_SetNull();
            }
            else
            {
               AV11Parametros_bc.gxTpr_Parametrovalor = AV10sdtParametros.gxTpr_Parametrovalor;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10sdtParametros.gxTpr_Parametrovalor)) )
            {
               AV11Parametros_bc.gxTv_SdtParametros_Parametrovalor_SetNull();
            }
         }
         AV11Parametros_bc.gxTpr_Parametrodel = AV10sdtParametros.gxTpr_Parametrodel;
         AV11Parametros_bc.Save();
         if ( AV11Parametros_bc.Success() )
         {
            if ( AV8IsRealizarCommit )
            {
               context.CommitDataStores("core.prcparametrosmanterdados",pr_default);
            }
            AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11Parametros_bc.GetMessages().Clone());
            if ( AV8IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcparametrosmanterdados",pr_default);
            }
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
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Parametros_bc = new GeneXus.Programs.core.SdtParametros(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcparametrosmanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcparametrosmanterdados__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private bool AV8IsRealizarCommit ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GeneXus.Programs.core.SdtsdtParametros AV10sdtParametros ;
      private GeneXus.Programs.core.SdtParametros AV11Parametros_bc ;
   }

   public class prcparametrosmanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcparametrosmanterdados__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
