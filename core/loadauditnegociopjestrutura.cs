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
   public class loadauditnegociopjestrutura : GXProcedure
   {
      public loadauditnegociopjestrutura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditnegociopjestrutura( IGxContext context )
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
         loadauditnegociopjestrutura objloadauditnegociopjestrutura;
         objloadauditnegociopjestrutura = new loadauditnegociopjestrutura();
         objloadauditnegociopjestrutura.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditnegociopjestrutura.AV11AuditingObject = aP1_AuditingObject;
         objloadauditnegociopjestrutura.AV17NegID = aP2_NegID;
         objloadauditnegociopjestrutura.AV15ActualMode = aP3_ActualMode;
         objloadauditnegociopjestrutura.context.SetSubmitInitialConfig(context);
         objloadauditnegociopjestrutura.initialize();
         Submit( executePrivateCatch,objloadauditnegociopjestrutura);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditnegociopjestrutura)stateInfo).executePrivate();
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
         /* Using cursor P007Q3 */
         pr_default.execute(0, new Object[] {AV17NegID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A345NegID = P007Q3_A345NegID[0];
            A356NegCodigo = P007Q3_A356NegCodigo[0];
            A346NegInsData = P007Q3_A346NegInsData[0];
            A347NegInsHora = P007Q3_A347NegInsHora[0];
            A348NegInsDataHora = P007Q3_A348NegInsDataHora[0];
            A349NegInsUsuID = P007Q3_A349NegInsUsuID[0];
            n349NegInsUsuID = P007Q3_n349NegInsUsuID[0];
            A364NegInsUsuNome = P007Q3_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P007Q3_n364NegInsUsuNome[0];
            A350NegCliID = P007Q3_A350NegCliID[0];
            A473NegCliMatricula = P007Q3_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = P007Q3_A351NegCliNomeFamiliar[0];
            A352NegCpjID = P007Q3_A352NegCpjID[0];
            A353NegCpjNomFan = P007Q3_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = P007Q3_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = P007Q3_A355NegCpjMatricula[0];
            A357NegPjtID = P007Q3_A357NegPjtID[0];
            A358NegPjtSigla = P007Q3_A358NegPjtSigla[0];
            A359NegPjtNome = P007Q3_A359NegPjtNome[0];
            A369NegCpjEndSeq = P007Q3_A369NegCpjEndSeq[0];
            A370NegCpjEndNome = P007Q3_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = P007Q3_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = P007Q3_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = P007Q3_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007Q3_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = P007Q3_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = P007Q3_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = P007Q3_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = P007Q3_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = P007Q3_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = P007Q3_A379NegCpjEndUFNome[0];
            A360NegAgcID = P007Q3_A360NegAgcID[0];
            n360NegAgcID = P007Q3_n360NegAgcID[0];
            A361NegAgcNome = P007Q3_A361NegAgcNome[0];
            n361NegAgcNome = P007Q3_n361NegAgcNome[0];
            A362NegAssunto = P007Q3_A362NegAssunto[0];
            A363NegDescricao = P007Q3_A363NegDescricao[0];
            A386NegUltFase = P007Q3_A386NegUltFase[0];
            A474NegUltNgfSeq = P007Q3_A474NegUltNgfSeq[0];
            A420NegUltIteID = P007Q3_A420NegUltIteID[0];
            A421NegUltIteNome = P007Q3_A421NegUltIteNome[0];
            A479NegUltIteOrdem = P007Q3_A479NegUltIteOrdem[0];
            A380NegValorEstimado = P007Q3_A380NegValorEstimado[0];
            A385NegValorAtualizado = P007Q3_A385NegValorAtualizado[0];
            A454NegUltItem = P007Q3_A454NegUltItem[0];
            n454NegUltItem = P007Q3_n454NegUltItem[0];
            A572NegDel = P007Q3_A572NegDel[0];
            A573NegDelDataHora = P007Q3_A573NegDelDataHora[0];
            n573NegDelDataHora = P007Q3_n573NegDelDataHora[0];
            A574NegDelData = P007Q3_A574NegDelData[0];
            n574NegDelData = P007Q3_n574NegDelData[0];
            A575NegDelHora = P007Q3_A575NegDelHora[0];
            n575NegDelHora = P007Q3_n575NegDelHora[0];
            A576NegDelUsuId = P007Q3_A576NegDelUsuId[0];
            n576NegDelUsuId = P007Q3_n576NegDelUsuId[0];
            A577NegDelUsuNome = P007Q3_A577NegDelUsuNome[0];
            n577NegDelUsuNome = P007Q3_n577NegDelUsuNome[0];
            A448NegPgpTotal = P007Q3_A448NegPgpTotal[0];
            n448NegPgpTotal = P007Q3_n448NegPgpTotal[0];
            A448NegPgpTotal = P007Q3_A448NegPgpTotal[0];
            n448NegPgpTotal = P007Q3_n448NegPgpTotal[0];
            A473NegCliMatricula = P007Q3_A473NegCliMatricula[0];
            A355NegCpjMatricula = P007Q3_A355NegCpjMatricula[0];
            A357NegPjtID = P007Q3_A357NegPjtID[0];
            A358NegPjtSigla = P007Q3_A358NegPjtSigla[0];
            A370NegCpjEndNome = P007Q3_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = P007Q3_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = P007Q3_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = P007Q3_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007Q3_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = P007Q3_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = P007Q3_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = P007Q3_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = P007Q3_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = P007Q3_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = P007Q3_A379NegCpjEndUFNome[0];
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A346NegInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído às";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A349NegInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A364NegInsUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente ID";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A357NegPjtID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A358NegPjtSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A359NegPjtNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A369NegCpjEndSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A375NegCpjEndMunID), 7, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A376NegCpjEndMunNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A377NegCpjEndUFID), 2, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A378NegCpjEndUFSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A379NegCpjEndUFNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Agente Comercial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A360NegAgcID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Agente Comercial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A361NegAgcNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAssunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltFase";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Fase";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A386NegUltFase), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltNgfSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Fase";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A474NegUltNgfSeq), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltIteID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Iteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A420NegUltIteID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltIteNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Iteração Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A421NegUltIteNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltIteOrdem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Iteração Ordem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A479NegUltIteOrdem), 4, 0);
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "em Negócios";
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
            /* Using cursor P007Q4 */
            pr_default.execute(1, new Object[] {A345NegID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A387NgfSeq = P007Q4_A387NgfSeq[0];
               A388NgfInsData = P007Q4_A388NgfInsData[0];
               A389NgfInsHora = P007Q4_A389NgfInsHora[0];
               A390NgfInsDataHora = P007Q4_A390NgfInsDataHora[0];
               A391NgfInsUsuID = P007Q4_A391NgfInsUsuID[0];
               n391NgfInsUsuID = P007Q4_n391NgfInsUsuID[0];
               A392NgfInsUsuNome = P007Q4_A392NgfInsUsuNome[0];
               n392NgfInsUsuNome = P007Q4_n392NgfInsUsuNome[0];
               A395NgfIteID = P007Q4_A395NgfIteID[0];
               A396NgfIteOrdem = P007Q4_A396NgfIteOrdem[0];
               A397NgfIteNome = P007Q4_A397NgfIteNome[0];
               A425NgfFimData = P007Q4_A425NgfFimData[0];
               n425NgfFimData = P007Q4_n425NgfFimData[0];
               A426NgfFimHora = P007Q4_A426NgfFimHora[0];
               n426NgfFimHora = P007Q4_n426NgfFimHora[0];
               A427NgfFimDataHora = P007Q4_A427NgfFimDataHora[0];
               n427NgfFimDataHora = P007Q4_n427NgfFimDataHora[0];
               A428NgfFimUsuID = P007Q4_A428NgfFimUsuID[0];
               n428NgfFimUsuID = P007Q4_n428NgfFimUsuID[0];
               A429NgfFimUsuNome = P007Q4_A429NgfFimUsuNome[0];
               n429NgfFimUsuNome = P007Q4_n429NgfFimUsuNome[0];
               A430NgfStatus = P007Q4_A430NgfStatus[0];
               n430NgfStatus = P007Q4_n430NgfStatus[0];
               A584NgfDel = P007Q4_A584NgfDel[0];
               A585NgfDelDataHora = P007Q4_A585NgfDelDataHora[0];
               n585NgfDelDataHora = P007Q4_n585NgfDelDataHora[0];
               A586NgfDelData = P007Q4_A586NgfDelData[0];
               n586NgfDelData = P007Q4_n586NgfDelData[0];
               A587NgfDelHora = P007Q4_A587NgfDelHora[0];
               n587NgfDelHora = P007Q4_n587NgfDelHora[0];
               A588NgfDelUsuId = P007Q4_A588NgfDelUsuId[0];
               n588NgfDelUsuId = P007Q4_n588NgfDelUsuId[0];
               A589NgfDelUsuNome = P007Q4_A589NgfDelUsuNome[0];
               n589NgfDelUsuNome = P007Q4_n589NgfDelUsuNome[0];
               A396NgfIteOrdem = P007Q4_A396NgfIteOrdem[0];
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj_fase";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A387NgfSeq), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A388NgfInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A389NgfInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A390NgfInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A391NgfInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A392NgfInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfIteID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Iteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A395NgfIteID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfIteOrdem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ordem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A396NgfIteOrdem), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfIteNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Itinerário";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A397NgfIteNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A425NgfFimData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A426NgfFimHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A427NgfFimDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A428NgfFimUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A429NgfFimUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfStatus";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Situação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A430NgfStatus;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A584NgfDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A585NgfDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A586NgfDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A587NgfDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A588NgfDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A589NgfDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P007Q5 */
            pr_default.execute(2, new Object[] {A345NegID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A435NgpItem = P007Q5_A435NgpItem[0];
               A455NgpInsData = P007Q5_A455NgpInsData[0];
               A456NgpInsHora = P007Q5_A456NgpInsHora[0];
               A457NgpInsDataHora = P007Q5_A457NgpInsDataHora[0];
               A458NgpInsUsuID = P007Q5_A458NgpInsUsuID[0];
               n458NgpInsUsuID = P007Q5_n458NgpInsUsuID[0];
               A459NgpInsUsuNome = P007Q5_A459NgpInsUsuNome[0];
               n459NgpInsUsuNome = P007Q5_n459NgpInsUsuNome[0];
               A478NgpTppID = P007Q5_A478NgpTppID[0];
               A439NgpTppPrdID = P007Q5_A439NgpTppPrdID[0];
               A440NgpTppPrdCodigo = P007Q5_A440NgpTppPrdCodigo[0];
               A441NgpTppPrdNome = P007Q5_A441NgpTppPrdNome[0];
               A442NgpTppPrdTipoID = P007Q5_A442NgpTppPrdTipoID[0];
               A443NgpTppPrdAtivo = P007Q5_A443NgpTppPrdAtivo[0];
               A444NgpTpp1Preco = P007Q5_A444NgpTpp1Preco[0];
               A445NgpPreco = P007Q5_A445NgpPreco[0];
               A446NgpQtde = P007Q5_A446NgpQtde[0];
               A447NgpTotal = P007Q5_A447NgpTotal[0];
               A453NgpObs = P007Q5_A453NgpObs[0];
               A578NgpDel = P007Q5_A578NgpDel[0];
               A579NgpDelDataHora = P007Q5_A579NgpDelDataHora[0];
               n579NgpDelDataHora = P007Q5_n579NgpDelDataHora[0];
               A580NgpDelData = P007Q5_A580NgpDelData[0];
               n580NgpDelData = P007Q5_n580NgpDelData[0];
               A581NgpDelHora = P007Q5_A581NgpDelHora[0];
               n581NgpDelHora = P007Q5_n581NgpDelHora[0];
               A582NgpDelUsuId = P007Q5_A582NgpDelUsuId[0];
               n582NgpDelUsuId = P007Q5_n582NgpDelUsuId[0];
               A583NgpDelUsuNome = P007Q5_A583NgpDelUsuNome[0];
               n583NgpDelUsuNome = P007Q5_n583NgpDelUsuNome[0];
               A440NgpTppPrdCodigo = P007Q5_A440NgpTppPrdCodigo[0];
               A441NgpTppPrdNome = P007Q5_A441NgpTppPrdNome[0];
               A442NgpTppPrdTipoID = P007Q5_A442NgpTppPrdTipoID[0];
               A443NgpTppPrdAtivo = P007Q5_A443NgpTppPrdAtivo[0];
               A444NgpTpp1Preco = P007Q5_A444NgpTpp1Preco[0];
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tabela de Preço ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A478NgpTppID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto ID";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A441NgpTppPrdNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto/Serviço";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço na Tabela";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Quantidade";
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
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007Q9 */
         pr_default.execute(3, new Object[] {AV17NegID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A345NegID = P007Q9_A345NegID[0];
            A356NegCodigo = P007Q9_A356NegCodigo[0];
            A346NegInsData = P007Q9_A346NegInsData[0];
            A347NegInsHora = P007Q9_A347NegInsHora[0];
            A348NegInsDataHora = P007Q9_A348NegInsDataHora[0];
            A349NegInsUsuID = P007Q9_A349NegInsUsuID[0];
            n349NegInsUsuID = P007Q9_n349NegInsUsuID[0];
            A364NegInsUsuNome = P007Q9_A364NegInsUsuNome[0];
            n364NegInsUsuNome = P007Q9_n364NegInsUsuNome[0];
            A350NegCliID = P007Q9_A350NegCliID[0];
            A473NegCliMatricula = P007Q9_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = P007Q9_A351NegCliNomeFamiliar[0];
            A352NegCpjID = P007Q9_A352NegCpjID[0];
            A353NegCpjNomFan = P007Q9_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = P007Q9_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = P007Q9_A355NegCpjMatricula[0];
            A357NegPjtID = P007Q9_A357NegPjtID[0];
            A358NegPjtSigla = P007Q9_A358NegPjtSigla[0];
            A359NegPjtNome = P007Q9_A359NegPjtNome[0];
            A369NegCpjEndSeq = P007Q9_A369NegCpjEndSeq[0];
            A370NegCpjEndNome = P007Q9_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = P007Q9_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = P007Q9_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = P007Q9_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007Q9_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = P007Q9_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = P007Q9_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = P007Q9_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = P007Q9_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = P007Q9_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = P007Q9_A379NegCpjEndUFNome[0];
            A360NegAgcID = P007Q9_A360NegAgcID[0];
            n360NegAgcID = P007Q9_n360NegAgcID[0];
            A361NegAgcNome = P007Q9_A361NegAgcNome[0];
            n361NegAgcNome = P007Q9_n361NegAgcNome[0];
            A362NegAssunto = P007Q9_A362NegAssunto[0];
            A363NegDescricao = P007Q9_A363NegDescricao[0];
            A386NegUltFase = P007Q9_A386NegUltFase[0];
            A474NegUltNgfSeq = P007Q9_A474NegUltNgfSeq[0];
            A420NegUltIteID = P007Q9_A420NegUltIteID[0];
            A421NegUltIteNome = P007Q9_A421NegUltIteNome[0];
            A479NegUltIteOrdem = P007Q9_A479NegUltIteOrdem[0];
            A380NegValorEstimado = P007Q9_A380NegValorEstimado[0];
            A385NegValorAtualizado = P007Q9_A385NegValorAtualizado[0];
            A454NegUltItem = P007Q9_A454NegUltItem[0];
            n454NegUltItem = P007Q9_n454NegUltItem[0];
            A572NegDel = P007Q9_A572NegDel[0];
            A573NegDelDataHora = P007Q9_A573NegDelDataHora[0];
            n573NegDelDataHora = P007Q9_n573NegDelDataHora[0];
            A574NegDelData = P007Q9_A574NegDelData[0];
            n574NegDelData = P007Q9_n574NegDelData[0];
            A575NegDelHora = P007Q9_A575NegDelHora[0];
            n575NegDelHora = P007Q9_n575NegDelHora[0];
            A576NegDelUsuId = P007Q9_A576NegDelUsuId[0];
            n576NegDelUsuId = P007Q9_n576NegDelUsuId[0];
            A577NegDelUsuNome = P007Q9_A577NegDelUsuNome[0];
            n577NegDelUsuNome = P007Q9_n577NegDelUsuNome[0];
            A448NegPgpTotal = P007Q9_A448NegPgpTotal[0];
            n448NegPgpTotal = P007Q9_n448NegPgpTotal[0];
            A40000GXC1 = P007Q9_A40000GXC1[0];
            n40000GXC1 = P007Q9_n40000GXC1[0];
            A40001GXC2 = P007Q9_A40001GXC2[0];
            n40001GXC2 = P007Q9_n40001GXC2[0];
            A448NegPgpTotal = P007Q9_A448NegPgpTotal[0];
            n448NegPgpTotal = P007Q9_n448NegPgpTotal[0];
            A473NegCliMatricula = P007Q9_A473NegCliMatricula[0];
            A355NegCpjMatricula = P007Q9_A355NegCpjMatricula[0];
            A357NegPjtID = P007Q9_A357NegPjtID[0];
            A358NegPjtSigla = P007Q9_A358NegPjtSigla[0];
            A370NegCpjEndNome = P007Q9_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = P007Q9_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = P007Q9_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = P007Q9_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = P007Q9_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = P007Q9_A374NegCpjEndBairro[0];
            A375NegCpjEndMunID = P007Q9_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = P007Q9_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = P007Q9_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = P007Q9_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = P007Q9_A379NegCpjEndUFNome[0];
            A40000GXC1 = P007Q9_A40000GXC1[0];
            n40000GXC1 = P007Q9_n40000GXC1[0];
            A40001GXC2 = P007Q9_A40001GXC2[0];
            n40001GXC2 = P007Q9_n40001GXC2[0];
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A346NegInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído às";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A349NegInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A364NegInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCliID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente ID";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A357NegPjtID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A358NegPjtSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegPjtNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A359NegPjtNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A369NegCpjEndSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A375NegCpjEndMunID), 7, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndMunNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A376NegCpjEndMunNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A377NegCpjEndUFID), 2, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A378NegCpjEndUFSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegCpjEndUFNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A379NegCpjEndUFNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Agente Comercial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A360NegAgcID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAgcNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Agente Comercial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A361NegAgcNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegAssunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltFase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A386NegUltFase), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltNgfSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A474NegUltNgfSeq), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltIteID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Iteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A420NegUltIteID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltIteNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Iteração Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A421NegUltIteNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NegUltIteOrdem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Última Iteração Ordem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A479NegUltIteOrdem), 4, 0);
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "em Negócios";
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
               /* Using cursor P007Q10 */
               pr_default.execute(4, new Object[] {A345NegID});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A387NgfSeq = P007Q10_A387NgfSeq[0];
                  A388NgfInsData = P007Q10_A388NgfInsData[0];
                  A389NgfInsHora = P007Q10_A389NgfInsHora[0];
                  A390NgfInsDataHora = P007Q10_A390NgfInsDataHora[0];
                  A391NgfInsUsuID = P007Q10_A391NgfInsUsuID[0];
                  n391NgfInsUsuID = P007Q10_n391NgfInsUsuID[0];
                  A392NgfInsUsuNome = P007Q10_A392NgfInsUsuNome[0];
                  n392NgfInsUsuNome = P007Q10_n392NgfInsUsuNome[0];
                  A395NgfIteID = P007Q10_A395NgfIteID[0];
                  A396NgfIteOrdem = P007Q10_A396NgfIteOrdem[0];
                  A397NgfIteNome = P007Q10_A397NgfIteNome[0];
                  A425NgfFimData = P007Q10_A425NgfFimData[0];
                  n425NgfFimData = P007Q10_n425NgfFimData[0];
                  A426NgfFimHora = P007Q10_A426NgfFimHora[0];
                  n426NgfFimHora = P007Q10_n426NgfFimHora[0];
                  A427NgfFimDataHora = P007Q10_A427NgfFimDataHora[0];
                  n427NgfFimDataHora = P007Q10_n427NgfFimDataHora[0];
                  A428NgfFimUsuID = P007Q10_A428NgfFimUsuID[0];
                  n428NgfFimUsuID = P007Q10_n428NgfFimUsuID[0];
                  A429NgfFimUsuNome = P007Q10_A429NgfFimUsuNome[0];
                  n429NgfFimUsuNome = P007Q10_n429NgfFimUsuNome[0];
                  A430NgfStatus = P007Q10_A430NgfStatus[0];
                  n430NgfStatus = P007Q10_n430NgfStatus[0];
                  A584NgfDel = P007Q10_A584NgfDel[0];
                  A585NgfDelDataHora = P007Q10_A585NgfDelDataHora[0];
                  n585NgfDelDataHora = P007Q10_n585NgfDelDataHora[0];
                  A586NgfDelData = P007Q10_A586NgfDelData[0];
                  n586NgfDelData = P007Q10_n586NgfDelData[0];
                  A587NgfDelHora = P007Q10_A587NgfDelHora[0];
                  n587NgfDelHora = P007Q10_n587NgfDelHora[0];
                  A588NgfDelUsuId = P007Q10_A588NgfDelUsuId[0];
                  n588NgfDelUsuId = P007Q10_n588NgfDelUsuId[0];
                  A589NgfDelUsuNome = P007Q10_A589NgfDelUsuNome[0];
                  n589NgfDelUsuNome = P007Q10_n589NgfDelUsuNome[0];
                  A396NgfIteOrdem = P007Q10_A396NgfIteOrdem[0];
                  AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                  AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_negociopj_fase";
                  AV12AuditingObjectRecordItem.gxTpr_Mode = "INS";
                  AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfSeq";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A387NgfSeq), 8, 0);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A388NgfInsData, 2, "/");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A389NgfInsHora, 0, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A390NgfInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsUsuID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A391NgfInsUsuID;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfInsUsuNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A392NgfInsUsuNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfIteID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Iteração";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A395NgfIteID.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfIteOrdem";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ordem";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A396NgfIteOrdem), 8, 0);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfIteNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Itinerário";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A397NgfIteNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A425NgfFimData, 2, "/");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A426NgfFimHora, 0, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A427NgfFimDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimUsuID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A428NgfFimUsuID;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfFimUsuNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "da Fase";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A429NgfFimUsuNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfStatus";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Situação";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A430NgfStatus;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDel";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A584NgfDel);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A585NgfDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A586NgfDelData, 10, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A587NgfDelHora, 0, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelUsuId";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A588NgfDelUsuId;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgfDelUsuNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A589NgfDelUsuNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  pr_default.readNext(4);
               }
               pr_default.close(4);
               /* Using cursor P007Q11 */
               pr_default.execute(5, new Object[] {A345NegID});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A435NgpItem = P007Q11_A435NgpItem[0];
                  A455NgpInsData = P007Q11_A455NgpInsData[0];
                  A456NgpInsHora = P007Q11_A456NgpInsHora[0];
                  A457NgpInsDataHora = P007Q11_A457NgpInsDataHora[0];
                  A458NgpInsUsuID = P007Q11_A458NgpInsUsuID[0];
                  n458NgpInsUsuID = P007Q11_n458NgpInsUsuID[0];
                  A459NgpInsUsuNome = P007Q11_A459NgpInsUsuNome[0];
                  n459NgpInsUsuNome = P007Q11_n459NgpInsUsuNome[0];
                  A478NgpTppID = P007Q11_A478NgpTppID[0];
                  A439NgpTppPrdID = P007Q11_A439NgpTppPrdID[0];
                  A440NgpTppPrdCodigo = P007Q11_A440NgpTppPrdCodigo[0];
                  A441NgpTppPrdNome = P007Q11_A441NgpTppPrdNome[0];
                  A442NgpTppPrdTipoID = P007Q11_A442NgpTppPrdTipoID[0];
                  A443NgpTppPrdAtivo = P007Q11_A443NgpTppPrdAtivo[0];
                  A444NgpTpp1Preco = P007Q11_A444NgpTpp1Preco[0];
                  A445NgpPreco = P007Q11_A445NgpPreco[0];
                  A446NgpQtde = P007Q11_A446NgpQtde[0];
                  A447NgpTotal = P007Q11_A447NgpTotal[0];
                  A453NgpObs = P007Q11_A453NgpObs[0];
                  A578NgpDel = P007Q11_A578NgpDel[0];
                  A579NgpDelDataHora = P007Q11_A579NgpDelDataHora[0];
                  n579NgpDelDataHora = P007Q11_n579NgpDelDataHora[0];
                  A580NgpDelData = P007Q11_A580NgpDelData[0];
                  n580NgpDelData = P007Q11_n580NgpDelData[0];
                  A581NgpDelHora = P007Q11_A581NgpDelHora[0];
                  n581NgpDelHora = P007Q11_n581NgpDelHora[0];
                  A582NgpDelUsuId = P007Q11_A582NgpDelUsuId[0];
                  n582NgpDelUsuId = P007Q11_n582NgpDelUsuId[0];
                  A583NgpDelUsuNome = P007Q11_A583NgpDelUsuNome[0];
                  n583NgpDelUsuNome = P007Q11_n583NgpDelUsuNome[0];
                  A440NgpTppPrdCodigo = P007Q11_A440NgpTppPrdCodigo[0];
                  A441NgpTppPrdNome = P007Q11_A441NgpTppPrdNome[0];
                  A442NgpTppPrdTipoID = P007Q11_A442NgpTppPrdTipoID[0];
                  A443NgpTppPrdAtivo = P007Q11_A443NgpTppPrdAtivo[0];
                  A444NgpTpp1Preco = P007Q11_A444NgpTpp1Preco[0];
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tabela de Preço ID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A478NgpTppID.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto ID";
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A441NgpTppPrdNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "NgpTppPrdTipoID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto/Serviço";
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço na Tabela";
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Quantidade";
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
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22CountUpdatedNgfSeq = 0;
               AV25CountUpdatedNgpItem = 0;
               AV34GXV1 = 1;
               while ( AV34GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV34GXV1));
                  if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj") == 0 )
                  {
                     AV35GXV2 = 1;
                     while ( AV35GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV35GXV2));
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
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegUltFase") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A386NegUltFase), 8, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegUltNgfSeq") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A474NegUltNgfSeq), 8, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegUltIteID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A420NegUltIteID.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegUltIteNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A421NegUltIteNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NegUltIteOrdem") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A479NegUltIteOrdem), 4, 0);
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
                        AV35GXV2 = (int)(AV35GXV2+1);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj_fase") == 0 )
                  {
                     AV21CountKeyAttributes = 0;
                     AV36GXV3 = 1;
                     while ( AV36GXV3 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV36GXV3));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfSeq") == 0 )
                        {
                           AV23KeyNgfSeq = (int)(Math.Round(NumberUtil.Val( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue, "."), 18, MidpointRounding.ToEven));
                           AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                           if ( AV21CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV36GXV3 = (int)(AV36GXV3+1);
                     }
                     AV37GXLvl1705 = 0;
                     /* Using cursor P007Q12 */
                     pr_default.execute(6, new Object[] {A345NegID, AV23KeyNgfSeq});
                     while ( (pr_default.getStatus(6) != 101) )
                     {
                        A387NgfSeq = P007Q12_A387NgfSeq[0];
                        A388NgfInsData = P007Q12_A388NgfInsData[0];
                        A389NgfInsHora = P007Q12_A389NgfInsHora[0];
                        A390NgfInsDataHora = P007Q12_A390NgfInsDataHora[0];
                        A391NgfInsUsuID = P007Q12_A391NgfInsUsuID[0];
                        n391NgfInsUsuID = P007Q12_n391NgfInsUsuID[0];
                        A392NgfInsUsuNome = P007Q12_A392NgfInsUsuNome[0];
                        n392NgfInsUsuNome = P007Q12_n392NgfInsUsuNome[0];
                        A395NgfIteID = P007Q12_A395NgfIteID[0];
                        A396NgfIteOrdem = P007Q12_A396NgfIteOrdem[0];
                        A397NgfIteNome = P007Q12_A397NgfIteNome[0];
                        A425NgfFimData = P007Q12_A425NgfFimData[0];
                        n425NgfFimData = P007Q12_n425NgfFimData[0];
                        A426NgfFimHora = P007Q12_A426NgfFimHora[0];
                        n426NgfFimHora = P007Q12_n426NgfFimHora[0];
                        A427NgfFimDataHora = P007Q12_A427NgfFimDataHora[0];
                        n427NgfFimDataHora = P007Q12_n427NgfFimDataHora[0];
                        A428NgfFimUsuID = P007Q12_A428NgfFimUsuID[0];
                        n428NgfFimUsuID = P007Q12_n428NgfFimUsuID[0];
                        A429NgfFimUsuNome = P007Q12_A429NgfFimUsuNome[0];
                        n429NgfFimUsuNome = P007Q12_n429NgfFimUsuNome[0];
                        A430NgfStatus = P007Q12_A430NgfStatus[0];
                        n430NgfStatus = P007Q12_n430NgfStatus[0];
                        A584NgfDel = P007Q12_A584NgfDel[0];
                        A585NgfDelDataHora = P007Q12_A585NgfDelDataHora[0];
                        n585NgfDelDataHora = P007Q12_n585NgfDelDataHora[0];
                        A586NgfDelData = P007Q12_A586NgfDelData[0];
                        n586NgfDelData = P007Q12_n586NgfDelData[0];
                        A587NgfDelHora = P007Q12_A587NgfDelHora[0];
                        n587NgfDelHora = P007Q12_n587NgfDelHora[0];
                        A588NgfDelUsuId = P007Q12_A588NgfDelUsuId[0];
                        n588NgfDelUsuId = P007Q12_n588NgfDelUsuId[0];
                        A589NgfDelUsuNome = P007Q12_A589NgfDelUsuNome[0];
                        n589NgfDelUsuNome = P007Q12_n589NgfDelUsuNome[0];
                        A396NgfIteOrdem = P007Q12_A396NgfIteOrdem[0];
                        AV37GXLvl1705 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV22CountUpdatedNgfSeq = (short)(AV22CountUpdatedNgfSeq+1);
                        AV38GXV4 = 1;
                        while ( AV38GXV4 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV38GXV4));
                           if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfSeq") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A387NgfSeq), 8, 0);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfInsData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A388NgfInsData, 2, "/");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfInsHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A389NgfInsHora, 0, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfInsDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A390NgfInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfInsUsuID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A391NgfInsUsuID;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfInsUsuNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A392NgfInsUsuNome;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfIteID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A395NgfIteID.ToString();
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfIteOrdem") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A396NgfIteOrdem), 8, 0);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfIteNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A397NgfIteNome;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfFimData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A425NgfFimData, 2, "/");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfFimHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A426NgfFimHora, 0, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfFimDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A427NgfFimDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfFimUsuID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A428NgfFimUsuID;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfFimUsuNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A429NgfFimUsuNome;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfStatus") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A430NgfStatus;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfDel") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A584NgfDel);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfDelDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A585NgfDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfDelData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A586NgfDelData, 10, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfDelHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A587NgfDelHora, 0, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfDelUsuId") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A588NgfDelUsuId;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfDelUsuNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A589NgfDelUsuNome;
                           }
                           AV38GXV4 = (int)(AV38GXV4+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(6);
                     if ( AV37GXLvl1705 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj_item") == 0 )
                  {
                     AV21CountKeyAttributes = 0;
                     AV39GXV5 = 1;
                     while ( AV39GXV5 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV39GXV5));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpItem") == 0 )
                        {
                           AV26KeyNgpItem = (int)(Math.Round(NumberUtil.Val( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue, "."), 18, MidpointRounding.ToEven));
                           AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                           if ( AV21CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV39GXV5 = (int)(AV39GXV5+1);
                     }
                     AV40GXLvl1795 = 0;
                     /* Using cursor P007Q13 */
                     pr_default.execute(7, new Object[] {A345NegID, AV26KeyNgpItem});
                     while ( (pr_default.getStatus(7) != 101) )
                     {
                        A435NgpItem = P007Q13_A435NgpItem[0];
                        A455NgpInsData = P007Q13_A455NgpInsData[0];
                        A456NgpInsHora = P007Q13_A456NgpInsHora[0];
                        A457NgpInsDataHora = P007Q13_A457NgpInsDataHora[0];
                        A458NgpInsUsuID = P007Q13_A458NgpInsUsuID[0];
                        n458NgpInsUsuID = P007Q13_n458NgpInsUsuID[0];
                        A459NgpInsUsuNome = P007Q13_A459NgpInsUsuNome[0];
                        n459NgpInsUsuNome = P007Q13_n459NgpInsUsuNome[0];
                        A478NgpTppID = P007Q13_A478NgpTppID[0];
                        A439NgpTppPrdID = P007Q13_A439NgpTppPrdID[0];
                        A440NgpTppPrdCodigo = P007Q13_A440NgpTppPrdCodigo[0];
                        A441NgpTppPrdNome = P007Q13_A441NgpTppPrdNome[0];
                        A442NgpTppPrdTipoID = P007Q13_A442NgpTppPrdTipoID[0];
                        A443NgpTppPrdAtivo = P007Q13_A443NgpTppPrdAtivo[0];
                        A444NgpTpp1Preco = P007Q13_A444NgpTpp1Preco[0];
                        A445NgpPreco = P007Q13_A445NgpPreco[0];
                        A446NgpQtde = P007Q13_A446NgpQtde[0];
                        A447NgpTotal = P007Q13_A447NgpTotal[0];
                        A453NgpObs = P007Q13_A453NgpObs[0];
                        A578NgpDel = P007Q13_A578NgpDel[0];
                        A579NgpDelDataHora = P007Q13_A579NgpDelDataHora[0];
                        n579NgpDelDataHora = P007Q13_n579NgpDelDataHora[0];
                        A580NgpDelData = P007Q13_A580NgpDelData[0];
                        n580NgpDelData = P007Q13_n580NgpDelData[0];
                        A581NgpDelHora = P007Q13_A581NgpDelHora[0];
                        n581NgpDelHora = P007Q13_n581NgpDelHora[0];
                        A582NgpDelUsuId = P007Q13_A582NgpDelUsuId[0];
                        n582NgpDelUsuId = P007Q13_n582NgpDelUsuId[0];
                        A583NgpDelUsuNome = P007Q13_A583NgpDelUsuNome[0];
                        n583NgpDelUsuNome = P007Q13_n583NgpDelUsuNome[0];
                        A440NgpTppPrdCodigo = P007Q13_A440NgpTppPrdCodigo[0];
                        A441NgpTppPrdNome = P007Q13_A441NgpTppPrdNome[0];
                        A442NgpTppPrdTipoID = P007Q13_A442NgpTppPrdTipoID[0];
                        A443NgpTppPrdAtivo = P007Q13_A443NgpTppPrdAtivo[0];
                        A444NgpTpp1Preco = P007Q13_A444NgpTpp1Preco[0];
                        AV40GXLvl1795 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV25CountUpdatedNgpItem = (short)(AV25CountUpdatedNgpItem+1);
                        AV41GXV6 = 1;
                        while ( AV41GXV6 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV41GXV6));
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
                           AV41GXV6 = (int)(AV41GXV6+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(7);
                     if ( AV40GXLvl1795 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  AV34GXV1 = (int)(AV34GXV1+1);
               }
               if ( AV22CountUpdatedNgfSeq < A40000GXC1 )
               {
                  AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P007Q14 */
                  pr_default.execute(8, new Object[] {AV17NegID});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A345NegID = P007Q14_A345NegID[0];
                     A387NgfSeq = P007Q14_A387NgfSeq[0];
                     A388NgfInsData = P007Q14_A388NgfInsData[0];
                     A389NgfInsHora = P007Q14_A389NgfInsHora[0];
                     A390NgfInsDataHora = P007Q14_A390NgfInsDataHora[0];
                     A391NgfInsUsuID = P007Q14_A391NgfInsUsuID[0];
                     n391NgfInsUsuID = P007Q14_n391NgfInsUsuID[0];
                     A392NgfInsUsuNome = P007Q14_A392NgfInsUsuNome[0];
                     n392NgfInsUsuNome = P007Q14_n392NgfInsUsuNome[0];
                     A395NgfIteID = P007Q14_A395NgfIteID[0];
                     A396NgfIteOrdem = P007Q14_A396NgfIteOrdem[0];
                     A397NgfIteNome = P007Q14_A397NgfIteNome[0];
                     A425NgfFimData = P007Q14_A425NgfFimData[0];
                     n425NgfFimData = P007Q14_n425NgfFimData[0];
                     A426NgfFimHora = P007Q14_A426NgfFimHora[0];
                     n426NgfFimHora = P007Q14_n426NgfFimHora[0];
                     A427NgfFimDataHora = P007Q14_A427NgfFimDataHora[0];
                     n427NgfFimDataHora = P007Q14_n427NgfFimDataHora[0];
                     A428NgfFimUsuID = P007Q14_A428NgfFimUsuID[0];
                     n428NgfFimUsuID = P007Q14_n428NgfFimUsuID[0];
                     A429NgfFimUsuNome = P007Q14_A429NgfFimUsuNome[0];
                     n429NgfFimUsuNome = P007Q14_n429NgfFimUsuNome[0];
                     A430NgfStatus = P007Q14_A430NgfStatus[0];
                     n430NgfStatus = P007Q14_n430NgfStatus[0];
                     A584NgfDel = P007Q14_A584NgfDel[0];
                     A585NgfDelDataHora = P007Q14_A585NgfDelDataHora[0];
                     n585NgfDelDataHora = P007Q14_n585NgfDelDataHora[0];
                     A586NgfDelData = P007Q14_A586NgfDelData[0];
                     n586NgfDelData = P007Q14_n586NgfDelData[0];
                     A587NgfDelHora = P007Q14_A587NgfDelHora[0];
                     n587NgfDelHora = P007Q14_n587NgfDelHora[0];
                     A588NgfDelUsuId = P007Q14_A588NgfDelUsuId[0];
                     n588NgfDelUsuId = P007Q14_n588NgfDelUsuId[0];
                     A589NgfDelUsuNome = P007Q14_A589NgfDelUsuNome[0];
                     n589NgfDelUsuNome = P007Q14_n589NgfDelUsuNome[0];
                     A396NgfIteOrdem = P007Q14_A396NgfIteOrdem[0];
                     AV23KeyNgfSeq = A387NgfSeq;
                     AV24RecordExistsNgfSeq = false;
                     AV43GXV7 = 1;
                     while ( AV43GXV7 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV43GXV7));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj_fase") == 0 )
                        {
                           AV21CountKeyAttributes = 0;
                           AV44GXV8 = 1;
                           while ( AV44GXV8 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV44GXV8));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgfSeq") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( StringUtil.Str( (decimal)(AV23KeyNgfSeq), 8, 0))) == 0 )
                                 {
                                    AV24RecordExistsNgfSeq = true;
                                    AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                                    if ( AV21CountKeyAttributes == 1 )
                                    {
                                       if (true) break;
                                    }
                                 }
                              }
                              AV44GXV8 = (int)(AV44GXV8+1);
                           }
                        }
                        AV43GXV7 = (int)(AV43GXV7+1);
                     }
                     if ( ! ( AV24RecordExistsNgfSeq ) )
                     {
                        AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                        AV19AuditingObjectRecordItemNew.gxTpr_Tablename = "tb_negociopj_fase";
                        AV19AuditingObjectRecordItemNew.gxTpr_Mode = "INS";
                        AV18AuditingObjectNewRecords.gxTpr_Record.Add(AV19AuditingObjectRecordItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfSeq";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Sequência";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A387NgfSeq), 8, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfInsData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.DToC( A388NgfInsData, 2, "/");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfInsHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A389NgfInsHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfInsDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A390NgfInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfInsUsuID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A391NgfInsUsuID;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfInsUsuNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Incluído por";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A392NgfInsUsuNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfIteID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Iteração";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A395NgfIteID.ToString();
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfIteOrdem";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Ordem";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A396NgfIteOrdem), 8, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfIteNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Descrição do Itinerário";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A397NgfIteNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfFimData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "da Fase";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.DToC( A425NgfFimData, 2, "/");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfFimHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "da Fase";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A426NgfFimHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfFimDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "da Fase";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A427NgfFimDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfFimUsuID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "da Fase";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A428NgfFimUsuID;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfFimUsuNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "da Fase";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A429NgfFimUsuNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfStatus";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Situação";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A430NgfStatus;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfDel";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Registro Excluído";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A584NgfDel);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfDelDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A585NgfDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfDelData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A586NgfDelData, 10, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfDelHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Hora de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A587NgfDelHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfDelUsuId";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário ID de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A588NgfDelUsuId;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgfDelUsuNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Nome do Usuário de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A589NgfDelUsuNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                     }
                     pr_default.readNext(8);
                  }
                  pr_default.close(8);
                  AV45GXV9 = 1;
                  while ( AV45GXV9 <= AV18AuditingObjectNewRecords.gxTpr_Record.Count )
                  {
                     AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV18AuditingObjectNewRecords.gxTpr_Record.Item(AV45GXV9));
                     AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                     AV45GXV9 = (int)(AV45GXV9+1);
                  }
               }
               if ( AV25CountUpdatedNgpItem < A40001GXC2 )
               {
                  AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P007Q15 */
                  pr_default.execute(9, new Object[] {AV17NegID});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A345NegID = P007Q15_A345NegID[0];
                     A435NgpItem = P007Q15_A435NgpItem[0];
                     A455NgpInsData = P007Q15_A455NgpInsData[0];
                     A456NgpInsHora = P007Q15_A456NgpInsHora[0];
                     A457NgpInsDataHora = P007Q15_A457NgpInsDataHora[0];
                     A458NgpInsUsuID = P007Q15_A458NgpInsUsuID[0];
                     n458NgpInsUsuID = P007Q15_n458NgpInsUsuID[0];
                     A459NgpInsUsuNome = P007Q15_A459NgpInsUsuNome[0];
                     n459NgpInsUsuNome = P007Q15_n459NgpInsUsuNome[0];
                     A478NgpTppID = P007Q15_A478NgpTppID[0];
                     A439NgpTppPrdID = P007Q15_A439NgpTppPrdID[0];
                     A440NgpTppPrdCodigo = P007Q15_A440NgpTppPrdCodigo[0];
                     A441NgpTppPrdNome = P007Q15_A441NgpTppPrdNome[0];
                     A442NgpTppPrdTipoID = P007Q15_A442NgpTppPrdTipoID[0];
                     A443NgpTppPrdAtivo = P007Q15_A443NgpTppPrdAtivo[0];
                     A444NgpTpp1Preco = P007Q15_A444NgpTpp1Preco[0];
                     A445NgpPreco = P007Q15_A445NgpPreco[0];
                     A446NgpQtde = P007Q15_A446NgpQtde[0];
                     A447NgpTotal = P007Q15_A447NgpTotal[0];
                     A453NgpObs = P007Q15_A453NgpObs[0];
                     A578NgpDel = P007Q15_A578NgpDel[0];
                     A579NgpDelDataHora = P007Q15_A579NgpDelDataHora[0];
                     n579NgpDelDataHora = P007Q15_n579NgpDelDataHora[0];
                     A580NgpDelData = P007Q15_A580NgpDelData[0];
                     n580NgpDelData = P007Q15_n580NgpDelData[0];
                     A581NgpDelHora = P007Q15_A581NgpDelHora[0];
                     n581NgpDelHora = P007Q15_n581NgpDelHora[0];
                     A582NgpDelUsuId = P007Q15_A582NgpDelUsuId[0];
                     n582NgpDelUsuId = P007Q15_n582NgpDelUsuId[0];
                     A583NgpDelUsuNome = P007Q15_A583NgpDelUsuNome[0];
                     n583NgpDelUsuNome = P007Q15_n583NgpDelUsuNome[0];
                     A440NgpTppPrdCodigo = P007Q15_A440NgpTppPrdCodigo[0];
                     A441NgpTppPrdNome = P007Q15_A441NgpTppPrdNome[0];
                     A442NgpTppPrdTipoID = P007Q15_A442NgpTppPrdTipoID[0];
                     A443NgpTppPrdAtivo = P007Q15_A443NgpTppPrdAtivo[0];
                     A444NgpTpp1Preco = P007Q15_A444NgpTpp1Preco[0];
                     AV26KeyNgpItem = A435NgpItem;
                     AV27RecordExistsNgpItem = false;
                     AV47GXV10 = 1;
                     while ( AV47GXV10 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV47GXV10));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_negociopj_item") == 0 )
                        {
                           AV21CountKeyAttributes = 0;
                           AV48GXV11 = 1;
                           while ( AV48GXV11 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV48GXV11));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "NgpItem") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( StringUtil.Str( (decimal)(AV26KeyNgpItem), 8, 0))) == 0 )
                                 {
                                    AV27RecordExistsNgpItem = true;
                                    AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                                    if ( AV21CountKeyAttributes == 1 )
                                    {
                                       if (true) break;
                                    }
                                 }
                              }
                              AV48GXV11 = (int)(AV48GXV11+1);
                           }
                        }
                        AV47GXV10 = (int)(AV47GXV10+1);
                     }
                     if ( ! ( AV27RecordExistsNgpItem ) )
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
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
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
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Tabela de Preço ID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A478NgpTppID.ToString();
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Produto ID";
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
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A441NgpTppPrdNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "NgpTppPrdTipoID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Tipo do Produto/Serviço";
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
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Preço na Tabela";
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
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Quantidade";
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
                     pr_default.readNext(9);
                  }
                  pr_default.close(9);
                  AV49GXV12 = 1;
                  while ( AV49GXV12 <= AV18AuditingObjectNewRecords.gxTpr_Record.Count )
                  {
                     AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV18AuditingObjectNewRecords.gxTpr_Record.Item(AV49GXV12));
                     AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                     AV49GXV12 = (int)(AV49GXV12+1);
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
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
         P007Q3_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q3_A356NegCodigo = new long[1] ;
         P007Q3_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q3_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q3_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q3_A349NegInsUsuID = new string[] {""} ;
         P007Q3_n349NegInsUsuID = new bool[] {false} ;
         P007Q3_A364NegInsUsuNome = new string[] {""} ;
         P007Q3_n364NegInsUsuNome = new bool[] {false} ;
         P007Q3_A350NegCliID = new Guid[] {Guid.Empty} ;
         P007Q3_A473NegCliMatricula = new long[1] ;
         P007Q3_A351NegCliNomeFamiliar = new string[] {""} ;
         P007Q3_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P007Q3_A353NegCpjNomFan = new string[] {""} ;
         P007Q3_A354NegCpjRazSocial = new string[] {""} ;
         P007Q3_A355NegCpjMatricula = new long[1] ;
         P007Q3_A357NegPjtID = new int[1] ;
         P007Q3_A358NegPjtSigla = new string[] {""} ;
         P007Q3_A359NegPjtNome = new string[] {""} ;
         P007Q3_A369NegCpjEndSeq = new short[1] ;
         P007Q3_A370NegCpjEndNome = new string[] {""} ;
         P007Q3_A371NegCpjEndEndereco = new string[] {""} ;
         P007Q3_A372NegCpjEndNumero = new string[] {""} ;
         P007Q3_A373NegCpjEndComplem = new string[] {""} ;
         P007Q3_n373NegCpjEndComplem = new bool[] {false} ;
         P007Q3_A374NegCpjEndBairro = new string[] {""} ;
         P007Q3_A375NegCpjEndMunID = new int[1] ;
         P007Q3_A376NegCpjEndMunNome = new string[] {""} ;
         P007Q3_A377NegCpjEndUFID = new short[1] ;
         P007Q3_A378NegCpjEndUFSigla = new string[] {""} ;
         P007Q3_A379NegCpjEndUFNome = new string[] {""} ;
         P007Q3_A360NegAgcID = new string[] {""} ;
         P007Q3_n360NegAgcID = new bool[] {false} ;
         P007Q3_A361NegAgcNome = new string[] {""} ;
         P007Q3_n361NegAgcNome = new bool[] {false} ;
         P007Q3_A362NegAssunto = new string[] {""} ;
         P007Q3_A363NegDescricao = new string[] {""} ;
         P007Q3_A386NegUltFase = new int[1] ;
         P007Q3_A474NegUltNgfSeq = new int[1] ;
         P007Q3_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         P007Q3_A421NegUltIteNome = new string[] {""} ;
         P007Q3_A479NegUltIteOrdem = new short[1] ;
         P007Q3_A380NegValorEstimado = new decimal[1] ;
         P007Q3_A385NegValorAtualizado = new decimal[1] ;
         P007Q3_A454NegUltItem = new int[1] ;
         P007Q3_n454NegUltItem = new bool[] {false} ;
         P007Q3_A572NegDel = new bool[] {false} ;
         P007Q3_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q3_n573NegDelDataHora = new bool[] {false} ;
         P007Q3_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q3_n574NegDelData = new bool[] {false} ;
         P007Q3_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q3_n575NegDelHora = new bool[] {false} ;
         P007Q3_A576NegDelUsuId = new string[] {""} ;
         P007Q3_n576NegDelUsuId = new bool[] {false} ;
         P007Q3_A577NegDelUsuNome = new string[] {""} ;
         P007Q3_n577NegDelUsuNome = new bool[] {false} ;
         P007Q3_A448NegPgpTotal = new decimal[1] ;
         P007Q3_n448NegPgpTotal = new bool[] {false} ;
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
         A371NegCpjEndEndereco = "";
         A372NegCpjEndNumero = "";
         A373NegCpjEndComplem = "";
         A374NegCpjEndBairro = "";
         A376NegCpjEndMunNome = "";
         A378NegCpjEndUFSigla = "";
         A379NegCpjEndUFNome = "";
         A360NegAgcID = "";
         A361NegAgcNome = "";
         A362NegAssunto = "";
         A363NegDescricao = "";
         A420NegUltIteID = Guid.Empty;
         A421NegUltIteNome = "";
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         A574NegDelData = (DateTime)(DateTime.MinValue);
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         A576NegDelUsuId = "";
         A577NegDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007Q4_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q4_A387NgfSeq = new int[1] ;
         P007Q4_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q4_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q4_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q4_A391NgfInsUsuID = new string[] {""} ;
         P007Q4_n391NgfInsUsuID = new bool[] {false} ;
         P007Q4_A392NgfInsUsuNome = new string[] {""} ;
         P007Q4_n392NgfInsUsuNome = new bool[] {false} ;
         P007Q4_A395NgfIteID = new Guid[] {Guid.Empty} ;
         P007Q4_A396NgfIteOrdem = new int[1] ;
         P007Q4_A397NgfIteNome = new string[] {""} ;
         P007Q4_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         P007Q4_n425NgfFimData = new bool[] {false} ;
         P007Q4_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         P007Q4_n426NgfFimHora = new bool[] {false} ;
         P007Q4_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q4_n427NgfFimDataHora = new bool[] {false} ;
         P007Q4_A428NgfFimUsuID = new string[] {""} ;
         P007Q4_n428NgfFimUsuID = new bool[] {false} ;
         P007Q4_A429NgfFimUsuNome = new string[] {""} ;
         P007Q4_n429NgfFimUsuNome = new bool[] {false} ;
         P007Q4_A430NgfStatus = new string[] {""} ;
         P007Q4_n430NgfStatus = new bool[] {false} ;
         P007Q4_A584NgfDel = new bool[] {false} ;
         P007Q4_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q4_n585NgfDelDataHora = new bool[] {false} ;
         P007Q4_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q4_n586NgfDelData = new bool[] {false} ;
         P007Q4_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q4_n587NgfDelHora = new bool[] {false} ;
         P007Q4_A588NgfDelUsuId = new string[] {""} ;
         P007Q4_n588NgfDelUsuId = new bool[] {false} ;
         P007Q4_A589NgfDelUsuNome = new string[] {""} ;
         P007Q4_n589NgfDelUsuNome = new bool[] {false} ;
         A388NgfInsData = DateTime.MinValue;
         A389NgfInsHora = (DateTime)(DateTime.MinValue);
         A390NgfInsDataHora = (DateTime)(DateTime.MinValue);
         A391NgfInsUsuID = "";
         A392NgfInsUsuNome = "";
         A395NgfIteID = Guid.Empty;
         A397NgfIteNome = "";
         A425NgfFimData = DateTime.MinValue;
         A426NgfFimHora = (DateTime)(DateTime.MinValue);
         A427NgfFimDataHora = (DateTime)(DateTime.MinValue);
         A428NgfFimUsuID = "";
         A429NgfFimUsuNome = "";
         A430NgfStatus = "";
         A585NgfDelDataHora = (DateTime)(DateTime.MinValue);
         A586NgfDelData = (DateTime)(DateTime.MinValue);
         A587NgfDelHora = (DateTime)(DateTime.MinValue);
         A588NgfDelUsuId = "";
         A589NgfDelUsuNome = "";
         P007Q5_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q5_A435NgpItem = new int[1] ;
         P007Q5_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q5_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q5_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q5_A458NgpInsUsuID = new string[] {""} ;
         P007Q5_n458NgpInsUsuID = new bool[] {false} ;
         P007Q5_A459NgpInsUsuNome = new string[] {""} ;
         P007Q5_n459NgpInsUsuNome = new bool[] {false} ;
         P007Q5_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007Q5_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007Q5_A440NgpTppPrdCodigo = new string[] {""} ;
         P007Q5_A441NgpTppPrdNome = new string[] {""} ;
         P007Q5_A442NgpTppPrdTipoID = new int[1] ;
         P007Q5_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007Q5_A444NgpTpp1Preco = new decimal[1] ;
         P007Q5_A445NgpPreco = new decimal[1] ;
         P007Q5_A446NgpQtde = new int[1] ;
         P007Q5_A447NgpTotal = new decimal[1] ;
         P007Q5_A453NgpObs = new string[] {""} ;
         P007Q5_A578NgpDel = new bool[] {false} ;
         P007Q5_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q5_n579NgpDelDataHora = new bool[] {false} ;
         P007Q5_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q5_n580NgpDelData = new bool[] {false} ;
         P007Q5_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q5_n581NgpDelHora = new bool[] {false} ;
         P007Q5_A582NgpDelUsuId = new string[] {""} ;
         P007Q5_n582NgpDelUsuId = new bool[] {false} ;
         P007Q5_A583NgpDelUsuNome = new string[] {""} ;
         P007Q5_n583NgpDelUsuNome = new bool[] {false} ;
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
         P007Q9_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q9_A356NegCodigo = new long[1] ;
         P007Q9_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q9_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q9_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q9_A349NegInsUsuID = new string[] {""} ;
         P007Q9_n349NegInsUsuID = new bool[] {false} ;
         P007Q9_A364NegInsUsuNome = new string[] {""} ;
         P007Q9_n364NegInsUsuNome = new bool[] {false} ;
         P007Q9_A350NegCliID = new Guid[] {Guid.Empty} ;
         P007Q9_A473NegCliMatricula = new long[1] ;
         P007Q9_A351NegCliNomeFamiliar = new string[] {""} ;
         P007Q9_A352NegCpjID = new Guid[] {Guid.Empty} ;
         P007Q9_A353NegCpjNomFan = new string[] {""} ;
         P007Q9_A354NegCpjRazSocial = new string[] {""} ;
         P007Q9_A355NegCpjMatricula = new long[1] ;
         P007Q9_A357NegPjtID = new int[1] ;
         P007Q9_A358NegPjtSigla = new string[] {""} ;
         P007Q9_A359NegPjtNome = new string[] {""} ;
         P007Q9_A369NegCpjEndSeq = new short[1] ;
         P007Q9_A370NegCpjEndNome = new string[] {""} ;
         P007Q9_A371NegCpjEndEndereco = new string[] {""} ;
         P007Q9_A372NegCpjEndNumero = new string[] {""} ;
         P007Q9_A373NegCpjEndComplem = new string[] {""} ;
         P007Q9_n373NegCpjEndComplem = new bool[] {false} ;
         P007Q9_A374NegCpjEndBairro = new string[] {""} ;
         P007Q9_A375NegCpjEndMunID = new int[1] ;
         P007Q9_A376NegCpjEndMunNome = new string[] {""} ;
         P007Q9_A377NegCpjEndUFID = new short[1] ;
         P007Q9_A378NegCpjEndUFSigla = new string[] {""} ;
         P007Q9_A379NegCpjEndUFNome = new string[] {""} ;
         P007Q9_A360NegAgcID = new string[] {""} ;
         P007Q9_n360NegAgcID = new bool[] {false} ;
         P007Q9_A361NegAgcNome = new string[] {""} ;
         P007Q9_n361NegAgcNome = new bool[] {false} ;
         P007Q9_A362NegAssunto = new string[] {""} ;
         P007Q9_A363NegDescricao = new string[] {""} ;
         P007Q9_A386NegUltFase = new int[1] ;
         P007Q9_A474NegUltNgfSeq = new int[1] ;
         P007Q9_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         P007Q9_A421NegUltIteNome = new string[] {""} ;
         P007Q9_A479NegUltIteOrdem = new short[1] ;
         P007Q9_A380NegValorEstimado = new decimal[1] ;
         P007Q9_A385NegValorAtualizado = new decimal[1] ;
         P007Q9_A454NegUltItem = new int[1] ;
         P007Q9_n454NegUltItem = new bool[] {false} ;
         P007Q9_A572NegDel = new bool[] {false} ;
         P007Q9_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q9_n573NegDelDataHora = new bool[] {false} ;
         P007Q9_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q9_n574NegDelData = new bool[] {false} ;
         P007Q9_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q9_n575NegDelHora = new bool[] {false} ;
         P007Q9_A576NegDelUsuId = new string[] {""} ;
         P007Q9_n576NegDelUsuId = new bool[] {false} ;
         P007Q9_A577NegDelUsuNome = new string[] {""} ;
         P007Q9_n577NegDelUsuNome = new bool[] {false} ;
         P007Q9_A448NegPgpTotal = new decimal[1] ;
         P007Q9_n448NegPgpTotal = new bool[] {false} ;
         P007Q9_A40000GXC1 = new int[1] ;
         P007Q9_n40000GXC1 = new bool[] {false} ;
         P007Q9_A40001GXC2 = new int[1] ;
         P007Q9_n40001GXC2 = new bool[] {false} ;
         P007Q10_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q10_A387NgfSeq = new int[1] ;
         P007Q10_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q10_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q10_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q10_A391NgfInsUsuID = new string[] {""} ;
         P007Q10_n391NgfInsUsuID = new bool[] {false} ;
         P007Q10_A392NgfInsUsuNome = new string[] {""} ;
         P007Q10_n392NgfInsUsuNome = new bool[] {false} ;
         P007Q10_A395NgfIteID = new Guid[] {Guid.Empty} ;
         P007Q10_A396NgfIteOrdem = new int[1] ;
         P007Q10_A397NgfIteNome = new string[] {""} ;
         P007Q10_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         P007Q10_n425NgfFimData = new bool[] {false} ;
         P007Q10_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         P007Q10_n426NgfFimHora = new bool[] {false} ;
         P007Q10_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q10_n427NgfFimDataHora = new bool[] {false} ;
         P007Q10_A428NgfFimUsuID = new string[] {""} ;
         P007Q10_n428NgfFimUsuID = new bool[] {false} ;
         P007Q10_A429NgfFimUsuNome = new string[] {""} ;
         P007Q10_n429NgfFimUsuNome = new bool[] {false} ;
         P007Q10_A430NgfStatus = new string[] {""} ;
         P007Q10_n430NgfStatus = new bool[] {false} ;
         P007Q10_A584NgfDel = new bool[] {false} ;
         P007Q10_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q10_n585NgfDelDataHora = new bool[] {false} ;
         P007Q10_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q10_n586NgfDelData = new bool[] {false} ;
         P007Q10_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q10_n587NgfDelHora = new bool[] {false} ;
         P007Q10_A588NgfDelUsuId = new string[] {""} ;
         P007Q10_n588NgfDelUsuId = new bool[] {false} ;
         P007Q10_A589NgfDelUsuNome = new string[] {""} ;
         P007Q10_n589NgfDelUsuNome = new bool[] {false} ;
         P007Q11_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q11_A435NgpItem = new int[1] ;
         P007Q11_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q11_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q11_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q11_A458NgpInsUsuID = new string[] {""} ;
         P007Q11_n458NgpInsUsuID = new bool[] {false} ;
         P007Q11_A459NgpInsUsuNome = new string[] {""} ;
         P007Q11_n459NgpInsUsuNome = new bool[] {false} ;
         P007Q11_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007Q11_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007Q11_A440NgpTppPrdCodigo = new string[] {""} ;
         P007Q11_A441NgpTppPrdNome = new string[] {""} ;
         P007Q11_A442NgpTppPrdTipoID = new int[1] ;
         P007Q11_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007Q11_A444NgpTpp1Preco = new decimal[1] ;
         P007Q11_A445NgpPreco = new decimal[1] ;
         P007Q11_A446NgpQtde = new int[1] ;
         P007Q11_A447NgpTotal = new decimal[1] ;
         P007Q11_A453NgpObs = new string[] {""} ;
         P007Q11_A578NgpDel = new bool[] {false} ;
         P007Q11_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q11_n579NgpDelDataHora = new bool[] {false} ;
         P007Q11_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q11_n580NgpDelData = new bool[] {false} ;
         P007Q11_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q11_n581NgpDelHora = new bool[] {false} ;
         P007Q11_A582NgpDelUsuId = new string[] {""} ;
         P007Q11_n582NgpDelUsuId = new bool[] {false} ;
         P007Q11_A583NgpDelUsuNome = new string[] {""} ;
         P007Q11_n583NgpDelUsuNome = new bool[] {false} ;
         P007Q12_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q12_A387NgfSeq = new int[1] ;
         P007Q12_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q12_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q12_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q12_A391NgfInsUsuID = new string[] {""} ;
         P007Q12_n391NgfInsUsuID = new bool[] {false} ;
         P007Q12_A392NgfInsUsuNome = new string[] {""} ;
         P007Q12_n392NgfInsUsuNome = new bool[] {false} ;
         P007Q12_A395NgfIteID = new Guid[] {Guid.Empty} ;
         P007Q12_A396NgfIteOrdem = new int[1] ;
         P007Q12_A397NgfIteNome = new string[] {""} ;
         P007Q12_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         P007Q12_n425NgfFimData = new bool[] {false} ;
         P007Q12_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         P007Q12_n426NgfFimHora = new bool[] {false} ;
         P007Q12_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q12_n427NgfFimDataHora = new bool[] {false} ;
         P007Q12_A428NgfFimUsuID = new string[] {""} ;
         P007Q12_n428NgfFimUsuID = new bool[] {false} ;
         P007Q12_A429NgfFimUsuNome = new string[] {""} ;
         P007Q12_n429NgfFimUsuNome = new bool[] {false} ;
         P007Q12_A430NgfStatus = new string[] {""} ;
         P007Q12_n430NgfStatus = new bool[] {false} ;
         P007Q12_A584NgfDel = new bool[] {false} ;
         P007Q12_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q12_n585NgfDelDataHora = new bool[] {false} ;
         P007Q12_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q12_n586NgfDelData = new bool[] {false} ;
         P007Q12_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q12_n587NgfDelHora = new bool[] {false} ;
         P007Q12_A588NgfDelUsuId = new string[] {""} ;
         P007Q12_n588NgfDelUsuId = new bool[] {false} ;
         P007Q12_A589NgfDelUsuNome = new string[] {""} ;
         P007Q12_n589NgfDelUsuNome = new bool[] {false} ;
         P007Q13_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q13_A435NgpItem = new int[1] ;
         P007Q13_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q13_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q13_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q13_A458NgpInsUsuID = new string[] {""} ;
         P007Q13_n458NgpInsUsuID = new bool[] {false} ;
         P007Q13_A459NgpInsUsuNome = new string[] {""} ;
         P007Q13_n459NgpInsUsuNome = new bool[] {false} ;
         P007Q13_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007Q13_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007Q13_A440NgpTppPrdCodigo = new string[] {""} ;
         P007Q13_A441NgpTppPrdNome = new string[] {""} ;
         P007Q13_A442NgpTppPrdTipoID = new int[1] ;
         P007Q13_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007Q13_A444NgpTpp1Preco = new decimal[1] ;
         P007Q13_A445NgpPreco = new decimal[1] ;
         P007Q13_A446NgpQtde = new int[1] ;
         P007Q13_A447NgpTotal = new decimal[1] ;
         P007Q13_A453NgpObs = new string[] {""} ;
         P007Q13_A578NgpDel = new bool[] {false} ;
         P007Q13_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q13_n579NgpDelDataHora = new bool[] {false} ;
         P007Q13_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q13_n580NgpDelData = new bool[] {false} ;
         P007Q13_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q13_n581NgpDelHora = new bool[] {false} ;
         P007Q13_A582NgpDelUsuId = new string[] {""} ;
         P007Q13_n582NgpDelUsuId = new bool[] {false} ;
         P007Q13_A583NgpDelUsuNome = new string[] {""} ;
         P007Q13_n583NgpDelUsuNome = new bool[] {false} ;
         AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         P007Q14_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q14_A387NgfSeq = new int[1] ;
         P007Q14_A388NgfInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q14_A389NgfInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q14_A390NgfInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q14_A391NgfInsUsuID = new string[] {""} ;
         P007Q14_n391NgfInsUsuID = new bool[] {false} ;
         P007Q14_A392NgfInsUsuNome = new string[] {""} ;
         P007Q14_n392NgfInsUsuNome = new bool[] {false} ;
         P007Q14_A395NgfIteID = new Guid[] {Guid.Empty} ;
         P007Q14_A396NgfIteOrdem = new int[1] ;
         P007Q14_A397NgfIteNome = new string[] {""} ;
         P007Q14_A425NgfFimData = new DateTime[] {DateTime.MinValue} ;
         P007Q14_n425NgfFimData = new bool[] {false} ;
         P007Q14_A426NgfFimHora = new DateTime[] {DateTime.MinValue} ;
         P007Q14_n426NgfFimHora = new bool[] {false} ;
         P007Q14_A427NgfFimDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q14_n427NgfFimDataHora = new bool[] {false} ;
         P007Q14_A428NgfFimUsuID = new string[] {""} ;
         P007Q14_n428NgfFimUsuID = new bool[] {false} ;
         P007Q14_A429NgfFimUsuNome = new string[] {""} ;
         P007Q14_n429NgfFimUsuNome = new bool[] {false} ;
         P007Q14_A430NgfStatus = new string[] {""} ;
         P007Q14_n430NgfStatus = new bool[] {false} ;
         P007Q14_A584NgfDel = new bool[] {false} ;
         P007Q14_A585NgfDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q14_n585NgfDelDataHora = new bool[] {false} ;
         P007Q14_A586NgfDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q14_n586NgfDelData = new bool[] {false} ;
         P007Q14_A587NgfDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q14_n587NgfDelHora = new bool[] {false} ;
         P007Q14_A588NgfDelUsuId = new string[] {""} ;
         P007Q14_n588NgfDelUsuId = new bool[] {false} ;
         P007Q14_A589NgfDelUsuNome = new string[] {""} ;
         P007Q14_n589NgfDelUsuNome = new bool[] {false} ;
         AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007Q15_A345NegID = new Guid[] {Guid.Empty} ;
         P007Q15_A435NgpItem = new int[1] ;
         P007Q15_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         P007Q15_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         P007Q15_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q15_A458NgpInsUsuID = new string[] {""} ;
         P007Q15_n458NgpInsUsuID = new bool[] {false} ;
         P007Q15_A459NgpInsUsuNome = new string[] {""} ;
         P007Q15_n459NgpInsUsuNome = new bool[] {false} ;
         P007Q15_A478NgpTppID = new Guid[] {Guid.Empty} ;
         P007Q15_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         P007Q15_A440NgpTppPrdCodigo = new string[] {""} ;
         P007Q15_A441NgpTppPrdNome = new string[] {""} ;
         P007Q15_A442NgpTppPrdTipoID = new int[1] ;
         P007Q15_A443NgpTppPrdAtivo = new bool[] {false} ;
         P007Q15_A444NgpTpp1Preco = new decimal[1] ;
         P007Q15_A445NgpPreco = new decimal[1] ;
         P007Q15_A446NgpQtde = new int[1] ;
         P007Q15_A447NgpTotal = new decimal[1] ;
         P007Q15_A453NgpObs = new string[] {""} ;
         P007Q15_A578NgpDel = new bool[] {false} ;
         P007Q15_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007Q15_n579NgpDelDataHora = new bool[] {false} ;
         P007Q15_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         P007Q15_n580NgpDelData = new bool[] {false} ;
         P007Q15_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         P007Q15_n581NgpDelHora = new bool[] {false} ;
         P007Q15_A582NgpDelUsuId = new string[] {""} ;
         P007Q15_n582NgpDelUsuId = new bool[] {false} ;
         P007Q15_A583NgpDelUsuNome = new string[] {""} ;
         P007Q15_n583NgpDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditnegociopjestrutura__default(),
            new Object[][] {
                new Object[] {
               P007Q3_A345NegID, P007Q3_A356NegCodigo, P007Q3_A346NegInsData, P007Q3_A347NegInsHora, P007Q3_A348NegInsDataHora, P007Q3_A349NegInsUsuID, P007Q3_n349NegInsUsuID, P007Q3_A364NegInsUsuNome, P007Q3_n364NegInsUsuNome, P007Q3_A350NegCliID,
               P007Q3_A473NegCliMatricula, P007Q3_A351NegCliNomeFamiliar, P007Q3_A352NegCpjID, P007Q3_A353NegCpjNomFan, P007Q3_A354NegCpjRazSocial, P007Q3_A355NegCpjMatricula, P007Q3_A357NegPjtID, P007Q3_A358NegPjtSigla, P007Q3_A359NegPjtNome, P007Q3_A369NegCpjEndSeq,
               P007Q3_A370NegCpjEndNome, P007Q3_A371NegCpjEndEndereco, P007Q3_A372NegCpjEndNumero, P007Q3_A373NegCpjEndComplem, P007Q3_n373NegCpjEndComplem, P007Q3_A374NegCpjEndBairro, P007Q3_A375NegCpjEndMunID, P007Q3_A376NegCpjEndMunNome, P007Q3_A377NegCpjEndUFID, P007Q3_A378NegCpjEndUFSigla,
               P007Q3_A379NegCpjEndUFNome, P007Q3_A360NegAgcID, P007Q3_n360NegAgcID, P007Q3_A361NegAgcNome, P007Q3_n361NegAgcNome, P007Q3_A362NegAssunto, P007Q3_A363NegDescricao, P007Q3_A386NegUltFase, P007Q3_A474NegUltNgfSeq, P007Q3_A420NegUltIteID,
               P007Q3_A421NegUltIteNome, P007Q3_A479NegUltIteOrdem, P007Q3_A380NegValorEstimado, P007Q3_A385NegValorAtualizado, P007Q3_A454NegUltItem, P007Q3_n454NegUltItem, P007Q3_A572NegDel, P007Q3_A573NegDelDataHora, P007Q3_n573NegDelDataHora, P007Q3_A574NegDelData,
               P007Q3_n574NegDelData, P007Q3_A575NegDelHora, P007Q3_n575NegDelHora, P007Q3_A576NegDelUsuId, P007Q3_n576NegDelUsuId, P007Q3_A577NegDelUsuNome, P007Q3_n577NegDelUsuNome, P007Q3_A448NegPgpTotal, P007Q3_n448NegPgpTotal
               }
               , new Object[] {
               P007Q4_A345NegID, P007Q4_A387NgfSeq, P007Q4_A388NgfInsData, P007Q4_A389NgfInsHora, P007Q4_A390NgfInsDataHora, P007Q4_A391NgfInsUsuID, P007Q4_n391NgfInsUsuID, P007Q4_A392NgfInsUsuNome, P007Q4_n392NgfInsUsuNome, P007Q4_A395NgfIteID,
               P007Q4_A396NgfIteOrdem, P007Q4_A397NgfIteNome, P007Q4_A425NgfFimData, P007Q4_n425NgfFimData, P007Q4_A426NgfFimHora, P007Q4_n426NgfFimHora, P007Q4_A427NgfFimDataHora, P007Q4_n427NgfFimDataHora, P007Q4_A428NgfFimUsuID, P007Q4_n428NgfFimUsuID,
               P007Q4_A429NgfFimUsuNome, P007Q4_n429NgfFimUsuNome, P007Q4_A430NgfStatus, P007Q4_n430NgfStatus, P007Q4_A584NgfDel, P007Q4_A585NgfDelDataHora, P007Q4_n585NgfDelDataHora, P007Q4_A586NgfDelData, P007Q4_n586NgfDelData, P007Q4_A587NgfDelHora,
               P007Q4_n587NgfDelHora, P007Q4_A588NgfDelUsuId, P007Q4_n588NgfDelUsuId, P007Q4_A589NgfDelUsuNome, P007Q4_n589NgfDelUsuNome
               }
               , new Object[] {
               P007Q5_A345NegID, P007Q5_A435NgpItem, P007Q5_A455NgpInsData, P007Q5_A456NgpInsHora, P007Q5_A457NgpInsDataHora, P007Q5_A458NgpInsUsuID, P007Q5_n458NgpInsUsuID, P007Q5_A459NgpInsUsuNome, P007Q5_n459NgpInsUsuNome, P007Q5_A478NgpTppID,
               P007Q5_A439NgpTppPrdID, P007Q5_A440NgpTppPrdCodigo, P007Q5_A441NgpTppPrdNome, P007Q5_A442NgpTppPrdTipoID, P007Q5_A443NgpTppPrdAtivo, P007Q5_A444NgpTpp1Preco, P007Q5_A445NgpPreco, P007Q5_A446NgpQtde, P007Q5_A447NgpTotal, P007Q5_A453NgpObs,
               P007Q5_A578NgpDel, P007Q5_A579NgpDelDataHora, P007Q5_n579NgpDelDataHora, P007Q5_A580NgpDelData, P007Q5_n580NgpDelData, P007Q5_A581NgpDelHora, P007Q5_n581NgpDelHora, P007Q5_A582NgpDelUsuId, P007Q5_n582NgpDelUsuId, P007Q5_A583NgpDelUsuNome,
               P007Q5_n583NgpDelUsuNome
               }
               , new Object[] {
               P007Q9_A345NegID, P007Q9_A356NegCodigo, P007Q9_A346NegInsData, P007Q9_A347NegInsHora, P007Q9_A348NegInsDataHora, P007Q9_A349NegInsUsuID, P007Q9_n349NegInsUsuID, P007Q9_A364NegInsUsuNome, P007Q9_n364NegInsUsuNome, P007Q9_A350NegCliID,
               P007Q9_A473NegCliMatricula, P007Q9_A351NegCliNomeFamiliar, P007Q9_A352NegCpjID, P007Q9_A353NegCpjNomFan, P007Q9_A354NegCpjRazSocial, P007Q9_A355NegCpjMatricula, P007Q9_A357NegPjtID, P007Q9_A358NegPjtSigla, P007Q9_A359NegPjtNome, P007Q9_A369NegCpjEndSeq,
               P007Q9_A370NegCpjEndNome, P007Q9_A371NegCpjEndEndereco, P007Q9_A372NegCpjEndNumero, P007Q9_A373NegCpjEndComplem, P007Q9_n373NegCpjEndComplem, P007Q9_A374NegCpjEndBairro, P007Q9_A375NegCpjEndMunID, P007Q9_A376NegCpjEndMunNome, P007Q9_A377NegCpjEndUFID, P007Q9_A378NegCpjEndUFSigla,
               P007Q9_A379NegCpjEndUFNome, P007Q9_A360NegAgcID, P007Q9_n360NegAgcID, P007Q9_A361NegAgcNome, P007Q9_n361NegAgcNome, P007Q9_A362NegAssunto, P007Q9_A363NegDescricao, P007Q9_A386NegUltFase, P007Q9_A474NegUltNgfSeq, P007Q9_A420NegUltIteID,
               P007Q9_A421NegUltIteNome, P007Q9_A479NegUltIteOrdem, P007Q9_A380NegValorEstimado, P007Q9_A385NegValorAtualizado, P007Q9_A454NegUltItem, P007Q9_n454NegUltItem, P007Q9_A572NegDel, P007Q9_A573NegDelDataHora, P007Q9_n573NegDelDataHora, P007Q9_A574NegDelData,
               P007Q9_n574NegDelData, P007Q9_A575NegDelHora, P007Q9_n575NegDelHora, P007Q9_A576NegDelUsuId, P007Q9_n576NegDelUsuId, P007Q9_A577NegDelUsuNome, P007Q9_n577NegDelUsuNome, P007Q9_A448NegPgpTotal, P007Q9_n448NegPgpTotal, P007Q9_A40000GXC1,
               P007Q9_n40000GXC1, P007Q9_A40001GXC2, P007Q9_n40001GXC2
               }
               , new Object[] {
               P007Q10_A345NegID, P007Q10_A387NgfSeq, P007Q10_A388NgfInsData, P007Q10_A389NgfInsHora, P007Q10_A390NgfInsDataHora, P007Q10_A391NgfInsUsuID, P007Q10_n391NgfInsUsuID, P007Q10_A392NgfInsUsuNome, P007Q10_n392NgfInsUsuNome, P007Q10_A395NgfIteID,
               P007Q10_A396NgfIteOrdem, P007Q10_A397NgfIteNome, P007Q10_A425NgfFimData, P007Q10_n425NgfFimData, P007Q10_A426NgfFimHora, P007Q10_n426NgfFimHora, P007Q10_A427NgfFimDataHora, P007Q10_n427NgfFimDataHora, P007Q10_A428NgfFimUsuID, P007Q10_n428NgfFimUsuID,
               P007Q10_A429NgfFimUsuNome, P007Q10_n429NgfFimUsuNome, P007Q10_A430NgfStatus, P007Q10_n430NgfStatus, P007Q10_A584NgfDel, P007Q10_A585NgfDelDataHora, P007Q10_n585NgfDelDataHora, P007Q10_A586NgfDelData, P007Q10_n586NgfDelData, P007Q10_A587NgfDelHora,
               P007Q10_n587NgfDelHora, P007Q10_A588NgfDelUsuId, P007Q10_n588NgfDelUsuId, P007Q10_A589NgfDelUsuNome, P007Q10_n589NgfDelUsuNome
               }
               , new Object[] {
               P007Q11_A345NegID, P007Q11_A435NgpItem, P007Q11_A455NgpInsData, P007Q11_A456NgpInsHora, P007Q11_A457NgpInsDataHora, P007Q11_A458NgpInsUsuID, P007Q11_n458NgpInsUsuID, P007Q11_A459NgpInsUsuNome, P007Q11_n459NgpInsUsuNome, P007Q11_A478NgpTppID,
               P007Q11_A439NgpTppPrdID, P007Q11_A440NgpTppPrdCodigo, P007Q11_A441NgpTppPrdNome, P007Q11_A442NgpTppPrdTipoID, P007Q11_A443NgpTppPrdAtivo, P007Q11_A444NgpTpp1Preco, P007Q11_A445NgpPreco, P007Q11_A446NgpQtde, P007Q11_A447NgpTotal, P007Q11_A453NgpObs,
               P007Q11_A578NgpDel, P007Q11_A579NgpDelDataHora, P007Q11_n579NgpDelDataHora, P007Q11_A580NgpDelData, P007Q11_n580NgpDelData, P007Q11_A581NgpDelHora, P007Q11_n581NgpDelHora, P007Q11_A582NgpDelUsuId, P007Q11_n582NgpDelUsuId, P007Q11_A583NgpDelUsuNome,
               P007Q11_n583NgpDelUsuNome
               }
               , new Object[] {
               P007Q12_A345NegID, P007Q12_A387NgfSeq, P007Q12_A388NgfInsData, P007Q12_A389NgfInsHora, P007Q12_A390NgfInsDataHora, P007Q12_A391NgfInsUsuID, P007Q12_n391NgfInsUsuID, P007Q12_A392NgfInsUsuNome, P007Q12_n392NgfInsUsuNome, P007Q12_A395NgfIteID,
               P007Q12_A396NgfIteOrdem, P007Q12_A397NgfIteNome, P007Q12_A425NgfFimData, P007Q12_n425NgfFimData, P007Q12_A426NgfFimHora, P007Q12_n426NgfFimHora, P007Q12_A427NgfFimDataHora, P007Q12_n427NgfFimDataHora, P007Q12_A428NgfFimUsuID, P007Q12_n428NgfFimUsuID,
               P007Q12_A429NgfFimUsuNome, P007Q12_n429NgfFimUsuNome, P007Q12_A430NgfStatus, P007Q12_n430NgfStatus, P007Q12_A584NgfDel, P007Q12_A585NgfDelDataHora, P007Q12_n585NgfDelDataHora, P007Q12_A586NgfDelData, P007Q12_n586NgfDelData, P007Q12_A587NgfDelHora,
               P007Q12_n587NgfDelHora, P007Q12_A588NgfDelUsuId, P007Q12_n588NgfDelUsuId, P007Q12_A589NgfDelUsuNome, P007Q12_n589NgfDelUsuNome
               }
               , new Object[] {
               P007Q13_A345NegID, P007Q13_A435NgpItem, P007Q13_A455NgpInsData, P007Q13_A456NgpInsHora, P007Q13_A457NgpInsDataHora, P007Q13_A458NgpInsUsuID, P007Q13_n458NgpInsUsuID, P007Q13_A459NgpInsUsuNome, P007Q13_n459NgpInsUsuNome, P007Q13_A478NgpTppID,
               P007Q13_A439NgpTppPrdID, P007Q13_A440NgpTppPrdCodigo, P007Q13_A441NgpTppPrdNome, P007Q13_A442NgpTppPrdTipoID, P007Q13_A443NgpTppPrdAtivo, P007Q13_A444NgpTpp1Preco, P007Q13_A445NgpPreco, P007Q13_A446NgpQtde, P007Q13_A447NgpTotal, P007Q13_A453NgpObs,
               P007Q13_A578NgpDel, P007Q13_A579NgpDelDataHora, P007Q13_n579NgpDelDataHora, P007Q13_A580NgpDelData, P007Q13_n580NgpDelData, P007Q13_A581NgpDelHora, P007Q13_n581NgpDelHora, P007Q13_A582NgpDelUsuId, P007Q13_n582NgpDelUsuId, P007Q13_A583NgpDelUsuNome,
               P007Q13_n583NgpDelUsuNome
               }
               , new Object[] {
               P007Q14_A345NegID, P007Q14_A387NgfSeq, P007Q14_A388NgfInsData, P007Q14_A389NgfInsHora, P007Q14_A390NgfInsDataHora, P007Q14_A391NgfInsUsuID, P007Q14_n391NgfInsUsuID, P007Q14_A392NgfInsUsuNome, P007Q14_n392NgfInsUsuNome, P007Q14_A395NgfIteID,
               P007Q14_A396NgfIteOrdem, P007Q14_A397NgfIteNome, P007Q14_A425NgfFimData, P007Q14_n425NgfFimData, P007Q14_A426NgfFimHora, P007Q14_n426NgfFimHora, P007Q14_A427NgfFimDataHora, P007Q14_n427NgfFimDataHora, P007Q14_A428NgfFimUsuID, P007Q14_n428NgfFimUsuID,
               P007Q14_A429NgfFimUsuNome, P007Q14_n429NgfFimUsuNome, P007Q14_A430NgfStatus, P007Q14_n430NgfStatus, P007Q14_A584NgfDel, P007Q14_A585NgfDelDataHora, P007Q14_n585NgfDelDataHora, P007Q14_A586NgfDelData, P007Q14_n586NgfDelData, P007Q14_A587NgfDelHora,
               P007Q14_n587NgfDelHora, P007Q14_A588NgfDelUsuId, P007Q14_n588NgfDelUsuId, P007Q14_A589NgfDelUsuNome, P007Q14_n589NgfDelUsuNome
               }
               , new Object[] {
               P007Q15_A345NegID, P007Q15_A435NgpItem, P007Q15_A455NgpInsData, P007Q15_A456NgpInsHora, P007Q15_A457NgpInsDataHora, P007Q15_A458NgpInsUsuID, P007Q15_n458NgpInsUsuID, P007Q15_A459NgpInsUsuNome, P007Q15_n459NgpInsUsuNome, P007Q15_A478NgpTppID,
               P007Q15_A439NgpTppPrdID, P007Q15_A440NgpTppPrdCodigo, P007Q15_A441NgpTppPrdNome, P007Q15_A442NgpTppPrdTipoID, P007Q15_A443NgpTppPrdAtivo, P007Q15_A444NgpTpp1Preco, P007Q15_A445NgpPreco, P007Q15_A446NgpQtde, P007Q15_A447NgpTotal, P007Q15_A453NgpObs,
               P007Q15_A578NgpDel, P007Q15_A579NgpDelDataHora, P007Q15_n579NgpDelDataHora, P007Q15_A580NgpDelData, P007Q15_n580NgpDelData, P007Q15_A581NgpDelHora, P007Q15_n581NgpDelHora, P007Q15_A582NgpDelUsuId, P007Q15_n582NgpDelUsuId, P007Q15_A583NgpDelUsuNome,
               P007Q15_n583NgpDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A369NegCpjEndSeq ;
      private short A377NegCpjEndUFID ;
      private short A479NegUltIteOrdem ;
      private short AV22CountUpdatedNgfSeq ;
      private short AV25CountUpdatedNgpItem ;
      private short AV21CountKeyAttributes ;
      private short AV37GXLvl1705 ;
      private short AV40GXLvl1795 ;
      private int A357NegPjtID ;
      private int A375NegCpjEndMunID ;
      private int A386NegUltFase ;
      private int A474NegUltNgfSeq ;
      private int A454NegUltItem ;
      private int A387NgfSeq ;
      private int A396NgfIteOrdem ;
      private int A435NgpItem ;
      private int A442NgpTppPrdTipoID ;
      private int A446NgpQtde ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int AV34GXV1 ;
      private int AV35GXV2 ;
      private int AV36GXV3 ;
      private int AV23KeyNgfSeq ;
      private int AV38GXV4 ;
      private int AV39GXV5 ;
      private int AV26KeyNgpItem ;
      private int AV41GXV6 ;
      private int AV43GXV7 ;
      private int AV44GXV8 ;
      private int AV45GXV9 ;
      private int AV47GXV10 ;
      private int AV48GXV11 ;
      private int AV49GXV12 ;
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
      private string A391NgfInsUsuID ;
      private string A428NgfFimUsuID ;
      private string A588NgfDelUsuId ;
      private string A458NgpInsUsuID ;
      private string A582NgpDelUsuId ;
      private DateTime A347NegInsHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime A573NegDelDataHora ;
      private DateTime A574NegDelData ;
      private DateTime A575NegDelHora ;
      private DateTime A389NgfInsHora ;
      private DateTime A390NgfInsDataHora ;
      private DateTime A426NgfFimHora ;
      private DateTime A427NgfFimDataHora ;
      private DateTime A585NgfDelDataHora ;
      private DateTime A586NgfDelData ;
      private DateTime A587NgfDelHora ;
      private DateTime A456NgpInsHora ;
      private DateTime A457NgpInsDataHora ;
      private DateTime A579NgpDelDataHora ;
      private DateTime A580NgpDelData ;
      private DateTime A581NgpDelHora ;
      private DateTime A346NegInsData ;
      private DateTime A388NgfInsData ;
      private DateTime A425NgfFimData ;
      private DateTime A455NgpInsData ;
      private bool returnInSub ;
      private bool n349NegInsUsuID ;
      private bool n364NegInsUsuNome ;
      private bool n373NegCpjEndComplem ;
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
      private bool n391NgfInsUsuID ;
      private bool n392NgfInsUsuNome ;
      private bool n425NgfFimData ;
      private bool n426NgfFimHora ;
      private bool n427NgfFimDataHora ;
      private bool n428NgfFimUsuID ;
      private bool n429NgfFimUsuNome ;
      private bool n430NgfStatus ;
      private bool A584NgfDel ;
      private bool n585NgfDelDataHora ;
      private bool n586NgfDelData ;
      private bool n587NgfDelHora ;
      private bool n588NgfDelUsuId ;
      private bool n589NgfDelUsuNome ;
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
      private bool n40001GXC2 ;
      private bool AV24RecordExistsNgfSeq ;
      private bool AV27RecordExistsNgpItem ;
      private string A363NegDescricao ;
      private string A364NegInsUsuNome ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A354NegCpjRazSocial ;
      private string A358NegPjtSigla ;
      private string A359NegPjtNome ;
      private string A370NegCpjEndNome ;
      private string A371NegCpjEndEndereco ;
      private string A372NegCpjEndNumero ;
      private string A373NegCpjEndComplem ;
      private string A374NegCpjEndBairro ;
      private string A376NegCpjEndMunNome ;
      private string A378NegCpjEndUFSigla ;
      private string A379NegCpjEndUFNome ;
      private string A361NegAgcNome ;
      private string A362NegAssunto ;
      private string A421NegUltIteNome ;
      private string A577NegDelUsuNome ;
      private string A392NgfInsUsuNome ;
      private string A397NgfIteNome ;
      private string A429NgfFimUsuNome ;
      private string A430NgfStatus ;
      private string A589NgfDelUsuNome ;
      private string A459NgpInsUsuNome ;
      private string A440NgpTppPrdCodigo ;
      private string A441NgpTppPrdNome ;
      private string A453NgpObs ;
      private string A583NgpDelUsuNome ;
      private Guid AV17NegID ;
      private Guid A345NegID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A420NegUltIteID ;
      private Guid A395NgfIteID ;
      private Guid A478NgpTppID ;
      private Guid A439NgpTppPrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007Q3_A345NegID ;
      private long[] P007Q3_A356NegCodigo ;
      private DateTime[] P007Q3_A346NegInsData ;
      private DateTime[] P007Q3_A347NegInsHora ;
      private DateTime[] P007Q3_A348NegInsDataHora ;
      private string[] P007Q3_A349NegInsUsuID ;
      private bool[] P007Q3_n349NegInsUsuID ;
      private string[] P007Q3_A364NegInsUsuNome ;
      private bool[] P007Q3_n364NegInsUsuNome ;
      private Guid[] P007Q3_A350NegCliID ;
      private long[] P007Q3_A473NegCliMatricula ;
      private string[] P007Q3_A351NegCliNomeFamiliar ;
      private Guid[] P007Q3_A352NegCpjID ;
      private string[] P007Q3_A353NegCpjNomFan ;
      private string[] P007Q3_A354NegCpjRazSocial ;
      private long[] P007Q3_A355NegCpjMatricula ;
      private int[] P007Q3_A357NegPjtID ;
      private string[] P007Q3_A358NegPjtSigla ;
      private string[] P007Q3_A359NegPjtNome ;
      private short[] P007Q3_A369NegCpjEndSeq ;
      private string[] P007Q3_A370NegCpjEndNome ;
      private string[] P007Q3_A371NegCpjEndEndereco ;
      private string[] P007Q3_A372NegCpjEndNumero ;
      private string[] P007Q3_A373NegCpjEndComplem ;
      private bool[] P007Q3_n373NegCpjEndComplem ;
      private string[] P007Q3_A374NegCpjEndBairro ;
      private int[] P007Q3_A375NegCpjEndMunID ;
      private string[] P007Q3_A376NegCpjEndMunNome ;
      private short[] P007Q3_A377NegCpjEndUFID ;
      private string[] P007Q3_A378NegCpjEndUFSigla ;
      private string[] P007Q3_A379NegCpjEndUFNome ;
      private string[] P007Q3_A360NegAgcID ;
      private bool[] P007Q3_n360NegAgcID ;
      private string[] P007Q3_A361NegAgcNome ;
      private bool[] P007Q3_n361NegAgcNome ;
      private string[] P007Q3_A362NegAssunto ;
      private string[] P007Q3_A363NegDescricao ;
      private int[] P007Q3_A386NegUltFase ;
      private int[] P007Q3_A474NegUltNgfSeq ;
      private Guid[] P007Q3_A420NegUltIteID ;
      private string[] P007Q3_A421NegUltIteNome ;
      private short[] P007Q3_A479NegUltIteOrdem ;
      private decimal[] P007Q3_A380NegValorEstimado ;
      private decimal[] P007Q3_A385NegValorAtualizado ;
      private int[] P007Q3_A454NegUltItem ;
      private bool[] P007Q3_n454NegUltItem ;
      private bool[] P007Q3_A572NegDel ;
      private DateTime[] P007Q3_A573NegDelDataHora ;
      private bool[] P007Q3_n573NegDelDataHora ;
      private DateTime[] P007Q3_A574NegDelData ;
      private bool[] P007Q3_n574NegDelData ;
      private DateTime[] P007Q3_A575NegDelHora ;
      private bool[] P007Q3_n575NegDelHora ;
      private string[] P007Q3_A576NegDelUsuId ;
      private bool[] P007Q3_n576NegDelUsuId ;
      private string[] P007Q3_A577NegDelUsuNome ;
      private bool[] P007Q3_n577NegDelUsuNome ;
      private decimal[] P007Q3_A448NegPgpTotal ;
      private bool[] P007Q3_n448NegPgpTotal ;
      private Guid[] P007Q4_A345NegID ;
      private int[] P007Q4_A387NgfSeq ;
      private DateTime[] P007Q4_A388NgfInsData ;
      private DateTime[] P007Q4_A389NgfInsHora ;
      private DateTime[] P007Q4_A390NgfInsDataHora ;
      private string[] P007Q4_A391NgfInsUsuID ;
      private bool[] P007Q4_n391NgfInsUsuID ;
      private string[] P007Q4_A392NgfInsUsuNome ;
      private bool[] P007Q4_n392NgfInsUsuNome ;
      private Guid[] P007Q4_A395NgfIteID ;
      private int[] P007Q4_A396NgfIteOrdem ;
      private string[] P007Q4_A397NgfIteNome ;
      private DateTime[] P007Q4_A425NgfFimData ;
      private bool[] P007Q4_n425NgfFimData ;
      private DateTime[] P007Q4_A426NgfFimHora ;
      private bool[] P007Q4_n426NgfFimHora ;
      private DateTime[] P007Q4_A427NgfFimDataHora ;
      private bool[] P007Q4_n427NgfFimDataHora ;
      private string[] P007Q4_A428NgfFimUsuID ;
      private bool[] P007Q4_n428NgfFimUsuID ;
      private string[] P007Q4_A429NgfFimUsuNome ;
      private bool[] P007Q4_n429NgfFimUsuNome ;
      private string[] P007Q4_A430NgfStatus ;
      private bool[] P007Q4_n430NgfStatus ;
      private bool[] P007Q4_A584NgfDel ;
      private DateTime[] P007Q4_A585NgfDelDataHora ;
      private bool[] P007Q4_n585NgfDelDataHora ;
      private DateTime[] P007Q4_A586NgfDelData ;
      private bool[] P007Q4_n586NgfDelData ;
      private DateTime[] P007Q4_A587NgfDelHora ;
      private bool[] P007Q4_n587NgfDelHora ;
      private string[] P007Q4_A588NgfDelUsuId ;
      private bool[] P007Q4_n588NgfDelUsuId ;
      private string[] P007Q4_A589NgfDelUsuNome ;
      private bool[] P007Q4_n589NgfDelUsuNome ;
      private Guid[] P007Q5_A345NegID ;
      private int[] P007Q5_A435NgpItem ;
      private DateTime[] P007Q5_A455NgpInsData ;
      private DateTime[] P007Q5_A456NgpInsHora ;
      private DateTime[] P007Q5_A457NgpInsDataHora ;
      private string[] P007Q5_A458NgpInsUsuID ;
      private bool[] P007Q5_n458NgpInsUsuID ;
      private string[] P007Q5_A459NgpInsUsuNome ;
      private bool[] P007Q5_n459NgpInsUsuNome ;
      private Guid[] P007Q5_A478NgpTppID ;
      private Guid[] P007Q5_A439NgpTppPrdID ;
      private string[] P007Q5_A440NgpTppPrdCodigo ;
      private string[] P007Q5_A441NgpTppPrdNome ;
      private int[] P007Q5_A442NgpTppPrdTipoID ;
      private bool[] P007Q5_A443NgpTppPrdAtivo ;
      private decimal[] P007Q5_A444NgpTpp1Preco ;
      private decimal[] P007Q5_A445NgpPreco ;
      private int[] P007Q5_A446NgpQtde ;
      private decimal[] P007Q5_A447NgpTotal ;
      private string[] P007Q5_A453NgpObs ;
      private bool[] P007Q5_A578NgpDel ;
      private DateTime[] P007Q5_A579NgpDelDataHora ;
      private bool[] P007Q5_n579NgpDelDataHora ;
      private DateTime[] P007Q5_A580NgpDelData ;
      private bool[] P007Q5_n580NgpDelData ;
      private DateTime[] P007Q5_A581NgpDelHora ;
      private bool[] P007Q5_n581NgpDelHora ;
      private string[] P007Q5_A582NgpDelUsuId ;
      private bool[] P007Q5_n582NgpDelUsuId ;
      private string[] P007Q5_A583NgpDelUsuNome ;
      private bool[] P007Q5_n583NgpDelUsuNome ;
      private Guid[] P007Q9_A345NegID ;
      private long[] P007Q9_A356NegCodigo ;
      private DateTime[] P007Q9_A346NegInsData ;
      private DateTime[] P007Q9_A347NegInsHora ;
      private DateTime[] P007Q9_A348NegInsDataHora ;
      private string[] P007Q9_A349NegInsUsuID ;
      private bool[] P007Q9_n349NegInsUsuID ;
      private string[] P007Q9_A364NegInsUsuNome ;
      private bool[] P007Q9_n364NegInsUsuNome ;
      private Guid[] P007Q9_A350NegCliID ;
      private long[] P007Q9_A473NegCliMatricula ;
      private string[] P007Q9_A351NegCliNomeFamiliar ;
      private Guid[] P007Q9_A352NegCpjID ;
      private string[] P007Q9_A353NegCpjNomFan ;
      private string[] P007Q9_A354NegCpjRazSocial ;
      private long[] P007Q9_A355NegCpjMatricula ;
      private int[] P007Q9_A357NegPjtID ;
      private string[] P007Q9_A358NegPjtSigla ;
      private string[] P007Q9_A359NegPjtNome ;
      private short[] P007Q9_A369NegCpjEndSeq ;
      private string[] P007Q9_A370NegCpjEndNome ;
      private string[] P007Q9_A371NegCpjEndEndereco ;
      private string[] P007Q9_A372NegCpjEndNumero ;
      private string[] P007Q9_A373NegCpjEndComplem ;
      private bool[] P007Q9_n373NegCpjEndComplem ;
      private string[] P007Q9_A374NegCpjEndBairro ;
      private int[] P007Q9_A375NegCpjEndMunID ;
      private string[] P007Q9_A376NegCpjEndMunNome ;
      private short[] P007Q9_A377NegCpjEndUFID ;
      private string[] P007Q9_A378NegCpjEndUFSigla ;
      private string[] P007Q9_A379NegCpjEndUFNome ;
      private string[] P007Q9_A360NegAgcID ;
      private bool[] P007Q9_n360NegAgcID ;
      private string[] P007Q9_A361NegAgcNome ;
      private bool[] P007Q9_n361NegAgcNome ;
      private string[] P007Q9_A362NegAssunto ;
      private string[] P007Q9_A363NegDescricao ;
      private int[] P007Q9_A386NegUltFase ;
      private int[] P007Q9_A474NegUltNgfSeq ;
      private Guid[] P007Q9_A420NegUltIteID ;
      private string[] P007Q9_A421NegUltIteNome ;
      private short[] P007Q9_A479NegUltIteOrdem ;
      private decimal[] P007Q9_A380NegValorEstimado ;
      private decimal[] P007Q9_A385NegValorAtualizado ;
      private int[] P007Q9_A454NegUltItem ;
      private bool[] P007Q9_n454NegUltItem ;
      private bool[] P007Q9_A572NegDel ;
      private DateTime[] P007Q9_A573NegDelDataHora ;
      private bool[] P007Q9_n573NegDelDataHora ;
      private DateTime[] P007Q9_A574NegDelData ;
      private bool[] P007Q9_n574NegDelData ;
      private DateTime[] P007Q9_A575NegDelHora ;
      private bool[] P007Q9_n575NegDelHora ;
      private string[] P007Q9_A576NegDelUsuId ;
      private bool[] P007Q9_n576NegDelUsuId ;
      private string[] P007Q9_A577NegDelUsuNome ;
      private bool[] P007Q9_n577NegDelUsuNome ;
      private decimal[] P007Q9_A448NegPgpTotal ;
      private bool[] P007Q9_n448NegPgpTotal ;
      private int[] P007Q9_A40000GXC1 ;
      private bool[] P007Q9_n40000GXC1 ;
      private int[] P007Q9_A40001GXC2 ;
      private bool[] P007Q9_n40001GXC2 ;
      private Guid[] P007Q10_A345NegID ;
      private int[] P007Q10_A387NgfSeq ;
      private DateTime[] P007Q10_A388NgfInsData ;
      private DateTime[] P007Q10_A389NgfInsHora ;
      private DateTime[] P007Q10_A390NgfInsDataHora ;
      private string[] P007Q10_A391NgfInsUsuID ;
      private bool[] P007Q10_n391NgfInsUsuID ;
      private string[] P007Q10_A392NgfInsUsuNome ;
      private bool[] P007Q10_n392NgfInsUsuNome ;
      private Guid[] P007Q10_A395NgfIteID ;
      private int[] P007Q10_A396NgfIteOrdem ;
      private string[] P007Q10_A397NgfIteNome ;
      private DateTime[] P007Q10_A425NgfFimData ;
      private bool[] P007Q10_n425NgfFimData ;
      private DateTime[] P007Q10_A426NgfFimHora ;
      private bool[] P007Q10_n426NgfFimHora ;
      private DateTime[] P007Q10_A427NgfFimDataHora ;
      private bool[] P007Q10_n427NgfFimDataHora ;
      private string[] P007Q10_A428NgfFimUsuID ;
      private bool[] P007Q10_n428NgfFimUsuID ;
      private string[] P007Q10_A429NgfFimUsuNome ;
      private bool[] P007Q10_n429NgfFimUsuNome ;
      private string[] P007Q10_A430NgfStatus ;
      private bool[] P007Q10_n430NgfStatus ;
      private bool[] P007Q10_A584NgfDel ;
      private DateTime[] P007Q10_A585NgfDelDataHora ;
      private bool[] P007Q10_n585NgfDelDataHora ;
      private DateTime[] P007Q10_A586NgfDelData ;
      private bool[] P007Q10_n586NgfDelData ;
      private DateTime[] P007Q10_A587NgfDelHora ;
      private bool[] P007Q10_n587NgfDelHora ;
      private string[] P007Q10_A588NgfDelUsuId ;
      private bool[] P007Q10_n588NgfDelUsuId ;
      private string[] P007Q10_A589NgfDelUsuNome ;
      private bool[] P007Q10_n589NgfDelUsuNome ;
      private Guid[] P007Q11_A345NegID ;
      private int[] P007Q11_A435NgpItem ;
      private DateTime[] P007Q11_A455NgpInsData ;
      private DateTime[] P007Q11_A456NgpInsHora ;
      private DateTime[] P007Q11_A457NgpInsDataHora ;
      private string[] P007Q11_A458NgpInsUsuID ;
      private bool[] P007Q11_n458NgpInsUsuID ;
      private string[] P007Q11_A459NgpInsUsuNome ;
      private bool[] P007Q11_n459NgpInsUsuNome ;
      private Guid[] P007Q11_A478NgpTppID ;
      private Guid[] P007Q11_A439NgpTppPrdID ;
      private string[] P007Q11_A440NgpTppPrdCodigo ;
      private string[] P007Q11_A441NgpTppPrdNome ;
      private int[] P007Q11_A442NgpTppPrdTipoID ;
      private bool[] P007Q11_A443NgpTppPrdAtivo ;
      private decimal[] P007Q11_A444NgpTpp1Preco ;
      private decimal[] P007Q11_A445NgpPreco ;
      private int[] P007Q11_A446NgpQtde ;
      private decimal[] P007Q11_A447NgpTotal ;
      private string[] P007Q11_A453NgpObs ;
      private bool[] P007Q11_A578NgpDel ;
      private DateTime[] P007Q11_A579NgpDelDataHora ;
      private bool[] P007Q11_n579NgpDelDataHora ;
      private DateTime[] P007Q11_A580NgpDelData ;
      private bool[] P007Q11_n580NgpDelData ;
      private DateTime[] P007Q11_A581NgpDelHora ;
      private bool[] P007Q11_n581NgpDelHora ;
      private string[] P007Q11_A582NgpDelUsuId ;
      private bool[] P007Q11_n582NgpDelUsuId ;
      private string[] P007Q11_A583NgpDelUsuNome ;
      private bool[] P007Q11_n583NgpDelUsuNome ;
      private Guid[] P007Q12_A345NegID ;
      private int[] P007Q12_A387NgfSeq ;
      private DateTime[] P007Q12_A388NgfInsData ;
      private DateTime[] P007Q12_A389NgfInsHora ;
      private DateTime[] P007Q12_A390NgfInsDataHora ;
      private string[] P007Q12_A391NgfInsUsuID ;
      private bool[] P007Q12_n391NgfInsUsuID ;
      private string[] P007Q12_A392NgfInsUsuNome ;
      private bool[] P007Q12_n392NgfInsUsuNome ;
      private Guid[] P007Q12_A395NgfIteID ;
      private int[] P007Q12_A396NgfIteOrdem ;
      private string[] P007Q12_A397NgfIteNome ;
      private DateTime[] P007Q12_A425NgfFimData ;
      private bool[] P007Q12_n425NgfFimData ;
      private DateTime[] P007Q12_A426NgfFimHora ;
      private bool[] P007Q12_n426NgfFimHora ;
      private DateTime[] P007Q12_A427NgfFimDataHora ;
      private bool[] P007Q12_n427NgfFimDataHora ;
      private string[] P007Q12_A428NgfFimUsuID ;
      private bool[] P007Q12_n428NgfFimUsuID ;
      private string[] P007Q12_A429NgfFimUsuNome ;
      private bool[] P007Q12_n429NgfFimUsuNome ;
      private string[] P007Q12_A430NgfStatus ;
      private bool[] P007Q12_n430NgfStatus ;
      private bool[] P007Q12_A584NgfDel ;
      private DateTime[] P007Q12_A585NgfDelDataHora ;
      private bool[] P007Q12_n585NgfDelDataHora ;
      private DateTime[] P007Q12_A586NgfDelData ;
      private bool[] P007Q12_n586NgfDelData ;
      private DateTime[] P007Q12_A587NgfDelHora ;
      private bool[] P007Q12_n587NgfDelHora ;
      private string[] P007Q12_A588NgfDelUsuId ;
      private bool[] P007Q12_n588NgfDelUsuId ;
      private string[] P007Q12_A589NgfDelUsuNome ;
      private bool[] P007Q12_n589NgfDelUsuNome ;
      private Guid[] P007Q13_A345NegID ;
      private int[] P007Q13_A435NgpItem ;
      private DateTime[] P007Q13_A455NgpInsData ;
      private DateTime[] P007Q13_A456NgpInsHora ;
      private DateTime[] P007Q13_A457NgpInsDataHora ;
      private string[] P007Q13_A458NgpInsUsuID ;
      private bool[] P007Q13_n458NgpInsUsuID ;
      private string[] P007Q13_A459NgpInsUsuNome ;
      private bool[] P007Q13_n459NgpInsUsuNome ;
      private Guid[] P007Q13_A478NgpTppID ;
      private Guid[] P007Q13_A439NgpTppPrdID ;
      private string[] P007Q13_A440NgpTppPrdCodigo ;
      private string[] P007Q13_A441NgpTppPrdNome ;
      private int[] P007Q13_A442NgpTppPrdTipoID ;
      private bool[] P007Q13_A443NgpTppPrdAtivo ;
      private decimal[] P007Q13_A444NgpTpp1Preco ;
      private decimal[] P007Q13_A445NgpPreco ;
      private int[] P007Q13_A446NgpQtde ;
      private decimal[] P007Q13_A447NgpTotal ;
      private string[] P007Q13_A453NgpObs ;
      private bool[] P007Q13_A578NgpDel ;
      private DateTime[] P007Q13_A579NgpDelDataHora ;
      private bool[] P007Q13_n579NgpDelDataHora ;
      private DateTime[] P007Q13_A580NgpDelData ;
      private bool[] P007Q13_n580NgpDelData ;
      private DateTime[] P007Q13_A581NgpDelHora ;
      private bool[] P007Q13_n581NgpDelHora ;
      private string[] P007Q13_A582NgpDelUsuId ;
      private bool[] P007Q13_n582NgpDelUsuId ;
      private string[] P007Q13_A583NgpDelUsuNome ;
      private bool[] P007Q13_n583NgpDelUsuNome ;
      private Guid[] P007Q14_A345NegID ;
      private int[] P007Q14_A387NgfSeq ;
      private DateTime[] P007Q14_A388NgfInsData ;
      private DateTime[] P007Q14_A389NgfInsHora ;
      private DateTime[] P007Q14_A390NgfInsDataHora ;
      private string[] P007Q14_A391NgfInsUsuID ;
      private bool[] P007Q14_n391NgfInsUsuID ;
      private string[] P007Q14_A392NgfInsUsuNome ;
      private bool[] P007Q14_n392NgfInsUsuNome ;
      private Guid[] P007Q14_A395NgfIteID ;
      private int[] P007Q14_A396NgfIteOrdem ;
      private string[] P007Q14_A397NgfIteNome ;
      private DateTime[] P007Q14_A425NgfFimData ;
      private bool[] P007Q14_n425NgfFimData ;
      private DateTime[] P007Q14_A426NgfFimHora ;
      private bool[] P007Q14_n426NgfFimHora ;
      private DateTime[] P007Q14_A427NgfFimDataHora ;
      private bool[] P007Q14_n427NgfFimDataHora ;
      private string[] P007Q14_A428NgfFimUsuID ;
      private bool[] P007Q14_n428NgfFimUsuID ;
      private string[] P007Q14_A429NgfFimUsuNome ;
      private bool[] P007Q14_n429NgfFimUsuNome ;
      private string[] P007Q14_A430NgfStatus ;
      private bool[] P007Q14_n430NgfStatus ;
      private bool[] P007Q14_A584NgfDel ;
      private DateTime[] P007Q14_A585NgfDelDataHora ;
      private bool[] P007Q14_n585NgfDelDataHora ;
      private DateTime[] P007Q14_A586NgfDelData ;
      private bool[] P007Q14_n586NgfDelData ;
      private DateTime[] P007Q14_A587NgfDelHora ;
      private bool[] P007Q14_n587NgfDelHora ;
      private string[] P007Q14_A588NgfDelUsuId ;
      private bool[] P007Q14_n588NgfDelUsuId ;
      private string[] P007Q14_A589NgfDelUsuNome ;
      private bool[] P007Q14_n589NgfDelUsuNome ;
      private Guid[] P007Q15_A345NegID ;
      private int[] P007Q15_A435NgpItem ;
      private DateTime[] P007Q15_A455NgpInsData ;
      private DateTime[] P007Q15_A456NgpInsHora ;
      private DateTime[] P007Q15_A457NgpInsDataHora ;
      private string[] P007Q15_A458NgpInsUsuID ;
      private bool[] P007Q15_n458NgpInsUsuID ;
      private string[] P007Q15_A459NgpInsUsuNome ;
      private bool[] P007Q15_n459NgpInsUsuNome ;
      private Guid[] P007Q15_A478NgpTppID ;
      private Guid[] P007Q15_A439NgpTppPrdID ;
      private string[] P007Q15_A440NgpTppPrdCodigo ;
      private string[] P007Q15_A441NgpTppPrdNome ;
      private int[] P007Q15_A442NgpTppPrdTipoID ;
      private bool[] P007Q15_A443NgpTppPrdAtivo ;
      private decimal[] P007Q15_A444NgpTpp1Preco ;
      private decimal[] P007Q15_A445NgpPreco ;
      private int[] P007Q15_A446NgpQtde ;
      private decimal[] P007Q15_A447NgpTotal ;
      private string[] P007Q15_A453NgpObs ;
      private bool[] P007Q15_A578NgpDel ;
      private DateTime[] P007Q15_A579NgpDelDataHora ;
      private bool[] P007Q15_n579NgpDelDataHora ;
      private DateTime[] P007Q15_A580NgpDelData ;
      private bool[] P007Q15_n580NgpDelData ;
      private DateTime[] P007Q15_A581NgpDelHora ;
      private bool[] P007Q15_n581NgpDelHora ;
      private string[] P007Q15_A582NgpDelUsuId ;
      private bool[] P007Q15_n582NgpDelUsuId ;
      private string[] P007Q15_A583NgpDelUsuNome ;
      private bool[] P007Q15_n583NgpDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV18AuditingObjectNewRecords ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV19AuditingObjectRecordItemNew ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV20AuditingObjectRecordItemAttributeItemNew ;
   }

   public class loadauditnegociopjestrutura__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007Q3;
          prmP007Q3 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007Q4;
          prmP007Q4 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007Q5;
          prmP007Q5 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007Q9;
          prmP007Q9 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          string cmdBufferP007Q9;
          cmdBufferP007Q9=" SELECT T1.NegID, T1.NegCodigo, T1.NegInsData, T1.NegInsHora, T1.NegInsDataHora, T1.NegInsUsuID, T1.NegInsUsuNome, T1.NegCliID AS NegCliID, T3.CliMatricula AS NegCliMatricula, T1.NegCliNomeFamiliar AS NegCliNomeFamiliar, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T4.CpjTipoId AS NegPjtID, T5.PjtSigla AS NegPjtSigla, T1.NegPjtNome AS NegPjtNome, T1.NegCpjEndSeq AS NegCpjEndSeq, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, T1.NegAgcID, T1.NegAgcNome, T1.NegAssunto, T1.NegDescricao, T1.NegUltFase, T1.NegUltNgfSeq, T1.NegUltIteID, T1.NegUltIteNome, T1.NegUltIteOrdem, T1.NegValorEstimado, T1.NegValorAtualizado, T1.NegUltItem, T1.NegDel, T1.NegDelDataHora, T1.NegDelData, T1.NegDelHora, T1.NegDelUsuId, T1.NegDelUsuNome, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal, COALESCE( T7.GXC1, 0) AS GXC1, COALESCE( T8.GXC2, 0) AS GXC2 FROM (((((tb_negociopj T1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE T1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = T1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = T1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = T1.NegCliID AND T4.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = T1.NegCliID AND T6.CpjID = T1.NegCpjID AND T6.CpjEndSeq = T1.NegCpjEndSeq),  (SELECT COUNT(*) AS GXC1 FROM tb_negociopj_fase WHERE NegID = :AV17NegID "
          + " ) T7,  (SELECT COUNT(*) AS GXC2 FROM tb_negociopj_item WHERE NegID = :AV17NegID ) T8 WHERE T1.NegID = :AV17NegID ORDER BY T1.NegID" ;
          Object[] prmP007Q10;
          prmP007Q10 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007Q11;
          prmP007Q11 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007Q12;
          prmP007Q12 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV23KeyNgfSeq",GXType.Int32,8,0)
          };
          Object[] prmP007Q13;
          prmP007Q13 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV26KeyNgpItem",GXType.Int32,8,0)
          };
          Object[] prmP007Q14;
          prmP007Q14 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007Q15;
          prmP007Q15 = new Object[] {
          new ParDef("AV17NegID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Q3", "SELECT T1.NegID, T1.NegCodigo, T1.NegInsData, T1.NegInsHora, T1.NegInsDataHora, T1.NegInsUsuID, T1.NegInsUsuNome, T1.NegCliID AS NegCliID, T3.CliMatricula AS NegCliMatricula, T1.NegCliNomeFamiliar AS NegCliNomeFamiliar, T1.NegCpjID AS NegCpjID, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T4.CpjTipoId AS NegPjtID, T5.PjtSigla AS NegPjtSigla, T1.NegPjtNome AS NegPjtNome, T1.NegCpjEndSeq AS NegCpjEndSeq, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, T1.NegAgcID, T1.NegAgcNome, T1.NegAssunto, T1.NegDescricao, T1.NegUltFase, T1.NegUltNgfSeq, T1.NegUltIteID, T1.NegUltIteNome, T1.NegUltIteOrdem, T1.NegValorEstimado, T1.NegValorAtualizado, T1.NegUltItem, T1.NegDel, T1.NegDelDataHora, T1.NegDelData, T1.NegDelHora, T1.NegDelUsuId, T1.NegDelUsuNome, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal FROM (((((tb_negociopj T1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE T1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = T1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = T1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = T1.NegCliID AND T4.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = T1.NegCliID AND T6.CpjID = T1.NegCpjID AND T6.CpjEndSeq = T1.NegCpjEndSeq) WHERE T1.NegID = :AV17NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007Q4", "SELECT T1.NegID, T1.NgfSeq, T1.NgfInsData, T1.NgfInsHora, T1.NgfInsDataHora, T1.NgfInsUsuID, T1.NgfInsUsuNome, T1.NgfIteID AS NgfIteID, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfFimData, T1.NgfFimHora, T1.NgfFimDataHora, T1.NgfFimUsuID, T1.NgfFimUsuNome, T1.NgfStatus, T1.NgfDel, T1.NgfDelDataHora, T1.NgfDelData, T1.NgfDelHora, T1.NgfDelUsuId, T1.NgfDelUsuNome FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Q5", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Q9", cmdBufferP007Q9,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007Q10", "SELECT T1.NegID, T1.NgfSeq, T1.NgfInsData, T1.NgfInsHora, T1.NgfInsDataHora, T1.NgfInsUsuID, T1.NgfInsUsuNome, T1.NgfIteID AS NgfIteID, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfFimData, T1.NgfFimHora, T1.NgfFimDataHora, T1.NgfFimUsuID, T1.NgfFimUsuNome, T1.NgfStatus, T1.NgfDel, T1.NgfDelDataHora, T1.NgfDelData, T1.NgfDelHora, T1.NgfDelUsuId, T1.NgfDelUsuNome FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Q11", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Q12", "SELECT T1.NegID, T1.NgfSeq, T1.NgfInsData, T1.NgfInsHora, T1.NgfInsDataHora, T1.NgfInsUsuID, T1.NgfInsUsuNome, T1.NgfIteID AS NgfIteID, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfFimData, T1.NgfFimHora, T1.NgfFimDataHora, T1.NgfFimUsuID, T1.NgfFimUsuNome, T1.NgfStatus, T1.NgfDel, T1.NgfDelDataHora, T1.NgfDelData, T1.NgfDelHora, T1.NgfDelUsuId, T1.NgfDelUsuNome FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :NegID and T1.NgfSeq = :AV23KeyNgfSeq ORDER BY T1.NegID, T1.NgfSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Q13", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID and T1.NgpItem = :AV26KeyNgpItem ORDER BY T1.NegID, T1.NgpItem ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q13,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Q14", "SELECT T1.NegID, T1.NgfSeq, T1.NgfInsData, T1.NgfInsHora, T1.NgfInsDataHora, T1.NgfInsUsuID, T1.NgfInsUsuNome, T1.NgfIteID AS NgfIteID, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfFimData, T1.NgfFimHora, T1.NgfFimDataHora, T1.NgfFimUsuID, T1.NgfFimUsuNome, T1.NgfStatus, T1.NgfDel, T1.NgfDelDataHora, T1.NgfDelData, T1.NgfDelHora, T1.NgfDelUsuId, T1.NgfDelUsuNome FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :AV17NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q14,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Q15", "SELECT T1.NegID, T1.NgpItem, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsDataHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpTppID AS NgpTppID, T1.NgpTppPrdID AS NgpTppPrdID, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdTipoID AS NgpTppPrdTipoID, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpPreco, T1.NgpQtde, T1.NgpTotal, T1.NgpObs, T1.NgpDel, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :AV17NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q15,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((bool[]) buf[24])[0] = rslt.wasNull(22);
                ((string[]) buf[25])[0] = rslt.getVarchar(23);
                ((int[]) buf[26])[0] = rslt.getInt(24);
                ((string[]) buf[27])[0] = rslt.getVarchar(25);
                ((short[]) buf[28])[0] = rslt.getShort(26);
                ((string[]) buf[29])[0] = rslt.getVarchar(27);
                ((string[]) buf[30])[0] = rslt.getVarchar(28);
                ((string[]) buf[31])[0] = rslt.getString(29, 40);
                ((bool[]) buf[32])[0] = rslt.wasNull(29);
                ((string[]) buf[33])[0] = rslt.getVarchar(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((string[]) buf[35])[0] = rslt.getVarchar(31);
                ((string[]) buf[36])[0] = rslt.getLongVarchar(32);
                ((int[]) buf[37])[0] = rslt.getInt(33);
                ((int[]) buf[38])[0] = rslt.getInt(34);
                ((Guid[]) buf[39])[0] = rslt.getGuid(35);
                ((string[]) buf[40])[0] = rslt.getVarchar(36);
                ((short[]) buf[41])[0] = rslt.getShort(37);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(38);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(39);
                ((int[]) buf[44])[0] = rslt.getInt(40);
                ((bool[]) buf[45])[0] = rslt.wasNull(40);
                ((bool[]) buf[46])[0] = rslt.getBool(41);
                ((DateTime[]) buf[47])[0] = rslt.getGXDateTime(42, true);
                ((bool[]) buf[48])[0] = rslt.wasNull(42);
                ((DateTime[]) buf[49])[0] = rslt.getGXDateTime(43);
                ((bool[]) buf[50])[0] = rslt.wasNull(43);
                ((DateTime[]) buf[51])[0] = rslt.getGXDateTime(44);
                ((bool[]) buf[52])[0] = rslt.wasNull(44);
                ((string[]) buf[53])[0] = rslt.getString(45, 40);
                ((bool[]) buf[54])[0] = rslt.wasNull(45);
                ((string[]) buf[55])[0] = rslt.getVarchar(46);
                ((bool[]) buf[56])[0] = rslt.wasNull(46);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(47);
                ((bool[]) buf[58])[0] = rslt.wasNull(47);
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
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((bool[]) buf[24])[0] = rslt.getBool(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getString(21, 40);
                ((bool[]) buf[32])[0] = rslt.wasNull(21);
                ((string[]) buf[33])[0] = rslt.getVarchar(22);
                ((bool[]) buf[34])[0] = rslt.wasNull(22);
                return;
             case 2 :
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
             case 3 :
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
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((bool[]) buf[24])[0] = rslt.wasNull(22);
                ((string[]) buf[25])[0] = rslt.getVarchar(23);
                ((int[]) buf[26])[0] = rslt.getInt(24);
                ((string[]) buf[27])[0] = rslt.getVarchar(25);
                ((short[]) buf[28])[0] = rslt.getShort(26);
                ((string[]) buf[29])[0] = rslt.getVarchar(27);
                ((string[]) buf[30])[0] = rslt.getVarchar(28);
                ((string[]) buf[31])[0] = rslt.getString(29, 40);
                ((bool[]) buf[32])[0] = rslt.wasNull(29);
                ((string[]) buf[33])[0] = rslt.getVarchar(30);
                ((bool[]) buf[34])[0] = rslt.wasNull(30);
                ((string[]) buf[35])[0] = rslt.getVarchar(31);
                ((string[]) buf[36])[0] = rslt.getLongVarchar(32);
                ((int[]) buf[37])[0] = rslt.getInt(33);
                ((int[]) buf[38])[0] = rslt.getInt(34);
                ((Guid[]) buf[39])[0] = rslt.getGuid(35);
                ((string[]) buf[40])[0] = rslt.getVarchar(36);
                ((short[]) buf[41])[0] = rslt.getShort(37);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(38);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(39);
                ((int[]) buf[44])[0] = rslt.getInt(40);
                ((bool[]) buf[45])[0] = rslt.wasNull(40);
                ((bool[]) buf[46])[0] = rslt.getBool(41);
                ((DateTime[]) buf[47])[0] = rslt.getGXDateTime(42, true);
                ((bool[]) buf[48])[0] = rslt.wasNull(42);
                ((DateTime[]) buf[49])[0] = rslt.getGXDateTime(43);
                ((bool[]) buf[50])[0] = rslt.wasNull(43);
                ((DateTime[]) buf[51])[0] = rslt.getGXDateTime(44);
                ((bool[]) buf[52])[0] = rslt.wasNull(44);
                ((string[]) buf[53])[0] = rslt.getString(45, 40);
                ((bool[]) buf[54])[0] = rslt.wasNull(45);
                ((string[]) buf[55])[0] = rslt.getVarchar(46);
                ((bool[]) buf[56])[0] = rslt.wasNull(46);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(47);
                ((bool[]) buf[58])[0] = rslt.wasNull(47);
                ((int[]) buf[59])[0] = rslt.getInt(48);
                ((bool[]) buf[60])[0] = rslt.wasNull(48);
                ((int[]) buf[61])[0] = rslt.getInt(49);
                ((bool[]) buf[62])[0] = rslt.wasNull(49);
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
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((bool[]) buf[24])[0] = rslt.getBool(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getString(21, 40);
                ((bool[]) buf[32])[0] = rslt.wasNull(21);
                ((string[]) buf[33])[0] = rslt.getVarchar(22);
                ((bool[]) buf[34])[0] = rslt.wasNull(22);
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
             case 6 :
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
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((bool[]) buf[24])[0] = rslt.getBool(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getString(21, 40);
                ((bool[]) buf[32])[0] = rslt.wasNull(21);
                ((string[]) buf[33])[0] = rslt.getVarchar(22);
                ((bool[]) buf[34])[0] = rslt.wasNull(22);
                return;
             case 7 :
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
             case 8 :
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
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((bool[]) buf[24])[0] = rslt.getBool(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getString(21, 40);
                ((bool[]) buf[32])[0] = rslt.wasNull(21);
                ((string[]) buf[33])[0] = rslt.getVarchar(22);
                ((bool[]) buf[34])[0] = rslt.wasNull(22);
                return;
             case 9 :
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
