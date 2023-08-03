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
   public class tabeladeprecoloaddvcombo : GXProcedure
   {
      public tabeladeprecoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladeprecoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_TppID ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15TppID = aP2_TppID;
         this.AV16SelectedValue = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_TppID ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_TppID, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_TppID ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         tabeladeprecoloaddvcombo objtabeladeprecoloaddvcombo;
         objtabeladeprecoloaddvcombo = new tabeladeprecoloaddvcombo();
         objtabeladeprecoloaddvcombo.AV13ComboName = aP0_ComboName;
         objtabeladeprecoloaddvcombo.AV14TrnMode = aP1_TrnMode;
         objtabeladeprecoloaddvcombo.AV15TppID = aP2_TppID;
         objtabeladeprecoloaddvcombo.AV16SelectedValue = "" ;
         objtabeladeprecoloaddvcombo.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objtabeladeprecoloaddvcombo.context.SetSubmitInitialConfig(context);
         objtabeladeprecoloaddvcombo.initialize();
         Submit( executePrivateCatch,objtabeladeprecoloaddvcombo);
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tabeladeprecoloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "PrdID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRDID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_PRDID' Routine */
         returnInSub = false;
         /* Using cursor P004I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4I2 = false;
            A231PrdAtivo = P004I2_A231PrdAtivo[0];
            A234PrdTipoNome = P004I2_A234PrdTipoNome[0];
            A220PrdID = P004I2_A220PrdID[0];
            A222PrdNome = P004I2_A222PrdNome[0];
            A221PrdCodigo = P004I2_A221PrdCodigo[0];
            A232PrdTipoID = P004I2_A232PrdTipoID[0];
            A234PrdTipoNome = P004I2_A234PrdTipoNome[0];
            AV19ComboCat_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV19ComboCat_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0));
            AV19ComboCat_DataItem.gxTpr_Title = A234PrdTipoNome;
            AV11Combo_Data.Add(AV19ComboCat_DataItem, 0);
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004I2_A234PrdTipoNome[0], A234PrdTipoNome) == 0 ) )
            {
               BRK4I2 = false;
               A220PrdID = P004I2_A220PrdID[0];
               A222PrdNome = P004I2_A222PrdNome[0];
               A221PrdCodigo = P004I2_A221PrdCodigo[0];
               A232PrdTipoID = P004I2_A232PrdTipoID[0];
               AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( A220PrdID.ToString());
               AV20ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV20ComboTitles.Add(A221PrdCodigo, 0);
               AV20ComboTitles.Add(A222PrdNome, 0);
               AV12Combo_DataItem.gxTpr_Title = AV20ComboTitles.ToJSonString(false);
               AV19ComboCat_DataItem.gxTpr_Children.Add(AV12Combo_DataItem, 0);
               BRK4I2 = true;
               pr_default.readNext(0);
            }
            if ( ! BRK4I2 )
            {
               BRK4I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV16SelectedValue = "";
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P004I2_A231PrdAtivo = new bool[] {false} ;
         P004I2_A234PrdTipoNome = new string[] {""} ;
         P004I2_A220PrdID = new Guid[] {Guid.Empty} ;
         P004I2_A222PrdNome = new string[] {""} ;
         P004I2_A221PrdCodigo = new string[] {""} ;
         P004I2_A232PrdTipoID = new int[1] ;
         A234PrdTipoNome = "";
         A220PrdID = Guid.Empty;
         A222PrdNome = "";
         A221PrdCodigo = "";
         AV19ComboCat_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV20ComboTitles = new GxSimpleCollection<string>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladeprecoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004I2_A231PrdAtivo, P004I2_A234PrdTipoNome, P004I2_A220PrdID, P004I2_A222PrdNome, P004I2_A221PrdCodigo, P004I2_A232PrdTipoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private string AV14TrnMode ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK4I2 ;
      private bool A231PrdAtivo ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private string A234PrdTipoNome ;
      private string A222PrdNome ;
      private string A221PrdCodigo ;
      private Guid AV15TppID ;
      private Guid A220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P004I2_A231PrdAtivo ;
      private string[] P004I2_A234PrdTipoNome ;
      private Guid[] P004I2_A220PrdID ;
      private string[] P004I2_A222PrdNome ;
      private string[] P004I2_A221PrdCodigo ;
      private int[] P004I2_A232PrdTipoID ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
      private GxSimpleCollection<string> AV20ComboTitles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV19ComboCat_DataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
   }

   public class tabeladeprecoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004I2;
          prmP004I2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P004I2", "SELECT T1.PrdAtivo, T2.PrtNome AS PrdTipoNome, T1.PrdID, T1.PrdNome, T1.PrdCodigo, T1.PrdTipoID AS PrdTipoID FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID) WHERE T1.PrdAtivo = TRUE ORDER BY T2.PrtNome, T1.PrdCodigo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
