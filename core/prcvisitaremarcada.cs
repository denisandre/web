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
   public class prcvisitaremarcada : GXProcedure
   {
      public prcvisitaremarcada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcvisitaremarcada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_VisID ,
                           bool aP1_IsDarCommit ,
                           GeneXus.Programs.genexussecurity.SdtGAMUser aP2_GAMUser ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages )
      {
         this.AV8VisID = aP0_VisID;
         this.AV9IsDarCommit = aP1_IsDarCommit;
         this.AV12GAMUser = aP2_GAMUser;
         this.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP3_Messages=this.AV10Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( Guid aP0_VisID ,
                                                                             bool aP1_IsDarCommit ,
                                                                             GeneXus.Programs.genexussecurity.SdtGAMUser aP2_GAMUser )
      {
         execute(aP0_VisID, aP1_IsDarCommit, aP2_GAMUser, out aP3_Messages);
         return AV10Messages ;
      }

      public void executeSubmit( Guid aP0_VisID ,
                                 bool aP1_IsDarCommit ,
                                 GeneXus.Programs.genexussecurity.SdtGAMUser aP2_GAMUser ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages )
      {
         prcvisitaremarcada objprcvisitaremarcada;
         objprcvisitaremarcada = new prcvisitaremarcada();
         objprcvisitaremarcada.AV8VisID = aP0_VisID;
         objprcvisitaremarcada.AV9IsDarCommit = aP1_IsDarCommit;
         objprcvisitaremarcada.AV12GAMUser = aP2_GAMUser;
         objprcvisitaremarcada.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcvisitaremarcada.context.SetSubmitInitialConfig(context);
         objprcvisitaremarcada.initialize();
         Submit( executePrivateCatch,objprcvisitaremarcada);
         aP3_Messages=this.AV10Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcvisitaremarcada)stateInfo).executePrivate();
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
         AV11Visita.Load(AV8VisID);
         if ( AV11Visita.Fail() )
         {
            AV10Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11Visita.GetMessages().Clone());
         }
         else
         {
            AV11Visita.gxTpr_Vissituacao = "REM";
            AV11Visita.gxTpr_Visupddatahora = DateTimeUtil.NowMS( context);
            AV11Visita.gxTpr_Visupddata = DateTimeUtil.ResetTime( AV11Visita.gxTpr_Visdatahorafim);
            GXt_dtime1 = DateTimeUtil.ResetDate(AV11Visita.gxTpr_Visdatahorafim);
            AV11Visita.gxTpr_Visupdhora = GXt_dtime1;
            AV11Visita.gxTpr_Visupdusuid = AV12GAMUser.gxTpr_Guid;
            AV11Visita.gxTpr_Visupdusunome = StringUtil.Trim( AV12GAMUser.gxTpr_Name);
            AV11Visita.Save();
            if ( AV11Visita.Success() )
            {
               AV10Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
               if ( AV9IsDarCommit )
               {
                  context.CommitDataStores("core.prcvisitaremarcada",pr_default);
               }
            }
            else
            {
               AV10Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11Visita.GetMessages().Clone());
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
         AV11Visita = new GeneXus.Programs.core.SdtVisita(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcvisitaremarcada__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcvisitaremarcada__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private DateTime GXt_dtime1 ;
      private bool AV9IsDarCommit ;
      private Guid AV8VisID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Programs.core.SdtVisita AV11Visita ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUser ;
   }

   public class prcvisitaremarcada__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcvisitaremarcada__default : DataStoreHelperBase, IDataStoreHelper
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
