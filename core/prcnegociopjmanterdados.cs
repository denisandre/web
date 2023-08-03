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
   public class prcnegociopjmanterdados : GXProcedure
   {
      public prcnegociopjmanterdados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcnegociopjmanterdados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ ,
                           bool aP1_IsRealizarCommit ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV14sdtNegocioPJ = aP0_sdtNegocioPJ;
         this.AV9IsRealizarCommit = aP1_IsRealizarCommit;
         this.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_Messages=this.AV10Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ ,
                                                                             bool aP1_IsRealizarCommit )
      {
         execute(aP0_sdtNegocioPJ, aP1_IsRealizarCommit, out aP2_Messages);
         return AV10Messages ;
      }

      public void executeSubmit( GeneXus.Programs.core.SdtsdtNegocioPJ aP0_sdtNegocioPJ ,
                                 bool aP1_IsRealizarCommit ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         prcnegociopjmanterdados objprcnegociopjmanterdados;
         objprcnegociopjmanterdados = new prcnegociopjmanterdados();
         objprcnegociopjmanterdados.AV14sdtNegocioPJ = aP0_sdtNegocioPJ;
         objprcnegociopjmanterdados.AV9IsRealizarCommit = aP1_IsRealizarCommit;
         objprcnegociopjmanterdados.AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objprcnegociopjmanterdados.context.SetSubmitInitialConfig(context);
         objprcnegociopjmanterdados.initialize();
         Submit( executePrivateCatch,objprcnegociopjmanterdados);
         aP2_Messages=this.AV10Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcnegociopjmanterdados)stateInfo).executePrivate();
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
         AV11NegocioPJ_bc.Load(AV14sdtNegocioPJ.gxTpr_Negid);
         if ( AV11NegocioPJ_bc.Fail() )
         {
            AV11NegocioPJ_bc = new GeneXus.Programs.core.SdtNegocioPJ(context);
         }
         AV11NegocioPJ_bc.gxTpr_Negcodigo = AV14sdtNegocioPJ.gxTpr_Negcodigo;
         AV11NegocioPJ_bc.gxTpr_Negcliid = AV14sdtNegocioPJ.gxTpr_Negcliid;
         AV11NegocioPJ_bc.gxTpr_Negcpjid = AV14sdtNegocioPJ.gxTpr_Negcpjid;
         AV11NegocioPJ_bc.gxTpr_Negcpjendseq = AV14sdtNegocioPJ.gxTpr_Negcpjendseq;
         if ( StringUtil.StrCmp(AV11NegocioPJ_bc.gxTpr_Negagcid, AV14sdtNegocioPJ.gxTpr_Negagcid) != 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14sdtNegocioPJ.gxTpr_Negagcid)) )
            {
               AV11NegocioPJ_bc.gxTv_SdtNegocioPJ_Negagcid_SetNull();
            }
            else
            {
               AV11NegocioPJ_bc.gxTpr_Negagcid = AV14sdtNegocioPJ.gxTpr_Negagcid;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14sdtNegocioPJ.gxTpr_Negagcid)) )
            {
               AV11NegocioPJ_bc.gxTv_SdtNegocioPJ_Negagcid_SetNull();
            }
         }
         if ( StringUtil.StrCmp(AV11NegocioPJ_bc.gxTpr_Negagcnome, AV14sdtNegocioPJ.gxTpr_Negagcnome) != 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14sdtNegocioPJ.gxTpr_Negagcnome)) )
            {
               AV11NegocioPJ_bc.gxTv_SdtNegocioPJ_Negagcnome_SetNull();
            }
            else
            {
               AV11NegocioPJ_bc.gxTpr_Negagcnome = AV14sdtNegocioPJ.gxTpr_Negagcnome;
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14sdtNegocioPJ.gxTpr_Negagcnome)) )
            {
               AV11NegocioPJ_bc.gxTv_SdtNegocioPJ_Negagcnome_SetNull();
            }
         }
         AV11NegocioPJ_bc.gxTpr_Negassunto = AV14sdtNegocioPJ.gxTpr_Negassunto;
         AV11NegocioPJ_bc.gxTpr_Negdescricao = AV14sdtNegocioPJ.gxTpr_Negdescricao;
         AV11NegocioPJ_bc.gxTpr_Negvalorestimado = AV14sdtNegocioPJ.gxTpr_Negvalorestimado;
         AV11NegocioPJ_bc.gxTpr_Negvaloratualizado = AV14sdtNegocioPJ.gxTpr_Negvaloratualizado;
         if ( AV11NegocioPJ_bc.gxTpr_Negultitem != AV14sdtNegocioPJ.gxTpr_Negultitem )
         {
            if ( (0==AV14sdtNegocioPJ.gxTpr_Negultitem) )
            {
               AV11NegocioPJ_bc.gxTv_SdtNegocioPJ_Negultitem_SetNull();
            }
            else
            {
               AV11NegocioPJ_bc.gxTpr_Negultitem = AV14sdtNegocioPJ.gxTpr_Negultitem;
            }
         }
         else
         {
            if ( (0==AV14sdtNegocioPJ.gxTpr_Negultitem) )
            {
               AV11NegocioPJ_bc.gxTv_SdtNegocioPJ_Negultitem_SetNull();
            }
         }
         AV11NegocioPJ_bc.gxTpr_Negdel = AV14sdtNegocioPJ.gxTpr_Negdel;
         /* Execute user subroutine: 'NEGOCIOPJ.ITEM.MANTER.DADOS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11NegocioPJ_bc.Save();
         if ( AV11NegocioPJ_bc.Success() )
         {
            if ( AV9IsRealizarCommit )
            {
               context.CommitDataStores("core.prcnegociopjmanterdados",pr_default);
            }
            AV10Messages.Add(new prcmessagesucesso(context).executeUdp( ), 0);
         }
         else
         {
            AV10Messages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(AV11NegocioPJ_bc.GetMessages().Clone());
            if ( AV9IsRealizarCommit )
            {
               context.RollbackDataStores("core.prcnegociopjmanterdados",pr_default);
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'NEGOCIOPJ.ITEM.MANTER.DADOS' Routine */
         returnInSub = false;
         AV12qtdRegistroBC = 1;
         while ( AV12qtdRegistroBC <= AV11NegocioPJ_bc.gxTpr_Item.Count )
         {
            AV8isEncontrado = false;
            AV13qtdRegistroSDT = 1;
            while ( AV13qtdRegistroSDT <= AV14sdtNegocioPJ.gxTpr_Item.Count )
            {
               if ( ((GeneXus.Programs.core.SdtNegocioPJ_Item)AV11NegocioPJ_bc.gxTpr_Item.Item(AV12qtdRegistroBC)).gxTpr_Ngpitem == ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngpitem )
               {
                  AV8isEncontrado = true;
                  if (true) break;
               }
               AV13qtdRegistroSDT = (short)(AV13qtdRegistroSDT+1);
            }
            if ( ! AV8isEncontrado )
            {
               AV11NegocioPJ_bc.gxTpr_Item.RemoveItem(AV12qtdRegistroBC);
            }
            AV12qtdRegistroBC = (short)(AV12qtdRegistroBC+1);
         }
         AV13qtdRegistroSDT = 1;
         while ( AV13qtdRegistroSDT <= AV14sdtNegocioPJ.gxTpr_Item.Count )
         {
            AV8isEncontrado = false;
            AV12qtdRegistroBC = 1;
            while ( AV12qtdRegistroBC <= AV11NegocioPJ_bc.gxTpr_Item.Count )
            {
               if ( ((GeneXus.Programs.core.SdtNegocioPJ_Item)AV11NegocioPJ_bc.gxTpr_Item.Item(AV12qtdRegistroBC)).gxTpr_Ngpitem == ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngpitem )
               {
                  AV8isEncontrado = true;
                  if (true) break;
               }
               AV12qtdRegistroBC = (short)(AV12qtdRegistroBC+1);
            }
            if ( ! AV8isEncontrado )
            {
               AV15NegocioPJ_item_bc = new GeneXus.Programs.core.SdtNegocioPJ_Item(context);
               AV15NegocioPJ_item_bc.gxTpr_Ngptppid = ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngptppid;
               AV15NegocioPJ_item_bc.gxTpr_Ngptppprdid = ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngptppprdid;
               AV15NegocioPJ_item_bc.gxTpr_Ngppreco = ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngppreco;
               AV15NegocioPJ_item_bc.gxTpr_Ngpqtde = ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngpqtde;
               AV15NegocioPJ_item_bc.gxTpr_Ngpobs = ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngpobs;
               AV15NegocioPJ_item_bc.gxTpr_Ngpdel = ((GeneXus.Programs.core.SdtsdtNegocioPJ_ItemItem)AV14sdtNegocioPJ.gxTpr_Item.Item(AV13qtdRegistroSDT)).gxTpr_Ngpdel;
               AV11NegocioPJ_bc.gxTpr_Item.Add(AV15NegocioPJ_item_bc, 0);
            }
            AV13qtdRegistroSDT = (short)(AV13qtdRegistroSDT+1);
         }
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
         AV11NegocioPJ_bc = new GeneXus.Programs.core.SdtNegocioPJ(context);
         AV15NegocioPJ_item_bc = new GeneXus.Programs.core.SdtNegocioPJ_Item(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopjmanterdados__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcnegociopjmanterdados__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12qtdRegistroBC ;
      private short AV13qtdRegistroSDT ;
      private bool AV9IsRealizarCommit ;
      private bool returnInSub ;
      private bool AV8isEncontrado ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GeneXus.Programs.core.SdtNegocioPJ AV11NegocioPJ_bc ;
      private GeneXus.Programs.core.SdtNegocioPJ_Item AV15NegocioPJ_item_bc ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ AV14sdtNegocioPJ ;
   }

   public class prcnegociopjmanterdados__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class prcnegociopjmanterdados__default : DataStoreHelperBase, IDataStoreHelper
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
