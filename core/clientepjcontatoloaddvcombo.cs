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
   public class clientepjcontatoloaddvcombo : GXProcedure
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
            return "clientepjcontato_Services_Execute" ;
         }

      }

      public clientepjcontatoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjcontatoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_CliID ,
                           Guid aP4_CpjID ,
                           short aP5_CpjConSeq ,
                           Guid aP6_Cond_CliID ,
                           string aP7_SearchTxtParms ,
                           out string aP8_SelectedValue ,
                           out string aP9_SelectedText ,
                           out string aP10_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20CliID = aP3_CliID;
         this.AV21CpjID = aP4_CpjID;
         this.AV22CpjConSeq = aP5_CpjConSeq;
         this.AV33Cond_CliID = aP6_Cond_CliID;
         this.AV23SearchTxtParms = aP7_SearchTxtParms;
         this.AV24SelectedValue = "" ;
         this.AV25SelectedText = "" ;
         this.AV26Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP8_SelectedValue=this.AV24SelectedValue;
         aP9_SelectedText=this.AV25SelectedText;
         aP10_Combo_DataJson=this.AV26Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_CliID ,
                                Guid aP4_CpjID ,
                                short aP5_CpjConSeq ,
                                Guid aP6_Cond_CliID ,
                                string aP7_SearchTxtParms ,
                                out string aP8_SelectedValue ,
                                out string aP9_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CliID, aP4_CpjID, aP5_CpjConSeq, aP6_Cond_CliID, aP7_SearchTxtParms, out aP8_SelectedValue, out aP9_SelectedText, out aP10_Combo_DataJson);
         return AV26Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_CliID ,
                                 Guid aP4_CpjID ,
                                 short aP5_CpjConSeq ,
                                 Guid aP6_Cond_CliID ,
                                 string aP7_SearchTxtParms ,
                                 out string aP8_SelectedValue ,
                                 out string aP9_SelectedText ,
                                 out string aP10_Combo_DataJson )
      {
         clientepjcontatoloaddvcombo objclientepjcontatoloaddvcombo;
         objclientepjcontatoloaddvcombo = new clientepjcontatoloaddvcombo();
         objclientepjcontatoloaddvcombo.AV17ComboName = aP0_ComboName;
         objclientepjcontatoloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objclientepjcontatoloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objclientepjcontatoloaddvcombo.AV20CliID = aP3_CliID;
         objclientepjcontatoloaddvcombo.AV21CpjID = aP4_CpjID;
         objclientepjcontatoloaddvcombo.AV22CpjConSeq = aP5_CpjConSeq;
         objclientepjcontatoloaddvcombo.AV33Cond_CliID = aP6_Cond_CliID;
         objclientepjcontatoloaddvcombo.AV23SearchTxtParms = aP7_SearchTxtParms;
         objclientepjcontatoloaddvcombo.AV24SelectedValue = "" ;
         objclientepjcontatoloaddvcombo.AV25SelectedText = "" ;
         objclientepjcontatoloaddvcombo.AV26Combo_DataJson = "" ;
         objclientepjcontatoloaddvcombo.context.SetSubmitInitialConfig(context);
         objclientepjcontatoloaddvcombo.initialize();
         Submit( executePrivateCatch,objclientepjcontatoloaddvcombo);
         aP8_SelectedValue=this.AV24SelectedValue;
         aP9_SelectedText=this.AV25SelectedText;
         aP10_Combo_DataJson=this.AV26Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientepjcontatoloaddvcombo)stateInfo).executePrivate();
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
         AV11MaxItems = 10;
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV23SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV23SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV23SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV23SearchTxtParms : StringUtil.Substring( AV23SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "CpjConTipoID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CPJCONTIPOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CpjConGenID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CPJCONGENID' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CliID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLIID' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "CpjID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CPJID' */
            S141 ();
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
         /* 'LOADCOMBOITEMS_CPJCONTIPOID' Routine */
         returnInSub = false;
         /* Using cursor P005Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A149CotID = P005Y2_A149CotID[0];
            A151CotNome = P005Y2_A151CotNome[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A149CotID), 9, 0));
            AV16Combo_DataItem.gxTpr_Title = A151CotNome;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P005Y3 */
            pr_default.execute(1, new Object[] {AV20CliID, AV21CpjID, AV22CpjConSeq});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A269CpjConSeq = P005Y3_A269CpjConSeq[0];
               A166CpjID = P005Y3_A166CpjID[0];
               A158CliID = P005Y3_A158CliID[0];
               A270CpjConTipoID = P005Y3_A270CpjConTipoID[0];
               AV24SelectedValue = ((0==A270CpjConTipoID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A270CpjConTipoID), 9, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_CPJCONGENID' Routine */
         returnInSub = false;
         /* Using cursor P005Y4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A152GenID = P005Y4_A152GenID[0];
            A154GenNome = P005Y4_A154GenNome[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A152GenID), 9, 0));
            AV16Combo_DataItem.gxTpr_Title = A154GenNome;
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P005Y5 */
            pr_default.execute(3, new Object[] {AV20CliID, AV21CpjID, AV22CpjConSeq});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A269CpjConSeq = P005Y5_A269CpjConSeq[0];
               A166CpjID = P005Y5_A166CpjID[0];
               A158CliID = P005Y5_A158CliID[0];
               A279CpjConGenID = P005Y5_A279CpjConGenID[0];
               AV24SelectedValue = ((0==A279CpjConGenID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A279CpjConGenID), 9, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_CLIID' Routine */
         returnInSub = false;
         /* Using cursor P005Y6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A158CliID = P005Y6_A158CliID[0];
            A160CliNomeFamiliar = P005Y6_A160CliNomeFamiliar[0];
            A159CliMatricula = P005Y6_A159CliMatricula[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A158CliID.ToString());
            AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV32ComboTitles.Add(A160CliNomeFamiliar, 0);
            AV32ComboTitles.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 0);
            AV16Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P005Y7 */
            pr_default.execute(5, new Object[] {AV20CliID, AV21CpjID, AV22CpjConSeq});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A269CpjConSeq = P005Y7_A269CpjConSeq[0];
               A166CpjID = P005Y7_A166CpjID[0];
               A158CliID = P005Y7_A158CliID[0];
               AV24SelectedValue = ((Guid.Empty==A158CliID) ? "" : StringUtil.Trim( A158CliID.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
         }
         else
         {
            if ( ! (Guid.Empty==AV20CliID) )
            {
               AV24SelectedValue = StringUtil.Trim( AV20CliID.ToString());
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_CPJID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom8 = AV12SkipItems;
            GXPagingTo8 = AV11MaxItems;
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A170CpjNomeFan ,
                                                 AV33Cond_CliID ,
                                                 A158CliID } ,
                                                 new int[]{
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P005Y8 */
            pr_default.execute(6, new Object[] {AV33Cond_CliID, lV14SearchTxt, GXPagingFrom8, GXPagingTo8, GXPagingTo8});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A170CpjNomeFan = P005Y8_A170CpjNomeFan[0];
               A158CliID = P005Y8_A158CliID[0];
               A166CpjID = P005Y8_A166CpjID[0];
               A188CpjCNPJFormat = P005Y8_A188CpjCNPJFormat[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A166CpjID.ToString());
               AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV32ComboTitles.Add(A170CpjNomeFan, 0);
               AV32ComboTitles.Add(A188CpjCNPJFormat, 0);
               AV16Combo_DataItem.gxTpr_Title = AV32ComboTitles.ToJSonString(false);
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV26Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               /* Using cursor P005Y9 */
               pr_default.execute(7, new Object[] {AV20CliID, AV21CpjID, AV22CpjConSeq});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A269CpjConSeq = P005Y9_A269CpjConSeq[0];
                  A166CpjID = P005Y9_A166CpjID[0];
                  A158CliID = P005Y9_A158CliID[0];
                  A170CpjNomeFan = P005Y9_A170CpjNomeFan[0];
                  A188CpjCNPJFormat = P005Y9_A188CpjCNPJFormat[0];
                  A170CpjNomeFan = P005Y9_A170CpjNomeFan[0];
                  A188CpjCNPJFormat = P005Y9_A188CpjCNPJFormat[0];
                  AV24SelectedValue = ((Guid.Empty==A166CpjID) ? "" : StringUtil.Trim( A166CpjID.ToString()));
                  AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                  AV32ComboTitles.Add(A170CpjNomeFan, 0);
                  AV32ComboTitles.Add(A188CpjCNPJFormat, 0);
                  AV25SelectedText = AV32ComboTitles.ToJSonString(false);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(7);
            }
            else
            {
               if ( ! (Guid.Empty==AV21CpjID) )
               {
                  AV24SelectedValue = StringUtil.Trim( AV21CpjID.ToString());
                  /* Using cursor P005Y10 */
                  pr_default.execute(8, new Object[] {AV21CpjID});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A166CpjID = P005Y10_A166CpjID[0];
                     A170CpjNomeFan = P005Y10_A170CpjNomeFan[0];
                     A188CpjCNPJFormat = P005Y10_A188CpjCNPJFormat[0];
                     A158CliID = P005Y10_A158CliID[0];
                     AV32ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                     AV32ComboTitles.Add(A170CpjNomeFan, 0);
                     AV32ComboTitles.Add(A188CpjCNPJFormat, 0);
                     AV25SelectedText = AV32ComboTitles.ToJSonString(false);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     pr_default.readNext(8);
                  }
                  pr_default.close(8);
               }
            }
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
         AV24SelectedValue = "";
         AV25SelectedText = "";
         AV26Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         scmdbuf = "";
         P005Y2_A149CotID = new int[1] ;
         P005Y2_A151CotNome = new string[] {""} ;
         A151CotNome = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005Y3_A269CpjConSeq = new short[1] ;
         P005Y3_A166CpjID = new Guid[] {Guid.Empty} ;
         P005Y3_A158CliID = new Guid[] {Guid.Empty} ;
         P005Y3_A270CpjConTipoID = new int[1] ;
         A166CpjID = Guid.Empty;
         A158CliID = Guid.Empty;
         P005Y4_A152GenID = new int[1] ;
         P005Y4_A154GenNome = new string[] {""} ;
         A154GenNome = "";
         P005Y5_A269CpjConSeq = new short[1] ;
         P005Y5_A166CpjID = new Guid[] {Guid.Empty} ;
         P005Y5_A158CliID = new Guid[] {Guid.Empty} ;
         P005Y5_A279CpjConGenID = new int[1] ;
         P005Y6_A158CliID = new Guid[] {Guid.Empty} ;
         P005Y6_A160CliNomeFamiliar = new string[] {""} ;
         P005Y6_A159CliMatricula = new long[1] ;
         A160CliNomeFamiliar = "";
         AV32ComboTitles = new GxSimpleCollection<string>();
         P005Y7_A269CpjConSeq = new short[1] ;
         P005Y7_A166CpjID = new Guid[] {Guid.Empty} ;
         P005Y7_A158CliID = new Guid[] {Guid.Empty} ;
         lV14SearchTxt = "";
         A170CpjNomeFan = "";
         P005Y8_A170CpjNomeFan = new string[] {""} ;
         P005Y8_A158CliID = new Guid[] {Guid.Empty} ;
         P005Y8_A166CpjID = new Guid[] {Guid.Empty} ;
         P005Y8_A188CpjCNPJFormat = new string[] {""} ;
         A188CpjCNPJFormat = "";
         P005Y9_A269CpjConSeq = new short[1] ;
         P005Y9_A166CpjID = new Guid[] {Guid.Empty} ;
         P005Y9_A158CliID = new Guid[] {Guid.Empty} ;
         P005Y9_A170CpjNomeFan = new string[] {""} ;
         P005Y9_A188CpjCNPJFormat = new string[] {""} ;
         P005Y10_A166CpjID = new Guid[] {Guid.Empty} ;
         P005Y10_A170CpjNomeFan = new string[] {""} ;
         P005Y10_A188CpjCNPJFormat = new string[] {""} ;
         P005Y10_A158CliID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontatoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005Y2_A149CotID, P005Y2_A151CotNome
               }
               , new Object[] {
               P005Y3_A269CpjConSeq, P005Y3_A166CpjID, P005Y3_A158CliID, P005Y3_A270CpjConTipoID
               }
               , new Object[] {
               P005Y4_A152GenID, P005Y4_A154GenNome
               }
               , new Object[] {
               P005Y5_A269CpjConSeq, P005Y5_A166CpjID, P005Y5_A158CliID, P005Y5_A279CpjConGenID
               }
               , new Object[] {
               P005Y6_A158CliID, P005Y6_A160CliNomeFamiliar, P005Y6_A159CliMatricula
               }
               , new Object[] {
               P005Y7_A269CpjConSeq, P005Y7_A166CpjID, P005Y7_A158CliID
               }
               , new Object[] {
               P005Y8_A170CpjNomeFan, P005Y8_A158CliID, P005Y8_A166CpjID, P005Y8_A188CpjCNPJFormat
               }
               , new Object[] {
               P005Y9_A269CpjConSeq, P005Y9_A166CpjID, P005Y9_A158CliID, P005Y9_A170CpjNomeFan, P005Y9_A188CpjCNPJFormat
               }
               , new Object[] {
               P005Y10_A166CpjID, P005Y10_A170CpjNomeFan, P005Y10_A188CpjCNPJFormat, P005Y10_A158CliID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22CpjConSeq ;
      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short A269CpjConSeq ;
      private int AV11MaxItems ;
      private int A149CotID ;
      private int A270CpjConTipoID ;
      private int A152GenID ;
      private int A279CpjConGenID ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private long A159CliMatricula ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private string AV26Combo_DataJson ;
      private string AV17ComboName ;
      private string AV23SearchTxtParms ;
      private string AV24SelectedValue ;
      private string AV25SelectedText ;
      private string AV14SearchTxt ;
      private string A151CotNome ;
      private string A154GenNome ;
      private string A160CliNomeFamiliar ;
      private string lV14SearchTxt ;
      private string A170CpjNomeFan ;
      private string A188CpjCNPJFormat ;
      private Guid AV20CliID ;
      private Guid AV21CpjID ;
      private Guid AV33Cond_CliID ;
      private Guid A166CpjID ;
      private Guid A158CliID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005Y2_A149CotID ;
      private string[] P005Y2_A151CotNome ;
      private short[] P005Y3_A269CpjConSeq ;
      private Guid[] P005Y3_A166CpjID ;
      private Guid[] P005Y3_A158CliID ;
      private int[] P005Y3_A270CpjConTipoID ;
      private int[] P005Y4_A152GenID ;
      private string[] P005Y4_A154GenNome ;
      private short[] P005Y5_A269CpjConSeq ;
      private Guid[] P005Y5_A166CpjID ;
      private Guid[] P005Y5_A158CliID ;
      private int[] P005Y5_A279CpjConGenID ;
      private Guid[] P005Y6_A158CliID ;
      private string[] P005Y6_A160CliNomeFamiliar ;
      private long[] P005Y6_A159CliMatricula ;
      private short[] P005Y7_A269CpjConSeq ;
      private Guid[] P005Y7_A166CpjID ;
      private Guid[] P005Y7_A158CliID ;
      private string[] P005Y8_A170CpjNomeFan ;
      private Guid[] P005Y8_A158CliID ;
      private Guid[] P005Y8_A166CpjID ;
      private string[] P005Y8_A188CpjCNPJFormat ;
      private short[] P005Y9_A269CpjConSeq ;
      private Guid[] P005Y9_A166CpjID ;
      private Guid[] P005Y9_A158CliID ;
      private string[] P005Y9_A170CpjNomeFan ;
      private string[] P005Y9_A188CpjCNPJFormat ;
      private Guid[] P005Y10_A166CpjID ;
      private string[] P005Y10_A170CpjNomeFan ;
      private string[] P005Y10_A188CpjCNPJFormat ;
      private Guid[] P005Y10_A158CliID ;
      private string aP8_SelectedValue ;
      private string aP9_SelectedText ;
      private string aP10_Combo_DataJson ;
      private GxSimpleCollection<string> AV32ComboTitles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class clientepjcontatoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Y8( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A170CpjNomeFan ,
                                             Guid AV33Cond_CliID ,
                                             Guid A158CliID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CpjNomeFan, CliID, CpjID, CpjCNPJFormat";
         sFromString = " FROM tb_clientepj";
         sOrderString = "";
         AddWhere(sWhereString, "(CliID = :AV33Cond_CliID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CpjNomeFan like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY CliID";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom8" + " LIMIT CASE WHEN " + ":GXPagingTo8" + " > 0 THEN " + ":GXPagingTo8" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 6 :
                     return conditional_P005Y8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005Y2;
          prmP005Y2 = new Object[] {
          };
          Object[] prmP005Y3;
          prmP005Y3 = new Object[] {
          new ParDef("AV20CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22CpjConSeq",GXType.Int16,4,0)
          };
          Object[] prmP005Y4;
          prmP005Y4 = new Object[] {
          };
          Object[] prmP005Y5;
          prmP005Y5 = new Object[] {
          new ParDef("AV20CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22CpjConSeq",GXType.Int16,4,0)
          };
          Object[] prmP005Y6;
          prmP005Y6 = new Object[] {
          };
          Object[] prmP005Y7;
          prmP005Y7 = new Object[] {
          new ParDef("AV20CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22CpjConSeq",GXType.Int16,4,0)
          };
          Object[] prmP005Y9;
          prmP005Y9 = new Object[] {
          new ParDef("AV20CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV22CpjConSeq",GXType.Int16,4,0)
          };
          Object[] prmP005Y10;
          prmP005Y10 = new Object[] {
          new ParDef("AV21CpjID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP005Y8;
          prmP005Y8 = new Object[] {
          new ParDef("AV33Cond_CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Y2", "SELECT CotID, CotNome FROM tb_contatotipo ORDER BY CotNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Y3", "SELECT CpjConSeq, CpjID, CliID, CpjConTipoID FROM tb_clientepj_contato WHERE CliID = :AV20CliID and CpjID = :AV21CpjID and CpjConSeq = :AV22CpjConSeq ORDER BY CliID, CpjID, CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005Y4", "SELECT GenID, GenNome FROM tb_genero ORDER BY GenNome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Y5", "SELECT CpjConSeq, CpjID, CliID, CpjConGenID FROM tb_clientepj_contato WHERE CliID = :AV20CliID and CpjID = :AV21CpjID and CpjConSeq = :AV22CpjConSeq ORDER BY CliID, CpjID, CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005Y6", "SELECT CliID, CliNomeFamiliar, CliMatricula FROM tb_cliente ORDER BY CliID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Y7", "SELECT CpjConSeq, CpjID, CliID FROM tb_clientepj_contato WHERE CliID = :AV20CliID and CpjID = :AV21CpjID and CpjConSeq = :AV22CpjConSeq ORDER BY CliID, CpjID, CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005Y8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005Y9", "SELECT T1.CpjConSeq, T1.CpjID, T1.CliID, T2.CpjNomeFan, T2.CpjCNPJFormat FROM (tb_clientepj_contato T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.CliID AND T2.CpjID = T1.CpjID) WHERE T1.CliID = :AV20CliID and T1.CpjID = :AV21CpjID and T1.CpjConSeq = :AV22CpjConSeq ORDER BY T1.CliID, T1.CpjID, T1.CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005Y10", "SELECT CpjID, CpjNomeFan, CpjCNPJFormat, CliID FROM tb_clientepj WHERE CpjID = :AV21CpjID ORDER BY CliID, CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Y10,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
       }
    }

 }

}
