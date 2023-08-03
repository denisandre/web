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
   public class visitaloaddvcombo : GXProcedure
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
            return "visita_Services_Execute" ;
         }

      }

      public visitaloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitaloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           Guid aP2_VisID ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV20VisID = aP2_VisID;
         this.AV22SelectedValue = "" ;
         this.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_Combo_Data=this.AV15Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    Guid aP2_VisID ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_VisID, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV15Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 Guid aP2_VisID ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         visitaloaddvcombo objvisitaloaddvcombo;
         objvisitaloaddvcombo = new visitaloaddvcombo();
         objvisitaloaddvcombo.AV17ComboName = aP0_ComboName;
         objvisitaloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objvisitaloaddvcombo.AV20VisID = aP2_VisID;
         objvisitaloaddvcombo.AV22SelectedValue = "" ;
         objvisitaloaddvcombo.AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objvisitaloaddvcombo.context.SetSubmitInitialConfig(context);
         objvisitaloaddvcombo.initialize();
         Submit( executePrivateCatch,objvisitaloaddvcombo);
         aP3_SelectedValue=this.AV22SelectedValue;
         aP4_Combo_Data=this.AV15Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitaloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV17ComboName, "VisTipoID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_VISTIPOID' */
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
         /* 'LOADCOMBOITEMS_VISTIPOID' Routine */
         returnInSub = false;
         /* Using cursor P006F2 */
         pr_default.execute(0, new Object[] {Gx_mode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A596VitDel = P006F2_A596VitDel[0];
            A411VitID = P006F2_A411VitID[0];
            A413VitNome = P006F2_A413VitNome[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A411VitID), 9, 0));
            AV16Combo_DataItem.gxTpr_Title = A413VitNome;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P006F3 */
            pr_default.execute(1, new Object[] {AV20VisID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A398VisID = P006F3_A398VisID[0];
               A414VisTipoID = P006F3_A414VisTipoID[0];
               AV22SelectedValue = ((0==A414VisTipoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A414VisTipoID), 9, 0)));
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
         P006F2_A596VitDel = new bool[] {false} ;
         P006F2_A411VitID = new int[1] ;
         P006F2_A413VitNome = new string[] {""} ;
         A413VitNome = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P006F3_A398VisID = new Guid[] {Guid.Empty} ;
         P006F3_A414VisTipoID = new int[1] ;
         A398VisID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitaloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006F2_A596VitDel, P006F2_A411VitID, P006F2_A413VitNome
               }
               , new Object[] {
               P006F3_A398VisID, P006F3_A414VisTipoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A411VitID ;
      private int A414VisTipoID ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string Gx_mode ;
      private bool returnInSub ;
      private bool A596VitDel ;
      private string AV17ComboName ;
      private string AV22SelectedValue ;
      private string A413VitNome ;
      private Guid AV20VisID ;
      private Guid A398VisID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P006F2_A596VitDel ;
      private int[] P006F2_A411VitID ;
      private string[] P006F2_A413VitNome ;
      private Guid[] P006F3_A398VisID ;
      private int[] P006F3_A414VisTipoID ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class visitaloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006F2;
          prmP006F2 = new Object[] {
          new ParDef("Gx_mode",GXType.Char,3,0)
          };
          Object[] prmP006F3;
          prmP006F3 = new Object[] {
          new ParDef("AV20VisID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006F2", "SELECT VitDel, VitID, VitNome FROM tb_visitatipo WHERE ( :Gx_mode = ( 'INS') and Not VitDel) or :Gx_mode <> ( 'INS') ORDER BY VitID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006F3", "SELECT VisID, VisTipoID FROM tb_visita WHERE VisID = :AV20VisID ORDER BY VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006F3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
