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
   public class prcnegociopjfluxomanterdados : GXProcedure
   {
      public prcnegociopjfluxomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjfluxomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtSDTNegocioPJFluxo aP0_SDTNegocioPJFluxo ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV9SDTNegocioPJFluxo = aP0_SDTNegocioPJFluxo;
         this.AV11IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV8Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtSDTNegocioPJFluxo aP0_SDTNegocioPJFluxo ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_SDTNegocioPJFluxo, aP1_IsRealizarCommit, out aP2_Messages);
         return AV8Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtSDTNegocioPJFluxo aP0_SDTNegocioPJFluxo ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcnegociopjfluxomanterdados objprcnegociopjfluxomanterdados;
         objprcnegociopjfluxomanterdados = new prcnegociopjfluxomanterdados();
         objprcnegociopjfluxomanterdados.AV9SDTNegocioPJFluxo = aP0_SDTNegocioPJFluxo;
         objprcnegociopjfluxomanterdados.AV11IsRealizarCommit = aP1_IsRealizarCommit;
         objprcnegociopjfluxomanterdados.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcnegociopjfluxomanterdados.context.SetSubmitInitialConfig(context);
         objprcnegociopjfluxomanterdados.initialize();
         Submit( executePrivateCatch,objprcnegociopjfluxomanterdados);
         aP2_Messages=this.AV8Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjfluxomanterdados)stateInfo).executePrivate();
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
         AV8Messages.Clear();
         AV10NegocioPJFluxo_bc.Load(AV9SDTNegocioPJFluxo.gxTpr_Negid, AV9SDTNegocioPJFluxo.gxTpr_Nefchave);
         if ( AV10NegocioPJFluxo_bc.Fail() )
         {
            AV10NegocioPJFluxo_bc = new GeneXus.Programs.core.SdtNegocioPJFluxo(context);
            AV10NegocioPJFluxo_bc.gxTpr_Negid = AV9SDTNegocioPJFluxo.gxTpr_Negid;
            AV10NegocioPJFluxo_bc.gxTpr_Nefchave = AV9SDTNegocioPJFluxo.gxTpr_Nefchave;
         }
         AV10NegocioPJFluxo_bc.gxTpr_Neftexto = StringUtil.Trim( AV9SDTNegocioPJFluxo.gxTpr_Neftexto);
         AV10NegocioPJFluxo_bc.gxTpr_Nefconfirmado = AV9SDTNegocioPJFluxo.gxTpr_Nefconfirmado;
         AV10NegocioPJFluxo_bc.gxTpr_Nefvalor = AV9SDTNegocioPJFluxo.gxTpr_Nefvalor;
         AV10NegocioPJFluxo_bc.Save();
         if ( AV10NegocioPJFluxo_bc.Success() )
         {
            if ( AV11IsRealizarCommit )
            {
               context.CommitDataStores("core.prcnegociopjfluxomanterdados",pr_default);
            }
            AV8Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV8Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV10NegocioPJFluxo_bc.GetMessages().Clone());
            if ( AV11IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcnegociopjfluxomanterdados",pr_default);
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
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10NegocioPJFluxo_bc = new GeneXus.Programs.core.SdtNegocioPJFluxo(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopjfluxomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopjfluxomanterdados__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private bool AV11IsRealizarCommit ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV9SDTNegocioPJFluxo ;
      private GeneXus.Programs.core.SdtNegocioPJFluxo AV10NegocioPJFluxo_bc ;
   }

   public class prcnegociopjfluxomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcnegociopjfluxomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
