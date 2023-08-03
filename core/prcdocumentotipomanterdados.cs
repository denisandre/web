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
   public class prcdocumentotipomanterdados : GXProcedure
   {
      public prcdocumentotipomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentotipomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV10sdtDocumentoTipo = aP0_sdtDocumentoTipo;
         this.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtDocumentoTipo, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtDocumentoTipo aP0_sdtDocumentoTipo ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcdocumentotipomanterdados objprcdocumentotipomanterdados;
         objprcdocumentotipomanterdados = new prcdocumentotipomanterdados();
         objprcdocumentotipomanterdados.AV10sdtDocumentoTipo = aP0_sdtDocumentoTipo;
         objprcdocumentotipomanterdados.AV8IsRealizarCommit = aP1_IsRealizarCommit;
         objprcdocumentotipomanterdados.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcdocumentotipomanterdados.context.SetSubmitInitialConfig(context);
         objprcdocumentotipomanterdados.initialize();
         Submit( executePrivateCatch,objprcdocumentotipomanterdados);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentotipomanterdados)stateInfo).executePrivate();
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
         AV11DocumentoTipo_bc.Load(AV10sdtDocumentoTipo.gxTpr_Doctipoid);
         if ( AV11DocumentoTipo_bc.Fail() )
         {
            AV11DocumentoTipo_bc = new GeneXus.Programs.core.SdtDocumentoTipo(context);
         }
         AV11DocumentoTipo_bc.gxTpr_Doctiposigla = AV10sdtDocumentoTipo.gxTpr_Doctiposigla;
         AV11DocumentoTipo_bc.gxTpr_Doctiponome = AV10sdtDocumentoTipo.gxTpr_Doctiponome;
         AV11DocumentoTipo_bc.gxTpr_Doctipoativo = AV10sdtDocumentoTipo.gxTpr_Doctipoativo;
         AV11DocumentoTipo_bc.gxTpr_Doctipodel = AV10sdtDocumentoTipo.gxTpr_Doctipodel;
         AV11DocumentoTipo_bc.Save();
         if ( AV11DocumentoTipo_bc.Success() )
         {
            if ( AV8IsRealizarCommit )
            {
               context.CommitDataStores("core.prcdocumentotipomanterdados",pr_default);
            }
            AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11DocumentoTipo_bc.GetMessages().Clone());
            if ( AV8IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcdocumentotipomanterdados",pr_default);
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
         AV11DocumentoTipo_bc = new GeneXus.Programs.core.SdtDocumentoTipo(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentotipomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentotipomanterdados__default(),
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
      private GeneXus.Programs.core.SdtsdtDocumentoTipo AV10sdtDocumentoTipo ;
      private GeneXus.Programs.core.SdtDocumentoTipo AV11DocumentoTipo_bc ;
   }

   public class prcdocumentotipomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcdocumentotipomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
