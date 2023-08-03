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
   public class prccontatotipomanterdados : GXProcedure
   {
      public prccontatotipomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prccontatotipomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10sdtContatoTipo = aP0_sdtContatoTipo;
         this.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtContatoTipo, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtContatoTipo aP0_sdtContatoTipo ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prccontatotipomanterdados objprccontatotipomanterdados;
         objprccontatotipomanterdados = new prccontatotipomanterdados();
         objprccontatotipomanterdados.AV10sdtContatoTipo = aP0_sdtContatoTipo;
         objprccontatotipomanterdados.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         objprccontatotipomanterdados.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprccontatotipomanterdados.context.SetSubmitInitialConfig(context);
         objprccontatotipomanterdados.initialize();
         Submit( executePrivateCatch,objprccontatotipomanterdados);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prccontatotipomanterdados)stateInfo).executePrivate();
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
         AV11ContatoTipo_bc.Load(AV10sdtContatoTipo.gxTpr_Cotid);
         if ( AV11ContatoTipo_bc.Fail() )
         {
            AV11ContatoTipo_bc = new GeneXus.Programs.core.SdtContatoTipo(context);
         }
         AV11ContatoTipo_bc.gxTpr_Cotsigla = AV10sdtContatoTipo.gxTpr_Cotsigla;
         AV11ContatoTipo_bc.gxTpr_Cotnome = AV10sdtContatoTipo.gxTpr_Cotnome;
         AV11ContatoTipo_bc.gxTpr_Cotativo = AV10sdtContatoTipo.gxTpr_Cotativo;
         AV11ContatoTipo_bc.gxTpr_Cotdel = AV10sdtContatoTipo.gxTpr_Cotdel;
         AV11ContatoTipo_bc.Save();
         if ( AV11ContatoTipo_bc.Success() )
         {
            if ( AV8IsRealizarCommit )
            {
               context.CommitDataStores("core.prccontatotipomanterdados",pr_default);
            }
            AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11ContatoTipo_bc.GetMessages().Clone());
            if ( AV8IsRealizarCommit )
            {
               context.RollbackDataStores("core.prccontatotipomanterdados",pr_default);
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
         AV11ContatoTipo_bc = new GeneXus.Programs.core.SdtContatoTipo(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prccontatotipomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prccontatotipomanterdados__default(),
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
      private GeneXus.Programs.core.SdtsdtContatoTipo AV10sdtContatoTipo ;
      private GeneXus.Programs.core.SdtContatoTipo AV11ContatoTipo_bc ;
   }

   public class prccontatotipomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prccontatotipomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
