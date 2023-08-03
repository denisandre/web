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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class municipio_bc : GxSilentTrn, IGxSilentTrn
   {
      public municipio_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipio_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z35MunicipioID = A35MunicipioID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
                  ZM055( 6) ;
                  ZM055( 7) ;
                  ZM055( 8) ;
                  ZM055( 9) ;
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MunicipioMicroID") == 0 )
               {
                  AV13Insert_MunicipioMicroID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z44MunicipioMicroMesoUFSiglaNome = A44MunicipioMicroMesoUFSiglaNome;
            Z48MunicipioMicroMesoUFRegSiglaNo = A48MunicipioMicroMesoUFRegSiglaNo;
            Z36MunicipioNome = A36MunicipioNome;
            Z37MunicipioMicroID = A37MunicipioMicroID;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z38MunicipioMicroNome = A38MunicipioMicroNome;
            Z39MunicipioMicroMesoID = A39MunicipioMicroMesoID;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z40MunicipioMicroMesoNome = A40MunicipioMicroMesoNome;
            Z41MunicipioMicroMesoUFID = A41MunicipioMicroMesoUFID;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z42MunicipioMicroMesoUFSigla = A42MunicipioMicroMesoUFSigla;
            Z43MunicipioMicroMesoUFNome = A43MunicipioMicroMesoUFNome;
            Z45MunicipioMicroMesoUFRegID = A45MunicipioMicroMesoUFRegID;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z46MunicipioMicroMesoUFRegSigla = A46MunicipioMicroMesoUFRegSigla;
            Z47MunicipioMicroMesoUFRegNome = A47MunicipioMicroMesoUFRegNome;
         }
         if ( GX_JID == -5 )
         {
            Z44MunicipioMicroMesoUFSiglaNome = A44MunicipioMicroMesoUFSiglaNome;
            Z48MunicipioMicroMesoUFRegSiglaNo = A48MunicipioMicroMesoUFRegSiglaNo;
            Z35MunicipioID = A35MunicipioID;
            Z36MunicipioNome = A36MunicipioNome;
            Z38MunicipioMicroNome = A38MunicipioMicroNome;
            Z39MunicipioMicroMesoID = A39MunicipioMicroMesoID;
            Z40MunicipioMicroMesoNome = A40MunicipioMicroMesoNome;
            Z41MunicipioMicroMesoUFID = A41MunicipioMicroMesoUFID;
            Z42MunicipioMicroMesoUFSigla = A42MunicipioMicroMesoUFSigla;
            Z43MunicipioMicroMesoUFNome = A43MunicipioMicroMesoUFNome;
            Z45MunicipioMicroMesoUFRegID = A45MunicipioMicroMesoUFRegID;
            Z46MunicipioMicroMesoUFRegSigla = A46MunicipioMicroMesoUFRegSigla;
            Z47MunicipioMicroMesoUFRegNome = A47MunicipioMicroMesoUFRegNome;
            Z37MunicipioMicroID = A37MunicipioMicroID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.municipio_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load055( )
      {
         /* Using cursor BC00058 */
         pr_default.execute(6, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound5 = 1;
            A44MunicipioMicroMesoUFSiglaNome = BC00058_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = BC00058_n44MunicipioMicroMesoUFSiglaNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = BC00058_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = BC00058_n48MunicipioMicroMesoUFRegSiglaNo[0];
            A36MunicipioNome = BC00058_A36MunicipioNome[0];
            A38MunicipioMicroNome = BC00058_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = BC00058_A39MunicipioMicroMesoID[0];
            A40MunicipioMicroMesoNome = BC00058_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = BC00058_n40MunicipioMicroMesoNome[0];
            A41MunicipioMicroMesoUFID = BC00058_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = BC00058_n41MunicipioMicroMesoUFID[0];
            A42MunicipioMicroMesoUFSigla = BC00058_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = BC00058_n42MunicipioMicroMesoUFSigla[0];
            A43MunicipioMicroMesoUFNome = BC00058_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = BC00058_n43MunicipioMicroMesoUFNome[0];
            A45MunicipioMicroMesoUFRegID = BC00058_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = BC00058_n45MunicipioMicroMesoUFRegID[0];
            A46MunicipioMicroMesoUFRegSigla = BC00058_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = BC00058_n46MunicipioMicroMesoUFRegSigla[0];
            A47MunicipioMicroMesoUFRegNome = BC00058_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = BC00058_n47MunicipioMicroMesoUFRegNome[0];
            A37MunicipioMicroID = BC00058_A37MunicipioMicroID[0];
            ZM055( -5) ;
         }
         pr_default.close(6);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
         n44MunicipioMicroMesoUFSiglaNome = false;
         /* Using cursor BC00057 */
         pr_default.execute(5, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
         A46MunicipioMicroMesoUFRegSigla = BC00057_A46MunicipioMicroMesoUFRegSigla[0];
         n46MunicipioMicroMesoUFRegSigla = BC00057_n46MunicipioMicroMesoUFRegSigla[0];
         A47MunicipioMicroMesoUFRegNome = BC00057_A47MunicipioMicroMesoUFRegNome[0];
         n47MunicipioMicroMesoUFRegNome = BC00057_n47MunicipioMicroMesoUFRegNome[0];
         pr_default.close(5);
         A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
         n48MunicipioMicroMesoUFRegSiglaNo = false;
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {A37MunicipioMicroID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Microregiao -> Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROID");
            AnyError = 1;
         }
         A38MunicipioMicroNome = BC00054_A38MunicipioMicroNome[0];
         A39MunicipioMicroMesoID = BC00054_A39MunicipioMicroMesoID[0];
         pr_default.close(2);
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A39MunicipioMicroMesoID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'tbibge_mesorregiao'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOID");
            AnyError = 1;
         }
         A40MunicipioMicroMesoNome = BC00055_A40MunicipioMicroMesoNome[0];
         n40MunicipioMicroMesoNome = BC00055_n40MunicipioMicroMesoNome[0];
         A41MunicipioMicroMesoUFID = BC00055_A41MunicipioMicroMesoUFID[0];
         n41MunicipioMicroMesoUFID = BC00055_n41MunicipioMicroMesoUFID[0];
         pr_default.close(3);
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFID");
            AnyError = 1;
         }
         A42MunicipioMicroMesoUFSigla = BC00056_A42MunicipioMicroMesoUFSigla[0];
         n42MunicipioMicroMesoUFSigla = BC00056_n42MunicipioMicroMesoUFSigla[0];
         A43MunicipioMicroMesoUFNome = BC00056_A43MunicipioMicroMesoUFNome[0];
         n43MunicipioMicroMesoUFNome = BC00056_n43MunicipioMicroMesoUFNome[0];
         A45MunicipioMicroMesoUFRegID = BC00056_A45MunicipioMicroMesoUFRegID[0];
         n45MunicipioMicroMesoUFRegID = BC00056_n45MunicipioMicroMesoUFRegID[0];
         pr_default.close(4);
         nIsDirty_5 = 1;
         A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
         n44MunicipioMicroMesoUFSiglaNome = false;
         /* Using cursor BC00057 */
         pr_default.execute(5, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFREGID");
            AnyError = 1;
         }
         A46MunicipioMicroMesoUFRegSigla = BC00057_A46MunicipioMicroMesoUFRegSigla[0];
         n46MunicipioMicroMesoUFRegSigla = BC00057_n46MunicipioMicroMesoUFRegSigla[0];
         A47MunicipioMicroMesoUFRegNome = BC00057_A47MunicipioMicroMesoUFRegNome[0];
         n47MunicipioMicroMesoUFRegNome = BC00057_n47MunicipioMicroMesoUFRegNome[0];
         pr_default.close(5);
         nIsDirty_5 = 1;
         A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
         n48MunicipioMicroMesoUFRegSiglaNo = false;
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00059 */
         pr_default.execute(7, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 5) ;
            RcdFound5 = 1;
            A35MunicipioID = BC00053_A35MunicipioID[0];
            A36MunicipioNome = BC00053_A36MunicipioNome[0];
            A37MunicipioMicroID = BC00053_A37MunicipioMicroID[0];
            A44MunicipioMicroMesoUFSiglaNome = BC00053_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = BC00053_n44MunicipioMicroMesoUFSiglaNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = BC00053_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = BC00053_n48MunicipioMicroMesoUFRegSiglaNo[0];
            Z35MunicipioID = A35MunicipioID;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_050( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A35MunicipioID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_municipio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z44MunicipioMicroMesoUFSiglaNome, BC00052_A44MunicipioMicroMesoUFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z48MunicipioMicroMesoUFRegSiglaNo, BC00052_A48MunicipioMicroMesoUFRegSiglaNo[0]) != 0 ) || ( StringUtil.StrCmp(Z36MunicipioNome, BC00052_A36MunicipioNome[0]) != 0 ) || ( Z37MunicipioMicroID != BC00052_A37MunicipioMicroID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_municipio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000510 */
                     pr_default.execute(8, new Object[] {A38MunicipioMicroNome, A39MunicipioMicroMesoID, n40MunicipioMicroMesoNome, A40MunicipioMicroMesoNome, n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID, n42MunicipioMicroMesoUFSigla, A42MunicipioMicroMesoUFSigla, n43MunicipioMicroMesoUFNome, A43MunicipioMicroMesoUFNome, n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID, n46MunicipioMicroMesoUFRegSigla, A46MunicipioMicroMesoUFRegSigla, n47MunicipioMicroMesoUFRegNome, A47MunicipioMicroMesoUFRegNome, n44MunicipioMicroMesoUFSiglaNome, A44MunicipioMicroMesoUFSiglaNome, n48MunicipioMicroMesoUFRegSiglaNo, A48MunicipioMicroMesoUFRegSiglaNo, A35MunicipioID, A36MunicipioNome, A37MunicipioMicroID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000511 */
                     pr_default.execute(9, new Object[] {A38MunicipioMicroNome, A39MunicipioMicroMesoID, n40MunicipioMicroMesoNome, A40MunicipioMicroMesoNome, n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID, n42MunicipioMicroMesoUFSigla, A42MunicipioMicroMesoUFSigla, n43MunicipioMicroMesoUFNome, A43MunicipioMicroMesoUFNome, n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID, n46MunicipioMicroMesoUFRegSigla, A46MunicipioMicroMesoUFRegSigla, n47MunicipioMicroMesoUFRegNome, A47MunicipioMicroMesoUFRegNome, n44MunicipioMicroMesoUFSiglaNome, A44MunicipioMicroMesoUFSiglaNome, n48MunicipioMicroMesoUFRegSiglaNo, A48MunicipioMicroMesoUFRegSiglaNo, A36MunicipioNome, A37MunicipioMicroID, A35MunicipioID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_municipio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000512 */
                  pr_default.execute(10, new Object[] {A35MunicipioID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000513 */
            pr_default.execute(11, new Object[] {A37MunicipioMicroID});
            A38MunicipioMicroNome = BC000513_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = BC000513_A39MunicipioMicroMesoID[0];
            pr_default.close(11);
            /* Using cursor BC000514 */
            pr_default.execute(12, new Object[] {A39MunicipioMicroMesoID});
            A40MunicipioMicroMesoNome = BC000514_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = BC000514_n40MunicipioMicroMesoNome[0];
            A41MunicipioMicroMesoUFID = BC000514_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = BC000514_n41MunicipioMicroMesoUFID[0];
            pr_default.close(12);
            /* Using cursor BC000515 */
            pr_default.execute(13, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
            A42MunicipioMicroMesoUFSigla = BC000515_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = BC000515_n42MunicipioMicroMesoUFSigla[0];
            A43MunicipioMicroMesoUFNome = BC000515_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = BC000515_n43MunicipioMicroMesoUFNome[0];
            A45MunicipioMicroMesoUFRegID = BC000515_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = BC000515_n45MunicipioMicroMesoUFRegID[0];
            pr_default.close(13);
            /* Using cursor BC000516 */
            pr_default.execute(14, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
            A46MunicipioMicroMesoUFRegSigla = BC000516_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = BC000516_n46MunicipioMicroMesoUFRegSigla[0];
            A47MunicipioMicroMesoUFRegNome = BC000516_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = BC000516_n47MunicipioMicroMesoUFRegNome[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart055( )
      {
         /* Scan By routine */
         /* Using cursor BC000517 */
         pr_default.execute(15, new Object[] {A35MunicipioID});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
            A44MunicipioMicroMesoUFSiglaNome = BC000517_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = BC000517_n44MunicipioMicroMesoUFSiglaNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = BC000517_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = BC000517_n48MunicipioMicroMesoUFRegSiglaNo[0];
            A35MunicipioID = BC000517_A35MunicipioID[0];
            A36MunicipioNome = BC000517_A36MunicipioNome[0];
            A38MunicipioMicroNome = BC000517_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = BC000517_A39MunicipioMicroMesoID[0];
            A40MunicipioMicroMesoNome = BC000517_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = BC000517_n40MunicipioMicroMesoNome[0];
            A41MunicipioMicroMesoUFID = BC000517_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = BC000517_n41MunicipioMicroMesoUFID[0];
            A42MunicipioMicroMesoUFSigla = BC000517_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = BC000517_n42MunicipioMicroMesoUFSigla[0];
            A43MunicipioMicroMesoUFNome = BC000517_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = BC000517_n43MunicipioMicroMesoUFNome[0];
            A45MunicipioMicroMesoUFRegID = BC000517_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = BC000517_n45MunicipioMicroMesoUFRegID[0];
            A46MunicipioMicroMesoUFRegSigla = BC000517_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = BC000517_n46MunicipioMicroMesoUFRegSigla[0];
            A47MunicipioMicroMesoUFRegNome = BC000517_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = BC000517_n47MunicipioMicroMesoUFRegNome[0];
            A37MunicipioMicroID = BC000517_A37MunicipioMicroID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
            A44MunicipioMicroMesoUFSiglaNome = BC000517_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = BC000517_n44MunicipioMicroMesoUFSiglaNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = BC000517_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = BC000517_n48MunicipioMicroMesoUFRegSiglaNo[0];
            A35MunicipioID = BC000517_A35MunicipioID[0];
            A36MunicipioNome = BC000517_A36MunicipioNome[0];
            A38MunicipioMicroNome = BC000517_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = BC000517_A39MunicipioMicroMesoID[0];
            A40MunicipioMicroMesoNome = BC000517_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = BC000517_n40MunicipioMicroMesoNome[0];
            A41MunicipioMicroMesoUFID = BC000517_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = BC000517_n41MunicipioMicroMesoUFID[0];
            A42MunicipioMicroMesoUFSigla = BC000517_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = BC000517_n42MunicipioMicroMesoUFSigla[0];
            A43MunicipioMicroMesoUFNome = BC000517_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = BC000517_n43MunicipioMicroMesoUFNome[0];
            A45MunicipioMicroMesoUFRegID = BC000517_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = BC000517_n45MunicipioMicroMesoUFRegID[0];
            A46MunicipioMicroMesoUFRegSigla = BC000517_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = BC000517_n46MunicipioMicroMesoUFRegSigla[0];
            A47MunicipioMicroMesoUFRegNome = BC000517_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = BC000517_n47MunicipioMicroMesoUFRegNome[0];
            A37MunicipioMicroID = BC000517_A37MunicipioMicroID[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bccore_municipio) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bccore_municipio, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A36MunicipioNome = "";
         A37MunicipioMicroID = 0;
         A38MunicipioMicroNome = "";
         A39MunicipioMicroMesoID = 0;
         A40MunicipioMicroMesoNome = "";
         n40MunicipioMicroMesoNome = false;
         A41MunicipioMicroMesoUFID = 0;
         n41MunicipioMicroMesoUFID = false;
         A42MunicipioMicroMesoUFSigla = "";
         n42MunicipioMicroMesoUFSigla = false;
         A43MunicipioMicroMesoUFNome = "";
         n43MunicipioMicroMesoUFNome = false;
         A44MunicipioMicroMesoUFSiglaNome = "";
         n44MunicipioMicroMesoUFSiglaNome = false;
         A45MunicipioMicroMesoUFRegID = 0;
         n45MunicipioMicroMesoUFRegID = false;
         A46MunicipioMicroMesoUFRegSigla = "";
         n46MunicipioMicroMesoUFRegSigla = false;
         A47MunicipioMicroMesoUFRegNome = "";
         n47MunicipioMicroMesoUFRegNome = false;
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         Z44MunicipioMicroMesoUFSiglaNome = "";
         Z48MunicipioMicroMesoUFRegSiglaNo = "";
         Z36MunicipioNome = "";
         Z37MunicipioMicroID = 0;
      }

      protected void InitAll055( )
      {
         A35MunicipioID = 0;
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow5( GeneXus.Programs.core.Sdtmunicipio obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Municipionome = A36MunicipioNome;
         obj5.gxTpr_Municipiomicroid = A37MunicipioMicroID;
         obj5.gxTpr_Municipiomicronome = A38MunicipioMicroNome;
         obj5.gxTpr_Municipiomicromesoid = A39MunicipioMicroMesoID;
         obj5.gxTpr_Municipiomicromesonome = A40MunicipioMicroMesoNome;
         obj5.gxTpr_Municipiomicromesoufid = A41MunicipioMicroMesoUFID;
         obj5.gxTpr_Municipiomicromesoufsigla = A42MunicipioMicroMesoUFSigla;
         obj5.gxTpr_Municipiomicromesoufnome = A43MunicipioMicroMesoUFNome;
         obj5.gxTpr_Municipiomicromesoufsiglanome = A44MunicipioMicroMesoUFSiglaNome;
         obj5.gxTpr_Municipiomicromesoufregid = A45MunicipioMicroMesoUFRegID;
         obj5.gxTpr_Municipiomicromesoufregsigla = A46MunicipioMicroMesoUFRegSigla;
         obj5.gxTpr_Municipiomicromesoufregnome = A47MunicipioMicroMesoUFRegNome;
         obj5.gxTpr_Municipiomicromesoufregsiglanome = A48MunicipioMicroMesoUFRegSiglaNo;
         obj5.gxTpr_Municipioid = A35MunicipioID;
         obj5.gxTpr_Municipioid_Z = Z35MunicipioID;
         obj5.gxTpr_Municipionome_Z = Z36MunicipioNome;
         obj5.gxTpr_Municipiomicroid_Z = Z37MunicipioMicroID;
         obj5.gxTpr_Municipiomicronome_Z = Z38MunicipioMicroNome;
         obj5.gxTpr_Municipiomicromesoid_Z = Z39MunicipioMicroMesoID;
         obj5.gxTpr_Municipiomicromesonome_Z = Z40MunicipioMicroMesoNome;
         obj5.gxTpr_Municipiomicromesoufid_Z = Z41MunicipioMicroMesoUFID;
         obj5.gxTpr_Municipiomicromesoufsigla_Z = Z42MunicipioMicroMesoUFSigla;
         obj5.gxTpr_Municipiomicromesoufnome_Z = Z43MunicipioMicroMesoUFNome;
         obj5.gxTpr_Municipiomicromesoufsiglanome_Z = Z44MunicipioMicroMesoUFSiglaNome;
         obj5.gxTpr_Municipiomicromesoufregid_Z = Z45MunicipioMicroMesoUFRegID;
         obj5.gxTpr_Municipiomicromesoufregsigla_Z = Z46MunicipioMicroMesoUFRegSigla;
         obj5.gxTpr_Municipiomicromesoufregnome_Z = Z47MunicipioMicroMesoUFRegNome;
         obj5.gxTpr_Municipiomicromesoufregsiglanome_Z = Z48MunicipioMicroMesoUFRegSiglaNo;
         obj5.gxTpr_Municipiomicromesonome_N = (short)(Convert.ToInt16(n40MunicipioMicroMesoNome));
         obj5.gxTpr_Municipiomicromesoufid_N = (short)(Convert.ToInt16(n41MunicipioMicroMesoUFID));
         obj5.gxTpr_Municipiomicromesoufsigla_N = (short)(Convert.ToInt16(n42MunicipioMicroMesoUFSigla));
         obj5.gxTpr_Municipiomicromesoufnome_N = (short)(Convert.ToInt16(n43MunicipioMicroMesoUFNome));
         obj5.gxTpr_Municipiomicromesoufsiglanome_N = (short)(Convert.ToInt16(n44MunicipioMicroMesoUFSiglaNome));
         obj5.gxTpr_Municipiomicromesoufregid_N = (short)(Convert.ToInt16(n45MunicipioMicroMesoUFRegID));
         obj5.gxTpr_Municipiomicromesoufregsigla_N = (short)(Convert.ToInt16(n46MunicipioMicroMesoUFRegSigla));
         obj5.gxTpr_Municipiomicromesoufregnome_N = (short)(Convert.ToInt16(n47MunicipioMicroMesoUFRegNome));
         obj5.gxTpr_Municipiomicromesoufregsiglanome_N = (short)(Convert.ToInt16(n48MunicipioMicroMesoUFRegSiglaNo));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( GeneXus.Programs.core.Sdtmunicipio obj5 )
      {
         obj5.gxTpr_Municipioid = A35MunicipioID;
         return  ;
      }

      public void RowToVars5( GeneXus.Programs.core.Sdtmunicipio obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A36MunicipioNome = obj5.gxTpr_Municipionome;
         A37MunicipioMicroID = obj5.gxTpr_Municipiomicroid;
         A38MunicipioMicroNome = obj5.gxTpr_Municipiomicronome;
         A39MunicipioMicroMesoID = obj5.gxTpr_Municipiomicromesoid;
         A40MunicipioMicroMesoNome = obj5.gxTpr_Municipiomicromesonome;
         n40MunicipioMicroMesoNome = false;
         A41MunicipioMicroMesoUFID = obj5.gxTpr_Municipiomicromesoufid;
         n41MunicipioMicroMesoUFID = false;
         A42MunicipioMicroMesoUFSigla = obj5.gxTpr_Municipiomicromesoufsigla;
         n42MunicipioMicroMesoUFSigla = false;
         A43MunicipioMicroMesoUFNome = obj5.gxTpr_Municipiomicromesoufnome;
         n43MunicipioMicroMesoUFNome = false;
         A44MunicipioMicroMesoUFSiglaNome = obj5.gxTpr_Municipiomicromesoufsiglanome;
         n44MunicipioMicroMesoUFSiglaNome = false;
         A45MunicipioMicroMesoUFRegID = obj5.gxTpr_Municipiomicromesoufregid;
         n45MunicipioMicroMesoUFRegID = false;
         A46MunicipioMicroMesoUFRegSigla = obj5.gxTpr_Municipiomicromesoufregsigla;
         n46MunicipioMicroMesoUFRegSigla = false;
         A47MunicipioMicroMesoUFRegNome = obj5.gxTpr_Municipiomicromesoufregnome;
         n47MunicipioMicroMesoUFRegNome = false;
         A48MunicipioMicroMesoUFRegSiglaNo = obj5.gxTpr_Municipiomicromesoufregsiglanome;
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         A35MunicipioID = obj5.gxTpr_Municipioid;
         Z35MunicipioID = obj5.gxTpr_Municipioid_Z;
         Z36MunicipioNome = obj5.gxTpr_Municipionome_Z;
         Z37MunicipioMicroID = obj5.gxTpr_Municipiomicroid_Z;
         Z38MunicipioMicroNome = obj5.gxTpr_Municipiomicronome_Z;
         Z39MunicipioMicroMesoID = obj5.gxTpr_Municipiomicromesoid_Z;
         Z40MunicipioMicroMesoNome = obj5.gxTpr_Municipiomicromesonome_Z;
         Z41MunicipioMicroMesoUFID = obj5.gxTpr_Municipiomicromesoufid_Z;
         Z42MunicipioMicroMesoUFSigla = obj5.gxTpr_Municipiomicromesoufsigla_Z;
         Z43MunicipioMicroMesoUFNome = obj5.gxTpr_Municipiomicromesoufnome_Z;
         Z44MunicipioMicroMesoUFSiglaNome = obj5.gxTpr_Municipiomicromesoufsiglanome_Z;
         Z45MunicipioMicroMesoUFRegID = obj5.gxTpr_Municipiomicromesoufregid_Z;
         Z46MunicipioMicroMesoUFRegSigla = obj5.gxTpr_Municipiomicromesoufregsigla_Z;
         Z47MunicipioMicroMesoUFRegNome = obj5.gxTpr_Municipiomicromesoufregnome_Z;
         Z48MunicipioMicroMesoUFRegSiglaNo = obj5.gxTpr_Municipiomicromesoufregsiglanome_Z;
         n40MunicipioMicroMesoNome = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesonome_N));
         n41MunicipioMicroMesoUFID = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufid_N));
         n42MunicipioMicroMesoUFSigla = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufsigla_N));
         n43MunicipioMicroMesoUFNome = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufnome_N));
         n44MunicipioMicroMesoUFSiglaNome = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufsiglanome_N));
         n45MunicipioMicroMesoUFRegID = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufregid_N));
         n46MunicipioMicroMesoUFRegSigla = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufregsigla_N));
         n47MunicipioMicroMesoUFRegNome = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufregnome_N));
         n48MunicipioMicroMesoUFRegSiglaNo = (bool)(Convert.ToBoolean(obj5.gxTpr_Municipiomicromesoufregsiglanome_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A35MunicipioID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z35MunicipioID = A35MunicipioID;
         }
         ZM055( -5) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars5( bccore_municipio, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z35MunicipioID = A35MunicipioID;
         }
         ZM055( -5) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A35MunicipioID != Z35MunicipioID )
               {
                  A35MunicipioID = Z35MunicipioID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update055( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A35MunicipioID != Z35MunicipioID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert055( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert055( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bccore_municipio, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bccore_municipio) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bccore_municipio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bccore_municipio) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bccore_municipio) ;
         }
         else
         {
            GeneXus.Programs.core.Sdtmunicipio auxBC = new GeneXus.Programs.core.Sdtmunicipio(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A35MunicipioID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_municipio);
               auxBC.Save();
               bccore_municipio.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bccore_municipio, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bccore_municipio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow5( bccore_municipio) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bccore_municipio) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bccore_municipio, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A35MunicipioID != Z35MunicipioID )
            {
               A35MunicipioID = Z35MunicipioID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A35MunicipioID != Z35MunicipioID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("core.municipio_bc",pr_default);
         VarsToRow5( bccore_municipio) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bccore_municipio.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_municipio.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_municipio )
         {
            bccore_municipio = (GeneXus.Programs.core.Sdtmunicipio)(sdt);
            if ( StringUtil.StrCmp(bccore_municipio.gxTpr_Mode, "") == 0 )
            {
               bccore_municipio.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bccore_municipio) ;
            }
            else
            {
               RowToVars5( bccore_municipio, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_municipio.gxTpr_Mode, "") == 0 )
            {
               bccore_municipio.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bccore_municipio, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtmunicipio municipio_BC
      {
         get {
            return bccore_municipio ;
         }

      }

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
            return "municipio_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV25Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z44MunicipioMicroMesoUFSiglaNome = "";
         A44MunicipioMicroMesoUFSiglaNome = "";
         Z48MunicipioMicroMesoUFRegSiglaNo = "";
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         Z36MunicipioNome = "";
         A36MunicipioNome = "";
         Z38MunicipioMicroNome = "";
         A38MunicipioMicroNome = "";
         Z40MunicipioMicroMesoNome = "";
         A40MunicipioMicroMesoNome = "";
         Z42MunicipioMicroMesoUFSigla = "";
         A42MunicipioMicroMesoUFSigla = "";
         Z43MunicipioMicroMesoUFNome = "";
         A43MunicipioMicroMesoUFNome = "";
         Z46MunicipioMicroMesoUFRegSigla = "";
         A46MunicipioMicroMesoUFRegSigla = "";
         Z47MunicipioMicroMesoUFRegNome = "";
         A47MunicipioMicroMesoUFRegNome = "";
         BC00058_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         BC00058_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         BC00058_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         BC00058_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         BC00058_A35MunicipioID = new int[1] ;
         BC00058_A36MunicipioNome = new string[] {""} ;
         BC00058_A38MunicipioMicroNome = new string[] {""} ;
         BC00058_A39MunicipioMicroMesoID = new int[1] ;
         BC00058_A40MunicipioMicroMesoNome = new string[] {""} ;
         BC00058_n40MunicipioMicroMesoNome = new bool[] {false} ;
         BC00058_A41MunicipioMicroMesoUFID = new int[1] ;
         BC00058_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         BC00058_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         BC00058_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         BC00058_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         BC00058_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         BC00058_A45MunicipioMicroMesoUFRegID = new int[1] ;
         BC00058_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         BC00058_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         BC00058_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         BC00058_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         BC00058_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         BC00058_A37MunicipioMicroID = new int[1] ;
         BC00057_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         BC00057_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         BC00057_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         BC00057_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         BC00054_A38MunicipioMicroNome = new string[] {""} ;
         BC00054_A39MunicipioMicroMesoID = new int[1] ;
         BC00055_A40MunicipioMicroMesoNome = new string[] {""} ;
         BC00055_n40MunicipioMicroMesoNome = new bool[] {false} ;
         BC00055_A41MunicipioMicroMesoUFID = new int[1] ;
         BC00055_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         BC00056_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         BC00056_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         BC00056_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         BC00056_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         BC00056_A45MunicipioMicroMesoUFRegID = new int[1] ;
         BC00056_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         BC00059_A35MunicipioID = new int[1] ;
         BC00053_A35MunicipioID = new int[1] ;
         BC00053_A36MunicipioNome = new string[] {""} ;
         BC00053_A37MunicipioMicroID = new int[1] ;
         BC00053_A38MunicipioMicroNome = new string[] {""} ;
         BC00053_A39MunicipioMicroMesoID = new int[1] ;
         BC00053_A40MunicipioMicroMesoNome = new string[] {""} ;
         BC00053_n40MunicipioMicroMesoNome = new bool[] {false} ;
         BC00053_A41MunicipioMicroMesoUFID = new int[1] ;
         BC00053_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         BC00053_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         BC00053_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         BC00053_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         BC00053_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         BC00053_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         BC00053_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         BC00053_A45MunicipioMicroMesoUFRegID = new int[1] ;
         BC00053_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         BC00053_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         BC00053_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         BC00053_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         BC00053_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         BC00053_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         BC00053_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         sMode5 = "";
         BC00052_A35MunicipioID = new int[1] ;
         BC00052_A36MunicipioNome = new string[] {""} ;
         BC00052_A37MunicipioMicroID = new int[1] ;
         BC00052_A38MunicipioMicroNome = new string[] {""} ;
         BC00052_A39MunicipioMicroMesoID = new int[1] ;
         BC00052_A40MunicipioMicroMesoNome = new string[] {""} ;
         BC00052_n40MunicipioMicroMesoNome = new bool[] {false} ;
         BC00052_A41MunicipioMicroMesoUFID = new int[1] ;
         BC00052_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         BC00052_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         BC00052_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         BC00052_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         BC00052_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         BC00052_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         BC00052_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         BC00052_A45MunicipioMicroMesoUFRegID = new int[1] ;
         BC00052_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         BC00052_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         BC00052_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         BC00052_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         BC00052_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         BC00052_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         BC00052_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         BC000513_A38MunicipioMicroNome = new string[] {""} ;
         BC000513_A39MunicipioMicroMesoID = new int[1] ;
         BC000514_A40MunicipioMicroMesoNome = new string[] {""} ;
         BC000514_n40MunicipioMicroMesoNome = new bool[] {false} ;
         BC000514_A41MunicipioMicroMesoUFID = new int[1] ;
         BC000514_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         BC000515_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         BC000515_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         BC000515_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         BC000515_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         BC000515_A45MunicipioMicroMesoUFRegID = new int[1] ;
         BC000515_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         BC000516_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         BC000516_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         BC000516_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         BC000516_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         BC000517_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         BC000517_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         BC000517_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         BC000517_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         BC000517_A35MunicipioID = new int[1] ;
         BC000517_A36MunicipioNome = new string[] {""} ;
         BC000517_A38MunicipioMicroNome = new string[] {""} ;
         BC000517_A39MunicipioMicroMesoID = new int[1] ;
         BC000517_A40MunicipioMicroMesoNome = new string[] {""} ;
         BC000517_n40MunicipioMicroMesoNome = new bool[] {false} ;
         BC000517_A41MunicipioMicroMesoUFID = new int[1] ;
         BC000517_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         BC000517_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         BC000517_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         BC000517_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         BC000517_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         BC000517_A45MunicipioMicroMesoUFRegID = new int[1] ;
         BC000517_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         BC000517_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         BC000517_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         BC000517_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         BC000517_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         BC000517_A37MunicipioMicroID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.municipio_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.municipio_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A35MunicipioID, BC00052_A36MunicipioNome, BC00052_A37MunicipioMicroID, BC00052_A38MunicipioMicroNome, BC00052_A39MunicipioMicroMesoID, BC00052_A40MunicipioMicroMesoNome, BC00052_n40MunicipioMicroMesoNome, BC00052_A41MunicipioMicroMesoUFID, BC00052_n41MunicipioMicroMesoUFID, BC00052_A42MunicipioMicroMesoUFSigla,
               BC00052_n42MunicipioMicroMesoUFSigla, BC00052_A43MunicipioMicroMesoUFNome, BC00052_n43MunicipioMicroMesoUFNome, BC00052_A44MunicipioMicroMesoUFSiglaNome, BC00052_n44MunicipioMicroMesoUFSiglaNome, BC00052_A45MunicipioMicroMesoUFRegID, BC00052_n45MunicipioMicroMesoUFRegID, BC00052_A46MunicipioMicroMesoUFRegSigla, BC00052_n46MunicipioMicroMesoUFRegSigla, BC00052_A47MunicipioMicroMesoUFRegNome,
               BC00052_n47MunicipioMicroMesoUFRegNome, BC00052_A48MunicipioMicroMesoUFRegSiglaNo, BC00052_n48MunicipioMicroMesoUFRegSiglaNo
               }
               , new Object[] {
               BC00053_A35MunicipioID, BC00053_A36MunicipioNome, BC00053_A37MunicipioMicroID, BC00053_A38MunicipioMicroNome, BC00053_A39MunicipioMicroMesoID, BC00053_A40MunicipioMicroMesoNome, BC00053_n40MunicipioMicroMesoNome, BC00053_A41MunicipioMicroMesoUFID, BC00053_n41MunicipioMicroMesoUFID, BC00053_A42MunicipioMicroMesoUFSigla,
               BC00053_n42MunicipioMicroMesoUFSigla, BC00053_A43MunicipioMicroMesoUFNome, BC00053_n43MunicipioMicroMesoUFNome, BC00053_A44MunicipioMicroMesoUFSiglaNome, BC00053_n44MunicipioMicroMesoUFSiglaNome, BC00053_A45MunicipioMicroMesoUFRegID, BC00053_n45MunicipioMicroMesoUFRegID, BC00053_A46MunicipioMicroMesoUFRegSigla, BC00053_n46MunicipioMicroMesoUFRegSigla, BC00053_A47MunicipioMicroMesoUFRegNome,
               BC00053_n47MunicipioMicroMesoUFRegNome, BC00053_A48MunicipioMicroMesoUFRegSiglaNo, BC00053_n48MunicipioMicroMesoUFRegSiglaNo
               }
               , new Object[] {
               BC00054_A38MunicipioMicroNome, BC00054_A39MunicipioMicroMesoID
               }
               , new Object[] {
               BC00055_A40MunicipioMicroMesoNome, BC00055_A41MunicipioMicroMesoUFID
               }
               , new Object[] {
               BC00056_A42MunicipioMicroMesoUFSigla, BC00056_A43MunicipioMicroMesoUFNome, BC00056_A45MunicipioMicroMesoUFRegID
               }
               , new Object[] {
               BC00057_A46MunicipioMicroMesoUFRegSigla, BC00057_A47MunicipioMicroMesoUFRegNome
               }
               , new Object[] {
               BC00058_A44MunicipioMicroMesoUFSiglaNome, BC00058_n44MunicipioMicroMesoUFSiglaNome, BC00058_A48MunicipioMicroMesoUFRegSiglaNo, BC00058_n48MunicipioMicroMesoUFRegSiglaNo, BC00058_A35MunicipioID, BC00058_A36MunicipioNome, BC00058_A38MunicipioMicroNome, BC00058_A39MunicipioMicroMesoID, BC00058_A40MunicipioMicroMesoNome, BC00058_n40MunicipioMicroMesoNome,
               BC00058_A41MunicipioMicroMesoUFID, BC00058_n41MunicipioMicroMesoUFID, BC00058_A42MunicipioMicroMesoUFSigla, BC00058_n42MunicipioMicroMesoUFSigla, BC00058_A43MunicipioMicroMesoUFNome, BC00058_n43MunicipioMicroMesoUFNome, BC00058_A45MunicipioMicroMesoUFRegID, BC00058_n45MunicipioMicroMesoUFRegID, BC00058_A46MunicipioMicroMesoUFRegSigla, BC00058_n46MunicipioMicroMesoUFRegSigla,
               BC00058_A47MunicipioMicroMesoUFRegNome, BC00058_n47MunicipioMicroMesoUFRegNome, BC00058_A37MunicipioMicroID
               }
               , new Object[] {
               BC00059_A35MunicipioID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000513_A38MunicipioMicroNome, BC000513_A39MunicipioMicroMesoID
               }
               , new Object[] {
               BC000514_A40MunicipioMicroMesoNome, BC000514_A41MunicipioMicroMesoUFID
               }
               , new Object[] {
               BC000515_A42MunicipioMicroMesoUFSigla, BC000515_A43MunicipioMicroMesoUFNome, BC000515_A45MunicipioMicroMesoUFRegID
               }
               , new Object[] {
               BC000516_A46MunicipioMicroMesoUFRegSigla, BC000516_A47MunicipioMicroMesoUFRegNome
               }
               , new Object[] {
               BC000517_A44MunicipioMicroMesoUFSiglaNome, BC000517_n44MunicipioMicroMesoUFSiglaNome, BC000517_A48MunicipioMicroMesoUFRegSiglaNo, BC000517_n48MunicipioMicroMesoUFRegSiglaNo, BC000517_A35MunicipioID, BC000517_A36MunicipioNome, BC000517_A38MunicipioMicroNome, BC000517_A39MunicipioMicroMesoID, BC000517_A40MunicipioMicroMesoNome, BC000517_n40MunicipioMicroMesoNome,
               BC000517_A41MunicipioMicroMesoUFID, BC000517_n41MunicipioMicroMesoUFID, BC000517_A42MunicipioMicroMesoUFSigla, BC000517_n42MunicipioMicroMesoUFSigla, BC000517_A43MunicipioMicroMesoUFNome, BC000517_n43MunicipioMicroMesoUFNome, BC000517_A45MunicipioMicroMesoUFRegID, BC000517_n45MunicipioMicroMesoUFRegID, BC000517_A46MunicipioMicroMesoUFRegSigla, BC000517_n46MunicipioMicroMesoUFRegSigla,
               BC000517_A47MunicipioMicroMesoUFRegNome, BC000517_n47MunicipioMicroMesoUFRegNome, BC000517_A37MunicipioMicroID
               }
            }
         );
         AV25Pgmname = "core.municipio_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private int trnEnded ;
      private int Z35MunicipioID ;
      private int A35MunicipioID ;
      private int AV26GXV1 ;
      private int AV13Insert_MunicipioMicroID ;
      private int Z37MunicipioMicroID ;
      private int A37MunicipioMicroID ;
      private int Z39MunicipioMicroMesoID ;
      private int A39MunicipioMicroMesoID ;
      private int Z41MunicipioMicroMesoUFID ;
      private int A41MunicipioMicroMesoUFID ;
      private int Z45MunicipioMicroMesoUFRegID ;
      private int A45MunicipioMicroMesoUFRegID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string sMode5 ;
      private bool returnInSub ;
      private bool n44MunicipioMicroMesoUFSiglaNome ;
      private bool n48MunicipioMicroMesoUFRegSiglaNo ;
      private bool n40MunicipioMicroMesoNome ;
      private bool n41MunicipioMicroMesoUFID ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n43MunicipioMicroMesoUFNome ;
      private bool n45MunicipioMicroMesoUFRegID ;
      private bool n46MunicipioMicroMesoUFRegSigla ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool mustCommit ;
      private string Z44MunicipioMicroMesoUFSiglaNome ;
      private string A44MunicipioMicroMesoUFSiglaNome ;
      private string Z48MunicipioMicroMesoUFRegSiglaNo ;
      private string A48MunicipioMicroMesoUFRegSiglaNo ;
      private string Z36MunicipioNome ;
      private string A36MunicipioNome ;
      private string Z38MunicipioMicroNome ;
      private string A38MunicipioMicroNome ;
      private string Z40MunicipioMicroMesoNome ;
      private string A40MunicipioMicroMesoNome ;
      private string Z42MunicipioMicroMesoUFSigla ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string Z43MunicipioMicroMesoUFNome ;
      private string A43MunicipioMicroMesoUFNome ;
      private string Z46MunicipioMicroMesoUFRegSigla ;
      private string A46MunicipioMicroMesoUFRegSigla ;
      private string Z47MunicipioMicroMesoUFRegNome ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.Sdtmunicipio bccore_municipio ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00058_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] BC00058_n44MunicipioMicroMesoUFSiglaNome ;
      private string[] BC00058_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] BC00058_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] BC00058_A35MunicipioID ;
      private string[] BC00058_A36MunicipioNome ;
      private string[] BC00058_A38MunicipioMicroNome ;
      private int[] BC00058_A39MunicipioMicroMesoID ;
      private string[] BC00058_A40MunicipioMicroMesoNome ;
      private bool[] BC00058_n40MunicipioMicroMesoNome ;
      private int[] BC00058_A41MunicipioMicroMesoUFID ;
      private bool[] BC00058_n41MunicipioMicroMesoUFID ;
      private string[] BC00058_A42MunicipioMicroMesoUFSigla ;
      private bool[] BC00058_n42MunicipioMicroMesoUFSigla ;
      private string[] BC00058_A43MunicipioMicroMesoUFNome ;
      private bool[] BC00058_n43MunicipioMicroMesoUFNome ;
      private int[] BC00058_A45MunicipioMicroMesoUFRegID ;
      private bool[] BC00058_n45MunicipioMicroMesoUFRegID ;
      private string[] BC00058_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] BC00058_n46MunicipioMicroMesoUFRegSigla ;
      private string[] BC00058_A47MunicipioMicroMesoUFRegNome ;
      private bool[] BC00058_n47MunicipioMicroMesoUFRegNome ;
      private int[] BC00058_A37MunicipioMicroID ;
      private string[] BC00057_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] BC00057_n46MunicipioMicroMesoUFRegSigla ;
      private string[] BC00057_A47MunicipioMicroMesoUFRegNome ;
      private bool[] BC00057_n47MunicipioMicroMesoUFRegNome ;
      private string[] BC00054_A38MunicipioMicroNome ;
      private int[] BC00054_A39MunicipioMicroMesoID ;
      private string[] BC00055_A40MunicipioMicroMesoNome ;
      private bool[] BC00055_n40MunicipioMicroMesoNome ;
      private int[] BC00055_A41MunicipioMicroMesoUFID ;
      private bool[] BC00055_n41MunicipioMicroMesoUFID ;
      private string[] BC00056_A42MunicipioMicroMesoUFSigla ;
      private bool[] BC00056_n42MunicipioMicroMesoUFSigla ;
      private string[] BC00056_A43MunicipioMicroMesoUFNome ;
      private bool[] BC00056_n43MunicipioMicroMesoUFNome ;
      private int[] BC00056_A45MunicipioMicroMesoUFRegID ;
      private bool[] BC00056_n45MunicipioMicroMesoUFRegID ;
      private int[] BC00059_A35MunicipioID ;
      private int[] BC00053_A35MunicipioID ;
      private string[] BC00053_A36MunicipioNome ;
      private int[] BC00053_A37MunicipioMicroID ;
      private string[] BC00053_A38MunicipioMicroNome ;
      private int[] BC00053_A39MunicipioMicroMesoID ;
      private string[] BC00053_A40MunicipioMicroMesoNome ;
      private bool[] BC00053_n40MunicipioMicroMesoNome ;
      private int[] BC00053_A41MunicipioMicroMesoUFID ;
      private bool[] BC00053_n41MunicipioMicroMesoUFID ;
      private string[] BC00053_A42MunicipioMicroMesoUFSigla ;
      private bool[] BC00053_n42MunicipioMicroMesoUFSigla ;
      private string[] BC00053_A43MunicipioMicroMesoUFNome ;
      private bool[] BC00053_n43MunicipioMicroMesoUFNome ;
      private string[] BC00053_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] BC00053_n44MunicipioMicroMesoUFSiglaNome ;
      private int[] BC00053_A45MunicipioMicroMesoUFRegID ;
      private bool[] BC00053_n45MunicipioMicroMesoUFRegID ;
      private string[] BC00053_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] BC00053_n46MunicipioMicroMesoUFRegSigla ;
      private string[] BC00053_A47MunicipioMicroMesoUFRegNome ;
      private bool[] BC00053_n47MunicipioMicroMesoUFRegNome ;
      private string[] BC00053_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] BC00053_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] BC00052_A35MunicipioID ;
      private string[] BC00052_A36MunicipioNome ;
      private int[] BC00052_A37MunicipioMicroID ;
      private string[] BC00052_A38MunicipioMicroNome ;
      private int[] BC00052_A39MunicipioMicroMesoID ;
      private string[] BC00052_A40MunicipioMicroMesoNome ;
      private bool[] BC00052_n40MunicipioMicroMesoNome ;
      private int[] BC00052_A41MunicipioMicroMesoUFID ;
      private bool[] BC00052_n41MunicipioMicroMesoUFID ;
      private string[] BC00052_A42MunicipioMicroMesoUFSigla ;
      private bool[] BC00052_n42MunicipioMicroMesoUFSigla ;
      private string[] BC00052_A43MunicipioMicroMesoUFNome ;
      private bool[] BC00052_n43MunicipioMicroMesoUFNome ;
      private string[] BC00052_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] BC00052_n44MunicipioMicroMesoUFSiglaNome ;
      private int[] BC00052_A45MunicipioMicroMesoUFRegID ;
      private bool[] BC00052_n45MunicipioMicroMesoUFRegID ;
      private string[] BC00052_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] BC00052_n46MunicipioMicroMesoUFRegSigla ;
      private string[] BC00052_A47MunicipioMicroMesoUFRegNome ;
      private bool[] BC00052_n47MunicipioMicroMesoUFRegNome ;
      private string[] BC00052_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] BC00052_n48MunicipioMicroMesoUFRegSiglaNo ;
      private string[] BC000513_A38MunicipioMicroNome ;
      private int[] BC000513_A39MunicipioMicroMesoID ;
      private string[] BC000514_A40MunicipioMicroMesoNome ;
      private bool[] BC000514_n40MunicipioMicroMesoNome ;
      private int[] BC000514_A41MunicipioMicroMesoUFID ;
      private bool[] BC000514_n41MunicipioMicroMesoUFID ;
      private string[] BC000515_A42MunicipioMicroMesoUFSigla ;
      private bool[] BC000515_n42MunicipioMicroMesoUFSigla ;
      private string[] BC000515_A43MunicipioMicroMesoUFNome ;
      private bool[] BC000515_n43MunicipioMicroMesoUFNome ;
      private int[] BC000515_A45MunicipioMicroMesoUFRegID ;
      private bool[] BC000515_n45MunicipioMicroMesoUFRegID ;
      private string[] BC000516_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] BC000516_n46MunicipioMicroMesoUFRegSigla ;
      private string[] BC000516_A47MunicipioMicroMesoUFRegNome ;
      private bool[] BC000516_n47MunicipioMicroMesoUFRegNome ;
      private string[] BC000517_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] BC000517_n44MunicipioMicroMesoUFSiglaNome ;
      private string[] BC000517_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] BC000517_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] BC000517_A35MunicipioID ;
      private string[] BC000517_A36MunicipioNome ;
      private string[] BC000517_A38MunicipioMicroNome ;
      private int[] BC000517_A39MunicipioMicroMesoID ;
      private string[] BC000517_A40MunicipioMicroMesoNome ;
      private bool[] BC000517_n40MunicipioMicroMesoNome ;
      private int[] BC000517_A41MunicipioMicroMesoUFID ;
      private bool[] BC000517_n41MunicipioMicroMesoUFID ;
      private string[] BC000517_A42MunicipioMicroMesoUFSigla ;
      private bool[] BC000517_n42MunicipioMicroMesoUFSigla ;
      private string[] BC000517_A43MunicipioMicroMesoUFNome ;
      private bool[] BC000517_n43MunicipioMicroMesoUFNome ;
      private int[] BC000517_A45MunicipioMicroMesoUFRegID ;
      private bool[] BC000517_n45MunicipioMicroMesoUFRegID ;
      private string[] BC000517_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] BC000517_n46MunicipioMicroMesoUFRegSigla ;
      private string[] BC000517_A47MunicipioMicroMesoUFRegNome ;
      private bool[] BC000517_n47MunicipioMicroMesoUFRegNome ;
      private int[] BC000517_A37MunicipioMicroID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class municipio_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class municipio_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00058;
        prmBC00058 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmBC00054;
        prmBC00054 = new Object[] {
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmBC00055;
        prmBC00055 = new Object[] {
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0)
        };
        Object[] prmBC00056;
        prmBC00056 = new Object[] {
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmBC00057;
        prmBC00057 = new Object[] {
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmBC00059;
        prmBC00059 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmBC00053;
        prmBC00053 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmBC00052;
        prmBC00052 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmBC000510;
        prmBC000510 = new Object[] {
        new ParDef("MunicipioMicroNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0) ,
        new ParDef("MunicipioMicroMesoNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSiglaNo",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioID",GXType.Int32,9,0) ,
        new ParDef("MunicipioNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmBC000511;
        prmBC000511 = new Object[] {
        new ParDef("MunicipioMicroNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0) ,
        new ParDef("MunicipioMicroMesoNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSiglaNo",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroID",GXType.Int32,9,0) ,
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmBC000512;
        prmBC000512 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmBC000513;
        prmBC000513 = new Object[] {
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmBC000514;
        prmBC000514 = new Object[] {
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0)
        };
        Object[] prmBC000515;
        prmBC000515 = new Object[] {
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmBC000516;
        prmBC000516 = new Object[] {
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmBC000517;
        prmBC000517 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00052", "SELECT MunicipioID, MunicipioNome, MunicipioMicroID, MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSiglaNo FROM tbibge_municipio WHERE MunicipioID = :MunicipioID  FOR UPDATE OF tbibge_municipio",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00053", "SELECT MunicipioID, MunicipioNome, MunicipioMicroID, MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSiglaNo FROM tbibge_municipio WHERE MunicipioID = :MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00054", "SELECT MicrorregiaoNome AS MunicipioMicroNome, MicrorregiaoMesoID AS MunicipioMicroMesoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MunicipioMicroID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00055", "SELECT MesorregiaoNome AS MunicipioMicroMesoNome, MesorregiaoUFID AS MunicipioMicroMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MunicipioMicroMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00056", "SELECT UFSigla AS MunicipioMicroMesoUFSigla, UFNome AS MunicipioMicroMesoUFNome, UFRegID AS MunicipioMicroMesoUFRegID FROM tbibge_uf WHERE UFID = :MunicipioMicroMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00057", "SELECT RegiaoSigla AS MunicipioMicroMesoUFRegSigla, RegiaoNome AS MunicipioMicroMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MunicipioMicroMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00058", "SELECT TM1.MunicipioMicroMesoUFSiglaNome AS MunicipioMicroMesoUFSiglaNome, TM1.MunicipioMicroMesoUFRegSiglaNo AS MunicipioMicroMesoUFRegSiglaNo, TM1.MunicipioID, TM1.MunicipioNome, TM1.MunicipioMicroNome AS MunicipioMicroNome, TM1.MunicipioMicroMesoID AS MunicipioMicroMesoID, TM1.MunicipioMicroMesoNome AS MunicipioMicroMesoNome, TM1.MunicipioMicroMesoUFID AS MunicipioMicroMesoUFID, TM1.MunicipioMicroMesoUFSigla AS MunicipioMicroMesoUFSigla, TM1.MunicipioMicroMesoUFNome AS MunicipioMicroMesoUFNome, TM1.MunicipioMicroMesoUFRegID AS MunicipioMicroMesoUFRegID, TM1.MunicipioMicroMesoUFRegSigla AS MunicipioMicroMesoUFRegSigla, TM1.MunicipioMicroMesoUFRegNome AS MunicipioMicroMesoUFRegNome, TM1.MunicipioMicroID AS MunicipioMicroID FROM (((tbibge_municipio TM1 INNER JOIN tbibge_microrregiao T2 ON T2.MicrorregiaoID = TM1.MunicipioMicroID) INNER JOIN tbibge_mesorregiao T3 ON T3.MesorregiaoID = T2.MicrorregiaoMesoID) INNER JOIN tbibge_uf T4 ON T4.UFID = T3.MesorregiaoUFID) WHERE TM1.MunicipioID = :MunicipioID ORDER BY TM1.MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00058,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00059", "SELECT MunicipioID FROM tbibge_municipio WHERE MunicipioID = :MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00059,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000510", "SAVEPOINT gxupdate;INSERT INTO tbibge_municipio(MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegSiglaNo, MunicipioID, MunicipioNome, MunicipioMicroID) VALUES(:MunicipioMicroNome, :MunicipioMicroMesoID, :MunicipioMicroMesoNome, :MunicipioMicroMesoUFID, :MunicipioMicroMesoUFSigla, :MunicipioMicroMesoUFNome, :MunicipioMicroMesoUFRegID, :MunicipioMicroMesoUFRegSigla, :MunicipioMicroMesoUFRegNome, :MunicipioMicroMesoUFSiglaNome, :MunicipioMicroMesoUFRegSiglaNo, :MunicipioID, :MunicipioNome, :MunicipioMicroID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000510)
           ,new CursorDef("BC000511", "SAVEPOINT gxupdate;UPDATE tbibge_municipio SET MunicipioMicroNome=:MunicipioMicroNome, MunicipioMicroMesoID=:MunicipioMicroMesoID, MunicipioMicroMesoNome=:MunicipioMicroMesoNome, MunicipioMicroMesoUFID=:MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla=:MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome=:MunicipioMicroMesoUFNome, MunicipioMicroMesoUFRegID=:MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla=:MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome=:MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSiglaNome=:MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegSiglaNo=:MunicipioMicroMesoUFRegSiglaNo, MunicipioNome=:MunicipioNome, MunicipioMicroID=:MunicipioMicroID  WHERE MunicipioID = :MunicipioID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000511)
           ,new CursorDef("BC000512", "SAVEPOINT gxupdate;DELETE FROM tbibge_municipio  WHERE MunicipioID = :MunicipioID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000512)
           ,new CursorDef("BC000513", "SELECT MicrorregiaoNome AS MunicipioMicroNome, MicrorregiaoMesoID AS MunicipioMicroMesoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MunicipioMicroID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000513,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000514", "SELECT MesorregiaoNome AS MunicipioMicroMesoNome, MesorregiaoUFID AS MunicipioMicroMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MunicipioMicroMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000514,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000515", "SELECT UFSigla AS MunicipioMicroMesoUFSigla, UFNome AS MunicipioMicroMesoUFNome, UFRegID AS MunicipioMicroMesoUFRegID FROM tbibge_uf WHERE UFID = :MunicipioMicroMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000515,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000516", "SELECT RegiaoSigla AS MunicipioMicroMesoUFRegSigla, RegiaoNome AS MunicipioMicroMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MunicipioMicroMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000516,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000517", "SELECT TM1.MunicipioMicroMesoUFSiglaNome AS MunicipioMicroMesoUFSiglaNome, TM1.MunicipioMicroMesoUFRegSiglaNo AS MunicipioMicroMesoUFRegSiglaNo, TM1.MunicipioID, TM1.MunicipioNome, TM1.MunicipioMicroNome AS MunicipioMicroNome, TM1.MunicipioMicroMesoID AS MunicipioMicroMesoID, TM1.MunicipioMicroMesoNome AS MunicipioMicroMesoNome, TM1.MunicipioMicroMesoUFID AS MunicipioMicroMesoUFID, TM1.MunicipioMicroMesoUFSigla AS MunicipioMicroMesoUFSigla, TM1.MunicipioMicroMesoUFNome AS MunicipioMicroMesoUFNome, TM1.MunicipioMicroMesoUFRegID AS MunicipioMicroMesoUFRegID, TM1.MunicipioMicroMesoUFRegSigla AS MunicipioMicroMesoUFRegSigla, TM1.MunicipioMicroMesoUFRegNome AS MunicipioMicroMesoUFRegNome, TM1.MunicipioMicroID AS MunicipioMicroID FROM (((tbibge_municipio TM1 INNER JOIN tbibge_microrregiao T2 ON T2.MicrorregiaoID = TM1.MunicipioMicroID) INNER JOIN tbibge_mesorregiao T3 ON T3.MesorregiaoID = T2.MicrorregiaoMesoID) INNER JOIN tbibge_uf T4 ON T4.UFID = T3.MesorregiaoUFID) WHERE TM1.MunicipioID = :MunicipioID ORDER BY TM1.MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000517,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((int[]) buf[15])[0] = rslt.getInt(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getVarchar(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((int[]) buf[15])[0] = rslt.getInt(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getVarchar(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((int[]) buf[7])[0] = rslt.getInt(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((int[]) buf[10])[0] = rslt.getInt(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((int[]) buf[16])[0] = rslt.getInt(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((string[]) buf[20])[0] = rslt.getVarchar(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((int[]) buf[22])[0] = rslt.getInt(14);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((int[]) buf[7])[0] = rslt.getInt(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((int[]) buf[10])[0] = rslt.getInt(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((int[]) buf[16])[0] = rslt.getInt(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((string[]) buf[20])[0] = rslt.getVarchar(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((int[]) buf[22])[0] = rslt.getInt(14);
              return;
     }
  }

}

}
