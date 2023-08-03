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
   public class prcgeneromanterdados : GXProcedure
   {
      public prcgeneromanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcgeneromanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10sdtGenero = aP0_sdtGenero;
         this.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtGenero, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtGenero aP0_sdtGenero ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcgeneromanterdados objprcgeneromanterdados;
         objprcgeneromanterdados = new prcgeneromanterdados();
         objprcgeneromanterdados.AV10sdtGenero = aP0_sdtGenero;
         objprcgeneromanterdados.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         objprcgeneromanterdados.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcgeneromanterdados.context.SetSubmitInitialConfig(context);
         objprcgeneromanterdados.initialize();
         Submit( executePrivateCatch,objprcgeneromanterdados);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcgeneromanterdados)stateInfo).executePrivate();
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
         AV11Genero_bc.Load(AV10sdtGenero.gxTpr_Genid);
         if ( AV11Genero_bc.Fail() )
         {
            AV11Genero_bc = new GeneXus.Programs.core.SdtGenero(context);
         }
         AV11Genero_bc.gxTpr_Gensigla = AV10sdtGenero.gxTpr_Gensigla;
         AV11Genero_bc.gxTpr_Gennome = AV10sdtGenero.gxTpr_Gennome;
         AV11Genero_bc.gxTpr_Genativo = AV10sdtGenero.gxTpr_Genativo;
         AV11Genero_bc.gxTpr_Gendel = AV10sdtGenero.gxTpr_Gendel;
         AV11Genero_bc.Save();
         if ( AV11Genero_bc.Success() )
         {
            if ( AV8IsRealizarCommit )
            {
               context.CommitDataStores("core.prcgeneromanterdados",pr_default);
            }
            AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11Genero_bc.GetMessages().Clone());
            if ( AV8IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcgeneromanterdados",pr_default);
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
         AV11Genero_bc = new GeneXus.Programs.core.SdtGenero(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcgeneromanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcgeneromanterdados__default(),
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
      private GeneXus.Programs.core.SdtsdtGenero AV10sdtGenero ;
      private GeneXus.Programs.core.SdtGenero AV11Genero_bc ;
   }

   public class prcgeneromanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcgeneromanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
