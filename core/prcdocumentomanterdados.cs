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
   public class prcdocumentomanterdados : GXProcedure
   {
      public prcdocumentomanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentomanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV9sdtDocumento = aP0_sdtDocumento;
         this.AV11IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV10Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtDocumento, aP1_IsRealizarCommit, out aP2_Messages);
         return AV10Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtDocumento aP0_sdtDocumento ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcdocumentomanterdados objprcdocumentomanterdados;
         objprcdocumentomanterdados = new prcdocumentomanterdados();
         objprcdocumentomanterdados.AV9sdtDocumento = aP0_sdtDocumento;
         objprcdocumentomanterdados.AV11IsRealizarCommit = aP1_IsRealizarCommit;
         objprcdocumentomanterdados.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcdocumentomanterdados.context.SetSubmitInitialConfig(context);
         objprcdocumentomanterdados.initialize();
         Submit( executePrivateCatch,objprcdocumentomanterdados);
         aP2_Messages=this.AV10Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentomanterdados)stateInfo).executePrivate();
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
         AV8Documento_bc.Load(AV9sdtDocumento.gxTpr_Docid);
         if ( AV8Documento_bc.Fail() )
         {
            AV8Documento_bc = new GeneXus.Programs.core.SdtDocumento(context);
         }
         AV8Documento_bc.gxTpr_Docversao = AV9sdtDocumento.gxTpr_Docversao;
         if ( AV8Documento_bc.gxTpr_Docversaoidpai != AV9sdtDocumento.gxTpr_Docversaoidpai )
         {
            if ( (Guid.Empty==AV9sdtDocumento.gxTpr_Docversaoidpai) )
            {
               AV8Documento_bc.gxTv_SdtDocumento_Docversaoidpai_SetNull();
            }
            else
            {
               AV8Documento_bc.gxTpr_Docversaoidpai = AV9sdtDocumento.gxTpr_Docversaoidpai;
            }
         }
         else
         {
            if ( (Guid.Empty==AV9sdtDocumento.gxTpr_Docversaoidpai) )
            {
               AV8Documento_bc.gxTv_SdtDocumento_Docversaoidpai_SetNull();
            }
         }
         AV8Documento_bc.gxTpr_Docorigem = AV9sdtDocumento.gxTpr_Docorigem;
         AV8Documento_bc.gxTpr_Docorigemid = AV9sdtDocumento.gxTpr_Docorigemid;
         AV8Documento_bc.gxTpr_Docdel = AV9sdtDocumento.gxTpr_Docdel;
         AV8Documento_bc.gxTpr_Docnome = AV9sdtDocumento.gxTpr_Docnome;
         AV8Documento_bc.gxTpr_Doctipoid = AV9sdtDocumento.gxTpr_Doctipoid;
         if ( AV8Documento_bc.gxTpr_Docultarqseq != AV9sdtDocumento.gxTpr_Docultarqseq )
         {
            if ( (0==AV9sdtDocumento.gxTpr_Docultarqseq) )
            {
               AV8Documento_bc.gxTv_SdtDocumento_Docultarqseq_SetNull();
            }
            else
            {
               AV8Documento_bc.gxTpr_Docultarqseq = AV9sdtDocumento.gxTpr_Docultarqseq;
            }
         }
         else
         {
            if ( (0==AV9sdtDocumento.gxTpr_Docultarqseq) )
            {
               AV8Documento_bc.gxTv_SdtDocumento_Docultarqseq_SetNull();
            }
         }
         AV8Documento_bc.gxTpr_Doccontrato = AV9sdtDocumento.gxTpr_Doccontrato;
         AV8Documento_bc.gxTpr_Docassinado = AV9sdtDocumento.gxTpr_Docassinado;
         AV8Documento_bc.gxTpr_Docativo = AV9sdtDocumento.gxTpr_Docativo;
         AV8Documento_bc.Save();
         if ( AV8Documento_bc.Success() )
         {
            if ( AV11IsRealizarCommit )
            {
               context.CommitDataStores("core.prcdocumentomanterdados",pr_default);
            }
            AV10Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV10Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV8Documento_bc.GetMessages().Clone());
            if ( AV11IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcdocumentomanterdados",pr_default);
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
         AV8Documento_bc = new GeneXus.Programs.core.SdtDocumento(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentomanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentomanterdados__default(),
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
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Programs.core.SdtDocumento AV8Documento_bc ;
      private GeneXus.Programs.core.SdtsdtDocumento AV9sdtDocumento ;
   }

   public class prcdocumentomanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcdocumentomanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
