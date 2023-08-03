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
   public class serializar : GXProcedure
   {
      public serializar( )
      {
         this.DisconnectAtCleanup = true;
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serializar( IGxContext context )
      {
         this.DisconnectAtCleanup = true;
         context = context.UtlClone();
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_AttName ,
                           int aP1_Incremento ,
                           out int aP2_ProximoNumero )
      {
         this.AV8AttName = aP0_AttName;
         this.AV12Incremento = aP1_Incremento;
         this.AV9ProximoNumero = 0 ;
         initialize();
         executePrivate();
         aP2_ProximoNumero=this.AV9ProximoNumero;
      }

      public int executeUdp( string aP0_AttName ,
                             int aP1_Incremento )
      {
         execute(aP0_AttName, aP1_Incremento, out aP2_ProximoNumero);
         return AV9ProximoNumero ;
      }

      public void executeSubmit( string aP0_AttName ,
                                 int aP1_Incremento ,
                                 out int aP2_ProximoNumero )
      {
         serializar objserializar;
         objserializar = new serializar();
         objserializar.AV8AttName = aP0_AttName;
         objserializar.AV12Incremento = aP1_Incremento;
         objserializar.AV9ProximoNumero = 0 ;
         objserializar.context.SetSubmitInitialConfig(context);
         objserializar.initialize();
         Submit( executePrivateCatch,objserializar);
         aP2_ProximoNumero=this.AV9ProximoNumero;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((serializar)stateInfo).executePrivate();
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
         AV9ProximoNumero = 0;
         AV10cAux = "";
         new GeneXus.Programs.core.parametrogeral(context ).gxep_get(  AV8AttName, out  AV10cAux) ;
         AV9ProximoNumero = (int)(Math.Round(NumberUtil.Val( StringUtil.Trim( AV10cAux), "."), 18, MidpointRounding.ToEven));
         AV9ProximoNumero = (int)(AV9ProximoNumero+AV12Incremento);
         AV10cAux = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ProximoNumero), 8, 0));
         new GeneXus.Programs.core.parametrogeral(context ).gxep_set(  AV8AttName,  StringUtil.Format( "Ultimo %1", AV8AttName, "", "", "", "", "", "", "", ""),  AV10cAux) ;
         context.CommitDataStores("core.serializar",pr_default);
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
         AV10cAux = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.serializar__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.serializar__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV12Incremento ;
      private int AV9ProximoNumero ;
      private string AV8AttName ;
      private string AV10cAux ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int aP2_ProximoNumero ;
      private IDataStoreProvider pr_gam ;
   }

   public class serializar__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class serializar__default : DataStoreHelperBase, IDataStoreHelper
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
