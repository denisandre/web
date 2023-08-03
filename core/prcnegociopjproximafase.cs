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
   public class prcnegociopjproximafase : GXProcedure
   {
      public prcnegociopjproximafase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjproximafase( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NegID ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV8NegID = aP0_NegID;
         this.AV18IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( Guid aP0_NegID ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_NegID, aP1_IsRealizarCommit, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( Guid aP0_NegID ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcnegociopjproximafase objprcnegociopjproximafase;
         objprcnegociopjproximafase = new prcnegociopjproximafase();
         objprcnegociopjproximafase.AV8NegID = aP0_NegID;
         objprcnegociopjproximafase.AV18IsRealizarCommit = aP1_IsRealizarCommit;
         objprcnegociopjproximafase.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcnegociopjproximafase.context.SetSubmitInitialConfig(context);
         objprcnegociopjproximafase.initialize();
         Submit( executePrivateCatch,objprcnegociopjproximafase);
         aP2_Messages=this.AV9Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjproximafase)stateInfo).executePrivate();
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
         AV11NegocioPJ_bc.Load(AV8NegID);
         if ( AV11NegocioPJ_bc.Fail() )
         {
            AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11NegocioPJ_bc.GetMessages().Clone());
         }
         else
         {
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV11NegocioPJ_bc.gxTpr_Fase.Count )
            {
               AV12NegocioPJFase_bc = ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)AV11NegocioPJ_bc.gxTpr_Fase.Item(AV23GXV1));
               if ( AV12NegocioPJFase_bc.gxTpr_Ngfseq == AV11NegocioPJ_bc.gxTpr_Negultfase )
               {
                  AV12NegocioPJFase_bc.gxTpr_Ngfstatus = "DONE";
                  AV12NegocioPJFase_bc.gxTpr_Ngffimdatahora = DateTimeUtil.NowMS( context);
                  AV12NegocioPJFase_bc.gxTpr_Ngffimdata = DateTimeUtil.ResetTime( AV12NegocioPJFase_bc.gxTpr_Ngffimdatahora);
                  GXt_dtime1 = DateTimeUtil.ResetTime( AV12NegocioPJFase_bc.gxTpr_Ngffimdata ) ;
                  AV12NegocioPJFase_bc.gxTpr_Ngffimhora = GXt_dtime1;
                  AV12NegocioPJFase_bc.gxTpr_Ngffimusuid = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
                  AV12NegocioPJFase_bc.gxTpr_Ngffimusunome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
                  if (true) break;
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
            AV22NegUltIteID = AV11NegocioPJ_bc.gxTpr_Negultiteid;
            /* Execute user subroutine: 'BUSCAR PROXIMA ORDEM DA ITERAÇÃO ATUAL' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV12NegocioPJFase_bc = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase(context);
            AV12NegocioPJFase_bc.gxTpr_Ngfiteid = AV21NgfIteId;
            AV12NegocioPJFase_bc.gxTpr_Ngfstatus = "TODO";
            AV11NegocioPJ_bc.gxTpr_Fase.Add(AV12NegocioPJFase_bc, 0);
            AV11NegocioPJ_bc.Save();
            if ( AV11NegocioPJ_bc.Success() )
            {
               if ( AV18IsRealizarCommit )
               {
                  context.CommitDataStores("core.prcnegociopjproximafase",pr_default);
               }
               AV9Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
            }
            else
            {
               AV9Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11NegocioPJ_bc.GetMessages().Clone());
               if ( AV18IsRealizarCommit )
               {
                  context.RollbackDataStores("core.prcnegociopjproximafase",pr_default);
               }
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'BUSCAR PROXIMA ORDEM DA ITERAÇÃO ATUAL' Routine */
         returnInSub = false;
         AV16ProximaIteOrdem = 0;
         /* Using cursor P00632 */
         pr_default.execute(0, new Object[] {AV22NegUltIteID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A381IteID = P00632_A381IteID[0];
            A382IteOrdem = P00632_A382IteOrdem[0];
            AV16ProximaIteOrdem = A382IteOrdem;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV16ProximaIteOrdem = (int)(AV16ProximaIteOrdem+1);
         AV21NgfIteId = Guid.Empty;
         /* Using cursor P00633 */
         pr_default.execute(1, new Object[] {AV16ProximaIteOrdem});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A382IteOrdem = P00633_A382IteOrdem[0];
            A381IteID = P00633_A381IteID[0];
            AV21NgfIteId = A381IteID;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         AV11NegocioPJ_bc = new GeneXus.Programs.core.SdtNegocioPJEstrutura(context);
         AV12NegocioPJFase_bc = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV22NegUltIteID = Guid.Empty;
         AV21NgfIteId = Guid.Empty;
         scmdbuf = "";
         P00632_A381IteID = new Guid[] {Guid.Empty} ;
         P00632_A382IteOrdem = new int[1] ;
         A381IteID = Guid.Empty;
         P00633_A382IteOrdem = new int[1] ;
         P00633_A381IteID = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopjproximafase__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopjproximafase__default(),
            new Object[][] {
                new Object[] {
               P00632_A381IteID, P00632_A382IteOrdem
               }
               , new Object[] {
               P00633_A382IteOrdem, P00633_A381IteID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private int AV16ProximaIteOrdem ;
      private int A382IteOrdem ;
      private string scmdbuf ;
      private DateTime GXt_dtime1 ;
      private bool AV18IsRealizarCommit ;
      private bool returnInSub ;
      private Guid AV8NegID ;
      private Guid AV22NegUltIteID ;
      private Guid AV21NgfIteId ;
      private Guid A381IteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00632_A381IteID ;
      private int[] P00632_A382IteOrdem ;
      private int[] P00633_A382IteOrdem ;
      private Guid[] P00633_A381IteID ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private GeneXus.Programs.core.SdtNegocioPJEstrutura AV11NegocioPJ_bc ;
      private GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase AV12NegocioPJFase_bc ;
   }

   public class prcnegociopjproximafase__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcnegociopjproximafase__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00632;
        prmP00632 = new Object[] {
        new ParDef("AV22NegUltIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmP00633;
        prmP00633 = new Object[] {
        new ParDef("AV16ProximaIteOrdem",GXType.Int32,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00632", "SELECT IteID, IteOrdem FROM tb_Iteracao WHERE IteID = :AV22NegUltIteID ORDER BY IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00633", "SELECT IteOrdem, IteID FROM tb_Iteracao WHERE IteOrdem = :AV16ProximaIteOrdem ORDER BY IteOrdem ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00633,1, GxCacheFrequency.OFF ,false,true )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
     }
  }

}

}
