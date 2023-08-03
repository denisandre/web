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
   public class documentoloaddvcombo : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "documento_Services_Execute" ;
         }

      }

      public documentoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_DocID ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20DocID = aP2_DocID;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_DocID ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_DocID, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_DocID ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         documentoloaddvcombo objdocumentoloaddvcombo;
         objdocumentoloaddvcombo = new documentoloaddvcombo();
         objdocumentoloaddvcombo.AV17ComboName = aP0_ComboName;
         objdocumentoloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objdocumentoloaddvcombo.AV20DocID = aP2_DocID;
         objdocumentoloaddvcombo.AV22SelectedValue = "" ;
         objdocumentoloaddvcombo.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objdocumentoloaddvcombo.context.SetSubmitInitialConfig(context);
         objdocumentoloaddvcombo.initialize();
         Submit( executePrivateCatch,objdocumentoloaddvcombo);
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_Combo_Data=this.AV15Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "DocTipoID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DOCTIPOID' */
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
         /* 'LOADCOMBOITEMS_DOCTIPOID' Routine */
         returnInSub = false;
         /* Using cursor P006L2 */
         pr_default.execute(0, new Object[] {Gx_mode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A503DocTipoDel = P006L2_A503DocTipoDel[0];
            A219DocTipoAtivo = P006L2_A219DocTipoAtivo[0];
            A146DocTipoID = P006L2_A146DocTipoID[0];
            A148DocTipoNome = P006L2_A148DocTipoNome[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A146DocTipoID), 9, 0));
            AV16Combo_DataItem.gxTpr_Title = A148DocTipoNome;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006L3 */
            pr_default.execute(1, new Object[] {AV20DocID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A289DocID = P006L3_A289DocID[0];
               A146DocTipoID = P006L3_A146DocTipoID[0];
               AV22SelectedValue = ((0==A146DocTipoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A146DocTipoID), 9, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
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
         AV22SelectedValue = "";
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         Gx_mode = "";
         P006L2_A503DocTipoDel = new bool[] {false} ;
         P006L2_A219DocTipoAtivo = new bool[] {false} ;
         P006L2_A146DocTipoID = new int[1] ;
         P006L2_A148DocTipoNome = new string[] {""} ;
         A148DocTipoNome = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P006L3_A289DocID = new Guid[] {Guid.Empty} ;
         P006L3_A146DocTipoID = new int[1] ;
         A289DocID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006L2_A503DocTipoDel, P006L2_A219DocTipoAtivo, P006L2_A146DocTipoID, P006L2_A148DocTipoNome
               }
               , new Object[] {
               P006L3_A289DocID, P006L3_A146DocTipoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A146DocTipoID ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string Gx_mode ;
      private bool returnInSub ;
      private bool A503DocTipoDel ;
      private bool A219DocTipoAtivo ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string A148DocTipoNome ;
      private Guid AV20DocID ;
      private Guid A289DocID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P006L2_A503DocTipoDel ;
      private bool[] P006L2_A219DocTipoAtivo ;
      private int[] P006L2_A146DocTipoID ;
      private string[] P006L2_A148DocTipoNome ;
      private Guid[] P006L3_A289DocID ;
      private int[] P006L3_A146DocTipoID ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class documentoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006L2;
          prmP006L2 = new Object[] {
          new ParDef("Gx_mode",GXType.Char,3,0)
          };
          Object[] prmP006L3;
          prmP006L3 = new Object[] {
          new ParDef("AV20DocID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006L2", "SELECT DocTipoDel, DocTipoAtivo, DocTipoID, DocTipoNome FROM tb_documentotipo WHERE ( :Gx_mode = ( 'INS') and DocTipoAtivo and Not DocTipoDel) or :Gx_mode <> ( 'INS') ORDER BY DocTipoNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006L2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006L3", "SELECT DocID, DocTipoID FROM tb_documento WHERE DocID = :AV20DocID ORDER BY DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006L3,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
