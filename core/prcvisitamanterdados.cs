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
   public class prcvisitamanterdados : GXProcedure
   {
      public prcvisitamanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcvisitamanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV9sdtVisita = aP0_sdtVisita;
         this.AV11IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV10Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtVisita, aP1_IsRealizarCommit, out aP2_Messages);
         return AV10Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtVisita aP0_sdtVisita ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcvisitamanterdados objprcvisitamanterdados;
         objprcvisitamanterdados = new prcvisitamanterdados();
         objprcvisitamanterdados.AV9sdtVisita = aP0_sdtVisita;
         objprcvisitamanterdados.AV11IsRealizarCommit = aP1_IsRealizarCommit;
         objprcvisitamanterdados.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcvisitamanterdados.context.SetSubmitInitialConfig(context);
         objprcvisitamanterdados.initialize();
         Submit( executePrivateCatch,objprcvisitamanterdados);
         aP2_Messages=this.AV10Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcvisitamanterdados)stateInfo).executePrivate();
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
         AV8visita_bc.Load(AV9sdtVisita.gxTpr_Visid);
         if ( AV8visita_bc.Fail() )
         {
            AV8visita_bc = new GeneXus.Programs.core.SdtVisita(context);
         }
         if ( AV8visita_bc.gxTpr_Vispaiid != AV9sdtVisita.gxTpr_Vispaiid )
         {
            if ( (Guid.Empty==AV9sdtVisita.gxTpr_Vispaiid) )
            {
               AV8visita_bc.gxTv_SdtVisita_Vispaiid_SetNull();
            }
            else
            {
               AV8visita_bc.gxTpr_Vispaiid = AV9sdtVisita.gxTpr_Vispaiid;
            }
         }
         else
         {
            if ( (Guid.Empty==AV9sdtVisita.gxTpr_Vispaiid) )
            {
               AV8visita_bc.gxTv_SdtVisita_Vispaiid_SetNull();
            }
         }
         AV8visita_bc.gxTpr_Visdata = AV9sdtVisita.gxTpr_Visdata;
         AV8visita_bc.gxTpr_Vishora = AV9sdtVisita.gxTpr_Vishora;
         AV8visita_bc.gxTpr_Visdatafim = AV9sdtVisita.gxTpr_Visdatafim;
         AV8visita_bc.gxTpr_Vishorafim = AV9sdtVisita.gxTpr_Vishorafim;
         AV8visita_bc.gxTpr_Vistipoid = AV9sdtVisita.gxTpr_Vistipoid;
         if ( AV8visita_bc.gxTpr_Visnegid != AV9sdtVisita.gxTpr_Visnegid )
         {
            if ( (Guid.Empty==AV9sdtVisita.gxTpr_Visnegid) )
            {
               AV8visita_bc.gxTv_SdtVisita_Visnegid_SetNull();
            }
            else
            {
               AV8visita_bc.gxTpr_Visnegid = AV9sdtVisita.gxTpr_Visnegid;
            }
         }
         else
         {
            if ( (Guid.Empty==AV9sdtVisita.gxTpr_Visnegid) )
            {
               AV8visita_bc.gxTv_SdtVisita_Visnegid_SetNull();
            }
         }
         if ( AV8visita_bc.gxTpr_Visngfseq != AV9sdtVisita.gxTpr_Visngfseq )
         {
            if ( (0==AV9sdtVisita.gxTpr_Visngfseq) )
            {
               AV8visita_bc.gxTv_SdtVisita_Visngfseq_SetNull();
            }
            else
            {
               AV8visita_bc.gxTpr_Visngfseq = AV9sdtVisita.gxTpr_Visngfseq;
            }
         }
         else
         {
            if ( (0==AV9sdtVisita.gxTpr_Visngfseq) )
            {
               AV8visita_bc.gxTv_SdtVisita_Visngfseq_SetNull();
            }
         }
         AV8visita_bc.gxTpr_Visassunto = AV9sdtVisita.gxTpr_Visassunto;
         if ( StringUtil.StrCmp(AV8visita_bc.gxTpr_Visdescricao, AV9sdtVisita.gxTpr_Visdescricao) != 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9sdtVisita.gxTpr_Visdescricao)) )
            {
               AV8visita_bc.gxTv_SdtVisita_Visdescricao_SetNull();
            }
            else
            {
               AV8visita_bc.gxTpr_Visdescricao = AV9sdtVisita.gxTpr_Visdescricao;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9sdtVisita.gxTpr_Visdescricao)) )
            {
               AV8visita_bc.gxTv_SdtVisita_Visdescricao_SetNull();
            }
         }
         if ( StringUtil.StrCmp(AV8visita_bc.gxTpr_Vislink, AV9sdtVisita.gxTpr_Vislink) != 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9sdtVisita.gxTpr_Vislink)) )
            {
               AV8visita_bc.gxTv_SdtVisita_Vislink_SetNull();
            }
            else
            {
               AV8visita_bc.gxTpr_Vislink = AV9sdtVisita.gxTpr_Vislink;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9sdtVisita.gxTpr_Vislink)) )
            {
               AV8visita_bc.gxTv_SdtVisita_Vislink_SetNull();
            }
         }
         AV8visita_bc.gxTpr_Vissituacao = AV9sdtVisita.gxTpr_Vissituacao;
         AV8visita_bc.gxTpr_Visdel = AV9sdtVisita.gxTpr_Visdel;
         AV8visita_bc.Save();
         if ( AV8visita_bc.Success() )
         {
            if ( AV11IsRealizarCommit )
            {
               context.CommitDataStores("core.prcvisitamanterdados",pr_default);
            }
            AV10Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV10Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV8visita_bc.GetMessages().Clone());
            if ( AV11IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcvisitamanterdados",pr_default);
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
         AV8visita_bc = new GeneXus.Programs.core.SdtVisita(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcvisitamanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcvisitamanterdados__default(),
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
      private GeneXus.Programs.core.SdtVisita AV8visita_bc ;
      private GeneXus.Programs.core.SdtsdtVisita AV9sdtVisita ;
   }

   public class prcvisitamanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcvisitamanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
