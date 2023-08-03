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
   public class negociopj_bc : GxSilentTrn, IGxSilentTrn
   {
      public negociopj_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopj_bc( IGxContext context )
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
         ReadRow0Y37( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Y37( ) ;
         standaloneModal( ) ;
         AddRow0Y37( ) ;
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
            E110Y2 ();
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

      protected void CONFIRM_0Y0( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Y37( ) ;
            }
            else
            {
               CheckExtendedTable0Y37( ) ;
               if ( AnyError == 0 )
               {
                  ZM0Y37( 56) ;
                  ZM0Y37( 57) ;
                  ZM0Y37( 58) ;
                  ZM0Y37( 59) ;
                  ZM0Y37( 60) ;
               }
               CloseExtendedTableCursors0Y37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode37 = Gx_mode;
            CONFIRM_0Y42( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode37;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode37;
         }
      }

      protected void CONFIRM_0Y42( )
      {
         s454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         s448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < bccore_NegocioPJ.gxTpr_Item.Count )
         {
            ReadRow0Y42( ) ;
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
               GetKey0Y42( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound42 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Y42( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Y42( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0Y42( 62) ;
                           ZM0Y42( 63) ;
                        }
                        CloseExtendedTableCursors0Y42( ) ;
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
                        getByPrimaryKey0Y42( ) ;
                        Load0Y42( ) ;
                        BeforeValidate0Y42( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Y42( ) ;
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
                           BeforeValidate0Y42( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Y42( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0Y42( 62) ;
                                 ZM0Y42( 63) ;
                              }
                              CloseExtendedTableCursors0Y42( ) ;
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
               VarsToRow42( ((GeneXus.Programs.core.SdtNegocioPJ_Item)bccore_NegocioPJ.gxTpr_Item.Item(nGXsfl_42_idx))) ;
            }
         }
         O454NegUltItem = s454NegUltItem;
         n454NegUltItem = false;
         O448NegPgpTotal = s448NegPgpTotal;
         n448NegPgpTotal = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new prcdebugtofile(context ).execute(  AV49Pgmname,  StringUtil.Format( "Event Start - &Mode: %1 e &NegID: %2", Gx_mode, AV7NegID.ToString(), "", "", "", "", "", "", "")) ;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV49Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV50GXV1 = 1;
            while ( AV50GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV50GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "NegCliID") == 0 )
               {
                  AV13Insert_NegCliID = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "NegCpjID") == 0 )
               {
                  AV14Insert_NegCpjID = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "NegCpjEndSeq") == 0 )
               {
                  AV28Insert_NegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV50GXV1 = (int)(AV50GXV1+1);
            }
         }
      }

      protected void E110Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV47AuditingObject,  AV49Pgmname) ;
      }

      protected void ZM0Y37( short GX_JID )
      {
         if ( ( GX_JID == 54 ) || ( GX_JID == 0 ) )
         {
            Z356NegCodigo = A356NegCodigo;
            Z348NegInsDataHora = A348NegInsDataHora;
            Z346NegInsData = A346NegInsData;
            Z347NegInsHora = A347NegInsHora;
            Z349NegInsUsuID = A349NegInsUsuID;
            Z364NegInsUsuNome = A364NegInsUsuNome;
            Z385NegValorAtualizado = A385NegValorAtualizado;
            Z380NegValorEstimado = A380NegValorEstimado;
            Z573NegDelDataHora = A573NegDelDataHora;
            Z574NegDelData = A574NegDelData;
            Z575NegDelHora = A575NegDelHora;
            Z576NegDelUsuId = A576NegDelUsuId;
            Z577NegDelUsuNome = A577NegDelUsuNome;
            Z360NegAgcID = A360NegAgcID;
            Z361NegAgcNome = A361NegAgcNome;
            Z362NegAssunto = A362NegAssunto;
            Z454NegUltItem = A454NegUltItem;
            Z572NegDel = A572NegDel;
            Z350NegCliID = A350NegCliID;
            Z352NegCpjID = A352NegCpjID;
            Z369NegCpjEndSeq = A369NegCpjEndSeq;
            Z641NegCpjEndCompleto = A641NegCpjEndCompleto;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 56 ) || ( GX_JID == 0 ) )
         {
            Z473NegCliMatricula = A473NegCliMatricula;
            Z351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            Z641NegCpjEndCompleto = A641NegCpjEndCompleto;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 57 ) || ( GX_JID == 0 ) )
         {
            Z353NegCpjNomFan = A353NegCpjNomFan;
            Z354NegCpjRazSocial = A354NegCpjRazSocial;
            Z355NegCpjMatricula = A355NegCpjMatricula;
            Z357NegPjtID = A357NegPjtID;
            Z641NegCpjEndCompleto = A641NegCpjEndCompleto;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 58 ) || ( GX_JID == 0 ) )
         {
            Z370NegCpjEndNome = A370NegCpjEndNome;
            Z371NegCpjEndEndereco = A371NegCpjEndEndereco;
            Z372NegCpjEndNumero = A372NegCpjEndNumero;
            Z373NegCpjEndComplem = A373NegCpjEndComplem;
            Z374NegCpjEndBairro = A374NegCpjEndBairro;
            Z642NegCpjEndCep = A642NegCpjEndCep;
            Z643NegCpjEndCepFormat = A643NegCpjEndCepFormat;
            Z375NegCpjEndMunID = A375NegCpjEndMunID;
            Z376NegCpjEndMunNome = A376NegCpjEndMunNome;
            Z377NegCpjEndUFID = A377NegCpjEndUFID;
            Z378NegCpjEndUFSigla = A378NegCpjEndUFSigla;
            Z379NegCpjEndUFNome = A379NegCpjEndUFNome;
            Z641NegCpjEndCompleto = A641NegCpjEndCompleto;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 59 ) || ( GX_JID == 0 ) )
         {
            Z358NegPjtSigla = A358NegPjtSigla;
            Z359NegPjtNome = A359NegPjtNome;
            Z641NegCpjEndCompleto = A641NegCpjEndCompleto;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( ( GX_JID == 60 ) || ( GX_JID == 0 ) )
         {
            Z641NegCpjEndCompleto = A641NegCpjEndCompleto;
            Z448NegPgpTotal = A448NegPgpTotal;
         }
         if ( GX_JID == -54 )
         {
            Z345NegID = A345NegID;
            Z356NegCodigo = A356NegCodigo;
            Z348NegInsDataHora = A348NegInsDataHora;
            Z346NegInsData = A346NegInsData;
            Z347NegInsHora = A347NegInsHora;
            Z349NegInsUsuID = A349NegInsUsuID;
            Z364NegInsUsuNome = A364NegInsUsuNome;
            Z385NegValorAtualizado = A385NegValorAtualizado;
            Z380NegValorEstimado = A380NegValorEstimado;
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
            Z642NegCpjEndCep = A642NegCpjEndCep;
            Z643NegCpjEndCepFormat = A643NegCpjEndCepFormat;
            Z375NegCpjEndMunID = A375NegCpjEndMunID;
            Z376NegCpjEndMunNome = A376NegCpjEndMunNome;
            Z377NegCpjEndUFID = A377NegCpjEndUFID;
            Z378NegCpjEndUFSigla = A378NegCpjEndUFSigla;
            Z379NegCpjEndUFNome = A379NegCpjEndUFNome;
         }
      }

      protected void standaloneNotModal( )
      {
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
            /* Using cursor BC000Y13 */
            pr_default.execute(10, new Object[] {A345NegID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               A448NegPgpTotal = BC000Y13_A448NegPgpTotal[0];
               n448NegPgpTotal = BC000Y13_n448NegPgpTotal[0];
            }
            else
            {
               A448NegPgpTotal = 0;
               n448NegPgpTotal = false;
            }
            O448NegPgpTotal = A448NegPgpTotal;
            n448NegPgpTotal = false;
            pr_default.close(10);
            A385NegValorAtualizado = A448NegPgpTotal;
            A380NegValorEstimado = A448NegPgpTotal;
         }
      }

      protected void Load0Y37( )
      {
         /* Using cursor BC000Y15 */
         pr_default.execute(11, new Object[] {A345NegID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound37 = 1;
            A356NegCodigo = BC000Y15_A356NegCodigo[0];
            A348NegInsDataHora = BC000Y15_A348NegInsDataHora[0];
            A346NegInsData = BC000Y15_A346NegInsData[0];
            A347NegInsHora = BC000Y15_A347NegInsHora[0];
            A349NegInsUsuID = BC000Y15_A349NegInsUsuID[0];
            n349NegInsUsuID = BC000Y15_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC000Y15_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC000Y15_n364NegInsUsuNome[0];
            A385NegValorAtualizado = BC000Y15_A385NegValorAtualizado[0];
            A380NegValorEstimado = BC000Y15_A380NegValorEstimado[0];
            A573NegDelDataHora = BC000Y15_A573NegDelDataHora[0];
            n573NegDelDataHora = BC000Y15_n573NegDelDataHora[0];
            A574NegDelData = BC000Y15_A574NegDelData[0];
            n574NegDelData = BC000Y15_n574NegDelData[0];
            A575NegDelHora = BC000Y15_A575NegDelHora[0];
            n575NegDelHora = BC000Y15_n575NegDelHora[0];
            A576NegDelUsuId = BC000Y15_A576NegDelUsuId[0];
            n576NegDelUsuId = BC000Y15_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC000Y15_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC000Y15_n577NegDelUsuNome[0];
            A473NegCliMatricula = BC000Y15_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC000Y15_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = BC000Y15_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC000Y15_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC000Y15_A355NegCpjMatricula[0];
            A358NegPjtSigla = BC000Y15_A358NegPjtSigla[0];
            A359NegPjtNome = BC000Y15_A359NegPjtNome[0];
            A370NegCpjEndNome = BC000Y15_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC000Y15_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC000Y15_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC000Y15_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC000Y15_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC000Y15_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = BC000Y15_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = BC000Y15_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = BC000Y15_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC000Y15_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC000Y15_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC000Y15_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC000Y15_A379NegCpjEndUFNome[0];
            A360NegAgcID = BC000Y15_A360NegAgcID[0];
            n360NegAgcID = BC000Y15_n360NegAgcID[0];
            A361NegAgcNome = BC000Y15_A361NegAgcNome[0];
            n361NegAgcNome = BC000Y15_n361NegAgcNome[0];
            A362NegAssunto = BC000Y15_A362NegAssunto[0];
            A363NegDescricao = BC000Y15_A363NegDescricao[0];
            A454NegUltItem = BC000Y15_A454NegUltItem[0];
            n454NegUltItem = BC000Y15_n454NegUltItem[0];
            A572NegDel = BC000Y15_A572NegDel[0];
            A350NegCliID = BC000Y15_A350NegCliID[0];
            A352NegCpjID = BC000Y15_A352NegCpjID[0];
            A369NegCpjEndSeq = BC000Y15_A369NegCpjEndSeq[0];
            A357NegPjtID = BC000Y15_A357NegPjtID[0];
            A448NegPgpTotal = BC000Y15_A448NegPgpTotal[0];
            n448NegPgpTotal = BC000Y15_n448NegPgpTotal[0];
            ZM0Y37( -54) ;
         }
         pr_default.close(11);
         OnLoadActions0Y37( ) ;
      }

      protected void OnLoadActions0Y37( )
      {
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         AV49Pgmname = "core.NegocioPJ_BC";
         A385NegValorAtualizado = A448NegPgpTotal;
         A380NegValorEstimado = A448NegPgpTotal;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
         {
            A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
               else
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
            }
         }
      }

      protected void CheckExtendedTable0Y37( )
      {
         nIsDirty_37 = 0;
         standaloneModal( ) ;
         AV49Pgmname = "core.NegocioPJ_BC";
         /* Using cursor BC000Y13 */
         pr_default.execute(10, new Object[] {A345NegID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A448NegPgpTotal = BC000Y13_A448NegPgpTotal[0];
            n448NegPgpTotal = BC000Y13_n448NegPgpTotal[0];
         }
         else
         {
            nIsDirty_37 = 1;
            A448NegPgpTotal = 0;
            n448NegPgpTotal = false;
         }
         pr_default.close(10);
         nIsDirty_37 = 1;
         A385NegValorAtualizado = A448NegPgpTotal;
         nIsDirty_37 = 1;
         A380NegValorEstimado = A448NegPgpTotal;
         /* Using cursor BC000Y16 */
         pr_default.execute(12, new Object[] {A356NegCodigo, A345NegID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código da Negociação"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(12);
         /* Using cursor BC000Y8 */
         pr_default.execute(6, new Object[] {A350NegCliID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCLIID");
            AnyError = 1;
         }
         A473NegCliMatricula = BC000Y8_A473NegCliMatricula[0];
         A351NegCliNomeFamiliar = BC000Y8_A351NegCliNomeFamiliar[0];
         pr_default.close(6);
         /* Using cursor BC000Y9 */
         pr_default.execute(7, new Object[] {A350NegCliID, A352NegCpjID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJID");
            AnyError = 1;
         }
         A353NegCpjNomFan = BC000Y9_A353NegCpjNomFan[0];
         A354NegCpjRazSocial = BC000Y9_A354NegCpjRazSocial[0];
         A355NegCpjMatricula = BC000Y9_A355NegCpjMatricula[0];
         A357NegPjtID = BC000Y9_A357NegPjtID[0];
         pr_default.close(7);
         /* Using cursor BC000Y11 */
         pr_default.execute(9, new Object[] {A357NegPjtID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "NEGPJTID");
            AnyError = 1;
         }
         A358NegPjtSigla = BC000Y11_A358NegPjtSigla[0];
         A359NegPjtNome = BC000Y11_A359NegPjtNome[0];
         pr_default.close(9);
         /* Using cursor BC000Y10 */
         pr_default.execute(8, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJENDSEQ");
            AnyError = 1;
         }
         A370NegCpjEndNome = BC000Y10_A370NegCpjEndNome[0];
         A371NegCpjEndEndereco = BC000Y10_A371NegCpjEndEndereco[0];
         A372NegCpjEndNumero = BC000Y10_A372NegCpjEndNumero[0];
         A373NegCpjEndComplem = BC000Y10_A373NegCpjEndComplem[0];
         n373NegCpjEndComplem = BC000Y10_n373NegCpjEndComplem[0];
         A374NegCpjEndBairro = BC000Y10_A374NegCpjEndBairro[0];
         A642NegCpjEndCep = BC000Y10_A642NegCpjEndCep[0];
         A643NegCpjEndCepFormat = BC000Y10_A643NegCpjEndCepFormat[0];
         A375NegCpjEndMunID = BC000Y10_A375NegCpjEndMunID[0];
         A376NegCpjEndMunNome = BC000Y10_A376NegCpjEndMunNome[0];
         A377NegCpjEndUFID = BC000Y10_A377NegCpjEndUFID[0];
         A378NegCpjEndUFSigla = BC000Y10_A378NegCpjEndUFSigla[0];
         A379NegCpjEndUFNome = BC000Y10_A379NegCpjEndUFNome[0];
         pr_default.close(8);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
         {
            nIsDirty_37 = 1;
            A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               nIsDirty_37 = 1;
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  nIsDirty_37 = 1;
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
               else
               {
                  nIsDirty_37 = 1;
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
            }
         }
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

      protected void CloseExtendedTableCursors0Y37( )
      {
         pr_default.close(10);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Y37( )
      {
         /* Using cursor BC000Y17 */
         pr_default.execute(13, new Object[] {A345NegID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Y7 */
         pr_default.execute(5, new Object[] {A345NegID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0Y37( 54) ;
            RcdFound37 = 1;
            A345NegID = BC000Y7_A345NegID[0];
            A356NegCodigo = BC000Y7_A356NegCodigo[0];
            A348NegInsDataHora = BC000Y7_A348NegInsDataHora[0];
            A346NegInsData = BC000Y7_A346NegInsData[0];
            A347NegInsHora = BC000Y7_A347NegInsHora[0];
            A349NegInsUsuID = BC000Y7_A349NegInsUsuID[0];
            n349NegInsUsuID = BC000Y7_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC000Y7_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC000Y7_n364NegInsUsuNome[0];
            A385NegValorAtualizado = BC000Y7_A385NegValorAtualizado[0];
            A380NegValorEstimado = BC000Y7_A380NegValorEstimado[0];
            A573NegDelDataHora = BC000Y7_A573NegDelDataHora[0];
            n573NegDelDataHora = BC000Y7_n573NegDelDataHora[0];
            A574NegDelData = BC000Y7_A574NegDelData[0];
            n574NegDelData = BC000Y7_n574NegDelData[0];
            A575NegDelHora = BC000Y7_A575NegDelHora[0];
            n575NegDelHora = BC000Y7_n575NegDelHora[0];
            A576NegDelUsuId = BC000Y7_A576NegDelUsuId[0];
            n576NegDelUsuId = BC000Y7_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC000Y7_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC000Y7_n577NegDelUsuNome[0];
            A360NegAgcID = BC000Y7_A360NegAgcID[0];
            n360NegAgcID = BC000Y7_n360NegAgcID[0];
            A361NegAgcNome = BC000Y7_A361NegAgcNome[0];
            n361NegAgcNome = BC000Y7_n361NegAgcNome[0];
            A362NegAssunto = BC000Y7_A362NegAssunto[0];
            A363NegDescricao = BC000Y7_A363NegDescricao[0];
            A454NegUltItem = BC000Y7_A454NegUltItem[0];
            n454NegUltItem = BC000Y7_n454NegUltItem[0];
            A572NegDel = BC000Y7_A572NegDel[0];
            A350NegCliID = BC000Y7_A350NegCliID[0];
            A352NegCpjID = BC000Y7_A352NegCpjID[0];
            A369NegCpjEndSeq = BC000Y7_A369NegCpjEndSeq[0];
            O454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            O572NegDel = A572NegDel;
            Z345NegID = A345NegID;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            Load0Y37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0Y37( ) ;
            }
            Gx_mode = sMode37;
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0Y37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode37;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y37( ) ;
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
         CONFIRM_0Y0( ) ;
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

      protected void CheckOptimisticConcurrency0Y37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Y6 */
            pr_default.execute(4, new Object[] {A345NegID});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( Z356NegCodigo != BC000Y6_A356NegCodigo[0] ) || ( Z348NegInsDataHora != BC000Y6_A348NegInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z346NegInsData ) != DateTimeUtil.ResetTime ( BC000Y6_A346NegInsData[0] ) ) || ( Z347NegInsHora != BC000Y6_A347NegInsHora[0] ) || ( StringUtil.StrCmp(Z349NegInsUsuID, BC000Y6_A349NegInsUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z364NegInsUsuNome, BC000Y6_A364NegInsUsuNome[0]) != 0 ) || ( Z385NegValorAtualizado != BC000Y6_A385NegValorAtualizado[0] ) || ( Z380NegValorEstimado != BC000Y6_A380NegValorEstimado[0] ) || ( Z573NegDelDataHora != BC000Y6_A573NegDelDataHora[0] ) || ( Z574NegDelData != BC000Y6_A574NegDelData[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z575NegDelHora != BC000Y6_A575NegDelHora[0] ) || ( StringUtil.StrCmp(Z576NegDelUsuId, BC000Y6_A576NegDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z577NegDelUsuNome, BC000Y6_A577NegDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z360NegAgcID, BC000Y6_A360NegAgcID[0]) != 0 ) || ( StringUtil.StrCmp(Z361NegAgcNome, BC000Y6_A361NegAgcNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z362NegAssunto, BC000Y6_A362NegAssunto[0]) != 0 ) || ( Z454NegUltItem != BC000Y6_A454NegUltItem[0] ) || ( Z572NegDel != BC000Y6_A572NegDel[0] ) || ( Z350NegCliID != BC000Y6_A350NegCliID[0] ) || ( Z352NegCpjID != BC000Y6_A352NegCpjID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z369NegCpjEndSeq != BC000Y6_A369NegCpjEndSeq[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y37( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y37( 0) ;
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y18 */
                     pr_default.execute(14, new Object[] {A351NegCliNomeFamiliar, A353NegCpjNomFan, A354NegCpjRazSocial, A359NegPjtNome, A345NegID, A356NegCodigo, A348NegInsDataHora, A346NegInsData, A347NegInsHora, n349NegInsUsuID, A349NegInsUsuID, n364NegInsUsuNome, A364NegInsUsuNome, A385NegValorAtualizado, A380NegValorEstimado, n573NegDelDataHora, A573NegDelDataHora, n574NegDelData, A574NegDelData, n575NegDelHora, A575NegDelHora, n576NegDelUsuId, A576NegDelUsuId, n577NegDelUsuNome, A577NegDelUsuNome, n360NegAgcID, A360NegAgcID, n361NegAgcNome, A361NegAgcNome, A362NegAssunto, A363NegDescricao, n454NegUltItem, A454NegUltItem, A572NegDel, A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ProcessLevel0Y37( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
               Load0Y37( ) ;
            }
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void Update0Y37( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y19 */
                     pr_default.execute(15, new Object[] {A351NegCliNomeFamiliar, A353NegCpjNomFan, A354NegCpjRazSocial, A359NegPjtNome, A356NegCodigo, A348NegInsDataHora, A346NegInsData, A347NegInsHora, n349NegInsUsuID, A349NegInsUsuID, n364NegInsUsuNome, A364NegInsUsuNome, A385NegValorAtualizado, A380NegValorEstimado, n573NegDelDataHora, A573NegDelDataHora, n574NegDelData, A574NegDelData, n575NegDelHora, A575NegDelHora, n576NegDelUsuId, A576NegDelUsuId, n577NegDelUsuNome, A577NegDelUsuNome, n360NegAgcID, A360NegAgcID, n361NegAgcNome, A361NegAgcNome, A362NegAssunto, A363NegDescricao, n454NegUltItem, A454NegUltItem, A572NegDel, A350NegCliID, A352NegCpjID, A369NegCpjEndSeq, A345NegID});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Y37( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            }
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void DeferredUpdate0Y37( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y37( ) ;
            AfterConfirm0Y37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y37( ) ;
               if ( AnyError == 0 )
               {
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  ScanKeyStart0Y42( ) ;
                  while ( RcdFound42 != 0 )
                  {
                     getByPrimaryKey0Y42( ) ;
                     Delete0Y42( ) ;
                     ScanKeyNext0Y42( ) ;
                     O454NegUltItem = A454NegUltItem;
                     n454NegUltItem = false;
                     O448NegPgpTotal = A448NegPgpTotal;
                     n448NegPgpTotal = false;
                  }
                  ScanKeyEnd0Y42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y20 */
                     pr_default.execute(16, new Object[] {A345NegID});
                     pr_default.close(16);
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
         EndLevel0Y37( ) ;
         Gx_mode = sMode37;
      }

      protected void OnDeleteControls0Y37( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV49Pgmname = "core.NegocioPJ_BC";
            /* Using cursor BC000Y22 */
            pr_default.execute(17, new Object[] {A345NegID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A448NegPgpTotal = BC000Y22_A448NegPgpTotal[0];
               n448NegPgpTotal = BC000Y22_n448NegPgpTotal[0];
            }
            else
            {
               A448NegPgpTotal = 0;
               n448NegPgpTotal = false;
            }
            pr_default.close(17);
            /* Using cursor BC000Y23 */
            pr_default.execute(18, new Object[] {A350NegCliID});
            A473NegCliMatricula = BC000Y23_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC000Y23_A351NegCliNomeFamiliar[0];
            pr_default.close(18);
            /* Using cursor BC000Y24 */
            pr_default.execute(19, new Object[] {A350NegCliID, A352NegCpjID});
            A353NegCpjNomFan = BC000Y24_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC000Y24_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC000Y24_A355NegCpjMatricula[0];
            A357NegPjtID = BC000Y24_A357NegPjtID[0];
            pr_default.close(19);
            /* Using cursor BC000Y25 */
            pr_default.execute(20, new Object[] {A357NegPjtID});
            A358NegPjtSigla = BC000Y25_A358NegPjtSigla[0];
            A359NegPjtNome = BC000Y25_A359NegPjtNome[0];
            pr_default.close(20);
            /* Using cursor BC000Y26 */
            pr_default.execute(21, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
            A370NegCpjEndNome = BC000Y26_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC000Y26_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC000Y26_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC000Y26_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC000Y26_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC000Y26_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = BC000Y26_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = BC000Y26_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = BC000Y26_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC000Y26_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC000Y26_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC000Y26_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC000Y26_A379NegCpjEndUFNome[0];
            pr_default.close(21);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  }
                  else
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  }
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Y27 */
            pr_default.execute(22, new Object[] {A345NegID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC000Y28 */
            pr_default.execute(23, new Object[] {A345NegID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC000Y29 */
            pr_default.execute(24, new Object[] {A345NegID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void ProcessNestedLevel0Y42( )
      {
         s454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         s448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         nGXsfl_42_idx = 0;
         while ( nGXsfl_42_idx < bccore_NegocioPJ.gxTpr_Item.Count )
         {
            ReadRow0Y42( ) ;
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
               standaloneNotModal0Y42( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Y42( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Y42( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Y42( ) ;
                  }
               }
               O454NegUltItem = A454NegUltItem;
               n454NegUltItem = false;
               O448NegPgpTotal = A448NegPgpTotal;
               n448NegPgpTotal = false;
            }
            KeyVarsToRow42( ((GeneXus.Programs.core.SdtNegocioPJ_Item)bccore_NegocioPJ.gxTpr_Item.Item(nGXsfl_42_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_42_idx = 0;
            while ( nGXsfl_42_idx < bccore_NegocioPJ.gxTpr_Item.Count )
            {
               ReadRow0Y42( ) ;
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
                  bccore_NegocioPJ.gxTpr_Item.RemoveElement(nGXsfl_42_idx);
                  nGXsfl_42_idx = (int)(nGXsfl_42_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Y42( ) ;
                  VarsToRow42( ((GeneXus.Programs.core.SdtNegocioPJ_Item)bccore_NegocioPJ.gxTpr_Item.Item(nGXsfl_42_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Y42( ) ;
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

      protected void ProcessLevel0Y37( )
      {
         /* Save parent mode. */
         sMode37 = Gx_mode;
         ProcessNestedLevel0Y42( ) ;
         if ( AnyError != 0 )
         {
            O454NegUltItem = s454NegUltItem;
            n454NegUltItem = false;
            O448NegPgpTotal = s448NegPgpTotal;
            n448NegPgpTotal = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode37;
         /* ' Update level parameters */
         /* Using cursor BC000Y30 */
         pr_default.execute(25, new Object[] {n454NegUltItem, A454NegUltItem, A380NegValorEstimado, A385NegValorAtualizado, A345NegID});
         pr_default.close(25);
         pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
      }

      protected void EndLevel0Y37( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0Y37( ) ;
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

      public void ScanKeyStart0Y37( )
      {
         /* Scan By routine */
         /* Using cursor BC000Y32 */
         pr_default.execute(26, new Object[] {A345NegID});
         RcdFound37 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound37 = 1;
            A345NegID = BC000Y32_A345NegID[0];
            A356NegCodigo = BC000Y32_A356NegCodigo[0];
            A348NegInsDataHora = BC000Y32_A348NegInsDataHora[0];
            A346NegInsData = BC000Y32_A346NegInsData[0];
            A347NegInsHora = BC000Y32_A347NegInsHora[0];
            A349NegInsUsuID = BC000Y32_A349NegInsUsuID[0];
            n349NegInsUsuID = BC000Y32_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC000Y32_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC000Y32_n364NegInsUsuNome[0];
            A385NegValorAtualizado = BC000Y32_A385NegValorAtualizado[0];
            A380NegValorEstimado = BC000Y32_A380NegValorEstimado[0];
            A573NegDelDataHora = BC000Y32_A573NegDelDataHora[0];
            n573NegDelDataHora = BC000Y32_n573NegDelDataHora[0];
            A574NegDelData = BC000Y32_A574NegDelData[0];
            n574NegDelData = BC000Y32_n574NegDelData[0];
            A575NegDelHora = BC000Y32_A575NegDelHora[0];
            n575NegDelHora = BC000Y32_n575NegDelHora[0];
            A576NegDelUsuId = BC000Y32_A576NegDelUsuId[0];
            n576NegDelUsuId = BC000Y32_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC000Y32_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC000Y32_n577NegDelUsuNome[0];
            A473NegCliMatricula = BC000Y32_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC000Y32_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = BC000Y32_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC000Y32_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC000Y32_A355NegCpjMatricula[0];
            A358NegPjtSigla = BC000Y32_A358NegPjtSigla[0];
            A359NegPjtNome = BC000Y32_A359NegPjtNome[0];
            A370NegCpjEndNome = BC000Y32_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC000Y32_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC000Y32_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC000Y32_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC000Y32_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC000Y32_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = BC000Y32_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = BC000Y32_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = BC000Y32_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC000Y32_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC000Y32_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC000Y32_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC000Y32_A379NegCpjEndUFNome[0];
            A360NegAgcID = BC000Y32_A360NegAgcID[0];
            n360NegAgcID = BC000Y32_n360NegAgcID[0];
            A361NegAgcNome = BC000Y32_A361NegAgcNome[0];
            n361NegAgcNome = BC000Y32_n361NegAgcNome[0];
            A362NegAssunto = BC000Y32_A362NegAssunto[0];
            A363NegDescricao = BC000Y32_A363NegDescricao[0];
            A454NegUltItem = BC000Y32_A454NegUltItem[0];
            n454NegUltItem = BC000Y32_n454NegUltItem[0];
            A572NegDel = BC000Y32_A572NegDel[0];
            A350NegCliID = BC000Y32_A350NegCliID[0];
            A352NegCpjID = BC000Y32_A352NegCpjID[0];
            A369NegCpjEndSeq = BC000Y32_A369NegCpjEndSeq[0];
            A357NegPjtID = BC000Y32_A357NegPjtID[0];
            A448NegPgpTotal = BC000Y32_A448NegPgpTotal[0];
            n448NegPgpTotal = BC000Y32_n448NegPgpTotal[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Y37( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound37 = 0;
         ScanKeyLoad0Y37( ) ;
      }

      protected void ScanKeyLoad0Y37( )
      {
         sMode37 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound37 = 1;
            A345NegID = BC000Y32_A345NegID[0];
            A356NegCodigo = BC000Y32_A356NegCodigo[0];
            A348NegInsDataHora = BC000Y32_A348NegInsDataHora[0];
            A346NegInsData = BC000Y32_A346NegInsData[0];
            A347NegInsHora = BC000Y32_A347NegInsHora[0];
            A349NegInsUsuID = BC000Y32_A349NegInsUsuID[0];
            n349NegInsUsuID = BC000Y32_n349NegInsUsuID[0];
            A364NegInsUsuNome = BC000Y32_A364NegInsUsuNome[0];
            n364NegInsUsuNome = BC000Y32_n364NegInsUsuNome[0];
            A385NegValorAtualizado = BC000Y32_A385NegValorAtualizado[0];
            A380NegValorEstimado = BC000Y32_A380NegValorEstimado[0];
            A573NegDelDataHora = BC000Y32_A573NegDelDataHora[0];
            n573NegDelDataHora = BC000Y32_n573NegDelDataHora[0];
            A574NegDelData = BC000Y32_A574NegDelData[0];
            n574NegDelData = BC000Y32_n574NegDelData[0];
            A575NegDelHora = BC000Y32_A575NegDelHora[0];
            n575NegDelHora = BC000Y32_n575NegDelHora[0];
            A576NegDelUsuId = BC000Y32_A576NegDelUsuId[0];
            n576NegDelUsuId = BC000Y32_n576NegDelUsuId[0];
            A577NegDelUsuNome = BC000Y32_A577NegDelUsuNome[0];
            n577NegDelUsuNome = BC000Y32_n577NegDelUsuNome[0];
            A473NegCliMatricula = BC000Y32_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = BC000Y32_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = BC000Y32_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = BC000Y32_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = BC000Y32_A355NegCpjMatricula[0];
            A358NegPjtSigla = BC000Y32_A358NegPjtSigla[0];
            A359NegPjtNome = BC000Y32_A359NegPjtNome[0];
            A370NegCpjEndNome = BC000Y32_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = BC000Y32_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = BC000Y32_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = BC000Y32_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = BC000Y32_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = BC000Y32_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = BC000Y32_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = BC000Y32_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = BC000Y32_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = BC000Y32_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = BC000Y32_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = BC000Y32_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = BC000Y32_A379NegCpjEndUFNome[0];
            A360NegAgcID = BC000Y32_A360NegAgcID[0];
            n360NegAgcID = BC000Y32_n360NegAgcID[0];
            A361NegAgcNome = BC000Y32_A361NegAgcNome[0];
            n361NegAgcNome = BC000Y32_n361NegAgcNome[0];
            A362NegAssunto = BC000Y32_A362NegAssunto[0];
            A363NegDescricao = BC000Y32_A363NegDescricao[0];
            A454NegUltItem = BC000Y32_A454NegUltItem[0];
            n454NegUltItem = BC000Y32_n454NegUltItem[0];
            A572NegDel = BC000Y32_A572NegDel[0];
            A350NegCliID = BC000Y32_A350NegCliID[0];
            A352NegCpjID = BC000Y32_A352NegCpjID[0];
            A369NegCpjEndSeq = BC000Y32_A369NegCpjEndSeq[0];
            A357NegPjtID = BC000Y32_A357NegPjtID[0];
            A448NegPgpTotal = BC000Y32_A448NegPgpTotal[0];
            n448NegPgpTotal = BC000Y32_n448NegPgpTotal[0];
         }
         Gx_mode = sMode37;
      }

      protected void ScanKeyEnd0Y37( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0Y37( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  )
         {
            GXt_int1 = (int)(A356NegCodigo);
            new GeneXus.Programs.core.serializar(context ).execute(  "NegCodigo",  1, out  GXt_int1) ;
            A356NegCodigo = GXt_int1;
         }
      }

      protected void BeforeInsert0Y37( )
      {
         /* Before Insert Rules */
         A348NegInsDataHora = DateTimeUtil.NowMS( context);
         A349NegInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n349NegInsUsuID = false;
         A364NegInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n364NegInsUsuNome = false;
         A385NegValorAtualizado = A380NegValorEstimado;
         A346NegInsData = DateTimeUtil.ResetTime( A348NegInsDataHora);
         A347NegInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A348NegInsDataHora));
      }

      protected void BeforeUpdate0Y37( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "Y", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
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

      protected void BeforeDelete0Y37( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "Y", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
      }

      protected void BeforeComplete0Y37( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "N", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "N", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0Y37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y37( )
      {
      }

      protected void ZM0Y42( short GX_JID )
      {
         if ( ( GX_JID == 61 ) || ( GX_JID == 0 ) )
         {
            Z447NgpTotal = A447NgpTotal;
            Z446NgpQtde = A446NgpQtde;
            Z445NgpPreco = A445NgpPreco;
            Z457NgpInsDataHora = A457NgpInsDataHora;
            Z455NgpInsData = A455NgpInsData;
            Z456NgpInsHora = A456NgpInsHora;
            Z458NgpInsUsuID = A458NgpInsUsuID;
            Z459NgpInsUsuNome = A459NgpInsUsuNome;
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
         if ( ( GX_JID == 62 ) || ( GX_JID == 0 ) )
         {
            Z440NgpTppPrdCodigo = A440NgpTppPrdCodigo;
            Z441NgpTppPrdNome = A441NgpTppPrdNome;
            Z443NgpTppPrdAtivo = A443NgpTppPrdAtivo;
            Z442NgpTppPrdTipoID = A442NgpTppPrdTipoID;
         }
         if ( ( GX_JID == 63 ) || ( GX_JID == 0 ) )
         {
            Z444NgpTpp1Preco = A444NgpTpp1Preco;
         }
         if ( GX_JID == -61 )
         {
            Z447NgpTotal = A447NgpTotal;
            Z345NegID = A345NegID;
            Z435NgpItem = A435NgpItem;
            Z446NgpQtde = A446NgpQtde;
            Z445NgpPreco = A445NgpPreco;
            Z457NgpInsDataHora = A457NgpInsDataHora;
            Z455NgpInsData = A455NgpInsData;
            Z456NgpInsHora = A456NgpInsHora;
            Z458NgpInsUsuID = A458NgpInsUsuID;
            Z459NgpInsUsuNome = A459NgpInsUsuNome;
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

      protected void standaloneNotModal0Y42( )
      {
      }

      protected void standaloneModal0Y42( )
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

      protected void Load0Y42( )
      {
         /* Using cursor BC000Y33 */
         pr_default.execute(27, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = BC000Y33_A447NgpTotal[0];
            A446NgpQtde = BC000Y33_A446NgpQtde[0];
            A445NgpPreco = BC000Y33_A445NgpPreco[0];
            A457NgpInsDataHora = BC000Y33_A457NgpInsDataHora[0];
            A455NgpInsData = BC000Y33_A455NgpInsData[0];
            A456NgpInsHora = BC000Y33_A456NgpInsHora[0];
            A458NgpInsUsuID = BC000Y33_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC000Y33_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC000Y33_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC000Y33_n459NgpInsUsuNome[0];
            A579NgpDelDataHora = BC000Y33_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC000Y33_n579NgpDelDataHora[0];
            A580NgpDelData = BC000Y33_A580NgpDelData[0];
            n580NgpDelData = BC000Y33_n580NgpDelData[0];
            A581NgpDelHora = BC000Y33_A581NgpDelHora[0];
            n581NgpDelHora = BC000Y33_n581NgpDelHora[0];
            A582NgpDelUsuId = BC000Y33_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC000Y33_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC000Y33_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC000Y33_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = BC000Y33_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC000Y33_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC000Y33_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = BC000Y33_A444NgpTpp1Preco[0];
            A453NgpObs = BC000Y33_A453NgpObs[0];
            A578NgpDel = BC000Y33_A578NgpDel[0];
            A439NgpTppPrdID = BC000Y33_A439NgpTppPrdID[0];
            A478NgpTppID = BC000Y33_A478NgpTppID[0];
            A442NgpTppPrdTipoID = BC000Y33_A442NgpTppPrdTipoID[0];
            ZM0Y42( -61) ;
         }
         pr_default.close(27);
         OnLoadActions0Y42( ) ;
      }

      protected void OnLoadActions0Y42( )
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

      protected void CheckExtendedTable0Y42( )
      {
         nIsDirty_42 = 0;
         Gx_BScreen = 1;
         standaloneModal0Y42( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000Y5 */
         pr_default.execute(3, new Object[] {A478NgpTppID, A439NgpTppPrdID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, "NGPTPPPRDID");
            AnyError = 1;
         }
         A444NgpTpp1Preco = BC000Y5_A444NgpTpp1Preco[0];
         pr_default.close(3);
         if ( IsIns( )  && (Convert.ToDecimal(0)==A445NgpPreco) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_42 = 1;
            A445NgpPreco = A444NgpTpp1Preco;
         }
         if ( (Guid.Empty==A478NgpTppID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tabela de Preço ID", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000Y4 */
         pr_default.execute(2, new Object[] {A439NgpTppPrdID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, "NGPTPPPRDID");
            AnyError = 1;
         }
         A440NgpTppPrdCodigo = BC000Y4_A440NgpTppPrdCodigo[0];
         A441NgpTppPrdNome = BC000Y4_A441NgpTppPrdNome[0];
         A443NgpTppPrdAtivo = BC000Y4_A443NgpTppPrdAtivo[0];
         A442NgpTppPrdTipoID = BC000Y4_A442NgpTppPrdTipoID[0];
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

      protected void CloseExtendedTableCursors0Y42( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable0Y42( )
      {
      }

      protected void GetKey0Y42( )
      {
         /* Using cursor BC000Y34 */
         pr_default.execute(28, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey0Y42( )
      {
         /* Using cursor BC000Y3 */
         pr_default.execute(1, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y42( 61) ;
            RcdFound42 = 1;
            InitializeNonKey0Y42( ) ;
            A447NgpTotal = BC000Y3_A447NgpTotal[0];
            A435NgpItem = BC000Y3_A435NgpItem[0];
            A446NgpQtde = BC000Y3_A446NgpQtde[0];
            A445NgpPreco = BC000Y3_A445NgpPreco[0];
            A457NgpInsDataHora = BC000Y3_A457NgpInsDataHora[0];
            A455NgpInsData = BC000Y3_A455NgpInsData[0];
            A456NgpInsHora = BC000Y3_A456NgpInsHora[0];
            A458NgpInsUsuID = BC000Y3_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC000Y3_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC000Y3_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC000Y3_n459NgpInsUsuNome[0];
            A579NgpDelDataHora = BC000Y3_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC000Y3_n579NgpDelDataHora[0];
            A580NgpDelData = BC000Y3_A580NgpDelData[0];
            n580NgpDelData = BC000Y3_n580NgpDelData[0];
            A581NgpDelHora = BC000Y3_A581NgpDelHora[0];
            n581NgpDelHora = BC000Y3_n581NgpDelHora[0];
            A582NgpDelUsuId = BC000Y3_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC000Y3_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC000Y3_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC000Y3_n583NgpDelUsuNome[0];
            A453NgpObs = BC000Y3_A453NgpObs[0];
            A578NgpDel = BC000Y3_A578NgpDel[0];
            A439NgpTppPrdID = BC000Y3_A439NgpTppPrdID[0];
            A478NgpTppID = BC000Y3_A478NgpTppID[0];
            O578NgpDel = A578NgpDel;
            O447NgpTotal = A447NgpTotal;
            Z345NegID = A345NegID;
            Z435NgpItem = A435NgpItem;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            Load0Y42( ) ;
            Gx_mode = sMode42;
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey0Y42( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Y42( ) ;
            Gx_mode = sMode42;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Y42( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Y42( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Y2 */
            pr_default.execute(0, new Object[] {A345NegID, A435NgpItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_item"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z447NgpTotal != BC000Y2_A447NgpTotal[0] ) || ( Z446NgpQtde != BC000Y2_A446NgpQtde[0] ) || ( Z445NgpPreco != BC000Y2_A445NgpPreco[0] ) || ( Z457NgpInsDataHora != BC000Y2_A457NgpInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z455NgpInsData ) != DateTimeUtil.ResetTime ( BC000Y2_A455NgpInsData[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z456NgpInsHora != BC000Y2_A456NgpInsHora[0] ) || ( StringUtil.StrCmp(Z458NgpInsUsuID, BC000Y2_A458NgpInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z459NgpInsUsuNome, BC000Y2_A459NgpInsUsuNome[0]) != 0 ) || ( Z579NgpDelDataHora != BC000Y2_A579NgpDelDataHora[0] ) || ( Z580NgpDelData != BC000Y2_A580NgpDelData[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z581NgpDelHora != BC000Y2_A581NgpDelHora[0] ) || ( StringUtil.StrCmp(Z582NgpDelUsuId, BC000Y2_A582NgpDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z583NgpDelUsuNome, BC000Y2_A583NgpDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z453NgpObs, BC000Y2_A453NgpObs[0]) != 0 ) || ( Z578NgpDel != BC000Y2_A578NgpDel[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z439NgpTppPrdID != BC000Y2_A439NgpTppPrdID[0] ) || ( Z478NgpTppID != BC000Y2_A478NgpTppID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj_item"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y42( )
      {
         BeforeValidate0Y42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y42( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y42( 0) ;
            CheckOptimisticConcurrency0Y42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y35 */
                     pr_default.execute(29, new Object[] {A447NgpTotal, A345NegID, A435NgpItem, A446NgpQtde, A445NgpPreco, A457NgpInsDataHora, A455NgpInsData, A456NgpInsHora, n458NgpInsUsuID, A458NgpInsUsuID, n459NgpInsUsuNome, A459NgpInsUsuNome, n579NgpDelDataHora, A579NgpDelDataHora, n580NgpDelData, A580NgpDelData, n581NgpDelHora, A581NgpDelHora, n582NgpDelUsuId, A582NgpDelUsuId, n583NgpDelUsuNome, A583NgpDelUsuNome, A453NgpObs, A578NgpDel, A439NgpTppPrdID, A478NgpTppID});
                     pr_default.close(29);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                     if ( (pr_default.getStatus(29) == 1) )
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
               Load0Y42( ) ;
            }
            EndLevel0Y42( ) ;
         }
         CloseExtendedTableCursors0Y42( ) ;
      }

      protected void Update0Y42( )
      {
         BeforeValidate0Y42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y42( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y36 */
                     pr_default.execute(30, new Object[] {A447NgpTotal, A446NgpQtde, A445NgpPreco, A457NgpInsDataHora, A455NgpInsData, A456NgpInsHora, n458NgpInsUsuID, A458NgpInsUsuID, n459NgpInsUsuNome, A459NgpInsUsuNome, n579NgpDelDataHora, A579NgpDelDataHora, n580NgpDelData, A580NgpDelData, n581NgpDelHora, A581NgpDelHora, n582NgpDelUsuId, A582NgpDelUsuId, n583NgpDelUsuNome, A583NgpDelUsuNome, A453NgpObs, A578NgpDel, A439NgpTppPrdID, A478NgpTppID, A345NegID, A435NgpItem});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                     if ( (pr_default.getStatus(30) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_item"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y42( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Y42( ) ;
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
            EndLevel0Y42( ) ;
         }
         CloseExtendedTableCursors0Y42( ) ;
      }

      protected void DeferredUpdate0Y42( )
      {
      }

      protected void Delete0Y42( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Y42( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y42( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y42( ) ;
            AfterConfirm0Y42( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y42( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Y37 */
                  pr_default.execute(31, new Object[] {A345NegID, A435NgpItem});
                  pr_default.close(31);
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
         EndLevel0Y42( ) ;
         Gx_mode = sMode42;
      }

      protected void OnDeleteControls0Y42( )
      {
         standaloneModal0Y42( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000Y38 */
            pr_default.execute(32, new Object[] {A439NgpTppPrdID});
            A440NgpTppPrdCodigo = BC000Y38_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC000Y38_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC000Y38_A443NgpTppPrdAtivo[0];
            A442NgpTppPrdTipoID = BC000Y38_A442NgpTppPrdTipoID[0];
            pr_default.close(32);
            /* Using cursor BC000Y39 */
            pr_default.execute(33, new Object[] {A478NgpTppID, A439NgpTppPrdID});
            A444NgpTpp1Preco = BC000Y39_A444NgpTpp1Preco[0];
            pr_default.close(33);
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

      protected void EndLevel0Y42( )
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

      public void ScanKeyStart0Y42( )
      {
         /* Scan By routine */
         /* Using cursor BC000Y40 */
         pr_default.execute(34, new Object[] {A345NegID});
         RcdFound42 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = BC000Y40_A447NgpTotal[0];
            A435NgpItem = BC000Y40_A435NgpItem[0];
            A446NgpQtde = BC000Y40_A446NgpQtde[0];
            A445NgpPreco = BC000Y40_A445NgpPreco[0];
            A457NgpInsDataHora = BC000Y40_A457NgpInsDataHora[0];
            A455NgpInsData = BC000Y40_A455NgpInsData[0];
            A456NgpInsHora = BC000Y40_A456NgpInsHora[0];
            A458NgpInsUsuID = BC000Y40_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC000Y40_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC000Y40_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC000Y40_n459NgpInsUsuNome[0];
            A579NgpDelDataHora = BC000Y40_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC000Y40_n579NgpDelDataHora[0];
            A580NgpDelData = BC000Y40_A580NgpDelData[0];
            n580NgpDelData = BC000Y40_n580NgpDelData[0];
            A581NgpDelHora = BC000Y40_A581NgpDelHora[0];
            n581NgpDelHora = BC000Y40_n581NgpDelHora[0];
            A582NgpDelUsuId = BC000Y40_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC000Y40_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC000Y40_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC000Y40_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = BC000Y40_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC000Y40_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC000Y40_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = BC000Y40_A444NgpTpp1Preco[0];
            A453NgpObs = BC000Y40_A453NgpObs[0];
            A578NgpDel = BC000Y40_A578NgpDel[0];
            A439NgpTppPrdID = BC000Y40_A439NgpTppPrdID[0];
            A478NgpTppID = BC000Y40_A478NgpTppID[0];
            A442NgpTppPrdTipoID = BC000Y40_A442NgpTppPrdTipoID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Y42( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound42 = 0;
         ScanKeyLoad0Y42( ) ;
      }

      protected void ScanKeyLoad0Y42( )
      {
         sMode42 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = BC000Y40_A447NgpTotal[0];
            A435NgpItem = BC000Y40_A435NgpItem[0];
            A446NgpQtde = BC000Y40_A446NgpQtde[0];
            A445NgpPreco = BC000Y40_A445NgpPreco[0];
            A457NgpInsDataHora = BC000Y40_A457NgpInsDataHora[0];
            A455NgpInsData = BC000Y40_A455NgpInsData[0];
            A456NgpInsHora = BC000Y40_A456NgpInsHora[0];
            A458NgpInsUsuID = BC000Y40_A458NgpInsUsuID[0];
            n458NgpInsUsuID = BC000Y40_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = BC000Y40_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = BC000Y40_n459NgpInsUsuNome[0];
            A579NgpDelDataHora = BC000Y40_A579NgpDelDataHora[0];
            n579NgpDelDataHora = BC000Y40_n579NgpDelDataHora[0];
            A580NgpDelData = BC000Y40_A580NgpDelData[0];
            n580NgpDelData = BC000Y40_n580NgpDelData[0];
            A581NgpDelHora = BC000Y40_A581NgpDelHora[0];
            n581NgpDelHora = BC000Y40_n581NgpDelHora[0];
            A582NgpDelUsuId = BC000Y40_A582NgpDelUsuId[0];
            n582NgpDelUsuId = BC000Y40_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = BC000Y40_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = BC000Y40_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = BC000Y40_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = BC000Y40_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = BC000Y40_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = BC000Y40_A444NgpTpp1Preco[0];
            A453NgpObs = BC000Y40_A453NgpObs[0];
            A578NgpDel = BC000Y40_A578NgpDel[0];
            A439NgpTppPrdID = BC000Y40_A439NgpTppPrdID[0];
            A478NgpTppID = BC000Y40_A478NgpTppID[0];
            A442NgpTppPrdTipoID = BC000Y40_A442NgpTppPrdTipoID[0];
         }
         Gx_mode = sMode42;
      }

      protected void ScanKeyEnd0Y42( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm0Y42( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y42( )
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

      protected void BeforeUpdate0Y42( )
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

      protected void BeforeDelete0Y42( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y42( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y42( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y42( )
      {
      }

      protected void send_integrity_lvl_hashes0Y42( )
      {
      }

      protected void send_integrity_lvl_hashes0Y37( )
      {
      }

      protected void AddRow0Y37( )
      {
         VarsToRow37( bccore_NegocioPJ) ;
      }

      protected void ReadRow0Y37( )
      {
         RowToVars37( bccore_NegocioPJ, 1) ;
      }

      protected void AddRow0Y42( )
      {
         GeneXus.Programs.core.SdtNegocioPJ_Item obj42;
         obj42 = new GeneXus.Programs.core.SdtNegocioPJ_Item(context);
         VarsToRow42( obj42) ;
         bccore_NegocioPJ.gxTpr_Item.Add(obj42, 0);
         obj42.gxTpr_Mode = "UPD";
         obj42.gxTpr_Modified = 0;
      }

      protected void ReadRow0Y42( )
      {
         nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
         RowToVars42( ((GeneXus.Programs.core.SdtNegocioPJ_Item)bccore_NegocioPJ.gxTpr_Item.Item(nGXsfl_42_idx)), 1) ;
      }

      protected void InitializeNonKey0Y37( )
      {
         AV47AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A356NegCodigo = 0;
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A346NegInsData = DateTime.MinValue;
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A349NegInsUsuID = "";
         n349NegInsUsuID = false;
         A364NegInsUsuNome = "";
         n364NegInsUsuNome = false;
         A385NegValorAtualizado = 0;
         A380NegValorEstimado = 0;
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
         A642NegCpjEndCep = 0;
         A643NegCpjEndCepFormat = "";
         A375NegCpjEndMunID = 0;
         A376NegCpjEndMunNome = "";
         A377NegCpjEndUFID = 0;
         A378NegCpjEndUFSigla = "";
         A379NegCpjEndUFNome = "";
         A641NegCpjEndCompleto = "";
         A360NegAgcID = "";
         n360NegAgcID = false;
         A361NegAgcNome = "";
         n361NegAgcNome = false;
         A362NegAssunto = "";
         A363NegDescricao = "";
         A448NegPgpTotal = 0;
         n448NegPgpTotal = false;
         A454NegUltItem = 0;
         n454NegUltItem = false;
         A572NegDel = false;
         O454NegUltItem = A454NegUltItem;
         n454NegUltItem = false;
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         O572NegDel = A572NegDel;
         Z356NegCodigo = 0;
         Z348NegInsDataHora = (DateTime)(DateTime.MinValue);
         Z346NegInsData = DateTime.MinValue;
         Z347NegInsHora = (DateTime)(DateTime.MinValue);
         Z349NegInsUsuID = "";
         Z364NegInsUsuNome = "";
         Z385NegValorAtualizado = 0;
         Z380NegValorEstimado = 0;
         Z573NegDelDataHora = (DateTime)(DateTime.MinValue);
         Z574NegDelData = (DateTime)(DateTime.MinValue);
         Z575NegDelHora = (DateTime)(DateTime.MinValue);
         Z576NegDelUsuId = "";
         Z577NegDelUsuNome = "";
         Z360NegAgcID = "";
         Z361NegAgcNome = "";
         Z362NegAssunto = "";
         Z454NegUltItem = 0;
         Z572NegDel = false;
         Z350NegCliID = Guid.Empty;
         Z352NegCpjID = Guid.Empty;
         Z369NegCpjEndSeq = 0;
      }

      protected void InitAll0Y37( )
      {
         A345NegID = Guid.NewGuid( );
         InitializeNonKey0Y37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0Y42( )
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
         Z445NgpPreco = 0;
         Z457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         Z455NgpInsData = DateTime.MinValue;
         Z456NgpInsHora = (DateTime)(DateTime.MinValue);
         Z458NgpInsUsuID = "";
         Z459NgpInsUsuNome = "";
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

      protected void InitAll0Y42( )
      {
         A435NgpItem = 0;
         InitializeNonKey0Y42( ) ;
      }

      protected void StandaloneModalInsert0Y42( )
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

      public void VarsToRow37( GeneXus.Programs.core.SdtNegocioPJ obj37 )
      {
         obj37.gxTpr_Mode = Gx_mode;
         obj37.gxTpr_Negcodigo = A356NegCodigo;
         obj37.gxTpr_Neginsdatahora = A348NegInsDataHora;
         obj37.gxTpr_Neginsdata = A346NegInsData;
         obj37.gxTpr_Neginshora = A347NegInsHora;
         obj37.gxTpr_Neginsusuid = A349NegInsUsuID;
         obj37.gxTpr_Neginsusunome = A364NegInsUsuNome;
         obj37.gxTpr_Negvaloratualizado = A385NegValorAtualizado;
         obj37.gxTpr_Negvalorestimado = A380NegValorEstimado;
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
         obj37.gxTpr_Negcpjendcep = A642NegCpjEndCep;
         obj37.gxTpr_Negcpjendcepformat = A643NegCpjEndCepFormat;
         obj37.gxTpr_Negcpjendmunid = A375NegCpjEndMunID;
         obj37.gxTpr_Negcpjendmunnome = A376NegCpjEndMunNome;
         obj37.gxTpr_Negcpjendufid = A377NegCpjEndUFID;
         obj37.gxTpr_Negcpjendufsigla = A378NegCpjEndUFSigla;
         obj37.gxTpr_Negcpjendufnome = A379NegCpjEndUFNome;
         obj37.gxTpr_Negcpjendcompleto = A641NegCpjEndCompleto;
         obj37.gxTpr_Negagcid = A360NegAgcID;
         obj37.gxTpr_Negagcnome = A361NegAgcNome;
         obj37.gxTpr_Negassunto = A362NegAssunto;
         obj37.gxTpr_Negdescricao = A363NegDescricao;
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
         obj37.gxTpr_Negcpjendcep_Z = Z642NegCpjEndCep;
         obj37.gxTpr_Negcpjendcepformat_Z = Z643NegCpjEndCepFormat;
         obj37.gxTpr_Negcpjendmunid_Z = Z375NegCpjEndMunID;
         obj37.gxTpr_Negcpjendmunnome_Z = Z376NegCpjEndMunNome;
         obj37.gxTpr_Negcpjendufid_Z = Z377NegCpjEndUFID;
         obj37.gxTpr_Negcpjendufsigla_Z = Z378NegCpjEndUFSigla;
         obj37.gxTpr_Negcpjendufnome_Z = Z379NegCpjEndUFNome;
         obj37.gxTpr_Negcpjendcompleto_Z = Z641NegCpjEndCompleto;
         obj37.gxTpr_Negagcid_Z = Z360NegAgcID;
         obj37.gxTpr_Negagcnome_Z = Z361NegAgcNome;
         obj37.gxTpr_Negassunto_Z = Z362NegAssunto;
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

      public void KeyVarsToRow37( GeneXus.Programs.core.SdtNegocioPJ obj37 )
      {
         obj37.gxTpr_Negid = A345NegID;
         return  ;
      }

      public void RowToVars37( GeneXus.Programs.core.SdtNegocioPJ obj37 ,
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
         A385NegValorAtualizado = obj37.gxTpr_Negvaloratualizado;
         A380NegValorEstimado = obj37.gxTpr_Negvalorestimado;
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
         A642NegCpjEndCep = obj37.gxTpr_Negcpjendcep;
         A643NegCpjEndCepFormat = obj37.gxTpr_Negcpjendcepformat;
         A375NegCpjEndMunID = obj37.gxTpr_Negcpjendmunid;
         A376NegCpjEndMunNome = obj37.gxTpr_Negcpjendmunnome;
         A377NegCpjEndUFID = obj37.gxTpr_Negcpjendufid;
         A378NegCpjEndUFSigla = obj37.gxTpr_Negcpjendufsigla;
         A379NegCpjEndUFNome = obj37.gxTpr_Negcpjendufnome;
         A641NegCpjEndCompleto = obj37.gxTpr_Negcpjendcompleto;
         A360NegAgcID = obj37.gxTpr_Negagcid;
         n360NegAgcID = false;
         A361NegAgcNome = obj37.gxTpr_Negagcnome;
         n361NegAgcNome = false;
         A362NegAssunto = obj37.gxTpr_Negassunto;
         A363NegDescricao = obj37.gxTpr_Negdescricao;
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
         Z642NegCpjEndCep = obj37.gxTpr_Negcpjendcep_Z;
         Z643NegCpjEndCepFormat = obj37.gxTpr_Negcpjendcepformat_Z;
         Z375NegCpjEndMunID = obj37.gxTpr_Negcpjendmunid_Z;
         Z376NegCpjEndMunNome = obj37.gxTpr_Negcpjendmunnome_Z;
         Z377NegCpjEndUFID = obj37.gxTpr_Negcpjendufid_Z;
         Z378NegCpjEndUFSigla = obj37.gxTpr_Negcpjendufsigla_Z;
         Z379NegCpjEndUFNome = obj37.gxTpr_Negcpjendufnome_Z;
         Z641NegCpjEndCompleto = obj37.gxTpr_Negcpjendcompleto_Z;
         Z360NegAgcID = obj37.gxTpr_Negagcid_Z;
         Z361NegAgcNome = obj37.gxTpr_Negagcnome_Z;
         Z362NegAssunto = obj37.gxTpr_Negassunto_Z;
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

      public void VarsToRow42( GeneXus.Programs.core.SdtNegocioPJ_Item obj42 )
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

      public void KeyVarsToRow42( GeneXus.Programs.core.SdtNegocioPJ_Item obj42 )
      {
         obj42.gxTpr_Ngpitem = A435NgpItem;
         return  ;
      }

      public void RowToVars42( GeneXus.Programs.core.SdtNegocioPJ_Item obj42 ,
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
         InitializeNonKey0Y37( ) ;
         ScanKeyStart0Y37( ) ;
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
            O572NegDel = A572NegDel;
         }
         ZM0Y37( -54) ;
         OnLoadActions0Y37( ) ;
         AddRow0Y37( ) ;
         bccore_NegocioPJ.gxTpr_Item.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart0Y42( ) ;
            nGXsfl_42_idx = 1;
            while ( RcdFound42 != 0 )
            {
               O578NgpDel = A578NgpDel;
               O447NgpTotal = A447NgpTotal;
               Z345NegID = A345NegID;
               Z435NgpItem = A435NgpItem;
               ZM0Y42( -61) ;
               OnLoadActions0Y42( ) ;
               nRcdExists_42 = 1;
               nIsMod_42 = 0;
               Z578NgpDel = A578NgpDel;
               Z447NgpTotal = A447NgpTotal;
               AddRow0Y42( ) ;
               nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
               ScanKeyNext0Y42( ) ;
            }
            ScanKeyEnd0Y42( ) ;
         }
         ScanKeyEnd0Y37( ) ;
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
         RowToVars37( bccore_NegocioPJ, 0) ;
         ScanKeyStart0Y37( ) ;
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
            O572NegDel = A572NegDel;
         }
         ZM0Y37( -54) ;
         OnLoadActions0Y37( ) ;
         AddRow0Y37( ) ;
         bccore_NegocioPJ.gxTpr_Item.ClearCollection();
         if ( RcdFound37 == 1 )
         {
            ScanKeyStart0Y42( ) ;
            nGXsfl_42_idx = 1;
            while ( RcdFound42 != 0 )
            {
               O578NgpDel = A578NgpDel;
               O447NgpTotal = A447NgpTotal;
               Z345NegID = A345NegID;
               Z435NgpItem = A435NgpItem;
               ZM0Y42( -61) ;
               OnLoadActions0Y42( ) ;
               nRcdExists_42 = 1;
               nIsMod_42 = 0;
               Z578NgpDel = A578NgpDel;
               Z447NgpTotal = A447NgpTotal;
               AddRow0Y42( ) ;
               nGXsfl_42_idx = (int)(nGXsfl_42_idx+1);
               ScanKeyNext0Y42( ) ;
            }
            ScanKeyEnd0Y42( ) ;
         }
         ScanKeyEnd0Y37( ) ;
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
         GetKey0Y37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A454NegUltItem = O454NegUltItem;
            n454NegUltItem = false;
            A448NegPgpTotal = O448NegPgpTotal;
            n448NegPgpTotal = false;
            Insert0Y37( ) ;
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
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  Update0Y37( ) ;
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
                        A454NegUltItem = O454NegUltItem;
                        n454NegUltItem = false;
                        A448NegPgpTotal = O448NegPgpTotal;
                        n448NegPgpTotal = false;
                        Insert0Y37( ) ;
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
                        A454NegUltItem = O454NegUltItem;
                        n454NegUltItem = false;
                        A448NegPgpTotal = O448NegPgpTotal;
                        n448NegPgpTotal = false;
                        Insert0Y37( ) ;
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
         RowToVars37( bccore_NegocioPJ, 1) ;
         SaveImpl( ) ;
         VarsToRow37( bccore_NegocioPJ) ;
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
         RowToVars37( bccore_NegocioPJ, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         A448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         Insert0Y37( ) ;
         AfterTrn( ) ;
         VarsToRow37( bccore_NegocioPJ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow37( bccore_NegocioPJ) ;
         }
         else
         {
            GeneXus.Programs.core.SdtNegocioPJ auxBC = new GeneXus.Programs.core.SdtNegocioPJ(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A345NegID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_NegocioPJ);
               auxBC.Save();
               bccore_NegocioPJ.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars37( bccore_NegocioPJ, 1) ;
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
         RowToVars37( bccore_NegocioPJ, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Y37( ) ;
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
               VarsToRow37( bccore_NegocioPJ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow37( bccore_NegocioPJ) ;
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
         RowToVars37( bccore_NegocioPJ, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0Y37( ) ;
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
         context.RollbackDataStores("core.negociopj_bc",pr_default);
         VarsToRow37( bccore_NegocioPJ) ;
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
         Gx_mode = bccore_NegocioPJ.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_NegocioPJ.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_NegocioPJ )
         {
            bccore_NegocioPJ = (GeneXus.Programs.core.SdtNegocioPJ)(sdt);
            if ( StringUtil.StrCmp(bccore_NegocioPJ.gxTpr_Mode, "") == 0 )
            {
               bccore_NegocioPJ.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow37( bccore_NegocioPJ) ;
            }
            else
            {
               RowToVars37( bccore_NegocioPJ, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_NegocioPJ.gxTpr_Mode, "") == 0 )
            {
               bccore_NegocioPJ.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars37( bccore_NegocioPJ, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtNegocioPJ NegocioPJ_BC
      {
         get {
            return bccore_NegocioPJ ;
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
            return "negocio_Execute" ;
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
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(5);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(21);
         pr_default.close(20);
         pr_default.close(17);
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
         AV49Pgmname = "";
         AV7NegID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_NegCliID = Guid.Empty;
         AV14Insert_NegCpjID = Guid.Empty;
         AV47AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
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
         Z641NegCpjEndCompleto = "";
         A641NegCpjEndCompleto = "";
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
         Z643NegCpjEndCepFormat = "";
         A643NegCpjEndCepFormat = "";
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
         BC000Y13_A448NegPgpTotal = new decimal[1] ;
         BC000Y13_n448NegPgpTotal = new bool[] {false} ;
         BC000Y15_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y15_A356NegCodigo = new long[1] ;
         BC000Y15_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y15_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y15_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y15_A349NegInsUsuID = new string[] {""} ;
         BC000Y15_n349NegInsUsuID = new bool[] {false} ;
         BC000Y15_A364NegInsUsuNome = new string[] {""} ;
         BC000Y15_n364NegInsUsuNome = new bool[] {false} ;
         BC000Y15_A385NegValorAtualizado = new decimal[1] ;
         BC000Y15_A380NegValorEstimado = new decimal[1] ;
         BC000Y15_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y15_n573NegDelDataHora = new bool[] {false} ;
         BC000Y15_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y15_n574NegDelData = new bool[] {false} ;
         BC000Y15_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y15_n575NegDelHora = new bool[] {false} ;
         BC000Y15_A576NegDelUsuId = new string[] {""} ;
         BC000Y15_n576NegDelUsuId = new bool[] {false} ;
         BC000Y15_A577NegDelUsuNome = new string[] {""} ;
         BC000Y15_n577NegDelUsuNome = new bool[] {false} ;
         BC000Y15_A473NegCliMatricula = new long[1] ;
         BC000Y15_A351NegCliNomeFamiliar = new string[] {""} ;
         BC000Y15_A353NegCpjNomFan = new string[] {""} ;
         BC000Y15_A354NegCpjRazSocial = new string[] {""} ;
         BC000Y15_A355NegCpjMatricula = new long[1] ;
         BC000Y15_A358NegPjtSigla = new string[] {""} ;
         BC000Y15_A359NegPjtNome = new string[] {""} ;
         BC000Y15_A370NegCpjEndNome = new string[] {""} ;
         BC000Y15_A371NegCpjEndEndereco = new string[] {""} ;
         BC000Y15_A372NegCpjEndNumero = new string[] {""} ;
         BC000Y15_A373NegCpjEndComplem = new string[] {""} ;
         BC000Y15_n373NegCpjEndComplem = new bool[] {false} ;
         BC000Y15_A374NegCpjEndBairro = new string[] {""} ;
         BC000Y15_A642NegCpjEndCep = new int[1] ;
         BC000Y15_A643NegCpjEndCepFormat = new string[] {""} ;
         BC000Y15_A375NegCpjEndMunID = new int[1] ;
         BC000Y15_A376NegCpjEndMunNome = new string[] {""} ;
         BC000Y15_A377NegCpjEndUFID = new short[1] ;
         BC000Y15_A378NegCpjEndUFSigla = new string[] {""} ;
         BC000Y15_A379NegCpjEndUFNome = new string[] {""} ;
         BC000Y15_A360NegAgcID = new string[] {""} ;
         BC000Y15_n360NegAgcID = new bool[] {false} ;
         BC000Y15_A361NegAgcNome = new string[] {""} ;
         BC000Y15_n361NegAgcNome = new bool[] {false} ;
         BC000Y15_A362NegAssunto = new string[] {""} ;
         BC000Y15_A363NegDescricao = new string[] {""} ;
         BC000Y15_A454NegUltItem = new int[1] ;
         BC000Y15_n454NegUltItem = new bool[] {false} ;
         BC000Y15_A572NegDel = new bool[] {false} ;
         BC000Y15_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC000Y15_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC000Y15_A369NegCpjEndSeq = new short[1] ;
         BC000Y15_A357NegPjtID = new int[1] ;
         BC000Y15_A448NegPgpTotal = new decimal[1] ;
         BC000Y15_n448NegPgpTotal = new bool[] {false} ;
         BC000Y16_A356NegCodigo = new long[1] ;
         BC000Y8_A473NegCliMatricula = new long[1] ;
         BC000Y8_A351NegCliNomeFamiliar = new string[] {""} ;
         BC000Y9_A353NegCpjNomFan = new string[] {""} ;
         BC000Y9_A354NegCpjRazSocial = new string[] {""} ;
         BC000Y9_A355NegCpjMatricula = new long[1] ;
         BC000Y9_A357NegPjtID = new int[1] ;
         BC000Y11_A358NegPjtSigla = new string[] {""} ;
         BC000Y11_A359NegPjtNome = new string[] {""} ;
         BC000Y10_A370NegCpjEndNome = new string[] {""} ;
         BC000Y10_A371NegCpjEndEndereco = new string[] {""} ;
         BC000Y10_A372NegCpjEndNumero = new string[] {""} ;
         BC000Y10_A373NegCpjEndComplem = new string[] {""} ;
         BC000Y10_n373NegCpjEndComplem = new bool[] {false} ;
         BC000Y10_A374NegCpjEndBairro = new string[] {""} ;
         BC000Y10_A642NegCpjEndCep = new int[1] ;
         BC000Y10_A643NegCpjEndCepFormat = new string[] {""} ;
         BC000Y10_A375NegCpjEndMunID = new int[1] ;
         BC000Y10_A376NegCpjEndMunNome = new string[] {""} ;
         BC000Y10_A377NegCpjEndUFID = new short[1] ;
         BC000Y10_A378NegCpjEndUFSigla = new string[] {""} ;
         BC000Y10_A379NegCpjEndUFNome = new string[] {""} ;
         BC000Y17_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y7_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y7_A356NegCodigo = new long[1] ;
         BC000Y7_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y7_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y7_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y7_A349NegInsUsuID = new string[] {""} ;
         BC000Y7_n349NegInsUsuID = new bool[] {false} ;
         BC000Y7_A364NegInsUsuNome = new string[] {""} ;
         BC000Y7_n364NegInsUsuNome = new bool[] {false} ;
         BC000Y7_A385NegValorAtualizado = new decimal[1] ;
         BC000Y7_A380NegValorEstimado = new decimal[1] ;
         BC000Y7_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y7_n573NegDelDataHora = new bool[] {false} ;
         BC000Y7_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y7_n574NegDelData = new bool[] {false} ;
         BC000Y7_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y7_n575NegDelHora = new bool[] {false} ;
         BC000Y7_A576NegDelUsuId = new string[] {""} ;
         BC000Y7_n576NegDelUsuId = new bool[] {false} ;
         BC000Y7_A577NegDelUsuNome = new string[] {""} ;
         BC000Y7_n577NegDelUsuNome = new bool[] {false} ;
         BC000Y7_A360NegAgcID = new string[] {""} ;
         BC000Y7_n360NegAgcID = new bool[] {false} ;
         BC000Y7_A361NegAgcNome = new string[] {""} ;
         BC000Y7_n361NegAgcNome = new bool[] {false} ;
         BC000Y7_A362NegAssunto = new string[] {""} ;
         BC000Y7_A363NegDescricao = new string[] {""} ;
         BC000Y7_A454NegUltItem = new int[1] ;
         BC000Y7_n454NegUltItem = new bool[] {false} ;
         BC000Y7_A572NegDel = new bool[] {false} ;
         BC000Y7_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC000Y7_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC000Y7_A369NegCpjEndSeq = new short[1] ;
         BC000Y7_A351NegCliNomeFamiliar = new string[] {""} ;
         BC000Y7_A353NegCpjNomFan = new string[] {""} ;
         BC000Y7_A354NegCpjRazSocial = new string[] {""} ;
         BC000Y7_A359NegPjtNome = new string[] {""} ;
         BC000Y6_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y6_A356NegCodigo = new long[1] ;
         BC000Y6_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y6_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y6_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y6_A349NegInsUsuID = new string[] {""} ;
         BC000Y6_n349NegInsUsuID = new bool[] {false} ;
         BC000Y6_A364NegInsUsuNome = new string[] {""} ;
         BC000Y6_n364NegInsUsuNome = new bool[] {false} ;
         BC000Y6_A385NegValorAtualizado = new decimal[1] ;
         BC000Y6_A380NegValorEstimado = new decimal[1] ;
         BC000Y6_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y6_n573NegDelDataHora = new bool[] {false} ;
         BC000Y6_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y6_n574NegDelData = new bool[] {false} ;
         BC000Y6_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y6_n575NegDelHora = new bool[] {false} ;
         BC000Y6_A576NegDelUsuId = new string[] {""} ;
         BC000Y6_n576NegDelUsuId = new bool[] {false} ;
         BC000Y6_A577NegDelUsuNome = new string[] {""} ;
         BC000Y6_n577NegDelUsuNome = new bool[] {false} ;
         BC000Y6_A360NegAgcID = new string[] {""} ;
         BC000Y6_n360NegAgcID = new bool[] {false} ;
         BC000Y6_A361NegAgcNome = new string[] {""} ;
         BC000Y6_n361NegAgcNome = new bool[] {false} ;
         BC000Y6_A362NegAssunto = new string[] {""} ;
         BC000Y6_A363NegDescricao = new string[] {""} ;
         BC000Y6_A454NegUltItem = new int[1] ;
         BC000Y6_n454NegUltItem = new bool[] {false} ;
         BC000Y6_A572NegDel = new bool[] {false} ;
         BC000Y6_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC000Y6_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC000Y6_A369NegCpjEndSeq = new short[1] ;
         BC000Y6_A351NegCliNomeFamiliar = new string[] {""} ;
         BC000Y6_A353NegCpjNomFan = new string[] {""} ;
         BC000Y6_A354NegCpjRazSocial = new string[] {""} ;
         BC000Y6_A359NegPjtNome = new string[] {""} ;
         BC000Y22_A448NegPgpTotal = new decimal[1] ;
         BC000Y22_n448NegPgpTotal = new bool[] {false} ;
         BC000Y23_A473NegCliMatricula = new long[1] ;
         BC000Y23_A351NegCliNomeFamiliar = new string[] {""} ;
         BC000Y24_A353NegCpjNomFan = new string[] {""} ;
         BC000Y24_A354NegCpjRazSocial = new string[] {""} ;
         BC000Y24_A355NegCpjMatricula = new long[1] ;
         BC000Y24_A357NegPjtID = new int[1] ;
         BC000Y25_A358NegPjtSigla = new string[] {""} ;
         BC000Y25_A359NegPjtNome = new string[] {""} ;
         BC000Y26_A370NegCpjEndNome = new string[] {""} ;
         BC000Y26_A371NegCpjEndEndereco = new string[] {""} ;
         BC000Y26_A372NegCpjEndNumero = new string[] {""} ;
         BC000Y26_A373NegCpjEndComplem = new string[] {""} ;
         BC000Y26_n373NegCpjEndComplem = new bool[] {false} ;
         BC000Y26_A374NegCpjEndBairro = new string[] {""} ;
         BC000Y26_A642NegCpjEndCep = new int[1] ;
         BC000Y26_A643NegCpjEndCepFormat = new string[] {""} ;
         BC000Y26_A375NegCpjEndMunID = new int[1] ;
         BC000Y26_A376NegCpjEndMunNome = new string[] {""} ;
         BC000Y26_A377NegCpjEndUFID = new short[1] ;
         BC000Y26_A378NegCpjEndUFSigla = new string[] {""} ;
         BC000Y26_A379NegCpjEndUFNome = new string[] {""} ;
         BC000Y27_A398VisID = new Guid[] {Guid.Empty} ;
         BC000Y28_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y28_A626NefChave = new string[] {""} ;
         BC000Y29_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y29_A387NgfSeq = new int[1] ;
         BC000Y32_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y32_A356NegCodigo = new long[1] ;
         BC000Y32_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y32_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y32_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y32_A349NegInsUsuID = new string[] {""} ;
         BC000Y32_n349NegInsUsuID = new bool[] {false} ;
         BC000Y32_A364NegInsUsuNome = new string[] {""} ;
         BC000Y32_n364NegInsUsuNome = new bool[] {false} ;
         BC000Y32_A385NegValorAtualizado = new decimal[1] ;
         BC000Y32_A380NegValorEstimado = new decimal[1] ;
         BC000Y32_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y32_n573NegDelDataHora = new bool[] {false} ;
         BC000Y32_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y32_n574NegDelData = new bool[] {false} ;
         BC000Y32_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y32_n575NegDelHora = new bool[] {false} ;
         BC000Y32_A576NegDelUsuId = new string[] {""} ;
         BC000Y32_n576NegDelUsuId = new bool[] {false} ;
         BC000Y32_A577NegDelUsuNome = new string[] {""} ;
         BC000Y32_n577NegDelUsuNome = new bool[] {false} ;
         BC000Y32_A473NegCliMatricula = new long[1] ;
         BC000Y32_A351NegCliNomeFamiliar = new string[] {""} ;
         BC000Y32_A353NegCpjNomFan = new string[] {""} ;
         BC000Y32_A354NegCpjRazSocial = new string[] {""} ;
         BC000Y32_A355NegCpjMatricula = new long[1] ;
         BC000Y32_A358NegPjtSigla = new string[] {""} ;
         BC000Y32_A359NegPjtNome = new string[] {""} ;
         BC000Y32_A370NegCpjEndNome = new string[] {""} ;
         BC000Y32_A371NegCpjEndEndereco = new string[] {""} ;
         BC000Y32_A372NegCpjEndNumero = new string[] {""} ;
         BC000Y32_A373NegCpjEndComplem = new string[] {""} ;
         BC000Y32_n373NegCpjEndComplem = new bool[] {false} ;
         BC000Y32_A374NegCpjEndBairro = new string[] {""} ;
         BC000Y32_A642NegCpjEndCep = new int[1] ;
         BC000Y32_A643NegCpjEndCepFormat = new string[] {""} ;
         BC000Y32_A375NegCpjEndMunID = new int[1] ;
         BC000Y32_A376NegCpjEndMunNome = new string[] {""} ;
         BC000Y32_A377NegCpjEndUFID = new short[1] ;
         BC000Y32_A378NegCpjEndUFSigla = new string[] {""} ;
         BC000Y32_A379NegCpjEndUFNome = new string[] {""} ;
         BC000Y32_A360NegAgcID = new string[] {""} ;
         BC000Y32_n360NegAgcID = new bool[] {false} ;
         BC000Y32_A361NegAgcNome = new string[] {""} ;
         BC000Y32_n361NegAgcNome = new bool[] {false} ;
         BC000Y32_A362NegAssunto = new string[] {""} ;
         BC000Y32_A363NegDescricao = new string[] {""} ;
         BC000Y32_A454NegUltItem = new int[1] ;
         BC000Y32_n454NegUltItem = new bool[] {false} ;
         BC000Y32_A572NegDel = new bool[] {false} ;
         BC000Y32_A350NegCliID = new Guid[] {Guid.Empty} ;
         BC000Y32_A352NegCpjID = new Guid[] {Guid.Empty} ;
         BC000Y32_A369NegCpjEndSeq = new short[1] ;
         BC000Y32_A357NegPjtID = new int[1] ;
         BC000Y32_A448NegPgpTotal = new decimal[1] ;
         BC000Y32_n448NegPgpTotal = new bool[] {false} ;
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
         BC000Y33_A447NgpTotal = new decimal[1] ;
         BC000Y33_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y33_A435NgpItem = new int[1] ;
         BC000Y33_A446NgpQtde = new int[1] ;
         BC000Y33_A445NgpPreco = new decimal[1] ;
         BC000Y33_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y33_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y33_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y33_A458NgpInsUsuID = new string[] {""} ;
         BC000Y33_n458NgpInsUsuID = new bool[] {false} ;
         BC000Y33_A459NgpInsUsuNome = new string[] {""} ;
         BC000Y33_n459NgpInsUsuNome = new bool[] {false} ;
         BC000Y33_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y33_n579NgpDelDataHora = new bool[] {false} ;
         BC000Y33_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y33_n580NgpDelData = new bool[] {false} ;
         BC000Y33_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y33_n581NgpDelHora = new bool[] {false} ;
         BC000Y33_A582NgpDelUsuId = new string[] {""} ;
         BC000Y33_n582NgpDelUsuId = new bool[] {false} ;
         BC000Y33_A583NgpDelUsuNome = new string[] {""} ;
         BC000Y33_n583NgpDelUsuNome = new bool[] {false} ;
         BC000Y33_A440NgpTppPrdCodigo = new string[] {""} ;
         BC000Y33_A441NgpTppPrdNome = new string[] {""} ;
         BC000Y33_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC000Y33_A444NgpTpp1Preco = new decimal[1] ;
         BC000Y33_A453NgpObs = new string[] {""} ;
         BC000Y33_A578NgpDel = new bool[] {false} ;
         BC000Y33_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC000Y33_A478NgpTppID = new Guid[] {Guid.Empty} ;
         BC000Y33_A442NgpTppPrdTipoID = new int[1] ;
         BC000Y5_A444NgpTpp1Preco = new decimal[1] ;
         BC000Y4_A440NgpTppPrdCodigo = new string[] {""} ;
         BC000Y4_A441NgpTppPrdNome = new string[] {""} ;
         BC000Y4_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC000Y4_A442NgpTppPrdTipoID = new int[1] ;
         BC000Y34_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y34_A435NgpItem = new int[1] ;
         BC000Y3_A447NgpTotal = new decimal[1] ;
         BC000Y3_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y3_A435NgpItem = new int[1] ;
         BC000Y3_A446NgpQtde = new int[1] ;
         BC000Y3_A445NgpPreco = new decimal[1] ;
         BC000Y3_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_A458NgpInsUsuID = new string[] {""} ;
         BC000Y3_n458NgpInsUsuID = new bool[] {false} ;
         BC000Y3_A459NgpInsUsuNome = new string[] {""} ;
         BC000Y3_n459NgpInsUsuNome = new bool[] {false} ;
         BC000Y3_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_n579NgpDelDataHora = new bool[] {false} ;
         BC000Y3_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_n580NgpDelData = new bool[] {false} ;
         BC000Y3_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y3_n581NgpDelHora = new bool[] {false} ;
         BC000Y3_A582NgpDelUsuId = new string[] {""} ;
         BC000Y3_n582NgpDelUsuId = new bool[] {false} ;
         BC000Y3_A583NgpDelUsuNome = new string[] {""} ;
         BC000Y3_n583NgpDelUsuNome = new bool[] {false} ;
         BC000Y3_A453NgpObs = new string[] {""} ;
         BC000Y3_A578NgpDel = new bool[] {false} ;
         BC000Y3_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC000Y3_A478NgpTppID = new Guid[] {Guid.Empty} ;
         sMode42 = "";
         BC000Y2_A447NgpTotal = new decimal[1] ;
         BC000Y2_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y2_A435NgpItem = new int[1] ;
         BC000Y2_A446NgpQtde = new int[1] ;
         BC000Y2_A445NgpPreco = new decimal[1] ;
         BC000Y2_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_A458NgpInsUsuID = new string[] {""} ;
         BC000Y2_n458NgpInsUsuID = new bool[] {false} ;
         BC000Y2_A459NgpInsUsuNome = new string[] {""} ;
         BC000Y2_n459NgpInsUsuNome = new bool[] {false} ;
         BC000Y2_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_n579NgpDelDataHora = new bool[] {false} ;
         BC000Y2_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_n580NgpDelData = new bool[] {false} ;
         BC000Y2_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y2_n581NgpDelHora = new bool[] {false} ;
         BC000Y2_A582NgpDelUsuId = new string[] {""} ;
         BC000Y2_n582NgpDelUsuId = new bool[] {false} ;
         BC000Y2_A583NgpDelUsuNome = new string[] {""} ;
         BC000Y2_n583NgpDelUsuNome = new bool[] {false} ;
         BC000Y2_A453NgpObs = new string[] {""} ;
         BC000Y2_A578NgpDel = new bool[] {false} ;
         BC000Y2_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC000Y2_A478NgpTppID = new Guid[] {Guid.Empty} ;
         BC000Y38_A440NgpTppPrdCodigo = new string[] {""} ;
         BC000Y38_A441NgpTppPrdNome = new string[] {""} ;
         BC000Y38_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC000Y38_A442NgpTppPrdTipoID = new int[1] ;
         BC000Y39_A444NgpTpp1Preco = new decimal[1] ;
         BC000Y40_A447NgpTotal = new decimal[1] ;
         BC000Y40_A345NegID = new Guid[] {Guid.Empty} ;
         BC000Y40_A435NgpItem = new int[1] ;
         BC000Y40_A446NgpQtde = new int[1] ;
         BC000Y40_A445NgpPreco = new decimal[1] ;
         BC000Y40_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y40_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         BC000Y40_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y40_A458NgpInsUsuID = new string[] {""} ;
         BC000Y40_n458NgpInsUsuID = new bool[] {false} ;
         BC000Y40_A459NgpInsUsuNome = new string[] {""} ;
         BC000Y40_n459NgpInsUsuNome = new bool[] {false} ;
         BC000Y40_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y40_n579NgpDelDataHora = new bool[] {false} ;
         BC000Y40_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Y40_n580NgpDelData = new bool[] {false} ;
         BC000Y40_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Y40_n581NgpDelHora = new bool[] {false} ;
         BC000Y40_A582NgpDelUsuId = new string[] {""} ;
         BC000Y40_n582NgpDelUsuId = new bool[] {false} ;
         BC000Y40_A583NgpDelUsuNome = new string[] {""} ;
         BC000Y40_n583NgpDelUsuNome = new bool[] {false} ;
         BC000Y40_A440NgpTppPrdCodigo = new string[] {""} ;
         BC000Y40_A441NgpTppPrdNome = new string[] {""} ;
         BC000Y40_A443NgpTppPrdAtivo = new bool[] {false} ;
         BC000Y40_A444NgpTpp1Preco = new decimal[1] ;
         BC000Y40_A453NgpObs = new string[] {""} ;
         BC000Y40_A578NgpDel = new bool[] {false} ;
         BC000Y40_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         BC000Y40_A478NgpTppID = new Guid[] {Guid.Empty} ;
         BC000Y40_A442NgpTppPrdTipoID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.negociopj_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopj_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Y2_A447NgpTotal, BC000Y2_A345NegID, BC000Y2_A435NgpItem, BC000Y2_A446NgpQtde, BC000Y2_A445NgpPreco, BC000Y2_A457NgpInsDataHora, BC000Y2_A455NgpInsData, BC000Y2_A456NgpInsHora, BC000Y2_A458NgpInsUsuID, BC000Y2_n458NgpInsUsuID,
               BC000Y2_A459NgpInsUsuNome, BC000Y2_n459NgpInsUsuNome, BC000Y2_A579NgpDelDataHora, BC000Y2_n579NgpDelDataHora, BC000Y2_A580NgpDelData, BC000Y2_n580NgpDelData, BC000Y2_A581NgpDelHora, BC000Y2_n581NgpDelHora, BC000Y2_A582NgpDelUsuId, BC000Y2_n582NgpDelUsuId,
               BC000Y2_A583NgpDelUsuNome, BC000Y2_n583NgpDelUsuNome, BC000Y2_A453NgpObs, BC000Y2_A578NgpDel, BC000Y2_A439NgpTppPrdID, BC000Y2_A478NgpTppID
               }
               , new Object[] {
               BC000Y3_A447NgpTotal, BC000Y3_A345NegID, BC000Y3_A435NgpItem, BC000Y3_A446NgpQtde, BC000Y3_A445NgpPreco, BC000Y3_A457NgpInsDataHora, BC000Y3_A455NgpInsData, BC000Y3_A456NgpInsHora, BC000Y3_A458NgpInsUsuID, BC000Y3_n458NgpInsUsuID,
               BC000Y3_A459NgpInsUsuNome, BC000Y3_n459NgpInsUsuNome, BC000Y3_A579NgpDelDataHora, BC000Y3_n579NgpDelDataHora, BC000Y3_A580NgpDelData, BC000Y3_n580NgpDelData, BC000Y3_A581NgpDelHora, BC000Y3_n581NgpDelHora, BC000Y3_A582NgpDelUsuId, BC000Y3_n582NgpDelUsuId,
               BC000Y3_A583NgpDelUsuNome, BC000Y3_n583NgpDelUsuNome, BC000Y3_A453NgpObs, BC000Y3_A578NgpDel, BC000Y3_A439NgpTppPrdID, BC000Y3_A478NgpTppID
               }
               , new Object[] {
               BC000Y4_A440NgpTppPrdCodigo, BC000Y4_A441NgpTppPrdNome, BC000Y4_A443NgpTppPrdAtivo, BC000Y4_A442NgpTppPrdTipoID
               }
               , new Object[] {
               BC000Y5_A444NgpTpp1Preco
               }
               , new Object[] {
               BC000Y6_A345NegID, BC000Y6_A356NegCodigo, BC000Y6_A348NegInsDataHora, BC000Y6_A346NegInsData, BC000Y6_A347NegInsHora, BC000Y6_A349NegInsUsuID, BC000Y6_n349NegInsUsuID, BC000Y6_A364NegInsUsuNome, BC000Y6_n364NegInsUsuNome, BC000Y6_A385NegValorAtualizado,
               BC000Y6_A380NegValorEstimado, BC000Y6_A573NegDelDataHora, BC000Y6_n573NegDelDataHora, BC000Y6_A574NegDelData, BC000Y6_n574NegDelData, BC000Y6_A575NegDelHora, BC000Y6_n575NegDelHora, BC000Y6_A576NegDelUsuId, BC000Y6_n576NegDelUsuId, BC000Y6_A577NegDelUsuNome,
               BC000Y6_n577NegDelUsuNome, BC000Y6_A360NegAgcID, BC000Y6_n360NegAgcID, BC000Y6_A361NegAgcNome, BC000Y6_n361NegAgcNome, BC000Y6_A362NegAssunto, BC000Y6_A363NegDescricao, BC000Y6_A454NegUltItem, BC000Y6_n454NegUltItem, BC000Y6_A572NegDel,
               BC000Y6_A350NegCliID, BC000Y6_A352NegCpjID, BC000Y6_A369NegCpjEndSeq, BC000Y6_A351NegCliNomeFamiliar, BC000Y6_A353NegCpjNomFan, BC000Y6_A354NegCpjRazSocial, BC000Y6_A359NegPjtNome
               }
               , new Object[] {
               BC000Y7_A345NegID, BC000Y7_A356NegCodigo, BC000Y7_A348NegInsDataHora, BC000Y7_A346NegInsData, BC000Y7_A347NegInsHora, BC000Y7_A349NegInsUsuID, BC000Y7_n349NegInsUsuID, BC000Y7_A364NegInsUsuNome, BC000Y7_n364NegInsUsuNome, BC000Y7_A385NegValorAtualizado,
               BC000Y7_A380NegValorEstimado, BC000Y7_A573NegDelDataHora, BC000Y7_n573NegDelDataHora, BC000Y7_A574NegDelData, BC000Y7_n574NegDelData, BC000Y7_A575NegDelHora, BC000Y7_n575NegDelHora, BC000Y7_A576NegDelUsuId, BC000Y7_n576NegDelUsuId, BC000Y7_A577NegDelUsuNome,
               BC000Y7_n577NegDelUsuNome, BC000Y7_A360NegAgcID, BC000Y7_n360NegAgcID, BC000Y7_A361NegAgcNome, BC000Y7_n361NegAgcNome, BC000Y7_A362NegAssunto, BC000Y7_A363NegDescricao, BC000Y7_A454NegUltItem, BC000Y7_n454NegUltItem, BC000Y7_A572NegDel,
               BC000Y7_A350NegCliID, BC000Y7_A352NegCpjID, BC000Y7_A369NegCpjEndSeq, BC000Y7_A351NegCliNomeFamiliar, BC000Y7_A353NegCpjNomFan, BC000Y7_A354NegCpjRazSocial, BC000Y7_A359NegPjtNome
               }
               , new Object[] {
               BC000Y8_A473NegCliMatricula, BC000Y8_A351NegCliNomeFamiliar
               }
               , new Object[] {
               BC000Y9_A353NegCpjNomFan, BC000Y9_A354NegCpjRazSocial, BC000Y9_A355NegCpjMatricula, BC000Y9_A357NegPjtID
               }
               , new Object[] {
               BC000Y10_A370NegCpjEndNome, BC000Y10_A371NegCpjEndEndereco, BC000Y10_A372NegCpjEndNumero, BC000Y10_A373NegCpjEndComplem, BC000Y10_n373NegCpjEndComplem, BC000Y10_A374NegCpjEndBairro, BC000Y10_A642NegCpjEndCep, BC000Y10_A643NegCpjEndCepFormat, BC000Y10_A375NegCpjEndMunID, BC000Y10_A376NegCpjEndMunNome,
               BC000Y10_A377NegCpjEndUFID, BC000Y10_A378NegCpjEndUFSigla, BC000Y10_A379NegCpjEndUFNome
               }
               , new Object[] {
               BC000Y11_A358NegPjtSigla, BC000Y11_A359NegPjtNome
               }
               , new Object[] {
               BC000Y13_A448NegPgpTotal, BC000Y13_n448NegPgpTotal
               }
               , new Object[] {
               BC000Y15_A345NegID, BC000Y15_A356NegCodigo, BC000Y15_A348NegInsDataHora, BC000Y15_A346NegInsData, BC000Y15_A347NegInsHora, BC000Y15_A349NegInsUsuID, BC000Y15_n349NegInsUsuID, BC000Y15_A364NegInsUsuNome, BC000Y15_n364NegInsUsuNome, BC000Y15_A385NegValorAtualizado,
               BC000Y15_A380NegValorEstimado, BC000Y15_A573NegDelDataHora, BC000Y15_n573NegDelDataHora, BC000Y15_A574NegDelData, BC000Y15_n574NegDelData, BC000Y15_A575NegDelHora, BC000Y15_n575NegDelHora, BC000Y15_A576NegDelUsuId, BC000Y15_n576NegDelUsuId, BC000Y15_A577NegDelUsuNome,
               BC000Y15_n577NegDelUsuNome, BC000Y15_A473NegCliMatricula, BC000Y15_A351NegCliNomeFamiliar, BC000Y15_A353NegCpjNomFan, BC000Y15_A354NegCpjRazSocial, BC000Y15_A355NegCpjMatricula, BC000Y15_A358NegPjtSigla, BC000Y15_A359NegPjtNome, BC000Y15_A370NegCpjEndNome, BC000Y15_A371NegCpjEndEndereco,
               BC000Y15_A372NegCpjEndNumero, BC000Y15_A373NegCpjEndComplem, BC000Y15_n373NegCpjEndComplem, BC000Y15_A374NegCpjEndBairro, BC000Y15_A642NegCpjEndCep, BC000Y15_A643NegCpjEndCepFormat, BC000Y15_A375NegCpjEndMunID, BC000Y15_A376NegCpjEndMunNome, BC000Y15_A377NegCpjEndUFID, BC000Y15_A378NegCpjEndUFSigla,
               BC000Y15_A379NegCpjEndUFNome, BC000Y15_A360NegAgcID, BC000Y15_n360NegAgcID, BC000Y15_A361NegAgcNome, BC000Y15_n361NegAgcNome, BC000Y15_A362NegAssunto, BC000Y15_A363NegDescricao, BC000Y15_A454NegUltItem, BC000Y15_n454NegUltItem, BC000Y15_A572NegDel,
               BC000Y15_A350NegCliID, BC000Y15_A352NegCpjID, BC000Y15_A369NegCpjEndSeq, BC000Y15_A357NegPjtID, BC000Y15_A448NegPgpTotal, BC000Y15_n448NegPgpTotal
               }
               , new Object[] {
               BC000Y16_A356NegCodigo
               }
               , new Object[] {
               BC000Y17_A345NegID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Y22_A448NegPgpTotal, BC000Y22_n448NegPgpTotal
               }
               , new Object[] {
               BC000Y23_A473NegCliMatricula, BC000Y23_A351NegCliNomeFamiliar
               }
               , new Object[] {
               BC000Y24_A353NegCpjNomFan, BC000Y24_A354NegCpjRazSocial, BC000Y24_A355NegCpjMatricula, BC000Y24_A357NegPjtID
               }
               , new Object[] {
               BC000Y25_A358NegPjtSigla, BC000Y25_A359NegPjtNome
               }
               , new Object[] {
               BC000Y26_A370NegCpjEndNome, BC000Y26_A371NegCpjEndEndereco, BC000Y26_A372NegCpjEndNumero, BC000Y26_A373NegCpjEndComplem, BC000Y26_n373NegCpjEndComplem, BC000Y26_A374NegCpjEndBairro, BC000Y26_A642NegCpjEndCep, BC000Y26_A643NegCpjEndCepFormat, BC000Y26_A375NegCpjEndMunID, BC000Y26_A376NegCpjEndMunNome,
               BC000Y26_A377NegCpjEndUFID, BC000Y26_A378NegCpjEndUFSigla, BC000Y26_A379NegCpjEndUFNome
               }
               , new Object[] {
               BC000Y27_A398VisID
               }
               , new Object[] {
               BC000Y28_A345NegID, BC000Y28_A626NefChave
               }
               , new Object[] {
               BC000Y29_A345NegID, BC000Y29_A387NgfSeq
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Y32_A345NegID, BC000Y32_A356NegCodigo, BC000Y32_A348NegInsDataHora, BC000Y32_A346NegInsData, BC000Y32_A347NegInsHora, BC000Y32_A349NegInsUsuID, BC000Y32_n349NegInsUsuID, BC000Y32_A364NegInsUsuNome, BC000Y32_n364NegInsUsuNome, BC000Y32_A385NegValorAtualizado,
               BC000Y32_A380NegValorEstimado, BC000Y32_A573NegDelDataHora, BC000Y32_n573NegDelDataHora, BC000Y32_A574NegDelData, BC000Y32_n574NegDelData, BC000Y32_A575NegDelHora, BC000Y32_n575NegDelHora, BC000Y32_A576NegDelUsuId, BC000Y32_n576NegDelUsuId, BC000Y32_A577NegDelUsuNome,
               BC000Y32_n577NegDelUsuNome, BC000Y32_A473NegCliMatricula, BC000Y32_A351NegCliNomeFamiliar, BC000Y32_A353NegCpjNomFan, BC000Y32_A354NegCpjRazSocial, BC000Y32_A355NegCpjMatricula, BC000Y32_A358NegPjtSigla, BC000Y32_A359NegPjtNome, BC000Y32_A370NegCpjEndNome, BC000Y32_A371NegCpjEndEndereco,
               BC000Y32_A372NegCpjEndNumero, BC000Y32_A373NegCpjEndComplem, BC000Y32_n373NegCpjEndComplem, BC000Y32_A374NegCpjEndBairro, BC000Y32_A642NegCpjEndCep, BC000Y32_A643NegCpjEndCepFormat, BC000Y32_A375NegCpjEndMunID, BC000Y32_A376NegCpjEndMunNome, BC000Y32_A377NegCpjEndUFID, BC000Y32_A378NegCpjEndUFSigla,
               BC000Y32_A379NegCpjEndUFNome, BC000Y32_A360NegAgcID, BC000Y32_n360NegAgcID, BC000Y32_A361NegAgcNome, BC000Y32_n361NegAgcNome, BC000Y32_A362NegAssunto, BC000Y32_A363NegDescricao, BC000Y32_A454NegUltItem, BC000Y32_n454NegUltItem, BC000Y32_A572NegDel,
               BC000Y32_A350NegCliID, BC000Y32_A352NegCpjID, BC000Y32_A369NegCpjEndSeq, BC000Y32_A357NegPjtID, BC000Y32_A448NegPgpTotal, BC000Y32_n448NegPgpTotal
               }
               , new Object[] {
               BC000Y33_A447NgpTotal, BC000Y33_A345NegID, BC000Y33_A435NgpItem, BC000Y33_A446NgpQtde, BC000Y33_A445NgpPreco, BC000Y33_A457NgpInsDataHora, BC000Y33_A455NgpInsData, BC000Y33_A456NgpInsHora, BC000Y33_A458NgpInsUsuID, BC000Y33_n458NgpInsUsuID,
               BC000Y33_A459NgpInsUsuNome, BC000Y33_n459NgpInsUsuNome, BC000Y33_A579NgpDelDataHora, BC000Y33_n579NgpDelDataHora, BC000Y33_A580NgpDelData, BC000Y33_n580NgpDelData, BC000Y33_A581NgpDelHora, BC000Y33_n581NgpDelHora, BC000Y33_A582NgpDelUsuId, BC000Y33_n582NgpDelUsuId,
               BC000Y33_A583NgpDelUsuNome, BC000Y33_n583NgpDelUsuNome, BC000Y33_A440NgpTppPrdCodigo, BC000Y33_A441NgpTppPrdNome, BC000Y33_A443NgpTppPrdAtivo, BC000Y33_A444NgpTpp1Preco, BC000Y33_A453NgpObs, BC000Y33_A578NgpDel, BC000Y33_A439NgpTppPrdID, BC000Y33_A478NgpTppID,
               BC000Y33_A442NgpTppPrdTipoID
               }
               , new Object[] {
               BC000Y34_A345NegID, BC000Y34_A435NgpItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Y38_A440NgpTppPrdCodigo, BC000Y38_A441NgpTppPrdNome, BC000Y38_A443NgpTppPrdAtivo, BC000Y38_A442NgpTppPrdTipoID
               }
               , new Object[] {
               BC000Y39_A444NgpTpp1Preco
               }
               , new Object[] {
               BC000Y40_A447NgpTotal, BC000Y40_A345NegID, BC000Y40_A435NgpItem, BC000Y40_A446NgpQtde, BC000Y40_A445NgpPreco, BC000Y40_A457NgpInsDataHora, BC000Y40_A455NgpInsData, BC000Y40_A456NgpInsHora, BC000Y40_A458NgpInsUsuID, BC000Y40_n458NgpInsUsuID,
               BC000Y40_A459NgpInsUsuNome, BC000Y40_n459NgpInsUsuNome, BC000Y40_A579NgpDelDataHora, BC000Y40_n579NgpDelDataHora, BC000Y40_A580NgpDelData, BC000Y40_n580NgpDelData, BC000Y40_A581NgpDelHora, BC000Y40_n581NgpDelHora, BC000Y40_A582NgpDelUsuId, BC000Y40_n582NgpDelUsuId,
               BC000Y40_A583NgpDelUsuNome, BC000Y40_n583NgpDelUsuNome, BC000Y40_A440NgpTppPrdCodigo, BC000Y40_A441NgpTppPrdNome, BC000Y40_A443NgpTppPrdAtivo, BC000Y40_A444NgpTpp1Preco, BC000Y40_A453NgpObs, BC000Y40_A578NgpDel, BC000Y40_A439NgpTppPrdID, BC000Y40_A478NgpTppID,
               BC000Y40_A442NgpTppPrdTipoID
               }
            }
         );
         Z446NgpQtde = 1;
         A446NgpQtde = 1;
         i446NgpQtde = 1;
         Z345NegID = Guid.NewGuid( );
         A345NegID = Guid.NewGuid( );
         AV49Pgmname = "core.NegocioPJ_BC";
         Z445NgpPreco = 0;
         A445NgpPreco = 0;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120Y2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_42 ;
      private short RcdFound42 ;
      private short AV28Insert_NegCpjEndSeq ;
      private short GX_JID ;
      private short Z369NegCpjEndSeq ;
      private short A369NegCpjEndSeq ;
      private short Z377NegCpjEndUFID ;
      private short A377NegCpjEndUFID ;
      private short Gx_BScreen ;
      private short RcdFound37 ;
      private short nIsDirty_37 ;
      private short nRcdExists_42 ;
      private short Gxremove42 ;
      private short nIsDirty_42 ;
      private int trnEnded ;
      private int s454NegUltItem ;
      private int O454NegUltItem ;
      private int A454NegUltItem ;
      private int nGXsfl_42_idx=1 ;
      private int AV50GXV1 ;
      private int Z454NegUltItem ;
      private int Z357NegPjtID ;
      private int A357NegPjtID ;
      private int Z642NegCpjEndCep ;
      private int A642NegCpjEndCep ;
      private int Z375NegCpjEndMunID ;
      private int A375NegCpjEndMunID ;
      private int GXt_int1 ;
      private int Z446NgpQtde ;
      private int A446NgpQtde ;
      private int Z442NgpTppPrdTipoID ;
      private int A442NgpTppPrdTipoID ;
      private int Z435NgpItem ;
      private int A435NgpItem ;
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
      private decimal Z385NegValorAtualizado ;
      private decimal A385NegValorAtualizado ;
      private decimal Z380NegValorEstimado ;
      private decimal A380NegValorEstimado ;
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
      private string AV49Pgmname ;
      private string Z349NegInsUsuID ;
      private string A349NegInsUsuID ;
      private string Z576NegDelUsuId ;
      private string A576NegDelUsuId ;
      private string Z360NegAgcID ;
      private string A360NegAgcID ;
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
      private DateTime Z455NgpInsData ;
      private DateTime A455NgpInsData ;
      private bool n454NegUltItem ;
      private bool n448NegPgpTotal ;
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
      private string Z364NegInsUsuNome ;
      private string A364NegInsUsuNome ;
      private string Z577NegDelUsuNome ;
      private string A577NegDelUsuNome ;
      private string Z361NegAgcNome ;
      private string A361NegAgcNome ;
      private string Z362NegAssunto ;
      private string A362NegAssunto ;
      private string Z641NegCpjEndCompleto ;
      private string A641NegCpjEndCompleto ;
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
      private string Z643NegCpjEndCepFormat ;
      private string A643NegCpjEndCepFormat ;
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
      private Guid AV7NegID ;
      private Guid AV13Insert_NegCliID ;
      private Guid AV14Insert_NegCpjID ;
      private Guid Z350NegCliID ;
      private Guid A350NegCliID ;
      private Guid Z352NegCpjID ;
      private Guid A352NegCpjID ;
      private Guid Z439NgpTppPrdID ;
      private Guid A439NgpTppPrdID ;
      private Guid Z478NgpTppID ;
      private Guid A478NgpTppID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtNegocioPJ bccore_NegocioPJ ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] BC000Y13_A448NegPgpTotal ;
      private bool[] BC000Y13_n448NegPgpTotal ;
      private Guid[] BC000Y15_A345NegID ;
      private long[] BC000Y15_A356NegCodigo ;
      private DateTime[] BC000Y15_A348NegInsDataHora ;
      private DateTime[] BC000Y15_A346NegInsData ;
      private DateTime[] BC000Y15_A347NegInsHora ;
      private string[] BC000Y15_A349NegInsUsuID ;
      private bool[] BC000Y15_n349NegInsUsuID ;
      private string[] BC000Y15_A364NegInsUsuNome ;
      private bool[] BC000Y15_n364NegInsUsuNome ;
      private decimal[] BC000Y15_A385NegValorAtualizado ;
      private decimal[] BC000Y15_A380NegValorEstimado ;
      private DateTime[] BC000Y15_A573NegDelDataHora ;
      private bool[] BC000Y15_n573NegDelDataHora ;
      private DateTime[] BC000Y15_A574NegDelData ;
      private bool[] BC000Y15_n574NegDelData ;
      private DateTime[] BC000Y15_A575NegDelHora ;
      private bool[] BC000Y15_n575NegDelHora ;
      private string[] BC000Y15_A576NegDelUsuId ;
      private bool[] BC000Y15_n576NegDelUsuId ;
      private string[] BC000Y15_A577NegDelUsuNome ;
      private bool[] BC000Y15_n577NegDelUsuNome ;
      private long[] BC000Y15_A473NegCliMatricula ;
      private string[] BC000Y15_A351NegCliNomeFamiliar ;
      private string[] BC000Y15_A353NegCpjNomFan ;
      private string[] BC000Y15_A354NegCpjRazSocial ;
      private long[] BC000Y15_A355NegCpjMatricula ;
      private string[] BC000Y15_A358NegPjtSigla ;
      private string[] BC000Y15_A359NegPjtNome ;
      private string[] BC000Y15_A370NegCpjEndNome ;
      private string[] BC000Y15_A371NegCpjEndEndereco ;
      private string[] BC000Y15_A372NegCpjEndNumero ;
      private string[] BC000Y15_A373NegCpjEndComplem ;
      private bool[] BC000Y15_n373NegCpjEndComplem ;
      private string[] BC000Y15_A374NegCpjEndBairro ;
      private int[] BC000Y15_A642NegCpjEndCep ;
      private string[] BC000Y15_A643NegCpjEndCepFormat ;
      private int[] BC000Y15_A375NegCpjEndMunID ;
      private string[] BC000Y15_A376NegCpjEndMunNome ;
      private short[] BC000Y15_A377NegCpjEndUFID ;
      private string[] BC000Y15_A378NegCpjEndUFSigla ;
      private string[] BC000Y15_A379NegCpjEndUFNome ;
      private string[] BC000Y15_A360NegAgcID ;
      private bool[] BC000Y15_n360NegAgcID ;
      private string[] BC000Y15_A361NegAgcNome ;
      private bool[] BC000Y15_n361NegAgcNome ;
      private string[] BC000Y15_A362NegAssunto ;
      private string[] BC000Y15_A363NegDescricao ;
      private int[] BC000Y15_A454NegUltItem ;
      private bool[] BC000Y15_n454NegUltItem ;
      private bool[] BC000Y15_A572NegDel ;
      private Guid[] BC000Y15_A350NegCliID ;
      private Guid[] BC000Y15_A352NegCpjID ;
      private short[] BC000Y15_A369NegCpjEndSeq ;
      private int[] BC000Y15_A357NegPjtID ;
      private decimal[] BC000Y15_A448NegPgpTotal ;
      private bool[] BC000Y15_n448NegPgpTotal ;
      private long[] BC000Y16_A356NegCodigo ;
      private long[] BC000Y8_A473NegCliMatricula ;
      private string[] BC000Y8_A351NegCliNomeFamiliar ;
      private string[] BC000Y9_A353NegCpjNomFan ;
      private string[] BC000Y9_A354NegCpjRazSocial ;
      private long[] BC000Y9_A355NegCpjMatricula ;
      private int[] BC000Y9_A357NegPjtID ;
      private string[] BC000Y11_A358NegPjtSigla ;
      private string[] BC000Y11_A359NegPjtNome ;
      private string[] BC000Y10_A370NegCpjEndNome ;
      private string[] BC000Y10_A371NegCpjEndEndereco ;
      private string[] BC000Y10_A372NegCpjEndNumero ;
      private string[] BC000Y10_A373NegCpjEndComplem ;
      private bool[] BC000Y10_n373NegCpjEndComplem ;
      private string[] BC000Y10_A374NegCpjEndBairro ;
      private int[] BC000Y10_A642NegCpjEndCep ;
      private string[] BC000Y10_A643NegCpjEndCepFormat ;
      private int[] BC000Y10_A375NegCpjEndMunID ;
      private string[] BC000Y10_A376NegCpjEndMunNome ;
      private short[] BC000Y10_A377NegCpjEndUFID ;
      private string[] BC000Y10_A378NegCpjEndUFSigla ;
      private string[] BC000Y10_A379NegCpjEndUFNome ;
      private Guid[] BC000Y17_A345NegID ;
      private Guid[] BC000Y7_A345NegID ;
      private long[] BC000Y7_A356NegCodigo ;
      private DateTime[] BC000Y7_A348NegInsDataHora ;
      private DateTime[] BC000Y7_A346NegInsData ;
      private DateTime[] BC000Y7_A347NegInsHora ;
      private string[] BC000Y7_A349NegInsUsuID ;
      private bool[] BC000Y7_n349NegInsUsuID ;
      private string[] BC000Y7_A364NegInsUsuNome ;
      private bool[] BC000Y7_n364NegInsUsuNome ;
      private decimal[] BC000Y7_A385NegValorAtualizado ;
      private decimal[] BC000Y7_A380NegValorEstimado ;
      private DateTime[] BC000Y7_A573NegDelDataHora ;
      private bool[] BC000Y7_n573NegDelDataHora ;
      private DateTime[] BC000Y7_A574NegDelData ;
      private bool[] BC000Y7_n574NegDelData ;
      private DateTime[] BC000Y7_A575NegDelHora ;
      private bool[] BC000Y7_n575NegDelHora ;
      private string[] BC000Y7_A576NegDelUsuId ;
      private bool[] BC000Y7_n576NegDelUsuId ;
      private string[] BC000Y7_A577NegDelUsuNome ;
      private bool[] BC000Y7_n577NegDelUsuNome ;
      private string[] BC000Y7_A360NegAgcID ;
      private bool[] BC000Y7_n360NegAgcID ;
      private string[] BC000Y7_A361NegAgcNome ;
      private bool[] BC000Y7_n361NegAgcNome ;
      private string[] BC000Y7_A362NegAssunto ;
      private string[] BC000Y7_A363NegDescricao ;
      private int[] BC000Y7_A454NegUltItem ;
      private bool[] BC000Y7_n454NegUltItem ;
      private bool[] BC000Y7_A572NegDel ;
      private Guid[] BC000Y7_A350NegCliID ;
      private Guid[] BC000Y7_A352NegCpjID ;
      private short[] BC000Y7_A369NegCpjEndSeq ;
      private string[] BC000Y7_A351NegCliNomeFamiliar ;
      private string[] BC000Y7_A353NegCpjNomFan ;
      private string[] BC000Y7_A354NegCpjRazSocial ;
      private string[] BC000Y7_A359NegPjtNome ;
      private Guid[] BC000Y6_A345NegID ;
      private long[] BC000Y6_A356NegCodigo ;
      private DateTime[] BC000Y6_A348NegInsDataHora ;
      private DateTime[] BC000Y6_A346NegInsData ;
      private DateTime[] BC000Y6_A347NegInsHora ;
      private string[] BC000Y6_A349NegInsUsuID ;
      private bool[] BC000Y6_n349NegInsUsuID ;
      private string[] BC000Y6_A364NegInsUsuNome ;
      private bool[] BC000Y6_n364NegInsUsuNome ;
      private decimal[] BC000Y6_A385NegValorAtualizado ;
      private decimal[] BC000Y6_A380NegValorEstimado ;
      private DateTime[] BC000Y6_A573NegDelDataHora ;
      private bool[] BC000Y6_n573NegDelDataHora ;
      private DateTime[] BC000Y6_A574NegDelData ;
      private bool[] BC000Y6_n574NegDelData ;
      private DateTime[] BC000Y6_A575NegDelHora ;
      private bool[] BC000Y6_n575NegDelHora ;
      private string[] BC000Y6_A576NegDelUsuId ;
      private bool[] BC000Y6_n576NegDelUsuId ;
      private string[] BC000Y6_A577NegDelUsuNome ;
      private bool[] BC000Y6_n577NegDelUsuNome ;
      private string[] BC000Y6_A360NegAgcID ;
      private bool[] BC000Y6_n360NegAgcID ;
      private string[] BC000Y6_A361NegAgcNome ;
      private bool[] BC000Y6_n361NegAgcNome ;
      private string[] BC000Y6_A362NegAssunto ;
      private string[] BC000Y6_A363NegDescricao ;
      private int[] BC000Y6_A454NegUltItem ;
      private bool[] BC000Y6_n454NegUltItem ;
      private bool[] BC000Y6_A572NegDel ;
      private Guid[] BC000Y6_A350NegCliID ;
      private Guid[] BC000Y6_A352NegCpjID ;
      private short[] BC000Y6_A369NegCpjEndSeq ;
      private string[] BC000Y6_A351NegCliNomeFamiliar ;
      private string[] BC000Y6_A353NegCpjNomFan ;
      private string[] BC000Y6_A354NegCpjRazSocial ;
      private string[] BC000Y6_A359NegPjtNome ;
      private decimal[] BC000Y22_A448NegPgpTotal ;
      private bool[] BC000Y22_n448NegPgpTotal ;
      private long[] BC000Y23_A473NegCliMatricula ;
      private string[] BC000Y23_A351NegCliNomeFamiliar ;
      private string[] BC000Y24_A353NegCpjNomFan ;
      private string[] BC000Y24_A354NegCpjRazSocial ;
      private long[] BC000Y24_A355NegCpjMatricula ;
      private int[] BC000Y24_A357NegPjtID ;
      private string[] BC000Y25_A358NegPjtSigla ;
      private string[] BC000Y25_A359NegPjtNome ;
      private string[] BC000Y26_A370NegCpjEndNome ;
      private string[] BC000Y26_A371NegCpjEndEndereco ;
      private string[] BC000Y26_A372NegCpjEndNumero ;
      private string[] BC000Y26_A373NegCpjEndComplem ;
      private bool[] BC000Y26_n373NegCpjEndComplem ;
      private string[] BC000Y26_A374NegCpjEndBairro ;
      private int[] BC000Y26_A642NegCpjEndCep ;
      private string[] BC000Y26_A643NegCpjEndCepFormat ;
      private int[] BC000Y26_A375NegCpjEndMunID ;
      private string[] BC000Y26_A376NegCpjEndMunNome ;
      private short[] BC000Y26_A377NegCpjEndUFID ;
      private string[] BC000Y26_A378NegCpjEndUFSigla ;
      private string[] BC000Y26_A379NegCpjEndUFNome ;
      private Guid[] BC000Y27_A398VisID ;
      private Guid[] BC000Y28_A345NegID ;
      private string[] BC000Y28_A626NefChave ;
      private Guid[] BC000Y29_A345NegID ;
      private int[] BC000Y29_A387NgfSeq ;
      private Guid[] BC000Y32_A345NegID ;
      private long[] BC000Y32_A356NegCodigo ;
      private DateTime[] BC000Y32_A348NegInsDataHora ;
      private DateTime[] BC000Y32_A346NegInsData ;
      private DateTime[] BC000Y32_A347NegInsHora ;
      private string[] BC000Y32_A349NegInsUsuID ;
      private bool[] BC000Y32_n349NegInsUsuID ;
      private string[] BC000Y32_A364NegInsUsuNome ;
      private bool[] BC000Y32_n364NegInsUsuNome ;
      private decimal[] BC000Y32_A385NegValorAtualizado ;
      private decimal[] BC000Y32_A380NegValorEstimado ;
      private DateTime[] BC000Y32_A573NegDelDataHora ;
      private bool[] BC000Y32_n573NegDelDataHora ;
      private DateTime[] BC000Y32_A574NegDelData ;
      private bool[] BC000Y32_n574NegDelData ;
      private DateTime[] BC000Y32_A575NegDelHora ;
      private bool[] BC000Y32_n575NegDelHora ;
      private string[] BC000Y32_A576NegDelUsuId ;
      private bool[] BC000Y32_n576NegDelUsuId ;
      private string[] BC000Y32_A577NegDelUsuNome ;
      private bool[] BC000Y32_n577NegDelUsuNome ;
      private long[] BC000Y32_A473NegCliMatricula ;
      private string[] BC000Y32_A351NegCliNomeFamiliar ;
      private string[] BC000Y32_A353NegCpjNomFan ;
      private string[] BC000Y32_A354NegCpjRazSocial ;
      private long[] BC000Y32_A355NegCpjMatricula ;
      private string[] BC000Y32_A358NegPjtSigla ;
      private string[] BC000Y32_A359NegPjtNome ;
      private string[] BC000Y32_A370NegCpjEndNome ;
      private string[] BC000Y32_A371NegCpjEndEndereco ;
      private string[] BC000Y32_A372NegCpjEndNumero ;
      private string[] BC000Y32_A373NegCpjEndComplem ;
      private bool[] BC000Y32_n373NegCpjEndComplem ;
      private string[] BC000Y32_A374NegCpjEndBairro ;
      private int[] BC000Y32_A642NegCpjEndCep ;
      private string[] BC000Y32_A643NegCpjEndCepFormat ;
      private int[] BC000Y32_A375NegCpjEndMunID ;
      private string[] BC000Y32_A376NegCpjEndMunNome ;
      private short[] BC000Y32_A377NegCpjEndUFID ;
      private string[] BC000Y32_A378NegCpjEndUFSigla ;
      private string[] BC000Y32_A379NegCpjEndUFNome ;
      private string[] BC000Y32_A360NegAgcID ;
      private bool[] BC000Y32_n360NegAgcID ;
      private string[] BC000Y32_A361NegAgcNome ;
      private bool[] BC000Y32_n361NegAgcNome ;
      private string[] BC000Y32_A362NegAssunto ;
      private string[] BC000Y32_A363NegDescricao ;
      private int[] BC000Y32_A454NegUltItem ;
      private bool[] BC000Y32_n454NegUltItem ;
      private bool[] BC000Y32_A572NegDel ;
      private Guid[] BC000Y32_A350NegCliID ;
      private Guid[] BC000Y32_A352NegCpjID ;
      private short[] BC000Y32_A369NegCpjEndSeq ;
      private int[] BC000Y32_A357NegPjtID ;
      private decimal[] BC000Y32_A448NegPgpTotal ;
      private bool[] BC000Y32_n448NegPgpTotal ;
      private decimal[] BC000Y33_A447NgpTotal ;
      private Guid[] BC000Y33_A345NegID ;
      private int[] BC000Y33_A435NgpItem ;
      private int[] BC000Y33_A446NgpQtde ;
      private decimal[] BC000Y33_A445NgpPreco ;
      private DateTime[] BC000Y33_A457NgpInsDataHora ;
      private DateTime[] BC000Y33_A455NgpInsData ;
      private DateTime[] BC000Y33_A456NgpInsHora ;
      private string[] BC000Y33_A458NgpInsUsuID ;
      private bool[] BC000Y33_n458NgpInsUsuID ;
      private string[] BC000Y33_A459NgpInsUsuNome ;
      private bool[] BC000Y33_n459NgpInsUsuNome ;
      private DateTime[] BC000Y33_A579NgpDelDataHora ;
      private bool[] BC000Y33_n579NgpDelDataHora ;
      private DateTime[] BC000Y33_A580NgpDelData ;
      private bool[] BC000Y33_n580NgpDelData ;
      private DateTime[] BC000Y33_A581NgpDelHora ;
      private bool[] BC000Y33_n581NgpDelHora ;
      private string[] BC000Y33_A582NgpDelUsuId ;
      private bool[] BC000Y33_n582NgpDelUsuId ;
      private string[] BC000Y33_A583NgpDelUsuNome ;
      private bool[] BC000Y33_n583NgpDelUsuNome ;
      private string[] BC000Y33_A440NgpTppPrdCodigo ;
      private string[] BC000Y33_A441NgpTppPrdNome ;
      private bool[] BC000Y33_A443NgpTppPrdAtivo ;
      private decimal[] BC000Y33_A444NgpTpp1Preco ;
      private string[] BC000Y33_A453NgpObs ;
      private bool[] BC000Y33_A578NgpDel ;
      private Guid[] BC000Y33_A439NgpTppPrdID ;
      private Guid[] BC000Y33_A478NgpTppID ;
      private int[] BC000Y33_A442NgpTppPrdTipoID ;
      private decimal[] BC000Y5_A444NgpTpp1Preco ;
      private string[] BC000Y4_A440NgpTppPrdCodigo ;
      private string[] BC000Y4_A441NgpTppPrdNome ;
      private bool[] BC000Y4_A443NgpTppPrdAtivo ;
      private int[] BC000Y4_A442NgpTppPrdTipoID ;
      private Guid[] BC000Y34_A345NegID ;
      private int[] BC000Y34_A435NgpItem ;
      private decimal[] BC000Y3_A447NgpTotal ;
      private Guid[] BC000Y3_A345NegID ;
      private int[] BC000Y3_A435NgpItem ;
      private int[] BC000Y3_A446NgpQtde ;
      private decimal[] BC000Y3_A445NgpPreco ;
      private DateTime[] BC000Y3_A457NgpInsDataHora ;
      private DateTime[] BC000Y3_A455NgpInsData ;
      private DateTime[] BC000Y3_A456NgpInsHora ;
      private string[] BC000Y3_A458NgpInsUsuID ;
      private bool[] BC000Y3_n458NgpInsUsuID ;
      private string[] BC000Y3_A459NgpInsUsuNome ;
      private bool[] BC000Y3_n459NgpInsUsuNome ;
      private DateTime[] BC000Y3_A579NgpDelDataHora ;
      private bool[] BC000Y3_n579NgpDelDataHora ;
      private DateTime[] BC000Y3_A580NgpDelData ;
      private bool[] BC000Y3_n580NgpDelData ;
      private DateTime[] BC000Y3_A581NgpDelHora ;
      private bool[] BC000Y3_n581NgpDelHora ;
      private string[] BC000Y3_A582NgpDelUsuId ;
      private bool[] BC000Y3_n582NgpDelUsuId ;
      private string[] BC000Y3_A583NgpDelUsuNome ;
      private bool[] BC000Y3_n583NgpDelUsuNome ;
      private string[] BC000Y3_A453NgpObs ;
      private bool[] BC000Y3_A578NgpDel ;
      private Guid[] BC000Y3_A439NgpTppPrdID ;
      private Guid[] BC000Y3_A478NgpTppID ;
      private decimal[] BC000Y2_A447NgpTotal ;
      private Guid[] BC000Y2_A345NegID ;
      private int[] BC000Y2_A435NgpItem ;
      private int[] BC000Y2_A446NgpQtde ;
      private decimal[] BC000Y2_A445NgpPreco ;
      private DateTime[] BC000Y2_A457NgpInsDataHora ;
      private DateTime[] BC000Y2_A455NgpInsData ;
      private DateTime[] BC000Y2_A456NgpInsHora ;
      private string[] BC000Y2_A458NgpInsUsuID ;
      private bool[] BC000Y2_n458NgpInsUsuID ;
      private string[] BC000Y2_A459NgpInsUsuNome ;
      private bool[] BC000Y2_n459NgpInsUsuNome ;
      private DateTime[] BC000Y2_A579NgpDelDataHora ;
      private bool[] BC000Y2_n579NgpDelDataHora ;
      private DateTime[] BC000Y2_A580NgpDelData ;
      private bool[] BC000Y2_n580NgpDelData ;
      private DateTime[] BC000Y2_A581NgpDelHora ;
      private bool[] BC000Y2_n581NgpDelHora ;
      private string[] BC000Y2_A582NgpDelUsuId ;
      private bool[] BC000Y2_n582NgpDelUsuId ;
      private string[] BC000Y2_A583NgpDelUsuNome ;
      private bool[] BC000Y2_n583NgpDelUsuNome ;
      private string[] BC000Y2_A453NgpObs ;
      private bool[] BC000Y2_A578NgpDel ;
      private Guid[] BC000Y2_A439NgpTppPrdID ;
      private Guid[] BC000Y2_A478NgpTppID ;
      private string[] BC000Y38_A440NgpTppPrdCodigo ;
      private string[] BC000Y38_A441NgpTppPrdNome ;
      private bool[] BC000Y38_A443NgpTppPrdAtivo ;
      private int[] BC000Y38_A442NgpTppPrdTipoID ;
      private decimal[] BC000Y39_A444NgpTpp1Preco ;
      private decimal[] BC000Y40_A447NgpTotal ;
      private Guid[] BC000Y40_A345NegID ;
      private int[] BC000Y40_A435NgpItem ;
      private int[] BC000Y40_A446NgpQtde ;
      private decimal[] BC000Y40_A445NgpPreco ;
      private DateTime[] BC000Y40_A457NgpInsDataHora ;
      private DateTime[] BC000Y40_A455NgpInsData ;
      private DateTime[] BC000Y40_A456NgpInsHora ;
      private string[] BC000Y40_A458NgpInsUsuID ;
      private bool[] BC000Y40_n458NgpInsUsuID ;
      private string[] BC000Y40_A459NgpInsUsuNome ;
      private bool[] BC000Y40_n459NgpInsUsuNome ;
      private DateTime[] BC000Y40_A579NgpDelDataHora ;
      private bool[] BC000Y40_n579NgpDelDataHora ;
      private DateTime[] BC000Y40_A580NgpDelData ;
      private bool[] BC000Y40_n580NgpDelData ;
      private DateTime[] BC000Y40_A581NgpDelHora ;
      private bool[] BC000Y40_n581NgpDelHora ;
      private string[] BC000Y40_A582NgpDelUsuId ;
      private bool[] BC000Y40_n582NgpDelUsuId ;
      private string[] BC000Y40_A583NgpDelUsuNome ;
      private bool[] BC000Y40_n583NgpDelUsuNome ;
      private string[] BC000Y40_A440NgpTppPrdCodigo ;
      private string[] BC000Y40_A441NgpTppPrdNome ;
      private bool[] BC000Y40_A443NgpTppPrdAtivo ;
      private decimal[] BC000Y40_A444NgpTpp1Preco ;
      private string[] BC000Y40_A453NgpObs ;
      private bool[] BC000Y40_A578NgpDel ;
      private Guid[] BC000Y40_A439NgpTppPrdID ;
      private Guid[] BC000Y40_A478NgpTppID ;
      private int[] BC000Y40_A442NgpTppPrdTipoID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ;
   }

   public class negociopj_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class negociopj_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000Y15;
        prmBC000Y15 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y13;
        prmBC000Y13 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y16;
        prmBC000Y16 = new Object[] {
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y8;
        prmBC000Y8 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y9;
        prmBC000Y9 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y11;
        prmBC000Y11 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000Y10;
        prmBC000Y10 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmBC000Y17;
        prmBC000Y17 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y7;
        prmBC000Y7 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y6;
        prmBC000Y6 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y18;
        prmBC000Y18 = new Object[] {
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
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NegDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NegDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NegDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAgcID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAssunto",GXType.VarChar,80,0) ,
        new ParDef("NegDescricao",GXType.LongVarChar,2097152,0) ,
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegDel",GXType.Boolean,4,0) ,
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmBC000Y19;
        prmBC000Y19 = new Object[] {
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
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NegDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NegDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NegDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAgcID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAssunto",GXType.VarChar,80,0) ,
        new ParDef("NegDescricao",GXType.LongVarChar,2097152,0) ,
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegDel",GXType.Boolean,4,0) ,
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y20;
        prmBC000Y20 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y22;
        prmBC000Y22 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y23;
        prmBC000Y23 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y24;
        prmBC000Y24 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y25;
        prmBC000Y25 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000Y26;
        prmBC000Y26 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmBC000Y27;
        prmBC000Y27 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y28;
        prmBC000Y28 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y29;
        prmBC000Y29 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y30;
        prmBC000Y30 = new Object[] {
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y32;
        prmBC000Y32 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y33;
        prmBC000Y33 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC000Y5;
        prmBC000Y5 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y4;
        prmBC000Y4 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y34;
        prmBC000Y34 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC000Y3;
        prmBC000Y3 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC000Y2;
        prmBC000Y2 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC000Y35;
        prmBC000Y35 = new Object[] {
        new ParDef("NgpTotal",GXType.Number,16,2) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0) ,
        new ParDef("NgpQtde",GXType.Int32,8,0) ,
        new ParDef("NgpPreco",GXType.Number,16,2) ,
        new ParDef("NgpInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgpInsData",GXType.Date,8,0) ,
        new ParDef("NgpInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
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
        Object[] prmBC000Y36;
        prmBC000Y36 = new Object[] {
        new ParDef("NgpTotal",GXType.Number,16,2) ,
        new ParDef("NgpQtde",GXType.Int32,8,0) ,
        new ParDef("NgpPreco",GXType.Number,16,2) ,
        new ParDef("NgpInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgpInsData",GXType.Date,8,0) ,
        new ParDef("NgpInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
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
        Object[] prmBC000Y37;
        prmBC000Y37 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmBC000Y38;
        prmBC000Y38 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y39;
        prmBC000Y39 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000Y40;
        prmBC000Y40 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000Y2", "SELECT NgpTotal, NegID, NgpItem, NgpQtde, NgpPreco, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem  FOR UPDATE OF tb_negociopj_item",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y3", "SELECT NgpTotal, NegID, NgpItem, NgpQtde, NgpPreco, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y4", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y5", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y6", "SELECT NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorAtualizado, NegValorEstimado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome FROM tb_negociopj WHERE NegID = :NegID  FOR UPDATE OF tb_negociopj",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y7", "SELECT NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorAtualizado, NegValorEstimado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y8", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y9", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y10", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndCep AS NegCpjEndCep, CpjEndCepFormat AS NegCpjEndCepFormat, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y11", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y13", "SELECT COALESCE( T1.NegPgpTotal, 0) AS NegPgpTotal FROM (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y15", "SELECT TM1.NegID, TM1.NegCodigo, TM1.NegInsDataHora, TM1.NegInsData, TM1.NegInsHora, TM1.NegInsUsuID, TM1.NegInsUsuNome, TM1.NegValorAtualizado, TM1.NegValorEstimado, TM1.NegDelDataHora, TM1.NegDelData, TM1.NegDelHora, TM1.NegDelUsuId, TM1.NegDelUsuNome, T3.CliMatricula AS NegCliMatricula, TM1.NegCliNomeFamiliar AS NegCliNomeFamiliar, TM1.NegCpjNomFan AS NegCpjNomFan, TM1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T5.PjtSigla AS NegPjtSigla, TM1.NegPjtNome AS NegPjtNome, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndCep AS NegCpjEndCep, T6.CpjEndCepFormat AS NegCpjEndCepFormat, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, TM1.NegAgcID, TM1.NegAgcNome, TM1.NegAssunto, TM1.NegDescricao, TM1.NegUltItem, TM1.NegDel, TM1.NegCliID AS NegCliID, TM1.NegCpjID AS NegCpjID, TM1.NegCpjEndSeq AS NegCpjEndSeq, T4.CpjTipoId AS NegPjtID, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal FROM (((((tb_negociopj TM1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE TM1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = TM1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = TM1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = TM1.NegCliID AND T4.CpjID = TM1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = TM1.NegCliID AND T6.CpjID = TM1.NegCpjID AND T6.CpjEndSeq = TM1.NegCpjEndSeq) WHERE TM1.NegID = :NegID ORDER BY TM1.NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y16", "SELECT NegCodigo FROM tb_negociopj WHERE (NegCodigo = :NegCodigo) AND (Not ( NegID = :NegID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y17", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y18", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj(NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome, NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorAtualizado, NegValorEstimado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegUltFase, NegUltIteID, NegUltIteNome, NegUltNgfSeq, NegUltIteOrdem) VALUES(:NegCliNomeFamiliar, :NegCpjNomFan, :NegCpjRazSocial, :NegPjtNome, :NegID, :NegCodigo, :NegInsDataHora, :NegInsData, :NegInsHora, :NegInsUsuID, :NegInsUsuNome, :NegValorAtualizado, :NegValorEstimado, :NegDelDataHora, :NegDelData, :NegDelHora, :NegDelUsuId, :NegDelUsuNome, :NegAgcID, :NegAgcNome, :NegAssunto, :NegDescricao, :NegUltItem, :NegDel, :NegCliID, :NegCpjID, :NegCpjEndSeq, 0, '00000000-0000-0000-0000-000000000000', '', 0, 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Y18)
           ,new CursorDef("BC000Y19", "SAVEPOINT gxupdate;UPDATE tb_negociopj SET NegCliNomeFamiliar=:NegCliNomeFamiliar, NegCpjNomFan=:NegCpjNomFan, NegCpjRazSocial=:NegCpjRazSocial, NegPjtNome=:NegPjtNome, NegCodigo=:NegCodigo, NegInsDataHora=:NegInsDataHora, NegInsData=:NegInsData, NegInsHora=:NegInsHora, NegInsUsuID=:NegInsUsuID, NegInsUsuNome=:NegInsUsuNome, NegValorAtualizado=:NegValorAtualizado, NegValorEstimado=:NegValorEstimado, NegDelDataHora=:NegDelDataHora, NegDelData=:NegDelData, NegDelHora=:NegDelHora, NegDelUsuId=:NegDelUsuId, NegDelUsuNome=:NegDelUsuNome, NegAgcID=:NegAgcID, NegAgcNome=:NegAgcNome, NegAssunto=:NegAssunto, NegDescricao=:NegDescricao, NegUltItem=:NegUltItem, NegDel=:NegDel, NegCliID=:NegCliID, NegCpjID=:NegCpjID, NegCpjEndSeq=:NegCpjEndSeq  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y19)
           ,new CursorDef("BC000Y20", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y20)
           ,new CursorDef("BC000Y22", "SELECT COALESCE( T1.NegPgpTotal, 0) AS NegPgpTotal FROM (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y23", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y24", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y25", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y26", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndCep AS NegCpjEndCep, CpjEndCepFormat AS NegCpjEndCepFormat, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y27", "SELECT VisID FROM tb_visita WHERE VisNegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000Y28", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000Y29", "SELECT NegID, NgfSeq FROM tb_negociopj_fase WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000Y30", "SAVEPOINT gxupdate;UPDATE tb_negociopj SET NegUltItem=:NegUltItem, NegValorEstimado=:NegValorEstimado, NegValorAtualizado=:NegValorAtualizado  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y30)
           ,new CursorDef("BC000Y32", "SELECT TM1.NegID, TM1.NegCodigo, TM1.NegInsDataHora, TM1.NegInsData, TM1.NegInsHora, TM1.NegInsUsuID, TM1.NegInsUsuNome, TM1.NegValorAtualizado, TM1.NegValorEstimado, TM1.NegDelDataHora, TM1.NegDelData, TM1.NegDelHora, TM1.NegDelUsuId, TM1.NegDelUsuNome, T3.CliMatricula AS NegCliMatricula, TM1.NegCliNomeFamiliar AS NegCliNomeFamiliar, TM1.NegCpjNomFan AS NegCpjNomFan, TM1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T5.PjtSigla AS NegPjtSigla, TM1.NegPjtNome AS NegPjtNome, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndCep AS NegCpjEndCep, T6.CpjEndCepFormat AS NegCpjEndCepFormat, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, TM1.NegAgcID, TM1.NegAgcNome, TM1.NegAssunto, TM1.NegDescricao, TM1.NegUltItem, TM1.NegDel, TM1.NegCliID AS NegCliID, TM1.NegCpjID AS NegCpjID, TM1.NegCpjEndSeq AS NegCpjEndSeq, T4.CpjTipoId AS NegPjtID, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal FROM (((((tb_negociopj TM1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE TM1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = TM1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = TM1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = TM1.NegCliID AND T4.CpjID = TM1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = TM1.NegCliID AND T6.CpjID = TM1.NegCpjID AND T6.CpjEndSeq = TM1.NegCpjEndSeq) WHERE TM1.NegID = :NegID ORDER BY TM1.NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y32,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y33", "SELECT T1.NgpTotal, T1.NegID, T1.NgpItem, T1.NgpQtde, T1.NgpPreco, T1.NgpInsDataHora, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpObs, T1.NgpDel, T1.NgpTppPrdID AS NgpTppPrdID, T1.NgpTppID AS NgpTppID, T2.PrdTipoID AS NgpTppPrdTipoID FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID and T1.NgpItem = :NgpItem ORDER BY T1.NegID, T1.NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y33,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y34", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y35", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj_item(NgpTotal, NegID, NgpItem, NgpQtde, NgpPreco, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID) VALUES(:NgpTotal, :NegID, :NgpItem, :NgpQtde, :NgpPreco, :NgpInsDataHora, :NgpInsData, :NgpInsHora, :NgpInsUsuID, :NgpInsUsuNome, :NgpDelDataHora, :NgpDelData, :NgpDelHora, :NgpDelUsuId, :NgpDelUsuNome, :NgpObs, :NgpDel, :NgpTppPrdID, :NgpTppID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Y35)
           ,new CursorDef("BC000Y36", "SAVEPOINT gxupdate;UPDATE tb_negociopj_item SET NgpTotal=:NgpTotal, NgpQtde=:NgpQtde, NgpPreco=:NgpPreco, NgpInsDataHora=:NgpInsDataHora, NgpInsData=:NgpInsData, NgpInsHora=:NgpInsHora, NgpInsUsuID=:NgpInsUsuID, NgpInsUsuNome=:NgpInsUsuNome, NgpDelDataHora=:NgpDelDataHora, NgpDelData=:NgpDelData, NgpDelHora=:NgpDelHora, NgpDelUsuId=:NgpDelUsuId, NgpDelUsuNome=:NgpDelUsuNome, NgpObs=:NgpObs, NgpDel=:NgpDel, NgpTppPrdID=:NgpTppPrdID, NgpTppID=:NgpTppID  WHERE NegID = :NegID AND NgpItem = :NgpItem;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y36)
           ,new CursorDef("BC000Y37", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj_item  WHERE NegID = :NegID AND NgpItem = :NgpItem;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y37)
           ,new CursorDef("BC000Y38", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y39", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Y40", "SELECT T1.NgpTotal, T1.NegID, T1.NgpItem, T1.NgpQtde, T1.NgpPreco, T1.NgpInsDataHora, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpObs, T1.NgpDel, T1.NgpTppPrdID AS NgpTppPrdID, T1.NgpTppID AS NgpTppID, T2.PrdTipoID AS NgpTppPrdTipoID FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID, T1.NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y40,11, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
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
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
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
              ((bool[]) buf[28])[0] = rslt.wasNull(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((Guid[]) buf[30])[0] = rslt.getGuid(21);
              ((Guid[]) buf[31])[0] = rslt.getGuid(22);
              ((short[]) buf[32])[0] = rslt.getShort(23);
              ((string[]) buf[33])[0] = rslt.getVarchar(24);
              ((string[]) buf[34])[0] = rslt.getVarchar(25);
              ((string[]) buf[35])[0] = rslt.getVarchar(26);
              ((string[]) buf[36])[0] = rslt.getVarchar(27);
              return;
           case 5 :
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
              ((bool[]) buf[28])[0] = rslt.wasNull(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((Guid[]) buf[30])[0] = rslt.getGuid(21);
              ((Guid[]) buf[31])[0] = rslt.getGuid(22);
              ((short[]) buf[32])[0] = rslt.getShort(23);
              ((string[]) buf[33])[0] = rslt.getVarchar(24);
              ((string[]) buf[34])[0] = rslt.getVarchar(25);
              ((string[]) buf[35])[0] = rslt.getVarchar(26);
              ((string[]) buf[36])[0] = rslt.getVarchar(27);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 10 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
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
              ((int[]) buf[36])[0] = rslt.getInt(29);
              ((string[]) buf[37])[0] = rslt.getVarchar(30);
              ((short[]) buf[38])[0] = rslt.getShort(31);
              ((string[]) buf[39])[0] = rslt.getVarchar(32);
              ((string[]) buf[40])[0] = rslt.getVarchar(33);
              ((string[]) buf[41])[0] = rslt.getString(34, 40);
              ((bool[]) buf[42])[0] = rslt.wasNull(34);
              ((string[]) buf[43])[0] = rslt.getVarchar(35);
              ((bool[]) buf[44])[0] = rslt.wasNull(35);
              ((string[]) buf[45])[0] = rslt.getVarchar(36);
              ((string[]) buf[46])[0] = rslt.getLongVarchar(37);
              ((int[]) buf[47])[0] = rslt.getInt(38);
              ((bool[]) buf[48])[0] = rslt.wasNull(38);
              ((bool[]) buf[49])[0] = rslt.getBool(39);
              ((Guid[]) buf[50])[0] = rslt.getGuid(40);
              ((Guid[]) buf[51])[0] = rslt.getGuid(41);
              ((short[]) buf[52])[0] = rslt.getShort(42);
              ((int[]) buf[53])[0] = rslt.getInt(43);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(44);
              ((bool[]) buf[55])[0] = rslt.wasNull(44);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 17 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              return;
           case 22 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 23 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 24 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 26 :
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
              ((int[]) buf[36])[0] = rslt.getInt(29);
              ((string[]) buf[37])[0] = rslt.getVarchar(30);
              ((short[]) buf[38])[0] = rslt.getShort(31);
              ((string[]) buf[39])[0] = rslt.getVarchar(32);
              ((string[]) buf[40])[0] = rslt.getVarchar(33);
              ((string[]) buf[41])[0] = rslt.getString(34, 40);
              ((bool[]) buf[42])[0] = rslt.wasNull(34);
              ((string[]) buf[43])[0] = rslt.getVarchar(35);
              ((bool[]) buf[44])[0] = rslt.wasNull(35);
              ((string[]) buf[45])[0] = rslt.getVarchar(36);
              ((string[]) buf[46])[0] = rslt.getLongVarchar(37);
              ((int[]) buf[47])[0] = rslt.getInt(38);
              ((bool[]) buf[48])[0] = rslt.wasNull(38);
              ((bool[]) buf[49])[0] = rslt.getBool(39);
              ((Guid[]) buf[50])[0] = rslt.getGuid(40);
              ((Guid[]) buf[51])[0] = rslt.getGuid(41);
              ((short[]) buf[52])[0] = rslt.getShort(42);
              ((int[]) buf[53])[0] = rslt.getInt(43);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(44);
              ((bool[]) buf[55])[0] = rslt.wasNull(44);
              return;
           case 27 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
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
           case 28 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 33 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 34 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
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
