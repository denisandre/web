using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prcdocumentovalidar : GXProcedure
   {
      public prcdocumentovalidar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdocumentovalidar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_DocID ,
                           string aP1_DocOrigem ,
                           string aP2_DocOrigemID ,
                           bool aP3_IsDarCommit ,
                           out GeneXus.Programs.core.SdtsdtRetorno aP4_sdtRetorno )
      {
         this.AV8DocID = aP0_DocID;
         this.AV14DocOrigem = aP1_DocOrigem;
         this.AV15DocOrigemID = aP2_DocOrigemID;
         this.AV9IsDarCommit = aP3_IsDarCommit;
         this.AV12sdtRetorno = new GeneXus.Programs.core.SdtsdtRetorno(context) ;
         initialize();
         executePrivate();
         aP4_sdtRetorno=this.AV12sdtRetorno;
      }

      public GeneXus.Programs.core.SdtsdtRetorno executeUdp( Guid aP0_DocID ,
                                                             string aP1_DocOrigem ,
                                                             string aP2_DocOrigemID ,
                                                             bool aP3_IsDarCommit )
      {
         execute(aP0_DocID, aP1_DocOrigem, aP2_DocOrigemID, aP3_IsDarCommit, out aP4_sdtRetorno);
         return AV12sdtRetorno ;
      }

      public void executeSubmit( Guid aP0_DocID ,
                                 string aP1_DocOrigem ,
                                 string aP2_DocOrigemID ,
                                 bool aP3_IsDarCommit ,
                                 out GeneXus.Programs.core.SdtsdtRetorno aP4_sdtRetorno )
      {
         prcdocumentovalidar objprcdocumentovalidar;
         objprcdocumentovalidar = new prcdocumentovalidar();
         objprcdocumentovalidar.AV8DocID = aP0_DocID;
         objprcdocumentovalidar.AV14DocOrigem = aP1_DocOrigem;
         objprcdocumentovalidar.AV15DocOrigemID = aP2_DocOrigemID;
         objprcdocumentovalidar.AV9IsDarCommit = aP3_IsDarCommit;
         objprcdocumentovalidar.AV12sdtRetorno = new GeneXus.Programs.core.SdtsdtRetorno(context) ;
         objprcdocumentovalidar.context.SetSubmitInitialConfig(context);
         objprcdocumentovalidar.initialize();
         Submit( executePrivateCatch,objprcdocumentovalidar);
         aP4_sdtRetorno=this.AV12sdtRetorno;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdocumentovalidar)stateInfo).executePrivate();
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
         AV17webSessionParm = "uploadedFiles_" + StringUtil.Trim( AV14DocOrigem) + "_" + StringUtil.Trim( AV15DocOrigemID);
         AV13UploadedFiles.FromJSonString(AV16WebSession.Get(AV17webSessionParm), null);
         AV12sdtRetorno.gxTpr_Success = true;
         if ( AV13UploadedFiles.Count > 0 )
         {
            GXt_objcol_SdtMessages_Message1 = AV11Messages;
            new GeneXus.Programs.core.prcdocumentoupload(context ).execute(  AV8DocID,  AV13UploadedFiles,  true, out  GXt_objcol_SdtMessages_Message1) ;
            AV11Messages = GXt_objcol_SdtMessages_Message1;
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV11Messages.Count )
            {
               AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV18GXV1));
               if ( AV10Message.gxTpr_Type == 1 )
               {
                  AV12sdtRetorno.gxTpr_Success = false;
                  AV12sdtRetorno.gxTpr_Message = StringUtil.Trim( AV10Message.gxTpr_Description);
                  if (true) break;
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
         }
         else
         {
            AV12sdtRetorno.gxTpr_Success = false;
            AV12sdtRetorno.gxTpr_Message = "Não identificado nenhum documento anexado!";
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
         AV12sdtRetorno = new GeneXus.Programs.core.SdtsdtRetorno(context);
         AV17webSessionParm = "";
         AV13UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "agl_tresorygroup");
         AV16WebSession = context.GetSession();
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV18GXV1 ;
      private bool AV9IsDarCommit ;
      private string AV14DocOrigem ;
      private string AV15DocOrigemID ;
      private string AV17webSessionParm ;
      private Guid AV8DocID ;
      private IGxSession AV16WebSession ;
      private GeneXus.Programs.core.SdtsdtRetorno aP4_sdtRetorno ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtFileUploadData> AV13UploadedFiles ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GeneXus.Programs.core.SdtsdtRetorno AV12sdtRetorno ;
   }

}
