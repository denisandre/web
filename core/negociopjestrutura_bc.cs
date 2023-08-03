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
   public class negociopjestrutura_bc : GxSilentTrn, IGxSilentTrn
   {
      public negociopjestrutura_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjestrutura_bc( IGxContext context )
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
         ReadRow1337( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1337( ) ;
         standaloneModal( ) ;
         AddRow1337( ) ;
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
            E11132 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z345NegID = A345NegID;
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1337( ) ;
            }
            else
            {
               CheckExtendedTable1337( ) ;
               if ( AnyError == 0 )
               {
                  ZM1337( 67) ;
                  ZM1337( 68) ;
                  ZM1337( 69) ;
                  ZM1337( 70) ;
                  ZM1337( 71) ;
                  ZM1337( 72) ;
                  ZM1337( 73) ;
                  ZM1337( 74) ;
                  ZM1337( 75) ;
               }
               CloseExtendedTableCursors1337( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode37 = Gx_mode;
            CONFIRM_1339( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_1342( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode37;
                  IsConfirmed = 1;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode37;
         }
      }

      protected void CONFIRM_1342( )
      {
         s454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         s448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < bccore_NegocioPJEstrutura.gxTpr_Item.Count )
         {
            ReadRow1342( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound42 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_42 != 0 ) )
            {
               GetKey1342( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound42 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1342( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1342( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1342( 79) ;
                           ZM1342( 80) ;
                        }
                        CloseExtendedTableCursors1342( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O454NegUltItem = A454NegUltItem;
                        n454NegUltItem = false;
                        O448NegPgpTotal = A448NegPgpTotal;
                        n448NegPgpTotal = false;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound42 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1342( ) ;
                        Load1342( ) ;
                        BeforeValidate1342( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1342( ) ;
                           O454NegUltItem = A454NegUltItem;
                           n454NegUltItem = false;
                           O448NegPgpTotal = A448NegPgpTotal;
                           n448NegPgpTotal = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_42 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1342( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1342( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1342( 79) ;
                                 ZM1342( 80) ;
                              }
                              CloseExtendedTableCursors1342( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O454NegUltItem = A454NegUltItem;
                              n454NegUltItem = false;
                              O448NegPgpTotal = A448NegPgpTotal;
                              n448NegPgpTotal = false;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow42( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)bccore_NegocioPJEstrutura.gxTpr_Item.Item(nGXsfl_42_idx))) ;
            }
         }
         O454NegUltItem = s454NegUltItem;
         n454NegUltItem = false;
         O448NegPgpTotal = s448NegPgpTotal;
         n448NegPgpTotal = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_1339( )
      {
         s386NegUltFase = O386NegUltFase;
         nGXsfl_39_idx = 0;
         while ( nGXsfl_39_idx < bccore_NegocioPJEstrutura.gxTpr_Fase.Count )
         {
            ReadRow1339( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound39 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_39 != 0 ) )
            {
               GetKey1339( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound39 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1339( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1339( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1339( 77) ;
                           ZM1339( 83) ;
                           ZM1339( 84) ;
                           ZM1339( 85) ;
                           ZM1339( 86) ;
                        }
                        CloseExtendedTableCursors1339( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O386NegUltFase = A386NegUltFase;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound39 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1339( ) ;
                        Load1339( ) ;
                        BeforeValidate1339( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1339( ) ;
                           O386NegUltFase = A386NegUltFase;
                        }
                     }
                     else
                     {
                        if ( nIsMod_39 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1339( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1339( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1339( 77) ;
                                 ZM1339( 83) ;
                                 ZM1339( 84) ;
                                 ZM1339( 85) ;
                                 ZM1339( 86) ;
                              }
                              CloseExtendedTableCursors1339( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O386NegUltFase = A386NegUltFase;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow39( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)bccore_NegocioPJEstrutura.gxTpr_Fase.Item(nGXsfl_39_idx))) ;
            }
         }
         O386NegUltFase = s386NegUltFase;
         /* Start of After( level) rules */
         /* Using cursor BC001310 */
         pr_default.execute(7, new Object[] {A345NegID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A474NegUltNgfSeq = BC001310_A474NegUltNgfSeq[0];
            n474NegUltNgfSeq = BC001310_n474NegUltNgfSeq[0];
         }
         else
         {
            A474NegUltNgfSeq = 0;
            n474NegUltNgfSeq = false;
         }
         /* Using cursor BC001313 */
         pr_default.execute(8, new Object[] {A345NegID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A420NegUltIteID = BC001313_A420NegUltIteID[0];
            n420NegUltIteID = BC001313_n420NegUltIteID[0];
         }
         else
         {
            A420NegUltIteID = Guid.Empty;
            n420NegUltIteID = false;
         }
         /* Using cursor BC001316 */
         pr_default.execute(9, new Object[] {A345NegID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A421NegUltIteNome = BC001316_A421NegUltIteNome[0];
            n421NegUltIteNome = BC001316_n421NegUltIteNome[0];
         }
         else
         {
            A421NegUltIteNome = "";
            n421NegUltIteNome = false;
         }
         /* Using cursor BC001319 */
         pr_default.execute(10, new Object[] {A345NegID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A479NegUltIteOrdem = BC001319_A479NegUltIteOrdem[0];
            n479NegUltIteOrdem = BC001319_n479NegUltIteOrdem[0];
         }
         else
         {
            A479NegUltIteOrdem = 0;
            n479NegUltIteOrdem = false;
         }
         /* End of After( level) rules */
      }

      protected void E12132( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "NegCliID") == 0 )
               {
                  AV13Insert_NegCliID = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "NegCpjID") == 0 )
               {
                  AV14Insert_NegCpjID = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "NegCpjEndSeq") == 0 )
               {
                  AV15Insert_NegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
            }
         }
      }

      protected void E11132( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV28AuditingObject,  AV30Pgmname) ;
      }

      protected void ZM1337( short GX_JID )
      {
         if ( ( GX_JID == 65 ) || ( GX_JID == 0 ) )
         {
            Z356NegCodigo = A356NegCodigo;
            Z348NegInsDataHora = A348NegInsDataHora;
            Z346NegInsData = A346NegInsData;
            Z347NegInsHora = A347NegInsHora;
            Z349NegInsUsuID = A349NegInsUsuID;
            Z364NegInsUsuNome = A364NegInsUsuNome;
            Z380NegValorEstimado = A380NegValorEstimado;
            Z385NegValorAtualizado = A385NegValorAtualizado;
            Z573NegDelDataHora = A573NegDelDataHora;
            Z574NegDelData = A574NegDelData;
            Z575NegDelHora = A575NegDelHora;
            Z576NegDelUsuId = A576NegDelUsuId;
            Z577NegDelUsuNome = A577NegDelUsuNome;
            Z360NegAgcID = A360NegAgcID;
            Z361NegAgcNome = A361NegAgcNome;
            Z362NegAssunto = A362NegAssunto;
            Z386NegUltFase = A386NegUltFase;
            Z454NegUltItem = A454NegUltItem;
            Z572NegDel = A572NegDel;
            Z350NegCliID = A350NegCliID;
            Z352NegCpjID = A352NegCpjID;
            Z369NegCpjEndSeq = A369NegCpjEndSeq;
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 67 ) || ( GX_JID == 0 ) )
         {
            Z473NegCliMatricula = A473NegCliMatricula;
            Z351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 68 ) || ( GX_JID == 0 ) )
         {
            Z353NegCpjNomFan = A353NegCpjNomFan;
            Z354NegCpjRazSocial = A354NegCpjRazSocial;
            Z355NegCpjMatricula = A355NegCpjMatricula;
            Z357NegPjtID = A357NegPjtID;
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 69 ) || ( GX_JID == 0 ) )
         {
            Z370NegCpjEndNome = A370NegCpjEndNome;
            Z371NegCpjEndEndereco = A371NegCpjEndEndereco;
            Z372NegCpjEndNumero = A372NegCpjEndNumero;
            Z373NegCpjEndComplem = A373NegCpjEndComplem;
            Z374NegCpjEndBairro = A374NegCpjEndBairro;
            Z375NegCpjEndMunID = A375NegCpjEndMunID;
            Z376NegCpjEndMunNome = A376NegCpjEndMunNome;
            Z377NegCpjEndUFID = A377NegCpjEndUFID;
            Z378NegCpjEndUFSigla = A378NegCpjEndUFSigla;
            Z379NegCpjEndUFNome = A379NegCpjEndUFNome;
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 70 ) || ( GX_JID == 0 ) )
         {
            Z358NegPjtSigla = A358NegPjtSigla;
            Z359NegPjtNome = A359NegPjtNome;
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 71 ) || ( GX_JID == 0 ) )
         {
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 72 ) || ( GX_JID == 0 ) )
         {
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 73 ) || ( GX_JID == 0 ) )
         {
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 74 ) || ( GX_JID == 0 ) )
         {
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 75 ) || ( GX_JID == 0 ) )
         {
            Z474NegUltNgfSeq = A474NegUltNgfSeq;
            Z420NegUltIteID = A420NegUltIteID;
            Z421NegUltIteNome = A421NegUltIteNome;
            Z479NegUltIteOrdem = A479NegUltIteOrdem;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( GX_JID == -65 )
         {
            Z345NegID = A345NegID;
            Z356NegCodigo = A356NegCodigo;
            Z348NegInsDataHora = A348NegInsDataHora;
            Z346NegInsData = A346NegInsData;
            Z347NegInsHora = A347NegInsHora;
            Z349NegInsUsuID = A349NegInsUsuID;
            Z364NegInsUsuNome = A364NegInsUsuNome;
            Z380NegValorEstimado = A380NegValorEstimado;
            Z385NegValorAtualizado = A385NegValorAtualizado;
            Z573NegDelDataHora = A573NegDelDataHora;
            Z574NegDelData = A574NegDelData;
            Z575NegDelHora = A575NegDelHora;
            Z576NegDelUsuId = A576NegDelUsuId;
            Z577NegDelUsuNome = A577NegDelUsuNome;
            Z351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            Z353NegCpjNomFan = A353NegCpjNomFan;
            Z354NegCpjRazSocial = A354NegCpjRazSocial;
            Z359NegPjtNome = A359NegPjtNome;
            Z360NegAgcID = A360NegAgcID;
            Z361NegAgcNome = A361NegAgcNome;
            Z362NegAssunto = A362NegAssunto;
            Z363NegDescricao = A363NegDescricao;
            Z386NegUltFase = A386NegUltFase;
            Z454NegUltItem = A454NegUltItem;
            Z572NegDel = A572NegDel;
            Z350NegCliID = A350NegCliID;
            Z352NegCpjID = A352NegCpjID;
            Z369NegCpjEndSeq = A369NegCpjEndSeq;
            Z448NegPgpTotal = A448NegPgpTotal;
            Z473NegCliMatricula = A473NegCliMatricula;
            Z355NegCpjMatricula = A355NegCpjMatricula;
            Z357NegPjtID = A357NegPjtID;
            Z358NegPjtSigla = A358NegPjtSigla;
            Z370NegCpjEndNome = A370NegCpjEndNome;
            Z371NegCpjEndEndereco = A371NegCpjEndEndereco;
            Z372NegCpjEndNumero = A372NegCpjEndNumero;
            Z373NegCpjEndComplem = A373NegCpjEndComplem;
            Z374NegCpjEndBairro = A374NegCpjEndBairro;
            Z375NegCpjEndMunID = A375NegCpjEndMunID;
            Z376NegCpjEndMunNome = A376NegCpjEndMunNome;
            Z377NegCpjEndUFID = A377NegCpjEndUFID;
            Z378NegCpjEndUFSigla = A378NegCpjEndUFSigla;
            Z379NegCpjEndUFNome = A379NegCpjEndUFNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV30Pgmname = "core.NegocioPJEstrutura_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A345NegID) )
         {
            A345NegID = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC001310 */
            pr_default.execute(7, new Object[] {A345NegID});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A474NegUltNgfSeq = BC001310_A474NegUltNgfSeq[0];
               n474NegUltNgfSeq = BC001310_n474NegUltNgfSeq[0];
            }
            else
            {
               A474NegUltNgfSeq = 0;
               n474NegUltNgfSeq = false;
            }
            pr_default.close(7);
            /* Using cursor BC001313 */
            pr_default.execute(8, new Object[] {A345NegID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A420NegUltIteID = BC001313_A420NegUltIteID[0];
               n420NegUltIteID = BC001313_n420NegUltIteID[0];
            }
            else
            {
               A420NegUltIteID = Guid.Empty;
               n420NegUltIteID = false;
            }
            pr_default.close(8);
            /* Using cursor BC001316 */
            pr_default.execute(9, new Object[] {A345NegID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               A421NegUltIteNome = BC001316_A421NegUltIteNome[0];
               n421NegUltIteNome = BC001316_n421NegUltIteNome[0];
            }
            else
            {
               A421NegUltIteNome = "";
               n421NegUltIteNome = false;
            }
            pr_default.close(9);
            /* Using cursor BC001319 */
            pr_default.execute(10, new Object[] {A345NegID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               A479NegUltIteOrdem = BC001319_A479NegUltIteOrdem[0];
               n479NegUltIteOrdem = BC001319_n479NegUltIteOrdem[0];
            }
            else
            {
               A479NegUltIteOrdem = 0;
               n479NegUltIteOrdem = false;
            }
            pr_default.close(10);
            /* Using cursor BC001327 */
            pr_default.execute(17, new Object[] {A345NegID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A448NegPgpTotal = BC001327_A448NegPgpTotal[0];
               n448NegPgpTotal = BC001327_n448NegPgpTotal[0];
            }
            else
            {
               A448NegPgpTotal = 0;
               n448NegPgpTotal = false;
            }
            O448NegPgpTotal = A448NegPgpTotal;
            n448NegPgpTotal = false;
            pr_default.close(17);
            A380NegValorEstimado = A448NegPgpTotal;
            A385NegValorAtualizado = A448NegPgpTotal;
         }
      }

      protected void Load1337( )
      {
         /* Using cursor BC001329 */
         pr_default.execute(18, new Object[] {A345NegID});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound37 = 1;
            A356NegCodigo = BC001329_A356NegCodigo[0];
            A348NegInsDataHora = BC001329_A348NegInsDataHora[0];
            A346NegInsData = BC001329_A346NegInsData[0];
            A347NegInsHora = BC001329_A347NegInsHora[0];
            A349NegInsUsuID = BC001329_A349NegInsUsuID[0];
            n349NegInsUsuID = BC001329_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC001329_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC001329_n364NegInsUsuNome[0];
            A380NegValorEstimado = BC001329_A380NegValorEstimado[0];
            A385NegValorAtualizado = BC001329_A385NegValorAtualizado[0];
            A573NegDelDataHora = BC001329_A573NegDelDataHora[0];
            n573NegDelDataHora = BC001329_n573NegDelDataHora[0];
            A574NegDelData = BC001329_A574NegDelData[0];
            n574NegDelData = BC001329_n574NegDelData[0];
            A575NegDelHora = BC001329_A575NegDelHora[0];
            n575NegDelHora = BC001329_n575NegDelHora[0];
            A576NegDelUsuId = BC001329_A576NegDelUsuId[0];
            n576NegDelUsuId = BC001329_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC001329_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC001329_n577NegDelUsuNome[0];
            A473NegCliMatricula = BC001329_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC001329_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = BC001329_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC001329_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC001329_A355NegCpjMatricula[0];
            A358NegPjtSigla = BC001329_A358NegPjtSigla[0];
            A359NegPjtNome = BC001329_A359NegPjtNome[0];
            A370NegCpjEndNome = BC001329_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC001329_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC001329_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC001329_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC001329_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC001329_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = BC001329_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC001329_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC001329_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC001329_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC001329_A379NegCpjEndUFNome[0];
            A360NegAgcID = BC001329_A360NegAgcID[0];
            n360NegAgcID = BC001329_n360NegAgcID[0];
            A361NegAgcNome = BC001329_A361NegAgcNome[0];
            n361NegAgcNome = BC001329_n361NegAgcNome[0];
            A362NegAssunto = BC001329_A362NegAssunto[0];
            A363NegDescricao = BC001329_A363NegDescricao[0];
            A386NegUltFase = BC001329_A386NegUltFase[0];
            A454NegUltItem = BC001329_A454NegUltItem[0];
            n454NegUltItem = BC001329_n454NegUltItem[0];
            A572NegDel = BC001329_A572NegDel[0];
            A350NegCliID = BC001329_A350NegCliID[0];
            A352NegCpjID = BC001329_A352NegCpjID[0];
            A369NegCpjEndSeq = BC001329_A369NegCpjEndSeq[0];
            A357NegPjtID = BC001329_A357NegPjtID[0];
            A448NegPgpTotal = BC001329_A448NegPgpTotal[0];
            n448NegPgpTotal = BC001329_n448NegPgpTotal[0];
            ZM1337( -65) ;
         }
         pr_default.close(18);
         OnLoadActions1337( ) ;
      }

      protected void OnLoadActions1337( )
      {
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         /* Using cursor BC001310 */
         pr_default.execute(7, new Object[] {A345NegID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A474NegUltNgfSeq = BC001310_A474NegUltNgfSeq[0];
            n474NegUltNgfSeq = BC001310_n474NegUltNgfSeq[0];
         }
         else
         {
            A474NegUltNgfSeq = 0;
            n474NegUltNgfSeq = false;
         }
         pr_default.close(7);
         /* Using cursor BC001313 */
         pr_default.execute(8, new Object[] {A345NegID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A420NegUltIteID = BC001313_A420NegUltIteID[0];
            n420NegUltIteID = BC001313_n420NegUltIteID[0];
         }
         else
         {
            A420NegUltIteID = Guid.Empty;
            n420NegUltIteID = false;
         }
         pr_default.close(8);
         /* Using cursor BC001316 */
         pr_default.execute(9, new Object[] {A345NegID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A421NegUltIteNome = BC001316_A421NegUltIteNome[0];
            n421NegUltIteNome = BC001316_n421NegUltIteNome[0];
         }
         else
         {
            A421NegUltIteNome = "";
            n421NegUltIteNome = false;
         }
         pr_default.close(9);
         /* Using cursor BC001319 */
         pr_default.execute(10, new Object[] {A345NegID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A479NegUltIteOrdem = BC001319_A479NegUltIteOrdem[0];
            n479NegUltIteOrdem = BC001319_n479NegUltIteOrdem[0];
         }
         else
         {
            A479NegUltIteOrdem = 0;
            n479NegUltIteOrdem = false;
         }
         pr_default.close(10);
         A380NegValorEstimado = A448NegPgpTotal;
         A385NegValorAtualizado = A448NegPgpTotal;
      }

      protected void CheckExtendedTable1337( )
      {
         nIsDirty_37 = 0;
         standaloneModal( ) ;
         /* Using cursor BC001310 */
         pr_default.execute(7, new Object[] {A345NegID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A474NegUltNgfSeq = BC001310_A474NegUltNgfSeq[0];
            n474NegUltNgfSeq = BC001310_n474NegUltNgfSeq[0];
         }
         else
         {
            nIsDirty_37 = 1;
            A474NegUltNgfSeq = 0;
            n474NegUltNgfSeq = false;
         }
         pr_default.close(7);
         /* Using cursor BC001313 */
         pr_default.execute(8, new Object[] {A345NegID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A420NegUltIteID = BC001313_A420NegUltIteID[0];
            n420NegUltIteID = BC001313_n420NegUltIteID[0];
         }
         else
         {
            nIsDirty_37 = 1;
            A420NegUltIteID = Guid.Empty;
            n420NegUltIteID = false;
         }
         pr_default.close(8);
         /* Using cursor BC001316 */
         pr_default.execute(9, new Object[] {A345NegID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A421NegUltIteNome = BC001316_A421NegUltIteNome[0];
            n421NegUltIteNome = BC001316_n421NegUltIteNome[0];
         }
         else
         {
            nIsDirty_37 = 1;
            A421NegUltIteNome = "";
            n421NegUltIteNome = false;
         }
         pr_default.close(9);
         /* Using cursor BC001319 */
         pr_default.execute(10, new Object[] {A345NegID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A479NegUltIteOrdem = BC001319_A479NegUltIteOrdem[0];
            n479NegUltIteOrdem = BC001319_n479NegUltIteOrdem[0];
         }
         else
         {
            nIsDirty_37 = 1;
            A479NegUltIteOrdem = 0;
            n479NegUltIteOrdem = false;
         }
         pr_default.close(10);
         /* Using cursor BC001327 */
         pr_default.execute(17, new Object[] {A345NegID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A448NegPgpTotal = BC001327_A448NegPgpTotal[0];
            n448NegPgpTotal = BC001327_n448NegPgpTotal[0];
         }
         else
         {
            nIsDirty_37 = 1;
            A448NegPgpTotal = 0;
            n448NegPgpTotal = false;
         }
         pr_default.close(17);
         nIsDirty_37 = 1;
         A380NegValorEstimado = A448NegPgpTotal;
         nIsDirty_37 = 1;
         A385NegValorAtualizado = A448NegPgpTotal;
         /* Using cursor BC001330 */
         pr_default.execute(19, new Object[] {A356NegCodigo, A345NegID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código da Negociação"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(19);
         /* Using cursor BC001322 */
         pr_default.execute(13, new Object[] {A350NegCliID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCLIID");
            AnyError = 1;
         }
         A473NegCliMatricula = BC001322_A473NegCliMatricula[0];
         A351NegCliNomeFamiliar = BC001322_A351NegCliNomeFamiliar[0];
         pr_default.close(13);
         /* Using cursor BC001323 */
         pr_default.execute(14, new Object[] {A350NegCliID, A352NegCpjID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJID");
            AnyError = 1;
         }
         A353NegCpjNomFan = BC001323_A353NegCpjNomFan[0];
         A354NegCpjRazSocial = BC001323_A354NegCpjRazSocial[0];
         A355NegCpjMatricula = BC001323_A355NegCpjMatricula[0];
         A357NegPjtID = BC001323_A357NegPjtID[0];
         pr_default.close(14);
         /* Using cursor BC001325 */
         pr_default.execute(16, new Object[] {A357NegPjtID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "NEGPJTID");
            AnyError = 1;
         }
         A358NegPjtSigla = BC001325_A358NegPjtSigla[0];
         A359NegPjtNome = BC001325_A359NegPjtNome[0];
         pr_default.close(16);
         /* Using cursor BC001324 */
         pr_default.execute(15, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJENDSEQ");
            AnyError = 1;
         }
         A370NegCpjEndNome = BC001324_A370NegCpjEndNome[0];
         A371NegCpjEndEndereco = BC001324_A371NegCpjEndEndereco[0];
         A372NegCpjEndNumero = BC001324_A372NegCpjEndNumero[0];
         A373NegCpjEndComplem = BC001324_A373NegCpjEndComplem[0];
         n373NegCpjEndComplem = BC001324_n373NegCpjEndComplem[0];
         A374NegCpjEndBairro = BC001324_A374NegCpjEndBairro[0];
         A375NegCpjEndMunID = BC001324_A375NegCpjEndMunID[0];
         A376NegCpjEndMunNome = BC001324_A376NegCpjEndMunNome[0];
         A377NegCpjEndUFID = BC001324_A377NegCpjEndUFID[0];
         A378NegCpjEndUFSigla = BC001324_A378NegCpjEndUFSigla[0];
         A379NegCpjEndUFNome = BC001324_A379NegCpjEndUFNome[0];
         pr_default.close(15);
         if ( (Guid.Empty==A350NegCliID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Cliente ID", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A352NegCpjID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID da Unidade", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A369NegCpjEndSeq) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sequência do Endereço", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A362NegAssunto)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Assunto da Negociação", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1337( )
      {
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(17);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(16);
         pr_default.close(15);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1337( )
      {
         /* Using cursor BC001331 */
         pr_default.execute(20, new Object[] {A345NegID});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001321 */
         pr_default.execute(12, new Object[] {A345NegID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            ZM1337( 65) ;
            RcdFound37 = 1;
            A345NegID = BC001321_A345NegID[0];
            A356NegCodigo = BC001321_A356NegCodigo[0];
            A348NegInsDataHora = BC001321_A348NegInsDataHora[0];
            A346NegInsData = BC001321_A346NegInsData[0];
            A347NegInsHora = BC001321_A347NegInsHora[0];
            A349NegInsUsuID = BC001321_A349NegInsUsuID[0];
            n349NegInsUsuID = BC001321_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC001321_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC001321_n364NegInsUsuNome[0];
            A380NegValorEstimado = BC001321_A380NegValorEstimado[0];
            A385NegValorAtualizado = BC001321_A385NegValorAtualizado[0];
            A573NegDelDataHora = BC001321_A573NegDelDataHora[0];
            n573NegDelDataHora = BC001321_n573NegDelDataHora[0];
            A574NegDelData = BC001321_A574NegDelData[0];
            n574NegDelData = BC001321_n574NegDelData[0];
            A575NegDelHora = BC001321_A575NegDelHora[0];
            n575NegDelHora = BC001321_n575NegDelHora[0];
            A576NegDelUsuId = BC001321_A576NegDelUsuId[0];
            n576NegDelUsuId = BC001321_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC001321_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC001321_n577NegDelUsuNome[0];
            A360NegAgcID = BC001321_A360NegAgcID[0];
            n360NegAgcID = BC001321_n360NegAgcID[0];
            A361NegAgcNome = BC001321_A361NegAgcNome[0];
            n361NegAgcNome = BC001321_n361NegAgcNome[0];
            A362NegAssunto = BC001321_A362NegAssunto[0];
            A363NegDescricao = BC001321_A363NegDescricao[0];
            A386NegUltFase = BC001321_A386NegUltFase[0];
            A454NegUltItem = BC001321_A454NegUltItem[0];
            n454NegUltItem = BC001321_n454NegUltItem[0];
            A572NegDel = BC001321_A572NegDel[0];
            A350NegCliID = BC001321_A350NegCliID[0];
            A352NegCpjID = BC001321_A352NegCpjID[0];
            A369NegCpjEndSeq = BC001321_A369NegCpjEndSeq[0];
            O454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            O386NegUltFase = A386NegUltFase;
            O572NegDel = A572NegDel;
            Z345NegID = A345NegID;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1337( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey1337( ) ;
            }
            Gx_mode = sMode37;
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey1337( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode37;
         }
         pr_default.close(12);
      }

      protected void getEqualNoModal( )
      {
         GetKey1337( ) ;
         if ( RcdFound37 == 0 )
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
         CONFIRM_130( ) ;
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

      protected void CheckOptimisticConcurrency1337( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001320 */
            pr_default.execute(11, new Object[] {A345NegID});
            if ( (pr_default.getStatus(11) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(11) == 101) || ( Z356NegCodigo != BC001320_A356NegCodigo[0] ) || ( Z348NegInsDataHora != BC001320_A348NegInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z346NegInsData ) != DateTimeUtil.ResetTime ( BC001320_A346NegInsData[0] ) ) || ( Z347NegInsHora != BC001320_A347NegInsHora[0] ) || ( StringUtil.StrCmp(Z349NegInsUsuID, BC001320_A349NegInsUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z364NegInsUsuNome, BC001320_A364NegInsUsuNome[0]) != 0 ) || ( Z380NegValorEstimado != BC001320_A380NegValorEstimado[0] ) || ( Z385NegValorAtualizado != BC001320_A385NegValorAtualizado[0] ) || ( Z573NegDelDataHora != BC001320_A573NegDelDataHora[0] ) || ( Z574NegDelData != BC001320_A574NegDelData[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z575NegDelHora != BC001320_A575NegDelHora[0] ) || ( StringUtil.StrCmp(Z576NegDelUsuId, BC001320_A576NegDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z577NegDelUsuNome, BC001320_A577NegDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z360NegAgcID, BC001320_A360NegAgcID[0]) != 0 ) || ( StringUtil.StrCmp(Z361NegAgcNome, BC001320_A361NegAgcNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z362NegAssunto, BC001320_A362NegAssunto[0]) != 0 ) || ( Z386NegUltFase != BC001320_A386NegUltFase[0] ) || ( Z454NegUltItem != BC001320_A454NegUltItem[0] ) || ( Z572NegDel != BC001320_A572NegDel[0] ) || ( Z350NegCliID != BC001320_A350NegCliID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z352NegCpjID != BC001320_A352NegCpjID[0] ) || ( Z369NegCpjEndSeq != BC001320_A369NegCpjEndSeq[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1337( )
      {
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1337( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1337( 0) ;
            CheckOptimisticConcurrency1337( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1337( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1337( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001332 */
                     pr_default.execute(21, new Object[] {A351NegCliNomeFamiliar, A353NegCpjNomFan, A354NegCpjRazSocial, A359NegPjtNome, A345NegID, A356NegCodigo, A348NegInsDataHora, A346NegInsData, A347NegInsHora, n349NegInsUsuID, A349NegInsUsuID, n364NegInsUsuNome, A364NegInsUsuNome, A380NegValorEstimado, A385NegValorAtualizado, n573NegDelDataHora, A573NegDelDataHora, n574NegDelData, A574NegDelData, n575NegDelHora, A575NegDelHora, n576NegDelUsuId, A576NegDelUsuId, n577NegDelUsuNome, A577NegDelUsuNome, n360NegAgcID, A360NegAgcID, n361NegAgcNome, A361NegAgcNome, A362NegAssunto, A363NegDescricao, A386NegUltFase, n454NegUltItem, A454NegUltItem, A572NegDel, A350NegCliID, A352NegCpjID, A369NegCpjEndSeq, n474NegUltNgfSeq, A474NegUltNgfSeq, n420NegUltIteID, A420NegUltIteID, n421NegUltIteNome, A421NegUltIteNome, n479NegUltIteOrdem, A479NegUltIteOrdem});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
                     if ( (pr_default.getStatus(21) == 1) )
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
                           ProcessLevel1337( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load1337( ) ;
            }
            EndLevel1337( ) ;
         }
         CloseExtendedTableCursors1337( ) ;
      }

      protected void Update1337( )
      {
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1337( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1337( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1337( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1337( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001333 */
                     pr_default.execute(22, new Object[] {A351NegCliNomeFamiliar, A353NegCpjNomFan, A354NegCpjRazSocial, A359NegPjtNome, A356NegCodigo, A348NegInsDataHora, A346NegInsData, A347NegInsHora, n349NegInsUsuID, A349NegInsUsuID, n364NegInsUsuNome, A364NegInsUsuNome, A380NegValorEstimado, A385NegValorAtualizado, n573NegDelDataHora, A573NegDelDataHora, n574NegDelData, A574NegDelData, n575NegDelHora, A575NegDelHora, n576NegDelUsuId, A576NegDelUsuId, n577NegDelUsuNome, A577NegDelUsuNome, n360NegAgcID, A360NegAgcID, n361NegAgcNome, A361NegAgcNome, A362NegAssunto, A363NegDescricao, A386NegUltFase, n454NegUltItem, A454NegUltItem, A572NegDel, A350NegCliID, A352NegCpjID, A369NegCpjEndSeq, n474NegUltNgfSeq, A474NegUltNgfSeq, n420NegUltIteID, A420NegUltIteID, n421NegUltIteNome, A421NegUltIteNome, n479NegUltIteOrdem, A479NegUltIteOrdem, A345NegID});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
                     if ( (pr_default.getStatus(22) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1337( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1337( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel1337( ) ;
         }
         CloseExtendedTableCursors1337( ) ;
      }

      protected void DeferredUpdate1337( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1337( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1337( ) ;
            AfterConfirm1337( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1337( ) ;
               if ( AnyError == 0 )
               {
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  ScanKeyStart1342( ) ;
                  while ( RcdFound42 != 0 )
                  {
                     getByPrimaryKey1342( ) ;
                     Delete1342( ) ;
                     ScanKeyNext1342( ) ;
                     O454NegUltItem = A454NegUltItem;
                     n454NegUltItem = false;
                     O448NegPgpTotal = A448NegPgpTotal;
                     n448NegPgpTotal = false;
                  }
                  ScanKeyEnd1342( ) ;
                  A386NegUltFase = O386NegUltFase;
                  ScanKeyStart1339( ) ;
                  while ( RcdFound39 != 0 )
                  {
                     getByPrimaryKey1339( ) ;
                     Delete1339( ) ;
                     ScanKeyNext1339( ) ;
                     O386NegUltFase = A386NegUltFase;
                  }
                  ScanKeyEnd1339( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001334 */
                     pr_default.execute(23, new Object[] {A345NegID});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
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
         }
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1337( ) ;
         Gx_mode = sMode37;
      }

      protected void OnDeleteControls1337( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001336 */
            pr_default.execute(24, new Object[] {A345NegID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A474NegUltNgfSeq = BC001336_A474NegUltNgfSeq[0];
               n474NegUltNgfSeq = BC001336_n474NegUltNgfSeq[0];
            }
            else
            {
               A474NegUltNgfSeq = 0;
               n474NegUltNgfSeq = false;
            }
            pr_default.close(24);
            /* Using cursor BC001339 */
            pr_default.execute(25, new Object[] {A345NegID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               A420NegUltIteID = BC001339_A420NegUltIteID[0];
               n420NegUltIteID = BC001339_n420NegUltIteID[0];
            }
            else
            {
               A420NegUltIteID = Guid.Empty;
               n420NegUltIteID = false;
            }
            pr_default.close(25);
            /* Using cursor BC001342 */
            pr_default.execute(26, new Object[] {A345NegID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               A421NegUltIteNome = BC001342_A421NegUltIteNome[0];
               n421NegUltIteNome = BC001342_n421NegUltIteNome[0];
            }
            else
            {
               A421NegUltIteNome = "";
               n421NegUltIteNome = false;
            }
            pr_default.close(26);
            /* Using cursor BC001345 */
            pr_default.execute(27, new Object[] {A345NegID});
            if ( (pr_default.getStatus(27) != 101) )
            {
               A479NegUltIteOrdem = BC001345_A479NegUltIteOrdem[0];
               n479NegUltIteOrdem = BC001345_n479NegUltIteOrdem[0];
            }
            else
            {
               A479NegUltIteOrdem = 0;
               n479NegUltIteOrdem = false;
            }
            pr_default.close(27);
            /* Using cursor BC001347 */
            pr_default.execute(28, new Object[] {A345NegID});
            if ( (pr_default.getStatus(28) != 101) )
            {
               A448NegPgpTotal = BC001347_A448NegPgpTotal[0];
               n448NegPgpTotal = BC001347_n448NegPgpTotal[0];
            }
            else
            {
               A448NegPgpTotal = 0;
               n448NegPgpTotal = false;
            }
            pr_default.close(28);
            /* Using cursor BC001348 */
            pr_default.execute(29, new Object[] {A350NegCliID});
            A473NegCliMatricula = BC001348_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC001348_A351NegCliNomeFamiliar[0];
            pr_default.close(29);
            /* Using cursor BC001349 */
            pr_default.execute(30, new Object[] {A350NegCliID, A352NegCpjID});
            A353NegCpjNomFan = BC001349_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC001349_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC001349_A355NegCpjMatricula[0];
            A357NegPjtID = BC001349_A357NegPjtID[0];
            pr_default.close(30);
            /* Using cursor BC001350 */
            pr_default.execute(31, new Object[] {A357NegPjtID});
            A358NegPjtSigla = BC001350_A358NegPjtSigla[0];
            A359NegPjtNome = BC001350_A359NegPjtNome[0];
            pr_default.close(31);
            /* Using cursor BC001351 */
            pr_default.execute(32, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
            A370NegCpjEndNome = BC001351_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC001351_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC001351_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC001351_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC001351_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC001351_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = BC001351_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC001351_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC001351_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC001351_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC001351_A379NegCpjEndUFNome[0];
            pr_default.close(32);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001352 */
            pr_default.execute(33, new Object[] {A345NegID});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor BC001353 */
            pr_default.execute(34, new Object[] {A345NegID});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor BC001354 */
            pr_default.execute(35, new Object[] {A345NegID});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""+" ("+"Negociação da Visita"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
         }
      }

      protected void ProcessNestedLevel1339( )
      {
         s386NegUltFase = O386NegUltFase;
         nGXsfl_39_idx = 0;
         while ( nGXsfl_39_idx < bccore_NegocioPJEstrutura.gxTpr_Fase.Count )
         {
            ReadRow1339( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound39 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_39 != 0 ) )
            {
               standaloneNotModal1339( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1339( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1339( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1339( ) ;
                  }
               }
               O386NegUltFase = A386NegUltFase;
            }
            KeyVarsToRow39( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)bccore_NegocioPJEstrutura.gxTpr_Fase.Item(nGXsfl_39_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_39_idx = 0;
            while ( nGXsfl_39_idx < bccore_NegocioPJEstrutura.gxTpr_Fase.Count )
            {
               ReadRow1339( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound39 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bccore_NegocioPJEstrutura.gxTpr_Fase.RemoveElement(nGXsfl_39_idx);
                  nGXsfl_39_idx = (int)(nGXsfl_39_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1339( ) ;
                  VarsToRow39( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)bccore_NegocioPJEstrutura.gxTpr_Fase.Item(nGXsfl_39_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* Using cursor BC001336 */
         pr_default.execute(24, new Object[] {A345NegID});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A474NegUltNgfSeq = BC001336_A474NegUltNgfSeq[0];
            n474NegUltNgfSeq = BC001336_n474NegUltNgfSeq[0];
         }
         else
         {
            A474NegUltNgfSeq = 0;
            n474NegUltNgfSeq = false;
         }
         /* Using cursor BC001339 */
         pr_default.execute(25, new Object[] {A345NegID});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A420NegUltIteID = BC001339_A420NegUltIteID[0];
            n420NegUltIteID = BC001339_n420NegUltIteID[0];
         }
         else
         {
            A420NegUltIteID = Guid.Empty;
            n420NegUltIteID = false;
         }
         /* Using cursor BC001342 */
         pr_default.execute(26, new Object[] {A345NegID});
         if ( (pr_default.getStatus(26) != 101) )
         {
            A421NegUltIteNome = BC001342_A421NegUltIteNome[0];
            n421NegUltIteNome = BC001342_n421NegUltIteNome[0];
         }
         else
         {
            A421NegUltIteNome = "";
            n421NegUltIteNome = false;
         }
         /* Using cursor BC001345 */
         pr_default.execute(27, new Object[] {A345NegID});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A479NegUltIteOrdem = BC001345_A479NegUltIteOrdem[0];
            n479NegUltIteOrdem = BC001345_n479NegUltIteOrdem[0];
         }
         else
         {
            A479NegUltIteOrdem = 0;
            n479NegUltIteOrdem = false;
         }
         /* End of After( level) rules */
         InitAll1339( ) ;
         if ( AnyError != 0 )
         {
            O386NegUltFase = s386NegUltFase;
         }
         nRcdExists_39 = 0;
         nIsMod_39 = 0;
         Gxremove39 = 0;
      }

      protected void ProcessNestedLevel1342( )
      {
         s454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         s448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < bccore_NegocioPJEstrutura.gxTpr_Item.Count )
         {
            ReadRow1342( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound42 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_42 != 0 ) )
            {
               standaloneNotModal1342( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1342( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1342( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1342( ) ;
                  }
               }
               O454NegUltItem = A454NegUltItem;
               n454NegUltItem = false;
               O448NegPgpTotal = A448NegPgpTotal;
               n448NegPgpTotal = false;
            }
            KeyVarsToRow42( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)bccore_NegocioPJEstrutura.gxTpr_Item.Item(nGXsfl_42_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_42_idx = 0;
            while ( nGXsfl_42_idx < bccore_NegocioPJEstrutura.gxTpr_Item.Count )
            {
               ReadRow1342( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound42 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bccore_NegocioPJEstrutura.gxTpr_Item.RemoveElement(nGXsfl_42_idx);
                  nGXsfl_42_idx = (int)(nGXsfl_42_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1342( ) ;
                  VarsToRow42( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)bccore_NegocioPJEstrutura.gxTpr_Item.Item(nGXsfl_42_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1342( ) ;
         if ( AnyError != 0 )
         {
            O454NegUltItem = s454NegUltItem;
            n454NegUltItem = false;
            O448NegPgpTotal = s448NegPgpTotal;
            n448NegPgpTotal = false;
         }
         nRcdExists_42 = 0;
         nIsMod_42 = 0;
         Gxremove42 = 0;
      }

      protected void ProcessLevel1337( )
      {
         /* Save parent mode. */
         sMode37 = Gx_mode;
         ProcessNestedLevel1339( ) ;
         ProcessNestedLevel1342( ) ;
         if ( AnyError != 0 )
         {
            O386NegUltFase = s386NegUltFase;
            O454NegUltItem = s454NegUltItem;
            n454NegUltItem = false;
            O448NegPgpTotal = s448NegPgpTotal;
            n448NegPgpTotal = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode37;
         /* ' Update level parameters */
         /* Using cursor BC001355 */
         pr_default.execute(36, new Object[] {n454NegUltItem, A454NegUltItem, A380NegValorEstimado, A385NegValorAtualizado, A386NegUltFase, n479NegUltIteOrdem, A479NegUltIteOrdem, n421NegUltIteNome, A421NegUltIteNome, n420NegUltIteID, A420NegUltIteID, n474NegUltNgfSeq, A474NegUltNgfSeq, A345NegID});
         pr_default.close(36);
         pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
      }

      protected void EndLevel1337( )
      {
         pr_default.close(11);
         if ( AnyError == 0 )
         {
            BeforeComplete1337( ) ;
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

      public void ScanKeyStart1337( )
      {
         /* Scan By routine */
         /* Using cursor BC001357 */
         pr_default.execute(37, new Object[] {A345NegID});
         RcdFound37 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound37 = 1;
            A345NegID = BC001357_A345NegID[0];
            A356NegCodigo = BC001357_A356NegCodigo[0];
            A348NegInsDataHora = BC001357_A348NegInsDataHora[0];
            A346NegInsData = BC001357_A346NegInsData[0];
            A347NegInsHora = BC001357_A347NegInsHora[0];
            A349NegInsUsuID = BC001357_A349NegInsUsuID[0];
            n349NegInsUsuID = BC001357_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC001357_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC001357_n364NegInsUsuNome[0];
            A380NegValorEstimado = BC001357_A380NegValorEstimado[0];
            A385NegValorAtualizado = BC001357_A385NegValorAtualizado[0];
            A573NegDelDataHora = BC001357_A573NegDelDataHora[0];
            n573NegDelDataHora = BC001357_n573NegDelDataHora[0];
            A574NegDelData = BC001357_A574NegDelData[0];
            n574NegDelData = BC001357_n574NegDelData[0];
            A575NegDelHora = BC001357_A575NegDelHora[0];
            n575NegDelHora = BC001357_n575NegDelHora[0];
            A576NegDelUsuId = BC001357_A576NegDelUsuId[0];
            n576NegDelUsuId = BC001357_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC001357_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC001357_n577NegDelUsuNome[0];
            A473NegCliMatricula = BC001357_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC001357_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = BC001357_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC001357_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC001357_A355NegCpjMatricula[0];
            A358NegPjtSigla = BC001357_A358NegPjtSigla[0];
            A359NegPjtNome = BC001357_A359NegPjtNome[0];
            A370NegCpjEndNome = BC001357_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC001357_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC001357_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC001357_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC001357_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC001357_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = BC001357_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC001357_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC001357_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC001357_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC001357_A379NegCpjEndUFNome[0];
            A360NegAgcID = BC001357_A360NegAgcID[0];
            n360NegAgcID = BC001357_n360NegAgcID[0];
            A361NegAgcNome = BC001357_A361NegAgcNome[0];
            n361NegAgcNome = BC001357_n361NegAgcNome[0];
            A362NegAssunto = BC001357_A362NegAssunto[0];
            A363NegDescricao = BC001357_A363NegDescricao[0];
            A386NegUltFase = BC001357_A386NegUltFase[0];
            A454NegUltItem = BC001357_A454NegUltItem[0];
            n454NegUltItem = BC001357_n454NegUltItem[0];
            A572NegDel = BC001357_A572NegDel[0];
            A350NegCliID = BC001357_A350NegCliID[0];
            A352NegCpjID = BC001357_A352NegCpjID[0];
            A369NegCpjEndSeq = BC001357_A369NegCpjEndSeq[0];
            A357NegPjtID = BC001357_A357NegPjtID[0];
            A448NegPgpTotal = BC001357_A448NegPgpTotal[0];
            n448NegPgpTotal = BC001357_n448NegPgpTotal[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1337( )
      {
         /* Scan next routine */
         pr_default.readNext(37);
         RcdFound37 = 0;
         ScanKeyLoad1337( ) ;
      }

      protected void ScanKeyLoad1337( )
      {
         sMode37 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound37 = 1;
            A345NegID = BC001357_A345NegID[0];
            A356NegCodigo = BC001357_A356NegCodigo[0];
            A348NegInsDataHora = BC001357_A348NegInsDataHora[0];
            A346NegInsData = BC001357_A346NegInsData[0];
            A347NegInsHora = BC001357_A347NegInsHora[0];
            A349NegInsUsuID = BC001357_A349NegInsUsuID[0];
            n349NegInsUsuID = BC001357_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC001357_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC001357_n364NegInsUsuNome[0];
            A380NegValorEstimado = BC001357_A380NegValorEstimado[0];
            A385NegValorAtualizado = BC001357_A385NegValorAtualizado[0];
            A573NegDelDataHora = BC001357_A573NegDelDataHora[0];
            n573NegDelDataHora = BC001357_n573NegDelDataHora[0];
            A574NegDelData = BC001357_A574NegDelData[0];
            n574NegDelData = BC001357_n574NegDelData[0];
            A575NegDelHora = BC001357_A575NegDelHora[0];
            n575NegDelHora = BC001357_n575NegDelHora[0];
            A576NegDelUsuId = BC001357_A576NegDelUsuId[0];
            n576NegDelUsuId = BC001357_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC001357_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC001357_n577NegDelUsuNome[0];
            A473NegCliMatricula = BC001357_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC001357_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = BC001357_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC001357_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC001357_A355NegCpjMatricula[0];
            A358NegPjtSigla = BC001357_A358NegPjtSigla[0];
            A359NegPjtNome = BC001357_A359NegPjtNome[0];
            A370NegCpjEndNome = BC001357_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC001357_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC001357_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC001357_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC001357_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC001357_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = BC001357_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC001357_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC001357_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC001357_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC001357_A379NegCpjEndUFNome[0];
            A360NegAgcID = BC001357_A360NegAgcID[0];
            n360NegAgcID = BC001357_n360NegAgcID[0];
            A361NegAgcNome = BC001357_A361NegAgcNome[0];
            n361NegAgcNome = BC001357_n361NegAgcNome[0];
            A362NegAssunto = BC001357_A362NegAssunto[0];
            A363NegDescricao = BC001357_A363NegDescricao[0];
            A386NegUltFase = BC001357_A386NegUltFase[0];
            A454NegUltItem = BC001357_A454NegUltItem[0];
            n454NegUltItem = BC001357_n454NegUltItem[0];
            A572NegDel = BC001357_A572NegDel[0];
            A350NegCliID = BC001357_A350NegCliID[0];
            A352NegCpjID = BC001357_A352NegCpjID[0];
            A369NegCpjEndSeq = BC001357_A369NegCpjEndSeq[0];
            A357NegPjtID = BC001357_A357NegPjtID[0];
            A448NegPgpTotal = BC001357_A448NegPgpTotal[0];
            n448NegPgpTotal = BC001357_n448NegPgpTotal[0];
         }
         Gx_mode = sMode37;
      }

      protected void ScanKeyEnd1337( )
      {
         pr_default.close(37);
      }

      protected void AfterConfirm1337( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  )
         {
            GXt_int1 = (int)(A356NegCodigo);
            new GeneXus.Programs.core.serializar(context ).execute(  "NegCodigo",  1, out  GXt_int1) ;
            A356NegCodigo = GXt_int1;
         }
      }

      protected void BeforeInsert1337( )
      {
         /* Before Insert Rules */
         A348NegInsDataHora = DateTimeUtil.NowMS( context);
         A349NegInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n349NegInsUsuID = false;
         A364NegInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n364NegInsUsuNome = false;
         A346NegInsData = DateTimeUtil.ResetTime( A348NegInsDataHora);
         A347NegInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A348NegInsDataHora));
      }

      protected void BeforeUpdate1337( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditnegociopjestrutura(context ).execute(  "Y", ref  AV28AuditingObject,  A345NegID,  Gx_mode) ;
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A573NegDelDataHora = DateTimeUtil.NowMS( context);
            n573NegDelDataHora = false;
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A576NegDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n576NegDelUsuId = false;
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A577NegDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n577NegDelUsuNome = false;
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A574NegDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A573NegDelDataHora) ) ;
            n574NegDelData = false;
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A575NegDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A573NegDelDataHora));
            n575NegDelHora = false;
         }
      }

      protected void BeforeDelete1337( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditnegociopjestrutura(context ).execute(  "Y", ref  AV28AuditingObject,  A345NegID,  Gx_mode) ;
      }

      protected void BeforeComplete1337( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjestrutura(context ).execute(  "N", ref  AV28AuditingObject,  A345NegID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjestrutura(context ).execute(  "N", ref  AV28AuditingObject,  A345NegID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1337( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1337( )
      {
      }

      protected void ZM1339( short GX_JID )
      {
         if ( ( GX_JID == 76 ) || ( GX_JID == 0 ) )
         {
            Z390NgfInsDataHora = A390NgfInsDataHora;
            Z388NgfInsData = A388NgfInsData;
            Z389NgfInsHora = A389NgfInsHora;
            Z391NgfInsUsuID = A391NgfInsUsuID;
            Z392NgfInsUsuNome = A392NgfInsUsuNome;
            Z585NgfDelDataHora = A585NgfDelDataHora;
            Z586NgfDelData = A586NgfDelData;
            Z587NgfDelHora = A587NgfDelHora;
            Z588NgfDelUsuId = A588NgfDelUsuId;
            Z589NgfDelUsuNome = A589NgfDelUsuNome;
            Z425NgfFimData = A425NgfFimData;
            Z426NgfFimHora = A426NgfFimHora;
            Z427NgfFimDataHora = A427NgfFimDataHora;
            Z428NgfFimUsuID = A428NgfFimUsuID;
            Z429NgfFimUsuNome = A429NgfFimUsuNome;
            Z430NgfStatus = A430NgfStatus;
            Z584NgfDel = A584NgfDel;
            Z395NgfIteID = A395NgfIteID;
         }
         if ( ( GX_JID == 77 ) || ( GX_JID == 0 ) )
         {
            Z396NgfIteOrdem = A396NgfIteOrdem;
            Z397NgfIteNome = A397NgfIteNome;
         }
         if ( ( GX_JID == 83 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 84 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 85 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 86 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -76 )
         {
            Z345NegID = A345NegID;
            Z387NgfSeq = A387NgfSeq;
            Z390NgfInsDataHora = A390NgfInsDataHora;
            Z388NgfInsData = A388NgfInsData;
            Z389NgfInsHora = A389NgfInsHora;
            Z391NgfInsUsuID = A391NgfInsUsuID;
            Z392NgfInsUsuNome = A392NgfInsUsuNome;
            Z585NgfDelDataHora = A585NgfDelDataHora;
            Z586NgfDelData = A586NgfDelData;
            Z587NgfDelHora = A587NgfDelHora;
            Z588NgfDelUsuId = A588NgfDelUsuId;
            Z589NgfDelUsuNome = A589NgfDelUsuNome;
            Z397NgfIteNome = A397NgfIteNome;
            Z425NgfFimData = A425NgfFimData;
            Z426NgfFimHora = A426NgfFimHora;
            Z427NgfFimDataHora = A427NgfFimDataHora;
            Z428NgfFimUsuID = A428NgfFimUsuID;
            Z429NgfFimUsuNome = A429NgfFimUsuNome;
            Z430NgfStatus = A430NgfStatus;
            Z584NgfDel = A584NgfDel;
            Z395NgfIteID = A395NgfIteID;
            Z396NgfIteOrdem = A396NgfIteOrdem;
         }
      }

      protected void standaloneNotModal1339( )
      {
      }

      protected void standaloneModal1339( )
      {
         if ( IsIns( )  )
         {
            A386NegUltFase = (int)(O386NegUltFase+1);
         }
         if ( IsIns( )  )
         {
            A387NgfSeq = A386NegUltFase;
         }
      }

      protected void Load1339( )
      {
         /* Using cursor BC001358 */
         pr_default.execute(38, new Object[] {A345NegID, A387NgfSeq});
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound39 = 1;
            A390NgfInsDataHora = BC001358_A390NgfInsDataHora[0];
            A388NgfInsData = BC001358_A388NgfInsData[0];
            A389NgfInsHora = BC001358_A389NgfInsHora[0];
            A391NgfInsUsuID = BC001358_A391NgfInsUsuID[0];
            n391NgfInsUsuID = BC001358_n391NgfInsUsuID[0];
            A392NgfInsUsuNome = BC001358_A392NgfInsUsuNome[0];
            n392NgfInsUsuNome = BC001358_n392NgfInsUsuNome[0];
            A585NgfDelDataHora = BC001358_A585NgfDelDataHora[0];
            n585NgfDelDataHora = BC001358_n585NgfDelDataHora[0];
            A586NgfDelData = BC001358_A586NgfDelData[0];
            n586NgfDelData = BC001358_n586NgfDelData[0];
            A587NgfDelHora = BC001358_A587NgfDelHora[0];
            n587NgfDelHora = BC001358_n587NgfDelHora[0];
            A588NgfDelUsuId = BC001358_A588NgfDelUsuId[0];
            n588NgfDelUsuId = BC001358_n588NgfDelUsuId[0];
            A589NgfDelUsuNome = BC001358_A589NgfDelUsuNome[0];
            n589NgfDelUsuNome = BC001358_n589NgfDelUsuNome[0];
            A396NgfIteOrdem = BC001358_A396NgfIteOrdem[0];
            A397NgfIteNome = BC001358_A397NgfIteNome[0];
            A425NgfFimData = BC001358_A425NgfFimData[0];
            n425NgfFimData = BC001358_n425NgfFimData[0];
            A426NgfFimHora = BC001358_A426NgfFimHora[0];
            n426NgfFimHora = BC001358_n426NgfFimHora[0];
            A427NgfFimDataHora = BC001358_A427NgfFimDataHora[0];
            n427NgfFimDataHora = BC001358_n427NgfFimDataHora[0];
            A428NgfFimUsuID = BC001358_A428NgfFimUsuID[0];
            n428NgfFimUsuID = BC001358_n428NgfFimUsuID[0];
            A429NgfFimUsuNome = BC001358_A429NgfFimUsuNome[0];
            n429NgfFimUsuNome = BC001358_n429NgfFimUsuNome[0];
            A430NgfStatus = BC001358_A430NgfStatus[0];
            n430NgfStatus = BC001358_n430NgfStatus[0];
            A584NgfDel = BC001358_A584NgfDel[0];
            A395NgfIteID = BC001358_A395NgfIteID[0];
            ZM1339( -76) ;
         }
         pr_default.close(38);
         OnLoadActions1339( ) ;
      }

      protected void OnLoadActions1339( )
      {
      }

      protected void CheckExtendedTable1339( )
      {
         nIsDirty_39 = 0;
         Gx_BScreen = 1;
         standaloneModal1339( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00138 */
         pr_default.execute(6, new Object[] {A395NgfIteID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Iteração ->Fase da Opertunidade do Negócio'.", "ForeignKeyNotFound", 1, "NGFITEID");
            AnyError = 1;
         }
         A396NgfIteOrdem = BC00138_A396NgfIteOrdem[0];
         A397NgfIteNome = BC00138_A397NgfIteNome[0];
         pr_default.close(6);
         if ( ! ( ( StringUtil.StrCmp(A430NgfStatus, "TODO") == 0 ) || ( StringUtil.StrCmp(A430NgfStatus, "DOING") == 0 ) || ( StringUtil.StrCmp(A430NgfStatus, "DONE") == 0 ) || ( StringUtil.StrCmp(A430NgfStatus, "CANCE") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A430NgfStatus)) ) )
         {
            GX_msglist.addItem("Campo Situação fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1339( )
      {
         pr_default.close(6);
      }

      protected void enableDisable1339( )
      {
      }

      protected void GetKey1339( )
      {
         /* Using cursor BC001359 */
         pr_default.execute(39, new Object[] {A345NegID, A387NgfSeq});
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(39);
      }

      protected void getByPrimaryKey1339( )
      {
         /* Using cursor BC00137 */
         pr_default.execute(5, new Object[] {A345NegID, A387NgfSeq});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM1339( 76) ;
            RcdFound39 = 1;
            InitializeNonKey1339( ) ;
            A387NgfSeq = BC00137_A387NgfSeq[0];
            A390NgfInsDataHora = BC00137_A390NgfInsDataHora[0];
            A388NgfInsData = BC00137_A388NgfInsData[0];
            A389NgfInsHora = BC00137_A389NgfInsHora[0];
            A391NgfInsUsuID = BC00137_A391NgfInsUsuID[0];
            n391NgfInsUsuID = BC00137_n391NgfInsUsuID[0];
            A392NgfInsUsuNome = BC00137_A392NgfInsUsuNome[0];
            n392NgfInsUsuNome = BC00137_n392NgfInsUsuNome[0];
            A585NgfDelDataHora = BC00137_A585NgfDelDataHora[0];
            n585NgfDelDataHora = BC00137_n585NgfDelDataHora[0];
            A586NgfDelData = BC00137_A586NgfDelData[0];
            n586NgfDelData = BC00137_n586NgfDelData[0];
            A587NgfDelHora = BC00137_A587NgfDelHora[0];
            n587NgfDelHora = BC00137_n587NgfDelHora[0];
            A588NgfDelUsuId = BC00137_A588NgfDelUsuId[0];
            n588NgfDelUsuId = BC00137_n588NgfDelUsuId[0];
            A589NgfDelUsuNome = BC00137_A589NgfDelUsuNome[0];
            n589NgfDelUsuNome = BC00137_n589NgfDelUsuNome[0];
            A425NgfFimData = BC00137_A425NgfFimData[0];
            n425NgfFimData = BC00137_n425NgfFimData[0];
            A426NgfFimHora = BC00137_A426NgfFimHora[0];
            n426NgfFimHora = BC00137_n426NgfFimHora[0];
            A427NgfFimDataHora = BC00137_A427NgfFimDataHora[0];
            n427NgfFimDataHora = BC00137_n427NgfFimDataHora[0];
            A428NgfFimUsuID = BC00137_A428NgfFimUsuID[0];
            n428NgfFimUsuID = BC00137_n428NgfFimUsuID[0];
            A429NgfFimUsuNome = BC00137_A429NgfFimUsuNome[0];
            n429NgfFimUsuNome = BC00137_n429NgfFimUsuNome[0];
            A430NgfStatus = BC00137_A430NgfStatus[0];
            n430NgfStatus = BC00137_n430NgfStatus[0];
            A584NgfDel = BC00137_A584NgfDel[0];
            A395NgfIteID = BC00137_A395NgfIteID[0];
            O584NgfDel = A584NgfDel;
            Z345NegID = A345NegID;
            Z387NgfSeq = A387NgfSeq;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1339( ) ;
            Load1339( ) ;
            Gx_mode = sMode39;
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey1339( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1339( ) ;
            Gx_mode = sMode39;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1339( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency1339( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00136 */
            pr_default.execute(4, new Object[] {A345NegID, A387NgfSeq});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_fase"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( Z390NgfInsDataHora != BC00136_A390NgfInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z388NgfInsData ) != DateTimeUtil.ResetTime ( BC00136_A388NgfInsData[0] ) ) || ( Z389NgfInsHora != BC00136_A389NgfInsHora[0] ) || ( StringUtil.StrCmp(Z391NgfInsUsuID, BC00136_A391NgfInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z392NgfInsUsuNome, BC00136_A392NgfInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z585NgfDelDataHora != BC00136_A585NgfDelDataHora[0] ) || ( Z586NgfDelData != BC00136_A586NgfDelData[0] ) || ( Z587NgfDelHora != BC00136_A587NgfDelHora[0] ) || ( StringUtil.StrCmp(Z588NgfDelUsuId, BC00136_A588NgfDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z589NgfDelUsuNome, BC00136_A589NgfDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z425NgfFimData ) != DateTimeUtil.ResetTime ( BC00136_A425NgfFimData[0] ) ) || ( Z426NgfFimHora != BC00136_A426NgfFimHora[0] ) || ( Z427NgfFimDataHora != BC00136_A427NgfFimDataHora[0] ) || ( StringUtil.StrCmp(Z428NgfFimUsuID, BC00136_A428NgfFimUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z429NgfFimUsuNome, BC00136_A429NgfFimUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z430NgfStatus, BC00136_A430NgfStatus[0]) != 0 ) || ( Z584NgfDel != BC00136_A584NgfDel[0] ) || ( Z395NgfIteID != BC00136_A395NgfIteID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj_fase"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1339( )
      {
         BeforeValidate1339( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1339( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1339( 0) ;
            CheckOptimisticConcurrency1339( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1339( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1339( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001360 */
                     pr_default.execute(40, new Object[] {A397NgfIteNome, A345NegID, A387NgfSeq, A390NgfInsDataHora, A388NgfInsData, A389NgfInsHora, n391NgfInsUsuID, A391NgfInsUsuID, n392NgfInsUsuNome, A392NgfInsUsuNome, n585NgfDelDataHora, A585NgfDelDataHora, n586NgfDelData, A586NgfDelData, n587NgfDelHora, A587NgfDelHora, n588NgfDelUsuId, A588NgfDelUsuId, n589NgfDelUsuNome, A589NgfDelUsuNome, n425NgfFimData, A425NgfFimData, n426NgfFimHora, A426NgfFimHora, n427NgfFimDataHora, A427NgfFimDataHora, n428NgfFimUsuID, A428NgfFimUsuID, n429NgfFimUsuNome, A429NgfFimUsuNome, n430NgfStatus, A430NgfStatus, A584NgfDel, A395NgfIteID});
                     pr_default.close(40);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fase");
                     if ( (pr_default.getStatus(40) == 1) )
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
               Load1339( ) ;
            }
            EndLevel1339( ) ;
         }
         CloseExtendedTableCursors1339( ) ;
      }

      protected void Update1339( )
      {
         BeforeValidate1339( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1339( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1339( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1339( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1339( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001361 */
                     pr_default.execute(41, new Object[] {A397NgfIteNome, A390NgfInsDataHora, A388NgfInsData, A389NgfInsHora, n391NgfInsUsuID, A391NgfInsUsuID, n392NgfInsUsuNome, A392NgfInsUsuNome, n585NgfDelDataHora, A585NgfDelDataHora, n586NgfDelData, A586NgfDelData, n587NgfDelHora, A587NgfDelHora, n588NgfDelUsuId, A588NgfDelUsuId, n589NgfDelUsuNome, A589NgfDelUsuNome, n425NgfFimData, A425NgfFimData, n426NgfFimHora, A426NgfFimHora, n427NgfFimDataHora, A427NgfFimDataHora, n428NgfFimUsuID, A428NgfFimUsuID, n429NgfFimUsuNome, A429NgfFimUsuNome, n430NgfStatus, A430NgfStatus, A584NgfDel, A395NgfIteID, A345NegID, A387NgfSeq});
                     pr_default.close(41);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fase");
                     if ( (pr_default.getStatus(41) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_fase"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1339( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1339( ) ;
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
            EndLevel1339( ) ;
         }
         CloseExtendedTableCursors1339( ) ;
      }

      protected void DeferredUpdate1339( )
      {
      }

      protected void Delete1339( )
      {
         Gx_mode = "DLT";
         BeforeValidate1339( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1339( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1339( ) ;
            AfterConfirm1339( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1339( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001362 */
                  pr_default.execute(42, new Object[] {A345NegID, A387NgfSeq});
                  pr_default.close(42);
                  pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fase");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1339( ) ;
         Gx_mode = sMode39;
      }

      protected void OnDeleteControls1339( )
      {
         standaloneModal1339( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001363 */
            pr_default.execute(43, new Object[] {A395NgfIteID});
            A396NgfIteOrdem = BC001363_A396NgfIteOrdem[0];
            A397NgfIteNome = BC001363_A397NgfIteNome[0];
            pr_default.close(43);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001364 */
            pr_default.execute(44, new Object[] {A345NegID, A387NgfSeq});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
         }
      }

      protected void EndLevel1339( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1339( )
      {
         /* Scan By routine */
         /* Using cursor BC001365 */
         pr_default.execute(45, new Object[] {A345NegID});
         RcdFound39 = 0;
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound39 = 1;
            A387NgfSeq = BC001365_A387NgfSeq[0];
            A390NgfInsDataHora = BC001365_A390NgfInsDataHora[0];
            A388NgfInsData = BC001365_A388NgfInsData[0];
            A389NgfInsHora = BC001365_A389NgfInsHora[0];
            A391NgfInsUsuID = BC001365_A391NgfInsUsuID[0];
            n391NgfInsUsuID = BC001365_n391NgfInsUsuID[0];
            A392NgfInsUsuNome = BC001365_A392NgfInsUsuNome[0];
            n392NgfInsUsuNome = BC001365_n392NgfInsUsuNome[0];
            A585NgfDelDataHora = BC001365_A585NgfDelDataHora[0];
            n585NgfDelDataHora = BC001365_n585NgfDelDataHora[0];
            A586NgfDelData = BC001365_A586NgfDelData[0];
            n586NgfDelData = BC001365_n586NgfDelData[0];
            A587NgfDelHora = BC001365_A587NgfDelHora[0];
            n587NgfDelHora = BC001365_n587NgfDelHora[0];
            A588NgfDelUsuId = BC001365_A588NgfDelUsuId[0];
            n588NgfDelUsuId = BC001365_n588NgfDelUsuId[0];
            A589NgfDelUsuNome = BC001365_A589NgfDelUsuNome[0];
            n589NgfDelUsuNome = BC001365_n589NgfDelUsuNome[0];
            A396NgfIteOrdem = BC001365_A396NgfIteOrdem[0];
            A397NgfIteNome = BC001365_A397NgfIteNome[0];
            A425NgfFimData = BC001365_A425NgfFimData[0];
            n425NgfFimData = BC001365_n425NgfFimData[0];
            A426NgfFimHora = BC001365_A426NgfFimHora[0];
            n426NgfFimHora = BC001365_n426NgfFimHora[0];
            A427NgfFimDataHora = BC001365_A427NgfFimDataHora[0];
            n427NgfFimDataHora = BC001365_n427NgfFimDataHora[0];
            A428NgfFimUsuID = BC001365_A428NgfFimUsuID[0];
            n428NgfFimUsuID = BC001365_n428NgfFimUsuID[0];
            A429NgfFimUsuNome = BC001365_A429NgfFimUsuNome[0];
            n429NgfFimUsuNome = BC001365_n429NgfFimUsuNome[0];
            A430NgfStatus = BC001365_A430NgfStatus[0];
            n430NgfStatus = BC001365_n430NgfStatus[0];
            A584NgfDel = BC001365_A584NgfDel[0];
            A395NgfIteID = BC001365_A395NgfIteID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1339( )
      {
         /* Scan next routine */
         pr_default.readNext(45);
         RcdFound39 = 0;
         ScanKeyLoad1339( ) ;
      }

      protected void ScanKeyLoad1339( )
      {
         sMode39 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound39 = 1;
            A387NgfSeq = BC001365_A387NgfSeq[0];
            A390NgfInsDataHora = BC001365_A390NgfInsDataHora[0];
            A388NgfInsData = BC001365_A388NgfInsData[0];
            A389NgfInsHora = BC001365_A389NgfInsHora[0];
            A391NgfInsUsuID = BC001365_A391NgfInsUsuID[0];
            n391NgfInsUsuID = BC001365_n391NgfInsUsuID[0];
            A392NgfInsUsuNome = BC001365_A392NgfInsUsuNome[0];
            n392NgfInsUsuNome = BC001365_n392NgfInsUsuNome[0];
            A585NgfDelDataHora = BC001365_A585NgfDelDataHora[0];
            n585NgfDelDataHora = BC001365_n585NgfDelDataHora[0];
            A586NgfDelData = BC001365_A586NgfDelData[0];
            n586NgfDelData = BC001365_n586NgfDelData[0];
            A587NgfDelHora = BC001365_A587NgfDelHora[0];
            n587NgfDelHora = BC001365_n587NgfDelHora[0];
            A588NgfDelUsuId = BC001365_A588NgfDelUsuId[0];
            n588NgfDelUsuId = BC001365_n588NgfDelUsuId[0];
            A589NgfDelUsuNome = BC001365_A589NgfDelUsuNome[0];
            n589NgfDelUsuNome = BC001365_n589NgfDelUsuNome[0];
            A396NgfIteOrdem = BC001365_A396NgfIteOrdem[0];
            A397NgfIteNome = BC001365_A397NgfIteNome[0];
            A425NgfFimData = BC001365_A425NgfFimData[0];
            n425NgfFimData = BC001365_n425NgfFimData[0];
            A426NgfFimHora = BC001365_A426NgfFimHora[0];
            n426NgfFimHora = BC001365_n426NgfFimHora[0];
            A427NgfFimDataHora = BC001365_A427NgfFimDataHora[0];
            n427NgfFimDataHora = BC001365_n427NgfFimDataHora[0];
            A428NgfFimUsuID = BC001365_A428NgfFimUsuID[0];
            n428NgfFimUsuID = BC001365_n428NgfFimUsuID[0];
            A429NgfFimUsuNome = BC001365_A429NgfFimUsuNome[0];
            n429NgfFimUsuNome = BC001365_n429NgfFimUsuNome[0];
            A430NgfStatus = BC001365_A430NgfStatus[0];
            n430NgfStatus = BC001365_n430NgfStatus[0];
            A584NgfDel = BC001365_A584NgfDel[0];
            A395NgfIteID = BC001365_A395NgfIteID[0];
         }
         Gx_mode = sMode39;
      }

      protected void ScanKeyEnd1339( )
      {
         pr_default.close(45);
      }

      protected void AfterConfirm1339( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1339( )
      {
         /* Before Insert Rules */
         A390NgfInsDataHora = DateTimeUtil.NowMS( context);
         A391NgfInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n391NgfInsUsuID = false;
         A392NgfInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n392NgfInsUsuNome = false;
         A388NgfInsData = DateTimeUtil.ResetTime( A390NgfInsDataHora);
         A389NgfInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A390NgfInsDataHora));
      }

      protected void BeforeUpdate1339( )
      {
         /* Before Update Rules */
         if ( A584NgfDel && ( O584NgfDel != A584NgfDel ) )
         {
            A585NgfDelDataHora = DateTimeUtil.NowMS( context);
            n585NgfDelDataHora = false;
         }
         if ( A584NgfDel && ( O584NgfDel != A584NgfDel ) )
         {
            A588NgfDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n588NgfDelUsuId = false;
         }
         if ( A584NgfDel && ( O584NgfDel != A584NgfDel ) )
         {
            A589NgfDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n589NgfDelUsuNome = false;
         }
         if ( A584NgfDel && ( O584NgfDel != A584NgfDel ) )
         {
            A586NgfDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A585NgfDelDataHora) ) ;
            n586NgfDelData = false;
         }
         if ( A584NgfDel && ( O584NgfDel != A584NgfDel ) )
         {
            A587NgfDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A585NgfDelDataHora));
            n587NgfDelHora = false;
         }
      }

      protected void BeforeDelete1339( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1339( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1339( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1339( )
      {
      }

      protected void send_integrity_lvl_hashes1339( )
      {
      }

      protected void ZM1342( short GX_JID )
      {
         if ( ( GX_JID == 78 ) || ( GX_JID == 0 ) )
         {
            Z447NgpTotal = A447NgpTotal;
            Z446NgpQtde = A446NgpQtde;
            Z457NgpInsDataHora = A457NgpInsDataHora;
            Z455NgpInsData = A455NgpInsData;
            Z456NgpInsHora = A456NgpInsHora;
            Z458NgpInsUsuID = A458NgpInsUsuID;
            Z459NgpInsUsuNome = A459NgpInsUsuNome;
            Z445NgpPreco = A445NgpPreco;
            Z579NgpDelDataHora = A579NgpDelDataHora;
            Z580NgpDelData = A580NgpDelData;
            Z581NgpDelHora = A581NgpDelHora;
            Z582NgpDelUsuId = A582NgpDelUsuId;
            Z583NgpDelUsuNome = A583NgpDelUsuNome;
            Z453NgpObs = A453NgpObs;
            Z578NgpDel = A578NgpDel;
            Z439NgpTppPrdID = A439NgpTppPrdID;
            Z478NgpTppID = A478NgpTppID;
         }
         if ( ( GX_JID == 79 ) || ( GX_JID == 0 ) )
         {
            Z440NgpTppPrdCodigo = A440NgpTppPrdCodigo;
            Z441NgpTppPrdNome = A441NgpTppPrdNome;
            Z443NgpTppPrdAtivo = A443NgpTppPrdAtivo;
            Z442NgpTppPrdTipoID = A442NgpTppPrdTipoID;
         }
         if ( ( GX_JID == 80 ) || ( GX_JID == 0 ) )
         {
            Z444NgpTpp1Preco = A444NgpTpp1Preco;
         }
         if ( GX_JID == -78 )
         {
            Z447NgpTotal = A447NgpTotal;
            Z345NegID = A345NegID;
            Z435NgpItem = A435NgpItem;
            Z446NgpQtde = A446NgpQtde;
            Z457NgpInsDataHora = A457NgpInsDataHora;
            Z455NgpInsData = A455NgpInsData;
            Z456NgpInsHora = A456NgpInsHora;
            Z458NgpInsUsuID = A458NgpInsUsuID;
            Z459NgpInsUsuNome = A459NgpInsUsuNome;
            Z445NgpPreco = A445NgpPreco;
            Z579NgpDelDataHora = A579NgpDelDataHora;
            Z580NgpDelData = A580NgpDelData;
            Z581NgpDelHora = A581NgpDelHora;
            Z582NgpDelUsuId = A582NgpDelUsuId;
            Z583NgpDelUsuNome = A583NgpDelUsuNome;
            Z453NgpObs = A453NgpObs;
            Z578NgpDel = A578NgpDel;
            Z439NgpTppPrdID = A439NgpTppPrdID;
            Z478NgpTppID = A478NgpTppID;
            Z440NgpTppPrdCodigo = A440NgpTppPrdCodigo;
            Z441NgpTppPrdNome = A441NgpTppPrdNome;
            Z443NgpTppPrdAtivo = A443NgpTppPrdAtivo;
            Z442NgpTppPrdTipoID = A442NgpTppPrdTipoID;
            Z444NgpTpp1Preco = A444NgpTpp1Preco;
         }
      }

      protected void standaloneNotModal1342( )
      {
      }

      protected void standaloneModal1342( )
      {
         if ( IsIns( )  )
         {
            A454NegUltItem = (int)(O454NegUltItem+1);
            n454NegUltItem = false;
         }
         if ( IsIns( )  )
         {
            A435NgpItem = A454NegUltItem;
         }
         if ( IsIns( )  && (0==A446NgpQtde) && ( Gx_BScreen == 0 ) )
         {
            A446NgpQtde = 1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1342( )
      {
         /* Using cursor BC001366 */
         pr_default.execute(46, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = BC001366_A447NgpTotal[0];
            A446NgpQtde = BC001366_A446NgpQtde[0];
            A457NgpInsDataHora = BC001366_A457NgpInsDataHora[0];
            A455NgpInsData = BC001366_A455NgpInsData[0];
            A456NgpInsHora = BC001366_A456NgpInsHora[0];
            A458NgpInsUsuID = BC001366_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC001366_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC001366_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC001366_n459NgpInsUsuNome[0];
            A445NgpPreco = BC001366_A445NgpPreco[0];
            A579NgpDelDataHora = BC001366_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC001366_n579NgpDelDataHora[0];
            A580NgpDelData = BC001366_A580NgpDelData[0];
            n580NgpDelData = BC001366_n580NgpDelData[0];
            A581NgpDelHora = BC001366_A581NgpDelHora[0];
            n581NgpDelHora = BC001366_n581NgpDelHora[0];
            A582NgpDelUsuId = BC001366_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC001366_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC001366_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC001366_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = BC001366_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC001366_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC001366_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = BC001366_A444NgpTpp1Preco[0];
            A453NgpObs = BC001366_A453NgpObs[0];
            A578NgpDel = BC001366_A578NgpDel[0];
            A439NgpTppPrdID = BC001366_A439NgpTppPrdID[0];
            A478NgpTppID = BC001366_A478NgpTppID[0];
            A442NgpTppPrdTipoID = BC001366_A442NgpTppPrdTipoID[0];
            ZM1342( -78) ;
         }
         pr_default.close(46);
         OnLoadActions1342( ) ;
      }

      protected void OnLoadActions1342( )
      {
         if ( IsIns( )  && (Convert.ToDecimal(0)==A445NgpPreco) && ( Gx_BScreen == 0 ) )
         {
            A445NgpPreco = A444NgpTpp1Preco;
         }
         A447NgpTotal = NumberUtil.Round( (A445NgpPreco*A446NgpQtde), 2);
         if ( IsIns( )  )
         {
            A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal);
            n448NegPgpTotal = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal-O447NgpTotal);
               n448NegPgpTotal = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A448NegPgpTotal = (decimal)(O448NegPgpTotal-O447NgpTotal);
                  n448NegPgpTotal = false;
               }
            }
         }
         A380NegValorEstimado = A448NegPgpTotal;
         A385NegValorAtualizado = A448NegPgpTotal;
      }

      protected void CheckExtendedTable1342( )
      {
         nIsDirty_42 = 0;
         Gx_BScreen = 1;
         standaloneModal1342( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00135 */
         pr_default.execute(3, new Object[] {A478NgpTppID, A439NgpTppPrdID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, "NGPTPPPRDID");
            AnyError = 1;
         }
         A444NgpTpp1Preco = BC00135_A444NgpTpp1Preco[0];
         pr_default.close(3);
         if ( IsIns( )  && (Convert.ToDecimal(0)==A445NgpPreco) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_42 = 1;
            A445NgpPreco = A444NgpTpp1Preco;
         }
         /* Using cursor BC00134 */
         pr_default.execute(2, new Object[] {A439NgpTppPrdID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, "NGPTPPPRDID");
            AnyError = 1;
         }
         A440NgpTppPrdCodigo = BC00134_A440NgpTppPrdCodigo[0];
         A441NgpTppPrdNome = BC00134_A441NgpTppPrdNome[0];
         A443NgpTppPrdAtivo = BC00134_A443NgpTppPrdAtivo[0];
         A442NgpTppPrdTipoID = BC00134_A442NgpTppPrdTipoID[0];
         pr_default.close(2);
         if ( (Guid.Empty==A439NgpTppPrdID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Produto", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         nIsDirty_42 = 1;
         A447NgpTotal = NumberUtil.Round( (A445NgpPreco*A446NgpQtde), 2);
         if ( (Convert.ToDecimal(0)==A445NgpPreco) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Preço", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A446NgpQtde) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Quantidade", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( IsIns( )  )
         {
            nIsDirty_42 = 1;
            A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal);
            n448NegPgpTotal = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_42 = 1;
               A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal-O447NgpTotal);
               n448NegPgpTotal = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_42 = 1;
                  A448NegPgpTotal = (decimal)(O448NegPgpTotal-O447NgpTotal);
                  n448NegPgpTotal = false;
               }
            }
         }
         nIsDirty_42 = 1;
         A380NegValorEstimado = A448NegPgpTotal;
         nIsDirty_42 = 1;
         A385NegValorAtualizado = A448NegPgpTotal;
      }

      protected void CloseExtendedTableCursors1342( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable1342( )
      {
      }

      protected void GetKey1342( )
      {
         /* Using cursor BC001367 */
         pr_default.execute(47, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(47);
      }

      protected void getByPrimaryKey1342( )
      {
         /* Using cursor BC00133 */
         pr_default.execute(1, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1342( 78) ;
            RcdFound42 = 1;
            InitializeNonKey1342( ) ;
            A447NgpTotal = BC00133_A447NgpTotal[0];
            A435NgpItem = BC00133_A435NgpItem[0];
            A446NgpQtde = BC00133_A446NgpQtde[0];
            A457NgpInsDataHora = BC00133_A457NgpInsDataHora[0];
            A455NgpInsData = BC00133_A455NgpInsData[0];
            A456NgpInsHora = BC00133_A456NgpInsHora[0];
            A458NgpInsUsuID = BC00133_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC00133_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC00133_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC00133_n459NgpInsUsuNome[0];
            A445NgpPreco = BC00133_A445NgpPreco[0];
            A579NgpDelDataHora = BC00133_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC00133_n579NgpDelDataHora[0];
            A580NgpDelData = BC00133_A580NgpDelData[0];
            n580NgpDelData = BC00133_n580NgpDelData[0];
            A581NgpDelHora = BC00133_A581NgpDelHora[0];
            n581NgpDelHora = BC00133_n581NgpDelHora[0];
            A582NgpDelUsuId = BC00133_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC00133_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC00133_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC00133_n583NgpDelUsuNome[0];
            A453NgpObs = BC00133_A453NgpObs[0];
            A578NgpDel = BC00133_A578NgpDel[0];
            A439NgpTppPrdID = BC00133_A439NgpTppPrdID[0];
            A478NgpTppID = BC00133_A478NgpTppID[0];
            O578NgpDel = A578NgpDel;
            O447NgpTotal = A447NgpTotal;
            Z345NegID = A345NegID;
            Z435NgpItem = A435NgpItem;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1342( ) ;
            Load1342( ) ;
            Gx_mode = sMode42;
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1342( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1342( ) ;
            Gx_mode = sMode42;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1342( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1342( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00132 */
            pr_default.execute(0, new Object[] {A345NegID, A435NgpItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_item"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z447NgpTotal != BC00132_A447NgpTotal[0] ) || ( Z446NgpQtde != BC00132_A446NgpQtde[0] ) || ( Z457NgpInsDataHora != BC00132_A457NgpInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z455NgpInsData ) != DateTimeUtil.ResetTime ( BC00132_A455NgpInsData[0] ) ) || ( Z456NgpInsHora != BC00132_A456NgpInsHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z458NgpInsUsuID, BC00132_A458NgpInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z459NgpInsUsuNome, BC00132_A459NgpInsUsuNome[0]) != 0 ) || ( Z445NgpPreco != BC00132_A445NgpPreco[0] ) || ( Z579NgpDelDataHora != BC00132_A579NgpDelDataHora[0] ) || ( Z580NgpDelData != BC00132_A580NgpDelData[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z581NgpDelHora != BC00132_A581NgpDelHora[0] ) || ( StringUtil.StrCmp(Z582NgpDelUsuId, BC00132_A582NgpDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z583NgpDelUsuNome, BC00132_A583NgpDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z453NgpObs, BC00132_A453NgpObs[0]) != 0 ) || ( Z578NgpDel != BC00132_A578NgpDel[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z439NgpTppPrdID != BC00132_A439NgpTppPrdID[0] ) || ( Z478NgpTppID != BC00132_A478NgpTppID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj_item"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1342( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1342( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1342( 0) ;
            CheckOptimisticConcurrency1342( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1342( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1342( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001368 */
                     pr_default.execute(48, new Object[] {A447NgpTotal, A345NegID, A435NgpItem, A446NgpQtde, A457NgpInsDataHora, A455NgpInsData, A456NgpInsHora, n458NgpInsUsuID, A458NgpInsUsuID, n459NgpInsUsuNome, A459NgpInsUsuNome, A445NgpPreco, n579NgpDelDataHora, A579NgpDelDataHora, n580NgpDelData, A580NgpDelData, n581NgpDelHora, A581NgpDelHora, n582NgpDelUsuId, A582NgpDelUsuId, n583NgpDelUsuNome, A583NgpDelUsuNome, A453NgpObs, A578NgpDel, A439NgpTppPrdID, A478NgpTppID});
                     pr_default.close(48);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                     if ( (pr_default.getStatus(48) == 1) )
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
               Load1342( ) ;
            }
            EndLevel1342( ) ;
         }
         CloseExtendedTableCursors1342( ) ;
      }

      protected void Update1342( )
      {
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1342( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1342( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1342( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1342( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001369 */
                     pr_default.execute(49, new Object[] {A447NgpTotal, A446NgpQtde, A457NgpInsDataHora, A455NgpInsData, A456NgpInsHora, n458NgpInsUsuID, A458NgpInsUsuID, n459NgpInsUsuNome, A459NgpInsUsuNome, A445NgpPreco, n579NgpDelDataHora, A579NgpDelDataHora, n580NgpDelData, A580NgpDelData, n581NgpDelHora, A581NgpDelHora, n582NgpDelUsuId, A582NgpDelUsuId, n583NgpDelUsuNome, A583NgpDelUsuNome, A453NgpObs, A578NgpDel, A439NgpTppPrdID, A478NgpTppID, A345NegID, A435NgpItem});
                     pr_default.close(49);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                     if ( (pr_default.getStatus(49) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_item"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1342( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1342( ) ;
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
            EndLevel1342( ) ;
         }
         CloseExtendedTableCursors1342( ) ;
      }

      protected void DeferredUpdate1342( )
      {
      }

      protected void Delete1342( )
      {
         Gx_mode = "DLT";
         BeforeValidate1342( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1342( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1342( ) ;
            AfterConfirm1342( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1342( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001370 */
                  pr_default.execute(50, new Object[] {A345NegID, A435NgpItem});
                  pr_default.close(50);
                  pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1342( ) ;
         Gx_mode = sMode42;
      }

      protected void OnDeleteControls1342( )
      {
         standaloneModal1342( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001371 */
            pr_default.execute(51, new Object[] {A439NgpTppPrdID});
            A440NgpTppPrdCodigo = BC001371_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC001371_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC001371_A443NgpTppPrdAtivo[0];
            A442NgpTppPrdTipoID = BC001371_A442NgpTppPrdTipoID[0];
            pr_default.close(51);
            /* Using cursor BC001372 */
            pr_default.execute(52, new Object[] {A478NgpTppID, A439NgpTppPrdID});
            A444NgpTpp1Preco = BC001372_A444NgpTpp1Preco[0];
            pr_default.close(52);
            if ( IsIns( )  )
            {
               A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal);
               n448NegPgpTotal = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal-O447NgpTotal);
                  n448NegPgpTotal = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A448NegPgpTotal = (decimal)(O448NegPgpTotal-O447NgpTotal);
                     n448NegPgpTotal = false;
                  }
               }
            }
            A380NegValorEstimado = A448NegPgpTotal;
            A385NegValorAtualizado = A448NegPgpTotal;
         }
      }

      protected void EndLevel1342( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1342( )
      {
         /* Scan By routine */
         /* Using cursor BC001373 */
         pr_default.execute(53, new Object[] {A345NegID});
         RcdFound42 = 0;
         if ( (pr_default.getStatus(53) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = BC001373_A447NgpTotal[0];
            A435NgpItem = BC001373_A435NgpItem[0];
            A446NgpQtde = BC001373_A446NgpQtde[0];
            A457NgpInsDataHora = BC001373_A457NgpInsDataHora[0];
            A455NgpInsData = BC001373_A455NgpInsData[0];
            A456NgpInsHora = BC001373_A456NgpInsHora[0];
            A458NgpInsUsuID = BC001373_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC001373_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC001373_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC001373_n459NgpInsUsuNome[0];
            A445NgpPreco = BC001373_A445NgpPreco[0];
            A579NgpDelDataHora = BC001373_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC001373_n579NgpDelDataHora[0];
            A580NgpDelData = BC001373_A580NgpDelData[0];
            n580NgpDelData = BC001373_n580NgpDelData[0];
            A581NgpDelHora = BC001373_A581NgpDelHora[0];
            n581NgpDelHora = BC001373_n581NgpDelHora[0];
            A582NgpDelUsuId = BC001373_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC001373_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC001373_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC001373_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = BC001373_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC001373_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC001373_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = BC001373_A444NgpTpp1Preco[0];
            A453NgpObs = BC001373_A453NgpObs[0];
            A578NgpDel = BC001373_A578NgpDel[0];
            A439NgpTppPrdID = BC001373_A439NgpTppPrdID[0];
            A478NgpTppID = BC001373_A478NgpTppID[0];
            A442NgpTppPrdTipoID = BC001373_A442NgpTppPrdTipoID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1342( )
      {
         /* Scan next routine */
         pr_default.readNext(53);
         RcdFound42 = 0;
         ScanKeyLoad1342( ) ;
      }

      protected void ScanKeyLoad1342( )
      {
         sMode42 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(53) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = BC001373_A447NgpTotal[0];
            A435NgpItem = BC001373_A435NgpItem[0];
            A446NgpQtde = BC001373_A446NgpQtde[0];
            A457NgpInsDataHora = BC001373_A457NgpInsDataHora[0];
            A455NgpInsData = BC001373_A455NgpInsData[0];
            A456NgpInsHora = BC001373_A456NgpInsHora[0];
            A458NgpInsUsuID = BC001373_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC001373_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC001373_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC001373_n459NgpInsUsuNome[0];
            A445NgpPreco = BC001373_A445NgpPreco[0];
            A579NgpDelDataHora = BC001373_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC001373_n579NgpDelDataHora[0];
            A580NgpDelData = BC001373_A580NgpDelData[0];
            n580NgpDelData = BC001373_n580NgpDelData[0];
            A581NgpDelHora = BC001373_A581NgpDelHora[0];
            n581NgpDelHora = BC001373_n581NgpDelHora[0];
            A582NgpDelUsuId = BC001373_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC001373_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC001373_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC001373_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = BC001373_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC001373_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC001373_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = BC001373_A444NgpTpp1Preco[0];
            A453NgpObs = BC001373_A453NgpObs[0];
            A578NgpDel = BC001373_A578NgpDel[0];
            A439NgpTppPrdID = BC001373_A439NgpTppPrdID[0];
            A478NgpTppID = BC001373_A478NgpTppID[0];
            A442NgpTppPrdTipoID = BC001373_A442NgpTppPrdTipoID[0];
         }
         Gx_mode = sMode42;
      }

      protected void ScanKeyEnd1342( )
      {
         pr_default.close(53);
      }

      protected void AfterConfirm1342( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1342( )
      {
         /* Before Insert Rules */
         A457NgpInsDataHora = DateTimeUtil.NowMS( context);
         A458NgpInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n458NgpInsUsuID = false;
         A459NgpInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n459NgpInsUsuNome = false;
         A455NgpInsData = DateTimeUtil.ResetTime( A457NgpInsDataHora);
         A456NgpInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A457NgpInsDataHora));
      }

      protected void BeforeUpdate1342( )
      {
         /* Before Update Rules */
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A579NgpDelDataHora = DateTimeUtil.NowMS( context);
            n579NgpDelDataHora = false;
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A582NgpDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n582NgpDelUsuId = false;
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A583NgpDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n583NgpDelUsuNome = false;
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A580NgpDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A579NgpDelDataHora) ) ;
            n580NgpDelData = false;
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A581NgpDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A579NgpDelDataHora));
            n581NgpDelHora = false;
         }
      }

      protected void BeforeDelete1342( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1342( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1342( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1342( )
      {
      }

      protected void send_integrity_lvl_hashes1342( )
      {
      }

      protected void send_integrity_lvl_hashes1337( )
      {
      }

      protected void AddRow1337( )
      {
         VarsToRow37( bccore_NegocioPJEstrutura) ;
      }

      protected void ReadRow1337( )
      {
         RowToVars37( bccore_NegocioPJEstrutura, 1) ;
      }

      protected void AddRow1339( )
      {
         GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase obj39;
         obj39 = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase(context);
         VarsToRow39( obj39) ;
         bccore_NegocioPJEstrutura.gxTpr_Fase.Add(obj39, 0);
         obj39.gxTpr_Mode = "UPD";
         obj39.gxTpr_Modified = 0;
      }

      protected void ReadRow1339( )
      {
         nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
         RowToVars39( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)bccore_NegocioPJEstrutura.gxTpr_Fase.Item(nGXsfl_39_idx)), 1) ;
      }

      protected void AddRow1342( )
      {
         GeneXus.Programs.core.SdtNegocioPJEstrutura_Item obj42;
         obj42 = new GeneXus.Programs.core.SdtNegocioPJEstrutura_Item(context);
         VarsToRow42( obj42) ;
         bccore_NegocioPJEstrutura.gxTpr_Item.Add(obj42, 0);
         obj42.gxTpr_Mode = "UPD";
         obj42.gxTpr_Modified = 0;
      }

      protected void ReadRow1342( )
      {
         nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
         RowToVars42( ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)bccore_NegocioPJEstrutura.gxTpr_Item.Item(nGXsfl_42_idx)), 1) ;
      }

      protected void InitializeNonKey1337( )
      {
         AV28AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A356NegCodigo = 0;
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A346NegInsData = DateTime.MinValue;
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A349NegInsUsuID = "";
         n349NegInsUsuID = false;
         A364NegInsUsuNome = "";
         n364NegInsUsuNome = false;
         A380NegValorEstimado = 0;
         A385NegValorAtualizado = 0;
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         n573NegDelDataHora = false;
         A574NegDelData = (DateTime)(DateTime.MinValue);
         n574NegDelData = false;
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         n575NegDelHora = false;
         A576NegDelUsuId = "";
         n576NegDelUsuId = false;
         A577NegDelUsuNome = "";
         n577NegDelUsuNome = false;
         A350NegCliID = Guid.Empty;
         A473NegCliMatricula = 0;
         A351NegCliNomeFamiliar = "";
         A352NegCpjID = Guid.Empty;
         A353NegCpjNomFan = "";
         A354NegCpjRazSocial = "";
         A355NegCpjMatricula = 0;
         A357NegPjtID = 0;
         A358NegPjtSigla = "";
         A359NegPjtNome = "";
         A369NegCpjEndSeq = 0;
         A370NegCpjEndNome = "";
         A371NegCpjEndEndereco = "";
         A372NegCpjEndNumero = "";
         A373NegCpjEndComplem = "";
         n373NegCpjEndComplem = false;
         A374NegCpjEndBairro = "";
         A375NegCpjEndMunID = 0;
         A376NegCpjEndMunNome = "";
         A377NegCpjEndUFID = 0;
         A378NegCpjEndUFSigla = "";
         A379NegCpjEndUFNome = "";
         A360NegAgcID = "";
         n360NegAgcID = false;
         A361NegAgcNome = "";
         n361NegAgcNome = false;
         A362NegAssunto = "";
         A363NegDescricao = "";
         A386NegUltFase = 0;
         A474NegUltNgfSeq = 0;
         n474NegUltNgfSeq = false;
         A420NegUltIteID = Guid.Empty;
         n420NegUltIteID = false;
         A421NegUltIteNome = "";
         n421NegUltIteNome = false;
         A479NegUltIteOrdem = 0;
         n479NegUltIteOrdem = false;
         A448NegPgpTotal = 0;
         n448NegPgpTotal = false;
         A454NegUltItem = 0;
         n454NegUltItem = false;
         A572NegDel = false;
         O454NegUltItem = A454NegUltItem;
         n454NegUltItem = false;
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         O386NegUltFase = A386NegUltFase;
         O572NegDel = A572NegDel;
         Z356NegCodigo = 0;
         Z348NegInsDataHora = (DateTime)(DateTime.MinValue);
         Z346NegInsData = DateTime.MinValue;
         Z347NegInsHora = (DateTime)(DateTime.MinValue);
         Z349NegInsUsuID = "";
         Z364NegInsUsuNome = "";
         Z380NegValorEstimado = 0;
         Z385NegValorAtualizado = 0;
         Z573NegDelDataHora = (DateTime)(DateTime.MinValue);
         Z574NegDelData = (DateTime)(DateTime.MinValue);
         Z575NegDelHora = (DateTime)(DateTime.MinValue);
         Z576NegDelUsuId = "";
         Z577NegDelUsuNome = "";
         Z360NegAgcID = "";
         Z361NegAgcNome = "";
         Z362NegAssunto = "";
         Z386NegUltFase = 0;
         Z454NegUltItem = 0;
         Z572NegDel = false;
         Z350NegCliID = Guid.Empty;
         Z352NegCpjID = Guid.Empty;
         Z369NegCpjEndSeq = 0;
      }

      protected void InitAll1337( )
      {
         A345NegID = Guid.NewGuid( );
         InitializeNonKey1337( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1339( )
      {
         A390NgfInsDataHora = (DateTime)(DateTime.MinValue);
         A388NgfInsData = DateTime.MinValue;
         A389NgfInsHora = (DateTime)(DateTime.MinValue);
         A391NgfInsUsuID = "";
         n391NgfInsUsuID = false;
         A392NgfInsUsuNome = "";
         n392NgfInsUsuNome = false;
         A585NgfDelDataHora = (DateTime)(DateTime.MinValue);
         n585NgfDelDataHora = false;
         A586NgfDelData = (DateTime)(DateTime.MinValue);
         n586NgfDelData = false;
         A587NgfDelHora = (DateTime)(DateTime.MinValue);
         n587NgfDelHora = false;
         A588NgfDelUsuId = "";
         n588NgfDelUsuId = false;
         A589NgfDelUsuNome = "";
         n589NgfDelUsuNome = false;
         A395NgfIteID = Guid.Empty;
         A396NgfIteOrdem = 0;
         A397NgfIteNome = "";
         A425NgfFimData = DateTime.MinValue;
         n425NgfFimData = false;
         A426NgfFimHora = (DateTime)(DateTime.MinValue);
         n426NgfFimHora = false;
         A427NgfFimDataHora = (DateTime)(DateTime.MinValue);
         n427NgfFimDataHora = false;
         A428NgfFimUsuID = "";
         n428NgfFimUsuID = false;
         A429NgfFimUsuNome = "";
         n429NgfFimUsuNome = false;
         A430NgfStatus = "";
         n430NgfStatus = false;
         A584NgfDel = false;
         O584NgfDel = A584NgfDel;
         Z390NgfInsDataHora = (DateTime)(DateTime.MinValue);
         Z388NgfInsData = DateTime.MinValue;
         Z389NgfInsHora = (DateTime)(DateTime.MinValue);
         Z391NgfInsUsuID = "";
         Z392NgfInsUsuNome = "";
         Z585NgfDelDataHora = (DateTime)(DateTime.MinValue);
         Z586NgfDelData = (DateTime)(DateTime.MinValue);
         Z587NgfDelHora = (DateTime)(DateTime.MinValue);
         Z588NgfDelUsuId = "";
         Z589NgfDelUsuNome = "";
         Z425NgfFimData = DateTime.MinValue;
         Z426NgfFimHora = (DateTime)(DateTime.MinValue);
         Z427NgfFimDataHora = (DateTime)(DateTime.MinValue);
         Z428NgfFimUsuID = "";
         Z429NgfFimUsuNome = "";
         Z430NgfStatus = "";
         Z584NgfDel = false;
         Z395NgfIteID = Guid.Empty;
      }

      protected void InitAll1339( )
      {
         A387NgfSeq = 0;
         InitializeNonKey1339( ) ;
      }

      protected void StandaloneModalInsert1339( )
      {
         A386NegUltFase = i386NegUltFase;
      }

      protected void InitializeNonKey1342( )
      {
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         A455NgpInsData = DateTime.MinValue;
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         A458NgpInsUsuID = "";
         n458NgpInsUsuID = false;
         A459NgpInsUsuNome = "";
         n459NgpInsUsuNome = false;
         A579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         n579NgpDelDataHora = false;
         A580NgpDelData = (DateTime)(DateTime.MinValue);
         n580NgpDelData = false;
         A581NgpDelHora = (DateTime)(DateTime.MinValue);
         n581NgpDelHora = false;
         A582NgpDelUsuId = "";
         n582NgpDelUsuId = false;
         A583NgpDelUsuNome = "";
         n583NgpDelUsuNome = false;
         A447NgpTotal = 0;
         A478NgpTppID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         A440NgpTppPrdCodigo = "";
         A441NgpTppPrdNome = "";
         A442NgpTppPrdTipoID = 0;
         A443NgpTppPrdAtivo = false;
         A444NgpTpp1Preco = 0;
         A453NgpObs = "";
         A578NgpDel = false;
         A446NgpQtde = 1;
         A445NgpPreco = 0;
         O578NgpDel = A578NgpDel;
         O447NgpTotal = A447NgpTotal;
         Z447NgpTotal = 0;
         Z446NgpQtde = 0;
         Z457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         Z455NgpInsData = DateTime.MinValue;
         Z456NgpInsHora = (DateTime)(DateTime.MinValue);
         Z458NgpInsUsuID = "";
         Z459NgpInsUsuNome = "";
         Z445NgpPreco = 0;
         Z579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         Z580NgpDelData = (DateTime)(DateTime.MinValue);
         Z581NgpDelHora = (DateTime)(DateTime.MinValue);
         Z582NgpDelUsuId = "";
         Z583NgpDelUsuNome = "";
         Z453NgpObs = "";
         Z578NgpDel = false;
         Z439NgpTppPrdID = Guid.Empty;
         Z478NgpTppID = Guid.Empty;
      }

      protected void InitAll1342( )
      {
         A435NgpItem = 0;
         InitializeNonKey1342( ) ;
      }

      protected void StandaloneModalInsert1342( )
      {
         A454NegUltItem = i454NegUltItem;
         n454NegUltItem = false;
         A446NgpQtde = i446NgpQtde;
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

      public void VarsToRow37( GeneXus.Programs.core.SdtNegocioPJEstrutura obj37 )
      {
         obj37.gxTpr_Mode = Gx_mode;
         obj37.gxTpr_Negcodigo = A356NegCodigo;
         obj37.gxTpr_Neginsdatahora = A348NegInsDataHora;
         obj37.gxTpr_Neginsdata = A346NegInsData;
         obj37.gxTpr_Neginshora = A347NegInsHora;
         obj37.gxTpr_Neginsusuid = A349NegInsUsuID;
         obj37.gxTpr_Neginsusunome = A364NegInsUsuNome;
         obj37.gxTpr_Negvalorestimado = A380NegValorEstimado;
         obj37.gxTpr_Negvaloratualizado = A385NegValorAtualizado;
         obj37.gxTpr_Negdeldatahora = A573NegDelDataHora;
         obj37.gxTpr_Negdeldata = A574NegDelData;
         obj37.gxTpr_Negdelhora = A575NegDelHora;
         obj37.gxTpr_Negdelusuid = A576NegDelUsuId;
         obj37.gxTpr_Negdelusunome = A577NegDelUsuNome;
         obj37.gxTpr_Negcliid = A350NegCliID;
         obj37.gxTpr_Negclimatricula = A473NegCliMatricula;
         obj37.gxTpr_Negclinomefamiliar = A351NegCliNomeFamiliar;
         obj37.gxTpr_Negcpjid = A352NegCpjID;
         obj37.gxTpr_Negcpjnomfan = A353NegCpjNomFan;
         obj37.gxTpr_Negcpjrazsocial = A354NegCpjRazSocial;
         obj37.gxTpr_Negcpjmatricula = A355NegCpjMatricula;
         obj37.gxTpr_Negpjtid = A357NegPjtID;
         obj37.gxTpr_Negpjtsigla = A358NegPjtSigla;
         obj37.gxTpr_Negpjtnome = A359NegPjtNome;
         obj37.gxTpr_Negcpjendseq = A369NegCpjEndSeq;
         obj37.gxTpr_Negcpjendnome = A370NegCpjEndNome;
         obj37.gxTpr_Negcpjendendereco = A371NegCpjEndEndereco;
         obj37.gxTpr_Negcpjendnumero = A372NegCpjEndNumero;
         obj37.gxTpr_Negcpjendcomplem = A373NegCpjEndComplem;
         obj37.gxTpr_Negcpjendbairro = A374NegCpjEndBairro;
         obj37.gxTpr_Negcpjendmunid = A375NegCpjEndMunID;
         obj37.gxTpr_Negcpjendmunnome = A376NegCpjEndMunNome;
         obj37.gxTpr_Negcpjendufid = A377NegCpjEndUFID;
         obj37.gxTpr_Negcpjendufsigla = A378NegCpjEndUFSigla;
         obj37.gxTpr_Negcpjendufnome = A379NegCpjEndUFNome;
         obj37.gxTpr_Negagcid = A360NegAgcID;
         obj37.gxTpr_Negagcnome = A361NegAgcNome;
         obj37.gxTpr_Negassunto = A362NegAssunto;
         obj37.gxTpr_Negdescricao = A363NegDescricao;
         obj37.gxTpr_Negultfase = A386NegUltFase;
         obj37.gxTpr_Negultngfseq = A474NegUltNgfSeq;
         obj37.gxTpr_Negultiteid = A420NegUltIteID;
         obj37.gxTpr_Negultitenome = A421NegUltIteNome;
         obj37.gxTpr_Negultiteordem = A479NegUltIteOrdem;
         obj37.gxTpr_Negpgptotal = A448NegPgpTotal;
         obj37.gxTpr_Negultitem = A454NegUltItem;
         obj37.gxTpr_Negdel = A572NegDel;
         obj37.gxTpr_Negid = A345NegID;
         obj37.gxTpr_Negid_Z = Z345NegID;
         obj37.gxTpr_Negcodigo_Z = Z356NegCodigo;
         obj37.gxTpr_Neginsdata_Z = Z346NegInsData;
         obj37.gxTpr_Neginshora_Z = Z347NegInsHora;
         obj37.gxTpr_Neginsdatahora_Z = Z348NegInsDataHora;
         obj37.gxTpr_Neginsusuid_Z = Z349NegInsUsuID;
         obj37.gxTpr_Neginsusunome_Z = Z364NegInsUsuNome;
         obj37.gxTpr_Negcliid_Z = Z350NegCliID;
         obj37.gxTpr_Negclimatricula_Z = Z473NegCliMatricula;
         obj37.gxTpr_Negclinomefamiliar_Z = Z351NegCliNomeFamiliar;
         obj37.gxTpr_Negcpjid_Z = Z352NegCpjID;
         obj37.gxTpr_Negcpjnomfan_Z = Z353NegCpjNomFan;
         obj37.gxTpr_Negcpjrazsocial_Z = Z354NegCpjRazSocial;
         obj37.gxTpr_Negcpjmatricula_Z = Z355NegCpjMatricula;
         obj37.gxTpr_Negpjtid_Z = Z357NegPjtID;
         obj37.gxTpr_Negpjtsigla_Z = Z358NegPjtSigla;
         obj37.gxTpr_Negpjtnome_Z = Z359NegPjtNome;
         obj37.gxTpr_Negcpjendseq_Z = Z369NegCpjEndSeq;
         obj37.gxTpr_Negcpjendnome_Z = Z370NegCpjEndNome;
         obj37.gxTpr_Negcpjendendereco_Z = Z371NegCpjEndEndereco;
         obj37.gxTpr_Negcpjendnumero_Z = Z372NegCpjEndNumero;
         obj37.gxTpr_Negcpjendcomplem_Z = Z373NegCpjEndComplem;
         obj37.gxTpr_Negcpjendbairro_Z = Z374NegCpjEndBairro;
         obj37.gxTpr_Negcpjendmunid_Z = Z375NegCpjEndMunID;
         obj37.gxTpr_Negcpjendmunnome_Z = Z376NegCpjEndMunNome;
         obj37.gxTpr_Negcpjendufid_Z = Z377NegCpjEndUFID;
         obj37.gxTpr_Negcpjendufsigla_Z = Z378NegCpjEndUFSigla;
         obj37.gxTpr_Negcpjendufnome_Z = Z379NegCpjEndUFNome;
         obj37.gxTpr_Negagcid_Z = Z360NegAgcID;
         obj37.gxTpr_Negagcnome_Z = Z361NegAgcNome;
         obj37.gxTpr_Negassunto_Z = Z362NegAssunto;
         obj37.gxTpr_Negultfase_Z = Z386NegUltFase;
         obj37.gxTpr_Negultngfseq_Z = Z474NegUltNgfSeq;
         obj37.gxTpr_Negultiteid_Z = Z420NegUltIteID;
         obj37.gxTpr_Negultitenome_Z = Z421NegUltIteNome;
         obj37.gxTpr_Negultiteordem_Z = Z479NegUltIteOrdem;
         obj37.gxTpr_Negpgptotal_Z = Z448NegPgpTotal;
         obj37.gxTpr_Negvalorestimado_Z = Z380NegValorEstimado;
         obj37.gxTpr_Negvaloratualizado_Z = Z385NegValorAtualizado;
         obj37.gxTpr_Negultitem_Z = Z454NegUltItem;
         obj37.gxTpr_Negdel_Z = Z572NegDel;
         obj37.gxTpr_Negdeldatahora_Z = Z573NegDelDataHora;
         obj37.gxTpr_Negdeldata_Z = Z574NegDelData;
         obj37.gxTpr_Negdelhora_Z = Z575NegDelHora;
         obj37.gxTpr_Negdelusuid_Z = Z576NegDelUsuId;
         obj37.gxTpr_Negdelusunome_Z = Z577NegDelUsuNome;
         obj37.gxTpr_Neginsusuid_N = (short)(Convert.ToInt16(n349NegInsUsuID));
         obj37.gxTpr_Neginsusunome_N = (short)(Convert.ToInt16(n364NegInsUsuNome));
         obj37.gxTpr_Negcpjendcomplem_N = (short)(Convert.ToInt16(n373NegCpjEndComplem));
         obj37.gxTpr_Negagcid_N = (short)(Convert.ToInt16(n360NegAgcID));
         obj37.gxTpr_Negagcnome_N = (short)(Convert.ToInt16(n361NegAgcNome));
         obj37.gxTpr_Negultngfseq_N = (short)(Convert.ToInt16(n474NegUltNgfSeq));
         obj37.gxTpr_Negultiteid_N = (short)(Convert.ToInt16(n420NegUltIteID));
         obj37.gxTpr_Negultitenome_N = (short)(Convert.ToInt16(n421NegUltIteNome));
         obj37.gxTpr_Negultiteordem_N = (short)(Convert.ToInt16(n479NegUltIteOrdem));
         obj37.gxTpr_Negpgptotal_N = (short)(Convert.ToInt16(n448NegPgpTotal));
         obj37.gxTpr_Negultitem_N = (short)(Convert.ToInt16(n454NegUltItem));
         obj37.gxTpr_Negdeldatahora_N = (short)(Convert.ToInt16(n573NegDelDataHora));
         obj37.gxTpr_Negdeldata_N = (short)(Convert.ToInt16(n574NegDelData));
         obj37.gxTpr_Negdelhora_N = (short)(Convert.ToInt16(n575NegDelHora));
         obj37.gxTpr_Negdelusuid_N = (short)(Convert.ToInt16(n576NegDelUsuId));
         obj37.gxTpr_Negdelusunome_N = (short)(Convert.ToInt16(n577NegDelUsuNome));
         obj37.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow37( GeneXus.Programs.core.SdtNegocioPJEstrutura obj37 )
      {
         obj37.gxTpr_Negid = A345NegID;
         return  ;
      }

      public void RowToVars37( GeneXus.Programs.core.SdtNegocioPJEstrutura obj37 ,
                               int forceLoad )
      {
         Gx_mode = obj37.gxTpr_Mode;
         A356NegCodigo = obj37.gxTpr_Negcodigo;
         A348NegInsDataHora = obj37.gxTpr_Neginsdatahora;
         A346NegInsData = obj37.gxTpr_Neginsdata;
         A347NegInsHora = obj37.gxTpr_Neginshora;
         A349NegInsUsuID = obj37.gxTpr_Neginsusuid;
         n349NegInsUsuID = false;
         A364NegInsUsuNome = obj37.gxTpr_Neginsusunome;
         n364NegInsUsuNome = false;
         A380NegValorEstimado = obj37.gxTpr_Negvalorestimado;
         A385NegValorAtualizado = obj37.gxTpr_Negvaloratualizado;
         A573NegDelDataHora = obj37.gxTpr_Negdeldatahora;
         n573NegDelDataHora = false;
         A574NegDelData = obj37.gxTpr_Negdeldata;
         n574NegDelData = false;
         A575NegDelHora = obj37.gxTpr_Negdelhora;
         n575NegDelHora = false;
         A576NegDelUsuId = obj37.gxTpr_Negdelusuid;
         n576NegDelUsuId = false;
         A577NegDelUsuNome = obj37.gxTpr_Negdelusunome;
         n577NegDelUsuNome = false;
         A350NegCliID = obj37.gxTpr_Negcliid;
         A473NegCliMatricula = obj37.gxTpr_Negclimatricula;
         A351NegCliNomeFamiliar = obj37.gxTpr_Negclinomefamiliar;
         A352NegCpjID = obj37.gxTpr_Negcpjid;
         A353NegCpjNomFan = obj37.gxTpr_Negcpjnomfan;
         A354NegCpjRazSocial = obj37.gxTpr_Negcpjrazsocial;
         A355NegCpjMatricula = obj37.gxTpr_Negcpjmatricula;
         A357NegPjtID = obj37.gxTpr_Negpjtid;
         A358NegPjtSigla = obj37.gxTpr_Negpjtsigla;
         A359NegPjtNome = obj37.gxTpr_Negpjtnome;
         A369NegCpjEndSeq = obj37.gxTpr_Negcpjendseq;
         A370NegCpjEndNome = obj37.gxTpr_Negcpjendnome;
         A371NegCpjEndEndereco = obj37.gxTpr_Negcpjendendereco;
         A372NegCpjEndNumero = obj37.gxTpr_Negcpjendnumero;
         A373NegCpjEndComplem = obj37.gxTpr_Negcpjendcomplem;
         n373NegCpjEndComplem = false;
         A374NegCpjEndBairro = obj37.gxTpr_Negcpjendbairro;
         A375NegCpjEndMunID = obj37.gxTpr_Negcpjendmunid;
         A376NegCpjEndMunNome = obj37.gxTpr_Negcpjendmunnome;
         A377NegCpjEndUFID = obj37.gxTpr_Negcpjendufid;
         A378NegCpjEndUFSigla = obj37.gxTpr_Negcpjendufsigla;
         A379NegCpjEndUFNome = obj37.gxTpr_Negcpjendufnome;
         A360NegAgcID = obj37.gxTpr_Negagcid;
         n360NegAgcID = false;
         A361NegAgcNome = obj37.gxTpr_Negagcnome;
         n361NegAgcNome = false;
         A362NegAssunto = obj37.gxTpr_Negassunto;
         A363NegDescricao = obj37.gxTpr_Negdescricao;
         if ( forceLoad == 1 )
         {
            A386NegUltFase = obj37.gxTpr_Negultfase;
         }
         A474NegUltNgfSeq = obj37.gxTpr_Negultngfseq;
         n474NegUltNgfSeq = false;
         A420NegUltIteID = obj37.gxTpr_Negultiteid;
         n420NegUltIteID = false;
         A421NegUltIteNome = obj37.gxTpr_Negultitenome;
         n421NegUltIteNome = false;
         A479NegUltIteOrdem = obj37.gxTpr_Negultiteordem;
         n479NegUltIteOrdem = false;
         A448NegPgpTotal = obj37.gxTpr_Negpgptotal;
         n448NegPgpTotal = false;
         if ( forceLoad == 1 )
         {
            A454NegUltItem = obj37.gxTpr_Negultitem;
            n454NegUltItem = false;
         }
         A572NegDel = obj37.gxTpr_Negdel;
         A345NegID = obj37.gxTpr_Negid;
         Z345NegID = obj37.gxTpr_Negid_Z;
         Z356NegCodigo = obj37.gxTpr_Negcodigo_Z;
         Z346NegInsData = obj37.gxTpr_Neginsdata_Z;
         Z347NegInsHora = obj37.gxTpr_Neginshora_Z;
         Z348NegInsDataHora = obj37.gxTpr_Neginsdatahora_Z;
         Z349NegInsUsuID = obj37.gxTpr_Neginsusuid_Z;
         Z364NegInsUsuNome = obj37.gxTpr_Neginsusunome_Z;
         Z350NegCliID = obj37.gxTpr_Negcliid_Z;
         Z473NegCliMatricula = obj37.gxTpr_Negclimatricula_Z;
         Z351NegCliNomeFamiliar = obj37.gxTpr_Negclinomefamiliar_Z;
         Z352NegCpjID = obj37.gxTpr_Negcpjid_Z;
         Z353NegCpjNomFan = obj37.gxTpr_Negcpjnomfan_Z;
         Z354NegCpjRazSocial = obj37.gxTpr_Negcpjrazsocial_Z;
         Z355NegCpjMatricula = obj37.gxTpr_Negcpjmatricula_Z;
         Z357NegPjtID = obj37.gxTpr_Negpjtid_Z;
         Z358NegPjtSigla = obj37.gxTpr_Negpjtsigla_Z;
         Z359NegPjtNome = obj37.gxTpr_Negpjtnome_Z;
         Z369NegCpjEndSeq = obj37.gxTpr_Negcpjendseq_Z;
         Z370NegCpjEndNome = obj37.gxTpr_Negcpjendnome_Z;
         Z371NegCpjEndEndereco = obj37.gxTpr_Negcpjendendereco_Z;
         Z372NegCpjEndNumero = obj37.gxTpr_Negcpjendnumero_Z;
         Z373NegCpjEndComplem = obj37.gxTpr_Negcpjendcomplem_Z;
         Z374NegCpjEndBairro = obj37.gxTpr_Negcpjendbairro_Z;
         Z375NegCpjEndMunID = obj37.gxTpr_Negcpjendmunid_Z;
         Z376NegCpjEndMunNome = obj37.gxTpr_Negcpjendmunnome_Z;
         Z377NegCpjEndUFID = obj37.gxTpr_Negcpjendufid_Z;
         Z378NegCpjEndUFSigla = obj37.gxTpr_Negcpjendufsigla_Z;
         Z379NegCpjEndUFNome = obj37.gxTpr_Negcpjendufnome_Z;
         Z360NegAgcID = obj37.gxTpr_Negagcid_Z;
         Z361NegAgcNome = obj37.gxTpr_Negagcnome_Z;
         Z362NegAssunto = obj37.gxTpr_Negassunto_Z;
         Z386NegUltFase = obj37.gxTpr_Negultfase_Z;
         O386NegUltFase = obj37.gxTpr_Negultfase_Z;
         Z474NegUltNgfSeq = obj37.gxTpr_Negultngfseq_Z;
         Z420NegUltIteID = obj37.gxTpr_Negultiteid_Z;
         Z421NegUltIteNome = obj37.gxTpr_Negultitenome_Z;
         Z479NegUltIteOrdem = obj37.gxTpr_Negultiteordem_Z;
         Z448NegPgpTotal = obj37.gxTpr_Negpgptotal_Z;
         O448NegPgpTotal = obj37.gxTpr_Negpgptotal_Z;
         Z380NegValorEstimado = obj37.gxTpr_Negvalorestimado_Z;
         Z385NegValorAtualizado = obj37.gxTpr_Negvaloratualizado_Z;
         Z454NegUltItem = obj37.gxTpr_Negultitem_Z;
         O454NegUltItem = obj37.gxTpr_Negultitem_Z;
         Z572NegDel = obj37.gxTpr_Negdel_Z;
         O572NegDel = obj37.gxTpr_Negdel_Z;
         Z573NegDelDataHora = obj37.gxTpr_Negdeldatahora_Z;
         Z574NegDelData = obj37.gxTpr_Negdeldata_Z;
         Z575NegDelHora = obj37.gxTpr_Negdelhora_Z;
         Z576NegDelUsuId = obj37.gxTpr_Negdelusuid_Z;
         Z577NegDelUsuNome = obj37.gxTpr_Negdelusunome_Z;
         n349NegInsUsuID = (bool)(Convert.ToBoolean(obj37.gxTpr_Neginsusuid_N));
         n364NegInsUsuNome = (bool)(Convert.ToBoolean(obj37.gxTpr_Neginsusunome_N));
         n373NegCpjEndComplem = (bool)(Convert.ToBoolean(obj37.gxTpr_Negcpjendcomplem_N));
         n360NegAgcID = (bool)(Convert.ToBoolean(obj37.gxTpr_Negagcid_N));
         n361NegAgcNome = (bool)(Convert.ToBoolean(obj37.gxTpr_Negagcnome_N));
         n474NegUltNgfSeq = (bool)(Convert.ToBoolean(obj37.gxTpr_Negultngfseq_N));
         n420NegUltIteID = (bool)(Convert.ToBoolean(obj37.gxTpr_Negultiteid_N));
         n421NegUltIteNome = (bool)(Convert.ToBoolean(obj37.gxTpr_Negultitenome_N));
         n479NegUltIteOrdem = (bool)(Convert.ToBoolean(obj37.gxTpr_Negultiteordem_N));
         n448NegPgpTotal = (bool)(Convert.ToBoolean(obj37.gxTpr_Negpgptotal_N));
         n454NegUltItem = (bool)(Convert.ToBoolean(obj37.gxTpr_Negultitem_N));
         n573NegDelDataHora = (bool)(Convert.ToBoolean(obj37.gxTpr_Negdeldatahora_N));
         n574NegDelData = (bool)(Convert.ToBoolean(obj37.gxTpr_Negdeldata_N));
         n575NegDelHora = (bool)(Convert.ToBoolean(obj37.gxTpr_Negdelhora_N));
         n576NegDelUsuId = (bool)(Convert.ToBoolean(obj37.gxTpr_Negdelusuid_N));
         n577NegDelUsuNome = (bool)(Convert.ToBoolean(obj37.gxTpr_Negdelusunome_N));
         Gx_mode = obj37.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow39( GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase obj39 )
      {
         obj39.gxTpr_Mode = Gx_mode;
         obj39.gxTpr_Ngfinsdatahora = A390NgfInsDataHora;
         obj39.gxTpr_Ngfinsdata = A388NgfInsData;
         obj39.gxTpr_Ngfinshora = A389NgfInsHora;
         obj39.gxTpr_Ngfinsusuid = A391NgfInsUsuID;
         obj39.gxTpr_Ngfinsusunome = A392NgfInsUsuNome;
         obj39.gxTpr_Ngfdeldatahora = A585NgfDelDataHora;
         obj39.gxTpr_Ngfdeldata = A586NgfDelData;
         obj39.gxTpr_Ngfdelhora = A587NgfDelHora;
         obj39.gxTpr_Ngfdelusuid = A588NgfDelUsuId;
         obj39.gxTpr_Ngfdelusunome = A589NgfDelUsuNome;
         obj39.gxTpr_Ngfiteid = A395NgfIteID;
         obj39.gxTpr_Ngfiteordem = A396NgfIteOrdem;
         obj39.gxTpr_Ngfitenome = A397NgfIteNome;
         obj39.gxTpr_Ngffimdata = A425NgfFimData;
         obj39.gxTpr_Ngffimhora = A426NgfFimHora;
         obj39.gxTpr_Ngffimdatahora = A427NgfFimDataHora;
         obj39.gxTpr_Ngffimusuid = A428NgfFimUsuID;
         obj39.gxTpr_Ngffimusunome = A429NgfFimUsuNome;
         obj39.gxTpr_Ngfstatus = A430NgfStatus;
         obj39.gxTpr_Ngfdel = A584NgfDel;
         obj39.gxTpr_Ngfseq = A387NgfSeq;
         obj39.gxTpr_Ngfseq_Z = Z387NgfSeq;
         obj39.gxTpr_Ngfinsdata_Z = Z388NgfInsData;
         obj39.gxTpr_Ngfinshora_Z = Z389NgfInsHora;
         obj39.gxTpr_Ngfinsdatahora_Z = Z390NgfInsDataHora;
         obj39.gxTpr_Ngfinsusuid_Z = Z391NgfInsUsuID;
         obj39.gxTpr_Ngfinsusunome_Z = Z392NgfInsUsuNome;
         obj39.gxTpr_Ngfiteid_Z = Z395NgfIteID;
         obj39.gxTpr_Ngfiteordem_Z = Z396NgfIteOrdem;
         obj39.gxTpr_Ngfitenome_Z = Z397NgfIteNome;
         obj39.gxTpr_Ngffimdata_Z = Z425NgfFimData;
         obj39.gxTpr_Ngffimhora_Z = Z426NgfFimHora;
         obj39.gxTpr_Ngffimdatahora_Z = Z427NgfFimDataHora;
         obj39.gxTpr_Ngffimusuid_Z = Z428NgfFimUsuID;
         obj39.gxTpr_Ngffimusunome_Z = Z429NgfFimUsuNome;
         obj39.gxTpr_Ngfstatus_Z = Z430NgfStatus;
         obj39.gxTpr_Ngfdel_Z = Z584NgfDel;
         obj39.gxTpr_Ngfdeldatahora_Z = Z585NgfDelDataHora;
         obj39.gxTpr_Ngfdeldata_Z = Z586NgfDelData;
         obj39.gxTpr_Ngfdelhora_Z = Z587NgfDelHora;
         obj39.gxTpr_Ngfdelusuid_Z = Z588NgfDelUsuId;
         obj39.gxTpr_Ngfdelusunome_Z = Z589NgfDelUsuNome;
         obj39.gxTpr_Ngfinsusuid_N = (short)(Convert.ToInt16(n391NgfInsUsuID));
         obj39.gxTpr_Ngfinsusunome_N = (short)(Convert.ToInt16(n392NgfInsUsuNome));
         obj39.gxTpr_Ngffimdata_N = (short)(Convert.ToInt16(n425NgfFimData));
         obj39.gxTpr_Ngffimhora_N = (short)(Convert.ToInt16(n426NgfFimHora));
         obj39.gxTpr_Ngffimdatahora_N = (short)(Convert.ToInt16(n427NgfFimDataHora));
         obj39.gxTpr_Ngffimusuid_N = (short)(Convert.ToInt16(n428NgfFimUsuID));
         obj39.gxTpr_Ngffimusunome_N = (short)(Convert.ToInt16(n429NgfFimUsuNome));
         obj39.gxTpr_Ngfstatus_N = (short)(Convert.ToInt16(n430NgfStatus));
         obj39.gxTpr_Ngfdeldatahora_N = (short)(Convert.ToInt16(n585NgfDelDataHora));
         obj39.gxTpr_Ngfdeldata_N = (short)(Convert.ToInt16(n586NgfDelData));
         obj39.gxTpr_Ngfdelhora_N = (short)(Convert.ToInt16(n587NgfDelHora));
         obj39.gxTpr_Ngfdelusuid_N = (short)(Convert.ToInt16(n588NgfDelUsuId));
         obj39.gxTpr_Ngfdelusunome_N = (short)(Convert.ToInt16(n589NgfDelUsuNome));
         obj39.gxTpr_Modified = nIsMod_39;
         return  ;
      }

      public void KeyVarsToRow39( GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase obj39 )
      {
         obj39.gxTpr_Ngfseq = A387NgfSeq;
         return  ;
      }

      public void RowToVars39( GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase obj39 ,
                               int forceLoad )
      {
         Gx_mode = obj39.gxTpr_Mode;
         A390NgfInsDataHora = obj39.gxTpr_Ngfinsdatahora;
         A388NgfInsData = obj39.gxTpr_Ngfinsdata;
         A389NgfInsHora = obj39.gxTpr_Ngfinshora;
         A391NgfInsUsuID = obj39.gxTpr_Ngfinsusuid;
         n391NgfInsUsuID = false;
         A392NgfInsUsuNome = obj39.gxTpr_Ngfinsusunome;
         n392NgfInsUsuNome = false;
         A585NgfDelDataHora = obj39.gxTpr_Ngfdeldatahora;
         n585NgfDelDataHora = false;
         A586NgfDelData = obj39.gxTpr_Ngfdeldata;
         n586NgfDelData = false;
         A587NgfDelHora = obj39.gxTpr_Ngfdelhora;
         n587NgfDelHora = false;
         A588NgfDelUsuId = obj39.gxTpr_Ngfdelusuid;
         n588NgfDelUsuId = false;
         A589NgfDelUsuNome = obj39.gxTpr_Ngfdelusunome;
         n589NgfDelUsuNome = false;
         A395NgfIteID = obj39.gxTpr_Ngfiteid;
         A396NgfIteOrdem = obj39.gxTpr_Ngfiteordem;
         A397NgfIteNome = obj39.gxTpr_Ngfitenome;
         A425NgfFimData = obj39.gxTpr_Ngffimdata;
         n425NgfFimData = false;
         A426NgfFimHora = obj39.gxTpr_Ngffimhora;
         n426NgfFimHora = false;
         A427NgfFimDataHora = obj39.gxTpr_Ngffimdatahora;
         n427NgfFimDataHora = false;
         A428NgfFimUsuID = obj39.gxTpr_Ngffimusuid;
         n428NgfFimUsuID = false;
         A429NgfFimUsuNome = obj39.gxTpr_Ngffimusunome;
         n429NgfFimUsuNome = false;
         A430NgfStatus = obj39.gxTpr_Ngfstatus;
         n430NgfStatus = false;
         A584NgfDel = obj39.gxTpr_Ngfdel;
         A387NgfSeq = obj39.gxTpr_Ngfseq;
         Z387NgfSeq = obj39.gxTpr_Ngfseq_Z;
         Z388NgfInsData = obj39.gxTpr_Ngfinsdata_Z;
         Z389NgfInsHora = obj39.gxTpr_Ngfinshora_Z;
         Z390NgfInsDataHora = obj39.gxTpr_Ngfinsdatahora_Z;
         Z391NgfInsUsuID = obj39.gxTpr_Ngfinsusuid_Z;
         Z392NgfInsUsuNome = obj39.gxTpr_Ngfinsusunome_Z;
         Z395NgfIteID = obj39.gxTpr_Ngfiteid_Z;
         Z396NgfIteOrdem = obj39.gxTpr_Ngfiteordem_Z;
         Z397NgfIteNome = obj39.gxTpr_Ngfitenome_Z;
         Z425NgfFimData = obj39.gxTpr_Ngffimdata_Z;
         Z426NgfFimHora = obj39.gxTpr_Ngffimhora_Z;
         Z427NgfFimDataHora = obj39.gxTpr_Ngffimdatahora_Z;
         Z428NgfFimUsuID = obj39.gxTpr_Ngffimusuid_Z;
         Z429NgfFimUsuNome = obj39.gxTpr_Ngffimusunome_Z;
         Z430NgfStatus = obj39.gxTpr_Ngfstatus_Z;
         Z584NgfDel = obj39.gxTpr_Ngfdel_Z;
         O584NgfDel = obj39.gxTpr_Ngfdel_Z;
         Z585NgfDelDataHora = obj39.gxTpr_Ngfdeldatahora_Z;
         Z586NgfDelData = obj39.gxTpr_Ngfdeldata_Z;
         Z587NgfDelHora = obj39.gxTpr_Ngfdelhora_Z;
         Z588NgfDelUsuId = obj39.gxTpr_Ngfdelusuid_Z;
         Z589NgfDelUsuNome = obj39.gxTpr_Ngfdelusunome_Z;
         n391NgfInsUsuID = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfinsusuid_N));
         n392NgfInsUsuNome = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfinsusunome_N));
         n425NgfFimData = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngffimdata_N));
         n426NgfFimHora = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngffimhora_N));
         n427NgfFimDataHora = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngffimdatahora_N));
         n428NgfFimUsuID = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngffimusuid_N));
         n429NgfFimUsuNome = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngffimusunome_N));
         n430NgfStatus = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfstatus_N));
         n585NgfDelDataHora = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfdeldatahora_N));
         n586NgfDelData = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfdeldata_N));
         n587NgfDelHora = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfdelhora_N));
         n588NgfDelUsuId = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfdelusuid_N));
         n589NgfDelUsuNome = (bool)(Convert.ToBoolean(obj39.gxTpr_Ngfdelusunome_N));
         nIsMod_39 = obj39.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow42( GeneXus.Programs.core.SdtNegocioPJEstrutura_Item obj42 )
      {
         obj42.gxTpr_Mode = Gx_mode;
         obj42.gxTpr_Ngpinsdatahora = A457NgpInsDataHora;
         obj42.gxTpr_Ngpinsdata = A455NgpInsData;
         obj42.gxTpr_Ngpinshora = A456NgpInsHora;
         obj42.gxTpr_Ngpinsusuid = A458NgpInsUsuID;
         obj42.gxTpr_Ngpinsusunome = A459NgpInsUsuNome;
         obj42.gxTpr_Ngpdeldatahora = A579NgpDelDataHora;
         obj42.gxTpr_Ngpdeldata = A580NgpDelData;
         obj42.gxTpr_Ngpdelhora = A581NgpDelHora;
         obj42.gxTpr_Ngpdelusuid = A582NgpDelUsuId;
         obj42.gxTpr_Ngpdelusunome = A583NgpDelUsuNome;
         obj42.gxTpr_Ngptotal = A447NgpTotal;
         obj42.gxTpr_Ngptppid = A478NgpTppID;
         obj42.gxTpr_Ngptppprdid = A439NgpTppPrdID;
         obj42.gxTpr_Ngptppprdcodigo = A440NgpTppPrdCodigo;
         obj42.gxTpr_Ngptppprdnome = A441NgpTppPrdNome;
         obj42.gxTpr_Ngptppprdtipoid = A442NgpTppPrdTipoID;
         obj42.gxTpr_Ngptppprdativo = A443NgpTppPrdAtivo;
         obj42.gxTpr_Ngptpp1preco = A444NgpTpp1Preco;
         obj42.gxTpr_Ngpobs = A453NgpObs;
         obj42.gxTpr_Ngpdel = A578NgpDel;
         obj42.gxTpr_Ngpqtde = A446NgpQtde;
         obj42.gxTpr_Ngppreco = A445NgpPreco;
         obj42.gxTpr_Ngpitem = A435NgpItem;
         obj42.gxTpr_Ngpitem_Z = Z435NgpItem;
         obj42.gxTpr_Ngpinsdata_Z = Z455NgpInsData;
         obj42.gxTpr_Ngpinshora_Z = Z456NgpInsHora;
         obj42.gxTpr_Ngpinsdatahora_Z = Z457NgpInsDataHora;
         obj42.gxTpr_Ngpinsusuid_Z = Z458NgpInsUsuID;
         obj42.gxTpr_Ngpinsusunome_Z = Z459NgpInsUsuNome;
         obj42.gxTpr_Ngptppid_Z = Z478NgpTppID;
         obj42.gxTpr_Ngptppprdid_Z = Z439NgpTppPrdID;
         obj42.gxTpr_Ngptppprdcodigo_Z = Z440NgpTppPrdCodigo;
         obj42.gxTpr_Ngptppprdnome_Z = Z441NgpTppPrdNome;
         obj42.gxTpr_Ngptppprdtipoid_Z = Z442NgpTppPrdTipoID;
         obj42.gxTpr_Ngptppprdativo_Z = Z443NgpTppPrdAtivo;
         obj42.gxTpr_Ngptpp1preco_Z = Z444NgpTpp1Preco;
         obj42.gxTpr_Ngppreco_Z = Z445NgpPreco;
         obj42.gxTpr_Ngpqtde_Z = Z446NgpQtde;
         obj42.gxTpr_Ngptotal_Z = Z447NgpTotal;
         obj42.gxTpr_Ngpobs_Z = Z453NgpObs;
         obj42.gxTpr_Ngpdel_Z = Z578NgpDel;
         obj42.gxTpr_Ngpdeldatahora_Z = Z579NgpDelDataHora;
         obj42.gxTpr_Ngpdeldata_Z = Z580NgpDelData;
         obj42.gxTpr_Ngpdelhora_Z = Z581NgpDelHora;
         obj42.gxTpr_Ngpdelusuid_Z = Z582NgpDelUsuId;
         obj42.gxTpr_Ngpdelusunome_Z = Z583NgpDelUsuNome;
         obj42.gxTpr_Ngpinsusuid_N = (short)(Convert.ToInt16(n458NgpInsUsuID));
         obj42.gxTpr_Ngpinsusunome_N = (short)(Convert.ToInt16(n459NgpInsUsuNome));
         obj42.gxTpr_Ngpdeldatahora_N = (short)(Convert.ToInt16(n579NgpDelDataHora));
         obj42.gxTpr_Ngpdeldata_N = (short)(Convert.ToInt16(n580NgpDelData));
         obj42.gxTpr_Ngpdelhora_N = (short)(Convert.ToInt16(n581NgpDelHora));
         obj42.gxTpr_Ngpdelusuid_N = (short)(Convert.ToInt16(n582NgpDelUsuId));
         obj42.gxTpr_Ngpdelusunome_N = (short)(Convert.ToInt16(n583NgpDelUsuNome));
         obj42.gxTpr_Modified = nIsMod_42;
         return  ;
      }

      public void KeyVarsToRow42( GeneXus.Programs.core.SdtNegocioPJEstrutura_Item obj42 )
      {
         obj42.gxTpr_Ngpitem = A435NgpItem;
         return  ;
      }

      public void RowToVars42( GeneXus.Programs.core.SdtNegocioPJEstrutura_Item obj42 ,
                               int forceLoad )
      {
         Gx_mode = obj42.gxTpr_Mode;
         A457NgpInsDataHora = obj42.gxTpr_Ngpinsdatahora;
         A455NgpInsData = obj42.gxTpr_Ngpinsdata;
         A456NgpInsHora = obj42.gxTpr_Ngpinshora;
         A458NgpInsUsuID = obj42.gxTpr_Ngpinsusuid;
         n458NgpInsUsuID = false;
         A459NgpInsUsuNome = obj42.gxTpr_Ngpinsusunome;
         n459NgpInsUsuNome = false;
         A579NgpDelDataHora = obj42.gxTpr_Ngpdeldatahora;
         n579NgpDelDataHora = false;
         A580NgpDelData = obj42.gxTpr_Ngpdeldata;
         n580NgpDelData = false;
         A581NgpDelHora = obj42.gxTpr_Ngpdelhora;
         n581NgpDelHora = false;
         A582NgpDelUsuId = obj42.gxTpr_Ngpdelusuid;
         n582NgpDelUsuId = false;
         A583NgpDelUsuNome = obj42.gxTpr_Ngpdelusunome;
         n583NgpDelUsuNome = false;
         A447NgpTotal = obj42.gxTpr_Ngptotal;
         A478NgpTppID = obj42.gxTpr_Ngptppid;
         A439NgpTppPrdID = obj42.gxTpr_Ngptppprdid;
         A440NgpTppPrdCodigo = obj42.gxTpr_Ngptppprdcodigo;
         A441NgpTppPrdNome = obj42.gxTpr_Ngptppprdnome;
         A442NgpTppPrdTipoID = obj42.gxTpr_Ngptppprdtipoid;
         A443NgpTppPrdAtivo = obj42.gxTpr_Ngptppprdativo;
         A444NgpTpp1Preco = obj42.gxTpr_Ngptpp1preco;
         A453NgpObs = obj42.gxTpr_Ngpobs;
         A578NgpDel = obj42.gxTpr_Ngpdel;
         A446NgpQtde = obj42.gxTpr_Ngpqtde;
         A445NgpPreco = obj42.gxTpr_Ngppreco;
         A435NgpItem = obj42.gxTpr_Ngpitem;
         Z435NgpItem = obj42.gxTpr_Ngpitem_Z;
         Z455NgpInsData = obj42.gxTpr_Ngpinsdata_Z;
         Z456NgpInsHora = obj42.gxTpr_Ngpinshora_Z;
         Z457NgpInsDataHora = obj42.gxTpr_Ngpinsdatahora_Z;
         Z458NgpInsUsuID = obj42.gxTpr_Ngpinsusuid_Z;
         Z459NgpInsUsuNome = obj42.gxTpr_Ngpinsusunome_Z;
         Z478NgpTppID = obj42.gxTpr_Ngptppid_Z;
         Z439NgpTppPrdID = obj42.gxTpr_Ngptppprdid_Z;
         Z440NgpTppPrdCodigo = obj42.gxTpr_Ngptppprdcodigo_Z;
         Z441NgpTppPrdNome = obj42.gxTpr_Ngptppprdnome_Z;
         Z442NgpTppPrdTipoID = obj42.gxTpr_Ngptppprdtipoid_Z;
         Z443NgpTppPrdAtivo = obj42.gxTpr_Ngptppprdativo_Z;
         Z444NgpTpp1Preco = obj42.gxTpr_Ngptpp1preco_Z;
         Z445NgpPreco = obj42.gxTpr_Ngppreco_Z;
         Z446NgpQtde = obj42.gxTpr_Ngpqtde_Z;
         Z447NgpTotal = obj42.gxTpr_Ngptotal_Z;
         O447NgpTotal = obj42.gxTpr_Ngptotal_Z;
         Z453NgpObs = obj42.gxTpr_Ngpobs_Z;
         Z578NgpDel = obj42.gxTpr_Ngpdel_Z;
         O578NgpDel = obj42.gxTpr_Ngpdel_Z;
         Z579NgpDelDataHora = obj42.gxTpr_Ngpdeldatahora_Z;
         Z580NgpDelData = obj42.gxTpr_Ngpdeldata_Z;
         Z581NgpDelHora = obj42.gxTpr_Ngpdelhora_Z;
         Z582NgpDelUsuId = obj42.gxTpr_Ngpdelusuid_Z;
         Z583NgpDelUsuNome = obj42.gxTpr_Ngpdelusunome_Z;
         n458NgpInsUsuID = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpinsusuid_N));
         n459NgpInsUsuNome = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpinsusunome_N));
         n579NgpDelDataHora = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpdeldatahora_N));
         n580NgpDelData = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpdeldata_N));
         n581NgpDelHora = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpdelhora_N));
         n582NgpDelUsuId = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpdelusuid_N));
         n583NgpDelUsuNome = (bool)(Convert.ToBoolean(obj42.gxTpr_Ngpdelusunome_N));
         nIsMod_42 = obj42.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A345NegID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1337( ) ;
         ScanKeyStart1337( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z345NegID = A345NegID;
            O454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            O386NegUltFase = A386NegUltFase;
            O572NegDel = A572NegDel;
         }
         ZM1337( -65) ;
         OnLoadActions1337( ) ;
         AddRow1337( ) ;
         bccore_NegocioPJEstrutura.gxTpr_Fase.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart1339( ) ;
            nGXsfl_39_idx = 1;
            while ( RcdFound39 != 0 )
            {
               O584NgfDel = A584NgfDel;
               Z345NegID = A345NegID;
               Z387NgfSeq = A387NgfSeq;
               ZM1339( -76) ;
               OnLoadActions1339( ) ;
               nRcdExists_39 = 1;
               nIsMod_39 = 0;
               Z584NgfDel = A584NgfDel;
               AddRow1339( ) ;
               nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
               ScanKeyNext1339( ) ;
            }
            ScanKeyEnd1339( ) ;
         }
         bccore_NegocioPJEstrutura.gxTpr_Item.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart1342( ) ;
            nGXsfl_42_idx = 1;
            while ( RcdFound42 != 0 )
            {
               O578NgpDel = A578NgpDel;
               O447NgpTotal = A447NgpTotal;
               Z345NegID = A345NegID;
               Z435NgpItem = A435NgpItem;
               ZM1342( -78) ;
               OnLoadActions1342( ) ;
               nRcdExists_42 = 1;
               nIsMod_42 = 0;
               Z578NgpDel = A578NgpDel;
               Z447NgpTotal = A447NgpTotal;
               AddRow1342( ) ;
               nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
               ScanKeyNext1342( ) ;
            }
            ScanKeyEnd1342( ) ;
         }
         ScanKeyEnd1337( ) ;
         if ( RcdFound37 == 0 )
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
         RowToVars37( bccore_NegocioPJEstrutura, 0) ;
         ScanKeyStart1337( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z345NegID = A345NegID;
            O454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            O386NegUltFase = A386NegUltFase;
            O572NegDel = A572NegDel;
         }
         ZM1337( -65) ;
         OnLoadActions1337( ) ;
         AddRow1337( ) ;
         bccore_NegocioPJEstrutura.gxTpr_Fase.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart1339( ) ;
            nGXsfl_39_idx = 1;
            while ( RcdFound39 != 0 )
            {
               O584NgfDel = A584NgfDel;
               Z345NegID = A345NegID;
               Z387NgfSeq = A387NgfSeq;
               ZM1339( -76) ;
               OnLoadActions1339( ) ;
               nRcdExists_39 = 1;
               nIsMod_39 = 0;
               Z584NgfDel = A584NgfDel;
               AddRow1339( ) ;
               nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
               ScanKeyNext1339( ) ;
            }
            ScanKeyEnd1339( ) ;
         }
         bccore_NegocioPJEstrutura.gxTpr_Item.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart1342( ) ;
            nGXsfl_42_idx = 1;
            while ( RcdFound42 != 0 )
            {
               O578NgpDel = A578NgpDel;
               O447NgpTotal = A447NgpTotal;
               Z345NegID = A345NegID;
               Z435NgpItem = A435NgpItem;
               ZM1342( -78) ;
               OnLoadActions1342( ) ;
               nRcdExists_42 = 1;
               nIsMod_42 = 0;
               Z578NgpDel = A578NgpDel;
               Z447NgpTotal = A447NgpTotal;
               AddRow1342( ) ;
               nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
               ScanKeyNext1342( ) ;
            }
            ScanKeyEnd1342( ) ;
         }
         ScanKeyEnd1337( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1337( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A386NegUltFase = O386NegUltFase;
            A454NegUltItem = O454NegUltItem;
            n454NegUltItem = false;
            A448NegPgpTotal = O448NegPgpTotal;
            n448NegPgpTotal = false;
            Insert1337( ) ;
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A345NegID != Z345NegID )
               {
                  A345NegID = Z345NegID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A386NegUltFase = O386NegUltFase;
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A386NegUltFase = O386NegUltFase;
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  Update1337( ) ;
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
                  if ( A345NegID != Z345NegID )
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
                        A386NegUltFase = O386NegUltFase;
                        A454NegUltItem = O454NegUltItem;
                        n454NegUltItem = false;
                        A448NegPgpTotal = O448NegPgpTotal;
                        n448NegPgpTotal = false;
                        Insert1337( ) ;
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
                        A386NegUltFase = O386NegUltFase;
                        A454NegUltItem = O454NegUltItem;
                        n454NegUltItem = false;
                        A448NegPgpTotal = O448NegPgpTotal;
                        n448NegPgpTotal = false;
                        Insert1337( ) ;
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
         RowToVars37( bccore_NegocioPJEstrutura, 1) ;
         SaveImpl( ) ;
         VarsToRow37( bccore_NegocioPJEstrutura) ;
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
         RowToVars37( bccore_NegocioPJEstrutura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A386NegUltFase = O386NegUltFase;
         A454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         A448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         Insert1337( ) ;
         AfterTrn( ) ;
         VarsToRow37( bccore_NegocioPJEstrutura) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow37( bccore_NegocioPJEstrutura) ;
         }
         else
         {
            GeneXus.Programs.core.SdtNegocioPJEstrutura auxBC = new GeneXus.Programs.core.SdtNegocioPJEstrutura(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A345NegID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_NegocioPJEstrutura);
               auxBC.Save();
               bccore_NegocioPJEstrutura.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars37( bccore_NegocioPJEstrutura, 1) ;
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
         RowToVars37( bccore_NegocioPJEstrutura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1337( ) ;
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
               VarsToRow37( bccore_NegocioPJEstrutura) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow37( bccore_NegocioPJEstrutura) ;
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
         RowToVars37( bccore_NegocioPJEstrutura, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1337( ) ;
         if ( RcdFound37 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A345NegID != Z345NegID )
            {
               A345NegID = Z345NegID;
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
            if ( A345NegID != Z345NegID )
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
         context.RollbackDataStores("core.negociopjestrutura_bc",pr_default);
         VarsToRow37( bccore_NegocioPJEstrutura) ;
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
         Gx_mode = bccore_NegocioPJEstrutura.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_NegocioPJEstrutura.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_NegocioPJEstrutura )
         {
            bccore_NegocioPJEstrutura = (GeneXus.Programs.core.SdtNegocioPJEstrutura)(sdt);
            if ( StringUtil.StrCmp(bccore_NegocioPJEstrutura.gxTpr_Mode, "") == 0 )
            {
               bccore_NegocioPJEstrutura.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow37( bccore_NegocioPJEstrutura) ;
            }
            else
            {
               RowToVars37( bccore_NegocioPJEstrutura, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_NegocioPJEstrutura.gxTpr_Mode, "") == 0 )
            {
               bccore_NegocioPJEstrutura.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars37( bccore_NegocioPJEstrutura, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtNegocioPJEstrutura NegocioPJEstrutura_BC
      {
         get {
            return bccore_NegocioPJEstrutura ;
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
         pr_default.close(51);
         pr_default.close(52);
         pr_default.close(5);
         pr_default.close(43);
         pr_default.close(12);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(32);
         pr_default.close(31);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z345NegID = Guid.Empty;
         A345NegID = Guid.Empty;
         sMode37 = "";
         BC001310_A474NegUltNgfSeq = new int[1] ;
         BC001310_n474NegUltNgfSeq = new bool[] {false} ;
         BC001313_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         BC001313_n420NegUltIteID = new bool[] {false} ;
         A420NegUltIteID = Guid.Empty;
         BC001316_A421NegUltIteNome = new string[] {""} ;
         BC001316_n421NegUltIteNome = new bool[] {false} ;
         A421NegUltIteNome = "";
         BC001319_A479NegUltIteOrdem = new short[1] ;
         BC001319_n479NegUltIteOrdem = new bool[] {false} ;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV30Pgmname = "";
         AV16TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_NegCliID = Guid.Empty;
         AV14Insert_NegCpjID = Guid.Empty;
         AV28AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         Z348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         Z346NegInsData = DateTime.MinValue;
         A346NegInsData = DateTime.MinValue;
         Z347NegInsHora = (DateTime)(DateTime.MinValue);
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         Z349NegInsUsuID = "";
         A349NegInsUsuID = "";
         Z364NegInsUsuNome = "";
         A364NegInsUsuNome = "";
         Z573NegDelDataHora = (DateTime)(DateTime.MinValue);
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         Z574NegDelData = (DateTime)(DateTime.MinValue);
         A574NegDelData = (DateTime)(DateTime.MinValue);
         Z575NegDelHora = (DateTime)(DateTime.MinValue);
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         Z576NegDelUsuId = "";
         A576NegDelUsuId = "";
         Z577NegDelUsuNome = "";
         A577NegDelUsuNome = "";
         Z360NegAgcID = "";
         A360NegAgcID = "";
         Z361NegAgcNome = "";
         A361NegAgcNome = "";
         Z362NegAssunto = "";
         A362NegAssunto = "";
         Z350NegCliID = Guid.Empty;
         A350NegCliID = Guid.Empty;
         Z352NegCpjID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         Z420NegUltIteID = Guid.Empty;
         Z421NegUltIteNome = "";
         Z351NegCliNomeFamiliar = "";
         A351NegCliNomeFamiliar = "";
         Z353NegCpjNomFan = "";
         A353NegCpjNomFan = "";
         Z354NegCpjRazSocial = "";
         A354NegCpjRazSocial = "";
         Z370NegCpjEndNome = "";
         A370NegCpjEndNome = "";
         Z371NegCpjEndEndereco = "";
         A371NegCpjEndEndereco = "";
         Z372NegCpjEndNumero = "";
         A372NegCpjEndNumero = "";
         Z373NegCpjEndComplem = "";
         A373NegCpjEndComplem = "";
         Z374NegCpjEndBairro = "";
         A374NegCpjEndBairro = "";
         Z376NegCpjEndMunNome = "";
         A376NegCpjEndMunNome = "";
         Z378NegCpjEndUFSigla = "";
         A378NegCpjEndUFSigla = "";
         Z379NegCpjEndUFNome = "";
         A379NegCpjEndUFNome = "";
         Z358NegPjtSigla = "";
         A358NegPjtSigla = "";
         Z359NegPjtNome = "";
         A359NegPjtNome = "";
         Z363NegDescricao = "";
         A363NegDescricao = "";
         BC001327_A448NegPgpTotal = new decimal[1] ;
         BC001327_n448NegPgpTotal = new bool[] {false} ;
         BC001329_A345NegID = new Guid[] {Guid.Empty} ;
         BC001329_A356NegCodigo = new long[1] ;
         BC001329_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001329_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC001329_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001329_A349NegInsUsuID = new string[] {""} ;
         BC001329_n349NegInsUsuID = new bool[] {false} ;
         BC001329_A364NegInsUsuNome = new string[] {""} ;
         BC001329_n364NegInsUsuNome = new bool[] {false} ;
         BC001329_A380NegValorEstimado = new decimal[1] ;
         BC001329_A385NegValorAtualizado = new decimal[1] ;
         BC001329_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001329_n573NegDelDataHora = new bool[] {false} ;
         BC001329_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC001329_n574NegDelData = new bool[] {false} ;
         BC001329_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001329_n575NegDelHora = new bool[] {false} ;
         BC001329_A576NegDelUsuId = new string[] {""} ;
         BC001329_n576NegDelUsuId = new bool[] {false} ;
         BC001329_A577NegDelUsuNome = new string[] {""} ;
         BC001329_n577NegDelUsuNome = new bool[] {false} ;
         BC001329_A473NegCliMatricula = new long[1] ;
         BC001329_A351NegCliNomeFamiliar = new string[] {""} ;
         BC001329_A353NegCpjNomFan = new string[] {""} ;
         BC001329_A354NegCpjRazSocial = new string[] {""} ;
         BC001329_A355NegCpjMatricula = new long[1] ;
         BC001329_A358NegPjtSigla = new string[] {""} ;
         BC001329_A359NegPjtNome = new string[] {""} ;
         BC001329_A370NegCpjEndNome = new string[] {""} ;
         BC001329_A371NegCpjEndEndereco = new string[] {""} ;
         BC001329_A372NegCpjEndNumero = new string[] {""} ;
         BC001329_A373NegCpjEndComplem = new string[] {""} ;
         BC001329_n373NegCpjEndComplem = new bool[] {false} ;
         BC001329_A374NegCpjEndBairro = new string[] {""} ;
         BC001329_A375NegCpjEndMunID = new int[1] ;
         BC001329_A376NegCpjEndMunNome = new string[] {""} ;
         BC001329_A377NegCpjEndUFID = new short[1] ;
         BC001329_A378NegCpjEndUFSigla = new string[] {""} ;
         BC001329_A379NegCpjEndUFNome = new string[] {""} ;
         BC001329_A360NegAgcID = new string[] {""} ;
         BC001329_n360NegAgcID = new bool[] {false} ;
         BC001329_A361NegAgcNome = new string[] {""} ;
         BC001329_n361NegAgcNome = new bool[] {false} ;
         BC001329_A362NegAssunto = new string[] {""} ;
         BC001329_A363NegDescricao = new string[] {""} ;
         BC001329_A386NegUltFase = new int[1] ;
         BC001329_A454NegUltItem = new int[1] ;
         BC001329_n454NegUltItem = new bool[] {false} ;
         BC001329_A572NegDel = new bool[] {false} ;
         BC001329_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC001329_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC001329_A369NegCpjEndSeq = new short[1] ;
         BC001329_A357NegPjtID = new int[1] ;
         BC001329_A448NegPgpTotal = new decimal[1] ;
         BC001329_n448NegPgpTotal = new bool[] {false} ;
         BC001330_A356NegCodigo = new long[1] ;
         BC001322_A473NegCliMatricula = new long[1] ;
         BC001322_A351NegCliNomeFamiliar = new string[] {""} ;
         BC001323_A353NegCpjNomFan = new string[] {""} ;
         BC001323_A354NegCpjRazSocial = new string[] {""} ;
         BC001323_A355NegCpjMatricula = new long[1] ;
         BC001323_A357NegPjtID = new int[1] ;
         BC001325_A358NegPjtSigla = new string[] {""} ;
         BC001325_A359NegPjtNome = new string[] {""} ;
         BC001324_A370NegCpjEndNome = new string[] {""} ;
         BC001324_A371NegCpjEndEndereco = new string[] {""} ;
         BC001324_A372NegCpjEndNumero = new string[] {""} ;
         BC001324_A373NegCpjEndComplem = new string[] {""} ;
         BC001324_n373NegCpjEndComplem = new bool[] {false} ;
         BC001324_A374NegCpjEndBairro = new string[] {""} ;
         BC001324_A375NegCpjEndMunID = new int[1] ;
         BC001324_A376NegCpjEndMunNome = new string[] {""} ;
         BC001324_A377NegCpjEndUFID = new short[1] ;
         BC001324_A378NegCpjEndUFSigla = new string[] {""} ;
         BC001324_A379NegCpjEndUFNome = new string[] {""} ;
         BC001331_A345NegID = new Guid[] {Guid.Empty} ;
         BC001321_A345NegID = new Guid[] {Guid.Empty} ;
         BC001321_A356NegCodigo = new long[1] ;
         BC001321_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001321_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC001321_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001321_A349NegInsUsuID = new string[] {""} ;
         BC001321_n349NegInsUsuID = new bool[] {false} ;
         BC001321_A364NegInsUsuNome = new string[] {""} ;
         BC001321_n364NegInsUsuNome = new bool[] {false} ;
         BC001321_A380NegValorEstimado = new decimal[1] ;
         BC001321_A385NegValorAtualizado = new decimal[1] ;
         BC001321_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001321_n573NegDelDataHora = new bool[] {false} ;
         BC001321_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC001321_n574NegDelData = new bool[] {false} ;
         BC001321_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001321_n575NegDelHora = new bool[] {false} ;
         BC001321_A576NegDelUsuId = new string[] {""} ;
         BC001321_n576NegDelUsuId = new bool[] {false} ;
         BC001321_A577NegDelUsuNome = new string[] {""} ;
         BC001321_n577NegDelUsuNome = new bool[] {false} ;
         BC001321_A360NegAgcID = new string[] {""} ;
         BC001321_n360NegAgcID = new bool[] {false} ;
         BC001321_A361NegAgcNome = new string[] {""} ;
         BC001321_n361NegAgcNome = new bool[] {false} ;
         BC001321_A362NegAssunto = new string[] {""} ;
         BC001321_A363NegDescricao = new string[] {""} ;
         BC001321_A386NegUltFase = new int[1] ;
         BC001321_A454NegUltItem = new int[1] ;
         BC001321_n454NegUltItem = new bool[] {false} ;
         BC001321_A572NegDel = new bool[] {false} ;
         BC001321_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC001321_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC001321_A369NegCpjEndSeq = new short[1] ;
         BC001321_A351NegCliNomeFamiliar = new string[] {""} ;
         BC001321_A353NegCpjNomFan = new string[] {""} ;
         BC001321_A354NegCpjRazSocial = new string[] {""} ;
         BC001321_A359NegPjtNome = new string[] {""} ;
         BC001320_A345NegID = new Guid[] {Guid.Empty} ;
         BC001320_A356NegCodigo = new long[1] ;
         BC001320_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001320_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC001320_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001320_A349NegInsUsuID = new string[] {""} ;
         BC001320_n349NegInsUsuID = new bool[] {false} ;
         BC001320_A364NegInsUsuNome = new string[] {""} ;
         BC001320_n364NegInsUsuNome = new bool[] {false} ;
         BC001320_A380NegValorEstimado = new decimal[1] ;
         BC001320_A385NegValorAtualizado = new decimal[1] ;
         BC001320_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001320_n573NegDelDataHora = new bool[] {false} ;
         BC001320_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC001320_n574NegDelData = new bool[] {false} ;
         BC001320_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001320_n575NegDelHora = new bool[] {false} ;
         BC001320_A576NegDelUsuId = new string[] {""} ;
         BC001320_n576NegDelUsuId = new bool[] {false} ;
         BC001320_A577NegDelUsuNome = new string[] {""} ;
         BC001320_n577NegDelUsuNome = new bool[] {false} ;
         BC001320_A360NegAgcID = new string[] {""} ;
         BC001320_n360NegAgcID = new bool[] {false} ;
         BC001320_A361NegAgcNome = new string[] {""} ;
         BC001320_n361NegAgcNome = new bool[] {false} ;
         BC001320_A362NegAssunto = new string[] {""} ;
         BC001320_A363NegDescricao = new string[] {""} ;
         BC001320_A386NegUltFase = new int[1] ;
         BC001320_A454NegUltItem = new int[1] ;
         BC001320_n454NegUltItem = new bool[] {false} ;
         BC001320_A572NegDel = new bool[] {false} ;
         BC001320_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC001320_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC001320_A369NegCpjEndSeq = new short[1] ;
         BC001320_A351NegCliNomeFamiliar = new string[] {""} ;
         BC001320_A353NegCpjNomFan = new string[] {""} ;
         BC001320_A354NegCpjRazSocial = new string[] {""} ;
         BC001320_A359NegPjtNome = new string[] {""} ;
         BC001336_A474NegUltNgfSeq = new int[1] ;
         BC001336_n474NegUltNgfSeq = new bool[] {false} ;
         BC001339_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         BC001339_n420NegUltIteID = new bool[] {false} ;
         BC001342_A421NegUltIteNome = new string[] {""} ;
         BC001342_n421NegUltIteNome = new bool[] {false} ;
         BC001345_A479NegUltIteOrdem = new short[1] ;
         BC001345_n479NegUltIteOrdem = new bool[] {false} ;
         BC001347_A448NegPgpTotal = new decimal[1] ;
         BC001347_n448NegPgpTotal = new bool[] {false} ;
         BC001348_A473NegCliMatricula = new long[1] ;
         BC001348_A351NegCliNomeFamiliar = new string[] {""} ;
         BC001349_A353NegCpjNomFan = new string[] {""} ;
         BC001349_A354NegCpjRazSocial = new string[] {""} ;
         BC001349_A355NegCpjMatricula = new long[1] ;
         BC001349_A357NegPjtID = new int[1] ;
         BC001350_A358NegPjtSigla = new string[] {""} ;
         BC001350_A359NegPjtNome = new string[] {""} ;
         BC001351_A370NegCpjEndNome = new string[] {""} ;
         BC001351_A371NegCpjEndEndereco = new string[] {""} ;
         BC001351_A372NegCpjEndNumero = new string[] {""} ;
         BC001351_A373NegCpjEndComplem = new string[] {""} ;
         BC001351_n373NegCpjEndComplem = new bool[] {false} ;
         BC001351_A374NegCpjEndBairro = new string[] {""} ;
         BC001351_A375NegCpjEndMunID = new int[1] ;
         BC001351_A376NegCpjEndMunNome = new string[] {""} ;
         BC001351_A377NegCpjEndUFID = new short[1] ;
         BC001351_A378NegCpjEndUFSigla = new string[] {""} ;
         BC001351_A379NegCpjEndUFNome = new string[] {""} ;
         BC001352_A398VisID = new Guid[] {Guid.Empty} ;
         BC001353_A345NegID = new Guid[] {Guid.Empty} ;
         BC001353_A626NefChave = new string[] {""} ;
         BC001354_A398VisID = new Guid[] {Guid.Empty} ;
         BC001357_A345NegID = new Guid[] {Guid.Empty} ;
         BC001357_A356NegCodigo = new long[1] ;
         BC001357_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001357_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC001357_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001357_A349NegInsUsuID = new string[] {""} ;
         BC001357_n349NegInsUsuID = new bool[] {false} ;
         BC001357_A364NegInsUsuNome = new string[] {""} ;
         BC001357_n364NegInsUsuNome = new bool[] {false} ;
         BC001357_A380NegValorEstimado = new decimal[1] ;
         BC001357_A385NegValorAtualizado = new decimal[1] ;
         BC001357_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001357_n573NegDelDataHora = new bool[] {false} ;
         BC001357_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC001357_n574NegDelData = new bool[] {false} ;
         BC001357_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001357_n575NegDelHora = new bool[] {false} ;
         BC001357_A576NegDelUsuId = new string[] {""} ;
         BC001357_n576NegDelUsuId = new bool[] {false} ;
         BC001357_A577NegDelUsuNome = new string[] {""} ;
         BC001357_n577NegDelUsuNome = new bool[] {false} ;
         BC001357_A473NegCliMatricula = new long[1] ;
         BC001357_A351NegCliNomeFamiliar = new string[] {""} ;
         BC001357_A353NegCpjNomFan = new string[] {""} ;
         BC001357_A354NegCpjRazSocial = new string[] {""} ;
         BC001357_A355NegCpjMatricula = new long[1] ;
         BC001357_A358NegPjtSigla = new string[] {""} ;
         BC001357_A359NegPjtNome = new string[] {""} ;
         BC001357_A370NegCpjEndNome = new string[] {""} ;
         BC001357_A371NegCpjEndEndereco = new string[] {""} ;
         BC001357_A372NegCpjEndNumero = new string[] {""} ;
         BC001357_A373NegCpjEndComplem = new string[] {""} ;
         BC001357_n373NegCpjEndComplem = new bool[] {false} ;
         BC001357_A374NegCpjEndBairro = new string[] {""} ;
         BC001357_A375NegCpjEndMunID = new int[1] ;
         BC001357_A376NegCpjEndMunNome = new string[] {""} ;
         BC001357_A377NegCpjEndUFID = new short[1] ;
         BC001357_A378NegCpjEndUFSigla = new string[] {""} ;
         BC001357_A379NegCpjEndUFNome = new string[] {""} ;
         BC001357_A360NegAgcID = new string[] {""} ;
         BC001357_n360NegAgcID = new bool[] {false} ;
         BC001357_A361NegAgcNome = new string[] {""} ;
         BC001357_n361NegAgcNome = new bool[] {false} ;
         BC001357_A362NegAssunto = new string[] {""} ;
         BC001357_A363NegDescricao = new string[] {""} ;
         BC001357_A386NegUltFase = new int[1] ;
         BC001357_A454NegUltItem = new int[1] ;
         BC001357_n454NegUltItem = new bool[] {false} ;
         BC001357_A572NegDel = new bool[] {false} ;
         BC001357_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC001357_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC001357_A369NegCpjEndSeq = new short[1] ;
         BC001357_A357NegPjtID = new int[1] ;
         BC001357_A448NegPgpTotal = new decimal[1] ;
         BC001357_n448NegPgpTotal = new bool[] {false} ;
         Z390NgfInsDataHora = (DateTime)(DateTime.MinValue);
         A390NgfInsDataHora = (DateTime)(DateTime.MinValue);
         Z388NgfInsData = DateTime.MinValue;
         A388NgfInsData = DateTime.MinValue;
         Z389NgfInsHora = (DateTime)(DateTime.MinValue);
         A389NgfInsHora = (DateTime)(DateTime.MinValue);
         Z391NgfInsUsuID = "";
         A391NgfInsUsuID = "";
         Z392NgfInsUsuNome = "";
         A392NgfInsUsuNome = "";
         Z585NgfDelDataHora = (DateTime)(DateTime.MinValue);
         A585NgfDelDataHora = (DateTime)(DateTime.MinValue);
         Z586NgfDelData = (DateTime)(DateTime.MinValue);
         A586NgfDelData = (DateTime)(DateTime.MinValue);
         Z587NgfDelHora = (DateTime)(DateTime.MinValue);
         A587NgfDelHora = (DateTime)(DateTime.MinValue);
         Z588NgfDelUsuId = "";
         A588NgfDelUsuId = "";
         Z589NgfDelUsuNome = "";
         A589NgfDelUsuNome = "";
         Z425NgfFimData = DateTime.MinValue;
         A425NgfFimData = DateTime.MinValue;
         Z426NgfFimHora = (DateTime)(DateTime.MinValue);
         A426NgfFimHora = (DateTime)(DateTime.MinValue);
         Z427NgfFimDataHora = (DateTime)(DateTime.MinValue);
         A427NgfFimDataHora = (DateTime)(DateTime.MinValue);
         Z428NgfFimUsuID = "";
         A428NgfFimUsuID = "";
         Z429NgfFimUsuNome = "";
         A429NgfFimUsuNome = "";
         Z430NgfStatus = "";
         A430NgfStatus = "";
         Z395NgfIteID = Guid.Empty;
         A395NgfIteID = Guid.Empty;
         Z397NgfIteNome = "";
         A397NgfIteNome = "";
         BC001358_A345NegID = new Guid[] {Guid.Empty} ;
         BC001358_A387NgfSeq = new int[1] ;
         BC001358_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001358_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         BC001358_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001358_A391NgfInsUsuID = new string[] {""} ;
         BC001358_n391NgfInsUsuID = new bool[] {false} ;
         BC001358_A392NgfInsUsuNome = new string[] {""} ;
         BC001358_n392NgfInsUsuNome = new bool[] {false} ;
         BC001358_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001358_n585NgfDelDataHora = new bool[] {false} ;
         BC001358_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         BC001358_n586NgfDelData = new bool[] {false} ;
         BC001358_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001358_n587NgfDelHora = new bool[] {false} ;
         BC001358_A588NgfDelUsuId = new string[] {""} ;
         BC001358_n588NgfDelUsuId = new bool[] {false} ;
         BC001358_A589NgfDelUsuNome = new string[] {""} ;
         BC001358_n589NgfDelUsuNome = new bool[] {false} ;
         BC001358_A396NgfIteOrdem = new int[1] ;
         BC001358_A397NgfIteNome = new string[] {""} ;
         BC001358_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         BC001358_n425NgfFimData = new bool[] {false} ;
         BC001358_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         BC001358_n426NgfFimHora = new bool[] {false} ;
         BC001358_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001358_n427NgfFimDataHora = new bool[] {false} ;
         BC001358_A428NgfFimUsuID = new string[] {""} ;
         BC001358_n428NgfFimUsuID = new bool[] {false} ;
         BC001358_A429NgfFimUsuNome = new string[] {""} ;
         BC001358_n429NgfFimUsuNome = new bool[] {false} ;
         BC001358_A430NgfStatus = new string[] {""} ;
         BC001358_n430NgfStatus = new bool[] {false} ;
         BC001358_A584NgfDel = new bool[] {false} ;
         BC001358_A395NgfIteID = new Guid[] {Guid.Empty} ;
         BC00138_A396NgfIteOrdem = new int[1] ;
         BC00138_A397NgfIteNome = new string[] {""} ;
         BC001359_A345NegID = new Guid[] {Guid.Empty} ;
         BC001359_A387NgfSeq = new int[1] ;
         BC00137_A345NegID = new Guid[] {Guid.Empty} ;
         BC00137_A387NgfSeq = new int[1] ;
         BC00137_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00137_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         BC00137_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00137_A391NgfInsUsuID = new string[] {""} ;
         BC00137_n391NgfInsUsuID = new bool[] {false} ;
         BC00137_A392NgfInsUsuNome = new string[] {""} ;
         BC00137_n392NgfInsUsuNome = new bool[] {false} ;
         BC00137_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00137_n585NgfDelDataHora = new bool[] {false} ;
         BC00137_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         BC00137_n586NgfDelData = new bool[] {false} ;
         BC00137_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00137_n587NgfDelHora = new bool[] {false} ;
         BC00137_A588NgfDelUsuId = new string[] {""} ;
         BC00137_n588NgfDelUsuId = new bool[] {false} ;
         BC00137_A589NgfDelUsuNome = new string[] {""} ;
         BC00137_n589NgfDelUsuNome = new bool[] {false} ;
         BC00137_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         BC00137_n425NgfFimData = new bool[] {false} ;
         BC00137_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         BC00137_n426NgfFimHora = new bool[] {false} ;
         BC00137_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00137_n427NgfFimDataHora = new bool[] {false} ;
         BC00137_A428NgfFimUsuID = new string[] {""} ;
         BC00137_n428NgfFimUsuID = new bool[] {false} ;
         BC00137_A429NgfFimUsuNome = new string[] {""} ;
         BC00137_n429NgfFimUsuNome = new bool[] {false} ;
         BC00137_A430NgfStatus = new string[] {""} ;
         BC00137_n430NgfStatus = new bool[] {false} ;
         BC00137_A584NgfDel = new bool[] {false} ;
         BC00137_A395NgfIteID = new Guid[] {Guid.Empty} ;
         BC00137_A397NgfIteNome = new string[] {""} ;
         sMode39 = "";
         BC00136_A345NegID = new Guid[] {Guid.Empty} ;
         BC00136_A387NgfSeq = new int[1] ;
         BC00136_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00136_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         BC00136_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00136_A391NgfInsUsuID = new string[] {""} ;
         BC00136_n391NgfInsUsuID = new bool[] {false} ;
         BC00136_A392NgfInsUsuNome = new string[] {""} ;
         BC00136_n392NgfInsUsuNome = new bool[] {false} ;
         BC00136_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00136_n585NgfDelDataHora = new bool[] {false} ;
         BC00136_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         BC00136_n586NgfDelData = new bool[] {false} ;
         BC00136_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00136_n587NgfDelHora = new bool[] {false} ;
         BC00136_A588NgfDelUsuId = new string[] {""} ;
         BC00136_n588NgfDelUsuId = new bool[] {false} ;
         BC00136_A589NgfDelUsuNome = new string[] {""} ;
         BC00136_n589NgfDelUsuNome = new bool[] {false} ;
         BC00136_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         BC00136_n425NgfFimData = new bool[] {false} ;
         BC00136_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         BC00136_n426NgfFimHora = new bool[] {false} ;
         BC00136_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00136_n427NgfFimDataHora = new bool[] {false} ;
         BC00136_A428NgfFimUsuID = new string[] {""} ;
         BC00136_n428NgfFimUsuID = new bool[] {false} ;
         BC00136_A429NgfFimUsuNome = new string[] {""} ;
         BC00136_n429NgfFimUsuNome = new bool[] {false} ;
         BC00136_A430NgfStatus = new string[] {""} ;
         BC00136_n430NgfStatus = new bool[] {false} ;
         BC00136_A584NgfDel = new bool[] {false} ;
         BC00136_A395NgfIteID = new Guid[] {Guid.Empty} ;
         BC00136_A397NgfIteNome = new string[] {""} ;
         BC001363_A396NgfIteOrdem = new int[1] ;
         BC001363_A397NgfIteNome = new string[] {""} ;
         BC001364_A398VisID = new Guid[] {Guid.Empty} ;
         BC001365_A345NegID = new Guid[] {Guid.Empty} ;
         BC001365_A387NgfSeq = new int[1] ;
         BC001365_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001365_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         BC001365_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001365_A391NgfInsUsuID = new string[] {""} ;
         BC001365_n391NgfInsUsuID = new bool[] {false} ;
         BC001365_A392NgfInsUsuNome = new string[] {""} ;
         BC001365_n392NgfInsUsuNome = new bool[] {false} ;
         BC001365_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001365_n585NgfDelDataHora = new bool[] {false} ;
         BC001365_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         BC001365_n586NgfDelData = new bool[] {false} ;
         BC001365_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001365_n587NgfDelHora = new bool[] {false} ;
         BC001365_A588NgfDelUsuId = new string[] {""} ;
         BC001365_n588NgfDelUsuId = new bool[] {false} ;
         BC001365_A589NgfDelUsuNome = new string[] {""} ;
         BC001365_n589NgfDelUsuNome = new bool[] {false} ;
         BC001365_A396NgfIteOrdem = new int[1] ;
         BC001365_A397NgfIteNome = new string[] {""} ;
         BC001365_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         BC001365_n425NgfFimData = new bool[] {false} ;
         BC001365_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         BC001365_n426NgfFimHora = new bool[] {false} ;
         BC001365_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001365_n427NgfFimDataHora = new bool[] {false} ;
         BC001365_A428NgfFimUsuID = new string[] {""} ;
         BC001365_n428NgfFimUsuID = new bool[] {false} ;
         BC001365_A429NgfFimUsuNome = new string[] {""} ;
         BC001365_n429NgfFimUsuNome = new bool[] {false} ;
         BC001365_A430NgfStatus = new string[] {""} ;
         BC001365_n430NgfStatus = new bool[] {false} ;
         BC001365_A584NgfDel = new bool[] {false} ;
         BC001365_A395NgfIteID = new Guid[] {Guid.Empty} ;
         Z457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         Z455NgpInsData = DateTime.MinValue;
         A455NgpInsData = DateTime.MinValue;
         Z456NgpInsHora = (DateTime)(DateTime.MinValue);
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         Z458NgpInsUsuID = "";
         A458NgpInsUsuID = "";
         Z459NgpInsUsuNome = "";
         A459NgpInsUsuNome = "";
         Z579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         A579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         Z580NgpDelData = (DateTime)(DateTime.MinValue);
         A580NgpDelData = (DateTime)(DateTime.MinValue);
         Z581NgpDelHora = (DateTime)(DateTime.MinValue);
         A581NgpDelHora = (DateTime)(DateTime.MinValue);
         Z582NgpDelUsuId = "";
         A582NgpDelUsuId = "";
         Z583NgpDelUsuNome = "";
         A583NgpDelUsuNome = "";
         Z453NgpObs = "";
         A453NgpObs = "";
         Z439NgpTppPrdID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         Z478NgpTppID = Guid.Empty;
         A478NgpTppID = Guid.Empty;
         Z440NgpTppPrdCodigo = "";
         A440NgpTppPrdCodigo = "";
         Z441NgpTppPrdNome = "";
         A441NgpTppPrdNome = "";
         BC001366_A447NgpTotal = new decimal[1] ;
         BC001366_A345NegID = new Guid[] {Guid.Empty} ;
         BC001366_A435NgpItem = new int[1] ;
         BC001366_A446NgpQtde = new int[1] ;
         BC001366_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001366_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC001366_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001366_A458NgpInsUsuID = new string[] {""} ;
         BC001366_n458NgpInsUsuID = new bool[] {false} ;
         BC001366_A459NgpInsUsuNome = new string[] {""} ;
         BC001366_n459NgpInsUsuNome = new bool[] {false} ;
         BC001366_A445NgpPreco = new decimal[1] ;
         BC001366_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001366_n579NgpDelDataHora = new bool[] {false} ;
         BC001366_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC001366_n580NgpDelData = new bool[] {false} ;
         BC001366_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001366_n581NgpDelHora = new bool[] {false} ;
         BC001366_A582NgpDelUsuId = new string[] {""} ;
         BC001366_n582NgpDelUsuId = new bool[] {false} ;
         BC001366_A583NgpDelUsuNome = new string[] {""} ;
         BC001366_n583NgpDelUsuNome = new bool[] {false} ;
         BC001366_A440NgpTppPrdCodigo = new string[] {""} ;
         BC001366_A441NgpTppPrdNome = new string[] {""} ;
         BC001366_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC001366_A444NgpTpp1Preco = new decimal[1] ;
         BC001366_A453NgpObs = new string[] {""} ;
         BC001366_A578NgpDel = new bool[] {false} ;
         BC001366_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC001366_A478NgpTppID = new Guid[] {Guid.Empty} ;
         BC001366_A442NgpTppPrdTipoID = new int[1] ;
         BC00135_A444NgpTpp1Preco = new decimal[1] ;
         BC00134_A440NgpTppPrdCodigo = new string[] {""} ;
         BC00134_A441NgpTppPrdNome = new string[] {""} ;
         BC00134_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC00134_A442NgpTppPrdTipoID = new int[1] ;
         BC001367_A345NegID = new Guid[] {Guid.Empty} ;
         BC001367_A435NgpItem = new int[1] ;
         BC00133_A447NgpTotal = new decimal[1] ;
         BC00133_A345NegID = new Guid[] {Guid.Empty} ;
         BC00133_A435NgpItem = new int[1] ;
         BC00133_A446NgpQtde = new int[1] ;
         BC00133_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00133_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC00133_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00133_A458NgpInsUsuID = new string[] {""} ;
         BC00133_n458NgpInsUsuID = new bool[] {false} ;
         BC00133_A459NgpInsUsuNome = new string[] {""} ;
         BC00133_n459NgpInsUsuNome = new bool[] {false} ;
         BC00133_A445NgpPreco = new decimal[1] ;
         BC00133_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00133_n579NgpDelDataHora = new bool[] {false} ;
         BC00133_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC00133_n580NgpDelData = new bool[] {false} ;
         BC00133_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00133_n581NgpDelHora = new bool[] {false} ;
         BC00133_A582NgpDelUsuId = new string[] {""} ;
         BC00133_n582NgpDelUsuId = new bool[] {false} ;
         BC00133_A583NgpDelUsuNome = new string[] {""} ;
         BC00133_n583NgpDelUsuNome = new bool[] {false} ;
         BC00133_A453NgpObs = new string[] {""} ;
         BC00133_A578NgpDel = new bool[] {false} ;
         BC00133_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC00133_A478NgpTppID = new Guid[] {Guid.Empty} ;
         sMode42 = "";
         BC00132_A447NgpTotal = new decimal[1] ;
         BC00132_A345NegID = new Guid[] {Guid.Empty} ;
         BC00132_A435NgpItem = new int[1] ;
         BC00132_A446NgpQtde = new int[1] ;
         BC00132_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00132_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC00132_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00132_A458NgpInsUsuID = new string[] {""} ;
         BC00132_n458NgpInsUsuID = new bool[] {false} ;
         BC00132_A459NgpInsUsuNome = new string[] {""} ;
         BC00132_n459NgpInsUsuNome = new bool[] {false} ;
         BC00132_A445NgpPreco = new decimal[1] ;
         BC00132_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00132_n579NgpDelDataHora = new bool[] {false} ;
         BC00132_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC00132_n580NgpDelData = new bool[] {false} ;
         BC00132_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00132_n581NgpDelHora = new bool[] {false} ;
         BC00132_A582NgpDelUsuId = new string[] {""} ;
         BC00132_n582NgpDelUsuId = new bool[] {false} ;
         BC00132_A583NgpDelUsuNome = new string[] {""} ;
         BC00132_n583NgpDelUsuNome = new bool[] {false} ;
         BC00132_A453NgpObs = new string[] {""} ;
         BC00132_A578NgpDel = new bool[] {false} ;
         BC00132_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC00132_A478NgpTppID = new Guid[] {Guid.Empty} ;
         BC001371_A440NgpTppPrdCodigo = new string[] {""} ;
         BC001371_A441NgpTppPrdNome = new string[] {""} ;
         BC001371_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC001371_A442NgpTppPrdTipoID = new int[1] ;
         BC001372_A444NgpTpp1Preco = new decimal[1] ;
         BC001373_A447NgpTotal = new decimal[1] ;
         BC001373_A345NegID = new Guid[] {Guid.Empty} ;
         BC001373_A435NgpItem = new int[1] ;
         BC001373_A446NgpQtde = new int[1] ;
         BC001373_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001373_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC001373_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001373_A458NgpInsUsuID = new string[] {""} ;
         BC001373_n458NgpInsUsuID = new bool[] {false} ;
         BC001373_A459NgpInsUsuNome = new string[] {""} ;
         BC001373_n459NgpInsUsuNome = new bool[] {false} ;
         BC001373_A445NgpPreco = new decimal[1] ;
         BC001373_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001373_n579NgpDelDataHora = new bool[] {false} ;
         BC001373_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC001373_n580NgpDelData = new bool[] {false} ;
         BC001373_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001373_n581NgpDelHora = new bool[] {false} ;
         BC001373_A582NgpDelUsuId = new string[] {""} ;
         BC001373_n582NgpDelUsuId = new bool[] {false} ;
         BC001373_A583NgpDelUsuNome = new string[] {""} ;
         BC001373_n583NgpDelUsuNome = new bool[] {false} ;
         BC001373_A440NgpTppPrdCodigo = new string[] {""} ;
         BC001373_A441NgpTppPrdNome = new string[] {""} ;
         BC001373_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC001373_A444NgpTpp1Preco = new decimal[1] ;
         BC001373_A453NgpObs = new string[] {""} ;
         BC001373_A578NgpDel = new bool[] {false} ;
         BC001373_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC001373_A478NgpTppID = new Guid[] {Guid.Empty} ;
         BC001373_A442NgpTppPrdTipoID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjestrutura_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjestrutura_bc__default(),
            new Object[][] {
                new Object[] {
               BC00132_A447NgpTotal, BC00132_A345NegID, BC00132_A435NgpItem, BC00132_A446NgpQtde, BC00132_A457NgpInsDataHora, BC00132_A455NgpInsData, BC00132_A456NgpInsHora, BC00132_A458NgpInsUsuID, BC00132_n458NgpInsUsuID, BC00132_A459NgpInsUsuNome,
               BC00132_n459NgpInsUsuNome, BC00132_A445NgpPreco, BC00132_A579NgpDelDataHora, BC00132_n579NgpDelDataHora, BC00132_A580NgpDelData, BC00132_n580NgpDelData, BC00132_A581NgpDelHora, BC00132_n581NgpDelHora, BC00132_A582NgpDelUsuId, BC00132_n582NgpDelUsuId,
               BC00132_A583NgpDelUsuNome, BC00132_n583NgpDelUsuNome, BC00132_A453NgpObs, BC00132_A578NgpDel, BC00132_A439NgpTppPrdID, BC00132_A478NgpTppID
               }
               , new Object[] {
               BC00133_A447NgpTotal, BC00133_A345NegID, BC00133_A435NgpItem, BC00133_A446NgpQtde, BC00133_A457NgpInsDataHora, BC00133_A455NgpInsData, BC00133_A456NgpInsHora, BC00133_A458NgpInsUsuID, BC00133_n458NgpInsUsuID, BC00133_A459NgpInsUsuNome,
               BC00133_n459NgpInsUsuNome, BC00133_A445NgpPreco, BC00133_A579NgpDelDataHora, BC00133_n579NgpDelDataHora, BC00133_A580NgpDelData, BC00133_n580NgpDelData, BC00133_A581NgpDelHora, BC00133_n581NgpDelHora, BC00133_A582NgpDelUsuId, BC00133_n582NgpDelUsuId,
               BC00133_A583NgpDelUsuNome, BC00133_n583NgpDelUsuNome, BC00133_A453NgpObs, BC00133_A578NgpDel, BC00133_A439NgpTppPrdID, BC00133_A478NgpTppID
               }
               , new Object[] {
               BC00134_A440NgpTppPrdCodigo, BC00134_A441NgpTppPrdNome, BC00134_A443NgpTppPrdAtivo, BC00134_A442NgpTppPrdTipoID
               }
               , new Object[] {
               BC00135_A444NgpTpp1Preco
               }
               , new Object[] {
               BC00136_A345NegID, BC00136_A387NgfSeq, BC00136_A390NgfInsDataHora, BC00136_A388NgfInsData, BC00136_A389NgfInsHora, BC00136_A391NgfInsUsuID, BC00136_n391NgfInsUsuID, BC00136_A392NgfInsUsuNome, BC00136_n392NgfInsUsuNome, BC00136_A585NgfDelDataHora,
               BC00136_n585NgfDelDataHora, BC00136_A586NgfDelData, BC00136_n586NgfDelData, BC00136_A587NgfDelHora, BC00136_n587NgfDelHora, BC00136_A588NgfDelUsuId, BC00136_n588NgfDelUsuId, BC00136_A589NgfDelUsuNome, BC00136_n589NgfDelUsuNome, BC00136_A425NgfFimData,
               BC00136_n425NgfFimData, BC00136_A426NgfFimHora, BC00136_n426NgfFimHora, BC00136_A427NgfFimDataHora, BC00136_n427NgfFimDataHora, BC00136_A428NgfFimUsuID, BC00136_n428NgfFimUsuID, BC00136_A429NgfFimUsuNome, BC00136_n429NgfFimUsuNome, BC00136_A430NgfStatus,
               BC00136_n430NgfStatus, BC00136_A584NgfDel, BC00136_A395NgfIteID, BC00136_A397NgfIteNome
               }
               , new Object[] {
               BC00137_A345NegID, BC00137_A387NgfSeq, BC00137_A390NgfInsDataHora, BC00137_A388NgfInsData, BC00137_A389NgfInsHora, BC00137_A391NgfInsUsuID, BC00137_n391NgfInsUsuID, BC00137_A392NgfInsUsuNome, BC00137_n392NgfInsUsuNome, BC00137_A585NgfDelDataHora,
               BC00137_n585NgfDelDataHora, BC00137_A586NgfDelData, BC00137_n586NgfDelData, BC00137_A587NgfDelHora, BC00137_n587NgfDelHora, BC00137_A588NgfDelUsuId, BC00137_n588NgfDelUsuId, BC00137_A589NgfDelUsuNome, BC00137_n589NgfDelUsuNome, BC00137_A425NgfFimData,
               BC00137_n425NgfFimData, BC00137_A426NgfFimHora, BC00137_n426NgfFimHora, BC00137_A427NgfFimDataHora, BC00137_n427NgfFimDataHora, BC00137_A428NgfFimUsuID, BC00137_n428NgfFimUsuID, BC00137_A429NgfFimUsuNome, BC00137_n429NgfFimUsuNome, BC00137_A430NgfStatus,
               BC00137_n430NgfStatus, BC00137_A584NgfDel, BC00137_A395NgfIteID, BC00137_A397NgfIteNome
               }
               , new Object[] {
               BC00138_A396NgfIteOrdem, BC00138_A397NgfIteNome
               }
               , new Object[] {
               BC001310_A474NegUltNgfSeq, BC001310_n474NegUltNgfSeq
               }
               , new Object[] {
               BC001313_A420NegUltIteID, BC001313_n420NegUltIteID
               }
               , new Object[] {
               BC001316_A421NegUltIteNome, BC001316_n421NegUltIteNome
               }
               , new Object[] {
               BC001319_A479NegUltIteOrdem, BC001319_n479NegUltIteOrdem
               }
               , new Object[] {
               BC001320_A345NegID, BC001320_A356NegCodigo, BC001320_A348NegInsDataHora, BC001320_A346NegInsData, BC001320_A347NegInsHora, BC001320_A349NegInsUsuID, BC001320_n349NegInsUsuID, BC001320_A364NegInsUsuNome, BC001320_n364NegInsUsuNome, BC001320_A380NegValorEstimado,
               BC001320_A385NegValorAtualizado, BC001320_A573NegDelDataHora, BC001320_n573NegDelDataHora, BC001320_A574NegDelData, BC001320_n574NegDelData, BC001320_A575NegDelHora, BC001320_n575NegDelHora, BC001320_A576NegDelUsuId, BC001320_n576NegDelUsuId, BC001320_A577NegDelUsuNome,
               BC001320_n577NegDelUsuNome, BC001320_A360NegAgcID, BC001320_n360NegAgcID, BC001320_A361NegAgcNome, BC001320_n361NegAgcNome, BC001320_A362NegAssunto, BC001320_A363NegDescricao, BC001320_A386NegUltFase, BC001320_A454NegUltItem, BC001320_n454NegUltItem,
               BC001320_A572NegDel, BC001320_A350NegCliID, BC001320_A352NegCpjID, BC001320_A369NegCpjEndSeq, BC001320_A351NegCliNomeFamiliar, BC001320_A353NegCpjNomFan, BC001320_A354NegCpjRazSocial, BC001320_A359NegPjtNome
               }
               , new Object[] {
               BC001321_A345NegID, BC001321_A356NegCodigo, BC001321_A348NegInsDataHora, BC001321_A346NegInsData, BC001321_A347NegInsHora, BC001321_A349NegInsUsuID, BC001321_n349NegInsUsuID, BC001321_A364NegInsUsuNome, BC001321_n364NegInsUsuNome, BC001321_A380NegValorEstimado,
               BC001321_A385NegValorAtualizado, BC001321_A573NegDelDataHora, BC001321_n573NegDelDataHora, BC001321_A574NegDelData, BC001321_n574NegDelData, BC001321_A575NegDelHora, BC001321_n575NegDelHora, BC001321_A576NegDelUsuId, BC001321_n576NegDelUsuId, BC001321_A577NegDelUsuNome,
               BC001321_n577NegDelUsuNome, BC001321_A360NegAgcID, BC001321_n360NegAgcID, BC001321_A361NegAgcNome, BC001321_n361NegAgcNome, BC001321_A362NegAssunto, BC001321_A363NegDescricao, BC001321_A386NegUltFase, BC001321_A454NegUltItem, BC001321_n454NegUltItem,
               BC001321_A572NegDel, BC001321_A350NegCliID, BC001321_A352NegCpjID, BC001321_A369NegCpjEndSeq, BC001321_A351NegCliNomeFamiliar, BC001321_A353NegCpjNomFan, BC001321_A354NegCpjRazSocial, BC001321_A359NegPjtNome
               }
               , new Object[] {
               BC001322_A473NegCliMatricula, BC001322_A351NegCliNomeFamiliar
               }
               , new Object[] {
               BC001323_A353NegCpjNomFan, BC001323_A354NegCpjRazSocial, BC001323_A355NegCpjMatricula, BC001323_A357NegPjtID
               }
               , new Object[] {
               BC001324_A370NegCpjEndNome, BC001324_A371NegCpjEndEndereco, BC001324_A372NegCpjEndNumero, BC001324_A373NegCpjEndComplem, BC001324_n373NegCpjEndComplem, BC001324_A374NegCpjEndBairro, BC001324_A375NegCpjEndMunID, BC001324_A376NegCpjEndMunNome, BC001324_A377NegCpjEndUFID, BC001324_A378NegCpjEndUFSigla,
               BC001324_A379NegCpjEndUFNome
               }
               , new Object[] {
               BC001325_A358NegPjtSigla, BC001325_A359NegPjtNome
               }
               , new Object[] {
               BC001327_A448NegPgpTotal, BC001327_n448NegPgpTotal
               }
               , new Object[] {
               BC001329_A345NegID, BC001329_A356NegCodigo, BC001329_A348NegInsDataHora, BC001329_A346NegInsData, BC001329_A347NegInsHora, BC001329_A349NegInsUsuID, BC001329_n349NegInsUsuID, BC001329_A364NegInsUsuNome, BC001329_n364NegInsUsuNome, BC001329_A380NegValorEstimado,
               BC001329_A385NegValorAtualizado, BC001329_A573NegDelDataHora, BC001329_n573NegDelDataHora, BC001329_A574NegDelData, BC001329_n574NegDelData, BC001329_A575NegDelHora, BC001329_n575NegDelHora, BC001329_A576NegDelUsuId, BC001329_n576NegDelUsuId, BC001329_A577NegDelUsuNome,
               BC001329_n577NegDelUsuNome, BC001329_A473NegCliMatricula, BC001329_A351NegCliNomeFamiliar, BC001329_A353NegCpjNomFan, BC001329_A354NegCpjRazSocial, BC001329_A355NegCpjMatricula, BC001329_A358NegPjtSigla, BC001329_A359NegPjtNome, BC001329_A370NegCpjEndNome, BC001329_A371NegCpjEndEndereco,
               BC001329_A372NegCpjEndNumero, BC001329_A373NegCpjEndComplem, BC001329_n373NegCpjEndComplem, BC001329_A374NegCpjEndBairro, BC001329_A375NegCpjEndMunID, BC001329_A376NegCpjEndMunNome, BC001329_A377NegCpjEndUFID, BC001329_A378NegCpjEndUFSigla, BC001329_A379NegCpjEndUFNome, BC001329_A360NegAgcID,
               BC001329_n360NegAgcID, BC001329_A361NegAgcNome, BC001329_n361NegAgcNome, BC001329_A362NegAssunto, BC001329_A363NegDescricao, BC001329_A386NegUltFase, BC001329_A454NegUltItem, BC001329_n454NegUltItem, BC001329_A572NegDel, BC001329_A350NegCliID,
               BC001329_A352NegCpjID, BC001329_A369NegCpjEndSeq, BC001329_A357NegPjtID, BC001329_A448NegPgpTotal, BC001329_n448NegPgpTotal
               }
               , new Object[] {
               BC001330_A356NegCodigo
               }
               , new Object[] {
               BC001331_A345NegID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001336_A474NegUltNgfSeq, BC001336_n474NegUltNgfSeq
               }
               , new Object[] {
               BC001339_A420NegUltIteID, BC001339_n420NegUltIteID
               }
               , new Object[] {
               BC001342_A421NegUltIteNome, BC001342_n421NegUltIteNome
               }
               , new Object[] {
               BC001345_A479NegUltIteOrdem, BC001345_n479NegUltIteOrdem
               }
               , new Object[] {
               BC001347_A448NegPgpTotal, BC001347_n448NegPgpTotal
               }
               , new Object[] {
               BC001348_A473NegCliMatricula, BC001348_A351NegCliNomeFamiliar
               }
               , new Object[] {
               BC001349_A353NegCpjNomFan, BC001349_A354NegCpjRazSocial, BC001349_A355NegCpjMatricula, BC001349_A357NegPjtID
               }
               , new Object[] {
               BC001350_A358NegPjtSigla, BC001350_A359NegPjtNome
               }
               , new Object[] {
               BC001351_A370NegCpjEndNome, BC001351_A371NegCpjEndEndereco, BC001351_A372NegCpjEndNumero, BC001351_A373NegCpjEndComplem, BC001351_n373NegCpjEndComplem, BC001351_A374NegCpjEndBairro, BC001351_A375NegCpjEndMunID, BC001351_A376NegCpjEndMunNome, BC001351_A377NegCpjEndUFID, BC001351_A378NegCpjEndUFSigla,
               BC001351_A379NegCpjEndUFNome
               }
               , new Object[] {
               BC001352_A398VisID
               }
               , new Object[] {
               BC001353_A345NegID, BC001353_A626NefChave
               }
               , new Object[] {
               BC001354_A398VisID
               }
               , new Object[] {
               }
               , new Object[] {
               BC001357_A345NegID, BC001357_A356NegCodigo, BC001357_A348NegInsDataHora, BC001357_A346NegInsData, BC001357_A347NegInsHora, BC001357_A349NegInsUsuID, BC001357_n349NegInsUsuID, BC001357_A364NegInsUsuNome, BC001357_n364NegInsUsuNome, BC001357_A380NegValorEstimado,
               BC001357_A385NegValorAtualizado, BC001357_A573NegDelDataHora, BC001357_n573NegDelDataHora, BC001357_A574NegDelData, BC001357_n574NegDelData, BC001357_A575NegDelHora, BC001357_n575NegDelHora, BC001357_A576NegDelUsuId, BC001357_n576NegDelUsuId, BC001357_A577NegDelUsuNome,
               BC001357_n577NegDelUsuNome, BC001357_A473NegCliMatricula, BC001357_A351NegCliNomeFamiliar, BC001357_A353NegCpjNomFan, BC001357_A354NegCpjRazSocial, BC001357_A355NegCpjMatricula, BC001357_A358NegPjtSigla, BC001357_A359NegPjtNome, BC001357_A370NegCpjEndNome, BC001357_A371NegCpjEndEndereco,
               BC001357_A372NegCpjEndNumero, BC001357_A373NegCpjEndComplem, BC001357_n373NegCpjEndComplem, BC001357_A374NegCpjEndBairro, BC001357_A375NegCpjEndMunID, BC001357_A376NegCpjEndMunNome, BC001357_A377NegCpjEndUFID, BC001357_A378NegCpjEndUFSigla, BC001357_A379NegCpjEndUFNome, BC001357_A360NegAgcID,
               BC001357_n360NegAgcID, BC001357_A361NegAgcNome, BC001357_n361NegAgcNome, BC001357_A362NegAssunto, BC001357_A363NegDescricao, BC001357_A386NegUltFase, BC001357_A454NegUltItem, BC001357_n454NegUltItem, BC001357_A572NegDel, BC001357_A350NegCliID,
               BC001357_A352NegCpjID, BC001357_A369NegCpjEndSeq, BC001357_A357NegPjtID, BC001357_A448NegPgpTotal, BC001357_n448NegPgpTotal
               }
               , new Object[] {
               BC001358_A345NegID, BC001358_A387NgfSeq, BC001358_A390NgfInsDataHora, BC001358_A388NgfInsData, BC001358_A389NgfInsHora, BC001358_A391NgfInsUsuID, BC001358_n391NgfInsUsuID, BC001358_A392NgfInsUsuNome, BC001358_n392NgfInsUsuNome, BC001358_A585NgfDelDataHora,
               BC001358_n585NgfDelDataHora, BC001358_A586NgfDelData, BC001358_n586NgfDelData, BC001358_A587NgfDelHora, BC001358_n587NgfDelHora, BC001358_A588NgfDelUsuId, BC001358_n588NgfDelUsuId, BC001358_A589NgfDelUsuNome, BC001358_n589NgfDelUsuNome, BC001358_A396NgfIteOrdem,
               BC001358_A397NgfIteNome, BC001358_A425NgfFimData, BC001358_n425NgfFimData, BC001358_A426NgfFimHora, BC001358_n426NgfFimHora, BC001358_A427NgfFimDataHora, BC001358_n427NgfFimDataHora, BC001358_A428NgfFimUsuID, BC001358_n428NgfFimUsuID, BC001358_A429NgfFimUsuNome,
               BC001358_n429NgfFimUsuNome, BC001358_A430NgfStatus, BC001358_n430NgfStatus, BC001358_A584NgfDel, BC001358_A395NgfIteID
               }
               , new Object[] {
               BC001359_A345NegID, BC001359_A387NgfSeq
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001363_A396NgfIteOrdem, BC001363_A397NgfIteNome
               }
               , new Object[] {
               BC001364_A398VisID
               }
               , new Object[] {
               BC001365_A345NegID, BC001365_A387NgfSeq, BC001365_A390NgfInsDataHora, BC001365_A388NgfInsData, BC001365_A389NgfInsHora, BC001365_A391NgfInsUsuID, BC001365_n391NgfInsUsuID, BC001365_A392NgfInsUsuNome, BC001365_n392NgfInsUsuNome, BC001365_A585NgfDelDataHora,
               BC001365_n585NgfDelDataHora, BC001365_A586NgfDelData, BC001365_n586NgfDelData, BC001365_A587NgfDelHora, BC001365_n587NgfDelHora, BC001365_A588NgfDelUsuId, BC001365_n588NgfDelUsuId, BC001365_A589NgfDelUsuNome, BC001365_n589NgfDelUsuNome, BC001365_A396NgfIteOrdem,
               BC001365_A397NgfIteNome, BC001365_A425NgfFimData, BC001365_n425NgfFimData, BC001365_A426NgfFimHora, BC001365_n426NgfFimHora, BC001365_A427NgfFimDataHora, BC001365_n427NgfFimDataHora, BC001365_A428NgfFimUsuID, BC001365_n428NgfFimUsuID, BC001365_A429NgfFimUsuNome,
               BC001365_n429NgfFimUsuNome, BC001365_A430NgfStatus, BC001365_n430NgfStatus, BC001365_A584NgfDel, BC001365_A395NgfIteID
               }
               , new Object[] {
               BC001366_A447NgpTotal, BC001366_A345NegID, BC001366_A435NgpItem, BC001366_A446NgpQtde, BC001366_A457NgpInsDataHora, BC001366_A455NgpInsData, BC001366_A456NgpInsHora, BC001366_A458NgpInsUsuID, BC001366_n458NgpInsUsuID, BC001366_A459NgpInsUsuNome,
               BC001366_n459NgpInsUsuNome, BC001366_A445NgpPreco, BC001366_A579NgpDelDataHora, BC001366_n579NgpDelDataHora, BC001366_A580NgpDelData, BC001366_n580NgpDelData, BC001366_A581NgpDelHora, BC001366_n581NgpDelHora, BC001366_A582NgpDelUsuId, BC001366_n582NgpDelUsuId,
               BC001366_A583NgpDelUsuNome, BC001366_n583NgpDelUsuNome, BC001366_A440NgpTppPrdCodigo, BC001366_A441NgpTppPrdNome, BC001366_A443NgpTppPrdAtivo, BC001366_A444NgpTpp1Preco, BC001366_A453NgpObs, BC001366_A578NgpDel, BC001366_A439NgpTppPrdID, BC001366_A478NgpTppID,
               BC001366_A442NgpTppPrdTipoID
               }
               , new Object[] {
               BC001367_A345NegID, BC001367_A435NgpItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001371_A440NgpTppPrdCodigo, BC001371_A441NgpTppPrdNome, BC001371_A443NgpTppPrdAtivo, BC001371_A442NgpTppPrdTipoID
               }
               , new Object[] {
               BC001372_A444NgpTpp1Preco
               }
               , new Object[] {
               BC001373_A447NgpTotal, BC001373_A345NegID, BC001373_A435NgpItem, BC001373_A446NgpQtde, BC001373_A457NgpInsDataHora, BC001373_A455NgpInsData, BC001373_A456NgpInsHora, BC001373_A458NgpInsUsuID, BC001373_n458NgpInsUsuID, BC001373_A459NgpInsUsuNome,
               BC001373_n459NgpInsUsuNome, BC001373_A445NgpPreco, BC001373_A579NgpDelDataHora, BC001373_n579NgpDelDataHora, BC001373_A580NgpDelData, BC001373_n580NgpDelData, BC001373_A581NgpDelHora, BC001373_n581NgpDelHora, BC001373_A582NgpDelUsuId, BC001373_n582NgpDelUsuId,
               BC001373_A583NgpDelUsuNome, BC001373_n583NgpDelUsuNome, BC001373_A440NgpTppPrdCodigo, BC001373_A441NgpTppPrdNome, BC001373_A443NgpTppPrdAtivo, BC001373_A444NgpTpp1Preco, BC001373_A453NgpObs, BC001373_A578NgpDel, BC001373_A439NgpTppPrdID, BC001373_A478NgpTppID,
               BC001373_A442NgpTppPrdTipoID
               }
            }
         );
         Z446NgpQtde = 1;
         A446NgpQtde = 1;
         i446NgpQtde = 1;
         Z345NegID = Guid.NewGuid( );
         A345NegID = Guid.NewGuid( );
         AV30Pgmname = "core.NegocioPJEstrutura_BC";
         Z445NgpPreco = 0;
         A445NgpPreco = 0;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12132 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_42 ;
      private short RcdFound42 ;
      private short nIsMod_39 ;
      private short RcdFound39 ;
      private short A479NegUltIteOrdem ;
      private short AV15Insert_NegCpjEndSeq ;
      private short GX_JID ;
      private short Z369NegCpjEndSeq ;
      private short A369NegCpjEndSeq ;
      private short Z479NegUltIteOrdem ;
      private short Z377NegCpjEndUFID ;
      private short A377NegCpjEndUFID ;
      private short Gx_BScreen ;
      private short RcdFound37 ;
      private short nIsDirty_37 ;
      private short nRcdExists_39 ;
      private short Gxremove39 ;
      private short nRcdExists_42 ;
      private short Gxremove42 ;
      private short nIsDirty_39 ;
      private short nIsDirty_42 ;
      private int trnEnded ;
      private int s454NegUltItem ;
      private int O454NegUltItem ;
      private int A454NegUltItem ;
      private int nGXsfl_42_idx=1 ;
      private int s386NegUltFase ;
      private int O386NegUltFase ;
      private int A386NegUltFase ;
      private int nGXsfl_39_idx=1 ;
      private int A474NegUltNgfSeq ;
      private int AV31GXV1 ;
      private int Z386NegUltFase ;
      private int Z454NegUltItem ;
      private int Z474NegUltNgfSeq ;
      private int Z357NegPjtID ;
      private int A357NegPjtID ;
      private int Z375NegCpjEndMunID ;
      private int A375NegCpjEndMunID ;
      private int GXt_int1 ;
      private int Z396NgfIteOrdem ;
      private int A396NgfIteOrdem ;
      private int Z387NgfSeq ;
      private int A387NgfSeq ;
      private int Z446NgpQtde ;
      private int A446NgpQtde ;
      private int Z442NgpTppPrdTipoID ;
      private int A442NgpTppPrdTipoID ;
      private int Z435NgpItem ;
      private int A435NgpItem ;
      private int i386NegUltFase ;
      private int i454NegUltItem ;
      private int i446NgpQtde ;
      private long Z356NegCodigo ;
      private long A356NegCodigo ;
      private long Z473NegCliMatricula ;
      private long A473NegCliMatricula ;
      private long Z355NegCpjMatricula ;
      private long A355NegCpjMatricula ;
      private decimal s448NegPgpTotal ;
      private decimal O448NegPgpTotal ;
      private decimal A448NegPgpTotal ;
      private decimal Z380NegValorEstimado ;
      private decimal A380NegValorEstimado ;
      private decimal Z385NegValorAtualizado ;
      private decimal A385NegValorAtualizado ;
      private decimal Z448NegPgpTotal ;
      private decimal Z447NgpTotal ;
      private decimal A447NgpTotal ;
      private decimal Z445NgpPreco ;
      private decimal A445NgpPreco ;
      private decimal Z444NgpTpp1Preco ;
      private decimal A444NgpTpp1Preco ;
      private decimal O447NgpTotal ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode37 ;
      private string AV30Pgmname ;
      private string Z349NegInsUsuID ;
      private string A349NegInsUsuID ;
      private string Z576NegDelUsuId ;
      private string A576NegDelUsuId ;
      private string Z360NegAgcID ;
      private string A360NegAgcID ;
      private string Z391NgfInsUsuID ;
      private string A391NgfInsUsuID ;
      private string Z588NgfDelUsuId ;
      private string A588NgfDelUsuId ;
      private string Z428NgfFimUsuID ;
      private string A428NgfFimUsuID ;
      private string sMode39 ;
      private string Z458NgpInsUsuID ;
      private string A458NgpInsUsuID ;
      private string Z582NgpDelUsuId ;
      private string A582NgpDelUsuId ;
      private string sMode42 ;
      private DateTime Z348NegInsDataHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime Z347NegInsHora ;
      private DateTime A347NegInsHora ;
      private DateTime Z573NegDelDataHora ;
      private DateTime A573NegDelDataHora ;
      private DateTime Z574NegDelData ;
      private DateTime A574NegDelData ;
      private DateTime Z575NegDelHora ;
      private DateTime A575NegDelHora ;
      private DateTime Z390NgfInsDataHora ;
      private DateTime A390NgfInsDataHora ;
      private DateTime Z389NgfInsHora ;
      private DateTime A389NgfInsHora ;
      private DateTime Z585NgfDelDataHora ;
      private DateTime A585NgfDelDataHora ;
      private DateTime Z586NgfDelData ;
      private DateTime A586NgfDelData ;
      private DateTime Z587NgfDelHora ;
      private DateTime A587NgfDelHora ;
      private DateTime Z426NgfFimHora ;
      private DateTime A426NgfFimHora ;
      private DateTime Z427NgfFimDataHora ;
      private DateTime A427NgfFimDataHora ;
      private DateTime Z457NgpInsDataHora ;
      private DateTime A457NgpInsDataHora ;
      private DateTime Z456NgpInsHora ;
      private DateTime A456NgpInsHora ;
      private DateTime Z579NgpDelDataHora ;
      private DateTime A579NgpDelDataHora ;
      private DateTime Z580NgpDelData ;
      private DateTime A580NgpDelData ;
      private DateTime Z581NgpDelHora ;
      private DateTime A581NgpDelHora ;
      private DateTime Z346NegInsData ;
      private DateTime A346NegInsData ;
      private DateTime Z388NgfInsData ;
      private DateTime A388NgfInsData ;
      private DateTime Z425NgfFimData ;
      private DateTime A425NgfFimData ;
      private DateTime Z455NgpInsData ;
      private DateTime A455NgpInsData ;
      private bool n454NegUltItem ;
      private bool n448NegPgpTotal ;
      private bool n474NegUltNgfSeq ;
      private bool n420NegUltIteID ;
      private bool n421NegUltIteNome ;
      private bool n479NegUltIteOrdem ;
      private bool returnInSub ;
      private bool Z572NegDel ;
      private bool A572NegDel ;
      private bool n349NegInsUsuID ;
      private bool n364NegInsUsuNome ;
      private bool n573NegDelDataHora ;
      private bool n574NegDelData ;
      private bool n575NegDelHora ;
      private bool n576NegDelUsuId ;
      private bool n577NegDelUsuNome ;
      private bool n373NegCpjEndComplem ;
      private bool n360NegAgcID ;
      private bool n361NegAgcNome ;
      private bool O572NegDel ;
      private bool Gx_longc ;
      private bool Z584NgfDel ;
      private bool A584NgfDel ;
      private bool n391NgfInsUsuID ;
      private bool n392NgfInsUsuNome ;
      private bool n585NgfDelDataHora ;
      private bool n586NgfDelData ;
      private bool n587NgfDelHora ;
      private bool n588NgfDelUsuId ;
      private bool n589NgfDelUsuNome ;
      private bool n425NgfFimData ;
      private bool n426NgfFimHora ;
      private bool n427NgfFimDataHora ;
      private bool n428NgfFimUsuID ;
      private bool n429NgfFimUsuNome ;
      private bool n430NgfStatus ;
      private bool O584NgfDel ;
      private bool Z578NgpDel ;
      private bool A578NgpDel ;
      private bool Z443NgpTppPrdAtivo ;
      private bool A443NgpTppPrdAtivo ;
      private bool n458NgpInsUsuID ;
      private bool n459NgpInsUsuNome ;
      private bool n579NgpDelDataHora ;
      private bool n580NgpDelData ;
      private bool n581NgpDelHora ;
      private bool n582NgpDelUsuId ;
      private bool n583NgpDelUsuNome ;
      private bool O578NgpDel ;
      private bool mustCommit ;
      private string Z363NegDescricao ;
      private string A363NegDescricao ;
      private string A421NegUltIteNome ;
      private string Z364NegInsUsuNome ;
      private string A364NegInsUsuNome ;
      private string Z577NegDelUsuNome ;
      private string A577NegDelUsuNome ;
      private string Z361NegAgcNome ;
      private string A361NegAgcNome ;
      private string Z362NegAssunto ;
      private string A362NegAssunto ;
      private string Z421NegUltIteNome ;
      private string Z351NegCliNomeFamiliar ;
      private string A351NegCliNomeFamiliar ;
      private string Z353NegCpjNomFan ;
      private string A353NegCpjNomFan ;
      private string Z354NegCpjRazSocial ;
      private string A354NegCpjRazSocial ;
      private string Z370NegCpjEndNome ;
      private string A370NegCpjEndNome ;
      private string Z371NegCpjEndEndereco ;
      private string A371NegCpjEndEndereco ;
      private string Z372NegCpjEndNumero ;
      private string A372NegCpjEndNumero ;
      private string Z373NegCpjEndComplem ;
      private string A373NegCpjEndComplem ;
      private string Z374NegCpjEndBairro ;
      private string A374NegCpjEndBairro ;
      private string Z376NegCpjEndMunNome ;
      private string A376NegCpjEndMunNome ;
      private string Z378NegCpjEndUFSigla ;
      private string A378NegCpjEndUFSigla ;
      private string Z379NegCpjEndUFNome ;
      private string A379NegCpjEndUFNome ;
      private string Z358NegPjtSigla ;
      private string A358NegPjtSigla ;
      private string Z359NegPjtNome ;
      private string A359NegPjtNome ;
      private string Z392NgfInsUsuNome ;
      private string A392NgfInsUsuNome ;
      private string Z589NgfDelUsuNome ;
      private string A589NgfDelUsuNome ;
      private string Z429NgfFimUsuNome ;
      private string A429NgfFimUsuNome ;
      private string Z430NgfStatus ;
      private string A430NgfStatus ;
      private string Z397NgfIteNome ;
      private string A397NgfIteNome ;
      private string Z459NgpInsUsuNome ;
      private string A459NgpInsUsuNome ;
      private string Z583NgpDelUsuNome ;
      private string A583NgpDelUsuNome ;
      private string Z453NgpObs ;
      private string A453NgpObs ;
      private string Z440NgpTppPrdCodigo ;
      private string A440NgpTppPrdCodigo ;
      private string Z441NgpTppPrdNome ;
      private string A441NgpTppPrdNome ;
      private Guid Z345NegID ;
      private Guid A345NegID ;
      private Guid A420NegUltIteID ;
      private Guid AV13Insert_NegCliID ;
      private Guid AV14Insert_NegCpjID ;
      private Guid Z350NegCliID ;
      private Guid A350NegCliID ;
      private Guid Z352NegCpjID ;
      private Guid A352NegCpjID ;
      private Guid Z420NegUltIteID ;
      private Guid Z395NgfIteID ;
      private Guid A395NgfIteID ;
      private Guid Z439NgpTppPrdID ;
      private Guid A439NgpTppPrdID ;
      private Guid Z478NgpTppID ;
      private Guid A478NgpTppID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtNegocioPJEstrutura bccore_NegocioPJEstrutura ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001310_A474NegUltNgfSeq ;
      private bool[] BC001310_n474NegUltNgfSeq ;
      private Guid[] BC001313_A420NegUltIteID ;
      private bool[] BC001313_n420NegUltIteID ;
      private string[] BC001316_A421NegUltIteNome ;
      private bool[] BC001316_n421NegUltIteNome ;
      private short[] BC001319_A479NegUltIteOrdem ;
      private bool[] BC001319_n479NegUltIteOrdem ;
      private decimal[] BC001327_A448NegPgpTotal ;
      private bool[] BC001327_n448NegPgpTotal ;
      private Guid[] BC001329_A345NegID ;
      private long[] BC001329_A356NegCodigo ;
      private DateTime[] BC001329_A348NegInsDataHora ;
      private DateTime[] BC001329_A346NegInsData ;
      private DateTime[] BC001329_A347NegInsHora ;
      private string[] BC001329_A349NegInsUsuID ;
      private bool[] BC001329_n349NegInsUsuID ;
      private string[] BC001329_A364NegInsUsuNome ;
      private bool[] BC001329_n364NegInsUsuNome ;
      private decimal[] BC001329_A380NegValorEstimado ;
      private decimal[] BC001329_A385NegValorAtualizado ;
      private DateTime[] BC001329_A573NegDelDataHora ;
      private bool[] BC001329_n573NegDelDataHora ;
      private DateTime[] BC001329_A574NegDelData ;
      private bool[] BC001329_n574NegDelData ;
      private DateTime[] BC001329_A575NegDelHora ;
      private bool[] BC001329_n575NegDelHora ;
      private string[] BC001329_A576NegDelUsuId ;
      private bool[] BC001329_n576NegDelUsuId ;
      private string[] BC001329_A577NegDelUsuNome ;
      private bool[] BC001329_n577NegDelUsuNome ;
      private long[] BC001329_A473NegCliMatricula ;
      private string[] BC001329_A351NegCliNomeFamiliar ;
      private string[] BC001329_A353NegCpjNomFan ;
      private string[] BC001329_A354NegCpjRazSocial ;
      private long[] BC001329_A355NegCpjMatricula ;
      private string[] BC001329_A358NegPjtSigla ;
      private string[] BC001329_A359NegPjtNome ;
      private string[] BC001329_A370NegCpjEndNome ;
      private string[] BC001329_A371NegCpjEndEndereco ;
      private string[] BC001329_A372NegCpjEndNumero ;
      private string[] BC001329_A373NegCpjEndComplem ;
      private bool[] BC001329_n373NegCpjEndComplem ;
      private string[] BC001329_A374NegCpjEndBairro ;
      private int[] BC001329_A375NegCpjEndMunID ;
      private string[] BC001329_A376NegCpjEndMunNome ;
      private short[] BC001329_A377NegCpjEndUFID ;
      private string[] BC001329_A378NegCpjEndUFSigla ;
      private string[] BC001329_A379NegCpjEndUFNome ;
      private string[] BC001329_A360NegAgcID ;
      private bool[] BC001329_n360NegAgcID ;
      private string[] BC001329_A361NegAgcNome ;
      private bool[] BC001329_n361NegAgcNome ;
      private string[] BC001329_A362NegAssunto ;
      private string[] BC001329_A363NegDescricao ;
      private int[] BC001329_A386NegUltFase ;
      private int[] BC001329_A454NegUltItem ;
      private bool[] BC001329_n454NegUltItem ;
      private bool[] BC001329_A572NegDel ;
      private Guid[] BC001329_A350NegCliID ;
      private Guid[] BC001329_A352NegCpjID ;
      private short[] BC001329_A369NegCpjEndSeq ;
      private int[] BC001329_A357NegPjtID ;
      private decimal[] BC001329_A448NegPgpTotal ;
      private bool[] BC001329_n448NegPgpTotal ;
      private long[] BC001330_A356NegCodigo ;
      private long[] BC001322_A473NegCliMatricula ;
      private string[] BC001322_A351NegCliNomeFamiliar ;
      private string[] BC001323_A353NegCpjNomFan ;
      private string[] BC001323_A354NegCpjRazSocial ;
      private long[] BC001323_A355NegCpjMatricula ;
      private int[] BC001323_A357NegPjtID ;
      private string[] BC001325_A358NegPjtSigla ;
      private string[] BC001325_A359NegPjtNome ;
      private string[] BC001324_A370NegCpjEndNome ;
      private string[] BC001324_A371NegCpjEndEndereco ;
      private string[] BC001324_A372NegCpjEndNumero ;
      private string[] BC001324_A373NegCpjEndComplem ;
      private bool[] BC001324_n373NegCpjEndComplem ;
      private string[] BC001324_A374NegCpjEndBairro ;
      private int[] BC001324_A375NegCpjEndMunID ;
      private string[] BC001324_A376NegCpjEndMunNome ;
      private short[] BC001324_A377NegCpjEndUFID ;
      private string[] BC001324_A378NegCpjEndUFSigla ;
      private string[] BC001324_A379NegCpjEndUFNome ;
      private Guid[] BC001331_A345NegID ;
      private Guid[] BC001321_A345NegID ;
      private long[] BC001321_A356NegCodigo ;
      private DateTime[] BC001321_A348NegInsDataHora ;
      private DateTime[] BC001321_A346NegInsData ;
      private DateTime[] BC001321_A347NegInsHora ;
      private string[] BC001321_A349NegInsUsuID ;
      private bool[] BC001321_n349NegInsUsuID ;
      private string[] BC001321_A364NegInsUsuNome ;
      private bool[] BC001321_n364NegInsUsuNome ;
      private decimal[] BC001321_A380NegValorEstimado ;
      private decimal[] BC001321_A385NegValorAtualizado ;
      private DateTime[] BC001321_A573NegDelDataHora ;
      private bool[] BC001321_n573NegDelDataHora ;
      private DateTime[] BC001321_A574NegDelData ;
      private bool[] BC001321_n574NegDelData ;
      private DateTime[] BC001321_A575NegDelHora ;
      private bool[] BC001321_n575NegDelHora ;
      private string[] BC001321_A576NegDelUsuId ;
      private bool[] BC001321_n576NegDelUsuId ;
      private string[] BC001321_A577NegDelUsuNome ;
      private bool[] BC001321_n577NegDelUsuNome ;
      private string[] BC001321_A360NegAgcID ;
      private bool[] BC001321_n360NegAgcID ;
      private string[] BC001321_A361NegAgcNome ;
      private bool[] BC001321_n361NegAgcNome ;
      private string[] BC001321_A362NegAssunto ;
      private string[] BC001321_A363NegDescricao ;
      private int[] BC001321_A386NegUltFase ;
      private int[] BC001321_A454NegUltItem ;
      private bool[] BC001321_n454NegUltItem ;
      private bool[] BC001321_A572NegDel ;
      private Guid[] BC001321_A350NegCliID ;
      private Guid[] BC001321_A352NegCpjID ;
      private short[] BC001321_A369NegCpjEndSeq ;
      private string[] BC001321_A351NegCliNomeFamiliar ;
      private string[] BC001321_A353NegCpjNomFan ;
      private string[] BC001321_A354NegCpjRazSocial ;
      private string[] BC001321_A359NegPjtNome ;
      private Guid[] BC001320_A345NegID ;
      private long[] BC001320_A356NegCodigo ;
      private DateTime[] BC001320_A348NegInsDataHora ;
      private DateTime[] BC001320_A346NegInsData ;
      private DateTime[] BC001320_A347NegInsHora ;
      private string[] BC001320_A349NegInsUsuID ;
      private bool[] BC001320_n349NegInsUsuID ;
      private string[] BC001320_A364NegInsUsuNome ;
      private bool[] BC001320_n364NegInsUsuNome ;
      private decimal[] BC001320_A380NegValorEstimado ;
      private decimal[] BC001320_A385NegValorAtualizado ;
      private DateTime[] BC001320_A573NegDelDataHora ;
      private bool[] BC001320_n573NegDelDataHora ;
      private DateTime[] BC001320_A574NegDelData ;
      private bool[] BC001320_n574NegDelData ;
      private DateTime[] BC001320_A575NegDelHora ;
      private bool[] BC001320_n575NegDelHora ;
      private string[] BC001320_A576NegDelUsuId ;
      private bool[] BC001320_n576NegDelUsuId ;
      private string[] BC001320_A577NegDelUsuNome ;
      private bool[] BC001320_n577NegDelUsuNome ;
      private string[] BC001320_A360NegAgcID ;
      private bool[] BC001320_n360NegAgcID ;
      private string[] BC001320_A361NegAgcNome ;
      private bool[] BC001320_n361NegAgcNome ;
      private string[] BC001320_A362NegAssunto ;
      private string[] BC001320_A363NegDescricao ;
      private int[] BC001320_A386NegUltFase ;
      private int[] BC001320_A454NegUltItem ;
      private bool[] BC001320_n454NegUltItem ;
      private bool[] BC001320_A572NegDel ;
      private Guid[] BC001320_A350NegCliID ;
      private Guid[] BC001320_A352NegCpjID ;
      private short[] BC001320_A369NegCpjEndSeq ;
      private string[] BC001320_A351NegCliNomeFamiliar ;
      private string[] BC001320_A353NegCpjNomFan ;
      private string[] BC001320_A354NegCpjRazSocial ;
      private string[] BC001320_A359NegPjtNome ;
      private int[] BC001336_A474NegUltNgfSeq ;
      private bool[] BC001336_n474NegUltNgfSeq ;
      private Guid[] BC001339_A420NegUltIteID ;
      private bool[] BC001339_n420NegUltIteID ;
      private string[] BC001342_A421NegUltIteNome ;
      private bool[] BC001342_n421NegUltIteNome ;
      private short[] BC001345_A479NegUltIteOrdem ;
      private bool[] BC001345_n479NegUltIteOrdem ;
      private decimal[] BC001347_A448NegPgpTotal ;
      private bool[] BC001347_n448NegPgpTotal ;
      private long[] BC001348_A473NegCliMatricula ;
      private string[] BC001348_A351NegCliNomeFamiliar ;
      private string[] BC001349_A353NegCpjNomFan ;
      private string[] BC001349_A354NegCpjRazSocial ;
      private long[] BC001349_A355NegCpjMatricula ;
      private int[] BC001349_A357NegPjtID ;
      private string[] BC001350_A358NegPjtSigla ;
      private string[] BC001350_A359NegPjtNome ;
      private string[] BC001351_A370NegCpjEndNome ;
      private string[] BC001351_A371NegCpjEndEndereco ;
      private string[] BC001351_A372NegCpjEndNumero ;
      private string[] BC001351_A373NegCpjEndComplem ;
      private bool[] BC001351_n373NegCpjEndComplem ;
      private string[] BC001351_A374NegCpjEndBairro ;
      private int[] BC001351_A375NegCpjEndMunID ;
      private string[] BC001351_A376NegCpjEndMunNome ;
      private short[] BC001351_A377NegCpjEndUFID ;
      private string[] BC001351_A378NegCpjEndUFSigla ;
      private string[] BC001351_A379NegCpjEndUFNome ;
      private Guid[] BC001352_A398VisID ;
      private Guid[] BC001353_A345NegID ;
      private string[] BC001353_A626NefChave ;
      private Guid[] BC001354_A398VisID ;
      private Guid[] BC001357_A345NegID ;
      private long[] BC001357_A356NegCodigo ;
      private DateTime[] BC001357_A348NegInsDataHora ;
      private DateTime[] BC001357_A346NegInsData ;
      private DateTime[] BC001357_A347NegInsHora ;
      private string[] BC001357_A349NegInsUsuID ;
      private bool[] BC001357_n349NegInsUsuID ;
      private string[] BC001357_A364NegInsUsuNome ;
      private bool[] BC001357_n364NegInsUsuNome ;
      private decimal[] BC001357_A380NegValorEstimado ;
      private decimal[] BC001357_A385NegValorAtualizado ;
      private DateTime[] BC001357_A573NegDelDataHora ;
      private bool[] BC001357_n573NegDelDataHora ;
      private DateTime[] BC001357_A574NegDelData ;
      private bool[] BC001357_n574NegDelData ;
      private DateTime[] BC001357_A575NegDelHora ;
      private bool[] BC001357_n575NegDelHora ;
      private string[] BC001357_A576NegDelUsuId ;
      private bool[] BC001357_n576NegDelUsuId ;
      private string[] BC001357_A577NegDelUsuNome ;
      private bool[] BC001357_n577NegDelUsuNome ;
      private long[] BC001357_A473NegCliMatricula ;
      private string[] BC001357_A351NegCliNomeFamiliar ;
      private string[] BC001357_A353NegCpjNomFan ;
      private string[] BC001357_A354NegCpjRazSocial ;
      private long[] BC001357_A355NegCpjMatricula ;
      private string[] BC001357_A358NegPjtSigla ;
      private string[] BC001357_A359NegPjtNome ;
      private string[] BC001357_A370NegCpjEndNome ;
      private string[] BC001357_A371NegCpjEndEndereco ;
      private string[] BC001357_A372NegCpjEndNumero ;
      private string[] BC001357_A373NegCpjEndComplem ;
      private bool[] BC001357_n373NegCpjEndComplem ;
      private string[] BC001357_A374NegCpjEndBairro ;
      private int[] BC001357_A375NegCpjEndMunID ;
      private string[] BC001357_A376NegCpjEndMunNome ;
      private short[] BC001357_A377NegCpjEndUFID ;
      private string[] BC001357_A378NegCpjEndUFSigla ;
      private string[] BC001357_A379NegCpjEndUFNome ;
      private string[] BC001357_A360NegAgcID ;
      private bool[] BC001357_n360NegAgcID ;
      private string[] BC001357_A361NegAgcNome ;
      private bool[] BC001357_n361NegAgcNome ;
      private string[] BC001357_A362NegAssunto ;
      private string[] BC001357_A363NegDescricao ;
      private int[] BC001357_A386NegUltFase ;
      private int[] BC001357_A454NegUltItem ;
      private bool[] BC001357_n454NegUltItem ;
      private bool[] BC001357_A572NegDel ;
      private Guid[] BC001357_A350NegCliID ;
      private Guid[] BC001357_A352NegCpjID ;
      private short[] BC001357_A369NegCpjEndSeq ;
      private int[] BC001357_A357NegPjtID ;
      private decimal[] BC001357_A448NegPgpTotal ;
      private bool[] BC001357_n448NegPgpTotal ;
      private Guid[] BC001358_A345NegID ;
      private int[] BC001358_A387NgfSeq ;
      private DateTime[] BC001358_A390NgfInsDataHora ;
      private DateTime[] BC001358_A388NgfInsData ;
      private DateTime[] BC001358_A389NgfInsHora ;
      private string[] BC001358_A391NgfInsUsuID ;
      private bool[] BC001358_n391NgfInsUsuID ;
      private string[] BC001358_A392NgfInsUsuNome ;
      private bool[] BC001358_n392NgfInsUsuNome ;
      private DateTime[] BC001358_A585NgfDelDataHora ;
      private bool[] BC001358_n585NgfDelDataHora ;
      private DateTime[] BC001358_A586NgfDelData ;
      private bool[] BC001358_n586NgfDelData ;
      private DateTime[] BC001358_A587NgfDelHora ;
      private bool[] BC001358_n587NgfDelHora ;
      private string[] BC001358_A588NgfDelUsuId ;
      private bool[] BC001358_n588NgfDelUsuId ;
      private string[] BC001358_A589NgfDelUsuNome ;
      private bool[] BC001358_n589NgfDelUsuNome ;
      private int[] BC001358_A396NgfIteOrdem ;
      private string[] BC001358_A397NgfIteNome ;
      private DateTime[] BC001358_A425NgfFimData ;
      private bool[] BC001358_n425NgfFimData ;
      private DateTime[] BC001358_A426NgfFimHora ;
      private bool[] BC001358_n426NgfFimHora ;
      private DateTime[] BC001358_A427NgfFimDataHora ;
      private bool[] BC001358_n427NgfFimDataHora ;
      private string[] BC001358_A428NgfFimUsuID ;
      private bool[] BC001358_n428NgfFimUsuID ;
      private string[] BC001358_A429NgfFimUsuNome ;
      private bool[] BC001358_n429NgfFimUsuNome ;
      private string[] BC001358_A430NgfStatus ;
      private bool[] BC001358_n430NgfStatus ;
      private bool[] BC001358_A584NgfDel ;
      private Guid[] BC001358_A395NgfIteID ;
      private int[] BC00138_A396NgfIteOrdem ;
      private string[] BC00138_A397NgfIteNome ;
      private Guid[] BC001359_A345NegID ;
      private int[] BC001359_A387NgfSeq ;
      private Guid[] BC00137_A345NegID ;
      private int[] BC00137_A387NgfSeq ;
      private DateTime[] BC00137_A390NgfInsDataHora ;
      private DateTime[] BC00137_A388NgfInsData ;
      private DateTime[] BC00137_A389NgfInsHora ;
      private string[] BC00137_A391NgfInsUsuID ;
      private bool[] BC00137_n391NgfInsUsuID ;
      private string[] BC00137_A392NgfInsUsuNome ;
      private bool[] BC00137_n392NgfInsUsuNome ;
      private DateTime[] BC00137_A585NgfDelDataHora ;
      private bool[] BC00137_n585NgfDelDataHora ;
      private DateTime[] BC00137_A586NgfDelData ;
      private bool[] BC00137_n586NgfDelData ;
      private DateTime[] BC00137_A587NgfDelHora ;
      private bool[] BC00137_n587NgfDelHora ;
      private string[] BC00137_A588NgfDelUsuId ;
      private bool[] BC00137_n588NgfDelUsuId ;
      private string[] BC00137_A589NgfDelUsuNome ;
      private bool[] BC00137_n589NgfDelUsuNome ;
      private DateTime[] BC00137_A425NgfFimData ;
      private bool[] BC00137_n425NgfFimData ;
      private DateTime[] BC00137_A426NgfFimHora ;
      private bool[] BC00137_n426NgfFimHora ;
      private DateTime[] BC00137_A427NgfFimDataHora ;
      private bool[] BC00137_n427NgfFimDataHora ;
      private string[] BC00137_A428NgfFimUsuID ;
      private bool[] BC00137_n428NgfFimUsuID ;
      private string[] BC00137_A429NgfFimUsuNome ;
      private bool[] BC00137_n429NgfFimUsuNome ;
      private string[] BC00137_A430NgfStatus ;
      private bool[] BC00137_n430NgfStatus ;
      private bool[] BC00137_A584NgfDel ;
      private Guid[] BC00137_A395NgfIteID ;
      private string[] BC00137_A397NgfIteNome ;
      private Guid[] BC00136_A345NegID ;
      private int[] BC00136_A387NgfSeq ;
      private DateTime[] BC00136_A390NgfInsDataHora ;
      private DateTime[] BC00136_A388NgfInsData ;
      private DateTime[] BC00136_A389NgfInsHora ;
      private string[] BC00136_A391NgfInsUsuID ;
      private bool[] BC00136_n391NgfInsUsuID ;
      private string[] BC00136_A392NgfInsUsuNome ;
      private bool[] BC00136_n392NgfInsUsuNome ;
      private DateTime[] BC00136_A585NgfDelDataHora ;
      private bool[] BC00136_n585NgfDelDataHora ;
      private DateTime[] BC00136_A586NgfDelData ;
      private bool[] BC00136_n586NgfDelData ;
      private DateTime[] BC00136_A587NgfDelHora ;
      private bool[] BC00136_n587NgfDelHora ;
      private string[] BC00136_A588NgfDelUsuId ;
      private bool[] BC00136_n588NgfDelUsuId ;
      private string[] BC00136_A589NgfDelUsuNome ;
      private bool[] BC00136_n589NgfDelUsuNome ;
      private DateTime[] BC00136_A425NgfFimData ;
      private bool[] BC00136_n425NgfFimData ;
      private DateTime[] BC00136_A426NgfFimHora ;
      private bool[] BC00136_n426NgfFimHora ;
      private DateTime[] BC00136_A427NgfFimDataHora ;
      private bool[] BC00136_n427NgfFimDataHora ;
      private string[] BC00136_A428NgfFimUsuID ;
      private bool[] BC00136_n428NgfFimUsuID ;
      private string[] BC00136_A429NgfFimUsuNome ;
      private bool[] BC00136_n429NgfFimUsuNome ;
      private string[] BC00136_A430NgfStatus ;
      private bool[] BC00136_n430NgfStatus ;
      private bool[] BC00136_A584NgfDel ;
      private Guid[] BC00136_A395NgfIteID ;
      private string[] BC00136_A397NgfIteNome ;
      private int[] BC001363_A396NgfIteOrdem ;
      private string[] BC001363_A397NgfIteNome ;
      private Guid[] BC001364_A398VisID ;
      private Guid[] BC001365_A345NegID ;
      private int[] BC001365_A387NgfSeq ;
      private DateTime[] BC001365_A390NgfInsDataHora ;
      private DateTime[] BC001365_A388NgfInsData ;
      private DateTime[] BC001365_A389NgfInsHora ;
      private string[] BC001365_A391NgfInsUsuID ;
      private bool[] BC001365_n391NgfInsUsuID ;
      private string[] BC001365_A392NgfInsUsuNome ;
      private bool[] BC001365_n392NgfInsUsuNome ;
      private DateTime[] BC001365_A585NgfDelDataHora ;
      private bool[] BC001365_n585NgfDelDataHora ;
      private DateTime[] BC001365_A586NgfDelData ;
      private bool[] BC001365_n586NgfDelData ;
      private DateTime[] BC001365_A587NgfDelHora ;
      private bool[] BC001365_n587NgfDelHora ;
      private string[] BC001365_A588NgfDelUsuId ;
      private bool[] BC001365_n588NgfDelUsuId ;
      private string[] BC001365_A589NgfDelUsuNome ;
      private bool[] BC001365_n589NgfDelUsuNome ;
      private int[] BC001365_A396NgfIteOrdem ;
      private string[] BC001365_A397NgfIteNome ;
      private DateTime[] BC001365_A425NgfFimData ;
      private bool[] BC001365_n425NgfFimData ;
      private DateTime[] BC001365_A426NgfFimHora ;
      private bool[] BC001365_n426NgfFimHora ;
      private DateTime[] BC001365_A427NgfFimDataHora ;
      private bool[] BC001365_n427NgfFimDataHora ;
      private string[] BC001365_A428NgfFimUsuID ;
      private bool[] BC001365_n428NgfFimUsuID ;
      private string[] BC001365_A429NgfFimUsuNome ;
      private bool[] BC001365_n429NgfFimUsuNome ;
      private string[] BC001365_A430NgfStatus ;
      private bool[] BC001365_n430NgfStatus ;
      private bool[] BC001365_A584NgfDel ;
      private Guid[] BC001365_A395NgfIteID ;
      private decimal[] BC001366_A447NgpTotal ;
      private Guid[] BC001366_A345NegID ;
      private int[] BC001366_A435NgpItem ;
      private int[] BC001366_A446NgpQtde ;
      private DateTime[] BC001366_A457NgpInsDataHora ;
      private DateTime[] BC001366_A455NgpInsData ;
      private DateTime[] BC001366_A456NgpInsHora ;
      private string[] BC001366_A458NgpInsUsuID ;
      private bool[] BC001366_n458NgpInsUsuID ;
      private string[] BC001366_A459NgpInsUsuNome ;
      private bool[] BC001366_n459NgpInsUsuNome ;
      private decimal[] BC001366_A445NgpPreco ;
      private DateTime[] BC001366_A579NgpDelDataHora ;
      private bool[] BC001366_n579NgpDelDataHora ;
      private DateTime[] BC001366_A580NgpDelData ;
      private bool[] BC001366_n580NgpDelData ;
      private DateTime[] BC001366_A581NgpDelHora ;
      private bool[] BC001366_n581NgpDelHora ;
      private string[] BC001366_A582NgpDelUsuId ;
      private bool[] BC001366_n582NgpDelUsuId ;
      private string[] BC001366_A583NgpDelUsuNome ;
      private bool[] BC001366_n583NgpDelUsuNome ;
      private string[] BC001366_A440NgpTppPrdCodigo ;
      private string[] BC001366_A441NgpTppPrdNome ;
      private bool[] BC001366_A443NgpTppPrdAtivo ;
      private decimal[] BC001366_A444NgpTpp1Preco ;
      private string[] BC001366_A453NgpObs ;
      private bool[] BC001366_A578NgpDel ;
      private Guid[] BC001366_A439NgpTppPrdID ;
      private Guid[] BC001366_A478NgpTppID ;
      private int[] BC001366_A442NgpTppPrdTipoID ;
      private decimal[] BC00135_A444NgpTpp1Preco ;
      private string[] BC00134_A440NgpTppPrdCodigo ;
      private string[] BC00134_A441NgpTppPrdNome ;
      private bool[] BC00134_A443NgpTppPrdAtivo ;
      private int[] BC00134_A442NgpTppPrdTipoID ;
      private Guid[] BC001367_A345NegID ;
      private int[] BC001367_A435NgpItem ;
      private decimal[] BC00133_A447NgpTotal ;
      private Guid[] BC00133_A345NegID ;
      private int[] BC00133_A435NgpItem ;
      private int[] BC00133_A446NgpQtde ;
      private DateTime[] BC00133_A457NgpInsDataHora ;
      private DateTime[] BC00133_A455NgpInsData ;
      private DateTime[] BC00133_A456NgpInsHora ;
      private string[] BC00133_A458NgpInsUsuID ;
      private bool[] BC00133_n458NgpInsUsuID ;
      private string[] BC00133_A459NgpInsUsuNome ;
      private bool[] BC00133_n459NgpInsUsuNome ;
      private decimal[] BC00133_A445NgpPreco ;
      private DateTime[] BC00133_A579NgpDelDataHora ;
      private bool[] BC00133_n579NgpDelDataHora ;
      private DateTime[] BC00133_A580NgpDelData ;
      private bool[] BC00133_n580NgpDelData ;
      private DateTime[] BC00133_A581NgpDelHora ;
      private bool[] BC00133_n581NgpDelHora ;
      private string[] BC00133_A582NgpDelUsuId ;
      private bool[] BC00133_n582NgpDelUsuId ;
      private string[] BC00133_A583NgpDelUsuNome ;
      private bool[] BC00133_n583NgpDelUsuNome ;
      private string[] BC00133_A453NgpObs ;
      private bool[] BC00133_A578NgpDel ;
      private Guid[] BC00133_A439NgpTppPrdID ;
      private Guid[] BC00133_A478NgpTppID ;
      private decimal[] BC00132_A447NgpTotal ;
      private Guid[] BC00132_A345NegID ;
      private int[] BC00132_A435NgpItem ;
      private int[] BC00132_A446NgpQtde ;
      private DateTime[] BC00132_A457NgpInsDataHora ;
      private DateTime[] BC00132_A455NgpInsData ;
      private DateTime[] BC00132_A456NgpInsHora ;
      private string[] BC00132_A458NgpInsUsuID ;
      private bool[] BC00132_n458NgpInsUsuID ;
      private string[] BC00132_A459NgpInsUsuNome ;
      private bool[] BC00132_n459NgpInsUsuNome ;
      private decimal[] BC00132_A445NgpPreco ;
      private DateTime[] BC00132_A579NgpDelDataHora ;
      private bool[] BC00132_n579NgpDelDataHora ;
      private DateTime[] BC00132_A580NgpDelData ;
      private bool[] BC00132_n580NgpDelData ;
      private DateTime[] BC00132_A581NgpDelHora ;
      private bool[] BC00132_n581NgpDelHora ;
      private string[] BC00132_A582NgpDelUsuId ;
      private bool[] BC00132_n582NgpDelUsuId ;
      private string[] BC00132_A583NgpDelUsuNome ;
      private bool[] BC00132_n583NgpDelUsuNome ;
      private string[] BC00132_A453NgpObs ;
      private bool[] BC00132_A578NgpDel ;
      private Guid[] BC00132_A439NgpTppPrdID ;
      private Guid[] BC00132_A478NgpTppID ;
      private string[] BC001371_A440NgpTppPrdCodigo ;
      private string[] BC001371_A441NgpTppPrdNome ;
      private bool[] BC001371_A443NgpTppPrdAtivo ;
      private int[] BC001371_A442NgpTppPrdTipoID ;
      private decimal[] BC001372_A444NgpTpp1Preco ;
      private decimal[] BC001373_A447NgpTotal ;
      private Guid[] BC001373_A345NegID ;
      private int[] BC001373_A435NgpItem ;
      private int[] BC001373_A446NgpQtde ;
      private DateTime[] BC001373_A457NgpInsDataHora ;
      private DateTime[] BC001373_A455NgpInsData ;
      private DateTime[] BC001373_A456NgpInsHora ;
      private string[] BC001373_A458NgpInsUsuID ;
      private bool[] BC001373_n458NgpInsUsuID ;
      private string[] BC001373_A459NgpInsUsuNome ;
      private bool[] BC001373_n459NgpInsUsuNome ;
      private decimal[] BC001373_A445NgpPreco ;
      private DateTime[] BC001373_A579NgpDelDataHora ;
      private bool[] BC001373_n579NgpDelDataHora ;
      private DateTime[] BC001373_A580NgpDelData ;
      private bool[] BC001373_n580NgpDelData ;
      private DateTime[] BC001373_A581NgpDelHora ;
      private bool[] BC001373_n581NgpDelHora ;
      private string[] BC001373_A582NgpDelUsuId ;
      private bool[] BC001373_n582NgpDelUsuId ;
      private string[] BC001373_A583NgpDelUsuNome ;
      private bool[] BC001373_n583NgpDelUsuNome ;
      private string[] BC001373_A440NgpTppPrdCodigo ;
      private string[] BC001373_A441NgpTppPrdNome ;
      private bool[] BC001373_A443NgpTppPrdAtivo ;
      private decimal[] BC001373_A444NgpTpp1Preco ;
      private string[] BC001373_A453NgpObs ;
      private bool[] BC001373_A578NgpDel ;
      private Guid[] BC001373_A439NgpTppPrdID ;
      private Guid[] BC001373_A478NgpTppID ;
      private int[] BC001373_A442NgpTppPrdTipoID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV28AuditingObject ;
   }

   public class negociopjestrutura_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class negociopjestrutura_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new UpdateCursor(def[40])
       ,new UpdateCursor(def[41])
       ,new UpdateCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new UpdateCursor(def[48])
       ,new UpdateCursor(def[49])
       ,new UpdateCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC001329;
        prmBC001329 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001310;
        prmBC001310 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001313;
        prmBC001313 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001316;
        prmBC001316 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001319;
        prmBC001319 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001327;
        prmBC001327 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001330;
        prmBC001330 = new Object[] {
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001322;
        prmBC001322 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001323;
        prmBC001323 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001325;
        prmBC001325 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmBC001324;
        prmBC001324 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001331;
        prmBC001331 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001321;
        prmBC001321 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001320;
        prmBC001320 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001332;
        prmBC001332 = new Object[] {
        new ParDef("NegCliNomeFamiliar",GXType.VarChar,80,0) ,
        new ParDef("NegCpjNomFan",GXType.VarChar,80,0) ,
        new ParDef("NegCpjRazSocial",GXType.VarChar,80,0) ,
        new ParDef("NegPjtNome",GXType.VarChar,80,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NegInsData",GXType.Date,8,0) ,
        new ParDef("NegInsHora",GXType.DateTime,0,5) ,
        new ParDef("NegInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NegDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NegDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NegDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAgcID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAssunto",GXType.VarChar,80,0) ,
        new ParDef("NegDescricao",GXType.LongVarChar,2097152,0) ,
        new ParDef("NegUltFase",GXType.Int32,8,0) ,
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegDel",GXType.Boolean,4,0) ,
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0) ,
        new ParDef("NegUltNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegUltIteID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("NegUltIteNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegUltIteOrdem",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC001333;
        prmBC001333 = new Object[] {
        new ParDef("NegCliNomeFamiliar",GXType.VarChar,80,0) ,
        new ParDef("NegCpjNomFan",GXType.VarChar,80,0) ,
        new ParDef("NegCpjRazSocial",GXType.VarChar,80,0) ,
        new ParDef("NegPjtNome",GXType.VarChar,80,0) ,
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NegInsData",GXType.Date,8,0) ,
        new ParDef("NegInsHora",GXType.DateTime,0,5) ,
        new ParDef("NegInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NegDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NegDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NegDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAgcID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAssunto",GXType.VarChar,80,0) ,
        new ParDef("NegDescricao",GXType.LongVarChar,2097152,0) ,
        new ParDef("NegUltFase",GXType.Int32,8,0) ,
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegDel",GXType.Boolean,4,0) ,
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0) ,
        new ParDef("NegUltNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegUltIteID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("NegUltIteNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegUltIteOrdem",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001334;
        prmBC001334 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001347;
        prmBC001347 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001348;
        prmBC001348 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001349;
        prmBC001349 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001350;
        prmBC001350 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmBC001351;
        prmBC001351 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001352;
        prmBC001352 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001353;
        prmBC001353 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001354;
        prmBC001354 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001336;
        prmBC001336 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001339;
        prmBC001339 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001342;
        prmBC001342 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001345;
        prmBC001345 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001355;
        prmBC001355 = new Object[] {
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegUltFase",GXType.Int32,8,0) ,
        new ParDef("NegUltIteOrdem",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("NegUltIteNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegUltIteID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("NegUltNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001357;
        prmBC001357 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001358;
        prmBC001358 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC00138;
        prmBC00138 = new Object[] {
        new ParDef("NgfIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001359;
        prmBC001359 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC00137;
        prmBC00137 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC00136;
        prmBC00136 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC001360;
        prmBC001360 = new Object[] {
        new ParDef("NgfIteNome",GXType.VarChar,80,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0) ,
        new ParDef("NgfInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgfInsData",GXType.Date,8,0) ,
        new ParDef("NgfInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgfInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgfInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgfDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgfDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NgfDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgfDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgfDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgfFimData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("NgfFimHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgfFimDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgfFimUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgfFimUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgfStatus",GXType.VarChar,5,0){Nullable=true} ,
        new ParDef("NgfDel",GXType.Boolean,4,0) ,
        new ParDef("NgfIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001361;
        prmBC001361 = new Object[] {
        new ParDef("NgfIteNome",GXType.VarChar,80,0) ,
        new ParDef("NgfInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgfInsData",GXType.Date,8,0) ,
        new ParDef("NgfInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgfInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgfInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgfDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgfDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NgfDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgfDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgfDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgfFimData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("NgfFimHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgfFimDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgfFimUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgfFimUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgfStatus",GXType.VarChar,5,0){Nullable=true} ,
        new ParDef("NgfDel",GXType.Boolean,4,0) ,
        new ParDef("NgfIteID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC001362;
        prmBC001362 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC001363;
        prmBC001363 = new Object[] {
        new ParDef("NgfIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001364;
        prmBC001364 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgfSeq",GXType.Int32,8,0)
        };
        Object[] prmBC001365;
        prmBC001365 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001366;
        prmBC001366 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC00135;
        prmBC00135 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00134;
        prmBC00134 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001367;
        prmBC001367 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC00133;
        prmBC00133 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC00132;
        prmBC00132 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC001368;
        prmBC001368 = new Object[] {
        new ParDef("NgpTotal",GXType.Number,16,2) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0) ,
        new ParDef("NgpQtde",GXType.Int32,8,0) ,
        new ParDef("NgpInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgpInsData",GXType.Date,8,0) ,
        new ParDef("NgpInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpPreco",GXType.Number,16,2) ,
        new ParDef("NgpDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgpDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NgpDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgpDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpObs",GXType.VarChar,1000,0) ,
        new ParDef("NgpDel",GXType.Boolean,4,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001369;
        prmBC001369 = new Object[] {
        new ParDef("NgpTotal",GXType.Number,16,2) ,
        new ParDef("NgpQtde",GXType.Int32,8,0) ,
        new ParDef("NgpInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgpInsData",GXType.Date,8,0) ,
        new ParDef("NgpInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpPreco",GXType.Number,16,2) ,
        new ParDef("NgpDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgpDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NgpDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgpDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpObs",GXType.VarChar,1000,0) ,
        new ParDef("NgpDel",GXType.Boolean,4,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC001370;
        prmBC001370 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC001371;
        prmBC001371 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001372;
        prmBC001372 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001373;
        prmBC001373 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00132", "SELECT NgpTotal, NegID, NgpItem, NgpQtde, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpPreco, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem  FOR UPDATE OF tb_negociopj_item",true, GxErrorMask.GX_NOMASK, false, this,prmBC00132,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00133", "SELECT NgpTotal, NegID, NgpItem, NgpQtde, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpPreco, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00133,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00134", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00134,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00135", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00135,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00136", "SELECT NegID, NgfSeq, NgfInsDataHora, NgfInsData, NgfInsHora, NgfInsUsuID, NgfInsUsuNome, NgfDelDataHora, NgfDelData, NgfDelHora, NgfDelUsuId, NgfDelUsuNome, NgfFimData, NgfFimHora, NgfFimDataHora, NgfFimUsuID, NgfFimUsuNome, NgfStatus, NgfDel, NgfIteID, NgfIteNome FROM tb_negociopj_fase WHERE NegID = :NegID AND NgfSeq = :NgfSeq  FOR UPDATE OF tb_negociopj_fase",true, GxErrorMask.GX_NOMASK, false, this,prmBC00136,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00137", "SELECT NegID, NgfSeq, NgfInsDataHora, NgfInsData, NgfInsHora, NgfInsUsuID, NgfInsUsuNome, NgfDelDataHora, NgfDelData, NgfDelHora, NgfDelUsuId, NgfDelUsuNome, NgfFimData, NgfFimHora, NgfFimDataHora, NgfFimUsuID, NgfFimUsuNome, NgfStatus, NgfDel, NgfIteID, NgfIteNome FROM tb_negociopj_fase WHERE NegID = :NegID AND NgfSeq = :NgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00137,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00138", "SELECT IteOrdem AS NgfIteOrdem, IteNome AS NgfIteNome FROM tb_Iteracao WHERE IteID = :NgfIteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00138,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001310", "SELECT COALESCE( T1.NegUltNgfSeq, 0) AS NegUltNgfSeq FROM (SELECT MAX(NgfSeq) AS NegUltNgfSeq, NegID FROM tb_negociopj_fase GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001313", "SELECT COALESCE( T1.NegUltIteID, '00000000-0000-0000-0000-000000000000') AS NegUltIteID FROM (SELECT MIN(T2.NgfIteID) AS NegUltIteID, T2.NegID FROM (tb_negociopj_fase T2 INNER JOIN (SELECT MAX(NgfSeq) AS GXC1, NegID FROM tb_negociopj_fase GROUP BY NegID ) T3 ON T3.NegID = T2.NegID) WHERE T2.NgfSeq = T3.GXC1 GROUP BY T2.NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001316", "SELECT COALESCE( T1.NegUltIteNome, '') AS NegUltIteNome FROM (SELECT MIN(T2.NgfIteNome) AS NegUltIteNome, T2.NegID FROM (tb_negociopj_fase T2 INNER JOIN (SELECT MAX(NgfSeq) AS GXC2, NegID FROM tb_negociopj_fase GROUP BY NegID ) T3 ON T3.NegID = T2.NegID) WHERE T2.NgfSeq = T3.GXC2 GROUP BY T2.NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001316,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001319", "SELECT COALESCE( T1.NegUltIteOrdem, 0) AS NegUltIteOrdem FROM (SELECT MIN(T4.IteOrdem) AS NegUltIteOrdem, T2.NegID FROM ((tb_negociopj_fase T2 INNER JOIN (SELECT MAX(T5.NgfSeq) AS GXC3, T5.NegID FROM (tb_negociopj_fase T5 INNER JOIN tb_Iteracao T6 ON T6.IteID = T5.NgfIteID) GROUP BY T5.NegID ) T3 ON T3.NegID = T2.NegID) INNER JOIN tb_Iteracao T4 ON T4.IteID = T2.NgfIteID) WHERE T2.NgfSeq = T3.GXC3 GROUP BY T2.NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001319,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001320", "SELECT NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorEstimado, NegValorAtualizado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltFase, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome FROM tb_negociopj WHERE NegID = :NegID  FOR UPDATE OF tb_negociopj",true, GxErrorMask.GX_NOMASK, false, this,prmBC001320,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001321", "SELECT NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorEstimado, NegValorAtualizado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltFase, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001321,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001322", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001322,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001323", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001323,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001324", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001324,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001325", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001325,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001327", "SELECT COALESCE( T1.NegPgpTotal, 0) AS NegPgpTotal FROM (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001327,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001329", "SELECT TM1.NegID, TM1.NegCodigo, TM1.NegInsDataHora, TM1.NegInsData, TM1.NegInsHora, TM1.NegInsUsuID, TM1.NegInsUsuNome, TM1.NegValorEstimado, TM1.NegValorAtualizado, TM1.NegDelDataHora, TM1.NegDelData, TM1.NegDelHora, TM1.NegDelUsuId, TM1.NegDelUsuNome, T3.CliMatricula AS NegCliMatricula, TM1.NegCliNomeFamiliar AS NegCliNomeFamiliar, TM1.NegCpjNomFan AS NegCpjNomFan, TM1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T5.PjtSigla AS NegPjtSigla, TM1.NegPjtNome AS NegPjtNome, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, TM1.NegAgcID, TM1.NegAgcNome, TM1.NegAssunto, TM1.NegDescricao, TM1.NegUltFase, TM1.NegUltItem, TM1.NegDel, TM1.NegCliID AS NegCliID, TM1.NegCpjID AS NegCpjID, TM1.NegCpjEndSeq AS NegCpjEndSeq, T4.CpjTipoId AS NegPjtID, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal FROM (((((tb_negociopj TM1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE TM1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = TM1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = TM1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = TM1.NegCliID AND T4.CpjID = TM1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = TM1.NegCliID AND T6.CpjID = TM1.NegCpjID AND T6.CpjEndSeq = TM1.NegCpjEndSeq) WHERE TM1.NegID = :NegID ORDER BY TM1.NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001329,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001330", "SELECT NegCodigo FROM tb_negociopj WHERE (NegCodigo = :NegCodigo) AND (Not ( NegID = :NegID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001330,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001331", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001331,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001332", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj(NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome, NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorEstimado, NegValorAtualizado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltFase, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegUltNgfSeq, NegUltIteID, NegUltIteNome, NegUltIteOrdem) VALUES(:NegCliNomeFamiliar, :NegCpjNomFan, :NegCpjRazSocial, :NegPjtNome, :NegID, :NegCodigo, :NegInsDataHora, :NegInsData, :NegInsHora, :NegInsUsuID, :NegInsUsuNome, :NegValorEstimado, :NegValorAtualizado, :NegDelDataHora, :NegDelData, :NegDelHora, :NegDelUsuId, :NegDelUsuNome, :NegAgcID, :NegAgcNome, :NegAssunto, :NegDescricao, :NegUltFase, :NegUltItem, :NegDel, :NegCliID, :NegCpjID, :NegCpjEndSeq, :NegUltNgfSeq, :NegUltIteID, :NegUltIteNome, :NegUltIteOrdem);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001332)
           ,new CursorDef("BC001333", "SAVEPOINT gxupdate;UPDATE tb_negociopj SET NegCliNomeFamiliar=:NegCliNomeFamiliar, NegCpjNomFan=:NegCpjNomFan, NegCpjRazSocial=:NegCpjRazSocial, NegPjtNome=:NegPjtNome, NegCodigo=:NegCodigo, NegInsDataHora=:NegInsDataHora, NegInsData=:NegInsData, NegInsHora=:NegInsHora, NegInsUsuID=:NegInsUsuID, NegInsUsuNome=:NegInsUsuNome, NegValorEstimado=:NegValorEstimado, NegValorAtualizado=:NegValorAtualizado, NegDelDataHora=:NegDelDataHora, NegDelData=:NegDelData, NegDelHora=:NegDelHora, NegDelUsuId=:NegDelUsuId, NegDelUsuNome=:NegDelUsuNome, NegAgcID=:NegAgcID, NegAgcNome=:NegAgcNome, NegAssunto=:NegAssunto, NegDescricao=:NegDescricao, NegUltFase=:NegUltFase, NegUltItem=:NegUltItem, NegDel=:NegDel, NegCliID=:NegCliID, NegCpjID=:NegCpjID, NegCpjEndSeq=:NegCpjEndSeq, NegUltNgfSeq=:NegUltNgfSeq, NegUltIteID=:NegUltIteID, NegUltIteNome=:NegUltIteNome, NegUltIteOrdem=:NegUltIteOrdem  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001333)
           ,new CursorDef("BC001334", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001334)
           ,new CursorDef("BC001336", "SELECT COALESCE( T1.NegUltNgfSeq, 0) AS NegUltNgfSeq FROM (SELECT MAX(NgfSeq) AS NegUltNgfSeq, NegID FROM tb_negociopj_fase GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001336,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001339", "SELECT COALESCE( T1.NegUltIteID, '00000000-0000-0000-0000-000000000000') AS NegUltIteID FROM (SELECT MIN(T2.NgfIteID) AS NegUltIteID, T2.NegID FROM (tb_negociopj_fase T2 INNER JOIN (SELECT MAX(NgfSeq) AS GXC1, NegID FROM tb_negociopj_fase GROUP BY NegID ) T3 ON T3.NegID = T2.NegID) WHERE T2.NgfSeq = T3.GXC1 GROUP BY T2.NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001339,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001342", "SELECT COALESCE( T1.NegUltIteNome, '') AS NegUltIteNome FROM (SELECT MIN(T2.NgfIteNome) AS NegUltIteNome, T2.NegID FROM (tb_negociopj_fase T2 INNER JOIN (SELECT MAX(NgfSeq) AS GXC2, NegID FROM tb_negociopj_fase GROUP BY NegID ) T3 ON T3.NegID = T2.NegID) WHERE T2.NgfSeq = T3.GXC2 GROUP BY T2.NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001342,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001345", "SELECT COALESCE( T1.NegUltIteOrdem, 0) AS NegUltIteOrdem FROM (SELECT MIN(T4.IteOrdem) AS NegUltIteOrdem, T2.NegID FROM ((tb_negociopj_fase T2 INNER JOIN (SELECT MAX(T5.NgfSeq) AS GXC3, T5.NegID FROM (tb_negociopj_fase T5 INNER JOIN tb_Iteracao T6 ON T6.IteID = T5.NgfIteID) GROUP BY T5.NegID ) T3 ON T3.NegID = T2.NegID) INNER JOIN tb_Iteracao T4 ON T4.IteID = T2.NgfIteID) WHERE T2.NgfSeq = T3.GXC3 GROUP BY T2.NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001345,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001347", "SELECT COALESCE( T1.NegPgpTotal, 0) AS NegPgpTotal FROM (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001347,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001348", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001348,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001349", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001349,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001350", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001350,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001351", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001351,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001352", "SELECT VisID FROM tb_visita WHERE VisNegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001352,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001353", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001353,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001354", "SELECT VisID FROM tb_visita WHERE VisNegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001354,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001355", "SAVEPOINT gxupdate;UPDATE tb_negociopj SET NegUltItem=:NegUltItem, NegValorEstimado=:NegValorEstimado, NegValorAtualizado=:NegValorAtualizado, NegUltFase=:NegUltFase, NegUltIteOrdem=:NegUltIteOrdem, NegUltIteNome=:NegUltIteNome, NegUltIteID=:NegUltIteID, NegUltNgfSeq=:NegUltNgfSeq  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001355)
           ,new CursorDef("BC001357", "SELECT TM1.NegID, TM1.NegCodigo, TM1.NegInsDataHora, TM1.NegInsData, TM1.NegInsHora, TM1.NegInsUsuID, TM1.NegInsUsuNome, TM1.NegValorEstimado, TM1.NegValorAtualizado, TM1.NegDelDataHora, TM1.NegDelData, TM1.NegDelHora, TM1.NegDelUsuId, TM1.NegDelUsuNome, T3.CliMatricula AS NegCliMatricula, TM1.NegCliNomeFamiliar AS NegCliNomeFamiliar, TM1.NegCpjNomFan AS NegCpjNomFan, TM1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T5.PjtSigla AS NegPjtSigla, TM1.NegPjtNome AS NegPjtNome, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, TM1.NegAgcID, TM1.NegAgcNome, TM1.NegAssunto, TM1.NegDescricao, TM1.NegUltFase, TM1.NegUltItem, TM1.NegDel, TM1.NegCliID AS NegCliID, TM1.NegCpjID AS NegCpjID, TM1.NegCpjEndSeq AS NegCpjEndSeq, T4.CpjTipoId AS NegPjtID, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal FROM (((((tb_negociopj TM1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE TM1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = TM1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = TM1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = TM1.NegCliID AND T4.CpjID = TM1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = TM1.NegCliID AND T6.CpjID = TM1.NegCpjID AND T6.CpjEndSeq = TM1.NegCpjEndSeq) WHERE TM1.NegID = :NegID ORDER BY TM1.NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001357,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001358", "SELECT T1.NegID, T1.NgfSeq, T1.NgfInsDataHora, T1.NgfInsData, T1.NgfInsHora, T1.NgfInsUsuID, T1.NgfInsUsuNome, T1.NgfDelDataHora, T1.NgfDelData, T1.NgfDelHora, T1.NgfDelUsuId, T1.NgfDelUsuNome, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfFimData, T1.NgfFimHora, T1.NgfFimDataHora, T1.NgfFimUsuID, T1.NgfFimUsuNome, T1.NgfStatus, T1.NgfDel, T1.NgfIteID AS NgfIteID FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :NegID and T1.NgfSeq = :NgfSeq ORDER BY T1.NegID, T1.NgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001358,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001359", "SELECT NegID, NgfSeq FROM tb_negociopj_fase WHERE NegID = :NegID AND NgfSeq = :NgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001359,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001360", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj_fase(NgfIteNome, NegID, NgfSeq, NgfInsDataHora, NgfInsData, NgfInsHora, NgfInsUsuID, NgfInsUsuNome, NgfDelDataHora, NgfDelData, NgfDelHora, NgfDelUsuId, NgfDelUsuNome, NgfFimData, NgfFimHora, NgfFimDataHora, NgfFimUsuID, NgfFimUsuNome, NgfStatus, NgfDel, NgfIteID) VALUES(:NgfIteNome, :NegID, :NgfSeq, :NgfInsDataHora, :NgfInsData, :NgfInsHora, :NgfInsUsuID, :NgfInsUsuNome, :NgfDelDataHora, :NgfDelData, :NgfDelHora, :NgfDelUsuId, :NgfDelUsuNome, :NgfFimData, :NgfFimHora, :NgfFimDataHora, :NgfFimUsuID, :NgfFimUsuNome, :NgfStatus, :NgfDel, :NgfIteID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001360)
           ,new CursorDef("BC001361", "SAVEPOINT gxupdate;UPDATE tb_negociopj_fase SET NgfIteNome=:NgfIteNome, NgfInsDataHora=:NgfInsDataHora, NgfInsData=:NgfInsData, NgfInsHora=:NgfInsHora, NgfInsUsuID=:NgfInsUsuID, NgfInsUsuNome=:NgfInsUsuNome, NgfDelDataHora=:NgfDelDataHora, NgfDelData=:NgfDelData, NgfDelHora=:NgfDelHora, NgfDelUsuId=:NgfDelUsuId, NgfDelUsuNome=:NgfDelUsuNome, NgfFimData=:NgfFimData, NgfFimHora=:NgfFimHora, NgfFimDataHora=:NgfFimDataHora, NgfFimUsuID=:NgfFimUsuID, NgfFimUsuNome=:NgfFimUsuNome, NgfStatus=:NgfStatus, NgfDel=:NgfDel, NgfIteID=:NgfIteID  WHERE NegID = :NegID AND NgfSeq = :NgfSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001361)
           ,new CursorDef("BC001362", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj_fase  WHERE NegID = :NegID AND NgfSeq = :NgfSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001362)
           ,new CursorDef("BC001363", "SELECT IteOrdem AS NgfIteOrdem, IteNome AS NgfIteNome FROM tb_Iteracao WHERE IteID = :NgfIteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001363,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001364", "SELECT VisID FROM tb_visita WHERE VisNegID = :NegID AND VisNgfSeq = :NgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001364,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001365", "SELECT T1.NegID, T1.NgfSeq, T1.NgfInsDataHora, T1.NgfInsData, T1.NgfInsHora, T1.NgfInsUsuID, T1.NgfInsUsuNome, T1.NgfDelDataHora, T1.NgfDelData, T1.NgfDelHora, T1.NgfDelUsuId, T1.NgfDelUsuNome, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfFimData, T1.NgfFimHora, T1.NgfFimDataHora, T1.NgfFimUsuID, T1.NgfFimUsuNome, T1.NgfStatus, T1.NgfDel, T1.NgfIteID AS NgfIteID FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :NegID ORDER BY T1.NegID, T1.NgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001365,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001366", "SELECT T1.NgpTotal, T1.NegID, T1.NgpItem, T1.NgpQtde, T1.NgpInsDataHora, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpPreco, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpObs, T1.NgpDel, T1.NgpTppPrdID AS NgpTppPrdID, T1.NgpTppID AS NgpTppID, T2.PrdTipoID AS NgpTppPrdTipoID FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID and T1.NgpItem = :NgpItem ORDER BY T1.NegID, T1.NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001366,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001367", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001367,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001368", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj_item(NgpTotal, NegID, NgpItem, NgpQtde, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpPreco, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID) VALUES(:NgpTotal, :NegID, :NgpItem, :NgpQtde, :NgpInsDataHora, :NgpInsData, :NgpInsHora, :NgpInsUsuID, :NgpInsUsuNome, :NgpPreco, :NgpDelDataHora, :NgpDelData, :NgpDelHora, :NgpDelUsuId, :NgpDelUsuNome, :NgpObs, :NgpDel, :NgpTppPrdID, :NgpTppID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001368)
           ,new CursorDef("BC001369", "SAVEPOINT gxupdate;UPDATE tb_negociopj_item SET NgpTotal=:NgpTotal, NgpQtde=:NgpQtde, NgpInsDataHora=:NgpInsDataHora, NgpInsData=:NgpInsData, NgpInsHora=:NgpInsHora, NgpInsUsuID=:NgpInsUsuID, NgpInsUsuNome=:NgpInsUsuNome, NgpPreco=:NgpPreco, NgpDelDataHora=:NgpDelDataHora, NgpDelData=:NgpDelData, NgpDelHora=:NgpDelHora, NgpDelUsuId=:NgpDelUsuId, NgpDelUsuNome=:NgpDelUsuNome, NgpObs=:NgpObs, NgpDel=:NgpDel, NgpTppPrdID=:NgpTppPrdID, NgpTppID=:NgpTppID  WHERE NegID = :NegID AND NgpItem = :NgpItem;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001369)
           ,new CursorDef("BC001370", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj_item  WHERE NegID = :NegID AND NgpItem = :NgpItem;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001370)
           ,new CursorDef("BC001371", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001371,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001372", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001372,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001373", "SELECT T1.NgpTotal, T1.NegID, T1.NgpItem, T1.NgpQtde, T1.NgpInsDataHora, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpPreco, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpObs, T1.NgpDel, T1.NgpTppPrdID AS NgpTppPrdID, T1.NgpTppID AS NgpTppID, T2.PrdTipoID AS NgpTppPrdTipoID FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID, T1.NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001373,11, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((bool[]) buf[23])[0] = rslt.getBool(17);
              ((Guid[]) buf[24])[0] = rslt.getGuid(18);
              ((Guid[]) buf[25])[0] = rslt.getGuid(19);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((bool[]) buf[23])[0] = rslt.getBool(17);
              ((Guid[]) buf[24])[0] = rslt.getGuid(18);
              ((Guid[]) buf[25])[0] = rslt.getGuid(19);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getString(16, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((string[]) buf[27])[0] = rslt.getVarchar(17);
              ((bool[]) buf[28])[0] = rslt.wasNull(17);
              ((string[]) buf[29])[0] = rslt.getVarchar(18);
              ((bool[]) buf[30])[0] = rslt.wasNull(18);
              ((bool[]) buf[31])[0] = rslt.getBool(19);
              ((Guid[]) buf[32])[0] = rslt.getGuid(20);
              ((string[]) buf[33])[0] = rslt.getVarchar(21);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getString(16, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((string[]) buf[27])[0] = rslt.getVarchar(17);
              ((bool[]) buf[28])[0] = rslt.wasNull(17);
              ((string[]) buf[29])[0] = rslt.getVarchar(18);
              ((bool[]) buf[30])[0] = rslt.wasNull(18);
              ((bool[]) buf[31])[0] = rslt.getBool(19);
              ((Guid[]) buf[32])[0] = rslt.getGuid(20);
              ((string[]) buf[33])[0] = rslt.getVarchar(21);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((string[]) buf[26])[0] = rslt.getLongVarchar(18);
              ((int[]) buf[27])[0] = rslt.getInt(19);
              ((int[]) buf[28])[0] = rslt.getInt(20);
              ((bool[]) buf[29])[0] = rslt.wasNull(20);
              ((bool[]) buf[30])[0] = rslt.getBool(21);
              ((Guid[]) buf[31])[0] = rslt.getGuid(22);
              ((Guid[]) buf[32])[0] = rslt.getGuid(23);
              ((short[]) buf[33])[0] = rslt.getShort(24);
              ((string[]) buf[34])[0] = rslt.getVarchar(25);
              ((string[]) buf[35])[0] = rslt.getVarchar(26);
              ((string[]) buf[36])[0] = rslt.getVarchar(27);
              ((string[]) buf[37])[0] = rslt.getVarchar(28);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((string[]) buf[26])[0] = rslt.getLongVarchar(18);
              ((int[]) buf[27])[0] = rslt.getInt(19);
              ((int[]) buf[28])[0] = rslt.getInt(20);
              ((bool[]) buf[29])[0] = rslt.wasNull(20);
              ((bool[]) buf[30])[0] = rslt.getBool(21);
              ((Guid[]) buf[31])[0] = rslt.getGuid(22);
              ((Guid[]) buf[32])[0] = rslt.getGuid(23);
              ((short[]) buf[33])[0] = rslt.getShort(24);
              ((string[]) buf[34])[0] = rslt.getVarchar(25);
              ((string[]) buf[35])[0] = rslt.getVarchar(26);
              ((string[]) buf[36])[0] = rslt.getVarchar(27);
              ((string[]) buf[37])[0] = rslt.getVarchar(28);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((long[]) buf[21])[0] = rslt.getLong(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((string[]) buf[23])[0] = rslt.getVarchar(17);
              ((string[]) buf[24])[0] = rslt.getVarchar(18);
              ((long[]) buf[25])[0] = rslt.getLong(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((string[]) buf[27])[0] = rslt.getVarchar(21);
              ((string[]) buf[28])[0] = rslt.getVarchar(22);
              ((string[]) buf[29])[0] = rslt.getVarchar(23);
              ((string[]) buf[30])[0] = rslt.getVarchar(24);
              ((string[]) buf[31])[0] = rslt.getVarchar(25);
              ((bool[]) buf[32])[0] = rslt.wasNull(25);
              ((string[]) buf[33])[0] = rslt.getVarchar(26);
              ((int[]) buf[34])[0] = rslt.getInt(27);
              ((string[]) buf[35])[0] = rslt.getVarchar(28);
              ((short[]) buf[36])[0] = rslt.getShort(29);
              ((string[]) buf[37])[0] = rslt.getVarchar(30);
              ((string[]) buf[38])[0] = rslt.getVarchar(31);
              ((string[]) buf[39])[0] = rslt.getString(32, 40);
              ((bool[]) buf[40])[0] = rslt.wasNull(32);
              ((string[]) buf[41])[0] = rslt.getVarchar(33);
              ((bool[]) buf[42])[0] = rslt.wasNull(33);
              ((string[]) buf[43])[0] = rslt.getVarchar(34);
              ((string[]) buf[44])[0] = rslt.getLongVarchar(35);
              ((int[]) buf[45])[0] = rslt.getInt(36);
              ((int[]) buf[46])[0] = rslt.getInt(37);
              ((bool[]) buf[47])[0] = rslt.wasNull(37);
              ((bool[]) buf[48])[0] = rslt.getBool(38);
              ((Guid[]) buf[49])[0] = rslt.getGuid(39);
              ((Guid[]) buf[50])[0] = rslt.getGuid(40);
              ((short[]) buf[51])[0] = rslt.getShort(41);
              ((int[]) buf[52])[0] = rslt.getInt(42);
              ((decimal[]) buf[53])[0] = rslt.getDecimal(43);
              ((bool[]) buf[54])[0] = rslt.wasNull(43);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 25 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 27 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 28 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              return;
           case 33 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 34 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 35 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 37 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((long[]) buf[21])[0] = rslt.getLong(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((string[]) buf[23])[0] = rslt.getVarchar(17);
              ((string[]) buf[24])[0] = rslt.getVarchar(18);
              ((long[]) buf[25])[0] = rslt.getLong(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((string[]) buf[27])[0] = rslt.getVarchar(21);
              ((string[]) buf[28])[0] = rslt.getVarchar(22);
              ((string[]) buf[29])[0] = rslt.getVarchar(23);
              ((string[]) buf[30])[0] = rslt.getVarchar(24);
              ((string[]) buf[31])[0] = rslt.getVarchar(25);
              ((bool[]) buf[32])[0] = rslt.wasNull(25);
              ((string[]) buf[33])[0] = rslt.getVarchar(26);
              ((int[]) buf[34])[0] = rslt.getInt(27);
              ((string[]) buf[35])[0] = rslt.getVarchar(28);
              ((short[]) buf[36])[0] = rslt.getShort(29);
              ((string[]) buf[37])[0] = rslt.getVarchar(30);
              ((string[]) buf[38])[0] = rslt.getVarchar(31);
              ((string[]) buf[39])[0] = rslt.getString(32, 40);
              ((bool[]) buf[40])[0] = rslt.wasNull(32);
              ((string[]) buf[41])[0] = rslt.getVarchar(33);
              ((bool[]) buf[42])[0] = rslt.wasNull(33);
              ((string[]) buf[43])[0] = rslt.getVarchar(34);
              ((string[]) buf[44])[0] = rslt.getLongVarchar(35);
              ((int[]) buf[45])[0] = rslt.getInt(36);
              ((int[]) buf[46])[0] = rslt.getInt(37);
              ((bool[]) buf[47])[0] = rslt.wasNull(37);
              ((bool[]) buf[48])[0] = rslt.getBool(38);
              ((Guid[]) buf[49])[0] = rslt.getGuid(39);
              ((Guid[]) buf[50])[0] = rslt.getGuid(40);
              ((short[]) buf[51])[0] = rslt.getShort(41);
              ((int[]) buf[52])[0] = rslt.getInt(42);
              ((decimal[]) buf[53])[0] = rslt.getDecimal(43);
              ((bool[]) buf[54])[0] = rslt.wasNull(43);
              return;
           case 38 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((int[]) buf[19])[0] = rslt.getInt(13);
              ((string[]) buf[20])[0] = rslt.getVarchar(14);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getString(18, 40);
              ((bool[]) buf[28])[0] = rslt.wasNull(18);
              ((string[]) buf[29])[0] = rslt.getVarchar(19);
              ((bool[]) buf[30])[0] = rslt.wasNull(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((bool[]) buf[33])[0] = rslt.getBool(21);
              ((Guid[]) buf[34])[0] = rslt.getGuid(22);
              return;
           case 39 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 43 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 44 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 45 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((int[]) buf[19])[0] = rslt.getInt(13);
              ((string[]) buf[20])[0] = rslt.getVarchar(14);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getString(18, 40);
              ((bool[]) buf[28])[0] = rslt.wasNull(18);
              ((string[]) buf[29])[0] = rslt.getVarchar(19);
              ((bool[]) buf[30])[0] = rslt.wasNull(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((bool[]) buf[33])[0] = rslt.getBool(21);
              ((Guid[]) buf[34])[0] = rslt.getGuid(22);
              return;
           case 46 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((string[]) buf[23])[0] = rslt.getVarchar(17);
              ((bool[]) buf[24])[0] = rslt.getBool(18);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((bool[]) buf[27])[0] = rslt.getBool(21);
              ((Guid[]) buf[28])[0] = rslt.getGuid(22);
              ((Guid[]) buf[29])[0] = rslt.getGuid(23);
              ((int[]) buf[30])[0] = rslt.getInt(24);
              return;
           case 47 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 52 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 53 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((string[]) buf[23])[0] = rslt.getVarchar(17);
              ((bool[]) buf[24])[0] = rslt.getBool(18);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((bool[]) buf[27])[0] = rslt.getBool(21);
              ((Guid[]) buf[28])[0] = rslt.getGuid(22);
              ((Guid[]) buf[29])[0] = rslt.getGuid(23);
              ((int[]) buf[30])[0] = rslt.getInt(24);
              return;
     }
  }

}

}
