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
   public class prcprodutotipomanterdados : GXProcedure
   {
      public prcprodutotipomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcprodutotipomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10sdtProdutoTipo = aP0_sdtProdutoTipo;
         this.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtProdutoTipo, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtProdutoTipo aP0_sdtProdutoTipo ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcprodutotipomanterdados objprcprodutotipomanterdados;
         objprcprodutotipomanterdados = new prcprodutotipomanterdados();
         objprcprodutotipomanterdados.AV10sdtProdutoTipo = aP0_sdtProdutoTipo;
         objprcprodutotipomanterdados.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         objprcprodutotipomanterdados.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcprodutotipomanterdados.context.SetSubmitInitialConfig(context);
         objprcprodutotipomanterdados.initialize();
         Submit( executePrivateCatch,objprcprodutotipomanterdados);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcprodutotipomanterdados)stateInfo).executePrivate();
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
         AV11ProdutoTipo_bc.Load(AV10sdtProdutoTipo.gxTpr_Prtid);
         if ( AV11ProdutoTipo_bc.Fail() )
         {
            AV11ProdutoTipo_bc = new GeneXus.Programs.core.SdtProdutoTipo(context);
         }
         AV11ProdutoTipo_bc.gxTpr_Prtsigla = AV10sdtProdutoTipo.gxTpr_Prtsigla;
         AV11ProdutoTipo_bc.gxTpr_Prtnome = AV10sdtProdutoTipo.gxTpr_Prtnome;
         AV11ProdutoTipo_bc.gxTpr_Prtativo = AV10sdtProdutoTipo.gxTpr_Prtativo;
         AV11ProdutoTipo_bc.gxTpr_Prtdel = AV10sdtProdutoTipo.gxTpr_Prtdel;
         AV11ProdutoTipo_bc.Save();
         if ( AV11ProdutoTipo_bc.Success() )
         {
            if ( AV8IsRealizarCommit )
            {
               context.CommitDataStores("core.prcprodutotipomanterdados",pr_default);
            }
            AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11ProdutoTipo_bc.GetMessages().Clone());
            if ( AV8IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcprodutotipomanterdados",pr_default);
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
         AV11ProdutoTipo_bc = new GeneXus.Programs.core.SdtProdutoTipo(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcprodutotipomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcprodutotipomanterdados__default(),
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
      private GeneXus.Programs.core.SdtsdtProdutoTipo AV10sdtProdutoTipo ;
      private GeneXus.Programs.core.SdtProdutoTipo AV11ProdutoTipo_bc ;
   }

   public class prcprodutotipomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcprodutotipomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
