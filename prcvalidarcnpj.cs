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
   public class prcvalidarcnpj : GXProcedure
   {
      public prcvalidarcnpj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcvalidarcnpj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Documento ,
                           out bool aP1_IsValido )
      {
         this.AV9Documento = aP0_Documento;
         this.AV18IsValido = false ;
         initialize();
         executePrivate();
         aP1_IsValido=this.AV18IsValido;
      }

      public bool executeUdp( string aP0_Documento )
      {
         execute(aP0_Documento, out aP1_IsValido);
         return AV18IsValido ;
      }

      public void executeSubmit( string aP0_Documento ,
                                 out bool aP1_IsValido )
      {
         prcvalidarcnpj objprcvalidarcnpj;
         objprcvalidarcnpj = new prcvalidarcnpj();
         objprcvalidarcnpj.AV9Documento = aP0_Documento;
         objprcvalidarcnpj.AV18IsValido = false ;
         objprcvalidarcnpj.context.SetSubmitInitialConfig(context);
         objprcvalidarcnpj.initialize();
         Submit( executePrivateCatch,objprcvalidarcnpj);
         aP1_IsValido=this.AV18IsValido;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcvalidarcnpj)stateInfo).executePrivate();
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
         AV18IsValido = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Documento)) )
         {
            this.cleanup();
            if (true) return;
         }
         GXt_char1 = AV8Aux;
         new prclimpanumero(context ).execute(  AV9Documento,  "", out  GXt_char1) ;
         AV8Aux = GXt_char1;
         AV8Aux = StringUtil.Trim( AV8Aux);
         if ( ( StringUtil.Len( AV8Aux) < 13 ) || ( StringUtil.Len( AV8Aux) > 15 ) )
         {
            this.cleanup();
            if (true) return;
         }
         else if ( ( NumberUtil.Val( AV8Aux, ".") == Convert.ToDecimal( 0 )) )
         {
            this.cleanup();
            if (true) return;
         }
         AV8Aux = StringUtil.PadL( AV8Aux, 15, "0");
         AV10nC[1-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 1, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[2-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 2, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[3-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 3, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[4-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 4, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[5-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 5, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[6-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 6, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[7-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 7, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[8-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 8, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[9-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 9, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[10-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 10, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[11-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 11, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[12-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 12, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[13-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 13, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[14-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 14, 1), "."), 18, MidpointRounding.ToEven));
         AV10nC[15-1] = (short)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV8Aux, 15, 1), "."), 18, MidpointRounding.ToEven));
         AV13nT1 = (decimal)(6*AV10nC[1-1]+5*AV10nC[2-1]+4*AV10nC[3-1]+3*AV10nC[4-1]+2*AV10nC[5-1]+9*AV10nC[6-1]+8*AV10nC[7-1]+7*AV10nC[8-1]+6*AV10nC[9-1]+5*AV10nC[10-1]+4*AV10nC[11-1]+3*AV10nC[12-1]+2*AV10nC[13-1]);
         AV14nT2 = (decimal)(AV13nT1/ (decimal)(11));
         AV15nT3 = (decimal)(AV13nT1-NumberUtil.Int( (long)(Math.Round(AV14nT2, 18, MidpointRounding.ToEven)))*11);
         AV11nDC1 = 0;
         if ( ( AV15nT3 > Convert.ToDecimal( 1 )) )
         {
            AV11nDC1 = (decimal)(11-AV15nT3);
         }
         if ( ( AV11nDC1 != Convert.ToDecimal( AV10nC[14-1] )) )
         {
            this.cleanup();
            if (true) return;
         }
         AV13nT1 = (decimal)(7*AV10nC[1-1]+6*AV10nC[2-1]+5*AV10nC[3-1]+4*AV10nC[4-1]+3*AV10nC[5-1]+2*AV10nC[6-1]+9*AV10nC[7-1]+8*AV10nC[8-1]+7*AV10nC[9-1]+6*AV10nC[10-1]+5*AV10nC[11-1]+4*AV10nC[12-1]+3*AV10nC[13-1]+2*AV11nDC1);
         AV14nT2 = (decimal)(AV13nT1/ (decimal)(11));
         AV15nT3 = (decimal)(AV13nT1-NumberUtil.Int( (long)(Math.Round(AV14nT2, 18, MidpointRounding.ToEven)))*11);
         AV12nDc2 = 0;
         if ( ( AV15nT3 > Convert.ToDecimal( 1 )) )
         {
            AV12nDc2 = (decimal)(11-AV15nT3);
         }
         if ( ( AV12nDc2 != Convert.ToDecimal( AV10nC[15-1] )) )
         {
            this.cleanup();
            if (true) return;
         }
         AV18IsValido = true;
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
         AV8Aux = "";
         GXt_char1 = "";
         AV10nC = new short[15] ;
         /* GeneXus formulas. */
      }

      private short [] AV10nC ;
      private decimal AV13nT1 ;
      private decimal AV14nT2 ;
      private decimal AV15nT3 ;
      private decimal AV11nDC1 ;
      private decimal AV12nDc2 ;
      private string GXt_char1 ;
      private bool AV18IsValido ;
      private string AV9Documento ;
      private string AV8Aux ;
      private bool aP1_IsValido ;
   }

}
