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
   public class negociopjloaddvcombo : GXProcedure
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
            return "negocio_Services_Execute" ;
         }

      }

      public negociopjloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           Guid aP3_NegID ,
                           Guid aP4_Cond_NegCliID ,
                           Guid aP5_Cond_NegCpjID ,
                           string aP6_SearchTxtParms ,
                           out string aP7_SelectedValue ,
                           out string aP8_SelectedText ,
                           out string aP9_Combo_DataJson )
      {
         this.AV17ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV19IsDynamicCall = aP2_IsDynamicCall;
         this.AV20NegID = aP3_NegID;
         this.AV32Cond_NegCliID = aP4_Cond_NegCliID;
         this.AV33Cond_NegCpjID = aP5_Cond_NegCpjID;
         this.AV21SearchTxtParms = aP6_SearchTxtParms;
         this.AV22SelectedValue = "" ;
         this.AV23SelectedText = "" ;
         this.AV24Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP7_SelectedValue=this.AV22SelectedValue;
         aP8_SelectedText=this.AV23SelectedText;
         aP9_Combo_DataJson=this.AV24Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                Guid aP3_NegID ,
                                Guid aP4_Cond_NegCliID ,
                                Guid aP5_Cond_NegCpjID ,
                                string aP6_SearchTxtParms ,
                                out string aP7_SelectedValue ,
                                out string aP8_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_NegID, aP4_Cond_NegCliID, aP5_Cond_NegCpjID, aP6_SearchTxtParms, out aP7_SelectedValue, out aP8_SelectedText, out aP9_Combo_DataJson);
         return AV24Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 Guid aP3_NegID ,
                                 Guid aP4_Cond_NegCliID ,
                                 Guid aP5_Cond_NegCpjID ,
                                 string aP6_SearchTxtParms ,
                                 out string aP7_SelectedValue ,
                                 out string aP8_SelectedText ,
                                 out string aP9_Combo_DataJson )
      {
         negociopjloaddvcombo objnegociopjloaddvcombo;
         objnegociopjloaddvcombo = new negociopjloaddvcombo();
         objnegociopjloaddvcombo.AV17ComboName = aP0_ComboName;
         objnegociopjloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objnegociopjloaddvcombo.AV19IsDynamicCall = aP2_IsDynamicCall;
         objnegociopjloaddvcombo.AV20NegID = aP3_NegID;
         objnegociopjloaddvcombo.AV32Cond_NegCliID = aP4_Cond_NegCliID;
         objnegociopjloaddvcombo.AV33Cond_NegCpjID = aP5_Cond_NegCpjID;
         objnegociopjloaddvcombo.AV21SearchTxtParms = aP6_SearchTxtParms;
         objnegociopjloaddvcombo.AV22SelectedValue = "" ;
         objnegociopjloaddvcombo.AV23SelectedText = "" ;
         objnegociopjloaddvcombo.AV24Combo_DataJson = "" ;
         objnegociopjloaddvcombo.context.SetSubmitInitialConfig(context);
         objnegociopjloaddvcombo.initialize();
         Submit( executePrivateCatch,objnegociopjloaddvcombo);
         aP7_SelectedValue=this.AV22SelectedValue;
         aP8_SelectedText=this.AV23SelectedText;
         aP9_Combo_DataJson=this.AV24Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((negociopjloaddvcombo)stateInfo).executePrivate();
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
         AV13PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV21SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV21SearchTxtParms))||StringUtil.StartsWith( AV18TrnMode, "GET") ? AV21SearchTxtParms : StringUtil.Substring( AV21SearchTxtParms, 3, -1));
         AV12SkipItems = (short)(AV13PageIndex*AV11MaxItems);
         if ( StringUtil.StrCmp(AV17ComboName, "NgpTppID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NGPTPPID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "NegCliID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NEGCLIID' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "NegCpjID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NEGCPJID' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV17ComboName, "NegCpjEndSeq") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_NEGCPJENDSEQ' */
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
         /* 'LOADCOMBOITEMS_NGPTPPID' Routine */
         returnInSub = false;
         /* Using cursor P006G2 */
         pr_default.execute(0, new Object[] {Gx_mode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A246TppAtivo = P006G2_A246TppAtivo[0];
            n246TppAtivo = P006G2_n246TppAtivo[0];
            A235TppID = P006G2_A235TppID[0];
            A237TppNome = P006G2_A237TppNome[0];
            A236TppCodigo = P006G2_A236TppCodigo[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A235TppID.ToString());
            AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV31ComboTitles.Add(A236TppCodigo, 0);
            AV31ComboTitles.Add(A237TppNome, 0);
            AV16Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_NEGCLIID' Routine */
         returnInSub = false;
         /* Using cursor P006G3 */
         pr_default.execute(1, new Object[] {Gx_mode});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A524CliDel = P006G3_A524CliDel[0];
            A197CliAtivo = P006G3_A197CliAtivo[0];
            A158CliID = P006G3_A158CliID[0];
            A159CliMatricula = P006G3_A159CliMatricula[0];
            A160CliNomeFamiliar = P006G3_A160CliNomeFamiliar[0];
            AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A158CliID.ToString());
            AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV31ComboTitles.Add(A160CliNomeFamiliar, 0);
            AV31ComboTitles.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 0);
            AV16Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
            AV15Combo_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         if ( ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 ) && ( StringUtil.StrCmp(AV18TrnMode, "NEW") != 0 ) )
         {
            /* Using cursor P006G4 */
            pr_default.execute(2, new Object[] {AV20NegID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A345NegID = P006G4_A345NegID[0];
               A350NegCliID = P006G4_A350NegCliID[0];
               AV22SelectedValue = ((Guid.Empty==A350NegCliID) ? "" : StringUtil.Trim( A350NegCliID.ToString()));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_NEGCPJID' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom5 = AV12SkipItems;
            GXPagingTo5 = AV11MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A170CpjNomeFan ,
                                                 Gx_mode ,
                                                 A207CpjAtivo ,
                                                 A542CpjDel ,
                                                 AV32Cond_NegCliID ,
                                                 A158CliID } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006G5 */
            pr_default.execute(3, new Object[] {AV32Cond_NegCliID, Gx_mode, Gx_mode, lV14SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A170CpjNomeFan = P006G5_A170CpjNomeFan[0];
               A542CpjDel = P006G5_A542CpjDel[0];
               A207CpjAtivo = P006G5_A207CpjAtivo[0];
               A158CliID = P006G5_A158CliID[0];
               A166CpjID = P006G5_A166CpjID[0];
               A171CpjRazaoSoc = P006G5_A171CpjRazaoSoc[0];
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( A166CpjID.ToString());
               AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV31ComboTitles.Add(A170CpjNomeFan, 0);
               AV31ComboTitles.Add(A171CpjRazaoSoc, 0);
               AV16Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006G6 */
                  pr_default.execute(4, new Object[] {AV20NegID});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A345NegID = P006G6_A345NegID[0];
                     A352NegCpjID = P006G6_A352NegCpjID[0];
                     AV22SelectedValue = ((Guid.Empty==A352NegCpjID) ? "" : StringUtil.Trim( A352NegCpjID.ToString()));
                     AV34CpjID = A352NegCpjID;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV34CpjID = StringUtil.StrToGuid( AV14SearchTxt);
               }
               /* Using cursor P006G7 */
               pr_default.execute(5, new Object[] {AV34CpjID});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A166CpjID = P006G7_A166CpjID[0];
                  A170CpjNomeFan = P006G7_A170CpjNomeFan[0];
                  A171CpjRazaoSoc = P006G7_A171CpjRazaoSoc[0];
                  A158CliID = P006G7_A158CliID[0];
                  AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                  AV31ComboTitles.Add(A170CpjNomeFan, 0);
                  AV31ComboTitles.Add(A171CpjRazaoSoc, 0);
                  AV23SelectedText = AV31ComboTitles.ToJSonString(false);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_NEGCPJENDSEQ' Routine */
         returnInSub = false;
         if ( AV19IsDynamicCall )
         {
            GXPagingFrom8 = AV12SkipItems;
            GXPagingTo8 = AV11MaxItems;
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV14SearchTxt ,
                                                 A252CpjEndEndereco ,
                                                 A255CpjEndBairro ,
                                                 A251CpjEndCepFormat ,
                                                 A257CpjEndMunNome ,
                                                 A259CpjEndUFSigla ,
                                                 A253CpjEndNumero ,
                                                 A254CpjEndComplem ,
                                                 Gx_mode ,
                                                 A554CpjEndDel ,
                                                 AV32Cond_NegCliID ,
                                                 AV33Cond_NegCpjID ,
                                                 A158CliID ,
                                                 A166CpjID } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV14SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV14SearchTxt), "%", "");
            /* Using cursor P006G8 */
            pr_default.execute(6, new Object[] {AV32Cond_NegCliID, AV33Cond_NegCpjID, Gx_mode, Gx_mode, lV14SearchTxt, GXPagingFrom8, GXPagingTo8, GXPagingTo8});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A554CpjEndDel = P006G8_A554CpjEndDel[0];
               A166CpjID = P006G8_A166CpjID[0];
               A158CliID = P006G8_A158CliID[0];
               A248CpjEndSeq = P006G8_A248CpjEndSeq[0];
               A249CpjEndNome = P006G8_A249CpjEndNome[0];
               A254CpjEndComplem = P006G8_A254CpjEndComplem[0];
               n254CpjEndComplem = P006G8_n254CpjEndComplem[0];
               A253CpjEndNumero = P006G8_A253CpjEndNumero[0];
               A259CpjEndUFSigla = P006G8_A259CpjEndUFSigla[0];
               A257CpjEndMunNome = P006G8_A257CpjEndMunNome[0];
               A251CpjEndCepFormat = P006G8_A251CpjEndCepFormat[0];
               A255CpjEndBairro = P006G8_A255CpjEndBairro[0];
               A252CpjEndEndereco = P006G8_A252CpjEndEndereco[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
               {
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
               }
               else
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  }
                  else
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                     {
                        A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                     }
                     else
                     {
                        A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                     }
                  }
               }
               AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A248CpjEndSeq), 4, 0));
               AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV31ComboTitles.Add(A368CpjEndCompleto, 0);
               AV31ComboTitles.Add(A249CpjEndNome, 0);
               AV16Combo_DataItem.gxTpr_Title = AV31ComboTitles.ToJSonString(false);
               AV15Combo_Data.Add(AV16Combo_DataItem, 0);
               if ( AV15Combo_Data.Count > AV11MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV24Combo_DataJson = AV15Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006G9 */
                  pr_default.execute(7, new Object[] {AV20NegID});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A345NegID = P006G9_A345NegID[0];
                     A369NegCpjEndSeq = P006G9_A369NegCpjEndSeq[0];
                     AV22SelectedValue = ((0==A369NegCpjEndSeq) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A369NegCpjEndSeq), 4, 0)));
                     AV28CpjEndSeq = A369NegCpjEndSeq;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV28CpjEndSeq = (short)(Math.Round(NumberUtil.Val( AV14SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P006G10 */
               pr_default.execute(8, new Object[] {AV28CpjEndSeq});
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A248CpjEndSeq = P006G10_A248CpjEndSeq[0];
                  A249CpjEndNome = P006G10_A249CpjEndNome[0];
                  A254CpjEndComplem = P006G10_A254CpjEndComplem[0];
                  n254CpjEndComplem = P006G10_n254CpjEndComplem[0];
                  A253CpjEndNumero = P006G10_A253CpjEndNumero[0];
                  A259CpjEndUFSigla = P006G10_A259CpjEndUFSigla[0];
                  A257CpjEndMunNome = P006G10_A257CpjEndMunNome[0];
                  A251CpjEndCepFormat = P006G10_A251CpjEndCepFormat[0];
                  A255CpjEndBairro = P006G10_A255CpjEndBairro[0];
                  A252CpjEndEndereco = P006G10_A252CpjEndEndereco[0];
                  A158CliID = P006G10_A158CliID[0];
                  A166CpjID = P006G10_A166CpjID[0];
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  }
                  else
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                     {
                        A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                     }
                     else
                     {
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                        {
                           A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                        }
                        else
                        {
                           A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                        }
                     }
                  }
                  AV31ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                  AV31ComboTitles.Add(A368CpjEndCompleto, 0);
                  AV31ComboTitles.Add(A249CpjEndNome, 0);
                  AV23SelectedText = AV31ComboTitles.ToJSonString(false);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(8);
               }
               pr_default.close(8);
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
         AV22SelectedValue = "";
         AV23SelectedText = "";
         AV24Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SearchTxt = "";
         scmdbuf = "";
         Gx_mode = "";
         P006G2_A246TppAtivo = new bool[] {false} ;
         P006G2_n246TppAtivo = new bool[] {false} ;
         P006G2_A235TppID = new Guid[] {Guid.Empty} ;
         P006G2_A237TppNome = new string[] {""} ;
         P006G2_A236TppCodigo = new string[] {""} ;
         A235TppID = Guid.Empty;
         A237TppNome = "";
         A236TppCodigo = "";
         AV16Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV31ComboTitles = new GxSimpleCollection<string>();
         AV15Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006G3_A524CliDel = new bool[] {false} ;
         P006G3_A197CliAtivo = new bool[] {false} ;
         P006G3_A158CliID = new Guid[] {Guid.Empty} ;
         P006G3_A159CliMatricula = new long[1] ;
         P006G3_A160CliNomeFamiliar = new string[] {""} ;
         A158CliID = Guid.Empty;
         A160CliNomeFamiliar = "";
         P006G4_A345NegID = new Guid[] {Guid.Empty} ;
         P006G4_A350NegCliID = new Guid[] {Guid.Empty} ;
         A345NegID = Guid.Empty;
         A350NegCliID = Guid.Empty;
         lV14SearchTxt = "";
         A170CpjNomeFan = "";
         P006G5_A170CpjNomeFan = new string[] {""} ;
         P006G5_A542CpjDel = new bool[] {false} ;
         P006G5_A207CpjAtivo = new bool[] {false} ;
         P006G5_A158CliID = new Guid[] {Guid.Empty} ;
         P006G5_A166CpjID = new Guid[] {Guid.Empty} ;
         P006G5_A171CpjRazaoSoc = new string[] {""} ;
         A166CpjID = Guid.Empty;
         A171CpjRazaoSoc = "";
         P006G6_A345NegID = new Guid[] {Guid.Empty} ;
         P006G6_A352NegCpjID = new Guid[] {Guid.Empty} ;
         A352NegCpjID = Guid.Empty;
         AV34CpjID = Guid.Empty;
         P006G7_A166CpjID = new Guid[] {Guid.Empty} ;
         P006G7_A170CpjNomeFan = new string[] {""} ;
         P006G7_A171CpjRazaoSoc = new string[] {""} ;
         P006G7_A158CliID = new Guid[] {Guid.Empty} ;
         A252CpjEndEndereco = "";
         A255CpjEndBairro = "";
         A251CpjEndCepFormat = "";
         A257CpjEndMunNome = "";
         A259CpjEndUFSigla = "";
         A253CpjEndNumero = "";
         A254CpjEndComplem = "";
         P006G8_A554CpjEndDel = new bool[] {false} ;
         P006G8_A166CpjID = new Guid[] {Guid.Empty} ;
         P006G8_A158CliID = new Guid[] {Guid.Empty} ;
         P006G8_A248CpjEndSeq = new short[1] ;
         P006G8_A249CpjEndNome = new string[] {""} ;
         P006G8_A254CpjEndComplem = new string[] {""} ;
         P006G8_n254CpjEndComplem = new bool[] {false} ;
         P006G8_A253CpjEndNumero = new string[] {""} ;
         P006G8_A259CpjEndUFSigla = new string[] {""} ;
         P006G8_A257CpjEndMunNome = new string[] {""} ;
         P006G8_A251CpjEndCepFormat = new string[] {""} ;
         P006G8_A255CpjEndBairro = new string[] {""} ;
         P006G8_A252CpjEndEndereco = new string[] {""} ;
         A249CpjEndNome = "";
         A368CpjEndCompleto = "";
         P006G9_A345NegID = new Guid[] {Guid.Empty} ;
         P006G9_A369NegCpjEndSeq = new short[1] ;
         P006G10_A248CpjEndSeq = new short[1] ;
         P006G10_A249CpjEndNome = new string[] {""} ;
         P006G10_A254CpjEndComplem = new string[] {""} ;
         P006G10_n254CpjEndComplem = new bool[] {false} ;
         P006G10_A253CpjEndNumero = new string[] {""} ;
         P006G10_A259CpjEndUFSigla = new string[] {""} ;
         P006G10_A257CpjEndMunNome = new string[] {""} ;
         P006G10_A251CpjEndCepFormat = new string[] {""} ;
         P006G10_A255CpjEndBairro = new string[] {""} ;
         P006G10_A252CpjEndEndereco = new string[] {""} ;
         P006G10_A158CliID = new Guid[] {Guid.Empty} ;
         P006G10_A166CpjID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006G2_A246TppAtivo, P006G2_n246TppAtivo, P006G2_A235TppID, P006G2_A237TppNome, P006G2_A236TppCodigo
               }
               , new Object[] {
               P006G3_A524CliDel, P006G3_A197CliAtivo, P006G3_A158CliID, P006G3_A159CliMatricula, P006G3_A160CliNomeFamiliar
               }
               , new Object[] {
               P006G4_A345NegID, P006G4_A350NegCliID
               }
               , new Object[] {
               P006G5_A170CpjNomeFan, P006G5_A542CpjDel, P006G5_A207CpjAtivo, P006G5_A158CliID, P006G5_A166CpjID, P006G5_A171CpjRazaoSoc
               }
               , new Object[] {
               P006G6_A345NegID, P006G6_A352NegCpjID
               }
               , new Object[] {
               P006G7_A166CpjID, P006G7_A170CpjNomeFan, P006G7_A171CpjRazaoSoc, P006G7_A158CliID
               }
               , new Object[] {
               P006G8_A554CpjEndDel, P006G8_A166CpjID, P006G8_A158CliID, P006G8_A248CpjEndSeq, P006G8_A249CpjEndNome, P006G8_A254CpjEndComplem, P006G8_n254CpjEndComplem, P006G8_A253CpjEndNumero, P006G8_A259CpjEndUFSigla, P006G8_A257CpjEndMunNome,
               P006G8_A251CpjEndCepFormat, P006G8_A255CpjEndBairro, P006G8_A252CpjEndEndereco
               }
               , new Object[] {
               P006G9_A345NegID, P006G9_A369NegCpjEndSeq
               }
               , new Object[] {
               P006G10_A248CpjEndSeq, P006G10_A249CpjEndNome, P006G10_A254CpjEndComplem, P006G10_n254CpjEndComplem, P006G10_A253CpjEndNumero, P006G10_A259CpjEndUFSigla, P006G10_A257CpjEndMunNome, P006G10_A251CpjEndCepFormat, P006G10_A255CpjEndBairro, P006G10_A252CpjEndEndereco,
               P006G10_A158CliID, P006G10_A166CpjID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13PageIndex ;
      private short AV12SkipItems ;
      private short A248CpjEndSeq ;
      private short A369NegCpjEndSeq ;
      private short AV28CpjEndSeq ;
      private int AV11MaxItems ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private long A159CliMatricula ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string Gx_mode ;
      private bool AV19IsDynamicCall ;
      private bool returnInSub ;
      private bool A246TppAtivo ;
      private bool n246TppAtivo ;
      private bool A524CliDel ;
      private bool A197CliAtivo ;
      private bool A207CpjAtivo ;
      private bool A542CpjDel ;
      private bool A554CpjEndDel ;
      private bool n254CpjEndComplem ;
      private string AV24Combo_DataJson ;
      private string AV17ComboName ;
      private string AV21SearchTxtParms ;
      private string AV22SelectedValue ;
      private string AV23SelectedText ;
      private string AV14SearchTxt ;
      private string A237TppNome ;
      private string A236TppCodigo ;
      private string A160CliNomeFamiliar ;
      private string lV14SearchTxt ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A252CpjEndEndereco ;
      private string A255CpjEndBairro ;
      private string A251CpjEndCepFormat ;
      private string A257CpjEndMunNome ;
      private string A259CpjEndUFSigla ;
      private string A253CpjEndNumero ;
      private string A254CpjEndComplem ;
      private string A249CpjEndNome ;
      private string A368CpjEndCompleto ;
      private Guid AV20NegID ;
      private Guid AV32Cond_NegCliID ;
      private Guid AV33Cond_NegCpjID ;
      private Guid A235TppID ;
      private Guid A158CliID ;
      private Guid A345NegID ;
      private Guid A350NegCliID ;
      private Guid A166CpjID ;
      private Guid A352NegCpjID ;
      private Guid AV34CpjID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P006G2_A246TppAtivo ;
      private bool[] P006G2_n246TppAtivo ;
      private Guid[] P006G2_A235TppID ;
      private string[] P006G2_A237TppNome ;
      private string[] P006G2_A236TppCodigo ;
      private bool[] P006G3_A524CliDel ;
      private bool[] P006G3_A197CliAtivo ;
      private Guid[] P006G3_A158CliID ;
      private long[] P006G3_A159CliMatricula ;
      private string[] P006G3_A160CliNomeFamiliar ;
      private Guid[] P006G4_A345NegID ;
      private Guid[] P006G4_A350NegCliID ;
      private string[] P006G5_A170CpjNomeFan ;
      private bool[] P006G5_A542CpjDel ;
      private bool[] P006G5_A207CpjAtivo ;
      private Guid[] P006G5_A158CliID ;
      private Guid[] P006G5_A166CpjID ;
      private string[] P006G5_A171CpjRazaoSoc ;
      private Guid[] P006G6_A345NegID ;
      private Guid[] P006G6_A352NegCpjID ;
      private Guid[] P006G7_A166CpjID ;
      private string[] P006G7_A170CpjNomeFan ;
      private string[] P006G7_A171CpjRazaoSoc ;
      private Guid[] P006G7_A158CliID ;
      private bool[] P006G8_A554CpjEndDel ;
      private Guid[] P006G8_A166CpjID ;
      private Guid[] P006G8_A158CliID ;
      private short[] P006G8_A248CpjEndSeq ;
      private string[] P006G8_A249CpjEndNome ;
      private string[] P006G8_A254CpjEndComplem ;
      private bool[] P006G8_n254CpjEndComplem ;
      private string[] P006G8_A253CpjEndNumero ;
      private string[] P006G8_A259CpjEndUFSigla ;
      private string[] P006G8_A257CpjEndMunNome ;
      private string[] P006G8_A251CpjEndCepFormat ;
      private string[] P006G8_A255CpjEndBairro ;
      private string[] P006G8_A252CpjEndEndereco ;
      private Guid[] P006G9_A345NegID ;
      private short[] P006G9_A369NegCpjEndSeq ;
      private short[] P006G10_A248CpjEndSeq ;
      private string[] P006G10_A249CpjEndNome ;
      private string[] P006G10_A254CpjEndComplem ;
      private bool[] P006G10_n254CpjEndComplem ;
      private string[] P006G10_A253CpjEndNumero ;
      private string[] P006G10_A259CpjEndUFSigla ;
      private string[] P006G10_A257CpjEndMunNome ;
      private string[] P006G10_A251CpjEndCepFormat ;
      private string[] P006G10_A255CpjEndBairro ;
      private string[] P006G10_A252CpjEndEndereco ;
      private Guid[] P006G10_A158CliID ;
      private Guid[] P006G10_A166CpjID ;
      private string aP7_SelectedValue ;
      private string aP8_SelectedText ;
      private string aP9_Combo_DataJson ;
      private GxSimpleCollection<string> AV31ComboTitles ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
   }

   public class negociopjloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006G5( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A170CpjNomeFan ,
                                             string Gx_mode ,
                                             bool A207CpjAtivo ,
                                             bool A542CpjDel ,
                                             Guid AV32Cond_NegCliID ,
                                             Guid A158CliID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CpjNomeFan, CpjDel, CpjAtivo, CliID, CpjID, CpjRazaoSoc";
         sFromString = " FROM tb_clientepj";
         sOrderString = "";
         AddWhere(sWhereString, "(CliID = :AV32Cond_NegCliID)");
         AddWhere(sWhereString, "(( ( :Gx_mode = ( 'INS') and CpjAtivo and Not CpjDel) or :Gx_mode <> ( 'INS')))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(CpjNomeFan like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         sOrderString += " ORDER BY CliID";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006G8( IGxContext context ,
                                             string AV14SearchTxt ,
                                             string A252CpjEndEndereco ,
                                             string A255CpjEndBairro ,
                                             string A251CpjEndCepFormat ,
                                             string A257CpjEndMunNome ,
                                             string A259CpjEndUFSigla ,
                                             string A253CpjEndNumero ,
                                             string A254CpjEndComplem ,
                                             string Gx_mode ,
                                             bool A554CpjEndDel ,
                                             Guid AV32Cond_NegCliID ,
                                             Guid AV33Cond_NegCpjID ,
                                             Guid A158CliID ,
                                             Guid A166CpjID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CpjEndDel, CpjID, CliID, CpjEndSeq, CpjEndNome, CpjEndComplem, CpjEndNumero, CpjEndUFSigla, CpjEndMunNome, CpjEndCepFormat, CpjEndBairro, CpjEndEndereco";
         sFromString = " FROM tb_clientepj_endereco";
         sOrderString = "";
         AddWhere(sWhereString, "(CliID = :AV32Cond_NegCliID and CpjID = :AV33Cond_NegCpjID)");
         AddWhere(sWhereString, "(( ( :Gx_mode = ( 'INS') and Not CpjEndDel) or :Gx_mode <> ( 'INS')))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchTxt)) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndNumero))))=0) and (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndComplem))))=0) THEN RTRIM(LTRIM(CpjEndEndereco)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) WHEN Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndNumero))))=0) and (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndComplem))))=0) THEN RTRIM(LTRIM(CpjEndEndereco)) || ', ' || RTRIM(LTRIM(CpjEndNumero)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) WHEN (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndNumero))))=0) and Not (char_length(trim(trailing ' ' from RTRIM(LTRIM(CpjEndComplem))))=0) THEN RTRIM(LTRIM(CpjEndEndereco)) || ', ' || RTRIM(LTRIM(CpjEndNumero)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) ELSE RTRIM(LTRIM(CpjEndEndereco)) || ', ' || RTRIM(LTRIM(CpjEndNumero)) || ' ' || RTRIM(LTRIM(CpjEndComplem)) || ' - ' || RTRIM(LTRIM(CpjEndBairro)) || ' - ' || RTRIM(LTRIM(CpjEndCepFormat)) || ' - ' || RTRIM(LTRIM(CpjEndMunNome)) || ' - ' || RTRIM(LTRIM(CpjEndUFSigla)) END) like '%' || :lV14SearchTxt)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         sOrderString += " ORDER BY CliID, CpjID";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom8" + " LIMIT CASE WHEN " + ":GXPagingTo8" + " > 0 THEN " + ":GXPagingTo8" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_P006G5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (Guid)dynConstraints[5] , (Guid)dynConstraints[6] );
               case 6 :
                     return conditional_P006G8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (Guid)dynConstraints[10] , (Guid)dynConstraints[11] , (Guid)dynConstraints[12] , (Guid)dynConstraints[13] );
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
          Object[] prmP006G2;
          prmP006G2 = new Object[] {
          new ParDef("Gx_mode",GXType.Char,3,0)
          };
          Object[] prmP006G3;
          prmP006G3 = new Object[] {
          new ParDef("Gx_mode",GXType.Char,3,0)
          };
          Object[] prmP006G4;
          prmP006G4 = new Object[] {
          new ParDef("AV20NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006G6;
          prmP006G6 = new Object[] {
          new ParDef("AV20NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006G7;
          prmP006G7 = new Object[] {
          new ParDef("AV34CpjID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006G9;
          prmP006G9 = new Object[] {
          new ParDef("AV20NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP006G10;
          prmP006G10 = new Object[] {
          new ParDef("AV28CpjEndSeq",GXType.Int16,4,0)
          };
          Object[] prmP006G5;
          prmP006G5 = new Object[] {
          new ParDef("AV32Cond_NegCliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Gx_mode",GXType.Char,3,0) ,
          new ParDef("Gx_mode",GXType.Char,3,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP006G8;
          prmP006G8 = new Object[] {
          new ParDef("AV32Cond_NegCliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV33Cond_NegCpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Gx_mode",GXType.Char,3,0) ,
          new ParDef("Gx_mode",GXType.Char,3,0) ,
          new ParDef("lV14SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006G2", "SELECT TppAtivo, TppID, TppNome, TppCodigo FROM tb_tabeladepreco WHERE ( :Gx_mode = ( 'INS') and TppAtivo) or :Gx_mode <> ( 'INS') ORDER BY TppCodigo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006G3", "SELECT CliDel, CliAtivo, CliID, CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE ( :Gx_mode = ( 'INS') and CliAtivo and Not CliDel) or :Gx_mode <> ( 'INS') ORDER BY CliNomeFamiliar ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006G4", "SELECT NegID, NegCliID FROM tb_negociopj WHERE NegID = :AV20NegID ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006G5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006G6", "SELECT NegID, NegCpjID FROM tb_negociopj WHERE NegID = :AV20NegID ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006G7", "SELECT CpjID, CpjNomeFan, CpjRazaoSoc, CliID FROM tb_clientepj WHERE CpjID = :AV34CpjID ORDER BY CliID, CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006G8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006G9", "SELECT NegID, NegCpjEndSeq FROM tb_negociopj WHERE NegID = :AV20NegID ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006G10", "SELECT CpjEndSeq, CpjEndNome, CpjEndComplem, CpjEndNumero, CpjEndUFSigla, CpjEndMunNome, CpjEndCepFormat, CpjEndBairro, CpjEndEndereco, CliID, CpjID FROM tb_clientepj_endereco WHERE CpjEndSeq = :AV28CpjEndSeq ORDER BY CliID, CpjID, CpjEndSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006G10,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 6 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((Guid[]) buf[10])[0] = rslt.getGuid(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                return;
       }
    }

 }

}
