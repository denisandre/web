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
namespace GeneXus.Programs {
   public class prclimpanumero : GXProcedure
   {
      public prclimpanumero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prclimpanumero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_vchTexto ,
                           string aP1_vchAceitaChars ,
                           out string aP2_vchTextoLimpo )
      {
         this.AV12vchTexto = aP0_vchTexto;
         this.AV10vchAceitaChars = aP1_vchAceitaChars;
         this.AV13vchTextoLimpo = "" ;
         initialize();
         executePrivate();
         aP2_vchTextoLimpo=this.AV13vchTextoLimpo;
      }

      public string executeUdp( string aP0_vchTexto ,
                                string aP1_vchAceitaChars )
      {
         execute(aP0_vchTexto, aP1_vchAceitaChars, out aP2_vchTextoLimpo);
         return AV13vchTextoLimpo ;
      }

      public void executeSubmit( string aP0_vchTexto ,
                                 string aP1_vchAceitaChars ,
                                 out string aP2_vchTextoLimpo )
      {
         prclimpanumero objprclimpanumero;
         objprclimpanumero = new prclimpanumero();
         objprclimpanumero.AV12vchTexto = aP0_vchTexto;
         objprclimpanumero.AV10vchAceitaChars = aP1_vchAceitaChars;
         objprclimpanumero.AV13vchTextoLimpo = "" ;
         objprclimpanumero.context.SetSubmitInitialConfig(context);
         objprclimpanumero.initialize();
         Submit( executePrivateCatch,objprclimpanumero);
         aP2_vchTextoLimpo=this.AV13vchTextoLimpo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prclimpanumero)stateInfo).executePrivate();
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
         AV13vchTextoLimpo = "";
         AV11vchChars = "1234567890" + StringUtil.Trim( AV10vchAceitaChars);
         AV9numPos = 1;
         while ( AV9numPos <= StringUtil.Len( AV12vchTexto) )
         {
            AV8chaChar = StringUtil.Substring( AV12vchTexto, AV9numPos, 1);
            if ( StringUtil.StringSearch( AV11vchChars, AV8chaChar, 1) > 0 )
            {
               AV13vchTextoLimpo += AV8chaChar;
            }
            AV9numPos = (short)(AV9numPos+1);
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
         AV13vchTextoLimpo = "";
         AV11vchChars = "";
         AV8chaChar = "";
         /* GeneXus formulas. */
      }

      private short AV9numPos ;
      private string AV8chaChar ;
      private string AV12vchTexto ;
      private string AV10vchAceitaChars ;
      private string AV13vchTextoLimpo ;
      private string AV11vchChars ;
      private string aP2_vchTextoLimpo ;
   }

}
