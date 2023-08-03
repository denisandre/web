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
   public class prcdebugtofile : GXProcedure
   {
      public prcdebugtofile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcdebugtofile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_PgmNome ,
                           string aP1_Message )
      {
         this.AV11PgmNome = aP0_PgmNome;
         this.AV8Message = aP1_Message;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_PgmNome ,
                                 string aP1_Message )
      {
         prcdebugtofile objprcdebugtofile;
         objprcdebugtofile = new prcdebugtofile();
         objprcdebugtofile.AV11PgmNome = aP0_PgmNome;
         objprcdebugtofile.AV8Message = aP1_Message;
         objprcdebugtofile.context.SetSubmitInitialConfig(context);
         objprcdebugtofile.initialize();
         Submit( executePrivateCatch,objprcdebugtofile);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcdebugtofile)stateInfo).executePrivate();
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
         AV10Agora = DateTimeUtil.NowMS( context);
         AV9File.Source = StringUtil.Format( "D:\\temp\\Log\\agl_tresorygroup_debug_%1%2%3.log", StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV10Agora)), 10, 0)), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( AV10Agora)), 10, 0)), 2, "0"), StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( AV10Agora)), 10, 0)), 2, "0"), "", "", "", "", "", "");
         AV9File.Open("");
         AV9File.WriteLine(StringUtil.Format( "%1. %2 - %3", StringUtil.PadR( StringUtil.Trim( context.localUtil.TToC( AV10Agora, 8, 12, 0, 3, "/", ":", " ")), 20, " "), StringUtil.PadR( StringUtil.Trim( AV11PgmNome), 20, " "), StringUtil.RTrim( AV8Message), "", "", "", "", "", ""));
         AV9File.Close();
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
         AV10Agora = (DateTime)(DateTime.MinValue);
         AV9File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private DateTime AV10Agora ;
      private string AV11PgmNome ;
      private string AV8Message ;
      private GxFile AV9File ;
   }

}
