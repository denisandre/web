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
   public class loadauditnegociopj : GXProcedure
   {
      public loadauditnegociopj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditnegociopj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_NegID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17NegID = aP2_NegID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_NegID ,
                                 string aP3_ActualMode )
      {
         loadauditnegociopj objloadauditnegociopj;
         objloadauditnegociopj = new loadauditnegociopj();
         objloadauditnegociopj.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditnegociopj.AV11AuditingObject = aP1_AuditingObject;
         objloadauditnegociopj.AV17NegID = aP2_NegID;
         objloadauditnegociopj.AV15ActualMode = aP3_ActualMode;
         objloadauditnegociopj.context.SetSubmitInitialConfig(context);
         objloadauditnegociopj.initialize();
         Submit( executePrivateCatch,objloadauditnegociopj);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditnegociopj)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV14SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV15ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
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
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007P3 */
         pr_default.execute(0, new Object[] {AV17NegID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A345NegID = P007P3_A345NegID[0];
            A356NegCodigo = P007P3_A356NegCodigo[0];
            A346NegInsData = P007P3_A346NegInsData[0];
            A347NegInsHora = P007P3_A347NegInsHora[0];
            A348NegInsDataHora = P007P3_A348NegInsDataHora[0];
            A349NegInsUsuID = P007P3_A349NegInsUsuID[0];
            n349NegInsUsuID = P007P3_n349NegInsUsuID[0];
            A364NegInsUsuNome = P007P3_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P007P3_n364NegInsUsuNome[0];
            A350NegCliID = P007P3_A350NegCliID[0];
            A473NegCliMatricula = P007P3_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = P007P3_A351NegCliNomeFamiliar[0];
            A352NegCpjID = P007P3_A352NegCpjID[0];
            A353NegCpjNomFan = P007P3_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = P007P3_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = P007P3_A355NegCpjMatricula[0];
            A357NegPjtID = P007P3_A357NegPjtID[0];
            A358NegPjtSigla = P007P3_A358NegPjtSigla[0];
            A359NegPjtNome = P007P3_A359NegPjtNome[0];
            A369NegCpjEndSeq = P007P3_A369NegCpjEndSeq[0];
            A370NegCpjEndNome = P007P3_A370NegCpjEndNome[0];
            A642NegCpjEndCep = P007P3_A642NegCpjEndCep[0];
            A375NegCpjEndMunID = P007P3_A375NegCpjEndMunID[0];
            A377NegCpjEndUFID = P007P3_A377NegCpjEndUFID[0];
            A379NegCpjEndUFNome = P007P3_A379NegCpjEndUFNome[0];
            A360NegAgcID = P007P3_A360NegAgcID[0];
            n360NegAgcID = P007P3_n360NegAgcID[0];
            A361NegAgcNome = P007P3_A361NegAgcNome[0];
            n361NegAgcNome = P007P3_n361NegAgcNome[0];
            A362NegAssunto = P007P3_A362NegAssunto[0];
            A363NegDescricao = P007P3_A363NegDescricao[0];
            A380NegValorEstimado = P007P3_A380NegValorEstimado[0];
            A385NegValorAtualizado = P007P3_A385NegValorAtualizado[0];
            A454NegUltItem = P007P3_A454NegUltItem[0];
            n454NegUltItem = P007P3_n454NegUltItem[0];
            A572NegDel = P007P3_A572NegDel[0];
            A573NegDelDataHora = P007P3_A573NegDelDataHora[0];
            n573NegDelDataHora = P007P3_n573NegDelDataHora[0];
            A574NegDelData = P007P3_A574NegDelData[0];
            n574NegDelData = P007P3_n574NegDelData[0];
            A575NegDelHora = P007P3_A575NegDelHora[0];
            n575NegDelHora = P007P3_n575NegDelHora[0];
            A576NegDelUsuId = P007P3_A576NegDelUsuId[0];
            n576NegDelUsuId = P007P3_n576NegDelUsuId[0];
            A577NegDelUsuNome = P007P3_A577NegDelUsuNome[0];
            n577NegDelUsuNome = P007P3_n577NegDelUsuNome[0];
            A448NegPgpTotal = P007P3_A448NegPgpTotal[0];
            n448NegPgpTotal = P007P3_n448NegPgpTotal[0];
            A373NegCpjEndComplem = P007P3_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007P3_n373NegCpjEndComplem[0];
            A372NegCpjEndNumero = P007P3_A372NegCpjEndNumero[0];
            A378NegCpjEndUFSigla = P007P3_A378NegCpjEndUFSigla[0];
            A376NegCpjEndMunNome = P007P3_A376NegCpjEndMunNome[0];
            A643NegCpjEndCepFormat = P007P3_A643NegCpjEndCepFormat[0];
            A374NegCpjEndBairro = P007P3_A374NegCpjEndBairro[0];
            A371NegCpjEndEndereco = P007P3_A371NegCpjEndEndereco[0];
            A448NegPgpTotal = P007P3_A448NegPgpTotal[0];
            n448NegPgpTotal = P007P3_n448NegPgpTotal[0];
            A473NegCliMatricula = P007P3_A473NegCliMatricula[0];
            A355NegCpjMatricula = P007P3_A355NegCpjMatricula[0];
            A357NegPjtID = P007P3_A357NegPjtID[0];
            A358NegPjtSigla = P007P3_A358NegPjtSigla[0];
            A370NegCpjEndNome = P007P3_A370NegCpjEndNome[0];
            A642NegCpjEndCep = P007P3_A642NegCpjEndCep[0];
            A375NegCpjEndMunID = P007P3_A375NegCpjEndMunID[0];
            A377NegCpjEndUFID = P007P3_A377NegCpjEndUFID[0];
            A379NegCpjEndUFNome = P007P3_A379NegCpjEndUFNome[0];
            A373NegCpjEndComplem = P007P3_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007P3_n373NegCpjEndComplem[0];
            A372NegCpjEndNumero = P007P3_A372NegCpjEndNumero[0];
            A378NegCpjEndUFSigla = P007P3_A378NegCpjEndUFSigla[0];
            A376NegCpjEndMunNome = P007P3_A376NegCpjEndMunNome[0];
            A643NegCpjEndCepFormat = P007P3_A643NegCpjEndCepFormat[0];
            A374NegCpjEndBairro = P007P3_A374NegCpjEndBairro[0];
            A371NegCpjEndEndereco = P007P3_A371NegCpjEndEndereco[0];
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
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A345NegID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCodigo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código da Negociação";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A356NegCodigo), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A346NegInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A349NegInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuários de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A364NegInsUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A350NegCliID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula do Cliente";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A473NegCliMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliNomeFamiliar";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome Familiar";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A351NegCliNomeFamiliar;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A352NegCpjID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjNomFan";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome Fantasia";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A353NegCpjNomFan;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjRazSocial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Razão Social";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A354NegCpjRazSocial;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A355NegCpjMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo da Unidade";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A357NegPjtID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla do Tipo da Unidade";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A358NegPjtSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Tipo da Unidade";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A359NegPjtNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A369NegCpjEndSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Endereço";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A370NegCpjEndNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndEndereco";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A371NegCpjEndEndereco;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndNumero";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Número";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A372NegCpjEndNumero;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndComplem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Complemento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A373NegCpjEndComplem;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndBairro";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Bairro";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A374NegCpjEndBairro;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndCep";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A642NegCpjEndCep), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndCepFormat";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP Formatado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A643NegCpjEndCepFormat;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código do Município";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A375NegCpjEndMunID), 7, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Município";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A376NegCpjEndMunNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A377NegCpjEndUFID), 2, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla da UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A378NegCpjEndUFSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome da UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A379NegCpjEndUFNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndCompleto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço Completo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A641NegCpjEndCompleto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID do Agente Comercial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A360NegAgcID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Agente Comercial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A361NegAgcNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAssunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A362NegAssunto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDescricao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A363NegDescricao;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPgpTotal";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Total de Produtos";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A448NegPgpTotal, 16, 2);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegValorEstimado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor Estimado em Negócios";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A380NegValorEstimado, 16, 2);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegValorAtualizado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor Atualizado em Negócios";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A385NegValorAtualizado, 16, 2);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltItem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Item";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A454NegUltItem), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A572NegDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A573NegDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A574NegDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A575NegDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A576NegDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A577NegDelUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Using cursor P007P4 */
            pr_default.execute(1, new Object[] {A345NegID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A435NgpItem = P007P4_A435NgpItem[0];
               A455NgpInsData = P007P4_A455NgpInsData[0];
               A456NgpInsHora = P007P4_A456NgpInsHora[0];
               A457NgpInsDataHora = P007P4_A457NgpInsDataHora[0];
               A458NgpInsUsuID = P007P4_A458NgpInsUsuID[0];
               n458NgpInsUsuID = P007P4_n458NgpInsUsuID[0];
               A459NgpInsUsuNome = P007P4_A459NgpInsUsuNome[0];
               n459NgpInsUsuNome = P007P4_n459NgpInsUsuNome[0];
               A478NgpTppID = P007P4_A478NgpTppID[0];
               A439NgpTppPrdID = P007P4_A439NgpTppPrdID[0];
               A440NgpTppPrdCodigo = P007P4_A440NgpTppPrdCodigo[0];
               A441NgpTppPrdNome = P007P4_A441NgpTppPrdNome[0];
               A442NgpTppPrdTipoID = P007P4_A442NgpTppPrdTipoID[0];
               A443NgpTppPrdAtivo = P007P4_A443NgpTppPrdAtivo[0];
               A444NgpTpp1Preco = P007P4_A444NgpTpp1Preco[0];
               A445NgpPreco = P007P4_A445NgpPreco[0];
               A446NgpQtde = P007P4_A446NgpQtde[0];
               A447NgpTotal = P007P4_A447NgpTotal[0];
               A453NgpObs = P007P4_A453NgpObs[0];
               A578NgpDel = P007P4_A578NgpDel[0];
               A579NgpDelDataHora = P007P4_A579NgpDelDataHora[0];
               n579NgpDelDataHora = P007P4_n579NgpDelDataHora[0];
               A580NgpDelData = P007P4_A580NgpDelData[0];
               n580NgpDelData = P007P4_n580NgpDelData[0];
               A581NgpDelHora = P007P4_A581NgpDelHora[0];
               n581NgpDelHora = P007P4_n581NgpDelHora[0];
               A582NgpDelUsuId = P007P4_A582NgpDelUsuId[0];
               n582NgpDelUsuId = P007P4_n582NgpDelUsuId[0];
               A583NgpDelUsuNome = P007P4_A583NgpDelUsuNome[0];
               n583NgpDelUsuNome = P007P4_n583NgpDelUsuNome[0];
               A440NgpTppPrdCodigo = P007P4_A440NgpTppPrdCodigo[0];
               A441NgpTppPrdNome = P007P4_A441NgpTppPrdNome[0];
               A442NgpTppPrdTipoID = P007P4_A442NgpTppPrdTipoID[0];
               A443NgpTppPrdAtivo = P007P4_A443NgpTppPrdAtivo[0];
               A444NgpTpp1Preco = P007P4_A444NgpTpp1Preco[0];
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj_item";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpItem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Item";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A435NgpItem), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A455NgpInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A456NgpInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A458NgpInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A459NgpInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tabela";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A478NgpTppID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A439NgpTppPrdID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdCodigo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código do Produto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A440NgpTppPrdCodigo;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Produto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A441NgpTppPrdNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto ou Serviço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A442NgpTppPrdTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A443NgpTppPrdAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTpp1Preco";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço Tabela";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A444NgpTpp1Preco, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpPreco";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A445NgpPreco, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpQtde";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Qtde.";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A446NgpQtde), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTotal";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Total";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A447NgpTotal, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpObs";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Observações";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A453NgpObs;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A578NgpDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A580NgpDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A581NgpDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A582NgpDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A583NgpDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007P7 */
         pr_default.execute(2, new Object[] {AV17NegID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A345NegID = P007P7_A345NegID[0];
            A356NegCodigo = P007P7_A356NegCodigo[0];
            A346NegInsData = P007P7_A346NegInsData[0];
            A347NegInsHora = P007P7_A347NegInsHora[0];
            A348NegInsDataHora = P007P7_A348NegInsDataHora[0];
            A349NegInsUsuID = P007P7_A349NegInsUsuID[0];
            n349NegInsUsuID = P007P7_n349NegInsUsuID[0];
            A364NegInsUsuNome = P007P7_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P007P7_n364NegInsUsuNome[0];
            A350NegCliID = P007P7_A350NegCliID[0];
            A473NegCliMatricula = P007P7_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = P007P7_A351NegCliNomeFamiliar[0];
            A352NegCpjID = P007P7_A352NegCpjID[0];
            A353NegCpjNomFan = P007P7_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = P007P7_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = P007P7_A355NegCpjMatricula[0];
            A357NegPjtID = P007P7_A357NegPjtID[0];
            A358NegPjtSigla = P007P7_A358NegPjtSigla[0];
            A359NegPjtNome = P007P7_A359NegPjtNome[0];
            A369NegCpjEndSeq = P007P7_A369NegCpjEndSeq[0];
            A370NegCpjEndNome = P007P7_A370NegCpjEndNome[0];
            A642NegCpjEndCep = P007P7_A642NegCpjEndCep[0];
            A375NegCpjEndMunID = P007P7_A375NegCpjEndMunID[0];
            A377NegCpjEndUFID = P007P7_A377NegCpjEndUFID[0];
            A379NegCpjEndUFNome = P007P7_A379NegCpjEndUFNome[0];
            A360NegAgcID = P007P7_A360NegAgcID[0];
            n360NegAgcID = P007P7_n360NegAgcID[0];
            A361NegAgcNome = P007P7_A361NegAgcNome[0];
            n361NegAgcNome = P007P7_n361NegAgcNome[0];
            A362NegAssunto = P007P7_A362NegAssunto[0];
            A363NegDescricao = P007P7_A363NegDescricao[0];
            A380NegValorEstimado = P007P7_A380NegValorEstimado[0];
            A385NegValorAtualizado = P007P7_A385NegValorAtualizado[0];
            A454NegUltItem = P007P7_A454NegUltItem[0];
            n454NegUltItem = P007P7_n454NegUltItem[0];
            A572NegDel = P007P7_A572NegDel[0];
            A573NegDelDataHora = P007P7_A573NegDelDataHora[0];
            n573NegDelDataHora = P007P7_n573NegDelDataHora[0];
            A574NegDelData = P007P7_A574NegDelData[0];
            n574NegDelData = P007P7_n574NegDelData[0];
            A575NegDelHora = P007P7_A575NegDelHora[0];
            n575NegDelHora = P007P7_n575NegDelHora[0];
            A576NegDelUsuId = P007P7_A576NegDelUsuId[0];
            n576NegDelUsuId = P007P7_n576NegDelUsuId[0];
            A577NegDelUsuNome = P007P7_A577NegDelUsuNome[0];
            n577NegDelUsuNome = P007P7_n577NegDelUsuNome[0];
            A448NegPgpTotal = P007P7_A448NegPgpTotal[0];
            n448NegPgpTotal = P007P7_n448NegPgpTotal[0];
            A40000GXC1 = P007P7_A40000GXC1[0];
            n40000GXC1 = P007P7_n40000GXC1[0];
            A373NegCpjEndComplem = P007P7_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007P7_n373NegCpjEndComplem[0];
            A372NegCpjEndNumero = P007P7_A372NegCpjEndNumero[0];
            A378NegCpjEndUFSigla = P007P7_A378NegCpjEndUFSigla[0];
            A376NegCpjEndMunNome = P007P7_A376NegCpjEndMunNome[0];
            A643NegCpjEndCepFormat = P007P7_A643NegCpjEndCepFormat[0];
            A374NegCpjEndBairro = P007P7_A374NegCpjEndBairro[0];
            A371NegCpjEndEndereco = P007P7_A371NegCpjEndEndereco[0];
            A448NegPgpTotal = P007P7_A448NegPgpTotal[0];
            n448NegPgpTotal = P007P7_n448NegPgpTotal[0];
            A473NegCliMatricula = P007P7_A473NegCliMatricula[0];
            A355NegCpjMatricula = P007P7_A355NegCpjMatricula[0];
            A357NegPjtID = P007P7_A357NegPjtID[0];
            A358NegPjtSigla = P007P7_A358NegPjtSigla[0];
            A370NegCpjEndNome = P007P7_A370NegCpjEndNome[0];
            A642NegCpjEndCep = P007P7_A642NegCpjEndCep[0];
            A375NegCpjEndMunID = P007P7_A375NegCpjEndMunID[0];
            A377NegCpjEndUFID = P007P7_A377NegCpjEndUFID[0];
            A379NegCpjEndUFNome = P007P7_A379NegCpjEndUFNome[0];
            A373NegCpjEndComplem = P007P7_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007P7_n373NegCpjEndComplem[0];
            A372NegCpjEndNumero = P007P7_A372NegCpjEndNumero[0];
            A378NegCpjEndUFSigla = P007P7_A378NegCpjEndUFSigla[0];
            A376NegCpjEndMunNome = P007P7_A376NegCpjEndMunNome[0];
            A643NegCpjEndCepFormat = P007P7_A643NegCpjEndCepFormat[0];
            A374NegCpjEndBairro = P007P7_A374NegCpjEndBairro[0];
            A371NegCpjEndEndereco = P007P7_A371NegCpjEndEndereco[0];
            A40000GXC1 = P007P7_A40000GXC1[0];
            n40000GXC1 = P007P7_n40000GXC1[0];
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
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345NegID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCodigo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código da Negociação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A356NegCodigo), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A346NegInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A349NegInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuários de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A364NegInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A350NegCliID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula do Cliente";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A473NegCliMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliNomeFamiliar";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome Familiar";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A351NegCliNomeFamiliar;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A352NegCpjID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjNomFan";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome Fantasia";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A353NegCpjNomFan;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjRazSocial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Razão Social";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A354NegCpjRazSocial;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A355NegCpjMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo da Unidade";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A357NegPjtID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla do Tipo da Unidade";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358NegPjtSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Tipo da Unidade";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A359NegPjtNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A369NegCpjEndSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Endereço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A370NegCpjEndNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndEndereco";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A371NegCpjEndEndereco;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndNumero";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Número";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A372NegCpjEndNumero;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndComplem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Complemento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A373NegCpjEndComplem;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndBairro";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Bairro";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A374NegCpjEndBairro;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndCep";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A642NegCpjEndCep), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndCepFormat";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP Formatado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A643NegCpjEndCepFormat;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código do Município";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A375NegCpjEndMunID), 7, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Município";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A376NegCpjEndMunNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A377NegCpjEndUFID), 2, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla da UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A378NegCpjEndUFSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome da UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A379NegCpjEndUFNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndCompleto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço Completo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A641NegCpjEndCompleto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID do Agente Comercial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A360NegAgcID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Agente Comercial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A361NegAgcNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAssunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A362NegAssunto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDescricao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A363NegDescricao;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPgpTotal";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Total de Produtos";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A448NegPgpTotal, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegValorEstimado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor Estimado em Negócios";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A380NegValorEstimado, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegValorAtualizado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor Atualizado em Negócios";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A385NegValorAtualizado, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltItem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Item";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A454NegUltItem), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A572NegDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A573NegDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A574NegDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A575NegDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A576NegDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A577NegDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               /* Using cursor P007P8 */
               pr_default.execute(3, new Object[] {A345NegID});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A435NgpItem = P007P8_A435NgpItem[0];
                  A455NgpInsData = P007P8_A455NgpInsData[0];
                  A456NgpInsHora = P007P8_A456NgpInsHora[0];
                  A457NgpInsDataHora = P007P8_A457NgpInsDataHora[0];
                  A458NgpInsUsuID = P007P8_A458NgpInsUsuID[0];
                  n458NgpInsUsuID = P007P8_n458NgpInsUsuID[0];
                  A459NgpInsUsuNome = P007P8_A459NgpInsUsuNome[0];
                  n459NgpInsUsuNome = P007P8_n459NgpInsUsuNome[0];
                  A478NgpTppID = P007P8_A478NgpTppID[0];
                  A439NgpTppPrdID = P007P8_A439NgpTppPrdID[0];
                  A440NgpTppPrdCodigo = P007P8_A440NgpTppPrdCodigo[0];
                  A441NgpTppPrdNome = P007P8_A441NgpTppPrdNome[0];
                  A442NgpTppPrdTipoID = P007P8_A442NgpTppPrdTipoID[0];
                  A443NgpTppPrdAtivo = P007P8_A443NgpTppPrdAtivo[0];
                  A444NgpTpp1Preco = P007P8_A444NgpTpp1Preco[0];
                  A445NgpPreco = P007P8_A445NgpPreco[0];
                  A446NgpQtde = P007P8_A446NgpQtde[0];
                  A447NgpTotal = P007P8_A447NgpTotal[0];
                  A453NgpObs = P007P8_A453NgpObs[0];
                  A578NgpDel = P007P8_A578NgpDel[0];
                  A579NgpDelDataHora = P007P8_A579NgpDelDataHora[0];
                  n579NgpDelDataHora = P007P8_n579NgpDelDataHora[0];
                  A580NgpDelData = P007P8_A580NgpDelData[0];
                  n580NgpDelData = P007P8_n580NgpDelData[0];
                  A581NgpDelHora = P007P8_A581NgpDelHora[0];
                  n581NgpDelHora = P007P8_n581NgpDelHora[0];
                  A582NgpDelUsuId = P007P8_A582NgpDelUsuId[0];
                  n582NgpDelUsuId = P007P8_n582NgpDelUsuId[0];
                  A583NgpDelUsuNome = P007P8_A583NgpDelUsuNome[0];
                  n583NgpDelUsuNome = P007P8_n583NgpDelUsuNome[0];
                  A440NgpTppPrdCodigo = P007P8_A440NgpTppPrdCodigo[0];
                  A441NgpTppPrdNome = P007P8_A441NgpTppPrdNome[0];
                  A442NgpTppPrdTipoID = P007P8_A442NgpTppPrdTipoID[0];
                  A443NgpTppPrdAtivo = P007P8_A443NgpTppPrdAtivo[0];
                  A444NgpTpp1Preco = P007P8_A444NgpTpp1Preco[0];
                  AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                  AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj_item";
                  AV12AuditingObjectRecordItem.gxTpr_Mode = "INS";
                  AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpItem";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Item";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A435NgpItem), 8, 0);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A455NgpInsData, 2, "/");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A456NgpInsHora, 0, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsUsuID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A458NgpInsUsuID;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpInsUsuNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A459NgpInsUsuNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tabela";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A478NgpTppID.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A439NgpTppPrdID.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdCodigo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código do Produto";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A440NgpTppPrdCodigo;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Produto";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A441NgpTppPrdNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdTipoID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto ou Serviço";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A442NgpTppPrdTipoID), 9, 0);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdAtivo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto Ativo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A443NgpTppPrdAtivo);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTpp1Preco";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço Tabela";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A444NgpTpp1Preco, 16, 2);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpPreco";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A445NgpPreco, 16, 2);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpQtde";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Qtde.";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A446NgpQtde), 8, 0);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTotal";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Total";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A447NgpTotal, 16, 2);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpObs";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Observações";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A453NgpObs;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDel";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A578NgpDel);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A580NgpDelData, 10, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A581NgpDelHora, 0, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelUsuId";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A582NgpDelUsuId;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpDelUsuNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A583NgpDelUsuNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22CountUpdatedNgpItem = 0;
               AV29GXV1 = 1;
               while ( AV29GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV29GXV1));
                  if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj") == 0 )
                  {
                     AV30GXV2 = 1;
                     while ( AV30GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV30GXV2));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A345NegID.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCodigo") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A356NegCodigo), 12, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegInsData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A346NegInsData, 2, "/");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegInsHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegInsDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegInsUsuID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A349NegInsUsuID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegInsUsuNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A364NegInsUsuNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCliID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A350NegCliID.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCliMatricula") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A473NegCliMatricula), 12, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCliNomeFamiliar") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A351NegCliNomeFamiliar;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A352NegCpjID.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjNomFan") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A353NegCpjNomFan;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjRazSocial") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A354NegCpjRazSocial;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjMatricula") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A355NegCpjMatricula), 12, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegPjtID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A357NegPjtID), 9, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegPjtSigla") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358NegPjtSigla;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegPjtNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A359NegPjtNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndSeq") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A369NegCpjEndSeq), 4, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A370NegCpjEndNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndEndereco") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A371NegCpjEndEndereco;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndNumero") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A372NegCpjEndNumero;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndComplem") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A373NegCpjEndComplem;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndBairro") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A374NegCpjEndBairro;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndCep") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A642NegCpjEndCep), 8, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndCepFormat") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A643NegCpjEndCepFormat;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndMunID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A375NegCpjEndMunID), 7, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndMunNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A376NegCpjEndMunNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndUFID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A377NegCpjEndUFID), 2, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndUFSigla") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A378NegCpjEndUFSigla;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndUFNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A379NegCpjEndUFNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegCpjEndCompleto") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A641NegCpjEndCompleto;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegAgcID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A360NegAgcID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegAgcNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A361NegAgcNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegAssunto") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A362NegAssunto;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDescricao") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A363NegDescricao;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegPgpTotal") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A448NegPgpTotal, 16, 2);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegValorEstimado") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A380NegValorEstimado, 16, 2);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegValorAtualizado") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A385NegValorAtualizado, 16, 2);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegUltItem") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A454NegUltItem), 8, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDel") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A572NegDel);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDelDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A573NegDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDelData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A574NegDelData, 10, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDelHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A575NegDelHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDelUsuId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A576NegDelUsuId;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegDelUsuNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A577NegDelUsuNome;
                        }
                        AV30GXV2 = (int)(AV30GXV2+1);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj_item") == 0 )
                  {
                     AV21CountKeyAttributes = 0;
                     AV31GXV3 = 1;
                     while ( AV31GXV3 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV31GXV3));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpItem") == 0 )
                        {
                           AV23KeyNgpItem = (int)(Math.Round(NumberUtil.Val( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue, "."), 18, MidpointRounding.ToEven));
                           AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                           if ( AV21CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV31GXV3 = (int)(AV31GXV3+1);
                     }
                     AV32GXLvl1314 = 0;
                     /* Using cursor P007P9 */
                     pr_default.execute(4, new Object[] {A345NegID, AV23KeyNgpItem});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A435NgpItem = P007P9_A435NgpItem[0];
                        A455NgpInsData = P007P9_A455NgpInsData[0];
                        A456NgpInsHora = P007P9_A456NgpInsHora[0];
                        A457NgpInsDataHora = P007P9_A457NgpInsDataHora[0];
                        A458NgpInsUsuID = P007P9_A458NgpInsUsuID[0];
                        n458NgpInsUsuID = P007P9_n458NgpInsUsuID[0];
                        A459NgpInsUsuNome = P007P9_A459NgpInsUsuNome[0];
                        n459NgpInsUsuNome = P007P9_n459NgpInsUsuNome[0];
                        A478NgpTppID = P007P9_A478NgpTppID[0];
                        A439NgpTppPrdID = P007P9_A439NgpTppPrdID[0];
                        A440NgpTppPrdCodigo = P007P9_A440NgpTppPrdCodigo[0];
                        A441NgpTppPrdNome = P007P9_A441NgpTppPrdNome[0];
                        A442NgpTppPrdTipoID = P007P9_A442NgpTppPrdTipoID[0];
                        A443NgpTppPrdAtivo = P007P9_A443NgpTppPrdAtivo[0];
                        A444NgpTpp1Preco = P007P9_A444NgpTpp1Preco[0];
                        A445NgpPreco = P007P9_A445NgpPreco[0];
                        A446NgpQtde = P007P9_A446NgpQtde[0];
                        A447NgpTotal = P007P9_A447NgpTotal[0];
                        A453NgpObs = P007P9_A453NgpObs[0];
                        A578NgpDel = P007P9_A578NgpDel[0];
                        A579NgpDelDataHora = P007P9_A579NgpDelDataHora[0];
                        n579NgpDelDataHora = P007P9_n579NgpDelDataHora[0];
                        A580NgpDelData = P007P9_A580NgpDelData[0];
                        n580NgpDelData = P007P9_n580NgpDelData[0];
                        A581NgpDelHora = P007P9_A581NgpDelHora[0];
                        n581NgpDelHora = P007P9_n581NgpDelHora[0];
                        A582NgpDelUsuId = P007P9_A582NgpDelUsuId[0];
                        n582NgpDelUsuId = P007P9_n582NgpDelUsuId[0];
                        A583NgpDelUsuNome = P007P9_A583NgpDelUsuNome[0];
                        n583NgpDelUsuNome = P007P9_n583NgpDelUsuNome[0];
                        A440NgpTppPrdCodigo = P007P9_A440NgpTppPrdCodigo[0];
                        A441NgpTppPrdNome = P007P9_A441NgpTppPrdNome[0];
                        A442NgpTppPrdTipoID = P007P9_A442NgpTppPrdTipoID[0];
                        A443NgpTppPrdAtivo = P007P9_A443NgpTppPrdAtivo[0];
                        A444NgpTpp1Preco = P007P9_A444NgpTpp1Preco[0];
                        AV32GXLvl1314 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV22CountUpdatedNgpItem = (short)(AV22CountUpdatedNgpItem+1);
                        AV33GXV4 = 1;
                        while ( AV33GXV4 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV33GXV4));
                           if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpItem") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A435NgpItem), 8, 0);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpInsData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A455NgpInsData, 2, "/");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpInsHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A456NgpInsHora, 0, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpInsDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpInsUsuID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A458NgpInsUsuID;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpInsUsuNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A459NgpInsUsuNome;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTppID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A478NgpTppID.ToString();
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTppPrdID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A439NgpTppPrdID.ToString();
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTppPrdCodigo") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A440NgpTppPrdCodigo;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTppPrdNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A441NgpTppPrdNome;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTppPrdTipoID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A442NgpTppPrdTipoID), 9, 0);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTppPrdAtivo") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A443NgpTppPrdAtivo);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTpp1Preco") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A444NgpTpp1Preco, 16, 2);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpPreco") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A445NgpPreco, 16, 2);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpQtde") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A446NgpQtde), 8, 0);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpTotal") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A447NgpTotal, 16, 2);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpObs") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A453NgpObs;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpDel") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A578NgpDel);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpDelDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpDelData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A580NgpDelData, 10, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpDelHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A581NgpDelHora, 0, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpDelUsuId") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A582NgpDelUsuId;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpDelUsuNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A583NgpDelUsuNome;
                           }
                           AV33GXV4 = (int)(AV33GXV4+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(4);
                     if ( AV32GXLvl1314 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  AV29GXV1 = (int)(AV29GXV1+1);
               }
               if ( AV22CountUpdatedNgpItem < A40000GXC1 )
               {
                  AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P007P10 */
                  pr_default.execute(5, new Object[] {AV17NegID});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A345NegID = P007P10_A345NegID[0];
                     A435NgpItem = P007P10_A435NgpItem[0];
                     A455NgpInsData = P007P10_A455NgpInsData[0];
                     A456NgpInsHora = P007P10_A456NgpInsHora[0];
                     A457NgpInsDataHora = P007P10_A457NgpInsDataHora[0];
                     A458NgpInsUsuID = P007P10_A458NgpInsUsuID[0];
                     n458NgpInsUsuID = P007P10_n458NgpInsUsuID[0];
                     A459NgpInsUsuNome = P007P10_A459NgpInsUsuNome[0];
                     n459NgpInsUsuNome = P007P10_n459NgpInsUsuNome[0];
                     A478NgpTppID = P007P10_A478NgpTppID[0];
                     A439NgpTppPrdID = P007P10_A439NgpTppPrdID[0];
                     A440NgpTppPrdCodigo = P007P10_A440NgpTppPrdCodigo[0];
                     A441NgpTppPrdNome = P007P10_A441NgpTppPrdNome[0];
                     A442NgpTppPrdTipoID = P007P10_A442NgpTppPrdTipoID[0];
                     A443NgpTppPrdAtivo = P007P10_A443NgpTppPrdAtivo[0];
                     A444NgpTpp1Preco = P007P10_A444NgpTpp1Preco[0];
                     A445NgpPreco = P007P10_A445NgpPreco[0];
                     A446NgpQtde = P007P10_A446NgpQtde[0];
                     A447NgpTotal = P007P10_A447NgpTotal[0];
                     A453NgpObs = P007P10_A453NgpObs[0];
                     A578NgpDel = P007P10_A578NgpDel[0];
                     A579NgpDelDataHora = P007P10_A579NgpDelDataHora[0];
                     n579NgpDelDataHora = P007P10_n579NgpDelDataHora[0];
                     A580NgpDelData = P007P10_A580NgpDelData[0];
                     n580NgpDelData = P007P10_n580NgpDelData[0];
                     A581NgpDelHora = P007P10_A581NgpDelHora[0];
                     n581NgpDelHora = P007P10_n581NgpDelHora[0];
                     A582NgpDelUsuId = P007P10_A582NgpDelUsuId[0];
                     n582NgpDelUsuId = P007P10_n582NgpDelUsuId[0];
                     A583NgpDelUsuNome = P007P10_A583NgpDelUsuNome[0];
                     n583NgpDelUsuNome = P007P10_n583NgpDelUsuNome[0];
                     A440NgpTppPrdCodigo = P007P10_A440NgpTppPrdCodigo[0];
                     A441NgpTppPrdNome = P007P10_A441NgpTppPrdNome[0];
                     A442NgpTppPrdTipoID = P007P10_A442NgpTppPrdTipoID[0];
                     A443NgpTppPrdAtivo = P007P10_A443NgpTppPrdAtivo[0];
                     A444NgpTpp1Preco = P007P10_A444NgpTpp1Preco[0];
                     AV23KeyNgpItem = A435NgpItem;
                     AV24RecordExistsNgpItem = false;
                     AV35GXV5 = 1;
                     while ( AV35GXV5 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV35GXV5));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj_item") == 0 )
                        {
                           AV21CountKeyAttributes = 0;
                           AV36GXV6 = 1;
                           while ( AV36GXV6 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV36GXV6));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpItem") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( StringUtil.Str( (decimal)(AV23KeyNgpItem), 8, 0))) == 0 )
                                 {
                                    AV24RecordExistsNgpItem = true;
                                    AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                                    if ( AV21CountKeyAttributes == 1 )
                                    {
                                       if (true) break;
                                    }
                                 }
                              }
                              AV36GXV6 = (int)(AV36GXV6+1);
                           }
                        }
                        AV35GXV5 = (int)(AV35GXV5+1);
                     }
                     if ( ! ( AV24RecordExistsNgpItem ) )
                     {
                        AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                        AV19AuditingObjectRecordItemNew.gxTpr_Tablename = "tb_negociopj_item";
                        AV19AuditingObjectRecordItemNew.gxTpr_Mode = "INS";
                        AV18AuditingObjectNewRecords.gxTpr_Record.Add(AV19AuditingObjectRecordItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpItem";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Item";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A435NgpItem), 8, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpInsData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.DToC( A455NgpInsData, 2, "/");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpInsHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Hora de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A456NgpInsHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpInsDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpInsUsuID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A458NgpInsUsuID;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpInsUsuNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Nome do Usuário de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A459NgpInsUsuNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Tabela";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A478NgpTppID.ToString();
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Produto";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A439NgpTppPrdID.ToString();
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdCodigo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Código do Produto";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A440NgpTppPrdCodigo;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Descrição do Produto";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A441NgpTppPrdNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdTipoID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Tipo do Produto ou Serviço";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A442NgpTppPrdTipoID), 9, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdAtivo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Produto Ativo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A443NgpTppPrdAtivo);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTpp1Preco";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Preço Tabela";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( A444NgpTpp1Preco, 16, 2);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpPreco";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Preço";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( A445NgpPreco, 16, 2);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpQtde";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Qtde.";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A446NgpQtde), 8, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTotal";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Total";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( A447NgpTotal, 16, 2);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpObs";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Observações";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A453NgpObs;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpDel";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Registro Excluído";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A578NgpDel);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpDelDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpDelData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A580NgpDelData, 10, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpDelHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Hora de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A581NgpDelHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpDelUsuId";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário ID de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A582NgpDelUsuId;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpDelUsuNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Nome do Usuário de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A583NgpDelUsuNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                     }
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
                  AV37GXV7 = 1;
                  while ( AV37GXV7 <= AV18AuditingObjectNewRecords.gxTpr_Record.Count )
                  {
                     AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV18AuditingObjectNewRecords.gxTpr_Record.Item(AV37GXV7));
                     AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                     AV37GXV7 = (int)(AV37GXV7+1);
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         scmdbuf = "";
         P007P3_A345NegID = new Guid[] {Guid.Empty} ;
         P007P3_A356NegCodigo = new long[1] ;
         P007P3_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P007P3_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         P007P3_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P3_A349NegInsUsuID = new string[] {""} ;
         P007P3_n349NegInsUsuID = new bool[] {false} ;
         P007P3_A364NegInsUsuNome = new string[] {""} ;
         P007P3_n364NegInsUsuNome = new bool[] {false} ;
         P007P3_A350NegCliID = new Guid[] {Guid.Empty} ;
         P007P3_A473NegCliMatricula = new long[1] ;
         P007P3_A351NegCliNomeFamiliar = new string[] {""} ;
         P007P3_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P007P3_A353NegCpjNomFan = new string[] {""} ;
         P007P3_A354NegCpjRazSocial = new string[] {""} ;
         P007P3_A355NegCpjMatricula = new long[1] ;
         P007P3_A357NegPjtID = new int[1] ;
         P007P3_A358NegPjtSigla = new string[] {""} ;
         P007P3_A359NegPjtNome = new string[] {""} ;
         P007P3_A369NegCpjEndSeq = new short[1] ;
         P007P3_A370NegCpjEndNome = new string[] {""} ;
         P007P3_A642NegCpjEndCep = new int[1] ;
         P007P3_A375NegCpjEndMunID = new int[1] ;
         P007P3_A377NegCpjEndUFID = new short[1] ;
         P007P3_A379NegCpjEndUFNome = new string[] {""} ;
         P007P3_A360NegAgcID = new string[] {""} ;
         P007P3_n360NegAgcID = new bool[] {false} ;
         P007P3_A361NegAgcNome = new string[] {""} ;
         P007P3_n361NegAgcNome = new bool[] {false} ;
         P007P3_A362NegAssunto = new string[] {""} ;
         P007P3_A363NegDescricao = new string[] {""} ;
         P007P3_A380NegValorEstimado = new decimal[1] ;
         P007P3_A385NegValorAtualizado = new decimal[1] ;
         P007P3_A454NegUltItem = new int[1] ;
         P007P3_n454NegUltItem = new bool[] {false} ;
         P007P3_A572NegDel = new bool[] {false} ;
         P007P3_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P3_n573NegDelDataHora = new bool[] {false} ;
         P007P3_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         P007P3_n574NegDelData = new bool[] {false} ;
         P007P3_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         P007P3_n575NegDelHora = new bool[] {false} ;
         P007P3_A576NegDelUsuId = new string[] {""} ;
         P007P3_n576NegDelUsuId = new bool[] {false} ;
         P007P3_A577NegDelUsuNome = new string[] {""} ;
         P007P3_n577NegDelUsuNome = new bool[] {false} ;
         P007P3_A448NegPgpTotal = new decimal[1] ;
         P007P3_n448NegPgpTotal = new bool[] {false} ;
         P007P3_A373NegCpjEndComplem = new string[] {""} ;
         P007P3_n373NegCpjEndComplem = new bool[] {false} ;
         P007P3_A372NegCpjEndNumero = new string[] {""} ;
         P007P3_A378NegCpjEndUFSigla = new string[] {""} ;
         P007P3_A376NegCpjEndMunNome = new string[] {""} ;
         P007P3_A643NegCpjEndCepFormat = new string[] {""} ;
         P007P3_A374NegCpjEndBairro = new string[] {""} ;
         P007P3_A371NegCpjEndEndereco = new string[] {""} ;
         A345NegID = Guid.Empty;
         A346NegInsData = DateTime.MinValue;
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A349NegInsUsuID = "";
         A364NegInsUsuNome = "";
         A350NegCliID = Guid.Empty;
         A351NegCliNomeFamiliar = "";
         A352NegCpjID = Guid.Empty;
         A353NegCpjNomFan = "";
         A354NegCpjRazSocial = "";
         A358NegPjtSigla = "";
         A359NegPjtNome = "";
         A370NegCpjEndNome = "";
         A379NegCpjEndUFNome = "";
         A360NegAgcID = "";
         A361NegAgcNome = "";
         A362NegAssunto = "";
         A363NegDescricao = "";
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         A574NegDelData = (DateTime)(DateTime.MinValue);
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         A576NegDelUsuId = "";
         A577NegDelUsuNome = "";
         A373NegCpjEndComplem = "";
         A372NegCpjEndNumero = "";
         A378NegCpjEndUFSigla = "";
         A376NegCpjEndMunNome = "";
         A643NegCpjEndCepFormat = "";
         A374NegCpjEndBairro = "";
         A371NegCpjEndEndereco = "";
         A641NegCpjEndCompleto = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007P4_A345NegID = new Guid[] {Guid.Empty} ;
         P007P4_A435NgpItem = new int[1] ;
         P007P4_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007P4_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007P4_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P4_A458NgpInsUsuID = new string[] {""} ;
         P007P4_n458NgpInsUsuID = new bool[] {false} ;
         P007P4_A459NgpInsUsuNome = new string[] {""} ;
         P007P4_n459NgpInsUsuNome = new bool[] {false} ;
         P007P4_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007P4_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007P4_A440NgpTppPrdCodigo = new string[] {""} ;
         P007P4_A441NgpTppPrdNome = new string[] {""} ;
         P007P4_A442NgpTppPrdTipoID = new int[1] ;
         P007P4_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007P4_A444NgpTpp1Preco = new decimal[1] ;
         P007P4_A445NgpPreco = new decimal[1] ;
         P007P4_A446NgpQtde = new int[1] ;
         P007P4_A447NgpTotal = new decimal[1] ;
         P007P4_A453NgpObs = new string[] {""} ;
         P007P4_A578NgpDel = new bool[] {false} ;
         P007P4_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P4_n579NgpDelDataHora = new bool[] {false} ;
         P007P4_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007P4_n580NgpDelData = new bool[] {false} ;
         P007P4_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007P4_n581NgpDelHora = new bool[] {false} ;
         P007P4_A582NgpDelUsuId = new string[] {""} ;
         P007P4_n582NgpDelUsuId = new bool[] {false} ;
         P007P4_A583NgpDelUsuNome = new string[] {""} ;
         P007P4_n583NgpDelUsuNome = new bool[] {false} ;
         A455NgpInsData = DateTime.MinValue;
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         A458NgpInsUsuID = "";
         A459NgpInsUsuNome = "";
         A478NgpTppID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         A440NgpTppPrdCodigo = "";
         A441NgpTppPrdNome = "";
         A453NgpObs = "";
         A579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         A580NgpDelData = (DateTime)(DateTime.MinValue);
         A581NgpDelHora = (DateTime)(DateTime.MinValue);
         A582NgpDelUsuId = "";
         A583NgpDelUsuNome = "";
         P007P7_A345NegID = new Guid[] {Guid.Empty} ;
         P007P7_A356NegCodigo = new long[1] ;
         P007P7_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P007P7_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         P007P7_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P7_A349NegInsUsuID = new string[] {""} ;
         P007P7_n349NegInsUsuID = new bool[] {false} ;
         P007P7_A364NegInsUsuNome = new string[] {""} ;
         P007P7_n364NegInsUsuNome = new bool[] {false} ;
         P007P7_A350NegCliID = new Guid[] {Guid.Empty} ;
         P007P7_A473NegCliMatricula = new long[1] ;
         P007P7_A351NegCliNomeFamiliar = new string[] {""} ;
         P007P7_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P007P7_A353NegCpjNomFan = new string[] {""} ;
         P007P7_A354NegCpjRazSocial = new string[] {""} ;
         P007P7_A355NegCpjMatricula = new long[1] ;
         P007P7_A357NegPjtID = new int[1] ;
         P007P7_A358NegPjtSigla = new string[] {""} ;
         P007P7_A359NegPjtNome = new string[] {""} ;
         P007P7_A369NegCpjEndSeq = new short[1] ;
         P007P7_A370NegCpjEndNome = new string[] {""} ;
         P007P7_A642NegCpjEndCep = new int[1] ;
         P007P7_A375NegCpjEndMunID = new int[1] ;
         P007P7_A377NegCpjEndUFID = new short[1] ;
         P007P7_A379NegCpjEndUFNome = new string[] {""} ;
         P007P7_A360NegAgcID = new string[] {""} ;
         P007P7_n360NegAgcID = new bool[] {false} ;
         P007P7_A361NegAgcNome = new string[] {""} ;
         P007P7_n361NegAgcNome = new bool[] {false} ;
         P007P7_A362NegAssunto = new string[] {""} ;
         P007P7_A363NegDescricao = new string[] {""} ;
         P007P7_A380NegValorEstimado = new decimal[1] ;
         P007P7_A385NegValorAtualizado = new decimal[1] ;
         P007P7_A454NegUltItem = new int[1] ;
         P007P7_n454NegUltItem = new bool[] {false} ;
         P007P7_A572NegDel = new bool[] {false} ;
         P007P7_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P7_n573NegDelDataHora = new bool[] {false} ;
         P007P7_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         P007P7_n574NegDelData = new bool[] {false} ;
         P007P7_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         P007P7_n575NegDelHora = new bool[] {false} ;
         P007P7_A576NegDelUsuId = new string[] {""} ;
         P007P7_n576NegDelUsuId = new bool[] {false} ;
         P007P7_A577NegDelUsuNome = new string[] {""} ;
         P007P7_n577NegDelUsuNome = new bool[] {false} ;
         P007P7_A448NegPgpTotal = new decimal[1] ;
         P007P7_n448NegPgpTotal = new bool[] {false} ;
         P007P7_A40000GXC1 = new int[1] ;
         P007P7_n40000GXC1 = new bool[] {false} ;
         P007P7_A373NegCpjEndComplem = new string[] {""} ;
         P007P7_n373NegCpjEndComplem = new bool[] {false} ;
         P007P7_A372NegCpjEndNumero = new string[] {""} ;
         P007P7_A378NegCpjEndUFSigla = new string[] {""} ;
         P007P7_A376NegCpjEndMunNome = new string[] {""} ;
         P007P7_A643NegCpjEndCepFormat = new string[] {""} ;
         P007P7_A374NegCpjEndBairro = new string[] {""} ;
         P007P7_A371NegCpjEndEndereco = new string[] {""} ;
         P007P8_A345NegID = new Guid[] {Guid.Empty} ;
         P007P8_A435NgpItem = new int[1] ;
         P007P8_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007P8_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007P8_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P8_A458NgpInsUsuID = new string[] {""} ;
         P007P8_n458NgpInsUsuID = new bool[] {false} ;
         P007P8_A459NgpInsUsuNome = new string[] {""} ;
         P007P8_n459NgpInsUsuNome = new bool[] {false} ;
         P007P8_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007P8_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007P8_A440NgpTppPrdCodigo = new string[] {""} ;
         P007P8_A441NgpTppPrdNome = new string[] {""} ;
         P007P8_A442NgpTppPrdTipoID = new int[1] ;
         P007P8_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007P8_A444NgpTpp1Preco = new decimal[1] ;
         P007P8_A445NgpPreco = new decimal[1] ;
         P007P8_A446NgpQtde = new int[1] ;
         P007P8_A447NgpTotal = new decimal[1] ;
         P007P8_A453NgpObs = new string[] {""} ;
         P007P8_A578NgpDel = new bool[] {false} ;
         P007P8_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P8_n579NgpDelDataHora = new bool[] {false} ;
         P007P8_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007P8_n580NgpDelData = new bool[] {false} ;
         P007P8_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007P8_n581NgpDelHora = new bool[] {false} ;
         P007P8_A582NgpDelUsuId = new string[] {""} ;
         P007P8_n582NgpDelUsuId = new bool[] {false} ;
         P007P8_A583NgpDelUsuNome = new string[] {""} ;
         P007P8_n583NgpDelUsuNome = new bool[] {false} ;
         P007P9_A345NegID = new Guid[] {Guid.Empty} ;
         P007P9_A435NgpItem = new int[1] ;
         P007P9_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007P9_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007P9_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P9_A458NgpInsUsuID = new string[] {""} ;
         P007P9_n458NgpInsUsuID = new bool[] {false} ;
         P007P9_A459NgpInsUsuNome = new string[] {""} ;
         P007P9_n459NgpInsUsuNome = new bool[] {false} ;
         P007P9_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007P9_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007P9_A440NgpTppPrdCodigo = new string[] {""} ;
         P007P9_A441NgpTppPrdNome = new string[] {""} ;
         P007P9_A442NgpTppPrdTipoID = new int[1] ;
         P007P9_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007P9_A444NgpTpp1Preco = new decimal[1] ;
         P007P9_A445NgpPreco = new decimal[1] ;
         P007P9_A446NgpQtde = new int[1] ;
         P007P9_A447NgpTotal = new decimal[1] ;
         P007P9_A453NgpObs = new string[] {""} ;
         P007P9_A578NgpDel = new bool[] {false} ;
         P007P9_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P9_n579NgpDelDataHora = new bool[] {false} ;
         P007P9_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007P9_n580NgpDelData = new bool[] {false} ;
         P007P9_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007P9_n581NgpDelHora = new bool[] {false} ;
         P007P9_A582NgpDelUsuId = new string[] {""} ;
         P007P9_n582NgpDelUsuId = new bool[] {false} ;
         P007P9_A583NgpDelUsuNome = new string[] {""} ;
         P007P9_n583NgpDelUsuNome = new bool[] {false} ;
         AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         P007P10_A345NegID = new Guid[] {Guid.Empty} ;
         P007P10_A435NgpItem = new int[1] ;
         P007P10_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007P10_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007P10_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P10_A458NgpInsUsuID = new string[] {""} ;
         P007P10_n458NgpInsUsuID = new bool[] {false} ;
         P007P10_A459NgpInsUsuNome = new string[] {""} ;
         P007P10_n459NgpInsUsuNome = new bool[] {false} ;
         P007P10_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007P10_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007P10_A440NgpTppPrdCodigo = new string[] {""} ;
         P007P10_A441NgpTppPrdNome = new string[] {""} ;
         P007P10_A442NgpTppPrdTipoID = new int[1] ;
         P007P10_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007P10_A444NgpTpp1Preco = new decimal[1] ;
         P007P10_A445NgpPreco = new decimal[1] ;
         P007P10_A446NgpQtde = new int[1] ;
         P007P10_A447NgpTotal = new decimal[1] ;
         P007P10_A453NgpObs = new string[] {""} ;
         P007P10_A578NgpDel = new bool[] {false} ;
         P007P10_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007P10_n579NgpDelDataHora = new bool[] {false} ;
         P007P10_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007P10_n580NgpDelData = new bool[] {false} ;
         P007P10_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007P10_n581NgpDelHora = new bool[] {false} ;
         P007P10_A582NgpDelUsuId = new string[] {""} ;
         P007P10_n582NgpDelUsuId = new bool[] {false} ;
         P007P10_A583NgpDelUsuNome = new string[] {""} ;
         P007P10_n583NgpDelUsuNome = new bool[] {false} ;
         AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditnegociopj__default(),
            new Object[][] {
                new Object[] {
               P007P3_A345NegID, P007P3_A356NegCodigo, P007P3_A346NegInsData, P007P3_A347NegInsHora, P007P3_A348NegInsDataHora, P007P3_A349NegInsUsuID, P007P3_n349NegInsUsuID, P007P3_A364NegInsUsuNome, P007P3_n364NegInsUsuNome, P007P3_A350NegCliID,
               P007P3_A473NegCliMatricula, P007P3_A351NegCliNomeFamiliar, P007P3_A352NegCpjID, P007P3_A353NegCpjNomFan, P007P3_A354NegCpjRazSocial, P007P3_A355NegCpjMatricula, P007P3_A357NegPjtID, P007P3_A358NegPjtSigla, P007P3_A359NegPjtNome, P007P3_A369NegCpjEndSeq,
               P007P3_A370NegCpjEndNome, P007P3_A642NegCpjEndCep, P007P3_A375NegCpjEndMunID, P007P3_A377NegCpjEndUFID, P007P3_A379NegCpjEndUFNome, P007P3_A360NegAgcID, P007P3_n360NegAgcID, P007P3_A361NegAgcNome, P007P3_n361NegAgcNome, P007P3_A362NegAssunto,
               P007P3_A363NegDescricao, P007P3_A380NegValorEstimado, P007P3_A385NegValorAtualizado, P007P3_A454NegUltItem, P007P3_n454NegUltItem, P007P3_A572NegDel, P007P3_A573NegDelDataHora, P007P3_n573NegDelDataHora, P007P3_A574NegDelData, P007P3_n574NegDelData,
               P007P3_A575NegDelHora, P007P3_n575NegDelHora, P007P3_A576NegDelUsuId, P007P3_n576NegDelUsuId, P007P3_A577NegDelUsuNome, P007P3_n577NegDelUsuNome, P007P3_A448NegPgpTotal, P007P3_n448NegPgpTotal, P007P3_A373NegCpjEndComplem, P007P3_n373NegCpjEndComplem,
               P007P3_A372NegCpjEndNumero, P007P3_A378NegCpjEndUFSigla, P007P3_A376NegCpjEndMunNome, P007P3_A643NegCpjEndCepFormat, P007P3_A374NegCpjEndBairro, P007P3_A371NegCpjEndEndereco
               }
               , new Object[] {
               P007P4_A345NegID, P007P4_A435NgpItem, P007P4_A455NgpInsData, P007P4_A456NgpInsHora, P007P4_A457NgpInsDataHora, P007P4_A458NgpInsUsuID, P007P4_n458NgpInsUsuID, P007P4_A459NgpInsUsuNome, P007P4_n459NgpInsUsuNome, P007P4_A478NgpTppID,
               P007P4_A439NgpTppPrdID, P007P4_A440NgpTppPrdCodigo, P007P4_A441NgpTppPrdNome, P007P4_A442NgpTppPrdTipoID, P007P4_A443NgpTppPrdAtivo, P007P4_A444NgpTpp1Preco, P007P4_A445NgpPreco, P007P4_A446NgpQtde, P007P4_A447NgpTotal, P007P4_A453NgpObs,
               P007P4_A578NgpDel, P007P4_A579NgpDelDataHora, P007P4_n579NgpDelDataHora, P007P4_A580NgpDelData, P007P4_n580NgpDelData, P007P4_A581NgpDelHora, P007P4_n581NgpDelHora, P007P4_A582NgpDelUsuId, P007P4_n582NgpDelUsuId, P007P4_A583NgpDelUsuNome,
               P007P4_n583NgpDelUsuNome
               }
               , new Object[] {
               P007P7_A345NegID, P007P7_A356NegCodigo, P007P7_A346NegInsData, P007P7_A347NegInsHora, P007P7_A348NegInsDataHora, P007P7_A349NegInsUsuID, P007P7_n349NegInsUsuID, P007P7_A364NegInsUsuNome, P007P7_n364NegInsUsuNome, P007P7_A350NegCliID,
               P007P7_A473NegCliMatricula, P007P7_A351NegCliNomeFamiliar, P007P7_A352NegCpjID, P007P7_A353NegCpjNomFan, P007P7_A354NegCpjRazSocial, P007P7_A355NegCpjMatricula, P007P7_A357NegPjtID, P007P7_A358NegPjtSigla, P007P7_A359NegPjtNome, P007P7_A369NegCpjEndSeq,
               P007P7_A370NegCpjEndNome, P007P7_A642NegCpjEndCep, P007P7_A375NegCpjEndMunID, P007P7_A377NegCpjEndUFID, P007P7_A379NegCpjEndUFNome, P007P7_A360NegAgcID, P007P7_n360NegAgcID, P007P7_A361NegAgcNome, P007P7_n361NegAgcNome, P007P7_A362NegAssunto,
               P007P7_A363NegDescricao, P007P7_A380NegValorEstimado, P007P7_A385NegValorAtualizado, P007P7_A454NegUltItem, P007P7_n454NegUltItem, P007P7_A572NegDel, P007P7_A573NegDelDataHora, P007P7_n573NegDelDataHora, P007P7_A574NegDelData, P007P7_n574NegDelData,
               P007P7_A575NegDelHora, P007P7_n575NegDelHora, P007P7_A576NegDelUsuId, P007P7_n576NegDelUsuId, P007P7_A577NegDelUsuNome, P007P7_n577NegDelUsuNome, P007P7_A448NegPgpTotal, P007P7_n448NegPgpTotal, P007P7_A40000GXC1, P007P7_n40000GXC1,
               P007P7_A373NegCpjEndComplem, P007P7_n373NegCpjEndComplem, P007P7_A372NegCpjEndNumero, P007P7_A378NegCpjEndUFSigla, P007P7_A376NegCpjEndMunNome, P007P7_A643NegCpjEndCepFormat, P007P7_A374NegCpjEndBairro, P007P7_A371NegCpjEndEndereco
               }
               , new Object[] {
               P007P8_A345NegID, P007P8_A435NgpItem, P007P8_A455NgpInsData, P007P8_A456NgpInsHora, P007P8_A457NgpInsDataHora, P007P8_A458NgpInsUsuID, P007P8_n458NgpInsUsuID, P007P8_A459NgpInsUsuNome, P007P8_n459NgpInsUsuNome, P007P8_A478NgpTppID,
               P007P8_A439NgpTppPrdID, P007P8_A440NgpTppPrdCodigo, P007P8_A441NgpTppPrdNome, P007P8_A442NgpTppPrdTipoID, P007P8_A443NgpTppPrdAtivo, P007P8_A444NgpTpp1Preco, P007P8_A445NgpPreco, P007P8_A446NgpQtde, P007P8_A447NgpTotal, P007P8_A453NgpObs,
               P007P8_A578NgpDel, P007P8_A579NgpDelDataHora, P007P8_n579NgpDelDataHora, P007P8_A580NgpDelData, P007P8_n580NgpDelData, P007P8_A581NgpDelHora, P007P8_n581NgpDelHora, P007P8_A582NgpDelUsuId, P007P8_n582NgpDelUsuId, P007P8_A583NgpDelUsuNome,
               P007P8_n583NgpDelUsuNome
               }
               , new Object[] {
               P007P9_A345NegID, P007P9_A435NgpItem, P007P9_A455NgpInsData, P007P9_A456NgpInsHora, P007P9_A457NgpInsDataHora, P007P9_A458NgpInsUsuID, P007P9_n458NgpInsUsuID, P007P9_A459NgpInsUsuNome, P007P9_n459NgpInsUsuNome, P007P9_A478NgpTppID,
               P007P9_A439NgpTppPrdID, P007P9_A440NgpTppPrdCodigo, P007P9_A441NgpTppPrdNome, P007P9_A442NgpTppPrdTipoID, P007P9_A443NgpTppPrdAtivo, P007P9_A444NgpTpp1Preco, P007P9_A445NgpPreco, P007P9_A446NgpQtde, P007P9_A447NgpTotal, P007P9_A453NgpObs,
               P007P9_A578NgpDel, P007P9_A579NgpDelDataHora, P007P9_n579NgpDelDataHora, P007P9_A580NgpDelData, P007P9_n580NgpDelData, P007P9_A581NgpDelHora, P007P9_n581NgpDelHora, P007P9_A582NgpDelUsuId, P007P9_n582NgpDelUsuId, P007P9_A583NgpDelUsuNome,
               P007P9_n583NgpDelUsuNome
               }
               , new Object[] {
               P007P10_A345NegID, P007P10_A435NgpItem, P007P10_A455NgpInsData, P007P10_A456NgpInsHora, P007P10_A457NgpInsDataHora, P007P10_A458NgpInsUsuID, P007P10_n458NgpInsUsuID, P007P10_A459NgpInsUsuNome, P007P10_n459NgpInsUsuNome, P007P10_A478NgpTppID,
               P007P10_A439NgpTppPrdID, P007P10_A440NgpTppPrdCodigo, P007P10_A441NgpTppPrdNome, P007P10_A442NgpTppPrdTipoID, P007P10_A443NgpTppPrdAtivo, P007P10_A444NgpTpp1Preco, P007P10_A445NgpPreco, P007P10_A446NgpQtde, P007P10_A447NgpTotal, P007P10_A453NgpObs,
               P007P10_A578NgpDel, P007P10_A579NgpDelDataHora, P007P10_n579NgpDelDataHora, P007P10_A580NgpDelData, P007P10_n580NgpDelData, P007P10_A581NgpDelHora, P007P10_n581NgpDelHora, P007P10_A582NgpDelUsuId, P007P10_n582NgpDelUsuId, P007P10_A583NgpDelUsuNome,
               P007P10_n583NgpDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A369NegCpjEndSeq ;
      private short A377NegCpjEndUFID ;
      private short AV22CountUpdatedNgpItem ;
      private short AV21CountKeyAttributes ;
      private short AV32GXLvl1314 ;
      private int A357NegPjtID ;
      private int A642NegCpjEndCep ;
      private int A375NegCpjEndMunID ;
      private int A454NegUltItem ;
      private int A435NgpItem ;
      private int A442NgpTppPrdTipoID ;
      private int A446NgpQtde ;
      private int A40000GXC1 ;
      private int AV29GXV1 ;
      private int AV30GXV2 ;
      private int AV31GXV3 ;
      private int AV23KeyNgpItem ;
      private int AV33GXV4 ;
      private int AV35GXV5 ;
      private int AV36GXV6 ;
      private int AV37GXV7 ;
      private long A356NegCodigo ;
      private long A473NegCliMatricula ;
      private long A355NegCpjMatricula ;
      private decimal A380NegValorEstimado ;
      private decimal A385NegValorAtualizado ;
      private decimal A448NegPgpTotal ;
      private decimal A444NgpTpp1Preco ;
      private decimal A445NgpPreco ;
      private decimal A447NgpTotal ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A349NegInsUsuID ;
      private string A360NegAgcID ;
      private string A576NegDelUsuId ;
      private string A458NgpInsUsuID ;
      private string A582NgpDelUsuId ;
      private DateTime A347NegInsHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime A573NegDelDataHora ;
      private DateTime A574NegDelData ;
      private DateTime A575NegDelHora ;
      private DateTime A456NgpInsHora ;
      private DateTime A457NgpInsDataHora ;
      private DateTime A579NgpDelDataHora ;
      private DateTime A580NgpDelData ;
      private DateTime A581NgpDelHora ;
      private DateTime A346NegInsData ;
      private DateTime A455NgpInsData ;
      private bool returnInSub ;
      private bool n349NegInsUsuID ;
      private bool n364NegInsUsuNome ;
      private bool n360NegAgcID ;
      private bool n361NegAgcNome ;
      private bool n454NegUltItem ;
      private bool A572NegDel ;
      private bool n573NegDelDataHora ;
      private bool n574NegDelData ;
      private bool n575NegDelHora ;
      private bool n576NegDelUsuId ;
      private bool n577NegDelUsuNome ;
      private bool n448NegPgpTotal ;
      private bool n373NegCpjEndComplem ;
      private bool n458NgpInsUsuID ;
      private bool n459NgpInsUsuNome ;
      private bool A443NgpTppPrdAtivo ;
      private bool A578NgpDel ;
      private bool n579NgpDelDataHora ;
      private bool n580NgpDelData ;
      private bool n581NgpDelHora ;
      private bool n582NgpDelUsuId ;
      private bool n583NgpDelUsuNome ;
      private bool n40000GXC1 ;
      private bool AV24RecordExistsNgpItem ;
      private string A363NegDescricao ;
      private string A364NegInsUsuNome ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A354NegCpjRazSocial ;
      private string A358NegPjtSigla ;
      private string A359NegPjtNome ;
      private string A370NegCpjEndNome ;
      private string A379NegCpjEndUFNome ;
      private string A361NegAgcNome ;
      private string A362NegAssunto ;
      private string A577NegDelUsuNome ;
      private string A373NegCpjEndComplem ;
      private string A372NegCpjEndNumero ;
      private string A378NegCpjEndUFSigla ;
      private string A376NegCpjEndMunNome ;
      private string A643NegCpjEndCepFormat ;
      private string A374NegCpjEndBairro ;
      private string A371NegCpjEndEndereco ;
      private string A641NegCpjEndCompleto ;
      private string A459NgpInsUsuNome ;
      private string A440NgpTppPrdCodigo ;
      private string A441NgpTppPrdNome ;
      private string A453NgpObs ;
      private string A583NgpDelUsuNome ;
      private Guid AV17NegID ;
      private Guid A345NegID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A478NgpTppID ;
      private Guid A439NgpTppPrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007P3_A345NegID ;
      private long[] P007P3_A356NegCodigo ;
      private DateTime[] P007P3_A346NegInsData ;
      private DateTime[] P007P3_A347NegInsHora ;
      private DateTime[] P007P3_A348NegInsDataHora ;
      private string[] P007P3_A349NegInsUsuID ;
      private bool[] P007P3_n349NegInsUsuID ;
      private string[] P007P3_A364NegInsUsuNome ;
      private bool[] P007P3_n364NegInsUsuNome ;
      private Guid[] P007P3_A350NegCliID ;
      private long[] P007P3_A473NegCliMatricula ;
      private string[] P007P3_A351NegCliNomeFamiliar ;
      private Guid[] P007P3_A352NegCpjID ;
      private string[] P007P3_A353NegCpjNomFan ;
      private string[] P007P3_A354NegCpjRazSocial ;
      private long[] P007P3_A355NegCpjMatricula ;
      private int[] P007P3_A357NegPjtID ;
      private string[] P007P3_A358NegPjtSigla ;
      private string[] P007P3_A359NegPjtNome ;
      private short[] P007P3_A369NegCpjEndSeq ;
      private string[] P007P3_A370NegCpjEndNome ;
      private int[] P007P3_A642NegCpjEndCep ;
      private int[] P007P3_A375NegCpjEndMunID ;
      private short[] P007P3_A377NegCpjEndUFID ;
      private string[] P007P3_A379NegCpjEndUFNome ;
      private string[] P007P3_A360NegAgcID ;
      private bool[] P007P3_n360NegAgcID ;
      private string[] P007P3_A361NegAgcNome ;
      private bool[] P007P3_n361NegAgcNome ;
      private string[] P007P3_A362NegAssunto ;
      private string[] P007P3_A363NegDescricao ;
      private decimal[] P007P3_A380NegValorEstimado ;
      private decimal[] P007P3_A385NegValorAtualizado ;
      private int[] P007P3_A454NegUltItem ;
      private bool[] P007P3_n454NegUltItem ;
      private bool[] P007P3_A572NegDel ;
      private DateTime[] P007P3_A573NegDelDataHora ;
      private bool[] P007P3_n573NegDelDataHora ;
      private DateTime[] P007P3_A574NegDelData ;
      private bool[] P007P3_n574NegDelData ;
      private DateTime[] P007P3_A575NegDelHora ;
      private bool[] P007P3_n575NegDelHora ;
      private string[] P007P3_A576NegDelUsuId ;
      private bool[] P007P3_n576NegDelUsuId ;
      private string[] P007P3_A577NegDelUsuNome ;
      private bool[] P007P3_n577NegDelUsuNome ;
      private decimal[] P007P3_A448NegPgpTotal ;
      private bool[] P007P3_n448NegPgpTotal ;
      private string[] P007P3_A373NegCpjEndComplem ;
      private bool[] P007P3_n373NegCpjEndComplem ;
      private string[] P007P3_A372NegCpjEndNumero ;
      private string[] P007P3_A378NegCpjEndUFSigla ;
      private string[] P007P3_A376NegCpjEndMunNome ;
      private string[] P007P3_A643NegCpjEndCepFormat ;
      private string[] P007P3_A374NegCpjEndBairro ;
      private string[] P007P3_A371NegCpjEndEndereco ;
      private Guid[] P007P4_A345NegID ;
      private int[] P007P4_A435NgpItem ;
      private DateTime[] P007P4_A455NgpInsData ;
      private DateTime[] P007P4_A456NgpInsHora ;
      private DateTime[] P007P4_A457NgpInsDataHora ;
      private string[] P007P4_A458NgpInsUsuID ;
      private bool[] P007P4_n458NgpInsUsuID ;
      private string[] P007P4_A459NgpInsUsuNome ;
      private bool[] P007P4_n459NgpInsUsuNome ;
      private Guid[] P007P4_A478NgpTppID ;
      private Guid[] P007P4_A439NgpTppPrdID ;
      private string[] P007P4_A440NgpTppPrdCodigo ;
      private string[] P007P4_A441NgpTppPrdNome ;
      private int[] P007P4_A442NgpTppPrdTipoID ;
      private bool[] P007P4_A443NgpTppPrdAtivo ;
      private decimal[] P007P4_A444NgpTpp1Preco ;
      private decimal[] P007P4_A445NgpPreco ;
      private int[] P007P4_A446NgpQtde ;
      private decimal[] P007P4_A447NgpTotal ;
      private string[] P007P4_A453NgpObs ;
      private bool[] P007P4_A578NgpDel ;
      private DateTime[] P007P4_A579NgpDelDataHora ;
      private bool[] P007P4_n579NgpDelDataHora ;
      private DateTime[] P007P4_A580NgpDelData ;
      private bool[] P007P4_n580NgpDelData ;
      private DateTime[] P007P4_A581NgpDelHora ;
      private bool[] P007P4_n581NgpDelHora ;
      private string[] P007P4_A582NgpDelUsuId ;
      private bool[] P007P4_n582NgpDelUsuId ;
      private string[] P007P4_A583NgpDelUsuNome ;
      private bool[] P007P4_n583NgpDelUsuNome ;
      private Guid[] P007P7_A345NegID ;
      private long[] P007P7_A356NegCodigo ;
      private DateTime[] P007P7_A346NegInsData ;
      private DateTime[] P007P7_A347NegInsHora ;
      private DateTime[] P007P7_A348NegInsDataHora ;
      private string[] P007P7_A349NegInsUsuID ;
      private bool[] P007P7_n349NegInsUsuID ;
      private string[] P007P7_A364NegInsUsuNome ;
      private bool[] P007P7_n364NegInsUsuNome ;
      private Guid[] P007P7_A350NegCliID ;
      private long[] P007P7_A473NegCliMatricula ;
      private string[] P007P7_A351NegCliNomeFamiliar ;
      private Guid[] P007P7_A352NegCpjID ;
      private string[] P007P7_A353NegCpjNomFan ;
      private string[] P007P7_A354NegCpjRazSocial ;
      private long[] P007P7_A355NegCpjMatricula ;
      private int[] P007P7_A357NegPjtID ;
      private string[] P007P7_A358NegPjtSigla ;
      private string[] P007P7_A359NegPjtNome ;
      private short[] P007P7_A369NegCpjEndSeq ;
      private string[] P007P7_A370NegCpjEndNome ;
      private int[] P007P7_A642NegCpjEndCep ;
      private int[] P007P7_A375NegCpjEndMunID ;
      private short[] P007P7_A377NegCpjEndUFID ;
      private string[] P007P7_A379NegCpjEndUFNome ;
      private string[] P007P7_A360NegAgcID ;
      private bool[] P007P7_n360NegAgcID ;
      private string[] P007P7_A361NegAgcNome ;
      private bool[] P007P7_n361NegAgcNome ;
      private string[] P007P7_A362NegAssunto ;
      private string[] P007P7_A363NegDescricao ;
      private decimal[] P007P7_A380NegValorEstimado ;
      private decimal[] P007P7_A385NegValorAtualizado ;
      private int[] P007P7_A454NegUltItem ;
      private bool[] P007P7_n454NegUltItem ;
      private bool[] P007P7_A572NegDel ;
      private DateTime[] P007P7_A573NegDelDataHora ;
      private bool[] P007P7_n573NegDelDataHora ;
      private DateTime[] P007P7_A574NegDelData ;
      private bool[] P007P7_n574NegDelData ;
      private DateTime[] P007P7_A575NegDelHora ;
      private bool[] P007P7_n575NegDelHora ;
      private string[] P007P7_A576NegDelUsuId ;
      private bool[] P007P7_n576NegDelUsuId ;
      private string[] P007P7_A577NegDelUsuNome ;
      private bool[] P007P7_n577NegDelUsuNome ;
      private decimal[] P007P7_A448NegPgpTotal ;
      private bool[] P007P7_n448NegPgpTotal ;
      private int[] P007P7_A40000GXC1 ;
      private bool[] P007P7_n40000GXC1 ;
      private string[] P007P7_A373NegCpjEndComplem ;
      private bool[] P007P7_n373NegCpjEndComplem ;
      private string[] P007P7_A372NegCpjEndNumero ;
      private string[] P007P7_A378NegCpjEndUFSigla ;
      private string[] P007P7_A376NegCpjEndMunNome ;
      private string[] P007P7_A643NegCpjEndCepFormat ;
      private string[] P007P7_A374NegCpjEndBairro ;
      private string[] P007P7_A371NegCpjEndEndereco ;
      private Guid[] P007P8_A345NegID ;
      private int[] P007P8_A435NgpItem ;
      private DateTime[] P007P8_A455NgpInsData ;
      private DateTime[] P007P8_A456NgpInsHora ;
      private DateTime[] P007P8_A457NgpInsDataHora ;
      private string[] P007P8_A458NgpInsUsuID ;
      private bool[] P007P8_n458NgpInsUsuID ;
      private string[] P007P8_A459NgpInsUsuNome ;
      private bool[] P007P8_n459NgpInsUsuNome ;
      private Guid[] P007P8_A478NgpTppID ;
      private Guid[] P007P8_A439NgpTppPrdID ;
      private string[] P007P8_A440NgpTppPrdCodigo ;
      private string[] P007P8_A441NgpTppPrdNome ;
      private int[] P007P8_A442NgpTppPrdTipoID ;
      private bool[] P007P8_A443NgpTppPrdAtivo ;
      private decimal[] P007P8_A444NgpTpp1Preco ;
      private decimal[] P007P8_A445NgpPreco ;
      private int[] P007P8_A446NgpQtde ;
      private decimal[] P007P8_A447NgpTotal ;
      private string[] P007P8_A453NgpObs ;
      private bool[] P007P8_A578NgpDel ;
      private DateTime[] P007P8_A579NgpDelDataHora ;
      private bool[] P007P8_n579NgpDelDataHora ;
      private DateTime[] P007P8_A580NgpDelData ;
      private bool[] P007P8_n580NgpDelData ;
      private DateTime[] P007P8_A581NgpDelHora ;
      private bool[] P007P8_n581NgpDelHora ;
      private string[] P007P8_A582NgpDelUsuId ;
      private bool[] P007P8_n582NgpDelUsuId ;
      private string[] P007P8_A583NgpDelUsuNome ;
      private bool[] P007P8_n583NgpDelUsuNome ;
      private Guid[] P007P9_A345NegID ;
      private int[] P007P9_A435NgpItem ;
      private DateTime[] P007P9_A455NgpInsData ;
      private DateTime[] P007P9_A456NgpInsHora ;
      private DateTime[] P007P9_A457NgpInsDataHora ;
      private string[] P007P9_A458NgpInsUsuID ;
      private bool[] P007P9_n458NgpInsUsuID ;
      private string[] P007P9_A459NgpInsUsuNome ;
      private bool[] P007P9_n459NgpInsUsuNome ;
      private Guid[] P007P9_A478NgpTppID ;
      private Guid[] P007P9_A439NgpTppPrdID ;
      private string[] P007P9_A440NgpTppPrdCodigo ;
      private string[] P007P9_A441NgpTppPrdNome ;
      private int[] P007P9_A442NgpTppPrdTipoID ;
      private bool[] P007P9_A443NgpTppPrdAtivo ;
      private decimal[] P007P9_A444NgpTpp1Preco ;
      private decimal[] P007P9_A445NgpPreco ;
      private int[] P007P9_A446NgpQtde ;
      private decimal[] P007P9_A447NgpTotal ;
      private string[] P007P9_A453NgpObs ;
      private bool[] P007P9_A578NgpDel ;
      private DateTime[] P007P9_A579NgpDelDataHora ;
      private bool[] P007P9_n579NgpDelDataHora ;
      private DateTime[] P007P9_A580NgpDelData ;
      private bool[] P007P9_n580NgpDelData ;
      private DateTime[] P007P9_A581NgpDelHora ;
      private bool[] P007P9_n581NgpDelHora ;
      private string[] P007P9_A582NgpDelUsuId ;
      private bool[] P007P9_n582NgpDelUsuId ;
      private string[] P007P9_A583NgpDelUsuNome ;
      private bool[] P007P9_n583NgpDelUsuNome ;
      private Guid[] P007P10_A345NegID ;
      private int[] P007P10_A435NgpItem ;
      private DateTime[] P007P10_A455NgpInsData ;
      private DateTime[] P007P10_A456NgpInsHora ;
      private DateTime[] P007P10_A457NgpInsDataHora ;
      private string[] P007P10_A458NgpInsUsuID ;
      private bool[] P007P10_n458NgpInsUsuID ;
      private string[] P007P10_A459NgpInsUsuNome ;
      private bool[] P007P10_n459NgpInsUsuNome ;
      private Guid[] P007P10_A478NgpTppID ;
      private Guid[] P007P10_A439NgpTppPrdID ;
      private string[] P007P10_A440NgpTppPrdCodigo ;
      private string[] P007P10_A441NgpTppPrdNome ;
      private int[] P007P10_A442NgpTppPrdTipoID ;
      private bool[] P007P10_A443NgpTppPrdAtivo ;
      private decimal[] P007P10_A444NgpTpp1Preco ;
      private decimal[] P007P10_A445NgpPreco ;
      private int[] P007P10_A446NgpQtde ;
      private decimal[] P007P10_A447NgpTotal ;
      private string[] P007P10_A453NgpObs ;
      private bool[] P007P10_A578NgpDel ;
      private DateTime[] P007P10_A579NgpDelDataHora ;
      private bool[] P007P10_n579NgpDelDataHora ;
      private DateTime[] P007P10_A580NgpDelData ;
      private bool[] P007P10_n580NgpDelData ;
      private DateTime[] P007P10_A581NgpDelHora ;
      private bool[] P007P10_n581NgpDelHora ;
      private string[] P007P10_A582NgpDelUsuId ;
      private bool[] P007P10_n582NgpDelUsuId ;
      private string[] P007P10_A583NgpDelUsuNome ;
      private bool[] P007P10_n583NgpDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV18AuditingObjectNewRecords ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV19AuditingObjectRecordItemNew ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV20AuditingObjectRecordItemAttributeItemNew ;
   }

   public class loadauditnegociopj__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007P3;
          prmP007P3 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007P4;
          prmP007P4 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007P7;
          prmP007P7 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          string cmdBufferP007P7;
          cmdBufferP007P7=" SELECT T1.NegID, T1.NegCodigo, T1.NegInsData, T1.NegInsHora, T1.NegInsDataHora, T1.NegInsUsuID, T1.NegInsUsuNome, T1.NegCliID AS NegCliID, T3.CliMatricula AS NegCliMatricula, T1.NegCliNomeFamiliar AS NegCliNomeFamiliar, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T4.CpjTipoId AS NegPjtID, T5.PjtSigla AS NegPjtSigla, T1.NegPjtNome AS NegPjtNome, T1.NegCpjEndSeq AS NegCpjEndSeq, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndCep AS NegCpjEndCep, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFNome AS NegCpjEndUFNome, T1.NegAgcID, T1.NegAgcNome, T1.NegAssunto, T1.NegDescricao, T1.NegValorEstimado, T1.NegValorAtualizado, T1.NegUltItem, T1.NegDel, T1.NegDelDataHora, T1.NegDelData, T1.NegDelHora, T1.NegDelUsuId, T1.NegDelUsuNome, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal, COALESCE( T7.GXC1, 0) AS GXC1, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndCepFormat AS NegCpjEndCepFormat, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndEndereco AS NegCpjEndEndereco FROM (((((tb_negociopj T1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE T1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = T1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = T1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = T1.NegCliID AND T4.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = T1.NegCliID AND T6.CpjID = T1.NegCpjID AND T6.CpjEndSeq = T1.NegCpjEndSeq),  (SELECT COUNT(*) AS GXC1 FROM tb_negociopj_item WHERE NegID = :AV17NegID ) T7 WHERE T1.NegID = :AV17NegID ORDER BY "
          + " T1.NegID" ;
          Object[] prmP007P8;
          prmP007P8 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007P9;
          prmP007P9 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV23KeyNgpItem",GXType.Int32,8,0)
          };
          Object[] prmP007P10;
          prmP007P10 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007P3", "SELECT T1.NegID, T1.NegCodigo, T1.NegInsData, T1.NegInsHora, T1.NegInsDataHora, T1.NegInsUsuID, T1.NegInsUsuNome, T1.NegCliID AS NegCliID, T3.CliMatricula AS NegCliMatricula, T1.NegCliNomeFamiliar AS NegCliNomeFamiliar, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T4.CpjTipoId AS NegPjtID, T5.PjtSigla AS NegPjtSigla, T1.NegPjtNome AS NegPjtNome, T1.NegCpjEndSeq AS NegCpjEndSeq, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndCep AS NegCpjEndCep, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFNome AS NegCpjEndUFNome, T1.NegAgcID, T1.NegAgcNome, T1.NegAssunto, T1.NegDescricao, T1.NegValorEstimado, T1.NegValorAtualizado, T1.NegUltItem, T1.NegDel, T1.NegDelDataHora, T1.NegDelData, T1.NegDelHora, T1.NegDelUsuId, T1.NegDelUsuNome, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndCepFormat AS NegCpjEndCepFormat, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndEndereco AS NegCpjEndEndereco FROM (((((tb_negociopj T1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE T1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = T1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = T1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = T1.NegCliID AND T4.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = T1.NegCliID AND T6.CpjID = T1.NegCpjID AND T6.CpjEndSeq = T1.NegCpjEndSeq) WHERE T1.NegID = :AV17NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007P4", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007P7", cmdBufferP007P7,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007P8", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007P9", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID and T1.NgpItem = :AV23KeyNgpItem ORDER BY T1.NegID, T1.NgpItem ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007P10", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :AV17NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007P10,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((string[]) buf[17])[0] = rslt.getVarchar(16);
                ((string[]) buf[18])[0] = rslt.getVarchar(17);
                ((short[]) buf[19])[0] = rslt.getShort(18);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((int[]) buf[21])[0] = rslt.getInt(20);
                ((int[]) buf[22])[0] = rslt.getInt(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getString(24, 40);
                ((bool[]) buf[26])[0] = rslt.wasNull(24);
                ((string[]) buf[27])[0] = rslt.getVarchar(25);
                ((bool[]) buf[28])[0] = rslt.wasNull(25);
                ((string[]) buf[29])[0] = rslt.getVarchar(26);
                ((string[]) buf[30])[0] = rslt.getLongVarchar(27);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(29);
                ((int[]) buf[33])[0] = rslt.getInt(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((bool[]) buf[35])[0] = rslt.getBool(31);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(32, true);
                ((bool[]) buf[37])[0] = rslt.wasNull(32);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(33);
                ((bool[]) buf[39])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(34);
                ((bool[]) buf[41])[0] = rslt.wasNull(34);
                ((string[]) buf[42])[0] = rslt.getString(35, 40);
                ((bool[]) buf[43])[0] = rslt.wasNull(35);
                ((string[]) buf[44])[0] = rslt.getVarchar(36);
                ((bool[]) buf[45])[0] = rslt.wasNull(36);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(37);
                ((bool[]) buf[47])[0] = rslt.wasNull(37);
                ((string[]) buf[48])[0] = rslt.getVarchar(38);
                ((bool[]) buf[49])[0] = rslt.wasNull(38);
                ((string[]) buf[50])[0] = rslt.getVarchar(39);
                ((string[]) buf[51])[0] = rslt.getVarchar(40);
                ((string[]) buf[52])[0] = rslt.getVarchar(41);
                ((string[]) buf[53])[0] = rslt.getVarchar(42);
                ((string[]) buf[54])[0] = rslt.getVarchar(43);
                ((string[]) buf[55])[0] = rslt.getVarchar(44);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((bool[]) buf[20])[0] = rslt.getBool(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(20, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(23);
                ((string[]) buf[29])[0] = rslt.getVarchar(24);
                ((bool[]) buf[30])[0] = rslt.wasNull(24);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((int[]) buf[16])[0] = rslt.getInt(15);
                ((string[]) buf[17])[0] = rslt.getVarchar(16);
                ((string[]) buf[18])[0] = rslt.getVarchar(17);
                ((short[]) buf[19])[0] = rslt.getShort(18);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((int[]) buf[21])[0] = rslt.getInt(20);
                ((int[]) buf[22])[0] = rslt.getInt(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getString(24, 40);
                ((bool[]) buf[26])[0] = rslt.wasNull(24);
                ((string[]) buf[27])[0] = rslt.getVarchar(25);
                ((bool[]) buf[28])[0] = rslt.wasNull(25);
                ((string[]) buf[29])[0] = rslt.getVarchar(26);
                ((string[]) buf[30])[0] = rslt.getLongVarchar(27);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(29);
                ((int[]) buf[33])[0] = rslt.getInt(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((bool[]) buf[35])[0] = rslt.getBool(31);
                ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(32, true);
                ((bool[]) buf[37])[0] = rslt.wasNull(32);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(33);
                ((bool[]) buf[39])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(34);
                ((bool[]) buf[41])[0] = rslt.wasNull(34);
                ((string[]) buf[42])[0] = rslt.getString(35, 40);
                ((bool[]) buf[43])[0] = rslt.wasNull(35);
                ((string[]) buf[44])[0] = rslt.getVarchar(36);
                ((bool[]) buf[45])[0] = rslt.wasNull(36);
                ((decimal[]) buf[46])[0] = rslt.getDecimal(37);
                ((bool[]) buf[47])[0] = rslt.wasNull(37);
                ((int[]) buf[48])[0] = rslt.getInt(38);
                ((bool[]) buf[49])[0] = rslt.wasNull(38);
                ((string[]) buf[50])[0] = rslt.getVarchar(39);
                ((bool[]) buf[51])[0] = rslt.wasNull(39);
                ((string[]) buf[52])[0] = rslt.getVarchar(40);
                ((string[]) buf[53])[0] = rslt.getVarchar(41);
                ((string[]) buf[54])[0] = rslt.getVarchar(42);
                ((string[]) buf[55])[0] = rslt.getVarchar(43);
                ((string[]) buf[56])[0] = rslt.getVarchar(44);
                ((string[]) buf[57])[0] = rslt.getVarchar(45);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((bool[]) buf[20])[0] = rslt.getBool(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(20, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(23);
                ((string[]) buf[29])[0] = rslt.getVarchar(24);
                ((bool[]) buf[30])[0] = rslt.wasNull(24);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((bool[]) buf[20])[0] = rslt.getBool(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(20, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(23);
                ((string[]) buf[29])[0] = rslt.getVarchar(24);
                ((bool[]) buf[30])[0] = rslt.wasNull(24);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((Guid[]) buf[9])[0] = rslt.getGuid(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((bool[]) buf[20])[0] = rslt.getBool(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(20, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[24])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[26])[0] = rslt.wasNull(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(23);
                ((string[]) buf[29])[0] = rslt.getVarchar(24);
                ((bool[]) buf[30])[0] = rslt.wasNull(24);
                return;
       }
    }

 }

}
