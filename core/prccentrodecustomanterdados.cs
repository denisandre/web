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
   public class prccentrodecustomanterdados : GXProcedure
   {
      public prccentrodecustomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prccentrodecustomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV11sdtCentroDeCusto = aP0_sdtCentroDeCusto;
         this.AV9IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV10Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtCentroDeCusto, aP1_IsRealizarCommit, out aP2_Messages);
         return AV10Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtCentroDeCusto aP0_sdtCentroDeCusto ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prccentrodecustomanterdados objprccentrodecustomanterdados;
         objprccentrodecustomanterdados = new prccentrodecustomanterdados();
         objprccentrodecustomanterdados.AV11sdtCentroDeCusto = aP0_sdtCentroDeCusto;
         objprccentrodecustomanterdados.AV9IsRealizarCommit = aP1_IsRealizarCommit;
         objprccentrodecustomanterdados.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprccentrodecustomanterdados.context.SetSubmitInitialConfig(context);
         objprccentrodecustomanterdados.initialize();
         Submit( executePrivateCatch,objprccentrodecustomanterdados);
         aP2_Messages=this.AV10Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prccentrodecustomanterdados)stateInfo).executePrivate();
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
         AV10Messages.Clear();
         AV8CentroDeCusto_bc.Load(AV11sdtCentroDeCusto.gxTpr_Ccuid);
         if ( AV8CentroDeCusto_bc.Fail() )
         {
            AV8CentroDeCusto_bc = new GeneXus.Programs.core.SdtCentroDeCusto(context);
         }
         AV8CentroDeCusto_bc.gxTpr_Ccusigla = AV11sdtCentroDeCusto.gxTpr_Ccusigla;
         AV8CentroDeCusto_bc.gxTpr_Ccunome = AV11sdtCentroDeCusto.gxTpr_Ccunome;
         AV8CentroDeCusto_bc.gxTpr_Ccuativo = AV11sdtCentroDeCusto.gxTpr_Ccuativo;
         AV8CentroDeCusto_bc.gxTpr_Ccudel = AV11sdtCentroDeCusto.gxTpr_Ccudel;
         AV8CentroDeCusto_bc.Save();
         if ( AV8CentroDeCusto_bc.Success() )
         {
            if ( AV9IsRealizarCommit )
            {
               context.CommitDataStores("core.prccentrodecustomanterdados",pr_default);
            }
            AV10Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV10Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV8CentroDeCusto_bc.GetMessages().Clone());
            if ( AV9IsRealizarCommit )
            {
               context.RollbackDataStores("core.prccentrodecustomanterdados",pr_default);
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
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8CentroDeCusto_bc = new GeneXus.Programs.core.SdtCentroDeCusto(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prccentrodecustomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prccentrodecustomanterdados__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private bool AV9IsRealizarCommit ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Programs.core.SdtCentroDeCusto AV8CentroDeCusto_bc ;
      private GeneXus.Programs.core.SdtsdtCentroDeCusto AV11sdtCentroDeCusto ;
   }

   public class prccentrodecustomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prccentrodecustomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
