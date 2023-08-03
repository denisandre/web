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
   public class prcdocumentoupload : GXProcedure
   {
      public prcdocumentoupload( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentoupload( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_DocID ,
                           GXBaseCollection<SdtFileUploadData> aP1_UploadedFiles ,
                           bool aP2_IsDarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages )
      {
         this.AV8DocID = aP0_DocID;
         this.AV10UploadedFiles = aP1_UploadedFiles;
         this.AV15IsDarCommit = aP2_IsDarCommit;
         this.AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP3_Messages=this.AV16Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( Guid aP0_DocID ,
                                                                             GXBaseCollection<SdtFileUploadData> aP1_UploadedFiles ,
                                                                             bool aP2_IsDarCommit )
      {
         execute(aP0_DocID, aP1_UploadedFiles, aP2_IsDarCommit, out aP3_Messages);
         return AV16Messages ;
      }

      public void executeSubmit( Guid aP0_DocID ,
                                 GXBaseCollection<SdtFileUploadData> aP1_UploadedFiles ,
                                 bool aP2_IsDarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages )
      {
         prcdocumentoupload objprcdocumentoupload;
         objprcdocumentoupload = new prcdocumentoupload();
         objprcdocumentoupload.AV8DocID = aP0_DocID;
         objprcdocumentoupload.AV10UploadedFiles = aP1_UploadedFiles;
         objprcdocumentoupload.AV15IsDarCommit = aP2_IsDarCommit;
         objprcdocumentoupload.AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcdocumentoupload.context.SetSubmitInitialConfig(context);
         objprcdocumentoupload.initialize();
         Submit( executePrivateCatch,objprcdocumentoupload);
         aP3_Messages=this.AV16Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentoupload)stateInfo).executePrivate();
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
         AV14Documento.Load(AV8DocID);
         AV17GXV1 = 1;
         while ( AV17GXV1 <= AV10UploadedFiles.Count )
         {
            AV9FileUploadData = ((SdtFileUploadData)AV10UploadedFiles.Item(AV17GXV1));
            AV13Arquivo = new GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos(context);
            AV13Arquivo.gxTpr_Docarqconteudo = AV9FileUploadData.gxTpr_File;
            AV13Arquivo.gxTpr_Docarqconteudonome = AV9FileUploadData.gxTpr_Name;
            AV13Arquivo.gxTpr_Docarqconteudoextensao = AV9FileUploadData.gxTpr_Extension;
            AV14Documento.gxTpr_Arquivos.Add(AV13Arquivo, 0);
            AV17GXV1 = (int)(AV17GXV1+1);
         }
         AV14Documento.Save();
         if ( AV14Documento.Success() )
         {
            AV16Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV16Messages = AV14Documento.GetMessages();
         }
         if ( AV15IsDarCommit )
         {
            context.CommitDataStores("core.prcdocumentoupload",pr_default);
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
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Documento = new GeneXus.Programs.core.SdtDocumentoEstrutura(context);
         AV9FileUploadData = new SdtFileUploadData(context);
         AV13Arquivo = new GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentoupload__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcdocumentoupload__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17GXV1 ;
      private bool AV15IsDarCommit ;
      private Guid AV8DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private GXBaseCollection<SdtFileUploadData> AV10UploadedFiles ;
      private GeneXus.Programs.core.SdtDocumentoEstrutura AV14Documento ;
      private GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos AV13Arquivo ;
      private SdtFileUploadData AV9FileUploadData ;
   }

   public class prcdocumentoupload__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcdocumentoupload__default : DataStoreHelperBase, IDataStoreHelper
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
