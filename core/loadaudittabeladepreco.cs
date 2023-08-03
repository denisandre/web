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
   public class loadaudittabeladepreco : GXProcedure
   {
      public loadaudittabeladepreco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudittabeladepreco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_TppID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17TppID = aP2_TppID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_TppID ,
                                 string aP3_ActualMode )
      {
         loadaudittabeladepreco objloadaudittabeladepreco;
         objloadaudittabeladepreco = new loadaudittabeladepreco();
         objloadaudittabeladepreco.AV14SaveOldValues = aP0_SaveOldValues;
         objloadaudittabeladepreco.AV11AuditingObject = aP1_AuditingObject;
         objloadaudittabeladepreco.AV17TppID = aP2_TppID;
         objloadaudittabeladepreco.AV15ActualMode = aP3_ActualMode;
         objloadaudittabeladepreco.context.SetSubmitInitialConfig(context);
         objloadaudittabeladepreco.initialize();
         Submit( executePrivateCatch,objloadaudittabeladepreco);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadaudittabeladepreco)stateInfo).executePrivate();
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
         /* Using cursor P00742 */
         pr_default.execute(0, new Object[] {AV17TppID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A235TppID = P00742_A235TppID[0];
            A236TppCodigo = P00742_A236TppCodigo[0];
            A237TppNome = P00742_A237TppNome[0];
            A238TppInsData = P00742_A238TppInsData[0];
            A239TppInsHora = P00742_A239TppInsHora[0];
            A240TppInsDataHora = P00742_A240TppInsDataHora[0];
            A241TppInsUsuID = P00742_A241TppInsUsuID[0];
            n241TppInsUsuID = P00742_n241TppInsUsuID[0];
            A433TppInsUsuNome = P00742_A433TppInsUsuNome[0];
            n433TppInsUsuNome = P00742_n433TppInsUsuNome[0];
            A242TppUpdData = P00742_A242TppUpdData[0];
            n242TppUpdData = P00742_n242TppUpdData[0];
            A243TppUpdHora = P00742_A243TppUpdHora[0];
            n243TppUpdHora = P00742_n243TppUpdHora[0];
            A244TppUpdDataHora = P00742_A244TppUpdDataHora[0];
            n244TppUpdDataHora = P00742_n244TppUpdDataHora[0];
            A245TppUpdUsuID = P00742_A245TppUpdUsuID[0];
            n245TppUpdUsuID = P00742_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = P00742_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = P00742_n434TppUpdUsuNome[0];
            A246TppAtivo = P00742_A246TppAtivo[0];
            n246TppAtivo = P00742_n246TppAtivo[0];
            A602TppDel = P00742_A602TppDel[0];
            A603TppDelDataHora = P00742_A603TppDelDataHora[0];
            n603TppDelDataHora = P00742_n603TppDelDataHora[0];
            A604TppDelData = P00742_A604TppDelData[0];
            n604TppDelData = P00742_n604TppDelData[0];
            A605TppDelHora = P00742_A605TppDelHora[0];
            n605TppDelHora = P00742_n605TppDelHora[0];
            A606TppDelUsuId = P00742_A606TppDelUsuId[0];
            n606TppDelUsuId = P00742_n606TppDelUsuId[0];
            A607TppDelUsuNome = P00742_A607TppDelUsuNome[0];
            n607TppDelUsuNome = P00742_n607TppDelUsuNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_tabeladepreco";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A235TppID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppCodigo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A236TppCodigo;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A237TppNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A238TppInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A241TppInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A433TppInsUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A242TppUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado por";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A245TppUpdUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A434TppUpdUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativa";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A246TppAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A602TppDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A603TppDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A604TppDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A605TppDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A606TppDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A607TppDelUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Using cursor P00743 */
            pr_default.execute(1, new Object[] {A235TppID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A220PrdID = P00743_A220PrdID[0];
               A221PrdCodigo = P00743_A221PrdCodigo[0];
               A222PrdNome = P00743_A222PrdNome[0];
               A232PrdTipoID = P00743_A232PrdTipoID[0];
               A231PrdAtivo = P00743_A231PrdAtivo[0];
               A247Tpp1Preco = P00743_A247Tpp1Preco[0];
               A608Tpp1Del = P00743_A608Tpp1Del[0];
               A609Tpp1DelDataHora = P00743_A609Tpp1DelDataHora[0];
               n609Tpp1DelDataHora = P00743_n609Tpp1DelDataHora[0];
               A610Tpp1DelData = P00743_A610Tpp1DelData[0];
               n610Tpp1DelData = P00743_n610Tpp1DelData[0];
               A611Tpp1DelHora = P00743_A611Tpp1DelHora[0];
               n611Tpp1DelHora = P00743_n611Tpp1DelHora[0];
               A612Tpp1DelUsuId = P00743_A612Tpp1DelUsuId[0];
               n612Tpp1DelUsuId = P00743_n612Tpp1DelUsuId[0];
               A613Tpp1DelUsuNome = P00743_A613Tpp1DelUsuNome[0];
               n613Tpp1DelUsuNome = P00743_n613Tpp1DelUsuNome[0];
               A231PrdAtivo = P00743_A231PrdAtivo[0];
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_tabeladepreco_produto";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto ou Serviço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A220PrdID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdCodigo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A221PrdCodigo;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A222PrdNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo Produto/Serviço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A231PrdAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1Preco";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A247Tpp1Preco, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1Del";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A608Tpp1Del);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A610Tpp1DelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A611Tpp1DelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A612Tpp1DelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A613Tpp1DelUsuNome;
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
         /* Using cursor P00745 */
         pr_default.execute(2, new Object[] {AV17TppID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A235TppID = P00745_A235TppID[0];
            A236TppCodigo = P00745_A236TppCodigo[0];
            A237TppNome = P00745_A237TppNome[0];
            A238TppInsData = P00745_A238TppInsData[0];
            A239TppInsHora = P00745_A239TppInsHora[0];
            A240TppInsDataHora = P00745_A240TppInsDataHora[0];
            A241TppInsUsuID = P00745_A241TppInsUsuID[0];
            n241TppInsUsuID = P00745_n241TppInsUsuID[0];
            A433TppInsUsuNome = P00745_A433TppInsUsuNome[0];
            n433TppInsUsuNome = P00745_n433TppInsUsuNome[0];
            A242TppUpdData = P00745_A242TppUpdData[0];
            n242TppUpdData = P00745_n242TppUpdData[0];
            A243TppUpdHora = P00745_A243TppUpdHora[0];
            n243TppUpdHora = P00745_n243TppUpdHora[0];
            A244TppUpdDataHora = P00745_A244TppUpdDataHora[0];
            n244TppUpdDataHora = P00745_n244TppUpdDataHora[0];
            A245TppUpdUsuID = P00745_A245TppUpdUsuID[0];
            n245TppUpdUsuID = P00745_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = P00745_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = P00745_n434TppUpdUsuNome[0];
            A246TppAtivo = P00745_A246TppAtivo[0];
            n246TppAtivo = P00745_n246TppAtivo[0];
            A602TppDel = P00745_A602TppDel[0];
            A603TppDelDataHora = P00745_A603TppDelDataHora[0];
            n603TppDelDataHora = P00745_n603TppDelDataHora[0];
            A604TppDelData = P00745_A604TppDelData[0];
            n604TppDelData = P00745_n604TppDelData[0];
            A605TppDelHora = P00745_A605TppDelHora[0];
            n605TppDelHora = P00745_n605TppDelHora[0];
            A606TppDelUsuId = P00745_A606TppDelUsuId[0];
            n606TppDelUsuId = P00745_n606TppDelUsuId[0];
            A607TppDelUsuNome = P00745_A607TppDelUsuNome[0];
            n607TppDelUsuNome = P00745_n607TppDelUsuNome[0];
            A40000GXC1 = P00745_A40000GXC1[0];
            n40000GXC1 = P00745_n40000GXC1[0];
            A40000GXC1 = P00745_A40000GXC1[0];
            n40000GXC1 = P00745_n40000GXC1[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_tabeladepreco";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A235TppID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppCodigo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A236TppCodigo;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A237TppNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A238TppInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A241TppInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A433TppInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A242TppUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Alterado por";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A245TppUpdUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppUpdUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A434TppUpdUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativa";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A246TppAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A602TppDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A603TppDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A604TppDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A605TppDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A606TppDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "TppDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A607TppDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               /* Using cursor P00746 */
               pr_default.execute(3, new Object[] {A235TppID});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A220PrdID = P00746_A220PrdID[0];
                  A221PrdCodigo = P00746_A221PrdCodigo[0];
                  A222PrdNome = P00746_A222PrdNome[0];
                  A232PrdTipoID = P00746_A232PrdTipoID[0];
                  A231PrdAtivo = P00746_A231PrdAtivo[0];
                  A247Tpp1Preco = P00746_A247Tpp1Preco[0];
                  A608Tpp1Del = P00746_A608Tpp1Del[0];
                  A609Tpp1DelDataHora = P00746_A609Tpp1DelDataHora[0];
                  n609Tpp1DelDataHora = P00746_n609Tpp1DelDataHora[0];
                  A610Tpp1DelData = P00746_A610Tpp1DelData[0];
                  n610Tpp1DelData = P00746_n610Tpp1DelData[0];
                  A611Tpp1DelHora = P00746_A611Tpp1DelHora[0];
                  n611Tpp1DelHora = P00746_n611Tpp1DelHora[0];
                  A612Tpp1DelUsuId = P00746_A612Tpp1DelUsuId[0];
                  n612Tpp1DelUsuId = P00746_n612Tpp1DelUsuId[0];
                  A613Tpp1DelUsuNome = P00746_A613Tpp1DelUsuNome[0];
                  n613Tpp1DelUsuNome = P00746_n613Tpp1DelUsuNome[0];
                  A231PrdAtivo = P00746_A231PrdAtivo[0];
                  AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                  AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_tabeladepreco_produto";
                  AV12AuditingObjectRecordItem.gxTpr_Mode = "INS";
                  AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Produto ou Serviço";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A220PrdID.ToString();
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdCodigo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A221PrdCodigo;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A222PrdNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo Produto/Serviço";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdAtivo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A231PrdAtivo);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1Preco";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Preço";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A247Tpp1Preco, 16, 2);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1Del";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A608Tpp1Del);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A610Tpp1DelData, 10, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A611Tpp1DelHora, 0, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelUsuId";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A612Tpp1DelUsuId;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Tpp1DelUsuNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A613Tpp1DelUsuNome;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22CountUpdatedPrdID = 0;
               AV29GXV1 = 1;
               while ( AV29GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV29GXV1));
                  if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_tabeladepreco") == 0 )
                  {
                     AV30GXV2 = 1;
                     while ( AV30GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV30GXV2));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A235TppID.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppCodigo") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A236TppCodigo;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A237TppNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppInsData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A238TppInsData, 2, "/");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppInsHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppInsDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppInsUsuID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A241TppInsUsuID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppInsUsuNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A433TppInsUsuNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppUpdData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A242TppUpdData, 2, "/");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppUpdHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppUpdDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppUpdUsuID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A245TppUpdUsuID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppUpdUsuNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A434TppUpdUsuNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppAtivo") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A246TppAtivo);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppDel") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A602TppDel);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppDelDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A603TppDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppDelData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A604TppDelData, 10, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppDelHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A605TppDelHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppDelUsuId") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A606TppDelUsuId;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "TppDelUsuNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A607TppDelUsuNome;
                        }
                        AV30GXV2 = (int)(AV30GXV2+1);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_tabeladepreco_produto") == 0 )
                  {
                     AV21CountKeyAttributes = 0;
                     AV31GXV3 = 1;
                     while ( AV31GXV3 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV31GXV3));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdID") == 0 )
                        {
                           AV23KeyPrdID = StringUtil.StrToGuid( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue);
                           AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                           if ( AV21CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV31GXV3 = (int)(AV31GXV3+1);
                     }
                     AV32GXLvl663 = 0;
                     /* Using cursor P00747 */
                     pr_default.execute(4, new Object[] {A235TppID, AV23KeyPrdID});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A220PrdID = P00747_A220PrdID[0];
                        A221PrdCodigo = P00747_A221PrdCodigo[0];
                        A222PrdNome = P00747_A222PrdNome[0];
                        A232PrdTipoID = P00747_A232PrdTipoID[0];
                        A231PrdAtivo = P00747_A231PrdAtivo[0];
                        A247Tpp1Preco = P00747_A247Tpp1Preco[0];
                        A608Tpp1Del = P00747_A608Tpp1Del[0];
                        A609Tpp1DelDataHora = P00747_A609Tpp1DelDataHora[0];
                        n609Tpp1DelDataHora = P00747_n609Tpp1DelDataHora[0];
                        A610Tpp1DelData = P00747_A610Tpp1DelData[0];
                        n610Tpp1DelData = P00747_n610Tpp1DelData[0];
                        A611Tpp1DelHora = P00747_A611Tpp1DelHora[0];
                        n611Tpp1DelHora = P00747_n611Tpp1DelHora[0];
                        A612Tpp1DelUsuId = P00747_A612Tpp1DelUsuId[0];
                        n612Tpp1DelUsuId = P00747_n612Tpp1DelUsuId[0];
                        A613Tpp1DelUsuNome = P00747_A613Tpp1DelUsuNome[0];
                        n613Tpp1DelUsuNome = P00747_n613Tpp1DelUsuNome[0];
                        A231PrdAtivo = P00747_A231PrdAtivo[0];
                        AV32GXLvl663 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV22CountUpdatedPrdID = (short)(AV22CountUpdatedPrdID+1);
                        AV33GXV4 = 1;
                        while ( AV33GXV4 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV33GXV4));
                           if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A220PrdID.ToString();
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdCodigo") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A221PrdCodigo;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A222PrdNome;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdTipoID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdAtivo") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A231PrdAtivo);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1Preco") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A247Tpp1Preco, 16, 2);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1Del") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A608Tpp1Del);
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1DelDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1DelData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A610Tpp1DelData, 10, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1DelHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A611Tpp1DelHora, 0, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1DelUsuId") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A612Tpp1DelUsuId;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Tpp1DelUsuNome") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A613Tpp1DelUsuNome;
                           }
                           AV33GXV4 = (int)(AV33GXV4+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(4);
                     if ( AV32GXLvl663 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  AV29GXV1 = (int)(AV29GXV1+1);
               }
               if ( AV22CountUpdatedPrdID < A40000GXC1 )
               {
                  AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P00748 */
                  pr_default.execute(5, new Object[] {AV17TppID});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A235TppID = P00748_A235TppID[0];
                     A220PrdID = P00748_A220PrdID[0];
                     A221PrdCodigo = P00748_A221PrdCodigo[0];
                     A222PrdNome = P00748_A222PrdNome[0];
                     A232PrdTipoID = P00748_A232PrdTipoID[0];
                     A231PrdAtivo = P00748_A231PrdAtivo[0];
                     A247Tpp1Preco = P00748_A247Tpp1Preco[0];
                     A608Tpp1Del = P00748_A608Tpp1Del[0];
                     A609Tpp1DelDataHora = P00748_A609Tpp1DelDataHora[0];
                     n609Tpp1DelDataHora = P00748_n609Tpp1DelDataHora[0];
                     A610Tpp1DelData = P00748_A610Tpp1DelData[0];
                     n610Tpp1DelData = P00748_n610Tpp1DelData[0];
                     A611Tpp1DelHora = P00748_A611Tpp1DelHora[0];
                     n611Tpp1DelHora = P00748_n611Tpp1DelHora[0];
                     A612Tpp1DelUsuId = P00748_A612Tpp1DelUsuId[0];
                     n612Tpp1DelUsuId = P00748_n612Tpp1DelUsuId[0];
                     A613Tpp1DelUsuNome = P00748_A613Tpp1DelUsuNome[0];
                     n613Tpp1DelUsuNome = P00748_n613Tpp1DelUsuNome[0];
                     A231PrdAtivo = P00748_A231PrdAtivo[0];
                     AV23KeyPrdID = A220PrdID;
                     AV24RecordExistsPrdID = false;
                     AV35GXV5 = 1;
                     while ( AV35GXV5 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV35GXV5));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_tabeladepreco_produto") == 0 )
                        {
                           AV21CountKeyAttributes = 0;
                           AV36GXV6 = 1;
                           while ( AV36GXV6 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV36GXV6));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdID") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( AV23KeyPrdID.ToString())) == 0 )
                                 {
                                    AV24RecordExistsPrdID = true;
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
                     if ( ! ( AV24RecordExistsPrdID ) )
                     {
                        AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                        AV19AuditingObjectRecordItemNew.gxTpr_Tablename = "tb_tabeladepreco_produto";
                        AV19AuditingObjectRecordItemNew.gxTpr_Mode = "INS";
                        AV18AuditingObjectNewRecords.gxTpr_Record.Add(AV19AuditingObjectRecordItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "PrdID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Produto ou Serviço";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A220PrdID.ToString();
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "PrdCodigo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Código";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A221PrdCodigo;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "PrdNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Descrição";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A222PrdNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "PrdTipoID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Tipo Produto/Serviço";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "PrdAtivo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Ativo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A231PrdAtivo);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1Preco";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Preço";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( A247Tpp1Preco, 16, 2);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1Del";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Registro Excluído";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A608Tpp1Del);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1DelDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1DelData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A610Tpp1DelData, 10, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1DelHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Hora de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A611Tpp1DelHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1DelUsuId";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário ID de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A612Tpp1DelUsuId;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "Tpp1DelUsuNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Nome do Usuário de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A613Tpp1DelUsuNome;
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
         P00742_A235TppID = new Guid[] {Guid.Empty} ;
         P00742_A236TppCodigo = new string[] {""} ;
         P00742_A237TppNome = new string[] {""} ;
         P00742_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P00742_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         P00742_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00742_A241TppInsUsuID = new string[] {""} ;
         P00742_n241TppInsUsuID = new bool[] {false} ;
         P00742_A433TppInsUsuNome = new string[] {""} ;
         P00742_n433TppInsUsuNome = new bool[] {false} ;
         P00742_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         P00742_n242TppUpdData = new bool[] {false} ;
         P00742_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00742_n243TppUpdHora = new bool[] {false} ;
         P00742_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00742_n244TppUpdDataHora = new bool[] {false} ;
         P00742_A245TppUpdUsuID = new string[] {""} ;
         P00742_n245TppUpdUsuID = new bool[] {false} ;
         P00742_A434TppUpdUsuNome = new string[] {""} ;
         P00742_n434TppUpdUsuNome = new bool[] {false} ;
         P00742_A246TppAtivo = new bool[] {false} ;
         P00742_n246TppAtivo = new bool[] {false} ;
         P00742_A602TppDel = new bool[] {false} ;
         P00742_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00742_n603TppDelDataHora = new bool[] {false} ;
         P00742_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         P00742_n604TppDelData = new bool[] {false} ;
         P00742_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         P00742_n605TppDelHora = new bool[] {false} ;
         P00742_A606TppDelUsuId = new string[] {""} ;
         P00742_n606TppDelUsuId = new bool[] {false} ;
         P00742_A607TppDelUsuNome = new string[] {""} ;
         P00742_n607TppDelUsuNome = new bool[] {false} ;
         A235TppID = Guid.Empty;
         A236TppCodigo = "";
         A237TppNome = "";
         A238TppInsData = DateTime.MinValue;
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A241TppInsUsuID = "";
         A433TppInsUsuNome = "";
         A242TppUpdData = DateTime.MinValue;
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         A245TppUpdUsuID = "";
         A434TppUpdUsuNome = "";
         A603TppDelDataHora = (DateTime)(DateTime.MinValue);
         A604TppDelData = (DateTime)(DateTime.MinValue);
         A605TppDelHora = (DateTime)(DateTime.MinValue);
         A606TppDelUsuId = "";
         A607TppDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00743_A235TppID = new Guid[] {Guid.Empty} ;
         P00743_A220PrdID = new Guid[] {Guid.Empty} ;
         P00743_A221PrdCodigo = new string[] {""} ;
         P00743_A222PrdNome = new string[] {""} ;
         P00743_A232PrdTipoID = new int[1] ;
         P00743_A231PrdAtivo = new bool[] {false} ;
         P00743_A247Tpp1Preco = new decimal[1] ;
         P00743_A608Tpp1Del = new bool[] {false} ;
         P00743_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00743_n609Tpp1DelDataHora = new bool[] {false} ;
         P00743_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         P00743_n610Tpp1DelData = new bool[] {false} ;
         P00743_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         P00743_n611Tpp1DelHora = new bool[] {false} ;
         P00743_A612Tpp1DelUsuId = new string[] {""} ;
         P00743_n612Tpp1DelUsuId = new bool[] {false} ;
         P00743_A613Tpp1DelUsuNome = new string[] {""} ;
         P00743_n613Tpp1DelUsuNome = new bool[] {false} ;
         A220PrdID = Guid.Empty;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         A610Tpp1DelData = (DateTime)(DateTime.MinValue);
         A611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         A612Tpp1DelUsuId = "";
         A613Tpp1DelUsuNome = "";
         P00745_A235TppID = new Guid[] {Guid.Empty} ;
         P00745_A236TppCodigo = new string[] {""} ;
         P00745_A237TppNome = new string[] {""} ;
         P00745_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P00745_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         P00745_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00745_A241TppInsUsuID = new string[] {""} ;
         P00745_n241TppInsUsuID = new bool[] {false} ;
         P00745_A433TppInsUsuNome = new string[] {""} ;
         P00745_n433TppInsUsuNome = new bool[] {false} ;
         P00745_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         P00745_n242TppUpdData = new bool[] {false} ;
         P00745_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00745_n243TppUpdHora = new bool[] {false} ;
         P00745_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00745_n244TppUpdDataHora = new bool[] {false} ;
         P00745_A245TppUpdUsuID = new string[] {""} ;
         P00745_n245TppUpdUsuID = new bool[] {false} ;
         P00745_A434TppUpdUsuNome = new string[] {""} ;
         P00745_n434TppUpdUsuNome = new bool[] {false} ;
         P00745_A246TppAtivo = new bool[] {false} ;
         P00745_n246TppAtivo = new bool[] {false} ;
         P00745_A602TppDel = new bool[] {false} ;
         P00745_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00745_n603TppDelDataHora = new bool[] {false} ;
         P00745_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         P00745_n604TppDelData = new bool[] {false} ;
         P00745_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         P00745_n605TppDelHora = new bool[] {false} ;
         P00745_A606TppDelUsuId = new string[] {""} ;
         P00745_n606TppDelUsuId = new bool[] {false} ;
         P00745_A607TppDelUsuNome = new string[] {""} ;
         P00745_n607TppDelUsuNome = new bool[] {false} ;
         P00745_A40000GXC1 = new int[1] ;
         P00745_n40000GXC1 = new bool[] {false} ;
         P00746_A235TppID = new Guid[] {Guid.Empty} ;
         P00746_A220PrdID = new Guid[] {Guid.Empty} ;
         P00746_A221PrdCodigo = new string[] {""} ;
         P00746_A222PrdNome = new string[] {""} ;
         P00746_A232PrdTipoID = new int[1] ;
         P00746_A231PrdAtivo = new bool[] {false} ;
         P00746_A247Tpp1Preco = new decimal[1] ;
         P00746_A608Tpp1Del = new bool[] {false} ;
         P00746_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00746_n609Tpp1DelDataHora = new bool[] {false} ;
         P00746_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         P00746_n610Tpp1DelData = new bool[] {false} ;
         P00746_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         P00746_n611Tpp1DelHora = new bool[] {false} ;
         P00746_A612Tpp1DelUsuId = new string[] {""} ;
         P00746_n612Tpp1DelUsuId = new bool[] {false} ;
         P00746_A613Tpp1DelUsuNome = new string[] {""} ;
         P00746_n613Tpp1DelUsuNome = new bool[] {false} ;
         AV23KeyPrdID = Guid.Empty;
         P00747_A235TppID = new Guid[] {Guid.Empty} ;
         P00747_A220PrdID = new Guid[] {Guid.Empty} ;
         P00747_A221PrdCodigo = new string[] {""} ;
         P00747_A222PrdNome = new string[] {""} ;
         P00747_A232PrdTipoID = new int[1] ;
         P00747_A231PrdAtivo = new bool[] {false} ;
         P00747_A247Tpp1Preco = new decimal[1] ;
         P00747_A608Tpp1Del = new bool[] {false} ;
         P00747_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00747_n609Tpp1DelDataHora = new bool[] {false} ;
         P00747_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         P00747_n610Tpp1DelData = new bool[] {false} ;
         P00747_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         P00747_n611Tpp1DelHora = new bool[] {false} ;
         P00747_A612Tpp1DelUsuId = new string[] {""} ;
         P00747_n612Tpp1DelUsuId = new bool[] {false} ;
         P00747_A613Tpp1DelUsuNome = new string[] {""} ;
         P00747_n613Tpp1DelUsuNome = new bool[] {false} ;
         AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         P00748_A235TppID = new Guid[] {Guid.Empty} ;
         P00748_A220PrdID = new Guid[] {Guid.Empty} ;
         P00748_A221PrdCodigo = new string[] {""} ;
         P00748_A222PrdNome = new string[] {""} ;
         P00748_A232PrdTipoID = new int[1] ;
         P00748_A231PrdAtivo = new bool[] {false} ;
         P00748_A247Tpp1Preco = new decimal[1] ;
         P00748_A608Tpp1Del = new bool[] {false} ;
         P00748_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00748_n609Tpp1DelDataHora = new bool[] {false} ;
         P00748_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         P00748_n610Tpp1DelData = new bool[] {false} ;
         P00748_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         P00748_n611Tpp1DelHora = new bool[] {false} ;
         P00748_A612Tpp1DelUsuId = new string[] {""} ;
         P00748_n612Tpp1DelUsuId = new bool[] {false} ;
         P00748_A613Tpp1DelUsuNome = new string[] {""} ;
         P00748_n613Tpp1DelUsuNome = new bool[] {false} ;
         AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadaudittabeladepreco__default(),
            new Object[][] {
                new Object[] {
               P00742_A235TppID, P00742_A236TppCodigo, P00742_A237TppNome, P00742_A238TppInsData, P00742_A239TppInsHora, P00742_A240TppInsDataHora, P00742_A241TppInsUsuID, P00742_n241TppInsUsuID, P00742_A433TppInsUsuNome, P00742_n433TppInsUsuNome,
               P00742_A242TppUpdData, P00742_n242TppUpdData, P00742_A243TppUpdHora, P00742_n243TppUpdHora, P00742_A244TppUpdDataHora, P00742_n244TppUpdDataHora, P00742_A245TppUpdUsuID, P00742_n245TppUpdUsuID, P00742_A434TppUpdUsuNome, P00742_n434TppUpdUsuNome,
               P00742_A246TppAtivo, P00742_n246TppAtivo, P00742_A602TppDel, P00742_A603TppDelDataHora, P00742_n603TppDelDataHora, P00742_A604TppDelData, P00742_n604TppDelData, P00742_A605TppDelHora, P00742_n605TppDelHora, P00742_A606TppDelUsuId,
               P00742_n606TppDelUsuId, P00742_A607TppDelUsuNome, P00742_n607TppDelUsuNome
               }
               , new Object[] {
               P00743_A235TppID, P00743_A220PrdID, P00743_A221PrdCodigo, P00743_A222PrdNome, P00743_A232PrdTipoID, P00743_A231PrdAtivo, P00743_A247Tpp1Preco, P00743_A608Tpp1Del, P00743_A609Tpp1DelDataHora, P00743_n609Tpp1DelDataHora,
               P00743_A610Tpp1DelData, P00743_n610Tpp1DelData, P00743_A611Tpp1DelHora, P00743_n611Tpp1DelHora, P00743_A612Tpp1DelUsuId, P00743_n612Tpp1DelUsuId, P00743_A613Tpp1DelUsuNome, P00743_n613Tpp1DelUsuNome
               }
               , new Object[] {
               P00745_A235TppID, P00745_A236TppCodigo, P00745_A237TppNome, P00745_A238TppInsData, P00745_A239TppInsHora, P00745_A240TppInsDataHora, P00745_A241TppInsUsuID, P00745_n241TppInsUsuID, P00745_A433TppInsUsuNome, P00745_n433TppInsUsuNome,
               P00745_A242TppUpdData, P00745_n242TppUpdData, P00745_A243TppUpdHora, P00745_n243TppUpdHora, P00745_A244TppUpdDataHora, P00745_n244TppUpdDataHora, P00745_A245TppUpdUsuID, P00745_n245TppUpdUsuID, P00745_A434TppUpdUsuNome, P00745_n434TppUpdUsuNome,
               P00745_A246TppAtivo, P00745_n246TppAtivo, P00745_A602TppDel, P00745_A603TppDelDataHora, P00745_n603TppDelDataHora, P00745_A604TppDelData, P00745_n604TppDelData, P00745_A605TppDelHora, P00745_n605TppDelHora, P00745_A606TppDelUsuId,
               P00745_n606TppDelUsuId, P00745_A607TppDelUsuNome, P00745_n607TppDelUsuNome, P00745_A40000GXC1, P00745_n40000GXC1
               }
               , new Object[] {
               P00746_A235TppID, P00746_A220PrdID, P00746_A221PrdCodigo, P00746_A222PrdNome, P00746_A232PrdTipoID, P00746_A231PrdAtivo, P00746_A247Tpp1Preco, P00746_A608Tpp1Del, P00746_A609Tpp1DelDataHora, P00746_n609Tpp1DelDataHora,
               P00746_A610Tpp1DelData, P00746_n610Tpp1DelData, P00746_A611Tpp1DelHora, P00746_n611Tpp1DelHora, P00746_A612Tpp1DelUsuId, P00746_n612Tpp1DelUsuId, P00746_A613Tpp1DelUsuNome, P00746_n613Tpp1DelUsuNome
               }
               , new Object[] {
               P00747_A235TppID, P00747_A220PrdID, P00747_A221PrdCodigo, P00747_A222PrdNome, P00747_A232PrdTipoID, P00747_A231PrdAtivo, P00747_A247Tpp1Preco, P00747_A608Tpp1Del, P00747_A609Tpp1DelDataHora, P00747_n609Tpp1DelDataHora,
               P00747_A610Tpp1DelData, P00747_n610Tpp1DelData, P00747_A611Tpp1DelHora, P00747_n611Tpp1DelHora, P00747_A612Tpp1DelUsuId, P00747_n612Tpp1DelUsuId, P00747_A613Tpp1DelUsuNome, P00747_n613Tpp1DelUsuNome
               }
               , new Object[] {
               P00748_A235TppID, P00748_A220PrdID, P00748_A221PrdCodigo, P00748_A222PrdNome, P00748_A232PrdTipoID, P00748_A231PrdAtivo, P00748_A247Tpp1Preco, P00748_A608Tpp1Del, P00748_A609Tpp1DelDataHora, P00748_n609Tpp1DelDataHora,
               P00748_A610Tpp1DelData, P00748_n610Tpp1DelData, P00748_A611Tpp1DelHora, P00748_n611Tpp1DelHora, P00748_A612Tpp1DelUsuId, P00748_n612Tpp1DelUsuId, P00748_A613Tpp1DelUsuNome, P00748_n613Tpp1DelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22CountUpdatedPrdID ;
      private short AV21CountKeyAttributes ;
      private short AV32GXLvl663 ;
      private int A232PrdTipoID ;
      private int A40000GXC1 ;
      private int AV29GXV1 ;
      private int AV30GXV2 ;
      private int AV31GXV3 ;
      private int AV33GXV4 ;
      private int AV35GXV5 ;
      private int AV36GXV6 ;
      private int AV37GXV7 ;
      private decimal A247Tpp1Preco ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A241TppInsUsuID ;
      private string A245TppUpdUsuID ;
      private string A606TppDelUsuId ;
      private string A612Tpp1DelUsuId ;
      private DateTime A239TppInsHora ;
      private DateTime A240TppInsDataHora ;
      private DateTime A243TppUpdHora ;
      private DateTime A244TppUpdDataHora ;
      private DateTime A603TppDelDataHora ;
      private DateTime A604TppDelData ;
      private DateTime A605TppDelHora ;
      private DateTime A609Tpp1DelDataHora ;
      private DateTime A610Tpp1DelData ;
      private DateTime A611Tpp1DelHora ;
      private DateTime A238TppInsData ;
      private DateTime A242TppUpdData ;
      private bool returnInSub ;
      private bool n241TppInsUsuID ;
      private bool n433TppInsUsuNome ;
      private bool n242TppUpdData ;
      private bool n243TppUpdHora ;
      private bool n244TppUpdDataHora ;
      private bool n245TppUpdUsuID ;
      private bool n434TppUpdUsuNome ;
      private bool A246TppAtivo ;
      private bool n246TppAtivo ;
      private bool A602TppDel ;
      private bool n603TppDelDataHora ;
      private bool n604TppDelData ;
      private bool n605TppDelHora ;
      private bool n606TppDelUsuId ;
      private bool n607TppDelUsuNome ;
      private bool A231PrdAtivo ;
      private bool A608Tpp1Del ;
      private bool n609Tpp1DelDataHora ;
      private bool n610Tpp1DelData ;
      private bool n611Tpp1DelHora ;
      private bool n612Tpp1DelUsuId ;
      private bool n613Tpp1DelUsuNome ;
      private bool n40000GXC1 ;
      private bool AV24RecordExistsPrdID ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string A433TppInsUsuNome ;
      private string A434TppUpdUsuNome ;
      private string A607TppDelUsuNome ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A613Tpp1DelUsuNome ;
      private Guid AV17TppID ;
      private Guid A235TppID ;
      private Guid A220PrdID ;
      private Guid AV23KeyPrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00742_A235TppID ;
      private string[] P00742_A236TppCodigo ;
      private string[] P00742_A237TppNome ;
      private DateTime[] P00742_A238TppInsData ;
      private DateTime[] P00742_A239TppInsHora ;
      private DateTime[] P00742_A240TppInsDataHora ;
      private string[] P00742_A241TppInsUsuID ;
      private bool[] P00742_n241TppInsUsuID ;
      private string[] P00742_A433TppInsUsuNome ;
      private bool[] P00742_n433TppInsUsuNome ;
      private DateTime[] P00742_A242TppUpdData ;
      private bool[] P00742_n242TppUpdData ;
      private DateTime[] P00742_A243TppUpdHora ;
      private bool[] P00742_n243TppUpdHora ;
      private DateTime[] P00742_A244TppUpdDataHora ;
      private bool[] P00742_n244TppUpdDataHora ;
      private string[] P00742_A245TppUpdUsuID ;
      private bool[] P00742_n245TppUpdUsuID ;
      private string[] P00742_A434TppUpdUsuNome ;
      private bool[] P00742_n434TppUpdUsuNome ;
      private bool[] P00742_A246TppAtivo ;
      private bool[] P00742_n246TppAtivo ;
      private bool[] P00742_A602TppDel ;
      private DateTime[] P00742_A603TppDelDataHora ;
      private bool[] P00742_n603TppDelDataHora ;
      private DateTime[] P00742_A604TppDelData ;
      private bool[] P00742_n604TppDelData ;
      private DateTime[] P00742_A605TppDelHora ;
      private bool[] P00742_n605TppDelHora ;
      private string[] P00742_A606TppDelUsuId ;
      private bool[] P00742_n606TppDelUsuId ;
      private string[] P00742_A607TppDelUsuNome ;
      private bool[] P00742_n607TppDelUsuNome ;
      private Guid[] P00743_A235TppID ;
      private Guid[] P00743_A220PrdID ;
      private string[] P00743_A221PrdCodigo ;
      private string[] P00743_A222PrdNome ;
      private int[] P00743_A232PrdTipoID ;
      private bool[] P00743_A231PrdAtivo ;
      private decimal[] P00743_A247Tpp1Preco ;
      private bool[] P00743_A608Tpp1Del ;
      private DateTime[] P00743_A609Tpp1DelDataHora ;
      private bool[] P00743_n609Tpp1DelDataHora ;
      private DateTime[] P00743_A610Tpp1DelData ;
      private bool[] P00743_n610Tpp1DelData ;
      private DateTime[] P00743_A611Tpp1DelHora ;
      private bool[] P00743_n611Tpp1DelHora ;
      private string[] P00743_A612Tpp1DelUsuId ;
      private bool[] P00743_n612Tpp1DelUsuId ;
      private string[] P00743_A613Tpp1DelUsuNome ;
      private bool[] P00743_n613Tpp1DelUsuNome ;
      private Guid[] P00745_A235TppID ;
      private string[] P00745_A236TppCodigo ;
      private string[] P00745_A237TppNome ;
      private DateTime[] P00745_A238TppInsData ;
      private DateTime[] P00745_A239TppInsHora ;
      private DateTime[] P00745_A240TppInsDataHora ;
      private string[] P00745_A241TppInsUsuID ;
      private bool[] P00745_n241TppInsUsuID ;
      private string[] P00745_A433TppInsUsuNome ;
      private bool[] P00745_n433TppInsUsuNome ;
      private DateTime[] P00745_A242TppUpdData ;
      private bool[] P00745_n242TppUpdData ;
      private DateTime[] P00745_A243TppUpdHora ;
      private bool[] P00745_n243TppUpdHora ;
      private DateTime[] P00745_A244TppUpdDataHora ;
      private bool[] P00745_n244TppUpdDataHora ;
      private string[] P00745_A245TppUpdUsuID ;
      private bool[] P00745_n245TppUpdUsuID ;
      private string[] P00745_A434TppUpdUsuNome ;
      private bool[] P00745_n434TppUpdUsuNome ;
      private bool[] P00745_A246TppAtivo ;
      private bool[] P00745_n246TppAtivo ;
      private bool[] P00745_A602TppDel ;
      private DateTime[] P00745_A603TppDelDataHora ;
      private bool[] P00745_n603TppDelDataHora ;
      private DateTime[] P00745_A604TppDelData ;
      private bool[] P00745_n604TppDelData ;
      private DateTime[] P00745_A605TppDelHora ;
      private bool[] P00745_n605TppDelHora ;
      private string[] P00745_A606TppDelUsuId ;
      private bool[] P00745_n606TppDelUsuId ;
      private string[] P00745_A607TppDelUsuNome ;
      private bool[] P00745_n607TppDelUsuNome ;
      private int[] P00745_A40000GXC1 ;
      private bool[] P00745_n40000GXC1 ;
      private Guid[] P00746_A235TppID ;
      private Guid[] P00746_A220PrdID ;
      private string[] P00746_A221PrdCodigo ;
      private string[] P00746_A222PrdNome ;
      private int[] P00746_A232PrdTipoID ;
      private bool[] P00746_A231PrdAtivo ;
      private decimal[] P00746_A247Tpp1Preco ;
      private bool[] P00746_A608Tpp1Del ;
      private DateTime[] P00746_A609Tpp1DelDataHora ;
      private bool[] P00746_n609Tpp1DelDataHora ;
      private DateTime[] P00746_A610Tpp1DelData ;
      private bool[] P00746_n610Tpp1DelData ;
      private DateTime[] P00746_A611Tpp1DelHora ;
      private bool[] P00746_n611Tpp1DelHora ;
      private string[] P00746_A612Tpp1DelUsuId ;
      private bool[] P00746_n612Tpp1DelUsuId ;
      private string[] P00746_A613Tpp1DelUsuNome ;
      private bool[] P00746_n613Tpp1DelUsuNome ;
      private Guid[] P00747_A235TppID ;
      private Guid[] P00747_A220PrdID ;
      private string[] P00747_A221PrdCodigo ;
      private string[] P00747_A222PrdNome ;
      private int[] P00747_A232PrdTipoID ;
      private bool[] P00747_A231PrdAtivo ;
      private decimal[] P00747_A247Tpp1Preco ;
      private bool[] P00747_A608Tpp1Del ;
      private DateTime[] P00747_A609Tpp1DelDataHora ;
      private bool[] P00747_n609Tpp1DelDataHora ;
      private DateTime[] P00747_A610Tpp1DelData ;
      private bool[] P00747_n610Tpp1DelData ;
      private DateTime[] P00747_A611Tpp1DelHora ;
      private bool[] P00747_n611Tpp1DelHora ;
      private string[] P00747_A612Tpp1DelUsuId ;
      private bool[] P00747_n612Tpp1DelUsuId ;
      private string[] P00747_A613Tpp1DelUsuNome ;
      private bool[] P00747_n613Tpp1DelUsuNome ;
      private Guid[] P00748_A235TppID ;
      private Guid[] P00748_A220PrdID ;
      private string[] P00748_A221PrdCodigo ;
      private string[] P00748_A222PrdNome ;
      private int[] P00748_A232PrdTipoID ;
      private bool[] P00748_A231PrdAtivo ;
      private decimal[] P00748_A247Tpp1Preco ;
      private bool[] P00748_A608Tpp1Del ;
      private DateTime[] P00748_A609Tpp1DelDataHora ;
      private bool[] P00748_n609Tpp1DelDataHora ;
      private DateTime[] P00748_A610Tpp1DelData ;
      private bool[] P00748_n610Tpp1DelData ;
      private DateTime[] P00748_A611Tpp1DelHora ;
      private bool[] P00748_n611Tpp1DelHora ;
      private string[] P00748_A612Tpp1DelUsuId ;
      private bool[] P00748_n612Tpp1DelUsuId ;
      private string[] P00748_A613Tpp1DelUsuNome ;
      private bool[] P00748_n613Tpp1DelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV18AuditingObjectNewRecords ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV19AuditingObjectRecordItemNew ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV20AuditingObjectRecordItemAttributeItemNew ;
   }

   public class loadaudittabeladepreco__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00742;
          prmP00742 = new Object[] {
          new ParDef("AV17TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00743;
          prmP00743 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00745;
          prmP00745 = new Object[] {
          new ParDef("AV17TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00746;
          prmP00746 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00747;
          prmP00747 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV23KeyPrdID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00748;
          prmP00748 = new Object[] {
          new ParDef("AV17TppID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00742", "SELECT TppID, TppCodigo, TppNome, TppInsData, TppInsHora, TppInsDataHora, TppInsUsuID, TppInsUsuNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome FROM tb_tabeladepreco WHERE TppID = :AV17TppID ORDER BY TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00742,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00743", "SELECT T1.TppID, T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID ORDER BY T1.TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00743,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00745", "SELECT T1.TppID, T1.TppCodigo, T1.TppNome, T1.TppInsData, T1.TppInsHora, T1.TppInsDataHora, T1.TppInsUsuID, T1.TppInsUsuNome, T1.TppUpdData, T1.TppUpdHora, T1.TppUpdDataHora, T1.TppUpdUsuID, T1.TppUpdUsuNome, T1.TppAtivo, T1.TppDel, T1.TppDelDataHora, T1.TppDelData, T1.TppDelHora, T1.TppDelUsuId, T1.TppDelUsuNome, COALESCE( T2.GXC1, 0) AS GXC1 FROM tb_tabeladepreco T1,  (SELECT COUNT(*) AS GXC1 FROM tb_tabeladepreco_produto WHERE TppID = :AV17TppID ) T2 WHERE T1.TppID = :AV17TppID ORDER BY T1.TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00745,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00746", "SELECT T1.TppID, T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID ORDER BY T1.TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00746,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00747", "SELECT T1.TppID, T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID and T1.PrdID = :AV23KeyPrdID ORDER BY T1.TppID, T1.PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00747,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00748", "SELECT T1.TppID, T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :AV17TppID ORDER BY T1.TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00748,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11, true);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((bool[]) buf[20])[0] = rslt.getBool(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((bool[]) buf[22])[0] = rslt.getBool(15);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16, true);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((string[]) buf[29])[0] = rslt.getString(19, 40);
                ((bool[]) buf[30])[0] = rslt.wasNull(19);
                ((string[]) buf[31])[0] = rslt.getVarchar(20);
                ((bool[]) buf[32])[0] = rslt.wasNull(20);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11, true);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((bool[]) buf[20])[0] = rslt.getBool(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((bool[]) buf[22])[0] = rslt.getBool(15);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16, true);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((string[]) buf[29])[0] = rslt.getString(19, 40);
                ((bool[]) buf[30])[0] = rslt.wasNull(19);
                ((string[]) buf[31])[0] = rslt.getVarchar(20);
                ((bool[]) buf[32])[0] = rslt.wasNull(20);
                ((int[]) buf[33])[0] = rslt.getInt(21);
                ((bool[]) buf[34])[0] = rslt.wasNull(21);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
