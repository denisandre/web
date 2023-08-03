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
   public class prctabeladeprecomanterdados : GXProcedure
   {
      public prctabeladeprecomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prctabeladeprecomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10sdtTabelaDePreco = aP0_sdtTabelaDePreco;
         this.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtTabelaDePreco, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtTabelaDePreco aP0_sdtTabelaDePreco ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prctabeladeprecomanterdados objprctabeladeprecomanterdados;
         objprctabeladeprecomanterdados = new prctabeladeprecomanterdados();
         objprctabeladeprecomanterdados.AV10sdtTabelaDePreco = aP0_sdtTabelaDePreco;
         objprctabeladeprecomanterdados.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         objprctabeladeprecomanterdados.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprctabeladeprecomanterdados.context.SetSubmitInitialConfig(context);
         objprctabeladeprecomanterdados.initialize();
         Submit( executePrivateCatch,objprctabeladeprecomanterdados);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prctabeladeprecomanterdados)stateInfo).executePrivate();
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
         AV11TabelaDePreco_bc.Load(AV10sdtTabelaDePreco.gxTpr_Tppid);
         if ( AV11TabelaDePreco_bc.Fail() )
         {
            AV11TabelaDePreco_bc = new GeneXus.Programs.core.SdtTabelaDePreco(context);
         }
         AV11TabelaDePreco_bc.gxTpr_Tppcodigo = AV10sdtTabelaDePreco.gxTpr_Tppcodigo;
         AV11TabelaDePreco_bc.gxTpr_Tppnome = AV10sdtTabelaDePreco.gxTpr_Tppnome;
         AV11TabelaDePreco_bc.gxTpr_Tppativo = AV10sdtTabelaDePreco.gxTpr_Tppativo;
         AV11TabelaDePreco_bc.gxTpr_Tppdel = AV10sdtTabelaDePreco.gxTpr_Tppdel;
         AV11TabelaDePreco_bc.Save();
         if ( AV11TabelaDePreco_bc.Success() )
         {
            if ( AV8IsRealizarCommit )
            {
               context.CommitDataStores("core.prctabeladeprecomanterdados",pr_default);
            }
            AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11TabelaDePreco_bc.GetMessages().Clone());
            if ( AV8IsRealizarCommit )
            {
               context.RollbackDataStores("core.prctabeladeprecomanterdados",pr_default);
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
         AV11TabelaDePreco_bc = new GeneXus.Programs.core.SdtTabelaDePreco(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prctabeladeprecomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prctabeladeprecomanterdados__default(),
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
      private GeneXus.Programs.core.SdtsdtTabelaDePreco AV10sdtTabelaDePreco ;
      private GeneXus.Programs.core.SdtTabelaDePreco AV11TabelaDePreco_bc ;
   }

   public class prctabeladeprecomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prctabeladeprecomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
